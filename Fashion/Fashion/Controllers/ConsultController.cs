using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class ConsultController : Controller
    {
        //
        // GET: /Consult/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 专家对特定咨询的回帖，当点击提交时调用此函数
        /// </summary>
        /// <returns></returns>
        public ActionResult MakeExpertAnswer()
        {
            return Content("d");
        }

        //特定咨询详情页面（用户和专家共用）
        public ActionResult ConsultDetails()
        {
            return View();
        }
    }
}
