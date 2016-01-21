using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.Code.DAL
{
    public class Rank_dal
    {
        /// <summary>
        /// 通过等级名，获得用户角色等级Id
        /// </summary>
        /// <param name="rankName">用户等级名</param>
        /// <returns></returns>
        public object GetRankId(string rankName)
        {
            string sqlStr = "select rankId from [Rank] where rankName=@rankName";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@rankName",rankName)
            };
            return SqlHelper.ExecuteScalar(sqlStr, parameters);
        }

        public object GetRankName(char rankId)
        {
            string sqlStr = "select rankName from [Rank] where rankId=@rankId";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@rankId",rankId)
            };
            return SqlHelper.ExecuteScalar(sqlStr,parameters);
        }



    }
}