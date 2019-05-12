using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;
using Epam.FinalTask.PhotoAlbum.Entities;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using System.Net;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult GetImageList(int? userId)
        {
            try
            {
                IEnumerable<Image> images;
                List<ImageModel> imageModels = new List<ImageModel>();
                Image imageBanned = dr.ImagesLogic.GetBannedImage();

                if (userId == null)
                {
                    images = dr.ImagesLogic.GetAllImages();
                }
                else
                {
                    int id = (int)userId;
                    User user = dr.UsersLogic.GetUserById(id);
                    images = user.UserImages;
                }

                foreach (Image image in images)
                {
                    ImageModel imageModel = image;
                    if (imageModel.Banned)
                    {
                        imageModel.MimeType = imageBanned.MimeType;
                        imageModel.ImageData = imageModel.ImageData;
                    }

                    imageModels.Add(imageModel);
                }

                return PartialView(imageModels);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}