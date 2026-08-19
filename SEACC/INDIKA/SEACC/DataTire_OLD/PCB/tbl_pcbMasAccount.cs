
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_pcbMasAccount {
		#region Fields
		private string pcbAccount_ID;
		private string pcbAccountName;
		private string assignedUser_ID;
		private string currency_ID;
		private decimal floatAmount;
		private string remarks;
		private string gl_ID;
		private string prefix;
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
		private int counter;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pcbMasAccount class.
		/// </summary>
		public tbl_pcbMasAccount() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pcbMasAccount class.
		/// </summary>
		public tbl_pcbMasAccount(string pcbAccount_ID, string pcbAccountName, string assignedUser_ID, string currency_ID, decimal floatAmount, string remarks, string gl_ID, string prefix, bool isCanceled, string createUser_ID, string modifiedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string canceledUserTerminal_ID, int counter) {
			this.pcbAccount_ID = pcbAccount_ID;
			this.pcbAccountName = pcbAccountName;
			this.assignedUser_ID = assignedUser_ID;
			this.currency_ID = currency_ID;
			this.floatAmount = floatAmount;
			this.remarks = remarks;
			this.gl_ID = gl_ID;
			this.prefix = prefix;
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
			this.counter = counter;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PcbAccount_ID value.
		/// </summary>
		public string PcbAccount_ID {
			get { return pcbAccount_ID; }
			set { pcbAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PcbAccountName value.
		/// </summary>
		public string PcbAccountName {
			get { return pcbAccountName; }
			set { pcbAccountName = value; }
		}
		
		/// <summary>
		/// Gets or sets the AssignedUser_ID value.
		/// </summary>
		public string AssignedUser_ID {
			get { return assignedUser_ID; }
			set { assignedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FloatAmount value.
		/// </summary>
		public decimal FloatAmount {
			get { return floatAmount; }
			set { floatAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
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
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public int Counter {
			get { return counter; }
			set { counter = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pcbMasAccount table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pcbAccountName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@assignedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@floatAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,10);
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
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
 
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
			scom.Parameters["@pcbAccountName"].Value = pcbAccountName;
			scom.Parameters["@assignedUser_ID"].Value = assignedUser_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@floatAmount"].Value = floatAmount;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@prefix"].Value = prefix;
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
			scom.Parameters["@counter"].Value = counter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pcbMasAccount table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pcbAccountName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@assignedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@floatAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,10);
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
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
 
 
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
			scom.Parameters["@pcbAccountName"].Value = pcbAccountName;
			scom.Parameters["@assignedUser_ID"].Value = assignedUser_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@floatAmount"].Value = floatAmount;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@prefix"].Value = prefix;
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
			scom.Parameters["@counter"].Value = counter;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pcbMasAccount table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbMasAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbMasAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByCurrency_ID(string currency_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountDeleteAllByCurrency_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbMasAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByAssignedUser_ID(string assignedUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountDeleteAllByAssignedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assignedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@assignedUser_ID"].Value = assignedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pcbMasAccount table.
		/// </summary>
		public static tbl_pcbMasAccount Select(string pcbAccount_ID_Incoming){

			tbl_pcbMasAccount tbl_pcbMasAccountins = new tbl_pcbMasAccount();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pcbAccount_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pcbAccount_ID"].Value = pcbAccount_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pcbMasAccountins = Maketbl_pcbMasAccount(dataReader);
				} else {
					tbl_pcbMasAccountins = null;
				}
			}
			scon.Close();
			return tbl_pcbMasAccountins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbMasAccount table.
		/// </summary>
		public static List<tbl_pcbMasAccount> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pcbMasAccount> tbl_pcbMasAccountList = new List<tbl_pcbMasAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbMasAccount tbl_pcbMasAccount = Maketbl_pcbMasAccount(dataReader);
					tbl_pcbMasAccountList.Add(tbl_pcbMasAccount);
				}
			}
			scon.Close();
			return tbl_pcbMasAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbMasAccount table by a foreign key.
		/// </summary>
		public static List<tbl_pcbMasAccount> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_pcbMasAccount> tbl_pcbMasAccountList = new List<tbl_pcbMasAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbMasAccount tbl_pcbMasAccount = Maketbl_pcbMasAccount(dataReader);
					tbl_pcbMasAccountList.Add(tbl_pcbMasAccount);
				}
			}
			scon.Close();
			return tbl_pcbMasAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbMasAccount table by a foreign key.
		/// </summary>
		public static List<tbl_pcbMasAccount> SelectAllByCurrency_ID(string currency_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountSelectAllByCurrency_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
				List<tbl_pcbMasAccount> tbl_pcbMasAccountList = new List<tbl_pcbMasAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbMasAccount tbl_pcbMasAccount = Maketbl_pcbMasAccount(dataReader);
					tbl_pcbMasAccountList.Add(tbl_pcbMasAccount);
				}
			}
			scon.Close();
			return tbl_pcbMasAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pcbMasAccount table by a foreign key.
		/// </summary>
		public static List<tbl_pcbMasAccount> SelectAllByAssignedUser_ID(string assignedUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pcbMasAccountSelectAllByAssignedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assignedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@assignedUser_ID"].Value = assignedUser_ID;
				List<tbl_pcbMasAccount> tbl_pcbMasAccountList = new List<tbl_pcbMasAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pcbMasAccount tbl_pcbMasAccount = Maketbl_pcbMasAccount(dataReader);
					tbl_pcbMasAccountList.Add(tbl_pcbMasAccount);
				}
			}
			scon.Close();
			return tbl_pcbMasAccountList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pcbMasAccount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pcbMasAccount Maketbl_pcbMasAccount(SqlDataReader dataReader) {
			tbl_pcbMasAccount tbl_pcbMasAccount = new tbl_pcbMasAccount();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pcbMasAccount.PcbAccount_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pcbMasAccount.PcbAccountName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pcbMasAccount.AssignedUser_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pcbMasAccount.Currency_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pcbMasAccount.FloatAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pcbMasAccount.Remarks = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pcbMasAccount.Gl_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pcbMasAccount.Prefix = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pcbMasAccount.IsCanceled = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pcbMasAccount.CreateUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pcbMasAccount.ModifiedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pcbMasAccount.CanceldUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pcbMasAccount.DateCreate = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pcbMasAccount.DateModified = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pcbMasAccount.DateCanceled = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pcbMasAccount.CreateUserTerminal_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pcbMasAccount.ModifiedUserTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pcbMasAccount.CanceledUserTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pcbMasAccount.Counter = dataReader.GetInt32(18);
			}

			return tbl_pcbMasAccount;
		}
		/// <summary>
		/// This makes tbl_pcbMasAccount datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pcbMasAccount object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pcbMasAccount  tbl_pcbMasAccount   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pcbAccount_ID = new DataColumn("pcbAccount_ID" , typeof(string));
			DataColumn col_pcbAccountName = new DataColumn("pcbAccountName" , typeof(string));
			DataColumn col_assignedUser_ID = new DataColumn("assignedUser_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_floatAmount = new DataColumn("floatAmount" , typeof(decimal));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
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
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_pcbAccount_ID,col_pcbAccountName,col_assignedUser_ID,col_currency_ID,col_floatAmount,col_remarks,col_gl_ID,col_prefix,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_canceledUserTerminal_ID,col_counter,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pcbMasAccount datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pcbMasAccount object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pcbMasAccount user) {
		DataRow drow = dt.NewRow();
		
			drow["pcbAccount_ID"] = user.pcbAccount_ID;
			drow["pcbAccountName"] = user.pcbAccountName;
			drow["assignedUser_ID"] = user.assignedUser_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["floatAmount"] = user.floatAmount;
			drow["remarks"] = user.remarks;
			drow["gl_ID"] = user.gl_ID;
			drow["prefix"] = user.prefix;
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
			drow["counter"] = user.counter;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
