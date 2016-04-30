using Fashion.Code.BLL;
using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class PostsController : Controller
    {
        //
        // GET: /Posts/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchPosts()
        {
            string searchKeyWord = Request["searchKeyWord"].ToString();


            if (Session["userName"] == null)
            {
                return View("../Topic/LoginRemind");
            }
            Post_bll post_bll = new Post_bll();
            List<Post_model> post_modelList = post_bll.GetSearchPost(1, 20, searchKeyWord);
            LoginStatusConfig();          //配置登录状态            
            //return View(post_modelList);
            return View("../Topic/Home",post_modelList);
        }

        /// <summary>
        /// 配置用户登录状态
        /// 如果已登录，返回true，并且设置登录状态：设置ViewData["LoginYes"] = 1；并且从数据库里取出用户头像的链接：ViewData["TouXiangUrl"] =...；
        /// 未登录返回false,并且设置ViewData["LoginYes"] = 0
        /// </summary>
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
            People_bll peopleBll = new People_bll();
            ViewData["TouXiangUrl"] = peopleBll.GetImgUrlTouXiang(Session["userName"].ToString());//从数据库里获取头像url
            return true;
        }

    }
}
