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
using System.Web.Security;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult UserPage(string userName)
        {
            if (userName == null)
            {
                return new HttpNotFoundResult();
            }

            try
            {
                UserModel user = dr.UsersLogic.GetUserByUserName(userName);

                if (user == null)
                {
                    return new HttpNotFoundResult();
                }

                return View(user);
            }
            catch (Exception)
            {
                return new HttpNotFoundResult();
            }
        }

        public ActionResult EditProfile(string userName)
        {
            if (User.Identity.Name != userName)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                UserModel user = dr.UsersLogic.GetUserByUserName(userName);

                if (user == null)
                {
                    return new HttpNotFoundResult();
                }

                ViewBag.UserName = user.UserName;
                ViewBag.AvatarId = user.UserAvatarId;

                return View();
            }
            catch (Exception)
            {
                return new HttpNotFoundResult();
            }
        }

        [HttpPost]
        public ActionResult EditProfile(EditUserModel model)
        {
            try
            {
                if (model.UserName == null)
                {
                    return new HttpNotFoundResult();
                }

                if (User.Identity.Name != model.UserName)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                User user = dr.UsersLogic.GetUserByUserName(model.UserName);

                if (user == null)
                {
                    return new HttpNotFoundResult();
                }

                if (model.Avatar != null)
                {
                    AvatarModel avatarModel = new AvatarModel();
                    WebImage webImage = new WebImage(model.Avatar.InputStream);

                    webImage.Resize(width: 300, height: 300, preserveAspectRatio: true, preventEnlarge: true);
                    avatarModel.MimeType = MimeMapping.GetMimeMapping(model.Avatar.FileName);
                    byte[] data = webImage.GetBytes(webImage.ImageFormat);
                    avatarModel.AvatarData = Convert.ToBase64String(data);

                    if (dr.AvatarsLogic.SetAvatarToUser((Avatar)avatarModel, user))
                    {
                        return RedirectToAction("EditProfile", "User", new { userName = model.UserName });
                    }
                }

                return View(model);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult DeleteProfile(string userName)
        {
            if (User.Identity.Name != userName)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = dr.UsersLogic.GetUserByUserName(userName);

            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            FormsAuthentication.SignOut();

            if (dr.UsersLogic.Remove(user))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}