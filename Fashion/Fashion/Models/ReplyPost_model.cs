using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class ReplyPost_model
    {
        //回帖信息
        public int replyPostId;//回帖编号
        public int replyPostPostId;//帖子编号
        public string replyPostReplyer;//回帖者
        public string replyPostContent;//回帖内容
    }
}