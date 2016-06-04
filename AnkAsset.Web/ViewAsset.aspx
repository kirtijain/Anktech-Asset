<%@ Page Title="" Language="C#"  AutoEventWireup="true"MasterPageFile="~/Site.Master" CodeBehind="ViewAsset.aspx.cs" Inherits="AnkAsset.Web.ViewAsset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3 class="section-title text-center">Assets List</h3>
     <a href="Asset.aspx"  class="section-title text-center" >Add Assets</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="Label1" runat="server" Text="Bill No" style="color:#2bb3dd"></asp:Label>
&nbsp;
      <asp:TextBox ID="txtbill" runat="server" Width="120"></asp:TextBox>&nbsp;&nbsp
      <asp:Button ID="Button1" runat="server" Text="Search" OnClick="ViewAsset_Click" CssClass="btn btn-primary btn-submit"/>
      <div class="form-group">
    <asp:GridView ID="gridView" DataKeyNames="AssetId" runat="server" 
        AutoGenerateColumns="false" ShowFooter="true" AllowPaging="True" HeaderStyle-Font-Bold="true" PageSize="8" OnPageIndexChanging="gridView_PageIndexChanging"
         CellPadding="4" ForeColor="#333333" GridLines="None">          
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
        
<Columns>
 <asp:TemplateField HeaderText="Asset Name" ItemStyle-Width="100px">
      <ItemTemplate>
         <asp:Label ID="lblAssetName" runat="server" Text='<%#Eval("AssetName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtAssetName" width="30px"  runat="server" Text='<%#Eval("AssetName") %>'/>
     </EditItemTemplate>
    
 </asp:TemplateField>
 
  <asp:TemplateField HeaderText="Asset Type" ItemStyle-Width="100px">
       <ItemTemplate>
         <asp:Label ID="lblAssetTypeName" runat="server" Text='<%#Eval("AssetTypeName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtAssetTypeName" width="30px"   runat="server" Text='<%#Eval("AssetTypeName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
    <asp:TemplateField HeaderText="Bill No" ItemStyle-Width="160px">
     <ItemTemplate>
         <asp:Label ID="lblModelNo" runat="server" Text='<%#Eval("BillNo") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtModelNo" width="30px"  runat="server" Text='<%#Eval("BillNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
   
    <asp:TemplateField HeaderText="Price" ItemStyle-Width="140px"> 
     <ItemTemplate>
         <asp:Label ID="lblAssetPrice" runat="server" Text='<%#Eval("AssetPrice") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtAssetPrice" width="30px"  runat="server" Text='<%#Eval("AssetPrice") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Description" ItemStyle-Width="150px">
     <ItemTemplate>
         <asp:Label ID="lblAssetDescription" runat="server" Text='<%#Eval("AssetDescription") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtAssetDescription" width="30px"  runat="server" Text='<%#Eval("AssetDescription") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Quantity" ItemStyle-Width="80px">
     <ItemTemplate>
         <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtQuantity" width="30px"  runat="server" Text='<%#Eval("Quantity") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Purchase Date" ItemStyle-Width="180px">
     <ItemTemplate>
         <asp:Label ID="lblPurchaseDate" runat="server" Text='<%#Eval("PurchaseDate") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtPurchaseDate" width="30px"  runat="server" Text='<%#Eval("PurchaseDate") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

   <%-- <asp:TemplateField HeaderText="Warrenty Months" ItemStyle-Width="140px">
     <ItemTemplate>
         <asp:Label ID="lblWarrentyMonths" runat="server" Text='<%#Eval("WarrentyMonths") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtWarrentyMonths" width="30px"  runat="server" Text='<%#Eval("WarrentyMonths") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>--%>

     <asp:TemplateField HeaderText="Vendor Name" ItemStyle-Width="100px">
     <ItemTemplate>
         <asp:Label ID="lblVendorName" runat="server" Text='<%#Eval("VendorName") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtVendorName" width="30px"  runat="server" Text='<%#Eval("VendorName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

     <asp:TemplateField HeaderText="Edit"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px">
            <ItemTemplate>             
              <a href='<%# "Asset.aspx?AssetId="+ Eval("AssetId")%>'>Edit</a>
            </ItemTemplate>
             <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Delete"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                 <asp:LinkButton ID="lkDelete" runat="server" Text="Delete" CommandArgument = '<%# Eval("AssetId")%>'  OnClientClick="return confirm('Are you sure you want to delete selected record ?')" OnClick="lkDelete_Click" />
            </ItemTemplate>           
             <HeaderStyle HorizontalAlign="Center" />
             <ItemStyle HorizontalAlign="Center" />
             <%-- <FooterTemplate>
            <a href="Asset.aspx" style="color:#000" >Add New Row</a>
    </FooterTemplate>--%>
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



 