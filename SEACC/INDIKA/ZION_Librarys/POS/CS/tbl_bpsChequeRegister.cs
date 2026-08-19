using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsChequeRegister {
		#region Fields
		private string chequeRegister_ID;
		private string remark;
		private DateTime dateRegister;
		private int paymentMethod_ID;
		private int transferType;
		private string transferRefNo;
		private int giftVoucherID;
		private int merchant_DeviceID;
		private string lastFourDigits;
		private string cardOwnerName;
		private int cardType;
		private int cardCategory;
		private DateTime dateCheque;
		private string customer_ID;
		private string accountNumber;
		private string depositedAccountNumber;
		private int companyAccount_ID;
		private string bank_ID;
		private string depositedBank_ID;
		private string branch_ID;
		private string depositedBranch_ID;
		private string chequeStatus_ID;
		private string chequeType_ID;
		private string invoice_ID;
		private string posTransaction_ID;
		private string receipt_ID;
		private string posReceipt_ID;
		private string accountReceipt_ID;
		private string orderRefNo_ID;
		private string chequeNumber;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string postingStatus_ID2;
		private string financialYear_ID;
		private decimal amount;
		private bool isSetteled;
		private bool isSetteledReturned;
		private bool isDepositted;
		private bool isReIssued;
		private bool isReconcilied;
		private bool isReturned;
		private bool isReturnedToSender;
		private string createUser_ID;
		private string modifiedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private bool isDeleted;
		private bool isLocked;
		private int depositCount;
		private decimal paneltyAmount;
		private decimal setteledAmount;
		private decimal depositedCashAmount;
		private DateTime dateDeposited;
		private DateTime dateReconcilied;
		private DateTime dateReIssued;
		private DateTime dateReturnedToSender;
		private string companyID;
		private string companyBranch_ID;
		private int posReturnTransaction_Index;
		private int advanceReceived_Index;
		private int recSerialNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeRegister class.
		/// </summary>
		public tbl_bpsChequeRegister() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeRegister class.
		/// </summary>
		public tbl_bpsChequeRegister(string chequeRegister_ID, string remark, DateTime dateRegister, int paymentMethod_ID, int transferType, string transferRefNo, int giftVoucherID, int merchant_DeviceID, string lastFourDigits, string cardOwnerName, int cardType, int cardCategory, DateTime dateCheque, string customer_ID, string accountNumber, string depositedAccountNumber, int companyAccount_ID, string bank_ID, string depositedBank_ID, string branch_ID, string depositedBranch_ID, string chequeStatus_ID, string chequeType_ID, string invoice_ID, string posTransaction_ID, string receipt_ID, string posReceipt_ID, string accountReceipt_ID, string orderRefNo_ID, string chequeNumber, string glPosting_ID, string postingStatus_ID, string postingStatus_ID2, string financialYear_ID, decimal amount, bool isSetteled, bool isSetteledReturned, bool isDepositted, bool isReIssued, bool isReconcilied, bool isReturned, bool isReturnedToSender, string createUser_ID, string modifiedUser_ID, DateTime dateCreate, DateTime dateModified, bool isDeleted, bool isLocked, int depositCount, decimal paneltyAmount, decimal setteledAmount, decimal depositedCashAmount, DateTime dateDeposited, DateTime dateReconcilied, DateTime dateReIssued, DateTime dateReturnedToSender, string companyID, string companyBranch_ID, int posReturnTransaction_Index, int advanceReceived_Index, int recSerialNo) {
			this.chequeRegister_ID = chequeRegister_ID;
			this.remark = remark;
			this.dateRegister = dateRegister;
			this.paymentMethod_ID = paymentMethod_ID;
			this.transferType = transferType;
			this.transferRefNo = transferRefNo;
			this.giftVoucherID = giftVoucherID;
			this.merchant_DeviceID = merchant_DeviceID;
			this.lastFourDigits = lastFourDigits;
			this.cardOwnerName = cardOwnerName;
			this.cardType = cardType;
			this.cardCategory = cardCategory;
			this.dateCheque = dateCheque;
			this.customer_ID = customer_ID;
			this.accountNumber = accountNumber;
			this.depositedAccountNumber = depositedAccountNumber;
			this.companyAccount_ID = companyAccount_ID;
			this.bank_ID = bank_ID;
			this.depositedBank_ID = depositedBank_ID;
			this.branch_ID = branch_ID;
			this.depositedBranch_ID = depositedBranch_ID;
			this.chequeStatus_ID = chequeStatus_ID;
			this.chequeType_ID = chequeType_ID;
			this.invoice_ID = invoice_ID;
			this.posTransaction_ID = posTransaction_ID;
			this.receipt_ID = receipt_ID;
			this.posReceipt_ID = posReceipt_ID;
			this.accountReceipt_ID = accountReceipt_ID;
			this.orderRefNo_ID = orderRefNo_ID;
			this.chequeNumber = chequeNumber;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.postingStatus_ID2 = postingStatus_ID2;
			this.financialYear_ID = financialYear_ID;
			this.amount = amount;
			this.isSetteled = isSetteled;
			this.isSetteledReturned = isSetteledReturned;
			this.isDepositted = isDepositted;
			this.isReIssued = isReIssued;
			this.isReconcilied = isReconcilied;
			this.isReturned = isReturned;
			this.isReturnedToSender = isReturnedToSender;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.depositCount = depositCount;
			this.paneltyAmount = paneltyAmount;
			this.setteledAmount = setteledAmount;
			this.depositedCashAmount = depositedCashAmount;
			this.dateDeposited = dateDeposited;
			this.dateReconcilied = dateReconcilied;
			this.dateReIssued = dateReIssued;
			this.dateReturnedToSender = dateReturnedToSender;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.posReturnTransaction_Index = posReturnTransaction_Index;
			this.advanceReceived_Index = advanceReceived_Index;
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
		/// Gets or sets the DateRegister value.
		/// </summary>
		public DateTime DateRegister {
			get { return dateRegister; }
			set { dateRegister = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentMethod_ID value.
		/// </summary>
		public int PaymentMethod_ID {
			get { return paymentMethod_ID; }
			set { paymentMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransferType value.
		/// </summary>
		public int TransferType {
			get { return transferType; }
			set { transferType = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransferRefNo value.
		/// </summary>
		public string TransferRefNo {
			get { return transferRefNo; }
			set { transferRefNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the GiftVoucherID value.
		/// </summary>
		public int GiftVoucherID {
			get { return giftVoucherID; }
			set { giftVoucherID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Merchant_DeviceID value.
		/// </summary>
		public int Merchant_DeviceID {
			get { return merchant_DeviceID; }
			set { merchant_DeviceID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LastFourDigits value.
		/// </summary>
		public string LastFourDigits {
			get { return lastFourDigits; }
			set { lastFourDigits = value; }
		}
		
		/// <summary>
		/// Gets or sets the CardOwnerName value.
		/// </summary>
		public string CardOwnerName {
			get { return cardOwnerName; }
			set { cardOwnerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CardType value.
		/// </summary>
		public int CardType {
			get { return cardType; }
			set { cardType = value; }
		}
		
		/// <summary>
		/// Gets or sets the CardCategory value.
		/// </summary>
		public int CardCategory {
			get { return cardCategory; }
			set { cardCategory = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCheque value.
		/// </summary>
		public DateTime DateCheque {
			get { return dateCheque; }
			set { dateCheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountNumber value.
		/// </summary>
		public string AccountNumber {
			get { return accountNumber; }
			set { accountNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepositedAccountNumber value.
		/// </summary>
		public string DepositedAccountNumber {
			get { return depositedAccountNumber; }
			set { depositedAccountNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyAccount_ID value.
		/// </summary>
		public int CompanyAccount_ID {
			get { return companyAccount_ID; }
			set { companyAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bank_ID value.
		/// </summary>
		public string Bank_ID {
			get { return bank_ID; }
			set { bank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepositedBank_ID value.
		/// </summary>
		public string DepositedBank_ID {
			get { return depositedBank_ID; }
			set { depositedBank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Branch_ID value.
		/// </summary>
		public string Branch_ID {
			get { return branch_ID; }
			set { branch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepositedBranch_ID value.
		/// </summary>
		public string DepositedBranch_ID {
			get { return depositedBranch_ID; }
			set { depositedBranch_ID = value; }
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
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosTransaction_ID value.
		/// </summary>
		public string PosTransaction_ID {
			get { return posTransaction_ID; }
			set { posTransaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosReceipt_ID value.
		/// </summary>
		public string PosReceipt_ID {
			get { return posReceipt_ID; }
			set { posReceipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountReceipt_ID value.
		/// </summary>
		public string AccountReceipt_ID {
			get { return accountReceipt_ID; }
			set { accountReceipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo_ID value.
		/// </summary>
		public string OrderRefNo_ID {
			get { return orderRefNo_ID; }
			set { orderRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeNumber value.
		/// </summary>
		public string ChequeNumber {
			get { return chequeNumber; }
			set { chequeNumber = value; }
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
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSetteled value.
		/// </summary>
		public bool IsSetteled {
			get { return isSetteled; }
			set { isSetteled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSetteledReturned value.
		/// </summary>
		public bool IsSetteledReturned {
			get { return isSetteledReturned; }
			set { isSetteledReturned = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDepositted value.
		/// </summary>
		public bool IsDepositted {
			get { return isDepositted; }
			set { isDepositted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReIssued value.
		/// </summary>
		public bool IsReIssued {
			get { return isReIssued; }
			set { isReIssued = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReconcilied value.
		/// </summary>
		public bool IsReconcilied {
			get { return isReconcilied; }
			set { isReconcilied = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReturned value.
		/// </summary>
		public bool IsReturned {
			get { return isReturned; }
			set { isReturned = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReturnedToSender value.
		/// </summary>
		public bool IsReturnedToSender {
			get { return isReturnedToSender; }
			set { isReturnedToSender = value; }
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
		/// Gets or sets the DepositCount value.
		/// </summary>
		public int DepositCount {
			get { return depositCount; }
			set { depositCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaneltyAmount value.
		/// </summary>
		public decimal PaneltyAmount {
			get { return paneltyAmount; }
			set { paneltyAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the SetteledAmount value.
		/// </summary>
		public decimal SetteledAmount {
			get { return setteledAmount; }
			set { setteledAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepositedCashAmount value.
		/// </summary>
		public decimal DepositedCashAmount {
			get { return depositedCashAmount; }
			set { depositedCashAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateDeposited value.
		/// </summary>
		public DateTime DateDeposited {
			get { return dateDeposited; }
			set { dateDeposited = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateReconcilied value.
		/// </summary>
		public DateTime DateReconcilied {
			get { return dateReconcilied; }
			set { dateReconcilied = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateReIssued value.
		/// </summary>
		public DateTime DateReIssued {
			get { return dateReIssued; }
			set { dateReIssued = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateReturnedToSender value.
		/// </summary>
		public DateTime DateReturnedToSender {
			get { return dateReturnedToSender; }
			set { dateReturnedToSender = value; }
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
		/// Gets or sets the PosReturnTransaction_Index value.
		/// </summary>
		public int PosReturnTransaction_Index {
			get { return posReturnTransaction_Index; }
			set { posReturnTransaction_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the AdvanceReceived_Index value.
		/// </summary>
		public int AdvanceReceived_Index {
			get { return advanceReceived_Index; }
			set { advanceReceived_Index = value; }
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
		/// Saves a record to the tbl_bpsChequeRegister table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateRegister", SqlDbType.DateTime,8);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transferType", SqlDbType.Int,4);
			scom.Parameters.Add("@transferRefNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@giftVoucherID", SqlDbType.Int,4);
			scom.Parameters.Add("@merchant_DeviceID", SqlDbType.Int,4);
			scom.Parameters.Add("@lastFourDigits", SqlDbType.VarChar,200);
			scom.Parameters.Add("@cardOwnerName", SqlDbType.VarChar,200);
			scom.Parameters.Add("@cardType", SqlDbType.Int,4);
			scom.Parameters.Add("@cardCategory", SqlDbType.Int,4);
			scom.Parameters.Add("@dateCheque", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@depositedAccountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@depositedBank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@depositedBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@postingStatus_ID2", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSetteled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSetteledReturned", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDepositted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReIssued", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReconcilied", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturned", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturnedToSender", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@depositCount", SqlDbType.Int,4);
			scom.Parameters.Add("@paneltyAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@setteledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depositedCashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dateDeposited", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateReconcilied", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateReIssued", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateReturnedToSender", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posReturnTransaction_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@advanceReceived_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dateRegister"].Value = dateRegister;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@transferType"].Value = transferType;
			scom.Parameters["@transferRefNo"].Value = transferRefNo;
			scom.Parameters["@giftVoucherID"].Value = giftVoucherID;
			scom.Parameters["@merchant_DeviceID"].Value = merchant_DeviceID;
			scom.Parameters["@lastFourDigits"].Value = lastFourDigits;
			scom.Parameters["@cardOwnerName"].Value = cardOwnerName;
			scom.Parameters["@cardType"].Value = cardType;
			scom.Parameters["@cardCategory"].Value = cardCategory;
			scom.Parameters["@dateCheque"].Value = dateCheque;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@depositedAccountNumber"].Value = depositedAccountNumber;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@depositedBank_ID"].Value = depositedBank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@depositedBranch_ID"].Value = depositedBranch_ID;
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
			scom.Parameters["@chequeType_ID"].Value = chequeType_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@postingStatus_ID2"].Value = postingStatus_ID2;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@isSetteled"].Value = isSetteled;
			scom.Parameters["@isSetteledReturned"].Value = isSetteledReturned;
			scom.Parameters["@isDepositted"].Value = isDepositted;
			scom.Parameters["@isReIssued"].Value = isReIssued;
			scom.Parameters["@isReconcilied"].Value = isReconcilied;
			scom.Parameters["@isReturned"].Value = isReturned;
			scom.Parameters["@isReturnedToSender"].Value = isReturnedToSender;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@depositCount"].Value = depositCount;
			scom.Parameters["@paneltyAmount"].Value = paneltyAmount;
			scom.Parameters["@setteledAmount"].Value = setteledAmount;
			scom.Parameters["@depositedCashAmount"].Value = depositedCashAmount;
			scom.Parameters["@dateDeposited"].Value = dateDeposited;
			scom.Parameters["@dateReconcilied"].Value = dateReconcilied;
			scom.Parameters["@dateReIssued"].Value = dateReIssued;
			scom.Parameters["@dateReturnedToSender"].Value = dateReturnedToSender;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@posReturnTransaction_Index"].Value = posReturnTransaction_Index;
			scom.Parameters["@advanceReceived_Index"].Value = advanceReceived_Index;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsChequeRegister table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateRegister", SqlDbType.DateTime,8);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transferType", SqlDbType.Int,4);
			scom.Parameters.Add("@transferRefNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@giftVoucherID", SqlDbType.Int,4);
			scom.Parameters.Add("@merchant_DeviceID", SqlDbType.Int,4);
			scom.Parameters.Add("@lastFourDigits", SqlDbType.VarChar,200);
			scom.Parameters.Add("@cardOwnerName", SqlDbType.VarChar,200);
			scom.Parameters.Add("@cardType", SqlDbType.Int,4);
			scom.Parameters.Add("@cardCategory", SqlDbType.Int,4);
			scom.Parameters.Add("@dateCheque", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@depositedAccountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@depositedBank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@depositedBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@postingStatus_ID2", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSetteled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSetteledReturned", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDepositted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReIssued", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReconcilied", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturned", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturnedToSender", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@depositCount", SqlDbType.Int,4);
			scom.Parameters.Add("@paneltyAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@setteledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@depositedCashAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dateDeposited", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateReconcilied", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateReIssued", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateReturnedToSender", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posReturnTransaction_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@advanceReceived_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
 
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dateRegister"].Value = dateRegister;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@transferType"].Value = transferType;
			scom.Parameters["@transferRefNo"].Value = transferRefNo;
			scom.Parameters["@giftVoucherID"].Value = giftVoucherID;
			scom.Parameters["@merchant_DeviceID"].Value = merchant_DeviceID;
			scom.Parameters["@lastFourDigits"].Value = lastFourDigits;
			scom.Parameters["@cardOwnerName"].Value = cardOwnerName;
			scom.Parameters["@cardType"].Value = cardType;
			scom.Parameters["@cardCategory"].Value = cardCategory;
			scom.Parameters["@dateCheque"].Value = dateCheque;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@depositedAccountNumber"].Value = depositedAccountNumber;
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@depositedBank_ID"].Value = depositedBank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@depositedBranch_ID"].Value = depositedBranch_ID;
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
			scom.Parameters["@chequeType_ID"].Value = chequeType_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@postingStatus_ID2"].Value = postingStatus_ID2;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@isSetteled"].Value = isSetteled;
			scom.Parameters["@isSetteledReturned"].Value = isSetteledReturned;
			scom.Parameters["@isDepositted"].Value = isDepositted;
			scom.Parameters["@isReIssued"].Value = isReIssued;
			scom.Parameters["@isReconcilied"].Value = isReconcilied;
			scom.Parameters["@isReturned"].Value = isReturned;
			scom.Parameters["@isReturnedToSender"].Value = isReturnedToSender;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@depositCount"].Value = depositCount;
			scom.Parameters["@paneltyAmount"].Value = paneltyAmount;
			scom.Parameters["@setteledAmount"].Value = setteledAmount;
			scom.Parameters["@depositedCashAmount"].Value = depositedCashAmount;
			scom.Parameters["@dateDeposited"].Value = dateDeposited;
			scom.Parameters["@dateReconcilied"].Value = dateReconcilied;
			scom.Parameters["@dateReIssued"].Value = dateReIssued;
			scom.Parameters["@dateReturnedToSender"].Value = dateReturnedToSender;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@posReturnTransaction_Index"].Value = posReturnTransaction_Index;
			scom.Parameters["@advanceReceived_Index"].Value = advanceReceived_Index;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsChequeRegister table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeStatus_ID(string chequeStatus_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByChequeStatus_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByAccountReceipt_ID(string accountReceipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByAccountReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
        public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByChequeRegister_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            //scon.Open();

            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
        /// </summary>
        public static void DeleteAllByChequeType_ID(string chequeType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByChequeType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@chequeType_ID"].Value = chequeType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByMerchant_DeviceID(int merchant_DeviceID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByMerchant_DeviceID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@merchant_DeviceID", SqlDbType.Int,4);
			scom.Parameters["@merchant_DeviceID"].Value = merchant_DeviceID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByReceipt_ID(string receipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByPosReceipt_ID(string posReceipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByPosReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterDeleteAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsChequeRegister table.
		/// </summary>
		public static tbl_bpsChequeRegister Select(string chequeRegister_ID_Incoming){

			tbl_bpsChequeRegister tbl_bpsChequeRegisterins = new tbl_bpsChequeRegister();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsChequeRegisterins = Maketbl_bpsChequeRegister(dataReader);
				} else {
					tbl_bpsChequeRegisterins = null;
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table.
		/// </summary>
		public static List<tbl_bpsChequeRegister> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
        public static List<tbl_bpsChequeRegister> SelectAllChequeRegister_ForReturnedChequeSummary(string sInvoiceID_CheqRegisterID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAll_ForReturnedChequeSummary", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@invoiceChReg_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@invoiceChReg_ID"].Value = sInvoiceID_CheqRegisterID;

            List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
                    tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
                }
            }
            scon.Close();
            return tbl_bpsChequeRegisterList;
        }

        /// <summary>
        /// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
        /// </summary>
        public static List<tbl_bpsChequeRegister> SelectAllByChequeStatus_ID(string chequeStatus_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByChequeStatus_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeRegister> SelectAllByAccountReceipt_ID(string accountReceipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByAccountReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeRegister> SelectAllByChequeType_ID(string chequeType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByChequeType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@chequeType_ID"].Value = chequeType_ID;
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeRegister> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeRegister> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeRegister> SelectAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeRegister> SelectAllByMerchant_DeviceID(int merchant_DeviceID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByMerchant_DeviceID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@merchant_DeviceID", SqlDbType.Int,4);
			scom.Parameters["@merchant_DeviceID"].Value = merchant_DeviceID;
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
        public static List<tbl_bpsChequeRegister> SelectAllByCompanyBranch_ID(string companyBranch_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByCompanyBranch_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
                    tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
                }
            }
            scon.Close();
            return tbl_bpsChequeRegisterList;
        }
        /// <summary>
        /// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
        /// </summary>
        public static List<tbl_bpsChequeRegister> SelectAllByReceipt_ID(string receipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeRegister> SelectAllByPosReceipt_ID(string posReceipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByPosReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@posReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@posReceipt_ID"].Value = posReceipt_ID;
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeRegister> SelectAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeRegisterSelectAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters["@bank_ID"].Value = bank_ID;
				List<tbl_bpsChequeRegister> tbl_bpsChequeRegisterList = new List<tbl_bpsChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeRegister tbl_bpsChequeRegister = Maketbl_bpsChequeRegister(dataReader);
					tbl_bpsChequeRegisterList.Add(tbl_bpsChequeRegister);
				}
			}
			scon.Close();
			return tbl_bpsChequeRegisterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsChequeRegister class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsChequeRegister Maketbl_bpsChequeRegister(SqlDataReader dataReader) {
			tbl_bpsChequeRegister tbl_bpsChequeRegister = new tbl_bpsChequeRegister();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsChequeRegister.ChequeRegister_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsChequeRegister.Remark = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsChequeRegister.DateRegister = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsChequeRegister.PaymentMethod_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsChequeRegister.TransferType = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsChequeRegister.TransferRefNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsChequeRegister.GiftVoucherID = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsChequeRegister.Merchant_DeviceID = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsChequeRegister.LastFourDigits = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsChequeRegister.CardOwnerName = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsChequeRegister.CardType = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsChequeRegister.CardCategory = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsChequeRegister.DateCheque = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsChequeRegister.Customer_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsChequeRegister.AccountNumber = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsChequeRegister.DepositedAccountNumber = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsChequeRegister.CompanyAccount_ID = dataReader.GetInt32(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsChequeRegister.Bank_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsChequeRegister.DepositedBank_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsChequeRegister.Branch_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_bpsChequeRegister.DepositedBranch_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_bpsChequeRegister.ChequeStatus_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_bpsChequeRegister.ChequeType_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_bpsChequeRegister.Invoice_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_bpsChequeRegister.PosTransaction_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_bpsChequeRegister.Receipt_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_bpsChequeRegister.PosReceipt_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_bpsChequeRegister.AccountReceipt_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_bpsChequeRegister.OrderRefNo_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_bpsChequeRegister.ChequeNumber = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_bpsChequeRegister.GlPosting_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_bpsChequeRegister.PostingStatus_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_bpsChequeRegister.PostingStatus_ID2 = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_bpsChequeRegister.FinancialYear_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_bpsChequeRegister.Amount = dataReader.GetDecimal(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_bpsChequeRegister.IsSetteled = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_bpsChequeRegister.IsSetteledReturned = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_bpsChequeRegister.IsDepositted = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_bpsChequeRegister.IsReIssued = dataReader.GetBoolean(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_bpsChequeRegister.IsReconcilied = dataReader.GetBoolean(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_bpsChequeRegister.IsReturned = dataReader.GetBoolean(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_bpsChequeRegister.IsReturnedToSender = dataReader.GetBoolean(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_bpsChequeRegister.CreateUser_ID = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_bpsChequeRegister.ModifiedUser_ID = dataReader.GetString(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_bpsChequeRegister.DateCreate = dataReader.GetDateTime(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_bpsChequeRegister.DateModified = dataReader.GetDateTime(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_bpsChequeRegister.IsDeleted = dataReader.GetBoolean(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_bpsChequeRegister.IsLocked = dataReader.GetBoolean(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_bpsChequeRegister.DepositCount = dataReader.GetInt32(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_bpsChequeRegister.PaneltyAmount = dataReader.GetDecimal(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_bpsChequeRegister.SetteledAmount = dataReader.GetDecimal(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_bpsChequeRegister.DepositedCashAmount = dataReader.GetDecimal(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_bpsChequeRegister.DateDeposited = dataReader.GetDateTime(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_bpsChequeRegister.DateReconcilied = dataReader.GetDateTime(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_bpsChequeRegister.DateReIssued = dataReader.GetDateTime(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_bpsChequeRegister.DateReturnedToSender = dataReader.GetDateTime(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_bpsChequeRegister.CompanyID = dataReader.GetString(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_bpsChequeRegister.CompanyBranch_ID = dataReader.GetString(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_bpsChequeRegister.PosReturnTransaction_Index = dataReader.GetInt32(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_bpsChequeRegister.AdvanceReceived_Index = dataReader.GetInt32(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_bpsChequeRegister.RecSerialNo = dataReader.GetInt32(60);
			}

			return tbl_bpsChequeRegister;
		}
		/// <summary>
		/// This makes tbl_bpsChequeRegister datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsChequeRegister object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsChequeRegister  tbl_bpsChequeRegister   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_dateRegister = new DataColumn("dateRegister" , typeof(DateTime));
			DataColumn col_paymentMethod_ID = new DataColumn("paymentMethod_ID" , typeof(int));
			DataColumn col_transferType = new DataColumn("transferType" , typeof(int));
			DataColumn col_transferRefNo = new DataColumn("transferRefNo" , typeof(string));
			DataColumn col_giftVoucherID = new DataColumn("giftVoucherID" , typeof(int));
			DataColumn col_merchant_DeviceID = new DataColumn("merchant_DeviceID" , typeof(int));
			DataColumn col_lastFourDigits = new DataColumn("lastFourDigits" , typeof(string));
			DataColumn col_cardOwnerName = new DataColumn("cardOwnerName" , typeof(string));
			DataColumn col_cardType = new DataColumn("cardType" , typeof(int));
			DataColumn col_cardCategory = new DataColumn("cardCategory" , typeof(int));
			DataColumn col_dateCheque = new DataColumn("dateCheque" , typeof(DateTime));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_accountNumber = new DataColumn("accountNumber" , typeof(string));
			DataColumn col_depositedAccountNumber = new DataColumn("depositedAccountNumber" , typeof(string));
			DataColumn col_companyAccount_ID = new DataColumn("companyAccount_ID" , typeof(int));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_depositedBank_ID = new DataColumn("depositedBank_ID" , typeof(string));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_depositedBranch_ID = new DataColumn("depositedBranch_ID" , typeof(string));
			DataColumn col_chequeStatus_ID = new DataColumn("chequeStatus_ID" , typeof(string));
			DataColumn col_chequeType_ID = new DataColumn("chequeType_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_posTransaction_ID = new DataColumn("posTransaction_ID" , typeof(string));
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_posReceipt_ID = new DataColumn("posReceipt_ID" , typeof(string));
			DataColumn col_accountReceipt_ID = new DataColumn("accountReceipt_ID" , typeof(string));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_chequeNumber = new DataColumn("chequeNumber" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_postingStatus_ID2 = new DataColumn("postingStatus_ID2" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_isSetteled = new DataColumn("isSetteled" , typeof(bool));
			DataColumn col_isSetteledReturned = new DataColumn("isSetteledReturned" , typeof(bool));
			DataColumn col_isDepositted = new DataColumn("isDepositted" , typeof(bool));
			DataColumn col_isReIssued = new DataColumn("isReIssued" , typeof(bool));
			DataColumn col_isReconcilied = new DataColumn("isReconcilied" , typeof(bool));
			DataColumn col_isReturned = new DataColumn("isReturned" , typeof(bool));
			DataColumn col_isReturnedToSender = new DataColumn("isReturnedToSender" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_depositCount = new DataColumn("depositCount" , typeof(int));
			DataColumn col_paneltyAmount = new DataColumn("paneltyAmount" , typeof(decimal));
			DataColumn col_setteledAmount = new DataColumn("setteledAmount" , typeof(decimal));
			DataColumn col_depositedCashAmount = new DataColumn("depositedCashAmount" , typeof(decimal));
			DataColumn col_dateDeposited = new DataColumn("dateDeposited" , typeof(DateTime));
			DataColumn col_dateReconcilied = new DataColumn("dateReconcilied" , typeof(DateTime));
			DataColumn col_dateReIssued = new DataColumn("dateReIssued" , typeof(DateTime));
			DataColumn col_dateReturnedToSender = new DataColumn("dateReturnedToSender" , typeof(DateTime));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_posReturnTransaction_Index = new DataColumn("posReturnTransaction_Index" , typeof(int));
			DataColumn col_advanceReceived_Index = new DataColumn("advanceReceived_Index" , typeof(int));
			DataColumn col_recSerialNo = new DataColumn("recSerialNo" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_chequeRegister_ID,col_remark,col_dateRegister,col_paymentMethod_ID,col_transferType,col_transferRefNo,col_giftVoucherID,col_merchant_DeviceID,col_lastFourDigits,col_cardOwnerName,col_cardType,col_cardCategory,col_dateCheque,col_customer_ID,col_accountNumber,col_depositedAccountNumber,col_companyAccount_ID,col_bank_ID,col_depositedBank_ID,col_branch_ID,col_depositedBranch_ID,col_chequeStatus_ID,col_chequeType_ID,col_invoice_ID,col_posTransaction_ID,col_receipt_ID,col_posReceipt_ID,col_accountReceipt_ID,col_orderRefNo_ID,col_chequeNumber,col_glPosting_ID,col_postingStatus_ID,col_postingStatus_ID2,col_financialYear_ID,col_amount,col_isSetteled,col_isSetteledReturned,col_isDepositted,col_isReIssued,col_isReconcilied,col_isReturned,col_isReturnedToSender,col_createUser_ID,col_modifiedUser_ID,col_dateCreate,col_dateModified,col_isDeleted,col_isLocked,col_depositCount,col_paneltyAmount,col_setteledAmount,col_depositedCashAmount,col_dateDeposited,col_dateReconcilied,col_dateReIssued,col_dateReturnedToSender,col_companyID,col_companyBranch_ID,col_posReturnTransaction_Index,col_advanceReceived_Index,col_recSerialNo,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsChequeRegister datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsChequeRegister object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsChequeRegister user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["remark"] = user.remark;
			drow["dateRegister"] = user.dateRegister;
			drow["paymentMethod_ID"] = user.paymentMethod_ID;
			drow["transferType"] = user.transferType;
			drow["transferRefNo"] = user.transferRefNo;
			drow["giftVoucherID"] = user.giftVoucherID;
			drow["merchant_DeviceID"] = user.merchant_DeviceID;
			drow["lastFourDigits"] = user.lastFourDigits;
			drow["cardOwnerName"] = user.cardOwnerName;
			drow["cardType"] = user.cardType;
			drow["cardCategory"] = user.cardCategory;
			drow["dateCheque"] = user.dateCheque;
			drow["customer_ID"] = user.customer_ID;
			drow["accountNumber"] = user.accountNumber;
			drow["depositedAccountNumber"] = user.depositedAccountNumber;
			drow["companyAccount_ID"] = user.companyAccount_ID;
			drow["bank_ID"] = user.bank_ID;
			drow["depositedBank_ID"] = user.depositedBank_ID;
			drow["branch_ID"] = user.branch_ID;
			drow["depositedBranch_ID"] = user.depositedBranch_ID;
			drow["chequeStatus_ID"] = user.chequeStatus_ID;
			drow["chequeType_ID"] = user.chequeType_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["posTransaction_ID"] = user.posTransaction_ID;
			drow["receipt_ID"] = user.receipt_ID;
			drow["posReceipt_ID"] = user.posReceipt_ID;
			drow["accountReceipt_ID"] = user.accountReceipt_ID;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["chequeNumber"] = user.chequeNumber;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["postingStatus_ID2"] = user.postingStatus_ID2;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["amount"] = user.amount;
			drow["isSetteled"] = user.isSetteled;
			drow["isSetteledReturned"] = user.isSetteledReturned;
			drow["isDepositted"] = user.isDepositted;
			drow["isReIssued"] = user.isReIssued;
			drow["isReconcilied"] = user.isReconcilied;
			drow["isReturned"] = user.isReturned;
			drow["isReturnedToSender"] = user.isReturnedToSender;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["depositCount"] = user.depositCount;
			drow["paneltyAmount"] = user.paneltyAmount;
			drow["setteledAmount"] = user.setteledAmount;
			drow["depositedCashAmount"] = user.depositedCashAmount;
			drow["dateDeposited"] = user.dateDeposited;
			drow["dateReconcilied"] = user.dateReconcilied;
			drow["dateReIssued"] = user.dateReIssued;
			drow["dateReturnedToSender"] = user.dateReturnedToSender;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["posReturnTransaction_Index"] = user.posReturnTransaction_Index;
			drow["advanceReceived_Index"] = user.advanceReceived_Index;
			drow["recSerialNo"] = user.recSerialNo;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
