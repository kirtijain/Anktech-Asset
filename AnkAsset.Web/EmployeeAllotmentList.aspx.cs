using AnkAsset.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnkAsset.Web
{
    public partial class EmployeeAllotmentList : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
       public int empid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(empid);
            }
        }
        protected void BindGrid(Int32 empid)
        {
            ds = EmployeeAllotmentInfoProvider.ViewEmployeeAllotmentInfo(empid);
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
            BindGrid(empid);
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }
        protected void lkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            int id = Convert.ToInt32(lnkRemove.CommandArgument);
            DataTable dt = AssetAllotmentInfoProvider.SelectPartId(id);
            int AllotedItemId = Convert.ToInt32(dt.Rows[0]["AllotedItemId"].ToString());
           // int AssetPartId = Convert.ToInt32(dt.Rows[0]["AssetPartId"].ToString());
            EmployeeAllotmentInfoProvider.DeactivateEmployeeAllotmentData(id);
                    
             AssetAllotmentInfoProvider.UpdateIsOccupiedAssetPart(AllotedItemId);
            BindGrid(empid);
        }
        protected void ViewEmployeeAllotment_Click(object sender, EventArgs e)
        {
            int empid = Convert.ToInt32(txtEmpId.Text);
            BindGrid(empid);
        }
    }
}