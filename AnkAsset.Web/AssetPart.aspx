<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssetPart.aspx.cs" Inherits="AnkAsset.Web.AssetPart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3 class="section-title text-center">Add Asset Parts</h3>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlAssetTypeName" CssClass="col-md-2 control-label">Asset Type</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlAssetTypeName" CssClass="form-control" Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlAssetTypeName_onSelectIndexChanged" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAssetTypeName" CssClass="text-danger" ErrorMessage="The Asset Type is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="lblBillNo" AssociatedControlID="ddlBillNo" CssClass="col-md-2 control-label">Bill No</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlBillNo" CssClass="form-control" Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlBillNo_SelectedIndexChanged" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlBillNo"
                    CssClass="text-danger" ErrorMessage="The Bill No is required." />
            </div>
        </div>
      
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAssetName" CssClass="col-md-2 control-label">Asset Name</asp:Label>
            <div class="col-md-10">
                <asp:HiddenField ID="hidAssetId" runat="server" />
                 <asp:TextBox runat="server" ID="txtAssetName" CssClass="form-control"  Enabled="false"/>
               <%-- <asp:DropDownList runat="server" ID="ddlAssetName" CssClass="form-control" Width="280" />--%>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAssetName" CssClass="text-danger" ErrorMessage="The Asset Name is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPartName" CssClass="col-md-2 control-label">Part Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPartName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPartName"
                    CssClass="text-danger" ErrorMessage="The Part Name is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPartSerialNo" CssClass="col-md-2 control-label">Part Serial No</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPartSerialNo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPartSerialNo"
                    CssClass="text-danger" ErrorMessage="The part serial no is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPartModelNo" CssClass="col-md-2 control-label">Part Model No</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPartModelNo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPartModelNo"
                    CssClass="text-danger" ErrorMessage="The Part Model No field is required." />

            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCompany" CssClass="col-md-2 control-label">Company Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCompany" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCompany"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The asset company is required." />

            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPartPrice" CssClass="col-md-2 control-label">Part Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPartPrice" MaxLength="10" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPartPrice"
                    CssClass="text-danger" ErrorMessage="The Part price is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPartDescription" CssClass="col-md-2 control-label">Part Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPartDescription" CssClass="form-control" />

            </div>
        </div>


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPartPurchaseDate" CssClass="col-md-2 control-label">Purchase Date</asp:Label>

            <div class="col-md-10">

                <asp:TextBox runat="server" ID="txtPartPurchaseDate" CssClass="form-control" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPartPurchaseDate" Enabled="true" Format="dd/MM/yyyy" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPartPurchaseDate"
                    CssClass="text-danger" ErrorMessage="The purchase date is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtWarrentyMonths" CssClass="col-md-2 control-label">Warrenty Months</asp:Label>
            <div class="col-md-10">

                <asp:TextBox runat="server" ID="txtWarrentyMonths" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtWarrentyMonths"
                    CssClass="text-danger" ErrorMessage="The warrenty months are required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtWarrentyDate" CssClass="col-md-2 control-label">Warrenty Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtWarrentyDate" CssClass="form-control" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtWarrentyDate" Enabled="true" Format="dd/MM/yyyy" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtWarrentyDate"
                    CssClass="text-danger" ErrorMessage="The warrenty date is required." />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-10">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="144px" OnClick="CreateAssetPart_Click" CssClass="btn btn-primary btn-submit" />
            </div>
        </div>
    </div>

</asp:Content>
