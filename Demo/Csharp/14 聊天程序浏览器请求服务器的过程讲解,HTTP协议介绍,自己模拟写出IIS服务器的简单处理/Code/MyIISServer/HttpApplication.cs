using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace MyIISServer
{
    public class HttpApplication
    {
        //这个方法就是对请求的处理
        public void ProcessRequest(HttpContext context)
        {
            //在这里该如何处理用户的请求？？
            //1.要先判断用户请求的是静态资源还是动态资源(根据后缀来判断)
            string ext = Path.GetExtension(context.Request.RequestUrl);
            if (ext == ".aspx")
            {
                //表示用户请求的是动态资源
                //http://192.168.1.100:9999/Default.aspx
                //获取请求的文件的文件名，无后缀（即获取该文件对应的后台类的名称。）
                string className = Path.GetFileNameWithoutExtension(context.Request.RequestUrl);


                //获取当前类型的命名空间
                string ns = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                // 获取当前正在执行的程序集（Default类所在的程序集）
                IHttpHandler pageHandler = (IHttpHandler)Assembly.GetExecutingAssembly().CreateInstance(ns + "." + className);
                pageHandler.ProcessRequest(context);

            }
            else
            {
                //假设其他的所有资源都是静态资源
                //1.现根据用户请求的静态资源的路径和文件名与当前程序执行的exe的路径拼接处用户请求的资源的完成的磁盘路径。 /index.htm
                //1.获取当前执行的exe的路径
                string p1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                //用户请求的静态资源的实际文件路径
                string fileName = Path.Combine(p1, "website", context.Request.RequestUrl.TrimStart('/'));

                if (File.Exists(fileName))
                {
                    //通过IO操作读取该文件，将读取到的数据设置到Response.ResponseBody中
                    context.Response.ResponseBody = File.ReadAllBytes(fileName);
                }
                else
                {
                    context.Response.ResponseBody = new byte[0];
                }


            }
        }
    }
}
