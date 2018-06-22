﻿using BlogManagement.BLL;
using BlogManagement.DAL.Entities;
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

        private AccountBLL account;
        private PostBLL post;

        public PostController()
        {
            account = new AccountBLL(new DAL.UnitOfWork.UnitOfWork(new BlogDBContext()));
            post = new PostBLL(new DAL.UnitOfWork.UnitOfWork(new BlogDBContext()));
        }

        [HttpPost]
        public String uploadFile(HttpPostedFileBase image)
        {
            image.SaveAs(Server.MapPath("~/Images/" + image.FileName));
            return "/Images/" + image.FileName;
        }
        

        public ActionResult Category(int ? idCate, int page =1)//for Cate
        {
            int pagesize = 5;
            IEnumerable<PostModel> lstPost = post.getPostModel().Where(a=>a.CategoryId == idCate);
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