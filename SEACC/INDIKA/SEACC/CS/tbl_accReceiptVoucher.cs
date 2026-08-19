using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accReceiptVoucher {
		#region Fields
		private string receiptVoucher_ID;
		private DateTime receiptVoucherDate;
		private string remark;
		private string narration;
		private string gl_ID;
		private string customer_ID;
		private string supplier_ID;
		private string employee_ID;
		private string cusSupEmpName;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string financialYear_ID;
		private string companyID;
		private string currency_ID;
		private string paymentMethod_ID;
		private decimal currencyRate;
		private decimal cashAmount;
		private decimal chequeAmount;
		private decimal totalAmount;
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
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accReceiptVoucher class.
		/// </summary>
		public tbl_accReceiptVoucher() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accReceiptVoucher class.
		/// </summary>
		public tbl_accReceiptVoucher(string receiptVoucher_ID, DateTime receiptVoucherDate, string remark, string narration, string gl_ID, string customer_ID, string supplier_ID, string employee_ID, string cusSupEmpName, string glPosting_ID, string postingStatus_ID, string financialYear_ID, string companyID, string currency_ID, string paymentMethod_ID, decimal currencyRate, decimal cashAmount, decimal chequeAmount, decimal totalAmount, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled, int printCount) {
			this.receiptVoucher_ID = receiptVoucher_ID;
			this.receiptVoucherDate = receiptVoucherDate;
			this.remark = remark;
			this.narration = narration;
			this.gl_ID = gl_ID;
			this.customer_ID = customer_ID;
			this.supplier_ID = supplier_ID;
			this.employee_ID = employee_ID;
			this.cusSupEmpName = cusSupEmpName;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.financialYear_ID = financialYear_ID;
			this.companyID = companyID;
			this.currency_ID = currency_ID;
			this.paymentMethod_ID = paymentMethod_ID;
			this.currencyRate = currencyRate;
			this.cashAmount = cashAmount;
			this.chequeAmount = chequeAmount;
			this.totalAmount = totalAmount;
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
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ReceiptVoucher_ID value.
		/// </summary>
		public string ReceiptVoucher_ID {
			get { return receiptVoucher_ID; }
			set { receiptVoucher_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptVoucherDate value.
		/// </summary>
		public DateTime ReceiptVoucherDate {
			get { return receiptVoucherDate; }
			set { receiptVoucherDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Narration value.
		/// </summary>
		public string Narration {
			get { return narration; }
			set { narration = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CusSupEmpName value.
		/// </summary>
		public string CusSupEmpName {
			get { return cusSupEmpName; }
			set { cusSupEmpName = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlPosting_ID value.
		/// </summary>
		public string GlPosting_ID {
			get { return glPosting_ID; }
			set { glPosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PostingStatus_ID value.
		/// </summary>
		public string PostingStatus_ID {
			get { return postingStatus_ID; }
			set { postingStatus_ID = value; }
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
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentMethod_ID value.
		/// </summary>
		public string PaymentMethod_ID {
			get { return paymentMethod_ID; }
			set { paymentMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CurrencyRate value.
		/// </summary>
		public decimal CurrencyRate {
			get { return currencyRate; }
			set { currencyRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the CashAmount value.
		/// </summary>
		public decimal CashAmount {
			get { return cashAmount; }
			set { cashAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeAmount value.
		/// </summary>
		public decimal ChequeAmount {
			get { return chequeAmount; }
			set { chequeAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accReceiptVoucher table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receiptVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receiptVoucherDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@narration", SqlDbType.VarChar,100);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cusSupEmpName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
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
 
			scom.Parameters["@receiptVoucher_ID"].Value = receiptVoucher_ID;
			scom.Parameters["@receiptVoucherDate"].Value = receiptVoucherDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@narration"].Value = narration;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@cusSupEmpName"].Value = cusSupEmpName;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@cashAmount"].Value = cashAmount;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@totalAmount"].Value = totalAmount;
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
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accReceiptVoucher table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receiptVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receiptVoucherDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@narration", SqlDbType.VarChar,100);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@cusSupEmpName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
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
 
 
			scom.Parameters["@receiptVoucher_ID"].Value = receiptVoucher_ID;
			scom.Parameters["@receiptVoucherDate"].Value = receiptVoucherDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@narration"].Value = narration;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@cusSupEmpName"].Value = cusSupEmpName;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@cashAmount"].Value = cashAmount;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@totalAmount"].Value = totalAmount;
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
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accReceiptVoucher table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@receiptVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receiptVoucher_ID"].Value = receiptVoucher_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByPaymentMethod_ID(string paymentMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherDeleteAllByPaymentMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accReceiptVoucher table.
		/// </summary>
		public static tbl_accReceiptVoucher Select(string receiptVoucher_ID_Incoming){

			tbl_accReceiptVoucher tbl_accReceiptVoucherins = new tbl_accReceiptVoucher();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receiptVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receiptVoucher_ID"].Value = receiptVoucher_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accReceiptVoucherins = Maketbl_accReceiptVoucher(dataReader);
				} else {
					tbl_accReceiptVoucherins = null;
				}
			}
			scon.Close();
			return tbl_accReceiptVoucherins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table.
		/// </summary>
		public static List<tbl_accReceiptVoucher> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accReceiptVoucher> tbl_accReceiptVoucherList = new List<tbl_accReceiptVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptVoucher tbl_accReceiptVoucher = Maketbl_accReceiptVoucher(dataReader);
					tbl_accReceiptVoucherList.Add(tbl_accReceiptVoucher);
				}
			}
			scon.Close();
			return tbl_accReceiptVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_accReceiptVoucher> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_accReceiptVoucher> tbl_accReceiptVoucherList = new List<tbl_accReceiptVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptVoucher tbl_accReceiptVoucher = Maketbl_accReceiptVoucher(dataReader);
					tbl_accReceiptVoucherList.Add(tbl_accReceiptVoucher);
				}
			}
			scon.Close();
			return tbl_accReceiptVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_accReceiptVoucher> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accReceiptVoucher> tbl_accReceiptVoucherList = new List<tbl_accReceiptVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptVoucher tbl_accReceiptVoucher = Maketbl_accReceiptVoucher(dataReader);
					tbl_accReceiptVoucherList.Add(tbl_accReceiptVoucher);
				}
			}
			scon.Close();
			return tbl_accReceiptVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_accReceiptVoucher> SelectAllByPaymentMethod_ID(string paymentMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherSelectAllByPaymentMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
				List<tbl_accReceiptVoucher> tbl_accReceiptVoucherList = new List<tbl_accReceiptVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptVoucher tbl_accReceiptVoucher = Maketbl_accReceiptVoucher(dataReader);
					tbl_accReceiptVoucherList.Add(tbl_accReceiptVoucher);
				}
			}
			scon.Close();
			return tbl_accReceiptVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_accReceiptVoucher> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_accReceiptVoucher> tbl_accReceiptVoucherList = new List<tbl_accReceiptVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptVoucher tbl_accReceiptVoucher = Maketbl_accReceiptVoucher(dataReader);
					tbl_accReceiptVoucherList.Add(tbl_accReceiptVoucher);
				}
			}
			scon.Close();
			return tbl_accReceiptVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceiptVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_accReceiptVoucher> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptVoucherSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_accReceiptVoucher> tbl_accReceiptVoucherList = new List<tbl_accReceiptVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceiptVoucher tbl_accReceiptVoucher = Maketbl_accReceiptVoucher(dataReader);
					tbl_accReceiptVoucherList.Add(tbl_accReceiptVoucher);
				}
			}
			scon.Close();
			return tbl_accReceiptVoucherList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accReceiptVoucher class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accReceiptVoucher Maketbl_accReceiptVoucher(SqlDataReader dataReader) {
			tbl_accReceiptVoucher tbl_accReceiptVoucher = new tbl_accReceiptVoucher();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accReceiptVoucher.ReceiptVoucher_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accReceiptVoucher.ReceiptVoucherDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accReceiptVoucher.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accReceiptVoucher.Narration = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accReceiptVoucher.Gl_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accReceiptVoucher.Customer_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accReceiptVoucher.Supplier_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accReceiptVoucher.Employee_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accReceiptVoucher.CusSupEmpName = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accReceiptVoucher.GlPosting_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accReceiptVoucher.PostingStatus_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accReceiptVoucher.FinancialYear_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accReceiptVoucher.CompanyID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_accReceiptVoucher.Currency_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_accReceiptVoucher.PaymentMethod_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_accReceiptVoucher.CurrencyRate = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_accReceiptVoucher.CashAmount = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_accReceiptVoucher.ChequeAmount = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_accReceiptVoucher.TotalAmount = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_accReceiptVoucher.CreateUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_accReceiptVoucher.ModifiedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_accReceiptVoucher.CheckedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_accReceiptVoucher.ApprovedUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_accReceiptVoucher.DeletedUser_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_accReceiptVoucher.PrintedUser_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_accReceiptVoucher.CreateTerminal_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_accReceiptVoucher.ModifiedTerminal_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_accReceiptVoucher.DeletedTerminal_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_accReceiptVoucher.PrintedTerminal_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_accReceiptVoucher.DateCreate = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_accReceiptVoucher.DateModified = dataReader.GetDateTime(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_accReceiptVoucher.DateChecked = dataReader.GetDateTime(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_accReceiptVoucher.DateApproved = dataReader.GetDateTime(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_accReceiptVoucher.DateDeleted = dataReader.GetDateTime(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_accReceiptVoucher.DatePrinted = dataReader.GetDateTime(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_accReceiptVoucher.IsChecked = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_accReceiptVoucher.IsApproved = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_accReceiptVoucher.IsFinished = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_accReceiptVoucher.IsDeleted = dataReader.GetBoolean(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_accReceiptVoucher.IsLocked = dataReader.GetBoolean(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_accReceiptVoucher.IsSeattled = dataReader.GetBoolean(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_accReceiptVoucher.PrintCount = dataReader.GetInt32(41);
			}

			return tbl_accReceiptVoucher;
		}
		/// <summary>
		/// This makes tbl_accReceiptVoucher datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accReceiptVoucher object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accReceiptVoucher  tbl_accReceiptVoucher   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_receiptVoucher_ID = new DataColumn("receiptVoucher_ID" , typeof(string));
			DataColumn col_receiptVoucherDate = new DataColumn("receiptVoucherDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_narration = new DataColumn("narration" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_cusSupEmpName = new DataColumn("cusSupEmpName" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_paymentMethod_ID = new DataColumn("paymentMethod_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_cashAmount = new DataColumn("cashAmount" , typeof(decimal));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
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
		dt.Columns.AddRange(new DataColumn[] { col_receiptVoucher_ID,col_receiptVoucherDate,col_remark,col_narration,col_gl_ID,col_customer_ID,col_supplier_ID,col_employee_ID,col_cusSupEmpName,col_glPosting_ID,col_postingStatus_ID,col_financialYear_ID,col_companyID,col_currency_ID,col_paymentMethod_ID,col_currencyRate,col_cashAmount,col_chequeAmount,col_totalAmount,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,col_printCount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accReceiptVoucher datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accReceiptVoucher object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accReceiptVoucher user) {
		DataRow drow = dt.NewRow();
		
			drow["receiptVoucher_ID"] = user.receiptVoucher_ID;
			drow["receiptVoucherDate"] = user.receiptVoucherDate;
			drow["remark"] = user.remark;
			drow["narration"] = user.narration;
			drow["gl_ID"] = user.gl_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["cusSupEmpName"] = user.cusSupEmpName;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["companyID"] = user.companyID;
			drow["currency_ID"] = user.currency_ID;
			drow["paymentMethod_ID"] = user.paymentMethod_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["cashAmount"] = user.cashAmount;
			drow["chequeAmount"] = user.chequeAmount;
			drow["totalAmount"] = user.totalAmount;
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
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
