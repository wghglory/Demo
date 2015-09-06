using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // this.Button2.OnClientClick = "alert((new Date()).toString());";
        this.Button2.OnClientClick = "return confirm('确定吗？');";
        this.Button1.Attributes.Add("UserName", "黄林");
        this.TextBox1.Attributes["onmouseover"] = "this.style.backgroundColor='red';";
        this.Label1.AssociatedControlID = "TextBox1";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("aaaaaaa");
        File.WriteAllText(@"d:\1.txt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss:ms"));
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        this.TextBox2.BackColor = Color.Blue;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // this.Button2.ForeColor = Color.Red;
        this.Button2.BackColor = Color.Blue;
        this.Button2.Text = "aaaaaaaaaaaaaa";
    }
}