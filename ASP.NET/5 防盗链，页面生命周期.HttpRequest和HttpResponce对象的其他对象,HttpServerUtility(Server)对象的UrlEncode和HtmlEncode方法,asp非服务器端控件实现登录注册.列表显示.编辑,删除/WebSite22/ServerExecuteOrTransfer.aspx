<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServerExecuteOrTransfer.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><!--Server这两个方法是服务器内部接管，不能重定向到外部网站，比redirect 302 found 少了请求-->
        <%-- <%this.Server.Execute("Default.aspx"); %>  第二个页面插入第一个，后面如果有第一个页面内容，则显示--%>
        <%-- <%this.Server.Transfer("Default.aspx");%>  第二个页面插入，插入后第一个页面不显示--%>
        <%this.Server.Execute("Default.aspx",true);%>
    </div>
    <asp:Button ID="Button1" runat="server" Text="11111" />
    </form>
    <h1>
        小标记。。</h1>
</body>
</html>
