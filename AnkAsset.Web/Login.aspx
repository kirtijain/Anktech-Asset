<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AnkAsset.Web.Login1" %>
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
		                    <h3 class="section-title">Login</h3>
		                </div>
		            </div>
		            <form class="form-horizontal" runat="server">
		                <div class="form-group">
		                    <div class="col-sm-3">
		                        <label for="username">Username <span class="error">*</span></label>
		                    </div>
		                    <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="col-sm-9 col-sm-offset-3" ErrorMessage="The user name field is required." />
		                        <%--<input type="text" placeholder="Username" name="loginUsername" id="username" class="form-control">--%>
		                    </div>
		                </div>
		                <div class="form-group">
		                    <div class="col-sm-3">
		                        <label for="password">
		                            Password
		                            <span class="error">*</span>
		                        </label>
		                    </div>
		                    <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="Password" TextMode="Password"  CssClass="form-control" />
                                 <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                CssClass="col-sm-9 col-sm-offset-3" ErrorMessage="The Password field is required." />
                                 <br />
                                 <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-primary btn-submit" />
                                  &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                                <span class="btn btn-primary btn-submit"><a style="color: white;" href="ForgotPassword.aspx">Forgot Password</a> </span>
                                 <%--  <asp:Button runat="server" href="ForgotPassword.aspx" Text="Forgot Password" CssClass="btn btn-primary btn-submit" />--%>
		                    </div>
		                </div>
		               <%-- <div class="form-group">
		                    <div class="col-sm-9 col-sm-offset-3">
                                 <asp:Button runat="server" OnClick="LogIn" Text="Log in" class="btn btn-primary btn-submit" />
		                       <%-- <button class="btn btn-primary btn-submit" type="submit">Login</button>--%>
		                    <%--</div>
		                </div>--%>
		                <div class="form-group">
		                	<div class="col-sm-9 col-sm-offset-3">
		                		<span>Not a member <a href="Register.aspx">Click here</a> to sign up </span>
		                	</div>
		                </div>
		            </form>
		        </div>
			</div>
		</div>
	</div>
</body>
</html>
