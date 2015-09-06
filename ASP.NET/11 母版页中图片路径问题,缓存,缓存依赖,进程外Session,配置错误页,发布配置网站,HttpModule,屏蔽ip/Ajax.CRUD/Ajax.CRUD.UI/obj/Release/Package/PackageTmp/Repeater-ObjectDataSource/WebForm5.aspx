<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="Ajax.CRUD.UI.Repeater_ObjectDataSource.WebForm5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        省：<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="ObjectDataSource1" DataTextField="AreaName" 
            DataValueField="AreaId">
        </asp:DropDownList>
        市：<asp:DropDownList ID="DropDownList2" runat="server" 
            DataSourceID="ObjectDataSource2" DataTextField="AreaName" 
            DataValueField="AreaId">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetAreasByParentId" TypeName="Ajax.CRUD.BLL.TblAreaBll">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="pid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetAreasByParentId" TypeName="Ajax.CRUD.BLL.TblAreaBll">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="1" Name="pid" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    
    </div>
    </form>
</body>
</html>
