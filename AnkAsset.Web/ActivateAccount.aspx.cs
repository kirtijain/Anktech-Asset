using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnkAsset.Core;
using AnkAsset.Data;
using System.Data.SqlClient;
namespace AnkAsset.Web
{
    public partial class ActivateAccount : System.Web.UI.Page
    {
        protected UserInfo objUserInfo = new UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserID"] != null)
            {
                objUserInfo.userGuid = new Guid(Request.QueryString["UserID"]);
                try
                {
                    UserInfoProvider.ActivationData(objUserInfo.userGuid);
                   // Response.Write("You account has been activated. You can <a href='Login.aspx'>Login</a> now! ");
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
                    return;
                }
            }

        }
    }
}
