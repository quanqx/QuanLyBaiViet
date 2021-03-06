﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogManagement.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int AccountId { get; set; }
        public String Content { get; set; }
        public DateTime CommentTime { get; set; }
        public int PostId { get; set; }
        public String UserName { get; set; }
        public String AccountImage { get; set; }

        public CommentModel(int commentId, int accountId, string content, DateTime commentTime, int postId, string userName)
        {
            CommentId = commentId;
            AccountId = accountId;
            Content = content;
            CommentTime = commentTime;
            PostId = postId;
            UserName = userName;
            AccountImage = "";
        }
    }
}