using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.SqlDAL
{
    public class SqlAvatarsDao : IAvatarsDao
    {
        private readonly string conStr;

        public SqlAvatarsDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public Avatar GetUserAvatarByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public void SetDefaultAvatar(Avatar avatar)
        {
            throw new NotImplementedException();
        }
    }
}
