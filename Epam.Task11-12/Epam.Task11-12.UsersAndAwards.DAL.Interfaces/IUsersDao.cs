﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task11_12.UsersAndAwards.Entities;

namespace Epam.Task11_12.UsersAndAwards.DAL.Interfaces
{
    public interface IUsersDao
    {
        IEnumerable<User> GetAll();

        bool Add(User user);

        bool Update(int userId, string userName, DateTime userDateOfBirth);

        bool Remove(int userId);

        User GetUserById(int userId);
    }
}