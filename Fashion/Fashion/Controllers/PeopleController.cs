using Fashion.Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class PeopleController : Controller
    {
        //
        // GET: /People/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        /// <summary>
        /// 判断登录是否成功，登录成功则返回论坛首页
        /// </summary>
        /// <returns></returns>
        public ActionResult makeLogin()
        {
            People_bll people = new People_bll();

            string username = Request["username"];
            string password = Request["password"];
            bool login = people.LoginYes(username, password);
            if (login)
            {
                return RedirectToAction("../Topic/Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }



        public ActionResult Register()
        {


            //People_bll people = new People_bll();
            //if (people.Register("simple", "1", "普通用1户") == 0)
            //{
            //    Response.Write("注册成功");
            //}
            //else {
            //    Response.Write("注册失败");
            //}
            return View();
        }


        /// <summary>
        /// 实现注册功能，把数据保存到数据库
        /// </summary>
        /// <returns></returns>
        public ActionResult makeRegister()
        {
            People_bll people = new People_bll();
            string username = Request["username"];
            string password = Request["password"];
            if (people.Register(username, password, "普通用户") == 0)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }

        }


       




     
    }
}
