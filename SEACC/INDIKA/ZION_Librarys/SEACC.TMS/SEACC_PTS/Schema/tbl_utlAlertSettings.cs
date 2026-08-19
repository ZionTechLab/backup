using SEACC_PTS.NmsLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Schema {
	public sealed class tbl_utlAlertSettings {
		#region Fields
		private string setting_ID;
		private string alert_ID;
		private string user_ID;
		private string personName;
		private string userEmail1;
		private string userEmail2;
		private string phoneNo1;
		private string phoneNo2;
		private int receiverType;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertSettings class.
		/// </summary>
		public tbl_utlAlertSettings() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertSettings class.
		/// </summary>
		public tbl_utlAlertSettings(string setting_ID, string alert_ID, string user_ID, string personName, string userEmail1, string userEmail2, string phoneNo1, string phoneNo2, int receiverType) {
			this.setting_ID = setting_ID;
			this.alert_ID = alert_ID;
			this.user_ID = user_ID;
			this.personName = personName;
			this.userEmail1 = userEmail1;
			this.userEmail2 = userEmail2;
			this.phoneNo1 = phoneNo1;
			this.phoneNo2 = phoneNo2;
			this.receiverType = receiverType;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Setting_ID value.
		/// </summary>
		public string Setting_ID {
			get { return setting_ID; }
			set { setting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Alert_ID value.
		/// </summary>
		public string Alert_ID {
			get { return alert_ID; }
			set { alert_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PersonName value.
		/// </summary>
		public string PersonName {
			get { return personName; }
			set { personName = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserEmail1 value.
		/// </summary>
		public string UserEmail1 {
			get { return userEmail1; }
			set { userEmail1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserEmail2 value.
		/// </summary>
		public string UserEmail2 {
			get { return userEmail2; }
			set { userEmail2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PhoneNo1 value.
		/// </summary>
		public string PhoneNo1 {
			get { return phoneNo1; }
			set { phoneNo1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PhoneNo2 value.
		/// </summary>
		public string PhoneNo2 {
			get { return phoneNo2; }
			set { phoneNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiverType value.
		/// </summary>
		public int ReceiverType {
			get { return receiverType; }
			set { receiverType = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlAlertSettings table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertSettingsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@setting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@personName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@userEmail1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@userEmail2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@phoneNo1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@phoneNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@receiverType", SqlDbType.Int,4);
 
			scom.Parameters["@setting_ID"].Value = setting_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@personName"].Value = personName;
			scom.Parameters["@userEmail1"].Value = userEmail1;
			scom.Parameters["@userEmail2"].Value = userEmail2;
			scom.Parameters["@phoneNo1"].Value = phoneNo1;
			scom.Parameters["@phoneNo2"].Value = phoneNo2;
			scom.Parameters["@receiverType"].Value = receiverType;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlertSettings table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertSettingsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@setting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@personName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@userEmail1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@userEmail2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@phoneNo1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@phoneNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@receiverType", SqlDbType.Int,4);
 
 
			scom.Parameters["@setting_ID"].Value = setting_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@personName"].Value = personName;
			scom.Parameters["@userEmail1"].Value = userEmail1;
			scom.Parameters["@userEmail2"].Value = userEmail2;
			scom.Parameters["@phoneNo1"].Value = phoneNo1;
			scom.Parameters["@phoneNo2"].Value = phoneNo2;
			scom.Parameters["@receiverType"].Value = receiverType;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlertSettings table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertSettingsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@setting_ID", SqlDbType.VarChar,20);
			scom.Parameters["@setting_ID"].Value = setting_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertSettings table by a foreign key.
		/// </summary>
		public static void DeleteAllByAlert_ID(string alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertSettingsDeleteAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlertSettings table.
		/// </summary>
		public static tbl_utlAlertSettings Select(string setting_ID_Incoming){

			tbl_utlAlertSettings tbl_utlAlertSettingsins = new tbl_utlAlertSettings();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertSettingsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@setting_ID", SqlDbType.VarChar,20);
			scom.Parameters["@setting_ID"].Value = setting_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlertSettingsins = Maketbl_utlAlertSettings(dataReader);
				} else {
					tbl_utlAlertSettingsins = null;
				}
			}
			scon.Close();
			return tbl_utlAlertSettingsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertSettings table.
		/// </summary>
		public static List<tbl_utlAlertSettings> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertSettingsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlertSettings> tbl_utlAlertSettingsList = new List<tbl_utlAlertSettings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertSettings tbl_utlAlertSettings = Maketbl_utlAlertSettings(dataReader);
					tbl_utlAlertSettingsList.Add(tbl_utlAlertSettings);
				}
			}
			scon.Close();
			return tbl_utlAlertSettingsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertSettings table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlertSettings> SelectAllByAlert_ID(string alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertSettingsSelectAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
				List<tbl_utlAlertSettings> tbl_utlAlertSettingsList = new List<tbl_utlAlertSettings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertSettings tbl_utlAlertSettings = Maketbl_utlAlertSettings(dataReader);
					tbl_utlAlertSettingsList.Add(tbl_utlAlertSettings);
				}
			}
			scon.Close();
			return tbl_utlAlertSettingsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlertSettings class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlertSettings Maketbl_utlAlertSettings(SqlDataReader dataReader) {
			tbl_utlAlertSettings tbl_utlAlertSettings = new tbl_utlAlertSettings();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlertSettings.Setting_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlertSettings.Alert_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlertSettings.User_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlertSettings.PersonName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlAlertSettings.UserEmail1 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlAlertSettings.UserEmail2 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_utlAlertSettings.PhoneNo1 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_utlAlertSettings.PhoneNo2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_utlAlertSettings.ReceiverType = dataReader.GetInt32(8);
			}

			return tbl_utlAlertSettings;
		}
		/// <summary>
		/// This makes tbl_utlAlertSettings datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlertSettings object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlertSettings  tbl_utlAlertSettings   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_setting_ID = new DataColumn("setting_ID" , typeof(string));
			DataColumn col_alert_ID = new DataColumn("alert_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_personName = new DataColumn("personName" , typeof(string));
			DataColumn col_userEmail1 = new DataColumn("userEmail1" , typeof(string));
			DataColumn col_userEmail2 = new DataColumn("userEmail2" , typeof(string));
			DataColumn col_phoneNo1 = new DataColumn("phoneNo1" , typeof(string));
			DataColumn col_phoneNo2 = new DataColumn("phoneNo2" , typeof(string));
			DataColumn col_receiverType = new DataColumn("receiverType" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_setting_ID,col_alert_ID,col_user_ID,col_personName,col_userEmail1,col_userEmail2,col_phoneNo1,col_phoneNo2,col_receiverType,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlertSettings datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlertSettings object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlertSettings user) {
		DataRow drow = dt.NewRow();
		
			drow["setting_ID"] = user.setting_ID;
			drow["alert_ID"] = user.alert_ID;
			drow["user_ID"] = user.user_ID;
			drow["personName"] = user.personName;
			drow["userEmail1"] = user.userEmail1;
			drow["userEmail2"] = user.userEmail2;
			drow["phoneNo1"] = user.phoneNo1;
			drow["phoneNo2"] = user.phoneNo2;
			drow["receiverType"] = user.receiverType;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
