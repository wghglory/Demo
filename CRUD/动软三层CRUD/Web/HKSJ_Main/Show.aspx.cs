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
namespace MaticSoft.Web.HKSJ_Main
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
		MaticSoft.BLL.HKSJ_Main bll=new MaticSoft.BLL.HKSJ_Main();
		MaticSoft.Model.HKSJ_Main model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lbltitle.Text=model.title;
		this.lblcontent.Text=model.content;
		this.lbltype.Text=model.type;
		this.lblDate.Text=model.Date.ToString();
		this.lblpeople.Text=model.people;
		this.lblpicUrl.Text=model.picUrl;

	}


    }
}
