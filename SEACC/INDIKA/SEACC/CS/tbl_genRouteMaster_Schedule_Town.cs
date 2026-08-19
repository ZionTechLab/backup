using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genRouteMaster_Schedule_Town {
		#region Fields
		private string route_ID;
		private string schedule_ID;
		private string town_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genRouteMaster_Schedule_Town class.
		/// </summary>
		public tbl_genRouteMaster_Schedule_Town() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genRouteMaster_Schedule_Town class.
		/// </summary>
		public tbl_genRouteMaster_Schedule_Town(string route_ID, string schedule_ID, string town_ID, bool isActive) {
			this.route_ID = route_ID;
			this.schedule_ID = schedule_ID;
			this.town_ID = town_ID;
			this.isActive = isActive;
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
		/// Gets or sets the Town_ID value.
		/// </summary>
		public string Town_ID {
			get { return town_ID; }
			set { town_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genRouteMaster_Schedule_Town table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_TownInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genRouteMaster_Schedule_Town table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_TownUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genRouteMaster_Schedule_Town table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_TownDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
 
			scom.Parameters["@town_ID"].Value = town_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule_Town table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID_Schedule_ID(string route_ID, string schedule_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_TownDeleteAllByRoute_ID_Schedule_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule_Town table by a foreign key.
		/// </summary>
		public static void DeleteAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_TownDeleteAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genRouteMaster_Schedule_Town table.
		/// </summary>
		public static tbl_genRouteMaster_Schedule_Town Select(string route_ID_Incoming, string schedule_ID_Incoming, string town_ID_Incoming){

			tbl_genRouteMaster_Schedule_Town tbl_genRouteMaster_Schedule_Townins = new tbl_genRouteMaster_Schedule_Town();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_TownSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID_Incoming;
			scom.Parameters["@schedule_ID"].Value = schedule_ID_Incoming;
			scom.Parameters["@town_ID"].Value = town_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genRouteMaster_Schedule_Townins = Maketbl_genRouteMaster_Schedule_Town(dataReader);
				} else {
					tbl_genRouteMaster_Schedule_Townins = null;
				}
			}
			scon.Close();
			return tbl_genRouteMaster_Schedule_Townins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule_Town table.
		/// </summary>
		public static List<tbl_genRouteMaster_Schedule_Town> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_TownSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genRouteMaster_Schedule_Town> tbl_genRouteMaster_Schedule_TownList = new List<tbl_genRouteMaster_Schedule_Town>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Schedule_Town tbl_genRouteMaster_Schedule_Town = Maketbl_genRouteMaster_Schedule_Town(dataReader);
					tbl_genRouteMaster_Schedule_TownList.Add(tbl_genRouteMaster_Schedule_Town);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_Schedule_TownList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule_Town table by a foreign key.
		/// </summary>
		public static List<tbl_genRouteMaster_Schedule_Town> SelectAllByRoute_ID_Schedule_ID(string route_ID, string schedule_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_TownSelectAllByRoute_ID_Schedule_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
				List<tbl_genRouteMaster_Schedule_Town> tbl_genRouteMaster_Schedule_TownList = new List<tbl_genRouteMaster_Schedule_Town>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Schedule_Town tbl_genRouteMaster_Schedule_Town = Maketbl_genRouteMaster_Schedule_Town(dataReader);
					tbl_genRouteMaster_Schedule_TownList.Add(tbl_genRouteMaster_Schedule_Town);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_Schedule_TownList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule_Town table by a foreign key.
		/// </summary>
		public static List<tbl_genRouteMaster_Schedule_Town> SelectAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_TownSelectAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
				List<tbl_genRouteMaster_Schedule_Town> tbl_genRouteMaster_Schedule_TownList = new List<tbl_genRouteMaster_Schedule_Town>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Schedule_Town tbl_genRouteMaster_Schedule_Town = Maketbl_genRouteMaster_Schedule_Town(dataReader);
					tbl_genRouteMaster_Schedule_TownList.Add(tbl_genRouteMaster_Schedule_Town);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_Schedule_TownList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genRouteMaster_Schedule_Town class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genRouteMaster_Schedule_Town Maketbl_genRouteMaster_Schedule_Town(SqlDataReader dataReader) {
			tbl_genRouteMaster_Schedule_Town tbl_genRouteMaster_Schedule_Town = new tbl_genRouteMaster_Schedule_Town();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genRouteMaster_Schedule_Town.Route_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genRouteMaster_Schedule_Town.Schedule_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genRouteMaster_Schedule_Town.Town_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genRouteMaster_Schedule_Town.IsActive = dataReader.GetBoolean(3);
			}

			return tbl_genRouteMaster_Schedule_Town;
		}
		/// <summary>
		/// This makes tbl_genRouteMaster_Schedule_Town datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genRouteMaster_Schedule_Town object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genRouteMaster_Schedule_Town  tbl_genRouteMaster_Schedule_Town   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(string));
			DataColumn col_schedule_ID = new DataColumn("schedule_ID" , typeof(string));
			DataColumn col_town_ID = new DataColumn("town_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_route_ID,col_schedule_ID,col_town_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genRouteMaster_Schedule_Town datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genRouteMaster_Schedule_Town object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genRouteMaster_Schedule_Town user) {
		DataRow drow = dt.NewRow();
		
			drow["route_ID"] = user.route_ID;
			drow["schedule_ID"] = user.schedule_ID;
			drow["town_ID"] = user.town_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
