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




        public ActionResult makeLogin()
        {
            
            return View();
            
        }
    }
}
