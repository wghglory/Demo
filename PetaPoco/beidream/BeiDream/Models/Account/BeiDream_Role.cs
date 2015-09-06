using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.Framework.Data;

namespace BeiDream.Models.Account
{
    [TableName("BeiDream_Role")]
    [PrimaryKey("ID")]
    public class BeiDream_Role : EntityBase<int>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUsed { get; set; }
    }
}