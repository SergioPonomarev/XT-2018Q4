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
        private static IAwardsDao awardsDao;
        private static IAwardsLogic awardsLogic;
        private static IUsersDao usersDao;
        private static IUsersLogic usersLogic;
        private static ICacheLogic cacheLogic;

        public static IAwardsDao AwardsDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["AwardsDaoKey"];

                if (awardsDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "textfile":
                            {
                                awardsDao = new AwardsDao();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return awardsDao;
            }
        }

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

        public static IAwardsLogic AwardsLogic => awardsLogic ?? (awardsLogic = new AwardsLogic(AwardsDao, CacheLogic));

        public static IUsersLogic UsersLogic => usersLogic ?? (usersLogic = new UsersLogic(UsersDao, CacheLogic));

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());
    }
}
