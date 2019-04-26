using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.DAL.Contracts
{
    public interface IImagesDao
    {
        Image GetBannedImage();

        Image GetImageById(int imageId);

        bool Add(Image image);

        bool SetBannedImage(Image image);

        IEnumerable<Image> GetUserImages(int userId);

        bool AddLikeToImage(Image image, int userId);

        bool RemoveLikeFromImage(Image image, int userId);

        bool BanImage(Image image);

        bool UnbanImage(Image image);

        bool Remove(Image image);

        IEnumerable<Image> GetAllImages();

        IEnumerable<int> GetLikesForImage(int imageId);
    }
}
