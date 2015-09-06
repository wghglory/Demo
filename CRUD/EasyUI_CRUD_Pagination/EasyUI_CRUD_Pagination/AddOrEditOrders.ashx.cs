using EasyUI.BLL;
using EasyUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUI_CRUD_Pagination
{

    public class AddOrEditOrders : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string id = context.Request["hidId"];  //update has id, add id = ""

            string selldate = context.Request["txtSellDate"];
            string txtprice = context.Request["txtPrice"];
            string txtamount = context.Request["txtAmount"];

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
            model.ProductName = (string)AssignModel(context.Request["txtProductName"]);
            model.Purchaser = (string)AssignModel(context.Request["txtPurchaser"]);
            model.ProductCode = (string)AssignModel(context.Request["txtProductCode"]);
            model.Salesperson = (string)AssignModel(context.Request["txtSalesPerson"]);

            MyOrderBLL bll = new MyOrderBLL();

            if (id == "")   //新增
            {
                bll.Add(model);
            }
            else  //更新
            {
                model.Id = int.Parse(id);
                bll.Update(model);
            }

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