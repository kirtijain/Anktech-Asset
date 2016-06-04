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
    public partial class ViewConfiguration : System.Web.UI.Page
    {
      //  public int id = 0;
        public string modelno = null;
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                BindConfigurationGrid(modelno);
                 //BindDropDownStatus();
            }
        }
       
        protected void BindConfigurationGrid(string modelno)
        {
            DataSet ds = AssetConfigurationInfoProvider.ViewConfigurationInfo(modelno);
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
            BindConfigurationGrid(modelno);
            gridView.PageIndex = e.NewPageIndex;
            gridView.DataBind();
        }
        protected void ViewAssetConfiguration_Click(object sender, EventArgs e)
        {
            string modelno = txtmodel.Text;
            BindConfigurationGrid(modelno);
        }
        protected void lkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            int id = Convert.ToInt32(lnkRemove.CommandArgument);
            AssetConfigurationInfoProvider.DeleteConfigurationData(id);
            BindConfigurationGrid(modelno);
        }
    }
}

