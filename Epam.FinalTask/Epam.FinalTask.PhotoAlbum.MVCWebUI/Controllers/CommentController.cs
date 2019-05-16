using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dr = Epam.FinalTask.PhotoAlbum.Common.DependencyResolver;
using Epam.FinalTask.PhotoAlbum.Entities;
using Epam.FinalTask.PhotoAlbum.MVCWebUI.Models;
using System.Net;
using System.Web.WebPages;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.Controllers
{
    public class CommentController : Controller
    {
        public ActionResult GetCommentsForImage(int imageId)
        {
            try
            {
                List<CommentModel> commentModels = GetCommentsByImageId(imageId);

                return PartialView(commentModels.OrderByDescending(c => c.CommentDate));
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(CommentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Image image = dr.ImagesLogic.GetImageById(model.CommentImageId);

                    if (image == null)
                    {
                        return new HttpNotFoundResult();
                    }

                    User user = dr.UsersLogic.GetUserByUserName(User.Identity.Name);

                    if (dr.CommentsLogic.Add(model.CommentText, image, user))
                    {
                        return RedirectToAction("ImagePage", "Image", new { imageId = image.ImageId });
                    }
                }

                return PartialView(model);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult Comments(int imageId)
        {
            ViewBag.ImageId = imageId;

            try
            {
                User user = dr.UsersLogic.GetUserByUserName(User.Identity.Name);

                if (user != null)
                {
                    ViewBag.Visitor = user;
                }
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView();
        }

        [HttpPost]
        [Authorize]
        public void DeleteComment(int commentId)
        {
            try
            {
                Comment comment = dr.CommentsLogic.GetCommentById(commentId);
                if (comment == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                User user = dr.UsersLogic.GetUserById(comment.CommentAuthorId);
                if (user == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if (User.Identity.Name != user.UserName)
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }

                if (!dr.CommentsLogic.Remove(comment))
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
        public void BanComment(int commentId)
        {
            try
            {
                Comment comment = dr.CommentsLogic.GetCommentById(commentId);
                if (comment == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if (comment.Banned)
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }

                User author = dr.UsersLogic.GetUserById(comment.CommentAuthorId);
                if (author == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if ((User.IsInRole("Admins") && author.UserRole == "User") || User.IsInRole("SuperAdmins"))
                {
                    if (!dr.CommentsLogic.BanComment(comment))
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
        public void UnbanComment(int commentId)
        {
            try
            {
                Comment comment = dr.CommentsLogic.GetCommentById(commentId);
                if (comment == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if (!comment.Banned)
                {
                    Response.SetStatus(HttpStatusCode.BadRequest);
                }

                User author = dr.UsersLogic.GetUserById(comment.CommentAuthorId);
                if (author == null)
                {
                    Response.SetStatus(HttpStatusCode.NotFound);
                }

                if ((User.IsInRole("Admins") && author.UserRole == "User") || User.IsInRole("SuperAdmins"))
                {
                    if (!dr.CommentsLogic.UnbanComment(comment))
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

        private List<CommentModel> GetCommentsByImageId(int imageId)
        {
            IEnumerable<Comment> comments = dr.CommentsLogic.GetCommentsForImage(imageId);

            List<CommentModel> commentModels = new List<CommentModel>();

            foreach (Comment comment in comments)
            {
                CommentModel model = comment;

                UserModel author = dr.UsersLogic.GetUserById(comment.CommentAuthorId);

                if (author != null)
                {
                    model.CommentAuthor = author;
                }

                commentModels.Add(model);
            }

            return commentModels;
        }
    }
}