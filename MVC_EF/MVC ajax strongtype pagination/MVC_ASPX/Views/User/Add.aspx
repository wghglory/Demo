<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Add</title>
</head>
<body>
    <div>
        <form action="/User/Add" method="post">
            <table>
                <tr>
                    <td>name</td>
                    <td>
                        <input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td>phone</td>
                    <td>
                        <input type="text" name="phone" value=" " /></td>
                </tr>
                <tr>
                    <td>address</td>
                    <td>
                        <input type="text" name="address" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input type="submit" value="submit" /></td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
