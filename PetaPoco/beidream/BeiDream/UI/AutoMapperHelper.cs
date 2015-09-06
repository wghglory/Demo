using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.Models.Account;
using BeiDream.UI.ViewModel.AutoMapper;

namespace BeiDream.UI
{
    /// <summary>
    /// 后续使用AutoMapper实现
    /// </summary>
    public static class AutoMapperHelper
    {
        public static List<NavigationMenu> GetMapper(List<BeiDream_NavigationMenu> List)
        {
            List<NavigationMenu> NavigationMenuList = new List<NavigationMenu>();
            foreach (var item in List)
            {
                //NavigationMenu DaoModel = new NavigationMenu();
                //DaoModel.id = item.ID;
                //DaoModel.text = item.ShowName;
                //DaoModel.leaf = item.IsLeaf;
                //DaoModel.url = item.url;
                //DaoModel.Expanded = item.Expanded;
                //DaoModel.children = null;
                NavigationMenu DaoModel = item.ToDestination<BeiDream_NavigationMenu, NavigationMenu>();
                NavigationMenuList.Add(DaoModel);
            }
            return NavigationMenuList;
        }
    }
}