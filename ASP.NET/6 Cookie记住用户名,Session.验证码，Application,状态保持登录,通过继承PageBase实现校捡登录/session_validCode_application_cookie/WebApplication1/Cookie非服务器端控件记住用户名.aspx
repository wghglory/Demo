<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cookie非服务器端控件记住用户名.aspx.cs" Inherits="WebApplication1.Cookie非服务器端控件记住用户名" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="Cookie非服务器端控件记住用户名.aspx" method="post">
        user name : <input type="text" name="txtUserName" value="<%= _userName %>" /><br />
        password: <input type="password" name="txtPwd" value=" " /><br />
        remember me: <input type="checkbox" name="chkRem" value="1" /><br />
        <input type="submit" value="submit" />
    </form>
</body>
</html>
