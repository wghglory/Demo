using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;
using Ajax.CRUD.Utility;
using System.Web.Script.Serialization;

namespace Ajax.CRUD.UI.ajax
{
    /// <summary>
    /// GetStudentsByPage 的摘要说明
    /// </summary>
    public class GetStudentsByPage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //获取用户要查看第几页
            int pageindex = context.Request["pageindex"] == null ? 1 : int.Parse(context.Request["pageindex"]);
            int pagesize = 5, recordcount, pagecount;

            //根据用户要查看第几页，调用业务逻辑层获取该数据
            Aspx_StudentsBll bll = new Aspx_StudentsBll();
            List<Aspx_Students> _list = bll.GetStudentsByPage(pagesize, pageindex, out recordcount, out pagecount);

            //根据用户查看的页的信息，返回分页导航的内容
            //生成导航内容
            string navigatorStr = PagerHelper.strPage(recordcount, pagesize, pagecount, pageindex, "GetStudentsByPage.ashx?pageindex=");

            //把list集合数据，以及导航字符串都封装到一个对象中。
            SendClientData scd = new SendClientData();
            scd.StudentList = _list;
            scd.NavigatorString = navigatorStr;

            //把scd对象通过json序列化成一个json字符串
            JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.Write(jss.Serialize(scd));
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