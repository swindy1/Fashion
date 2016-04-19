using Fashion.Code.DAL;
using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Code.BLL
{
    public class User_bll
    {
          /// <summary>
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
        /// 通过用户名获取用的个人资料《特定咨询》
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User_model GetUserDataConsult(string userName)
        {
            User_dal user_dal = new User_dal();
            User_model user_model=user_dal.GetUserDataConsult(userName);
            DateTime today = new DateTime(2016, 4, 18);//今天日期
            DateTime birthDate = user_model.birthDate;//出生年月日
            int age = today.Year - birthDate.Year;//年龄
            if (birthDate > today.AddYears(-age))//还未生日，年龄减去1
                age--;
            user_model.age = age;
            return user_model;
        }
    }
}