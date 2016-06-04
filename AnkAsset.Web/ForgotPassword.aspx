<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="AnkAsset.Web.ForgotPassword" %>
<html>
<head>
	<title>Asset Management</title>
	<link rel="stylesheet" href="Content/css/bootstrap.css">
	<link rel="stylesheet" type="text/css" href="Content/css/style.css">
	<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700' rel='stylesheet' type='text/css'>
</head>
<body>
	<div class="container">
		<div class="row">
			<div class="col-sm-6 col-sm-offset-3">
				<div class="login-form">
		            <div class="row">
		            	<div class="col-md-12">
		            		<h1 class="page-title">AnkTech Asset Management System</h1>
		            	</div>
		                <div class="col-sm-9 col-sm-offset-3">
		                    <h3 class="section-title">Forgot Password</h3>
		                </div>
		            </div>
		            <form class="form-horizontal" runat="server">
		                <div class="form-group">
		                    <div class="col-sm-3">
		                        <label for="email">Enter Email <span class="error">*</span></label>
		                    </div>
		                    <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtEmailId" CssClass="form-control"/>
                                 <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailId"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId" ErrorMessage="Please write correct email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
		                        <%--<input type="text" placeholder="Username" name="loginUsername" id="username" class="form-control">--%>
		                    </div>
		                </div>
		               <div class="form-group">
		                    <div class="col-sm-9 col-sm-offset-3">
                                  <asp:Button runat="server" OnClick="ForgotPassword_Click" Text="Submit" CssClass="btn btn-primary btn-submit" />
		                   </div>
		                </div>
                         <div class="form-group">
                                  <asp:Label runat="server" ID="lblMessage" CssClass="col-md-2 control-label"></asp:Label>
                        </div>
		               
		            </form>
		        </div>
			</div>
		</div>
	</div>
</body>
</html>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>--%>
</html>
