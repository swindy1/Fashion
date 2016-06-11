using Fashion.Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class ShangChengController : Controller
    {
        //
        // GET: /ShangCheng/

        public ActionResult Index()
        {
            LoginStatusConfig();//配置登录状态
            return View();
        }
        public ActionResult ClothDetails()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
        public ActionResult Index8()
        {
            return View();
        }
        public ActionResult Index9()
        {
            return View();
        }
        public ActionResult Index10()
        {
            return View();
        }
        public ActionResult Index11()
        {
            return View();
        }
        public ActionResult Index12()
        {
            return View();
        }
        public ActionResult Index13()
        {
            return View();
        }
        public ActionResult Index14()
        {
            return View();
        }
        public ActionResult Index15()
        {
            return View();
        }
        public ActionResult Index16()
        {
            return View();
        }
        public ActionResult Index17()
        {
            return View();
        }
        public ActionResult Index18()
        {
            return View();
        }
        public ActionResult Index19()
        {
            return View();
        }
        public ActionResult Index20()
        {
            return View();
        }
        public ActionResult Index21()
        {
            return View();
        }
        public ActionResult Index22()
        {
            return View();
        }
        public ActionResult Index23()
        {
            return View();
        }
        public ActionResult Index24()
        {
            return View();
        }
        public ActionResult Index25()
        {
            return View();
        }
        public ActionResult Index26()
        {
            return View();
        }
        public ActionResult Index27()
        {
            return View();
        }
        public ActionResult Index28()
        {
            return View();
        }
        public ActionResult Index29()
        {
            return View();
        }
        public ActionResult Index30()
        {
            return View();
        }
        public ActionResult Index31()
        {
            return View();
        }
        public ActionResult Index32()
        {
            return View();
        }
        public ActionResult Index33()
        {
            return View();
        }
        public ActionResult Index34()
        {
            return View();
        }
        public ActionResult Index35()
        {
            return View();
        }
        public ActionResult Index36()
        {
            return View();
        }
        

        /// <summary>
        /// 配置用户登录状态
        /// 如果已登录，返回true，并且设置登录状态：设置ViewData["LoginYes"] = 1；并且从数据库里取出用户头像的链接：ViewData["TouXiangUrl"] =...；
        /// 未登录返回false,并且设置ViewData["LoginYes"] = 0
        /// </summary>
        /// 
        public bool LoginStatusConfig()
        {
            if (Session["userName"] == null)
            {//未登录
                ViewData["LoginYes"] = 0;
                return false;
            }
            //已登录
            ViewData["LoginYes"] = 1;
            ViewData["userName"] = Session["userName"].ToString();
            ViewData["signature"] = Session["signature"].ToString();
            People_bll peopleBll = new People_bll();
            ViewData["TouXiangUrl"] = peopleBll.GetImgUrlTouXiang(Session["userName"].ToString());//从数据库里获取头像url
            return true;
        }

    }
}
