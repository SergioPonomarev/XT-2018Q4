using System;
using System.Configuration;
using Epam.Task7.UsersAndAwards.BLL;
using Epam.Task7.UsersAndAwards.BLL.Interfaces;
using Epam.Task7.UsersAndAwards.DAL.Interfaces;
using Epam.Task7.UsersAndAwards.TextFileDAL;

namespace Epam.Task7.UsersAndAwards.Common
{
    public class DependencyResolver
    {
        private static IUsersDao usersDao;
        private static IUsersLogic usersLogic;
        private static ICacheLogic cacheLogic;

        public static IUsersDao UsersDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["UsersDaoKey"];

                if (usersDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "textfile":
                            {
                                usersDao = new UsersDao();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return usersDao;
            }
        }

        public static IUsersLogic UsersLogic => usersLogic ?? (usersLogic = new UsersLogic(UsersDao, CacheLogic));

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());
    }
}
