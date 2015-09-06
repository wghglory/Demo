using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.UI;
using BeiDream.Models.Account;
using BeiDream.Framework.Data;

namespace BeiDream.Service.Account
{
    public interface INavigationMenuService : IDataRepository<BeiDream_NavigationMenu>
    {
        List<NavigationMenu> GetNavigationMenu(int id);
        List<NavigationMenu> GetNavigationMenuNoLeaf(int id);
        void GetNavigationMenus(ref List<NavigationMenu> list);
        void GetNavigationMenusNoLeaf(ref List<NavigationMenu> list);
    }
}