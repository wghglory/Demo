<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MVC_ASPX.Models.Student>>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>IndexPageList</title>
    <link href="../../Content/pageHelperNav.css" rel="stylesheet" />
</head>
<body>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th>
                <%: Html.DisplayNameFor(model => model.Name) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Age) %>
            </th>
            <th>
                <%: Html.DisplayNameFor(model => model.Gender) %>
            </th>
            <th></th>
        </tr>

        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Name) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Age) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Gender) %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
            </td>
        </tr>
        <% } %>
    </table>

    <% int pageSize = ViewBag.pageSize;
       int pageIndex = ViewBag.PageIndex;
       int totalCount = ViewBag.totalCount; %>

    <div class="paginator">
        <%: Html.GetPageNavStr(pageSize,pageIndex,totalCount) %>
    </div>
</body>
</html>
