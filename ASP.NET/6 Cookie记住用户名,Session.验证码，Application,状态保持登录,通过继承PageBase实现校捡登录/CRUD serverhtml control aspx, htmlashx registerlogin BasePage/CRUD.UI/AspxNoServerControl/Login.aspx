<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRUD.UI.AspxNoServerControl.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>登录</title>
</head>
<body>
    <%--当这里的表单用普通的表单而不是runat=server以后，IsPostBack就不能用了。--%>
    <form id="form1" action="Login.aspx" method="post">
    <table border="1" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                Login id
            </td>
            <td>
                <input type="text" name="txtLoginId" value="" />
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <input type="password" name="txtPassword" value="" /><font color="red"><%=_errorMessage%></font>
            </td>
        </tr>
        <tr>
            <td>
                <input type="submit" value="登录" />
            </td>
            <td>
                <a href="Register.aspx">注册</a>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
