<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewState演示1层的自动增长.aspx.cs"
    Inherits="WebApplication2.ViewState演示1层的自动增长" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!--div runat=server, viewstate-->
    <div style="border: 1px solid blue; width: 200px; height: 200px" id="dv1" runat="server">
        0
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    </form>
</body>
</html>
