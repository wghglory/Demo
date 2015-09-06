using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;
using System.Web.Script.Serialization;

namespace Ajax.CRUD.UI.ajax
{
    /// <summary>
    /// GetAreaByParentId 的摘要说明
    /// </summary>
    public class GetAreaByParentId : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1.获取用户传递过来的父Id
            string pid = context.Request["pid"];
            if (pid != null)
            {
                //2.根据父Id查询当前父Id下的所有地区（如果父Id为0，则表示加载所有的“省份”）
                TblAreaBll bll = new TblAreaBll();
                List<TblArea> _list = bll.GetAreasByParentId(int.Parse(pid));
                JavaScriptSerializer jss = new JavaScriptSerializer();
                //string jsonString = jss.Serialize(_list);

                //这个对象_areaData有两个属性。
                //SelectedId表示将来告诉客户端Id为指定的元素，要被默认选中
                //AreaJsonData是具体的地区数据的集合
                //这里的_list[7]是表示假设了一个省份默认被选中。假设查询出来的第8个省份（索引为7的省份被选中），将来这个值肯定是从其他地方读取的所以这个值暂时不需要关心。 
                var _areaData = new { SelectedId = _list[7].AreaId, AreaJsonData = _list };
                string jsonString = jss.Serialize(_areaData);

                context.Response.Write(jsonString);
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