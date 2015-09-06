using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CRUD.BLL;
using CRUD.Model;
using System.Text;

namespace CRUD.UI
{
    /// <summary>
    /// UserList 的摘要说明
    /// </summary>
    public class UserList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //1.读取模板
            string html = File.ReadAllText(context.Request.MapPath("templates/UserList.htm"));
            //2.访问数据库读取所有行
            UsersBll bll = new UsersBll();
            StringBuilder sbRows = new StringBuilder();
            List<Users> list = bll.GetAllUsers();
            //遍历list集合中的数据内容
            foreach (var item in list)
            {
                sbRows.Append("<tr><td>" + item.AutoId.ToString() + "</td><td>" + item.LoginId + "</td><td>" + item.LoginPwd + "</td><td><a href=\"ProcessEdit.ashx?id=" + item.AutoId + "\">编辑</a></td><td><a href=\"ProcessDelete.ashx?id=" + item.AutoId + "\" onclick=\"return confirm('确定要删除吗？');\">删除</a></td></tr>");
            }
            //3.在模板中将真实行的数据替换对应的参数@rows
            html = html.Replace("@rows", sbRows.ToString());
            //输出到客户端
            context.Response.Write(html);
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