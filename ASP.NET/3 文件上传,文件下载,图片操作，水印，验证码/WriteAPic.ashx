<%@ WebHandler Language="C#" Class="WriteAPic" %>

using System;
using System.Web;
using System.Drawing;

public class WriteAPic : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";
        //把磁盘中现有的图片直接读取，并输出给用户
        //context.Response.WriteFile("download/1.jpg");

        //手动创建一张图片
        //1。创建一张图
        using (Image image = new Bitmap(700, 300))
        {
            //在这张图片上画一些文字（字符串）
            using (Graphics g=Graphics.FromImage(image))
            {
                //开始画字符串
                g.DrawString("黄林，" + context.Request.UserAgent, new Font("幼圆", 10), Brushes.Yellow, new PointF(10,10));
            }

            //把图片输出到用户的响应流中
            image.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
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