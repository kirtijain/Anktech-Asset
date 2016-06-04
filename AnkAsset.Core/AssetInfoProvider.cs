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
    public class AssetInfoProvider
    {

        public static int AssetData(AssetInfo objAssetInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "INSERT INTO Asset(AssetName, AssetTypeId,BillNo,AssetPrice,AssetDescription,Quantity,PurchaseDate,CreatedDate,AssetVendorId,IsWorking) " +
            " VALUES( @AssetName,@AssetTypeId,@BillNo, @AssetPrice,@AssetDescription,@Quantity,@PurchaseDate,@CreatedDate,@AssetVendorId,@IsWorking)";

            sqlCom.Parameters.Add("@AssetName", SqlDbType.VarChar).Value = objAssetInfo.assetName;
            //sqlCom.Parameters.Add("@SerialNo", SqlDbType.VarChar).Value = objAssetInfo.serialNo;
            sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.Int).Value = objAssetInfo.assetTypeId;
           // sqlCom.Parameters.Add("@AssetCompany", SqlDbType.VarChar).Value = objAssetInfo.assetCompany;
            //sqlCom.Parameters.Add("@ModelNo", SqlDbType.VarChar).Value = objAssetInfo.modelNo;
            sqlCom.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = objAssetInfo.BillNo;
            sqlCom.Parameters.Add("@AssetPrice", SqlDbType.Decimal).Value = objAssetInfo.assetPrice;
            sqlCom.Parameters.Add("@AssetDescription", SqlDbType.VarChar).Value = objAssetInfo.assetDescription;
            sqlCom.Parameters.Add("@Quantity", SqlDbType.Int).Value = objAssetInfo.quantity;
            sqlCom.Parameters.Add("@PurchaseDate", SqlDbType.DateTime).Value = objAssetInfo.purchaseDate;
            sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objAssetInfo.createdDate;
           
            sqlCom.Parameters.Add("@AssetVendorId", SqlDbType.Int).Value = objAssetInfo.assetVendorId;
            sqlCom.Parameters.Add("@IsWorking", SqlDbType.Bit).Value = objAssetInfo.isWorking;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static int UpdateAssetData(AssetInfo objAssetInfo, int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE Asset SET AssetName=@AssetName, AssetTypeId=@AssetTypeId,BillNo= @BillNo,AssetPrice=@AssetPrice,AssetDescription=@AssetDescription,Quantity=@Quantity,PurchaseDate=@PurchaseDate,ModifiedDate=@ModifiedDate,AssetVendorId=@AssetVendorId,IsWorking=@IsWorking where AssetId=" + id;

            sqlCom.Parameters.Add("@AssetName", SqlDbType.VarChar).Value = objAssetInfo.assetName;
            sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.Int).Value = objAssetInfo.assetTypeId;
            sqlCom.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = objAssetInfo.BillNo;
            sqlCom.Parameters.Add("@AssetPrice", SqlDbType.Decimal).Value = objAssetInfo.assetPrice;
            sqlCom.Parameters.Add("@AssetDescription", SqlDbType.VarChar).Value = objAssetInfo.assetDescription;
            sqlCom.Parameters.Add("@Quantity", SqlDbType.Int).Value = objAssetInfo.quantity;
            sqlCom.Parameters.Add("@PurchaseDate", SqlDbType.DateTime).Value = objAssetInfo.purchaseDate;
            sqlCom.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
            sqlCom.Parameters.Add("@AssetVendorId", SqlDbType.Int).Value = objAssetInfo.assetVendorId;
            sqlCom.Parameters.Add("@IsWorking", SqlDbType.Bit).Value = objAssetInfo.isWorking;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static int DeleteAssetData(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "Update Asset set IsWorking='False' where AssetId=" + id;

            //  sqlCom.Parameters.Add("@AssetName", SqlDbType.VarChar).Value = objAssetInfo.assetName;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        public static DataTable GetData()
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from AssetVendor";
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static DataTable GetAssetTypeData()
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from LookupAssetType";
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }

        public static DataSet ViewAssetInfo(string Name)
        { 
            SqlCommand sqlCom = new SqlCommand();
            if (Name == null)
            {
                sqlCom.CommandText = "select * from Asset,AssetVendor,LookupAssetType Where Asset.AssetVendorId=AssetVendor.AssetVendorId and Asset.AssetTypeId=LookupAssetType.AssetTypeId and Asset.IsWorking='True'";
            }
            else
            {
                sqlCom.CommandText = "select * from Asset,AssetVendor,LookupAssetType Where Asset.AssetVendorId=AssetVendor.AssetVendorId and Asset.AssetTypeId=LookupAssetType.AssetTypeId and Asset.IsWorking='True' and Asset.BillNo='" +Name+"'";
            }

            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
        public static DataSet LoadAssetInfo(int id)
        {
            //  int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from Asset,AssetVendor,LookupAssetType Where Asset.AssetVendorId=AssetVendor.AssetVendorId and Asset.AssetTypeId=LookupAssetType.AssetTypeId and Asset.AssetId=" + id;
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }

    }

}

