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
        private static IAvatarsLogic avatarsLogic;
        private static IAvatarsDao avatarsDao;
        private static IImagesLogic imagesLogic;
        private static IImagesDao imagesDao;
        private static ICommentsLogic commentsLogic;
        private static ICommentsDao commentsDao;

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
                            usersDao = new SqlUsersDao(conStr, ImagesDao);
                            break;

                        case "fakedb":
                            usersDao = new FakeUsersDao(ImagesDao);
                            break;

                        default:
                            break;
                    }
                }

                return usersDao;
            }
        }

        private static IAvatarsDao AvatarsDao
        {
            get
            {
                if (avatarsDao == null)
                {
                    string key = ConfigurationManager.AppSettings["AvatarsDaoKey"];

                    switch (key.ToLower())
                    {
                        case "sqldb":
                            avatarsDao = new SqlAvatarsDao(conStr);
                            break;

                        case "fakedb":
                            avatarsDao = new FakeAvatarsDao(UsersDao);
                            break;

                        default:
                            break;
                    }
                }

                return avatarsDao;
            }
        }

        private static IImagesDao ImagesDao
        {
            get
            {
                if (imagesDao == null)
                {
                    string key = ConfigurationManager.AppSettings["ImagesDaoKey"];

                    switch (key.ToLower())
                    {
                        case "sqldb":
                            imagesDao = new SqlImagesDao(conStr);
                            break;

                        case "fakedb":
                            imagesDao = new FakeImagesDao();
                            break;

                        default:
                            break;
                    }
                }

                return imagesDao;
            }
        }

        private static ICommentsDao CommentsDao
        {
            get
            {
                if (commentsDao == null)
                {
                    string key = ConfigurationManager.AppSettings["CommentsDaoKey"];

                    switch (key.ToLower())
                    {
                        case "sqldb":
                            commentsDao = new SqlCommentsDao(conStr);
                            break;

                        case "fakedb":
                            commentsDao = new FakeCommentsDao();
                            break;

                        default:
                            break;
                    }
                }

                return commentsDao;
            }
        }

        public static IAccountsLogic AccountsLogic => accountsLogic ?? (accountsLogic = new AccountsLogic(AccountsDao, UsersLogic));

        public static IUsersLogic UsersLogic => usersLogic ?? (usersLogic = new UsersLogic(UsersDao));

        public static IAvatarsLogic AvatarsLogic => avatarsLogic ?? (avatarsLogic = new AvatarsLogic(AvatarsDao));

        public static IImagesLogic ImagesLogic => imagesLogic ?? (imagesLogic = new ImagesLogic(ImagesDao));

        public static ICommentsLogic CommentsLogic => commentsLogic ?? (commentsLogic = new CommentsLogic(CommentsDao));
    }
}
