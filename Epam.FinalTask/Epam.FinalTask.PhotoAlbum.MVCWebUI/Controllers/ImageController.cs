using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.WebPages;
using Epam.FinalTask.PhotoAlbum.Entities;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;

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
                        imageModel.ImageData = imageBanned.ImageData;
                    }

                    imageModels.Add(imageModel);
                }

                return this.PartialView(imageModels);
            }
            catch (Exception)
            {
                return this.View("~/Views/Shared/Error.cshtml");
            }
        }

        [Authorize]
        public ActionResult UploadImage()
        {
            return this.View();
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
                            return this.RedirectToAction("UserPage", "User", new { userName = user.UserName });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Uploading image error.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Uploading image error.");
                    }
                }

                return this.View(model);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult ImagePage(int imageId)
        {
            try
            {
                ImageModel image = dr.ImagesLogic.GetImageById(imageId);
                if (image == null)
                {
                    return new HttpNotFoundResult();
                }

                UserModel user = dr.UsersLogic.GetUserById(image.ImageOwnerId);

                if (user == null)
                {
                    return new HttpNotFoundResult();
                }

                AvatarModel avatar = dr.AvatarsLogic.GetUserAvatar(user.UserAvatarId);

                if (avatar == null)
                {
                    return new HttpNotFoundResult();
                }

                ImageModel bannedImage = dr.ImagesLogic.GetBannedImage();

                if (bannedImage == null)
                {
                    return new HttpNotFoundResult();
                }

                List<int> likes = dr.ImagesLogic.GetLikesForImage(image.ImageId).ToList();

                if (User.Identity.IsAuthenticated)
                {
                    UserModel visitor = dr.UsersLogic.GetUserByUserName(User.Identity.Name);

                    if (visitor == null)
                    {
                        return new HttpNotFoundResult();
                    }

                    ViewBag.Visitor = visitor;

                    bool liked = likes.Contains(visitor.UserId);

                    ViewBag.Liked = liked;
                }

                ViewBag.Owner = user;
                ViewBag.Avatar = avatar;
                ViewBag.BannedImage = bannedImage;
                ViewBag.Likes = likes;

                return this.View(image);
            }
            catch (Exception)
            {
                return new HttpNotFoundResult();
            }
        }

        [HttpPost]
        [Authorize]
        public void BanImage(int imageId)
        {
            try
            {
                Image image = dr.ImagesLogic.GetImageById(imageId);

                if (image == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                User owner = dr.UsersLogic.GetUserById(image.ImageOwnerId);

                if (owner == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if ((User.IsInRole("Admins") && owner.UserRole == "User") || User.IsInRole("SuperAdmins"))
                {
                    if (!dr.ImagesLogic.BanImage(image))
                    {
                        Response.SetStatus(HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Authorize]
        public void UnbanImage(int imageId)
        {
            try
            {
                Image image = dr.ImagesLogic.GetImageById(imageId);

                if (image == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                User owner = dr.UsersLogic.GetUserById(image.ImageOwnerId);

                if (owner == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if ((User.IsInRole("Admins") && owner.UserRole == "User") || User.IsInRole("SuperAdmins"))
                {
                    if (!dr.ImagesLogic.UnbanImage(image))
                    {
                        Response.SetStatus(HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Authorize]
        public void LikeImage(int imageId, int visitorId)
        {
            try
            {
                Image image = dr.ImagesLogic.GetImageById(imageId);

                if (image == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                User user = dr.UsersLogic.GetUserById(visitorId);

                if (user == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if (!dr.ImagesLogic.AddLikeToImage(image, user.UserId))
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Authorize]
        public void UnlikeImage(int imageId, int visitorId)
        {
            try
            {
                Image image = dr.ImagesLogic.GetImageById(imageId);

                if (image == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                User user = dr.UsersLogic.GetUserById(visitorId);

                if (user == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if (!dr.ImagesLogic.RemoveLikeFromImage(image, user.UserId))
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Authorize]
        public void DeleteImage(int imageId)
        {
            try
            {
                Image image = dr.ImagesLogic.GetImageById(imageId);

                if (image == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                User user = dr.UsersLogic.GetUserById(image.ImageOwnerId);

                if (user == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if (User.Identity.Name == user.UserName)
                {
                    if (!dr.ImagesLogic.Remove(image))
                    {
                        Response.SetStatus(HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
            }
        }
    }
}