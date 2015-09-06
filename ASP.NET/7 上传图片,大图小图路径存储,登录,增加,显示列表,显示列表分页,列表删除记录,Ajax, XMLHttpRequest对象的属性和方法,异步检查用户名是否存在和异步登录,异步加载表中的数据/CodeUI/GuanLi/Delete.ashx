<%@ WebHandler Language="C#" Class="Delete" %>

using System;
using System.Web;
using IO = System.IO;

public class Delete : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        if (context.Session["UserInfo"] != null)
        {
            if (context.Request["Id"] != null)
            {
                sc0802.Bll.Aspx_NewsBll bll = new sc0802.Bll.Aspx_NewsBll();
                //开始执行删除
                //不等于null表示当前用户已登录
                //1.获取用户的Id
                string Id = context.Request["Id"];
                //一、先根据Id从数据库中删除
                //1>先获取当前记录的大图片与小图片的路径
                Model.Aspx_News model = bll.GetNewsModelByNewsId(int.Parse(Id));
                //2>从数据库中删除该操作
                int r = bll.DeleteByNewsId(int.Parse(Id));
                if (r > 0)
                {
                    //二、把数据从磁盘上删除掉
                    if (IO.File.Exists(context.Request.MapPath(model.NewsImage)))
                    {
                        IO.File.Delete(context.Request.MapPath(model.NewsImage));
                    }
                    if (IO.File.Exists(context.Request.MapPath(model.NewsSmallImage)))
                    {
                        IO.File.Delete(context.Request.MapPath(model.NewsSmallImage));
                    }
                }

                context.Response.Redirect("NewsList.aspx");
            }
            else
            {
                context.Response.Redirect("404page.htm");
            }



        }
        else
        {
            context.Response.Redirect("Login.aspx");
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