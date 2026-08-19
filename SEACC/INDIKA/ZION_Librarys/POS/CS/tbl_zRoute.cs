using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zRoute {
		#region Fields
		private string route_ID;
		private string routeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zRoute class.
		/// </summary>
		public tbl_zRoute() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zRoute class.
		/// </summary>
		public tbl_zRoute(string route_ID, string routeName) {
			this.route_ID = route_ID;
			this.routeName = routeName;
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
		/// Gets or sets the RouteName value.
		/// </summary>
		public string RouteName {
			get { return routeName; }
			set { routeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zRoute table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zRouteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@routeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@routeName"].Value = routeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zRoute table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zRouteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@routeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@routeName"].Value = routeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zRoute table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zRouteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zRoute table.
		/// </summary>
		public static tbl_zRoute Select(string route_ID_Incoming){

			tbl_zRoute tbl_zRouteins = new tbl_zRoute();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zRouteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zRouteins = Maketbl_zRoute(dataReader);
				} else {
					tbl_zRouteins = null;
				}
			}
			scon.Close();
			return tbl_zRouteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zRoute table.
		/// </summary>
		public static List<tbl_zRoute> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zRouteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zRoute> tbl_zRouteList = new List<tbl_zRoute>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zRoute tbl_zRoute = Maketbl_zRoute(dataReader);
					tbl_zRouteList.Add(tbl_zRoute);
				}
			}
			scon.Close();
			return tbl_zRouteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zRoute class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zRoute Maketbl_zRoute(SqlDataReader dataReader) {
			tbl_zRoute tbl_zRoute = new tbl_zRoute();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zRoute.Route_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zRoute.RouteName = dataReader.GetString(1);
			}

			return tbl_zRoute;
		}
		/// <summary>
		/// This fills tbl_zRoute datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zRoute object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zRoute user) {
		DataRow drow = dt.NewRow();
		
			drow["route_ID"] = user.route_ID;
			drow["routeName"] = user.routeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
