using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_rbInsReportMaster {
		#region Fields
		private string report_ID;
		private string reportName;
		private string title1;
		private string title2;
		private string title3;
		private bool isDisplay;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsReportMaster class.
		/// </summary>
		public tbl_rbInsReportMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsReportMaster class.
		/// </summary>
		public tbl_rbInsReportMaster(string report_ID, string reportName, string title1, string title2, string title3, bool isDisplay) {
			this.report_ID = report_ID;
			this.reportName = reportName;
			this.title1 = title1;
			this.title2 = title2;
			this.title3 = title3;
			this.isDisplay = isDisplay;
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
		/// Gets or sets the ReportName value.
		/// </summary>
		public string ReportName {
			get { return reportName; }
			set { reportName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Title1 value.
		/// </summary>
		public string Title1 {
			get { return title1; }
			set { title1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Title2 value.
		/// </summary>
		public string Title2 {
			get { return title2; }
			set { title2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Title3 value.
		/// </summary>
		public string Title3 {
			get { return title3; }
			set { title3 = value; }
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
		/// Saves a record to the tbl_rbInsReportMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@title1", SqlDbType.VarChar,100);
			scom.Parameters.Add("@title2", SqlDbType.VarChar,100);
			scom.Parameters.Add("@title3", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
 
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@reportName"].Value = reportName;
			scom.Parameters["@title1"].Value = title1;
			scom.Parameters["@title2"].Value = title2;
			scom.Parameters["@title3"].Value = title3;
			scom.Parameters["@isDisplay"].Value = isDisplay;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_rbInsReportMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@title1", SqlDbType.VarChar,100);
			scom.Parameters.Add("@title2", SqlDbType.VarChar,100);
			scom.Parameters.Add("@title3", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
 
 
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@reportName"].Value = reportName;
			scom.Parameters["@title1"].Value = title1;
			scom.Parameters["@title2"].Value = title2;
			scom.Parameters["@title3"].Value = title3;
			scom.Parameters["@isDisplay"].Value = isDisplay;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_rbInsReportMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_rbInsReportMaster table.
		/// </summary>
		public static tbl_rbInsReportMaster Select(string report_ID_Incoming){

			tbl_rbInsReportMaster tbl_rbInsReportMasterins = new tbl_rbInsReportMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_rbInsReportMasterins = Maketbl_rbInsReportMaster(dataReader);
				} else {
					tbl_rbInsReportMasterins = null;
				}
			}
			scon.Close();
			return tbl_rbInsReportMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbInsReportMaster table.
		/// </summary>
		public static List<tbl_rbInsReportMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_rbInsReportMaster> tbl_rbInsReportMasterList = new List<tbl_rbInsReportMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbInsReportMaster tbl_rbInsReportMaster = Maketbl_rbInsReportMaster(dataReader);
					tbl_rbInsReportMasterList.Add(tbl_rbInsReportMaster);
				}
			}
			scon.Close();
			return tbl_rbInsReportMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_rbInsReportMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_rbInsReportMaster Maketbl_rbInsReportMaster(SqlDataReader dataReader) {
			tbl_rbInsReportMaster tbl_rbInsReportMaster = new tbl_rbInsReportMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_rbInsReportMaster.Report_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_rbInsReportMaster.ReportName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_rbInsReportMaster.Title1 = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_rbInsReportMaster.Title2 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_rbInsReportMaster.Title3 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_rbInsReportMaster.IsDisplay = dataReader.GetBoolean(5);
			}

			return tbl_rbInsReportMaster;
		}
		/// <summary>
		/// This makes tbl_rbInsReportMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_rbInsReportMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_rbInsReportMaster  tbl_rbInsReportMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_report_ID = new DataColumn("report_ID" , typeof(string));
			DataColumn col_reportName = new DataColumn("reportName" , typeof(string));
			DataColumn col_title1 = new DataColumn("title1" , typeof(string));
			DataColumn col_title2 = new DataColumn("title2" , typeof(string));
			DataColumn col_title3 = new DataColumn("title3" , typeof(string));
			DataColumn col_isDisplay = new DataColumn("isDisplay" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_report_ID,col_reportName,col_title1,col_title2,col_title3,col_isDisplay,});		return dt;
		}
		/// <summary>
		/// This fills tbl_rbInsReportMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_rbInsReportMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_rbInsReportMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["report_ID"] = user.report_ID;
			drow["reportName"] = user.reportName;
			drow["title1"] = user.title1;
			drow["title2"] = user.title2;
			drow["title3"] = user.title3;
			drow["isDisplay"] = user.isDisplay;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
