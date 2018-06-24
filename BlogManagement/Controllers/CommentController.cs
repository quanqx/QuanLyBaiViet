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

        private UnitOfWork uow;
        private CommentBLL commentBLL;
        private PostBLL postBLL;
        private AccountBLL accountBLL;

        public CommentController()
        {
            uow = new UnitOfWork(new BlogDBContext());
            commentBLL = new CommentBLL(uow);
            postBLL = new PostBLL(uow);
            accountBLL = new AccountBLL(uow);
        }
        
        [HttpPost]
        public ActionResult Comment(int PostId, String Content)
        {
            Account acc = accountBLL.getByEmail(User.Identity.Name);
            Comment cmt = new Comment(1, acc.AccountId, Content, DateTime.Now, PostId);
            commentBLL.Add(cmt);
            return Json(commentBLL.CommentToCommentModel(commentBLL.getCommentByPostId(PostId)));
        }
        
        public ActionResult removeComment(int commentId)
        {
            Comment cmt = commentBLL.get(commentId);
            if (cmt != null)
                commentBLL.Delete(cmt);
            return Redirect("/Home/ShowPost");
        }
    }
}