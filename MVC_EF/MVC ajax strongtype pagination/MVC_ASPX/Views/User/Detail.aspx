<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Detail</title>
</head>
<body>
    <div>
        <% MVC_ASPX.Models.User user = (MVC_ASPX.Models.User)ViewData["User"]; %>
        <table border="1">
            <tr>
                <td>id</td>
                <td>
                    <span><%:user.Id %></span>
                </td>
            </tr>
            <tr>
                <td>name</td>
                <td>
                    <span><%:user.Name %></span>
                </td>
            </tr>
            <tr>
                <td>phone</td>
                <td>
                    <span><%:user.Phone %></span>
                </td>
            </tr>
            <tr>
                <td>address</td>
                <td>
                    <span><%:user.Address %></span>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
