using System;
using System.Net;
using System.Web.Mvc;
using Epam.FinalTask.PhotoAlbum.Entities;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
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

                    return this.PartialView(userModel);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception)
            {
                return this.View("~/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult GetHeaderMenu()
        {
            return this.PartialView();
        }
    }
}