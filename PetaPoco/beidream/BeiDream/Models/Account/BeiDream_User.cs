using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.Framework.Data;
using System.ComponentModel.DataAnnotations;

namespace BeiDream.Models.Account
{
    [TableName("BeiDream_User")]
    [PrimaryKey("ID")]
    public class BeiDream_User:EntityBase<int>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(64, ErrorMessage = "用户名不能超过64位")]
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [StringLength(8, MinimumLength = 6, ErrorMessage = "密码最短6位，不能超过8位")]
        public string PassWord { get; set; }
    }
}