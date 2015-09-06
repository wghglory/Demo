using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.UI;
using BeiDream.Framework.Data;
using BeiDream.Models.Account;

namespace BeiDream.Service.Account
{
    public class NavigationMenuService : DbContextBase<BeiDream_NavigationMenu>, INavigationMenuService, IDependency
    {
        public NavigationMenuService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
        public List<NavigationMenu> GetNavigationMenu(int id)
        {
            var sql = Sql.Builder.Where("ParentID=@0",id);
            sql.OrderBy("OrderNo ASC");   //默认ASC升序，降序为DESC
            List<BeiDream_NavigationMenu> List = this.PetaPocoDB.Fetch<BeiDream_NavigationMenu>(sql);
            return AutoMapperHelper.GetMapper(List);
        }
        public List<NavigationMenu> GetNavigationMenuNoLeaf(int id)
        {
            var sql = Sql.Builder.Where("ParentID=@0", id);
            sql.Where("IsLeaf=@0", false);
            sql.OrderBy("OrderNo ASC");   //默认ASC升序，降序为DESC
            List<BeiDream_NavigationMenu> List = this.PetaPocoDB.Fetch<BeiDream_NavigationMenu>(sql);
            return AutoMapperHelper.GetMapper(List);
        }
        /// <summary>
        /// 递归查询产品分类列表
        /// </summary>
        /// <param name="list">父级产品分类列表</param>
        public void GetNavigationMenus(ref List<NavigationMenu> list)
        {
            foreach (NavigationMenu season in list)
            {
                List<NavigationMenu> lstSeason = GetNavigationMenu(season.id);
                season.children = lstSeason;
                if (list.Count > 0)
                {
                    GetNavigationMenus(ref lstSeason);
                }
            }
        }
        /// <summary>
        /// 递归查询产品分类列表
        /// </summary>
        /// <param name="list">父级产品分类列表</param>
        public void GetNavigationMenusNoLeaf(ref List<NavigationMenu> list)
        {
            foreach (NavigationMenu season in list)
            {
                List<NavigationMenu> lstSeason = GetNavigationMenuNoLeaf(season.id);
                season.children = lstSeason;
                if (list.Count > 0)
                {
                    GetNavigationMenusNoLeaf(ref lstSeason);
                }
            }
        }
    }
}