﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllotment.aspx.cs" Inherits="AnkAsset.Web.ViewAllotment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3 class="section-title text-center">Asset Allotment List</h3>
    <a href="AssetAllotment.aspx"  class="section-title text-center">Asset Allotment</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="Label1" runat="server" Text="AllotTo Item Model No" style="color:#2bb3dd"></asp:Label>
&nbsp;
      <asp:TextBox ID="txtmodel" runat="server" Width="120"></asp:TextBox>&nbsp;&nbsp
      <asp:Button ID="Button1" runat="server" Text="Search" OnClick="ViewAssetAllotment_Click" CssClass="btn btn-primary btn-submit"/>
 <div class="form-group">
    <asp:GridView ID="gridView" DataKeyNames="AssetAllotmentId" runat="server" 
        AutoGenerateColumns="false" ShowFooter="true" AllowPaging="True" HeaderStyle-Font-Bold="true" PageSize="8" OnPageIndexChanging="gridView_PageIndexChanging"
         CellPadding="4" ForeColor="#333333" GridLines="None">          
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" /> 
<Columns>
  <%--  <asp:TemplateField HeaderText="Employee Id" ItemStyle-Width="100px">
      <ItemTemplate>
         <asp:Label ID="lblEmployeeId" runat="server" Text='<%#Eval("EmpId") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtEmployeeId" width="30px"  runat="server" Text='<%#Eval("EmpId") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>
<asp:TemplateField HeaderText="Employee Name" ItemStyle-Width="100px">
      <ItemTemplate>
         <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtEmployeeName" width="30px"  runat="server" Text='<%#Eval("EmployeeName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>--%>
 <asp:TemplateField HeaderText="Allot To Item Name" ItemStyle-Width="100px">
      <ItemTemplate>
         <asp:Label ID="lblAssetName" runat="server" Text='<%#Eval("PartName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtAssetName" width="30px"  runat="server" Text='<%#Eval("PartName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

     <asp:TemplateField HeaderText="Allot To Item Model No" ItemStyle-Width="150px">
     <ItemTemplate>
         <asp:Label ID="lblModelNo" runat="server" Text='<%#Eval("AllotToModelNo") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtModelNo" width="30px"  runat="server" Text='<%#Eval("AllotToModelNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

      <asp:TemplateField HeaderText="Allot To Item Serial No" ItemStyle-Width="150px">
     <ItemTemplate>
         <asp:Label ID="lblSerialNo" runat="server" Text='<%#Eval("AllotToSerialNo") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtSerialNo" width="30px"  runat="server" Text='<%#Eval("AllotToSerialNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

    <asp:TemplateField HeaderText="Alloted Item Name" ItemStyle-Width="140px">
       <ItemTemplate>
         <asp:Label ID="lblAllotedItemName" runat="server" Text='<%#Eval("AllotedItemName") %>'/>
     </ItemTemplate>
     <EditItemTemplate>
         <asp:TextBox ID="txtAllotedItemName" width="30px"   runat="server" Text='<%#Eval("AllotedItemName") %>'/>
     </EditItemTemplate>
 </asp:TemplateField> 

     <asp:TemplateField HeaderText="Alloted Item Model No" ItemStyle-Width="140px">
     <ItemTemplate>
         <asp:Label ID="lblAllotedItemModelNo" runat="server" Text='<%#Eval("AllotedItemModelNo") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtAllotedItemModelNo" width="30px"  runat="server" Text='<%#Eval("AllotedItemModelNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField> 
    <asp:TemplateField HeaderText="Alloted Item Serial No" ItemStyle-Width="140px">
     <ItemTemplate>
         <asp:Label ID="lblPartModelNo" runat="server" Text='<%#Eval("AllotedItemSerialNo") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtPartModelNo" width="30px"  runat="server" Text='<%#Eval("AllotedItemSerialNo") %>'/>
     </EditItemTemplate>
 </asp:TemplateField> 

    <asp:TemplateField HeaderText="Allotment Date" ItemStyle-Width="150px">
     <ItemTemplate>
         <asp:Label ID="lblAllotmentDate" runat="server" Text='<%#Eval("AllotmentDate") %>'/>
     </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txtAllotmentDate" width="30px"  runat="server" Text='<%#Eval("AllotmentDate") %>'/>
     </EditItemTemplate>
 </asp:TemplateField>

 <asp:TemplateField HeaderText="Edit"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30px"> 
            <ItemTemplate>             
              <a href='<%# "AssetAllotment.aspx?AssetAllotmentId="+ Eval("AssetAllotmentId")%>'>Edit</a>
            </ItemTemplate>
             <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Delete"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
            <ItemTemplate>
                 <asp:LinkButton ID="lkDelete" runat="server" Text="Delete" CommandArgument = '<%# Eval("AssetAllotmentId")%>'  OnClientClick="return confirm('Are you sure you want to delete selected record ?')" OnClick="lkDelete_Click" />
            </ItemTemplate>           
             <HeaderStyle HorizontalAlign="Center" />
             <ItemStyle HorizontalAlign="Center" />
             <%-- <FooterTemplate>
            <a href="AssetAllotment.aspx" style="color:#000" >Add New Row</a>
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

