<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cookie服务器端记住用户名.aspx.cs" Inherits="WebApplication1.Cookie记住用户名" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    loginId:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    Password:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <br />
    Remember<asp:CheckBox ID="CheckBox1" runat="server" />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
