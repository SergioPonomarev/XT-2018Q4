using System;
using System.Web.Mvc;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Controllers
{
    public class AvatarController : Controller
    {
        public ActionResult GetUserAvatar(int avatarId)
        {
            try
            {
                AvatarModel model = dr.AvatarsLogic.GetUserAvatar(avatarId);

                return this.PartialView(model);
            }
            catch (Exception)
            {
                return this.View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}