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
namespace MaticSoft.Web.HKSJ_Clients
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
					int id=(Convert.ToInt32(strid));
					ShowInfo(id);
				}
			}
		}
		
	private void ShowInfo(int id)
	{
		MaticSoft.BLL.HKSJ_Clients bll=new MaticSoft.BLL.HKSJ_Clients();
		MaticSoft.Model.HKSJ_Clients model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lbltitle.Text=model.title;
		this.lblsoftName.Text=model.softName;
		this.lblcontent.Text=model.content;
		this.lblliaisonPhone.Text=model.liaisonPhone;
		this.lblliaisonPeple.Text=model.liaisonPeple;
		this.lbldate.Text=model.date.ToString();
		this.lblpeple.Text=model.peple;

	}


    }
}
