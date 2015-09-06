using System;
using System.Text;

namespace MVC5.Ext
{
    public class PageHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize">一页多少条</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="totalRecordCount">总条数</param>
        /// <returns></returns>
        public static string GetPageNavStr(int pageSize, int currentPageIndex, int totalRecordCount)
        {
            string redirectTo = "";
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalRecordCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                if (currentPageIndex != 1)
                {//处理首页连接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageSize={1}&pageIndex=1'>首页</a> ", redirectTo, pageSize);
                }
                if (currentPageIndex > 1)
                {//处理上一页的连接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageSize={2}&pageIndex={1}'>上一页</a> ", redirectTo, currentPageIndex - 1, pageSize);
                }
                else
                {
                    // output.Append("<span class='pageLink'>上一页</span>");
                }

                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentPageIndex + i - currint) >= 1 && (currentPageIndex + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理
                            //output.Append(string.Format("[{0}]", currentPageIndex));
                            output.AppendFormat("<a class='cpb' href='{0}?pageSize={2}$pageIndex={1}'>{3}</a> ", redirectTo, currentPageIndex, pageSize, currentPageIndex);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a class='pageLink' href='{0}?pageSize={2}&pageIndex={1}'>{3}</a> ", redirectTo, currentPageIndex + i - currint, pageSize, currentPageIndex + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPageIndex < totalPages)
                {//处理下一页的链接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageSize={2}&pageIndex={1}'>下一页</a> ", redirectTo, currentPageIndex + 1, pageSize);
                }
                else
                {
                    //output.Append("<span class='pageLink'>下一页</span>");
                }
                output.Append(" ");
                if (currentPageIndex != totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageSize={2}&pageIndex={1}'>末页</a> ", redirectTo, totalPages, pageSize);
                }
                output.Append(" ");
            }
            output.AppendFormat("第{0}页 / 共{1}页", currentPageIndex, totalPages);//这个统计加不加都行
            return output.ToString();
        }


        public static string GetPageNavStr(int pageSize, int currentPageIndex, int totalRecordCount, string requestUrl)
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

    }
}
