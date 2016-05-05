using Fashion.Code.DAL;
using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Fashion.Code.BLL
{
    public class User_bll
    {

        /// <summary>
        /// 执行关注，取消关注或不执行操作的逻辑判断
        /// 执行操作返回1，无操作返回0
        /// </summary>
        /// <param name="concernName"></param>
        /// <param name="beConcernName"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public int LgGuanZhuUser(string concernName, string beConcernName, string Num)
        {
            User_dal user_dal = new User_dal();
            int concernNameId =Convert.ToInt32( user_dal.GetUserId(concernName));
            int beConcernNameId =Convert.ToInt32( user_dal.GetUserId(beConcernName));
            object exist = user_dal.select_ConIdAndBeConId(concernNameId, beConcernNameId);//查询记录是否存在，null或concernNameId
            if (exist == null && Num == "1")//无关注记录，只可插入不可删除
                return user_dal.insert_IdTotb_Attention(concernNameId, beConcernNameId);
            else if (exist!=null && Num == "0")//有关注记录，只可删除不可插入
                return user_dal.delete_IdFromtb_Attention(concernNameId, beConcernNameId);
            else
                return 0;

        }






        /// <summary>
        /// 传递一个userName参数使用户感谢+1
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GiveUserName(string userName,string Num)
        {

            User_dal user_dal = new User_dal();
            if ((int)user_dal.UpdateStarCount(userName,Num) == 1)
                return 1;
            else
                return 0;

        }








          /// <summary>
        /// Creator:Simple
        /// 通过用户名查询该用户的ID，
        /// 成功返回1
        /// 失败返回0
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetUserId(string userName)
        {
            User_dal user_dal = new User_dal();
            object userId = user_dal.GetUserId(userName);
            if (userId == null || userId == System.DBNull.Value)
            {
                return 0;
            }
            return (int)userId;
            
        }


        /// <summary>
        /// Creator:Simple
        /// 通过用户名获取用的个人资料《特定咨询》
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User_model GetUserDataConsult(string userName)
        {
            User_dal user_dal = new User_dal();
            User_model user_model = new User_model();
            try
            {
                user_model = user_dal.GetUserDataConsult(userName);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            DateTime today = DateTime.Now;//今天日期
            DateTime birthDate = user_model.birthDate;//出生年月日
            int age = today.Year - birthDate.Year;//年龄
            if (birthDate > today.AddYears(-age))//还未生日，年龄减去1
                age--;
            user_model.age = age;
            return user_model;
        }

        /// <summary>
        /// Creator:Simple
        /// 获取一定数量的专家的数据：id、用户名、头像url  
        /// 用于用户特定咨询的选择专家
        /// </summary>
        /// <returns></returns>
        public List<ExpertUserConsult_model> GetExpertConsult()
        {
            List<ExpertUserConsult_model> expertUserConsult_modelList = new List<ExpertUserConsult_model>();
            User_dal user_dal = new User_dal();
            expertUserConsult_modelList = user_dal.GetExpertConsult();
            return expertUserConsult_modelList;
        }

        /// <summary>
        /// Creator:Simple
        /// 通过用户名查找用户的个性签名
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetSignature(string userName)
        {
            User_dal user_dal=new User_dal();
            object objSignature = user_dal.GetSignature(userName);
            if (objSignature == null || objSignature == System.DBNull.Value)
            { 
                ///
            }
            return objSignature.ToString();
        }


        /// <summary>
        /// Creator:Simple
        /// 根据用户的userId 和等级名rankName  获取用户的 特定咨询数（或特定解答数） 提问数 回答数 收藏 关注数 粉丝数 获赞数
        /// rankName为普通用户时，查询特定咨询数
        ///                  为专家时，查询特定解答数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public CountUser_model GetCountUser(int userId,string rankName)
        {
            User_dal user_dal = new User_dal();
            CountUser_model countUser_model = new CountUser_model();
            try {
                countUser_model = user_dal.GetCountUser(userId, rankName);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return countUser_model;
        }

    }
}