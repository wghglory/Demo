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
namespace MaticSoft.Web.HKSJ_Relationship
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
		MaticSoft.BLL.HKSJ_Relationship bll=new MaticSoft.BLL.HKSJ_Relationship();
		MaticSoft.Model.HKSJ_Relationship model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtAddress.Text=model.Address;
		this.txtZip.Text=model.Zip;
		this.txtplane.Text=model.plane;
		this.txtFax.Text=model.Fax;
		this.txtQQ_MSN.Text=model.QQ_MSN;
		this.txtDate.Text=model.Date.ToString();
		this.txtpeople.Text=model.people;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtAddress.Text.Trim().Length==0)
			{
				strErr+="Address不能为空！\\n";	
			}
			if(this.txtZip.Text.Trim().Length==0)
			{
				strErr+="Zip不能为空！\\n";	
			}
			if(this.txtplane.Text.Trim().Length==0)
			{
				strErr+="plane不能为空！\\n";	
			}
			if(this.txtFax.Text.Trim().Length==0)
			{
				strErr+="Fax不能为空！\\n";	
			}
			if(this.txtQQ_MSN.Text.Trim().Length==0)
			{
				strErr+="QQ_MSN不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtDate.Text))
			{
				strErr+="Date格式错误！\\n";	
			}
			if(this.txtpeople.Text.Trim().Length==0)
			{
				strErr+="people不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			string Address=this.txtAddress.Text;
			string Zip=this.txtZip.Text;
			string plane=this.txtplane.Text;
			string Fax=this.txtFax.Text;
			string QQ_MSN=this.txtQQ_MSN.Text;
			DateTime Date=DateTime.Parse(this.txtDate.Text);
			string people=this.txtpeople.Text;


			MaticSoft.Model.HKSJ_Relationship model=new MaticSoft.Model.HKSJ_Relationship();
			model.ID=ID;
			model.Address=Address;
			model.Zip=Zip;
			model.plane=plane;
			model.Fax=Fax;
			model.QQ_MSN=QQ_MSN;
			model.Date=Date;
			model.people=people;

			MaticSoft.BLL.HKSJ_Relationship bll=new MaticSoft.BLL.HKSJ_Relationship();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
