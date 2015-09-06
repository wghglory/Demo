using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student.BLL;
using System.Web.Script.Serialization;
using Student.Model;

namespace Student.UI.Ajax
{
    /// <summary>
    /// StudentEdit 的摘要说明
    /// </summary>
    public class StudentEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request["sid"];
            string action = context.Request["action"];
            if (id != null && action == "get")
            {
                Student.BLL.StudentManagerBLL bll = new StudentManagerBLL();
                Student.Model.StudentsModel model = bll.GetModel(int.Parse(id));
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

                context.Response.Write(javaScriptSerializer.Serialize(model));
            }
            else if (context.Request["txtSid"] != null && action == "up")
            {
                Student.BLL.StudentManagerBLL bll = new StudentManagerBLL();
                Student.Model.StudentsModel model = new StudentsModel();

                model.SId = Convert.ToInt32(context.Request["txtSid"]);

                model.SName = context.Request["txtName"];
                model.SAge = Convert.ToInt32(context.Request["txtAge"]);
                model.SEmail = context.Request["txtEmail"];
                model.SBirthday = Convert.ToDateTime(context.Request["txtBirthday"]);
                model.SGender = context.Request["txtGender"];

                context.Response.Write(bll.Update(model) ? 1 : 0);
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