using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.Code.DAL
{
    public class ErrorMessage_dal
    {
        /// <summary>
        /// 向错误信息反馈表里插入一条错误信息。
        /// 当处理系统出错问题时使用，用于后期维护和修改bug
        /// </summary>
        /// <param name="errorName">错误信息名</param>
        /// <param name="errorMessage">错误内容</param>
        /// <returns></returns>
        public int Insert(ErrorMessage_model errorMessage_model)
        {
            string sqlStr = "insert into tb_ErrorMessage(ErrorMessageName,ErrorMessageContent,ErrorMessageCreateTime)values(@errorName,@errorMessage,@dataTime)";
            SqlParameter []parameters=new SqlParameter[]{
                new SqlParameter("@errorName",errorMessage_model.errorMessageName),
                new SqlParameter("@errorMessage",errorMessage_model.errorMessageContent),
                new SqlParameter("@dataTime",errorMessage_model.errorMessageCreateTime)
            };
            return SqlHelper.ExecuteNonquery(sqlStr,parameters);
        }

    }
}