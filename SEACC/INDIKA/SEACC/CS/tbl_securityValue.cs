using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityValue {
		#region Fields
		private string securityCode;
		private string securityValue;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityValue class.
		/// </summary>
		public tbl_securityValue() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityValue class.
		/// </summary>
		public tbl_securityValue(string securityCode, string securityValue) {
			this.securityCode = securityCode;
			this.securityValue = securityValue;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SecurityCode value.
		/// </summary>
		public string SecurityCode {
			get { return securityCode; }
			set { securityCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the SecurityValue value.
		/// </summary>
		public string SecurityValue {
			get { return securityValue; }
			set { securityValue = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityValue table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityValueInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@securityCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@securityValue", SqlDbType.VarChar,100);
 
			scom.Parameters["@securityCode"].Value = securityCode;
			scom.Parameters["@securityValue"].Value = securityValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityValue table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityValueUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@securityCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@securityValue", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@securityCode"].Value = securityCode;
			scom.Parameters["@securityValue"].Value = securityValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityValue table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityValueDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@securityCode", SqlDbType.VarChar,20);
			scom.Parameters["@securityCode"].Value = securityCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityValue table.
		/// </summary>
		public static tbl_securityValue Select(string securityCode_Incoming){

			tbl_securityValue tbl_securityValueins = new tbl_securityValue();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityValueSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@securityCode", SqlDbType.VarChar,20);
			scom.Parameters["@securityCode"].Value = securityCode_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityValueins = Maketbl_securityValue(dataReader);
				} else {
					tbl_securityValueins = null;
				}
			}
			scon.Close();
			return tbl_securityValueins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityValue table.
		/// </summary>
		public static List<tbl_securityValue> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityValueSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityValue> tbl_securityValueList = new List<tbl_securityValue>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityValue tbl_securityValue = Maketbl_securityValue(dataReader);
					tbl_securityValueList.Add(tbl_securityValue);
				}
			}
			scon.Close();
			return tbl_securityValueList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityValue class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityValue Maketbl_securityValue(SqlDataReader dataReader) {
			tbl_securityValue tbl_securityValue = new tbl_securityValue();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityValue.SecurityCode = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityValue.SecurityValue = dataReader.GetString(1);
			}

			return tbl_securityValue;
		}
		/// <summary>
		/// This makes tbl_securityValue datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityValue object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityValue  tbl_securityValue   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_securityCode = new DataColumn("securityCode" , typeof(string));
			DataColumn col_securityValue = new DataColumn("securityValue" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_securityCode,col_securityValue,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityValue datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityValue object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityValue user) {
		DataRow drow = dt.NewRow();
		
			drow["securityCode"] = user.securityCode;
			drow["securityValue"] = user.securityValue;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
