<%@ WebHandler Language="C#" Class="ShuiYin" %>

using System;
using System.Web;
using System.Drawing;

public class ShuiYin : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";
        //读取原图
        using (System.Drawing.Image img = System.Drawing.Image.FromFile(context.Request.MapPath("download/1.jpg")))
        {
            //读取水印图片
            using (Image imgWater = Image.FromFile(context.Server.MapPath("download/2.png")))
            {
                //创建一个“画布”
                using (Graphics g = Graphics.FromImage(img))
                {
                    //把水印图片画到“原图”上
                    g.DrawImage(imgWater, new Rectangle(100, 100, imgWater.Width, imgWater.Height), new Rectangle(0, 0, imgWater.Width, imgWater.Height), GraphicsUnit.Pixel);
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