using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ajax.CRUD.Model;
using Ajax.CRUD.BLL;

namespace Ajax.CRUD.UI.test
{
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["sid"] != null)
                {
                    int sid = Convert.ToInt32(Request["sid"]);
                    Aspx_StudentsBll bll = new Aspx_StudentsBll();
                    Aspx_Students model = bll.GetStudentInfoBySid(sid);
                    this.txtName.Text = model.StuName;
                    this.txtAge.Text = model.StuAge.ToString();
                    this.txtEmail.Text = model.StuEmail;
                    this.txtBirthday.Text = model.StuBirthday.ToString();
                    this.ddlGender.SelectedValue = model.StuGender;
                    ViewState["stuId"] = model.StuId;
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //1获取用户输入的数据
            Aspx_Students model = new Aspx_Students();
            model.StuId = Convert.ToInt32(ViewState["stuId"]);
            model.StuName = this.txtName.Text;
            model.StuAge = Convert.ToInt32(this.txtAge.Text);
            model.StuEmail = this.txtEmail.Text.Trim();
            model.StuBirthday = Convert.ToDateTime(this.txtBirthday.Text);
            model.StuGender = this.ddlGender.SelectedValue;

            //2.保存回数据库
            Aspx_StudentsBll bll = new Aspx_StudentsBll();
            bll.Update(model);
            Response.Redirect("WebForm6.aspx");
        }
    }
}