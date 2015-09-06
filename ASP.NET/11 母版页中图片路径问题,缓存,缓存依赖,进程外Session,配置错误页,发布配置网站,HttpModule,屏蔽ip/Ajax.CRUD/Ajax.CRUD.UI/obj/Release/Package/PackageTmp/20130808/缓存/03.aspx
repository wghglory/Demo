<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="03.aspx.cs" Inherits="Ajax.CRUD.UI._20130808.缓存._03" %>

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
                        <%#Eval("StuId") %>
                    </td>
                    <td>
                        <%#Eval("StuName") %>
                    </td>
                    <td>
                        <%#Eval("StuAge") %>
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
