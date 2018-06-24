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
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(fileUpload.FileName));
                fileUpload.SaveAs(path);
                model.Image = fileUpload.FileName;
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
            ViewBag.idAcc = account.getByEmail(User.Identity.Name).AccountId;
            return View(res.ToPagedList(page, pagesize));
            
        }
        public ActionResult UpdatePost(int idPost)
        {
            return View(post.get(idPost));
        }
        [HttpPost]
        public ActionResult UpdatePost(Post model)
        {
            post.Update(model);

            return RedirectToAction("ShowPost");
        }

    }
}