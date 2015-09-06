<%@ WebHandler Language="C#" Class="ProcessUpload" %>

using System;
using System.Web;

public class ProcessUpload : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //1.服务器端接收用户的请求数据
        //1.1获取用户发送过来的文件
        if (context.Request.Files.Count > 0)
        {
            //context.Request.Files["file1"]
            HttpPostedFile file = context.Request.Files[0];
            //file.ContentLength,通过http请求报文获取文件的大小
            string fileOri = System.IO.Path.GetFileName(file.FileName);
            string newfilename = Guid.NewGuid().ToString() + "_" + fileOri;

            //返回当前字符串的一个哈希值
            int hashcode = newfilename.GetHashCode();
            int dir1 = hashcode & 0xf;//计算出了第一级目录的值
            //计算第二级目录
            int dir2 = (hashcode >> 4) & 0xf;

            //在磁盘上创建该目录
            System.IO.Directory.CreateDirectory(context.Request.MapPath("upload/" + dir1.ToString() + "/" + dir2.ToString() + "/"));

            //1.2将文件保存到服务器的某个目录下
            file.SaveAs(context.Server.MapPath("upload/" + dir1.ToString() + "/" + dir2.ToString() + "/" + newfilename));
            
            
            //类似一些收费资源的时候可以这么做。
            //当用户向请求该资源的时候，通过让用户请求某个一般处理程序，在这个一般处理程序中，通过文件操作，获取磁盘上的某个资源然后把该资源读取到内容中，再发送给客户端。
            //file.SaveAs(@"d:\abc\" + newfilename);
            context.Response.Write("ok");
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