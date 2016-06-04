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
    public partial class AssetMaintainance : System.Web.UI.Page
    {
        public int AssetTypeid = 0;
        public int ID = 0;
        public int Assetid = 0;
        public int BillId = 0;
        public int ModelId = 0;
        public string SerialId = null;
        public string AssetNameId = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AssetMaintainanceId"]))
            {
                ID = Convert.ToInt32(Request.QueryString["AssetMaintainanceId"]);
            }
            //    ID = Convert.ToInt32(Request.QueryString["AssetMaintainanceId"]);            
            if (!IsPostBack)
            {
                BindDropDownList(AssetTypeid);
                BindDropDownStatus();
                BindDropDownVendor();
                if (ID != 0)
                {
                    DataTable dt = AssetMaintainanceInfoProvider.LoadMaintenanceInfo(ID);
                    if (dt.Rows.Count > 0)
                    {
                        ddlAssetTypeName.Items.FindByText(dt.Rows[0]["AssetTypeName"].ToString()).Selected=true;
                        txtCallDate.Text = dt.Rows[0]["CallDate"].ToString();
                        txtServiceDate.Text = dt.Rows[0]["ServiceDate"].ToString();
                        txtIssueDescription.Text = dt.Rows[0]["IssueDescription"].ToString();
                        txtMaintenanceCost.Text = dt.Rows[0]["MaintenanceCost"].ToString();
                        ddlLookupCallStatus.Items.FindByText(dt.Rows[0]["StatusName"].ToString()).Selected = true;
                        ddlVendorName.SelectedIndex = ddlVendorName.Items.IndexOf(ddlVendorName.Items.FindByText(dt.Rows[0]["VendorName"].ToString()));
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
                        DataTable datatableserial = AssetMaintainanceInfoProvider.GetAllotToSerialNo(ModelId);

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
        protected void CreateAssetMaintainance_Click(object sender, EventArgs e)
        {
            AssetMaintainanceInfo objAssetMaintainanceInfo = new AssetMaintainanceInfo();
            objAssetMaintainanceInfo.assetPartId = Convert.ToInt32(ddlPartName.SelectedValue);
            objAssetMaintainanceInfo.assetTypeId = Convert.ToInt32(ddlAssetTypeName.SelectedValue);
            objAssetMaintainanceInfo.partModelNo = ddlModelNo.SelectedItem.ToString();
            objAssetMaintainanceInfo.partSerialNo = ddlSerialNo.SelectedItem.ToString();
            objAssetMaintainanceInfo.lookupCallStatusId = Convert.ToInt32(ddlLookupCallStatus.SelectedValue);
            objAssetMaintainanceInfo.assetVendorId = Convert.ToInt32(ddlVendorName.SelectedValue);
            objAssetMaintainanceInfo.issueDescription = txtIssueDescription.Text;
            objAssetMaintainanceInfo.callDate = Convert.ToDateTime(txtCallDate.Text);
            objAssetMaintainanceInfo.serviceDate = Convert.ToDateTime(txtServiceDate.Text);
            objAssetMaintainanceInfo.createdDate = DateTime.Now;
            objAssetMaintainanceInfo.maintainanceCost = decimal.Parse(txtMaintenanceCost.Text);
            if (ID == 0)
            {
                AssetMaintainanceInfoProvider.AssetMaintainanceData(objAssetMaintainanceInfo);
                Response.Redirect("ViewMaintenance.aspx");
            }
            else
            {
                AssetMaintainanceInfoProvider.UpdateAssetMaintainanceData(objAssetMaintainanceInfo, ID);
                Response.Redirect("ViewMaintenance.aspx");
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
            DataTable dt = AssetMaintainanceInfoProvider.GetAllotToSerialNo(Name);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlSerialNo, "PartSerialNo", "PartSerialNo", dt, "----Select Serial No----");
            }
        }

        private void BindDropDownStatus()
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetStatusData();
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlLookupCallStatus, "StatusName", "LookupCallStatusId", dt, "----Select Status----");
            }
        }
        private void BindDropDownVendor()
        {
            DataTable dt = AssetInfoProvider.GetData();
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlVendorName, "VendorName", "AssetVendorId", dt, "----Select Vendor Name----");
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
        protected void ddlAssetTypeName_SelectedIndexChanged(object sender, EventArgs e)
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

