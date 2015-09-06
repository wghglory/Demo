using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiDream.Framework.Data
{
    public interface IUnitOfWork
    {
        /// <summary>
        ///  返回 PetaPoco.Database，这将允许对上下文中的给定实体执行 CRUD 操作。
        /// </summary>
        /// <returns> PetaPoco.Database </returns>
        Database GetPetaPocoDB();                     //根据不同的ORM类型指定不同的方法
        void Begin();
        void Commit();
        void Rollback();
    }
}