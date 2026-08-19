using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsWeeklyStockTake {
		#region Fields
		private string weeklyStockTake_ID;
		private DateTime weeklyStockTakeDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsWeeklyStockTake class.
		/// </summary>
		public tbl_scsWeeklyStockTake() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsWeeklyStockTake class.
		/// </summary>
		public tbl_scsWeeklyStockTake(string weeklyStockTake_ID, DateTime weeklyStockTakeDate) {
			this.weeklyStockTake_ID = weeklyStockTake_ID;
			this.weeklyStockTakeDate = weeklyStockTakeDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the WeeklyStockTake_ID value.
		/// </summary>
		public string WeeklyStockTake_ID {
			get { return weeklyStockTake_ID; }
			set { weeklyStockTake_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeeklyStockTakeDate value.
		/// </summary>
		public DateTime WeeklyStockTakeDate {
			get { return weeklyStockTakeDate; }
			set { weeklyStockTakeDate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsWeeklyStockTake table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsWeeklyStockTakeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@weeklyStockTake_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@weeklyStockTakeDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@weeklyStockTake_ID"].Value = weeklyStockTake_ID;
			scom.Parameters["@weeklyStockTakeDate"].Value = weeklyStockTakeDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsWeeklyStockTake table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsWeeklyStockTakeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@weeklyStockTake_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@weeklyStockTakeDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@weeklyStockTake_ID"].Value = weeklyStockTake_ID;
			scom.Parameters["@weeklyStockTakeDate"].Value = weeklyStockTakeDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsWeeklyStockTake table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsWeeklyStockTakeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@weeklyStockTake_ID", SqlDbType.VarChar,20);
			scom.Parameters["@weeklyStockTake_ID"].Value = weeklyStockTake_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsWeeklyStockTake table.
		/// </summary>
		public static tbl_scsWeeklyStockTake Select(string weeklyStockTake_ID_Incoming){

			tbl_scsWeeklyStockTake tbl_scsWeeklyStockTakeins = new tbl_scsWeeklyStockTake();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsWeeklyStockTakeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@weeklyStockTake_ID", SqlDbType.VarChar,20);
			scom.Parameters["@weeklyStockTake_ID"].Value = weeklyStockTake_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsWeeklyStockTakeins = Maketbl_scsWeeklyStockTake(dataReader);
				} else {
					tbl_scsWeeklyStockTakeins = null;
				}
			}
			scon.Close();
			return tbl_scsWeeklyStockTakeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsWeeklyStockTake table.
		/// </summary>
		public static List<tbl_scsWeeklyStockTake> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsWeeklyStockTakeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsWeeklyStockTake> tbl_scsWeeklyStockTakeList = new List<tbl_scsWeeklyStockTake>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsWeeklyStockTake tbl_scsWeeklyStockTake = Maketbl_scsWeeklyStockTake(dataReader);
					tbl_scsWeeklyStockTakeList.Add(tbl_scsWeeklyStockTake);
				}
			}
			scon.Close();
			return tbl_scsWeeklyStockTakeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsWeeklyStockTake class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsWeeklyStockTake Maketbl_scsWeeklyStockTake(SqlDataReader dataReader) {
			tbl_scsWeeklyStockTake tbl_scsWeeklyStockTake = new tbl_scsWeeklyStockTake();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsWeeklyStockTake.WeeklyStockTake_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsWeeklyStockTake.WeeklyStockTakeDate = dataReader.GetDateTime(1);
			}

			return tbl_scsWeeklyStockTake;
		}
		/// <summary>
		/// This makes tbl_scsWeeklyStockTake datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsWeeklyStockTake object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsWeeklyStockTake  tbl_scsWeeklyStockTake   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_weeklyStockTake_ID = new DataColumn("weeklyStockTake_ID" , typeof(string));
			DataColumn col_weeklyStockTakeDate = new DataColumn("weeklyStockTakeDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_weeklyStockTake_ID,col_weeklyStockTakeDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsWeeklyStockTake datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsWeeklyStockTake object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsWeeklyStockTake user) {
		DataRow drow = dt.NewRow();
		
			drow["weeklyStockTake_ID"] = user.weeklyStockTake_ID;
			drow["weeklyStockTakeDate"] = user.weeklyStockTakeDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
