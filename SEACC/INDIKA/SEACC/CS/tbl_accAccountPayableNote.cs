using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accAccountPayableNote {
		#region Fields
		private string accountPayableNote_ID;
		private DateTime accountPayableNoteDate;
		private string narration;
		private string billNo;
		private DateTime billDate;
		private string noDeliveryOrder;
		private string noAWB;
		private string noLC;
		private string apnType_ID;
		private string externalGoodReceivedNote_ID;
		private string purchaseOrder_ID;
		private string customer_ID;
		private string supplier_ID;
		private string employee_ID;
		private string bankAcc_No;
		private string stockNoteType_ID;
		private string costCenter1_ID;
		private string costCenter2_ID;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string financialYear_ID;
		private string currency_ID;
		private decimal currencyRate;
		private decimal creditDays;
		private decimal discountPercentage;
		private decimal nbtPercentage;
		private decimal vatPercentage;
		private decimal otherTaxPercentage;
		private decimal subTotal;
		private decimal discountTotal;
		private decimal nbtTotal;
		private decimal vatTotal;
		private decimal otherTaxTotal;
		private decimal grandTotal;
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
		private bool isAdvancePayment;
		private bool isPartPayment;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isPettyCashReimbursment;
		private bool isSAPN;
		private decimal settledAmount;
		private bool isSeattled;
		private string chequeRegister_ID;
		private bool isReturnCheque;
		private int printCount;
		private string companyID;
		private string companyBranch_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accAccountPayableNote class.
		/// </summary>
		public tbl_accAccountPayableNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accAccountPayableNote class.
		/// </summary>
		public tbl_accAccountPayableNote(string accountPayableNote_ID, DateTime accountPayableNoteDate, string narration, string billNo, DateTime billDate, string noDeliveryOrder, string noAWB, string noLC, string apnType_ID, string externalGoodReceivedNote_ID, string purchaseOrder_ID, string customer_ID, string supplier_ID, string employee_ID, string bankAcc_No, string stockNoteType_ID, string costCenter1_ID, string costCenter2_ID, string glPosting_ID, string postingStatus_ID, string financialYear_ID, string currency_ID, decimal currencyRate, decimal creditDays, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isAdvancePayment, bool isPartPayment, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isPettyCashReimbursment, bool isSAPN, decimal settledAmount, bool isSeattled, string chequeRegister_ID, bool isReturnCheque, int printCount, string companyID, string companyBranch_ID) {
			this.accountPayableNote_ID = accountPayableNote_ID;
			this.accountPayableNoteDate = accountPayableNoteDate;
			this.narration = narration;
			this.billNo = billNo;
			this.billDate = billDate;
			this.noDeliveryOrder = noDeliveryOrder;
			this.noAWB = noAWB;
			this.noLC = noLC;
			this.apnType_ID = apnType_ID;
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.purchaseOrder_ID = purchaseOrder_ID;
			this.customer_ID = customer_ID;
			this.supplier_ID = supplier_ID;
			this.employee_ID = employee_ID;
			this.bankAcc_No = bankAcc_No;
			this.stockNoteType_ID = stockNoteType_ID;
			this.costCenter1_ID = costCenter1_ID;
			this.costCenter2_ID = costCenter2_ID;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.financialYear_ID = financialYear_ID;
			this.currency_ID = currency_ID;
			this.currencyRate = currencyRate;
			this.creditDays = creditDays;
			this.discountPercentage = discountPercentage;
			this.nbtPercentage = nbtPercentage;
			this.vatPercentage = vatPercentage;
			this.otherTaxPercentage = otherTaxPercentage;
			this.subTotal = subTotal;
			this.discountTotal = discountTotal;
			this.nbtTotal = nbtTotal;
			this.vatTotal = vatTotal;
			this.otherTaxTotal = otherTaxTotal;
			this.grandTotal = grandTotal;
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
			this.isAdvancePayment = isAdvancePayment;
			this.isPartPayment = isPartPayment;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isPettyCashReimbursment = isPettyCashReimbursment;
			this.isSAPN = isSAPN;
			this.settledAmount = settledAmount;
			this.isSeattled = isSeattled;
			this.chequeRegister_ID = chequeRegister_ID;
			this.isReturnCheque = isReturnCheque;
			this.printCount = printCount;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AccountPayableNote_ID value.
		/// </summary>
		public string AccountPayableNote_ID {
			get { return accountPayableNote_ID; }
			set { accountPayableNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountPayableNoteDate value.
		/// </summary>
		public DateTime AccountPayableNoteDate {
			get { return accountPayableNoteDate; }
			set { accountPayableNoteDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Narration value.
		/// </summary>
		public string Narration {
			get { return narration; }
			set { narration = value; }
		}
		
		/// <summary>
		/// Gets or sets the BillNo value.
		/// </summary>
		public string BillNo {
			get { return billNo; }
			set { billNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the BillDate value.
		/// </summary>
		public DateTime BillDate {
			get { return billDate; }
			set { billDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoDeliveryOrder value.
		/// </summary>
		public string NoDeliveryOrder {
			get { return noDeliveryOrder; }
			set { noDeliveryOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoAWB value.
		/// </summary>
		public string NoAWB {
			get { return noAWB; }
			set { noAWB = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoLC value.
		/// </summary>
		public string NoLC {
			get { return noLC; }
			set { noLC = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApnType_ID value.
		/// </summary>
		public string ApnType_ID {
			get { return apnType_ID; }
			set { apnType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNote_ID value.
		/// </summary>
		public string ExternalGoodReceivedNote_ID {
			get { return externalGoodReceivedNote_ID; }
			set { externalGoodReceivedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseOrder_ID value.
		/// </summary>
		public string PurchaseOrder_ID {
			get { return purchaseOrder_ID; }
			set { purchaseOrder_ID = value; }
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
		/// Gets or sets the BankAcc_No value.
		/// </summary>
		public string BankAcc_No {
			get { return bankAcc_No; }
			set { bankAcc_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the StockNoteType_ID value.
		/// </summary>
		public string StockNoteType_ID {
			get { return stockNoteType_ID; }
			set { stockNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenter1_ID value.
		/// </summary>
		public string CostCenter1_ID {
			get { return costCenter1_ID; }
			set { costCenter1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenter2_ID value.
		/// </summary>
		public string CostCenter2_ID {
			get { return costCenter2_ID; }
			set { costCenter2_ID = value; }
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
		/// Gets or sets the CreditDays value.
		/// </summary>
		public decimal CreditDays {
			get { return creditDays; }
			set { creditDays = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPercentage value.
		/// </summary>
		public decimal DiscountPercentage {
			get { return discountPercentage; }
			set { discountPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the NbtPercentage value.
		/// </summary>
		public decimal NbtPercentage {
			get { return nbtPercentage; }
			set { nbtPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatPercentage value.
		/// </summary>
		public decimal VatPercentage {
			get { return vatPercentage; }
			set { vatPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the OtherTaxPercentage value.
		/// </summary>
		public decimal OtherTaxPercentage {
			get { return otherTaxPercentage; }
			set { otherTaxPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubTotal value.
		/// </summary>
		public decimal SubTotal {
			get { return subTotal; }
			set { subTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountTotal value.
		/// </summary>
		public decimal DiscountTotal {
			get { return discountTotal; }
			set { discountTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the NbtTotal value.
		/// </summary>
		public decimal NbtTotal {
			get { return nbtTotal; }
			set { nbtTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatTotal value.
		/// </summary>
		public decimal VatTotal {
			get { return vatTotal; }
			set { vatTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the OtherTaxTotal value.
		/// </summary>
		public decimal OtherTaxTotal {
			get { return otherTaxTotal; }
			set { otherTaxTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrandTotal value.
		/// </summary>
		public decimal GrandTotal {
			get { return grandTotal; }
			set { grandTotal = value; }
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
		/// Gets or sets the IsAdvancePayment value.
		/// </summary>
		public bool IsAdvancePayment {
			get { return isAdvancePayment; }
			set { isAdvancePayment = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPartPayment value.
		/// </summary>
		public bool IsPartPayment {
			get { return isPartPayment; }
			set { isPartPayment = value; }
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
		/// Gets or sets the IsPettyCashReimbursment value.
		/// </summary>
		public bool IsPettyCashReimbursment {
			get { return isPettyCashReimbursment; }
			set { isPettyCashReimbursment = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSAPN value.
		/// </summary>
		public bool IsSAPN {
			get { return isSAPN; }
			set { isSAPN = value; }
		}
		
		/// <summary>
		/// Gets or sets the SettledAmount value.
		/// </summary>
		public decimal SettledAmount {
			get { return settledAmount; }
			set { settledAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSeattled value.
		/// </summary>
		public bool IsSeattled {
			get { return isSeattled; }
			set { isSeattled = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReturnCheque value.
		/// </summary>
		public bool IsReturnCheque {
			get { return isReturnCheque; }
			set { isReturnCheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
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
		/// Saves a record to the tbl_accAccountPayableNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountPayableNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@narration", SqlDbType.VarChar,200);
			scom.Parameters.Add("@billNo", SqlDbType.VarChar,100);
			scom.Parameters.Add("@billDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@noDeliveryOrder", SqlDbType.VarChar,50);
			scom.Parameters.Add("@noAWB", SqlDbType.VarChar,50);
			scom.Parameters.Add("@noLC", SqlDbType.VarChar,50);
			scom.Parameters.Add("@apnType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bankAcc_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditDays", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@isAdvancePayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPartPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPettyCashReimbursment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSAPN", SqlDbType.Bit,1);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isReturnCheque", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@accountPayableNoteDate"].Value = accountPayableNoteDate;
			scom.Parameters["@narration"].Value = narration;
			scom.Parameters["@billNo"].Value = billNo;
			scom.Parameters["@billDate"].Value = billDate;
			scom.Parameters["@noDeliveryOrder"].Value = noDeliveryOrder;
			scom.Parameters["@noAWB"].Value = noAWB;
			scom.Parameters["@noLC"].Value = noLC;
			scom.Parameters["@apnType_ID"].Value = apnType_ID;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@bankAcc_No"].Value = bankAcc_No;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@creditDays"].Value = creditDays;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
			scom.Parameters["@vatPercentage"].Value = vatPercentage;
			scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@nbtTotal"].Value = nbtTotal;
			scom.Parameters["@vatTotal"].Value = vatTotal;
			scom.Parameters["@otherTaxTotal"].Value = otherTaxTotal;
			scom.Parameters["@grandTotal"].Value = grandTotal;
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
			scom.Parameters["@isAdvancePayment"].Value = isAdvancePayment;
			scom.Parameters["@isPartPayment"].Value = isPartPayment;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isPettyCashReimbursment"].Value = isPettyCashReimbursment;
			scom.Parameters["@isSAPN"].Value = isSAPN;
			scom.Parameters["@settledAmount"].Value = settledAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@isReturnCheque"].Value = isReturnCheque;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accAccountPayableNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountPayableNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@narration", SqlDbType.VarChar,200);
			scom.Parameters.Add("@billNo", SqlDbType.VarChar,100);
			scom.Parameters.Add("@billDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@noDeliveryOrder", SqlDbType.VarChar,50);
			scom.Parameters.Add("@noAWB", SqlDbType.VarChar,50);
			scom.Parameters.Add("@noLC", SqlDbType.VarChar,50);
			scom.Parameters.Add("@apnType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bankAcc_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditDays", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@isAdvancePayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPartPayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPettyCashReimbursment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSAPN", SqlDbType.Bit,1);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isReturnCheque", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@accountPayableNoteDate"].Value = accountPayableNoteDate;
			scom.Parameters["@narration"].Value = narration;
			scom.Parameters["@billNo"].Value = billNo;
			scom.Parameters["@billDate"].Value = billDate;
			scom.Parameters["@noDeliveryOrder"].Value = noDeliveryOrder;
			scom.Parameters["@noAWB"].Value = noAWB;
			scom.Parameters["@noLC"].Value = noLC;
			scom.Parameters["@apnType_ID"].Value = apnType_ID;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@bankAcc_No"].Value = bankAcc_No;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@creditDays"].Value = creditDays;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
			scom.Parameters["@vatPercentage"].Value = vatPercentage;
			scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@nbtTotal"].Value = nbtTotal;
			scom.Parameters["@vatTotal"].Value = vatTotal;
			scom.Parameters["@otherTaxTotal"].Value = otherTaxTotal;
			scom.Parameters["@grandTotal"].Value = grandTotal;
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
			scom.Parameters["@isAdvancePayment"].Value = isAdvancePayment;
			scom.Parameters["@isPartPayment"].Value = isPartPayment;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isPettyCashReimbursment"].Value = isPettyCashReimbursment;
			scom.Parameters["@isSAPN"].Value = isSAPN;
			scom.Parameters["@settledAmount"].Value = settledAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@isReturnCheque"].Value = isReturnCheque;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accAccountPayableNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCostCenter1_ID(string costCenter1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteDeleteAllByCostCenter1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCostCenter2_ID(string costCenter2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteDeleteAllByCostCenter2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByExternalGoodReceivedNote_ID(string externalGoodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteDeleteAllByExternalGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByPurchaseOrder_ID(string purchaseOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteDeleteAllByPurchaseOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accAccountPayableNote table.
		/// </summary>
		public static tbl_accAccountPayableNote Select(string accountPayableNote_ID_Incoming){

			tbl_accAccountPayableNote tbl_accAccountPayableNoteins = new tbl_accAccountPayableNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accAccountPayableNoteins = Maketbl_accAccountPayableNote(dataReader);
				} else {
					tbl_accAccountPayableNoteins = null;
				}
			}
			scon.Close();
			return tbl_accAccountPayableNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table.
		/// </summary>
		public static List<tbl_accAccountPayableNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accAccountPayableNote> tbl_accAccountPayableNoteList = new List<tbl_accAccountPayableNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote tbl_accAccountPayableNote = Maketbl_accAccountPayableNote(dataReader);
					tbl_accAccountPayableNoteList.Add(tbl_accAccountPayableNote);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static List<tbl_accAccountPayableNote> SelectAllByCostCenter1_ID(string costCenter1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteSelectAllByCostCenter1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
				List<tbl_accAccountPayableNote> tbl_accAccountPayableNoteList = new List<tbl_accAccountPayableNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote tbl_accAccountPayableNote = Maketbl_accAccountPayableNote(dataReader);
					tbl_accAccountPayableNoteList.Add(tbl_accAccountPayableNote);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static List<tbl_accAccountPayableNote> SelectAllByCostCenter2_ID(string costCenter2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteSelectAllByCostCenter2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
				List<tbl_accAccountPayableNote> tbl_accAccountPayableNoteList = new List<tbl_accAccountPayableNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote tbl_accAccountPayableNote = Maketbl_accAccountPayableNote(dataReader);
					tbl_accAccountPayableNoteList.Add(tbl_accAccountPayableNote);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static List<tbl_accAccountPayableNote> SelectAllByExternalGoodReceivedNote_ID(string externalGoodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteSelectAllByExternalGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
				List<tbl_accAccountPayableNote> tbl_accAccountPayableNoteList = new List<tbl_accAccountPayableNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote tbl_accAccountPayableNote = Maketbl_accAccountPayableNote(dataReader);
					tbl_accAccountPayableNoteList.Add(tbl_accAccountPayableNote);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static List<tbl_accAccountPayableNote> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_accAccountPayableNote> tbl_accAccountPayableNoteList = new List<tbl_accAccountPayableNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote tbl_accAccountPayableNote = Maketbl_accAccountPayableNote(dataReader);
					tbl_accAccountPayableNoteList.Add(tbl_accAccountPayableNote);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static List<tbl_accAccountPayableNote> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_accAccountPayableNote> tbl_accAccountPayableNoteList = new List<tbl_accAccountPayableNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote tbl_accAccountPayableNote = Maketbl_accAccountPayableNote(dataReader);
					tbl_accAccountPayableNoteList.Add(tbl_accAccountPayableNote);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static List<tbl_accAccountPayableNote> SelectAllByPurchaseOrder_ID(string purchaseOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteSelectAllByPurchaseOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
				List<tbl_accAccountPayableNote> tbl_accAccountPayableNoteList = new List<tbl_accAccountPayableNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote tbl_accAccountPayableNote = Maketbl_accAccountPayableNote(dataReader);
					tbl_accAccountPayableNoteList.Add(tbl_accAccountPayableNote);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountPayableNote table by a foreign key.
		/// </summary>
		public static List<tbl_accAccountPayableNote> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountPayableNoteSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_accAccountPayableNote> tbl_accAccountPayableNoteList = new List<tbl_accAccountPayableNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountPayableNote tbl_accAccountPayableNote = Maketbl_accAccountPayableNote(dataReader);
					tbl_accAccountPayableNoteList.Add(tbl_accAccountPayableNote);
				}
			}
			scon.Close();
			return tbl_accAccountPayableNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accAccountPayableNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accAccountPayableNote Maketbl_accAccountPayableNote(SqlDataReader dataReader) {
			tbl_accAccountPayableNote tbl_accAccountPayableNote = new tbl_accAccountPayableNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accAccountPayableNote.AccountPayableNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accAccountPayableNote.AccountPayableNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accAccountPayableNote.Narration = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accAccountPayableNote.BillNo = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accAccountPayableNote.BillDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accAccountPayableNote.NoDeliveryOrder = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accAccountPayableNote.NoAWB = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accAccountPayableNote.NoLC = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accAccountPayableNote.ApnType_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accAccountPayableNote.ExternalGoodReceivedNote_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accAccountPayableNote.PurchaseOrder_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accAccountPayableNote.Customer_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accAccountPayableNote.Supplier_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_accAccountPayableNote.Employee_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_accAccountPayableNote.BankAcc_No = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_accAccountPayableNote.StockNoteType_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_accAccountPayableNote.CostCenter1_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_accAccountPayableNote.CostCenter2_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_accAccountPayableNote.GlPosting_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_accAccountPayableNote.PostingStatus_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_accAccountPayableNote.FinancialYear_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_accAccountPayableNote.Currency_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_accAccountPayableNote.CurrencyRate = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_accAccountPayableNote.CreditDays = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_accAccountPayableNote.DiscountPercentage = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_accAccountPayableNote.NbtPercentage = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_accAccountPayableNote.VatPercentage = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_accAccountPayableNote.OtherTaxPercentage = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_accAccountPayableNote.SubTotal = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_accAccountPayableNote.DiscountTotal = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_accAccountPayableNote.NbtTotal = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_accAccountPayableNote.VatTotal = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_accAccountPayableNote.OtherTaxTotal = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_accAccountPayableNote.GrandTotal = dataReader.GetDecimal(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_accAccountPayableNote.CreateUser_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_accAccountPayableNote.ModifiedUser_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_accAccountPayableNote.CheckedUser_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_accAccountPayableNote.ApprovedUser_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_accAccountPayableNote.DeletedUser_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_accAccountPayableNote.PrintedUser_ID = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_accAccountPayableNote.CreateTerminal_ID = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_accAccountPayableNote.ModifiedTerminal_ID = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_accAccountPayableNote.DeletedTerminal_ID = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_accAccountPayableNote.PrintedTerminal_ID = dataReader.GetString(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_accAccountPayableNote.DateCreate = dataReader.GetDateTime(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_accAccountPayableNote.DateModified = dataReader.GetDateTime(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_accAccountPayableNote.DateChecked = dataReader.GetDateTime(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_accAccountPayableNote.DateApproved = dataReader.GetDateTime(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_accAccountPayableNote.DateDeleted = dataReader.GetDateTime(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_accAccountPayableNote.DatePrinted = dataReader.GetDateTime(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_accAccountPayableNote.IsAdvancePayment = dataReader.GetBoolean(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_accAccountPayableNote.IsPartPayment = dataReader.GetBoolean(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_accAccountPayableNote.IsChecked = dataReader.GetBoolean(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_accAccountPayableNote.IsApproved = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_accAccountPayableNote.IsFinished = dataReader.GetBoolean(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_accAccountPayableNote.IsDeleted = dataReader.GetBoolean(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_accAccountPayableNote.IsLocked = dataReader.GetBoolean(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_accAccountPayableNote.IsPettyCashReimbursment = dataReader.GetBoolean(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_accAccountPayableNote.IsSAPN = dataReader.GetBoolean(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_accAccountPayableNote.SettledAmount = dataReader.GetDecimal(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_accAccountPayableNote.IsSeattled = dataReader.GetBoolean(60);
			}
			if (dataReader.IsDBNull(61) == false) {
				tbl_accAccountPayableNote.ChequeRegister_ID = dataReader.GetString(61);
			}
			if (dataReader.IsDBNull(62) == false) {
				tbl_accAccountPayableNote.IsReturnCheque = dataReader.GetBoolean(62);
			}
			if (dataReader.IsDBNull(63) == false) {
				tbl_accAccountPayableNote.PrintCount = dataReader.GetInt32(63);
			}
			if (dataReader.IsDBNull(64) == false) {
				tbl_accAccountPayableNote.CompanyID = dataReader.GetString(64);
			}
			if (dataReader.IsDBNull(65) == false) {
				tbl_accAccountPayableNote.CompanyBranch_ID = dataReader.GetString(65);
			}

			return tbl_accAccountPayableNote;
		}
		/// <summary>
		/// This makes tbl_accAccountPayableNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accAccountPayableNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accAccountPayableNote  tbl_accAccountPayableNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_accountPayableNote_ID = new DataColumn("accountPayableNote_ID" , typeof(string));
			DataColumn col_accountPayableNoteDate = new DataColumn("accountPayableNoteDate" , typeof(DateTime));
			DataColumn col_narration = new DataColumn("narration" , typeof(string));
			DataColumn col_billNo = new DataColumn("billNo" , typeof(string));
			DataColumn col_billDate = new DataColumn("billDate" , typeof(DateTime));
			DataColumn col_noDeliveryOrder = new DataColumn("noDeliveryOrder" , typeof(string));
			DataColumn col_noAWB = new DataColumn("noAWB" , typeof(string));
			DataColumn col_noLC = new DataColumn("noLC" , typeof(string));
			DataColumn col_apnType_ID = new DataColumn("apnType_ID" , typeof(string));
			DataColumn col_externalGoodReceivedNote_ID = new DataColumn("externalGoodReceivedNote_ID" , typeof(string));
			DataColumn col_purchaseOrder_ID = new DataColumn("purchaseOrder_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_bankAcc_No = new DataColumn("bankAcc_No" , typeof(string));
			DataColumn col_stockNoteType_ID = new DataColumn("stockNoteType_ID" , typeof(string));
			DataColumn col_costCenter1_ID = new DataColumn("costCenter1_ID" , typeof(string));
			DataColumn col_costCenter2_ID = new DataColumn("costCenter2_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_creditDays = new DataColumn("creditDays" , typeof(decimal));
			DataColumn col_discountPercentage = new DataColumn("discountPercentage" , typeof(decimal));
			DataColumn col_nbtPercentage = new DataColumn("nbtPercentage" , typeof(decimal));
			DataColumn col_vatPercentage = new DataColumn("vatPercentage" , typeof(decimal));
			DataColumn col_otherTaxPercentage = new DataColumn("otherTaxPercentage" , typeof(decimal));
			DataColumn col_subTotal = new DataColumn("subTotal" , typeof(decimal));
			DataColumn col_discountTotal = new DataColumn("discountTotal" , typeof(decimal));
			DataColumn col_nbtTotal = new DataColumn("nbtTotal" , typeof(decimal));
			DataColumn col_vatTotal = new DataColumn("vatTotal" , typeof(decimal));
			DataColumn col_otherTaxTotal = new DataColumn("otherTaxTotal" , typeof(decimal));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
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
			DataColumn col_isAdvancePayment = new DataColumn("isAdvancePayment" , typeof(bool));
			DataColumn col_isPartPayment = new DataColumn("isPartPayment" , typeof(bool));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isPettyCashReimbursment = new DataColumn("isPettyCashReimbursment" , typeof(bool));
			DataColumn col_isSAPN = new DataColumn("isSAPN" , typeof(bool));
			DataColumn col_settledAmount = new DataColumn("settledAmount" , typeof(decimal));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_isReturnCheque = new DataColumn("isReturnCheque" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_accountPayableNote_ID,col_accountPayableNoteDate,col_narration,col_billNo,col_billDate,col_noDeliveryOrder,col_noAWB,col_noLC,col_apnType_ID,col_externalGoodReceivedNote_ID,col_purchaseOrder_ID,col_customer_ID,col_supplier_ID,col_employee_ID,col_bankAcc_No,col_stockNoteType_ID,col_costCenter1_ID,col_costCenter2_ID,col_glPosting_ID,col_postingStatus_ID,col_financialYear_ID,col_currency_ID,col_currencyRate,col_creditDays,col_discountPercentage,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grandTotal,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isAdvancePayment,col_isPartPayment,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isPettyCashReimbursment,col_isSAPN,col_settledAmount,col_isSeattled,col_chequeRegister_ID,col_isReturnCheque,col_printCount,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accAccountPayableNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accAccountPayableNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accAccountPayableNote user) {
		DataRow drow = dt.NewRow();
		
			drow["accountPayableNote_ID"] = user.accountPayableNote_ID;
			drow["accountPayableNoteDate"] = user.accountPayableNoteDate;
			drow["narration"] = user.narration;
			drow["billNo"] = user.billNo;
			drow["billDate"] = user.billDate;
			drow["noDeliveryOrder"] = user.noDeliveryOrder;
			drow["noAWB"] = user.noAWB;
			drow["noLC"] = user.noLC;
			drow["apnType_ID"] = user.apnType_ID;
			drow["externalGoodReceivedNote_ID"] = user.externalGoodReceivedNote_ID;
			drow["purchaseOrder_ID"] = user.purchaseOrder_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["bankAcc_No"] = user.bankAcc_No;
			drow["stockNoteType_ID"] = user.stockNoteType_ID;
			drow["costCenter1_ID"] = user.costCenter1_ID;
			drow["costCenter2_ID"] = user.costCenter2_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["creditDays"] = user.creditDays;
			drow["discountPercentage"] = user.discountPercentage;
			drow["nbtPercentage"] = user.nbtPercentage;
			drow["vatPercentage"] = user.vatPercentage;
			drow["otherTaxPercentage"] = user.otherTaxPercentage;
			drow["subTotal"] = user.subTotal;
			drow["discountTotal"] = user.discountTotal;
			drow["nbtTotal"] = user.nbtTotal;
			drow["vatTotal"] = user.vatTotal;
			drow["otherTaxTotal"] = user.otherTaxTotal;
			drow["grandTotal"] = user.grandTotal;
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
			drow["isAdvancePayment"] = user.isAdvancePayment;
			drow["isPartPayment"] = user.isPartPayment;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isPettyCashReimbursment"] = user.isPettyCashReimbursment;
			drow["isSAPN"] = user.isSAPN;
			drow["settledAmount"] = user.settledAmount;
			drow["isSeattled"] = user.isSeattled;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["isReturnCheque"] = user.isReturnCheque;
			drow["printCount"] = user.printCount;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
