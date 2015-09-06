<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Ajax.CRUD.UI.Repeater_ObjectDataSource.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
            <%--头部的模板--%>
            <HeaderTemplate>
                <table border="1" cellpadding="2" cellspacing="2">
                    <thead>
                        <tr>
                            <th>
                                编号
                            </th>
                            <th>
                                地区名称
                            </th>
                            <th>
                                父级编号
                            </th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <%--数据模板循环生成每一行， 循环生成每一行  --%>
            <ItemTemplate>
                <tr style="background: yellow;">
                    <td>
                        <%# Eval("AreaId")%>
                    </td>
                    <td>
                        <%# Eval("AreaName")%>
                    </td>
                    <td>
                        <%# Eval("AreaPId")%>
                    </td>
                </tr>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr size="3" width="300" color="red" />
            </SeparatorTemplate>
            <AlternatingItemTemplate>
                <tr style="background: blue;">
                    <td>
                        <%# Eval("AreaId")%>
                    </td>
                    <td>
                        <%# Eval("AreaName")%>
                    </td>
                    <td>
                        <%# Eval("AreaPId")%>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <%--尾部的模板--%>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAreasByParentId"
            TypeName="Ajax.CRUD.BLL.TblAreaBll">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="pid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
