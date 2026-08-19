using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zMonth {
		#region Fields
		private string monthName;
		private int monthNumber;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zMonth class.
		/// </summary>
		public tbl_zMonth() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zMonth class.
		/// </summary>
		public tbl_zMonth(string monthName, int monthNumber) {
			this.monthName = monthName;
			this.monthNumber = monthNumber;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MonthName value.
		/// </summary>
		public string MonthName {
			get { return monthName; }
			set { monthName = value; }
		}
		
		/// <summary>
		/// Gets or sets the MonthNumber value.
		/// </summary>
		public int MonthNumber {
			get { return monthNumber; }
			set { monthNumber = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zMonth table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMonthInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@monthName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@monthNumber", SqlDbType.Int,4);
 
			scom.Parameters["@monthName"].Value = monthName;
			scom.Parameters["@monthNumber"].Value = monthNumber;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zMonth table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMonthUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@monthName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@monthNumber", SqlDbType.Int,4);
 
 
			scom.Parameters["@monthName"].Value = monthName;
			scom.Parameters["@monthNumber"].Value = monthNumber;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zMonth table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMonthDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@monthName", SqlDbType.VarChar,20);
			scom.Parameters["@monthName"].Value = monthName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zMonth table.
		/// </summary>
		public static tbl_zMonth Select(string monthName_Incoming){

			tbl_zMonth tbl_zMonthins = new tbl_zMonth();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMonthSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@monthName", SqlDbType.VarChar,20);
			scom.Parameters["@monthName"].Value = monthName_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zMonthins = Maketbl_zMonth(dataReader);
				} else {
					tbl_zMonthins = null;
				}
			}
			scon.Close();
			return tbl_zMonthins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMonth table.
		/// </summary>
		public static List<tbl_zMonth> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMonthSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zMonth> tbl_zMonthList = new List<tbl_zMonth>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMonth tbl_zMonth = Maketbl_zMonth(dataReader);
					tbl_zMonthList.Add(tbl_zMonth);
				}
			}
			scon.Close();
			return tbl_zMonthList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zMonth class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zMonth Maketbl_zMonth(SqlDataReader dataReader) {
			tbl_zMonth tbl_zMonth = new tbl_zMonth();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zMonth.MonthName = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zMonth.MonthNumber = dataReader.GetInt32(1);
			}

			return tbl_zMonth;
		}
		/// <summary>
		/// This makes tbl_zMonth datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zMonth object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zMonth  tbl_zMonth   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_monthName = new DataColumn("monthName" , typeof(string));
			DataColumn col_monthNumber = new DataColumn("monthNumber" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_monthName,col_monthNumber,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zMonth datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zMonth object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zMonth user) {
		DataRow drow = dt.NewRow();
		
			drow["monthName"] = user.monthName;
			drow["monthNumber"] = user.monthNumber;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
