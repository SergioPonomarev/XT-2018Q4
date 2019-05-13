using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;
using Epam.FinalTask.PhotoAlbum.Entities;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using System.Net;
using System.Web.Helpers;

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
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [Authorize]
        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult UploadImage(UploadImageModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = dr.UsersLogic.GetUserByUserName(User.Identity.Name);

                    if (user != null)
                    {
                        ImageModel image = new ImageModel();

                        WebImage webImage = new WebImage(model.Image.InputStream);

                        webImage.Resize(width: 1000, height: 1000, preserveAspectRatio: true, preventEnlarge: true);

                        image.ImageOwnerId = user.UserId;

                        image.Description = model.Description;

                        image.MimeType = MimeMapping.GetMimeMapping(model.Image.FileName);

                        byte[] data = webImage.GetBytes(webImage.ImageFormat);

                        image.ImageData = Convert.ToBase64String(data);

                        if (dr.ImagesLogic.Add((Image)image))
                        {
                            return RedirectToAction("UserPage", "User", new { name = user.UserName });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Uploading image error.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Uploading image error.");
                    }
                }

                return View(model);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}