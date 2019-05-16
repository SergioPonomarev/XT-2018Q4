using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using Epam.FinalTask.PhotoAlbum.Entities;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (dr.AccountsLogic.CanLogin(model.UserName, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
                        return this.RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Wrong login or password.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Wrong login or password.");
                }

                return this.View(model);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Registration()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = dr.UsersLogic.GetUserByUserName(model.UserName);

                    if (user != null)
                    {
                        ModelState.AddModelError(string.Empty, "User already exists.");
                    }
                    else
                    {
                        if (dr.AccountsLogic.UserRegistration(model.UserName, model.Password))
                        {
                            return this.RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Registration error.");
                        }
                    }
                }

                return this.View(model);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}