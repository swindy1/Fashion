using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DbError()
        {
            string errorMsg = "数据库错误";
            if (Request["errorMsg"] == null)
            {
                errorMsg = "未知错误";
            }
            errorMsg = Request["errorMsg"].ToString();
            ViewData["errorMsg"] = errorMsg;
            return View();
        }
    }
}
