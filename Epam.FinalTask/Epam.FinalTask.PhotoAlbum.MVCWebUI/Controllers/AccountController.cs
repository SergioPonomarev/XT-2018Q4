using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using Epam.FinalTask.PhotoAlbum.Entities;
using System.Net;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
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
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Wrong login or password.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login or password.");
                }

                return View(model);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registration()
        {
            return View();
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
                        ModelState.AddModelError("", "User already exists.");
                    }
                    else
                    {
                        if (dr.AccountsLogic.UserRegistration(model.UserName, model.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Registration error.");
                        }
                    }
                }

                return View(model);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}