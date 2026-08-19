using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zOrderRefNo {
		#region Fields
		private string orderRefNo_ID;
		private string orderRefNo;
		private string route_ID;
		private string town_ID;
		private string employee_ID;
		private string customer_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zOrderRefNo class.
		/// </summary>
		public tbl_zOrderRefNo() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zOrderRefNo class.
		/// </summary>
		public tbl_zOrderRefNo(string orderRefNo_ID, string orderRefNo, string route_ID, string town_ID, string employee_ID, string customer_ID, bool isActive) {
			this.orderRefNo_ID = orderRefNo_ID;
			this.orderRefNo = orderRefNo;
			this.route_ID = route_ID;
			this.town_ID = town_ID;
			this.employee_ID = employee_ID;
			this.customer_ID = customer_ID;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the OrderRefNo_ID value.
		/// </summary>
		public string OrderRefNo_ID {
			get { return orderRefNo_ID; }
			set { orderRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo value.
		/// </summary>
		public string OrderRefNo {
			get { return orderRefNo; }
			set { orderRefNo = value; }
		}
		
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
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
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
		/// Saves a record to the tbl_zOrderRefNo table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@orderRefNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@orderRefNo"].Value = orderRefNo;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zOrderRefNo table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@orderRefNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@orderRefNo"].Value = orderRefNo;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zOrderRefNo table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zOrderRefNo table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zOrderRefNo table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zOrderRefNo table by a foreign key.
		/// </summary>
		public static void DeleteAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoDeleteAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zOrderRefNo table.
		/// </summary>
		public static tbl_zOrderRefNo Select(string orderRefNo_ID_Incoming){

			tbl_zOrderRefNo tbl_zOrderRefNoins = new tbl_zOrderRefNo();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zOrderRefNoins = Maketbl_zOrderRefNo(dataReader);
				} else {
					tbl_zOrderRefNoins = null;
				}
			}
			scon.Close();
			return tbl_zOrderRefNoins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zOrderRefNo table.
		/// </summary>
		public static List<tbl_zOrderRefNo> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zOrderRefNo> tbl_zOrderRefNoList = new List<tbl_zOrderRefNo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zOrderRefNo tbl_zOrderRefNo = Maketbl_zOrderRefNo(dataReader);
					tbl_zOrderRefNoList.Add(tbl_zOrderRefNo);
				}
			}
			scon.Close();
			return tbl_zOrderRefNoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zOrderRefNo table by a foreign key.
		/// </summary>
		public static List<tbl_zOrderRefNo> SelectAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_zOrderRefNo> tbl_zOrderRefNoList = new List<tbl_zOrderRefNo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zOrderRefNo tbl_zOrderRefNo = Maketbl_zOrderRefNo(dataReader);
					tbl_zOrderRefNoList.Add(tbl_zOrderRefNo);
				}
			}
			scon.Close();
			return tbl_zOrderRefNoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zOrderRefNo table by a foreign key.
		/// </summary>
		public static List<tbl_zOrderRefNo> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_zOrderRefNo> tbl_zOrderRefNoList = new List<tbl_zOrderRefNo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zOrderRefNo tbl_zOrderRefNo = Maketbl_zOrderRefNo(dataReader);
					tbl_zOrderRefNoList.Add(tbl_zOrderRefNo);
				}
			}
			scon.Close();
			return tbl_zOrderRefNoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zOrderRefNo table by a foreign key.
		/// </summary>
		public static List<tbl_zOrderRefNo> SelectAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zOrderRefNoSelectAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
				List<tbl_zOrderRefNo> tbl_zOrderRefNoList = new List<tbl_zOrderRefNo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zOrderRefNo tbl_zOrderRefNo = Maketbl_zOrderRefNo(dataReader);
					tbl_zOrderRefNoList.Add(tbl_zOrderRefNo);
				}
			}
			scon.Close();
			return tbl_zOrderRefNoList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zOrderRefNo class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zOrderRefNo Maketbl_zOrderRefNo(SqlDataReader dataReader) {
			tbl_zOrderRefNo tbl_zOrderRefNo = new tbl_zOrderRefNo();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zOrderRefNo.OrderRefNo_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zOrderRefNo.OrderRefNo = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zOrderRefNo.Route_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zOrderRefNo.Town_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zOrderRefNo.Employee_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zOrderRefNo.Customer_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zOrderRefNo.IsActive = dataReader.GetBoolean(6);
			}

			return tbl_zOrderRefNo;
		}
		/// <summary>
		/// This makes tbl_zOrderRefNo datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zOrderRefNo object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zOrderRefNo  tbl_zOrderRefNo   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_orderRefNo = new DataColumn("orderRefNo" , typeof(string));
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(string));
			DataColumn col_town_ID = new DataColumn("town_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_orderRefNo_ID,col_orderRefNo,col_route_ID,col_town_ID,col_employee_ID,col_customer_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zOrderRefNo datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zOrderRefNo object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zOrderRefNo user) {
		DataRow drow = dt.NewRow();
		
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["orderRefNo"] = user.orderRefNo;
			drow["route_ID"] = user.route_ID;
			drow["town_ID"] = user.town_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
