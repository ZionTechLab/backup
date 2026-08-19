using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genShiftMaster {
		#region Fields
		private string shift_ID;
		private string shiftName;
		private DateTime startTime;
		private DateTime endTime;
		private decimal hours;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genShiftMaster class.
		/// </summary>
		public tbl_genShiftMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genShiftMaster class.
		/// </summary>
		public tbl_genShiftMaster(string shift_ID, string shiftName, DateTime startTime, DateTime endTime, decimal hours) {
			this.shift_ID = shift_ID;
			this.shiftName = shiftName;
			this.startTime = startTime;
			this.endTime = endTime;
			this.hours = hours;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Shift_ID value.
		/// </summary>
		public string Shift_ID {
			get { return shift_ID; }
			set { shift_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftName value.
		/// </summary>
		public string ShiftName {
			get { return shiftName; }
			set { shiftName = value; }
		}
		
		/// <summary>
		/// Gets or sets the StartTime value.
		/// </summary>
		public DateTime StartTime {
			get { return startTime; }
			set { startTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the EndTime value.
		/// </summary>
		public DateTime EndTime {
			get { return endTime; }
			set { endTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the Hours value.
		/// </summary>
		public decimal Hours {
			get { return hours; }
			set { hours = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genShiftMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genShiftMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shiftName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@startTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@hours", SqlDbType.Decimal,9);
 
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@shiftName"].Value = shiftName;
			scom.Parameters["@startTime"].Value = startTime;
			scom.Parameters["@endTime"].Value = endTime;
			scom.Parameters["@hours"].Value = hours;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genShiftMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genShiftMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shiftName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@startTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@hours", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@shiftName"].Value = shiftName;
			scom.Parameters["@startTime"].Value = startTime;
			scom.Parameters["@endTime"].Value = endTime;
			scom.Parameters["@hours"].Value = hours;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genShiftMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genShiftMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters["@shift_ID"].Value = shift_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genShiftMaster table.
		/// </summary>
		public static tbl_genShiftMaster Select(string shift_ID_Incoming){

			tbl_genShiftMaster tbl_genShiftMasterins = new tbl_genShiftMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genShiftMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters["@shift_ID"].Value = shift_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genShiftMasterins = Maketbl_genShiftMaster(dataReader);
				} else {
					tbl_genShiftMasterins = null;
				}
			}
			scon.Close();
			return tbl_genShiftMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genShiftMaster table.
		/// </summary>
		public static List<tbl_genShiftMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genShiftMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genShiftMaster> tbl_genShiftMasterList = new List<tbl_genShiftMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genShiftMaster tbl_genShiftMaster = Maketbl_genShiftMaster(dataReader);
					tbl_genShiftMasterList.Add(tbl_genShiftMaster);
				}
			}
			scon.Close();
			return tbl_genShiftMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genShiftMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genShiftMaster Maketbl_genShiftMaster(SqlDataReader dataReader) {
			tbl_genShiftMaster tbl_genShiftMaster = new tbl_genShiftMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genShiftMaster.Shift_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genShiftMaster.ShiftName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genShiftMaster.StartTime = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genShiftMaster.EndTime = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genShiftMaster.Hours = dataReader.GetDecimal(4);
			}

			return tbl_genShiftMaster;
		}
		/// <summary>
		/// This makes tbl_genShiftMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genShiftMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genShiftMaster  tbl_genShiftMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_shift_ID = new DataColumn("shift_ID" , typeof(string));
			DataColumn col_shiftName = new DataColumn("shiftName" , typeof(string));
			DataColumn col_startTime = new DataColumn("startTime" , typeof(DateTime));
			DataColumn col_endTime = new DataColumn("endTime" , typeof(DateTime));
			DataColumn col_hours = new DataColumn("hours" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_shift_ID,col_shiftName,col_startTime,col_endTime,col_hours,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genShiftMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genShiftMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genShiftMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["shift_ID"] = user.shift_ID;
			drow["shiftName"] = user.shiftName;
			drow["startTime"] = user.startTime;
			drow["endTime"] = user.endTime;
			drow["hours"] = user.hours;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
