<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AnkAsset.Web.Account.ChangePassword" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <h3 class="section-title text-center">Change Your Password</h3>
    
    <div class="form-horizontal">
    <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCurrentPassword" CssClass="col-md-2 control-label"> Current Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCurrentPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCurrentPassword"
                    CssClass="text-danger" ErrorMessage="The Password field is required." />
                
            </div>
        <asp:Label runat="server" AssociatedControlID="txtNewPassword" CssClass="col-md-2 control-label">New Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNewPassword"
                    CssClass="text-danger" ErrorMessage="The New Password is required." />
                
            </div>
        <asp:Label runat="server" AssociatedControlID="txtConfirmNewPassword" CssClass="col-md-2 control-label">Confirm New Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtConfirmNewPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmNewPassword"
                    CssClass="text-danger" ErrorMessage="The confirm Password is required." />
                
            </div>
         <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="ChangePassword_Click" Text="Save" CssClass="btn btn-primary btn-submit" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblMessage" CssClass="col-md-2 control-label"></asp:Label>
            </div>
</div>
        </div>
</asp:Content>
