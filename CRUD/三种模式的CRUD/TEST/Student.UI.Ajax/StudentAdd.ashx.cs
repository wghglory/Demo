using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student.BLL;
using Student.Model;

namespace Student.UI.Ajax
{
    /// <summary>
    /// StudentAdd 的摘要说明
    /// </summary>
    public class StudentAdd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Student.BLL.StudentManagerBLL bll = new StudentManagerBLL();
            Student.Model.StudentsModel model = new StudentsModel();

            model.SName = context.Request["txtName"];
            model.SAge = Convert.ToInt32(context.Request["txtAge"]);
            model.SEmail = context.Request["txtEmail"];
            model.SBirthday = Convert.ToDateTime(context.Request["txtBirthday"]);
            model.SGender = context.Request["txtGender"];

            context.Response.Write(bll.Add(model) ? 1 : 0);
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