<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AnkAsset.Web.Register" %>
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
		                    <h3 class="section-title">Create New Account</h3>
		                </div>
		            </div>
		            <form class="form-horizontal" runat="server">
		                <div class="form-group">
		                    <div class="col-sm-3">
		                        <label for="name">Name <span class="error">*</span></label>
		                    </div>
		                    <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName"
                                          CssClass="text-danger" ErrorMessage="The name field is required." />
		                    </div>
		                </div>

                         <div class="form-group">
		                    <div class="col-sm-3">
		                        <label for="username">Username <span class="error">*</span></label>
		                    </div>
		                    <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
		                       
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
                                 <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"  CssClass="form-control" />
                                 <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
   		                    </div>
		                </div>

                        <div class="form-group">
		                    <div class="col-sm-3">
		                        <label for="confirmpassword">
		                            Confirm Password
		                            <span class="error">*</span>
		                        </label>
		                    </div>
		                    <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password"  CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                 <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
   		                    </div>
		                </div>

                         <div class="form-group">
		                    <div class="col-sm-3">
		                        <label for="email">Email <span class="error">*</span></label>
		                    </div>
		                    <div class="col-sm-9">
                                 <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please write correct email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
		                       
		                    </div>
		                </div>

                         <div class="form-group">
		                    <div class="col-sm-3">
		                        <label for="contactno">Contact No <span class="error">*</span></label>
		                    </div>
		                    <div class="col-sm-9">
                                <asp:TextBox runat="server" ID="txtUserContact" MaxLength="10"  CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserContact"
                    CssClass="text-danger" ErrorMessage="The contact no field is required." />
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtUserContact" ErrorMessage="Please write correct phone no address" ValidationExpression="[1-9][0-9]{9}$"></asp:RegularExpressionValidator>
      
                             </div>
		                </div>

                         <div class="form-group">
		                    <div class="col-sm-3">
		                        <label for="address">Address <span class="error">*</span></label>
		                    </div>
		                    <div class="col-sm-9">
                                <asp:TextBox runat="server" ID="txtUserAddress" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserAddress"
                    CssClass="text-danger" ErrorMessage="The address field is required." />
		                       
		                    </div>
		                </div>

		               <div class="form-group">
		                    <div class="col-sm-9 col-sm-offset-3">
                                 <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-primary btn-submit" />
                               
                               
		                    </div>
		                </div>
		               
		            </form>
		        </div>
			</div>
		</div>
	</div>
</body>
</html>



