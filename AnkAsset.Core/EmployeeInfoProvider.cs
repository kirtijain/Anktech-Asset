

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

    public class EmployeeInfoProvider
    {
        /// <summary>
        /// insert information for apply leave
        /// </summary>
        /// <param name="objLeaveInfo">LeaveInfo type objLeaveInfo</param>
        /// <returns>returns no of affected rows</returns>
        public static int SaveEmployeeData(EmployeeInfo objEmployeeInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "INSERT INTO Employee (EmpId,EmployeeName,EmailId, ContactNo,Address,CreatedDate,IsActive) " +
            " VALUES(@EmpId,@EmployeeName,@EmailId, @ContactNo, @Address,@CreatedDate,@IsActive)";

            sqlCom.Parameters.Add("@EmpId", SqlDbType.Int).Value = objEmployeeInfo.EmpId;
            sqlCom.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = objEmployeeInfo.EmployeeName;
            //sqlCom.Parameters.Add("@LastName", SqlDbType.VarChar).Value = objEmployeeInfo.LastName;
            sqlCom.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = objEmployeeInfo.EmailId;
            sqlCom.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = objEmployeeInfo.ContactNo;
            sqlCom.Parameters.Add("@Address", SqlDbType.VarChar).Value = objEmployeeInfo.Address;
          
            sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objEmployeeInfo.CreatedDate;
            sqlCom.Parameters.Add("@IsActive", SqlDbType.Bit).Value = objEmployeeInfo.IsActive;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static int UpdateEmployeeData(EmployeeInfo objEmployeeInfo, int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE Employee SET EmpId=@EmpId,EmployeeName=@EmployeeName,EmailId=@EmailId,ContactNo= @ContactNo,Address=@Address,ModifiedDate=@ModifiedDate,IsActive=@IsActive where Id=" + id;
            sqlCom.Parameters.Add("@EmpId", SqlDbType.Int).Value = objEmployeeInfo.EmpId;
            sqlCom.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = objEmployeeInfo.EmployeeName;
           // sqlCom.Parameters.Add("@LastName", SqlDbType.VarChar).Value = objEmployeeInfo.LastName;
            sqlCom.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = objEmployeeInfo.EmailId;
            sqlCom.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = objEmployeeInfo.ContactNo;
            sqlCom.Parameters.Add("@Address", SqlDbType.VarChar).Value = objEmployeeInfo.Address;
          
            sqlCom.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
            
            sqlCom.Parameters.Add("@IsActive", SqlDbType.Bit).Value = 1;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        //public static DataTable LoginData(UserInfo objUserInfo)
        //{
        //    SqlCommand sqlCom = new SqlCommand();
        //    sqlCom.CommandText = "select * from Users where UserName =@username and Password=@password and IsActive=1";
        //    sqlCom.Parameters.AddWithValue("@username", objUserInfo.userName);
        //    sqlCom.Parameters.AddWithValue("@password", objUserInfo.password);
        //    DataTable ds=DatabaseConnection.RunSqlReturnData(sqlCom);
        //    sqlCom.CommandType = CommandType.Text;
        //    return ds;
        //}
       
        public static DataSet ViewEmployeeInfo()
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from Employee Where IsActive='True'";
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
        public static DataSet LoadEmployeeInfo(int id)
        {
            //  int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from Employee where Id=" + id;
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }

        public static int DeactivateEmployeeData(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "Update Employee set IsActive='False' where Id=" + id;

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
       
        
    }
}
