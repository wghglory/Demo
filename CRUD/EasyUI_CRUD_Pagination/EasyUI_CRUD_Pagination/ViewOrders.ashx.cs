using EasyUI.BLL;
using EasyUI.Common;
using EasyUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace EasyUI_CRUD_Pagination
{
    /// <summary>
    /// Summary description for ViewOrders
    /// </summary>
    public class ViewOrders : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            MyOrderBLL bll = new MyOrderBLL();
            //IEnumerable<MyOrder> list = bll.GetAll();

            //这里我过滤出想要显示在前台的数据
            //var list = bll.GetAll().Select(x => new { ID = x.Id, Productname = x.ProductName, Purchaser = x.Purchaser, Amount = x.SellAmount, SellDate = x.SellDate, Price = x.SellPrice });

            int pageindex = 1;
            if (int.TryParse(context.Request["pageIndex"], out pageindex) == false)
            {
                pageindex = 1;
            }

            int pagesize = 10;
            int pagecount = bll.GetTotalCount();
            //string navStr = PageHelper.GetPageNavStr(pagesize, pageindex, pagecount, "ViewOrders.ashx?pageindex=");
            string navStr = PageHelper.GetPageNavStr(pagesize, pageindex, pagecount);

            var pagedlist = bll.GetPagedData(pagesize, pageindex).Select(x => new { ID = x.Id, Productname = x.ProductName, Buyer = x.Purchaser, Amount = x.SellAmount, SellDate = x.SellDate, Price = x.SellPrice });

            JavaScriptSerializer jss = new JavaScriptSerializer();

            //这个选择性的来
            string jsonStr = jss.Serialize(new { NavStr = navStr, PagedList = pagedlist, PageSize = pagesize, RecordCount = pagecount });
            context.Response.Write(jsonStr);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}