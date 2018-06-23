using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogManagement.DAL.Entities;
using BlogManagement.DAL.UnitOfWork;
using BlogManagement.Models;

namespace BlogManagement.BLL
{
    public class CommentBLL : ICommentBLL
    {
        private IUnitOfWork uow;

        public CommentBLL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Add(Comment cmt)
        {
            uow.commentRepository.Add(cmt);
            uow.Save();
        }

        public void Delete(Comment cmt)
        {
            uow.commentRepository.Delete(cmt);
            uow.Save();
        }

        public Comment get(int id)
        {
            return uow.commentRepository.get(id);
        }

        public IEnumerable<Comment> getAll()
        {
            return uow.commentRepository.getAll();
        }

        public void Update(Comment cmt)
        {
            uow.commentRepository.Update(cmt);
            uow.Save();
        }

        public IEnumerable<Comment> getCommentByPostId(int id)
        {
            return uow.commentRepository.getAll().Where(a => a.PostId == id);
        }

        public Dictionary<int, List<CommentModel>> convertCommentModel(IEnumerable<PostModel> lstPost)
        {
            Dictionary<int, List<CommentModel>> dic = new Dictionary<int, List<CommentModel>>();
            foreach (var item in lstPost)
            {
                List<CommentModel> commentModels = CommentToCommentModel(item.Comments) as List<CommentModel>;
                dic.Add(item.PostId, commentModels.OrderByDescending(a => a.CommentTime).ToList());
            }
            return dic;
        }

        private IEnumerable<CommentModel> CommentToCommentModel(IEnumerable<Comment> comments)
        {
            List<CommentModel> commentModels = new List<CommentModel>();
            foreach (var i in comments)
            {
                Account acc = uow.accountRepository.getById(i.AccountId);
                CommentModel cmtModel = new CommentModel(i.CommentId, i.AccountId, i.Content, i.CommentTime, i.PostId, acc.UserName);
                cmtModel.AccountImage = acc.Image;
                commentModels.Add(cmtModel);
            }
            return commentModels;
        }
    }
}