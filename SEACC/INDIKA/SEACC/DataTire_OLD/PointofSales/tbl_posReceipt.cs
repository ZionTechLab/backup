using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_posReceipt {
		#region Fields
		private string posReceipt_ID;
		private DateTime posReceiptDate;
		private int posTransaction_Index;
		private string remark;
		private string customer_ID;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string postingStatus_ID2;
		private string financialYear_ID;
		private string salesNoteType_ID;
		private string currency_ID;
		private decimal currencyRate;
		private decimal cashAmount;
		private decimal chequeAmount;
		private decimal totalAmount;
		private string totalAmountInWord;
		private decimal tenderedAmount;
		private decimal posTxBalanceAmount;
		private decimal changeAmount;
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
		private bool isPartPayment;
		private bool isFullPayment;
		private bool isAdvance;
		private bool isOverPayment;
		private decimal seattleAmount;
		private bool isSeattled;
		private string companyID;
		private string companyBranch_ID;
		private int advanceReceived_Index;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_posReceipt class.
		/// </summary>
		public tbl_posReceipt() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_posReceipt class.
		/// </summary>
		public tbl_posReceipt(string posReceipt_ID, DateTime posReceiptDate, int posTransaction_Index, string remark, string customer_ID, string glPosting_ID, string postingStatus_ID, string postingStatus_ID2, string financialYear_ID, string salesNoteType_ID, string currency_ID, decimal currencyRate, decimal cashAmount, decimal chequeAmount, decimal totalAmount, string totalAmountInWord, decimal tenderedAmount, decimal posTxBalanceAmount, decimal changeAmount, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string printedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, int printCount, bool isPartPayment, bool isFullPayment, bool isAdvance, bool isOverPayment, decimal seattleAmount, bool isSeattled, string companyID, string companyBranch_ID, int advanceReceived_Index) {
			this.posReceipt_ID = posReceipt_ID;
			this.posReceiptDate = posReceiptDate;
			this.posTransaction_Index = posTransaction_Index;
			this.remark = remark;
			this.customer_ID = customer_ID;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.postingStatus_ID2 = postingStatus_ID2;
			this.financialYear_ID = financialYear_ID;
			this.salesNoteType_ID = salesNoteType_ID;
			this.currency_ID = currency_ID;
			this.currencyRate = currencyRate;
			this.cashAmount = cashAmount;
			this.chequeAmount = chequeAmount;
			this.totalAmount = totalAmount;
			this.totalAmountInWord = totalAmountInWord;
			this.tenderedAmount = tenderedAmount;
			this.posTxBalanceAmount = posTxBalanceAmount;
			this.changeAmount = changeAmount;
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
			this.isPartPayment = isPartPayment;
			this.isFullPayment = isFullPayment;
			this.isAdvance = isAdvance;
			this.isOverPayment = isOverPayment;
			this.seattleAmount = seattleAmount;
			this.isSeattled = isSeattled;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.advanceReceived_Index = advanceReceived_Index;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PosReceipt_ID value.
		/// </summary>
		public string PosReceipt_ID {
			get { return posReceipt_ID; }
			set { posReceipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosReceiptDate value.
		/// </summary>
		public DateTime PosReceiptDate {
			get { return posReceiptDate; }
			set { posReceiptDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosTransaction_Index value.
		/// </summary>
		public int PosTransaction_Index {
			get { return posTransaction_Index; }
			set { posTransaction_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
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
		/// Gets or sets the TotalAmountInWord value.
		/// </summary>
		public string TotalAmountInWord {
			get { return totalAmountInWord; }
			set { totalAmountInWord = value; }
		}
		
		/// <summary>
		/// Gets or sets the TenderedAmount value.
		/// </summary>
		public decimal TenderedAmount {
			get { return tenderedAmount; }
			set { tenderedAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosTxBalanceAmount value.
		/// </summary>
		public decimal PosTxBalanceAmount {
			get { return posTxBalanceAmount; }
			set { posTxBalanceAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChangeAmount value.
		/// </summary>
		public decimal ChangeAmount {
			get { return changeAmount; }
			set { changeAmount = value; }
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
		/// Gets or sets the IsPartPayment value.
		/// </summary>
		public bool IsPartPayment {
			get { return isPartPayment; }
			set { isPartPayment = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFullPayment value.
		/// </summary>
		public bool IsFullPayment {
			get { return isFullPayment; }
			set { isFullPayment = value; }
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
		/// Gets or sets the AdvanceReceived_Index value.
		/// </summary>
		public int AdvanceReceived_Index {
			get { return advanceReceived_Index; }
			set { advanceReceived_Index = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_posReceipt table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posReceiptInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posReceiptDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@postingStatus_ID2", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmountInWord", SqlDbType.VarChar,500);
			scom.Parameters.Add("@tenderedAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@posTxBalanceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@changeAmount", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@isPartPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFullPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAdvance", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOverPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@advanceReceived_Index", SqlDbType.Int,4);
 
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
			scom.Parameters["@posReceiptDate"].Value = posReceiptDate;
			scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@postingStatus_ID2"].Value = postingStatus_ID2;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@cashAmount"].Value = cashAmount;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@totalAmountInWord"].Value = totalAmountInWord;
			scom.Parameters["@tenderedAmount"].Value = tenderedAmount;
			scom.Parameters["@posTxBalanceAmount"].Value = posTxBalanceAmount;
			scom.Parameters["@changeAmount"].Value = changeAmount;
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
			scom.Parameters["@isPartPayment"].Value = isPartPayment;
			scom.Parameters["@isFullPayment"].Value = isFullPayment;
			scom.Parameters["@isAdvance"].Value = isAdvance;
			scom.Parameters["@isOverPayment"].Value = isOverPayment;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@advanceReceived_Index"].Value = advanceReceived_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_posReceipt table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posReceiptUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posReceiptDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@postingStatus_ID2", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmountInWord", SqlDbType.VarChar,500);
			scom.Parameters.Add("@tenderedAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@posTxBalanceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@changeAmount", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@isPartPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFullPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAdvance", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOverPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@advanceReceived_Index", SqlDbType.Int,4);
 
 
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
			scom.Parameters["@posReceiptDate"].Value = posReceiptDate;
			scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@postingStatus_ID2"].Value = postingStatus_ID2;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@cashAmount"].Value = cashAmount;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@totalAmountInWord"].Value = totalAmountInWord;
			scom.Parameters["@tenderedAmount"].Value = tenderedAmount;
			scom.Parameters["@posTxBalanceAmount"].Value = posTxBalanceAmount;
			scom.Parameters["@changeAmount"].Value = changeAmount;
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
			scom.Parameters["@isPartPayment"].Value = isPartPayment;
			scom.Parameters["@isFullPayment"].Value = isFullPayment;
			scom.Parameters["@isAdvance"].Value = isAdvance;
			scom.Parameters["@isOverPayment"].Value = isOverPayment;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@advanceReceived_Index"].Value = advanceReceived_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_posReceipt table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posReceiptDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posReceiptDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByAdvanceReceived_Index(int advanceReceived_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posReceiptDeleteAllByAdvanceReceived_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@advanceReceived_Index", SqlDbType.Int,4);
			scom.Parameters["@advanceReceived_Index"].Value = advanceReceived_Index;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_posReceipt table.
		/// </summary>
		public static tbl_posReceipt Select(string posReceipt_ID_Incoming){

			tbl_posReceipt tbl_posReceiptins = new tbl_posReceipt();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posReceiptSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_posReceiptins = Maketbl_posReceipt(dataReader);
				} else {
					tbl_posReceiptins = null;
				}
			}
			scon.Close();
			return tbl_posReceiptins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posReceipt table.
		/// </summary>
		public static List<tbl_posReceipt> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posReceiptSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_posReceipt> tbl_posReceiptList = new List<tbl_posReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posReceipt tbl_posReceipt = Maketbl_posReceipt(dataReader);
					tbl_posReceiptList.Add(tbl_posReceipt);
				}
			}
			scon.Close();
			return tbl_posReceiptList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posReceipt table by a foreign key.
		/// </summary>
		public static List<tbl_posReceipt> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posReceiptSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_posReceipt> tbl_posReceiptList = new List<tbl_posReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posReceipt tbl_posReceipt = Maketbl_posReceipt(dataReader);
					tbl_posReceiptList.Add(tbl_posReceipt);
				}
			}
			scon.Close();
			return tbl_posReceiptList;
		}

        public static List<tbl_posReceipt> SelectAllByPosTransaction_Index(int posTransaction_Index)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_posReceiptSelectAllByPosTransaction_Index", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int, 4);
            scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index;
            List<tbl_posReceipt> tbl_posReceiptList = new List<tbl_posReceipt>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_posReceipt tbl_posReceipt = Maketbl_posReceipt(dataReader);
                    tbl_posReceiptList.Add(tbl_posReceipt);
                }
            }
            scon.Close();
            return tbl_posReceiptList;
        }

        /// <summary>
        /// Selects all records from the tbl_posReceipt table by a foreign key.
        /// </summary>
        public static List<tbl_posReceipt> SelectAllByAdvanceReceived_Index(int advanceReceived_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posReceiptSelectAllByAdvanceReceived_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@advanceReceived_Index", SqlDbType.Int,4);
			scom.Parameters["@advanceReceived_Index"].Value = advanceReceived_Index;
				List<tbl_posReceipt> tbl_posReceiptList = new List<tbl_posReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posReceipt tbl_posReceipt = Maketbl_posReceipt(dataReader);
					tbl_posReceiptList.Add(tbl_posReceipt);
				}
			}
			scon.Close();
			return tbl_posReceiptList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_posReceipt class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_posReceipt Maketbl_posReceipt(SqlDataReader dataReader) {
			tbl_posReceipt tbl_posReceipt = new tbl_posReceipt();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_posReceipt.PosReceipt_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_posReceipt.PosReceiptDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_posReceipt.PosTransaction_Index = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_posReceipt.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_posReceipt.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_posReceipt.GlPosting_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_posReceipt.PostingStatus_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_posReceipt.PostingStatus_ID2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_posReceipt.FinancialYear_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_posReceipt.SalesNoteType_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_posReceipt.Currency_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_posReceipt.CurrencyRate = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_posReceipt.CashAmount = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_posReceipt.ChequeAmount = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_posReceipt.TotalAmount = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_posReceipt.TotalAmountInWord = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_posReceipt.TenderedAmount = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_posReceipt.PosTxBalanceAmount = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_posReceipt.ChangeAmount = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_posReceipt.CreateUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_posReceipt.ModifiedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_posReceipt.CheckedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_posReceipt.ApprovedUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_posReceipt.PrintedUser_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_posReceipt.DateCreate = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_posReceipt.DateModified = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_posReceipt.DateChecked = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_posReceipt.DateApproved = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_posReceipt.DatePrinted = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_posReceipt.IsChecked = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_posReceipt.IsApproved = dataReader.GetBoolean(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_posReceipt.IsFinished = dataReader.GetBoolean(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_posReceipt.IsDeleted = dataReader.GetBoolean(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_posReceipt.IsLocked = dataReader.GetBoolean(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_posReceipt.PrintCount = dataReader.GetInt32(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_posReceipt.IsPartPayment = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_posReceipt.IsFullPayment = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_posReceipt.IsAdvance = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_posReceipt.IsOverPayment = dataReader.GetBoolean(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_posReceipt.SeattleAmount = dataReader.GetDecimal(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_posReceipt.IsSeattled = dataReader.GetBoolean(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_posReceipt.CompanyID = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_posReceipt.CompanyBranch_ID = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_posReceipt.AdvanceReceived_Index = dataReader.GetInt32(43);
			}

			return tbl_posReceipt;
		}
		/// <summary>
		/// This makes tbl_posReceipt datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_posReceipt object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_posReceipt  tbl_posReceipt   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_posReceipt_ID = new DataColumn("posReceipt_ID" , typeof(string));
			DataColumn col_posReceiptDate = new DataColumn("posReceiptDate" , typeof(DateTime));
			DataColumn col_posTransaction_Index = new DataColumn("posTransaction_Index" , typeof(int));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_postingStatus_ID2 = new DataColumn("postingStatus_ID2" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_cashAmount = new DataColumn("cashAmount" , typeof(decimal));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_totalAmountInWord = new DataColumn("totalAmountInWord" , typeof(string));
			DataColumn col_tenderedAmount = new DataColumn("tenderedAmount" , typeof(decimal));
			DataColumn col_posTxBalanceAmount = new DataColumn("posTxBalanceAmount" , typeof(decimal));
			DataColumn col_changeAmount = new DataColumn("changeAmount" , typeof(decimal));
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
			DataColumn col_isPartPayment = new DataColumn("isPartPayment" , typeof(bool));
			DataColumn col_isFullPayment = new DataColumn("isFullPayment" , typeof(bool));
			DataColumn col_isAdvance = new DataColumn("isAdvance" , typeof(bool));
			DataColumn col_isOverPayment = new DataColumn("isOverPayment" , typeof(bool));
			DataColumn col_seattleAmount = new DataColumn("seattleAmount" , typeof(decimal));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_advanceReceived_Index = new DataColumn("advanceReceived_Index" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_posReceipt_ID,col_posReceiptDate,col_posTransaction_Index,col_remark,col_customer_ID,col_glPosting_ID,col_postingStatus_ID,col_postingStatus_ID2,col_financialYear_ID,col_salesNoteType_ID,col_currency_ID,col_currencyRate,col_cashAmount,col_chequeAmount,col_totalAmount,col_totalAmountInWord,col_tenderedAmount,col_posTxBalanceAmount,col_changeAmount,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_printedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_printCount,col_isPartPayment,col_isFullPayment,col_isAdvance,col_isOverPayment,col_seattleAmount,col_isSeattled,col_companyID,col_companyBranch_ID,col_advanceReceived_Index,});		return dt;
		}
		/// <summary>
		/// This fills tbl_posReceipt datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_posReceipt object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_posReceipt user) {
		DataRow drow = dt.NewRow();
		
			drow["posReceipt_ID"] = user.posReceipt_ID;
			drow["posReceiptDate"] = user.posReceiptDate;
			drow["posTransaction_Index"] = user.posTransaction_Index;
			drow["remark"] = user.remark;
			drow["customer_ID"] = user.customer_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["postingStatus_ID2"] = user.postingStatus_ID2;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["salesNoteType_ID"] = user.salesNoteType_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["cashAmount"] = user.cashAmount;
			drow["chequeAmount"] = user.chequeAmount;
			drow["totalAmount"] = user.totalAmount;
			drow["totalAmountInWord"] = user.totalAmountInWord;
			drow["tenderedAmount"] = user.tenderedAmount;
			drow["posTxBalanceAmount"] = user.posTxBalanceAmount;
			drow["changeAmount"] = user.changeAmount;
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
			drow["isPartPayment"] = user.isPartPayment;
			drow["isFullPayment"] = user.isFullPayment;
			drow["isAdvance"] = user.isAdvance;
			drow["isOverPayment"] = user.isOverPayment;
			drow["seattleAmount"] = user.seattleAmount;
			drow["isSeattled"] = user.isSeattled;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["advanceReceived_Index"] = user.advanceReceived_Index;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
