using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsPettyCashAccount_Transaction {
		#region Fields
		private int line_No;
		private string pettyCashAccount_ID;
		private string pettyCashExpenditureType_ID;
		private string pettyCashIncomeType_ID;
		private DateTime transactionDate;
		private string remark;
		private string spentUserID;
		private string spentUserName;
		private string voucherNo;
		private string invoiceNo;
		private decimal amount;
		private string iouAccount_ID;
		private string cost_Center_ID;
		private string cost_Center2_ID;
		private string cost_Center3_ID;
		private string cost_Center4_ID;
		private string reimbRequest_ID;
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
		private bool isIncome;
		private bool isExpenditure;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashAccount_Transaction class.
		/// </summary>
		public tbl_bpsPettyCashAccount_Transaction() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashAccount_Transaction class.
		/// </summary>
		public tbl_bpsPettyCashAccount_Transaction(int line_No, string pettyCashAccount_ID, string pettyCashExpenditureType_ID, string pettyCashIncomeType_ID, DateTime transactionDate, string remark, string spentUserID, string spentUserName, string voucherNo, string invoiceNo, decimal amount, string iouAccount_ID, string cost_Center_ID, string cost_Center2_ID, string cost_Center3_ID, string cost_Center4_ID, string reimbRequest_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isIncome, bool isExpenditure) {
			this.line_No = line_No;
			this.pettyCashAccount_ID = pettyCashAccount_ID;
			this.pettyCashExpenditureType_ID = pettyCashExpenditureType_ID;
			this.pettyCashIncomeType_ID = pettyCashIncomeType_ID;
			this.transactionDate = transactionDate;
			this.remark = remark;
			this.spentUserID = spentUserID;
			this.spentUserName = spentUserName;
			this.voucherNo = voucherNo;
			this.invoiceNo = invoiceNo;
			this.amount = amount;
			this.iouAccount_ID = iouAccount_ID;
			this.cost_Center_ID = cost_Center_ID;
			this.cost_Center2_ID = cost_Center2_ID;
			this.cost_Center3_ID = cost_Center3_ID;
			this.cost_Center4_ID = cost_Center4_ID;
			this.reimbRequest_ID = reimbRequest_ID;
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
			this.isIncome = isIncome;
			this.isExpenditure = isExpenditure;
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
		/// Gets or sets the PettyCashAccount_ID value.
		/// </summary>
		public string PettyCashAccount_ID {
			get { return pettyCashAccount_ID; }
			set { pettyCashAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCashExpenditureType_ID value.
		/// </summary>
		public string PettyCashExpenditureType_ID {
			get { return pettyCashExpenditureType_ID; }
			set { pettyCashExpenditureType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCashIncomeType_ID value.
		/// </summary>
		public string PettyCashIncomeType_ID {
			get { return pettyCashIncomeType_ID; }
			set { pettyCashIncomeType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionDate value.
		/// </summary>
		public DateTime TransactionDate {
			get { return transactionDate; }
			set { transactionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the SpentUserID value.
		/// </summary>
		public string SpentUserID {
			get { return spentUserID; }
			set { spentUserID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SpentUserName value.
		/// </summary>
		public string SpentUserName {
			get { return spentUserName; }
			set { spentUserName = value; }
		}
		
		/// <summary>
		/// Gets or sets the VoucherNo value.
		/// </summary>
		public string VoucherNo {
			get { return voucherNo; }
			set { voucherNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvoiceNo value.
		/// </summary>
		public string InvoiceNo {
			get { return invoiceNo; }
			set { invoiceNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IouAccount_ID value.
		/// </summary>
		public string IouAccount_ID {
			get { return iouAccount_ID; }
			set { iouAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_Center_ID value.
		/// </summary>
		public string Cost_Center_ID {
			get { return cost_Center_ID; }
			set { cost_Center_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_Center2_ID value.
		/// </summary>
		public string Cost_Center2_ID {
			get { return cost_Center2_ID; }
			set { cost_Center2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_Center3_ID value.
		/// </summary>
		public string Cost_Center3_ID {
			get { return cost_Center3_ID; }
			set { cost_Center3_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_Center4_ID value.
		/// </summary>
		public string Cost_Center4_ID {
			get { return cost_Center4_ID; }
			set { cost_Center4_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReimbRequest_ID value.
		/// </summary>
		public string ReimbRequest_ID {
			get { return reimbRequest_ID; }
			set { reimbRequest_ID = value; }
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
		/// Gets or sets the IsIncome value.
		/// </summary>
		public bool IsIncome {
			get { return isIncome; }
			set { isIncome = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsExpenditure value.
		/// </summary>
		public bool IsExpenditure {
			get { return isExpenditure; }
			set { isExpenditure = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsPettyCashAccount_Transaction table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pettyCashExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCashIncomeType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@spentUserID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@spentUserName", SqlDbType.VarChar,200);
			scom.Parameters.Add("@voucherNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoiceNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cost_Center2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cost_Center3_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cost_Center4_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@reimbRequest_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isIncome", SqlDbType.Bit,1);
			scom.Parameters.Add("@isExpenditure", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
			scom.Parameters["@pettyCashExpenditureType_ID"].Value = pettyCashExpenditureType_ID;
			scom.Parameters["@pettyCashIncomeType_ID"].Value = pettyCashIncomeType_ID;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@spentUserID"].Value = spentUserID;
			scom.Parameters["@spentUserName"].Value = spentUserName;
			scom.Parameters["@voucherNo"].Value = voucherNo;
			scom.Parameters["@invoiceNo"].Value = invoiceNo;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
			scom.Parameters["@cost_Center2_ID"].Value = cost_Center2_ID;
			scom.Parameters["@cost_Center3_ID"].Value = cost_Center3_ID;
			scom.Parameters["@cost_Center4_ID"].Value = cost_Center4_ID;
			scom.Parameters["@reimbRequest_ID"].Value = reimbRequest_ID;
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
			scom.Parameters["@isIncome"].Value = isIncome;
			scom.Parameters["@isExpenditure"].Value = isExpenditure;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsPettyCashAccount_Transaction table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pettyCashExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@pettyCashIncomeType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@spentUserID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@spentUserName", SqlDbType.VarChar,200);
			scom.Parameters.Add("@voucherNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoiceNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cost_Center2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cost_Center3_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cost_Center4_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@reimbRequest_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isIncome", SqlDbType.Bit,1);
			scom.Parameters.Add("@isExpenditure", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
			scom.Parameters["@pettyCashExpenditureType_ID"].Value = pettyCashExpenditureType_ID;
			scom.Parameters["@pettyCashIncomeType_ID"].Value = pettyCashIncomeType_ID;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@spentUserID"].Value = spentUserID;
			scom.Parameters["@spentUserName"].Value = spentUserName;
			scom.Parameters["@voucherNo"].Value = voucherNo;
			scom.Parameters["@invoiceNo"].Value = invoiceNo;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
			scom.Parameters["@cost_Center2_ID"].Value = cost_Center2_ID;
			scom.Parameters["@cost_Center3_ID"].Value = cost_Center3_ID;
			scom.Parameters["@cost_Center4_ID"].Value = cost_Center4_ID;
			scom.Parameters["@reimbRequest_ID"].Value = reimbRequest_ID;
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
			scom.Parameters["@isIncome"].Value = isIncome;
			scom.Parameters["@isExpenditure"].Value = isExpenditure;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsPettyCashAccount_Transaction table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static void DeleteAllByCost_Center_ID(string cost_Center_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionDeleteAllByCost_Center_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,10);
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static void DeleteAllByCost_Center3_ID(string cost_Center3_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionDeleteAllByCost_Center3_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center3_ID", SqlDbType.VarChar,10);
			scom.Parameters["@cost_Center3_ID"].Value = cost_Center3_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static void DeleteAllByCost_Center2_ID(string cost_Center2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionDeleteAllByCost_Center2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@cost_Center2_ID"].Value = cost_Center2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static void DeleteAllBySpentUserID(string spentUserID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionDeleteAllBySpentUserID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@spentUserID", SqlDbType.VarChar,20);
			scom.Parameters["@spentUserID"].Value = spentUserID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static void DeleteAllByPettyCashAccount_ID(string pettyCashAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionDeleteAllByPettyCashAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static void DeleteAllByPettyCashIncomeType_ID(string pettyCashIncomeType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionDeleteAllByPettyCashIncomeType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashIncomeType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCashIncomeType_ID"].Value = pettyCashIncomeType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static void DeleteAllByCost_Center4_ID(string cost_Center4_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionDeleteAllByCost_Center4_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center4_ID", SqlDbType.VarChar,10);
			scom.Parameters["@cost_Center4_ID"].Value = cost_Center4_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static void DeleteAllByPettyCashExpenditureType_ID(string pettyCashExpenditureType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionDeleteAllByPettyCashExpenditureType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCashExpenditureType_ID"].Value = pettyCashExpenditureType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static void DeleteAllByIouAccount_ID(string iouAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionDeleteAllByIouAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsPettyCashAccount_Transaction table.
		/// </summary>
		public static tbl_bpsPettyCashAccount_Transaction Select(int line_No_Incoming, string pettyCashAccount_ID_Incoming){

			tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transactionins = new tbl_bpsPettyCashAccount_Transaction();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transactionins = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
				} else {
					tbl_bpsPettyCashAccount_Transactionins = null;
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_Transactionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Transaction> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsPettyCashAccount_Transaction> tbl_bpsPettyCashAccount_TransactionList = new List<tbl_bpsPettyCashAccount_Transaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
					tbl_bpsPettyCashAccount_TransactionList.Add(tbl_bpsPettyCashAccount_Transaction);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_TransactionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Transaction> SelectAllByCost_Center_ID(string cost_Center_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelectAllByCost_Center_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,10);
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
				List<tbl_bpsPettyCashAccount_Transaction> tbl_bpsPettyCashAccount_TransactionList = new List<tbl_bpsPettyCashAccount_Transaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
					tbl_bpsPettyCashAccount_TransactionList.Add(tbl_bpsPettyCashAccount_Transaction);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_TransactionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Transaction> SelectAllByCost_Center3_ID(string cost_Center3_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelectAllByCost_Center3_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center3_ID", SqlDbType.VarChar,10);
			scom.Parameters["@cost_Center3_ID"].Value = cost_Center3_ID;
				List<tbl_bpsPettyCashAccount_Transaction> tbl_bpsPettyCashAccount_TransactionList = new List<tbl_bpsPettyCashAccount_Transaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
					tbl_bpsPettyCashAccount_TransactionList.Add(tbl_bpsPettyCashAccount_Transaction);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_TransactionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Transaction> SelectAllByCost_Center2_ID(string cost_Center2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelectAllByCost_Center2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@cost_Center2_ID"].Value = cost_Center2_ID;
				List<tbl_bpsPettyCashAccount_Transaction> tbl_bpsPettyCashAccount_TransactionList = new List<tbl_bpsPettyCashAccount_Transaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
					tbl_bpsPettyCashAccount_TransactionList.Add(tbl_bpsPettyCashAccount_Transaction);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_TransactionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Transaction> SelectAllBySpentUserID(string spentUserID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelectAllBySpentUserID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@spentUserID", SqlDbType.VarChar,20);
			scom.Parameters["@spentUserID"].Value = spentUserID;
				List<tbl_bpsPettyCashAccount_Transaction> tbl_bpsPettyCashAccount_TransactionList = new List<tbl_bpsPettyCashAccount_Transaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
					tbl_bpsPettyCashAccount_TransactionList.Add(tbl_bpsPettyCashAccount_Transaction);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_TransactionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Transaction> SelectAllByPettyCashAccount_ID(string pettyCashAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelectAllByPettyCashAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
				List<tbl_bpsPettyCashAccount_Transaction> tbl_bpsPettyCashAccount_TransactionList = new List<tbl_bpsPettyCashAccount_Transaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
					tbl_bpsPettyCashAccount_TransactionList.Add(tbl_bpsPettyCashAccount_Transaction);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_TransactionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Transaction> SelectAllByPettyCashIncomeType_ID(string pettyCashIncomeType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelectAllByPettyCashIncomeType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashIncomeType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCashIncomeType_ID"].Value = pettyCashIncomeType_ID;
				List<tbl_bpsPettyCashAccount_Transaction> tbl_bpsPettyCashAccount_TransactionList = new List<tbl_bpsPettyCashAccount_Transaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
					tbl_bpsPettyCashAccount_TransactionList.Add(tbl_bpsPettyCashAccount_Transaction);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_TransactionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Transaction> SelectAllByCost_Center4_ID(string cost_Center4_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelectAllByCost_Center4_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center4_ID", SqlDbType.VarChar,10);
			scom.Parameters["@cost_Center4_ID"].Value = cost_Center4_ID;
				List<tbl_bpsPettyCashAccount_Transaction> tbl_bpsPettyCashAccount_TransactionList = new List<tbl_bpsPettyCashAccount_Transaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
					tbl_bpsPettyCashAccount_TransactionList.Add(tbl_bpsPettyCashAccount_Transaction);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_TransactionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Transaction> SelectAllByPettyCashExpenditureType_ID(string pettyCashExpenditureType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelectAllByPettyCashExpenditureType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pettyCashExpenditureType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@pettyCashExpenditureType_ID"].Value = pettyCashExpenditureType_ID;
				List<tbl_bpsPettyCashAccount_Transaction> tbl_bpsPettyCashAccount_TransactionList = new List<tbl_bpsPettyCashAccount_Transaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
					tbl_bpsPettyCashAccount_TransactionList.Add(tbl_bpsPettyCashAccount_Transaction);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_TransactionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashAccount_Transaction table by a foreign key.
		/// </summary>
		public static List<tbl_bpsPettyCashAccount_Transaction> SelectAllByIouAccount_ID(string iouAccount_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashAccount_TransactionSelectAllByIouAccount_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iouAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iouAccount_ID"].Value = iouAccount_ID;
				List<tbl_bpsPettyCashAccount_Transaction> tbl_bpsPettyCashAccount_TransactionList = new List<tbl_bpsPettyCashAccount_Transaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = Maketbl_bpsPettyCashAccount_Transaction(dataReader);
					tbl_bpsPettyCashAccount_TransactionList.Add(tbl_bpsPettyCashAccount_Transaction);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashAccount_TransactionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsPettyCashAccount_Transaction class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsPettyCashAccount_Transaction Maketbl_bpsPettyCashAccount_Transaction(SqlDataReader dataReader) {
			tbl_bpsPettyCashAccount_Transaction tbl_bpsPettyCashAccount_Transaction = new tbl_bpsPettyCashAccount_Transaction();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsPettyCashAccount_Transaction.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsPettyCashAccount_Transaction.PettyCashAccount_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsPettyCashAccount_Transaction.PettyCashExpenditureType_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsPettyCashAccount_Transaction.PettyCashIncomeType_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsPettyCashAccount_Transaction.TransactionDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsPettyCashAccount_Transaction.Remark = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsPettyCashAccount_Transaction.SpentUserID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsPettyCashAccount_Transaction.SpentUserName = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsPettyCashAccount_Transaction.VoucherNo = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsPettyCashAccount_Transaction.InvoiceNo = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsPettyCashAccount_Transaction.Amount = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsPettyCashAccount_Transaction.IouAccount_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsPettyCashAccount_Transaction.Cost_Center_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsPettyCashAccount_Transaction.Cost_Center2_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsPettyCashAccount_Transaction.Cost_Center3_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsPettyCashAccount_Transaction.Cost_Center4_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsPettyCashAccount_Transaction.ReimbRequest_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsPettyCashAccount_Transaction.CreateUser_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsPettyCashAccount_Transaction.ModifiedUser_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsPettyCashAccount_Transaction.CheckedUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_bpsPettyCashAccount_Transaction.ApprovedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_bpsPettyCashAccount_Transaction.DateCreate = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_bpsPettyCashAccount_Transaction.DateModified = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_bpsPettyCashAccount_Transaction.DateChecked = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_bpsPettyCashAccount_Transaction.DateApproved = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_bpsPettyCashAccount_Transaction.IsChecked = dataReader.GetBoolean(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_bpsPettyCashAccount_Transaction.IsApproved = dataReader.GetBoolean(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_bpsPettyCashAccount_Transaction.IsFinished = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_bpsPettyCashAccount_Transaction.IsDeleted = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_bpsPettyCashAccount_Transaction.IsLocked = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_bpsPettyCashAccount_Transaction.IsIncome = dataReader.GetBoolean(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_bpsPettyCashAccount_Transaction.IsExpenditure = dataReader.GetBoolean(31);
			}

			return tbl_bpsPettyCashAccount_Transaction;
		}
		/// <summary>
		/// This makes tbl_bpsPettyCashAccount_Transaction datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashAccount_Transaction object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsPettyCashAccount_Transaction  tbl_bpsPettyCashAccount_Transaction   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_pettyCashAccount_ID = new DataColumn("pettyCashAccount_ID" , typeof(string));
			DataColumn col_pettyCashExpenditureType_ID = new DataColumn("pettyCashExpenditureType_ID" , typeof(string));
			DataColumn col_pettyCashIncomeType_ID = new DataColumn("pettyCashIncomeType_ID" , typeof(string));
			DataColumn col_transactionDate = new DataColumn("transactionDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_spentUserID = new DataColumn("spentUserID" , typeof(string));
			DataColumn col_spentUserName = new DataColumn("spentUserName" , typeof(string));
			DataColumn col_voucherNo = new DataColumn("voucherNo" , typeof(string));
			DataColumn col_invoiceNo = new DataColumn("invoiceNo" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_iouAccount_ID = new DataColumn("iouAccount_ID" , typeof(string));
			DataColumn col_cost_Center_ID = new DataColumn("cost_Center_ID" , typeof(string));
			DataColumn col_cost_Center2_ID = new DataColumn("cost_Center2_ID" , typeof(string));
			DataColumn col_cost_Center3_ID = new DataColumn("cost_Center3_ID" , typeof(string));
			DataColumn col_cost_Center4_ID = new DataColumn("cost_Center4_ID" , typeof(string));
			DataColumn col_reimbRequest_ID = new DataColumn("reimbRequest_ID" , typeof(string));
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
			DataColumn col_isIncome = new DataColumn("isIncome" , typeof(bool));
			DataColumn col_isExpenditure = new DataColumn("isExpenditure" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_pettyCashAccount_ID,col_pettyCashExpenditureType_ID,col_pettyCashIncomeType_ID,col_transactionDate,col_remark,col_spentUserID,col_spentUserName,col_voucherNo,col_invoiceNo,col_amount,col_iouAccount_ID,col_cost_Center_ID,col_cost_Center2_ID,col_cost_Center3_ID,col_cost_Center4_ID,col_reimbRequest_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isIncome,col_isExpenditure,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsPettyCashAccount_Transaction datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashAccount_Transaction object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsPettyCashAccount_Transaction user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["pettyCashAccount_ID"] = user.pettyCashAccount_ID;
			drow["pettyCashExpenditureType_ID"] = user.pettyCashExpenditureType_ID;
			drow["pettyCashIncomeType_ID"] = user.pettyCashIncomeType_ID;
			drow["transactionDate"] = user.transactionDate;
			drow["remark"] = user.remark;
			drow["spentUserID"] = user.spentUserID;
			drow["spentUserName"] = user.spentUserName;
			drow["voucherNo"] = user.voucherNo;
			drow["invoiceNo"] = user.invoiceNo;
			drow["amount"] = user.amount;
			drow["iouAccount_ID"] = user.iouAccount_ID;
			drow["cost_Center_ID"] = user.cost_Center_ID;
			drow["cost_Center2_ID"] = user.cost_Center2_ID;
			drow["cost_Center3_ID"] = user.cost_Center3_ID;
			drow["cost_Center4_ID"] = user.cost_Center4_ID;
			drow["reimbRequest_ID"] = user.reimbRequest_ID;
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
			drow["isIncome"] = user.isIncome;
			drow["isExpenditure"] = user.isExpenditure;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
