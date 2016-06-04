<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asset.aspx.cs" Inherits="AnkAsset.Web.Asset" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3 class="section-title text-center">Add Asset</h3>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>


    <div class="form-horizontal">

        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlAssetTypeName" CssClass="col-md-2 control-label">Asset Type</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlAssetTypeName" CssClass="form-control" Width="280" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAssetTypeName" CssClass="text-danger" ErrorMessage="The Asset Type is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAssetName" CssClass="col-md-2 control-label">Asset Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAssetName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAssetName"
                    CssClass="text-danger" ErrorMessage="The asset name field is required." />
            </div>
        </div>
       
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtBillNo" CssClass="col-md-2 control-label">Bill No</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBillNo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBillNo"
                    CssClass="text-danger" ErrorMessage="The Bill No field is required." />

            </div>
        </div>
       
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAssetPrice" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAssetPrice" MaxLength="10" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAssetPrice"
                    CssClass="text-danger" ErrorMessage="The asset price is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAssetDescription" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAssetDescription" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAssetDescription"
                    CssClass="text-danger" ErrorMessage="The asset description is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtQuantity" CssClass="col-md-2 control-label">Quantity</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtQuantity"
                    CssClass="text-danger" ErrorMessage="The quantity is required." />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Please write correct Quantity" ValidationExpression="[1-9]+$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPurchaseDate" CssClass="col-md-2 control-label">Purchase Date</asp:Label>

            <div class="col-md-10">

                <asp:TextBox runat="server" ID="txtPurchaseDate" CssClass="form-control" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPurchaseDate" Enabled="true" Format="dd/MM/yyyy" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPurchaseDate"
                    CssClass="text-danger" ErrorMessage="The purchase date is required." />
            </div>
        </div>
       
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlVendorName" CssClass="col-md-2 control-label">Vendor Name</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlVendorName" CssClass="form-control" Width="280" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlVendorName"
                    CssClass="text-danger" ErrorMessage="The Vendor Name is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="144px" OnClick="CreateAsset_Click" CssClass="btn btn-primary btn-submit" />
            </div>
        </div>
    </div>
</asp:Content>
<%-- <script type="text/javascript">
     $(function () {
         $("#datepicker").datepicker();
     });
  </script>--%>