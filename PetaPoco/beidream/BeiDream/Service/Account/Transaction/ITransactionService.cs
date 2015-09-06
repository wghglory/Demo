using BeiDream.Framework.Data;
using BeiDream.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeiDream.Service.Account
{
    public interface ITransactionService
    {
        /// <summary>
        /// 获取 当前单元操作对象
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
        /// <summary>
        /// 删除用户信息的同时删除此用户关联的角色信息对应数据
        /// </summary>
        /// <param name="Users"></param>
        /// <returns></returns>
        bool DeleteUserAndUserRole(List<BeiDream_User> Users);
                /// <summary>
        /// 删除用户信息的同时删除此用户关联的角色信息对应数据
        /// </summary>
        /// <param name="Users"></param>
        /// <returns></returns>
        bool DeleteUserAndUserRole(List<object> UsersID);
        /// <summary>
        /// 删除角色信息的同时删除此角色关联的用户信息对应数据
        /// </summary>
        /// <param name="Roles"></param>
        /// <returns></returns>
        bool DeleteRoleAndUserRole(List<BeiDream_Role> Roles);
        /// <summary>
        /// 新增用户，并新增其对应的角色信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Roles"></param>
        /// <returns></returns>
        bool AddUserAndUserRole(BeiDream_User model, List<int> Roles);
        /// <summary>
        /// 修改用户，并修改其对应的角色信息(实现是，先删除此用户对应的角色信息，再新增）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Roles"></param>
        /// <returns></returns>
        bool UpdateUserAndUserRole(BeiDream_User model, List<int> Roles);
    }
}