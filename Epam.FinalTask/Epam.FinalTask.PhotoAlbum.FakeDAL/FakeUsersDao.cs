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
                }
            };

            id++;
        }

        public User GetUserByUserName(string userName)
        {
            return this.users.FirstOrDefault(u => u.UserName == userName);
        }

        public bool Add(User user)
        {
            try
            {
                user.UserId = id++;
                user.UserRole = defaultRole;

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
    }
}
