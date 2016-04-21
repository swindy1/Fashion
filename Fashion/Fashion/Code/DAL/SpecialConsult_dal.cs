using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.Code.DAL
{
    public class SpecialConsult_dal
    {

        /// <summary>
        /// 用户特定咨询，保存用户特定咨询填写的数据
        /// </summary>
        /// <param name="userId">咨询者的id</param>
        /// <param name="expertId">专家id</param>
        /// <param name="occasion">场合</param>
        /// <param name="details">咨询详情</param>
        /// <param name="geRenZhaoUrl">个人照片url</param>
        /// <param name="likeStyleImageUrl">喜欢风格的照片url</param>
        /// <param name="dislikeStyleImageUrl">不喜欢风格的照片url</param>
        /// <returns></returns>
        public int InsertConsultData(int userId, int expertId, string occasion, string details, string geRenZhaoUrl, string likeStyleImageUrl, string dislikeStyleImageUrl)
        {
            string sqlStr = @"insert into tb_SpecialConsult 
                                                             ( SpecialConsult_UserId, SpecialConsult_UserPhotoUrl,
                                                               SpecialConsult_Occasion, SpecialConsult_LikeStyleUrl, 
                                                               SpecialConsult_DislikeStyleUrl, SpecialConsult_Detail, SpecialConsult_ExpertId)
                                                   values(@userId,@geRenZhaoUrl,
                                                               @occasion,@likeStyleImageUrl,
   	                                                           @dislikeStyleImageUrl,@details,@expertId)";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@userId",userId),
                new SqlParameter("@expertId",expertId),
                new SqlParameter("@occasion",occasion),
                new SqlParameter("@details",details),
                new SqlParameter("@geRenZhaoUrl",geRenZhaoUrl),
                new SqlParameter("@likeStyleImageUrl",likeStyleImageUrl),
                new SqlParameter("@dislikeStyleImageUrl",dislikeStyleImageUrl),
            };
            return SqlHelper.ExecuteNonquery(sqlStr, parameters);
            
        }
    }
}








