using EasyUI.BLL;
using EasyUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyUI_CRUD_Pagination
{
    public partial class EditOrder : System.Web.UI.Page
    {
        protected MyOrder model = new MyOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  //加载数据
            {
                string id = Request["id"];
                if (id != "")
                {
                    model = new MyOrderBLL().GetById(int.Parse(id));
                }
            }

            else //更新
            {             
                string hid = Request["hidId"];

                string selldate = Request["txtSellDate"];
                string txtprice = Request["txtPrice"];
                string txtamount = Request["txtAmount"];

                if (selldate == "")  //什么都没输入
                {
                    model.SellDate = null;
                }
                else  //有输入并检查输入是否合法
                {
                    DateTime dt = DateTime.MinValue;
                    if (DateTime.TryParse(selldate, out dt) == false)
                    {
                        Response.Write("fail");
                        Response.End(); //或者return
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
                        Response.Write("fail");
                        Response.End();
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
                        Response.Write("fail");
                        Response.End();
                        //return;
                    }
                    else
                    {
                        model.SellAmount = amount;
                    }
                }


                //允许不输入，空可以；但是decimal就只允许输入数字，不能输入ss非法       
                model.ProductName = (string)AssignModel(Request["txtProductName"]);
                model.Purchaser = (string)AssignModel(Request["txtPurchaser"]);
                model.ProductCode = (string)AssignModel(Request["txtProductCode"]);
                model.Salesperson = (string)AssignModel(Request["txtSalesPerson"]);

                MyOrderBLL bll = new MyOrderBLL();
                model.Id = int.Parse(hid);
                bll.Update(model);

                Response.Clear();
                Response.Write("ok");
                Response.End();
            }
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

    }
}