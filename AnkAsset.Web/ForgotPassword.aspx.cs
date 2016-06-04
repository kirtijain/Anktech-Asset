using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using System.Configuration;
using System.Text;
using System.Net;
using System.Net.Mail;
using AnkAsset.Core;
using AnkAsset.Data;
using System.Data;
namespace AnkAsset.Web
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ForgotPassword_Click(object sender, EventArgs e)
        {

            UserInfo objUserInfo = new UserInfo();
            objUserInfo.email = txtEmailId.Text;
            DataTable dt = UserInfoProvider.ForgotPassword(objUserInfo);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    string EmailFrom = ConfigurationManager.AppSettings["EmailFrom"];
                   
                    string to = objUserInfo.email;
                    MailMessage message = new MailMessage(EmailFrom, to);
                    //For testing replace the local host path with your lost host path and while making online replace with your website domain name
                    // ActivationUrl = Server.HtmlEncode(SiteUrl + "/Account/ActivateAccount.aspx?UserID=" + objUserInfo.userGuid);
                    message.Body = "Hi " + dt.Rows[0]["Name"] + "!\n" +
                "Username: " + dt.Rows[0]["UserName"] + "<br><br>Password: " + dt.Rows[0]["Password"] + "<br><br>";
                   message.Subject = "Forgot Password Information";
                    EmailInfoProvider.SendMailMethod(to, EmailFrom, message.Subject, message.Body);
                    //client.Send(message);
                    ShowMessage("Password is sent to you at your email id!!");
                  
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }

            }
            else
            {
                lblMessage.Text = "Email Address Not Registered";

            }
        }
        void ShowMessage(string msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + msg + "');</script>");
        }



        }
    }
