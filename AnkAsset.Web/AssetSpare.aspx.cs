using AnkAsset.Core;
using AnkAsset.Web.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnkAsset.Web
{
    public partial class AssetSpare : System.Web.UI.Page
    {
        public int AssetTypeid = 0;
      //  public int AssetId = 0;
        public int AssetSpareID = 0;
        //public int ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            AssetSpareID = Convert.ToInt32(Request.QueryString["AssetSpareId"]);

            if (!IsPostBack)
            {
                BindDropDownList(AssetTypeid);

                if (AssetSpareID != 0)
                {
                    DataTable dt = AssetSpareInfoProvider.LoadAssetSpareInfo(AssetSpareID);
                    if (dt.Rows.Count > 0)
                    {
                        ddlAssetTypeName.SelectedIndex = ddlAssetTypeName.Items.IndexOf(ddlAssetTypeName.Items.FindByText(dt.Rows[0]["AssetTypeName"].ToString()));
                        int Assetid = Convert.ToInt32(dt.Rows[0]["AssetTypeId"].ToString());
                        DataTable datatablebill = AssetMaintainanceInfoProvider.GetBillNo(Assetid);
                        if (datatablebill.Rows.Count > 0)
                        {
                            Common.BindDropdowns(ddlBillNo, "BillNo", "AssetId", datatablebill, "----Select Bill No----");
                            ddlBillNo.Items.FindByText(dt.Rows[0]["BillNo"].ToString()).Selected = true;

                        }
                        int BillId = Convert.ToInt32(dt.Rows[0]["AssetId"].ToString());
                        DataTable datatablemodel = AssetMaintainanceInfoProvider.GetModelNo(BillId);
                        if (datatablemodel.Rows.Count > 0)
                        {
                            Common.BindDropdowns(ddlModelNo, "PartModelNo", "PartModelNo", datatablemodel, "----Select Model No----");
                            ddlModelNo.SelectedIndex = ddlModelNo.Items.IndexOf(ddlModelNo.Items.FindByText(dt.Rows[0]["PartModelNo"].ToString()));
                        }
                        string ModelId = dt.Rows[0]["PartModelNo"].ToString();
                        DataTable datatableserial = AssetMaintainanceInfoProvider.GetSerialNo(ModelId);

                        if (datatableserial.Rows.Count > 0)
                        {
                            Common.BindDropdowns(ddlSerialNo, "PartSerialNo", "PartSerialNo", datatableserial, "----Select Serial No----");
                            ddlSerialNo.SelectedIndex = ddlSerialNo.Items.IndexOf(ddlSerialNo.Items.FindByText(dt.Rows[0]["PartSerialNo"].ToString()));
                        }
                        string SerialId = dt.Rows[0]["PartSerialNo"].ToString();
                        DataTable datatableAssetName = AssetMaintainanceInfoProvider.GetAssetPartName(SerialId);

                        if (dt.Rows.Count > 0)
                        {
                            Common.BindDropdowns(ddlPartName, "PartName", "AssetPartId", datatableAssetName, "----Select Part Name----");
                            ddlPartName.SelectedIndex = ddlPartName.Items.IndexOf(ddlPartName.Items.FindByText(dt.Rows[0]["PartName"].ToString()));
                        }
                    }
                }
            }
        }

        protected void CreateAssetSpare_Click(object sender, EventArgs e)
        {
            // string f = hidAssetId.Value;

            AssetSpareInfo objAssetSpareInfo = new AssetSpareInfo();
            objAssetSpareInfo.assetPartId = Convert.ToInt32(ddlPartName.SelectedValue);
            objAssetSpareInfo.assetTypeId = Convert.ToInt32(ddlAssetTypeName.SelectedValue);
            objAssetSpareInfo.sparePartModelNo = ddlModelNo.SelectedItem.ToString();
            objAssetSpareInfo.sparePartSerialNo = ddlSerialNo.SelectedItem.ToString();

            if (AssetSpareID == 0)
            {
                AssetSpareInfoProvider.AssetSpareData(objAssetSpareInfo);
                Response.Redirect("ViewSpare.aspx");
            }
            else
            {
                AssetSpareInfoProvider.UpdateAssetSpareData(objAssetSpareInfo, AssetSpareID);
                Response.Redirect("ViewSpare.aspx");
            }
        }
        private void BindDropDownList(Int32 id)
        {
            DataTable dt = AssetPartInfoProvider.GetAssetData(id);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlAssetTypeName, "AssetTypeName", "AssetTypeId", dt, "----Select Asset Type----");
            }
        }
        private void BindBillNo(Int32 id)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetBillNo(id);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlBillNo, "BillNo", "AssetId", dt, "----Select Bill No----");
            }
        }

        private void BindModelNo(Int32 BillNo)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetModelNo(BillNo);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlModelNo, "PartModelNo", "PartModelNo", dt, "----Select Model No----");
            }
        }

        private void BindSerialNo(string Name)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetSerialNo(Name);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlSerialNo, "PartSerialNo", "PartSerialNo", dt, "----Select Serial No----");
            }
        }

             
        private void BindAssetName(string Name)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetAssetPartName(Name);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlPartName, "PartName", "AssetPartId", dt, "----Select Asset Part Name----");
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
                int BillNo = Convert.ToInt32(ddlBillNo.SelectedValue);
                BindModelNo(BillNo);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }

        protected void ddlModelNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindSerialNo(ddlModelNo.SelectedValue);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }
        protected void ddlSerialNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SerialNo = ddlSerialNo.SelectedItem.ToString();
                BindAssetName(SerialNo);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }
    }
}