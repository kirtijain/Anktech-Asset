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
    public class AssetAllotmentInfoProvider
    {
        public static int AssetAllotmentData(AssetAllotmentInfo objAssetAllotmentInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "INSERT INTO AssetAllotment(AssetPartId,AllotToModelNo,AllotToSerialNo,AllotedItemModelNo,AllotedItemSerialNo,AllotedItemId,AllotmentDate,CreatedDate)" +
            " VALUES(@AssetPartId,@AllotToModelNo,@AllotToSerialNo,@AllotedItemModelNo,@AllotedItemSerialNo,@AllotedItemId,@AllotmentDate,@CreatedDate)";
            //   sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.Int).Value = objAssetAllotmentInfo.assetTypeId; ;
            sqlCom.Parameters.Add("@AssetPartId", SqlDbType.Int).Value = objAssetAllotmentInfo.assetPartId;
           // sqlCom.Parameters.Add("@Id", SqlDbType.Int).Value = objAssetAllotmentInfo.Id;
            sqlCom.Parameters.Add("@AllotToModelNo", SqlDbType.VarChar).Value = objAssetAllotmentInfo.allotToModelNo;
            sqlCom.Parameters.Add("@AllotToSerialNo", SqlDbType.VarChar).Value = objAssetAllotmentInfo.allotToSerialNo;
            sqlCom.Parameters.Add("@AllotedItemSerialNo", SqlDbType.VarChar).Value = objAssetAllotmentInfo.allotedItemSerialNo;
            sqlCom.Parameters.Add("@AllotedItemId", SqlDbType.Int).Value = objAssetAllotmentInfo.allotedItemId;
            sqlCom.Parameters.Add("@AllotedItemModelNo", SqlDbType.VarChar).Value = objAssetAllotmentInfo.allotedItemModelNo;
            //sqlCom.Parameters.Add("@ItemQuantity", SqlDbType.Int).Value = objAssetAllotmentInfo.itemQuantity;
            sqlCom.Parameters.Add("@AllotmentDate", SqlDbType.DateTime).Value = objAssetAllotmentInfo.allotmentDate;
            sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objAssetAllotmentInfo.createdDate;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        public static int UpdateAssetAllotmentData(AssetAllotmentInfo objAssetAllotmentInfo, int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE AssetAllotment SET AssetPartId=@AssetPartId,AllotToModelNo=@AllotToModelNo,AllotToSerialNo=@AllotToSerialNo,AllotedItemSerialNo=@AllotedItemSerialNo,AllotedItemId=@AllotedItemId,AllotedItemModelNo=@AllotedItemModelNo,AllotmentDate=@AllotmentDate,ModifiedDate=@ModifiedDate where AssetAllotmentId=" + id;
            sqlCom.Parameters.Add("@AssetPartId", SqlDbType.Int).Value = objAssetAllotmentInfo.assetPartId;
            sqlCom.Parameters.Add("@AllotToModelNo", SqlDbType.VarChar).Value = objAssetAllotmentInfo.allotToModelNo;
            sqlCom.Parameters.Add("@AllotToSerialNo", SqlDbType.VarChar).Value = objAssetAllotmentInfo.allotToSerialNo;
            sqlCom.Parameters.Add("@AllotedItemSerialNo", SqlDbType.VarChar).Value = objAssetAllotmentInfo.allotedItemSerialNo;
            sqlCom.Parameters.Add("@AllotedItemId", SqlDbType.Int).Value = objAssetAllotmentInfo.allotedItemId;
            sqlCom.Parameters.Add("@AllotedItemModelNo", SqlDbType.VarChar).Value = objAssetAllotmentInfo.allotedItemModelNo;
            //sqlCom.Parameters.Add("@ItemQuantity", SqlDbType.Int).Value = objAssetAllotmentInfo.itemQuantity;
            sqlCom.Parameters.Add("@AllotmentDate", SqlDbType.DateTime).Value = objAssetAllotmentInfo.allotmentDate;
            sqlCom.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        public static DataTable GetAssetData(Int32 AssetPartid)
        {
            SqlCommand sqlCom = new SqlCommand();
            if (AssetPartid == 0)
            {
                sqlCom.CommandText = "select * from LookupAssetType where AssetTypeId<=3";
            }
            else
            {
                sqlCom.CommandText = "select * from AssetPart where AssetPartId=" + AssetPartid;
            }
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
       
        public static DataSet ViewAssetAllotmentInfo(string modelno)
        {
            SqlCommand sqlCom = new SqlCommand();
            if (modelno == null)
            {
                sqlCom.CommandText = "SELECT AssetAllotment.*,(select AssetPart.PartName from AssetPart where AssetPart.AssetPartId= AssetAllotment.AssetPartId)as PartName , " +
                "(select AssetPart.PartName from AssetPart where AssetPart.AssetPartId= AssetAllotment.AllotedItemId)as AllotedItemName FROM  AssetAllotment";
                // "(select Employee.EmployeeName from Employee where Employee.Id= AssetAllotment.Id)as EmployeeName, " +
                //   "(select Employee.EmpId from Employee where Employee.Id= AssetAllotment.Id)as EmpId, " +
            }
            else 
            {
                sqlCom.CommandText = "SELECT AssetAllotment.*,(select AssetPart.PartName from AssetPart where AssetPart.AssetPartId= AssetAllotment.AssetPartId)as PartName , " +
               "(select AssetPart.PartName from AssetPart where AssetPart.AssetPartId= AssetAllotment.AllotedItemId)as AllotedItemName , "+
                 " FROM  AssetAllotment where AllotToModelNo='" + modelno + "'";
                //"(select Employee.EmpId from Employee where Employee.Id= AssetAllotment.Id)as EmpId, " +
                // "(select Employee.EmployeeName from Employee where Employee.Id= AssetAllotment.Id)as EmployeeName " +
             
            }
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }

        public static DataTable LoadAllotmentInfo(int id)
        {
            //int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "SELECT aa.*,a.BillNo,lat.AssetTypeName,ap.PartName,lat.AssetTypeId,a.AssetId,ap.PartModelNo,ap.PartSerialNo "+
          "FROM  AssetPart ap INNER JOIN AssetAllotment aa ON ap.AssetPartId = aa.AssetPartId INNER JOIN "+
          "LookupAssetType lat ON ap.AssetTypeId = lat.AssetTypeId INNER JOIN Asset a ON lat.AssetTypeId = a.AssetTypeId AND "+
          "ap.AssetId = a.AssetId where aa.AssetAllotmentId=" + id;

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);      
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static DataTable LoadEmployeeInfo(int id)
        {
            //int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from Employee,AssetAllotment where Employee.Id=AssetAllotment.Id and AssetAllotment.AssetAllotmentId=" + id;

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }

        public static DataTable LoadAllotedInfo(int id)
        {
            SqlCommand sqlCom = new SqlCommand();                                               
            sqlCom.CommandText = "SELECT aa.*,a.BillNo,lat.AssetTypeName,ap.PartName,lat.AssetTypeId,a.AssetId ,ap.PartModelNo,ap.PartSerialNo " +
                 "FROM  AssetPart ap INNER JOIN AssetAllotment aa ON ap.AssetPartId = aa.AllotedItemId " +
               "INNER JOIN LookupAssetType lat ON ap.AssetTypeId = lat.AssetTypeId " +
           "INNER JOIN Asset a ON lat.AssetTypeId = a.AssetTypeId AND ap.AssetId = a.AssetId " +
              "where aa.AssetAllotmentId=" + id;

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static int DeleteAssetAllotmentData(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "Delete from AssetAllotment where AssetAllotmentId=" + id;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        public static int UpdateIsOccupied(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE AssetPart SET IsOccupied='True' where AssetPartId=" + id;
           
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        public static int UpdateIsOccupiedAssetPart(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE AssetPart SET IsOccupied='False' where AssetPartId=" + id;

            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static DataTable SelectPartId(Int32 id)
        {
            SqlCommand sqlCom = new SqlCommand();
           
                sqlCom.CommandText = "select AllotedItemId from EmployeeAllotment where EmployeeAllotmentId=" +  id;
           
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static DataTable SelectPartIdForAssetAllotment(Int32 id)
        {
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.CommandText = "select AllotedItemId from AssetAllotment where AssetAllotmentId=" + id;

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
    }
}

