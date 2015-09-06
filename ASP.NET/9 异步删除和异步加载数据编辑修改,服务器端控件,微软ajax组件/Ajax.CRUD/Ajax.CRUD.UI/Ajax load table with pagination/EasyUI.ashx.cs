using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;

namespace Ajax.CRUD.UI.test
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Aspx_StudentsBll bll = new Aspx_StudentsBll();
            int recordcount, pagecount;
            List<Aspx_Students> list = bll.GetStudentsByPage(10, 1, out recordcount, out pagecount);
            //序列化
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var sendData = new { total = recordcount, rows = list };
            context.Response.Write(jss.Serialize(sendData));
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