<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculateAdd.aspx.cs" Inherits="WebApplication2.CalculateAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" action="CalculateAdd.aspx" method="post">
    <input type="text" name="txtNum1" value="<%=this._number1 %>" />+
    <input type="text" name="txtNum2" value="<%=this._number2 %>" />
    <input type="submit" value="=" />
    <input type="text" value="<%=this._sum %>" />
    </form>
</body>
</html>
