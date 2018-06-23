using BlogManagement.DAL.Entities;
using BlogManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.BLL
{
    interface ICommentBLL
    {
        Comment get(int id);
        IEnumerable<Comment> getAll();
        void Add(Comment cmt);
        void Update(Comment cmt);
        void Delete(Comment cmt);
        IEnumerable<Comment> getCommentByPostId(int id);
        Dictionary<int, List<CommentModel>> convertCommentModel(IEnumerable<PostModel> lstPost);
    }
}
