using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_rbInsReportItem_Settings {
		#region Fields
		private string gl_ID;
		private string reportItem_ID;
		private bool isDisplay;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsReportItem_Settings class.
		/// </summary>
		public tbl_rbInsReportItem_Settings() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsReportItem_Settings class.
		/// </summary>
		public tbl_rbInsReportItem_Settings(string gl_ID, string reportItem_ID, bool isDisplay) {
			this.gl_ID = gl_ID;
			this.reportItem_ID = reportItem_ID;
			this.isDisplay = isDisplay;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportItem_ID value.
		/// </summary>
		public string ReportItem_ID {
			get { return reportItem_ID; }
			set { reportItem_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDisplay value.
		/// </summary>
		public bool IsDisplay {
			get { return isDisplay; }
			set { isDisplay = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_rbInsReportItem_Settings table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItem_SettingsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
			scom.Parameters["@isDisplay"].Value = isDisplay;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_rbInsReportItem_Settings table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItem_SettingsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
 
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
			scom.Parameters["@isDisplay"].Value = isDisplay;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_rbInsReportItem_Settings table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItem_SettingsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbInsReportItem_Settings table by a foreign key.
		/// </summary>
		public static void DeleteAllByReportItem_ID(string reportItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItem_SettingsDeleteAllByReportItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_rbInsReportItem_Settings table.
		/// </summary>
		public static tbl_rbInsReportItem_Settings Select(string gl_ID_Incoming, string reportItem_ID_Incoming){

			tbl_rbInsReportItem_Settings tbl_rbInsReportItem_Settingsins = new tbl_rbInsReportItem_Settings();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItem_SettingsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_rbInsReportItem_Settingsins = Maketbl_rbInsReportItem_Settings(dataReader);
				} else {
					tbl_rbInsReportItem_Settingsins = null;
				}
			}
			scon.Close();
			return tbl_rbInsReportItem_Settingsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbInsReportItem_Settings table.
		/// </summary>
		public static List<tbl_rbInsReportItem_Settings> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItem_SettingsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_rbInsReportItem_Settings> tbl_rbInsReportItem_SettingsList = new List<tbl_rbInsReportItem_Settings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbInsReportItem_Settings tbl_rbInsReportItem_Settings = Maketbl_rbInsReportItem_Settings(dataReader);
					tbl_rbInsReportItem_SettingsList.Add(tbl_rbInsReportItem_Settings);
				}
			}
			scon.Close();
			return tbl_rbInsReportItem_SettingsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbInsReportItem_Settings table by a foreign key.
		/// </summary>
		public static List<tbl_rbInsReportItem_Settings> SelectAllByReportItem_ID(string reportItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItem_SettingsSelectAllByReportItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
				List<tbl_rbInsReportItem_Settings> tbl_rbInsReportItem_SettingsList = new List<tbl_rbInsReportItem_Settings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbInsReportItem_Settings tbl_rbInsReportItem_Settings = Maketbl_rbInsReportItem_Settings(dataReader);
					tbl_rbInsReportItem_SettingsList.Add(tbl_rbInsReportItem_Settings);
				}
			}
			scon.Close();
			return tbl_rbInsReportItem_SettingsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_rbInsReportItem_Settings class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_rbInsReportItem_Settings Maketbl_rbInsReportItem_Settings(SqlDataReader dataReader) {
			tbl_rbInsReportItem_Settings tbl_rbInsReportItem_Settings = new tbl_rbInsReportItem_Settings();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_rbInsReportItem_Settings.Gl_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_rbInsReportItem_Settings.ReportItem_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_rbInsReportItem_Settings.IsDisplay = dataReader.GetBoolean(2);
			}

			return tbl_rbInsReportItem_Settings;
		}
		/// <summary>
		/// This makes tbl_rbInsReportItem_Settings datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_rbInsReportItem_Settings object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_rbInsReportItem_Settings  tbl_rbInsReportItem_Settings   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_reportItem_ID = new DataColumn("reportItem_ID" , typeof(string));
			DataColumn col_isDisplay = new DataColumn("isDisplay" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_gl_ID,col_reportItem_ID,col_isDisplay,});		return dt;
		}
		/// <summary>
		/// This fills tbl_rbInsReportItem_Settings datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_rbInsReportItem_Settings object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_rbInsReportItem_Settings user) {
		DataRow drow = dt.NewRow();
		
			drow["gl_ID"] = user.gl_ID;
			drow["reportItem_ID"] = user.reportItem_ID;
			drow["isDisplay"] = user.isDisplay;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
