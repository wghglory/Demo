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
namespace MaticSoft.Web.HKSJ_First
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string Name= Request.Params["id"];
					ShowInfo(Name);
				}
			}
		}
			
	private void ShowInfo(string Name)
	{
		MaticSoft.BLL.HKSJ_First bll=new MaticSoft.BLL.HKSJ_First();
		MaticSoft.Model.HKSJ_First model=bll.GetModel(Name);
		this.lblName.Text=model.Name;
		this.txtMatter.Text=model.Matter;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtMatter.Text.Trim().Length==0)
			{
				strErr+="Matter不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Name=this.lblName.Text;
			string Matter=this.txtMatter.Text;


			MaticSoft.Model.HKSJ_First model=new MaticSoft.Model.HKSJ_First();
			model.Name=Name;
			model.Matter=Matter;

			MaticSoft.BLL.HKSJ_First bll=new MaticSoft.BLL.HKSJ_First();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
