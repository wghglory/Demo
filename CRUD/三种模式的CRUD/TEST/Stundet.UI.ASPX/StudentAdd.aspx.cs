using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student.BLL;
using Student.Model;

namespace Stundet.UI.ASPX
{
    public partial class StudentAdd : System.Web.UI.Page
    {

        protected string msg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["hi"] != null)
            {
                StudentManagerBLL bll = new StudentManagerBLL();
                Student.Model.StudentsModel model = new StudentsModel
                  {
                      SName = Request["txtName"],
                      SAge = Convert.ToInt32(Request["txtAge"]),
                      SEmail = Request["txtEmail"],
                      SBirthday = Convert.ToDateTime(Request["txtBirthday"]),
                      SGender = Request["txtGender"]
                  };

                if (bll.Add(model))
                {
                    Response.Redirect("StudentList.aspx");
                }
                else
                {
                    msg = "添加失败!请重试!";
                }
            }
        }
    }
}