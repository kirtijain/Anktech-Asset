

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

    public class UserInfoProvider
    {
        /// <summary>
        /// insert information for apply leave
        /// </summary>
        /// <param name="objLeaveInfo">LeaveInfo type objLeaveInfo</param>
        /// <returns>returns no of affected rows</returns>
        public static int SaveData(UserInfo objUserInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "INSERT INTO Users (Name, UserName, Password, Email, UserContact,UserAddress,CreatedDate,IsActive,UserGuid) " +
            " VALUES( @Name, @UserName,@Password, @Email, @UserContact, @UserAddress,@CreatedDate,@IsActive,@UserGuid)";
          
            sqlCom.Parameters.Add("@Name", SqlDbType.VarChar).Value = objUserInfo.name;
            sqlCom.Parameters.Add("@UserName", SqlDbType.VarChar).Value = objUserInfo.userName;
            sqlCom.Parameters.Add("@Password", SqlDbType.VarChar).Value = objUserInfo.password;
            sqlCom.Parameters.Add("@Email", SqlDbType.VarChar).Value = objUserInfo.email;
            sqlCom.Parameters.Add("@UserContact", SqlDbType.VarChar).Value = objUserInfo.userContact;
            sqlCom.Parameters.Add("@UserAddress", SqlDbType.VarChar).Value = objUserInfo.userAddress;
            sqlCom.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objUserInfo.createdDate;
            sqlCom.Parameters.Add("@IsActive", SqlDbType.Bit).Value = objUserInfo.isActive;
            sqlCom.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = objUserInfo.userGuid;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static int UpdateUserData(UserInfo objUserInfo, int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "UPDATE Users SET Name=@Name, UserName=@UserName,Email=@Email, Password= @Password,UserContact= @UserContact,UserAddress=@UserAddress,ModifiedDate=@ModifiedDate,IsActive=@IsActive where UserId=" + id;

            sqlCom.Parameters.Add("@Name", SqlDbType.VarChar).Value = objUserInfo.name;
            sqlCom.Parameters.Add("@UserName", SqlDbType.VarChar).Value = objUserInfo.userName;
            sqlCom.Parameters.Add("@Email", SqlDbType.VarChar).Value = objUserInfo.email;
            sqlCom.Parameters.Add("@Password", SqlDbType.VarChar).Value = objUserInfo.password;
            sqlCom.Parameters.Add("@UserContact", SqlDbType.VarChar).Value = objUserInfo.userContact;
            sqlCom.Parameters.Add("@UserAddress", SqlDbType.VarChar).Value = objUserInfo.userAddress;
          
            sqlCom.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Now;
            
            sqlCom.Parameters.Add("@IsActive", SqlDbType.Bit).Value = 1;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }
        public static DataTable LoginData(UserInfo objUserInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from Users where UserName =@username and Password=@password and IsActive=1";
            sqlCom.Parameters.AddWithValue("@username", objUserInfo.userName);
            sqlCom.Parameters.AddWithValue("@password", objUserInfo.password);
            DataTable ds=DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
        public static DataTable IsUsernameEmailExist(UserInfo objUserInfo)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select Email,UserName from Users where UserName =@username and email=@Email";
            sqlCom.Parameters.AddWithValue("@username", objUserInfo.userName);
            sqlCom.Parameters.AddWithValue("@email", objUserInfo.email);
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }
        public static int ActivationData(Guid UserGuid)
        {
            SqlCommand cmd = new SqlCommand();
            //{   //approve account by setting Is_Active to 1 i.e. True in the sql server table
                cmd.CommandText = "UPDATE Users SET IsActive=1 WHERE UserGuid=@UserGuid";
                cmd.Parameters.Add("@UserGuid", SqlDbType.UniqueIdentifier).Value = UserGuid;
                //cmd.Parameters.AddWithValue("@UserGuid", Request.QueryString["UserGuid"]);
                int affectedRows = DatabaseConnection.RunSql(cmd);
                cmd.CommandType = CommandType.Text;
                return affectedRows;
            //}
        }
        public static DataTable ForgotPassword(UserInfo objUserInfo)
        {
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.CommandText = "select Name,Password,UserName from Users where Email=@Email";
            
            sqlCom.Parameters.AddWithValue("@Email", objUserInfo.email);
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;

        }
        public static DataTable ChangePasswordData(UserInfo objUserInfo)
        {
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.CommandText = "select * from Users where Password=@Password";

            sqlCom.Parameters.AddWithValue("@Password", objUserInfo.password);
            DataTable dt = DatabaseConnection.RunSqlReturnData(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return dt;
        }

        public static int UpdatePassword(UserInfo objUserInfo)
        {
            SqlCommand cmd = new SqlCommand();

            //{   //approve account by setting Is_Approved to 1 i.e. True in the sql server table
            cmd.CommandText = "UPDATE Users SET Password=@NewPassword WHERE Password=@Password";
            cmd.Parameters.Add("@NewPassword", SqlDbType.VarChar).Value = objUserInfo.newPassword;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = objUserInfo.password;
            int affectedRows = DatabaseConnection.RunSql(cmd);
            cmd.CommandType = CommandType.Text;
            return affectedRows;
            //}
        }

        public static DataSet ViewUserInfo()
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from Users Where IsActive='True' and UserName NOT IN('admin.anktech')";
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }
        public static DataSet LoadUserInfo(int id)
        {
            //  int AssetId = Convert.ToInt16(id);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "select * from Users where UserId=" + id;
            DataSet ds = DatabaseConnection.RunSqlReturnDataWithDataset(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return ds;
        }

        public static int DeactivateUserData(int id)
        {
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.CommandText = "Update Users set IsActive='False' where UserId=" + id;

            //  sqlCom.Parameters.Add("@AssetName", SqlDbType.VarChar).Value = objAssetInfo.assetName;
            int affectedRows = DatabaseConnection.RunSql(sqlCom);
            sqlCom.CommandType = CommandType.Text;
            return affectedRows;
        }

    }
}
