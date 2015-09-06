<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="GuanLi_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        window.onload = function () {

            document.getElementById('imgValidCode').onclick = function () {
                this.src = 'ValidCode.ashx?id=' + Math.random();
            };
        };
    </script>
</head>
<body>
    <form id="form1" action="Login.aspx" method="post">
    <div>
        <table border="1" cellpadding="2" cellspacing="2">
            <tr>
                <td>
                    login id
                </td>
                <td>
                    <input type="text" name="txtLoginId" value="<%=_userName %>" />
                </td>
            </tr>
            <tr>
                <td>
                    password
                </td>
                <td>
                    <input type="password" name="txtPassword" value="" />
                </td>
            </tr>
            <tr>
                <td>
                    验证码
                </td>
                <td>
                    <input type="text" size="4" maxlength="4" name="txtValidcode" value="" />
                    <img id="imgValidCode" src="ValidCode.ashx" alt="" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <input type="checkbox" name="chkRemember" value="1" />记住我
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <input type="submit" value="登录" />
                    <font color="red"><%=_errorMsg %></font>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
