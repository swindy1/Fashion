using Fashion.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Code.BLL
{
    public class SpecialConsult_bll
    {
        /// <summary>
        /// 用户特定咨询，保存用户特定咨询填写的数据
        /// </summary>
        /// <param name="userId">咨询者的id</param>
        /// <param name="expertId">专家id</param>
        /// <param name="occasion">场合</param>
        /// <param name="details">咨询详情</param>
        /// <param name="geRenZhaoFileName">个人照片名</param>
        /// <param name="likeStyleImageFileName">喜欢风格的照片名</param>
        /// <param name="dislikeStyleImageFileName">不喜欢风格的照片名</param>
        /// <returns></returns>

        public int InsertConsultData(int userId, int expertId, string occasion, string details, string geRenZhaoFileName, string likeStyleImageFileName, string dislikeStyleImageFileName)
        {
            SpecialConsult_dal specialConsul_dal = new SpecialConsult_dal();
            string geRenZhaoUrl="/Images/ConsultImages/GeRenZhao/"+ geRenZhaoFileName;
            string likeStyleImageUrl="/Images/ConsultImages/LikeStyleImage/"+ likeStyleImageFileName;
            string dislikeStyleImageUrl = "/Images/ConsultImages/LikeStyleImage/" + dislikeStyleImageFileName;
            return specialConsul_dal.InsertConsultData(userId, expertId, occasion, details, geRenZhaoUrl, likeStyleImageUrl, dislikeStyleImageUrl);
        }
    }
}