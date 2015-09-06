using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyIISServer
{

    /// <summary>
    /// 这个Default类就是默认Default.aspx对应的后台代码文件。
    /// </summary>
    public class Default : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            StringBuilder sbHtml = new StringBuilder();
            sbHtml.Append("<html><head><title>这是我的第一个网页</title></head><body>");

            for (int i = 0; i < 5; i++)
            {
                sbHtml.Append("<h1>" + DateTime.Now.ToString() + "</h1>");
            }
            sbHtml.Append("</body></html>");

            context.Response.ResponseBody = Encoding.UTF8.GetBytes(sbHtml.ToString());

        }
    }
}
