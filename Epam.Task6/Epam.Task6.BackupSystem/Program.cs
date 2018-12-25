using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Epam.Task6.BackupSystem
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Greetings! You are using Backup Program for .txt files.");
            Console.WriteLine();

            if (string.IsNullOrEmpty(Config.WatchingDirectory) ||
                string.IsNullOrEmpty(Config.BackupDirectory))
            {
                SetConfig();
            }

            while (true)
            {
                ShowMainMenu();
                string choice = MainMenuChoice();

                switch (choice)
                {
                    case "1":
                        FileSystemWatcher fileWatcher = new FileSystemWatcher(Config.WatchingDirectory, "*.txt")
                        {
                            EnableRaisingEvents = true,
                            IncludeSubdirectories = true,
                            NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size,
                        };

                        fileWatcher.Changed += WatcherEvents.OnFileChange;
                        fileWatcher.Created += WatcherEvents.OnFileChange;
                        fileWatcher.Deleted += WatcherEvents.OnFileChange;
                        fileWatcher.Renamed += WatcherEvents.OnFileRename;

                        FileSystemWatcher directoryWatcher = new FileSystemWatcher(Config.WatchingDirectory, "*.*")
                        {
                            EnableRaisingEvents = true,
                            IncludeSubdirectories = true,
                            NotifyFilter = NotifyFilters.DirectoryName,
                        };

                        directoryWatcher.Renamed += WatcherEvents.OnDirectoryRename;
                        directoryWatcher.Deleted += WatcherEvents.OnDirectoryDelete;

                        IEnumerable<FileInfo> files = WatchingLogic.GetAllFiles();
                        Config.CurrentFiles = WatchingLogic.GetCurrentFilesHashes(files);
                        WatchingLogic.MakeFullDirectoryCopy();

                        Console.WriteLine("The program is watching files in setted directory. Press Esc to stop it.");

                        while (Console.ReadKey().Key != ConsoleKey.Escape)
                        {
                            Thread.Yield();
                        }

                        fileWatcher.EnableRaisingEvents = false;
                        directoryWatcher.EnableRaisingEvents = false;
                        break;

                    case "2":
                        Console.WriteLine("Please enter the date and time to backup");
                        Console.Write("in format yyyy.MM.dd_HH-mm: ");

                        DateTime dateForBackUp;

                        try
                        {
                            dateForBackUp = BackupLogic.GetDateForBackup(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid date input.");
                            Console.WriteLine();
                            break;
                        }

                        BackupLogic.ClearDirectory(Config.WatchingDirectory);

                        try
                        {
                            BackupLogic.GetBackToChosenDate(dateForBackUp);
                        }
                        catch (DirectoryNotFoundException)
                        {
                            Console.WriteLine("Error. The backup directory was not found.");
                            Console.WriteLine("Choose 3rd Main menu item to set the path of observing directory.");
                            Console.WriteLine();
                            break;
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Error. The log file was not found.");
                            Console.WriteLine();
                            break;
                        }

                        break;

                    case "3":
                        Console.WriteLine("Press Enter if you want to clear the history and set new directory to watch.");
                        Console.WriteLine("Press any another key to get back to get back to Main menu.");

                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            try
                            {
                                BackupLogic.ClearDirectory(Config.BackupDirectory);
                            }
                            catch (DirectoryNotFoundException)
                            {
                                Console.WriteLine("Error. The backup directory was not found so there is nothing to clear.");
                                SetConfig();
                                break;
                            }

                            Console.WriteLine("All history was successfully cleared.");

                            SetConfig();
                        }

                        break;

                    case "4":
                        PrintConfig();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Wrong input.");
                        break;
                }
            }
        }

        private static void PrintConfig()
        {
            Console.WriteLine($"Watching directory: {Config.WatchingDirectory}");
            Console.WriteLine($"Backup directory: {Config.BackupDirectory}");
            Console.WriteLine($"Log file: {Config.LogFileName}");
            Console.WriteLine();
        }

        private static string MainMenuChoice()
        {
            return Console.ReadLine();
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Choose working mode:");
            Console.WriteLine("\t1 - Watching. The program will save a history of all changes in setted directory.");
            Console.WriteLine("\t2 - Backup. The program will return the setted directory state to any moment you choose.");
            Console.WriteLine("\t3 - Start anew. The program will clear all history and let you set new directory to watch.");
            Console.WriteLine("\t4 - Configuration. The program will print paths to watching directory, backup directory and log file.");
            Console.WriteLine("\t5 - Quit the program.");
            Console.Write("Enter your choice: ");
        }

        private static void SetConfig()
        {
            Console.WriteLine("Please set path of observing directory in format");
            Console.Write(@"'C:\Directory': ");

            Configuration currentConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string watchingPath = Console.ReadLine();
            currentConfig.AppSettings.Settings["watchingDirectory"].Value = watchingPath;

            DirectoryInfo backupDirectory = Directory.CreateDirectory(Path.Combine(watchingPath.Substring(0, watchingPath.LastIndexOf('\\')), "Backup"));
            currentConfig.AppSettings.Settings["backupDirectory"].Value = backupDirectory.FullName;

            FileInfo logFile = new FileInfo(Path.Combine(backupDirectory.FullName, "Log.xml"));
            currentConfig.AppSettings.Settings["logFile"].Value = logFile.FullName;

            Console.WriteLine();
        }
    }
}
