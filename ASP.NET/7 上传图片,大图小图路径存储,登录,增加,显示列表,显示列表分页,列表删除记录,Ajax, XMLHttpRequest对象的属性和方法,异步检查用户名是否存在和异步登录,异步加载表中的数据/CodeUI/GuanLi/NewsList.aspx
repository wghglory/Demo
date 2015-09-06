<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="GuanLi_NewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <!-- #include file=top.htm-->
    <form id="form1" runat="server">
    <table border="1" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                编号
            </td>
            <td>
                标题
            </td>
            <td>
                时间
            </td>
            <td>
                作者
            </td>
            <td>
                图片
            </td>
            <td>
                所属类别
            </td>
            <td>
                详细
            </td>
            <td>
                删除
            </td>
        </tr>
        <%for (int i = 0; i < _listNews.Count; i++)
          {%>
        <tr>
            <td>
                <%=_listNews[i].NewsId %>
            </td>
            <td>
                <%=_listNews[i].NewsTitle %>
            </td>
            <td>
                <%=_listNews[i].NewsIssueDate %>
            </td>
            <td>
                <%=_listNews[i].NewsAuthor %>
            </td>
            <td>
                <img style="width: 100px; height: 100px;" src="<%=_listNews[i].NewsSmallImage %>"
                    alt="Alternate Text" />
            </td>
            <td>
                <%=_listNews[i].Aspx_TypeObject.TypeName %>
            </td>
            <td>
                <a href="Details.aspx?Id=<%=_listNews[i].NewsId %>">详细</a>
            </td>
            <td>
                <a href="Delete.ashx?Id=<%=_listNews[i].NewsId %>">删除</a>
            </td>
        </tr>
        <%} %>
    </table>
    <p>
        <%for (int i = 0; i < this._pcount; i++)
          {%>
        <a style="margin-right: 8px;" href="NewsList.aspx?pagesize=<%=_psize %>&pageindex=<%=i+1 %>">
            <%=i+1 %></a>
        <% } %>
    </p>
    <span>共：<%=_rcount %>条记录，每页显示：<%=_psize %>条记录，共分：<%=_pcount %>页，当前是第：<%=_pindex %>页。</span>
    <br />
    =============================================
    <p>
        以下是页面导航：
    </p>
    <p>
        <%=this._navigator %>
    </p>
    </form>
</body>
</html>
