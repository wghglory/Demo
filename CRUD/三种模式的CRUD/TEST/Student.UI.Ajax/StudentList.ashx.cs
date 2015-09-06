using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Student.BLL;
using Student.Model;

namespace Student.UI.Ajax
{
    /// <summary>
    /// StudentList 的摘要说明
    /// </summary>
    public class StudentList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            List<Student.Model.StudentsModel> list = new List<StudentsModel>();

            Student.BLL.StudentManagerBLL bll = new StudentManagerBLL();
            int count = bll.GetDataAllCount();
            int pagecount = (int)Math.Ceiling((count * 1.0) / 5);

            int thispage = Convert.ToInt32(context.Request["pageindex"] ?? "1");
            string pageStr = Utility.PagerHelper.strPage(count, 5, pagecount, thispage, "StudentList.ashx?pageindex=");
            list = bll.GetList(5, thispage);

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

            Datahelper datahelper = new Datahelper { StrPage = pageStr, listStudentModel = list };
            context.Response.Write(javaScriptSerializer.Serialize(datahelper));
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