using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiDream.Framework.Data
{
    public interface IUnitOfWorkContext:IUnitOfWork
    {

        ///// <summary>
        /////   为指定的类型返回 System.Data.Entity.DbSet，这将允许对上下文中的给定实体执行 CRUD 操作。
        ///// </summary>
        ///// <typeparam name="TEntity"> 应为其返回一个集的实体类型。 </typeparam>
        ///// <returns> 给定实体类型的 System.Data.Entity.DbSet 实例。 </returns>
        //DbSet<TEntity> Set<TEntity>() where TEntity : class;            //EF的实现方式




        /// <summary>
        ///   注册一个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        object RegisterNew<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        ///   批量注册多个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entities"> 要注册的对象集合 </param>
        List<object> RegisterNew<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        /// <summary>
        ///   注册一个更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        int RegisterModified<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        ///   批量注册多个更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        bool RegisterModified<TEntity>(IEnumerable<TEntity> entity) where TEntity : class;

        /// <summary>
        ///   注册一个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        int RegisterDeleted<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        ///   批量注册多个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entities"> 要注册的对象集合 </param>
        bool RegisterDeleted<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    }
}