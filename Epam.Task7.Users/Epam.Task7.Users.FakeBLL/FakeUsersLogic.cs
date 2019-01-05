using System;
using System.Collections.Generic;
using System.Globalization;
using Epam.Task7.Users.BLL.Interfaces;
using Epam.Task7.Users.Entities;

namespace Epam.Task7.Users.FakeBLL
{
    public class FakeUsersLogic : IUsersLogic
    {
        private const string DateFormat = "yyyy-MM-dd";
        private readonly IDictionary<int, User> users;
        private int maxId;

        public FakeUsersLogic()
        {
            this.users = new Dictionary<int, User>();
        }

        public void Add(string userName, string userDateOfBirth)
        {
            DateTime dateOfBirth;

            try
            {
                dateOfBirth = DateTime.ParseExact(userDateOfBirth, DateFormat, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw;
            }

            if (DateTime.Now < dateOfBirth)
            {
                throw new ArgumentException("Inputed date of birth is greater than current date.");
            }

            User user = new User
            {
                Id = ++this.maxId,
                Name = userName,
                DateOfBirth = dateOfBirth,
            };

            this.users.Add(user.Id, user);
        }

        public bool Remove(int id)
        {
            return this.users.Remove(id);
        }

        public bool RemoveAll()
        {
            this.users.Clear();
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return this.users.Values;
        }
    }
}
