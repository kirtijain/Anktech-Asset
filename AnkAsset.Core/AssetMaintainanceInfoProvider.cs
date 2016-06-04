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
    public class AssetMaintainanceInfoProvider
    {
        public static int AssetMaintainanceData(AssetMaintainanceInfo objAssetMaintainanceInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "INSERT INTO AssetMaintainance(AssetTypeId,AssetPartId,PartModelNo,PartSerialNo,LookupCallStatusId,AssetVendorId,CallDate,ServiceDate,IssueDescription,CreatedDate,MaintenanceCost) " +
            " VALUES (@AssetTypeId,@AssetPartId,@PartModelNo,@PartSerialNo,@LookupCallStatusId, @AssetVendorId,@CallDate, @ServiceDate,@IssueDescription,@CreatedDate,@MaintenanceCost)";
            sqlCom.Parameters.Add("@AssetPartId", SqlDbType.Int).Value = objAssetMaintainanceInfo.assetPartId;
            sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.Int).Value = objAssetMaintainanceInfo.assetTypeId;
            sqlCom.Parameters.Add("@PartModelNo", SqlDbType.VarChar).Value = objAssetMaintainanceInfo.partModelNo;
            sqlCom.Parameters.Add("@PartSerialNo", SqlDbType.VarChar).Value = objAssetMaintainanceInfo.partSerialNo;
            sqlCom.Parameters.Add("@LookupCallStatusId", SqlDbType.Int).Value = objAssetMaintainanceInfo.lookupCallStatusId;
            sqlCom.Parameters.Add("@AssetVendorId", SqlDbType.Int).Value = objAssetMaintainanceInfo.assetVendorId;
            sqlCom.Parameters.Add("@CallDate", SqlDbType.DateTime).Value = objAssetMaintainanceInfo.callDate;
            sqlCom.Parameters.Add("@IssueDescription", SqlDbType.VarChar).Value = objAssetMaintainanceInfo.issueDescription;
            sqlCom.Parameters.Add("@ServiceDate", SqlDbType.DateTime).Value = objAssetMaintainanceInfo.serviceDate;
            sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objAssetMaintainanceInfo.createdDate;
            sqlCom.Parameters.Add("@MaintenanceCost", SqlDbType.Decimal).Value = objAssetMaintainanceInfo.maintainanceCost;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static int UpdateAssetMaintainanceData(AssetMaintainanceInfo objAssetMaintainanceInfo, int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE AssetMaintainance SET AssetTypeId=@AssetTypeId,AssetPartId=@AssetPartId,PartModelNo=@PartModelNo,PartSerialNo=@PartSerialNo,LookupCallStatusId=@LookupCallStatusId,AssetVendorId=@AssetVendorId, CallDate=@CallDate,IssueDescription= @IssueDescription,ServiceDate=@ServiceDate,ModifiedDate=@ModifiedDate,MaintenanceCost=@MaintenanceCost where AssetMaintainanceId=" + id;
            sqlCom.Parameters.Add("@AssetPartId", SqlDbType.Int).Value = objAssetMaintainanceInfo.assetPartId;
            sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.Int).Value = objAssetMaintainanceInfo.assetTypeId;
            sqlCom.Parameters.Add("@PartModelNo", SqlDbType.VarChar).Value = objAssetMaintainanceInfo.partModelNo;
            sqlCom.Parameters.Add("@PartSerialNo", SqlDbType.VarChar).Value = objAssetMaintainanceInfo.partSerialNo;
            sqlCom.Parameters.Add("@LookupCallStatusId", SqlDbType.Int).Value = objAssetMaintainanceInfo.lookupCallStatusId;
            sqlCom.Parameters.Add("@AssetVendorId", SqlDbType.Int).Value = objAssetMaintainanceInfo.assetVendorId;
            sqlCom.Parameters.Add("@CallDate", SqlDbType.DateTime).Value = objAssetMaintainanceInfo.callDate;
            sqlCom.Parameters.Add("@IssueDescription", SqlDbType.VarChar).Value = objAssetMaintainanceInfo.issueDescription;
            sqlCom.Parameters.Add("@ServiceDate", SqlDbType.DateTime).Value = objAssetMaintainanceInfo.serviceDate;
            sqlCom.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
            sqlCom.Parameters.Add("@MaintenanceCost", SqlDbType.Decimal).Value = objAssetMaintainanceInfo.maintainanceCost;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        public static DataTable GetStatusData()
        {
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.CommandText = "select * from LookupCallStatus";

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static DataTable GetBillNo(Int32 id)
        {
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.CommandText = "select BillNo,AssetTypeId,AssetId from Asset where AssetTypeId="+id;

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static DataTable GetModelNo(Int32 BillNo)
        {
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.CommandText = "select distinct PartModelNo from AssetPart where AssetId=" + BillNo;

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static DataTable GetSerialNo(string ModelNo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Parameters.Add("@ModelNo", SqlDbType.VarChar).Value = ModelNo;

            sqlCom.CommandText = "select PartSerialNo from AssetPart where PartModelNo=@ModelNo and isWorking=1 and IsOccupied=0";

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }

        public static DataTable GetAllotToSerialNo(string ModelNo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Parameters.Add("@ModelNo", SqlDbType.VarChar).Value = ModelNo;

            sqlCom.CommandText = "select PartSerialNo from AssetPart where PartModelNo=@ModelNo and isWorking=1";

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }


        public static DataSet ViewMaintenanceInfo(Int32 Id)
        {
            SqlCommand sqlCom = new SqlCommand();
            if (Id == 0)
            {
                sqlCom.CommandText = "select am.*,a.PartName,lap.AssetTypeName,lc.StatusName,av.VendorName from AssetMaintainance am join AssetVendor av on am.AssetVendorId=av.AssetVendorId join AssetPart a on a.AssetPartId=am.AssetPartId join LookupAssetType lap on lap.AssetTypeId=am.AssetTypeId join LookupCallStatus lc on lc.LookupCallStatusId=am.LookupCallStatusId where am.CreatedDate > @FilterDate";
            }
            else
            {
                sqlCom.CommandText = "select am.*,a.PartName,lap.AssetTypeName,lc.StatusName,av.VendorName from AssetMaintainance am join AssetVendor av on am.AssetVendorId=av.AssetVendorId join AssetPart a on a.AssetPartId=am.AssetPartId join LookupAssetType lap on lap.AssetTypeId=am.AssetTypeId join LookupCallStatus lc on lc.LookupCallStatusId=am.LookupCallStatusId where am.LookupCallStatusId=" + Id + " AND am.CreatedDate > @FilterDate";
            }
            sqlCom.Parameters.Add("@FilterDate", SqlDbType.DateTime).Value = DateTime.Now.Date.AddDays(-30);
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
        public static DataTable LoadMaintenanceInfo(int id)
        {
            //  int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select am.*,a.PartName,ap.BillNo,a.AssetId,lap.AssetTypeName,lc.StatusName,av.VendorName from AssetMaintainance am join AssetVendor av on am.AssetVendorId=av.AssetVendorId join AssetPart a on a.AssetPartId=am.AssetPartId join LookupAssetType lap on lap.AssetTypeId=am.AssetTypeId join LookupCallStatus lc on lc.LookupCallStatusId=am.LookupCallStatusId join Asset ap on ap.AssetId=a.AssetId where AssetMaintainanceId=" + id;
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static int DeleteMaintenanceData(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "Delete from AssetMaintainance where AssetMaintainanceId=" + id;

            //  sqlCom.Parameters.Add("@AssetName", SqlDbType.VarChar).Value = objAssetInfo.assetName;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static DataTable GetAssetPartName(string Name)
        {
            //  int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Parameters.Add("@SerialNo", SqlDbType.VarChar).Value = Name;
            sqlCom.CommandText = "select * from AssetPart where PartSerialNo=@SerialNo";
            DataTable ds = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
    }
}

