using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using sc0802.Bll;

public partial class GuanLi_NewsList : System.Web.UI.Page  //BasePage
{

    protected int _psize;
    protected int _pcount;
    protected int _rcount;
    protected int _pindex;

    protected string _navigator;
    //protected override void Page_Load(object sender, EventArgs e)
    //{
    //    base.Page_Load(sender, e);

    //    //加载数据
    //    LoadNewsData();
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        //base.Page_Load(sender, e);

        //加载数据
        LoadNewsData();
    }

    protected List<Aspx_News> _listNews;

    private void LoadNewsData()
    {
        #region 旧版本
        //Aspx_NewsBll bll = new Aspx_NewsBll();
        //int rc, pc;
        //int psize = 5, pindex = 1;
        ////pagesize=5&pageindex=8
        //if (Request["pagesize"] != null && Request["pageindex"] != null)
        //{
        //    //每页条数
        //    psize = int.Parse(Request["pagesize"]);
        //    pindex = int.Parse(Request["pageindex"]);
        //}

        //_listNews = bll.GetNewsByPage(psize, pindex, out rc, out pc);
        //this._pcount = pc;
        //this._pindex = pindex;
        //this._psize = psize;
        //this._rcount = rc;
        #endregion

        #region 新版本

        Aspx_NewsBll bll = new Aspx_NewsBll();
        int rc, pc;
        int psize = 5, pindex = 1;
        if (Request["pageindex"] != null)
        {
            pindex = int.Parse(Request["pageindex"]);
        }

        _listNews = bll.GetNewsByPage(psize, pindex, out rc, out pc);
        this._pcount = pc;
        this._pindex = pindex;
        this._psize = psize;
        this._rcount = rc;


        this._navigator = PageClass.strPage(rc, psize, pc, pindex, "NewsList.aspx?pageindex=");
        #endregion

    }
}