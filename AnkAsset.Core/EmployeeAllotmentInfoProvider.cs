

namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;
    using System.Data.SqlClient;
    using System.Data;

    public class EmployeeAllotmentInfoProvider
    {
        /// <summary>
        /// insert information for apply leave
        /// </summary>
        /// <param name="objLeaveInfo">LeaveInfo type objLeaveInfo</param>
        /// <returns>returns no of affected rows</returns>
        public static int SaveEmployeeAllotmentData(EmployeeAllotmentInfo objEmployeeAllotmentInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "INSERT INTO EmployeeAllotment (Id,AllotedModelNo,AllotedSerialNo,AllotedItemId,CreatedDate) " +
            " VALUES(@Id,@AllotedModelNo,@AllotedSerialNo, @AllotedItemId,@CreatedDate)";

            sqlCom.Parameters.Add("@Id", SqlDbType.Int).Value = objEmployeeAllotmentInfo.Id;
           // sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.Int).Value = objEmployeeAllotmentInfo.AssetTypeId;
            //sqlCom.Parameters.Add("@LastName", SqlDbType.VarChar).Value = objEmployeeInfo.LastName;
            sqlCom.Parameters.Add("@AllotedModelNo", SqlDbType.VarChar).Value = objEmployeeAllotmentInfo.allotedModelNo;
            sqlCom.Parameters.Add("@AllotedSerialNo", SqlDbType.VarChar).Value = objEmployeeAllotmentInfo.allotedSerialNo;
            sqlCom.Parameters.Add("@AllotedItemId", SqlDbType.Int).Value = objEmployeeAllotmentInfo.allotedItemId;

            sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objEmployeeAllotmentInfo.createdDate;
            
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static int UpdateEmployeeAllotmentData(EmployeeAllotmentInfo objEmployeeAllotmentInfo, int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE EmployeeAllotment SET Id=@Id,AllotedItemId=@AllotedItemId,AllotedModelNo=@AllotedModelNo,AllotedSerialNo=@AllotedSerialNo,ModifiedDate=@ModifiedDate where EmployeeAllotmentId=" + id;
            sqlCom.Parameters.Add("@Id", SqlDbType.Int).Value = objEmployeeAllotmentInfo.Id;
            // sqlCom.Parameters.Add("@AssetTypeId", SqlDbType.Int).Value = objEmployeeAllotmentInfo.AssetTypeId;
            //sqlCom.Parameters.Add("@LastName", SqlDbType.VarChar).Value = objEmployeeInfo.LastName;
            sqlCom.Parameters.Add("@AllotedModelNo", SqlDbType.VarChar).Value = objEmployeeAllotmentInfo.allotedModelNo;
            sqlCom.Parameters.Add("@AllotedSerialNo", SqlDbType.VarChar).Value = objEmployeeAllotmentInfo.allotedSerialNo;
            sqlCom.Parameters.Add("@AllotedItemId", SqlDbType.Int).Value = objEmployeeAllotmentInfo.allotedItemId;


            sqlCom.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;

          
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
       
        public static DataTable GetEmployeeInfo(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            if (id == 0)
            {
                sqlCom.CommandText = "select * from Employee Where IsActive='True'";
            }
            else 
            {
                sqlCom.CommandText = "select * from Employee Where Id="+id;
            }
                DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static DataSet ViewEmployeeAllotmentInfo(int empid)
        {
            SqlCommand sqlCom = new SqlCommand();
            if (empid == 0)
            {
                sqlCom.CommandText = "select * from EmployeeAllotment,Employee,AssetPart where EmployeeAllotment.Id=Employee.Id and AssetPart.AssetPartId=EmployeeAllotment.AllotedItemId";
            }
            else 
            {
                sqlCom.CommandText = "select * from EmployeeAllotment,Employee,AssetPart where EmployeeAllotment.Id=Employee.Id and AssetPart.AssetPartId=EmployeeAllotment.AllotedItemId and Employee.EmpId="+empid;
            }
                DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
       
        public static int DeactivateEmployeeAllotmentData(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "Delete from EmployeeAllotment where EmployeeAllotmentId=" + id;

            //  sqlCom.Parameters.Add("@AssetName", SqlDbType.VarChar).Value = objAssetInfo.assetName;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

        //public static DataTable GetBillNo(Int32 id)
        //{
        //    SqlCommand sqlCom = new SqlCommand();

        //    sqlCom.CommandText = "select BillNo,AssetTypeId,AssetId from Asset where AssetTypeId=" + id;

        //    DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
        //    sqlCom.CommandType = CommandType.Text;
        //    return dt;
        //}
        public static DataTable GetModelNo(Int32 id)
        {
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.CommandText = "select distinct PartModelNo,AssetTypeId from AssetPart where AssetTypeId=" + id;

            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static DataTable LoadEmployeeAllotmentInfo(int id)
        {
            //  int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select ea.*,a.PartName,e.*,lap.AssetTypeName,lap.AssetTypeId from EmployeeAllotment ea join AssetPart a on a.AssetPartId=ea.AllotedItemId join Employee e on e.Id=ea.Id join LookupAssetType lap on lap.AssetTypeId=a.AssetTypeId  where EmployeeAllotmentId=" + id;
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
    }
}
