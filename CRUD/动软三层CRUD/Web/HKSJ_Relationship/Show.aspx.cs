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
namespace MaticSoft.Web.HKSJ_Relationship
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
		MaticSoft.BLL.HKSJ_Relationship bll=new MaticSoft.BLL.HKSJ_Relationship();
		MaticSoft.Model.HKSJ_Relationship model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblAddress.Text=model.Address;
		this.lblZip.Text=model.Zip;
		this.lblplane.Text=model.plane;
		this.lblFax.Text=model.Fax;
		this.lblQQ_MSN.Text=model.QQ_MSN;
		this.lblDate.Text=model.Date.ToString();
		this.lblpeople.Text=model.people;

	}


    }
}
