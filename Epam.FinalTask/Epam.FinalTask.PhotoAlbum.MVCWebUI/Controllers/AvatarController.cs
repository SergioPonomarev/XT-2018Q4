using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Controllers
{
    public class AvatarController : Controller
    {
        public ActionResult GetUserAvatar(int avatarId)
        {
            try
            {
                AvatarModel model = dr.AvatarsLogic.GetUserAvatar(avatarId);

                return PartialView(model);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}