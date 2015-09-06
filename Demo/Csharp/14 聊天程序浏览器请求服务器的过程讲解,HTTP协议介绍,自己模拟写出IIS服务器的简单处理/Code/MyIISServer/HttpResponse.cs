using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyIISServer
{
    /// <summary>
    /// 封装服务器对用户的响应信息
    /// </summary>
    public class HttpResponse
    {
        private HttpRequest httpRequest;

        public HttpResponse(HttpRequest httpRequest)
        {
            // TODO: Complete member initialization
            this.httpRequest = httpRequest;
        }

        //用来存储服务器对用户相应具体内容的属性
        public byte[] ResponseBody
        {
            get;
            set;
        }

        //响应头
        public byte[] ResponseHeader
        {
            get
            {
                //HTTP/1.1 200 OK
                //Content-Type: text/html
                //Content-Length: 913
                StringBuilder sbResponse = new StringBuilder();
                //构建响应行
                sbResponse.AppendLine("HTTP/1.1 200 OK");
                //构建响应的Content-Type:
                sbResponse.AppendLine("Content-Type: " + GetUserContentType());
                //拼接长度Content-Length:,表示的是响应正文数据的长度。
                sbResponse.AppendLine("Content-Length: " + this.ResponseBody.Length);
                sbResponse.AppendLine();
                return Encoding.UTF8.GetBytes(sbResponse.ToString());
            }
        }

        private string GetUserContentType()
        {
            string content_Type = string.Empty;
            switch (Path.GetExtension(this.httpRequest.RequestUrl))
            {
                case ".aspx":
                case ".html":
                case ".htm":
                    content_Type = "text/html; charset=utf-8";
                    break;
                case ".png":
                    content_Type = "image/png";
                    break;
                case ".gif":
                    content_Type = "image/gif";
                    break;
                case ".jpg":
                case ".jpeg":
                    content_Type = "image/jpeg";
                    break;
                case ".css":
                    content_Type = "text/css";
                    break;
                case ".js":
                    content_Type = "application/x-javascript";
                    break;
                default:
                    content_Type = "text/plain";
                    break;
            }
            return content_Type;
        }

    }
}
