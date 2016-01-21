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


       
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            //throw new Exception("more than 1 row was found");
            string finshRegister1 = Request["finshRegister"]; //获取一个值，1代表用户是通过注册跳转到该函数的，0则相反
            if (Convert.ToInt32(finshRegister1) == 1)
            {
                ViewData["finshRegister"] = 1;
                return View();
            }
            else
            {
                ViewData["finshRegister"] = 0;
                return View();
            }
        }
        /// <summary>
        /// 判断登录是否成功，登录成功返回1，登录失败返回0
        /// login
        /// </summary>
        /// <returns></returns>
        public ActionResult ajaxMakeLogin()
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

                return Content("1");
            }
            else
            {
                return Content("0");
            }
            
        }

        /// <summary>
        /// 根据用户名判断账号名是否存在，存在返回1，不存在返回0，数据库出错返回2
        /// 用于Login页面
        /// </summary>
        /// <returns></returns>      
        public ActionResult ajaxUserName()
        {
            string userName = Request["userName"].ToString();
            People_bll people = new People_bll();
            return Content(people.HavingUserName(userName).ToString());
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

        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
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
                return RedirectToAction("Login", new { finshRegister = 1 });
            }
            else
            {
                return View();
            }

        }
        /// <summary>
        /// 我的主页
        /// </summary>
        /// <returns></returns>
        public ActionResult PeopleHomePage()
        {
            return View();
        }


       




     
    }
}
