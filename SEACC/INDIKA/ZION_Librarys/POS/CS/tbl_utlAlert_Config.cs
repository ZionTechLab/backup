using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlert_Config {
		#region Fields
		private string user_ID;
		private int alertID;
		private bool isActivate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Config class.
		/// </summary>
		public tbl_utlAlert_Config() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Config class.
		/// </summary>
		public tbl_utlAlert_Config(string user_ID, int alertID, bool isActivate) {
			this.user_ID = user_ID;
			this.alertID = alertID;
			this.isActivate = isActivate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AlertID value.
		/// </summary>
		public int AlertID {
			get { return alertID; }
			set { alertID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActivate value.
		/// </summary>
		public bool IsActivate {
			get { return isActivate; }
			set { isActivate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlAlert_Config table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_ConfigInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alertID", SqlDbType.Int,4);
			scom.Parameters.Add("@isActivate", SqlDbType.Bit,1);
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@alertID"].Value = alertID;
			scom.Parameters["@isActivate"].Value = isActivate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlert_Config table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_ConfigUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alertID", SqlDbType.Int,4);
			scom.Parameters.Add("@isActivate", SqlDbType.Bit,1);
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@alertID"].Value = alertID;
			scom.Parameters["@isActivate"].Value = isActivate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlert_Config table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_ConfigDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alertID", SqlDbType.Int,4);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@alertID"].Value = alertID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Config table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_ConfigDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Config table by a foreign key.
		/// </summary>
		public static void DeleteAllByAlertID(int alertID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_ConfigDeleteAllByAlertID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alertID", SqlDbType.Int,4);
			scom.Parameters["@alertID"].Value = alertID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlert_Config table.
		/// </summary>
		public static tbl_utlAlert_Config Select(string user_ID_Incoming, int alertID_Incoming){

			tbl_utlAlert_Config tbl_utlAlert_Configins = new tbl_utlAlert_Config();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_ConfigSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alertID", SqlDbType.Int,4);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@alertID"].Value = alertID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlert_Configins = Maketbl_utlAlert_Config(dataReader);
				} else {
					tbl_utlAlert_Configins = null;
				}
			}
			scon.Close();
			return tbl_utlAlert_Configins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Config table.
		/// </summary>
		public static List<tbl_utlAlert_Config> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_ConfigSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlert_Config> tbl_utlAlert_ConfigList = new List<tbl_utlAlert_Config>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Config tbl_utlAlert_Config = Maketbl_utlAlert_Config(dataReader);
					tbl_utlAlert_ConfigList.Add(tbl_utlAlert_Config);
				}
			}
			scon.Close();
			return tbl_utlAlert_ConfigList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Config table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_Config> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_ConfigSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_utlAlert_Config> tbl_utlAlert_ConfigList = new List<tbl_utlAlert_Config>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Config tbl_utlAlert_Config = Maketbl_utlAlert_Config(dataReader);
					tbl_utlAlert_ConfigList.Add(tbl_utlAlert_Config);
				}
			}
			scon.Close();
			return tbl_utlAlert_ConfigList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Config table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_Config> SelectAllByAlertID(int alertID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_ConfigSelectAllByAlertID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alertID", SqlDbType.Int,4);
			scom.Parameters["@alertID"].Value = alertID;
				List<tbl_utlAlert_Config> tbl_utlAlert_ConfigList = new List<tbl_utlAlert_Config>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Config tbl_utlAlert_Config = Maketbl_utlAlert_Config(dataReader);
					tbl_utlAlert_ConfigList.Add(tbl_utlAlert_Config);
				}
			}
			scon.Close();
			return tbl_utlAlert_ConfigList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlert_Config class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlert_Config Maketbl_utlAlert_Config(SqlDataReader dataReader) {
			tbl_utlAlert_Config tbl_utlAlert_Config = new tbl_utlAlert_Config();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlert_Config.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlert_Config.AlertID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlert_Config.IsActivate = dataReader.GetBoolean(2);
			}

			return tbl_utlAlert_Config;
		}
		/// <summary>
		/// This makes tbl_utlAlert_Config datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Config object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlert_Config  tbl_utlAlert_Config   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_alertID = new DataColumn("alertID" , typeof(int));
			DataColumn col_isActivate = new DataColumn("isActivate" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_alertID,col_isActivate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlert_Config datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Config object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlert_Config user) {
		DataRow drow = dt.NewRow();
		
			drow["user_ID"] = user.user_ID;
			drow["alertID"] = user.alertID;
			drow["isActivate"] = user.isActivate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
