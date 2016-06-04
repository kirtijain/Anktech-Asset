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
    public partial class Vendor : System.Web.UI.Page
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["AssetVendorId"] != null)
            {
                var Id = Request.QueryString["AssetVendorId"];
                ID = Convert.ToInt32(Id);
            }

            if (!IsPostBack)
            {
                if (ID != 0)
                {
                    DataSet ds = VendorInfoProvider.LoadVendorInfo(ID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtVendorName.Text= ds.Tables[0].Rows[0]["VendorName"].ToString();
                        txtPersonName.Text = ds.Tables[0].Rows[0]["PersonName"].ToString();
                        txtContactNo.Text= ds.Tables[0].Rows[0]["ContactNo"].ToString();
                        txtAlternateNumber.Text= ds.Tables[0].Rows[0]["AlternateNumber"].ToString();
                        txtServiceCenterAddress.Text = ds.Tables[0].Rows[0]["ServiceCenterAddress"].ToString();
                        //txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                    }
                }
            }
        }
          protected void CreateVendor_Click(object sender, EventArgs e)
        {
            VendorInfo objVendorInfo = new VendorInfo();
            objVendorInfo.vendorName = txtVendorName.Text;
            objVendorInfo.personName = txtPersonName.Text;
            objVendorInfo.contactNo = txtContactNo.Text;
            objVendorInfo.alternateNumber = txtAlternateNumber.Text;
            objVendorInfo.serviceCenterAddress = txtServiceCenterAddress.Text;
            objVendorInfo.createdDate = DateTime.Now;
            if (ID == 0)
            {
                VendorInfoProvider.VendorData(objVendorInfo);
                Response.Redirect("VendorList.aspx");
            }
            else
            {
                VendorInfoProvider.UpdateVendorData(objVendorInfo,ID);
                Response.Redirect("VendorList.aspx");
            }
        }
    }
}