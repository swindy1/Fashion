using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fashion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //路由规则：
            //1.路由可以有多条
            //2.路由是有顺序的。前面被匹配了之后，后面的路由规则就没有机会了。
            //3.路由可以调试，可以通过引用一个路由调试库（RouteDebug.dll)进行调试
            //注册一条路由规则
            routes.MapRoute(
                name: "Default",  //作为路由规则的key，不能重复
                url: "{controller}/{action}/{id}", //请求后台url规则
                defaults: new { controller = "People",   //默认值，可以有多条
                                         action = "Register",
                                         id = UrlParameter.Optional }
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "网站首页",
            //    url: "{*values}",
            //    defaults: new {controller="Topic",action="Home"}
            //    );

        }
    }
}