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
namespace MaticSoft.Web.HKSJ_USERS
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int ID=(Convert.ToInt32(strid));
					ShowInfo(ID);
				}
			}
		}
		
	private void ShowInfo(int ID)
	{
		MaticSoft.BLL.HKSJ_USERS bll=new MaticSoft.BLL.HKSJ_USERS();
		MaticSoft.Model.HKSJ_USERS model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblUserName.Text=model.UserName;
		this.lblLoginName.Text=model.LoginName;
		this.lblPassWord.Text=model.PassWord;
		this.lblPlane.Text=model.Plane;
		this.lblphone.Text=model.phone;
		this.lblMail.Text=model.Mail;
		this.lblcardNo.Text=model.cardNo;

	}


    }
}
