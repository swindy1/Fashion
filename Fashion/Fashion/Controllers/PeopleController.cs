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
                //登录成功之后，保存用户的用户名，权限等资料到session
                Session["userName"] = username;
                Session["rank"] = "rank";
                return RedirectToAction("Home", "Topic");
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }



        /// <summary>
        // 测试用的
        /// </summary>
        /// <returns></returns>
        
        public ActionResult ajax()
        {
            
//            return JavaScript("window.location.href = '../Topic/Answer'");
            
            return View();
            //return RedirectToAction("Answer","Home");
            
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
