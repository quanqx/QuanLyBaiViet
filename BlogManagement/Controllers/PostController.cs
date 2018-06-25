using BlogManagement.BLL;
using BlogManagement.DAL.Entities;
using BlogManagement.DAL.UnitOfWork;
using BlogManagement.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogManagement.Controllers
{
    public class PostController : Controller
    {

        private UnitOfWork uow;
        private AccountBLL account;
        private PostBLL post;
        private CommentBLL comment;

        public PostController()
        {
            uow = new UnitOfWork(new BlogDBContext());
            account = new AccountBLL(uow);
            post = new PostBLL(uow);
            comment = new CommentBLL(uow);
        }

        [HttpPost]
        public String uploadFile(HttpPostedFileBase image)
        {
            String fileName = genNameImage() + Path.GetExtension(image.FileName);
            image.SaveAs(Server.MapPath("~/Images/" + fileName));
            return "/Images/" + fileName;
        }
        
        public ActionResult removePost(int postId)
        {
            Post p = post.get(postId);
            if(p != null)
                post.Delete(p);
            IEnumerable<Comment> comments = comment.getCommentByPostId(postId);
            foreach(var item in comments)
            {
                comment.Delete(item);
            }
            return Redirect("/Home/ShowPost");
        }

        private String genNameImage()
        {
            int Y = DateTime.Now.Year;
            int M = DateTime.Now.Month;
            int D = DateTime.Now.Day;
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            return Y + "" + (M < 10 ? "0" + M : M + "") + "" + (D < 10 ? "0" + D : D + "") + ""
                + (h < 10 ? "0" + h : h + "") + "" + (m < 10 ? "0" + m : m + "") + ""
                + (s < 10 ? "0" + s : s + "");
        }

    }
}