<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletedList.aspx.cs" Inherits="Ajax.CRUD.UI.BulletedList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%=System.Reflection.Assembly.GetExecutingAssembly().Location%>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAreasByParentId"
            TypeName="Ajax.CRUD.BLL.TblAreaBll">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" DefaultValue="0" Name="pid" PropertyName="Text"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource1"
            DataTextField="AreaName" DataValueField="AreaId">
        </asp:DropDownList>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br />
        <br />
        <br />
        <asp:BulletedList ID="BulletedList1" runat="server">
        </asp:BulletedList>
        <br />
        ========================================<br />
        <asp:BulletedList ID="BulletedList2" runat="server" 
            DataSourceID="ObjectDataSource2" DataTextField="AreaId" DataValueField="AreaId">
        </asp:BulletedList>
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetAreasByParentId" TypeName="Ajax.CRUD.BLL.TblAreaBll">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="pid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <br />
        ==============省市联动==============================<br />
        <br />
        <br />
        省<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
            DataSourceID="ObjectDataSource3" DataTextField="AreaName" 
            DataValueField="AreaId">
        </asp:DropDownList>
        市<asp:DropDownList ID="DropDownList3" runat="server" 
            DataSourceID="ObjectDataSource4" DataTextField="AreaName" 
            DataValueField="AreaId">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
            SelectMethod="GetAreasByParentId" TypeName="Ajax.CRUD.BLL.TblAreaBll">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList2" Name="pid" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
            SelectMethod="GetAreasByParentId" TypeName="Ajax.CRUD.BLL.TblAreaBll">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="pid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
