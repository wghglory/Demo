﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MVC_ASPX.Models.Student>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Create</title>
</head>
<body>
    <script src="<%: Url.Content("~/Scripts/jquery-1.8.2.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>
    
    <% using (Html.BeginForm()) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>
    
        <fieldset>
            <legend>Student</legend>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Age) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Age) %>
                <%: Html.ValidationMessageFor(model => model.Age) %>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Gender) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Gender) %>
                <%: Html.ValidationMessageFor(model => model.Gender) %>
            </div>
    
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
    <% } %>
    
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</body>
</html>
