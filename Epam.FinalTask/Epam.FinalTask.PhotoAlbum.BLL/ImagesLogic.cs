using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.BLL.Contracts;
using Epam.FinalTask.PhotoAlbum.DAL.Contracts;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.BLL
{
    public class ImagesLogic : IImagesLogic
    {
        private readonly IImagesDao imagesDao;

        public ImagesLogic(IImagesDao imagesDao)
        {
            this.imagesDao = imagesDao;
        }

        public bool Add(Image image)
        {
            image.Banned = false;
            image.ImageDateOfUpload = DateTime.Now;
            return this.imagesDao.Add(image);
        }

        public bool AddLikeToImage(Image image, int userId)
        {
            return this.imagesDao.AddLikeToImage(image, userId);
        }

        public bool BanImage(Image image)
        {
            return this.imagesDao.BanImage(image);
        }

        public IEnumerable<Image> GetAllImages()
        {
            try
            {
                return this.imagesDao.GetAllImages().ToArray();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public Image GetBannedImage()
        {
            try
            {
                return this.imagesDao.GetBannedImage();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public Image GetImageById(int imageId)
        {
            try
            {
                return this.imagesDao.GetImageById(imageId);
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public IEnumerable<int> GetLikesForImage(int imageId)
        {
            try
            {
                return this.imagesDao.GetLikesForImage(imageId).ToArray();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Remove(Image image)
        {
            return this.imagesDao.Remove(image);
        }

        public bool RemoveLikeFromImage(Image image, int userId)
        {
            return this.imagesDao.RemoveLikeFromImage(image, userId);
        }

        public bool SetBannedImage(Image image)
        {
            image.ImageDateOfUpload = DateTime.Now;
            return this.imagesDao.SetBannedImage(image);
        }

        public bool UnbanImage(Image image)
        {
            return this.imagesDao.UnbanImage(image);
        }
    }
}
