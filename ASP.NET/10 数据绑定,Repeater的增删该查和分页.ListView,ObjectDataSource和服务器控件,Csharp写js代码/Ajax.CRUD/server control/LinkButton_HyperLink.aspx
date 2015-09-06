<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinkButton_HyperLink.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.baidu.com">百度</asp:HyperLink>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" CommandArgument="1" CommandName="Delete"
            OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" CommandArgument="2" CommandName="Update"
            OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" CommandArgument="3" CommandName="Select"
            OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" GroupingText="Basic Info">
            xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx</asp:Panel>
        <br />
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
        <br />
        <br />
        <br />
        <div runat="server" id="dv1">
        </div>
        <input id="txt1" runat="server" type="text" name="name" value="1`11" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
