using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsPettyCashAccount {
		#region Fields
		private string pettyCashAccount_ID;
		private string pettyCashAccountName;
		private DateTime pettyCashAccountDate;
		private string remark;
		private string assignedUser_ID;
		private string currency_ID;
		private DateTime expireDate;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isClose;
		private decimal floatAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashAccount class.
		/// </summary>
		public tbl_bpsPettyCashAccount() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashAccount class.
		/// </summary>
		public tbl_bpsPettyCashAccount(string pettyCashAccount_ID, string pettyCashAccountName, DateTime pettyCashAccountDate, string remark, string assignedUser_ID, string currency_ID, DateTime expireDate, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isClose, decimal floatAmount) {
			this.pettyCashAccount_ID = pettyCashAccount_ID;
			this.pettyCashAccountName = pettyCashAccountName;
			this.pettyCashAccountDate = pettyCashAccountDate;
			this.remark = remark;
			this.assignedUser_ID = assignedUser_ID;
			this.currency_ID = currency_ID;
			this.expireDate = expireDate;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isClose = isClose;
			this.floatAmount = floatAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PettyCashAccount_ID value.
		/// </summary>
		public string PettyCashAccount_ID {
			get { return pettyCashAccount_ID; }
			set { pettyCashAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCashAccountName value.
		/// </summary>
		public string PettyCashAccountName {
			get { return pettyCashAccountName; }
			set { pettyCashAccountName = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCashAccountDate value.
		/// </summary>
		public DateTime PettyCashAccountDate {
			get { return pettyCashAccountDate; }
			set { pettyCashAccountDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
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
		/// Gets or sets the ExpireDate value.
		/// </summary>
		public DateTime ExpireDate {
			get { return expireDate; }
			set { expireDate = value; }
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
		/// Gets or sets the CheckedUser_ID value.
		/// </summary>
		public string CheckedUser_ID {
			get { return checkedUser_ID; }
			set { checkedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
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
		/// Gets or sets the DateChecked value.
		/// </summary>
		public DateTime DateChecked {
			get { return dateChecked; }
			set { dateChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved value.
		/// </summary>
		public DateTime DateApproved {
			get { return dateApproved; }
			set { dateApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChecked value.
		/// </summary>
		public bool IsChecked {
			get { return isChecked; }
			set { isChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFinished value.
		/// </summary>
		public bool IsFinished {
			get { return isFinished; }
			set { isFinished = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsClose value.
		/// </summary>
		public bool IsClose {
			get { return isClose; }
			set { isClose = value; }
		}
		
		/// <summary>
		/// Gets or sets the FloatAmount value.
		/// </summary>
		public decimal FloatAmount {
			get { return floatAmount; }
			set { floatAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsPettyCashAccount table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccountInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pettyCashAccountName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@pettyCashAccountDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@assignedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@expireDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isClose", SqlDbType.Bit,1);
			scom.Parameters.Add("@floatAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
			scom.Parameters["@pettyCashAccountName"].Value = pettyCashAccountName;
			scom.Parameters["@pettyCashAccountDate"].Value = pettyCashAccountDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@assignedUser_ID"].Value = assignedUser_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@expireDate"].Value = expireDate;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isClose"].Value = isClose;
			scom.Parameters["@floatAmount"].Value = floatAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsPettyCashAccount table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccountUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pettyCashAccountName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@pettyCashAccountDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@assignedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@expireDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isClose", SqlDbType.Bit,1);
			scom.Parameters.Add("@floatAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
			scom.Parameters["@pettyCashAccountName"].Value = pettyCashAccountName;
			scom.Parameters["@pettyCashAccountDate"].Value = pettyCashAccountDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@assignedUser_ID"].Value = assignedUser_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@expireDate"].Value = expireDate;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isClose"].Value = isClose;
			scom.Parameters["@floatAmount"].Value = floatAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsPettyCashAccount table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccountDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByAssignedUser_ID(string assignedUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccountDeleteAllByAssignedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assignedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@assignedUser_ID"].Value = assignedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsPettyCashAccount table.
		/// </summary>
		public static tbl_bpsPettyCashAccount Select(string pettyCashAccount_ID_Incoming){

			tbl_bpsPettyCashAccount tbl_bpsPettyCashAccountins = new tbl_bpsPettyCashAccount();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccountSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsPettyCashAccountins = Maketbl_bpsPettyCashAccount(dataReader);
				} else {
					tbl_bpsPettyCashAccountins = null;
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccountins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount table.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccountSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsPettyCashAccount> tbl_bpsPettyCashAccountList = new List<tbl_bpsPettyCashAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount tbl_bpsPettyCashAccount = Maketbl_bpsPettyCashAccount(dataReader);
					tbl_bpsPettyCashAccountList.Add(tbl_bpsPettyCashAccount);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount> SelectAllByAssignedUser_ID(string assignedUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccountSelectAllByAssignedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assignedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@assignedUser_ID"].Value = assignedUser_ID;
				List<tbl_bpsPettyCashAccount> tbl_bpsPettyCashAccountList = new List<tbl_bpsPettyCashAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount tbl_bpsPettyCashAccount = Maketbl_bpsPettyCashAccount(dataReader);
					tbl_bpsPettyCashAccountList.Add(tbl_bpsPettyCashAccount);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccountList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsPettyCashAccount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsPettyCashAccount Maketbl_bpsPettyCashAccount(SqlDataReader dataReader) {
			tbl_bpsPettyCashAccount tbl_bpsPettyCashAccount = new tbl_bpsPettyCashAccount();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsPettyCashAccount.PettyCashAccount_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsPettyCashAccount.PettyCashAccountName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsPettyCashAccount.PettyCashAccountDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsPettyCashAccount.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsPettyCashAccount.AssignedUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsPettyCashAccount.Currency_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsPettyCashAccount.ExpireDate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsPettyCashAccount.CreateUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsPettyCashAccount.ModifiedUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsPettyCashAccount.CheckedUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsPettyCashAccount.ApprovedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsPettyCashAccount.DateCreate = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsPettyCashAccount.DateModified = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsPettyCashAccount.DateChecked = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsPettyCashAccount.DateApproved = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsPettyCashAccount.IsChecked = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsPettyCashAccount.IsApproved = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsPettyCashAccount.IsFinished = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsPettyCashAccount.IsDeleted = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsPettyCashAccount.IsLocked = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_bpsPettyCashAccount.IsClose = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_bpsPettyCashAccount.FloatAmount = dataReader.GetDecimal(21);
			}

			return tbl_bpsPettyCashAccount;
		}
		/// <summary>
		/// This makes tbl_bpsPettyCashAccount datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashAccount object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsPettyCashAccount  tbl_bpsPettyCashAccount   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pettyCashAccount_ID = new DataColumn("pettyCashAccount_ID" , typeof(string));
			DataColumn col_pettyCashAccountName = new DataColumn("pettyCashAccountName" , typeof(string));
			DataColumn col_pettyCashAccountDate = new DataColumn("pettyCashAccountDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_assignedUser_ID = new DataColumn("assignedUser_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_expireDate = new DataColumn("expireDate" , typeof(DateTime));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isClose = new DataColumn("isClose" , typeof(bool));
			DataColumn col_floatAmount = new DataColumn("floatAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_pettyCashAccount_ID,col_pettyCashAccountName,col_pettyCashAccountDate,col_remark,col_assignedUser_ID,col_currency_ID,col_expireDate,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isClose,col_floatAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsPettyCashAccount datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashAccount object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsPettyCashAccount user) {
		DataRow drow = dt.NewRow();
		
			drow["pettyCashAccount_ID"] = user.pettyCashAccount_ID;
			drow["pettyCashAccountName"] = user.pettyCashAccountName;
			drow["pettyCashAccountDate"] = user.pettyCashAccountDate;
			drow["remark"] = user.remark;
			drow["assignedUser_ID"] = user.assignedUser_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["expireDate"] = user.expireDate;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isClose"] = user.isClose;
			drow["floatAmount"] = user.floatAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
