<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="AnkAsset.Web.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<%--  $weeks = array("Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat");
echo date('w', mktime(0, 0, 0, $month, 0, $year));
for ($i = 1; $i <= $days_in_month; $i++) {
    array_push($weeks, $i);
}
foreach ($weeks as $key => $value) {
    if (($a++ % $b) == 0) {
        echo "<tr>";
    }
    if($value==$day){
        echo "<td><font color='red'> $value</font></td>"; 
    }
    else{
    echo "<td> $value</td>";
    }
}--%>
<body>
    <form id="form1" runat="server">
        <div>
            <%  string[] weeks = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

                var date = DateTime.Now;
                var month = 0;
                //var a = 0;
                //var b = 7;
                var day = date.Date; //20
                var year = date.Year;//2016 
                var monthname = date.ToString("MMMM");
                if (string.IsNullOrEmpty(Request.QueryString["next"]) && string.IsNullOrEmpty(Request.QueryString["pre"]))
                {
                    month = date.Month; //4
                }
                else
                {
                    if (Convert.ToInt32(Request.QueryString["next"]) != 0)
                    {
                        month = Convert.ToInt32(Session["Month"]) + 1;
                        Session["Inc"] = Convert.ToInt32(Session["Inc"]) + 1;
                        monthname = date.AddMonths(Convert.ToInt32(Session["Inc"])).ToString("MMMM");
                    }
                    else
                    {
                        month = Convert.ToInt32(Session["Month"]) - 1;
                        Session["Inc"] = Convert.ToInt32(Session["Inc"]) - 1;
                        monthname = date.AddMonths(Convert.ToInt32(Session["Inc"])).ToString("MMMM");
                    }
                }

                Session["Month"] = month;
                var days_in_month = DateTime.DaysInMonth(year, month);
                var j = 0;
                var i = 0;%>

            <table border="1" width="40%">
                <tr>
                    <td colspan="2" align="center">
                        <a href="/WebForm2.aspx?pre=<%= Session["Month"]%>">Pre</a>
                    </td>
                    <td colspan="3" align="center"><%Response.Write(monthname);%></td>
                    <td colspan="2" align="center"><a href="/WebForm2.aspx?next=<%=  Session["Month"] %>">Next</a>
                    </td>
                </tr>
                  <tr>
                    <%for (j = 1; j <= 7; j++)
                      {%>
                    <% DateTime testDate = new DateTime(year, month, j); %>
                    <td><% Response.Write(testDate.DayOfWeek);%></td>
                    <% } %>
                </tr>
                <%--<tr>
                    <%for (j = 0; j < weeks.Length; j++)
                      {%>
                    <td><% Response.Write(weeks[j]);%></td>
                    <% } %>
                </tr>--%>

                <tr>
                    <%var a = 0;
                      var b = 7; %>
                    <%for (i = 1; i <= days_in_month; i++)
                      { %>
                    <%if ((a++ % b) == 0)
                      { %>
                    <tr>

                        <%} %>
                        <td><% Response.Write(i);%></td>
                        <%} %>

               <%-- <%for (i = 1; i <= days_in_month; i++)
                  { %>
                <% array_push(weeks, i); %>

                <%} %>

                <%foreach (var value in weeks)
                  { %>

                <%if ((a++ % b) == 0)
                  { %>

                <tr>
                    <%} %>

                    <%if (value == day.ToString())
                          
                      { %>

                    <td><font color='red'><%Response.Write(value);%></font></td>

                    <%} %>

                    <%else
                      
                      { %>
                    <td><%Response.Write(value); %></td>

                    <% } %>

                    <%} %>--%>
            </table>

        </div>
    </form>
</body>
</html>
