<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AnkAsset.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%
                string[] arr = new string[10] { "Y", "Y", "N", "Y", "N", "Y", "N", "Y", "N", "Y" }; %>
            <%  var count = 0;
                var x = 3;
                int i = 1;               
                int j = 1;
                int y = 0;%>
            <%
                for (i = 0; i < arr.Length; i++)
                {
                    count++;

                } %>
          
            <% if ((count % x) == 0)%>
            <%{%>
            <% y = count / x;%>
            <%}%>
            <%else%>
            <%{%>
            <%y = (count / x) + 1;%>
            <%}%>


            <table width='500px'>
                 <%  var index = 0; %>
                <% for (i = 1; i <= y; i++) %>
                <%{ %>               
                <tr>
                    <%for (j = 1; j <= 3; j++)
                      { %>

                    <td>
                        <%Response.Write(arr[index]);%>
                    </td>
                    <% index++; %>
                    <%} %>
                </tr>

                <% }%>
            </table>


        </div>
    </form>
</body>
</html>
