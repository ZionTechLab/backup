using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SEACC_PTS.NmsLogic
{
    public partial class DBHandling
    {
        public static string conn;

        public static string DBConnection
        {
            get { return DBHandling.conn; }
            set { DBHandling.conn = value; }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection scon = new SqlConnection();
            if (conn.Trim() != null)
            {
                scon = new SqlConnection(conn);
            }
            else
            {
                throw new Exception("Connection string was null");
            }
            return scon;
        }


        public static String ConnectionString
        {
            get
            {
                return conn;
            }
            set
            {
                if (value.Trim() != "")
                {
                    conn = value.Trim();
                }
                else
                {
                    throw new System.Exception("Connection string is null");
                }
            }
        }

        public static DataSet ExecQuery(string sQuery)
        {
            SqlConnection Sqlcon = new SqlConnection(DBHandling.ConnectionString);
            SqlDataAdapter Sqlda;
            DataSet ds = new DataSet();

            Sqlcon.Open();
            Sqlda = new SqlDataAdapter(sQuery, Sqlcon);
            Sqlda.Fill(ds);
            Sqlcon.Close();
            return (ds);
        }
    }
}
