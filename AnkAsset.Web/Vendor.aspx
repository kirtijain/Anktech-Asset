<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendor.aspx.cs" Inherits="AnkAsset.Web.Vendor" %>

    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     <h3 class="section-title text-center">Add Vendor</h3>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
       
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtVendorName" CssClass="col-md-2 control-label">Vendor Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtVendorName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtVendorName"
                    CssClass="text-danger" ErrorMessage="The Vendor name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPersonName" CssClass="col-md-2 control-label">Person Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPersonName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPersonName"
                    CssClass="text-danger" ErrorMessage="The Person name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtContactNo" CssClass="col-md-2 control-label">Contact No</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control" MaxLength="10" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtContactNo"
                    CssClass="text-danger" ErrorMessage="The contact no is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAlternateNumber" CssClass="col-md-2 control-label">Alternate No</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAlternateNumber" CssClass="form-control" MaxLength="10" />
                
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtServiceCenterAddress" CssClass="col-md-2 control-label">Service Center Address</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtServiceCenterAddress"  CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtServiceCenterAddress"
                    CssClass="text-danger" ErrorMessage="The Service center address is required." />
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-10">
           
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="144px" OnClick="CreateVendor_Click" CssClass="btn btn-primary btn-submit"/>
            </div>
      </div>
    </div>
</asp:Content>
