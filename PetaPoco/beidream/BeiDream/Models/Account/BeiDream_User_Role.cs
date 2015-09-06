using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.Framework.Data;

namespace BeiDream.Models.Account
{
    [TableName("BeiDream_User_Role")]
    [PrimaryKey("ID")]
    public class BeiDream_User_Role : EntityBase<int>
    {
        /// <summary>
        /// 用户主键ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 角色主键ID
        /// </summary>
        public int RoleID { get; set; }
    }
}