using Fashion.Code.DAL;
using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Code.BLL
{
    public class PostComment_bll
    {
        /// <summary>
        /// 获取评论数据
        /// </summary>
        /// 这里还没有分条数，即这里全部取出来
        /// <param name="postId">帖子的id</param>
        /// <param name="postType">帖子类型</param>
        /// <returns></returns>
        public List<PostComment_model> GetPostComment(int postId, int postType)
        { 
            PostComment_dal postComment_dal=new PostComment_dal();
            return postComment_dal.GetPostComment(postId,postType);
        }
    }
}