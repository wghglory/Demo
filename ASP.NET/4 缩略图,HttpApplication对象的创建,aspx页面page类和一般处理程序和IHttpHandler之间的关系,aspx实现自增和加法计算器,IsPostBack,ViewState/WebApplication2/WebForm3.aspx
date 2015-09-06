<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="WebForm3.aspx.cs"
    Inherits="WebApplication2.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%=System.Reflection.Assembly.GetExecutingAssembly().Location%>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    </div>
    </form>
</body>
</html>
