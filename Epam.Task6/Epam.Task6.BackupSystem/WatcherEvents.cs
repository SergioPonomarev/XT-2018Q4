using System;
using System.IO;

namespace Epam.Task6.BackupSystem
{
    public static class WatcherEvents
    {
        public static void OnDirectoryDelete(object sender, FileSystemEventArgs e)
        {
            WatchingLogic.DirectoryDelete(e.FullPath);
        }

        public static void OnDirectoryRename(object sender, RenamedEventArgs e)
        {
            WatchingLogic.RecursiveDirectoryRename(e.FullPath, e.OldFullPath);
        }

        public static void OnFileChange(object sender, FileSystemEventArgs e)
        {
            WatchingLogic.Change(e.FullPath, e.ChangeType);
        }

        public static void OnFileRename(object sender, RenamedEventArgs e)
        {
            WatchingLogic.Change(e.FullPath, WatcherChangeTypes.Created);

            WatchingLogic.Change(e.OldFullPath, WatcherChangeTypes.Deleted);
        }
    }
}
