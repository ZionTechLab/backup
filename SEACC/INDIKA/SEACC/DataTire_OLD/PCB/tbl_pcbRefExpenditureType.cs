using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pcbRefExpenditureType {
		#region Fields
		private string pcbExpenditureType_ID;
		private string gl_ID;
		private bool isCanceled;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string canceldUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateCanceled;
		private string createUserTerminal_ID;
		private string modifiedUserTerminal_ID;
		private string canceledUserTerminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pcbRefExpenditureType class.
		/// </summary>
		public tbl_pcbRefExpenditureType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pcbRefExpenditureType class.
		/// </summary>
		public tbl_pcbRefExpenditureType(string pcbExpenditureType_ID, string gl_ID, bool isCanceled, string createUser_ID, string modifiedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string canceledUserTerminal_ID) {
			this.pcbExpenditureType_ID = pcbExpenditureType_ID;
			this.gl_ID = gl_ID;
			this.isCanceled = isCanceled;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.canceldUser_ID = canceldUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateCanceled = dateCanceled;
			this.createUserTerminal_ID = createUserTerminal_ID;
			this.modifiedUserTerminal_ID = modifiedUserTerminal_ID;
			this.canceledUserTerminal_ID = canceledUserTerminal_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PcbExpenditureType_ID value.
		/// </summary>
		public string PcbExpenditureType_ID {
			get { return pcbExpenditureType_ID; }
			set { pcbExpenditureType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceldUser_ID value.
		/// </summary>
		public string CanceldUser_ID {
			get { return canceldUser_ID; }
			set { canceldUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCanceled value.
		/// </summary>
		public DateTime DateCanceled {
			get { return dateCanceled; }
			set { dateCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUserTerminal_ID value.
		/// </summary>
		public string CreateUserTerminal_ID {
			get { return createUserTerminal_ID; }
			set { createUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUserTerminal_ID value.
		/// </summary>
		public string ModifiedUserTerminal_ID {
			get { return modifiedUserTerminal_ID; }
			set { modifiedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceledUserTerminal_ID value.
		/// </summary>
		public string CanceledUserTerminal_ID {
			get { return canceledUserTerminal_ID; }
			set { canceledUserTerminal_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pcbRefExpenditureType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pcbExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@pcbExpenditureType_ID"].Value = pcbExpenditureType_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pcbRefExpenditureType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pcbExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@pcbExpenditureType_ID"].Value = pcbExpenditureType_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pcbRefExpenditureType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pcbExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbExpenditureType_ID"].Value = pcbExpenditureType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbRefExpenditureType table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureTypeDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pcbRefExpenditureType table.
		/// </summary>
		public static tbl_pcbRefExpenditureType Select(string pcbExpenditureType_ID_Incoming){

			tbl_pcbRefExpenditureType tbl_pcbRefExpenditureTypeins = new tbl_pcbRefExpenditureType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbExpenditureType_ID"].Value = pcbExpenditureType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pcbRefExpenditureTypeins = Maketbl_pcbRefExpenditureType(dataReader);
				} else {
					tbl_pcbRefExpenditureTypeins = null;
				}
			}
			scon.Close();
			return tbl_pcbRefExpenditureTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbRefExpenditureType table.
		/// </summary>
		public static List<tbl_pcbRefExpenditureType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pcbRefExpenditureType> tbl_pcbRefExpenditureTypeList = new List<tbl_pcbRefExpenditureType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbRefExpenditureType tbl_pcbRefExpenditureType = Maketbl_pcbRefExpenditureType(dataReader);
					tbl_pcbRefExpenditureTypeList.Add(tbl_pcbRefExpenditureType);
				}
			}
			scon.Close();
			return tbl_pcbRefExpenditureTypeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbRefExpenditureType table by a foreign key.
		/// </summary>
		public static List<tbl_pcbRefExpenditureType> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureTypeSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_pcbRefExpenditureType> tbl_pcbRefExpenditureTypeList = new List<tbl_pcbRefExpenditureType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbRefExpenditureType tbl_pcbRefExpenditureType = Maketbl_pcbRefExpenditureType(dataReader);
					tbl_pcbRefExpenditureTypeList.Add(tbl_pcbRefExpenditureType);
				}
			}
			scon.Close();
			return tbl_pcbRefExpenditureTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pcbRefExpenditureType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pcbRefExpenditureType Maketbl_pcbRefExpenditureType(SqlDataReader dataReader) {
			tbl_pcbRefExpenditureType tbl_pcbRefExpenditureType = new tbl_pcbRefExpenditureType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pcbRefExpenditureType.PcbExpenditureType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pcbRefExpenditureType.Gl_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pcbRefExpenditureType.IsCanceled = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pcbRefExpenditureType.CreateUser_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pcbRefExpenditureType.ModifiedUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pcbRefExpenditureType.CanceldUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pcbRefExpenditureType.DateCreate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pcbRefExpenditureType.DateModified = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pcbRefExpenditureType.DateCanceled = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pcbRefExpenditureType.CreateUserTerminal_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pcbRefExpenditureType.ModifiedUserTerminal_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pcbRefExpenditureType.CanceledUserTerminal_ID = dataReader.GetString(11);
			}

			return tbl_pcbRefExpenditureType;
		}
		/// <summary>
		/// This makes tbl_pcbRefExpenditureType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pcbRefExpenditureType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pcbRefExpenditureType  tbl_pcbRefExpenditureType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pcbExpenditureType_ID = new DataColumn("pcbExpenditureType_ID" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_canceldUser_ID = new DataColumn("canceldUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
			DataColumn col_createUserTerminal_ID = new DataColumn("createUserTerminal_ID" , typeof(string));
			DataColumn col_modifiedUserTerminal_ID = new DataColumn("modifiedUserTerminal_ID" , typeof(string));
			DataColumn col_canceledUserTerminal_ID = new DataColumn("canceledUserTerminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_pcbExpenditureType_ID,col_gl_ID,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_canceledUserTerminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pcbRefExpenditureType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pcbRefExpenditureType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pcbRefExpenditureType user) {
		DataRow drow = dt.NewRow();
		
			drow["pcbExpenditureType_ID"] = user.pcbExpenditureType_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["isCanceled"] = user.isCanceled;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["canceldUser_ID"] = user.canceldUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateCanceled"] = user.dateCanceled;
			drow["createUserTerminal_ID"] = user.createUserTerminal_ID;
			drow["modifiedUserTerminal_ID"] = user.modifiedUserTerminal_ID;
			drow["canceledUserTerminal_ID"] = user.canceledUserTerminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
