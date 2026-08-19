using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genRouteMaster_Schedule_SalesRep {
		#region Fields
		private string route_ID;
		private string schedule_ID;
		private string employee_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genRouteMaster_Schedule_SalesRep class.
		/// </summary>
		public tbl_genRouteMaster_Schedule_SalesRep() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genRouteMaster_Schedule_SalesRep class.
		/// </summary>
		public tbl_genRouteMaster_Schedule_SalesRep(string route_ID, string schedule_ID, string employee_ID, bool isActive) {
			this.route_ID = route_ID;
			this.schedule_ID = schedule_ID;
			this.employee_ID = employee_ID;
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
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
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
		/// Saves a record to the tbl_genRouteMaster_Schedule_SalesRep table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_SalesRepInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genRouteMaster_Schedule_SalesRep table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_SalesRepUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genRouteMaster_Schedule_SalesRep table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_SalesRepDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule_SalesRep table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID_Schedule_ID(string route_ID, string schedule_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_SalesRepDeleteAllByRoute_ID_Schedule_ID", scon);
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
		/// Selects all records from the tbl_genRouteMaster_Schedule_SalesRep table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_SalesRepDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genRouteMaster_Schedule_SalesRep table.
		/// </summary>
		public static tbl_genRouteMaster_Schedule_SalesRep Select(string route_ID_Incoming, string schedule_ID_Incoming, string employee_ID_Incoming){

			tbl_genRouteMaster_Schedule_SalesRep tbl_genRouteMaster_Schedule_SalesRepins = new tbl_genRouteMaster_Schedule_SalesRep();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_SalesRepSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID_Incoming;
			scom.Parameters["@schedule_ID"].Value = schedule_ID_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genRouteMaster_Schedule_SalesRepins = Maketbl_genRouteMaster_Schedule_SalesRep(dataReader);
				} else {
					tbl_genRouteMaster_Schedule_SalesRepins = null;
				}
			}
			scon.Close();
			return tbl_genRouteMaster_Schedule_SalesRepins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule_SalesRep table.
		/// </summary>
		public static List<tbl_genRouteMaster_Schedule_SalesRep> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_SalesRepSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genRouteMaster_Schedule_SalesRep> tbl_genRouteMaster_Schedule_SalesRepList = new List<tbl_genRouteMaster_Schedule_SalesRep>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Schedule_SalesRep tbl_genRouteMaster_Schedule_SalesRep = Maketbl_genRouteMaster_Schedule_SalesRep(dataReader);
					tbl_genRouteMaster_Schedule_SalesRepList.Add(tbl_genRouteMaster_Schedule_SalesRep);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_Schedule_SalesRepList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule_SalesRep table by a foreign key.
		/// </summary>
		public static List<tbl_genRouteMaster_Schedule_SalesRep> SelectAllByRoute_ID_Schedule_ID(string route_ID, string schedule_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_SalesRepSelectAllByRoute_ID_Schedule_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@schedule_ID", SqlDbType.VarChar,10);
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
				List<tbl_genRouteMaster_Schedule_SalesRep> tbl_genRouteMaster_Schedule_SalesRepList = new List<tbl_genRouteMaster_Schedule_SalesRep>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Schedule_SalesRep tbl_genRouteMaster_Schedule_SalesRep = Maketbl_genRouteMaster_Schedule_SalesRep(dataReader);
					tbl_genRouteMaster_Schedule_SalesRepList.Add(tbl_genRouteMaster_Schedule_SalesRep);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_Schedule_SalesRepList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRouteMaster_Schedule_SalesRep table by a foreign key.
		/// </summary>
		public static List<tbl_genRouteMaster_Schedule_SalesRep> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRouteMaster_Schedule_SalesRepSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_genRouteMaster_Schedule_SalesRep> tbl_genRouteMaster_Schedule_SalesRepList = new List<tbl_genRouteMaster_Schedule_SalesRep>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRouteMaster_Schedule_SalesRep tbl_genRouteMaster_Schedule_SalesRep = Maketbl_genRouteMaster_Schedule_SalesRep(dataReader);
					tbl_genRouteMaster_Schedule_SalesRepList.Add(tbl_genRouteMaster_Schedule_SalesRep);
				}
			}
			scon.Close();
			return tbl_genRouteMaster_Schedule_SalesRepList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genRouteMaster_Schedule_SalesRep class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genRouteMaster_Schedule_SalesRep Maketbl_genRouteMaster_Schedule_SalesRep(SqlDataReader dataReader) {
			tbl_genRouteMaster_Schedule_SalesRep tbl_genRouteMaster_Schedule_SalesRep = new tbl_genRouteMaster_Schedule_SalesRep();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genRouteMaster_Schedule_SalesRep.Route_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genRouteMaster_Schedule_SalesRep.Schedule_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genRouteMaster_Schedule_SalesRep.Employee_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genRouteMaster_Schedule_SalesRep.IsActive = dataReader.GetBoolean(3);
			}

			return tbl_genRouteMaster_Schedule_SalesRep;
		}
		/// <summary>
		/// This makes tbl_genRouteMaster_Schedule_SalesRep datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genRouteMaster_Schedule_SalesRep object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genRouteMaster_Schedule_SalesRep  tbl_genRouteMaster_Schedule_SalesRep   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(string));
			DataColumn col_schedule_ID = new DataColumn("schedule_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_route_ID,col_schedule_ID,col_employee_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genRouteMaster_Schedule_SalesRep datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genRouteMaster_Schedule_SalesRep object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genRouteMaster_Schedule_SalesRep user) {
		DataRow drow = dt.NewRow();
		
			drow["route_ID"] = user.route_ID;
			drow["schedule_ID"] = user.schedule_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
