<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMaintenance.aspx.cs" Inherits="AnkAsset.Web.ViewMaintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3 class="section-title text-center">Maintenance Detail</h3>
     <a href="AssetMaintainance.aspx" class="section-title text-center">Add New Maintenance Info</a>
    <div class="form-group">
        <asp:DropDownList id="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_onSelectIndexChanged"/>
    
    <asp:GridView ID="gridView" DataKeyNames="AssetMaintainanceId" runat="server"
        AutoGenerateColumns="false" ShowFooter="true" AllowPaging="True" HeaderStyle-Font-Bold="true" PageSize="9" OnPageIndexChanging="gridView_PageIndexChanging"
         CellPadding="4" ForeColor="#333333" GridLines="None">          
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
        
<Columns>
    <asp:TemplateField HeaderText="Asset Type" ItemStyle-Width="90px">
      <ItemTemplate>
         <asp:Label ID="lblAssetTypeName" runat="server" Text='<%#Eval("AssetTypeName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtAssetTypeName" width="30px"  runat="server" Text='<%#Eval("AssetTypeName") %>'/>
     </EditItemTemplate>
    
 </asp:TemplateField>
 <asp:TemplateField HeaderText="Asset Part Name"  ItemStyle-Width="140px">
      <ItemTemplate>
         <asp:Label ID="lblAssetPartName" runat="server" Text='<%#Eval("PartName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtAssetPartName" width="30px"  runat="server" Text='<%#Eval("PartName") %>'/>
     </EditItemTemplate>
    
 </asp:TemplateField>
    
 <asp:TemplateField HeaderText="Model No"  ItemStyle-Width="70px">
      <ItemTemplate>
         <asp:Label ID="lblModelNo" runat="server" Text='<%#Eval("PartModelNo") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtModelNo" width="30px"  runat="server" Text='<%#Eval("PartModelNo") %>'/>
     </EditItemTemplate>
    
 </asp:TemplateField>
    <asp:TemplateField HeaderText="Serial No" ItemStyle-Width="70px">
     <ItemTemplate>
         <asp:Label ID="lblSerialNo" runat="server" Text='<%#Eval("PartSerialNo") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtSerialNo" width="30px"  runat="server" Text='<%#Eval("PartSerialNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
 <asp:TemplateField HeaderText="Status" ItemStyle-Width="80px">
     <ItemTemplate>
         <asp:Label ID="lblStatusName" runat="server" Text='<%#Eval("StatusName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtStatusName" width="30px"  runat="server" Text='<%#Eval("StatusName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

  <asp:TemplateField HeaderText="Call Date"  ItemStyle-Width="140px">
       <ItemTemplate>
         <asp:Label ID="lblCallDate" runat="server" Text='<%#Eval("CallDate") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtCallDate" width="30px"   runat="server" Text='<%#Eval("CallDate") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Maintenance Cost" ItemStyle-Width="120px">
     <ItemTemplate>
         <asp:Label ID="lblMaintenanceCost" runat="server" Text='<%#Eval("MaintenanceCost") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtMaintenanceCost" width="30px"  runat="server" Text='<%#Eval("MaintenanceCost") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Issue Description" ItemStyle-Width="170px">
     <ItemTemplate>
         <asp:Label ID="lblIssueDescription" runat="server" Text='<%#Eval("IssueDescription") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtIssueDescription" width="30px"  runat="server" Text='<%#Eval("IssueDescription") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Service Date" ItemStyle-Width="150px">
     <ItemTemplate>
         <asp:Label ID="lblServiceDate" runat="server" Text='<%#Eval("ServiceDate") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtServiceDate" width="30px"  runat="server" Text='<%#Eval("ServiceDate") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

     <asp:TemplateField HeaderText="Vendor Name" ItemStyle-Width="100px">
     <ItemTemplate>
         <asp:Label ID="lblVendorName" runat="server" Text='<%#Eval("VendorName") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtVendorName" width="30px"  runat="server" Text='<%#Eval("VendorName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
            
     <asp:TemplateField HeaderText="Edit"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
            <ItemTemplate>             
              <a href='<%# "AssetMaintainance.aspx?AssetMaintainanceId="+ Eval("AssetMaintainanceId")%>'>Edit</a>
                 
            </ItemTemplate>
             <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
         <%--<FooterTemplate>
            <a href="AssetMaintainance.aspx" style="color:#000">Add New Row</a>
    </FooterTemplate>--%>
         </asp:TemplateField>

             <asp:TemplateField HeaderText="Delete"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="150px">
            <ItemTemplate>
                 <asp:LinkButton ID="lkDelete" runat="server" Text="Delete" CommandArgument = '<%# Eval("AssetMaintainanceId")%>'  OnClientClick="return confirm('Are you sure you want to delete selected record ?')" OnClick="lkDelete_Click" />
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
