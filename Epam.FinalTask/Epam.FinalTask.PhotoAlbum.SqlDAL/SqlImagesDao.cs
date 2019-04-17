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

        public bool Add(Image image)
        {
            throw new NotImplementedException();
        }

        public void AddLikeToImage(Image image, int visitorId)
        {
            throw new NotImplementedException();
        }

        public void BanImage(Image image)
        {
            throw new NotImplementedException();
        }

        public Image GetBannedImage()
        {
            throw new NotImplementedException();
        }

        public Image GetImageById(int imageId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetUserImages(int userId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Image image)
        {
            throw new NotImplementedException();
        }

        public void RemoveLikeFromImage(Image image, int visitorId)
        {
            throw new NotImplementedException();
        }

        public void SetBannedImage(Image image)
        {
            throw new NotImplementedException();
        }

        public void UnbanImage(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
