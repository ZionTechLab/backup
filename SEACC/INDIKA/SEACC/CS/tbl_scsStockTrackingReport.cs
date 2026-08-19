using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using Digiteq_Inventory;

namespace DataTire
{
    public sealed class tbl_scsStockTrackingReport
    {
        #region Fields
        private DateTime firstDate;
        private DateTime fromDate;
        private string storeID;
        private string ItemCode;
        private string itemCategoryID;
        #endregion

        #region BackupMethods
        public void ExecuteQuery(DateTime firstDate, DateTime fromDate, string sStoreID, string sItemCode, string sitemCategoryID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand command = new SqlCommand("sp_StockTrackingReportExecution", scon);
            command.CommandType = CommandType.StoredProcedure;
            
            command.CommandTimeout = 600;

            command.Parameters.Add("@firstDate", SqlDbType.DateTime).Value = firstDate;
            command.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromDate;
            command.Parameters.Add("@storeID", SqlDbType.VarChar).Value = sStoreID;
            command.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = sItemCode;
            command.Parameters.Add("@itemCategoryID", SqlDbType.VarChar).Value = sitemCategoryID;
            scon.Open();

            command.ExecuteNonQuery();
            scon.Close();
        }
        #endregion

        public static List<tbl_scsStockTrackingReport> SelectAll(DateTime firstDate, DateTime fromDate, string sStoreID, string sItemCode, string sitemCategoryID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@firstDate", SqlDbType.DateTime).Value = firstDate;
            scom.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromDate;
            scom.Parameters.Add("@storeID", SqlDbType.VarChar).Value = sStoreID;
            scom.Parameters.Add("@ItemCode", SqlDbType.VarChar).Value = sItemCode;
            scom.Parameters.Add("@itemCategoryID", SqlDbType.VarChar).Value = sitemCategoryID;

            //scom.Parameters["@firstDate"].Value = accountPayableNote_ID_Incoming;
            List<tbl_scsStockTrackingReport> tbl_scsStockTrackingReportList = new List<tbl_scsStockTrackingReport>();

            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_scsStockTrackingReport tbl_scsStockTrackingReport = Maketbl_scsStockTrackingReport(dataReader);
                    tbl_scsStockTrackingReportList.Add(tbl_scsStockTrackingReport);
                }
                //if (dataReader.Read())
                //{
                //    tbl_scsStockTrackingReport = Maketbl_accAccountPayableNote(dataReader);
                //}
                //else
                //{
                //    tbl_scsStockTrackingReport = null;
                //}
            }
            scon.Close();
            return tbl_scsStockTrackingReportList;
        }

        private static tbl_scsStockTrackingReport Maketbl_scsStockTrackingReport(SqlDataReader dataReader)
        {
            tbl_scsStockTrackingReport tbl_scsStockTrackingReport = new tbl_scsStockTrackingReport();

            if (dataReader.IsDBNull(0) == false)
            {
                tbl_scsStockTrackingReport.firstDate = dataReader.GetDateTime(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                tbl_scsStockTrackingReport.fromDate = dataReader.GetDateTime(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                tbl_scsStockTrackingReport.storeID = dataReader.GetString(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                tbl_scsStockTrackingReport.ItemCode = dataReader.GetString(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                tbl_scsStockTrackingReport.itemCategoryID = dataReader.GetString(4);
            }          

            return tbl_scsStockTrackingReport;
        }

    }
}


