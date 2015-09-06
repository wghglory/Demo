using BeiDream.Framework.Common;
using BeiDream.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiDream.Service.Account
{
    public interface IUserRoleService
    {
        List<BeiDream_User_Role> GetList(FilterGroup FilterGroup = null, string orderByConditions = "");
        bool IsExist(FilterGroup FilterGroup);
    }
}