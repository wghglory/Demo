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
namespace MaticSoft.Web.HKSJ_Main
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
		MaticSoft.BLL.HKSJ_Main bll=new MaticSoft.BLL.HKSJ_Main();
		MaticSoft.Model.HKSJ_Main model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txttitle.Text=model.title;
		this.txtcontent.Text=model.content;
		this.txttype.Text=model.type;
		this.txtDate.Text=model.Date.ToString();
		this.txtpeople.Text=model.people;
		this.txtpicUrl.Text=model.picUrl;

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
			if(this.txttype.Text.Trim().Length==0)
			{
				strErr+="type不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtDate.Text))
			{
				strErr+="Date格式错误！\\n";	
			}
			if(this.txtpeople.Text.Trim().Length==0)
			{
				strErr+="people不能为空！\\n";	
			}
			if(this.txtpicUrl.Text.Trim().Length==0)
			{
				strErr+="picUrl不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			string title=this.txttitle.Text;
			string content=this.txtcontent.Text;
			string type=this.txttype.Text;
			DateTime Date=DateTime.Parse(this.txtDate.Text);
			string people=this.txtpeople.Text;
			string picUrl=this.txtpicUrl.Text;


			MaticSoft.Model.HKSJ_Main model=new MaticSoft.Model.HKSJ_Main();
			model.ID=ID;
			model.title=title;
			model.content=content;
			model.type=type;
			model.Date=Date;
			model.people=people;
			model.picUrl=picUrl;

			MaticSoft.BLL.HKSJ_Main bll=new MaticSoft.BLL.HKSJ_Main();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
