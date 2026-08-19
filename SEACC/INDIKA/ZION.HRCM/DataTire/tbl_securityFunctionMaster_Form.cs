using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityFunctionMaster_Form {
		#region Fields
		private int function_ID;
		private string displayName;
		private int counter;
		private int length;
		private string prefix1;
		private bool isAutoGenerate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster_Form class.
		/// </summary>
		public tbl_securityFunctionMaster_Form() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster_Form class.
		/// </summary>
		public tbl_securityFunctionMaster_Form(int function_ID, string displayName, int counter, int length, string prefix1, bool isAutoGenerate) {
			this.function_ID = function_ID;
			this.displayName = displayName;
			this.counter = counter;
			this.length = length;
			this.prefix1 = prefix1;
			this.isAutoGenerate = isAutoGenerate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Function_ID value.
		/// </summary>
		public int Function_ID {
			get { return function_ID; }
			set { function_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DisplayName value.
		/// </summary>
		public string DisplayName {
			get { return displayName; }
			set { displayName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public int Counter {
			get { return counter; }
			set { counter = value; }
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
		/// Gets or sets the IsAutoGenerate value.
		/// </summary>
		public bool IsAutoGenerate {
			get { return isAutoGenerate; }
			set { isAutoGenerate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityFunctionMaster_Form table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_FormInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isAutoGenerate", SqlDbType.Bit,1);
 
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix1"].Value = prefix1;
			scom.Parameters["@isAutoGenerate"].Value = isAutoGenerate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityFunctionMaster_Form table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_FormUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isAutoGenerate", SqlDbType.Bit,1);
 
 
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix1"].Value = prefix1;
			scom.Parameters["@isAutoGenerate"].Value = isAutoGenerate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityFunctionMaster_Form table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_FormDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form table by a foreign key.
		/// </summary>
		public static void DeleteAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_FormDeleteAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityFunctionMaster_Form table.
		/// </summary>
		public static tbl_securityFunctionMaster_Form Select(int function_ID_Incoming){

			tbl_securityFunctionMaster_Form tbl_securityFunctionMaster_Formins = new tbl_securityFunctionMaster_Form();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_FormSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityFunctionMaster_Formins = Maketbl_securityFunctionMaster_Form(dataReader);
				} else {
					tbl_securityFunctionMaster_Formins = null;
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Formins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form table.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Form> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_FormSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityFunctionMaster_Form> tbl_securityFunctionMaster_FormList = new List<tbl_securityFunctionMaster_Form>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Form tbl_securityFunctionMaster_Form = Maketbl_securityFunctionMaster_Form(dataReader);
					tbl_securityFunctionMaster_FormList.Add(tbl_securityFunctionMaster_Form);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_FormList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Form> SelectAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_FormSelectAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
				List<tbl_securityFunctionMaster_Form> tbl_securityFunctionMaster_FormList = new List<tbl_securityFunctionMaster_Form>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Form tbl_securityFunctionMaster_Form = Maketbl_securityFunctionMaster_Form(dataReader);
					tbl_securityFunctionMaster_FormList.Add(tbl_securityFunctionMaster_Form);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_FormList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityFunctionMaster_Form class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityFunctionMaster_Form Maketbl_securityFunctionMaster_Form(SqlDataReader dataReader) {
			tbl_securityFunctionMaster_Form tbl_securityFunctionMaster_Form = new tbl_securityFunctionMaster_Form();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityFunctionMaster_Form.Function_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityFunctionMaster_Form.DisplayName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityFunctionMaster_Form.Counter = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityFunctionMaster_Form.Length = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityFunctionMaster_Form.Prefix1 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityFunctionMaster_Form.IsAutoGenerate = dataReader.GetBoolean(5);
			}

			return tbl_securityFunctionMaster_Form;
		}
		/// <summary>
		/// This makes tbl_securityFunctionMaster_Form datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster_Form object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityFunctionMaster_Form  tbl_securityFunctionMaster_Form   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_function_ID = new DataColumn("function_ID" , typeof(int));
			DataColumn col_displayName = new DataColumn("displayName" , typeof(string));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_prefix1 = new DataColumn("prefix1" , typeof(string));
			DataColumn col_isAutoGenerate = new DataColumn("isAutoGenerate" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_function_ID,col_displayName,col_counter,col_length,col_prefix1,col_isAutoGenerate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityFunctionMaster_Form datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster_Form object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityFunctionMaster_Form user) {
		DataRow drow = dt.NewRow();
		
			drow["function_ID"] = user.function_ID;
			drow["displayName"] = user.displayName;
			drow["counter"] = user.counter;
			drow["length"] = user.length;
			drow["prefix1"] = user.prefix1;
			drow["isAutoGenerate"] = user.isAutoGenerate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
