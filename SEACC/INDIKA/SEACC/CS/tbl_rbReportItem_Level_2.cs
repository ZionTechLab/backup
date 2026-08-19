using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_rbReportItem_Level_2 {
		#region Fields
		private string reportItem_level2_ID;
		private string reportItem_level1_ID;
		private string reportItem_level2Name;
		private string description;
		private string noteNo;
		private bool isDisplay;
		private bool isTextOnly;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_rbReportItem_Level_2 class.
		/// </summary>
		public tbl_rbReportItem_Level_2() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rbReportItem_Level_2 class.
		/// </summary>
		public tbl_rbReportItem_Level_2(string reportItem_level2_ID, string reportItem_level1_ID, string reportItem_level2Name, string description, string noteNo, bool isDisplay, bool isTextOnly) {
			this.reportItem_level2_ID = reportItem_level2_ID;
			this.reportItem_level1_ID = reportItem_level1_ID;
			this.reportItem_level2Name = reportItem_level2Name;
			this.description = description;
			this.noteNo = noteNo;
			this.isDisplay = isDisplay;
			this.isTextOnly = isTextOnly;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ReportItem_level2_ID value.
		/// </summary>
		public string ReportItem_level2_ID {
			get { return reportItem_level2_ID; }
			set { reportItem_level2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportItem_level1_ID value.
		/// </summary>
		public string ReportItem_level1_ID {
			get { return reportItem_level1_ID; }
			set { reportItem_level1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportItem_level2Name value.
		/// </summary>
		public string ReportItem_level2Name {
			get { return reportItem_level2Name; }
			set { reportItem_level2Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoteNo value.
		/// </summary>
		public string NoteNo {
			get { return noteNo; }
			set { noteNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDisplay value.
		/// </summary>
		public bool IsDisplay {
			get { return isDisplay; }
			set { isDisplay = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTextOnly value.
		/// </summary>
		public bool IsTextOnly {
			get { return isTextOnly; }
			set { isTextOnly = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_rbReportItem_Level_2 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_2Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_level1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_level2Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@Description", SqlDbType.VarChar,700);
			scom.Parameters.Add("@noteNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTextOnly", SqlDbType.Bit,1);
 
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
			scom.Parameters["@reportItem_level1_ID"].Value = reportItem_level1_ID;
			scom.Parameters["@reportItem_level2Name"].Value = reportItem_level2Name;
			scom.Parameters["@Description"].Value = description;
			scom.Parameters["@noteNo"].Value = noteNo;
			scom.Parameters["@isDisplay"].Value = isDisplay;
			scom.Parameters["@isTextOnly"].Value = isTextOnly;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_rbReportItem_Level_2 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_2Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_level1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_level2Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@Description", SqlDbType.VarChar,700);
			scom.Parameters.Add("@noteNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTextOnly", SqlDbType.Bit,1);
 
 
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
			scom.Parameters["@reportItem_level1_ID"].Value = reportItem_level1_ID;
			scom.Parameters["@reportItem_level2Name"].Value = reportItem_level2Name;
			scom.Parameters["@Description"].Value = description;
			scom.Parameters["@noteNo"].Value = noteNo;
			scom.Parameters["@isDisplay"].Value = isDisplay;
			scom.Parameters["@isTextOnly"].Value = isTextOnly;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_rbReportItem_Level_2 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_2Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbReportItem_Level_2 table by a foreign key.
		/// </summary>
		public static void DeleteAllByReportItem_level1_ID(string reportItem_level1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_2DeleteAllByReportItem_level1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_level1_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_level1_ID"].Value = reportItem_level1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_rbReportItem_Level_2 table.
		/// </summary>
		public static tbl_rbReportItem_Level_2 Select(string reportItem_level2_ID_Incoming){

			tbl_rbReportItem_Level_2 tbl_rbReportItem_Level_2ins = new tbl_rbReportItem_Level_2();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_2Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_rbReportItem_Level_2ins = Maketbl_rbReportItem_Level_2(dataReader);
				} else {
					tbl_rbReportItem_Level_2ins = null;
				}
			}
			scon.Close();
			return tbl_rbReportItem_Level_2ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbReportItem_Level_2 table.
		/// </summary>
		public static List<tbl_rbReportItem_Level_2> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_2SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_rbReportItem_Level_2> tbl_rbReportItem_Level_2List = new List<tbl_rbReportItem_Level_2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbReportItem_Level_2 tbl_rbReportItem_Level_2 = Maketbl_rbReportItem_Level_2(dataReader);
					tbl_rbReportItem_Level_2List.Add(tbl_rbReportItem_Level_2);
				}
			}
			scon.Close();
			return tbl_rbReportItem_Level_2List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbReportItem_Level_2 table by a foreign key.
		/// </summary>
		public static List<tbl_rbReportItem_Level_2> SelectAllByReportItem_level1_ID(string reportItem_level1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItem_Level_2SelectAllByReportItem_level1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_level1_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_level1_ID"].Value = reportItem_level1_ID;
				List<tbl_rbReportItem_Level_2> tbl_rbReportItem_Level_2List = new List<tbl_rbReportItem_Level_2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbReportItem_Level_2 tbl_rbReportItem_Level_2 = Maketbl_rbReportItem_Level_2(dataReader);
					tbl_rbReportItem_Level_2List.Add(tbl_rbReportItem_Level_2);
				}
			}
			scon.Close();
			return tbl_rbReportItem_Level_2List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_rbReportItem_Level_2 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_rbReportItem_Level_2 Maketbl_rbReportItem_Level_2(SqlDataReader dataReader) {
			tbl_rbReportItem_Level_2 tbl_rbReportItem_Level_2 = new tbl_rbReportItem_Level_2();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_rbReportItem_Level_2.ReportItem_level2_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_rbReportItem_Level_2.ReportItem_level1_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_rbReportItem_Level_2.ReportItem_level2Name = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_rbReportItem_Level_2.Description = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_rbReportItem_Level_2.NoteNo = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_rbReportItem_Level_2.IsDisplay = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_rbReportItem_Level_2.IsTextOnly = dataReader.GetBoolean(6);
			}

			return tbl_rbReportItem_Level_2;
		}
		/// <summary>
		/// This makes tbl_rbReportItem_Level_2 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_rbReportItem_Level_2 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_rbReportItem_Level_2  tbl_rbReportItem_Level_2   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_reportItem_level2_ID = new DataColumn("reportItem_level2_ID" , typeof(string));
			DataColumn col_reportItem_level1_ID = new DataColumn("reportItem_level1_ID" , typeof(string));
			DataColumn col_reportItem_level2Name = new DataColumn("reportItem_level2Name" , typeof(string));
			DataColumn col_Description = new DataColumn("Description" , typeof(string));
			DataColumn col_noteNo = new DataColumn("noteNo" , typeof(string));
			DataColumn col_isDisplay = new DataColumn("isDisplay" , typeof(bool));
			DataColumn col_isTextOnly = new DataColumn("isTextOnly" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_reportItem_level2_ID,col_reportItem_level1_ID,col_reportItem_level2Name,col_Description,col_noteNo,col_isDisplay,col_isTextOnly,});		return dt;
		}
		/// <summary>
		/// This fills tbl_rbReportItem_Level_2 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_rbReportItem_Level_2 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_rbReportItem_Level_2 user) {
		DataRow drow = dt.NewRow();
		
			drow["reportItem_level2_ID"] = user.reportItem_level2_ID;
			drow["reportItem_level1_ID"] = user.reportItem_level1_ID;
			drow["reportItem_level2Name"] = user.reportItem_level2Name;
			drow["Description"] = user.Description;
			drow["noteNo"] = user.noteNo;
			drow["isDisplay"] = user.isDisplay;
			drow["isTextOnly"] = user.isTextOnly;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
