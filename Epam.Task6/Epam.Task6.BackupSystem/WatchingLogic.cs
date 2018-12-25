using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Epam.Task6.BackupSystem
{
    public static class WatchingLogic
    {
        public static IEnumerable<FileInfo> GetAllFiles()
        {
            DirectoryInfo dirToWatch = new DirectoryInfo(Config.WatchingDirectory);

            IEnumerable<FileInfo> files = dirToWatch.EnumerateFiles("*", SearchOption.AllDirectories);

            return files;
        }

        public static Dictionary<string, string> GetCurrentFilesHashes(IEnumerable<FileInfo> files)
        {
            Dictionary<string, string> currentFilesHashes = new Dictionary<string, string>();

            string hash = null;

            foreach (FileInfo file in files)
            {
                hash = GetHashCode(file.FullName);

                currentFilesHashes.Add(file.FullName, hash);
            }

            return currentFilesHashes;
        }

        public static void MakeFullDirectoryCopy()
        {
            IEnumerable<FileInfo> files = GetAllFiles();

            if (files.Count() == 0)
            {
                return;
            }

            using (FileStream fs = new FileStream(Config.LogFileName, FileMode.OpenOrCreate))
            {
                int index;

                List<LogDao> logList = XmlHelper.GetAll(fs, out index, files.Count());

                foreach (FileInfo file in files)
                {
                    logList.Add(new LogDao(++index, file.FullName, DateTime.Now, WatcherChangeTypes.Changed));

                    MakeCopy(file.FullName, index, Config.CurrentFiles[file.FullName]);
                }

                XmlHelper.SaveToXml(logList, fs);
            }
        }

        public static void Change(string fullPath, WatcherChangeTypes changeType)
        {
            while (true)
            {
                try
                {
                    string hash = null;

                    if (changeType != WatcherChangeTypes.Deleted)
                    {
                        hash = GetHashCode(fullPath);
                    }

                    if (Config.FilesInWork.Any(x => x.Key == fullPath && x.Value == hash))
                    {
                        return;
                    }

                    int index;

                    using (FileStream fs = new FileStream(Config.LogFileName, FileMode.OpenOrCreate))
                    {
                        List<LogDao> logList = XmlHelper.GetAll(fs, out index);

                        logList.Add(new LogDao(++index, fullPath, DateTime.Now, changeType));

                        XmlHelper.SaveToXml(logList, fs);
                    }

                    switch (changeType)
                    {
                        case WatcherChangeTypes.Changed:
                            if (hash != Config.CurrentFiles[fullPath])
                            {
                                Config.CurrentFiles[fullPath] = hash;
                                MakeCopy(fullPath, index, hash);
                            }

                            break;

                        case WatcherChangeTypes.Created:
                            Config.CurrentFiles.Add(fullPath, hash);
                            MakeCopy(fullPath, index, hash);
                            break;

                        case WatcherChangeTypes.Deleted:
                            Config.CurrentFiles.Remove(fullPath);
                            break;
                    }

                    break;
                }
                catch
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                }
            }
        }

        public static void DirectoryDelete(string directoryPath)
        {
            List<string> deletedFiles = Config.CurrentFiles
                .Where(x => x.Key.StartsWith(directoryPath))
                .Select(x => x.Key)
                .ToList();

            foreach (string deletedFile in deletedFiles)
            {
                Change(deletedFile, WatcherChangeTypes.Deleted);
            }
        }

        public static void RecursiveDirectoryRename(string newDirectoryPath, string oldDirectoryPath)
        {
            DirectoryInfo newDirectory = new DirectoryInfo(newDirectoryPath);

            IEnumerable<FileInfo> files = newDirectory.EnumerateFiles("*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo file in files)
            {
                string oldFullName = Path.Combine(oldDirectoryPath, file.Name);

                Change(oldFullName, WatcherChangeTypes.Deleted);

                Change(file.FullName, WatcherChangeTypes.Created);
            }

            IEnumerable<DirectoryInfo> directories = newDirectory.EnumerateDirectories("*", SearchOption.TopDirectoryOnly);

            foreach (DirectoryInfo directory in directories)
            {
                RecursiveDirectoryRename(Path.Combine(newDirectoryPath, directory.Name), Path.Combine(oldDirectoryPath, directory.Name));
            }
        }

        private static void MakeCopy(string filePath, int index, string md5)
        {
            Config.FilesInWork.Add(new KeyValuePair<string, string>(filePath, md5));

            Thread th = new Thread(() => Copy(filePath, index, md5));

            th.Start();
        }

        private static void Copy(string filePath, int index, string md5)
        {
            File.Copy(filePath, Path.Combine(Config.BackupDirectory, index.ToString()));

            if (Config.FilesInWork.Any(x => x.Key == filePath && x.Value == md5))
            {
                Config.FilesInWork.Remove(Config.FilesInWork.First(x => x.Key == filePath && x.Value == md5));
            }
        }

        private static string GetHashCode(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] byteHash = md5.ComputeHash(stream);
                    string hash = Encoding.Default.GetString(byteHash);
                    return hash;
                }
            }
        }
    }
}
