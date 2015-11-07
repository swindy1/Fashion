using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class TopicController : Controller
    {
        //
        // GET: /Topic/

        
        public ActionResult Index2()
        {
            return Index2();
        }
        
        public ActionResult Home()
        {

            if (Session["userName"] == null)
            {
                ViewData["LoginYes"] = 0;
            }
                
            else
            {
                ViewData["LoginYes"] = 1;
                ViewData["userName"] = Session["userName"].ToString();
            }
            
            return View();
        }

        
        
        public ActionResult Answer()
        {
            //ViewData["a"]=Request["type"].ToString();
            //ViewData["a"]="a";
            return View();
        }
        public ActionResult AjaxAnswer()
        {
            return Content("HelloWorld This is Answer");
        }
        public ActionResult Post()
        {
            return View();
        }
        public ActionResult fabu()
        {
            return View();
        }
        

    }
}
