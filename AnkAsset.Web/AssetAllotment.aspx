<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssetAllotment.aspx.cs" Inherits="AnkAsset.Web.AssetAllotment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
          <h3 class="section-title text-center">Asset Allotment</h3>
          <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
           <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
            <%--   <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlEmpId" CssClass="col-md-2 control-label">Employee Id</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlEmpId" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlEmpId_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlEmpId"
                    CssClass="text-danger" ErrorMessage="The EmpId is required." />
               
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmployeeName" CssClass="col-md-2 control-label">Employee Name</asp:Label>
            <div class="col-md-10">
                <asp:HiddenField ID="hidId" runat="server" />
                 <asp:TextBox runat="server" ID="txtEmployeeName" CssClass="form-control" width="280" Enabled="false"/>

                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmployeeName" CssClass="text-danger" ErrorMessage="The Employee Name is required." />
            </div>
        </div>--%>
        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="ddlAssetTypeName"  CssClass="col-md-2 control-label">Allot To Asset Type</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlAssetTypeName" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlAssetTypeName_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAssetTypeName"
                    CssClass="text-danger" ErrorMessage="The Asset type is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" id="Label1" AssociatedControlID="ddlBillNo"  CssClass="col-md-2 control-label">Allot To Bill No</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlBillNo" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlBillNo_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlBillNo"
                    CssClass="text-danger" ErrorMessage="The Bill No is required." />
            </div>
        </div>

       <div class="form-group">
            <asp:Label runat="server" id="Label2" AssociatedControlID="ddlModelNo"  CssClass="col-md-2 control-label">Allot To Model No</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlModelNo" CssClass="form-control"   Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlModelNo_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlModelNo"
                    CssClass="text-danger" ErrorMessage="The Model No is required." />
            </div>
        </div>
               <div class="form-group">
            <asp:Label runat="server" id="Label3" AssociatedControlID="ddlSerialNo"  CssClass="col-md-2 control-label">Allot To Serial No</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlSerialNo" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlSerialNo_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlSerialNo"
                    CssClass="text-danger" ErrorMessage="The Serial No is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="ddlPartName"  CssClass="col-md-2 control-label">Allot To Asset Name</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlPartName" CssClass="form-control"  Width="280" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPartName" CssClass="text-danger" ErrorMessage="The Part is required." />
            </div>
        </div>
              
               <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="ddlAllotedAssetTypeName"  CssClass="col-md-2 control-label">Alloted Item Asset Type</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlAllotedAssetTypeName" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlAllotedAssetTypeName_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAllotedAssetTypeName"
                    CssClass="text-danger" ErrorMessage="The Asset type is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" id="Label4" AssociatedControlID="ddlAllotedItemBillNo"  CssClass="col-md-2 control-label">Alloted Item Bill No</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlAllotedItemBillNo" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlAllotedItemBillNo_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAllotedItemBillNo"
                    CssClass="text-danger" ErrorMessage="The Bill No is required." />
            </div>
        </div>

       <div class="form-group">
            <asp:Label runat="server" id="lblModelNo" AssociatedControlID="ddlAllotedItemModelNo"  CssClass="col-md-2 control-label">Alloted Item Model No</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlAllotedItemModelNo" CssClass="form-control"   Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlAllotedItemModelNo_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAllotedItemModelNo"
                    CssClass="text-danger" ErrorMessage="The Model No is required." />
            </div>
        </div>
               <div class="form-group">
            <asp:Label runat="server" id="lblSerialNo" AssociatedControlID="ddlAllotedItemSerialNo"  CssClass="col-md-2 control-label">Alloted Item Serial No</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlAllotedItemSerialNo" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlAllotedItemSerialNo_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAllotedItemSerialNo"
                    CssClass="text-danger" ErrorMessage="The Serial No is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="ddlAllotedItemName"  CssClass="col-md-2 control-label">Alloted Item Name</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlAllotedItemName" CssClass="form-control"  Width="280" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAllotedItemName" CssClass="text-danger" ErrorMessage="The item name is required." />
            </div>
        </div>


<%--        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtItemQuantity" CssClass="col-md-2 control-label">Item Quantity</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtItemQuantity" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtItemQuantity"
                    CssClass="text-danger" ErrorMessage="The Quantity is required." />
            </div>
        </div>--%>

        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="txtAllotmentDate"  CssClass="col-md-2 control-label">Allotment Date</asp:Label>
            
            <div class="col-md-10">
              
                <asp:TextBox runat="server" ID="txtAllotmentDate" CssClass="form-control" />
                <cc1:CalendarExtender ID="CalendarExtender1"  runat="server" TargetControlID="txtAllotmentDate" Enabled="true" Format="dd/MM/yyyy"/>
                   <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAllotmentDate"
                    CssClass="text-danger" ErrorMessage="The Allotment date is required." />
            </div>
        </div>
              
        <div class="form-group">
            <div class="col-md-10">
           
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="144px" OnClick="CreateAssetAllotment_Click" CssClass="btn btn-primary btn-submit" />
            </div>
        </div>
   </div>
</asp:Content>
