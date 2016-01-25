using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class Message_model
    {
        //消息
        public int messageId;//消息编码
        public string messageContent;//消息内容
        public string messageSender;//发送者
        public string messageReceiver;//接受者
        public DateTime messageDate;//发送日期
    }
}