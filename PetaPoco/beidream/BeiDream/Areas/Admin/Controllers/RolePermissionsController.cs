using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using BeiDream.UI;
using System.Dynamic;
using BeiDream.Service.Account;
using BeiDream.Models.Account;

namespace BeiDream.Areas.Admin.Controllers
{   
    [Description("角色权限管理")]
    public class RolePermissionsController : BaseController
    {
        public readonly IRoleService RoleService;

        public RolePermissionsController(IRoleService RoleService)
        {
            this.RoleService = RoleService;
        }
        //
        // GET: /Admin/RolePermissions/
        [Anonymous]
        public ActionResult Index()
        {
            return View();
        }
        [Anonymous]
        public ActionResult GetRoleListTree()
        {
            List<BeiDream_Role> ListRoles = RoleService.PetaPocoDB.Fetch<BeiDream_Role>("");
            List<dynamic> listTree = new List<dynamic>();
            foreach (var item in ListRoles)
            {
                dynamic aa = new ExpandoObject();
                aa.text = item.Name;
                aa.children = new List<dynamic>();
                listTree.Add(aa);
            }
            List<dynamic> listShowRoot = new List<dynamic>();
            dynamic bb = new ExpandoObject();
            bb.text = "用户列表";
            bb.children = listTree;
            listShowRoot.Add(bb);
            return this.ExtjsJsonResult(true, listShowRoot);
        }
    }
}
