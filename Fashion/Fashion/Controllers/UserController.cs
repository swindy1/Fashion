using Fashion.Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 退出登录状态，退出成功返回1，失败返回0
        /// login
        /// </summary>
        /// <returns></returns>
        public ActionResult AjaxMakeUnLogin()
        {
            Session["userName"] = null;
            Session["rank"] = null;
            return Content("1");

            People_bll people = new People_bll();
            string username = Request["username"];
            string password = Request["password"];
            bool login = false;  //true代表账号密码都正确
            try
            {
                login = people.LoginYes(username, password);
            }
            catch (Exception e)
            {
                //数据库异常处理，数据库里存在大于两条用户名一样的数据
                ErrorMessage_bll errorMessage_bll = new ErrorMessage_bll();
                errorMessage_bll.InsertErrorMessage("数据库出错", "数据库里tb_User表存在大于2条用户名一样的数据，用户名为：" + username);
                return Content("2");
            }
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
        /// 感谢
        /// 成功返回1，失败返回0
        /// </summary>
        /// <returns></returns>
        public ActionResult ThankUser()
        {
            string userName = Request["userName"];
            string Num = Request["number"];
            User_bll user = new User_bll();           
             return Content(user.GiveUserName(userName,Num).ToString());
            
        }


        /// <summary>
        /// 传递三个参数到User_bll
        /// 关注或取消关注，成功返回1，失败返回0
        /// </summary>
        /// <returns></returns>
        public ActionResult GuanZhuUser()
        {

            string concernName = Request["concernName"];
            string beConcernName = Request["beConcernName"];
            string Num = Request["Num"];
            User_bll user_bll = new User_bll();
            return Content(user_bll.LgGuanZhuUser(concernName, beConcernName, Num).ToString());
            //return Content("1");
        }





    }
}
