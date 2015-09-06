using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //packages添加路由检验RouteDebug.dll
            //注册完路由表之后。 在global设置调试路由规则
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);

            //路由规则是有顺序的。


            routes.MapRoute(//创建路由规则放到routes集合中，也就是放到RouteTable中
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }   // 参数默认值
                //, new { action = @"^w[4]$"}  //action必须匹配正则表达式
            );

            routes.MapRoute(
                "Default2", //  /shit/Home-Index/3-9
                "{controller}-{action}/{id}-{id2}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "MVC5_Ajax_Validation_Strongtype_ControllersByEF6._0.Controllers" }
                //限定到那个命名空间搜索
           );

            routes.MapRoute(
                "Default3", // /Home-Index/3-9
                "{*sdd}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default4",
                url: "{controller}/{action}.html",  //伪静态！
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
