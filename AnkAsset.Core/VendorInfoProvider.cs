using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnkAsset.Data;
using System.Data.SqlClient;
using System.Data;

namespace AnkAsset.Core
{
    public class VendorInfoProvider
    {

        public static int VendorData(VendorInfo objVendorInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "INSERT INTO AssetVendor(VendorName, PersonName,ContactNo,AlternateNumber, ServiceCenterAddress,CreatedDate) " +
            " VALUES( @VendorName, @PersonName,@ContactNo,@AlternateNumber, @ServiceCenterAddress,@CreatedDate)";

            sqlCom.Parameters.Add("@VendorName", SqlDbType.VarChar).Value = objVendorInfo.vendorName;
            sqlCom.Parameters.Add("@PersonName", SqlDbType.VarChar).Value = objVendorInfo.personName;
            sqlCom.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = objVendorInfo.contactNo;
            sqlCom.Parameters.Add("@AlternateNumber", SqlDbType.VarChar).Value = objVendorInfo.alternateNumber;
            sqlCom.Parameters.Add("@ServiceCenterAddress", SqlDbType.VarChar).Value = objVendorInfo.serviceCenterAddress;
            sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objVendorInfo.createdDate;
           
            
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static int UpdateVendorData(VendorInfo objVendorInfo, int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE AssetVendor SET VendorName=@VendorName, PersonName=@PersonName,ContactNo=@ContactNo, AlternateNumber= @AlternateNumber,ServiceCenterAddress= @ServiceCenterAddress,ModifiedDate=@ModifiedDate where AssetVendorId=" + id;

            sqlCom.Parameters.Add("@VendorName", SqlDbType.VarChar).Value = objVendorInfo.vendorName;
            sqlCom.Parameters.Add("@PersonName", SqlDbType.VarChar).Value = objVendorInfo.personName;
            sqlCom.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = objVendorInfo.contactNo;
            sqlCom.Parameters.Add("@AlternateNumber", SqlDbType.VarChar).Value = objVendorInfo.alternateNumber;
            sqlCom.Parameters.Add("@ServiceCenterAddress", SqlDbType.VarChar).Value = objVendorInfo.serviceCenterAddress;
            sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objVendorInfo.createdDate;
           

            sqlCom.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;

           // sqlCom.Parameters.Add("@IsActive", SqlDbType.Bit).Value = 1;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }


        public static DataSet ViewVendorInfo()
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from Assetvendor";
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }

        public static DataSet LoadVendorInfo(int id)
        {
            //  int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from AssetVendor where AssetVendorId=" + id;
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
        public static int DeleteVendorData(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "Delete from AssetVendor where AssetVendorId=" + id;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        }

    }

