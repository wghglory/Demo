<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CRUD.UI.AspxNoServerControl.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="Register.aspx" method="post">
    <table border="1" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                Login Id
            </td>
            <td>
                <input type="text" name="txtLoginId" value="<%=_loginId %>" />
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <input type="password" name="txtPassword1" value="" />
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <input type="password" name="txtPassword2" value="" /><font color="red"><%=_errorMessage %></font>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <input type="submit" value="注册" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
