using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace BeiDream.Framework.Data
{
    /// <summary>
    ///     可持久到数据库的领域模型的基类。
    /// </summary>
    [Serializable]
    public abstract class EntityBase<TKey>
    {
        #region 构造函数

        /// <summary>
        ///     数据实体基类
        /// </summary>
        protected EntityBase()
        {
            IsDeleted = false;
            CreateDate = DateTime.Now;
        }

        #endregion

        #region 属性

        [Key]
        public TKey ID { get; set; }

        /// <summary>
        ///     获取或设置 获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     获取或设置 添加时间
        /// </summary>
        [Required(ErrorMessage = "创建时间不能为空")]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime CreateDate { get; set; }

        #endregion
    }
}