using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.Code.DAL
{
    public class SpecialConsultAnswerClothes_dal
    {

        /// <summary>
        /// 通过解答的数据id specialAnswerId获取该数据的搭配的衣服
        /// </summary>
        /// <param name="specialAnswerId"></param>
        /// <returns></returns>
        public List<SpecialConsultAnswerClothes_model> GetSpecialAnswerClothes(int specialAnswerId)
        {
            string sqlStr = @"select SpecialConsultAnswerClothes_ClotheType as clothType, 
                                                   SpecialConsultAnswerClothes_ClotheUrl clothUrl
                                            from tb_SpecialConsultAnswerClothes 
                                            where SpecialConsultAnswerClothes_AnswerId=@specialAnswerId";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@specialAnswerId",specialAnswerId)
            };
            DataTable dataTable = SqlHelper.ExecuteDataTable(sqlStr,parameters);
            List<SpecialConsultAnswerClothes_model> specialConsultAnswerClothes_modelList = new List<SpecialConsultAnswerClothes_model>();
            foreach (DataRow row in dataTable.Rows)
            {
                specialConsultAnswerClothes_modelList.Add(ToModel(row));
            }
            return specialConsultAnswerClothes_modelList;
        }

        /// <summary>
        /// 将一条数据转化为SpecialConsultAnswerClothes_model数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public SpecialConsultAnswerClothes_model ToModel(DataRow row)
        {
            SpecialConsultAnswerClothes_model specialConsultAnswerClothes_model = new SpecialConsultAnswerClothes_model();
            specialConsultAnswerClothes_model.clothType = row["clothType"].ToString();
            specialConsultAnswerClothes_model.clothUrl = row["clothUrl"].ToString();
            return specialConsultAnswerClothes_model;
        }
        /// <summary>
        /// 将专家对特定咨询的接到的衣服购买链接存储到数据库
        /// </summary>
        /// <param name="specialConsultAnswer_Id">专家的解答的数据表的id</param>
        /// <param name="selectClothUrlDic">衣服购买链接的键值对</param>
        /// <returns></returns>
        public int InsertConsultAnswerClothes(int specialConsultAnswer_Id, Dictionary<string, string> selectClothUrlDic)
        {
            Dictionary<string, string>.KeyCollection clothTypeKeys = selectClothUrlDic.Keys;
            string sqlStr = "";
            foreach (string clothType in clothTypeKeys)
            {
                sqlStr = sqlStr + @"insert tb_SpecialConsultAnswerClothes (SpecialConsultAnswerClothes_AnswerId, 
                                                                                                                  SpecialConsultAnswerClothes_ClotheType, 
									                                                                              SpecialConsultAnswerClothes_ClotheUrl)
							                                                                          values ("+specialConsultAnswer_Id+",'"+clothType+"','"+selectClothUrlDic[clothType]+"')";
            }
            return SqlHelper.ExecuteNonquery(sqlStr);

        }
    }
}