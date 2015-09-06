<%@ Page Title="子页面的Title" Language="C#" MasterPageFile="~/20130808/母版页/Site1.Master"
    AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Ajax.CRUD.UI._20130808.母版页.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <p>
        fdsfdsffffff</p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        fdsfdsfdsfdsfdsfdsfds</p>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <p>
        fdsfdsfdsfdsf</p>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="head2" runat="server">
    <p>
        fdsfdsfdsfdsfdsfdsfsdfdfdsfdsfdsfdfdsfdsfsd<asp:Button ID="Button1" 
            runat="server" onclick="Button1_Click" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</p>
</asp:Content>
