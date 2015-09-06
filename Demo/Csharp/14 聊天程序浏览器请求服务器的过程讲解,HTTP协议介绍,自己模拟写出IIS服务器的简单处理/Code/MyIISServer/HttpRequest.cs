using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyIISServer
{
    /// <summary>
    /// 封装用户的请求信息
    /// </summary>
    public class HttpRequest
    {
        public HttpRequest(string httpRequestMessage)
        {
            //对用户的请求报文进行解析
            //GET /index.htm HTTP/1.1
            //Accept: text/html, application/xhtml+xml, */*
            //Referer: http://localhost:32768/
            //Accept-Language: zh-CN
            //User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)
            //Accept-Encoding: gzip, deflate
            //Host: localhost:32768
            //DNT: 1
            //Connection: Keep-Alive

            string[] lines = httpRequestMessage.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] parts = lines[0].Split(' ');
            this.Method = parts[0];
            this.RequestUrl = parts[1];
        }

        /// <summary>
        /// 用户请求的方法Post/Get
        /// </summary>
        public string Method
        {
            get;
            set;
        }

        //用户请求的资源的路径/index.htm
        public string RequestUrl
        {
            get;
            set;
        }

        //访问的来路。
        public string Referer
        {
            get;
            set;
        }
    }
}
