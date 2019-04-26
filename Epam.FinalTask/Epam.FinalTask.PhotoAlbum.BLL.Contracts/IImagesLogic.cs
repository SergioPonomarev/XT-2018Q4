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

        bool AddLikeToImage(Image image, int visitorId);

        bool RemoveLikeFromImage(Image image, int visitorId);

        bool BanImage(Image image);

        bool UnbanImage(Image image);

        bool Remove(Image image);

        IEnumerable<Image> GetAllImages();

        IEnumerable<int> GetLikesForImage(int imageId);
    }
}
