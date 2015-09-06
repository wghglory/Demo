using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeiDream.Framework.Data
{
    public interface IDataRepository<TEntity> : IDependency where TEntity : class
        {
            #region 属性

            /// <summary>
            ///     获取 当前实体的查询数据集
            /// </summary>
            Database PetaPocoDB { get; }

            #endregion

            #region 公共方法

            /// <summary>
            ///     插入实体记录
            /// </summary>
            /// <param name="entity"> 实体对象 </param>
            /// <returns> 操作影响的行数 </returns>
            bool Add(TEntity entity);

            /// <summary>
            ///     批量插入实体记录集合
            /// </summary>
            /// <param name="entities"> 实体记录集合 </param>
            /// <returns> 操作影响的行数 </returns>
            List<object> Add(IEnumerable<TEntity> entities);

            /// <summary>
            ///     删除实体记录
            /// </summary>
            /// <param name="entity"> 实体对象 </param>
            /// <returns> 操作影响的行数 </returns>
            int Delete(TEntity entity);

            /// <summary>
            ///     删除实体记录集合
            /// </summary>
            /// <param name="entities"> 实体记录集合 </param>
            /// <returns> 操作影响的行数 </returns>
            bool Delete(IEnumerable<TEntity> entities);

            /// <summary>
            ///     更新实体记录
            /// </summary>
            /// <param name="entity"> 实体对象 </param>
            /// <returns> 操作影响的行数 </returns>
            int Update(TEntity entity);

            /// <summary>
            ///     更新实体记录
            /// </summary>
            /// <param name="entity"> 实体对象 </param>
            /// <returns> 操作影响的行数 </returns>
            bool Update(IEnumerable<TEntity> entities);
            /// <summary>
            /// 根据主键ID获取实体
            /// </summary>
            /// <param name="KeyID">主键ID</param>
            /// <returns>实体</returns>
            TEntity GetModelByID(object KeyID);

            /// <summary>
            /// 动态查询，返回dynamic类型的列表
            /// 请使用标准SQL语句进行查询(SELECT ... FROM ...)
            /// </summary> 
            /// <returns></returns>
            PagedList<dynamic> DynamicPagedList(int pageIndex, int pageSize, Sql sql);

            PagedList<TEntity> PagedList(int pageIndex, int pageSize, string sql, params object[] args);

            PagedList<TEntity> PagedList(int pageIndex, int pageSize, Sql sql);

            PagedList<TDto> PagedList<TDto>(int pageIndex, int pageSize, string sql, params object[] args);

            PagedList<TDto> PagedList<TDto>(int pageIndex, int pageSize, Sql sql);
            #endregion
        }
}
