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
    public partial class EmployeeAllotment : System.Web.UI.Page
    {
        public int AssetTypeid=0;
        public int empid = 0;
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["EmployeeAllotmentId"]))
            {
                ID = Convert.ToInt32(Request.QueryString["EmployeeAllotmentId"]);
            }
            if (!IsPostBack)
            {
                BindEmpId(empid);
                BindDropDownList(AssetTypeid);
                if (ID != 0)
                {
                    DataTable dt = EmployeeAllotmentInfoProvider.LoadEmployeeAllotmentInfo(ID);
                    if (dt.Rows.Count > 0)
                    {
                        ddlAssetTypeName.SelectedIndex = ddlAssetTypeName.Items.IndexOf(ddlAssetTypeName.Items.FindByText(dt.Rows[0]["AssetTypeName"].ToString()));
                        ddlEmpId.SelectedIndex = ddlEmpId.Items.IndexOf(ddlEmpId.Items.FindByText(dt.Rows[0]["EmpId"].ToString()));
                        int Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                        DataTable datatableemp = EmployeeAllotmentInfoProvider.GetEmployeeInfo(Id);
                        if (datatableemp.Rows.Count > 0)
                        {
                            txtEmployeeName.Text = dt.Rows[0]["EmployeeName"].ToString();
                            hidId.Value = dt.Rows[0]["Id"].ToString();
                        }
                        
                        int AssetTypeId = Convert.ToInt32(dt.Rows[0]["AssettypeId"].ToString());
                        DataTable datatablemodel = EmployeeAllotmentInfoProvider.GetModelNo(AssetTypeId);
                        if (datatablemodel.Rows.Count > 0)
                        {
                            Common.BindDropdowns(ddlModelNo, "PartModelNo", "PartModelNo", datatablemodel, "----Select Model No----");
                            ddlModelNo.SelectedIndex = ddlModelNo.Items.IndexOf(ddlModelNo.Items.FindByText(dt.Rows[0]["AllotedModelNo"].ToString()));
                        }
                        string ModelId = dt.Rows[0]["AllotedModelNo"].ToString();
                        DataTable datatableserial = AssetMaintainanceInfoProvider.GetSerialNo(ModelId);

                        if (datatableserial.Rows.Count > 0)
                        {
                            Common.BindDropdowns(ddlSerialNo, "PartSerialNo", "PartSerialNo", datatableserial, "----Select Serial No----");
                            ddlSerialNo.SelectedIndex = ddlSerialNo.Items.IndexOf(ddlSerialNo.Items.FindByText(dt.Rows[0]["AllotedSerialNo"].ToString()));
                        }
                        string SerialId = dt.Rows[0]["AllotedSerialNo"].ToString();
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

        protected void CreateEmployeeAllotment_Click(object sender, EventArgs e)
        {

            // string f = hidAssetId.Value;

            EmployeeAllotmentInfo objEmployeeAllotmentInfo = new EmployeeAllotmentInfo();
            objEmployeeAllotmentInfo.Id = Convert.ToInt32(hidId.Value);
            //objEmployeeAllotmentInfo.AssetTypeId = Convert.ToInt32(ddlAssetTypeName.SelectedValue);

            objEmployeeAllotmentInfo.allotedModelNo = ddlModelNo.SelectedItem.ToString();
            objEmployeeAllotmentInfo.allotedSerialNo = ddlSerialNo.SelectedItem.ToString();
            objEmployeeAllotmentInfo.allotedItemId = Convert.ToInt32(ddlPartName.SelectedValue);
            objEmployeeAllotmentInfo.createdDate = DateTime.Now;
            if (ID == 0)
            {

                EmployeeAllotmentInfoProvider.SaveEmployeeAllotmentData(objEmployeeAllotmentInfo);
                AssetAllotmentInfoProvider.UpdateIsOccupied(objEmployeeAllotmentInfo.allotedItemId);
                Response.Redirect("EmployeeAllotmentList.aspx");
            }
            else
            {
                DataTable dt = EmployeeAllotmentInfoProvider.LoadEmployeeAllotmentInfo(ID);
                if (dt.Rows.Count > 0)
                {
                    if ((dt.Rows[0]["AllotedModelNo"] == objEmployeeAllotmentInfo.allotedModelNo) && (dt.Rows[0]["AllotedSerialNo"] == objEmployeeAllotmentInfo.allotedSerialNo) && (Convert.ToInt32(dt.Rows[0]["AllotedItemId"]) == objEmployeeAllotmentInfo.allotedItemId))
                    {
                        EmployeeAllotmentInfoProvider.UpdateEmployeeAllotmentData(objEmployeeAllotmentInfo, ID);
                    }
                    else
                    {
                        EmployeeAllotmentInfoProvider.UpdateEmployeeAllotmentData(objEmployeeAllotmentInfo, ID);
                        AssetAllotmentInfoProvider.UpdateIsOccupiedAssetPart(Convert.ToInt32(dt.Rows[0]["AllotedItemId"]));
                        AssetAllotmentInfoProvider.UpdateIsOccupied(objEmployeeAllotmentInfo.allotedItemId);

                    }
                }
              Response.Redirect("EmployeeAllotmentList.aspx");
            }
        }

        private void BindEmpId(Int32 id)
        {
            DataTable dt = EmployeeAllotmentInfoProvider.GetEmployeeInfo(id);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlEmpId, "EmpId", "Id", dt, "----Select Emp Id----");
            }
        }
        private void BindEmpName(Int32 id)
        {
            DataTable dt = EmployeeAllotmentInfoProvider.GetEmployeeInfo(id);
            if (dt.Rows.Count > 0)
            {
                txtEmployeeName.Text = dt.Rows[0]["EmployeeName"].ToString();
                hidId.Value = dt.Rows[0]["Id"].ToString();
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
        private void BindModelNo(Int32 id)
        {
            DataTable dt = EmployeeAllotmentInfoProvider.GetModelNo(id);
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
        protected void ddlEmpId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ddlEmpId.SelectedValue);
                BindEmpName(id);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }
        protected void ddlAssetTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ddlAssetTypeName.SelectedValue);
                BindModelNo(id);
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