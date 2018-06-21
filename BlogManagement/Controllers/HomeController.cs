using BlogManagement.BLL;
using BlogManagement.DAL.Entities;
using BlogManagement.Models;
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
            return Redirect("Timeline");
        }
        public ActionResult TimeLine()
        {
            IEnumerable<PostModel> lstPost = post.getPostModel();
            Dictionary<int, List<CommentModel>> dic = new Dictionary<int, List<CommentModel>>();
            foreach (var item in lstPost)
            {
                List<CommentModel> commentModels = new List<CommentModel>();
                foreach (var i in item.Comments)
                {
                    CommentModel cmtModel = new CommentModel(i.CommentId, i.AccountId, i.Content, i.CommentTime, i.PostId, post.getUserNameById(i.AccountId));
                    commentModels.Add(cmtModel);
                }
                dic.Add(item.PostId, commentModels);
            }
            ViewBag.lstComment = dic;
            return View(lstPost);
        }


    }
}