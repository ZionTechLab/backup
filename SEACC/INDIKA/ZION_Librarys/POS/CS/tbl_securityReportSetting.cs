using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityReportSetting {
		#region Fields
		private string report_ID;
		private string user_ID;
		private string printer_ID;
		private string paper_ID;
		private string terminal_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityReportSetting class.
		/// </summary>
		public tbl_securityReportSetting() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityReportSetting class.
		/// </summary>
		public tbl_securityReportSetting(string report_ID, string user_ID, string printer_ID, string paper_ID, string terminal_ID, bool isActive) {
			this.report_ID = report_ID;
			this.user_ID = user_ID;
			this.printer_ID = printer_ID;
			this.paper_ID = paper_ID;
			this.terminal_ID = terminal_ID;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Report_ID value.
		/// </summary>
		public string Report_ID {
			get { return report_ID; }
			set { report_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Printer_ID value.
		/// </summary>
		public string Printer_ID {
			get { return printer_ID; }
			set { printer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Paper_ID value.
		/// </summary>
		public string Paper_ID {
			get { return paper_ID; }
			set { paper_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityReportSetting table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printer_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paper_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@printer_ID"].Value = printer_ID;
			scom.Parameters["@paper_ID"].Value = paper_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityReportSetting table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printer_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paper_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@printer_ID"].Value = printer_ID;
			scom.Parameters["@paper_ID"].Value = paper_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityReportSetting table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printer_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paper_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@report_ID"].Value = report_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@printer_ID"].Value = printer_ID;
 
			scom.Parameters["@paper_ID"].Value = paper_ID;
 
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table by a foreign key.
		/// </summary>
		public static void DeleteAllByReport_ID(string report_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingDeleteAllByReport_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table by a foreign key.
		/// </summary>
		public static void DeleteAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingDeleteAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table by a foreign key.
		/// </summary>
		public static void DeleteAllByPaper_ID(string paper_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingDeleteAllByPaper_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paper_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paper_ID"].Value = paper_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table by a foreign key.
		/// </summary>
		public static void DeleteAllByPrinter_ID(string printer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingDeleteAllByPrinter_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printer_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printer_ID"].Value = printer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityReportSetting table.
		/// </summary>
		public static tbl_securityReportSetting Select(string report_ID_Incoming, string user_ID_Incoming, string printer_ID_Incoming, string paper_ID_Incoming, string terminal_ID_Incoming){

			tbl_securityReportSetting tbl_securityReportSettingins = new tbl_securityReportSetting();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printer_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paper_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@report_ID"].Value = report_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@printer_ID"].Value = printer_ID_Incoming;
			scom.Parameters["@paper_ID"].Value = paper_ID_Incoming;
			scom.Parameters["@terminal_ID"].Value = terminal_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityReportSettingins = Maketbl_securityReportSetting(dataReader);
				} else {
					tbl_securityReportSettingins = null;
				}
			}
			scon.Close();
			return tbl_securityReportSettingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table.
		/// </summary>
		public static List<tbl_securityReportSetting> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityReportSetting> tbl_securityReportSettingList = new List<tbl_securityReportSetting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportSetting tbl_securityReportSetting = Maketbl_securityReportSetting(dataReader);
					tbl_securityReportSettingList.Add(tbl_securityReportSetting);
				}
			}
			scon.Close();
			return tbl_securityReportSettingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportSetting> SelectAllByReport_ID(string report_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingSelectAllByReport_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
				List<tbl_securityReportSetting> tbl_securityReportSettingList = new List<tbl_securityReportSetting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportSetting tbl_securityReportSetting = Maketbl_securityReportSetting(dataReader);
					tbl_securityReportSettingList.Add(tbl_securityReportSetting);
				}
			}
			scon.Close();
			return tbl_securityReportSettingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportSetting> SelectAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingSelectAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
				List<tbl_securityReportSetting> tbl_securityReportSettingList = new List<tbl_securityReportSetting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportSetting tbl_securityReportSetting = Maketbl_securityReportSetting(dataReader);
					tbl_securityReportSettingList.Add(tbl_securityReportSetting);
				}
			}
			scon.Close();
			return tbl_securityReportSettingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportSetting> SelectAllByPaper_ID(string paper_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingSelectAllByPaper_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paper_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paper_ID"].Value = paper_ID;
				List<tbl_securityReportSetting> tbl_securityReportSettingList = new List<tbl_securityReportSetting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportSetting tbl_securityReportSetting = Maketbl_securityReportSetting(dataReader);
					tbl_securityReportSettingList.Add(tbl_securityReportSetting);
				}
			}
			scon.Close();
			return tbl_securityReportSettingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportSetting> SelectAllByPrinter_ID(string printer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingSelectAllByPrinter_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printer_ID", SqlDbType.VarChar,10);
			scom.Parameters["@printer_ID"].Value = printer_ID;
				List<tbl_securityReportSetting> tbl_securityReportSettingList = new List<tbl_securityReportSetting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportSetting tbl_securityReportSetting = Maketbl_securityReportSetting(dataReader);
					tbl_securityReportSettingList.Add(tbl_securityReportSetting);
				}
			}
			scon.Close();
			return tbl_securityReportSettingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportSetting table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportSetting> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportSettingSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_securityReportSetting> tbl_securityReportSettingList = new List<tbl_securityReportSetting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportSetting tbl_securityReportSetting = Maketbl_securityReportSetting(dataReader);
					tbl_securityReportSettingList.Add(tbl_securityReportSetting);
				}
			}
			scon.Close();
			return tbl_securityReportSettingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityReportSetting class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityReportSetting Maketbl_securityReportSetting(SqlDataReader dataReader) {
			tbl_securityReportSetting tbl_securityReportSetting = new tbl_securityReportSetting();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityReportSetting.Report_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityReportSetting.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityReportSetting.Printer_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityReportSetting.Paper_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityReportSetting.Terminal_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityReportSetting.IsActive = dataReader.GetBoolean(5);
			}

			return tbl_securityReportSetting;
		}
		/// <summary>
		/// This makes tbl_securityReportSetting datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityReportSetting object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityReportSetting  tbl_securityReportSetting   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_report_ID = new DataColumn("report_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_printer_ID = new DataColumn("printer_ID" , typeof(string));
			DataColumn col_paper_ID = new DataColumn("paper_ID" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_report_ID,col_user_ID,col_printer_ID,col_paper_ID,col_terminal_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityReportSetting datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityReportSetting object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityReportSetting user) {
		DataRow drow = dt.NewRow();
		
			drow["report_ID"] = user.report_ID;
			drow["user_ID"] = user.user_ID;
			drow["printer_ID"] = user.printer_ID;
			drow["paper_ID"] = user.paper_ID;
			drow["terminal_ID"] = user.terminal_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
