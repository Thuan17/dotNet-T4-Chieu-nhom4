using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DTO
{
    public class DB
    {
        string strSeverName, strDatabaseName, strUserName, strPwd, strConnection;
        readonly SqlConnection conn;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public SqlDataAdapter DA
        {
            get { return da; }
            set { da = value; }
        }
        public DataSet DS
        {
            get { return ds; }
            set { ds = value; }
        }

        public string StrConnection
        {
            get { return strConnection; }
            set { strConnection = value; }
        }

        public string StrPwd
        {
            get { return strPwd; }
            set { strPwd = value; }
        }

        public string StrDatabaseName
        {
            get { return strDatabaseName; }
            set { strDatabaseName = value; }
        }

        public string StrUserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        public string StrSeverName
        {
            get { return strSeverName; }
            set { strSeverName = value; }
        }

        public DB()
        {
            StrSeverName = @"LAPTOP-ALA9RHJO\SQLEXPRESS";
            StrDatabaseName = "QL_VeXe";
            StrUserName = "sa";
            StrPwd = "123";
            StrConnection = @"Data Source=" + StrSeverName + ";Initial Catalog=" + StrDatabaseName + ";User ID=" + StrUserName + ";Password=" + StrPwd;
            conn = new SqlConnection(strConnection);
        }

        public void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed) { conn.Open(); }
        }

        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open) { conn.Close(); }
        }

        public int ExecuteNoneQuery(string sql)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }

        public int GetCount_ExecuteScalar(string sql)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            return (int)cmd.ExecuteScalar();
        }

        public SqlDataReader Reader(string sql)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader r = cmd.ExecuteReader();
            return r;
        }

        public DataTable GetDataTable(string strSQL, string tableName)
        {
            if (ds.Tables[tableName] != null)
                ds.Tables[tableName].Clear();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            da.Fill(DS, tableName);
            return DS.Tables[tableName];
        }

        public SqlDataAdapter GetDataAdapter(string strSQL, string tableName)
        {
            OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            da.Fill(DS, tableName);
            return da;
        }




    }
}
