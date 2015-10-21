 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.Code.DAL
{
    public class User_dal
    {

       /// <summary>
       /// 获取用户的密码
       /// </summary>
       /// <param name="userId">用户的账号</param>
       /// <returns></returns>
        public object getPassword(string userId)
        {
            string sqlStr = "select [password] from [User] where userId=@userId";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@userId",userId)
            };
            return SqlHelper.executeScalar(sqlStr, parameters);
        }

        /// <summary>
        /// 查询数据库里的账号数，
        /// 通过用户名和密码，查询数据库是否有该用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public object getAccountCount(string userName, string password)
        {
            string sqlStr = "select count(*) from [user] where userName=@userName and [password]=@password";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@userName",userName),
                new SqlParameter("@password",password)
            };
            return SqlHelper.executeScalar(sqlStr,parameters);
        }



        /// <summary>
        /// 用户注册，注册成功返回1
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="rankId">等级编号</param>
        /// <returns></returns>
        public int InsertRegister(string userName,string password,string rankId)
        {

            string sqlStr = "insert into [user] (userName,[password],rankId) values (@userName,@password,@rankId)";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("userName",userName),
                new SqlParameter("password",password),
                new SqlParameter("rankId",rankId)
            };
            return SqlHelper.executeNonquery(sqlStr,parameters);
        }
        

      
        //public DataTable get(string[] columnNames,)
        //{ 
        //    if(columnNames.Length<=0)
        //    { }
        //    string sqlStr = "select ";
        //    sqlStr=sqlStr+columnNames[0];
        //    for(int i=1;i<columnNames.Length;i++)
        //    {
        //        sqlStr = sqlStr + "," + columnNames[i];
        //    }
        //    sqlStr = sqlStr + " from User where userId=@userId";
        //    SqlParameter[] parameters = new SqlParameter[]{
        //        new SqlParameter("@userId",userId)
        //    };

                
            
        //}
    

    }
}