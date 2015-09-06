<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repeater.aspx.cs" Inherits="Ajax.CRUD.UI.Repeater" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Repeater ID="Repeater3" runat="server" DataSourceID="ObjectDataSource2" OnItemCommand="Repeater3_ItemCommand">
        <ItemTemplate>
            <div>
                <a href="#">
                    <%#Eval("Title")%></a>
                <div>
                    <%#Eval("Content") %>
                </div>
                <div>
                    邮箱：<%#Eval("Email") %></div>
                <div>
                    <asp:Button ID="Button1" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("AutoId") %>' />
                </div>
                <div>
                    <asp:Button ID="Button2" runat="server" Text="编辑" CommandName="Edit" CommandArgument='<%#Eval("AutoId") %>' />
                </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div style="background: yellow">
                <a href="#">
                    <%#Eval("Title")%></a>
                <div>
                    <%#Eval("Content") %>
                </div>
                <div>
                    邮箱：<%#Eval("Email") %></div>
                <div>
                    <asp:Button ID="Button1" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("AutoId") %>' />
                </div>
                <div>
                    <asp:Button ID="Button2" runat="server" Text="编辑" CommandName="Edit" CommandArgument='<%#Eval("AutoId") %>' />
                </div>
            </div>
        </AlternatingItemTemplate>
        <SeparatorTemplate>
            <hr style="border: 1px dashed red; margin-top: 10px;" />
        </SeparatorTemplate>
    </asp:Repeater>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAllComments"
        TypeName="Ajax.CRUD.BLL.TblCommentsBll"></asp:ObjectDataSource>
    <br />
    <br />
    <br />
    <asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
            <table>
                <tr style="background-color: red;">
                    <td>
                        <%#Eval("AreaId") %>
                    </td>
                    <td>
                        <%#Eval("AreaName") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <table>
                <tr style="background-color: Blue;">
                    <td>
                        <%#Eval("AreaId") %>
                    </td>
                    <td>
                        <%#Eval("AreaName") %>
                    </td>
                </tr>
            </table>
        </AlternatingItemTemplate>
        <SeparatorTemplate>
            <hr style="color: Yellow;" />
        </SeparatorTemplate>
    </asp:Repeater>
    ===========================================================
    <div>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background-color: red;">
                    <td>
                        <%#Eval("AreaId") %>
                    </td>
                    <td>
                        <%#Eval("AreaName") %>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background-color: Blue;">
                    <td>
                        <%#Eval("AreaId") %>
                    </td>
                    <td>
                        <%#Eval("AreaName") %>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <SeparatorTemplate>
                <hr style="color: Yellow;" />
            </SeparatorTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAreasByParentId"
            TypeName="Ajax.CRUD.BLL.TblAreaBll">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="pid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    ====================================================
    </form>
</body>
</html>
