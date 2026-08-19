using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityConfigValue {
		#region Fields
		private int valueID;
		private string valueName;
		private string configValue;
		private string configTypeValue_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityConfigValue class.
		/// </summary>
		public tbl_securityConfigValue() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityConfigValue class.
		/// </summary>
		public tbl_securityConfigValue(int valueID, string valueName, string configValue, string configTypeValue_ID) {
			this.valueID = valueID;
			this.valueName = valueName;
			this.configValue = configValue;
			this.configTypeValue_ID = configTypeValue_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ValueID value.
		/// </summary>
		public int ValueID {
			get { return valueID; }
			set { valueID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ValueName value.
		/// </summary>
		public string ValueName {
			get { return valueName; }
			set { valueName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ConfigValue value.
		/// </summary>
		public string ConfigValue {
			get { return configValue; }
			set { configValue = value; }
		}
		
		/// <summary>
		/// Gets or sets the ConfigTypeValue_ID value.
		/// </summary>
		public string ConfigTypeValue_ID {
			get { return configTypeValue_ID; }
			set { configTypeValue_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityConfigValue table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigValueInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters.Add("@valueName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@configValue", SqlDbType.VarChar,200);
			scom.Parameters.Add("@configTypeValue_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@valueID"].Value = valueID;
			scom.Parameters["@valueName"].Value = valueName;
			scom.Parameters["@configValue"].Value = configValue;
			scom.Parameters["@configTypeValue_ID"].Value = configTypeValue_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityConfigValue table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigValueUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters.Add("@valueName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@configValue", SqlDbType.VarChar,200);
			scom.Parameters.Add("@configTypeValue_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@valueID"].Value = valueID;
			scom.Parameters["@valueName"].Value = valueName;
			scom.Parameters["@configValue"].Value = configValue;
			scom.Parameters["@configTypeValue_ID"].Value = configTypeValue_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityConfigValue table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigValueDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters["@valueID"].Value = valueID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityConfigValue table by a foreign key.
		/// </summary>
		public static void DeleteAllByConfigTypeValue_ID(string configTypeValue_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigValueDeleteAllByConfigTypeValue_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@configTypeValue_ID", SqlDbType.VarChar,10);
			scom.Parameters["@configTypeValue_ID"].Value = configTypeValue_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityConfigValue table.
		/// </summary>
		public static tbl_securityConfigValue Select(int valueID_Incoming){

			tbl_securityConfigValue tbl_securityConfigValueins = new tbl_securityConfigValue();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigValueSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters["@valueID"].Value = valueID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityConfigValueins = Maketbl_securityConfigValue(dataReader);
				} else {
					tbl_securityConfigValueins = null;
				}
			}
			scon.Close();
			return tbl_securityConfigValueins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityConfigValue table.
		/// </summary>
		public static List<tbl_securityConfigValue> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigValueSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityConfigValue> tbl_securityConfigValueList = new List<tbl_securityConfigValue>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityConfigValue tbl_securityConfigValue = Maketbl_securityConfigValue(dataReader);
					tbl_securityConfigValueList.Add(tbl_securityConfigValue);
				}
			}
			scon.Close();
			return tbl_securityConfigValueList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityConfigValue table by a foreign key.
		/// </summary>
		public static List<tbl_securityConfigValue> SelectAllByConfigTypeValue_ID(string configTypeValue_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigValueSelectAllByConfigTypeValue_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@configTypeValue_ID", SqlDbType.VarChar,10);
			scom.Parameters["@configTypeValue_ID"].Value = configTypeValue_ID;
				List<tbl_securityConfigValue> tbl_securityConfigValueList = new List<tbl_securityConfigValue>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityConfigValue tbl_securityConfigValue = Maketbl_securityConfigValue(dataReader);
					tbl_securityConfigValueList.Add(tbl_securityConfigValue);
				}
			}
			scon.Close();
			return tbl_securityConfigValueList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityConfigValue class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityConfigValue Maketbl_securityConfigValue(SqlDataReader dataReader) {
			tbl_securityConfigValue tbl_securityConfigValue = new tbl_securityConfigValue();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityConfigValue.ValueID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityConfigValue.ValueName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityConfigValue.ConfigValue = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityConfigValue.ConfigTypeValue_ID = dataReader.GetString(3);
			}

			return tbl_securityConfigValue;
		}
		/// <summary>
		/// This makes tbl_securityConfigValue datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityConfigValue object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityConfigValue  tbl_securityConfigValue   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_valueID = new DataColumn("valueID" , typeof(int));
			DataColumn col_valueName = new DataColumn("valueName" , typeof(string));
			DataColumn col_configValue = new DataColumn("configValue" , typeof(string));
			DataColumn col_configTypeValue_ID = new DataColumn("configTypeValue_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_valueID,col_valueName,col_configValue,col_configTypeValue_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityConfigValue datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityConfigValue object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityConfigValue user) {
		DataRow drow = dt.NewRow();
		
			drow["valueID"] = user.valueID;
			drow["valueName"] = user.valueName;
			drow["configValue"] = user.configValue;
			drow["configTypeValue_ID"] = user.configTypeValue_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
