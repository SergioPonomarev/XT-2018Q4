using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.BLL;
using Epam.FinalTask.PhotoAlbum.BLL.Contracts;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.FakeDAL;
using Epam.FinalTask.PhotoAlbum.SqlDAL;

namespace Epam.FinalTask.PhotoAlbum.Common
{
    public class DependencyResolver
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["PhotoAlbumDB"].ConnectionString;

        private static IAccountsLogic accountsLogic;
        private static IAccountsDao accountsDao;
        private static IUsersLogic usersLogic;
        private static IUsersDao usersDao;

        private static IAccountsDao AccountsDao
        {
            get
            {
                if (accountsDao == null)
                {
                    string key = ConfigurationManager.AppSettings["AccountsDaoKey"];

                    switch (key.ToLower())
                    {
                        case "sqldb":
                            accountsDao = new SqlAccountsDao(conStr);
                            break;

                        case "fakedb":
                            accountsDao = new FakeAccountsDao();
                            break;

                        default:
                            break;
                    }
                }

                return accountsDao;
            }
        }

        private static IUsersDao UsersDao
        {
            get
            {
                if (usersDao == null)
                {
                    string key = ConfigurationManager.AppSettings["UsersDaoKey"];

                    switch (key.ToLower())
                    {
                        case "sqldb":
                            usersDao = new SqlUsersDao(conStr);
                            break;

                        case "fakedb":
                            usersDao = new FakeUsersDao();
                            break;

                        default:
                            break;
                    }
                }

                return usersDao;
            }
        }

        public static IAccountsLogic AccountsLogic => accountsLogic ?? (accountsLogic = new AccountsLogic(AccountsDao, UsersLogic));

        public static IUsersLogic UsersLogic => usersLogic ?? (usersLogic = new UsersLogic(UsersDao));
    }
}
