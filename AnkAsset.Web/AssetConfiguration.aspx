<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssetConfiguration.aspx.cs" Inherits="AnkAsset.Web.AssetConfiguration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <h3 class="section-title text-center">Add Asset Configuration</h3>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <hr/>
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
            <asp:Label runat="server" AssociatedControlID="txtRAMSize" CssClass="col-md-2 control-label">RAM Size(In GB)</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtRAMSize" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRAMSize"
                    CssClass="text-danger" ErrorMessage="The RAM size is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtOSType" CssClass="col-md-2 control-label">OS Type</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtOSType" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOSType"
                    CssClass="text-danger" ErrorMessage="The OS type is required." />
            </div>
        </div>

               <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtHardDiskSize" CssClass="col-md-2 control-label">HardDisk Size(In GB)</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtHardDiskSize" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtHardDiskSize"
                    CssClass="text-danger" ErrorMessage="The Hard Disk Size field is required." />
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtProcessor" CssClass="col-md-2 control-label">Processor</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtProcessor" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtProcessor"
                    CssClass="text-danger" ErrorMessage="The Processor is required." />
            </div>
        </div>

            <div class="form-group">
            <div class="col-md-10">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="144px" OnClick="CreateAssetConfiguration_Click" CssClass="btn btn-primary btn-submit"/>
            </div>
        </div>
   </div>
</asp:Content>
