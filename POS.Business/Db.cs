using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace POS.Business
{
    public class Db
    {
        #region "Declurations"

        SqlConnection SqlConn;
        SqlCommand SqlCmd;
        SqlDataAdapter SqlDataAdapter;
        DataSet ds;

        #endregion

        #region "Properties"
        public string sqlConString;

        public string  SqlConString
        {
            get { return sqlConString; }
            set { sqlConString = value; }
        }

        public CommandType sqlCmdType;

        public CommandType  SqlCmdType
        {
            get { return sqlCmdType; }
            set { sqlCmdType = value; }
        }

        public string sqlCmdText;

        public string  SqlCmdText
        {
            get { return sqlCmdText; }
            set { sqlCmdText = value; }
        }

        public string tableName;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }


        #endregion

        #region "Functions"

        public void SqlConnectionOpen()
        {
            SqlConn = new SqlConnection();
            SqlConn.ConnectionString = this.sqlConString;
            SqlConn.Open();
        }

        public void CloseConnection()
        {
            if (SqlConn.State == ConnectionState.Open)
                SqlConn.Close();
        }

        public void InsertRecords(params object[] Parameters)
        {

        }

        

        #endregion
    }
}
