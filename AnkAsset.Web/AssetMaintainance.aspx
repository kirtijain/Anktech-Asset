<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssetMaintainance.aspx.cs" Inherits="AnkAsset.Web.AssetMaintainance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
          <h3 class="section-title text-center">Asset Maintenance</h3>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
        
    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
              <br />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
         </div>
        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="ddlAssetTypeName"  CssClass="col-md-2 control-label">Asset Type</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlAssetTypeName" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlAssetTypeName_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAssetTypeName"
                    CssClass="text-danger" ErrorMessage="The Asset type is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" id="Label1" AssociatedControlID="ddlBillNo"  CssClass="col-md-2 control-label">Bill No</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlBillNo" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlBillNo_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlBillNo"
                    CssClass="text-danger" ErrorMessage="The Bill No is required." />
            </div>
        </div>

       <div class="form-group">
            <asp:Label runat="server" id="lblModelNo" AssociatedControlID="ddlModelNo"  CssClass="col-md-2 control-label">Model No</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlModelNo" CssClass="form-control"   Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlModelNo_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlModelNo"
                    CssClass="text-danger" ErrorMessage="The Model No is required." />
            </div>
        </div>
               <div class="form-group">
            <asp:Label runat="server" id="lblSerialNo" AssociatedControlID="ddlSerialNo"  CssClass="col-md-2 control-label">Serial No</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlSerialNo" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlSerialNo_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlSerialNo"
                    CssClass="text-danger" ErrorMessage="The Serial No is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="ddlPartName"  CssClass="col-md-2 control-label">Asset Part Name</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlPartName" CssClass="form-control"  Width="280" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPartName" CssClass="text-danger" ErrorMessage="The Part is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlVendorName" CssClass="col-md-2 control-label">Vendor Name</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlVendorName" CssClass="form-control"  Width="280"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlVendorName"
                    CssClass="text-danger" ErrorMessage="The vendor Name is required." />
               
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlLookupCallStatus" CssClass="col-md-2 control-label">Status</asp:Label>
            <div class="col-md-10">
               <asp:dropdownlist runat="server" ID="ddlLookupCallStatus" CssClass="form-control"  Width="280"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlLookupCallStatus"
                    CssClass="text-danger" ErrorMessage="The status field is required." />
            </div>
        </div>
     
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtIssueDescription" CssClass="col-md-2 control-label">Issue Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtIssueDescription" CssClass="form-control" Height="80"/>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="txtIssueDescription"
                    CssClass="text-danger" ErrorMessage="The issue description is required." />
                
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="txtCallDate"  CssClass="col-md-2 control-label">Call Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCallDate" CssClass="form-control" />
                <cc1:CalendarExtender ID="CalendarExtender1"  runat="server" TargetControlID="txtCallDate" Enabled="true" Format="dd/MM/yyyy"/>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCallDate"
                    CssClass="text-danger" ErrorMessage="The call date is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="txtServiceDate"  CssClass="col-md-2 control-label">Service Date</asp:Label>
            <div class="col-md-10">
              
                <asp:TextBox runat="server" ID="txtServiceDate" CssClass="form-control" />
                
                <cc1:CalendarExtender ID="CalendarExtender2"  runat="server" TargetControlID="txtServiceDate" Enabled="true" Format="dd/MM/yyyy"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtServiceDate"
                    CssClass="text-danger" ErrorMessage="The service date is required." />
            </div>
        </div>
          <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtMaintenanceCost" CssClass="col-md-2 control-label">Maintenance Cost</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtMaintenanceCost" MaxLength="10"  CssClass="form-control" />
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMaintenanceCost"
                    CssClass="text-danger" ErrorMessage="The cost is required." />
                 </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
           
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="144px" OnClick="CreateAssetMaintainance_Click" CssClass="btn btn-primary btn-submit"/>
            </div>
        </div>
   </div>
        
</asp:Content>
<%-- <script type="text/javascript">
     $(function () {
         $("#datepicker").datepicker();
     });
  </script>--%>