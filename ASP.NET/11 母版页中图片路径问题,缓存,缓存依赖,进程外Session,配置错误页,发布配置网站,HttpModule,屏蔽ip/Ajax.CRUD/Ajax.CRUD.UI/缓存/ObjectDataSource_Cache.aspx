<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObjectDataSource_Cache.aspx.cs" Inherits="Ajax.CRUD.UI._20130808.缓存._04" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
            <HeaderTemplate>
                <table border="1" cellpadding="2" cellspacing="2">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("AutoId")%>
                    </td>
                    <td>
                        <%#Eval("Title")%>
                    </td>
                    <td>
                        <%#Eval("Email")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="ObjectDataSource1" EnableCaching="true" CacheDuration="20"
            CacheExpirationPolicy="Absolute" runat="server" SelectMethod="GetAllComments"
            TypeName="Ajax.CRUD.BLL.TblCommentsBll"></asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
