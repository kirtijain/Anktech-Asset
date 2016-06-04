<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssetSpare.aspx.cs" Inherits="AnkAsset.Web.AssetSpare" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3 class="section-title text-center">Add Spare Part</h3>
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
            <asp:Label runat="server"  AssociatedControlID="ddlPartName"  CssClass="col-md-2 control-label">Spare Part Name</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlPartName" CssClass="form-control"  Width="280" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPartName" CssClass="text-danger" ErrorMessage="The Part is required." />
            </div>
        </div>
       <%-- <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCompany" CssClass="col-md-2 control-label">Company Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCompany" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCompany"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The asset company is required." />

            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPartPrice" CssClass="col-md-2 control-label">Spare Part Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPartPrice" MaxLength="10" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPartPrice"
                    CssClass="text-danger" ErrorMessage="The Part price is required." />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPartPurchaseDate" CssClass="col-md-2 control-label">Spare Part Purchase Date</asp:Label>

            <div class="col-md-10">

                <asp:TextBox runat="server" ID="txtPartPurchaseDate" CssClass="form-control" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPartPurchaseDate" Enabled="true" Format="dd/MM/yyyy" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPartPurchaseDate"
                    CssClass="text-danger" ErrorMessage="The purchase date is required." />
            </div>
        </div>--%>
      <%--   <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtWarrentyMonths" CssClass="col-md-2 control-label">Warrenty Months</asp:Label>
            <div class="col-md-10">

                <asp:TextBox runat="server" ID="txtWarrentyMonths" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtWarrentyMonths"
                    CssClass="text-danger" ErrorMessage="The warrenty months are required." />
            </div>
        </div>--%>
       <%-- <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtWarrentyDate" CssClass="col-md-2 control-label">Spare Part Warrenty Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtWarrentyDate" CssClass="form-control" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtWarrentyDate" Enabled="true" Format="dd/MM/yyyy" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtWarrentyDate"
                    CssClass="text-danger" ErrorMessage="The warrenty date is required." />
            </div>
        </div>--%>

        <div class="form-group">
            <div class="col-md-10">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="144px" OnClick="CreateAssetSpare_Click" CssClass="btn btn-primary btn-submit" />
            </div>
        </div>
    </div>

</asp:Content>
