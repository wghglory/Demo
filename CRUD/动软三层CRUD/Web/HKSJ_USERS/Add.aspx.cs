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
namespace MaticSoft.Web.HKSJ_USERS
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="UserName不能为空！\\n";	
			}
			if(this.txtLoginName.Text.Trim().Length==0)
			{
				strErr+="LoginName不能为空！\\n";	
			}
			if(this.txtPassWord.Text.Trim().Length==0)
			{
				strErr+="PassWord不能为空！\\n";	
			}
			if(this.txtPlane.Text.Trim().Length==0)
			{
				strErr+="Plane不能为空！\\n";	
			}
			if(this.txtphone.Text.Trim().Length==0)
			{
				strErr+="phone不能为空！\\n";	
			}
			if(this.txtMail.Text.Trim().Length==0)
			{
				strErr+="Mail不能为空！\\n";	
			}
			if(this.txtcardNo.Text.Trim().Length==0)
			{
				strErr+="cardNo不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string UserName=this.txtUserName.Text;
			string LoginName=this.txtLoginName.Text;
			string PassWord=this.txtPassWord.Text;
			string Plane=this.txtPlane.Text;
			string phone=this.txtphone.Text;
			string Mail=this.txtMail.Text;
			string cardNo=this.txtcardNo.Text;

			MaticSoft.Model.HKSJ_USERS model=new MaticSoft.Model.HKSJ_USERS();
			model.UserName=UserName;
			model.LoginName=LoginName;
			model.PassWord=PassWord;
			model.Plane=Plane;
			model.phone=phone;
			model.Mail=Mail;
			model.cardNo=cardNo;

			MaticSoft.BLL.HKSJ_USERS bll=new MaticSoft.BLL.HKSJ_USERS();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
