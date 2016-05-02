using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.Code.DAL
{
    public class ReplyPost_dal
    {


        /// <summary>
        /// 通过回帖staticHuiTieHtml查询回帖数据的id
        /// </summary>
        /// <param name="staticHuiTieHtml"></param>
        /// <returns></returns>
        public object GetReplyPostId(string staticHuiTieHtml)
        {
            string sqlStr = "select ReplyPost_Id from tb_ReplyPost where ReplyPost_HtmlUrl=@staticHuiTieHtml";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@staticHuiTieHtml",staticHuiTieHtml)
            };
            return SqlHelper.ExecuteScalar(sqlStr, parameters);
        }


        /// <summary>
        /// 获取原帖为postId的所有回帖
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public List<ReplyPost_model> GetReplyPost(int postId)
        {
            string sqlStr = "select * from ReplyPostView where postId=@postId";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@postId",postId)
            };
            DataTable dataTable = SqlHelper.ExecuteDataTable(sqlStr,parameters);
            List<ReplyPost_model> replyPost_modelList = new List<ReplyPost_model>();
            foreach (DataRow row in dataTable.Rows)
            {
                replyPost_modelList.Add(ToModel(row));
            }
            return replyPost_modelList;
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
            string sqlStr = @"select replyPost.ReplyPost_PostId postId,post.Post_Caption zhuTieCaption,
                                                   replyPost.ReplyPost_Content replyContent,replyPost.ReplyPost_Date [datetime],PostPhotoAll.photoUrl
                                          from tb_ReplyPost replyPost left join tb_Post post on replyPost.ReplyPost_PostId=post.Post_Id
                                                  left join 
                                            (select PostPhoto_PostId,PostPhoto_PhotoUrl as photoUrl,
                                                    ROW_NUMBER()over(partition by PostPhoto_PostId order by PostPhoto_PostId) as new_index
                                                    from tb_PostPhoto where PostPhoto_PostType=2) AS PostPhotoAll
                                          on replyPost.ReplyPost_Id=PostPhotoAll.PostPhoto_PostId
                                          where new_index = 1 and Post_SenderId=@userId";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@userId",userId)
            };
            DataTable dataTable = SqlHelper.ExecuteDataTable(sqlStr, parameters);
            List<ReplyPost_model> replyPost_modelList = new List<ReplyPost_model>();
            foreach (DataRow row in dataTable.Rows)
            {
                replyPost_modelList.Add(ToShortModel(row));
            }
            return replyPost_modelList;
        }


        /// <summary>
        /// 将一条数据转化为ReplyPost_model数据
        /// 原贴id  原贴标题 回帖内容的前200字符  回帖帖子的第一张图片 日期
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public ReplyPost_model ToShortModel(DataRow row)
        {
            ReplyPost_model replyPost_model = new ReplyPost_model();
            replyPost_model.PostId = (int)row["postId"];
            replyPost_model.Post_model.postCaption = row["zhuTieCaption"].ToString();
            replyPost_model.replyPostContent = row["replyContent"].ToString();
            replyPost_model.replyPostDate = (DateTime)row["datetime"];
            replyPost_model.firstPostPhotoUrl = row["photoUrl"].ToString();
            return replyPost_model;
        }

        /// <summary>
        /// 将一条数据转化为ReplyPost_model数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public ReplyPost_model ToModel(DataRow row)
        {
            ReplyPost_model replyPost_model = new ReplyPost_model();
            replyPost_model.Commenter.userId = (int)row["userId"];
            replyPost_model.Commenter.userName = row["userName"].ToString();
            replyPost_model.Commenter.signature = (row["signature"] != DBNull.Value ? row["signature"].ToString() : null);
            replyPost_model.Commenter.touXiangUrl = row["touXiangUrl"].ToString();
            replyPost_model.replyPostId = (int)row["id"];
            replyPost_model.PostId = (int)row["postId"];
            replyPost_model.replyPostContent = row["content"].ToString();
            if (row["datetime"] != null)
            {
                replyPost_model.replyPostDate = (DateTime)row["datetime"];
            }
            replyPost_model.replyPostHtmlUrl = row["htmlUrl"].ToString();
            replyPost_model.replyPostSupportCount = (int)row["supportCount"];
            replyPost_model.commentCount = (row["commentCount"] != DBNull.Value ? (int)row["commentCount"] : 0);
            return replyPost_model;
        }

     /// <summary>
     /// 将回帖数据存储到数据库
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
            string sqlStr = @"insert into tb_ReplyPost (ReplyPost_PostId, ReplyPost_ReplyerId, 
                                                                                   ReplyPost_Content, ReplyPost_SupportCount, 
				                                                         		   ReplyPost_Date, ReplyPost_HtmlUrl) 
                                                                       values (@postId,@replyId,@content200,
                                                                                    @supportCount,@datetime,@staticTuiTieHtml)";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@postId",postId),
                new SqlParameter("@replyId",replyId),
                new SqlParameter("@content200",content200),
                new SqlParameter("@supportCount",supportCount),
                new SqlParameter("@datetime",datetime),
                new SqlParameter("@staticTuiTieHtml",staticTuiTieHtml),
            };
            return SqlHelper.ExecuteNonquery(sqlStr, parameters);
        }
    }
}