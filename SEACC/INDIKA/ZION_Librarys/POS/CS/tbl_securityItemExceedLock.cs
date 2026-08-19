using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityItemExceedLock {
		#region Fields
		private int valueID;
		private string valueName;
		private bool configValue;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityItemExceedLock class.
		/// </summary>
		public tbl_securityItemExceedLock() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityItemExceedLock class.
		/// </summary>
		public tbl_securityItemExceedLock(int valueID, string valueName, bool configValue) {
			this.valueID = valueID;
			this.valueName = valueName;
			this.configValue = configValue;
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
		public bool ConfigValue {
			get { return configValue; }
			set { configValue = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityItemExceedLock table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityItemExceedLockInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters.Add("@valueName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@configValue", SqlDbType.Bit,1);
 
			scom.Parameters["@valueID"].Value = valueID;
			scom.Parameters["@valueName"].Value = valueName;
			scom.Parameters["@configValue"].Value = configValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityItemExceedLock table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityItemExceedLockUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters.Add("@valueName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@configValue", SqlDbType.Bit,1);
 
 
			scom.Parameters["@valueID"].Value = valueID;
			scom.Parameters["@valueName"].Value = valueName;
			scom.Parameters["@configValue"].Value = configValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityItemExceedLock table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityItemExceedLockDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters["@valueID"].Value = valueID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityItemExceedLock table.
		/// </summary>
		public static tbl_securityItemExceedLock Select(int valueID_Incoming){

			tbl_securityItemExceedLock tbl_securityItemExceedLockins = new tbl_securityItemExceedLock();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityItemExceedLockSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@valueID", SqlDbType.Int,4);
			scom.Parameters["@valueID"].Value = valueID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityItemExceedLockins = Maketbl_securityItemExceedLock(dataReader);
				} else {
					tbl_securityItemExceedLockins = null;
				}
			}
			scon.Close();
			return tbl_securityItemExceedLockins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityItemExceedLock table.
		/// </summary>
		public static List<tbl_securityItemExceedLock> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityItemExceedLockSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityItemExceedLock> tbl_securityItemExceedLockList = new List<tbl_securityItemExceedLock>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityItemExceedLock tbl_securityItemExceedLock = Maketbl_securityItemExceedLock(dataReader);
					tbl_securityItemExceedLockList.Add(tbl_securityItemExceedLock);
				}
			}
			scon.Close();
			return tbl_securityItemExceedLockList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityItemExceedLock class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityItemExceedLock Maketbl_securityItemExceedLock(SqlDataReader dataReader) {
			tbl_securityItemExceedLock tbl_securityItemExceedLock = new tbl_securityItemExceedLock();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityItemExceedLock.ValueID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityItemExceedLock.ValueName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityItemExceedLock.ConfigValue = dataReader.GetBoolean(2);
			}

			return tbl_securityItemExceedLock;
		}
		/// <summary>
		/// This makes tbl_securityItemExceedLock datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityItemExceedLock object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityItemExceedLock  tbl_securityItemExceedLock   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_valueID = new DataColumn("valueID" , typeof(int));
			DataColumn col_valueName = new DataColumn("valueName" , typeof(string));
			DataColumn col_configValue = new DataColumn("configValue" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_valueID,col_valueName,col_configValue,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityItemExceedLock datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityItemExceedLock object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityItemExceedLock user) {
		DataRow drow = dt.NewRow();
		
			drow["valueID"] = user.valueID;
			drow["valueName"] = user.valueName;
			drow["configValue"] = user.configValue;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
