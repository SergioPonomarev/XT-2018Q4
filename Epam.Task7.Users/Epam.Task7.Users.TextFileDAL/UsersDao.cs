using Epam.Task7.Users.DAL.Interfaces;
using Epam.Task7.Users.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.TextFileDAL
{
    public class UsersDao : IUsersDao
    {
        private const string DateFormat = "yyyy-MM-dd";
        private const char Separator = '|';
        private readonly string maxIdFilePath;
        private readonly string usersFilePath;
        private int maxId;
        
        public UsersDao()
        {
            this.maxIdFilePath = ConfigurationManager.AppSettings["TextFileDALIdKey"];
            this.usersFilePath = ConfigurationManager.AppSettings["TextFileDALUsersKey"];

            try
            {
                maxId = int.Parse(File.ReadAllText(maxIdFilePath));
            }
            catch
            {
                this.maxId = 0;
            }
        }

        public void Add(User user)
        {
            user.Id = ++maxId;

            File.WriteAllText(maxIdFilePath, maxId.ToString());
            File.AppendAllLines(usersFilePath, new[] { UserSerialize(user) });
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return File.ReadAllLines(usersFilePath)
                    .Select(line =>
                    {
                        var parts = line.Split(new[] { Separator }, 3);
                        return new User
                        {
                            Id = int.Parse(parts[0]),
                            Name = parts[1],
                            DateOfBirth = DateTime.ParseExact(parts[1], DateFormat, CultureInfo.InvariantCulture),
                        };
                    });
            }
            catch
            {
                return Enumerable.Empty<User>();
            }
        }

        public bool Remove(int id)
        {
            var users = GetAll().ToList();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return false;
            }

            users.Remove(user);

            File.WriteAllLines(usersFilePath, users.Select(UserSerialize));

            return true;
        }

        public bool RemoveAll()
        {
            try
            {
                File.WriteAllText(usersFilePath, string.Empty);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string UserSerialize(User user)
        {
            return $"{user.Id}{Separator}{user.Name}{Separator}{user.DateOfBirth.ToShortDateString()}";
        }
    }
}
