using System;
using System.Collections.Generic;
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

        public void AddLikeToImage(Image image, int userId)
        {
            this.imagesDao.AddLikeToImage(image, userId);
        }

        public void BanImage(Image image)
        {
            this.imagesDao.BanImage(image);
        }

        public IEnumerable<Image> GetAllImages()
        {
            return this.imagesDao.GetAllImages().ToArray();
        }

        public Image GetBannedImage()
        {
            return this.imagesDao.GetBannedImage();
        }

        public Image GetImageById(int imageId)
        {
            return this.imagesDao.GetImageById(imageId);
        }

        public IEnumerable<int> GetLikesForImage(int imageId)
        {
            return this.imagesDao.GetLikesForImage(imageId).ToArray();
        }

        public void Remove(Image image)
        {
            this.imagesDao.Remove(image);
        }

        public void RemoveLikeFromImage(Image image, int userId)
        {
            this.imagesDao.RemoveLikeFromImage(image, userId);
        }

        public bool SetBannedImage(Image image)
        {
            image.ImageDateOfUpload = DateTime.Now;
            return this.imagesDao.SetBannedImage(image);
        }

        public void UnbanImage(Image image)
        {
            this.imagesDao.UnbanImage(image);
        }
    }
}
