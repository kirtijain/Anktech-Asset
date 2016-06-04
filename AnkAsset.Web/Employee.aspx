<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="AnkAsset.Web.Employee" %>

    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3 class="section-title text-center">Add Employee</h3>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>


    <div class="form-horizontal">

        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmpId" CssClass="col-md-2 control-label">Employee Id</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmpId" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmpId"
                    CssClass="text-danger" ErrorMessage="The employee id field is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmployeeName" CssClass="col-md-2 control-label">Employee Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmployeeName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmployeeName"
                    CssClass="text-danger" ErrorMessage="The Employee name field is required." />
            </div>
        </div>
            
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmailId" CssClass="col-md-2 control-label">Email Id</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmailId" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailId"
                    CssClass="text-danger" ErrorMessage="The email id field is required." />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId" ErrorMessage="Please write correct email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
        </div>
       
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtContactNo" CssClass="col-md-2 control-label">Contact No</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactNo" MaxLength="10" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtContactNo"
                    CssClass="text-danger" ErrorMessage="The contact no is required." />
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Please write correct phone no address" ValidationExpression="[1-9][0-9]{9}$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-2 control-label">Address</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" />
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress"
                    CssClass="text-danger" ErrorMessage="The address is required." />--%>
            </div>
        </div>
         <div class="form-group">
            <div class="col-md-10">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="144px" OnClick="CreateEmployee_Click" CssClass="btn btn-primary btn-submit" />
            </div>
        </div>
 </div>
</asp:Content>
