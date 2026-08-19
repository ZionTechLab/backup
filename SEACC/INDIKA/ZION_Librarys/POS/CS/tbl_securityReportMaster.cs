using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_securityReportMaster {
		#region Fields
		private string report_ID;
		private int sortOrder;
		private string reportName;
		private string reportCategory_ID;
		private string displayName;
		private string displayName2;
		private string reportPath;
		private bool isEnable;
		private bool isSetPaper;
		private bool isSetPrinter;
		private bool isSetTerminal;
		private bool isSetUser;
		private bool isDefaultPrinter;
		private int printCount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityReportMaster class.
		/// </summary>
		public tbl_securityReportMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityReportMaster class.
		/// </summary>
		public tbl_securityReportMaster(string report_ID, int sortOrder, string reportName, string reportCategory_ID, string displayName, string displayName2, string reportPath, bool isEnable, bool isSetPaper, bool isSetPrinter, bool isSetTerminal, bool isSetUser, bool isDefaultPrinter, int printCount) {
			this.report_ID = report_ID;
			this.sortOrder = sortOrder;
			this.reportName = reportName;
			this.reportCategory_ID = reportCategory_ID;
			this.displayName = displayName;
			this.displayName2 = displayName2;
			this.reportPath = reportPath;
			this.isEnable = isEnable;
			this.isSetPaper = isSetPaper;
			this.isSetPrinter = isSetPrinter;
			this.isSetTerminal = isSetTerminal;
			this.isSetUser = isSetUser;
			this.isDefaultPrinter = isDefaultPrinter;
			this.printCount = printCount;
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
		/// Gets or sets the SortOrder value.
		/// </summary>
		public int SortOrder {
			get { return sortOrder; }
			set { sortOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportName value.
		/// </summary>
		public string ReportName {
			get { return reportName; }
			set { reportName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportCategory_ID value.
		/// </summary>
		public string ReportCategory_ID {
			get { return reportCategory_ID; }
			set { reportCategory_ID = value; }
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
		
		/// <summary>
		/// Gets or sets the IsSetPaper value.
		/// </summary>
		public bool IsSetPaper {
			get { return isSetPaper; }
			set { isSetPaper = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSetPrinter value.
		/// </summary>
		public bool IsSetPrinter {
			get { return isSetPrinter; }
			set { isSetPrinter = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSetTerminal value.
		/// </summary>
		public bool IsSetTerminal {
			get { return isSetTerminal; }
			set { isSetTerminal = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSetUser value.
		/// </summary>
		public bool IsSetUser {
			get { return isSetUser; }
			set { isSetUser = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDefaultPrinter value.
		/// </summary>
		public bool IsDefaultPrinter {
			get { return isDefaultPrinter; }
			set { isDefaultPrinter = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityReportMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@reportName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@reportCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@displayName2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@reportPath", SqlDbType.VarChar,700);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSetPaper", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSetPrinter", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSetTerminal", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSetUser", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDefaultPrinter", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@sortOrder"].Value = sortOrder;
			scom.Parameters["@reportName"].Value = reportName;
			scom.Parameters["@reportCategory_ID"].Value = reportCategory_ID;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@displayName2"].Value = displayName2;
			scom.Parameters["@reportPath"].Value = reportPath;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@isSetPaper"].Value = isSetPaper;
			scom.Parameters["@isSetPrinter"].Value = isSetPrinter;
			scom.Parameters["@isSetTerminal"].Value = isSetTerminal;
			scom.Parameters["@isSetUser"].Value = isSetUser;
			scom.Parameters["@isDefaultPrinter"].Value = isDefaultPrinter;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityReportMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@reportName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@reportCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@displayName2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@reportPath", SqlDbType.VarChar,700);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSetPaper", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSetPrinter", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSetTerminal", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSetUser", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDefaultPrinter", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
 
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@sortOrder"].Value = sortOrder;
			scom.Parameters["@reportName"].Value = reportName;
			scom.Parameters["@reportCategory_ID"].Value = reportCategory_ID;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@displayName2"].Value = displayName2;
			scom.Parameters["@reportPath"].Value = reportPath;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@isSetPaper"].Value = isSetPaper;
			scom.Parameters["@isSetPrinter"].Value = isSetPrinter;
			scom.Parameters["@isSetTerminal"].Value = isSetTerminal;
			scom.Parameters["@isSetUser"].Value = isSetUser;
			scom.Parameters["@isDefaultPrinter"].Value = isDefaultPrinter;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityReportMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByReportCategory_ID(string reportCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMasterDeleteAllByReportCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@reportCategory_ID"].Value = reportCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityReportMaster table.
		/// </summary>
		public static tbl_securityReportMaster Select(string report_ID_Incoming){

			tbl_securityReportMaster tbl_securityReportMasterins = new tbl_securityReportMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityReportMasterins = Maketbl_securityReportMaster(dataReader);
				} else {
					tbl_securityReportMasterins = null;
				}
			}
			scon.Close();
			return tbl_securityReportMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportMaster table.
		/// </summary>
		public static List<tbl_securityReportMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityReportMaster> tbl_securityReportMasterList = new List<tbl_securityReportMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportMaster tbl_securityReportMaster = Maketbl_securityReportMaster(dataReader);
					tbl_securityReportMasterList.Add(tbl_securityReportMaster);
				}
			}
			scon.Close();
			return tbl_securityReportMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityReportMaster table by a foreign key.
		/// </summary>
		public static List<tbl_securityReportMaster> SelectAllByReportCategory_ID(string reportCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityReportMasterSelectAllByReportCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@reportCategory_ID"].Value = reportCategory_ID;
				List<tbl_securityReportMaster> tbl_securityReportMasterList = new List<tbl_securityReportMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityReportMaster tbl_securityReportMaster = Maketbl_securityReportMaster(dataReader);
					tbl_securityReportMasterList.Add(tbl_securityReportMaster);
				}
			}
			scon.Close();
			return tbl_securityReportMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityReportMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityReportMaster Maketbl_securityReportMaster(SqlDataReader dataReader) {
			tbl_securityReportMaster tbl_securityReportMaster = new tbl_securityReportMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityReportMaster.Report_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityReportMaster.SortOrder = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityReportMaster.ReportName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityReportMaster.ReportCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityReportMaster.DisplayName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityReportMaster.DisplayName2 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityReportMaster.ReportPath = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_securityReportMaster.IsEnable = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_securityReportMaster.IsSetPaper = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_securityReportMaster.IsSetPrinter = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_securityReportMaster.IsSetTerminal = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_securityReportMaster.IsSetUser = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_securityReportMaster.IsDefaultPrinter = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_securityReportMaster.PrintCount = dataReader.GetInt32(13);
			}

			return tbl_securityReportMaster;
		}
		/// <summary>
		/// This makes tbl_securityReportMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityReportMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityReportMaster  tbl_securityReportMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_report_ID = new DataColumn("report_ID" , typeof(string));
			DataColumn col_sortOrder = new DataColumn("sortOrder" , typeof(int));
			DataColumn col_reportName = new DataColumn("reportName" , typeof(string));
			DataColumn col_reportCategory_ID = new DataColumn("reportCategory_ID" , typeof(string));
			DataColumn col_displayName = new DataColumn("displayName" , typeof(string));
			DataColumn col_displayName2 = new DataColumn("displayName2" , typeof(string));
			DataColumn col_reportPath = new DataColumn("reportPath" , typeof(string));
			DataColumn col_isEnable = new DataColumn("isEnable" , typeof(bool));
			DataColumn col_isSetPaper = new DataColumn("isSetPaper" , typeof(bool));
			DataColumn col_isSetPrinter = new DataColumn("isSetPrinter" , typeof(bool));
			DataColumn col_isSetTerminal = new DataColumn("isSetTerminal" , typeof(bool));
			DataColumn col_isSetUser = new DataColumn("isSetUser" , typeof(bool));
			DataColumn col_isDefaultPrinter = new DataColumn("isDefaultPrinter" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_report_ID,col_sortOrder,col_reportName,col_reportCategory_ID,col_displayName,col_displayName2,col_reportPath,col_isEnable,col_isSetPaper,col_isSetPrinter,col_isSetTerminal,col_isSetUser,col_isDefaultPrinter,col_printCount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityReportMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityReportMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityReportMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["report_ID"] = user.report_ID;
			drow["sortOrder"] = user.sortOrder;
			drow["reportName"] = user.reportName;
			drow["reportCategory_ID"] = user.reportCategory_ID;
			drow["displayName"] = user.displayName;
			drow["displayName2"] = user.displayName2;
			drow["reportPath"] = user.reportPath;
			drow["isEnable"] = user.isEnable;
			drow["isSetPaper"] = user.isSetPaper;
			drow["isSetPrinter"] = user.isSetPrinter;
			drow["isSetTerminal"] = user.isSetTerminal;
			drow["isSetUser"] = user.isSetUser;
			drow["isDefaultPrinter"] = user.isDefaultPrinter;
			drow["printCount"] = user.printCount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
