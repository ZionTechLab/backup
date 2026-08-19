using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genRoute_Town {
		#region Fields
		private int route_ID;
		private string town_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genRoute_Town class.
		/// </summary>
		public tbl_genRoute_Town() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genRoute_Town class.
		/// </summary>
		public tbl_genRoute_Town(int route_ID, string town_ID) {
			this.route_ID = route_ID;
			this.town_ID = town_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Route_ID value.
		/// </summary>
		public int Route_ID {
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genRoute_Town table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRoute_TownInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genRoute_Town table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRoute_TownDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scom.Parameters["@town_ID"].Value = town_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRoute_Town table by a foreign key.
		/// </summary>
		public static void DeleteAllByTown_ID(string town_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRoute_TownDeleteAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;

			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRoute_Town table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(int route_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRoute_TownDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRoute_Town table by a foreign key.
		/// </summary>
		public static List<tbl_genRoute_Town> SelectAllByTown_ID(string town_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRoute_TownSelectAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
				List<tbl_genRoute_Town> tbl_genRoute_TownList = new List<tbl_genRoute_Town>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRoute_Town tbl_genRoute_Town = Maketbl_genRoute_Town(dataReader);
					tbl_genRoute_TownList.Add(tbl_genRoute_Town);
				}
			}
			scon.Close();
			return tbl_genRoute_TownList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRoute_Town table by a foreign key.
		/// </summary>
		public static List<tbl_genRoute_Town> SelectAllByRoute_ID(int route_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRoute_TownSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_genRoute_Town> tbl_genRoute_TownList = new List<tbl_genRoute_Town>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRoute_Town tbl_genRoute_Town = Maketbl_genRoute_Town(dataReader);
					tbl_genRoute_TownList.Add(tbl_genRoute_Town);
				}
			}
			scon.Close();
			return tbl_genRoute_TownList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genRoute_Town class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genRoute_Town Maketbl_genRoute_Town(SqlDataReader dataReader) {
			tbl_genRoute_Town tbl_genRoute_Town = new tbl_genRoute_Town();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genRoute_Town.Route_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genRoute_Town.Town_ID = dataReader.GetString(1);
			}

			return tbl_genRoute_Town;
		}
		/// <summary>
		/// This makes tbl_genRoute_Town datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genRoute_Town object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genRoute_Town  tbl_genRoute_Town   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(int));
			DataColumn col_town_ID = new DataColumn("town_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_route_ID,col_town_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genRoute_Town datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genRoute_Town object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genRoute_Town user) {
		DataRow drow = dt.NewRow();
		
			drow["route_ID"] = user.route_ID;
			drow["town_ID"] = user.town_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
