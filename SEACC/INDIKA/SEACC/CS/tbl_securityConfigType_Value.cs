using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityConfigType_Value {
		#region Fields
		private string configTypeValue_ID;
		private string configTypeValue;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityConfigType_Value class.
		/// </summary>
		public tbl_securityConfigType_Value() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityConfigType_Value class.
		/// </summary>
		public tbl_securityConfigType_Value(string configTypeValue_ID, string configTypeValue, string remark) {
			this.configTypeValue_ID = configTypeValue_ID;
			this.configTypeValue = configTypeValue;
			this.remark = remark;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ConfigTypeValue_ID value.
		/// </summary>
		public string ConfigTypeValue_ID {
			get { return configTypeValue_ID; }
			set { configTypeValue_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ConfigTypeValue value.
		/// </summary>
		public string ConfigTypeValue {
			get { return configTypeValue; }
			set { configTypeValue = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityConfigType_Value table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigType_ValueInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@configTypeValue_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@configTypeValue", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
 
			scom.Parameters["@configTypeValue_ID"].Value = configTypeValue_ID;
			scom.Parameters["@configTypeValue"].Value = configTypeValue;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityConfigType_Value table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigType_ValueUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@configTypeValue_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@configTypeValue", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
 
 
			scom.Parameters["@configTypeValue_ID"].Value = configTypeValue_ID;
			scom.Parameters["@configTypeValue"].Value = configTypeValue;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityConfigType_Value table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigType_ValueDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@configTypeValue_ID", SqlDbType.VarChar,10);
			scom.Parameters["@configTypeValue_ID"].Value = configTypeValue_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityConfigType_Value table.
		/// </summary>
		public static tbl_securityConfigType_Value Select(string configTypeValue_ID_Incoming){

			tbl_securityConfigType_Value tbl_securityConfigType_Valueins = new tbl_securityConfigType_Value();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigType_ValueSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@configTypeValue_ID", SqlDbType.VarChar,10);
			scom.Parameters["@configTypeValue_ID"].Value = configTypeValue_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityConfigType_Valueins = Maketbl_securityConfigType_Value(dataReader);
				} else {
					tbl_securityConfigType_Valueins = null;
				}
			}
			scon.Close();
			return tbl_securityConfigType_Valueins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityConfigType_Value table.
		/// </summary>
		public static List<tbl_securityConfigType_Value> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigType_ValueSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityConfigType_Value> tbl_securityConfigType_ValueList = new List<tbl_securityConfigType_Value>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityConfigType_Value tbl_securityConfigType_Value = Maketbl_securityConfigType_Value(dataReader);
					tbl_securityConfigType_ValueList.Add(tbl_securityConfigType_Value);
				}
			}
			scon.Close();
			return tbl_securityConfigType_ValueList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityConfigType_Value class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityConfigType_Value Maketbl_securityConfigType_Value(SqlDataReader dataReader) {
			tbl_securityConfigType_Value tbl_securityConfigType_Value = new tbl_securityConfigType_Value();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityConfigType_Value.ConfigTypeValue_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityConfigType_Value.ConfigTypeValue = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityConfigType_Value.Remark = dataReader.GetString(2);
			}

			return tbl_securityConfigType_Value;
		}
		/// <summary>
		/// This makes tbl_securityConfigType_Value datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityConfigType_Value object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityConfigType_Value  tbl_securityConfigType_Value   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_configTypeValue_ID = new DataColumn("configTypeValue_ID" , typeof(string));
			DataColumn col_configTypeValue = new DataColumn("configTypeValue" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_configTypeValue_ID,col_configTypeValue,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityConfigType_Value datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityConfigType_Value object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityConfigType_Value user) {
		DataRow drow = dt.NewRow();
		
			drow["configTypeValue_ID"] = user.configTypeValue_ID;
			drow["configTypeValue"] = user.configTypeValue;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
