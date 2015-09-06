using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;
using System.Web.UI.HtmlControls;

namespace Ajax.CRUD.UI.ObjectDataSource
{
    public partial class CRUD_Repeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Repeater控件中的所有的服务器端控件的回发事件都会触发该方法来执行，
        //所以在该方法中需要根据CommandName来区分用户点击的是哪个按钮
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //表示用户点击了删除
            if (e.CommandName == "Delete")
            {
                int sid = Convert.ToInt32(e.CommandArgument);
                //根据参数调用业务逻辑层实现删除
                Aspx_StudentsBll bll = new Aspx_StudentsBll();
                bll.DeleteByStuId(sid);

                //删除成功后，重新绑定
                this.Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //当前项绑定完毕事件
            //获取当前绑定的行的数据
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)//表示是数据行
            {
                //则获取当前绑定的行的数据
                //e.Item.DataItem;表示数据源中的一行，如果数据源是List<T>集合，则e.Item.DataItem表示的是一个List中的对象（Model）
                //如果绑定的数据源是一个DataTable,则e.Item.DataItem表示DataTable中的一行，DataRow
                //object obj = e.Item.DataItem;
                Aspx_Students model = e.Item.DataItem as Aspx_Students;
                if (model.StuAge > 40)
                {
                    //让当前单元格前景色变成红色
                    Control control = e.Item.FindControl("tdAge");

                    HtmlTableCell htc = control as HtmlTableCell;
                    htc.Attributes["style"] = "color:red;";
                }
            }

            //判断该数据的年龄是否大于40



            //如果大于40则将年龄单元格设置为红色前景色
        }
    }
}