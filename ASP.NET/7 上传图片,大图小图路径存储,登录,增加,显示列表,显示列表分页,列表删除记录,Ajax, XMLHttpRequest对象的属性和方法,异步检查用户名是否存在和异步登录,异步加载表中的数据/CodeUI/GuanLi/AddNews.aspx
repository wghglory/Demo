<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNews.aspx.cs" Inherits="GuanLi_AddNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <!-- #include file=top.htm-->
    <form id="form1" action="AddNews.aspx" method="post" enctype="multipart/form-data">
    <table border="1" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                标题：
            </td>
            <td>
                <input type="text" name="txtTitle" value="" />
            </td>
        </tr>
        <tr>
            <td>
                内容：
            </td>
            <td>
                <textarea cols="30" rows="20" name="txtContent"></textarea>
            </td>
        </tr>
        <tr>
            <td>
                图片：
            </td>
            <td>
                <input type="file" name="imgFile" value="" />
            </td>
        </tr>
        <tr>
            <td>
                类别：
            </td>
            <td>
                <select name="selectCategory">
                    <%for (int i = 0; i < _listTypes.Count; i++)
                      {%>
                    <option value="<%=_listTypes[i].TypeId %>">
                        <%=_listTypes[i].TypeName %></option>
                    <%} %>
                </select>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <input type="submit" value="保存" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
