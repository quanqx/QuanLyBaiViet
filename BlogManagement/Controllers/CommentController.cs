using BlogManagement.BLL;
using BlogManagement.DAL.Entities;
using BlogManagement.DAL.UnitOfWork;
using BlogManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogManagement.Controllers
{
    public class CommentController : Controller
    {

        private CommentBLL commentBLL;

        public CommentController()
        {
            commentBLL = new CommentBLL(new UnitOfWork(new BlogDBContext()));
        }

        // GET: Comment
        [HttpPost]
        public ActionResult Comment(int PostId, String Content)
        {
            Account acc = commentBLL.getAccountByEmail(User.Identity.Name);
            Comment cmt = new Comment(1, acc.AccountId, Content, DateTime.Now, PostId);
            commentBLL.Add(cmt);
            CommentModel model = new CommentModel(1, cmt.AccountId, Content, cmt.CommentTime, PostId, acc.UserName);
            model.AccountImage = acc.Image;
            return Json(model);
        }
    }
}