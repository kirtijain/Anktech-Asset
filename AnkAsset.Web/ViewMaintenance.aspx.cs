using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnkAsset.Data;
using AnkAsset.Core;
using System.Data;
namespace AnkAsset.Web
{
    public partial class ViewMaintenance : System.Web.UI.Page
    {
        public int Id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                BindMaintenanceGrid(Id);
                 BindDropDownStatus();
            }
        }
        private void BindDropDownStatus()
        {
            //DataTable dt = new DataTable();
            DataTable dt = AssetMaintainanceInfoProvider.GetStatusData();
            if (dt.Rows.Count > 0)
            {
                ddlStatus.DataSource = dt;

                ddlStatus.DataTextField = "StatusName"; // the items to be displayed in the list items

                ddlStatus.DataValueField = "LookupCallStatusId"; // the id of the items displayed

                ddlStatus.DataBind();
                ddlStatus.Items.Insert(0, "----Select Status----");
            }
        }
        protected void BindMaintenanceGrid(Int32 Id)
        {
            DataSet ds = AssetMaintainanceInfoProvider.ViewMaintenanceInfo(Id);
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
        protected void ddlStatus_onSelectIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(ddlStatus.SelectedValue);
                BindMaintenanceGrid(Id);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindMaintenanceGrid(Id);
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }


        protected void lkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            int id = Convert.ToInt32(lnkRemove.CommandArgument);
            AssetMaintainanceInfoProvider.DeleteMaintenanceData(id);
            BindMaintenanceGrid(Id);
        }
    }
}
