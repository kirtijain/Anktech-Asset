<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendorList.aspx.cs" Inherits="AnkAsset.Web.VendorList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3 class="section-title text-center">Vendors List</h3>
      <a href="Vendor.aspx"  class="section-title text-center" >Add New Vendor</a>
 <div class="form-group">
    <asp:GridView ID="gridView" DataKeyNames="AssetVendorId" runat="server" 
        AutoGenerateColumns="false" ShowFooter="true" AllowPaging="True" HeaderStyle-Font-Bold="true" PageSize="6" OnPageIndexChanging="gridView_PageIndexChanging"
         CellPadding="4" ForeColor="#333333" GridLines="None">          
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
        
<Columns>
 <asp:TemplateField HeaderText="Vendor Name" ItemStyle-Width="130px"> 
      <ItemTemplate>
         <asp:Label ID="lblName" runat="server" Text='<%#Eval("VendorName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtName" width="30px"  runat="server" Text='<%#Eval("VendorName") %>'/>
     </EditItemTemplate>
    
 </asp:TemplateField>
 <asp:TemplateField HeaderText="Person Name" ItemStyle-Width="130px">
     <ItemTemplate>
         <asp:Label ID="lblPersonName" runat="server" Text='<%#Eval("PersonName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtPersonName" width="30px"  runat="server" Text='<%#Eval("PersonName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

 <%-- <asp:TemplateField HeaderText="Email" ItemStyle-Width="230px">
       <ItemTemplate>
         <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtEmail" width="30px"   runat="server" Text='<%#Eval("Email") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>--%>

   <asp:TemplateField HeaderText="Contact No" ItemStyle-Width="130px">
     <ItemTemplate>
         <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtContactNo" width="30px"  runat="server" Text='<%#Eval("ContactNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
    
   <asp:TemplateField HeaderText="Alternate No" ItemStyle-Width="130px">
     <ItemTemplate>
         <asp:Label ID="lblAlternateNumber" runat="server" Text='<%#Eval("AlternateNumber") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtAlternateNumber" width="30px"  runat="server" Text='<%#Eval("AlternateNumber") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Service Center Address" ItemStyle-Width="170px">
     <ItemTemplate>
         <asp:Label ID="lblServiceCenterAddress" runat="server" Text='<%#Eval("ServiceCenterAddress") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtServiceCenterAddress" width="30px"  runat="server" Text='<%#Eval("ServiceCenterAddress") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
      <asp:TemplateField HeaderText="Edit"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="50px">
            <ItemTemplate>             
              <a href='<%# "Vendor.aspx?AssetVendorId="+ Eval("AssetVendorId")%>'>Edit</a>
            </ItemTemplate>
             <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
     <asp:TemplateField HeaderText="Delete"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>            
              
               <asp:LinkButton ID="Delete" runat="server" Text="Delete" CommandArgument = '<%# Eval("AssetVendorId")%>'  OnClientClick="return confirm('Are you sure you want to Delete selected record ?')" OnClick="lkDelete_Click" />
                   
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
