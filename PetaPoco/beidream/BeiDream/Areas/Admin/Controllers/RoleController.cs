using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Framework.Data;
using BeiDream.Models.Account;
using BeiDream.Service.Account;
using BeiDream.UI;
using System.IO;
using BeiDream.Framework.Common;
using BeiDream.UI.ViewModel;
using System.ComponentModel;

namespace BeiDream.Areas.Admin.Controllers
{
    [Description("角色管理")]
    public class RoleController : BaseController
    {
        public readonly IRoleService RoleService;
        public readonly IUserRoleService UserRoleService;
        public readonly ITransactionService TransactionService;

        public RoleController(IRoleService RoleService, ITransactionService TransactionService, IUserRoleService UserRoleService)
        {
            this.RoleService = RoleService;
            this.UserRoleService = UserRoleService;
            this.TransactionService = TransactionService;
        }
        #region 角色管理
        //
        // GET: /Admin/Role/
        [DefaultPage]
        [Anonymous]
        public ActionResult RoleManage()
        {
            return View();
        }
        /// <summary>
        /// 带分页的查询方法
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="start">开始的id</param>
        /// <param name="limit">分页大学</param>
        /// <param name="roleName">查询条件</param>
        /// <returns></returns>
        [Anonymous]
        public ActionResult GetRoleList(int page, int start, int limit, string roleName)
        {
            FilterGroup group = new FilterGroup();
            List<FilterRule> list = new List<FilterRule>();
            group.rules = list;
            if (!string.IsNullOrEmpty(roleName))
            {
                list.Add(new FilterRule("name", roleName, RuleOperatorQueryEnum.like));
            }
            PagedList<BeiDream_Role> PageList = RoleService.GetPagedList(page, limit, group);
            return this.ExtjsGridJsonResult(PageList, PageList.TotalItemCount);
        }
        /// <summary>
        /// 返回数据库新增后的实体，供前台的extjs的 grid的store更新数据，这样就不需要进行重新加载store了,删，改类似
        /// </summary>
        /// <param name="Roles"></param>
        /// <returns></returns>
        [Anonymous]
        [HttpPost]
        public ActionResult Add(List<BeiDream_Role> Roles)
        {
            List<BeiDream_Role> AddRoles = new List<BeiDream_Role>();
            List<Object> ListObj = RoleService.Add(Roles);
            if (ListObj.Count == 0)
            {
                List<string> msg = new List<string>();
                msg.Add("添加角色失败！");
                return this.ExtjsJsonResult(false, msg);
            }
            else
            {
                foreach (var item in ListObj)
                {
                    AddRoles.Add(RoleService.GetModelByID(item));
                }
                List<string> msg = new List<string>();
                msg.Add("添加角色成功！");
                return this.ExtjsJsonResult(true, AddRoles, msg);
            }

        }
        [Anonymous]
        public ActionResult Remove(List<BeiDream_Role> Roles)
        {
            bool IsSuccess = TransactionService.DeleteRoleAndUserRole(Roles);
            List<string> msg = new List<string>();
            msg.Add(IsSuccess ? "删除角色成功！" : "删除角色失败！");
            return this.ExtjsJsonResult(IsSuccess, Roles, msg);
        }
        [Anonymous]
        public ActionResult Update(List<BeiDream_Role> Roles)
        {
            bool IsSuccess = RoleService.Update(Roles);
            List<string> msg = new List<string>();
            msg.Add(IsSuccess ? "修改角色成功！" : "修改角色失败！");
            return this.ExtjsJsonResult(IsSuccess, Roles, msg);
        }
        [Anonymous]
        public ActionResult ValidateInput(BeiDream_Role Role, bool IsAdd)
        {
            List<string> msg = new List<string>();
            if (IsAdd)
            {
                FilterGroup userRoleGroup = new FilterGroup();
                FilterHelper.CreateFilterGroup(userRoleGroup, null, "Name", Role.Name, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.equal);
                bool IsExist = RoleService.IsExist(userRoleGroup);
                msg.Add(IsExist ? "角色名称已存在！" : "");
                return this.ExtjsJsonResult(IsExist, msg);
            }
            else
            {
                FilterGroup userRoleGroup = new FilterGroup();
                FilterHelper.CreateFilterGroup(userRoleGroup, null, "Name", Role.Name, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.equal);
                FilterHelper.CreateFilterGroup(userRoleGroup, null, "ID", Role.ID, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.notequal);
                bool IsExist = RoleService.IsExist(userRoleGroup);
                msg.Add(IsExist ? "角色名称已存在！" : "");
                return this.ExtjsJsonResult(IsExist, msg);
            }
        } 
        #endregion

        #region 用户管理-角色选择功能
        [Anonymous]
        public ActionResult GetRoleListGroup()
        {
            List<BeiDream_Role> ListRole = RoleService.PetaPocoDB.Fetch<BeiDream_Role>("");
            List<UserRoleGroup> ListUserRoleGroup = GetUserRoleGroup(ListRole);
            return this.ExtjsJsonResult(true, ListUserRoleGroup);
        }
        /// <summary>
        /// 设置角色是否包含当前选择的用户
        /// </summary>
        /// <param name="ListRole"></param>
        /// <returns></returns>
        private List<UserRoleGroup> GetUserRoleGroup(List<BeiDream_Role> ListRole)
        {
            object SelectUserID = SessionHelper.Get("SelectUserID");
            List<UserRoleGroup> ListUserRoleGroup = new List<UserRoleGroup>();
            if (SelectUserID == null)
            {
                foreach (var item in ListRole)
                {
                    UserRoleGroup model = new UserRoleGroup();
                    model.ID = item.ID;
                    model.Name = item.Name;
                    model.IsContainCurrentUser = false;
                    ListUserRoleGroup.Add(model);
                }
                return ListUserRoleGroup;
            }
            foreach (var item in ListRole)
            {
                UserRoleGroup model = new UserRoleGroup();
                model.ID = item.ID;
                model.Name = item.Name;
                FilterGroup userRoleGroup = new FilterGroup();
                FilterHelper.CreateFilterGroup(userRoleGroup, null, "RoleID", item.ID, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.equal);
                FilterHelper.CreateFilterGroup(userRoleGroup, null, "UserID", SelectUserID, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.equal);
                model.IsContainCurrentUser = UserRoleService.IsExist(userRoleGroup);
                ListUserRoleGroup.Add(model);
            }
            return ListUserRoleGroup;
        } 
        #endregion
    }
}
