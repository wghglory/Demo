<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cacheDenpendency_数据库.aspx.cs" Inherits="Ajax.CRUD.UI._20130808.缓存._06" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table border="1" cellpadding="2" cellspacing="2">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("AutoId") %>
                    </td>
                    <td>
                        <%#Eval("Title") %>
                    </td>
                    <td>
                        <%#Eval("Email") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
