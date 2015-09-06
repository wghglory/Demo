<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="Ajax.CRUD.UI.test.WebForm6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ajax.CRUD.Model.Aspx_Students"
        DeleteMethod="DeleteByStuId" InsertMethod="Add" SelectMethod="GetStudentsByPage"
        TypeName="Ajax.CRUD.BLL.Aspx_StudentsBll" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="stuId" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="5" Name="pagesize" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="1" Name="pageindex" QueryStringField="pageindex"
                Type="Int32" />
            <asp:Parameter Direction="Output" Name="recordcount" Type="Int32" />
            <asp:Parameter Direction="Output" Name="pagecount" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <table width="400" border="1" cellpadding="2" cellspacing="2">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("StuId")%>
                </td>
                <td>
                    <%#Eval("StuName")%>
                </td>
                <td>
                    <%#Eval("StuAge")%>
                </td>
                <td>
                    <%#Eval("StuGender")%>
                </td>
                <td>
                    <%#Eval("StuEmail")%>
                </td>
                <td>
                    <%#Eval("StuBirthday")%>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" CommandArgument='<%#Eval("StuId")%>' CommandName="Delete"
                        Text="删除" />
                </td>
                <td>
                    <a href="EditStudent.aspx?sid=<%#Eval("StuId") %>">编辑</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <p>
        <%=PagerString %>
    </p>
    </form>
</body>
</html>
