using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityDateSettings {
		#region Fields
		private int processNote_ID;
		private bool isEnable;
		private int maxDaysBackword;
		private int maxDaysForward;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityDateSettings class.
		/// </summary>
		public tbl_securityDateSettings() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityDateSettings class.
		/// </summary>
		public tbl_securityDateSettings(int processNote_ID, bool isEnable, int maxDaysBackword, int maxDaysForward) {
			this.processNote_ID = processNote_ID;
			this.isEnable = isEnable;
			this.maxDaysBackword = maxDaysBackword;
			this.maxDaysForward = maxDaysForward;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProcessNote_ID value.
		/// </summary>
		public int ProcessNote_ID {
			get { return processNote_ID; }
			set { processNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEnable value.
		/// </summary>
		public bool IsEnable {
			get { return isEnable; }
			set { isEnable = value; }
		}
		
		/// <summary>
		/// Gets or sets the MaxDaysBackword value.
		/// </summary>
		public int MaxDaysBackword {
			get { return maxDaysBackword; }
			set { maxDaysBackword = value; }
		}
		
		/// <summary>
		/// Gets or sets the MaxDaysForward value.
		/// </summary>
		public int MaxDaysForward {
			get { return maxDaysForward; }
			set { maxDaysForward = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityDateSettings table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityDateSettingsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure; 
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@maxDaysBackword", SqlDbType.Int,4);
			scom.Parameters.Add("@maxDaysForward", SqlDbType.Int,4);
 
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@maxDaysBackword"].Value = maxDaysBackword;
			scom.Parameters["@maxDaysForward"].Value = maxDaysForward;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityDateSettings table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityDateSettingsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@maxDaysBackword", SqlDbType.Int,4);
			scom.Parameters.Add("@maxDaysForward", SqlDbType.Int,4);
 
 
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@maxDaysBackword"].Value = maxDaysBackword;
			scom.Parameters["@maxDaysForward"].Value = maxDaysForward;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityDateSettings table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityDateSettingsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityDateSettings table by a foreign key.
		/// </summary>
		public static void DeleteAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityDateSettingsDeleteAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityDateSettings table.
		/// </summary>
		public static tbl_securityDateSettings Select(int processNote_ID_Incoming){

			tbl_securityDateSettings tbl_securityDateSettingsins = new tbl_securityDateSettings();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityDateSettingsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityDateSettingsins = Maketbl_securityDateSettings(dataReader);
				} else {
					tbl_securityDateSettingsins = null;
				}
			}
			scon.Close();
			return tbl_securityDateSettingsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityDateSettings table.
		/// </summary>
		public static List<tbl_securityDateSettings> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityDateSettingsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityDateSettings> tbl_securityDateSettingsList = new List<tbl_securityDateSettings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityDateSettings tbl_securityDateSettings = Maketbl_securityDateSettings(dataReader);
					tbl_securityDateSettingsList.Add(tbl_securityDateSettings);
				}
			}
			scon.Close();
			return tbl_securityDateSettingsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityDateSettings table by a foreign key.
		/// </summary>
		public static List<tbl_securityDateSettings> SelectAllByProcessNote_ID(int processNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityDateSettingsSelectAllByProcessNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
				List<tbl_securityDateSettings> tbl_securityDateSettingsList = new List<tbl_securityDateSettings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityDateSettings tbl_securityDateSettings = Maketbl_securityDateSettings(dataReader);
					tbl_securityDateSettingsList.Add(tbl_securityDateSettings);
				}
			}
			scon.Close();
			return tbl_securityDateSettingsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityDateSettings class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityDateSettings Maketbl_securityDateSettings(SqlDataReader dataReader) {
			tbl_securityDateSettings tbl_securityDateSettings = new tbl_securityDateSettings();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityDateSettings.ProcessNote_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityDateSettings.IsEnable = dataReader.GetBoolean(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityDateSettings.MaxDaysBackword = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityDateSettings.MaxDaysForward = dataReader.GetInt32(3);
			}

			return tbl_securityDateSettings;
		}
		/// <summary>
		/// This makes tbl_securityDateSettings datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityDateSettings object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityDateSettings  tbl_securityDateSettings   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_processNote_ID = new DataColumn("processNote_ID" , typeof(int));
			DataColumn col_isEnable = new DataColumn("isEnable" , typeof(bool));
			DataColumn col_maxDaysBackword = new DataColumn("maxDaysBackword" , typeof(int));
			DataColumn col_maxDaysForward = new DataColumn("maxDaysForward" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_processNote_ID,col_isEnable,col_maxDaysBackword,col_maxDaysForward,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityDateSettings datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityDateSettings object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityDateSettings user) {
		DataRow drow = dt.NewRow();
		
			drow["processNote_ID"] = user.processNote_ID;
			drow["isEnable"] = user.isEnable;
			drow["maxDaysBackword"] = user.maxDaysBackword;
			drow["maxDaysForward"] = user.maxDaysForward;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
