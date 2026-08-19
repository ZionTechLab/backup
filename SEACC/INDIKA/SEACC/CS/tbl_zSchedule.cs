using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zSchedule {
		#region Fields
		private string schedule_ID;
		private string scheduleName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zSchedule class.
		/// </summary>
		public tbl_zSchedule() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zSchedule class.
		/// </summary>
		public tbl_zSchedule(string schedule_ID, string scheduleName) {
			this.schedule_ID = schedule_ID;
			this.scheduleName = scheduleName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Schedule_ID value.
		/// </summary>
		public string Schedule_ID {
			get { return schedule_ID; }
			set { schedule_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ScheduleName value.
		/// </summary>
		public string ScheduleName {
			get { return scheduleName; }
			set { scheduleName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zSchedule table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zScheduleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@scheduleName", SqlDbType.VarChar,50);
 
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
			scom.Parameters["@scheduleName"].Value = scheduleName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zSchedule table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zScheduleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@scheduleName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
			scom.Parameters["@scheduleName"].Value = scheduleName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zSchedule table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zScheduleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zSchedule table.
		/// </summary>
		public static tbl_zSchedule Select(string schedule_ID_Incoming){

			tbl_zSchedule tbl_zScheduleins = new tbl_zSchedule();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zScheduleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters["@schedule_ID"].Value = schedule_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zScheduleins = Maketbl_zSchedule(dataReader);
				} else {
					tbl_zScheduleins = null;
				}
			}
			scon.Close();
			return tbl_zScheduleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zSchedule table.
		/// </summary>
		public static List<tbl_zSchedule> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zScheduleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zSchedule> tbl_zScheduleList = new List<tbl_zSchedule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zSchedule tbl_zSchedule = Maketbl_zSchedule(dataReader);
					tbl_zScheduleList.Add(tbl_zSchedule);
				}
			}
			scon.Close();
			return tbl_zScheduleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zSchedule class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zSchedule Maketbl_zSchedule(SqlDataReader dataReader) {
			tbl_zSchedule tbl_zSchedule = new tbl_zSchedule();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zSchedule.Schedule_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zSchedule.ScheduleName = dataReader.GetString(1);
			}

			return tbl_zSchedule;
		}
		/// <summary>
		/// This makes tbl_zSchedule datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zSchedule object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zSchedule  tbl_zSchedule   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_schedule_ID = new DataColumn("schedule_ID" , typeof(string));
			DataColumn col_scheduleName = new DataColumn("scheduleName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_schedule_ID,col_scheduleName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zSchedule datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zSchedule object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zSchedule user) {
		DataRow drow = dt.NewRow();
		
			drow["schedule_ID"] = user.schedule_ID;
			drow["scheduleName"] = user.scheduleName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
