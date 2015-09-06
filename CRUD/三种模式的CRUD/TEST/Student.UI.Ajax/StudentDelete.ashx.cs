using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student.BLL;

namespace Student.UI.Ajax
{
    /// <summary>
    /// StudentDelete 的摘要说明
    /// </summary>
    public class StudentDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request["sid"];
            if (id != null)
            {
                Student.BLL.StudentManagerBLL bll = new StudentManagerBLL();
                context.Response.Write(bll.Delete(int.Parse(id)) ? 1 : 0);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}