using BlogManagement.BLL;
using BlogManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogManagement.Controllers
{
    public class HomeController : Controller
    {

        AccountBLL account = new AccountBLL(new DAL.UnitOfWork.UnitOfWork(new BlogDBContext()));
        PostBLL post = new PostBLL(new DAL.UnitOfWork.UnitOfWork(new BlogDBContext()));
        CategoryBLL category = new CategoryBLL(new DAL.UnitOfWork.UnitOfWork(new BlogDBContext()));

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.lst = post.getAll();
            return View();
        }

        public ActionResult navPartial()
        {
            return PartialView();
        }
        public ActionResult NavLeftPartial()
        {
            ViewBag.lstCategory = category.getAll();
            return PartialView();
        }
        public ActionResult CreatePostPartial()
        {
            ViewBag.CategoryId = new SelectList(new BlogDBContext().Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult CreatePostPartial(Post model, HttpPostedFileBase fileUpload)
        {
            string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(fileUpload.FileName));
            fileUpload.SaveAs(path);
            model.AccountId = account.getByEmail(User.Identity.Name).AccountId;
            model.DatePost = DateTime.Now;
            model.Image = fileUpload.FileName;
            post.Add(model);
            return Redirect("Index");
        }


    }
}