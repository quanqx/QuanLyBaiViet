using BlogManagement.BLL;
using BlogManagement.DAL.Entities;
using BlogManagement.DAL.UnitOfWork;
using BlogManagement.Models;
using PagedList;
using System;
using System.Collections.Generic;
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

        public PostController()
        {
            uow = new UnitOfWork(new BlogDBContext());
            account = new AccountBLL(uow);
            post = new PostBLL(uow);
        }

        [HttpPost]
        public String uploadFile(HttpPostedFileBase image)
        {
            image.SaveAs(Server.MapPath("~/Images/" + image.FileName));
            return "/Images/" + image.FileName;
        }

    }
}