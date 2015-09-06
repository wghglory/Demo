<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentAssembly.aspx.cs" Inherits="WebApplication2.CurrentAssembly" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%="aspx所在的dll"+System.Reflection.Assembly.GetExecutingAssembly().Location %>
    <form id="form1" runat="server">
    <div>
        <%for (int i = 0; i < 10; i++)
          {%>
        <h1>
            hello</h1>
        <%} %>
    </div>
    </form>
</body>
</html>
