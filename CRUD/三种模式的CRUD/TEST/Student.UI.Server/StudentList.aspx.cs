using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student.BLL;

namespace Student.UI.Server
{
    public partial class StudentList : System.Web.UI.Page
    {
        protected string pageStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {


            Student.BLL.StudentManagerBLL bll = new StudentManagerBLL();


            int pageSize = 5;
            int count = bll.GetDataAllCount();
            int pagecount = (int)Math.Ceiling((count * 1.0) / pageSize);
            int thisPage = Convert.ToInt32(Request["pageindex"] ?? "1");
            pageStr = Utility.PagerHelper.strPage(count, pageSize, pagecount, thisPage, "StudentList.aspx?pageindex=");


            Repeater1.DataSource = bll.GetList(pageSize, thisPage);
            Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}