// ----------------------------------------------------------------
// <copyright file="DatabaseConnection.cs" company="Anktech">
// Copyright 2015
// </copyright>
// ----------------------------------------------------------------

namespace AnkAsset.Data
{

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DatabaseConnection
    {

        /// <summary>
        /// Gets string type DataConnection
        /// </summary>
        public static string DataConnection
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
            }
        }

        /// <summary>
        /// method for inserting values into database
        /// </summary>
        /// <param name="insertCommand">SqlCommand type insertCommand</param>
        /// <returns>number of affected rows</returns>
        public static int RunSql(SqlCommand insertCommand)
        {
            int affectedRows = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = DataConnection;
            insertCommand.Connection = con;
            con.Open();
            affectedRows = insertCommand.ExecuteNonQuery();
            con.Close();

            return affectedRows;
        }

        /// <summary>
        /// Runs a SQL query, returning the affected row's id.
        /// </summary>
        /// <param name="sql">The SQL command</param>
        /// <returns>The id of the affected row</returns>
        public static int RunSqlReturnId(SqlCommand sql)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = DataConnection;
            sql.Connection = connection;
            connection.Open();

            sql.ExecuteNonQuery();

            // Return the ID
            DataTable row = new DataTable();

            // TODO: Is this safe? Should we use SELECT SCOPE_IDENTITY()
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT @@IDENTITY", connection);

            adapt.Fill(row);
            connection.Close();

            // Return ID
            return Convert.ToInt32(row.Rows[0][0]);
        }

        /// <summary>
        /// method for getting values from database to DataTable
        /// </summary>
        /// <param name="selectCommand">SqlCommand type selectCommand</param>
        /// <returns>returns data table</returns>
        public static DataTable RunSqlReturnData(SqlCommand selectCommand)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = DataConnection;
            selectCommand.Connection = con;
            SqlDataAdapter sqlDa = new SqlDataAdapter(selectCommand);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);
            return dt;
        }

        /// <summary>
        /// establish connection with database
        /// </summary>
        /// <param name="selectCommand">SqlCommand type selectCommand</param>
        /// <returns>returns dataset</returns>
        public static DataSet RunSqlReturnDataWithDataset(SqlCommand selectCommand)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = DataConnection;
            selectCommand.Connection = con;
            SqlDataAdapter sqlDa = new SqlDataAdapter(selectCommand);
            DataSet ds = new DataSet();
            sqlDa.Fill(ds);

            return ds;
        }

        /// <summary>
        /// establish connection with database
        /// </summary>
        /// <param name="SQL">string SQL</param>
        /// <returns>return SqlDataReader</returns>
        public static SqlDataReader RunSqlReturnDataReader(string SQL)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = DataConnection;

            SqlDataReader retDtr = null;

            con.Open();

            SqlCommand cmd = new SqlCommand(SQL, con);

            retDtr = cmd.ExecuteReader();

            return retDtr;
        }    
    }
}