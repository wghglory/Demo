using AjaxComment.BLL;
using AjaxComment.Common;
using AjaxComment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AjaxComment.UI.Ajax_jquery
{
    /// <summary>
    /// Summary description for GetCommentByPage
    /// </summary>
    public class GetCommentByPage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int pageindex = context.Request["pageindex"] == null ? 1 : int.Parse(context.Request["pageindex"]);
            int pagesize = 5, recordcount, pagecount;


            T_MsgBLL bll = new T_MsgBLL();

            //自己写stored proc,自己写DALExt。
            IEnumerable<T_Msg> list = bll.GetDataByPage(pagesize, pageindex, out recordcount, out pagecount);

            ////使用代码生成器生成DAL.
            //IEnumerable<T_Msg> list = bll.GetPagedData(pagesize, pageindex);
            //recordcount = bll.GetTotalCount();

            //string navigatorStr = PageHelper.ShowPageNavigator(recordcount, pagesize, pageindex, "GetCommentByPage.ashx?pageindex=");

            string navigatorStr = LaomaPager.ShowPageNavigate(pagesize, pageindex, recordcount);

            var scd = new { CommentList = list, NavigatorString = navigatorStr, PageSize = pagesize, RecordCount = recordcount };

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