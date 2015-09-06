<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRUD.UI.基本操作练习.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.8.3.js" type="text/javascript"></script>
    <script type="text/javascript">
        //        window.onload = function () {
        //            document.getElementById('imgValidCode').onclick = function () {
        //                this.src = 'ValidCode.ashx?id=' + Math.random();
        //            };
        //        };
        $(function () {
            $('#imgValidCode').click(function () {
                $(this).attr('src', 'ValidCode.ashx?id=' + Math.random()); //防止缓存，没有请求
            });

            //为按钮注册单击事件
            $('input[type=submit]').click(function () {
                if ($('input[name=txtLoginId]').val().length > 0 && $('input[name=txtLoginPwd]').val().length > 0 && $('input[name=txtValidCode]').val().length == 4) {


                } else {
                    alert('请正确填写信息！');
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" action="Login.aspx" method="post">
    <table border="1" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                Login Id
            </td>
            <td>
                <input type="text" name="txtLoginId" value="<%=_userName %>" />
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <input type="password" name="txtLoginPwd" value="" />
            </td>
        </tr>
        <tr>
            <td>
                验证码：
            </td>
            <td>
                <img id="imgValidCode" src="ValidCode.ashx" alt="" />
                <input type="text" name="txtValidCode" size="4" maxlength="4" value="" />
                <font color="red">
                    <%=_validCodeErrorMsg%></font>
            </td>
        </tr>
        <tr>
            <td>
                记住用户:
            </td>
            <td>
                <input type="checkbox" name="chkRemember" value="1" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <input type="submit" value="登录" />
                <%=LoginErrorMsg %>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
