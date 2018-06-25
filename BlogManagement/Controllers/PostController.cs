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
        private PostBLL post;
        private CommentBLL comment;

        public PostController()
        {
            uow = new UnitOfWork(new BlogDBContext());
            post = new PostBLL(uow);
            comment = new CommentBLL(uow);
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
        
    }
}