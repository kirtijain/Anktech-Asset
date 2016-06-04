<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="AnkAsset.Web.UsersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3 class="section-title text-center">Users List</h3>
 <div class="form-group">
    <asp:GridView ID="gridView" DataKeyNames="UserId" runat="server" OnRowDataBound="gridView_RowDataBound"
        AutoGenerateColumns="false" ShowFooter="true" AllowPaging="True" HeaderStyle-Font-Bold="true" PageSize="6"
         CellPadding="4" ForeColor="#333333" GridLines="None">          
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
        
<Columns>
 <asp:TemplateField HeaderText="Name" ItemStyle-Width="80px"> 
      <ItemTemplate>
         <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtName" width="30px"  runat="server" Text='<%#Eval("Name") %>'/>
     </EditItemTemplate>
    
 </asp:TemplateField>
 <asp:TemplateField HeaderText="UserName" ItemStyle-Width="100px">
     <ItemTemplate>
         <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtUserName" width="30px"  runat="server" Text='<%#Eval("UserName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

  <asp:TemplateField HeaderText="Email" ItemStyle-Width="230px">
       <ItemTemplate>
         <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtEmail" width="30px"   runat="server" Text='<%#Eval("Email") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

   <asp:TemplateField HeaderText="Contact No" ItemStyle-Width="150px">
     <ItemTemplate>
         <asp:Label ID="lblUserContact" runat="server" Text='<%#Eval("UserContact") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtUserContact" width="30px"  runat="server" Text='<%#Eval("UserContact") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Address" ItemStyle-Width="200px">
     <ItemTemplate>
         <asp:Label ID="lblUserAddress" runat="server" Text='<%#Eval("UserAddress") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtUserAddress" width="30px"  runat="server" Text='<%#Eval("UserAddress") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
     <asp:TemplateField HeaderText="InActive"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>            
              
               <asp:LinkButton ID="InActive" runat="server" Text="InActive" CommandArgument = '<%# Eval("UserId")%>'  OnClientClick="return confirm('Are you sure you want to Deactivate selected record ?')" OnClick="lkInActive_Click" />
                   
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

