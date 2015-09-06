<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAdd.aspx.cs" Inherits="Stundet.UI.ASPX.StudentAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <input type="hidden" name="hi" value="a" />
            <table border="2">
                <tr>
                    <th>姓名</th>
                    <td>
                        <input type="text" name="txtName" value="" /></td>
                </tr>
                <tr>
                    <th>年龄</th>
                    <td>
                        <input type="text" name="txtAge" value="" /></td>
                </tr>
                <tr>
                    <th>邮箱</th>
                    <td>
                        <input type="text" name="txtEmail" value="" /></td>
                </tr>
                <tr>
                    <th>生日</th>
                    <td>
                        <input type="text" name="txtBirthday" value="" /></td>
                </tr>
                <tr>
                    <th>性别</th>
                    <td>
                        <input type="text" name="txtGender" value="" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="submit" value="添加" /><span style="color: red"><%=msg %></span></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
