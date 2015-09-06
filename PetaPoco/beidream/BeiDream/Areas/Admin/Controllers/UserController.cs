using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Framework.Common;
using Newtonsoft.Json.Linq;
using BeiDream.Models.Account;
using BeiDream.UI;
using BeiDream.Framework.Data;
using BeiDream.Service.Account;
using BeiDream.UI.ViewModel;
using Util.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BeiDream.Areas.Admin.Controllers
{
    [Description("用户管理")]
    public class UserController : BaseController
    {
        public readonly IUserRoleService UserRoleService;
        public readonly IUserService UserService;
        public readonly ITransactionService TransactionService;
        public readonly IValidation Validation;
        public UserController(IUserService UserService, IUserRoleService UserRoleService, ITransactionService TransactionService, IValidation Validation)
        {
            this.UserRoleService = UserRoleService;
            this.UserService = UserService;
            this.TransactionService = TransactionService;
            this.Validation = Validation;
        }
        //
        // GET: /Admin/User/

        #region 登录部分
        [Anonymous]
        public ActionResult Login()
        {
            ViewBag.Title = "登录";
            return View();
        }
        [Anonymous]
        public FileContentResult GetVerifyCode()
        {
            VerifyCode v = new VerifyCode();
            string code = v.CreateVerifyCode();                //取随机码
            //Session["vcode"] = code;
            SessionHelper.SetSession("vcode", code);
            v.Padding = 10;
            byte[] bytes = v.CreateImage(code);
            return File(bytes, @"image/jpeg");
        }
        [Anonymous]
        [HttpPost]
        public JObject Login(LoginModel model)
        {
            bool success = false;
            JObject errors = new JObject();
            if (ModelState.IsValid)
            {
                string vcode = "";
                if (Session["vcode"] != null)
                {
                    vcode = Session["vcode"].ToString();
                }
                if (vcode.Count() > 0 && vcode.ToLower() == model.Vcode.ToLower())
                {
                    BeiDream_User User = new BeiDream_User();
                    if (model.UserName.ToLower() == "admin" && model.Password == "123456")
                    {
                        success = true;
                        SessionHelper.SetSession("UserID", User.ID);
                    }
                    else
                    {
                        errors.Add("UserName", "错误的用户名或密码。");
                        errors.Add("Password", "错误的用户名或密码。");
                    }
                }
                else
                {
                    errors.Add("Vcode", "验证码错误");
                }
            }
            else
            {

                JsonNet.ModelStateToJObject(ModelState, errors);
            }
            return JsonNet.WriteJObjectResult(success, errors);
        }
        public ActionResult Logout()
        {
            SessionHelper.Del("UserID");    //Session里的UserID是否存在判断用户是否登录
            return RedirectToAction("Index", "Home");
        } 
        #endregion

        #region 用户管理
        [DefaultPage]
        [Anonymous]
        public ActionResult Index()
        {
            return View();
        }
        [Anonymous]
        public ActionResult UserList()
        {
            return View();
        }
        [Anonymous]
        public ActionResult UserDetail()
        {
            return View();
        }
        [Anonymous]
        public ActionResult SaveSelectId(int id)
        {
            SessionHelper.SetSession("SelectUserID", id);
            return this.ExtjsJsonResult(true);
        }
        [Anonymous]
        public ActionResult GetUserModel(int id)
        {
            object SelectUserID = SessionHelper.Get("SelectUserID");
            if (SelectUserID != null)
            {
                BeiDream_User model = UserService.PetaPocoDB.SingleOrDefault<BeiDream_User>(SelectUserID);
                return this.ExtjsJsonResult(true,model);
            }
            else
            {
                return this.ExtjsJsonResult(true);
            }
        }
        /// <summary>
        /// 清空之前选中的用户session
        /// </summary>
        /// <returns></returns>
        [Anonymous]
        public ActionResult RemoveSelectId()
        {
            SessionHelper.Del("SelectUserID");
            return this.ExtjsJsonResult(true);
        }
        [Anonymous]
        public ActionResult DeleteCurrentUser()
        {
            object SelectUserID = SessionHelper.Get("SelectUserID");
            if (SelectUserID == null)
            {
                List<string> msg = new List<string>();
                msg.Add("当前未选中任何用户！");
                return this.ExtjsJsonResult(true, msg);
            }
            else
            {
                List<object> UsersID=new List<object>();
                UsersID.Add(SelectUserID);
                bool DeleteSuccess = TransactionService.DeleteUserAndUserRole(UsersID);
                List<string> msg = new List<string>();
                msg.Add(DeleteSuccess ? "删除用户成功！" : "删除用户失败！");
                return this.ExtjsJsonResult(true, msg);
            }
        }
        [Anonymous]
        public ActionResult SaveUser(BeiDream_User model, List<int> Roles)
        {
            var ValidateResult = Validation.Validate(model);//服务器端的验证
            if (ValidateResult.IsValid)     //验证成功
            {
                bool IsExitUser = UserService.PetaPocoDB.Exists<BeiDream_User>(model.ID);
                if (!IsExitUser)
                {
                    FilterGroup userRoleGroup = new FilterGroup();
                    FilterHelper.CreateFilterGroup(userRoleGroup, null, "UserName", model.UserName, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.equal);
                    bool IsExist = UserService.IsExist(userRoleGroup);
                    if (IsExist)
                    {
                        List<string> errorName=new List<string>();
                        errorName.Add("UserName");
                        ValidationResult error = new ValidationResult("已存在相同的用户名", errorName);
                        ValidateResult.Add(error);
                         return this.ExtjsFromJsonResult(false,ValidateResult); 
                    }
                    else
                    {
                        bool IsSaveSuccess = TransactionService.AddUserAndUserRole(model, Roles);
                        List<string> msg = new List<string>();
                        msg.Add(IsSaveSuccess ? "用户信息保存成功！" : "用户信息保存失败！");
                        return this.ExtjsFromJsonResult(true, null, msg); 
                    }
                }
                else
                {
                    FilterGroup userRoleGroup = new FilterGroup();
                    FilterHelper.CreateFilterGroup(userRoleGroup, null, "UserName", model.UserName, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.equal);
                    FilterHelper.CreateFilterGroup(userRoleGroup, null, "ID", model.ID, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.notequal);
                    bool IsExist = UserService.IsExist(userRoleGroup);
                    if (IsExist)
                    {
                        List<string> errorName = new List<string>();
                        errorName.Add("UserName");
                        ValidationResult error = new ValidationResult("已存在相同的用户名", errorName);
                        ValidateResult.Add(error);
                        return this.ExtjsFromJsonResult(false, ValidateResult); 
                    }
                    else
                    {
                        bool IsSaveSuccess = TransactionService.UpdateUserAndUserRole(model, Roles);
                        List<string> msg = new List<string>();
                        msg.Add(IsSaveSuccess ? "用户信息保存成功！" : "用户信息保存失败！");
                        return this.ExtjsFromJsonResult(true, null, msg); 
                    }
                }
            }
            else
            {
                return this.ExtjsFromJsonResult(false,ValidateResult);   //验证失败，返回失败的验证结果,给出前台提示信息
            }          
        }
        [Anonymous]
        public ActionResult GetUserList(int page, int start, int limit, string UserKeyName, string RoleID)
        {
            RemoveSelectId();
            PagedList<BeiDream_User> PageList = null;
            FilterGroup userGroup = GetQueryConditions(UserKeyName, RoleID);
            PageList = UserService.GetPagedList(page, limit, userGroup);
            return this.ExtjsGridJsonResult(PageList, PageList.TotalItemCount);
        }
        private FilterGroup GetQueryConditions(string UserKeyName, string RoleID)
        {
            FilterGroup userGroup = new FilterGroup();
            if (!string.IsNullOrEmpty(RoleID))             //用户角色不为空时
            {
                FilterGroup userRoleGroup = new FilterGroup();
                FilterHelper.CreateFilterGroup(userRoleGroup, null, "RoleID", RoleID, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.equal);
                //先根据用户角色查出对应的用户ID
                List<BeiDream_User_Role> List = UserRoleService.GetList(userRoleGroup);
                if (List.Count != 0)             //todo,此角色信息为空情况下，查到的用户也应该为空,目前未处理
                {
                    if (string.IsNullOrEmpty(UserKeyName))
                    {
                        //再根据此用户角色下的用户ID，因为查出所以用户ID，查询条件是或的关系GroupOperatorQueryEnum.or，翻译出对应用户的查询条件，最后查出对应用户
                        foreach (var item in List)
                        {
                            FilterHelper.CreateFilterGroup(userGroup, null, "ID", item.UserID, GroupOperatorQueryEnum.or, RuleOperatorQueryEnum.equal);
                        }
                    }
                    else
                    {
                        //先翻译出用户名查询条件,与其他查询条件是与的关系GroupOperatorQueryEnum.and
                        FilterHelper.CreateFilterGroup(userGroup, null, "UserName", UserKeyName, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.like);
                        //因为第二个查询条件是多个查询条件的结合组成再与第一个查询条件结合，故放到子FilterGroup中
                        List<FilterGroup> filterGroups = new List<FilterGroup>();
                        FilterGroup userIDGroup = new FilterGroup();
                        //再根据此用户角色下的用户ID，因为查出所以用户ID，查询条件是或的关系GroupOperatorQueryEnum.or，翻译出对应用户的查询条件，最后查出对应用户
                        foreach (var item in List)
                        {
                            FilterHelper.CreateFilterGroup(userIDGroup, null, "ID", item.UserID, GroupOperatorQueryEnum.or, RuleOperatorQueryEnum.equal);
                        }
                        filterGroups.Add(userIDGroup);
                        userGroup.groups = filterGroups;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(UserKeyName))
                {
                    //先翻译出用户名查询条件,与其他查询条件是与的关系GroupOperatorQueryEnum.and
                    FilterHelper.CreateFilterGroup(userGroup, null, "UserName", UserKeyName, GroupOperatorQueryEnum.and, RuleOperatorQueryEnum.like);
                }
            }
            return userGroup;
        } 
        #endregion
    }
}
