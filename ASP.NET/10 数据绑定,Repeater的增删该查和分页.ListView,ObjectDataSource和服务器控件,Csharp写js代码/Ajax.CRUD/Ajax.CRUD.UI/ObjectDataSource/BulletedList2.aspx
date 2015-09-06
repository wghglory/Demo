<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletedList2.aspx.cs" Inherits="Ajax.CRUD.UI.Repeater_ObjectDataSource.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetAreasByParentId" TypeName="Ajax.CRUD.BLL.TblAreaBll">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" DefaultValue="0" Name="pid" 
                    PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br />
        <asp:BulletedList ID="BulletedList1" runat="server" 
            DataSourceID="ObjectDataSource1" DataTextField="AreaName" 
            DataValueField="AreaId">
        </asp:BulletedList>
    
    </div>
    </form>
</body>
</html>
