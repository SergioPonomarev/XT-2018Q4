using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.SqlDAL
{
    public class SqlImagesDao : IImagesDao
    {
        private readonly string conStr;

        public SqlImagesDao(string connectionString)
        {
            this.conStr = connectionString;
        }

        public Image GetBannedImage()
        {
            throw new NotImplementedException();
        }
    }
}
