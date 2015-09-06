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
    public partial class StudentEdit : System.Web.UI.Page
    {

        protected string SId = string.Empty;
        protected string SName = string.Empty;
        protected string SAge = string.Empty;
        protected string SEmail = string.Empty;
        protected string SBirthday = string.Empty;
        protected string SGender = string.Empty;
        protected string msg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentManagerBLL bll = new StudentManagerBLL();
            if (Request["sid"] != null && Request["hi"] == null)
            {

                Student.Model.StudentsModel model = bll.GetModel(int.Parse(Request["sid"]));

                SId = model.SId.ToString();
                SName = model.SName;
                SAge = model.SAge.ToString();
                SEmail = model.SEmail;
                SBirthday = model.SBirthday.ToShortDateString();
                SGender = model.SGender;
            }
            else if (Request["txtSid"] != null && Request["hi"] != null)
            {
                Student.Model.StudentsModel model = new StudentsModel
                    {
                        SId = int.Parse(Request["txtSid"]),
                        SName = Request["txtName"],
                        SAge = Convert.ToInt32(Request["txtAge"]),
                        SEmail = Request["txtEmail"],
                        SBirthday = Convert.ToDateTime(Request["txtBirthday"]),
                        SGender = Request["txtGender"]
                    };

                if (bll.Update(model))
                {
                    Response.Redirect("StudentList.aspx");
                }
                else
                {
                    msg = "修改失败!请重试!";
                }
            }
        }
    }
}