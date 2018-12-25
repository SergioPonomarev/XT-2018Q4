using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Epam.Task6.BackupSystem
{
    public static class BackupLogic
    {
        public static DateTime GetDateForBackup(string inputDate)
        {
            return DateTime.ParseExact(inputDate + "-00", Config.DateFormat, CultureInfo.InvariantCulture);
        }

        public static void ClearDirectory(string directory)
        {
            DirectoryInfo watchingDirectory = new DirectoryInfo(directory);

            foreach (FileInfo file in watchingDirectory.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in watchingDirectory.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static void GetBackToChosenDate(DateTime dateForBackup)
        {
            using (FileStream fs = new FileStream(Config.LogFileName, FileMode.OpenOrCreate))
            {
                List<LogDao> files = XmlHelper.GetNeeded(dateForBackup, fs);

                foreach (var logDao in files)
                {
                    string dir = Path.GetDirectoryName(logDao.Path);

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    File.Copy(Path.Combine(Config.BackupDirectory, $"{logDao.FileIndex}"), logDao.Path);
                }
            }
        }
    }
}
