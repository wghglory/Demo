using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //这样不如在一般处理程序写，不要再aspx写
        Response.Write(this.Request.HttpMethod);
        //this.Response.ContentType = "image/jpeg";
        //this.Response.WriteFile();
        //this.Response.ContentEncoding
        //this.Response.ContentType=
        if (!this.IsPostBack)
        {

            //第一次访问该页面
            //访问数据库填充数据
            string constr = "Data Source=steve-pc;Initial Catalog=ccdb;Integrated Security=True";
            using (SqlDataAdapter adapter = new SqlDataAdapter("select top 10 * from T_Seats", constr))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
            }
        }
    }
}