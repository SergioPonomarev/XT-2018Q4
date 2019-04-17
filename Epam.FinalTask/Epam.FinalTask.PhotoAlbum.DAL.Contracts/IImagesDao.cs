﻿using System;
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

        void SetBannedImage(Image image);

        IEnumerable<Image> GetUserImages(int userId);

        void AddLikeToImage(Image image, int visitorId);

        void RemoveLikeFromImage(Image image, int visitorId);

        void BanImage(Image image);

        void UnbanImage(Image image);

        void Remove(Image image);
    }
}
