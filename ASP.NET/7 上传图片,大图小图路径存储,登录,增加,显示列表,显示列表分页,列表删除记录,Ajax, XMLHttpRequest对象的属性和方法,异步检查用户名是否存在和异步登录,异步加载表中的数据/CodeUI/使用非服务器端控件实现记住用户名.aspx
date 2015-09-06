<%@ Page Language="C#" AutoEventWireup="true" CodeFile="使用非服务器端控件实现记住用户名.aspx.cs"
    Inherits="使用非服务器端控件实现记住用户名" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" action="使用非服务器端控件实现记住用户名.aspx" method="post">
    <input type="text" name="txtUserName" value="<%=_userName %>" /><br />
    <input type="password" name="txtPassword" value="" /><br />
    <input type="checkbox" name="chkRemember" value="1" />记住用户名<br />
    <input type="submit" value="登录" />
    </form>
</body>
</html>
