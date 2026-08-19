using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsCashDeposit {
		#region Fields
		private string cashDeposit_ID;
		private string remark;
		private DateTime dateDeposit;
		private decimal totalReceipt;
		private decimal totalAmount;
		private decimal depositedAmount;
		private string accountNumber;
		private string bank_ID;
		private string branch_ID;
		private string createUser_ID;
		private string modifiedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private bool isReconciled;
		private string companyID;
		private string companyBranch_ID;
		private int companyAccount_ID;
		private int recSerialNo;
		private DateTime dateReconcilied;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsCashDeposit class.
		/// </summary>
		public tbl_bpsCashDeposit() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsCashDeposit class.
		/// </summary>
		public tbl_bpsCashDeposit(string cashDeposit_ID, string remark, DateTime dateDeposit, decimal totalReceipt, decimal totalAmount, decimal depositedAmount, string accountNumber, string bank_ID, string branch_ID, string createUser_ID, string modifiedUser_ID, DateTime dateCreate, DateTime dateModified, bool isReconciled, string companyID, string companyBranch_ID, int companyAccount_ID, int recSerialNo, DateTime dateReconcilied) {
			this.cashDeposit_ID = cashDeposit_ID;
			this.remark = remark;
			this.dateDeposit = dateDeposit;
			this.totalReceipt = totalReceipt;
			this.totalAmount = totalAmount;
			this.depositedAmount = depositedAmount;
			this.accountNumber = accountNumber;
			this.bank_ID = bank_ID;
			this.branch_ID = branch_ID;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.isReconciled = isReconciled;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.companyAccount_ID = companyAccount_ID;
			this.recSerialNo = recSerialNo;
			this.dateReconcilied = dateReconcilied;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CashDeposit_ID value.
		/// </summary>
		public string CashDeposit_ID {
			get { return cashDeposit_ID; }
			set { cashDeposit_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateDeposit value.
		/// </summary>
		public DateTime DateDeposit {
			get { return dateDeposit; }
			set { dateDeposit = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalReceipt value.
		/// </summary>
		public decimal TotalReceipt {
			get { return totalReceipt; }
			set { totalReceipt = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepositedAmount value.
		/// </summary>
		public decimal DepositedAmount {
			get { return depositedAmount; }
			set { depositedAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountNumber value.
		/// </summary>
		public string AccountNumber {
			get { return accountNumber; }
			set { accountNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bank_ID value.
		/// </summary>
		public string Bank_ID {
			get { return bank_ID; }
			set { bank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Branch_ID value.
		/// </summary>
		public string Branch_ID {
			get { return branch_ID; }
			set { branch_ID = value; }
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
		/// Gets or sets the IsReconciled value.
		/// </summary>
		public bool IsReconciled {
			get { return isReconciled; }
			set { isReconciled = value; }
		}
		
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
		/// Gets or sets the CompanyAccount_ID value.
		/// </summary>
		public int CompanyAccount_ID {
			get { return companyAccount_ID; }
			set { companyAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RecSerialNo value.
		/// </summary>
		public int RecSerialNo {
			get { return recSerialNo; }
			set { recSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateReconcilied value.
		/// </summary>
		public DateTime DateReconcilied {
			get { return dateReconcilied; }
			set { dateReconcilied = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsCashDeposit table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDepositInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@cashDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateDeposit", SqlDbType.DateTime,8);
			scom.Parameters.Add("@totalReceipt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depositedAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isReconciled", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
			scom.Parameters.Add("@dateReconcilied", SqlDbType.DateTime,8);
 
			scom.Parameters["@cashDeposit_ID"].Value = cashDeposit_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dateDeposit"].Value = dateDeposit;
			scom.Parameters["@totalReceipt"].Value = totalReceipt;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@depositedAmount"].Value = depositedAmount;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@isReconciled"].Value = isReconciled;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
			scom.Parameters["@dateReconcilied"].Value = dateReconcilied;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsCashDeposit table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDepositUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@cashDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateDeposit", SqlDbType.DateTime,8);
			scom.Parameters.Add("@totalReceipt", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depositedAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isReconciled", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
			scom.Parameters.Add("@dateReconcilied", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@cashDeposit_ID"].Value = cashDeposit_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dateDeposit"].Value = dateDeposit;
			scom.Parameters["@totalReceipt"].Value = totalReceipt;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@depositedAmount"].Value = depositedAmount;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@isReconciled"].Value = isReconciled;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
			scom.Parameters["@dateReconcilied"].Value = dateReconcilied;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsCashDeposit table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDepositDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@cashDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cashDeposit_ID"].Value = cashDeposit_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCashDeposit table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDepositDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCashDeposit table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDepositDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsCashDeposit table.
		/// </summary>
		public static tbl_bpsCashDeposit Select(string cashDeposit_ID_Incoming){

			tbl_bpsCashDeposit tbl_bpsCashDepositins = new tbl_bpsCashDeposit();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDepositSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cashDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cashDeposit_ID"].Value = cashDeposit_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsCashDepositins = Maketbl_bpsCashDeposit(dataReader);
				} else {
					tbl_bpsCashDepositins = null;
				}
			}
			scon.Close();
			return tbl_bpsCashDepositins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCashDeposit table.
		/// </summary>
		public static List<tbl_bpsCashDeposit> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDepositSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsCashDeposit> tbl_bpsCashDepositList = new List<tbl_bpsCashDeposit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsCashDeposit tbl_bpsCashDeposit = Maketbl_bpsCashDeposit(dataReader);
					tbl_bpsCashDepositList.Add(tbl_bpsCashDeposit);
				}
			}
			scon.Close();
			return tbl_bpsCashDepositList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCashDeposit table by a foreign key.
		/// </summary>
		public static List<tbl_bpsCashDeposit> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDepositSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_bpsCashDeposit> tbl_bpsCashDepositList = new List<tbl_bpsCashDeposit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsCashDeposit tbl_bpsCashDeposit = Maketbl_bpsCashDeposit(dataReader);
					tbl_bpsCashDepositList.Add(tbl_bpsCashDeposit);
				}
			}
			scon.Close();
			return tbl_bpsCashDepositList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsCashDeposit table by a foreign key.
		/// </summary>
		public static List<tbl_bpsCashDeposit> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsCashDepositSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_bpsCashDeposit> tbl_bpsCashDepositList = new List<tbl_bpsCashDeposit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsCashDeposit tbl_bpsCashDeposit = Maketbl_bpsCashDeposit(dataReader);
					tbl_bpsCashDepositList.Add(tbl_bpsCashDeposit);
				}
			}
			scon.Close();
			return tbl_bpsCashDepositList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsCashDeposit class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsCashDeposit Maketbl_bpsCashDeposit(SqlDataReader dataReader) {
			tbl_bpsCashDeposit tbl_bpsCashDeposit = new tbl_bpsCashDeposit();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsCashDeposit.CashDeposit_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsCashDeposit.Remark = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsCashDeposit.DateDeposit = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsCashDeposit.TotalReceipt = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsCashDeposit.TotalAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsCashDeposit.DepositedAmount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsCashDeposit.AccountNumber = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsCashDeposit.Bank_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsCashDeposit.Branch_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsCashDeposit.CreateUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsCashDeposit.ModifiedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsCashDeposit.DateCreate = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsCashDeposit.DateModified = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsCashDeposit.IsReconciled = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsCashDeposit.CompanyID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsCashDeposit.CompanyBranch_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsCashDeposit.CompanyAccount_ID = dataReader.GetInt32(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsCashDeposit.RecSerialNo = dataReader.GetInt32(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsCashDeposit.DateReconcilied = dataReader.GetDateTime(18);
			}

			return tbl_bpsCashDeposit;
		}
		/// <summary>
		/// This makes tbl_bpsCashDeposit datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsCashDeposit object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsCashDeposit  tbl_bpsCashDeposit   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_cashDeposit_ID = new DataColumn("cashDeposit_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_dateDeposit = new DataColumn("dateDeposit" , typeof(DateTime));
			DataColumn col_totalReceipt = new DataColumn("totalReceipt" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_depositedAmount = new DataColumn("depositedAmount" , typeof(decimal));
			DataColumn col_accountNumber = new DataColumn("accountNumber" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_isReconciled = new DataColumn("isReconciled" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_companyAccount_ID = new DataColumn("companyAccount_ID" , typeof(int));
			DataColumn col_recSerialNo = new DataColumn("recSerialNo" , typeof(int));
			DataColumn col_dateReconcilied = new DataColumn("dateReconcilied" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_cashDeposit_ID,col_remark,col_dateDeposit,col_totalReceipt,col_totalAmount,col_depositedAmount,col_accountNumber,col_bank_ID,col_branch_ID,col_createUser_ID,col_modifiedUser_ID,col_dateCreate,col_dateModified,col_isReconciled,col_companyID,col_companyBranch_ID,col_companyAccount_ID,col_recSerialNo,col_dateReconcilied,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsCashDeposit datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsCashDeposit object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsCashDeposit user) {
		DataRow drow = dt.NewRow();
		
			drow["cashDeposit_ID"] = user.cashDeposit_ID;
			drow["remark"] = user.remark;
			drow["dateDeposit"] = user.dateDeposit;
			drow["totalReceipt"] = user.totalReceipt;
			drow["totalAmount"] = user.totalAmount;
			drow["depositedAmount"] = user.depositedAmount;
			drow["accountNumber"] = user.accountNumber;
			drow["bank_ID"] = user.bank_ID;
			drow["branch_ID"] = user.branch_ID;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["isReconciled"] = user.isReconciled;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["companyAccount_ID"] = user.companyAccount_ID;
			drow["recSerialNo"] = user.recSerialNo;
			drow["dateReconcilied"] = user.dateReconcilied;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
