<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="验证码.aspx.cs" Inherits="WebApplication1.验证码" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="text" name="validcode" value="" />
        <img src="ValidCodeashx.ashx" alt="Alternate Text" />
        <input type="submit" name="name" value="验证" />
        <font color="red"><%=msg %></font>

    </div>
    </form>
</body>
</html>
