using System;
using System.Web.Mvc;

namespace MVC5
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class MyActionFilterAttribute : ActionFilterAttribute//间接继承自Attribute
    {
        public string Name { get; set; }
        //Action 执行之前
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.HttpContext.Response.Write("<br />OnActionExecuting:" + Name);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            filterContext.HttpContext.Response.Write("<br />OnActionExecuted:" + Name);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            filterContext.HttpContext.Response.Write("<br />OnResultExecuted:" + Name);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            filterContext.HttpContext.Response.Write("<br />OnResultExecuting:" + Name);
        }


    }
}