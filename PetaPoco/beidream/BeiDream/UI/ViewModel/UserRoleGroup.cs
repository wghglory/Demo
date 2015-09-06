using BeiDream.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiDream.UI.ViewModel
{
    public class UserRoleGroup:BeiDream_Role
    {
        /// <summary>
        /// 此角色是否包含当前用户
        /// </summary>
        public bool IsContainCurrentUser { get; set; }
    }
}