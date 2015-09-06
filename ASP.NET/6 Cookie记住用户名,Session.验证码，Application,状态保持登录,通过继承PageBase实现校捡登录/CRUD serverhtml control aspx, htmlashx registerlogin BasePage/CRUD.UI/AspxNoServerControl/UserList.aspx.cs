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
    public partial class UserList : System.Web.UI.Page
    {
        protected List<Users> _listUsers = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            string delId = this.Request["delId"];
            if (delId != null)
            {
                //表示要执行删除操作
                BLL.UsersBll bll = new UsersBll();
                bll.Delete(int.Parse(delId));
                //删除完毕重新加载数据
                LoadData();
            }
            else
            {
                //表示是直接访问UserList.aspx页面，要查看数据
                LoadData();
            }

        }

        private void LoadData()
        {
            //直接访问数据库
            UsersBll bll = new UsersBll();
            _listUsers = bll.GetAllUsers();
        }
    }
}