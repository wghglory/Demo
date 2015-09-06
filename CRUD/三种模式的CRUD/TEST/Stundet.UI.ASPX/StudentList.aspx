<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="Stundet.UI.ASPX.StudentList" %>

<%@ Import Namespace="Student.Model" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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

                <% foreach (StudentsModel studentsModel in list)
                   {%>

                <tr>
                    <td><%=studentsModel.SId %> </td>
                    <td><%=studentsModel.SName %> </td>
                    <td><%=studentsModel.SAge %> </td>
                    <td><%=studentsModel.SEmail %> </td>
                    <td><%=studentsModel.SBirthday %> </td>
                    <td><%=studentsModel.SGender %> </td>
                    <td><a href="StudentEdit.aspx?sid=<%=studentsModel.SId %>">编辑</a></td>
                    <td><a href="StudentDelete.ashx?sid=<%=studentsModel.SId %>">删除</a></td>
                </tr>
                <%    } %>
            
            </table>
            <p><%=pageStr %> </p>
            <a href="StudentAdd.aspx">添加一条数据</a>
        </div>
    </form>
</body>
</html>
