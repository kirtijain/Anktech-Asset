<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewFaulty.aspx.cs" Inherits="AnkAsset.Web.ViewFaulty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3 class="section-title text-center">Asset Faulty Parts</h3>

      <%--<a href="AssetSpare.aspx" class="section-title text-center">Add Spare Parts</a>--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
     &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="Label1" runat="server" Text="Model No" style="color:#2bb3dd"></asp:Label>
&nbsp;
      <asp:TextBox ID="txtmodel" runat="server" Width="120"></asp:TextBox>&nbsp;&nbsp
      <asp:Button ID="Button1" runat="server" Text="Search" OnClick="ViewAssetFaulty_Click" CssClass="btn btn-primary btn-submit"/>
     <div class="form-group">
    <asp:GridView ID="gridView" DataKeyNames="AssetPartId" runat="server" 
        AutoGenerateColumns="false" ShowFooter="true" AllowPaging="True" HeaderStyle-Font-Bold="true" PageSize="8" OnPageIndexChanging="gridView_PageIndexChanging"
         CellPadding="4" ForeColor="#333333" GridLines="None">          
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>
 <asp:TemplateField HeaderText="Asset Type" ItemStyle-Width="70px">
      <ItemTemplate>
         <asp:Label ID="lblAssetTypeName" runat="server" Text='<%#Eval("AssetTypeName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtAssetTypeName" width="30px"  runat="server" Text='<%#Eval("AssetTypeName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
    <asp:TemplateField HeaderText="Bill No" ItemStyle-Width="100px">
     <ItemTemplate>
         <asp:Label ID="lblModelNo" runat="server" Text='<%#Eval("BillNo") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtModelNo" width="30px"  runat="server" Text='<%#Eval("BillNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
    
  <asp:TemplateField HeaderText=" Part Name" ItemStyle-Width="140px">
       <ItemTemplate>
         <asp:Label ID="lblPartName" runat="server" Text='<%#Eval("PartName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtPartName" width="30px"   runat="server" Text='<%#Eval("PartName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
     <asp:TemplateField HeaderText="Serial No" ItemStyle-Width="160px">
     <ItemTemplate>
         <asp:Label ID="lblPartSerialNo" runat="server" Text='<%#Eval("PartSerialNo") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtPartSerialNo" width="30px"  runat="server" Text='<%#Eval("PartSerialNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

      <asp:TemplateField HeaderText="Model No" ItemStyle-Width="156px">
     <ItemTemplate>
         <asp:Label ID="lblPartModelNo" runat="server" Text='<%#Eval("PartModelNo") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtPartModelNo" width="30px"  runat="server" Text='<%#Eval("PartModelNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
<asp:TemplateField HeaderText="Company" ItemStyle-Width="120px">
     <ItemTemplate>
         <asp:Label ID="lblCompany" runat="server" Text='<%#Eval("Company") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtCompany" width="30px"  runat="server" Text='<%#Eval("Company") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
   <asp:TemplateField HeaderText="Part Price" ItemStyle-Width="130px">
     <ItemTemplate>
         <asp:Label ID="lblPartPrice" runat="server" Text='<%#Eval("PartPrice") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtPartPrice" width="30px"  runat="server" Text='<%#Eval("PartPrice") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

   <%-- <asp:TemplateField HeaderText="Description" ItemStyle-Width="150px">
     <ItemTemplate>
         <asp:Label ID="lblPartDescription" runat="server" Text='<%#Eval("PartDescription") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtPartDescription" width="30px"  runat="server" Text='<%#Eval("PartDescription") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>--%>

   
    <asp:TemplateField HeaderText="Purchase Date" ItemStyle-Width="180px">
     <ItemTemplate>
         <asp:Label ID="lblPartPurchaseDate" runat="server" Text='<%#Eval("PartPurchaseDate") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtPartPurchaseDate" width="30px"  runat="server" Text='<%#Eval("PartPurchaseDate") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

  <asp:TemplateField HeaderText="Warrenty Months" ItemStyle-Width="130px">
     <ItemTemplate>
         <asp:Label ID="lblWarrentyMonths" runat="server" Text='<%#Eval("WarrentyMonths") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtWarrentyMonths" width="30px"  runat="server" Text='<%#Eval("WarrentyMonths") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <%--  <asp:TemplateField HeaderText="Edit"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="40px">
            <ItemTemplate>             
              <a href='<%# "AssetSpare.aspx?AssetSpareId="+ Eval("AssetSpareId")%>'>Edit</a>
            </ItemTemplate>
             <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Delete"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                 <asp:LinkButton ID="lkDelete" runat="server" Text="Delete" CommandArgument = '<%# Eval("AssetSpareId")%>'  OnClientClick="return confirm('Are you sure you want to delete selected record ?')" OnClick="lkDelete_Click" />
            </ItemTemplate>           
             <HeaderStyle HorizontalAlign="Center" />
             <ItemStyle HorizontalAlign="Center" />
  </asp:TemplateField>   --%>
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