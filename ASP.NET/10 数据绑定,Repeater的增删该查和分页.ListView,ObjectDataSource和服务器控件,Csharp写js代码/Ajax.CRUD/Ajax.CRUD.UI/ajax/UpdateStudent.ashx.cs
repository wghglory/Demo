
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;

namespace Ajax.CRUD.UI.ajax
{
    /// <summary>
    /// UpdateStudent 的摘要说明
    /// </summary>
    public class UpdateStudent : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //获取用户输入的内容，将内容构建一个model

            //stuId=18&stuName=%E8%8D%80%E7%AC%91%E7%BF%A0&stuAge=17&stuGender=%E5%A5%B3&stuEmail=ly%40yahoo.cn&stuBirthday=1988-01-12
            string stuId = context.Request["stuId"];
            string stuName = context.Request["stuName"];
            string stuGender = context.Request["stuGender"];
            string stuAge = context.Request["stuAge"];
            string stuEmail = context.Request["stuEmail"];
            string stuBirthday = context.Request["stuBirthday"];
            if (stuId != null)
            {
                //调用业务逻辑侧的更新方法
                Aspx_StudentsBll bll = new Aspx_StudentsBll();
                Aspx_Students model = new Aspx_Students()
                {
                    StuId = int.Parse(stuId),
                    StuName = stuName,
                    StuGender = stuGender,
                    StuAge = int.Parse(stuAge),
                    StuEmail = stuEmail,
                    StuBirthday = DateTime.Parse(stuBirthday)
                };
                int r = bll.Update(model);
                if (r > 0)
                {
                    //成功返回一个1. 
                    context.Response.Write("1");
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
}