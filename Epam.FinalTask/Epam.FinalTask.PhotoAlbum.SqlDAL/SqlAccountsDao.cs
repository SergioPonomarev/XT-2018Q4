﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;

namespace Epam.FinalTask.PhotoAlbum.SqlDAL
{
    public class SqlAccountsDao : IAccountsDao
    {
        private readonly string conStr;

        public SqlAccountsDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public string GetPassByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public bool SetPassToUser(string userName, string hashedPass)
        {
            throw new NotImplementedException();
        }
    }
}