using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_rbReportItem {
		#region Fields
		private string reportItem_ID;
		private string reportItem_level2_ID;
		private string reportItemName;
		private bool isDisplay;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_rbReportItem class.
		/// </summary>
		public tbl_rbReportItem() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rbReportItem class.
		/// </summary>
		public tbl_rbReportItem(string reportItem_ID, string reportItem_level2_ID, string reportItemName, bool isDisplay) {
			this.reportItem_ID = reportItem_ID;
			this.reportItem_level2_ID = reportItem_level2_ID;
			this.reportItemName = reportItemName;
			this.isDisplay = isDisplay;
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_rbReportItem table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItemInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItemName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
 
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
			scom.Parameters["@reportItemName"].Value = reportItemName;
			scom.Parameters["@isDisplay"].Value = isDisplay;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_rbReportItem table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItemUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reportItemName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isDisplay", SqlDbType.Bit,1);
 
 
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
			scom.Parameters["@reportItemName"].Value = reportItemName;
			scom.Parameters["@isDisplay"].Value = isDisplay;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_rbReportItem table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItemDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbReportItem table by a foreign key.
		/// </summary>
		public static void DeleteAllByReportItem_level2_ID(string reportItem_level2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItemDeleteAllByReportItem_level2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_rbReportItem table.
		/// </summary>
		public static tbl_rbReportItem Select(string reportItem_ID_Incoming){

			tbl_rbReportItem tbl_rbReportItemins = new tbl_rbReportItem();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItemSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_ID"].Value = reportItem_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_rbReportItemins = Maketbl_rbReportItem(dataReader);
				} else {
					tbl_rbReportItemins = null;
				}
			}
			scon.Close();
			return tbl_rbReportItemins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbReportItem table.
		/// </summary>
		public static List<tbl_rbReportItem> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItemSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_rbReportItem> tbl_rbReportItemList = new List<tbl_rbReportItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbReportItem tbl_rbReportItem = Maketbl_rbReportItem(dataReader);
					tbl_rbReportItemList.Add(tbl_rbReportItem);
				}
			}
			scon.Close();
			return tbl_rbReportItemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rbReportItem table by a foreign key.
		/// </summary>
		public static List<tbl_rbReportItem> SelectAllByReportItem_level2_ID(string reportItem_level2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rbReportItemSelectAllByReportItem_level2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportItem_level2_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reportItem_level2_ID"].Value = reportItem_level2_ID;
				List<tbl_rbReportItem> tbl_rbReportItemList = new List<tbl_rbReportItem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_rbReportItem tbl_rbReportItem = Maketbl_rbReportItem(dataReader);
					tbl_rbReportItemList.Add(tbl_rbReportItem);
				}
			}
			scon.Close();
			return tbl_rbReportItemList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_rbReportItem class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_rbReportItem Maketbl_rbReportItem(SqlDataReader dataReader) {
			tbl_rbReportItem tbl_rbReportItem = new tbl_rbReportItem();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_rbReportItem.ReportItem_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_rbReportItem.ReportItem_level2_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_rbReportItem.ReportItemName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_rbReportItem.IsDisplay = dataReader.GetBoolean(3);
			}

			return tbl_rbReportItem;
		}
		/// <summary>
		/// This makes tbl_rbReportItem datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_rbReportItem object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_rbReportItem  tbl_rbReportItem   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_reportItem_ID = new DataColumn("reportItem_ID" , typeof(string));
			DataColumn col_reportItem_level2_ID = new DataColumn("reportItem_level2_ID" , typeof(string));
			DataColumn col_reportItemName = new DataColumn("reportItemName" , typeof(string));
			DataColumn col_isDisplay = new DataColumn("isDisplay" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_reportItem_ID,col_reportItem_level2_ID,col_reportItemName,col_isDisplay,});		return dt;
		}
		/// <summary>
		/// This fills tbl_rbReportItem datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_rbReportItem object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_rbReportItem user) {
		DataRow drow = dt.NewRow();
		
			drow["reportItem_ID"] = user.reportItem_ID;
			drow["reportItem_level2_ID"] = user.reportItem_level2_ID;
			drow["reportItemName"] = user.reportItemName;
			drow["isDisplay"] = user.isDisplay;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
