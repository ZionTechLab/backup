using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pcbRefExpenditureCategory {
		#region Fields
		private string pcbExpenditureCategory_ID;
		private string pcbExpenditureType_ID;
		private string pcbExpenditureCategoryName;
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
		/// Initializes a new instance of the tbl_pcbRefExpenditureCategory class.
		/// </summary>
		public tbl_pcbRefExpenditureCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pcbRefExpenditureCategory class.
		/// </summary>
		public tbl_pcbRefExpenditureCategory(string pcbExpenditureCategory_ID, string pcbExpenditureType_ID, string pcbExpenditureCategoryName, bool isCanceled, string createUser_ID, string modifiedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string canceledUserTerminal_ID) {
			this.pcbExpenditureCategory_ID = pcbExpenditureCategory_ID;
			this.pcbExpenditureType_ID = pcbExpenditureType_ID;
			this.pcbExpenditureCategoryName = pcbExpenditureCategoryName;
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
		/// Gets or sets the PcbExpenditureCategory_ID value.
		/// </summary>
		public string PcbExpenditureCategory_ID {
			get { return pcbExpenditureCategory_ID; }
			set { pcbExpenditureCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PcbExpenditureType_ID value.
		/// </summary>
		public string PcbExpenditureType_ID {
			get { return pcbExpenditureType_ID; }
			set { pcbExpenditureType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PcbExpenditureCategoryName value.
		/// </summary>
		public string PcbExpenditureCategoryName {
			get { return pcbExpenditureCategoryName; }
			set { pcbExpenditureCategoryName = value; }
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
		/// Saves a record to the tbl_pcbRefExpenditureCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pcbExpenditureCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pcbExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pcbExpenditureCategoryName", SqlDbType.VarChar,50);
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
 
			scom.Parameters["@pcbExpenditureCategory_ID"].Value = pcbExpenditureCategory_ID;
			scom.Parameters["@pcbExpenditureType_ID"].Value = pcbExpenditureType_ID;
			scom.Parameters["@pcbExpenditureCategoryName"].Value = pcbExpenditureCategoryName;
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
		/// Updates a record in the tbl_pcbRefExpenditureCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pcbExpenditureCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pcbExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pcbExpenditureCategoryName", SqlDbType.VarChar,50);
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
 
 
			scom.Parameters["@pcbExpenditureCategory_ID"].Value = pcbExpenditureCategory_ID;
			scom.Parameters["@pcbExpenditureType_ID"].Value = pcbExpenditureType_ID;
			scom.Parameters["@pcbExpenditureCategoryName"].Value = pcbExpenditureCategoryName;
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
		/// Deletes a record from the tbl_pcbRefExpenditureCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pcbExpenditureCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbExpenditureCategory_ID"].Value = pcbExpenditureCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbRefExpenditureCategory table by a foreign key.
		/// </summary>
		public static void DeleteAllByPcbExpenditureType_ID(string pcbExpenditureType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureCategoryDeleteAllByPcbExpenditureType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbExpenditureType_ID"].Value = pcbExpenditureType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pcbRefExpenditureCategory table.
		/// </summary>
		public static tbl_pcbRefExpenditureCategory Select(string pcbExpenditureCategory_ID_Incoming){

			tbl_pcbRefExpenditureCategory tbl_pcbRefExpenditureCategoryins = new tbl_pcbRefExpenditureCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbExpenditureCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbExpenditureCategory_ID"].Value = pcbExpenditureCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pcbRefExpenditureCategoryins = Maketbl_pcbRefExpenditureCategory(dataReader);
				} else {
					tbl_pcbRefExpenditureCategoryins = null;
				}
			}
			scon.Close();
			return tbl_pcbRefExpenditureCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbRefExpenditureCategory table.
		/// </summary>
		public static List<tbl_pcbRefExpenditureCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pcbRefExpenditureCategory> tbl_pcbRefExpenditureCategoryList = new List<tbl_pcbRefExpenditureCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbRefExpenditureCategory tbl_pcbRefExpenditureCategory = Maketbl_pcbRefExpenditureCategory(dataReader);
					tbl_pcbRefExpenditureCategoryList.Add(tbl_pcbRefExpenditureCategory);
				}
			}
			scon.Close();
			return tbl_pcbRefExpenditureCategoryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbRefExpenditureCategory table by a foreign key.
		/// </summary>
		public static List<tbl_pcbRefExpenditureCategory> SelectAllByPcbExpenditureType_ID(string pcbExpenditureType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbRefExpenditureCategorySelectAllByPcbExpenditureType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbExpenditureType_ID"].Value = pcbExpenditureType_ID;
				List<tbl_pcbRefExpenditureCategory> tbl_pcbRefExpenditureCategoryList = new List<tbl_pcbRefExpenditureCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbRefExpenditureCategory tbl_pcbRefExpenditureCategory = Maketbl_pcbRefExpenditureCategory(dataReader);
					tbl_pcbRefExpenditureCategoryList.Add(tbl_pcbRefExpenditureCategory);
				}
			}
			scon.Close();
			return tbl_pcbRefExpenditureCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pcbRefExpenditureCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pcbRefExpenditureCategory Maketbl_pcbRefExpenditureCategory(SqlDataReader dataReader) {
			tbl_pcbRefExpenditureCategory tbl_pcbRefExpenditureCategory = new tbl_pcbRefExpenditureCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pcbRefExpenditureCategory.PcbExpenditureCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pcbRefExpenditureCategory.PcbExpenditureType_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pcbRefExpenditureCategory.PcbExpenditureCategoryName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pcbRefExpenditureCategory.IsCanceled = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pcbRefExpenditureCategory.CreateUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pcbRefExpenditureCategory.ModifiedUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pcbRefExpenditureCategory.CanceldUser_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pcbRefExpenditureCategory.DateCreate = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pcbRefExpenditureCategory.DateModified = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pcbRefExpenditureCategory.DateCanceled = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pcbRefExpenditureCategory.CreateUserTerminal_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pcbRefExpenditureCategory.ModifiedUserTerminal_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pcbRefExpenditureCategory.CanceledUserTerminal_ID = dataReader.GetString(12);
			}

			return tbl_pcbRefExpenditureCategory;
		}
		/// <summary>
		/// This makes tbl_pcbRefExpenditureCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pcbRefExpenditureCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pcbRefExpenditureCategory  tbl_pcbRefExpenditureCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pcbExpenditureCategory_ID = new DataColumn("pcbExpenditureCategory_ID" , typeof(string));
			DataColumn col_pcbExpenditureType_ID = new DataColumn("pcbExpenditureType_ID" , typeof(string));
			DataColumn col_pcbExpenditureCategoryName = new DataColumn("pcbExpenditureCategoryName" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_pcbExpenditureCategory_ID,col_pcbExpenditureType_ID,col_pcbExpenditureCategoryName,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_canceledUserTerminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pcbRefExpenditureCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pcbRefExpenditureCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pcbRefExpenditureCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["pcbExpenditureCategory_ID"] = user.pcbExpenditureCategory_ID;
			drow["pcbExpenditureType_ID"] = user.pcbExpenditureType_ID;
			drow["pcbExpenditureCategoryName"] = user.pcbExpenditureCategoryName;
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
