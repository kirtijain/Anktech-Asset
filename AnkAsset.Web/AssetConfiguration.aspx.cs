using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnkAsset.Data;
using AnkAsset.Core;
using AnkAsset.Web.Helper;

namespace AnkAsset.Web
{
    public partial class AssetConfiguration : System.Web.UI.Page
    {
        public int id = 0;
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AssetConfigurationId"]))
            {
                id = Convert.ToInt32(Request.QueryString["AssetConfigurationId"]);
            }
            if (!IsPostBack)
            {
                BindDropDownList(ID);
                if (id != 0)
                {
                    DataTable dt = AssetConfigurationInfoProvider.LoadConfigurationInfo(id);
                    if (dt.Rows.Count > 0)
                    {
                        ddlAssetTypeName.SelectedIndex = ddlAssetTypeName.Items.IndexOf(ddlAssetTypeName.Items.FindByText(dt.Rows[0]["AssetTypeName"].ToString()));
                        txtRAMSize.Text = dt.Rows[0]["RAMSize"].ToString();
                        txtOSType.Text = dt.Rows[0]["OSType"].ToString();
                        txtHardDiskSize.Text = dt.Rows[0]["HardDiskSize"].ToString();
                        txtProcessor.Text = dt.Rows[0]["Processor"].ToString();
                       // txtCompany.Text = dt.Rows[0]["Company"].ToString();
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

                        if (datatableAssetName.Rows.Count > 0)
                        {
                            Common.BindDropdowns(ddlPartName, "PartName", "AssetPartId", datatableAssetName, "----Select Part Name----");
                            ddlPartName.SelectedIndex = ddlPartName.Items.IndexOf(ddlPartName.Items.FindByText(dt.Rows[0]["PartName"].ToString()));
                        }
                    }
                }
            }
        }
        protected void CreateAssetConfiguration_Click(object sender, EventArgs e)
        {
            AssetConfigurationInfo objAssetConfigurationInfo = new AssetConfigurationInfo();
            objAssetConfigurationInfo.assetPartId = Convert.ToInt32(ddlPartName.SelectedValue);
            objAssetConfigurationInfo.RAMSize = txtRAMSize.Text;
            objAssetConfigurationInfo.OStype = txtOSType.Text;
            objAssetConfigurationInfo.hardDiskSize = txtHardDiskSize.Text;
            objAssetConfigurationInfo.processor = txtProcessor.Text;
            objAssetConfigurationInfo.createdDate = DateTime.Now;
          //  objAssetConfigurationInfo.company = txtCompany.Text;
            if (id == 0)
            {
                AssetConfigurationInfoProvider.AssetConfigurationData(objAssetConfigurationInfo);
                Response.Redirect("ViewConfiguration.aspx");
            }
            else 
            {
                AssetConfigurationInfoProvider.UpdateAssetConfigurationData(objAssetConfigurationInfo,id);
                Response.Redirect("ViewConfiguration.aspx");
            }
            
        }
        private void BindDropDownList(Int32 ID)
        {
            DataTable dt = AssetConfigurationInfoProvider.GetAssetData(ID);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlAssetTypeName, "AssetTypeName","AssetTypeId", dt, "----Select Asset Type----");
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
        //private void BindDropDownList()
        //{
        //    DataTable dt = AssetConfigurationInfoProvider.GetAssetPartData();
        //    if (dt.Rows.Count > 0)
        //    {
        //        ddlPartName.DataSource = dt;

        //        ddlPartName.DataTextField = "partName"; // the items to be displayed in the list items

        //        ddlPartName.DataValueField = "AssetPartId"; // the id of the items displayed

        //        ddlPartName.DataBind();
        //        ddlPartName.Items.Insert(0, "----Select Part Name----");
        //    }
        //}
        //private void BindPartModelNo(Int32 AssetPartid)
        //{
        //    //DataTable dt = new DataTable();
        //    DataTable dt = AssetAllotmentInfoProvider.GetAssetPartData(AssetPartid);
        //    if (dt.Rows.Count > 0)
        //    {
        //        ddlPartModelNo.DataSource = dt;

        //        ddlPartModelNo.DataTextField = "PartModelNo"; // the items to be displayed in the list items

        //        ddlPartModelNo.DataValueField = "AssetPartId"; // the id of the items displayed

        //        ddlPartModelNo.DataBind();
        //        ddlPartModelNo.Items.Insert(0, "----Select Part Model No----");
        //    }
        //}
        //protected void ddlPartName_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        int AssetPartid = Convert.ToInt32(ddlPartModelNo.SelectedValue);
        //        BindPartModelNo(AssetPartid);
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
        //    }
        //}
    }
}
