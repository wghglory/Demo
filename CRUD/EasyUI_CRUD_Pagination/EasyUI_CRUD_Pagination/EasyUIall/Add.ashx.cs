using EasyUI.BLL;
using EasyUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUI_CRUD_Pagination.EasyUIall
{
    /// <summary>
    /// Summary description for Add
    /// </summary>
    public class Add : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            string selldate = context.Request["SellDate"];
            string txtprice = context.Request["SellPrice"];
            string txtamount = context.Request["SellAmount"];

            MyOrder model = new MyOrder();

            if (selldate == "")  //什么都没输入
            {
                model.SellDate = null;
            }
            else  //有输入并检查输入是否合法
            {
                DateTime dt = DateTime.MinValue;
                if (DateTime.TryParse(selldate, out dt) == false)
                {
                    context.Response.Write("fail");
                    context.Response.End(); //或者return
                    //return;
                }
                else
                {
                    model.SellDate = dt;
                }
            }

            if (txtprice == "")
            {
                model.SellPrice = null;
            }
            else
            {
                decimal price = decimal.MinValue;
                if (decimal.TryParse(txtprice, out price) == false)
                {
                    context.Response.Write("fail");
                    context.Response.End();
                    //return;
                }
                else
                {
                    model.SellPrice = price;
                }
            }

            if (txtamount == "")
            {
                model.SellAmount = null;
            }
            else  //有输入并检查输入是否合法
            {
                int amount = int.MinValue;
                if (int.TryParse(txtamount, out amount) == false)
                {
                    context.Response.Write("fail");
                    context.Response.End();
                    //return;
                }
                else
                {
                    model.SellAmount = amount;
                }
            }


            //允许不输入，空可以；但是decimal就只允许输入数字，不能输入ss非法       
            model.ProductName = (string)AssignModel(context.Request["ProductName"]);
            model.Purchaser = (string)AssignModel(context.Request["Purchaser"]);
            model.ProductCode = (string)AssignModel(context.Request["ProductCode"]);
            model.Salesperson = (string)AssignModel(context.Request["SalesPerson"]);

            MyOrderBLL bll = new MyOrderBLL();

            bll.Add(model);

            context.Response.Write("ok");
        }

        public object AssignModel(string requestContext)
        {
            if (requestContext == "")
            {
                return null;
            }
            else
            {
                return requestContext;
            }
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