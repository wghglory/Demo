<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MVC_ASPX.Models.User>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Details</title>
</head>
<body>
    <fieldset>
        <legend>User</legend>
    
        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Name) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Name) %>
        </div>
    
        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Address) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Address) %>
        </div>
    
        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Phone) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Phone) %>
        </div>
    
        <div class="display-label">
            <%: Html.DisplayNameFor(model => model.Age) %>
        </div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Age) %>
        </div>
    </fieldset>
    <p>
    
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</body>
</html>
