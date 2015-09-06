using BeiDream.Framework.Common;
using BeiDream.Framework.Data;
using BeiDream.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiDream.Service.Account
{
    public class UserRoleService : DbContextBase<BeiDream_User_Role>, IUserRoleService, IDependency
    {
        public UserRoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }
        public List<BeiDream_User_Role> GetList(FilterGroup FilterGroup = null, string orderByConditions = "")
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
            return this.PetaPocoDB.Fetch<BeiDream_User_Role>(sql);
        }


        public bool IsExist(FilterGroup FilterGroup)
        {
            string whereCondition = "1=1";
            if (FilterGroup != null && FilterGroup.rules != null && FilterGroup.rules.Count != 0)
            {
                whereCondition = FilterHelper.GetFilterTanslate(FilterGroup);
            }
            return this.PetaPocoDB.Exists<BeiDream_User_Role>(whereCondition, null);
        }
    }
}