using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Code.Ajax
{
    /// <summary>
    /// test 的摘要说明
    /// </summary>
    public class test : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("ssss");
            
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}