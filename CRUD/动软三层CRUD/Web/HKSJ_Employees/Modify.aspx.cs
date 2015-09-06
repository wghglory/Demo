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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(int ID)
	{
		MaticSoft.BLL.HKSJ_Employees bll=new MaticSoft.BLL.HKSJ_Employees();
		MaticSoft.Model.HKSJ_Employees model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txttitle.Text=model.title;
		this.txtcontent.Text=model.content;
		this.txtpeople.Text=model.people;
		this.txtdate.Text=model.date.ToString();
		this.txtstatus.Text=model.status.ToString();
		this.txtMainPeople.Text=model.MainPeople;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int ID=int.Parse(this.lblID.Text);
			string title=this.txttitle.Text;
			string content=this.txtcontent.Text;
			string people=this.txtpeople.Text;
			DateTime date=DateTime.Parse(this.txtdate.Text);
			int status=int.Parse(this.txtstatus.Text);
			string MainPeople=this.txtMainPeople.Text;


			MaticSoft.Model.HKSJ_Employees model=new MaticSoft.Model.HKSJ_Employees();
			model.ID=ID;
			model.title=title;
			model.content=content;
			model.people=people;
			model.date=date;
			model.status=status;
			model.MainPeople=MainPeople;

			MaticSoft.BLL.HKSJ_Employees bll=new MaticSoft.BLL.HKSJ_Employees();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
