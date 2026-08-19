using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsReceipt {
		#region Fields
		private string receipt_ID;
		private DateTime receiptDate;
		private string remark;
		private string tmpReceipt_ID;
		private string customer_ID;
		private string invoice_ID;
		private string quotation_ID;
		private string customerOrder_ID;
		private string deliveryOrder_ID;
		private string orderRefNo_ID;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string postingStatus_ID2;
		private string financialYear_ID;
		private string salesNoteType_ID;
		private string collector_ID;
		private string currency_ID;
		private decimal currencyRate;
		private decimal cashAmount;
		private decimal depositedCashAmount;
		private decimal chequeAmount;
		private decimal totalAmount;
		private string tatalAmountInWord;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string printedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime datePrinted;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private int printCount;
		private bool isAdvance;
		private bool isOverPayment;
		private decimal seattleAmount;
		private bool isSeattled;
		private bool isSalesReceipt;
		private DateTime oldestInvoiceDate;
		private string invoiceList;
		private bool isCashDeposited;
		private DateTime dateDeposited;
		private string companyID;
		private string companyBranch_ID;
		public string collector_ID2;
		public string collector_ID3;
		public string collector_ID4;
		public string PageNo;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsReceipt class.
		/// </summary>
		public tbl_bpsReceipt() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsReceipt class.
		/// </summary>
		public tbl_bpsReceipt(string receipt_ID, DateTime receiptDate, string remark, string tmpReceipt_ID, string customer_ID, string invoice_ID, string quotation_ID, string customerOrder_ID, string deliveryOrder_ID, string orderRefNo_ID, string glPosting_ID, string postingStatus_ID, string postingStatus_ID2, string financialYear_ID, string salesNoteType_ID, string collector_ID, string currency_ID, decimal currencyRate, decimal cashAmount, decimal depositedCashAmount, decimal chequeAmount, decimal totalAmount, string tatalAmountInWord, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string printedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, int printCount, bool isAdvance, bool isOverPayment, decimal seattleAmount, bool isSeattled, bool isSalesReceipt, DateTime oldestInvoiceDate, string invoiceList, bool isCashDeposited, DateTime dateDeposited, string companyID, string companyBranch_ID,string collector_ID2, string collector_ID3, string collector_ID4,string pageNo) {
			this.receipt_ID = receipt_ID;
			this.receiptDate = receiptDate;
			this.remark = remark;
			this.tmpReceipt_ID = tmpReceipt_ID;
			this.customer_ID = customer_ID;
			this.invoice_ID = invoice_ID;
			this.quotation_ID = quotation_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.orderRefNo_ID = orderRefNo_ID;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.postingStatus_ID2 = postingStatus_ID2;
			this.financialYear_ID = financialYear_ID;
			this.salesNoteType_ID = salesNoteType_ID;
			this.collector_ID = collector_ID;
			this.currency_ID = currency_ID;
			this.currencyRate = currencyRate;
			this.cashAmount = cashAmount;
			this.depositedCashAmount = depositedCashAmount;
			this.chequeAmount = chequeAmount;
			this.totalAmount = totalAmount;
			this.tatalAmountInWord = tatalAmountInWord;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.printedUser_ID = printedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.datePrinted = datePrinted;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.printCount = printCount;
			this.isAdvance = isAdvance;
			this.isOverPayment = isOverPayment;
			this.seattleAmount = seattleAmount;
			this.isSeattled = isSeattled;
			this.isSalesReceipt = isSalesReceipt;
			this.oldestInvoiceDate = oldestInvoiceDate;
			this.invoiceList = invoiceList;
			this.isCashDeposited = isCashDeposited;
			this.dateDeposited = dateDeposited;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.collector_ID2 = collector_ID2;
			this.collector_ID3 = collector_ID3;
			this.collector_ID4 = collector_ID4;
			this.PageNo = pageNo;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptDate value.
		/// </summary>
		public DateTime ReceiptDate {
			get { return receiptDate; }
			set { receiptDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the TmpReceipt_ID value.
		/// </summary>
		public string TmpReceipt_ID {
			get { return tmpReceipt_ID; }
			set { tmpReceipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Quotation_ID value.
		/// </summary>
		public string Quotation_ID {
			get { return quotation_ID; }
			set { quotation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryOrder_ID value.
		/// </summary>
		public string DeliveryOrder_ID {
			get { return deliveryOrder_ID; }
			set { deliveryOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo_ID value.
		/// </summary>
		public string OrderRefNo_ID {
			get { return orderRefNo_ID; }
			set { orderRefNo_ID = value; }
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
		/// Gets or sets the PostingStatus_ID2 value.
		/// </summary>
		public string PostingStatus_ID2 {
			get { return postingStatus_ID2; }
			set { postingStatus_ID2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesNoteType_ID value.
		/// </summary>
		public string SalesNoteType_ID {
			get { return salesNoteType_ID; }
			set { salesNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Collector_ID value.
		/// </summary>
		public string Collector_ID {
			get { return collector_ID; }
			set { collector_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
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
		/// Gets or sets the DepositedCashAmount value.
		/// </summary>
		public decimal DepositedCashAmount {
			get { return depositedCashAmount; }
			set { depositedCashAmount = value; }
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
		/// Gets or sets the TatalAmountInWord value.
		/// </summary>
		public string TatalAmountInWord {
			get { return tatalAmountInWord; }
			set { tatalAmountInWord = value; }
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
		/// Gets or sets the PrintedUser_ID value.
		/// </summary>
		public string PrintedUser_ID {
			get { return printedUser_ID; }
			set { printedUser_ID = value; }
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
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAdvance value.
		/// </summary>
		public bool IsAdvance {
			get { return isAdvance; }
			set { isAdvance = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOverPayment value.
		/// </summary>
		public bool IsOverPayment {
			get { return isOverPayment; }
			set { isOverPayment = value; }
		}
		
		/// <summary>
		/// Gets or sets the SeattleAmount value.
		/// </summary>
		public decimal SeattleAmount {
			get { return seattleAmount; }
			set { seattleAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSeattled value.
		/// </summary>
		public bool IsSeattled {
			get { return isSeattled; }
			set { isSeattled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSalesReceipt value.
		/// </summary>
		public bool IsSalesReceipt {
			get { return isSalesReceipt; }
			set { isSalesReceipt = value; }
		}
		
		/// <summary>
		/// Gets or sets the OldestInvoiceDate value.
		/// </summary>
		public DateTime OldestInvoiceDate {
			get { return oldestInvoiceDate; }
			set { oldestInvoiceDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvoiceList value.
		/// </summary>
		public string InvoiceList {
			get { return invoiceList; }
			set { invoiceList = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCashDeposited value.
		/// </summary>
		public bool IsCashDeposited {
			get { return isCashDeposited; }
			set { isCashDeposited = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateDeposited value.
		/// </summary>
		public DateTime DateDeposited {
			get { return dateDeposited; }
			set { dateDeposited = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsReceipt table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceiptInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receiptDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@tmpReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@postingStatus_ID2", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@collector_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depositedCashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmountInWord", SqlDbType.VarChar,200);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isAdvance", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOverPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesReceipt", SqlDbType.Bit,1);
			scom.Parameters.Add("@oldestInvoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@invoiceList", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isCashDeposited", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateDeposited", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@collector_ID2", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@collector_ID3", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@collector_ID4", SqlDbType.VarChar, 20);
	scom.Parameters.Add("@PageNo", SqlDbType.VarChar, 20);

			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@receiptDate"].Value = receiptDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@tmpReceipt_ID"].Value = tmpReceipt_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@postingStatus_ID2"].Value = postingStatus_ID2;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@collector_ID"].Value = collector_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@cashAmount"].Value = cashAmount;
			scom.Parameters["@depositedCashAmount"].Value = depositedCashAmount;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@tatalAmountInWord"].Value = tatalAmountInWord;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isAdvance"].Value = isAdvance;
			scom.Parameters["@isOverPayment"].Value = isOverPayment;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@isSalesReceipt"].Value = isSalesReceipt;
			scom.Parameters["@oldestInvoiceDate"].Value = oldestInvoiceDate;
			scom.Parameters["@invoiceList"].Value = invoiceList;
			scom.Parameters["@isCashDeposited"].Value = isCashDeposited;
			scom.Parameters["@dateDeposited"].Value = dateDeposited;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 scom.Parameters["@collector_ID2"].Value = collector_ID2;
 scom.Parameters["@collector_ID3"].Value = collector_ID3;
			scom.Parameters["@collector_ID4"].Value = collector_ID4;
	scom.Parameters["@PageNo"].Value = PageNo;
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsReceipt table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceiptUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receiptDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@tmpReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@postingStatus_ID2", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@collector_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depositedCashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmountInWord", SqlDbType.VarChar,200);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isAdvance", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOverPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesReceipt", SqlDbType.Bit,1);
			scom.Parameters.Add("@oldestInvoiceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@invoiceList", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isCashDeposited", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateDeposited", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@collector_ID2", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@collector_ID3", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@collector_ID4", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@PageNo", SqlDbType.VarChar, 20);

			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@receiptDate"].Value = receiptDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@tmpReceipt_ID"].Value = tmpReceipt_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@postingStatus_ID2"].Value = postingStatus_ID2;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@collector_ID"].Value = collector_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@cashAmount"].Value = cashAmount;
			scom.Parameters["@depositedCashAmount"].Value = depositedCashAmount;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@tatalAmountInWord"].Value = tatalAmountInWord;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isAdvance"].Value = isAdvance;
			scom.Parameters["@isOverPayment"].Value = isOverPayment;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@isSalesReceipt"].Value = isSalesReceipt;
			scom.Parameters["@oldestInvoiceDate"].Value = oldestInvoiceDate;
			scom.Parameters["@invoiceList"].Value = invoiceList;
			scom.Parameters["@isCashDeposited"].Value = isCashDeposited;
			scom.Parameters["@dateDeposited"].Value = dateDeposited;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@collector_ID2"].Value = collector_ID2;
			scom.Parameters["@collector_ID3"].Value = collector_ID3;
			scom.Parameters["@collector_ID4"].Value = collector_ID4;
			scom.Parameters["@PageNo"].Value = PageNo;
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsReceipt table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceiptDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_bpsReceipt table by a foreign key.
        /// </summary>
       
		
		/// <summary>
		/// Selects a single record from the tbl_bpsReceipt table.
		/// </summary>
		public static tbl_bpsReceipt Select(string receipt_ID_Incoming){

			tbl_bpsReceipt tbl_bpsReceiptins = new tbl_bpsReceipt();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceiptSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsReceiptins = Maketbl_bpsReceipt(dataReader);
				} else {
					tbl_bpsReceiptins = null;
				}
			}
			scon.Close();
			return tbl_bpsReceiptins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsReceipt table.
		/// </summary>
		public static List<tbl_bpsReceipt> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsReceiptSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            List<tbl_bpsReceipt> tbl_bpsReceiptList = new List<tbl_bpsReceipt>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_bpsReceipt tbl_bpsReceipt = Maketbl_bpsReceipt(dataReader);
                    tbl_bpsReceiptList.Add(tbl_bpsReceipt);
                }
            }
            scon.Close();
            return tbl_bpsReceiptList;
        }

        /// <summary>
        /// Selects all records from the tbl_bpsReceipt table by a foreign key.
        /// </summary>
        //public static List<tbl_bpsReceipt> SelectAllByCustomer_ID(string customer_ID)
        //{

        //    SqlConnection scon = DBHandling.GetConnection();
        //    SqlCommand scom = new SqlCommand("tbl_bpsReceiptSelectAllByCustomer_ID", scon);
        //    scom.CommandType = CommandType.StoredProcedure;
        //    scon.Open();

        //    scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
        //    scom.Parameters["@customer_ID"].Value = customer_ID;
        //    List<tbl_bpsReceipt> tbl_bpsReceiptList = new List<tbl_bpsReceipt>();
        //    using (SqlDataReader dataReader = scom.ExecuteReader())
        //    {
        //        while (dataReader.Read())
        //        {
        //            tbl_bpsReceipt tbl_bpsReceipt = Maketbl_bpsReceipt(dataReader);
        //            tbl_bpsReceiptList.Add(tbl_bpsReceipt);
        //        }
        //    }
        //    scon.Close();
        //    return tbl_bpsReceiptList;
        //}

       
        public static List<tbl_bpsReceipt> SelectAllByInvoice_ID(string invoice_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsReceiptSelectAllByInvoice_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@invoice_ID"].Value = invoice_ID;
            List<tbl_bpsReceipt> tbl_bpsReceiptList = new List<tbl_bpsReceipt>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_bpsReceipt tbl_bpsReceipt = Maketbl_bpsReceipt(dataReader);
                    tbl_bpsReceiptList.Add(tbl_bpsReceipt);
                }
            }
            scon.Close();
            return tbl_bpsReceiptList;
        }

        public static List<tbl_bpsReceipt> SelectAll_ByCustomerIDandDateRange(DateTime dateFrom, DateTime dateTo, string sCustomerID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsReceiptSelectAll_ByCustomerIDandDateRange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@customer_ID"].Value = sCustomerID;
				List<tbl_bpsReceipt> tbl_bpsReceiptList = new List<tbl_bpsReceipt>();

                using (SqlDataReader dataReader = scom.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        tbl_bpsReceipt tbl_bpsReceipt = Maketbl_bpsReceipt(dataReader);
                        tbl_bpsReceiptList.Add(tbl_bpsReceipt);
                    }
                }
                scon.Close();
                return tbl_bpsReceiptList;
        }

        //public static tbl_bpsReceipt Select_FromAllReciepts(string receipt_ID_Incoming)
        //{

        //    tbl_bpsReceipt tbl_bpsReceiptins = new tbl_bpsReceipt();
        //    SqlConnection scon = DBHandling.GetConnection();
        //    SqlCommand scom = new SqlCommand("tbl_bpsReceiptSelect", scon);
        //    scom.CommandType = CommandType.StoredProcedure;
        //    scon.Open();

        //    scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar, 20);
        //    scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
        //    using (SqlDataReader dataReader = scom.ExecuteReader())
        //    {
        //        if (dataReader.Read())
        //        {
        //            tbl_bpsReceiptins = Maketbl_bpsReceipt(dataReader);
        //        }
        //        else
        //        {
        //            tbl_bpsReceiptins = null;
        //        }
        //    }
        //    scon.Close();
        //    return tbl_bpsReceiptins;
        //}

        /// <summary>
        /// Selects all records from the tbl_bpsReceipt table by a foreign key.
        /// </summary>
        public static List<tbl_bpsReceipt> SelectAllByCompanyBranch_ID(string companyBranch_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsReceiptSelectAllByCompanyBranch_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            List<tbl_bpsReceipt> tbl_bpsReceiptList = new List<tbl_bpsReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsReceipt tbl_bpsReceipt = Maketbl_bpsReceipt(dataReader);
					tbl_bpsReceiptList.Add(tbl_bpsReceipt);
				}
			}
			scon.Close();
			return tbl_bpsReceiptList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsReceipt class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsReceipt Maketbl_bpsReceipt(SqlDataReader dataReader) {
			tbl_bpsReceipt tbl_bpsReceipt = new tbl_bpsReceipt();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsReceipt.Receipt_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsReceipt.ReceiptDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsReceipt.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsReceipt.TmpReceipt_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsReceipt.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsReceipt.Invoice_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsReceipt.Quotation_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsReceipt.CustomerOrder_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsReceipt.DeliveryOrder_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsReceipt.OrderRefNo_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsReceipt.GlPosting_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsReceipt.PostingStatus_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsReceipt.PostingStatus_ID2 = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsReceipt.FinancialYear_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsReceipt.SalesNoteType_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsReceipt.Collector_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsReceipt.Currency_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsReceipt.CurrencyRate = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsReceipt.CashAmount = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsReceipt.DepositedCashAmount = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_bpsReceipt.ChequeAmount = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_bpsReceipt.TotalAmount = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_bpsReceipt.TatalAmountInWord = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_bpsReceipt.CreateUser_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_bpsReceipt.ModifiedUser_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_bpsReceipt.CheckedUser_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_bpsReceipt.ApprovedUser_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_bpsReceipt.PrintedUser_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_bpsReceipt.DateCreate = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_bpsReceipt.DateModified = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_bpsReceipt.DateChecked = dataReader.GetDateTime(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_bpsReceipt.DateApproved = dataReader.GetDateTime(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_bpsReceipt.DatePrinted = dataReader.GetDateTime(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_bpsReceipt.IsChecked = dataReader.GetBoolean(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_bpsReceipt.IsApproved = dataReader.GetBoolean(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_bpsReceipt.IsFinished = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_bpsReceipt.IsDeleted = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_bpsReceipt.IsLocked = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_bpsReceipt.PrintCount = dataReader.GetInt32(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_bpsReceipt.IsAdvance = dataReader.GetBoolean(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_bpsReceipt.IsOverPayment = dataReader.GetBoolean(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_bpsReceipt.SeattleAmount = dataReader.GetDecimal(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_bpsReceipt.IsSeattled = dataReader.GetBoolean(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_bpsReceipt.IsSalesReceipt = dataReader.GetBoolean(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_bpsReceipt.OldestInvoiceDate = dataReader.GetDateTime(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_bpsReceipt.InvoiceList = dataReader.GetString(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_bpsReceipt.IsCashDeposited = dataReader.GetBoolean(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_bpsReceipt.DateDeposited = dataReader.GetDateTime(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_bpsReceipt.CompanyID = dataReader.GetString(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_bpsReceipt.CompanyBranch_ID = dataReader.GetString(49);
			}

			if (dataReader.IsDBNull(50) == false)
			{
				tbl_bpsReceipt.collector_ID2 = dataReader.GetString(50);
			}
			if (dataReader.IsDBNull(51) == false)
			{
				tbl_bpsReceipt.collector_ID3 = dataReader.GetString(51);
			}
			if (dataReader.IsDBNull(52) == false)
			{
				tbl_bpsReceipt.collector_ID4 = dataReader.GetString(52);
			}
			if (dataReader.IsDBNull(53) == false)
			{
				tbl_bpsReceipt.PageNo = dataReader.GetString(53);
			}
			return tbl_bpsReceipt;
		}
		/// <summary>
		/// This makes tbl_bpsReceipt datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsReceipt object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsReceipt  tbl_bpsReceipt   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_receiptDate = new DataColumn("receiptDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_tmpReceipt_ID = new DataColumn("tmpReceipt_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_quotation_ID = new DataColumn("quotation_ID" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_postingStatus_ID2 = new DataColumn("postingStatus_ID2" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID" , typeof(string));
			DataColumn col_collector_ID = new DataColumn("collector_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_cashAmount = new DataColumn("cashAmount" , typeof(decimal));
			DataColumn col_depositedCashAmount = new DataColumn("depositedCashAmount" , typeof(decimal));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_tatalAmountInWord = new DataColumn("tatalAmountInWord" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_printedUser_ID = new DataColumn("printedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_datePrinted = new DataColumn("datePrinted" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_isAdvance = new DataColumn("isAdvance" , typeof(bool));
			DataColumn col_isOverPayment = new DataColumn("isOverPayment" , typeof(bool));
			DataColumn col_seattleAmount = new DataColumn("seattleAmount" , typeof(decimal));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_isSalesReceipt = new DataColumn("isSalesReceipt" , typeof(bool));
			DataColumn col_oldestInvoiceDate = new DataColumn("oldestInvoiceDate" , typeof(DateTime));
			DataColumn col_invoiceList = new DataColumn("invoiceList" , typeof(string));
			DataColumn col_isCashDeposited = new DataColumn("isCashDeposited" , typeof(bool));
			DataColumn col_dateDeposited = new DataColumn("dateDeposited" , typeof(DateTime));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_receipt_ID,col_receiptDate,col_remark,col_tmpReceipt_ID,col_customer_ID,col_invoice_ID,col_quotation_ID,col_customerOrder_ID,col_deliveryOrder_ID,col_orderRefNo_ID,col_glPosting_ID,col_postingStatus_ID,col_postingStatus_ID2,col_financialYear_ID,col_salesNoteType_ID,col_collector_ID,col_currency_ID,col_currencyRate,col_cashAmount,col_depositedCashAmount,col_chequeAmount,col_totalAmount,col_tatalAmountInWord,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_printedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_printCount,col_isAdvance,col_isOverPayment,col_seattleAmount,col_isSeattled,col_isSalesReceipt,col_oldestInvoiceDate,col_invoiceList,col_isCashDeposited,col_dateDeposited,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsReceipt datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsReceipt object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsReceipt user) {
		DataRow drow = dt.NewRow();
		
			drow["receipt_ID"] = user.receipt_ID;
			drow["receiptDate"] = user.receiptDate;
			drow["remark"] = user.remark;
			drow["tmpReceipt_ID"] = user.tmpReceipt_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["quotation_ID"] = user.quotation_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["postingStatus_ID2"] = user.postingStatus_ID2;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["salesNoteType_ID"] = user.salesNoteType_ID;
			drow["collector_ID"] = user.collector_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["cashAmount"] = user.cashAmount;
			drow["depositedCashAmount"] = user.depositedCashAmount;
			drow["chequeAmount"] = user.chequeAmount;
			drow["totalAmount"] = user.totalAmount;
			drow["tatalAmountInWord"] = user.tatalAmountInWord;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["printedUser_ID"] = user.printedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["datePrinted"] = user.datePrinted;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["printCount"] = user.printCount;
			drow["isAdvance"] = user.isAdvance;
			drow["isOverPayment"] = user.isOverPayment;
			drow["seattleAmount"] = user.seattleAmount;
			drow["isSeattled"] = user.isSeattled;
			drow["isSalesReceipt"] = user.isSalesReceipt;
			drow["oldestInvoiceDate"] = user.oldestInvoiceDate;
			drow["invoiceList"] = user.invoiceList;
			drow["isCashDeposited"] = user.isCashDeposited;
			drow["dateDeposited"] = user.dateDeposited;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}


}
