using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.Code.DAL
{
    public class SpecialConsultAnswer_dal
    {
        /// <summary>
        /// 通过特定咨询的帖子编号specialConsultId查询数据库的tb_SpecialConsultAnswer，
        /// 获取专家解答的数据
        /// </summary>
        /// <param name="specialConsultId">特定咨询的帖子编号</param>
        /// <returns></returns>
        public SpecialConsultAnswer_model GetOneSpecialAnswerData(int specialConsultId)
        {
            string sqlStr = @"select SpecialConsultAnswer_Id as specialAnswerId,
                                                   SpecialConsultAnswer_SpecialConsultId as specialConsultId,
                                            	   SpecialConsultAnswer_HtmlUrl as answerHtmlUrl,
                                            	   SpecialConsultAnswer_Date [datetime]
                                            from tb_SpecialConsultAnswer where SpecialConsultAnswer_SpecialConsultId=@specialConsultId";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@specialConsultId",specialConsultId)
            };
            DataTable dataTable = SqlHelper.ExecuteDataTable(sqlStr, parameters);
            SpecialConsultAnswer_model specialConsultAnswer_model = ToModel(dataTable.Rows[0]);
            return specialConsultAnswer_model;
        }


        /// <summary>
        /// 将一条数据转化为SpecialConsultAnswer_model数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public SpecialConsultAnswer_model ToModel(DataRow row)
        {
            SpecialConsultAnswer_model specialConsultAnswer_model = new SpecialConsultAnswer_model();
            specialConsultAnswer_model.specialAnswerId = (int)row["specialAnswerId"];
            specialConsultAnswer_model.specialConsult_model.id = (int)row["specialConsultId"];
            specialConsultAnswer_model.answerHtmlUrl = row["answerHtmlUrl"].ToString();
            specialConsultAnswer_model.date = (DateTime)row["datetime"];
            return specialConsultAnswer_model;
        }
    }
}