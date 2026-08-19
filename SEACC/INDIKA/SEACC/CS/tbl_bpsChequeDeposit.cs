using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsChequeDeposit {
		#region Fields
		private string chequeDeposit_ID;
		private string remark;
		private DateTime dateDeposit;
		private decimal totalCheque;
		private decimal totalAmount;
		private string accountHolder;
		private string accountNumber;
		private string bank_ID;
		private string branch_ID;
		private string createUser_ID;
		private string modifiedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private bool isFinished;
		private bool isDeleted;
		private string companyID;
		private string companyBranch_ID;
		private bool isFactoringDeposite;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeDeposit class.
		/// </summary>
		public tbl_bpsChequeDeposit() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeDeposit class.
		/// </summary>
		public tbl_bpsChequeDeposit(string chequeDeposit_ID, string remark, DateTime dateDeposit, decimal totalCheque, decimal totalAmount, string accountHolder, string accountNumber, string bank_ID, string branch_ID, string createUser_ID, string modifiedUser_ID, DateTime dateCreate, DateTime dateModified, bool isFinished, bool isDeleted, string companyID, string companyBranch_ID, bool isFactoringDeposite) {
			this.chequeDeposit_ID = chequeDeposit_ID;
			this.remark = remark;
			this.dateDeposit = dateDeposit;
			this.totalCheque = totalCheque;
			this.totalAmount = totalAmount;
			this.accountHolder = accountHolder;
			this.accountNumber = accountNumber;
			this.bank_ID = bank_ID;
			this.branch_ID = branch_ID;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.isFactoringDeposite = isFactoringDeposite;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ChequeDeposit_ID value.
		/// </summary>
		public string ChequeDeposit_ID {
			get { return chequeDeposit_ID; }
			set { chequeDeposit_ID = value; }
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
		/// Gets or sets the TotalCheque value.
		/// </summary>
		public decimal TotalCheque {
			get { return totalCheque; }
			set { totalCheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountHolder value.
		/// </summary>
		public string AccountHolder {
			get { return accountHolder; }
			set { accountHolder = value; }
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
		/// Gets or sets the IsFactoringDeposite value.
		/// </summary>
		public bool IsFactoringDeposite {
			get { return isFactoringDeposite; }
			set { isFactoringDeposite = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsChequeDeposit table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateDeposit", SqlDbType.DateTime,8);
			scom.Parameters.Add("@totalCheque", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@accountHolder", SqlDbType.VarChar,50);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isFactoringDeposite", SqlDbType.Bit,1);
 
			scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dateDeposit"].Value = dateDeposit;
			scom.Parameters["@totalCheque"].Value = totalCheque;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@accountHolder"].Value = accountHolder;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isFactoringDeposite"].Value = isFactoringDeposite;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsChequeDeposit table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateDeposit", SqlDbType.DateTime,8);
			scom.Parameters.Add("@totalCheque", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@accountHolder", SqlDbType.VarChar,50);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isFactoringDeposite", SqlDbType.Bit,1);
 
 
			scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dateDeposit"].Value = dateDeposit;
			scom.Parameters["@totalCheque"].Value = totalCheque;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@accountHolder"].Value = accountHolder;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isFactoringDeposite"].Value = isFactoringDeposite;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsChequeDeposit table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit table by a foreign key.
		/// </summary>
		public static void DeleteAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositDeleteAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit table by a foreign key.
		/// </summary>
		public static void DeleteAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositDeleteAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsChequeDeposit table.
		/// </summary>
		public static tbl_bpsChequeDeposit Select(string chequeDeposit_ID_Incoming){

			tbl_bpsChequeDeposit tbl_bpsChequeDepositins = new tbl_bpsChequeDeposit();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeDeposit_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeDeposit_ID"].Value = chequeDeposit_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsChequeDepositins = Maketbl_bpsChequeDeposit(dataReader);
				} else {
					tbl_bpsChequeDepositins = null;
				}
			}
			scon.Close();
			return tbl_bpsChequeDepositins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit table.
		/// </summary>
		public static List<tbl_bpsChequeDeposit> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsChequeDeposit> tbl_bpsChequeDepositList = new List<tbl_bpsChequeDeposit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeDeposit tbl_bpsChequeDeposit = Maketbl_bpsChequeDeposit(dataReader);
					tbl_bpsChequeDepositList.Add(tbl_bpsChequeDeposit);
				}
			}
			scon.Close();
			return tbl_bpsChequeDepositList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeDeposit> SelectAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositSelectAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
				List<tbl_bpsChequeDeposit> tbl_bpsChequeDepositList = new List<tbl_bpsChequeDeposit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeDeposit tbl_bpsChequeDeposit = Maketbl_bpsChequeDeposit(dataReader);
					tbl_bpsChequeDepositList.Add(tbl_bpsChequeDeposit);
				}
			}
			scon.Close();
			return tbl_bpsChequeDepositList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeDeposit> SelectAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositSelectAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
				List<tbl_bpsChequeDeposit> tbl_bpsChequeDepositList = new List<tbl_bpsChequeDeposit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeDeposit tbl_bpsChequeDeposit = Maketbl_bpsChequeDeposit(dataReader);
					tbl_bpsChequeDepositList.Add(tbl_bpsChequeDeposit);
				}
			}
			scon.Close();
			return tbl_bpsChequeDepositList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeDeposit> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_bpsChequeDeposit> tbl_bpsChequeDepositList = new List<tbl_bpsChequeDeposit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeDeposit tbl_bpsChequeDeposit = Maketbl_bpsChequeDeposit(dataReader);
					tbl_bpsChequeDepositList.Add(tbl_bpsChequeDeposit);
				}
			}
			scon.Close();
			return tbl_bpsChequeDepositList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeDeposit table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeDeposit> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeDepositSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_bpsChequeDeposit> tbl_bpsChequeDepositList = new List<tbl_bpsChequeDeposit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeDeposit tbl_bpsChequeDeposit = Maketbl_bpsChequeDeposit(dataReader);
					tbl_bpsChequeDepositList.Add(tbl_bpsChequeDeposit);
				}
			}
			scon.Close();
			return tbl_bpsChequeDepositList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsChequeDeposit class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsChequeDeposit Maketbl_bpsChequeDeposit(SqlDataReader dataReader) {
			tbl_bpsChequeDeposit tbl_bpsChequeDeposit = new tbl_bpsChequeDeposit();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsChequeDeposit.ChequeDeposit_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsChequeDeposit.Remark = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsChequeDeposit.DateDeposit = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsChequeDeposit.TotalCheque = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsChequeDeposit.TotalAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsChequeDeposit.AccountHolder = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsChequeDeposit.AccountNumber = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsChequeDeposit.Bank_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsChequeDeposit.Branch_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsChequeDeposit.CreateUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsChequeDeposit.ModifiedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsChequeDeposit.DateCreate = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsChequeDeposit.DateModified = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsChequeDeposit.IsFinished = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsChequeDeposit.IsDeleted = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsChequeDeposit.CompanyID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsChequeDeposit.CompanyBranch_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsChequeDeposit.IsFactoringDeposite = dataReader.GetBoolean(17);
			}

			return tbl_bpsChequeDeposit;
		}
		/// <summary>
		/// This makes tbl_bpsChequeDeposit datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsChequeDeposit object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsChequeDeposit  tbl_bpsChequeDeposit   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chequeDeposit_ID = new DataColumn("chequeDeposit_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_dateDeposit = new DataColumn("dateDeposit" , typeof(DateTime));
			DataColumn col_totalCheque = new DataColumn("totalCheque" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_accountHolder = new DataColumn("accountHolder" , typeof(string));
			DataColumn col_accountNumber = new DataColumn("accountNumber" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_isFactoringDeposite = new DataColumn("isFactoringDeposite" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_chequeDeposit_ID,col_remark,col_dateDeposit,col_totalCheque,col_totalAmount,col_accountHolder,col_accountNumber,col_bank_ID,col_branch_ID,col_createUser_ID,col_modifiedUser_ID,col_dateCreate,col_dateModified,col_isFinished,col_isDeleted,col_companyID,col_companyBranch_ID,col_isFactoringDeposite,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsChequeDeposit datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsChequeDeposit object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsChequeDeposit user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeDeposit_ID"] = user.chequeDeposit_ID;
			drow["remark"] = user.remark;
			drow["dateDeposit"] = user.dateDeposit;
			drow["totalCheque"] = user.totalCheque;
			drow["totalAmount"] = user.totalAmount;
			drow["accountHolder"] = user.accountHolder;
			drow["accountNumber"] = user.accountNumber;
			drow["bank_ID"] = user.bank_ID;
			drow["branch_ID"] = user.branch_ID;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["isFactoringDeposite"] = user.isFactoringDeposite;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
