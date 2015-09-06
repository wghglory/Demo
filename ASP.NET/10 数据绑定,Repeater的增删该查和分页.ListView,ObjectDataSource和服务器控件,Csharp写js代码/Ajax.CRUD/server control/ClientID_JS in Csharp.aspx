<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientID_JS in Csharp.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        window.onload = function () {
            document.getElementById('<%=Button1.ClientID %>').onclick = function () {
                //alert('aaa');
            };
        };
    </script>
    <style type="text/css">
        .myclass
        {
            background-color: Red;
        }
    </style>
</head>
<body>
    bb
    <div style="display: none; width: 200px; height: 200px; border: 1px solid blue;">
        aaa
    </div>
    cc
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" CssClass="myclass" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="#6600FF" 
            Text="Labelfdsfdsfdsafdsfdsf"></asp:Label>
        <br />
        <br />
        ===============<asp:Label ID="Label2" runat="server" Text="AAAAA"></asp:Label>
        =================================<br />
        <br />
        ===================<asp:Literal ID="Literal1" runat="server" 
            Text="BBBBBBBBBBBBBB"></asp:Literal>
        ===============================<br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" ontextchanged="TextBox2_TextChanged" 
            AutoPostBack="True"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
       <%-- <asp:TextBox ID="TextBox5" runat="server" TextMode="Date"></asp:TextBox>
        <asp:TextBox ID="TextBox6" runat="server" TextMode="Color"></asp:TextBox>
        <asp:TextBox ID="TextBox7" runat="server" TextMode="Email"></asp:TextBox>--%>
        <br />
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="State" Text="单身" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="State" Text="已婚" />
        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="State" Text="保密" />
        <br />
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Value="1">男</asp:ListItem>
            <asp:ListItem Value="2">女</asp:ListItem>
            <asp:ListItem Value="3">保密</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
