using Fashion.Code.DAL;
using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Code.BLL
{
    public class ReplyPost_bll
    {
        /// <summary>
        /// 获取原帖为postId的所有回帖
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public List<ReplyPost_model> GetReplyPost(int postId)
        {
            ReplyPost_dal replyPost_dal = new ReplyPost_dal();            
            return replyPost_dal.GetReplyPost(postId);

        }

        /// <summary>
        /// 实现回帖功能，将回帖数据存储到数据库
        /// </summary>
        /// <param name="postId">主贴id</param>
        /// <param name="replyId">回帖者的id</param>
        /// <param name="content200">回帖内容的前200字符</param>
        /// <param name="supportCount">点赞数</param>
        /// <param name="datetime">日期</param>
        /// <param name="staticTuiTieHtml">回帖内容的静态html地址</param>
        /// <returns></returns>
        public int InsertReplyPost(int postId,int replyId,string content200,int supportCount,DateTime datetime,string staticTuiTieHtml)
        {
            ReplyPost_dal replyPost_dal = new ReplyPost_dal();
            return replyPost_dal.InsertReplyPost(postId, replyId, content200, supportCount, datetime, staticTuiTieHtml);
        }

    }
}