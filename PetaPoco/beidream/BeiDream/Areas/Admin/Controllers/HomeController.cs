using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.UI;
using Newtonsoft.Json.Linq;
using BeiDream.Framework.Common;
using BeiDream.Core.Config;
using BeiDream.Service.Account;
using BeiDream.Service;
using BeiDream.Models.Account;
using System.ComponentModel;

namespace BeiDream.Areas.Admin.Controllers
{
    [Description("管理系统")]
    public class HomeController : BaseController
    {
        public readonly INavigationMenuService _NavigationMenuService;
        public HomeController(INavigationMenuService NavigationMenuService)
        {
            this._NavigationMenuService = NavigationMenuService;
        }
        //
        // GET: /Admin/Home/
        [Anonymous]
        public ActionResult Index()
        {
            return View();
        }
        [Anonymous]
        public ActionResult Default()
        {
            return View();
        }
        [Anonymous]
        public ActionResult GetMenuTree()
        {
            //以XML文件配置的方式实现
            //var NavigationMenuConfig = CachedConfigContext.Current.NavigationMenuConfig;
            //数据库存储的方式实现            
            List<NavigationMenu> listShow = _NavigationMenuService.GetNavigationMenu(0);
            _NavigationMenuService.GetNavigationMenus(ref listShow); // 调用递归的方法

            return this.ExtjsJsonResult(true, listShow);
        }
    }
}
