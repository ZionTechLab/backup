using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityFunctionMaster_Form_Advanced {
		#region Fields
		private string companyID;
		private string companyBranch_ID;
		private int function_ID;
		private string salesNoteType_ID;
		private string prefix;
		private int counter;
		private int length;
		private bool isAutoGenerate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster_Form_Advanced class.
		/// </summary>
		public tbl_securityFunctionMaster_Form_Advanced() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionMaster_Form_Advanced class.
		/// </summary>
		public tbl_securityFunctionMaster_Form_Advanced(string companyID, string companyBranch_ID, int function_ID, string salesNoteType_ID, string prefix, int counter, int length, bool isAutoGenerate) {
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.function_ID = function_ID;
			this.salesNoteType_ID = salesNoteType_ID;
			this.prefix = prefix;
			this.counter = counter;
			this.length = length;
			this.isAutoGenerate = isAutoGenerate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Function_ID value.
		/// </summary>
		public int Function_ID {
			get { return function_ID; }
			set { function_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesNoteType_ID value.
		/// </summary>
		public string SalesNoteType_ID {
			get { return salesNoteType_ID; }
			set { salesNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
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
		/// Gets or sets the IsAutoGenerate value.
		/// </summary>
		public bool IsAutoGenerate {
			get { return isAutoGenerate; }
			set { isAutoGenerate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityFunctionMaster_Form_Advanced table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@isAutoGenerate", SqlDbType.Bit,1);
 
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@isAutoGenerate"].Value = isAutoGenerate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityFunctionMaster_Form_Advanced table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@isAutoGenerate", SqlDbType.Bit,1);
 
 
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@isAutoGenerate"].Value = isAutoGenerate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityFunctionMaster_Form_Advanced table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@function_ID"].Value = function_ID;
 
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form_Advanced table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesNoteType_ID(string salesNoteType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedDeleteAllBySalesNoteType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form_Advanced table by a foreign key.
		/// </summary>
		public static void DeleteAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedDeleteAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form_Advanced table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form_Advanced table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityFunctionMaster_Form_Advanced table.
		/// </summary>
		public static tbl_securityFunctionMaster_Form_Advanced Select(string companyID_Incoming, string companyBranch_ID_Incoming, int function_ID_Incoming, string salesNoteType_ID_Incoming){

			tbl_securityFunctionMaster_Form_Advanced tbl_securityFunctionMaster_Form_Advancedins = new tbl_securityFunctionMaster_Form_Advanced();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@function_ID"].Value = function_ID_Incoming;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityFunctionMaster_Form_Advancedins = Maketbl_securityFunctionMaster_Form_Advanced(dataReader);
				} else {
					tbl_securityFunctionMaster_Form_Advancedins = null;
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Form_Advancedins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form_Advanced table.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Form_Advanced> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityFunctionMaster_Form_Advanced> tbl_securityFunctionMaster_Form_AdvancedList = new List<tbl_securityFunctionMaster_Form_Advanced>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Form_Advanced tbl_securityFunctionMaster_Form_Advanced = Maketbl_securityFunctionMaster_Form_Advanced(dataReader);
					tbl_securityFunctionMaster_Form_AdvancedList.Add(tbl_securityFunctionMaster_Form_Advanced);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Form_AdvancedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form_Advanced table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Form_Advanced> SelectAllBySalesNoteType_ID(string salesNoteType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedSelectAllBySalesNoteType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
				List<tbl_securityFunctionMaster_Form_Advanced> tbl_securityFunctionMaster_Form_AdvancedList = new List<tbl_securityFunctionMaster_Form_Advanced>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Form_Advanced tbl_securityFunctionMaster_Form_Advanced = Maketbl_securityFunctionMaster_Form_Advanced(dataReader);
					tbl_securityFunctionMaster_Form_AdvancedList.Add(tbl_securityFunctionMaster_Form_Advanced);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Form_AdvancedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form_Advanced table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Form_Advanced> SelectAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedSelectAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
				List<tbl_securityFunctionMaster_Form_Advanced> tbl_securityFunctionMaster_Form_AdvancedList = new List<tbl_securityFunctionMaster_Form_Advanced>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Form_Advanced tbl_securityFunctionMaster_Form_Advanced = Maketbl_securityFunctionMaster_Form_Advanced(dataReader);
					tbl_securityFunctionMaster_Form_AdvancedList.Add(tbl_securityFunctionMaster_Form_Advanced);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Form_AdvancedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form_Advanced table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Form_Advanced> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_securityFunctionMaster_Form_Advanced> tbl_securityFunctionMaster_Form_AdvancedList = new List<tbl_securityFunctionMaster_Form_Advanced>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Form_Advanced tbl_securityFunctionMaster_Form_Advanced = Maketbl_securityFunctionMaster_Form_Advanced(dataReader);
					tbl_securityFunctionMaster_Form_AdvancedList.Add(tbl_securityFunctionMaster_Form_Advanced);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Form_AdvancedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionMaster_Form_Advanced table by a foreign key.
		/// </summary>
		public static List<tbl_securityFunctionMaster_Form_Advanced> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionMaster_Form_AdvancedSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_securityFunctionMaster_Form_Advanced> tbl_securityFunctionMaster_Form_AdvancedList = new List<tbl_securityFunctionMaster_Form_Advanced>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionMaster_Form_Advanced tbl_securityFunctionMaster_Form_Advanced = Maketbl_securityFunctionMaster_Form_Advanced(dataReader);
					tbl_securityFunctionMaster_Form_AdvancedList.Add(tbl_securityFunctionMaster_Form_Advanced);
				}
			}
			scon.Close();
			return tbl_securityFunctionMaster_Form_AdvancedList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityFunctionMaster_Form_Advanced class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityFunctionMaster_Form_Advanced Maketbl_securityFunctionMaster_Form_Advanced(SqlDataReader dataReader) {
			tbl_securityFunctionMaster_Form_Advanced tbl_securityFunctionMaster_Form_Advanced = new tbl_securityFunctionMaster_Form_Advanced();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityFunctionMaster_Form_Advanced.CompanyID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityFunctionMaster_Form_Advanced.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityFunctionMaster_Form_Advanced.Function_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityFunctionMaster_Form_Advanced.SalesNoteType_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityFunctionMaster_Form_Advanced.Prefix = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityFunctionMaster_Form_Advanced.Counter = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityFunctionMaster_Form_Advanced.Length = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_securityFunctionMaster_Form_Advanced.IsAutoGenerate = dataReader.GetBoolean(7);
			}

			return tbl_securityFunctionMaster_Form_Advanced;
		}
		/// <summary>
		/// This makes tbl_securityFunctionMaster_Form_Advanced datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster_Form_Advanced object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityFunctionMaster_Form_Advanced  tbl_securityFunctionMaster_Form_Advanced   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_function_ID = new DataColumn("function_ID" , typeof(int));
			DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID" , typeof(string));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_isAutoGenerate = new DataColumn("isAutoGenerate" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_companyID,col_companyBranch_ID,col_function_ID,col_salesNoteType_ID,col_prefix,col_counter,col_length,col_isAutoGenerate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityFunctionMaster_Form_Advanced datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityFunctionMaster_Form_Advanced object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityFunctionMaster_Form_Advanced user) {
		DataRow drow = dt.NewRow();
		
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["function_ID"] = user.function_ID;
			drow["salesNoteType_ID"] = user.salesNoteType_ID;
			drow["prefix"] = user.prefix;
			drow["counter"] = user.counter;
			drow["length"] = user.length;
			drow["isAutoGenerate"] = user.isAutoGenerate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
