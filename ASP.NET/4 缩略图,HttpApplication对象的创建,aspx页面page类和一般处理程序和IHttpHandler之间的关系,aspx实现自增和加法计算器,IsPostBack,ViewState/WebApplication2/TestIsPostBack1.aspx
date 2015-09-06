<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestIsPostBack1.aspx.cs"
    Inherits="WebApplication2.TestIsPostBack1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form id="form1" action="TestIsPostBack1.aspx" method="post">
    <input type="hidden" name="hiddenIsPostBack" value="1" />
    <div>
        <input type="submit" name="name" value="提交" />
    </div>
    </form>--%>
    <!-- -->
    <form id="form1" runat="server">
    <div>
        <input type="submit" name="name" value="提交" />
    </div>
    </form>
</body>
</html>
