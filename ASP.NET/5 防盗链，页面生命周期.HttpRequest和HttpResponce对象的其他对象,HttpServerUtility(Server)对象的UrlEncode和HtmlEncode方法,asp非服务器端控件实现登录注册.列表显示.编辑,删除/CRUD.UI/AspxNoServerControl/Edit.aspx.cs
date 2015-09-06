using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.BLL;
using CRUD.Model;

namespace CRUD.UI.AspxNoServerControl
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request["hiddenIsPostback"] != null && this.Request["hiddenIsPostback"] == "true")//判断是否是第一次访问
            {
                //表示是回发.第一次get请求
                //回发过来就要执行更新操作
                UsersBll bll = new UsersBll();
                Users model = new Users();
                model.AutoId = int.Parse(this.Request["txtAutoId"]);
                model.ErrorCount = int.Parse(this.Request["txtErrorCount"]);
                model.LastLoginTime = DateTime.Parse(this.Request["txtLastLoginTime"]);
                model.LoginId = this.Request["txtLoginId"];
                model.LoginPwd = this.Request["txtPwd"];
                bll.Update(model);
                this.Response.Redirect("UserList.aspx");
            }
            else
            {
                LoadData();
            }


        }

        private void LoadData()
        {
            //根据用户请求的autoid,加载对应的数据
            string editId = this.Request["EditId"];
            if (editId != null)
            {
                //查询Id为editId的记录的所有信息
                UsersBll bll = new UsersBll();

                _model = bll.GetUserInfoByAutoId(int.Parse(editId));
                
            }
        }

        protected Users _model;
    }
}