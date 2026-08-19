using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accChequeRegister {
		#region Fields
		private string chequeRegister_ID;
		private string remark;
		private string payee;
		private DateTime dateRegister;
		private DateTime dateCheque;
		private int companyAccount_ID;
		private string chequeNumber;
		private string chequeStatus_ID;
		private string chequeType_ID;
		private string chequeBook_ID;
		private string paymentVoucher_ID;
		private string financialYear_ID;
		private string companyID;
		private decimal chequeAmount;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string deletedUser_ID;
		private string printedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deletedTerminal_ID;
		private string printedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime dateDeleted;
		private DateTime datePrinted;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isSeattled;
		private int printCount;
		private decimal setteledAmount;
		private DateTime reconcilationDate;
		private int recSerialNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accChequeRegister class.
		/// </summary>
		public tbl_accChequeRegister() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accChequeRegister class.
		/// </summary>
		public tbl_accChequeRegister(string chequeRegister_ID, string remark, string payee, DateTime dateRegister, DateTime dateCheque, int companyAccount_ID, string chequeNumber, string chequeStatus_ID, string chequeType_ID, string chequeBook_ID, string paymentVoucher_ID, string financialYear_ID, string companyID, decimal chequeAmount, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled, int printCount, decimal setteledAmount, DateTime reconcilationDate, int recSerialNo) {
			this.chequeRegister_ID = chequeRegister_ID;
			this.remark = remark;
			this.payee = payee;
			this.dateRegister = dateRegister;
			this.dateCheque = dateCheque;
			this.companyAccount_ID = companyAccount_ID;
			this.chequeNumber = chequeNumber;
			this.chequeStatus_ID = chequeStatus_ID;
			this.chequeType_ID = chequeType_ID;
			this.chequeBook_ID = chequeBook_ID;
			this.paymentVoucher_ID = paymentVoucher_ID;
			this.financialYear_ID = financialYear_ID;
			this.companyID = companyID;
			this.chequeAmount = chequeAmount;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.deletedUser_ID = deletedUser_ID;
			this.printedUser_ID = printedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deletedTerminal_ID = deletedTerminal_ID;
			this.printedTerminal_ID = printedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.dateDeleted = dateDeleted;
			this.datePrinted = datePrinted;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isSeattled = isSeattled;
			this.printCount = printCount;
			this.setteledAmount = setteledAmount;
			this.reconcilationDate = reconcilationDate;
			this.recSerialNo = recSerialNo;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Payee value.
		/// </summary>
		public string Payee {
			get { return payee; }
			set { payee = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateRegister value.
		/// </summary>
		public DateTime DateRegister {
			get { return dateRegister; }
			set { dateRegister = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCheque value.
		/// </summary>
		public DateTime DateCheque {
			get { return dateCheque; }
			set { dateCheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyAccount_ID value.
		/// </summary>
		public int CompanyAccount_ID {
			get { return companyAccount_ID; }
			set { companyAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeNumber value.
		/// </summary>
		public string ChequeNumber {
			get { return chequeNumber; }
			set { chequeNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeStatus_ID value.
		/// </summary>
		public string ChequeStatus_ID {
			get { return chequeStatus_ID; }
			set { chequeStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeType_ID value.
		/// </summary>
		public string ChequeType_ID {
			get { return chequeType_ID; }
			set { chequeType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeBook_ID value.
		/// </summary>
		public string ChequeBook_ID {
			get { return chequeBook_ID; }
			set { chequeBook_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentVoucher_ID value.
		/// </summary>
		public string PaymentVoucher_ID {
			get { return paymentVoucher_ID; }
			set { paymentVoucher_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeAmount value.
		/// </summary>
		public decimal ChequeAmount {
			get { return chequeAmount; }
			set { chequeAmount = value; }
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
		/// Gets or sets the DeletedUser_ID value.
		/// </summary>
		public string DeletedUser_ID {
			get { return deletedUser_ID; }
			set { deletedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintedUser_ID value.
		/// </summary>
		public string PrintedUser_ID {
			get { return printedUser_ID; }
			set { printedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeletedTerminal_ID value.
		/// </summary>
		public string DeletedTerminal_ID {
			get { return deletedTerminal_ID; }
			set { deletedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintedTerminal_ID value.
		/// </summary>
		public string PrintedTerminal_ID {
			get { return printedTerminal_ID; }
			set { printedTerminal_ID = value; }
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
		/// Gets or sets the DateDeleted value.
		/// </summary>
		public DateTime DateDeleted {
			get { return dateDeleted; }
			set { dateDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the DatePrinted value.
		/// </summary>
		public DateTime DatePrinted {
			get { return datePrinted; }
			set { datePrinted = value; }
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
		/// Gets or sets the IsSeattled value.
		/// </summary>
		public bool IsSeattled {
			get { return isSeattled; }
			set { isSeattled = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the SetteledAmount value.
		/// </summary>
		public decimal SetteledAmount {
			get { return setteledAmount; }
			set { setteledAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReconcilationDate value.
		/// </summary>
		public DateTime ReconcilationDate {
			get { return reconcilationDate; }
			set { reconcilationDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the RecSerialNo value.
		/// </summary>
		public int RecSerialNo {
			get { return recSerialNo; }
			set { recSerialNo = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accChequeRegister table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeRegisterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@payee", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateRegister", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCheque", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeBook_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@setteledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reconcilationDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@payee"].Value = payee;
			scom.Parameters["@dateRegister"].Value = dateRegister;
			scom.Parameters["@dateCheque"].Value = dateCheque;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
			scom.Parameters["@chequeType_ID"].Value = chequeType_ID;
			scom.Parameters["@chequeBook_ID"].Value = chequeBook_ID;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@setteledAmount"].Value = setteledAmount;
			scom.Parameters["@reconcilationDate"].Value = reconcilationDate;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accChequeRegister table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeRegisterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@payee", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateRegister", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCheque", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeBook_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@setteledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reconcilationDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
 
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@payee"].Value = payee;
			scom.Parameters["@dateRegister"].Value = dateRegister;
			scom.Parameters["@dateCheque"].Value = dateCheque;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
			scom.Parameters["@chequeType_ID"].Value = chequeType_ID;
			scom.Parameters["@chequeBook_ID"].Value = chequeBook_ID;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@setteledAmount"].Value = setteledAmount;
			scom.Parameters["@reconcilationDate"].Value = reconcilationDate;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accChequeRegister table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeRegisterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByPaymentVoucher_ID(string paymentVoucher_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeRegisterDeleteAllByPaymentVoucher_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeRegister table by a foreign key.
		/// </summary>
        /// 
        public static void DeleteAllByCompanyAccount_ID(int companyAccount_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accChequeRegisterDeleteAllByCompanyAccount_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int, 4);
            scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_accChequeRegister table by a foreign key.
        /// </summary>
		public static void DeleteAllByChequeBook_ID(string chequeBook_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeRegisterDeleteAllByChequeBook_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeBook_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeBook_ID"].Value = chequeBook_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accChequeRegister table.
		/// </summary>
		public static tbl_accChequeRegister Select(string chequeRegister_ID_Incoming){

			tbl_accChequeRegister tbl_accChequeRegisterins = new tbl_accChequeRegister();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeRegisterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accChequeRegisterins = Maketbl_accChequeRegister(dataReader);
				} else {
					tbl_accChequeRegisterins = null;
				}
			}
			scon.Close();
			return tbl_accChequeRegisterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeRegister table.
		/// </summary>
		public static List<tbl_accChequeRegister> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeRegisterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accChequeRegister> tbl_accChequeRegisterList = new List<tbl_accChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accChequeRegister tbl_accChequeRegister = Maketbl_accChequeRegister(dataReader);
					tbl_accChequeRegisterList.Add(tbl_accChequeRegister);
				}
			}
			scon.Close();
			return tbl_accChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_accChequeRegister> SelectAllByPaymentVoucher_ID(string paymentVoucher_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeRegisterSelectAllByPaymentVoucher_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
				List<tbl_accChequeRegister> tbl_accChequeRegisterList = new List<tbl_accChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accChequeRegister tbl_accChequeRegister = Maketbl_accChequeRegister(dataReader);
					tbl_accChequeRegisterList.Add(tbl_accChequeRegister);
				}
			}
			scon.Close();
			return tbl_accChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_accChequeRegister> SelectAllByChequeBook_ID(string chequeBook_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accChequeRegisterSelectAllByChequeBook_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeBook_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeBook_ID"].Value = chequeBook_ID;
				List<tbl_accChequeRegister> tbl_accChequeRegisterList = new List<tbl_accChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accChequeRegister tbl_accChequeRegister = Maketbl_accChequeRegister(dataReader);
					tbl_accChequeRegisterList.Add(tbl_accChequeRegister);
				}
			}
			scon.Close();
			return tbl_accChequeRegisterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accChequeRegister class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accChequeRegister Maketbl_accChequeRegister(SqlDataReader dataReader) {
			tbl_accChequeRegister tbl_accChequeRegister = new tbl_accChequeRegister();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accChequeRegister.ChequeRegister_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accChequeRegister.Remark = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accChequeRegister.Payee = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accChequeRegister.DateRegister = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accChequeRegister.DateCheque = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accChequeRegister.CompanyAccount_ID = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accChequeRegister.ChequeNumber = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accChequeRegister.ChequeStatus_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accChequeRegister.ChequeType_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accChequeRegister.ChequeBook_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accChequeRegister.PaymentVoucher_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accChequeRegister.FinancialYear_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accChequeRegister.CompanyID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_accChequeRegister.ChequeAmount = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_accChequeRegister.CreateUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_accChequeRegister.ModifiedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_accChequeRegister.CheckedUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_accChequeRegister.ApprovedUser_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_accChequeRegister.DeletedUser_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_accChequeRegister.PrintedUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_accChequeRegister.CreateTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_accChequeRegister.ModifiedTerminal_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_accChequeRegister.DeletedTerminal_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_accChequeRegister.PrintedTerminal_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_accChequeRegister.DateCreate = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_accChequeRegister.DateModified = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_accChequeRegister.DateChecked = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_accChequeRegister.DateApproved = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_accChequeRegister.DateDeleted = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_accChequeRegister.DatePrinted = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_accChequeRegister.IsChecked = dataReader.GetBoolean(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_accChequeRegister.IsApproved = dataReader.GetBoolean(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_accChequeRegister.IsFinished = dataReader.GetBoolean(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_accChequeRegister.IsDeleted = dataReader.GetBoolean(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_accChequeRegister.IsLocked = dataReader.GetBoolean(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_accChequeRegister.IsSeattled = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_accChequeRegister.PrintCount = dataReader.GetInt32(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_accChequeRegister.SetteledAmount = dataReader.GetDecimal(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_accChequeRegister.ReconcilationDate = dataReader.GetDateTime(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_accChequeRegister.RecSerialNo = dataReader.GetInt32(39);
			}

			return tbl_accChequeRegister;
		}
		/// <summary>
		/// This makes tbl_accChequeRegister datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accChequeRegister object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accChequeRegister  tbl_accChequeRegister   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_payee = new DataColumn("payee" , typeof(string));
			DataColumn col_dateRegister = new DataColumn("dateRegister" , typeof(DateTime));
			DataColumn col_dateCheque = new DataColumn("dateCheque" , typeof(DateTime));
			DataColumn col_companyAccount_ID = new DataColumn("companyAccount_ID" , typeof(int));
			DataColumn col_chequeNumber = new DataColumn("chequeNumber" , typeof(string));
			DataColumn col_chequeStatus_ID = new DataColumn("chequeStatus_ID" , typeof(string));
			DataColumn col_chequeType_ID = new DataColumn("chequeType_ID" , typeof(string));
			DataColumn col_chequeBook_ID = new DataColumn("chequeBook_ID" , typeof(string));
			DataColumn col_paymentVoucher_ID = new DataColumn("paymentVoucher_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_deletedUser_ID = new DataColumn("deletedUser_ID" , typeof(string));
			DataColumn col_printedUser_ID = new DataColumn("printedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID" , typeof(string));
			DataColumn col_printedTerminal_ID = new DataColumn("printedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_dateDeleted = new DataColumn("dateDeleted" , typeof(DateTime));
			DataColumn col_datePrinted = new DataColumn("datePrinted" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_setteledAmount = new DataColumn("setteledAmount" , typeof(decimal));
			DataColumn col_reconcilationDate = new DataColumn("reconcilationDate" , typeof(DateTime));
			DataColumn col_recSerialNo = new DataColumn("recSerialNo" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_chequeRegister_ID,col_remark,col_payee,col_dateRegister,col_dateCheque,col_companyAccount_ID,col_chequeNumber,col_chequeStatus_ID,col_chequeType_ID,col_chequeBook_ID,col_paymentVoucher_ID,col_financialYear_ID,col_companyID,col_chequeAmount,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,col_printCount,col_setteledAmount,col_reconcilationDate,col_recSerialNo,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accChequeRegister datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accChequeRegister object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accChequeRegister user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["remark"] = user.remark;
			drow["payee"] = user.payee;
			drow["dateRegister"] = user.dateRegister;
			drow["dateCheque"] = user.dateCheque;
			drow["companyAccount_ID"] = user.companyAccount_ID;
			drow["chequeNumber"] = user.chequeNumber;
			drow["chequeStatus_ID"] = user.chequeStatus_ID;
			drow["chequeType_ID"] = user.chequeType_ID;
			drow["chequeBook_ID"] = user.chequeBook_ID;
			drow["paymentVoucher_ID"] = user.paymentVoucher_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["companyID"] = user.companyID;
			drow["chequeAmount"] = user.chequeAmount;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["deletedUser_ID"] = user.deletedUser_ID;
			drow["printedUser_ID"] = user.printedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
			drow["printedTerminal_ID"] = user.printedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["dateDeleted"] = user.dateDeleted;
			drow["datePrinted"] = user.datePrinted;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isSeattled"] = user.isSeattled;
			drow["printCount"] = user.printCount;
			drow["setteledAmount"] = user.setteledAmount;
			drow["reconcilationDate"] = user.reconcilationDate;
			drow["recSerialNo"] = user.recSerialNo;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
