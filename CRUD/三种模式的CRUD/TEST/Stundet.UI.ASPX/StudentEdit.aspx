<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="Stundet.UI.ASPX.StudentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" method="POST" action="StudentEdit.aspx">
        <div>

            <input type="hidden" name="hi" value="a" />
            <table border="2">
                <tr>
                    <th>编号</th>
                    <td>
                        <input type="text" name="txtSid" value="<%=SId %>" readonly="readonly" /></td>
                </tr>
                <tr>
                    <th>姓名</th>
                    <td>
                        <input type="text" name="txtName" value="<%=SName %>" /></td>
                </tr>
                <tr>
                    <th>年龄</th>
                    <td>
                        <input type="text" name="txtAge" value="<%=SAge %>" /></td>
                </tr>
                <tr>
                    <th>邮箱</th>
                    <td>
                        <input type="text" name="txtEmail" value="<%=SEmail %>" /></td>
                </tr>
                <tr>
                    <th>生日</th>
                    <td>
                        <input type="text" name="txtBirthday" value="<%=SBirthday %>" /></td>
                </tr>
                <tr>
                    <th>性别</th>
                    <td>
                        <input type="text" name="txtGender" value="<%=SGender %>" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="submit" value=" 保存修改" /><span style="color: red"><%=msg %></span></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
