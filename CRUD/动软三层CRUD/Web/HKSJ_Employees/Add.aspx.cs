using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace MaticSoft.Web.HKSJ_Employees
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttitle.Text.Trim().Length==0)
			{
				strErr+="title不能为空！\\n";	
			}
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="content不能为空！\\n";	
			}
			if(this.txtpeople.Text.Trim().Length==0)
			{
				strErr+="people不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtdate.Text))
			{
				strErr+="date格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtstatus.Text))
			{
				strErr+="status格式错误！\\n";	
			}
			if(this.txtMainPeople.Text.Trim().Length==0)
			{
				strErr+="MainPeople不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string title=this.txttitle.Text;
			string content=this.txtcontent.Text;
			string people=this.txtpeople.Text;
			DateTime date=DateTime.Parse(this.txtdate.Text);
			int status=int.Parse(this.txtstatus.Text);
			string MainPeople=this.txtMainPeople.Text;

			MaticSoft.Model.HKSJ_Employees model=new MaticSoft.Model.HKSJ_Employees();
			model.title=title;
			model.content=content;
			model.people=people;
			model.date=date;
			model.status=status;
			model.MainPeople=MainPeople;

			MaticSoft.BLL.HKSJ_Employees bll=new MaticSoft.BLL.HKSJ_Employees();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
