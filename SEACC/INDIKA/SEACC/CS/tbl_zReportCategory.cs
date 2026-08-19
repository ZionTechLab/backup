using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zReportCategory {
		#region Fields
		private string reportCategory_ID;
		private string reportCategoryName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zReportCategory class.
		/// </summary>
		public tbl_zReportCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zReportCategory class.
		/// </summary>
		public tbl_zReportCategory(string reportCategory_ID, string reportCategoryName) {
			this.reportCategory_ID = reportCategory_ID;
			this.reportCategoryName = reportCategoryName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ReportCategory_ID value.
		/// </summary>
		public string ReportCategory_ID {
			get { return reportCategory_ID; }
			set { reportCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReportCategoryName value.
		/// </summary>
		public string ReportCategoryName {
			get { return reportCategoryName; }
			set { reportCategoryName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zReportCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zReportCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@reportCategoryName", SqlDbType.VarChar,50);
 
			scom.Parameters["@reportCategory_ID"].Value = reportCategory_ID;
			scom.Parameters["@reportCategoryName"].Value = reportCategoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zReportCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zReportCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reportCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@reportCategoryName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@reportCategory_ID"].Value = reportCategory_ID;
			scom.Parameters["@reportCategoryName"].Value = reportCategoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zReportCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zReportCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@reportCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@reportCategory_ID"].Value = reportCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zReportCategory table.
		/// </summary>
		public static tbl_zReportCategory Select(string reportCategory_ID_Incoming){

			tbl_zReportCategory tbl_zReportCategoryins = new tbl_zReportCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zReportCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reportCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@reportCategory_ID"].Value = reportCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zReportCategoryins = Maketbl_zReportCategory(dataReader);
				} else {
					tbl_zReportCategoryins = null;
				}
			}
			scon.Close();
			return tbl_zReportCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zReportCategory table.
		/// </summary>
		public static List<tbl_zReportCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zReportCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zReportCategory> tbl_zReportCategoryList = new List<tbl_zReportCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zReportCategory tbl_zReportCategory = Maketbl_zReportCategory(dataReader);
					tbl_zReportCategoryList.Add(tbl_zReportCategory);
				}
			}
			scon.Close();
			return tbl_zReportCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zReportCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zReportCategory Maketbl_zReportCategory(SqlDataReader dataReader) {
			tbl_zReportCategory tbl_zReportCategory = new tbl_zReportCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zReportCategory.ReportCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zReportCategory.ReportCategoryName = dataReader.GetString(1);
			}

			return tbl_zReportCategory;
		}
		/// <summary>
		/// This makes tbl_zReportCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zReportCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zReportCategory  tbl_zReportCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_reportCategory_ID = new DataColumn("reportCategory_ID" , typeof(string));
			DataColumn col_reportCategoryName = new DataColumn("reportCategoryName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_reportCategory_ID,col_reportCategoryName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zReportCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zReportCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zReportCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["reportCategory_ID"] = user.reportCategory_ID;
			drow["reportCategoryName"] = user.reportCategoryName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
