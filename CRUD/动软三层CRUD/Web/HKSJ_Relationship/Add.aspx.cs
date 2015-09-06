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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string Address=this.txtAddress.Text;
			string Zip=this.txtZip.Text;
			string plane=this.txtplane.Text;
			string Fax=this.txtFax.Text;
			string QQ_MSN=this.txtQQ_MSN.Text;
			DateTime Date=DateTime.Parse(this.txtDate.Text);
			string people=this.txtpeople.Text;

			MaticSoft.Model.HKSJ_Relationship model=new MaticSoft.Model.HKSJ_Relationship();
			model.Address=Address;
			model.Zip=Zip;
			model.plane=plane;
			model.Fax=Fax;
			model.QQ_MSN=QQ_MSN;
			model.Date=Date;
			model.people=people;

			MaticSoft.BLL.HKSJ_Relationship bll=new MaticSoft.BLL.HKSJ_Relationship();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
