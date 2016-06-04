using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnkAsset.Data;
using AnkAsset.Core;
namespace AnkAsset.Web
{
    public partial class UsersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataSet ds = UserInfoProvider.ViewUserInfo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                gridView.DataSource = ds;
                gridView.DataBind();
                int columncount = gridView.Rows[0].Cells.Count;
                lblmsg.Text = " No data found !!!";
            }

        }

        protected void lkInActive_Click(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            int id = Convert.ToInt32(lnkRemove.CommandArgument);
            UserInfoProvider.DeactivateUserData(id);
            BindGrid();
            
        }
        protected void gridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Hide the edit button when some condition is true
                // for example, the row contains a certain property
                if (Context.User.Identity.Name!="admin.anktech")
                {
                    if (gridView.Columns[5].HeaderText == "InActive")
                    {
                        gridView.Columns[5].Visible = false;
                    }
                   LinkButton btnEdit = (LinkButton)e.Row.FindControl("InActive");
                   btnEdit.Visible = false;
                }
            }
        }
    }
}