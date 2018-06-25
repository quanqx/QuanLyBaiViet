using BlogManagement.BLL;
using BlogManagement.DAL.Entities;
using BlogManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace BlogManagement.Controllers
{
    public class HomeController : Controller
    {
        DAL.UnitOfWork.UnitOfWork uow;
        AccountBLL account;
        PostBLL post;
        CategoryBLL category;
        CommentBLL comment;
        
        public HomeController()
        {
            uow = new DAL.UnitOfWork.UnitOfWork(new BlogDBContext());
            account = new AccountBLL(uow);
            post = new PostBLL(uow);
            category = new CategoryBLL(uow);
            comment = new CommentBLL(uow);
        }

        public ActionResult navPartial()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.accountId = account.getByEmail(User.Identity.Name).AccountId;
            }
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
        public ActionResult CreatePost(Post model, HttpPostedFileBase fileUpload)
        {
            if(fileUpload != null)
            {
                String fileName = genNameImage() + Path.GetExtension(fileUpload.FileName);
                fileUpload.SaveAs(Server.MapPath("~/Images/" + fileName));
                model.Image = fileName;
            }
            model.AccountId = account.getByEmail(User.Identity.Name).AccountId;
            model.DatePost = DateTime.Now;
            
            post.Add(model);
            return Redirect("ShowPost");
        }

        public ActionResult ShowPost(int? accountId, int? categoryId, int page = 1)
        {
            int pagesize = 5;
            IEnumerable<PostModel> lstPost = post.getPostModel();
            IEnumerable<PostModel> res = lstPost;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.user = account.getByEmail(User.Identity.Name);
            }
            if (accountId == null)
            {
                if (categoryId != null)
                {
                    res = lstPost.Where(a => a.CategoryId == categoryId);
                }
            }
            else
            {
                if (categoryId != null)
                {
                    res = lstPost.Where(a => a.CategoryId == categoryId && a.AccountId == accountId);
                }
                else
                {
                    res = lstPost.Where(a => a.AccountId == accountId);
                }
            }
            ViewBag.lstComment = comment.convertCommentModel(res);
            return View(res.ToPagedList(page, pagesize));
            
        }
        public ActionResult UpdatePost(int idPost)
        {
            return View(post.get(idPost));
        }
        [HttpPost]
        public ActionResult UpdatePost(Post model, HttpPostedFileBase fileUpload)
        {
            if (fileUpload != null)
            {
                String fileName = genNameImage() + Path.GetExtension(fileUpload.FileName);
                fileUpload.SaveAs(Server.MapPath("~/Images/" + fileName));
                model.Image = fileName;
            }
            post.Update(model);
            return RedirectToAction("ShowPost");
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
                + (s < 10 ? "0" + s : s + "") + ".";
        }

    }
}