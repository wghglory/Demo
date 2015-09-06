using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;
using System.Web.Script.Serialization;
using System.IO;

namespace Ajax.CRUD.UI.ajax
{
    /// <summary>
    /// GetAllComments 的摘要说明
    /// </summary>
    public class GetAllComments : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1.请求数据。
            TblCommentsBll bll = new TblCommentsBll();
            List<TblComments> list = bll.GetAllComments();
            //2.把数据序列化成一个json格式的字符串返回给用户
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonString = jss.Serialize(list);
            context.Response.Write(jsonString);
            //File.WriteAllText(@"d:\json.txt", jsonString);
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