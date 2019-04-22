using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.BLL.Contracts
{
    public interface IImagesLogic
    {
        Image GetBannedImage();

        Image GetImageById(int imageId);

        bool Add(Image image);

        bool SetBannedImage(Image image);

        void AddLikeToImage(Image image, int visitorId);

        void RemoveLikeFromImage(Image image, int visitorId);

        void BanImage(Image image);

        void UnbanImage(Image image);

        void Remove(Image image);

        IEnumerable<Image> GetAllImages();

        IEnumerable<int> GetLikesForImage(int imageId);
    }
}
