using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.FakeDAL
{
    public class FakeUsersDao : IUsersDao
    {
        private static readonly string defaultRole = "User";
        private static readonly int defaultAvatarId = 1;

        private List<User> users;
        private static int id = 1;

        public FakeUsersDao()
        {
            this.users = new List<User>
            {
                new User()
                {
                    UserId = id,
                    UserName = "admin",
                    UserRole = "SuperAdmin",
                    UserAvatarId = 1,
                }
            };

            id++;
        }

        public User GetUserByUserName(string userName)
        {
            User user = this.users.FirstOrDefault(u => u.UserName == userName);

            if (user != null)
            {
                user.UserImages = Enumerable.Empty<Image>();
            }

            return user;
        }

        public bool Add(User user)
        {
            try
            {
                if (user.UserId == 0)
                {
                    user.UserId = id++;
                    user.UserRole = defaultRole;
                    user.UserAvatarId = defaultAvatarId;
                }

                this.users.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return this.users;
        }

        public bool RemoveUser(string userName)
        {
            return this.users.Remove(this.GetUserByUserName(userName));
        }
    }
}
