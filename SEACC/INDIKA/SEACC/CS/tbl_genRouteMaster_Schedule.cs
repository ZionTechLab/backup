using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genRouteMaster_Schedule {
		#region Fields
		private string route_ID;
		private string schedule_ID;
		private DateTime startDate;
		private DateTime endDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genRouteMaster_Schedule class.
		/// </summary>
		public tbl_genRouteMaster_Schedule() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genRouteMaster_Schedule class.
		/// </summary>
		public tbl_genRouteMaster_Schedule(string route_ID, string schedule_ID, DateTime startDate, DateTime endDate) {
			this.route_ID = route_ID;
			this.schedule_ID = schedule_ID;
			this.startDate = startDate;
			this.endDate = endDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Route_ID value.
		/// </summary>
		public string Route_ID {
			get { return route_ID; }
			set { route_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Schedule_ID value.
		/// </summary>
		public string Schedule_ID {
			get { return schedule_ID; }
			set { schedule_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StartDate value.
		/// </summary>
		public DateTime StartDate {
			get { return startDate; }
			set { startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the EndDate value.
		/// </summary>
		public DateTime EndDate {
			get { return endDate; }
			set { endDate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genRouteMaster_Schedule table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_ScheduleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genRouteMaster_Schedule table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_ScheduleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genRouteMaster_Schedule table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_ScheduleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule table by a foreign key.
		/// </summary>
		public static void DeleteAllBySchedule_ID(string schedule_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_ScheduleDeleteAllBySchedule_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_ScheduleDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genRouteMaster_Schedule table.
		/// </summary>
		public static tbl_genRouteMaster_Schedule Select(string route_ID_Incoming, string schedule_ID_Incoming){

			tbl_genRouteMaster_Schedule tbl_genRouteMaster_Scheduleins = new tbl_genRouteMaster_Schedule();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_ScheduleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID_Incoming;
			scom.Parameters["@schedule_ID"].Value = schedule_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genRouteMaster_Scheduleins = Maketbl_genRouteMaster_Schedule(dataReader);
				} else {
					tbl_genRouteMaster_Scheduleins = null;
				}
			}
			scon.Close();
			return tbl_genRouteMaster_Scheduleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule table.
		/// </summary>
		public static List<tbl_genRouteMaster_Schedule> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_ScheduleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genRouteMaster_Schedule> tbl_genRouteMaster_ScheduleList = new List<tbl_genRouteMaster_Schedule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Schedule tbl_genRouteMaster_Schedule = Maketbl_genRouteMaster_Schedule(dataReader);
					tbl_genRouteMaster_ScheduleList.Add(tbl_genRouteMaster_Schedule);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_ScheduleList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule table by a foreign key.
		/// </summary>
		public static List<tbl_genRouteMaster_Schedule> SelectAllBySchedule_ID(string schedule_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_ScheduleSelectAllBySchedule_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
				List<tbl_genRouteMaster_Schedule> tbl_genRouteMaster_ScheduleList = new List<tbl_genRouteMaster_Schedule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Schedule tbl_genRouteMaster_Schedule = Maketbl_genRouteMaster_Schedule(dataReader);
					tbl_genRouteMaster_ScheduleList.Add(tbl_genRouteMaster_Schedule);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_ScheduleList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule table by a foreign key.
		/// </summary>
		public static List<tbl_genRouteMaster_Schedule> SelectAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_ScheduleSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_genRouteMaster_Schedule> tbl_genRouteMaster_ScheduleList = new List<tbl_genRouteMaster_Schedule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Schedule tbl_genRouteMaster_Schedule = Maketbl_genRouteMaster_Schedule(dataReader);
					tbl_genRouteMaster_ScheduleList.Add(tbl_genRouteMaster_Schedule);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_ScheduleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genRouteMaster_Schedule class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genRouteMaster_Schedule Maketbl_genRouteMaster_Schedule(SqlDataReader dataReader) {
			tbl_genRouteMaster_Schedule tbl_genRouteMaster_Schedule = new tbl_genRouteMaster_Schedule();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genRouteMaster_Schedule.Route_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genRouteMaster_Schedule.Schedule_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genRouteMaster_Schedule.StartDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genRouteMaster_Schedule.EndDate = dataReader.GetDateTime(3);
			}

			return tbl_genRouteMaster_Schedule;
		}
		/// <summary>
		/// This makes tbl_genRouteMaster_Schedule datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genRouteMaster_Schedule object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genRouteMaster_Schedule  tbl_genRouteMaster_Schedule   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(string));
			DataColumn col_schedule_ID = new DataColumn("schedule_ID" , typeof(string));
			DataColumn col_startDate = new DataColumn("startDate" , typeof(DateTime));
			DataColumn col_endDate = new DataColumn("endDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_route_ID,col_schedule_ID,col_startDate,col_endDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genRouteMaster_Schedule datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genRouteMaster_Schedule object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genRouteMaster_Schedule user) {
		DataRow drow = dt.NewRow();
		
			drow["route_ID"] = user.route_ID;
			drow["schedule_ID"] = user.schedule_ID;
			drow["startDate"] = user.startDate;
			drow["endDate"] = user.endDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
