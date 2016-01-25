using Fashion.Code.DAL;
using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Code.BLL
{
    public class ErrorMessage_bll
    {
        /// <summary>
        /// 向错误信息反馈表里插入一条错误信息。
        /// 当系统出错时使用，用于后期维护和修改bug
        /// </summary>
        /// <param name="errorName">错误信息名</param>
        /// <param name="errorMessage">错误内容</param>
        public void InsertErrorMessage(string errorName,string errorContent)
        {
            ErrorMessage_dal errorMessage_dal = new ErrorMessage_dal();
            ErrorMessage_model errorMessage_model = new ErrorMessage_model();
            errorMessage_model.errorMessageName = errorName;
            errorMessage_model.errorMessageContent = errorContent;
            errorMessage_model.errorMessageCreateTime = DateTime.Now;
            errorMessage_dal.Insert(errorMessage_model);
        }
        
    }
}