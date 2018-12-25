using System;
using System.IO;

namespace Epam.Task6.BackupSystem
{
    [Serializable]
    public class LogDao
    {
        public LogDao()
        {
        }

        public LogDao(int fileIndex, 
                      string path, 
                      DateTime date, 
                      WatcherChangeTypes changeType)
        {
            this.FileIndex = fileIndex;
            this.Path = path;
            this.Date = date;
            this.ChangeType = changeType;
        }

        public int FileIndex { get; set; }

        public DateTime Date { get; set; }

        public string Path { get; set; }

        public WatcherChangeTypes ChangeType { get; set; }
    }
}
