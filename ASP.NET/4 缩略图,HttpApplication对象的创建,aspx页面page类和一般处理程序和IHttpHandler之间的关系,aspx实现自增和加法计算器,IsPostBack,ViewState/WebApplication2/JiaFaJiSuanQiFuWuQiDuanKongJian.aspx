﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiaFaJiSuanQiFuWuQiDuanKongJian.aspx.cs"
    Inherits="WebApplication2.JiaFaJiSuanQiFuWuQiDuanKongJian" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox EnableViewState="false" ID="TextBox1" runat="server"></asp:TextBox>
        +<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="=" />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
