using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.Models.Account;
using BeiDream.Framework.Data;
using BeiDream.Framework.Common;

namespace BeiDream.Service.Account
{
    public class RoleService : DbContextBase<BeiDream_Role>, IRoleService, IDependency
    {
        public RoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
        public PagedList<BeiDream_Role> GetPagedList(int pageIndex, int pageSize, FilterGroup FilterGroup = null, string orderByConditions = "")
        {
            var sql = new Sql();
            if (FilterGroup != null && FilterGroup.rules != null && FilterGroup.rules.Count != 0)
            {
                string whereCondition = FilterHelper.GetFilterTanslate(FilterGroup);
                sql = Sql.Builder.Where(whereCondition);
            }
            
            if (orderByConditions != string.Empty)
            {
                sql.OrderBy(orderByConditions);
            }
            return this.PagedList<BeiDream_Role>(pageIndex, pageSize, sql);
        }


        public List<BeiDream_Role> GetList(FilterGroup FilterGroup = null, string orderByConditions = "")
        {
            var sql = new Sql();
            if (FilterGroup != null && FilterGroup.rules != null && FilterGroup.rules.Count != 0)
            {
                string whereCondition = FilterHelper.GetFilterTanslate(FilterGroup);
                sql = Sql.Builder.Where(whereCondition);
            }
            if (orderByConditions != string.Empty)
            {
                sql.OrderBy(orderByConditions);
            }
            return this.PetaPocoDB.Fetch<BeiDream_Role>(sql);
        }


        public bool IsExist(object primaryKey)
        {
            return this.PetaPocoDB.Exists<BeiDream_Role>(primaryKey);
        }


        public bool IsExist(FilterGroup FilterGroup)
        {
            string whereCondition ="1=1";
            if (FilterGroup != null && FilterGroup.rules != null && FilterGroup.rules.Count != 0)
            {
                whereCondition = FilterHelper.GetFilterTanslate(FilterGroup);
            }
            return this.PetaPocoDB.Exists<BeiDream_Role>(whereCondition, null);
        }
    }
}