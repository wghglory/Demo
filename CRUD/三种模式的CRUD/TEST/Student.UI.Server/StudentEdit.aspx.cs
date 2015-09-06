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
    public partial class StudentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string id = Request["sid"];
                if (id != null)
                {
                    Student.BLL.StudentManagerBLL bll = new StudentManagerBLL();
                    StudentsModel model = bll.GetModel(int.Parse(id));
                    TextBox6.Text = model.SId.ToString();
                    TextBox1.Text = model.SName;
                    TextBox2.Text = model.SAge.ToString();
                    TextBox3.Text = model.SEmail;
                    TextBox4.Text = model.SBirthday.ToLongDateString();
                    TextBox5.Text = model.SGender;

                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Student.Model.StudentsModel model = new StudentsModel
                {
                    SId = int.Parse(TextBox6.Text),
                    SName = this.TextBox1.Text,
                    SAge = int.Parse(TextBox2.Text),
                    SEmail = TextBox3.Text,
                    SBirthday = Convert.ToDateTime(TextBox4.Text),
                    SGender = TextBox5.Text
                };
            Student.BLL.StudentManagerBLL bll = new StudentManagerBLL();
            bll.Update(model);

            Response.Redirect("StudentList.aspx");
        }
    }
}