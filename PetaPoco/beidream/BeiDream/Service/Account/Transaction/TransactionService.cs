using BeiDream.Framework.Data;
using BeiDream.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiDream.Service.Account
{
    public class TransactionService : ITransactionService, IDependency
    {
        public IUnitOfWork UnitOfWork
        {
            get;
            private set;
        }
        public TransactionService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        public bool DeleteUserAndUserRole(List<BeiDream_User> Users)
        {
            var DBContext = UnitOfWork.GetPetaPocoDB();
            DBContext.BeginTransaction();
            try
            {
                foreach (var item in Users)
                {
                    DBContext.Delete(item);
                    var sql = Sql.Builder.Where("UserID=@0", item.ID);
                    DBContext.Delete<BeiDream_User_Role>(sql);
                }
                DBContext.CompleteTransaction();
                return true;
            }
            catch (Exception)
            {
                DBContext.AbortTransaction();
                return false;
            }
        }
        public bool DeleteRoleAndUserRole(List<BeiDream_Role> Roles)
        {
            var DBContext = UnitOfWork.GetPetaPocoDB();
            DBContext.BeginTransaction();
            try
            {
                foreach (var item in Roles)
                {
                    DBContext.Delete(item);
                    var sql = Sql.Builder.Where("RoleID=@0", item.ID);
                    DBContext.Delete<BeiDream_User_Role>(sql);
                }
                DBContext.CompleteTransaction();
                return true;
            }
            catch (Exception)
            {
                DBContext.AbortTransaction();
                return false;
            }
        }

        public bool DeleteUserAndUserRole(List<object> UsersID)
        {
            var DBContext = UnitOfWork.GetPetaPocoDB();
            DBContext.BeginTransaction();
            try
            {
                foreach (var item in UsersID)
                {
                    DBContext.Delete<BeiDream_Role>(item);
                    var sql = Sql.Builder.Where("UserID=@0", item);
                    DBContext.Delete<BeiDream_User_Role>(sql);
                }
                DBContext.CompleteTransaction();
                return true;
            }
            catch (Exception)
            {
                DBContext.AbortTransaction();
                return false;
            }
        }

        public bool AddUserAndUserRole(BeiDream_User model, List<int> Roles)
        {
            var DBContext = UnitOfWork.GetPetaPocoDB();
            DBContext.BeginTransaction();
            try
            {
                object UserID=DBContext.Insert(model);
                foreach (var item in Roles)
                {
                    BeiDream_User_Role User_Role = new BeiDream_User_Role();
                    User_Role.UserID = (int)UserID;
                    User_Role.RoleID = item;
                    DBContext.Insert(User_Role);
                }
                DBContext.CompleteTransaction();
                return true;
            }
            catch (Exception)
            {
                DBContext.AbortTransaction();
                return false;
            }
        }

        public bool UpdateUserAndUserRole(BeiDream_User model, List<int> Roles)
        {
            var DBContext = UnitOfWork.GetPetaPocoDB();
            DBContext.BeginTransaction();
            try
            {
                DBContext.Update(model);
                //先删除此用户对应的角色信息
                var sql = Sql.Builder.Where("UserID=@0", model.ID);
                DBContext.Delete<BeiDream_User_Role>(sql);
                //再添加此用户对应的角色信息
                foreach (var item in Roles)
                {
                    BeiDream_User_Role User_Role = new BeiDream_User_Role();
                    User_Role.UserID = model.ID;
                    User_Role.RoleID = item;
                    DBContext.Insert(User_Role);
                }
                DBContext.CompleteTransaction();
                return true;
            }
            catch (Exception)
            {
                DBContext.AbortTransaction();
                return false;
            }
        }
    }
}