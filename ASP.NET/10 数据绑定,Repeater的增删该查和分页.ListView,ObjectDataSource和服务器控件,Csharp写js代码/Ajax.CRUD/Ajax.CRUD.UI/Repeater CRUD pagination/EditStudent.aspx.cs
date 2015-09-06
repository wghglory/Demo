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
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取sid，并根据sid从数据库中查询，将查询到的结果显示到页面的控件中 
            if (!this.IsPostBack)
            {
                if (Request["sid"] != null)
                {
                    int sid = int.Parse(Request["sid"]);
                    //第一次
                    LoadStudentData(sid);
                }

            }
        }
        //根据sid查询数据库中的数据
        private void LoadStudentData(int sid)
        {
            Aspx_StudentsBll bll = new Aspx_StudentsBll();
            Aspx_Students model = bll.GetStudentInfoBySid(sid);
            this.txtName.Text = model.StuName;
            this.txtAge.Text = model.StuAge.ToString();
            this.txtEmail.Text = model.StuEmail;
            this.txtBirthday.Text = model.StuBirthday.ToString("yyyy-MM-dd");
            this.ddlGender.SelectedValue = model.StuGender;
            ViewState["sid"] = sid;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //执行更新操作
            Aspx_Students model = new Aspx_Students();
            model.StuName = this.txtName.Text.Trim();
            model.StuAge = Convert.ToInt32(txtAge.Text);
            model.StuEmail = txtEmail.Text;
            model.StuGender = ddlGender.SelectedValue;
            model.StuBirthday = DateTime.Parse(this.txtBirthday.Text);
            model.StuId = Convert.ToInt32(ViewState["sid"]);

            Aspx_StudentsBll bll = new Aspx_StudentsBll();
            bll.Update(model);
            Response.Redirect("CRUD_Repeater.aspx");
        }
    }
}