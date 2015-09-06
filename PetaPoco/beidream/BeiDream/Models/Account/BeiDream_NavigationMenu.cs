using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeiDream.Framework.Data;

namespace BeiDream.Models.Account
{
    [TableName("BeiDream_NavigationMenu")]
    [PrimaryKey("ID")]
    public class BeiDream_NavigationMenu:EntityBase<int>
    {
        /// <summary>
        /// 展示的名称
        /// </summary>
        public string ShowName { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public int ParentID { get; set; }
        /// <summary>
        /// 是否叶节点，true：下面再无叶节点
        /// </summary>
        public bool IsLeaf { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderNo { get; set; }
        /// <summary>
        /// 节点对应的请求的页面，mvc就是对应的Action
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 是否展开叶节点
        /// </summary>
        public bool Expanded { get; set; }
        /// <summary>
        /// 显示图标样式
        /// </summary>
        public string iconCls { get; set; }
    }
}