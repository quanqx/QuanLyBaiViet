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
    public class ProfileController : Controller
    {
        private PostBLL post;
        private AccountBLL account;
        public ProfileController()
        {
            account = new AccountBLL(new DAL.UnitOfWork.UnitOfWork(new BlogDBContext()));
            post = new PostBLL(new UnitOfWork(new BlogDBContext()));
        }

        // GET: Profile
        public ActionResult TimeLine(int ? id,int page =1)
        {
            int pagesize = 5;
            if (id == null)
            {
                id = account.getByEmail(User.Identity.Name).AccountId;
            }
            IEnumerable<PostModel> lstPost = post.getPostModel().Where(a => a.AccountId == id);
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
            return View(lstPost.ToPagedList(page, pagesize));
        }
    }
}