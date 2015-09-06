<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CRUD.UI.AspxNoServerControl.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="Edit.aspx" method="post">
    <!--这个隐藏域的作用：就是判断用户是否是点击的“保修修改”按钮。
    //因为当用户第一次请求该页面的时候是用get方式请求的。
    但是get请求后面没有跟?hiddenIsPostback=xxxx，所以第一次请求该页面的时候
    context.Request["hiddenIsPostback"]一定是null
     -->
    <input type="hidden" name="hiddenIsPostback" value="true" />
    <table border="1" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                编号
            </td>
            <td>
                <input type="text" name="txtAutoId" value="<%=_model.AutoId %>" readonly="readonly" />
            </td>
        </tr>
        <tr>
            <td>
                登录名
            </td>
            <td>
                <input type="text" name="txtLoginId" value="<%=_model.LoginId %>" />
            </td>
        </tr>
        <tr>
            <td>
                密码
            </td>
            <td>
                <input type="password" name="txtPwd" value="<%=_model.LoginPwd%>" />
            </td>
        </tr>
        <tr>
            <td>
                错误次数
            </td>
            <td>
                <input type="text" name="txtErrorCount" value="<%=_model.ErrorCount%>" />
            </td>
        </tr>
        <tr>
            <td>
                最后出错时间：
            </td>
            <td>
                <input type="text" name="txtLastLoginTime" value="<%=_model.LastLoginTime%>" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <input type="submit" value="保存修改" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
