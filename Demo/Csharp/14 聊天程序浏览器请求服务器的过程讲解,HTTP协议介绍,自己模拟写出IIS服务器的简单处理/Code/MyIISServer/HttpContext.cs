using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyIISServer
{
    /// <summary>
    /// 封装Request对象和Response对象
    /// </summary>
    public class HttpContext
    {
        public HttpContext(string reqStr)
        {
            //1.对用户传递过来的请求报文进行解析
            //解析后分别保存到Request对象与Response对象中。
            //把请求报文继续传递给HttpRequest对象，有HttpRequest对象来对请求报文进行解析
            this.Request = new HttpRequest(reqStr);

            //创建一个用来相应用户的HttpResponse对象。
            this.Response = new HttpResponse(this.Request);

        }

        public HttpRequest Request
        {
            get;
            set;
        }

        public HttpResponse Response
        {
            get;
            set;
        }
    }
}
