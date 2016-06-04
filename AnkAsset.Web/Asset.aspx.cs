using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnkAsset.Data;
using AnkAsset.Core;
using System.Data;
using AnkAsset.Web.Helper;

namespace AnkAsset.Web
{
    public partial class Asset : System.Web.UI.Page
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(Request.QueryString["AssetId"]);
            if (!IsPostBack)
            {
                BindDropDownList();
                BindAssetType();
                if (ID != 0)
                {
                    DataSet ds = AssetInfoProvider.LoadAssetInfo(ID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtAssetName.Text = ds.Tables[0].Rows[0]["AssetName"].ToString();
                        ddlAssetTypeName.Items.FindByText(ds.Tables[0].Rows[0]["AssetTypeName"].ToString()).Selected=true;
                        txtBillNo.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                        txtAssetPrice.Text = ds.Tables[0].Rows[0]["AssetPrice"].ToString();
                        txtAssetDescription.Text = ds.Tables[0].Rows[0]["AssetDescription"].ToString();
                        txtQuantity.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
                        txtPurchaseDate.Text = ds.Tables[0].Rows[0]["PurchaseDate"].ToString();
                      ddlVendorName.Items.FindByText(ds.Tables[0].Rows[0]["VendorName"].ToString()).Selected=true;
                    }
                }
            }
        }

        protected void CreateAsset_Click(object sender, EventArgs e)
        {
            AssetInfo objAssetInfo = new AssetInfo();
            objAssetInfo.assetName = txtAssetName.Text;
   
            objAssetInfo.assetTypeId = Convert.ToInt32(ddlAssetTypeName.SelectedValue);
            objAssetInfo.assetVendorId = Convert.ToInt32(ddlVendorName.SelectedValue);
            objAssetInfo.BillNo = txtBillNo.Text;
            objAssetInfo.assetPrice = decimal.Parse(txtAssetPrice.Text);
            objAssetInfo.assetDescription = txtAssetDescription.Text;
            objAssetInfo.quantity = Convert.ToInt16(txtQuantity.Text);
            objAssetInfo.purchaseDate = Convert.ToDateTime(txtPurchaseDate.Text);
            objAssetInfo.createdDate = DateTime.Now;
            objAssetInfo.isWorking = true;
            if (ID == 0)
            {
                AssetInfoProvider.AssetData(objAssetInfo);
                Response.Redirect("ViewAsset.aspx");

            }
            else
            {
                AssetInfoProvider.UpdateAssetData(objAssetInfo, ID);
                // BindDropDownList();
                Response.Redirect("ViewAsset.aspx");
            }
        }
        private void BindDropDownList()
        {
            DataTable dt = AssetInfoProvider.GetData();
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlVendorName, "VendorName", "AssetVendorId", dt, "----Select Vendor Name----");
            }
        }
        private void BindAssetType()
        {
            DataTable dt = AssetInfoProvider.GetAssetTypeData();
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlAssetTypeName, "AssetTypeName", "AssetTypeId", dt, "----Select Asset Type----");
            }
        }
    }
}