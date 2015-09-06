using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student.BLL;
using Student.Model;

namespace Student.UI.Server
{
    public partial class StudentAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Student.Model.StudentsModel model = new StudentsModel
            {

                SName = this.TextBox1.Text,
                SAge = int.Parse(TextBox2.Text),
                SEmail = TextBox3.Text,
                SBirthday = Convert.ToDateTime(TextBox4.Text),
                SGender = TextBox5.Text
            };
            Student.BLL.StudentManagerBLL bll = new StudentManagerBLL();
            bll.Add(model);

            Response.Redirect("StudentList.aspx");
        }
    }
}