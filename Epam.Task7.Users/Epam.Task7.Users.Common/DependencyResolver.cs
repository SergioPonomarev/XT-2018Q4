using System;
using System.Configuration;
using Epam.Task7.Users.BLL;
using Epam.Task7.Users.BLL.Interfaces;
using Epam.Task7.Users.DAL.Interfaces;
using Epam.Task7.Users.TextFileDAL;

namespace Epam.Task7.Users.Common
{
    public static class DependencyResolver
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
