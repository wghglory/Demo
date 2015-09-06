<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="Student.UI.Server.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table border="2">
                        <tr>
                            <th>编号</th>
                            <th>姓名</th>
                            <th>年龄</th>
                            <th>邮箱</th>
                            <th>生日</th>
                            <th>性别</th>
                            <th>编辑</th>
                            <th>删除</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("SId") %></td>
                        <td><%# Eval("SName") %></td>
                        <td><%# Eval("SAge") %></td>
                        <td><%# Eval("SEmail") %></td>
                        <td><%# Eval("SBirthday") %></td>
                        <td><%# Eval("SGender") %></td>
                        <td><a href="StudentEdit.aspx?sid=<%# Eval("SId") %>">编辑</a></td>
                        <td><a href="StudentDelete.ashx?sid=<%# Eval("SId") %>">删除</a>  </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <br />
            <a href="#">添加一条新记录</a>
            <br />
            <br />
            <br />

            <p><%=pageStr %></p>
        </div>
    </form>
</body>
</html>
