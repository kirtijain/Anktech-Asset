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
    public partial class ViewAllotment : System.Web.UI.Page
    {
         DataSet ds = new DataSet();
         public string modelno = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(modelno);
            }
        }
         protected void BindGrid(string modelno)
        {
             ds = AssetAllotmentInfoProvider.ViewAssetAllotmentInfo(modelno);
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
            BindGrid(modelno);
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }
        protected void ViewAssetAllotment_Click(object sender, EventArgs e)
        {
            string modelno = txtmodel.Text;
            BindGrid(modelno);
        }
        protected void lkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            int id = Convert.ToInt32(lnkRemove.CommandArgument);
            DataTable dt = AssetAllotmentInfoProvider.SelectPartIdForAssetAllotment(id);
            int AllotedItemId = Convert.ToInt32(dt.Rows[0]["AllotedItemId"].ToString());
           // int AssetPartId = Convert.ToInt32(dt.Rows[0]["AssetPartId"].ToString());
            AssetAllotmentInfoProvider.DeleteAssetAllotmentData(id);

            AssetAllotmentInfoProvider.UpdateIsOccupiedAssetPart(AllotedItemId);
            BindGrid(modelno);
        }

    }
}