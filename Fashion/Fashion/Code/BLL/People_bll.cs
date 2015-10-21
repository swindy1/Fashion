using Fashion.Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Code.BLL
{
    public class People_bll
    {




        //user表
        ///////////////////////////////
        /// <summary>
        /// 判断登录是否成功，成功返回true，失败返回false
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool LoginYes(string userName,string password)
        {
            User_dal user = new User_dal();
            //用户的数量
            object AccountCount = user.getAccountCount(userName, password);
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
            else
            {
                return true;
            }
        }



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
            object rankIdObj = rankDal.getRankId(rankName);
            if (rankIdObj == null)
            {
                return 2;
            }
            if (rankIdObj == System.DBNull.Value)
            {
                return 3;
            }
            string rankId = rankIdObj.ToString();
            User_dal userDal = new User_dal();
            if (userDal.InsertRegister(userName, password, rankId) == 1)
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