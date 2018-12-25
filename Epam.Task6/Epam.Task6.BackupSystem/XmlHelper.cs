using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Epam.Task6.BackupSystem
{
    public static class XmlHelper
    {
        private static XmlSerializer serializer;

        static XmlHelper()
        {
            serializer = new XmlSerializer(typeof(List<LogDao>));
        }

        public static void SaveToXml(List<LogDao> logDaos, FileStream fs)
        {
            if (logDaos != null)
            {
                fs.SetLength(0);

                serializer.Serialize(fs, logDaos);
            }
        }

        public static List<LogDao> GetAll(FileStream fs, out int maxIndex, int capacityIfCreate = 1)
        {
            List<LogDao> logDaos;

            if (fs.Length > 0)
            {
                logDaos = (List<LogDao>)serializer.Deserialize(fs);

                maxIndex = logDaos.Max(x => x.FileIndex);
            }
            else
            {
                logDaos = new List<LogDao>(capacityIfCreate);

                maxIndex = 0;
            }

            return logDaos;
        }

        public static List<LogDao> GetNeeded(DateTime dateForRollback, FileStream fs)
        {
            List<LogDao> orderedAllLogDaos = GetAll(fs)
                                            .OrderByDescending(x => x.Date)
                                            .ToList();

            DateTime startDate = orderedAllLogDaos.Last().Date;

            dateForRollback = startDate < dateForRollback
                ? dateForRollback
                : startDate;

            var grouping = orderedAllLogDaos.GroupBy(x => x.Path);

            List<LogDao> actualLogDaos = new List<LogDao>(grouping.Count());

            foreach (IGrouping<string, LogDao> groupByPath in grouping)
            {
                LogDao logDao = groupByPath.FirstOrDefault(x => x.Date <= dateForRollback);

                if (logDao != null && logDao.ChangeType != WatcherChangeTypes.Deleted)
                {
                    actualLogDaos.Add(logDao);
                }
            }

            return actualLogDaos;
        }

        private static List<LogDao> GetAll(FileStream fs)
        {
            if (fs.Length > 0)
            {
                return (List<LogDao>)serializer.Deserialize(fs);
            }

            return new List<LogDao>();
        }
    }
}
