using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.Models.Account;
using BeiDream.Framework.Data;
using BeiDream.Framework.Common;

namespace BeiDream.Service.Account
{
    public interface IUserService : IDataRepository<BeiDream_User>
    {
        PagedList<BeiDream_User> GetPagedList(int pageIndex, int pageSize, FilterGroup FilterGroup = null, string orderByConditions = "");

        List<BeiDream_User> GetList(FilterGroup FilterGroup = null, string orderByConditions = "");
        bool IsExist(FilterGroup FilterGroup);
    }
}