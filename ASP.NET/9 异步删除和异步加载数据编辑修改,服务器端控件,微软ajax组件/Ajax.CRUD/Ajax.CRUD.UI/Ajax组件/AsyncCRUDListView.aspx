<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncCRUDListView.aspx.cs" Inherits="Ajax.CRUD.UI._20130808.Ajax组件.AsyncCRUDListView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
                    <AlternatingItemTemplate>
                        <tr style="background-color:#FFF8DC;">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                            </td>
                            <td>
                                <asp:Label ID="StuIdLabel" runat="server" Text='<%# Eval("StuId") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuNameLabel" runat="server" Text='<%# Eval("StuName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuAgeLabel" runat="server" Text='<%# Eval("StuAge") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuGenderLabel" runat="server" Text='<%# Eval("StuGender") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuEmailLabel" runat="server" Text='<%# Eval("StuEmail") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuBirthdayLabel" runat="server" 
                                    Text='<%# Eval("StuBirthday") %>' />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <tr style="background-color:#008A8C;color: #FFFFFF;">
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                            </td>
                            <td>
                                <asp:TextBox ID="StuIdTextBox" runat="server" Text='<%# Bind("StuId") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="StuNameTextBox" runat="server" Text='<%# Bind("StuName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="StuAgeTextBox" runat="server" Text='<%# Bind("StuAge") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="StuGenderTextBox" runat="server" 
                                    Text='<%# Bind("StuGender") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="StuEmailTextBox" runat="server" 
                                    Text='<%# Bind("StuEmail") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="StuBirthdayTextBox" runat="server" 
                                    Text='<%# Bind("StuBirthday") %>' />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" 
                            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                            <tr>
                                <td>
                                    未返回数据。</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                            </td>
                            <td>
                                <asp:TextBox ID="StuIdTextBox" runat="server" Text='<%# Bind("StuId") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="StuNameTextBox" runat="server" Text='<%# Bind("StuName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="StuAgeTextBox" runat="server" Text='<%# Bind("StuAge") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="StuGenderTextBox" runat="server" 
                                    Text='<%# Bind("StuGender") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="StuEmailTextBox" runat="server" 
                                    Text='<%# Bind("StuEmail") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="StuBirthdayTextBox" runat="server" 
                                    Text='<%# Bind("StuBirthday") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr style="background-color:#DCDCDC;color: #000000;">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                            </td>
                            <td>
                                <asp:Label ID="StuIdLabel" runat="server" Text='<%# Eval("StuId") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuNameLabel" runat="server" Text='<%# Eval("StuName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuAgeLabel" runat="server" Text='<%# Eval("StuAge") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuGenderLabel" runat="server" Text='<%# Eval("StuGender") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuEmailLabel" runat="server" Text='<%# Eval("StuEmail") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuBirthdayLabel" runat="server" 
                                    Text='<%# Eval("StuBirthday") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                            <th runat="server">
                                            </th>
                                            <th runat="server">
                                                StuId</th>
                                            <th runat="server">
                                                StuName</th>
                                            <th runat="server">
                                                StuAge</th>
                                            <th runat="server">
                                                StuGender</th>
                                            <th runat="server">
                                                StuEmail</th>
                                            <th runat="server">
                                                StuBirthday</th>
                                        </tr>
                                        <tr ID="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" 
                                    style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                            </td>
                            <td>
                                <asp:Label ID="StuIdLabel" runat="server" Text='<%# Eval("StuId") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuNameLabel" runat="server" Text='<%# Eval("StuName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuAgeLabel" runat="server" Text='<%# Eval("StuAge") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuGenderLabel" runat="server" Text='<%# Eval("StuGender") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuEmailLabel" runat="server" Text='<%# Eval("StuEmail") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StuBirthdayLabel" runat="server" 
                                    Text='<%# Eval("StuBirthday") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" 
                    PageSize="5">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    DataObjectTypeName="Ajax.CRUD.Model.Aspx_Students" DeleteMethod="DeleteByStuId" 
                    InsertMethod="Add" SelectMethod="GetStudentsBetweentAnd" 
                    TypeName="Ajax.CRUD.BLL.Aspx_StudentsBll" UpdateMethod="Update" 
                    EnablePaging="True" MaximumRowsParameterName="pageRows" 
                    SelectCountMethod="GetTotalCount" StartRowIndexParameterName="startRowNumber">
                    <DeleteParameters>
                        <asp:Parameter Name="stuId" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
