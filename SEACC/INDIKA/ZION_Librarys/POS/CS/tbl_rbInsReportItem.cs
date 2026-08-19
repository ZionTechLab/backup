using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_rbInsReportItem {
		#region Fields
		private string reportItem_ID;
		private string reportItem_level2_ID;
		private string reportItemName;
		private bool isDisplay;
		private string noteNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsReportItem class.
		/// </summary>
		public tbl_rbInsReportItem() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rbInsReportItem class.
		/// </summary>
		public tbl_rbInsReportItem(string reportItem_ID, string reportItem_level2_ID, string reportItemName, bool isDisplay, string noteNo) {
			this.reportItem_ID = reportItem_ID;
			this.reportItem_level2_ID = reportItem_level2_ID;
			this.reportItemName = reportItemName;
			this.isDisplay = isDisplay;
			this.noteNo = noteNo;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ReportItem_ID value.
		/// </summary>
		public string ReportItem_ID {
			get { return reportItem_ID; }
			set { reportItem_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportItem_level2_ID value.
		/// </summary>
		public string ReportItem_level2_ID {
			get { return reportItem_level2_ID; }
			set { reportItem_level2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportItemName value.
		/// </summary>
		public string ReportItemName {
			get { return reportItemName; }
			set { reportItemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDisplay value.
		/// </summary>
		public bool IsDisplay {
			get { return isDisplay; }
			set { isDisplay = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoteNo value.
		/// </summary>
		public string NoteNo {
			get { return noteNo; }
			set { noteNo = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_rbInsReportItem table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItemInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItemName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
			scom.Parameters.Add("@noteNo", SqlDbType.VarChar,10);
 
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
			scom.Parameters["@reportItemName"].Value = reportItemName;
			scom.Parameters["@isDisplay"].Value = isDisplay;
			scom.Parameters["@noteNo"].Value = noteNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_rbInsReportItem table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItemUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItemName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
			scom.Parameters.Add("@noteNo", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
			scom.Parameters["@reportItemName"].Value = reportItemName;
			scom.Parameters["@isDisplay"].Value = isDisplay;
			scom.Parameters["@noteNo"].Value = noteNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_rbInsReportItem table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItemDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbInsReportItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByReportItem_level2_ID(string reportItem_level2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItemDeleteAllByReportItem_level2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_rbInsReportItem table.
		/// </summary>
		public static tbl_rbInsReportItem Select(string reportItem_ID_Incoming){

			tbl_rbInsReportItem tbl_rbInsReportItemins = new tbl_rbInsReportItem();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItemSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_rbInsReportItemins = Maketbl_rbInsReportItem(dataReader);
				} else {
					tbl_rbInsReportItemins = null;
				}
			}
			scon.Close();
			return tbl_rbInsReportItemins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbInsReportItem table.
		/// </summary>
		public static List<tbl_rbInsReportItem> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItemSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_rbInsReportItem> tbl_rbInsReportItemList = new List<tbl_rbInsReportItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbInsReportItem tbl_rbInsReportItem = Maketbl_rbInsReportItem(dataReader);
					tbl_rbInsReportItemList.Add(tbl_rbInsReportItem);
				}
			}
			scon.Close();
			return tbl_rbInsReportItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbInsReportItem table by a foreign key.
		/// </summary>
		public static List<tbl_rbInsReportItem> SelectAllByReportItem_level2_ID(string reportItem_level2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbInsReportItemSelectAllByReportItem_level2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
				List<tbl_rbInsReportItem> tbl_rbInsReportItemList = new List<tbl_rbInsReportItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbInsReportItem tbl_rbInsReportItem = Maketbl_rbInsReportItem(dataReader);
					tbl_rbInsReportItemList.Add(tbl_rbInsReportItem);
				}
			}
			scon.Close();
			return tbl_rbInsReportItemList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_rbInsReportItem class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_rbInsReportItem Maketbl_rbInsReportItem(SqlDataReader dataReader) {
			tbl_rbInsReportItem tbl_rbInsReportItem = new tbl_rbInsReportItem();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_rbInsReportItem.ReportItem_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_rbInsReportItem.ReportItem_level2_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_rbInsReportItem.ReportItemName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_rbInsReportItem.IsDisplay = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_rbInsReportItem.NoteNo = dataReader.GetString(4);
			}

			return tbl_rbInsReportItem;
		}
		/// <summary>
		/// This makes tbl_rbInsReportItem datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_rbInsReportItem object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_rbInsReportItem  tbl_rbInsReportItem   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_reportItem_ID = new DataColumn("reportItem_ID" , typeof(string));
			DataColumn col_reportItem_level2_ID = new DataColumn("reportItem_level2_ID" , typeof(string));
			DataColumn col_reportItemName = new DataColumn("reportItemName" , typeof(string));
			DataColumn col_isDisplay = new DataColumn("isDisplay" , typeof(bool));
			DataColumn col_noteNo = new DataColumn("noteNo" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_reportItem_ID,col_reportItem_level2_ID,col_reportItemName,col_isDisplay,col_noteNo,});		return dt;
		}
		/// <summary>
		/// This fills tbl_rbInsReportItem datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_rbInsReportItem object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_rbInsReportItem user) {
		DataRow drow = dt.NewRow();
		
			drow["reportItem_ID"] = user.reportItem_ID;
			drow["reportItem_level2_ID"] = user.reportItem_level2_ID;
			drow["reportItemName"] = user.reportItemName;
			drow["isDisplay"] = user.isDisplay;
			drow["noteNo"] = user.noteNo;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
