using Nvelocity.BLL;
using Nvelocity.Common;
using Nvelocity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nvelocity.UI
{
    /// <summary>
    /// Summary description for SupplierEdit
    /// </summary>
    public class SupplierEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //PersonEdit.ashx?action=AddNew
            //PersonEdit.ashx?action=Edit&Id=3
            string action = context.Request["aCtIon"];  //Action ignore case
            if (action == "AddNew")
            {
                //判断是否含有Save并且等于true，如果是的话就说明是点击【保存】按钮请求来的
                bool save = Convert.ToBoolean(context.Request["Save"]);
                if (save) //新增保存
                {
                    string companyName = context.Request["CompanyName"];
                    string contactName = context.Request["ContactName"];
                    string address = context.Request["Address"];
                    string city = context.Request["City"];
                    string postalcode = context.Request["PostalCode"];
                    string phone = context.Request["Phone"];
                    string country = context.Request["Country"];

                    Supplier supplier = new Supplier();
                    supplier.CompanyName = companyName;
                    supplier.ContactName = contactName;
                    supplier.Address = address;
                    supplier.City = city;
                    supplier.PostalCode = postalcode;
                    supplier.Phone = phone;
                    supplier.Country = country;

                    SupplierBLL bll = new SupplierBLL();
                    bll.Add(supplier);

                    context.Response.Redirect("SupplierList.ashx");//保存成功返回列表页面
                }
                else //展示新增
                {
                    //string html = CommonHelper.RenderHtml("PersonEdit.htm", new { Name = "", Age = 20, Email = "@rupeng.com" });
                    //var data = new {Action="Edit", Name = "", Age = 20, Email = "@rupeng.com" };如果数据库有一列叫Action就完蛋了
                    var data = new { Action = "AddNew", Supplier = new { CompanyName = "", ContactName = "", Address="", Phone="", PostalCode="", City="", Country="" } };
                    string html = CommonHelper.RenderHtml("SupplierEdit.html", data);
                    context.Response.Write(html);
                }
            }
            else if (action == "Edit")
            {
                int id = Convert.ToInt32(context.Request["Id"]);
                //todo:检查id合法性
                SupplierBLL bll = new SupplierBLL();
                bool save = Convert.ToBoolean(context.Request["Save"]);
                if (save)  //编辑保存
                {
                    string companyName = context.Request["CompanyName"];
                    string contactName = context.Request["ContactName"];
                    string address = context.Request["Address"];
                    string city = context.Request["City"];
                    string postalcode = context.Request["PostalCode"];
                    string phone = context.Request["Phone"];
                    string country = context.Request["Country"];

                    Supplier supplier = new Supplier();
                    supplier.SupplierID = id;
                    supplier.CompanyName = companyName;
                    supplier.ContactName = contactName;
                    supplier.Address = address;
                    supplier.City = city;
                    supplier.PostalCode = postalcode;
                    supplier.Phone = phone;
                    supplier.Country = country;

                    bll.Update(supplier);

                    context.Response.Redirect("SupplierList.ashx");//保存成功返回列表页面
                }
                else   //展示编辑
                {
                    Supplier supplier = bll.GetBySupplierID(id);
                    if (supplier == null)
                    {
                        context.Response.Write("cannot find person whose id=" + id);
                    }
                    else
                    {
                        var data = new { Action = "Edit", Supplier = supplier };
                        string html = CommonHelper.RenderHtml("SupplierEdit.html", data);
                        context.Response.Write(html);
                    }
                }
            }
            else if (action == "Delete")
            {
                int id = Convert.ToInt32(context.Request["Id"]);
                new SupplierBLL().DeleteBySupplierID(id); 
                context.Response.Redirect("SupplierList.ashx");//保存成功返回列表页面
            }
            else
            {
                context.Response.Write("Action参数错误！");
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