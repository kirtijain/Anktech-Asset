<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeAllotment.aspx.cs" Inherits="AnkAsset.Web.EmployeeAllotment" %>

    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
          <h3 class="section-title text-center">Employee Allotment</h3>
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
               <%-- <asp:DropDownList runat="server" ID="ddlAssetName" CssClass="form-control" Width="280" />--%>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmployeeName" CssClass="text-danger" ErrorMessage="The Employee Name is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server"  AssociatedControlID="ddlAssetTypeName"  CssClass="col-md-2 control-label">Asset Type</asp:Label>
            <div class="col-md-10">
                <asp:dropdownlist runat="server" ID="ddlAssetTypeName" CssClass="form-control"  Width="280" AutoPostBack="true" OnSelectedIndexChanged="ddlAssetTypeName_SelectedIndexChanged"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAssetTypeName"
                    CssClass="text-danger" ErrorMessage="The Asset Name is required." />
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
            <div class="col-md-10">
           
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="144px" OnClick="CreateEmployeeAllotment_Click" CssClass="btn btn-primary btn-submit"/>
            </div>
        </div>
   </div>
        
</asp:Content>