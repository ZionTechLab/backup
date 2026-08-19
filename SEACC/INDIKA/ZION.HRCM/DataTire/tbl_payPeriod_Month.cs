using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payPeriod_Month {
		#region Fields
		private int year_ID;
		private int month_ID;
		private string month_Tittle;
		private DateTime month_startDate;
		private DateTime month_endDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payPeriod_Month class.
		/// </summary>
		public tbl_payPeriod_Month() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payPeriod_Month class.
		/// </summary>
		public tbl_payPeriod_Month(int year_ID, int month_ID, string month_Tittle, DateTime month_startDate, DateTime month_endDate) {
			this.year_ID = year_ID;
			this.month_ID = month_ID;
			this.month_Tittle = month_Tittle;
			this.month_startDate = month_startDate;
			this.month_endDate = month_endDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Year_ID value.
		/// </summary>
		public int Year_ID {
			get { return year_ID; }
			set { year_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_ID value.
		/// </summary>
		public int Month_ID {
			get { return month_ID; }
			set { month_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_Tittle value.
		/// </summary>
		public string Month_Tittle {
			get { return month_Tittle; }
			set { month_Tittle = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_startDate value.
		/// </summary>
		public DateTime Month_startDate {
			get { return month_startDate; }
			set { month_startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_endDate value.
		/// </summary>
		public DateTime Month_endDate {
			get { return month_endDate; }
			set { month_endDate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_payPeriod_Month table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payPeriod_MonthInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_Tittle", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@month_endDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@month_Tittle"].Value = month_Tittle;
			scom.Parameters["@month_startDate"].Value = month_startDate;
			scom.Parameters["@month_endDate"].Value = month_endDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payPeriod_Month table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payPeriod_MonthUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_Tittle", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@month_endDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@month_Tittle"].Value = month_Tittle;
			scom.Parameters["@month_startDate"].Value = month_startDate;
			scom.Parameters["@month_endDate"].Value = month_endDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payPeriod_Month table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payPeriod_MonthDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters["@year_ID"].Value = year_ID;
 
			scom.Parameters["@month_ID"].Value = month_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_payPeriod_Month table.
		/// </summary>
		public static tbl_payPeriod_Month Select(int year_ID_Incoming, int month_ID_Incoming){

			tbl_payPeriod_Month tbl_payPeriod_Monthins = new tbl_payPeriod_Month();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payPeriod_MonthSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters["@year_ID"].Value = year_ID_Incoming;
			scom.Parameters["@month_ID"].Value = month_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payPeriod_Monthins = Maketbl_payPeriod_Month(dataReader);
				} else {
					tbl_payPeriod_Monthins = null;
				}
			}
			scon.Close();
			return tbl_payPeriod_Monthins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payPeriod_Month table.
		/// </summary>
		public static List<tbl_payPeriod_Month> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payPeriod_MonthSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payPeriod_Month> tbl_payPeriod_MonthList = new List<tbl_payPeriod_Month>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payPeriod_Month tbl_payPeriod_Month = Maketbl_payPeriod_Month(dataReader);
					tbl_payPeriod_MonthList.Add(tbl_payPeriod_Month);
				}
			}
			scon.Close();
			return tbl_payPeriod_MonthList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payPeriod_Month class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payPeriod_Month Maketbl_payPeriod_Month(SqlDataReader dataReader) {
			tbl_payPeriod_Month tbl_payPeriod_Month = new tbl_payPeriod_Month();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payPeriod_Month.Year_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payPeriod_Month.Month_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payPeriod_Month.Month_Tittle = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payPeriod_Month.Month_startDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payPeriod_Month.Month_endDate = dataReader.GetDateTime(4);
			}

			return tbl_payPeriod_Month;
		}
		/// <summary>
		/// This makes tbl_payPeriod_Month datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payPeriod_Month object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payPeriod_Month  tbl_payPeriod_Month   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_year_ID = new DataColumn("year_ID" , typeof(int));
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(int));
			DataColumn col_month_Tittle = new DataColumn("month_Tittle" , typeof(string));
			DataColumn col_month_startDate = new DataColumn("month_startDate" , typeof(DateTime));
			DataColumn col_month_endDate = new DataColumn("month_endDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_year_ID,col_month_ID,col_month_Tittle,col_month_startDate,col_month_endDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payPeriod_Month datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payPeriod_Month object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payPeriod_Month user) {
		DataRow drow = dt.NewRow();
		
			drow["year_ID"] = user.year_ID;
			drow["month_ID"] = user.month_ID;
			drow["month_Tittle"] = user.month_Tittle;
			drow["month_startDate"] = user.month_startDate;
			drow["month_endDate"] = user.month_endDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
