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
    public partial class Register : System.Web.UI.Page
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserId"] != null)
            {
                var Id = Request.QueryString["UserId"];
                ID = Convert.ToInt32(Id);
            }           

            if (!IsPostBack)
            {
                if (ID != 0)
                {
                    DataSet ds = UserInfoProvider.LoadUserInfo(ID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        txtUserName.Text= ds.Tables[0].Rows[0]["UserName"].ToString();
                        txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                        txtUserContact.Text = ds.Tables[0].Rows[0]["UserContact"].ToString();
                        txtUserAddress.Text = ds.Tables[0].Rows[0]["UserAddress"].ToString();
                        //txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                    }
                }
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            bool ab=false;
            UserInfo objUserInfo = new UserInfo();
            objUserInfo.userName = txtUserName.Text;
            objUserInfo.email = txtEmail.Text;
            objUserInfo.name = txtName.Text;
            objUserInfo.password = txtPassword.Text;
            objUserInfo.userContact = txtUserContact.Text;
            objUserInfo.userAddress = txtUserAddress.Text;
            objUserInfo.createdDate = DateTime.Now;
            objUserInfo.isActive = false;
            objUserInfo.userGuid = Guid.NewGuid();
            DataTable dt = UserInfoProvider.IsUsernameEmailExist(objUserInfo);
            if (ID == 0)
            {
                if (dt.Rows.Count > 0)
                {
                    ab = true;
                }
                else
                {
                    ab = false;
                }
                if (ab == true)
                {
                    ShowMessage("UserName/Email already exists...please try another");
                }
                else {

                    UserInfoProvider.SaveData(objUserInfo);
                    SendMail(objUserInfo);
                }
            }
            ////if (ID == 0)
            ////{
            //    UserInfoProvider.SaveData(objUserInfo);
            //    SendMail(objUserInfo);
            ////}
            else
            {
                UserInfoProvider.UpdateUserData(objUserInfo, ID);
                Response.Redirect("ViewAsset.aspx");
            }

        }
                private void SendMail(UserInfo objUserInfo)
                {
                try
                {
                    string EmailFrom = ConfigurationManager.AppSettings["EmailFrom"];
                    string SiteUrl = ConfigurationManager.AppSettings["SiteUrl"];
                    string SiteName = ConfigurationManager.AppSettings["SiteName"];
                    string ActivationUrl = string.Empty;
                    string to = objUserInfo.email;
                    MailMessage message = new MailMessage(EmailFrom, to);
                    //For testing replace the local host path with your lost host path and while making online replace with your website domain name
                    ActivationUrl = Server.HtmlEncode(SiteUrl + "/ActivateAccount.aspx?UserID=" + objUserInfo.userGuid);
                    message.Body = "Hi " + objUserInfo.name.Trim() + "!\n" +
                 "Thanks for showing interest and registring in <a href=SiteName> AnkAsset.com<a> " +
                 " Please <a href='" + ActivationUrl + "'>click here to activate</a>  your account and enjoy our services. \nThanks!";
                    message.Subject = "Email Verification";
                    EmailInfoProvider.SendMailMethod(to, EmailFrom, message.Subject, message.Body);
                    //client.Send(message);
                    ShowMessage("Email Sending successfully...!");
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }
                Response.Redirect("Thankyou.aspx");

                }
             void ShowMessage(string msg)
             {
              ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + msg + "');</script>");
             }
        }
    }
