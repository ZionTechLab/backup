using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityFunctionMaster_Report {
		#region Fields
		private int function_ID;
		private string displayName;
		private string displayName2;
		private string reportPath;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster_Report class.
		/// </summary>
		public tbl_securityFunctionMaster_Report() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster_Report class.
		/// </summary>
		public tbl_securityFunctionMaster_Report(int function_ID, string displayName, string displayName2, string reportPath) {
			this.function_ID = function_ID;
			this.displayName = displayName;
			this.displayName2 = displayName2;
			this.reportPath = reportPath;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Function_ID value.
		/// </summary>
		public int Function_ID {
			get { return function_ID; }
			set { function_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DisplayName value.
		/// </summary>
		public string DisplayName {
			get { return displayName; }
			set { displayName = value; }
		}
		
		/// <summary>
		/// Gets or sets the DisplayName2 value.
		/// </summary>
		public string DisplayName2 {
			get { return displayName2; }
			set { displayName2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportPath value.
		/// </summary>
		public string ReportPath {
			get { return reportPath; }
			set { reportPath = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityFunctionMaster_Report table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_ReportInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@displayName2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@reportPath", SqlDbType.VarChar,700);
 
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@displayName2"].Value = displayName2;
			scom.Parameters["@reportPath"].Value = reportPath;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityFunctionMaster_Report table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_ReportUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@displayName2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@reportPath", SqlDbType.VarChar,700);
 
 
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@displayName2"].Value = displayName2;
			scom.Parameters["@reportPath"].Value = reportPath;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityFunctionMaster_Report table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_ReportDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report table by a foreign key.
		/// </summary>
		public static void DeleteAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_ReportDeleteAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityFunctionMaster_Report table.
		/// </summary>
		public static tbl_securityFunctionMaster_Report Select(int function_ID_Incoming){

			tbl_securityFunctionMaster_Report tbl_securityFunctionMaster_Reportins = new tbl_securityFunctionMaster_Report();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_ReportSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityFunctionMaster_Reportins = Maketbl_securityFunctionMaster_Report(dataReader);
				} else {
					tbl_securityFunctionMaster_Reportins = null;
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Reportins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report table.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Report> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_ReportSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityFunctionMaster_Report> tbl_securityFunctionMaster_ReportList = new List<tbl_securityFunctionMaster_Report>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Report tbl_securityFunctionMaster_Report = Maketbl_securityFunctionMaster_Report(dataReader);
					tbl_securityFunctionMaster_ReportList.Add(tbl_securityFunctionMaster_Report);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_ReportList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Report table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Report> SelectAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_ReportSelectAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
				List<tbl_securityFunctionMaster_Report> tbl_securityFunctionMaster_ReportList = new List<tbl_securityFunctionMaster_Report>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Report tbl_securityFunctionMaster_Report = Maketbl_securityFunctionMaster_Report(dataReader);
					tbl_securityFunctionMaster_ReportList.Add(tbl_securityFunctionMaster_Report);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_ReportList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityFunctionMaster_Report class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityFunctionMaster_Report Maketbl_securityFunctionMaster_Report(SqlDataReader dataReader) {
			tbl_securityFunctionMaster_Report tbl_securityFunctionMaster_Report = new tbl_securityFunctionMaster_Report();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityFunctionMaster_Report.Function_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityFunctionMaster_Report.DisplayName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityFunctionMaster_Report.DisplayName2 = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityFunctionMaster_Report.ReportPath = dataReader.GetString(3);
			}

			return tbl_securityFunctionMaster_Report;
		}
		/// <summary>
		/// This makes tbl_securityFunctionMaster_Report datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster_Report object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityFunctionMaster_Report  tbl_securityFunctionMaster_Report   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_function_ID = new DataColumn("function_ID" , typeof(int));
			DataColumn col_displayName = new DataColumn("displayName" , typeof(string));
			DataColumn col_displayName2 = new DataColumn("displayName2" , typeof(string));
			DataColumn col_reportPath = new DataColumn("reportPath" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_function_ID,col_displayName,col_displayName2,col_reportPath,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityFunctionMaster_Report datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster_Report object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityFunctionMaster_Report user) {
		DataRow drow = dt.NewRow();
		
			drow["function_ID"] = user.function_ID;
			drow["displayName"] = user.displayName;
			drow["displayName2"] = user.displayName2;
			drow["reportPath"] = user.reportPath;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
