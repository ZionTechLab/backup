using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genRouteMaster_Town {
		#region Fields
		private string route_ID;
		private string town_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genRouteMaster_Town class.
		/// </summary>
		public tbl_genRouteMaster_Town() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genRouteMaster_Town class.
		/// </summary>
		public tbl_genRouteMaster_Town(string route_ID, string town_ID, bool isActive) {
			this.route_ID = route_ID;
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
		/// Saves a record to the tbl_genRouteMaster_Town table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_TownInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genRouteMaster_Town table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_TownUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genRouteMaster_Town table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_TownDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scom.Parameters["@town_ID"].Value = town_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Town table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_TownDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Town table by a foreign key.
		/// </summary>
		public static void DeleteAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_TownDeleteAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genRouteMaster_Town table.
		/// </summary>
		public static tbl_genRouteMaster_Town Select(string route_ID_Incoming, string town_ID_Incoming){

			tbl_genRouteMaster_Town tbl_genRouteMaster_Townins = new tbl_genRouteMaster_Town();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_TownSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID_Incoming;
			scom.Parameters["@town_ID"].Value = town_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genRouteMaster_Townins = Maketbl_genRouteMaster_Town(dataReader);
				} else {
					tbl_genRouteMaster_Townins = null;
				}
			}
			scon.Close();
			return tbl_genRouteMaster_Townins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Town table.
		/// </summary>
		public static List<tbl_genRouteMaster_Town> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_TownSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genRouteMaster_Town> tbl_genRouteMaster_TownList = new List<tbl_genRouteMaster_Town>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Town tbl_genRouteMaster_Town = Maketbl_genRouteMaster_Town(dataReader);
					tbl_genRouteMaster_TownList.Add(tbl_genRouteMaster_Town);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_TownList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Town table by a foreign key.
		/// </summary>
		public static List<tbl_genRouteMaster_Town> SelectAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_TownSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_genRouteMaster_Town> tbl_genRouteMaster_TownList = new List<tbl_genRouteMaster_Town>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Town tbl_genRouteMaster_Town = Maketbl_genRouteMaster_Town(dataReader);
					tbl_genRouteMaster_TownList.Add(tbl_genRouteMaster_Town);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_TownList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Town table by a foreign key.
		/// </summary>
		public static List<tbl_genRouteMaster_Town> SelectAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_TownSelectAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
				List<tbl_genRouteMaster_Town> tbl_genRouteMaster_TownList = new List<tbl_genRouteMaster_Town>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Town tbl_genRouteMaster_Town = Maketbl_genRouteMaster_Town(dataReader);
					tbl_genRouteMaster_TownList.Add(tbl_genRouteMaster_Town);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_TownList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genRouteMaster_Town class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genRouteMaster_Town Maketbl_genRouteMaster_Town(SqlDataReader dataReader) {
			tbl_genRouteMaster_Town tbl_genRouteMaster_Town = new tbl_genRouteMaster_Town();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genRouteMaster_Town.Route_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genRouteMaster_Town.Town_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genRouteMaster_Town.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_genRouteMaster_Town;
		}
		/// <summary>
		/// This makes tbl_genRouteMaster_Town datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genRouteMaster_Town object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genRouteMaster_Town  tbl_genRouteMaster_Town   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(string));
			DataColumn col_town_ID = new DataColumn("town_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_route_ID,col_town_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genRouteMaster_Town datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genRouteMaster_Town object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genRouteMaster_Town user) {
		DataRow drow = dt.NewRow();
		
			drow["route_ID"] = user.route_ID;
			drow["town_ID"] = user.town_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
