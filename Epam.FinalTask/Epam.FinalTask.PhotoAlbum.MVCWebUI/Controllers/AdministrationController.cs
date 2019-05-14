using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using System.Net;
using System.Web.Helpers;
using Epam.FinalTask.PhotoAlbum.Entities;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Controllers
{
    public class AdministrationController : Controller
    {
        public ActionResult Manage(string avatarError, string avatarSuccess, string imageError, string imageSuccess)
        {
            if (!User.IsInRole("SuperAdmins"))
            {
                return new HttpNotFoundResult();
            }
            try
            {
                AvatarModel avatar = dr.AvatarsLogic.GetDefaultAvatar();
                ViewBag.Avatar = avatar;

                ImageModel image = dr.ImagesLogic.GetBannedImage();
                ViewBag.Image = image;

                if (avatarError != null)
                {
                    ViewBag.AvatarErrorMessage = avatarError;
                }

                if (avatarSuccess != null)
                {
                    ViewBag.AvatarSuccessMessage = avatarSuccess;
                }

                if (imageError != null)
                {
                    ViewBag.ImageErrorMessage = imageError;
                }

                if (imageSuccess != null)
                {
                    ViewBag.ImageSuccessMessage = imageSuccess;
                }

                return View();

            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult Manage(HttpPostedFileBase avatar, HttpPostedFileBase image)
        {
            string avatarSuccess = null;
            string avatarError = null;
            string imageSuccess = null;
            string imageError = null;

            if (!User.IsInRole("SuperAdmins"))
            {
                return new HttpNotFoundResult();
            }

            if (avatar != null)
            {
                if (avatar.ContentLength <= 524288)
                {
                    AvatarModel avatarModel = new AvatarModel();
                    WebImage webImage = new WebImage(avatar.InputStream);

                    webImage.Resize(width: 300, height: 300, preserveAspectRatio: true, preventEnlarge: true);
                    avatarModel.MimeType = MimeMapping.GetMimeMapping(avatar.FileName);
                    byte[] data = webImage.GetBytes(webImage.ImageFormat);
                    avatarModel.AvatarData = Convert.ToBase64String(data);

                    try
                    {
                        if (dr.AvatarsLogic.SetDefaultAvatar((Avatar)avatarModel))
                        {
                            avatarSuccess = "Avatar has been uploaded successfully.";
                        }
                        else
                        {
                            avatarError = "Avatar uploading error.";
                        }
                    }
                    catch (Exception)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                }
                else
                {
                    avatarError = "Avatar size must not exceed 0.5 mb.";
                }
            }

            if (image != null)
            {
                if (image.ContentLength <= 1048576)
                {
                    ImageModel imageModel = new ImageModel();
                    WebImage webImage = new WebImage(image.InputStream);

                    webImage.Resize(width: 1000, height: 1000, preserveAspectRatio: true, preventEnlarge: true);
                    imageModel.MimeType = MimeMapping.GetMimeMapping(image.FileName);
                    byte[] data = webImage.GetBytes(webImage.ImageFormat);
                    imageModel.ImageData = Convert.ToBase64String(data);

                    try
                    {
                        UserModel userModel = dr.UsersLogic.GetUserByUserName(User.Identity.Name);

                        if (userModel == null)
                        {
                            imageModel.ImageOwnerId = 1;
                        }
                        else
                        {
                            imageModel.ImageOwnerId = userModel.UserId;
                        }

                        if (dr.ImagesLogic.SetBannedImage((Image)imageModel))
                        {
                            imageSuccess = "Image has been uploaded succesfully.";
                        }
                        else
                        {
                            imageError = "Image uploading error.";
                        }
                    }
                    catch (Exception)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    imageError = "Image size must not exceed 1 mb.";
                }
            }

            return RedirectToAction("Manage", "Administration", new
            {
                avatarError = avatarError,
                avatarSuccess = avatarSuccess,
                imageError = imageError,
                imageSuccess = imageSuccess
            });
        }
    }
}