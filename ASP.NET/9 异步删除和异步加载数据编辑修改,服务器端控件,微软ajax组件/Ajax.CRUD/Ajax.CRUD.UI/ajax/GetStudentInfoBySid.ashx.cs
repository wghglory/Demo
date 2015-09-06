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
    /// GetStudentInfoBySid 的摘要说明
    /// </summary>
    public class GetStudentInfoBySid : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //获取sid
            string sid = context.Request["sid"];
            if (sid != null)
            {
                Aspx_StudentsBll bll = new Aspx_StudentsBll();
                //调用业务逻辑层执行查询
                Aspx_Students model = bll.GetStudentInfoBySid(int.Parse(sid));
                if (model != null)
                {
                    //才要将数据序列化响应给用户 
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    context.Response.Write(jss.Serialize(model));
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