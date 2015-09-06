<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="CRUD.UI.AspxNoServerControl.UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <form id="form1" action="Register.aspx" method="get">
    <table border="1" cellpadding="2" cellspacing="2">
        <thead>
            <tr>
                <th>
                    AutoId
                </th>
                <th>
                    LoginId
                </th>
                <th>
                    Password
                </th>
                <th>
                    ErrorCount
                </th>
                <th>
                    LastLoginTime
                </th>
                <th>
                    编辑
                </th>
                <th>
                    删除
                </th>
            </tr>
        </thead>
        <tbody>
            <%for (int i = 0; i < _listUsers.Count; i++)
              {%>
            <tr>
                <td>
                    <%=_listUsers[i].AutoId %>
                </td>
                <td>
                    <%=_listUsers[i].LoginId %>
                </td>
                <td>
                    <%=_listUsers[i].LoginPwd %>
                </td>
                <td>
                    <%=_listUsers[i].ErrorCount %>
                </td>
                <td>
                    <%=_listUsers[i].LastLoginTime %>
                </td>
                <td>
                    <a href="Edit.aspx?EditId=<%=_listUsers[i].AutoId%>">编辑</a>
                </td>
                <td>
                    <a onclick="return confirm('确定要删除吗？');" href="UserList.aspx?delId=<%=_listUsers[i].AutoId %>">
                        删除</a>
                </td>
            </tr>
            <% } %>
        </tbody>
    </table>
    </form>
</body>
</html>
