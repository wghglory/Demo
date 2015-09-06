using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.Models.Account;
using BeiDream.Framework.Data;
using BeiDream.Framework.Common;

namespace BeiDream.Service.Account
{
    public class UserService : DbContextBase<BeiDream_User>, IUserService, IDependency
    {
        public UserService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
        public PagedList<BeiDream_User> GetPagedList(int pageIndex, int pageSize, FilterGroup FilterGroup = null, string orderByConditions = "")
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
            return this.PagedList<BeiDream_User>(pageIndex, pageSize, sql);
        }


        public List<BeiDream_User> GetList(FilterGroup FilterGroup = null, string orderByConditions = "")
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
           return this.PetaPocoDB.Fetch<BeiDream_User>(sql);
        }


        public bool IsExist(FilterGroup FilterGroup)
        {
            string whereCondition = "1=1";
            if (FilterGroup != null && FilterGroup.rules != null && FilterGroup.rules.Count != 0)
            {
                whereCondition = FilterHelper.GetFilterTanslate(FilterGroup);
            }
            return this.PetaPocoDB.Exists<BeiDream_User>(whereCondition, null);
        }
    }
}