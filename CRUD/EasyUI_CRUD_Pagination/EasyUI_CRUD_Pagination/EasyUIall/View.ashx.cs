using EasyUI.BLL;
using EasyUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace EasyUI_CRUD_Pagination.EasyUIall
{
    /// <summary>
    /// Summary description for View
    /// </summary>
    public class View : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //自动往后台发送：rows:10  page:请求的当前页，
            //要求返还的数据：  {total:200,rows:[{},{}]}

            int pageSize = int.Parse(context.Request["rows"] ?? "10");
            int pageIndex = int.Parse(context.Request["page"] ?? "1");


            MyOrderBLL bll = new MyOrderBLL();
            int total = bll.GetTotalCount();
            var orderlist =
                 bll.GetPagedData(pageSize, pageIndex)
                     .Select(
                         o =>
                             new
                             {
                                 Id = o.Id,
                                 SellDate = String.Format("{0:u}", o.SellDate),//http://www.csharp-examples.net/string-format-datetime/
                                 ProductName = o.ProductName,
                                 ProductCode = o.ProductCode,
                                 SellAmount = o.SellAmount,
                                 Purchaser = o.Purchaser,
                                 Salesperson = o.Salesperson,
                                 SellPrice = o.SellPrice
                             }).ToList();


            var data = new { total = total, rows = orderlist };
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonStr = jss.Serialize(data);

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