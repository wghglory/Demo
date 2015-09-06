using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.UI;
using BeiDream.Service.Account;
using BeiDream.Models.Account;
using BeiDream.Framework.Data;
using System.IO;
using System.Dynamic;
using System.ComponentModel;

namespace BeiDream.Areas.Admin.Controllers
{
    [Description("菜单管理")]
    public class NavigationMenuController : BaseController
    {
        public readonly INavigationMenuService _NavigationMenuService;
        public NavigationMenuController(INavigationMenuService NavigationMenuService)
        {
            this._NavigationMenuService = NavigationMenuService;
        }
        //
        // GET: /Admin/Home/
        [DefaultPage]
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
            List<NavigationMenu> listShow = _NavigationMenuService.GetNavigationMenuNoLeaf(0);
            _NavigationMenuService.GetNavigationMenusNoLeaf(ref listShow); // 调用递归的方法
            List<NavigationMenu> listShowRoot = new List<NavigationMenu>();
            listShowRoot.Add(new NavigationMenu() { id = 0, text = "主菜单", leaf = false, Expanded = true, url = "", children = listShow, iconCls = "House" });
            return this.ExtjsJsonResult(true, listShowRoot);
        }
        [Anonymous]
        public ActionResult GetMenuList(int page, int start, int limit,int ParentID)
        {
            Sql sql = new Sql();
            sql.Where("ParentID=@0", ParentID);
            sql.OrderBy("OrderNo ASC");   //默认ASC升序，降序为DESC
            PagedList<BeiDream_NavigationMenu> PageList = _NavigationMenuService.PagedList(page, limit, sql);
            return this.ExtjsGridJsonResult(PageList, PageList.TotalItemCount);
        }
        [Anonymous]
        [HttpPost]
        public ActionResult Add(List<BeiDream_NavigationMenu> NavigationMenus, int ParentID)
        {
            List<BeiDream_NavigationMenu> AddNavigationMenus = new List<BeiDream_NavigationMenu>();
            foreach (var item in NavigationMenus)
            {
                item.ParentID = ParentID;
            }
            List<Object> ListObj = _NavigationMenuService.Add(NavigationMenus);
            if (ListObj.Count == 0)
            {
                List<string> msg = new List<string>();
                msg.Add("添加菜单失败！");
                return this.ExtjsJsonResult(false, msg);
            }
            else
            {
                foreach (var item in ListObj)
                {
                    NavigationMenus.Add(_NavigationMenuService.GetModelByID(item));
                }
                List<string> msg = new List<string>();
                msg.Add("添加菜单成功！");
                return this.ExtjsJsonResult(true, NavigationMenus, msg);
            }

        }
        [Anonymous]
        public ActionResult Remove(List<BeiDream_NavigationMenu> NavigationMenus)
        {
            bool IsSuccess = _NavigationMenuService.Delete(NavigationMenus);
            List<string> msg = new List<string>();
            msg.Add(IsSuccess ? "删除菜单成功！" : "删除菜单失败！");
            return this.ExtjsJsonResult(IsSuccess, NavigationMenus, msg);
        }
        [Anonymous]
        public ActionResult Update(List<BeiDream_NavigationMenu> NavigationMenus)
        {
            bool IsSuccess = _NavigationMenuService.Update(NavigationMenus);
            List<string> msg = new List<string>();
            msg.Add(IsSuccess ? "修改菜单成功！" : "修改菜单失败！");
            return this.ExtjsJsonResult(IsSuccess, NavigationMenus, msg);
        }

        [Anonymous]
        public ActionResult GetIcons()
        {
            List<string> data = new List<string>();
            var rootPath = HttpContext.Server.MapPath("~/Scripts/ext-4.21/resources/css/icon.css");
            StreamReader sr = new StreamReader(rootPath);
            while (true)
            {
                string str = sr.ReadLine();
                if (!String.IsNullOrEmpty(str))
                {
                    data.Add(str.Substring(1, str.IndexOf('{')-1));
                }
                else
                    break;
            }
            return this.ExtjsJsonResult(true, data);
        }
        
        [Anonymous]
        public ActionResult GetAllControllers(int page, int start, int limit)
        {
            IList<MVCController> items = new List<MVCController>();
            items = ActionHelper.GetAllMvcController();
            PagedList<MVCController> p = new PagedList<MVCController>(items, page, limit);
            return this.ExtjsGridJsonResult(p, p.TotalItemCount);
        }
    }
}
