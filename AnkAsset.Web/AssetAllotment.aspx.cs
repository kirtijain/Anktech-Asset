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
    public partial class AssetAllotment : System.Web.UI.Page
    {
        public int AssetAllotmentid=0;
        public int empid = 0;
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           AssetAllotmentid = Convert.ToInt32(Request.QueryString["AssetAllotmentid"]);
            if (!IsPostBack)
            {
              //  BindEmpId(empid);
                BindDropDownList(ID);
                BindAllotedList(ID);
                 if (AssetAllotmentid != 0)
                    {
                        DataTable dt = AssetAllotmentInfoProvider.LoadAllotmentInfo(AssetAllotmentid);
                       // DataTable dtEmp = AssetAllotmentInfoProvider.LoadEmployeeInfo(AssetAllotmentid);
                        if (dt.Rows.Count > 0)
                        {
                            txtAllotmentDate.Text = (dt.Rows[0]["AllotmentDate"].ToString());
                          //  txtItemQuantity.Text = dt.Rows[0]["ItemQuantity"].ToString();
                            //ddlEmpId.SelectedIndex = ddlEmpId.Items.IndexOf(ddlEmpId.Items.FindByText(dtEmp.Rows[0]["EmpId"].ToString()));
                            //int Id = Convert.ToInt32(dtEmp.Rows[0]["Id"].ToString());
                            //DataTable datatableemp = EmployeeAllotmentInfoProvider.GetEmployeeInfo(Id);
                            //if (datatableemp.Rows.Count > 0)
                            //{
                            //    txtEmployeeName.Text = dtEmp.Rows[0]["EmployeeName"].ToString();
                            //    hidId.Value = dtEmp.Rows[0]["Id"].ToString();
                            //}
                            ddlAssetTypeName.Items.FindByText(dt.Rows[0]["AssetTypeName"].ToString()).Selected = true;
                            int AssetTypeid = Convert.ToInt32(dt.Rows[0]["AssetTypeId"].ToString());

                            DataTable datatablebill = AssetMaintainanceInfoProvider.GetBillNo(AssetTypeid);
                            if (datatablebill.Rows.Count > 0)
                            {
                                Common.BindDropdowns(ddlBillNo, "BillNo", "AssetId", datatablebill, "----Select AllotTo Bill No----");
                                ddlBillNo.Items.FindByText(dt.Rows[0]["BillNo"].ToString()).Selected = true;
                            }

                            int BillId = Convert.ToInt32(dt.Rows[0]["AssetId"].ToString());
                            DataTable datatablemodel = AssetMaintainanceInfoProvider.GetModelNo(BillId);
                            if (datatablemodel.Rows.Count > 0)
                            {
                                Common.BindDropdowns(ddlModelNo, "PartModelNo", "PartModelNo", datatablemodel, "----Select AllotTo Model No----");
                               ddlModelNo.Items.FindByText(dt.Rows[0]["AllotToModelNo"].ToString()).Selected=true;
                            }

                            string ModelId = dt.Rows[0]["PartModelNo"].ToString();
                            DataTable datatableserial = AssetMaintainanceInfoProvider.GetAllotToSerialNo(ModelId);
                            if (datatableserial.Rows.Count > 0)
                            {
                                Common.BindDropdowns(ddlSerialNo, "PartSerialNo", "PartSerialNo", datatableserial, "----Select AllotTo Serial No----");
                               ddlSerialNo.Items.FindByText(dt.Rows[0]["AllotToSerialNo"].ToString()).Selected=true;
                            }

                            string SerialId = dt.Rows[0]["PartSerialNo"].ToString();
                            DataTable datatableAssetName = AssetMaintainanceInfoProvider.GetAssetPartName(SerialId);
                            if (dt.Rows.Count > 0)
                            {
                               Common.BindDropdowns(ddlPartName, "PartName", "AssetPartId", datatableAssetName, "----Select AllotTo Part Name----");
                               ddlPartName.Items.FindByText(dt.Rows[0]["PartName"].ToString()).Selected=true;
                            }
                        }
                            //Alloted Dropdowns
                        DataTable datatabledt = AssetAllotmentInfoProvider.LoadAllotedInfo(AssetAllotmentid);
                        if (datatabledt.Rows.Count > 0)
                        {
                            ddlAllotedAssetTypeName.Items.FindByText(datatabledt.Rows[0]["AssetTypeName"].ToString()).Selected = true;
                            int AllotedAssetTypeid = Convert.ToInt32(datatabledt.Rows[0]["AssetTypeId"].ToString());

                            DataTable databill = AssetMaintainanceInfoProvider.GetBillNo(AllotedAssetTypeid);
                            if (databill.Rows.Count > 0)
                            {
                                Common.BindDropdowns(ddlAllotedItemBillNo, "BillNo", "AssetId", databill, "----Select Alloted Bill No----");
                                ddlAllotedItemBillNo.Items.FindByText(datatabledt.Rows[0]["BillNo"].ToString()).Selected = true;
                            }
                            int BillNoId = Convert.ToInt32(datatabledt.Rows[0]["AssetId"].ToString());
                            DataTable datamodel = AssetMaintainanceInfoProvider.GetModelNo(BillNoId);
                            if (datamodel.Rows.Count > 0)
                            {
                                Common.BindDropdowns(ddlAllotedItemModelNo, "PartModelNo", "PartModelNo", datamodel, "----Select Alloted Model No----");
                                ddlAllotedItemModelNo.Items.FindByText(datatabledt.Rows[0]["AllotedItemModelNo"].ToString()).Selected = true;
                            }
                            string ModelNoId = datatabledt.Rows[0]["PartModelNo"].ToString();
                            DataTable dataserial = AssetMaintainanceInfoProvider.GetSerialNo(ModelNoId);

                            if (dataserial.Rows.Count > 0)
                            {
                                Common.BindDropdowns(ddlAllotedItemSerialNo, "PartSerialNo", "PartSerialNo", dataserial, "----Select Alloted Serial No----");
                                ddlAllotedItemSerialNo.Items.FindByText(datatabledt.Rows[0]["AllotedItemSerialNo"].ToString()).Selected = true;
                            }
                            string SerialNoId = datatabledt.Rows[0]["PartSerialNo"].ToString();
                            DataTable dataAssetName = AssetMaintainanceInfoProvider.GetAssetPartName(SerialNoId);

                            if (dataAssetName.Rows.Count > 0)
                            {
                                Common.BindDropdowns(ddlAllotedItemName, "PartName", "AssetPartId", dataAssetName, "----Select Alloted Part Name----");
                                ddlAllotedItemName.Items.FindByText(datatabledt.Rows[0]["PartName"].ToString()).Selected = true;
                            }
                        }
                    }
                }
            }

        protected void CreateAssetAllotment_Click(object sender, EventArgs e)
        {
            AssetAllotmentInfo objAssetAllotmentInfo = new AssetAllotmentInfo();
           // objAssetAllotmentInfo.Id = Convert.ToInt32(hidId.Value);
            objAssetAllotmentInfo.assetPartId = Convert.ToInt32(ddlPartName.SelectedValue);
            objAssetAllotmentInfo.allotedItemId = Convert.ToInt32(ddlAllotedItemName.SelectedValue);
            objAssetAllotmentInfo.allotedItemModelNo = ddlAllotedItemModelNo.SelectedValue;
            objAssetAllotmentInfo.allotedItemSerialNo = ddlAllotedItemSerialNo.SelectedValue;
            objAssetAllotmentInfo.allotToModelNo = ddlModelNo.SelectedValue;
            objAssetAllotmentInfo.allotToSerialNo = ddlSerialNo.SelectedValue;
            objAssetAllotmentInfo.allotmentDate = Convert.ToDateTime(txtAllotmentDate.Text);
          //  objAssetAllotmentInfo.itemQuantity = Convert.ToInt32(txtItemQuantity.Text);
            objAssetAllotmentInfo.createdDate = DateTime.Now;
            if (AssetAllotmentid == 0)
            {
                AssetAllotmentInfoProvider.AssetAllotmentData(objAssetAllotmentInfo);
                AssetAllotmentInfoProvider.UpdateIsOccupied(objAssetAllotmentInfo.allotedItemId);
                Response.Redirect("ViewAllotment.aspx");
            }
            else
            {
                DataTable dt = AssetAllotmentInfoProvider.LoadAllotedInfo(AssetAllotmentid);
                if (dt.Rows.Count > 0)
                {
                    if ((dt.Rows[0]["AllotedItemModelNo"] == objAssetAllotmentInfo.allotedItemModelNo) && (dt.Rows[0]["AllotedItemSerialNo"] == objAssetAllotmentInfo.allotedItemSerialNo) && (Convert.ToInt32(dt.Rows[0]["AllotedItemId"]) == objAssetAllotmentInfo.allotedItemId))
                    {
                        AssetAllotmentInfoProvider.UpdateAssetAllotmentData(objAssetAllotmentInfo, AssetAllotmentid);
                    }
                    else
                    {
                        AssetAllotmentInfoProvider.UpdateAssetAllotmentData(objAssetAllotmentInfo, AssetAllotmentid);
                        AssetAllotmentInfoProvider.UpdateIsOccupiedAssetPart(Convert.ToInt32(dt.Rows[0]["AllotedItemId"]));
                        AssetAllotmentInfoProvider.UpdateIsOccupied(objAssetAllotmentInfo.allotedItemId);

                    } 
                }
              
                Response.Redirect("ViewAllotment.aspx");
            }
        }
        //private void BindEmpId(Int32 id)
        //{
        //    DataTable dt = EmployeeAllotmentInfoProvider.GetEmployeeInfo(id);
        //    if (dt.Rows.Count > 0)
        //    {
        //        Common.BindDropdowns(ddlEmpId, "EmpId", "Id", dt, "----Select Emp Id----");
        //    }
        //}
        //private void BindEmpName(Int32 id)
        //{
        //    DataTable dt = EmployeeAllotmentInfoProvider.GetEmployeeInfo(id);
        //    if (dt.Rows.Count > 0)
        //    {
        //        txtEmployeeName.Text = dt.Rows[0]["EmployeeName"].ToString();
        //        hidId.Value = dt.Rows[0]["Id"].ToString();
        //    }
        //}

        private void BindDropDownList(Int32 ID)
        {
            DataTable dt = AssetAllotmentInfoProvider.GetAssetData(ID);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlAssetTypeName, "AssetTypeName", "AssetTypeId", dt, "----Select AllotTo Type----");
            }
        }
        private void BindBillNo(Int32 id)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetBillNo(id);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlBillNo, "BillNo", "AssetId", dt, "----Select AllotTo Bill No----");
            }
        }

        private void BindModelNo(Int32 BillNo)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetModelNo(BillNo);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlModelNo, "PartModelNo", "PartModelNo", dt, "----Select AllotTo Model No----");
            }
        }

        private void BindSerialNo(string Name)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetAllotToSerialNo(Name);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlSerialNo, "PartSerialNo", "PartSerialNo", dt, "----Select AllotTo Serial No----");
            }
        }
        private void BindAssetName(string Name)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetAssetPartName(Name);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlPartName, "PartName", "AssetPartId", dt, "----Select AllotTo Part Name----");
            }
        }
        //protected void ddlEmpId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int id = Convert.ToInt32(ddlEmpId.SelectedValue);
        //        BindEmpName(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
        //    }
        //}
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
        
        //bind alloted item dropdown
        private void BindAllotedList(Int32 ID)
        {
            DataTable dt = AssetPartInfoProvider.GetAssetData(ID);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlAllotedAssetTypeName, "AssetTypeName", "AssetTypeId", dt, "----Select Alloted Asset Type----");
            }
        }
        private void BindAllotedBillNo(Int32 id)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetBillNo(id);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlAllotedItemBillNo, "BillNo", "AssetId", dt, "----Select Alloted Bill No----");
            }
        }

        private void BindAllotedModelNo(Int32 BillNo)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetModelNo(BillNo);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlAllotedItemModelNo, "PartModelNo", "PartModelNo", dt, "----Select Alloted Model No----");
            }
        }

        private void BindAllotedSerialNo(string Name)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetSerialNo(Name);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlAllotedItemSerialNo, "PartSerialNo", "PartSerialNo", dt, "----Select Alloted Serial No----");
            }
        }
        private void BindAllotedAssetName(string Name)
        {
            DataTable dt = AssetMaintainanceInfoProvider.GetAssetPartName(Name);
            if (dt.Rows.Count > 0)
            {
                Common.BindDropdowns(ddlAllotedItemName, "PartName", "AssetPartId", dt, "----Select Alloted Part Name----");
            }
        }
        protected void ddlAllotedAssetTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ddlAllotedAssetTypeName.SelectedValue);
                BindAllotedBillNo(id);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }
        protected void ddlAllotedItemBillNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int BillNo = Convert.ToInt32(ddlAllotedItemBillNo.SelectedValue);
                BindAllotedModelNo(BillNo);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }
        protected void ddlAllotedItemModelNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindAllotedSerialNo(ddlAllotedItemModelNo.SelectedValue);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }
        protected void ddlAllotedItemSerialNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SerialNo = ddlAllotedItemSerialNo.SelectedItem.ToString();
                BindAllotedAssetName(SerialNo);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
            }
        }
    }
}
