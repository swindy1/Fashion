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
        /// 通过回帖staticHuiTieHtml查询回帖数据的id
        /// </summary>
        /// <param name="staticHuiTieHtml"></param>
        /// <returns></returns>
        public int GetReplyPostId(string staticHuiTieHtml)
        {
            ReplyPost_dal replyPost_dal = new ReplyPost_dal();
            object objReplyPost_Id = replyPost_dal.GetReplyPostId(staticHuiTieHtml);
            if (objReplyPost_Id == null || objReplyPost_Id == System.DBNull.Value)
            {

            }
            return Convert.ToInt32(objReplyPost_Id);
        }

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
        /// 通过用户名获取某个用户userId的回帖
        /// 这次不用查询出全部的数据，只需查询一部分数据，因为不是用于详情内容，而是用于遍历
        /// 原贴id  原贴标题 回帖内容的前200字符  回帖帖子的第一张图片 日期
        /// 返回ReplyPost_modelList;
        /// </summary>
        /// <param name="userId">用户id</param>       
        /// <returns></returns>
        public List<ReplyPost_model> GetShortReplyPostData(int userId)
        {
            ReplyPost_dal replyPost_dal = new ReplyPost_dal();
            List<ReplyPost_model> replyPost_modelList = replyPost_dal.GetShortReplyPostData(userId);
            return replyPost_modelList;
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