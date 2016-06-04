using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnkAsset.Core;
using AnkAsset.Data;

namespace AnkAsset.Web
{
    public partial class VendorList : System.Web.UI.Page
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
            DataSet ds = VendorInfoProvider.ViewVendorInfo();
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

        protected void lkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            int id = Convert.ToInt32(lnkRemove.CommandArgument);
            VendorInfoProvider.DeleteVendorData(id);
            BindGrid();
        }
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGrid();
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }

    }
}