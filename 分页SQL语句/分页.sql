--假设每页5条，查看第3页
alter proc usp_getNewsByPage
@pagesize int, --每页的记录条数
@pageIndex int,--当前要查看第几页
@recordCount int output,--表中总共的记录条数
@pagecount int output --一共可以分多少页
as
--1.要查询的数据通过链接找到，然后把找到的数据放入到临时表中
select * into #NewsTemp from 
(select
	NewsId, 
	NewsTitle, 
	NewsIssueDate, 
	NewsAuthor, 
	NewsSmallImage,
	TypeName
from aspx_news n inner join aspx_type t
on n.newstypeid=t.typeId) as Tbl
--2.再对这个结果进行其他复杂查询
----根据需求查询当前要显示的页的记录的条数
select * from 
(select *,rn=row_number() over(order by NewsIssueDate desc) from #NewsTemp) as t
where t.rn between ((@pageIndex-1)*@pagesize)+1 and (@pageIndex*@pagesize)
--把表中总记录条数查询出来
select @recordCount=count(*) from #NewsTemp
--根据总记录条数,计算一共有多少页
set @pageCount=ceiling(@recordCount*1.0/@pagesize)


--test sp:
declare @rc INT, @pc int
exec usp_getNewsByPage @pagesize=5,@pageIndex=1,@recordCount=@rc OUTPUT,@pagecount=@pc OUTPUT
select @rc AS [total COUNT],@pc AS [Page Count]


DAL:
public List<Aspx_News> GetNewsByPage(int pageSize, int pageIndex, out int recordCount, out int pageCount)
        {
            List<Aspx_News> list = new List<Aspx_News>();
            string sql = "usp_getNewsByPage";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@pageSize",pageSize),
            new SqlParameter("@pageIndex",pageIndex),
            new SqlParameter("@recordCount",System.Data.SqlDbType.Int),
            new SqlParameter("@pagecount",System.Data.SqlDbType.Int)
            };
            pms[2].Direction = System.Data.ParameterDirection.Output;
            pms[3].Direction = System.Data.ParameterDirection.Output;

            #region MyRegion
            //执行读取操作
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.StoredProcedure, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // NewsId, 
                        //NewsTitle, 
                        //NewsIssueDate, 
                        //NewsAuthor, 
                        //NewsSmallImage,
                        //TypeName
                        Aspx_News model = new Aspx_News();
                        model.NewsId = reader.GetInt32(0);
                        model.NewsTitle = reader.GetString(1);
                        model.NewsIssueDate = reader.IsDBNull(2) ? null : (DateTime?)reader.GetDateTime(2);
                        model.NewsAuthor = reader.IsDBNull(3) ? null : reader.GetString(3);
                        model.NewsSmallImage = reader.IsDBNull(4) ? null : reader.GetString(4);
                        Aspx_Type typeModel = new Aspx_Type();
                        typeModel.TypeName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        model.Aspx_TypeObject = typeModel;
                        list.Add(model);

                    }
                }
            }
            #endregion

            recordCount = Convert.ToInt32(pms[2].Value);
            pageCount = Convert.ToInt32(pms[3].Value);

            return list;

        }


PageClass.cs:

using System;

/// <summary>
/// PageClass 的摘要说明
/// </summary>
public class PageClass
{
    #region 数字分页类
    public static string strPage(int intCounts, int intPageSizes, int intPageCounts, int intThisPages, string strUrl)
    {
        int intCount = Convert.ToInt32(intCounts); //总记录数
        int intPageCount = Convert.ToInt32(intPageCounts); //总共页数
        int intPageSize = Convert.ToInt32(intPageSizes); //每页显示
        int intPage = 7;  //数字显示
        int intThisPage = Convert.ToInt32(intThisPages); //当前页数
        int intBeginPage = 0; //开始页数
        int intCrossPage = 0; //变换页数
        int intEndPage = 0; //结束页数
        string strPage = null; //返回值

        intCrossPage = intPage / 2;
        strPage = "共 <font color=\"#FF0000\">" + intCount.ToString() + "</font> 条记录 第 <font color=\"#FF0000\">" + intThisPage.ToString() + "/" + intPageCount.ToString() + "</font> 页 每页 <font color=\"#FF0000\">" + intPageSize.ToString() + "</font> 条 &nbsp;&nbsp;&nbsp;&nbsp;";
        if (intThisPage > 1)
        {
            strPage = strPage + "<a href=\"" + strUrl + "1\">首页</a> ";
            strPage = strPage + "<a href=\"" + strUrl + Convert.ToString(intThisPage - 1) + "\">上一页</a> ";
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
                if (i == intThisPage)
                {
                    strPage = strPage + " <font color=\"#FF0000\">" + i.ToString() + "</font> ";
                }
                else
                {
                    strPage = strPage + " <a href=\"" + strUrl + i.ToString() + "\" title=\"第" + i.ToString() + "页\">" + i.ToString() + "</a> ";
                }
            }
        }
        if (intThisPage < intPageCount)
        {
            strPage = strPage + "<a href=\"" + strUrl + Convert.ToString(intThisPage + 1) + "\">下一页</a> ";
            strPage = strPage + "<a href=\"" + strUrl + intPageCount.ToString() + "\">尾页</a> ";
        }
        return strPage;
    }
    #endregion
}


aspx:
<%=this._navigator %>


codebehind:
Aspx_NewsBll bll = new Aspx_NewsBll();
        int rc, pc;
        int psize = 5, pindex = 1;
        if (Request["pageindex"] != null)
        {
            pindex = int.Parse(Request["pageindex"]);
        }

        _listNews = bll.GetNewsByPage(psize, pindex, out rc, out pc);
        this._pcount = pc;
        this._pindex = pindex;
        this._psize = psize;
        this._rcount = rc;


        this._navigator = PageClass.strPage(rc, psize, pc, pindex, "NewsList.aspx?pageindex=");


