<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Drawing;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.Buffer = false;
        context.Response.Write("aaaaaaa");
        context.Response.ContentType = "image/jpeg";
        Uri referrerUrl = context.Request.UrlReferrer;
        Uri requestUrl = context.Request.Url;   //自己网站的请求

        if (Uri.Compare(referrerUrl, requestUrl, UriComponents.HostAndPort, UriFormat.SafeUnescaped, StringComparison.CurrentCulture) == 0)
        {
            //本网站的访问
            context.Response.WriteFile("人民艺术.jpg");
        }

        //if (referrerUrl != null && referrerUrl.Host == "localhost")
        //{
        //    context.Response.WriteFile("人民艺术.jpeg");
        //}
        else
        {
            using (Image img = new Bitmap(500, 200))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.Clear(Color.Yellow);
                    //g.DrawString("禁止外部访问！！！！", new Font("宋体", 20), Brushes.Black, new PointF(20, 20));

                    g.DrawString(context.Request.UserHostAddress, new Font("宋体", 20), Brushes.Black, new PointF(20, 20));
                }
                img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}