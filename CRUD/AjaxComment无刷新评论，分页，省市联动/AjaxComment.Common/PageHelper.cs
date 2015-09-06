using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjaxComment.Common
{
    public class PageHelper
    {
        #region 数字分页类
        public static string ShowPageNavigator(int totalRecordCount, int pageSize, int currentPageIndex, string requestUrl)
        {
            int intCount = Convert.ToInt32(totalRecordCount); //总记录数
            int intPageCount = Convert.ToInt32(Math.Ceiling(totalRecordCount * 1.0 / pageSize)); //总共页数
            int intPageSize = Convert.ToInt32(pageSize); //每页显示
            int intPage = 7;  //数字显示
            int intThisPage = Convert.ToInt32(currentPageIndex); //当前页数
            int intBeginPage = 0; //开始页数
            int intCrossPage = 0; //变换页数
            int intEndPage = 0; //结束页数
            //string strPage = null; //返回值
            StringBuilder strPage = new StringBuilder();//返回值


            intCrossPage = intPage / 2;
            strPage.AppendFormat("共 <font color='#FF0000'>{0}</font> 条记录 第 <font color='#FF0000'>{1}/{2}</font> 页 每页 <font color='#FF0000'>{3}</font> 条 &nbsp;&nbsp;&nbsp;&nbsp;", intCount.ToString(), intThisPage.ToString(), intPageCount.ToString(), intPageSize.ToString());
            if (intThisPage > 1)
            {
                strPage.AppendFormat("<a href='{0}1'>首页</a>", requestUrl);
                strPage.AppendFormat("<a href='{0}'>上一页</a>", requestUrl + Convert.ToString(intThisPage - 1));
            }
            if (intPageCount > intPage)
            {
                if (intThisPage > intPageCount - intCrossPage)
                {
                    intBeginPage = intPageCount - intPage + 1;
                    intEndPage = intPageCount;
                }
                else
                {
                    if (intThisPage <= intPage - intCrossPage)
                    {
                        intBeginPage = 1;
                        intEndPage = intPage;
                    }
                    else
                    {
                        intBeginPage = intThisPage - intCrossPage;
                        intEndPage = intThisPage + intCrossPage;
                    }
                }
            }
            else
            {
                intBeginPage = 1;
                intEndPage = intPageCount;
            }
            if (intCount > 0)
            {

                for (int i = intBeginPage; i <= intEndPage; i++)
                {
                    if (i == intThisPage)   //current page
                    {
                        //strPage = strPage + " <font color=\"#FF0000\">" + i.ToString() + "</font> ";
                        strPage.AppendFormat("<a class='cpb' href='{0}' title='第{1}页'>{2}</a> ", requestUrl + i.ToString(), i.ToString(), i.ToString());
                    }
                    else
                    {
                        strPage.AppendFormat("<a href='{0}' title='第{1}页'>{2}</a>", requestUrl + i.ToString(), i.ToString(), i.ToString());
                    }
                }
            }
            if (intThisPage < intPageCount)
            {
                strPage.AppendFormat("<a href='{0}'>下一页</a> ", requestUrl + Convert.ToString(intThisPage + 1));
                strPage.AppendFormat("<a href='{0}'>尾页</a> ", requestUrl + intPageCount.ToString());
            }
            return strPage.ToString();
        }
        #endregion
    }
}
