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
    public partial class ViewAsset : System.Web.UI.Page
    {
        public string billno = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(billno);
            }
        }

        protected void BindGrid(string billno)
        {
            DataSet ds = AssetInfoProvider.ViewAssetInfo(billno);
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

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGrid(billno);
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }
        protected void ViewAsset_Click(object sender, EventArgs e)
        {
            string billno = txtbill.Text;
            BindGrid(billno);
        }
        protected void lkDelete_Click(object sender, EventArgs e)
        {

            LinkButton lnkRemove = (LinkButton)sender;
            int id = Convert.ToInt32(lnkRemove.CommandArgument);
            AssetInfoProvider.DeleteAssetData(id);
            BindGrid(billno);


        }
    }
}