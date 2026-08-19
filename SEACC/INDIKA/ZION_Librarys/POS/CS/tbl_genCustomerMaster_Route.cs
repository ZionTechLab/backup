using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCustomerMaster_Route {
		#region Fields
		private string customer_ID;
		private string route_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerMaster_Route class.
		/// </summary>
		public tbl_genCustomerMaster_Route() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerMaster_Route class.
		/// </summary>
		public tbl_genCustomerMaster_Route(string customer_ID, string route_ID, bool isActive) {
			this.customer_ID = customer_ID;
			this.route_ID = route_ID;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Route_ID value.
		/// </summary>
		public string Route_ID {
			get { return route_ID; }
			set { route_ID = value; }
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
		/// Saves a record to the tbl_genCustomerMaster_Route table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_RouteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCustomerMaster_Route table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_RouteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCustomerMaster_Route table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_RouteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scom.Parameters["@route_ID"].Value = route_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Route table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_RouteDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Route table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_RouteDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCustomerMaster_Route table.
		/// </summary>
		public static tbl_genCustomerMaster_Route Select(string customer_ID_Incoming, string route_ID_Incoming){

			tbl_genCustomerMaster_Route tbl_genCustomerMaster_Routeins = new tbl_genCustomerMaster_Route();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_RouteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			scom.Parameters["@route_ID"].Value = route_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCustomerMaster_Routeins = Maketbl_genCustomerMaster_Route(dataReader);
				} else {
					tbl_genCustomerMaster_Routeins = null;
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_Routeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Route table.
		/// </summary>
		public static List<tbl_genCustomerMaster_Route> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_RouteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCustomerMaster_Route> tbl_genCustomerMaster_RouteList = new List<tbl_genCustomerMaster_Route>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerMaster_Route tbl_genCustomerMaster_Route = Maketbl_genCustomerMaster_Route(dataReader);
					tbl_genCustomerMaster_RouteList.Add(tbl_genCustomerMaster_Route);
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_RouteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Route table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerMaster_Route> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_RouteSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_genCustomerMaster_Route> tbl_genCustomerMaster_RouteList = new List<tbl_genCustomerMaster_Route>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerMaster_Route tbl_genCustomerMaster_Route = Maketbl_genCustomerMaster_Route(dataReader);
					tbl_genCustomerMaster_RouteList.Add(tbl_genCustomerMaster_Route);
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_RouteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Route table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerMaster_Route> SelectAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_RouteSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_genCustomerMaster_Route> tbl_genCustomerMaster_RouteList = new List<tbl_genCustomerMaster_Route>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerMaster_Route tbl_genCustomerMaster_Route = Maketbl_genCustomerMaster_Route(dataReader);
					tbl_genCustomerMaster_RouteList.Add(tbl_genCustomerMaster_Route);
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_RouteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCustomerMaster_Route class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCustomerMaster_Route Maketbl_genCustomerMaster_Route(SqlDataReader dataReader) {
			tbl_genCustomerMaster_Route tbl_genCustomerMaster_Route = new tbl_genCustomerMaster_Route();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCustomerMaster_Route.Customer_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCustomerMaster_Route.Route_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCustomerMaster_Route.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_genCustomerMaster_Route;
		}
		/// <summary>
		/// This makes tbl_genCustomerMaster_Route datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCustomerMaster_Route object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCustomerMaster_Route  tbl_genCustomerMaster_Route   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_customer_ID,col_route_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCustomerMaster_Route datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCustomerMaster_Route object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCustomerMaster_Route user) {
		DataRow drow = dt.NewRow();
		
			drow["customer_ID"] = user.customer_ID;
			drow["route_ID"] = user.route_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
