using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.Model;
using Ajax.CRUD.BLL;
using System.Web.Script.Serialization;

namespace Ajax.CRUD.UI.ajax
{
    /// <summary>
    /// GetAllStudents 的摘要说明
    /// </summary>
    public class GetAllStudents : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Aspx_StudentsBll bll = new Aspx_StudentsBll();
            List<Aspx_Students> list = bll.GetAllStudents();
            //序列化
            JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.Write(jss.Serialize(list));
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