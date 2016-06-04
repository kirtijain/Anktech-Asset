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
    public class AssetPartInfoProvider
    {
        public static int AssetPartData(AssetPartInfo objAssetPartInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "INSERT INTO AssetPart(AssetTypeId,AssetId,PartName, PartSerialNo,PartModelNo,Company,PartPrice,PartDescription,PartPurchaseDate,WarrentyMonths,WarrentyDate,CreatedDate,IsWorking,IsOccupied) " +
            " VALUES( @AssetTypeId,@AssetId,@PartName, @PartSerialNo,@PartModelNo,@Company,@PartPrice,@PartDescription,@PartPurchaseDate,@WarrentyMonths,@WarrentyDate,@CreatedDate,@IsWorking,@IsOccupied)";
            sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.Int).Value = objAssetPartInfo.assetTypeId;
            sqlCom.Parameters.Add("@AssetId", SqlDbType.Int).Value = objAssetPartInfo.assetId;
            sqlCom.Parameters.Add("@PartName", SqlDbType.VarChar).Value = objAssetPartInfo.partName;
            sqlCom.Parameters.Add("@PartSerialNo", SqlDbType.VarChar).Value = objAssetPartInfo.partSerialNo;
            sqlCom.Parameters.Add("@Company", SqlDbType.VarChar).Value = objAssetPartInfo.company;
            sqlCom.Parameters.Add("@PartModelNo", SqlDbType.VarChar).Value = objAssetPartInfo.partModelNo;
            sqlCom.Parameters.Add("@PartPrice", SqlDbType.Decimal).Value = objAssetPartInfo.partPrice;
            sqlCom.Parameters.Add("@PartDescription", SqlDbType.VarChar).Value = objAssetPartInfo.partDescription;
            sqlCom.Parameters.Add("@PartPurchaseDate", SqlDbType.DateTime).Value = objAssetPartInfo.partPurchaseDate;
            sqlCom.Parameters.Add("@WarrentyMonths", SqlDbType.Int).Value = objAssetPartInfo.warrantyMonths;
            sqlCom.Parameters.Add("@WarrentyDate", SqlDbType.DateTime).Value = objAssetPartInfo.warrantyDate;
            sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objAssetPartInfo.createdDate;
            sqlCom.Parameters.Add("@IsWorking", SqlDbType.Bit).Value = objAssetPartInfo.isWorking;
            sqlCom.Parameters.Add("@IsOccupied", SqlDbType.Bit).Value = objAssetPartInfo.isOccupied;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        public static int UpdateAssetPartData(AssetPartInfo objAssetPartInfo, int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE AssetPart SET AssetTypeId=@AssetTypeId,AssetId=@AssetId,PartSerialNo=@PartSerialNo,PartName=@PartName,PartModelNo= @PartModelNo,Company=@Company,PartPrice=@PartPrice,PartDescription=@PartDescription,PartPurchaseDate=@PartPurchaseDate,WarrentyMonths=@WarrentyMonths,WarrentyDate=@WarrentyDate,ModifiedDate=@ModifiedDate,IsWorking=@IsWorking,IsOccupied=@IsOccupied where AssetPartId=" + id;

            sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.VarChar).Value = objAssetPartInfo.assetTypeId;
            sqlCom.Parameters.Add("@AssetId", SqlDbType.VarChar).Value = objAssetPartInfo.assetId;
            sqlCom.Parameters.Add("@PartSerialNo", SqlDbType.VarChar).Value = objAssetPartInfo.partSerialNo;
            sqlCom.Parameters.Add("@PartName", SqlDbType.VarChar).Value = objAssetPartInfo.partName;
            sqlCom.Parameters.Add("@Company", SqlDbType.VarChar).Value = objAssetPartInfo.company;
            sqlCom.Parameters.Add("@PartModelNo", SqlDbType.VarChar).Value = objAssetPartInfo.partModelNo;
            sqlCom.Parameters.Add("@PartPrice", SqlDbType.Decimal).Value = objAssetPartInfo.partPrice;
            sqlCom.Parameters.Add("@PartDescription", SqlDbType.VarChar).Value = objAssetPartInfo.partDescription;
            // sqlCom.Parameters.Add("@Quantity", SqlDbType.Int).Value = objAssetInfo.quantity;
            sqlCom.Parameters.Add("@PartPurchaseDate", SqlDbType.DateTime).Value = objAssetPartInfo.partPurchaseDate;
            sqlCom.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
            sqlCom.Parameters.Add("@WarrentyMonths", SqlDbType.Int).Value = objAssetPartInfo.warrantyMonths;
            sqlCom.Parameters.Add("@WarrentyDate", SqlDbType.DateTime).Value = objAssetPartInfo.warrantyDate;
            // sqlCom.Parameters.Add("@AssetVendorId", SqlDbType.Int).Value = objAssetInfo.assetVendorId;
            sqlCom.Parameters.Add("@IsWorking", SqlDbType.Bit).Value = objAssetPartInfo.isWorking;
            sqlCom.Parameters.Add("@IsOccupied", SqlDbType.Bit).Value = objAssetPartInfo.isOccupied;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }


        public static DataTable GetAssetData(Int32 id = 0)
        {
            SqlCommand sqlCom = new SqlCommand();
            if (id == 0)
            {
                sqlCom.CommandText = "select * from LookupAssetType";
            }
            else
            {
                sqlCom.CommandText = "select * from Asset,LookupAssetType where Asset.AssetTypeId=LookupAssetType.AssetTypeId and LookupAssetType.AssetTypeId=" + id;
            }
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static DataSet ViewAssetSpareInfo(string Name)
        {
            SqlCommand sqlCom = new SqlCommand();
            if (Name == null)
            {
                sqlCom.CommandText = "select * from AssetPart,LookupAssetType,Asset Where Asset.AssetId=AssetPart.AssetId and Assetpart.AssetTypeId=LookupAssetType.AssetTypeId and AssetPart.IsWorking='True' and AssetPart.IsOccupied='False'";
            }
            else
            {
                sqlCom.CommandText = "select * from AssetPart,LookupAssetType,Asset Where Asset.AssetId=AssetPart.AssetId and Assetpart.AssetTypeId=LookupAssetType.AssetTypeId and AssetPart.IsWorking='True' and AssetPart.IsOccupied='False' and AssetPart.PartModelNo='" + Name + "'";
            }
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
        public static DataSet ViewAssetFaultyInfo(string Name)
        {
            SqlCommand sqlCom = new SqlCommand();
            if (Name == null)
            {
                sqlCom.CommandText = "select * from AssetPart,LookupAssetType,Asset Where Asset.AssetId=AssetPart.AssetId and Assetpart.AssetTypeId=LookupAssetType.AssetTypeId and AssetPart.IsWorking='False'";
            }
            else
            {
                sqlCom.CommandText = "select * from AssetPart,LookupAssetType,Asset Where Asset.AssetId=AssetPart.AssetId and Assetpart.AssetTypeId=LookupAssetType.AssetTypeId and AssetPart.IsWorking='False' and AssetPart.PartModelNo='" + Name + "'";
            }
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
        public static DataSet ViewAssetPartInfo(string Name )
        {
            SqlCommand sqlCom = new SqlCommand();
            if (Name == null)
            {
                sqlCom.CommandText = "select * from AssetPart,LookupAssetType,Asset Where Asset.AssetId=AssetPart.AssetId and Assetpart.AssetTypeId=LookupAssetType.AssetTypeId and AssetPart.IsWorking='True'";
            }
            else 
            {
                sqlCom.CommandText = "select * from AssetPart,LookupAssetType,Asset Where Asset.AssetId=AssetPart.AssetId and Assetpart.AssetTypeId=LookupAssetType.AssetTypeId and AssetPart.IsWorking='True' and AssetPart.PartModelNo='" +Name+"'";
            }
             DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
        public static DataTable LoadAssetPartInfo(int id)
        {
            //  int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from AssetPart,Asset,LookupAssetType Where Asset.AssetId=AssetPart.AssetId and LookupAssetType.AssetTypeId=AssetPart.AssetTypeId and AssetPart.AssetPartId=" + id;
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static int DeleteAssetPartData(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "Update AssetPart set IsWorking='False' where AssetPartId=" + id;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static DataTable GetAssetName(String Name)
        {
            //  int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = Name;
            sqlCom.CommandText = "select * from Asset Where BillNo=@BillNo";

            DataTable ds = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
    }

}

