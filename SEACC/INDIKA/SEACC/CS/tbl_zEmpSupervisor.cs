using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zEmpSupervisor {
		#region Fields
		private string supervisor_ID;
		private string supervisorName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zEmpSupervisor class.
		/// </summary>
		public tbl_zEmpSupervisor() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zEmpSupervisor class.
		/// </summary>
		public tbl_zEmpSupervisor(string supervisor_ID, string supervisorName) {
			this.supervisor_ID = supervisor_ID;
			this.supervisorName = supervisorName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Supervisor_ID value.
		/// </summary>
		public string Supervisor_ID {
			get { return supervisor_ID; }
			set { supervisor_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SupervisorName value.
		/// </summary>
		public string SupervisorName {
			get { return supervisorName; }
			set { supervisorName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zEmpSupervisor table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpSupervisorInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supervisor_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supervisorName", SqlDbType.VarChar,50);
 
			scom.Parameters["@supervisor_ID"].Value = supervisor_ID;
			scom.Parameters["@supervisorName"].Value = supervisorName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zEmpSupervisor table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpSupervisorUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supervisor_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supervisorName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@supervisor_ID"].Value = supervisor_ID;
			scom.Parameters["@supervisorName"].Value = supervisorName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zEmpSupervisor table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpSupervisorDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@supervisor_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supervisor_ID"].Value = supervisor_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmpSupervisor table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupervisor_ID(string supervisor_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpSupervisorDeleteAllBySupervisor_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supervisor_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supervisor_ID"].Value = supervisor_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zEmpSupervisor table.
		/// </summary>
		public static tbl_zEmpSupervisor Select(string supervisor_ID_Incoming){

			tbl_zEmpSupervisor tbl_zEmpSupervisorins = new tbl_zEmpSupervisor();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpSupervisorSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supervisor_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supervisor_ID"].Value = supervisor_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zEmpSupervisorins = Maketbl_zEmpSupervisor(dataReader);
				} else {
					tbl_zEmpSupervisorins = null;
				}
			}
			scon.Close();
			return tbl_zEmpSupervisorins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmpSupervisor table.
		/// </summary>
		public static List<tbl_zEmpSupervisor> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpSupervisorSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zEmpSupervisor> tbl_zEmpSupervisorList = new List<tbl_zEmpSupervisor>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zEmpSupervisor tbl_zEmpSupervisor = Maketbl_zEmpSupervisor(dataReader);
					tbl_zEmpSupervisorList.Add(tbl_zEmpSupervisor);
				}
			}
			scon.Close();
			return tbl_zEmpSupervisorList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmpSupervisor table by a foreign key.
		/// </summary>
		public static List<tbl_zEmpSupervisor> SelectAllBySupervisor_ID(string supervisor_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmpSupervisorSelectAllBySupervisor_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supervisor_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supervisor_ID"].Value = supervisor_ID;
				List<tbl_zEmpSupervisor> tbl_zEmpSupervisorList = new List<tbl_zEmpSupervisor>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zEmpSupervisor tbl_zEmpSupervisor = Maketbl_zEmpSupervisor(dataReader);
					tbl_zEmpSupervisorList.Add(tbl_zEmpSupervisor);
				}
			}
			scon.Close();
			return tbl_zEmpSupervisorList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zEmpSupervisor class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zEmpSupervisor Maketbl_zEmpSupervisor(SqlDataReader dataReader) {
			tbl_zEmpSupervisor tbl_zEmpSupervisor = new tbl_zEmpSupervisor();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zEmpSupervisor.Supervisor_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zEmpSupervisor.SupervisorName = dataReader.GetString(1);
			}

			return tbl_zEmpSupervisor;
		}
		/// <summary>
		/// This makes tbl_zEmpSupervisor datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zEmpSupervisor object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zEmpSupervisor  tbl_zEmpSupervisor   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_supervisor_ID = new DataColumn("supervisor_ID" , typeof(string));
			DataColumn col_supervisorName = new DataColumn("supervisorName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_supervisor_ID,col_supervisorName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zEmpSupervisor datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zEmpSupervisor object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zEmpSupervisor user) {
		DataRow drow = dt.NewRow();
		
			drow["supervisor_ID"] = user.supervisor_ID;
			drow["supervisorName"] = user.supervisorName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
