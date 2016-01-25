using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class ErrorMessage_model
    {
        //错误消息
        public int errorMessageId;  //错误消息编号
        public string errorMessageName; //错误消息名
        public string errorMessageContent; //错误消息内容
        public DateTime errorMessageCreateTime; //错误消息插入时间
    }
}