using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.Models.Account;
using BeiDream.Framework.Data;
using BeiDream.Framework.Common;

namespace BeiDream.Service.Account
{
    public interface IRoleService : IDataRepository<BeiDream_Role>
    {
        PagedList<BeiDream_Role> GetPagedList(int pageIndex, int pageSize, FilterGroup FilterGroup = null, string orderByConditions = "");
        List<BeiDream_Role> GetList(FilterGroup FilterGroup = null, string orderByConditions = "");
        bool IsExist(object primaryKey);
        bool IsExist(FilterGroup FilterGroup);
    }
}