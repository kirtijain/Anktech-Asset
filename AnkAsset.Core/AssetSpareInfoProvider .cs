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
    public class AssetSpareInfoProvider
    {
        public static int AssetSpareData(AssetSpareInfo objAssetspareInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "INSERT INTO AssetSpare(AssetTypeId,AssetPartId,PartSerialNo,PartModelNo) " +
            " VALUES( @AssetTypeId,@AssetPartId, @PartSerialNo,@PartModelNo)";
            sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.Int).Value = objAssetspareInfo.assetTypeId;
           sqlCom.Parameters.Add("@AssetPartId", SqlDbType.Int).Value = objAssetspareInfo.assetPartId;
         
            sqlCom.Parameters.Add("@PartSerialNo", SqlDbType.VarChar).Value = objAssetspareInfo.sparePartSerialNo;
         
            sqlCom.Parameters.Add("@PartModelNo", SqlDbType.VarChar).Value = objAssetspareInfo.sparePartModelNo;
                      int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        public static int UpdateAssetSpareData(AssetSpareInfo objAssetspareInfo, int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE AssetSpare SET AssetTypeId=@AssetTypeId,AssetPartId=@AssetPartId,PartSerialNo=@PartSerialNo,PartModelNo= @PartModelNo where AssetSpareId=" + id;

            sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.Int).Value = objAssetspareInfo.assetTypeId;
           sqlCom.Parameters.Add("@AssetPartId", SqlDbType.Int).Value = objAssetspareInfo.assetPartId;
         //   sqlCom.Parameters.Add("@SparePartName", SqlDbType.VarChar).Value = objAssetspareInfo.sparePartName;
            sqlCom.Parameters.Add("@PartSerialNo", SqlDbType.VarChar).Value = objAssetspareInfo.sparePartSerialNo;
          //  sqlCom.Parameters.Add("@SpareCompany", SqlDbType.VarChar).Value = objAssetspareInfo.spareCompany;
            sqlCom.Parameters.Add("@PartModelNo", SqlDbType.VarChar).Value = objAssetspareInfo.sparePartModelNo;
           

            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        //public static DataSet ViewAssetSpareInfo(string Name)
        //{
        //    SqlCommand sqlCom = new SqlCommand();
        //    if (Name == null)
        //    {
        //        sqlCom.CommandText = "select am.*,a.*,ap.BillNo,a.AssetId,lap.AssetTypeName from AssetSpare am join AssetPart a on a.AssetPartId=am.AssetPartId join LookupAssetType lap on lap.AssetTypeId=am.AssetTypeId join Asset ap on ap.AssetId=a.AssetId ";
        //    }
        //    else
        //    {
        //        sqlCom.CommandText = "select am.*,a.*,ap.BillNo,a.AssetId,lap.AssetTypeName from AssetSpare am join AssetPart a on a.AssetPartId=am.AssetPartId join LookupAssetType lap on lap.AssetTypeId=am.AssetTypeId join Asset ap on ap.AssetId=a.AssetId  and am.PartModelNo='" + Name + "'";
        //    }
        //    DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
        //    sqlCom.CommandType = CommandType.Text;
        //    return ds;
        //}
        
        public static DataTable LoadAssetSpareInfo(int id)
        {
            //  int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select am.*,a.PartName,ap.BillNo,a.AssetId,lap.AssetTypeName from AssetSpare am  join AssetPart a on a.AssetPartId=am.AssetPartId join LookupAssetType lap on lap.AssetTypeId=am.AssetTypeId join Asset ap on ap.AssetId=a.AssetId where AssetSpareId=" + id;
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static int DeleteAssetSpareData(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "Delete from AssetSpare where AssetSpareId=" + id;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
       
    }

}

