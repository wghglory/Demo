using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.Model;

namespace Ajax.CRUD.UI
{
    public class SendClientData
    {
        /// <summary>
        /// 存放生成的json字符串的属性
        /// </summary>
        public List<Aspx_Students> StudentList
        {
            get;
            set;
        }

        /// <summary>
        /// 存放生成的导航栏的html标签
        /// </summary>
        public string NavigatorString
        {
            get;
            set;
        }
    }
}