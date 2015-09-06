using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.BLL;

namespace Ajax.CRUD.UI.ajax
{
    /// <summary>
    /// DeleteStudentById 的摘要说明
    /// </summary>
    public class DeleteStudentById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string sid = context.Request["sid"];
            if (sid != null)
            {
                int id = int.Parse(sid);
                //执行删除操作
                Aspx_StudentsBll bll = new Aspx_StudentsBll();
                int r = bll.DeleteByStuId(id);
                if (r > 0)
                {
                    //如果服务器返回了1，表示删除成功！
                    context.Response.Write("1");
                }

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