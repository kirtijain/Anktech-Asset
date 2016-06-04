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
    public partial class Employee : System.Web.UI.Page
    {
        public int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                var Id = Request.QueryString["Id"];
                ID = Convert.ToInt32(Id);
            }

            if (!IsPostBack)
            {
                if (ID != 0)
                {
                    DataSet ds = EmployeeInfoProvider.LoadEmployeeInfo(ID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtEmpId.Text = ds.Tables[0].Rows[0]["EmpId"].ToString();
                       txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                     //  txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                        txtEmailId.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                        txtContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        //txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                    }
                }
            }
        }
        protected void CreateEmployee_Click(object sender, EventArgs e)
        {
            EmployeeInfo objEmloyeeInfo = new EmployeeInfo();
            objEmloyeeInfo.EmpId = Convert.ToInt32(txtEmpId.Text);

            objEmloyeeInfo.EmailId = txtEmailId.Text;
            objEmloyeeInfo.EmployeeName = txtEmployeeName.Text;
          //  objEmloyeeInfo.LastName = txtLastName.Text;
            objEmloyeeInfo.ContactNo = txtContactNo.Text;
            objEmloyeeInfo.Address = txtAddress.Text;
            objEmloyeeInfo.CreatedDate = DateTime.Now;
            objEmloyeeInfo.IsActive = true;
            
            if (ID == 0)
            {
                EmployeeInfoProvider.SaveEmployeeData(objEmloyeeInfo);
                Response.Redirect("EmployeesList.aspx");
            }
            else
            {
                EmployeeInfoProvider.UpdateEmployeeData(objEmloyeeInfo, ID);
                Response.Redirect("EmployeesList.aspx");
            }

        }
    }
}