<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeaterShowByPage.aspx.cs"
    Inherits="Ajax.CRUD.UI.Repeater.RepeaterShowByPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1" OnItemCommand="Repeater1_ItemCommand"
            OnItemDataBound="Repeater1_ItemDataBound">
            <HeaderTemplate>
                <table border="1" cellpadding="2" cellspacing="2">
                    <thead>
                        <tr>
                            <th>
                                编号
                            </th>
                            <th>
                                姓名
                            </th>
                            <th>
                                年龄
                            </th>
                            <th>
                                性别
                            </th>
                            <th>
                                Email
                            </th>
                            <th>
                                生日
                            </th>
                            <th>
                                编辑
                            </th>
                            <th>
                                删除
                            </th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("StuId")%>
                    </td>
                    <td>
                        <%#Eval("StuName")%>
                    </td>
                    <td runat="server" id="tdAge">
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
                        <a href='EditStudent.aspx?sid=<%#Eval("StuId")%>'>编辑</a>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CommandArgument='<%#Eval("StuId")%>' CommandName="Delete"
                            Text="删除" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetStudentsByPage"
            TypeName="Ajax.CRUD.BLL.Aspx_StudentsBll">
            <SelectParameters>
                <asp:Parameter DefaultValue="5" Name="pagesize" Type="Int32" />
                <asp:QueryStringParameter DefaultValue="1" Name="pageindex" QueryStringField="pageindex"
                    Type="Int32" />
                <asp:Parameter Direction="Output" Name="recordcount" Type="Int32" />
                <asp:Parameter Direction="Output" Name="pagecount" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
      
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
      
    </div>
    </form>
</body>
</html>
