using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student.BLL;
using Student.Model;
using Utility;

namespace Stundet.UI.ASPX
{
    public partial class StudentList : System.Web.UI.Page
    {
        protected List<Student.Model.StudentsModel> list = new List<StudentsModel>();
        protected string pageStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Student.BLL.StudentManagerBLL bll = new StudentManagerBLL();
            int count = bll.GetDataAllCount();
            int pagecount = (int)Math.Ceiling((count * 1.0) / 5);

            int thispage = Convert.ToInt32(Request["pageindex"] ?? "1");
            pageStr = Utility.PagerHelper.strPage(count, 5, pagecount, thispage, "StudentList.aspx?pageindex=");
            list = bll.GetList(5, thispage);
        }
    }
}