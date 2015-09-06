using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeiDream.Framework.Data
{
    /// <summary>
    /// DAL基类，实现Repository通用泛型数据访问模式
    /// </summary>
    public class DbContextBase<T> : IDataRepository<T> where T : class
    {
        /// <summary>
        /// 获取 仓储上下文的实例
        /// </summary>
        private readonly IUnitOfWork UnitOfWork;

        public DbContextBase(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        /// <summary>
        ///     获取或设置 EntityFramework的数据仓储上下文
        /// </summary>
        protected IUnitOfWorkContext EFContext
        {
            get
            {
                if (UnitOfWork is IUnitOfWorkContext)
                {
                    return UnitOfWork as IUnitOfWorkContext;
                }
                throw new Exception(string.Format("数据仓储上下文对象类型不正确，应为IRepositoryContext，实际为 {0}", UnitOfWork.GetType().Name));
            }
        }

        public Database PetaPocoDB
        {
            get { return EFContext.GetPetaPocoDB(); }
        }

        public PagedList<dynamic> DynamicPagedList(int pageIndex, int pageSize, Sql sql)
        {
            var pageDate = PetaPocoDB.Page<dynamic>(pageIndex, pageSize, sql);
            return new PagedList<dynamic>(pageDate.Items,pageIndex,pageSize,pageDate.TotalItems);
        }

        public PagedList<T> PagedList(int pageIndex, int pageSize, string sql, params object[] args)
        {
            var pageData = PetaPocoDB.Page<T>(pageIndex, pageSize, sql, args);
            return new PagedList<T>(pageData.Items, pageIndex, pageSize, pageData.TotalItems);
        }

        public PagedList<T> PagedList(int pageIndex, int pageSize, Sql sql)
        {
            var pageData = PetaPocoDB.Page<T>(pageIndex, pageSize, sql);
            return new PagedList<T>(pageData.Items, pageIndex, pageSize, pageData.TotalItems);
        }

        public PagedList<TDto> PagedList<TDto>(int pageIndex, int pageSize, string sql, params object[] args)
        {
            var pageData = PetaPocoDB.Page<TDto>(pageIndex, pageSize, sql, args);
            return new PagedList<TDto>(pageData.Items, pageIndex, pageSize, pageData.TotalItems);
        }

        public PagedList<TDto> PagedList<TDto>(int pageIndex, int pageSize, Sql sql)
        {
            var pageData = PetaPocoDB.Page<TDto>(pageIndex, pageSize, sql);
            return new PagedList<TDto>(pageData.Items, pageIndex, pageSize, pageData.TotalItems);
        }


        public bool Add(T entity)
        {
            return EFContext.RegisterNew(entity)!=null;
        }

        public List<object> Add(IEnumerable<T> entities)
        {
            return EFContext.RegisterNew(entities);
        }

        public int Delete(T entity)
        {
            return EFContext.RegisterDeleted(entity);
        }

        public bool Delete(IEnumerable<T> entities)
        {
            return EFContext.RegisterDeleted(entities);
        }

        public int Update(T entity)
        {
            return EFContext.RegisterModified(entity);
        }

        public bool Update(IEnumerable<T> entities)
        {
            return EFContext.RegisterModified(entities);
        }


        public T GetModelByID(object KeyID)
        {
            return EFContext.GetPetaPocoDB().SingleOrDefault<T>(KeyID);
        }
    }
}
