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
namespace AnkAsset.Web.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void PageLoad(object sender, EventArgs e)
        {

        }
        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            UserInfo objUserInfo = new UserInfo();
            objUserInfo.password = txtCurrentPassword.Text;
            objUserInfo.newPassword = txtNewPassword.Text;
            DataTable dt = UserInfoProvider.ChangePasswordData(objUserInfo);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    UserInfoProvider.UpdatePassword(objUserInfo);
                    ShowMessage("Password is Updated!!");
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }
            }
            else
            {
                lblMessage.Text = "Current Password is not Corrrect";
            }
           
        }
        void ShowMessage(string msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + msg + "');</script>");
        }

    }
}
