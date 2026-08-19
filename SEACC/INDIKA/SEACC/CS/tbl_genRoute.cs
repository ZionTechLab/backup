using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_genRoute {
		#region Fields
		private int route_ID;
		private string route_Code;
		private string routeName;
        public bool isLocked;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the tbl_genRoute class.
        /// </summary>
        public tbl_genRoute() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genRoute class.
		/// </summary>
		public tbl_genRoute(int route_ID, string route_Code, string routeName,bool _isLocked) {
			this.route_ID = route_ID;
			this.route_Code = route_Code;
			this.routeName = routeName;
            isLocked = _isLocked;

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
		/// Gets or sets the Route_Code value.
		/// </summary>
		public string Route_Code {
			get { return route_Code; }
			set { route_Code = value; }
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
		/// Saves a record to the tbl_genRoute table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@route_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@routeName", SqlDbType.VarChar,100);
            scom.Parameters.Add("@isLocked", SqlDbType.Bit);

            scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@route_Code"].Value = route_Code;
			scom.Parameters["@routeName"].Value = routeName;
            scom.Parameters["@isLocked"].Value = isLocked;

            scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genRoute table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@route_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@routeName", SqlDbType.VarChar,100);
            scom.Parameters.Add("@isLocked", SqlDbType.Bit);

            scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@route_Code"].Value = route_Code;
			scom.Parameters["@routeName"].Value = routeName;
            scom.Parameters["@isLocked"].Value = isLocked;

            scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genRoute table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genRoute table.
		/// </summary>
		public static tbl_genRoute Select(int route_ID_Incoming){

			tbl_genRoute tbl_genRouteins = new tbl_genRoute();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genRouteins = Maketbl_genRoute(dataReader);
				} else {
					tbl_genRouteins = null;
				}
			}
			scon.Close();
			return tbl_genRouteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRoute table.
		/// </summary>
		public static List<tbl_genRoute> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genRoute> tbl_genRouteList = new List<tbl_genRoute>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRoute tbl_genRoute = Maketbl_genRoute(dataReader);
					tbl_genRouteList.Add(tbl_genRoute);
				}
			}
			scon.Close();
			return tbl_genRouteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genRoute class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genRoute Maketbl_genRoute(SqlDataReader dataReader) {
			tbl_genRoute tbl_genRoute = new tbl_genRoute();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genRoute.Route_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genRoute.Route_Code = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genRoute.RouteName = dataReader.GetString(2);
			}
            if (dataReader.IsDBNull(3) == false)
            {
                tbl_genRoute.isLocked = dataReader.GetBoolean(3);
            }
            return tbl_genRoute;
		}
		/// <summary>
		/// This makes tbl_genRoute datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genRoute object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genRoute  tbl_genRoute   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(int));
			DataColumn col_route_Code = new DataColumn("route_Code" , typeof(string));
			DataColumn col_routeName = new DataColumn("routeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_route_ID,col_route_Code,col_routeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genRoute datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genRoute object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genRoute user) {
		DataRow drow = dt.NewRow();
		
			drow["route_ID"] = user.route_ID;
			drow["route_Code"] = user.route_Code;
			drow["routeName"] = user.routeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
