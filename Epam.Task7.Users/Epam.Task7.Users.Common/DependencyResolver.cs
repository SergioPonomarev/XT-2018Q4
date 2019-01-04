using Epam.Task7.Users.BLL;
using Epam.Task7.Users.BLL.Interfaces;
using Epam.Task7.Users.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.Common
{
    public class DependencyResolver
    {
        private static IUsersDao usersDao;

        private static IUsersDao UsersDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["UsersDaoKey"];

                if (usersDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "testfile":
                            {
                                usersDao = new TextFileDAL.UsersDao();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return usersDao;
            }
        }

        private static IUsersLogic usersLogic;

        public static IUsersLogic UsersLogic => usersLogic ?? (usersLogic = new UsersLogic(UsersDao));
    }
}
