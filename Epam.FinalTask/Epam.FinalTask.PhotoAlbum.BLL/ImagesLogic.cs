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
            image.Likes = new List<int>();
            return this.imagesDao.Add(image);
        }

        public void AddLikeToImage(Image image, int visitorId)
        {
            this.imagesDao.AddLikeToImage(image, visitorId);
        }

        public Image GetBannedImage()
        {
            return this.imagesDao.GetBannedImage();
        }

        public Image GetImageById(int imageId)
        {
            return this.imagesDao.GetImageById(imageId);
        }

        public void RemoveLikeFromImage(Image image, int visitorId)
        {
            this.imagesDao.RemoveLikeFromImage(image, visitorId);
        }

        public void SetBannedImage(Image image)
        {
            this.imagesDao.SetBannedImage(image);
        }
    }
}
