using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //LinkButton的单击事件
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //...
        Button btn = sender as Button;
        Response.Write(btn.CommandName + "     " + btn.CommandArgument.ToString());

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        ////this.FileUpload1.PostedFile
        ////this.txt1.Value;
        //this.txt1
        ////this.TextBox1.Text
        //this.TextBox1
    }
}