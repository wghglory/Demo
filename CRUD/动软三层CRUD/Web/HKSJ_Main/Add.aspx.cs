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
			string title=this.txttitle.Text;
			string content=this.txtcontent.Text;
			string type=this.txttype.Text;
			DateTime Date=DateTime.Parse(this.txtDate.Text);
			string people=this.txtpeople.Text;
			string picUrl=this.txtpicUrl.Text;

			MaticSoft.Model.HKSJ_Main model=new MaticSoft.Model.HKSJ_Main();
			model.title=title;
			model.content=content;
			model.type=type;
			model.Date=Date;
			model.people=people;
			model.picUrl=picUrl;

			MaticSoft.BLL.HKSJ_Main bll=new MaticSoft.BLL.HKSJ_Main();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
