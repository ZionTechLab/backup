using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityConfigForms {
		#region Fields
		private string configForm_ID;
		private int counter;
		private string configName;
		private int length;
		private string prefix1;
		private string seperator1;
		private string prefix2;
		private string seperator2;
		private bool isAutoGenerate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityConfigForms class.
		/// </summary>
		public tbl_securityConfigForms() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityConfigForms class.
		/// </summary>
		public tbl_securityConfigForms(string configForm_ID, int counter, string configName, int length, string prefix1, string seperator1, string prefix2, string seperator2, bool isAutoGenerate) {
			this.configForm_ID = configForm_ID;
			this.counter = counter;
			this.configName = configName;
			this.length = length;
			this.prefix1 = prefix1;
			this.seperator1 = seperator1;
			this.prefix2 = prefix2;
			this.seperator2 = seperator2;
			this.isAutoGenerate = isAutoGenerate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ConfigForm_ID value.
		/// </summary>
		public string ConfigForm_ID {
			get { return configForm_ID; }
			set { configForm_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public int Counter {
			get { return counter; }
			set { counter = value; }
		}
		
		/// <summary>
		/// Gets or sets the ConfigName value.
		/// </summary>
		public string ConfigName {
			get { return configName; }
			set { configName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public int Length {
			get { return length; }
			set { length = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix1 value.
		/// </summary>
		public string Prefix1 {
			get { return prefix1; }
			set { prefix1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Seperator1 value.
		/// </summary>
		public string Seperator1 {
			get { return seperator1; }
			set { seperator1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix2 value.
		/// </summary>
		public string Prefix2 {
			get { return prefix2; }
			set { prefix2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Seperator2 value.
		/// </summary>
		public string Seperator2 {
			get { return seperator2; }
			set { seperator2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAutoGenerate value.
		/// </summary>
		public bool IsAutoGenerate {
			get { return isAutoGenerate; }
			set { isAutoGenerate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityConfigForms table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigFormsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@configForm_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@configName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefix2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isAutoGenerate", SqlDbType.Bit,1);
 
			scom.Parameters["@configForm_ID"].Value = configForm_ID;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@configName"].Value = configName;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix1"].Value = prefix1;
			scom.Parameters["@seperator1"].Value = seperator1;
			scom.Parameters["@prefix2"].Value = prefix2;
			scom.Parameters["@seperator2"].Value = seperator2;
			scom.Parameters["@isAutoGenerate"].Value = isAutoGenerate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityConfigForms table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigFormsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@configForm_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@configName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefix2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isAutoGenerate", SqlDbType.Bit,1);
 
 
			scom.Parameters["@configForm_ID"].Value = configForm_ID;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@configName"].Value = configName;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix1"].Value = prefix1;
			scom.Parameters["@seperator1"].Value = seperator1;
			scom.Parameters["@prefix2"].Value = prefix2;
			scom.Parameters["@seperator2"].Value = seperator2;
			scom.Parameters["@isAutoGenerate"].Value = isAutoGenerate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityConfigForms table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigFormsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@configForm_ID", SqlDbType.VarChar,10);
			scom.Parameters["@configForm_ID"].Value = configForm_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityConfigForms table.
		/// </summary>
		public static tbl_securityConfigForms Select(string configForm_ID_Incoming){

			tbl_securityConfigForms tbl_securityConfigFormsins = new tbl_securityConfigForms();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigFormsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@configForm_ID", SqlDbType.VarChar,10);
			scom.Parameters["@configForm_ID"].Value = configForm_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityConfigFormsins = Maketbl_securityConfigForms(dataReader);
				} else {
					tbl_securityConfigFormsins = null;
				}
			}
			scon.Close();
			return tbl_securityConfigFormsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityConfigForms table.
		/// </summary>
		public static List<tbl_securityConfigForms> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityConfigFormsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityConfigForms> tbl_securityConfigFormsList = new List<tbl_securityConfigForms>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityConfigForms tbl_securityConfigForms = Maketbl_securityConfigForms(dataReader);
					tbl_securityConfigFormsList.Add(tbl_securityConfigForms);
				}
			}
			scon.Close();
			return tbl_securityConfigFormsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityConfigForms class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityConfigForms Maketbl_securityConfigForms(SqlDataReader dataReader) {
			tbl_securityConfigForms tbl_securityConfigForms = new tbl_securityConfigForms();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityConfigForms.ConfigForm_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityConfigForms.Counter = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityConfigForms.ConfigName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityConfigForms.Length = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityConfigForms.Prefix1 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityConfigForms.Seperator1 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityConfigForms.Prefix2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_securityConfigForms.Seperator2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_securityConfigForms.IsAutoGenerate = dataReader.GetBoolean(8);
			}

			return tbl_securityConfigForms;
		}
		/// <summary>
		/// This makes tbl_securityConfigForms datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityConfigForms object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityConfigForms  tbl_securityConfigForms   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_configForm_ID = new DataColumn("configForm_ID" , typeof(string));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_configName = new DataColumn("configName" , typeof(string));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_prefix1 = new DataColumn("prefix1" , typeof(string));
			DataColumn col_seperator1 = new DataColumn("seperator1" , typeof(string));
			DataColumn col_prefix2 = new DataColumn("prefix2" , typeof(string));
			DataColumn col_seperator2 = new DataColumn("seperator2" , typeof(string));
			DataColumn col_isAutoGenerate = new DataColumn("isAutoGenerate" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_configForm_ID,col_counter,col_configName,col_length,col_prefix1,col_seperator1,col_prefix2,col_seperator2,col_isAutoGenerate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityConfigForms datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityConfigForms object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityConfigForms user) {
		DataRow drow = dt.NewRow();
		
			drow["configForm_ID"] = user.configForm_ID;
			drow["counter"] = user.counter;
			drow["configName"] = user.configName;
			drow["length"] = user.length;
			drow["prefix1"] = user.prefix1;
			drow["seperator1"] = user.seperator1;
			drow["prefix2"] = user.prefix2;
			drow["seperator2"] = user.seperator2;
			drow["isAutoGenerate"] = user.isAutoGenerate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
