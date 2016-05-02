using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.Code.DAL
{
    public class Collect_dal
    {
        /// <summary>
        /// 通过用户名获取某个用户userId的收藏的主贴
        /// 这次不用查询出全部的数据，只需查询一部分数据，因为不是用于详情内容，而是用于遍历
        /// 原贴id  原贴标题 原贴内容  原贴的第一张图片 日期
        /// 返回Collect_model;
        /// </summary>
        /// <param name="userId">用户id</param>       
        /// <returns></returns>
        public List<Collect_model> GetShortCollectPostData(int userId)
        {
            string sqlStr = @"select tb_Collect.Collect_PostId postId,tb_Post.Post_Caption zhuTieCaption,
                                                   tb_Post.Post_Content zhuTieContent,tb_Post.Post_Date [datetime],
                                           		PostPhotoAll.photoUrl
                                             from tb_Collect  left join tb_Post  on tb_Collect.Collect_PostId=tb_Post.Post_Id
                                             left join
                                               (select PostPhoto_PostId,PostPhoto_PhotoUrl as photoUrl,
                                                       ROW_NUMBER()over(partition by PostPhoto_PostId order by PostPhoto_PostId) as new_index
                                                 from tb_PostPhoto where PostPhoto_PostType=1)as PostPhotoAll
                                              on tb_Collect.Collect_PostId=PostPhotoAll.PostPhoto_PostId
                                           where new_index=1 and tb_Collect.Collect_CollectorId=@userId";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@userId",userId)
            };
            DataTable dataTable = SqlHelper.ExecuteDataTable(sqlStr, parameters);
            List<Collect_model> collect_modelList = new List<Collect_model>();
            foreach (DataRow row in dataTable.Rows)
            {
                collect_modelList.Add(ToShortModel(row));
            }
            return collect_modelList;
        }

        /// <summary>
        /// 将一条数据转化为ReplyPost_model数据
        /// 原贴id  原贴标题 原贴内容  原贴的第一张图片 日期
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Collect_model ToShortModel(DataRow row)
        {
            Collect_model collect_model = new Collect_model();
            collect_model.collectPostId = (int)row["postId"];
            collect_model.Post_model.postCaption = row["zhuTieCaption"].ToString();
            collect_model.Post_model.postContent = row["zhuTieContent"].ToString();
            collect_model.Post_model.postDate = (DateTime)row["datetime"];
            collect_model.Post_model.firstPostPhotoUrl = row["photoUrl"].ToString();
            return collect_model;
        }
    }
}