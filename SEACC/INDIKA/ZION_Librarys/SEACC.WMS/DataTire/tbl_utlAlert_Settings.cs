using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlert_Settings {
		#region Fields
		private int alert_ID;
		private int setting_ID;
		private string employee_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Settings class.
		/// </summary>
		public tbl_utlAlert_Settings() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Settings class.
		/// </summary>
		public tbl_utlAlert_Settings(int alert_ID, int setting_ID, string employee_ID, bool isActive) {
			this.alert_ID = alert_ID;
			this.setting_ID = setting_ID;
			this.employee_ID = employee_ID;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Alert_ID value.
		/// </summary>
		public int Alert_ID {
			get { return alert_ID; }
			set { alert_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Setting_ID value.
		/// </summary>
		public int Setting_ID {
			get { return setting_ID; }
			set { setting_ID = value; }
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
		/// Saves a record to the tbl_utlAlert_Settings table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SettingsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@setting_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@setting_ID"].Value = setting_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlert_Settings table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SettingsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@setting_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@setting_ID"].Value = setting_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlert_Settings table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SettingsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@setting_ID", SqlDbType.Int,4);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
			scom.Parameters["@setting_ID"].Value = setting_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Settings table by a foreign key.
		/// </summary>
		public static void DeleteAllByAlert_ID(int alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SettingsDeleteAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlert_Settings table.
		/// </summary>
		public static tbl_utlAlert_Settings Select(int alert_ID_Incoming, int setting_ID_Incoming){

			tbl_utlAlert_Settings tbl_utlAlert_Settingsins = new tbl_utlAlert_Settings();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SettingsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@setting_ID", SqlDbType.Int,4);
			scom.Parameters["@alert_ID"].Value = alert_ID_Incoming;
			scom.Parameters["@setting_ID"].Value = setting_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlert_Settingsins = Maketbl_utlAlert_Settings(dataReader);
				} else {
					tbl_utlAlert_Settingsins = null;
				}
			}
			scon.Close();
			return tbl_utlAlert_Settingsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Settings table.
		/// </summary>
		public static List<tbl_utlAlert_Settings> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SettingsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlert_Settings> tbl_utlAlert_SettingsList = new List<tbl_utlAlert_Settings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Settings tbl_utlAlert_Settings = Maketbl_utlAlert_Settings(dataReader);
					tbl_utlAlert_SettingsList.Add(tbl_utlAlert_Settings);
				}
			}
			scon.Close();
			return tbl_utlAlert_SettingsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Settings table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_Settings> SelectAllByAlert_ID(int alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SettingsSelectAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters["@alert_ID"].Value = alert_ID;
				List<tbl_utlAlert_Settings> tbl_utlAlert_SettingsList = new List<tbl_utlAlert_Settings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Settings tbl_utlAlert_Settings = Maketbl_utlAlert_Settings(dataReader);
					tbl_utlAlert_SettingsList.Add(tbl_utlAlert_Settings);
				}
			}
			scon.Close();
			return tbl_utlAlert_SettingsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlert_Settings class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlert_Settings Maketbl_utlAlert_Settings(SqlDataReader dataReader) {
			tbl_utlAlert_Settings tbl_utlAlert_Settings = new tbl_utlAlert_Settings();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlert_Settings.Alert_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlert_Settings.Setting_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlert_Settings.Employee_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlert_Settings.IsActive = dataReader.GetBoolean(3);
			}

			return tbl_utlAlert_Settings;
		}
		/// <summary>
		/// This makes tbl_utlAlert_Settings datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Settings object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlert_Settings  tbl_utlAlert_Settings   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_alert_ID = new DataColumn("alert_ID" , typeof(int));
			DataColumn col_setting_ID = new DataColumn("setting_ID" , typeof(int));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_alert_ID,col_setting_ID,col_employee_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlert_Settings datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Settings object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlert_Settings user) {
		DataRow drow = dt.NewRow();
		
			drow["alert_ID"] = user.alert_ID;
			drow["setting_ID"] = user.setting_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
