using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using Epam.FinalTask.PhotoAlbum.Entities;
using System.Net;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserBlock(string userName)
        {
            try
            {
                User user = dr.UsersLogic.GetUserByUserName(userName);

                if (user != null)
                {
                    UserModel userModel = user;

                    Avatar avatar = dr.AvatarsLogic.GetUserAvatar(userModel.UserAvatarId);

                    if (avatar == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                    }

                    AvatarModel avatarModel = avatar;

                    ViewBag.Avatar = avatarModel;

                    return PartialView(userModel);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult GetHeaderMenu()
        {
            return PartialView();
        }
    }
}