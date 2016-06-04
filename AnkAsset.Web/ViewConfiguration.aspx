<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewConfiguration.aspx.cs" Inherits="AnkAsset.Web.ViewConfiguration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3 class="section-title text-center">Configuration Detail</h3>
     <a href="AssetConfiguration.aspx" class="section-title text-center">Add New Configuration</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="Label1" runat="server" Text="Serial No" style="color:#2bb3dd"></asp:Label>
&nbsp;
      <asp:TextBox ID="txtmodel" runat="server" Width="120"></asp:TextBox>&nbsp;&nbsp
      <asp:Button ID="Button1" runat="server" Text="Search" OnClick="ViewAssetConfiguration_Click" CssClass="btn btn-primary btn-submit"/>
    <div class="form-group">
    <asp:GridView ID="gridView" DataKeyNames="AssetConfigurationId" runat="server"
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
 
  <asp:TemplateField HeaderText="RAM Size"  ItemStyle-Width="140px">
       <ItemTemplate>
         <asp:Label ID="lblRAMSize" runat="server" Text='<%#Eval("RAMSize") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtRAMSize" width="30px"   runat="server" Text='<%#Eval("RAMSize") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="HardDisk Size" ItemStyle-Width="120px">
     <ItemTemplate>
         <asp:Label ID="lblHardDiskSize" runat="server" Text='<%#Eval("HardDiskSize") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtHardDiskSize" width="30px"  runat="server" Text='<%#Eval("HardDiskSize") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Processor" ItemStyle-Width="140px">
     <ItemTemplate>
         <asp:Label ID="lblProcessor" runat="server" Text='<%#Eval("Processor") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtProcessor" width="30px"  runat="server" Text='<%#Eval("Processor") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
     <asp:TemplateField HeaderText="OS Type"  ItemStyle-Width="160px">
       <ItemTemplate>
         <asp:Label ID="lblOSType" runat="server" Text='<%#Eval("OSType") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtOSType" width="30px"   runat="server" Text='<%#Eval("OSType") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
    <asp:TemplateField HeaderText="Company" ItemStyle-Width="150px">
     <ItemTemplate>
         <asp:Label ID="lblCompany" runat="server" Text='<%#Eval("Company") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtCompany" width="30px"  runat="server" Text='<%#Eval("Company") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

     <asp:TemplateField HeaderText="Edit"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px">
            <ItemTemplate>             
              <a href='<%# "AssetConfiguration.aspx?AssetConfigurationId="+ Eval("AssetConfigurationId")%>'>Edit</a>
                 
            </ItemTemplate>
             <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
      <asp:TemplateField HeaderText="Delete"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>            
              
               <asp:LinkButton ID="Delete" runat="server" Text="Delete" CommandArgument = '<%# Eval("AssetConfigurationId")%>'  OnClientClick="return confirm('Are you sure you want to Delete selected record ?')" OnClick="lkDelete_Click" />
                   
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
