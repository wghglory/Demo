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
namespace MaticSoft.Web.HKSJ_Clients
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
			if(this.txtsoftName.Text.Trim().Length==0)
			{
				strErr+="softName不能为空！\\n";	
			}
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="content不能为空！\\n";	
			}
			if(this.txtliaisonPhone.Text.Trim().Length==0)
			{
				strErr+="liaisonPhone不能为空！\\n";	
			}
			if(this.txtliaisonPeple.Text.Trim().Length==0)
			{
				strErr+="liaisonPeple不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtdate.Text))
			{
				strErr+="date格式错误！\\n";	
			}
			if(this.txtpeple.Text.Trim().Length==0)
			{
				strErr+="peple不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string title=this.txttitle.Text;
			string softName=this.txtsoftName.Text;
			string content=this.txtcontent.Text;
			string liaisonPhone=this.txtliaisonPhone.Text;
			string liaisonPeple=this.txtliaisonPeple.Text;
			DateTime date=DateTime.Parse(this.txtdate.Text);
			string peple=this.txtpeple.Text;

			MaticSoft.Model.HKSJ_Clients model=new MaticSoft.Model.HKSJ_Clients();
			model.title=title;
			model.softName=softName;
			model.content=content;
			model.liaisonPhone=liaisonPhone;
			model.liaisonPeple=liaisonPeple;
			model.date=date;
			model.peple=peple;

			MaticSoft.BLL.HKSJ_Clients bll=new MaticSoft.BLL.HKSJ_Clients();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
