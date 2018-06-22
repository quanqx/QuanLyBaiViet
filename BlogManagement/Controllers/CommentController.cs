using BlogManagement.BLL;
using BlogManagement.DAL.Entities;
using BlogManagement.DAL.UnitOfWork;
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
            commentBLL = new CommentBLL(new UnitOfWork(new DAL.Entities.BlogDBContext()));
        }

        // GET: Comment
        [HttpPost]
        public ActionResult Comment(int PostId, int AccountId, String Content)
        {
            Comment cmt = new Comment(1, AccountId, Content, DateTime.Now, PostId);
            commentBLL.Add(cmt);
            return View();
        }
    }
}