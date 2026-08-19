using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genRouteMaster {
		#region Fields
		private string route_ID;
		private string routeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genRouteMaster class.
		/// </summary>
		public tbl_genRouteMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genRouteMaster class.
		/// </summary>
		public tbl_genRouteMaster(string route_ID, string routeName) {
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
		/// Saves a record to the tbl_genRouteMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@routeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@routeName"].Value = routeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genRouteMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@routeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@routeName"].Value = routeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genRouteMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genRouteMaster table.
		/// </summary>
		public static tbl_genRouteMaster Select(string route_ID_Incoming){

			tbl_genRouteMaster tbl_genRouteMasterins = new tbl_genRouteMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genRouteMasterins = Maketbl_genRouteMaster(dataReader);
				} else {
					tbl_genRouteMasterins = null;
				}
			}
			scon.Close();
			return tbl_genRouteMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster table.
		/// </summary>
		public static List<tbl_genRouteMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genRouteMaster> tbl_genRouteMasterList = new List<tbl_genRouteMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster tbl_genRouteMaster = Maketbl_genRouteMaster(dataReader);
					tbl_genRouteMasterList.Add(tbl_genRouteMaster);
				}
			}
			scon.Close();
			return tbl_genRouteMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genRouteMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genRouteMaster Maketbl_genRouteMaster(SqlDataReader dataReader) {
			tbl_genRouteMaster tbl_genRouteMaster = new tbl_genRouteMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genRouteMaster.Route_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genRouteMaster.RouteName = dataReader.GetString(1);
			}

			return tbl_genRouteMaster;
		}
		/// <summary>
		/// This makes tbl_genRouteMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genRouteMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genRouteMaster  tbl_genRouteMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(string));
			DataColumn col_routeName = new DataColumn("routeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_route_ID,col_routeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genRouteMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genRouteMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genRouteMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["route_ID"] = user.route_ID;
			drow["routeName"] = user.routeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
