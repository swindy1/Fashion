using Fashion.Code.DAL;
using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Code.BLL
{
    public class SpecialConsultAnswerClothes_bll
    {


        /// <summary>
        /// 通过解答的数据id specialAnswerId获取该数据的搭配的衣服
        /// </summary>
        /// <param name="specialAnswerId"></param>
        /// <returns></returns>
        public List<SpecialConsultAnswerClothes_model> GetSpecialAnswerClothes(int specialAnswerId)
        {

            SpecialConsultAnswerClothes_dal specialConsultAnswerClothes_dal = new SpecialConsultAnswerClothes_dal();
            List<SpecialConsultAnswerClothes_model> specialConsultAnswerClothes_modelList = specialConsultAnswerClothes_dal.GetSpecialAnswerClothes(specialAnswerId);
            return specialConsultAnswerClothes_modelList;
        }
        /// <summary>
        /// 将专家对特定咨询的接到的衣服购买链接存储到数据库
        /// </summary>
        /// <param name="specialConsultAnswer_Id">专家的解答的数据表的id</param>
        /// <param name="selectClothUrlDic">衣服购买链接的键值对</param>
        /// <returns></returns>
        public int InsertConsultAnswerClothes(int specialConsultAnswer_Id, Dictionary<string, string> selectClothUrlDic)
        {
            SpecialConsultAnswerClothes_dal specialConsultAnswerClothes_dal = new SpecialConsultAnswerClothes_dal();
            return specialConsultAnswerClothes_dal.InsertConsultAnswerClothes(specialConsultAnswer_Id, selectClothUrlDic);
        }

    }
}