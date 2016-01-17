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
        /// 通过用户名查询数据库里该用户的条数
        /// </summary>
        /// <param name="userName">用户名</param>       
        /// <returns></returns>
        public object getAccountCount(string userName)
        {
            string sqlStr = "select count(*) from [user] where userName=@userName";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@userName",userName)
            };
            return SqlHelper.executeScalar(sqlStr, parameters);
        }

       /// <summary>
       /// 获取用户的密码
       /// </summary>
        /// <param name="userName">用户的账号</param>
       /// <returns></returns>
        public object getPassword(string userName)
        {
            string sqlStr = "select [password] from [User] where userName=@userName";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@userName",userName)
            };
            return SqlHelper.executeScalar(sqlStr, parameters);
        }

        /// <summary>
        /// 通过用户名查询该用户的盐值，返回类型为object
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public object getSalt(string userName)
        {
            string sqlStr = "select salt from [user] where userName=@userName";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@userName",userName)
            };
            return SqlHelper.executeScalar(sqlStr, parameters);
        }

        /// <summary>
        /// 通过用户名获取该用户的密码和盐值
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable getPwdAndSalt(string userName)
        {
            string sqlStr = "select [password],[salt] from [user] where userName=@userName";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@userName",userName)
            };
            return SqlHelper.executeDataTable(sqlStr,parameters);
        }


        

       



        /// <summary>
        /// 用户注册，注册成功返回1
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="salt">盐值</param>
        /// <param name="password">密码</param>
        /// <param name="rankId">等级编号</param>
        /// <returns></returns>
        public int InsertRegister(string userName,string salt,string password,string rankId)
        {

            string sqlStr = "insert into [user] (userName,salt,[password],rankId) values (@userName,@salt,@password,@rankId)";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("userName",userName),
                new SqlParameter("salt",salt),
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