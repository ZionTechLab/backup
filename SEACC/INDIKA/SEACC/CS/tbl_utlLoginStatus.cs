using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlLoginStatus {
		#region Fields
		private string loginStatus_ID;
		private string loginStatus;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlLoginStatus class.
		/// </summary>
		public tbl_utlLoginStatus() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlLoginStatus class.
		/// </summary>
		public tbl_utlLoginStatus(string loginStatus_ID, string loginStatus) {
			this.loginStatus_ID = loginStatus_ID;
			this.loginStatus = loginStatus;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the LoginStatus_ID value.
		/// </summary>
		public string LoginStatus_ID {
			get { return loginStatus_ID; }
			set { loginStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LoginStatus value.
		/// </summary>
		public string LoginStatus {
			get { return loginStatus; }
			set { loginStatus = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlLoginStatus table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlLoginStatusInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@loginStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@loginStatus", SqlDbType.VarChar,50);
 
			scom.Parameters["@loginStatus_ID"].Value = loginStatus_ID;
			scom.Parameters["@loginStatus"].Value = loginStatus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlLoginStatus table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlLoginStatusUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@loginStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@loginStatus", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@loginStatus_ID"].Value = loginStatus_ID;
			scom.Parameters["@loginStatus"].Value = loginStatus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlLoginStatus table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlLoginStatusDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@loginStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@loginStatus_ID"].Value = loginStatus_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlLoginStatus table.
		/// </summary>
		public static tbl_utlLoginStatus Select(string loginStatus_ID_Incoming){

			tbl_utlLoginStatus tbl_utlLoginStatusins = new tbl_utlLoginStatus();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlLoginStatusSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@loginStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@loginStatus_ID"].Value = loginStatus_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlLoginStatusins = Maketbl_utlLoginStatus(dataReader);
				} else {
					tbl_utlLoginStatusins = null;
				}
			}
			scon.Close();
			return tbl_utlLoginStatusins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlLoginStatus table.
		/// </summary>
		public static List<tbl_utlLoginStatus> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlLoginStatusSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlLoginStatus> tbl_utlLoginStatusList = new List<tbl_utlLoginStatus>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlLoginStatus tbl_utlLoginStatus = Maketbl_utlLoginStatus(dataReader);
					tbl_utlLoginStatusList.Add(tbl_utlLoginStatus);
				}
			}
			scon.Close();
			return tbl_utlLoginStatusList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlLoginStatus class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlLoginStatus Maketbl_utlLoginStatus(SqlDataReader dataReader) {
			tbl_utlLoginStatus tbl_utlLoginStatus = new tbl_utlLoginStatus();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlLoginStatus.LoginStatus_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlLoginStatus.LoginStatus = dataReader.GetString(1);
			}

			return tbl_utlLoginStatus;
		}
		/// <summary>
		/// This makes tbl_utlLoginStatus datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlLoginStatus object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlLoginStatus  tbl_utlLoginStatus   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_loginStatus_ID = new DataColumn("loginStatus_ID" , typeof(string));
			DataColumn col_loginStatus = new DataColumn("loginStatus" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_loginStatus_ID,col_loginStatus,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlLoginStatus datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlLoginStatus object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlLoginStatus user) {
		DataRow drow = dt.NewRow();
		
			drow["loginStatus_ID"] = user.loginStatus_ID;
			drow["loginStatus"] = user.loginStatus;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
