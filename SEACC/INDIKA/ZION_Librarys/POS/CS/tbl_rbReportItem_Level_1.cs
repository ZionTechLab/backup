using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_rbReportItem_Level_1 {
		#region Fields
		private string reportItem_level1_ID;
		private string report_ID;
		private string reportItem_level1Name;
		private bool isDisplay;
		private int line_No;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_rbReportItem_Level_1 class.
		/// </summary>
		public tbl_rbReportItem_Level_1() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rbReportItem_Level_1 class.
		/// </summary>
		public tbl_rbReportItem_Level_1(string reportItem_level1_ID, string report_ID, string reportItem_level1Name, bool isDisplay, int line_No) {
			this.reportItem_level1_ID = reportItem_level1_ID;
			this.report_ID = report_ID;
			this.reportItem_level1Name = reportItem_level1Name;
			this.isDisplay = isDisplay;
			this.line_No = line_No;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ReportItem_level1_ID value.
		/// </summary>
		public string ReportItem_level1_ID {
			get { return reportItem_level1_ID; }
			set { reportItem_level1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Report_ID value.
		/// </summary>
		public string Report_ID {
			get { return report_ID; }
			set { report_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportItem_level1Name value.
		/// </summary>
		public string ReportItem_level1Name {
			get { return reportItem_level1Name; }
			set { reportItem_level1Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDisplay value.
		/// </summary>
		public bool IsDisplay {
			get { return isDisplay; }
			set { isDisplay = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_rbReportItem_Level_1 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_1Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportItem_level1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_level1Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
 
			scom.Parameters["@reportItem_level1_ID"].Value = reportItem_level1_ID;
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@reportItem_level1Name"].Value = reportItem_level1Name;
			scom.Parameters["@isDisplay"].Value = isDisplay;
			scom.Parameters["@line_No"].Value = line_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_rbReportItem_Level_1 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_1Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportItem_level1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_level1Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
 
 
			scom.Parameters["@reportItem_level1_ID"].Value = reportItem_level1_ID;
			scom.Parameters["@report_ID"].Value = report_ID;
			scom.Parameters["@reportItem_level1Name"].Value = reportItem_level1Name;
			scom.Parameters["@isDisplay"].Value = isDisplay;
			scom.Parameters["@line_No"].Value = line_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_rbReportItem_Level_1 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_1Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@reportItem_level1_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_level1_ID"].Value = reportItem_level1_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbReportItem_Level_1 table by a foreign key.
		/// </summary>
		public static void DeleteAllByReport_ID(string report_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_1DeleteAllByReport_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_rbReportItem_Level_1 table.
		/// </summary>
		public static tbl_rbReportItem_Level_1 Select(string reportItem_level1_ID_Incoming){

			tbl_rbReportItem_Level_1 tbl_rbReportItem_Level_1ins = new tbl_rbReportItem_Level_1();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_1Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_level1_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_level1_ID"].Value = reportItem_level1_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_rbReportItem_Level_1ins = Maketbl_rbReportItem_Level_1(dataReader);
				} else {
					tbl_rbReportItem_Level_1ins = null;
				}
			}
			scon.Close();
			return tbl_rbReportItem_Level_1ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbReportItem_Level_1 table.
		/// </summary>
		public static List<tbl_rbReportItem_Level_1> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_1SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_rbReportItem_Level_1> tbl_rbReportItem_Level_1List = new List<tbl_rbReportItem_Level_1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbReportItem_Level_1 tbl_rbReportItem_Level_1 = Maketbl_rbReportItem_Level_1(dataReader);
					tbl_rbReportItem_Level_1List.Add(tbl_rbReportItem_Level_1);
				}
			}
			scon.Close();
			return tbl_rbReportItem_Level_1List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbReportItem_Level_1 table by a foreign key.
		/// </summary>
		public static List<tbl_rbReportItem_Level_1> SelectAllByReport_ID(string report_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_1SelectAllByReport_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@report_ID", SqlDbType.VarChar,20);
			scom.Parameters["@report_ID"].Value = report_ID;
				List<tbl_rbReportItem_Level_1> tbl_rbReportItem_Level_1List = new List<tbl_rbReportItem_Level_1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbReportItem_Level_1 tbl_rbReportItem_Level_1 = Maketbl_rbReportItem_Level_1(dataReader);
					tbl_rbReportItem_Level_1List.Add(tbl_rbReportItem_Level_1);
				}
			}
			scon.Close();
			return tbl_rbReportItem_Level_1List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_rbReportItem_Level_1 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_rbReportItem_Level_1 Maketbl_rbReportItem_Level_1(SqlDataReader dataReader) {
			tbl_rbReportItem_Level_1 tbl_rbReportItem_Level_1 = new tbl_rbReportItem_Level_1();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_rbReportItem_Level_1.ReportItem_level1_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_rbReportItem_Level_1.Report_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_rbReportItem_Level_1.ReportItem_level1Name = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_rbReportItem_Level_1.IsDisplay = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_rbReportItem_Level_1.Line_No = dataReader.GetInt32(4);
			}

			return tbl_rbReportItem_Level_1;
		}
		/// <summary>
		/// This makes tbl_rbReportItem_Level_1 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_rbReportItem_Level_1 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_rbReportItem_Level_1  tbl_rbReportItem_Level_1   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_reportItem_level1_ID = new DataColumn("reportItem_level1_ID" , typeof(string));
			DataColumn col_report_ID = new DataColumn("report_ID" , typeof(string));
			DataColumn col_reportItem_level1Name = new DataColumn("reportItem_level1Name" , typeof(string));
			DataColumn col_isDisplay = new DataColumn("isDisplay" , typeof(bool));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_reportItem_level1_ID,col_report_ID,col_reportItem_level1Name,col_isDisplay,col_line_No,});		return dt;
		}
		/// <summary>
		/// This fills tbl_rbReportItem_Level_1 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_rbReportItem_Level_1 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_rbReportItem_Level_1 user) {
		DataRow drow = dt.NewRow();
		
			drow["reportItem_level1_ID"] = user.reportItem_level1_ID;
			drow["report_ID"] = user.report_ID;
			drow["reportItem_level1Name"] = user.reportItem_level1Name;
			drow["isDisplay"] = user.isDisplay;
			drow["line_No"] = user.line_No;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
