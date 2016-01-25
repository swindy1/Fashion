using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class Comment_model
    {
        //评论
        public int commentId;//评论编号
        public int commentPostId;//帖子编号
        public string commentConmenter;//评论者
        public string commentBeComment;//被评论者
        public string commentContent;//评论内容
    }
}