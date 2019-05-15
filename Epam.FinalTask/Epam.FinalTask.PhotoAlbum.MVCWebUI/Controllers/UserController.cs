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
using System.Net.Http;
using System.Web.WebPages;

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
            if (User.Identity.Name != model.UserName)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                User user = dr.UsersLogic.GetUserByUserName(model.UserName);

                if (user == null)
                {
                    return new HttpNotFoundResult();
                }

                if (ModelState.IsValid)
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

                ViewBag.UserName = model.UserName;
                ViewBag.AvatarId = user.UserAvatarId;

                return View(model);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public void DeleteProfile(string userName)
        {
            if (User.Identity.Name != userName)
            {
                Response.SetStatus(HttpStatusCode.BadRequest);
            }

            try
            {
                User user = dr.UsersLogic.GetUserByUserName(userName);

                if (user == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                FormsAuthentication.SignOut();

                if (!dr.UsersLogic.Remove(user))
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
        public void BanUser(string userName)
        {
            try
            {
                User userToBan = dr.UsersLogic.GetUserByUserName(userName);

                if (userToBan == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if (userToBan.Banned)
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }

                if ((User.IsInRole("Admins") && userToBan.UserRole == "User") || User.IsInRole("SuperAdmins"))
                {
                    if (!dr.UsersLogic.BanUser(userToBan))
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
        public void UnbanUser(string userName)
        {
            try
            {
                User userToUnban = dr.UsersLogic.GetUserByUserName(userName);

                if (userToUnban == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if (!userToUnban.Banned)
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }

                if ((User.IsInRole("Admins") && userToUnban.UserRole == "User") || User.IsInRole("SuperAdmins"))
                {
                    if (!dr.UsersLogic.UnbanUser(userToUnban))
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
        public void PromoteToAdmin(string userName)
        {
            try
            {
                User userToPromote = dr.UsersLogic.GetUserByUserName(userName);

                if (userToPromote == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if (userToPromote.UserRole == "Admin")
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }

                if (User.IsInRole("SuperAdmins"))
                {
                    if (!dr.UsersLogic.PromoteToAdmin(userToPromote))
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
        public void DemoteToUser(string userName)
        {
            try
            {
                User userToDemote = dr.UsersLogic.GetUserByUserName(userName);

                if (userToDemote == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if (userToDemote.UserRole == "User")
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }

                if (User.IsInRole("SuperAdmins"))
                {
                    if (!dr.UsersLogic.DemoteToUser(userToDemote))
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