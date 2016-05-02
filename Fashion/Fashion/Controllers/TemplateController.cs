using Fashion.Code.BLL;
using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class TemplateController : Controller
    {
        //
        // GET: /Template/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 模板页，查看我的  “回答 提问 收藏 ” 帖子，
        /// </summary>
        /// <returns></returns>
        public ActionResult MyPostTemplate()
        {
            LoginStatusConfig();//配置登录状态
            if (Session["userName"] == null)
            {
                return RedirectToAction("LoginRemind", "Topic");
            }
            string userName = Session["userName"].ToString();
            User_bll user_bll = new User_bll();
            int userId = Convert.ToInt32(user_bll.GetUserId(userName));//通过用户名获取userId
            CountUser_model countUser_model = user_bll.GetCountUser(userId);//获取用户的CountUser_model 数据：点赞数 关注数 粉丝数 收藏数 提问数 回帖数 特定咨询数 等          
            ViewData["countUser_model"] = countUser_model;
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
