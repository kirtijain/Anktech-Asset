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
    public partial class AssetPart : System.Web.UI.Page
    {
        public int AssetId = 0;
        public int AssetPartID = 0;
        public int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            AssetPartID = Convert.ToInt32(Request.QueryString["AssetPartId"]);

            if (!IsPostBack)
            {
                BindDropDownList();
                
                if (AssetPartID != 0)
                {
                    DataTable datatableAsset = AssetPartInfoProvider.LoadAssetPartInfo(AssetPartID);
                    if (datatableAsset.Rows.Count > 0)
                    {
                        txtPartName.Text = datatableAsset.Rows[0]["PartName"].ToString();
                        txtPartSerialNo.Text = datatableAsset.Rows[0]["PartSerialNo"].ToString();
                        txtPartModelNo.Text = datatableAsset.Rows[0]["PartModelNo"].ToString();
                        txtCompany.Text = datatableAsset.Rows[0]["Company"].ToString();
                        txtPartPrice.Text = datatableAsset.Rows[0]["PartPrice"].ToString();
                        txtPartDescription.Text = datatableAsset.Rows[0]["PartDescription"].ToString();
                        txtPartPurchaseDate.Text = datatableAsset.Rows[0]["PartPurchaseDate"].ToString();
                        txtWarrentyDate.Text = datatableAsset.Rows[0]["WarrentyDate"].ToString();
                        txtWarrentyMonths.Text = datatableAsset.Rows[0]["WarrentyMonths"].ToString();
                        ddlAssetTypeName.Items.FindByText(datatableAsset.Rows[0]["AssetTypeName"].ToString()).Selected = true;

                        int assaetTypeId = Convert.ToInt32(datatableAsset.Rows[0]["AssetTypeId"].ToString());

                        DataTable dt = AssetPartInfoProvider.GetAssetData(assaetTypeId);

                        if (dt.Rows.Count > 0)
                        {
                            Common.BindDropdowns(ddlBillNo, "BillNo", "BillNo", dt, "----Select Bill No----");

                            ddlBillNo.Items.FindByText(datatableAsset.Rows[0]["BillNo"].ToString()).Selected = true;
                            txtAssetName.Text = datatableAsset.Rows[0]["AssetName"].ToString();
                            hidAssetId.Value = datatableAsset.Rows[0]["AssetId"].ToString();
                        }
                    }
                }
            }
        }

        protected void CreateAssetPart_Click(object sender, EventArgs e)
        {
           // string f = hidAssetId.Value;

            AssetPartInfo objAssetPartInfo = new AssetPartInfo();
            objAssetPartInfo.assetId = Convert.ToInt32(hidAssetId.Value);
            objAssetPartInfo.assetTypeId = Convert.ToInt32(ddlAssetTypeName.SelectedValue);
          
            objAssetPartInfo.partName = txtPartName.Text;
            objAssetPartInfo.partSerialNo = txtPartSerialNo.Text;
            objAssetPartInfo.partModelNo = txtPartModelNo.Text;
            objAssetPartInfo.company = txtCompany.Text;
            objAssetPartInfo.partPrice = decimal.Parse(txtPartPrice.Text);
            objAssetPartInfo.partDescription = txtPartDescription.Text;
            objAssetPartInfo.partPurchaseDate = Convert.ToDateTime(txtPartPurchaseDate.Text);
            objAssetPartInfo.warrantyMonths = Convert.ToInt32(txtWarrentyMonths.Text);
            objAssetPartInfo.warrantyDate = Convert.ToDateTime(txtWarrentyDate.Text);
            objAssetPartInfo.createdDate = DateTime.Now;
            objAssetPartInfo.isWorking = true;
            objAssetPartInfo.isOccupied = false;
            if (AssetPartID == 0)
            {
                AssetPartInfoProvider.AssetPartData(objAssetPartInfo);
                Response.Redirect("ViewAssetParts.aspx");
            }
            else
            {
                AssetPartInfoProvider.UpdateAssetPartData(objAssetPartInfo, AssetPartID);
                Response.Redirect("ViewAssetParts.aspx");
            }
        }

        private void BindDropDownList()
        {
            //DataTable dt = new DataTable();
            DataTable dt = AssetPartInfoProvider.GetAssetData();
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlAssetTypeName, "AssetTypeName", "AssetTypeId", dt, "----Select Asset Type----");
            }
        }

        private void BindBillNo(Int32 id)
        {
            DataTable dt = AssetPartInfoProvider.GetAssetData(id);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlBillNo, "BillNo", "BillNo", dt, "----Select Bill No----");
            }
        }

        private void BindAssetName(string Name)
        {
            DataTable dt = AssetPartInfoProvider.GetAssetName(Name);
            if (dt.Rows.Count > 0)
            {
                txtAssetName.Text = dt.Rows[0]["AssetName"].ToString();
                hidAssetId.Value = dt.Rows[0]["AssetId"].ToString();
            }
        }

        protected void ddlAssetTypeName_onSelectIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ddlAssetTypeName.SelectedValue);
                BindBillNo(id);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }

        protected void ddlBillNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindAssetName(ddlBillNo.SelectedValue);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }
    }
}