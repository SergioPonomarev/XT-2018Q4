using System;
using System.Collections.Generic;
using System.Configuration;

namespace Epam.Task6.BackupSystem
{
    public static class Config
    {
        static Config()
        {
            BackupDirectory = ConfigurationManager.AppSettings["backupDirectory"];
            WatchingDirectory = ConfigurationManager.AppSettings["watchingDirectory"];
            LogFileName = ConfigurationManager.AppSettings["logFile"];
            FilesInWork = new List<KeyValuePair<string, string>>();
        }

        public static string DateFormat => "yyyy.MM.dd_HH-mm-ss";

        public static string BackupDirectory { get; set; }

        public static string WatchingDirectory { get; set; }

        public static string LogFileName { get; set; }

        public static Dictionary<string, string> CurrentFiles { get; set; }

        public static List<KeyValuePair<string, string>> FilesInWork { get; set; }
    }
}
