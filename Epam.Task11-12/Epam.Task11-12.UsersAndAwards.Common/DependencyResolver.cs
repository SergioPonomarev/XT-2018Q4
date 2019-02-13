using System;
using System.Configuration;
using Epam.Task11_12.UsersAndAwards.BLL;
using Epam.Task11_12.UsersAndAwards.BLL.Interfaces;
using Epam.Task11_12.UsersAndAwards.DAL.Interfaces;
using Epam.Task11_12.UsersAndAwards.SqlDAL;

namespace Epam.Task11_12.UsersAndAwards.Common
{
    public class DependencyResolver
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["UsersAndAwardsDB"].ConnectionString;

        private static ICacheLogic cacheLogic;
        private static IUsersDao usersDao;
        private static IUsersLogic usersLogic;
        private static IAwardsDao awardsDao;
        private static IAwardsLogic awardsLogic;
        private static IAwardsUsersDao awardsUsersDao;
        private static IAwardsUsersLogic awardsUsersLogic;
        private static IAccountsLogic accountsLogic;
        private static IAccountsDao accountsDao;

        public static IUsersDao UsersDao
        {
            get
            {
                if (usersDao == null)
                {
                    var key = ConfigurationManager.AppSettings["UsersDaoKey"];

                    switch (key.ToLower())
                    {
                        case "sqldb":
                            usersDao = new SqlUsersDao(conStr);
                            break;

                        default:
                            break;
                    }
                }

                return usersDao;
            }
        }

        public static IAwardsDao AwardsDao
        {
            get
            {
                if (awardsDao == null)
                {
                    var key = ConfigurationManager.AppSettings["AwardsDaoKey"];

                    switch (key.ToLower())
                    {
                        case "sqldb":
                            awardsDao = new SqlAwardsDao(conStr);
                            break;

                        default:
                            break;
                    }
                }

                return awardsDao;
            }
        }

        public static IAwardsUsersDao AwardsUsersDao
        {
            get
            {
                if (awardsUsersDao == null)
                {
                    var key = ConfigurationManager.AppSettings["AwardsUsersDaoKey"];

                    switch (key.ToLower())
                    {
                        case "sqldb":
                            awardsUsersDao = new SqlAwardsUsersDao(conStr);
                            break;

                        default:
                            break;
                    }
                }

                return awardsUsersDao;
            }
        }

        public static IAccountsDao AccountsDao
        {
            get
            {
                if (accountsDao == null)
                {
                    var key = ConfigurationManager.AppSettings["AccountsDaoKey"];

                    switch (key.ToLower())
                    {
                        case "sqldb":
                            accountsDao = new SqlAccountsDao(conStr);
                            break;

                        default:
                            break;
                    }
                }

                return accountsDao;
            }
        }

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());

        public static IUsersLogic UsersLogic => usersLogic ?? (usersLogic = new UsersLogic(UsersDao, CacheLogic));

        public static IAwardsLogic AwardsLogic => awardsLogic ?? (awardsLogic = new AwardsLogic(AwardsDao, CacheLogic));

        public static IAwardsUsersLogic AwardsUsersLogic => awardsUsersLogic ?? (awardsUsersLogic = new AwardsUsersLogic(AwardsUsersDao, CacheLogic, UsersLogic, AwardsLogic));

        public static IAccountsLogic AccountsLogic => accountsLogic ?? (accountsLogic = new AccountsLogic(AccountsDao, UsersLogic, CacheLogic));
    }
}
