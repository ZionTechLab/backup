using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_atlProcess_Print_Reports {
		#region Fields
		private Int64 transaction_ID;
		private string report_ID;
		private DateTime printDate;
		private string user_ID;
		private string terminal_ID;
		private int activity;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_atlProcess_Print_Reports class.
		/// </summary>
		public tbl_atlProcess_Print_Reports() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlProcess_Print_Reports class.
		/// </summary>
		public tbl_atlProcess_Print_Reports(string report_ID, DateTime printDate, string user_ID, string terminal_ID, int activity) {
			this.report_ID = report_ID;
			this.printDate = printDate;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
			this.activity = activity;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlProcess_Print_Reports class.
		/// </summary>
		public tbl_atlProcess_Print_Reports(Int64 transaction_ID, string report_ID, DateTime printDate, string user_ID, string terminal_ID, int activity) {
			this.transaction_ID = transaction_ID;
			this.report_ID = report_ID;
			this.printDate = printDate;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
			this.activity = activity;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public Int64 Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Report_ID value.
		/// </summary>
		public string Report_ID {
			get { return report_ID; }
			set { report_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintDate value.
		/// </summary>
		public DateTime PrintDate {
			get { return printDate; }
			set { printDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Activity value.
		/// </summary>
		public int Activity {
			get { return activity; }
			set { activity = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_atlProcess_Print_Reports table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_Print_ReportsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@activity", SqlDbType.Int,4);
 
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@printDate"].Value = printDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@activity"].Value = activity;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_atlProcess_Print_Reports table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_Print_ReportsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@activity", SqlDbType.Int,4);
 
 
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@printDate"].Value = printDate;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@activity"].Value = activity;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_atlProcess_Print_Reports table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_Print_ReportsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt, 8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_atlProcess_Print_Reports table.
		/// </summary>
		public static tbl_atlProcess_Print_Reports Select(Int64 transaction_ID_Incoming){

			tbl_atlProcess_Print_Reports tbl_atlProcess_Print_Reportsins = new tbl_atlProcess_Print_Reports();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_Print_ReportsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt, 8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_atlProcess_Print_Reportsins = Maketbl_atlProcess_Print_Reports(dataReader);
				} else {
					tbl_atlProcess_Print_Reportsins = null;
				}
			}
			scon.Close();
			return tbl_atlProcess_Print_Reportsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlProcess_Print_Reports table.
		/// </summary>
		public static List<tbl_atlProcess_Print_Reports> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlProcess_Print_ReportsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_atlProcess_Print_Reports> tbl_atlProcess_Print_ReportsList = new List<tbl_atlProcess_Print_Reports>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlProcess_Print_Reports tbl_atlProcess_Print_Reports = Maketbl_atlProcess_Print_Reports(dataReader);
					tbl_atlProcess_Print_ReportsList.Add(tbl_atlProcess_Print_Reports);
				}
			}
			scon.Close();
			return tbl_atlProcess_Print_ReportsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_atlProcess_Print_Reports class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_atlProcess_Print_Reports Maketbl_atlProcess_Print_Reports(SqlDataReader dataReader) {
			tbl_atlProcess_Print_Reports tbl_atlProcess_Print_Reports = new tbl_atlProcess_Print_Reports();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_atlProcess_Print_Reports.Transaction_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_atlProcess_Print_Reports.Report_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_atlProcess_Print_Reports.PrintDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_atlProcess_Print_Reports.User_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_atlProcess_Print_Reports.Terminal_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_atlProcess_Print_Reports.Activity = dataReader.GetInt32(5);
			}

			return tbl_atlProcess_Print_Reports;
		}
		/// <summary>
		/// This makes tbl_atlProcess_Print_Reports datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_atlProcess_Print_Reports object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_atlProcess_Print_Reports  tbl_atlProcess_Print_Reports   )
		{
		DataTable dt = new DataTable();

        DataColumn col_transaction_ID = new DataColumn("transaction_ID", typeof(Int64));
			DataColumn col_report_ID = new DataColumn("report_ID" , typeof(string));
			DataColumn col_printDate = new DataColumn("printDate" , typeof(DateTime));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_activity = new DataColumn("activity" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_transaction_ID,col_report_ID,col_printDate,col_user_ID,col_terminal_ID,col_activity,});		return dt;
		}
		/// <summary>
		/// This fills tbl_atlProcess_Print_Reports datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_atlProcess_Print_Reports object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_atlProcess_Print_Reports user) {
		DataRow drow = dt.NewRow();
		
			drow["transaction_ID"] = user.transaction_ID;
			drow["report_ID"] = user.report_ID;
			drow["printDate"] = user.printDate;
			drow["user_ID"] = user.user_ID;
			drow["terminal_ID"] = user.terminal_ID;
			drow["activity"] = user.activity;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
