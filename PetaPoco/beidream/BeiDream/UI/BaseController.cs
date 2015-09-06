using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.UI;

namespace BeiDream.UI
{
    /// <summary>
    /// Admin后台系统公共控制器(需要验证的模块)
    /// </summary>
    [PermissionFilter]
    public class BaseController:Controller
    {

    }
}