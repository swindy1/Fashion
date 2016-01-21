using Fashion.Code.DAL;
using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Fashion.Code.BLL
{
    public class People_bll
    {
        /////////////////////////////////////////////
        //user表
        ////////////////////////////////////////////
        /// <summary>
        ///  user表
        /// 判断是否存在该用户
        /// 结果返回1代表存在
        /// 结果返回0代表不存在
        /// 结果返回2代表数据库出错，因为数据库存在超过2条数据的该用户
        /// </summary>
        /// <param name="userName"></param>
        public int HavingUserName(string userName)
        {
            User_dal user = new User_dal();
            int accountCount = (int)user.GetAccountCount(userName);
            if (accountCount<=0)
            {
                return 0;
            }
            if (accountCount > 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }  
        }

       


        /// <summary>
        /// 判断登录是否成功，成功返回true，失败返回false
        /// 使用者：People控制器里的ajaxMakeLogin
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool LoginYes(string userName,string password)
        {
            User_dal user_dal = new User_dal();
            //用户的数量
            object AccountCount = user_dal.GetAccountCount(userName);
            //null代表数据库不存在该数据，System.DBNull.Value代表数据库里存在数据，但是该字段的值为null
            if (AccountCount == null || AccountCount == System.DBNull.Value)
            {
                return false;
            }
            //如果用户的数量小于0
            if ((int)AccountCount <= 0)
            {
                return false;
            }
            if ((int)AccountCount > 1)
            {
                return false;
            }
            //以上判断存在该用户后，获取其盐值和密码

            User_model user_model = user_dal.GetPwdAndSaltModel(userName);
            string salt = user_model.salt; //颜值
            string realPassword = user_model.password; //密码
            //将盐值加在密码的后面，并转化为二进制
            byte[] pwdAndSaltBytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
            //经过哈希算法加密后得到的二进制值
            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(pwdAndSaltBytes);
            string hashPassword = Convert.ToBase64String(hashBytes);
            //判断密码是否正确
            if (realPassword == hashPassword)
            {
                return true;
            }
            else
            {
                return false;
            }      
        }





        /////////////////////////////////////////////
        //user表和Rank表
        ////////////////////////////////////////////
        /// <summary>
        /// 实现注册功能，返回结果为int型
        /// 0代表注册成功；
        /// 1代表：数据插入出错，注册失败
        /// 2代表：查询到的数据为null，数据库中的等级表里不存在该rankName对应的数据
        /// 3代表：查询到的该字段为null,数据库中的等级表里的rankName字段对应的rankId为null
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="rankName">等级名（管理员，普通用户，时尚达人，专家）</param>
        /// <returns></returns>
        public int Register(string userName,string password,string rankName)
        {
            //通过等级名得到等级编号
            Rank_dal rankDal = new Rank_dal();
            object rankIdObj = rankDal.GetRankId(rankName);
            if (rankIdObj == null)
            {
                return 2;
            }
            if (rankIdObj == System.DBNull.Value)
            {
                return 3;
            }
            string rankId = rankIdObj.ToString();

            //盐值
            string salt = Guid.NewGuid().ToString();
            //将盐值加在密码的后面，并转化为二进制
            byte[] pwdAndSaltBytes = System.Text.Encoding.UTF8.GetBytes(password+salt);
            //经过哈希算法加密后得到的二进制值
            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(pwdAndSaltBytes);
            string hashPassword = Convert.ToBase64String(hashBytes);
            User_dal userDal = new User_dal();
            if (userDal.InsertRegister(userName,salt,hashPassword, rankId) == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
            
        }



    }
}