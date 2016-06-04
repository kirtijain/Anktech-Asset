using AnkAsset.Core;
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace AnkAsset.Web
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogIn(object sender, EventArgs e)
        {
            UserInfo objUserInfo = new UserInfo();
            objUserInfo.userName = UserName.Text;
            objUserInfo.password = Password.Text;
            DataTable dt = UserInfoProvider.LoginData(objUserInfo);

            if (dt.Rows.Count > 0)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                  1,                                     // ticket version
                  objUserInfo.userName,                              // authenticated username
                  DateTime.Now,                          // issueDate
                  DateTime.Now.AddMinutes(30),           // expiryDate
                  true,                          // true to persist across browser sessions
                  dt.Rows[0]["UserId"].ToString(),                              // can be used to store additional user data
                  FormsAuthentication.FormsCookiePath);  // the path for the cookie

                // Encrypt the ticket using the machine key
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                // Add the cookie to the request to save it
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                Session["IsLogin"]=true;
                // Your redirect logic
                Response.Redirect("ViewAsset.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }
            ////    if (IsValid)
            ////    {
            ////        // Validate the user password
            ////        var manager = new UserManager();
            ////        ApplicationUser user = manager.Find(UserName.Text, Password.Text);
            ////        if (user != null)
            ////        {
            ////            IdentityHelper.SignIn(manager, user, RememberMe.Checked);
            ////            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            ////        }
            ////        else
            ////        {
            ////            FailureText.Text = "Invalid username or password.";
            ////            ErrorMessage.Visible = true;
            ////        }
            ////    }
        }

        protected void ForgotPwd(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");

        }
    }
}