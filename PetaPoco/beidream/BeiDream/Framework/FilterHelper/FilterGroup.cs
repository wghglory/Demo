namespace BeiDream.Framework.Common
{
    using System.Collections.Generic;
    /// <summary>
    /// 对应前台 ligerFilter 的检索规则数据
    /// </summary>
    public class FilterGroup
    {
        /// <summary>
        /// 规则
        /// </summary>
        public IList<FilterRule> rules { get; set; }
        /// <summary>
        /// 操作符
        /// </summary>
        public GroupOperatorQueryEnum op { get; set; }
        /// <summary>
        /// 条件组
        /// </summary>
        public IList<FilterGroup> groups { get; set; }
    }
}
