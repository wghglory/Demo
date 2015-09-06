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
namespace MaticSoft.Web.HKSJ_First
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
					string Name= strid;
					ShowInfo(Name);
				}
			}
		}
		
	private void ShowInfo(string Name)
	{
		MaticSoft.BLL.HKSJ_First bll=new MaticSoft.BLL.HKSJ_First();
		MaticSoft.Model.HKSJ_First model=bll.GetModel(Name);
		this.lblName.Text=model.Name;
		this.lblMatter.Text=model.Matter;

	}


    }
}
