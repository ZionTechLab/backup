using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccGLMaster_AccountType {
		#region Fields
		private int line_No;
		private string glAccountType_ID;
		private string glAccountType_3rdPartyCode;
		private string glAccountTypeName;
		private bool isCredit;
		private bool isActive;
		private string glSubCatagory_ID;
		private int counter;
		private int length;
		private string prefix;
		private string seperator;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAccGLMaster_AccountType class.
		/// </summary>
		public tbl_zAccGLMaster_AccountType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAccGLMaster_AccountType class.
		/// </summary>
		public tbl_zAccGLMaster_AccountType(int line_No, string glAccountType_ID, string glAccountType_3rdPartyCode, string glAccountTypeName, bool isCredit, bool isActive, string glSubCatagory_ID, int counter, int length, string prefix, string seperator) {
			this.line_No = line_No;
			this.glAccountType_ID = glAccountType_ID;
			this.glAccountType_3rdPartyCode = glAccountType_3rdPartyCode;
			this.glAccountTypeName = glAccountTypeName;
			this.isCredit = isCredit;
			this.isActive = isActive;
			this.glSubCatagory_ID = glSubCatagory_ID;
			this.counter = counter;
			this.length = length;
			this.prefix = prefix;
			this.seperator = seperator;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlAccountType_ID value.
		/// </summary>
		public string GlAccountType_ID {
			get { return glAccountType_ID; }
			set { glAccountType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlAccountType_3rdPartyCode value.
		/// </summary>
		public string GlAccountType_3rdPartyCode {
			get { return glAccountType_3rdPartyCode; }
			set { glAccountType_3rdPartyCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlAccountTypeName value.
		/// </summary>
		public string GlAccountTypeName {
			get { return glAccountTypeName; }
			set { glAccountTypeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCredit value.
		/// </summary>
		public bool IsCredit {
			get { return isCredit; }
			set { isCredit = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlSubCatagory_ID value.
		/// </summary>
		public string GlSubCatagory_ID {
			get { return glSubCatagory_ID; }
			set { glSubCatagory_ID = value; }
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
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Seperator value.
		/// </summary>
		public string Seperator {
			get { return seperator; }
			set { seperator = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAccGLMaster_AccountType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_AccountTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@glAccountType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glAccountType_3rdPartyCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glAccountTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@glSubCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator", SqlDbType.VarChar,50);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@glAccountType_ID"].Value = glAccountType_ID;
			scom.Parameters["@glAccountType_3rdPartyCode"].Value = glAccountType_3rdPartyCode;
			scom.Parameters["@glAccountTypeName"].Value = glAccountTypeName;
			scom.Parameters["@isCredit"].Value = isCredit;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@glSubCatagory_ID"].Value = glSubCatagory_ID;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@seperator"].Value = seperator;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAccGLMaster_AccountType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_AccountTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@glAccountType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glAccountType_3rdPartyCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glAccountTypeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@glSubCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@length", SqlDbType.Int,4);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@seperator", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@glAccountType_ID"].Value = glAccountType_ID;
			scom.Parameters["@glAccountType_3rdPartyCode"].Value = glAccountType_3rdPartyCode;
			scom.Parameters["@glAccountTypeName"].Value = glAccountTypeName;
			scom.Parameters["@isCredit"].Value = isCredit;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@glSubCatagory_ID"].Value = glSubCatagory_ID;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@seperator"].Value = seperator;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAccGLMaster_AccountType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_AccountTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@glAccountType_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glAccountType_ID"].Value = glAccountType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccGLMaster_AccountType table by a foreign key.
		/// </summary>
		public static void DeleteAllByGlSubCatagory_ID(string glSubCatagory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_AccountTypeDeleteAllByGlSubCatagory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glSubCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glSubCatagory_ID"].Value = glSubCatagory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAccGLMaster_AccountType table.
		/// </summary>
		public static tbl_zAccGLMaster_AccountType Select(string glAccountType_ID_Incoming){

			tbl_zAccGLMaster_AccountType tbl_zAccGLMaster_AccountTypeins = new tbl_zAccGLMaster_AccountType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_AccountTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glAccountType_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glAccountType_ID"].Value = glAccountType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAccGLMaster_AccountTypeins = Maketbl_zAccGLMaster_AccountType(dataReader);
				} else {
					tbl_zAccGLMaster_AccountTypeins = null;
				}
			}
			scon.Close();
			return tbl_zAccGLMaster_AccountTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccGLMaster_AccountType table.
		/// </summary>
		public static List<tbl_zAccGLMaster_AccountType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_AccountTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAccGLMaster_AccountType> tbl_zAccGLMaster_AccountTypeList = new List<tbl_zAccGLMaster_AccountType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccGLMaster_AccountType tbl_zAccGLMaster_AccountType = Maketbl_zAccGLMaster_AccountType(dataReader);
					tbl_zAccGLMaster_AccountTypeList.Add(tbl_zAccGLMaster_AccountType);
				}
			}
			scon.Close();
			return tbl_zAccGLMaster_AccountTypeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccGLMaster_AccountType table by a foreign key.
		/// </summary>
		public static List<tbl_zAccGLMaster_AccountType> SelectAllByGlSubCatagory_ID(string glSubCatagory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccGLMaster_AccountTypeSelectAllByGlSubCatagory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glSubCatagory_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glSubCatagory_ID"].Value = glSubCatagory_ID;
				List<tbl_zAccGLMaster_AccountType> tbl_zAccGLMaster_AccountTypeList = new List<tbl_zAccGLMaster_AccountType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccGLMaster_AccountType tbl_zAccGLMaster_AccountType = Maketbl_zAccGLMaster_AccountType(dataReader);
					tbl_zAccGLMaster_AccountTypeList.Add(tbl_zAccGLMaster_AccountType);
				}
			}
			scon.Close();
			return tbl_zAccGLMaster_AccountTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAccGLMaster_AccountType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAccGLMaster_AccountType Maketbl_zAccGLMaster_AccountType(SqlDataReader dataReader) {
			tbl_zAccGLMaster_AccountType tbl_zAccGLMaster_AccountType = new tbl_zAccGLMaster_AccountType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAccGLMaster_AccountType.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccGLMaster_AccountType.GlAccountType_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zAccGLMaster_AccountType.GlAccountType_3rdPartyCode = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zAccGLMaster_AccountType.GlAccountTypeName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zAccGLMaster_AccountType.IsCredit = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zAccGLMaster_AccountType.IsActive = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zAccGLMaster_AccountType.GlSubCatagory_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zAccGLMaster_AccountType.Counter = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zAccGLMaster_AccountType.Length = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_zAccGLMaster_AccountType.Prefix = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_zAccGLMaster_AccountType.Seperator = dataReader.GetString(10);
			}

			return tbl_zAccGLMaster_AccountType;
		}
		/// <summary>
		/// This makes tbl_zAccGLMaster_AccountType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAccGLMaster_AccountType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAccGLMaster_AccountType  tbl_zAccGLMaster_AccountType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_glAccountType_ID = new DataColumn("glAccountType_ID" , typeof(string));
			DataColumn col_glAccountType_3rdPartyCode = new DataColumn("glAccountType_3rdPartyCode" , typeof(string));
			DataColumn col_glAccountTypeName = new DataColumn("glAccountTypeName" , typeof(string));
			DataColumn col_isCredit = new DataColumn("isCredit" , typeof(bool));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
			DataColumn col_glSubCatagory_ID = new DataColumn("glSubCatagory_ID" , typeof(string));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_length = new DataColumn("length" , typeof(int));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_seperator = new DataColumn("seperator" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_glAccountType_ID,col_glAccountType_3rdPartyCode,col_glAccountTypeName,col_isCredit,col_isActive,col_glSubCatagory_ID,col_counter,col_length,col_prefix,col_seperator,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccGLMaster_AccountType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccGLMaster_AccountType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccGLMaster_AccountType user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["glAccountType_ID"] = user.glAccountType_ID;
			drow["glAccountType_3rdPartyCode"] = user.glAccountType_3rdPartyCode;
			drow["glAccountTypeName"] = user.glAccountTypeName;
			drow["isCredit"] = user.isCredit;
			drow["isActive"] = user.isActive;
			drow["glSubCatagory_ID"] = user.glSubCatagory_ID;
			drow["counter"] = user.counter;
			drow["length"] = user.length;
			drow["prefix"] = user.prefix;
			drow["seperator"] = user.seperator;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
