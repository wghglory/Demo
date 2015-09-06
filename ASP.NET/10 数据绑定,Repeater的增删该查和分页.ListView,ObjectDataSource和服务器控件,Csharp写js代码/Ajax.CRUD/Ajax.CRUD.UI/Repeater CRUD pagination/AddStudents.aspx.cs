using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;

namespace Ajax.CRUD.UI.ObjectDataSource
{
    public partial class AddStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //增加一条数据
            //获取用户的输入

            Aspx_Students model = new Aspx_Students();
            Aspx_StudentsBll bll = new Aspx_StudentsBll();
            model.StuName = this.txtName.Text;
            model.StuEmail = this.txtEmail.Text;
            model.StuGender = this.ddlGender.SelectedValue;
            model.StuAge = int.Parse(this.txtAge.Text);
            model.StuBirthday = DateTime.Parse(this.txtBirthday.Text);
            bll.Add(model);
            Response.Redirect("crud_repeater.aspx");
        }
    }
}