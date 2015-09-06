<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<!DOCTYPE html>
<html>
   <head runat="server">
      <meta name="viewport" content="width=device-width" />
      <title>Edit</title>
   </head>
   <body>
      <div>
         <% MVC_ASPX.Models.User user = ViewData.Model; %>
         <%--<% MVC_ASPX.Models.User user = (MVC_ASPX.Models.User)ViewData["User"]; %>--%>
         <form action="/User/Edit" method="post">
            <table border="1">
               <tr>
                  <td>id</td>
                  <td>
                     <input type="hidden" name="id" value="<%:user.Id %> " />
                  </td>
               </tr>
               <tr>
                  <td>name</td>
                  <td>
                     <input type="text" name="name" value="<%:user.Name %> " />
                  </td>
               </tr>
               <tr>
                  <td>phone</td>
                  <td>
                     <input type="text" name="phone" value="<%:user.Phone %> " />
                  </td>
               </tr>
               <tr>
                  <td>address</td>
                  <td>
                     <input type="text" name="address" value="<%:user.Address %> " />
                  </td>
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