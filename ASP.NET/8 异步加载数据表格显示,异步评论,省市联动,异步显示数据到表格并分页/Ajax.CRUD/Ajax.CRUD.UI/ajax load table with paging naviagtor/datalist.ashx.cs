using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;
using System.Web.Script.Serialization;
using Ajax.CRUD.Utility;

namespace Ajax.CRUD.UI.test
{
    /// <summary>
    /// datalist1 的摘要说明
    /// </summary>
    public class datalist1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //分页读取students表中的数据
            Aspx_StudentsBll bll = new Aspx_StudentsBll();
            int pageindex = context.Request["pageindex"] == null ? 1 : int.Parse(context.Request["pageindex"]);
            int recordcount, pagecount;
            List<Aspx_Students> list = bll.GetStudentsByPage(5, pageindex, out recordcount, out pagecount);
            var sendData = new { PageDataList = list, Navigator = PagerHelper.strPage(recordcount, 5, pagecount, pageindex, "datalist.ashx?pageindex=") };
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string datalist = jss.Serialize(sendData);
            context.Response.Write(datalist);
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