<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesList.aspx.cs" Inherits="AnkAsset.Web.EmployeesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3 class="section-title text-center">Employees List</h3>
    <a href="Employee.aspx"  class="section-title text-center" >Add New Employee</a>
 <div class="form-group">
    <asp:GridView ID="gridView" DataKeyNames="Id" runat="server" 
        AutoGenerateColumns="false" ShowFooter="true" AllowPaging="True" HeaderStyle-Font-Bold="true" PageSize="6"
         CellPadding="4" ForeColor="#333333" GridLines="None">          
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
        
<Columns>
    <asp:TemplateField HeaderText="Employee Id" ItemStyle-Width="120px"> 
      <ItemTemplate>
         <asp:Label ID="lblEmpId" runat="server" Text='<%#Eval("EmpId") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtEmpId" width="30px"  runat="server" Text='<%#Eval("EmpId") %>'/>
     </EditItemTemplate>
    
 </asp:TemplateField>
 <asp:TemplateField HeaderText="First Name" ItemStyle-Width="130px"> 
      <ItemTemplate>
         <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("EmployeeName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtFirstName" width="30px"  runat="server" Text='<%#Eval("EmployeeName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
 
  <asp:TemplateField HeaderText="Email Id" ItemStyle-Width="170px">
       <ItemTemplate>
         <asp:Label ID="lblEmailId" runat="server" Text='<%#Eval("EmailId") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtEmailId" width="30px"   runat="server" Text='<%#Eval("EmailId") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

   <asp:TemplateField HeaderText="Contact No" ItemStyle-Width="150px">
     <ItemTemplate>
         <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtContactNo" width="30px"  runat="server" Text='<%#Eval("ContactNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Address" ItemStyle-Width="150px">
     <ItemTemplate>
         <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtAddress" width="30px"  runat="server" Text='<%#Eval("Address") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
     <asp:TemplateField HeaderText="Edit"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px">
            <ItemTemplate>             
              <a href='<%# "Employee.aspx?Id="+ Eval("Id")%>'>Edit</a>
            </ItemTemplate>
             <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
     <asp:TemplateField HeaderText="InActive"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>            
              
               <asp:LinkButton ID="InActive" runat="server" Text="InActive" CommandArgument = '<%# Eval("Id")%>'  OnClientClick="return confirm('Are you sure you want to Deactivate selected record ?')" OnClick="lkInActive_Click" />
                   
             <%-- <a href='<%# "Register.aspx?UserId="+ Eval("UserId")%>'>Edit</a>--%>
            </ItemTemplate>
             <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
      
 </Columns>
         <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#c9e3e0 " Font-Bold="True" ForeColor="Black" />
            <HeaderStyle BackColor="#c9e3e0 " Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle CssClass="rowHover" BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" /> 
              
</asp:GridView>
    </div>
<div class="form-group">
<br />&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblmsg" runat="server"></asp:Label>
</div>
 </asp:Content>


