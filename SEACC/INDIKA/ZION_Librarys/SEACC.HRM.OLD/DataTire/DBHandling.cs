using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DataTire
{
    public partial class DBHandling
    {
        public static string conn;
        private static string username;
        private static string password;
        
        public static string Password
        {
            get { return DBHandling.password; }
            set { DBHandling.password = value; }
        }

        public static string DBConnection
        {
            get { return DBHandling.conn; }
            set { DBHandling.conn = value; }
        }
        public static string Username
        {
            get { return DBHandling.username; }
            set { DBHandling.username = value; }
        }

        #region Connection



        public static String ConnectionString
        {
            get
            {
                return conn;
            }
            set
            {
                if (value.Trim() != "")
                    conn = value.Trim();
                else
                    throw new System.Exception("Connection string is null");
            }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection scon = new SqlConnection();
            if (conn.Trim() != null)
                scon = new SqlConnection(conn);
            else
                throw new Exception("Connection string was null");

            return scon;
        }
        #endregion

        public static DataSet ExecQuery(string sQuery)
        {
            SqlConnection Sqlcon = new SqlConnection(DBHandling.ConnectionString);
            SqlDataAdapter Sqlda;
            DataSet ds = new DataSet();

            Sqlcon.Open();
            Sqlda = new SqlDataAdapter(sQuery, Sqlcon);
            // set the CommandTimeout
            Sqlda.SelectCommand.CommandTimeout = 300;  // seconds

            Sqlda.Fill(ds);
            Sqlcon.Close();
            return (ds);
        }

        public static string ExecQuery_ReturnStringValue(string sQuery)
        {
            string returnValue = "";
            if (sQuery != "" && sQuery.Length > 0)
            {
                SqlConnection Sqlcon = new SqlConnection(DBHandling.ConnectionString);               
                SqlCommand Sqlcmd = new SqlCommand(sQuery, Sqlcon);
                Sqlcon.Open();
                object oQuaryResalt = Sqlcmd.ExecuteScalar();
                returnValue = oQuaryResalt != null ? oQuaryResalt.ToString() : "-";             
                Sqlcon.Close();
                
            }
            return returnValue;
        }

        public static bool ExecQuery_ReturnBoolValue(string sQuery)
        {
            bool returnValue = false;
            if (sQuery != "" && sQuery.Length > 0)
            {
                SqlConnection Sqlcon = new SqlConnection(DBHandling.ConnectionString);
                SqlCommand Sqlcmd = new SqlCommand(sQuery, Sqlcon);
                Sqlcon.Open();
                object oQuaryResalt = Sqlcmd.ExecuteScalar();
                returnValue = oQuaryResalt != null ? true : false;
                Sqlcon.Close();

            }
            return returnValue;
        }

        public static decimal ExecQuery_ReturnDecimal(string sQuery)
        {
            decimal returnValue = 0;
            if (sQuery != "" && sQuery.Length > 0)
            {
                SqlConnection Sqlcon = new SqlConnection(DBHandling.ConnectionString);
                SqlCommand Sqlcmd = new SqlCommand(sQuery, Sqlcon);
                Sqlcon.Open();

                SqlDataReader reader = Sqlcmd.ExecuteReader();
                if (reader.HasRows == true)
                    if (reader.Read())
                        returnValue = reader.GetDecimal(0);

                Sqlcon.Close();
            }
            return returnValue;
        }

        #region Date

        ///// <summary>
        ///// Return System Dates 
        ///// </summary>
        ///// <param name="DateType">If 1 returns currentdate,if 2 returns start date, othewise returns enddate</param>
        ///// <returns>Datetime</returns>
        //public static DateTime GetPuticulerDate()
        //{
        //    DateTime dte = DateTime.Now;
        //    return dte;
        //}

        ///// <summary>
        ///// Return System Date 
        ///// </summary>
        ///// <param name="withformat">If want to format the date like "01/02/2007" make this true otherwise returns "1/2/2007"</param>
        ///// <returns></returns>
        //public static string GetPuticulerDate(bool withformat)
        //{
        //    string str = "";
        //    DateTime dte = DateTime.Now;

        //    if (withformat == true)
        //    {
        //        str = dte.Month.ToString("00") + "/" + dte.Day.ToString("00") + "/" + dte.Year.ToString("0000");
        //    }
        //    else
        //    {
        //        str = dte.ToShortDateString();
        //    }
        //    return str;
        //}

        ///// <summary>
        ///// Use this to get curent system date on server
        ///// </summary>
        //// <param name="withformat">If want to format the date like "01:02:15" make this true otherwise returns "1:2:15"</param>
        ///// <returns></returns>
        //public static string GetPuticulerTime(bool withformat)
        //{
        //    string str = "";
        //    DateTime dte = DateTime.Now;

        //    if (withformat == true)
        //    {
        //        str = dte.Hour.ToString("00") + ":" + dte.Minute.ToString("00") + ":" + dte.Second.ToString("00");
        //    }
        //    else
        //    {
        //        str = dte.ToShortTimeString();
        //    }
        //    return str;
        //}

        #endregion

        public void ReadDB()
        {
            throw new System.NotImplementedException();
        }

        public void CreateDataset()
        {
            throw new System.NotImplementedException();
        }
    }
}