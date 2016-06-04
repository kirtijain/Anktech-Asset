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
    public class AssetConfigurationInfoProvider
    {
        public static int AssetConfigurationData(AssetConfigurationInfo objAssetConfigurationInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "INSERT INTO AssetConfiguration(AssetPartId,RAMSize, HardDiskSize,OSType,Processor,CreatedDate) " +
            " VALUES( @AssetPartId,@RAMSize, @HardDiskSize,@OSType,@Processor,@CreatedDate)";
            sqlCom.Parameters.Add("@AssetPartId", SqlDbType.Int).Value = objAssetConfigurationInfo.assetPartId; ;
            sqlCom.Parameters.Add("@RAMSize", SqlDbType.VarChar).Value = objAssetConfigurationInfo.RAMSize;
            sqlCom.Parameters.Add("@OSType", SqlDbType.VarChar).Value = objAssetConfigurationInfo.OStype;
            sqlCom.Parameters.Add("@HardDiskSize", SqlDbType.VarChar).Value = objAssetConfigurationInfo.hardDiskSize;
            sqlCom.Parameters.Add("@Processor", SqlDbType.VarChar).Value = objAssetConfigurationInfo.processor;
           // sqlCom.Parameters.Add("@Company", SqlDbType.VarChar).Value = objAssetConfigurationInfo.company;
            sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objAssetConfigurationInfo.createdDate;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        public static int UpdateAssetConfigurationData(AssetConfigurationInfo objAssetConfigurationInfo, int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE AssetConfiguration SET AssetPartId=@AssetPartId,RAMSize=@RAMSize,HardDiskSize=@HardDiskSize,OSType=@OSType,Processor=@Processor,ModifiedDate=@ModifiedDate where AssetConfigurationId=" + id;
            sqlCom.Parameters.Add("@AssetPartId", SqlDbType.Int).Value = objAssetConfigurationInfo.assetPartId; ;
            sqlCom.Parameters.Add("@RAMSize", SqlDbType.VarChar).Value = objAssetConfigurationInfo.RAMSize;
            sqlCom.Parameters.Add("@HardDiskSize", SqlDbType.VarChar).Value = objAssetConfigurationInfo.hardDiskSize;
            sqlCom.Parameters.Add("@OSType", SqlDbType.VarChar).Value = objAssetConfigurationInfo.OStype;
            sqlCom.Parameters.Add("@Processor", SqlDbType.VarChar).Value = objAssetConfigurationInfo.processor;
           // sqlCom.Parameters.Add("@Company", SqlDbType.VarChar).Value = objAssetConfigurationInfo.company;
          //  sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objAssetConfigurationInfo.createdDate;
            sqlCom.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
             int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static DataTable GetAssetData(Int32 id = 0)
        {
            SqlCommand sqlCom = new SqlCommand();
            if (id == 0)
            {
                sqlCom.CommandText = "select * from LookupAssetType where AssetTypeId<=3";
            }
            else
            {
                sqlCom.CommandText = "select * from Asset,LookupAssetType where Asset.AssetTypeId=LookupAssetType.AssetTypeId and LookupAssetType.AssetTypeId=" + id;
            }
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static DataSet ViewConfigurationInfo(string modelno)
        {
            SqlCommand sqlCom = new SqlCommand();
            if (modelno == null)
            {
                sqlCom.CommandText = "SELECT AssetConfiguration.*,LookupAssetType.AssetTypeName,AssetPart.PartName,AssetPart.PartModelNo,AssetPart.PartSerialNo,AssetPart.Company  FROM  AssetPart INNER JOIN AssetConfiguration ON AssetPart.AssetPartId = AssetConfiguration.AssetPartId INNER JOIN LookupAssetType ON AssetPart.AssetTypeId = LookupAssetType.AssetTypeId INNER JOIN Asset ON LookupAssetType.AssetTypeId = Asset.AssetTypeId AND AssetPart.AssetId = Asset.AssetId";
            }
            else
            {
                sqlCom.CommandText = "SELECT AssetConfiguration.*,LookupAssetType.AssetTypeName,AssetPart.PartName,AssetPart.PartModelNo,AssetPart.PartSerialNo,AssetPart.Company  FROM  AssetPart INNER JOIN AssetConfiguration ON AssetPart.AssetPartId = AssetConfiguration.AssetPartId INNER JOIN LookupAssetType ON AssetPart.AssetTypeId = LookupAssetType.AssetTypeId INNER JOIN Asset ON LookupAssetType.AssetTypeId = Asset.AssetTypeId AND AssetPart.AssetId = Asset.AssetId where AssetPart.PartSerialNo='" + modelno + "'";
            }
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
        public static DataTable LoadConfigurationInfo(int id)
        {
            //int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "SELECT AssetConfiguration.*,Asset.AssetTypeId,Asset.AssetId,Asset.BillNo,LookupAssetType.AssetTypeName,AssetPart.PartName,AssetPart.PartModelNo,AssetPart.PartSerialNo  FROM  AssetPart INNER JOIN AssetConfiguration ON AssetPart.AssetPartId = AssetConfiguration.AssetPartId INNER JOIN LookupAssetType ON AssetPart.AssetTypeId = LookupAssetType.AssetTypeId INNER JOIN Asset ON LookupAssetType.AssetTypeId = Asset.AssetTypeId AND AssetPart.AssetId = Asset.AssetId where AssetConfigurationId=" + id;
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }

        public static DataTable GetAssetPartData()
        {
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.CommandText = "select * from AssetPart";

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static int DeleteConfigurationData(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "Delete from AssetConfiguration where AssetConfigurationId=" + id;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
    }

}

