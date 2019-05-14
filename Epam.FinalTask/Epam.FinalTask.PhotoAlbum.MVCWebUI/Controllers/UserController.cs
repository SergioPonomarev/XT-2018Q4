using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using System.Net;

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
                UserModel model = dr.UsersLogic.GetUserByUserName(userName);

                return View(model);
            }
            catch (Exception)
            {
                return new HttpNotFoundResult();
            }
        }

        [HttpPost]
        public ActionResult EditProfile(HttpPostedFileBase avatar)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteProfile(string userName)
        {
            if (User.Identity.Name != userName)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}