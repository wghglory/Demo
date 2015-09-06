<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repeater隔行变色.aspx.cs" Inherits="Ajax.CRUD.UI.Repeater_ObjectDataSource.Repeater隔行变色" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllComments"
            TypeName="Ajax.CRUD.BLL.TblCommentsBll"></asp:ObjectDataSource>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
            <ItemTemplate>
                <div>
                    <div style="font: 14px 宋体; color: #3273C0;">
                        <%# Eval("Title")%></div>
                    <div style="font: 12px 宋体; color: Black;">
                        <%#Eval("Content") %></div>
                    <span style="font: 12px 宋体; color: Black;">
                        <%#Eval("Email")%></span>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div style="background-color: Yellow">
                    <div style="font: 14px 宋体; color: #3273C0;">
                        <%# Eval("Title")%></div>
                    <div style="font: 12px 宋体; color: Black;">
                        <%#Eval("Content") %></div>
                    <span style="font: 12px 宋体; color: Black;">
                        <%#Eval("Email")%></span>
                </div>
            </AlternatingItemTemplate>
            <SeparatorTemplate>
                <hr style="border: 2px dashed gray;" />
            </SeparatorTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
