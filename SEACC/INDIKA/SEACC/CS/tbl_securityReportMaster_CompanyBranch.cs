using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityReportMaster_CompanyBranch {
		#region Fields
		private string report_ID;
		private string companyID;
		private string companyBranch;
		private string displayName;
		private string displayName2;
		private string reportPath;
		private bool isEnable;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityReportMaster_CompanyBranch class.
		/// </summary>
		public tbl_securityReportMaster_CompanyBranch() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityReportMaster_CompanyBranch class.
		/// </summary>
		public tbl_securityReportMaster_CompanyBranch(string report_ID, string companyID, string companyBranch, string displayName, string displayName2, string reportPath, bool isEnable) {
			this.report_ID = report_ID;
			this.companyID = companyID;
			this.companyBranch = companyBranch;
			this.displayName = displayName;
			this.displayName2 = displayName2;
			this.reportPath = reportPath;
			this.isEnable = isEnable;
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
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch value.
		/// </summary>
		public string CompanyBranch {
			get { return companyBranch; }
			set { companyBranch = value; }
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
		
		/// <summary>
		/// Gets or sets the IsEnable value.
		/// </summary>
		public bool IsEnable {
			get { return isEnable; }
			set { isEnable = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityReportMaster_CompanyBranch table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch", SqlDbType.VarChar,20);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@displayName2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@reportPath", SqlDbType.VarChar,700);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
 
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch"].Value = companyBranch;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@displayName2"].Value = displayName2;
			scom.Parameters["@reportPath"].Value = reportPath;
			scom.Parameters["@isEnable"].Value = isEnable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityReportMaster_CompanyBranch table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch", SqlDbType.VarChar,20);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@displayName2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@reportPath", SqlDbType.VarChar,700);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
 
 
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch"].Value = companyBranch;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@displayName2"].Value = displayName2;
			scom.Parameters["@reportPath"].Value = reportPath;
			scom.Parameters["@isEnable"].Value = isEnable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityReportMaster_CompanyBranch table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
 
			scom.Parameters["@companyID"].Value = companyID;
 
			scom.Parameters["@companyBranch"].Value = companyBranch;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportMaster_CompanyBranch table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch(string companyBranch) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchDeleteAllByCompanyBranch", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch"].Value = companyBranch;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportMaster_CompanyBranch table by a foreign key.
		/// </summary>
		public static void DeleteAllByReport_ID(string report_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchDeleteAllByReport_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportMaster_CompanyBranch table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityReportMaster_CompanyBranch table.
		/// </summary>
		public static tbl_securityReportMaster_CompanyBranch Select(string report_ID_Incoming, string companyID_Incoming, string companyBranch_Incoming){

			tbl_securityReportMaster_CompanyBranch tbl_securityReportMaster_CompanyBranchins = new tbl_securityReportMaster_CompanyBranch();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID_Incoming;
			scom.Parameters["@companyID"].Value = companyID_Incoming;
			scom.Parameters["@companyBranch"].Value = companyBranch_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityReportMaster_CompanyBranchins = Maketbl_securityReportMaster_CompanyBranch(dataReader);
				} else {
					tbl_securityReportMaster_CompanyBranchins = null;
				}
			}
			scon.Close();
			return tbl_securityReportMaster_CompanyBranchins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportMaster_CompanyBranch table.
		/// </summary>
		public static List<tbl_securityReportMaster_CompanyBranch> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityReportMaster_CompanyBranch> tbl_securityReportMaster_CompanyBranchList = new List<tbl_securityReportMaster_CompanyBranch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportMaster_CompanyBranch tbl_securityReportMaster_CompanyBranch = Maketbl_securityReportMaster_CompanyBranch(dataReader);
					tbl_securityReportMaster_CompanyBranchList.Add(tbl_securityReportMaster_CompanyBranch);
				}
			}
			scon.Close();
			return tbl_securityReportMaster_CompanyBranchList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportMaster_CompanyBranch table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportMaster_CompanyBranch> SelectAllByCompanyBranch(string companyBranch) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchSelectAllByCompanyBranch", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch"].Value = companyBranch;
				List<tbl_securityReportMaster_CompanyBranch> tbl_securityReportMaster_CompanyBranchList = new List<tbl_securityReportMaster_CompanyBranch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportMaster_CompanyBranch tbl_securityReportMaster_CompanyBranch = Maketbl_securityReportMaster_CompanyBranch(dataReader);
					tbl_securityReportMaster_CompanyBranchList.Add(tbl_securityReportMaster_CompanyBranch);
				}
			}
			scon.Close();
			return tbl_securityReportMaster_CompanyBranchList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportMaster_CompanyBranch table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportMaster_CompanyBranch> SelectAllByReport_ID(string report_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchSelectAllByReport_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
				List<tbl_securityReportMaster_CompanyBranch> tbl_securityReportMaster_CompanyBranchList = new List<tbl_securityReportMaster_CompanyBranch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportMaster_CompanyBranch tbl_securityReportMaster_CompanyBranch = Maketbl_securityReportMaster_CompanyBranch(dataReader);
					tbl_securityReportMaster_CompanyBranchList.Add(tbl_securityReportMaster_CompanyBranch);
				}
			}
			scon.Close();
			return tbl_securityReportMaster_CompanyBranchList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportMaster_CompanyBranch table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportMaster_CompanyBranch> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMaster_CompanyBranchSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_securityReportMaster_CompanyBranch> tbl_securityReportMaster_CompanyBranchList = new List<tbl_securityReportMaster_CompanyBranch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportMaster_CompanyBranch tbl_securityReportMaster_CompanyBranch = Maketbl_securityReportMaster_CompanyBranch(dataReader);
					tbl_securityReportMaster_CompanyBranchList.Add(tbl_securityReportMaster_CompanyBranch);
				}
			}
			scon.Close();
			return tbl_securityReportMaster_CompanyBranchList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityReportMaster_CompanyBranch class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityReportMaster_CompanyBranch Maketbl_securityReportMaster_CompanyBranch(SqlDataReader dataReader) {
			tbl_securityReportMaster_CompanyBranch tbl_securityReportMaster_CompanyBranch = new tbl_securityReportMaster_CompanyBranch();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityReportMaster_CompanyBranch.Report_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityReportMaster_CompanyBranch.CompanyID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityReportMaster_CompanyBranch.CompanyBranch = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityReportMaster_CompanyBranch.DisplayName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityReportMaster_CompanyBranch.DisplayName2 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityReportMaster_CompanyBranch.ReportPath = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityReportMaster_CompanyBranch.IsEnable = dataReader.GetBoolean(6);
			}

			return tbl_securityReportMaster_CompanyBranch;
		}
		/// <summary>
		/// This makes tbl_securityReportMaster_CompanyBranch datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityReportMaster_CompanyBranch object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityReportMaster_CompanyBranch  tbl_securityReportMaster_CompanyBranch   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_report_ID = new DataColumn("report_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch = new DataColumn("companyBranch" , typeof(string));
			DataColumn col_displayName = new DataColumn("displayName" , typeof(string));
			DataColumn col_displayName2 = new DataColumn("displayName2" , typeof(string));
			DataColumn col_reportPath = new DataColumn("reportPath" , typeof(string));
			DataColumn col_isEnable = new DataColumn("isEnable" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_report_ID,col_companyID,col_companyBranch,col_displayName,col_displayName2,col_reportPath,col_isEnable,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityReportMaster_CompanyBranch datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityReportMaster_CompanyBranch object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityReportMaster_CompanyBranch user) {
		DataRow drow = dt.NewRow();
		
			drow["report_ID"] = user.report_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranch"] = user.companyBranch;
			drow["displayName"] = user.displayName;
			drow["displayName2"] = user.displayName2;
			drow["reportPath"] = user.reportPath;
			drow["isEnable"] = user.isEnable;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
