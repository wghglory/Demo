using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiDream.Framework.Data
{
    public abstract class PetaPocoUnitOfWorkBase : IUnitOfWorkContext, IDisposable
    {
        private bool _requireAbort = false;
        private int _transactionDepth = 0;
        private Object _transactionLock = new Object();

        protected abstract Database DBContext{ get; }

        public Guid Id { get; private set; }

        public PetaPocoUnitOfWorkBase()
        {
            Id = Guid.NewGuid();
        }

        public void Begin()
        {
            lock (_transactionLock)
            {
                if (_transactionDepth == 0)
                {
                    DBContext.BeginTransaction();
                }
                _transactionDepth++;
            }

        }

        public void Commit()
        {
            lock (_transactionLock)
            {
                _transactionDepth--;
                if (_transactionDepth == 0)
                {
                    try
                    {
                        DBContext.CompleteTransaction();
                    }
                    catch
                    {
                        _transactionDepth++;
                        _requireAbort = true;
                        throw;
                    }
                }
            }
        }

        public void Rollback()
        {
            lock (_transactionLock)
            {
                _transactionDepth--;
                if (_transactionDepth == 0)
                {
                    DBContext.AbortTransaction();
                    _requireAbort = false;
                }
            }
        }

        public void Dispose()
        {
            if (_requireAbort)
            {
                DBContext.AbortTransaction();
            }
            DBContext.Dispose();
        }

        public object RegisterNew<TEntity>(TEntity entity) where TEntity : class
        {
            return DBContext.Insert(entity);
        }

        public List<object> RegisterNew<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            List<object> ListObj = new List<object>();
            try
            {
                this.Begin();
                foreach (var entity in entities)
                {
                    ListObj.Add(this.RegisterNew(entity));
                }
                this.Commit();

            }
            catch (Exception)
            {
                this.Rollback();
            }
            return ListObj;
        }

        public int RegisterModified<TEntity>(TEntity entity) where TEntity : class
        {
            return DBContext.Update(entity);
        }
        /// <summary>
        /// （考虑性能的前提下，慎用）
        /// 此处在考虑性能的情况下，不应用此方式来实现，因为ORM框架更新是整体更新，如果批量整体更新，效率太低
        /// 在考虑性能的情况下，可以用sql的方式直接只更新修改的字段，提高效率
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        public bool RegisterModified<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            try
            {
                this.Begin();
                foreach (var entity in entities)
                {
                    this.RegisterModified(entity);
                }
                this.Commit();
                return true;
            }
            catch (Exception)
            {
                this.Rollback();
                return false;
            }
        }
        public int RegisterDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            return DBContext.Delete(entity);
        }

        public bool RegisterDeleted<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            try
            {
                this.Begin();
                foreach (var entity in entities)
                {
                    this.RegisterDeleted(entity);
                }
                this.Commit();
                return true;
            }
            catch (Exception)
            {
                this.Rollback();
                return false;
            }
        }

        public Database GetPetaPocoDB()
        {
            return DBContext;
        }
    }
}