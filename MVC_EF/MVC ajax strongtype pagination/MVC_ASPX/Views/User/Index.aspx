<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<!DOCTYPE html>
<html>
   <head runat="server">
      <meta name="viewport" content="width=device-width" />
      <title>Index</title>
   </head>
   <body>
      <div>
         <% List<MVC_ASPX.Models.User> userlist = (List<MVC_ASPX.Models.User>)ViewData["User"]; %>
         <a href="/User/Add">Add new</a>
         <table>
            <tr>
               <th>id</th>
               <th>name</th>
               <th>phone</th>
               <th>operation</th>
            </tr>
            <%for (int i = 0; i < userlist.Count; i++)
              {%>
            <tr>
               <td><%=userlist[i].Id %></td>
               <td><%=userlist[i].Name %></td>
               <td><%=userlist[i].Phone %></td>
               <td><a href="/User/Edit?id=<%:userlist[i].Id %>">edit</a> &nbsp;
                  <a href="/User/Detail?id=<%:userlist[i].Id %>">Detail</a> &nbsp;
                  <a href="/User/Delete?id=<%:userlist[i].Id %>">Delete</a> 
               </td>
            </tr>
            <%} %>
         </table>
      </div>
   </body>
</html>