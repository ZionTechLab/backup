using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accDebitNote {
		#region Fields
		private string debitNote_ID;
		private DateTime debitNote_Date;
		private string remarks;
		private string purchaseReturnedNote_ID;
		private string accountPayableNote_ID;
		private string paymentVoucher_ID;
		private string invoice_ID;
		private string creditNote_ID;
		private string supplier_ID;
		private string currency_ID;
		private decimal currencyRate;
		private decimal grandTotal;
		private decimal otherTaxTotal;
		private decimal vatTotal;
		private decimal nbtTotal;
		private decimal discountTotal;
		private decimal subTotal;
		private decimal otherTaxPercentage;
		private decimal vatPercentage;
		private decimal nbtPercentage;
		private decimal discountPercentage;
		private string companyID;
		private string companyBranch_ID;
		private string financialYear_ID;
		private string postingStatus_ID;
		private string glPosting_ID;
		private string costCenter1_ID;
		private string costCenter2_ID;
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
		private bool isReturnedGoods;
		private bool isSalesNote;
		private bool isAPNAdjustment;
		private decimal settledAmount;
		private bool isSettled;
		private bool isLocked;
		private int printCount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accDebitNote class.
		/// </summary>
		public tbl_accDebitNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accDebitNote class.
		/// </summary>
		public tbl_accDebitNote(string debitNote_ID, DateTime debitNote_Date, string remarks, string purchaseReturnedNote_ID, string accountPayableNote_ID, string paymentVoucher_ID, string invoice_ID, string creditNote_ID, string supplier_ID, string currency_ID, decimal currencyRate, decimal grandTotal, decimal otherTaxTotal, decimal vatTotal, decimal nbtTotal, decimal discountTotal, decimal subTotal, decimal otherTaxPercentage, decimal vatPercentage, decimal nbtPercentage, decimal discountPercentage, string companyID, string companyBranch_ID, string financialYear_ID, string postingStatus_ID, string glPosting_ID, string costCenter1_ID, string costCenter2_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isReturnedGoods, bool isSalesNote, bool isAPNAdjustment, decimal settledAmount, bool isSettled, bool isLocked, int printCount) {
			this.debitNote_ID = debitNote_ID;
			this.debitNote_Date = debitNote_Date;
			this.remarks = remarks;
			this.purchaseReturnedNote_ID = purchaseReturnedNote_ID;
			this.accountPayableNote_ID = accountPayableNote_ID;
			this.paymentVoucher_ID = paymentVoucher_ID;
			this.invoice_ID = invoice_ID;
			this.creditNote_ID = creditNote_ID;
			this.supplier_ID = supplier_ID;
			this.currency_ID = currency_ID;
			this.currencyRate = currencyRate;
			this.grandTotal = grandTotal;
			this.otherTaxTotal = otherTaxTotal;
			this.vatTotal = vatTotal;
			this.nbtTotal = nbtTotal;
			this.discountTotal = discountTotal;
			this.subTotal = subTotal;
			this.otherTaxPercentage = otherTaxPercentage;
			this.vatPercentage = vatPercentage;
			this.nbtPercentage = nbtPercentage;
			this.discountPercentage = discountPercentage;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.financialYear_ID = financialYear_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.glPosting_ID = glPosting_ID;
			this.costCenter1_ID = costCenter1_ID;
			this.costCenter2_ID = costCenter2_ID;
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
			this.isReturnedGoods = isReturnedGoods;
			this.isSalesNote = isSalesNote;
			this.isAPNAdjustment = isAPNAdjustment;
			this.settledAmount = settledAmount;
			this.isSettled = isSettled;
			this.isLocked = isLocked;
			this.printCount = printCount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the DebitNote_ID value.
		/// </summary>
		public string DebitNote_ID {
			get { return debitNote_ID; }
			set { debitNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DebitNote_Date value.
		/// </summary>
		public DateTime DebitNote_Date {
			get { return debitNote_Date; }
			set { debitNote_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseReturnedNote_ID value.
		/// </summary>
		public string PurchaseReturnedNote_ID {
			get { return purchaseReturnedNote_ID; }
			set { purchaseReturnedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountPayableNote_ID value.
		/// </summary>
		public string AccountPayableNote_ID {
			get { return accountPayableNote_ID; }
			set { accountPayableNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentVoucher_ID value.
		/// </summary>
		public string PaymentVoucher_ID {
			get { return paymentVoucher_ID; }
			set { paymentVoucher_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditNote_ID value.
		/// </summary>
		public string CreditNote_ID {
			get { return creditNote_ID; }
			set { creditNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
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
		/// Gets or sets the GrandTotal value.
		/// </summary>
		public decimal GrandTotal {
			get { return grandTotal; }
			set { grandTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the OtherTaxTotal value.
		/// </summary>
		public decimal OtherTaxTotal {
			get { return otherTaxTotal; }
			set { otherTaxTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatTotal value.
		/// </summary>
		public decimal VatTotal {
			get { return vatTotal; }
			set { vatTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the NbtTotal value.
		/// </summary>
		public decimal NbtTotal {
			get { return nbtTotal; }
			set { nbtTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountTotal value.
		/// </summary>
		public decimal DiscountTotal {
			get { return discountTotal; }
			set { discountTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubTotal value.
		/// </summary>
		public decimal SubTotal {
			get { return subTotal; }
			set { subTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the OtherTaxPercentage value.
		/// </summary>
		public decimal OtherTaxPercentage {
			get { return otherTaxPercentage; }
			set { otherTaxPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatPercentage value.
		/// </summary>
		public decimal VatPercentage {
			get { return vatPercentage; }
			set { vatPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the NbtPercentage value.
		/// </summary>
		public decimal NbtPercentage {
			get { return nbtPercentage; }
			set { nbtPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPercentage value.
		/// </summary>
		public decimal DiscountPercentage {
			get { return discountPercentage; }
			set { discountPercentage = value; }
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
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PostingStatus_ID value.
		/// </summary>
		public string PostingStatus_ID {
			get { return postingStatus_ID; }
			set { postingStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlPosting_ID value.
		/// </summary>
		public string GlPosting_ID {
			get { return glPosting_ID; }
			set { glPosting_ID = value; }
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
		/// Gets or sets the IsReturnedGoods value.
		/// </summary>
		public bool IsReturnedGoods {
			get { return isReturnedGoods; }
			set { isReturnedGoods = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSalesNote value.
		/// </summary>
		public bool IsSalesNote {
			get { return isSalesNote; }
			set { isSalesNote = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAPNAdjustment value.
		/// </summary>
		public bool IsAPNAdjustment {
			get { return isAPNAdjustment; }
			set { isAPNAdjustment = value; }
		}
		
		/// <summary>
		/// Gets or sets the SettledAmount value.
		/// </summary>
		public decimal SettledAmount {
			get { return settledAmount; }
			set { settledAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSettled value.
		/// </summary>
		public bool IsSettled {
			get { return isSettled; }
			set { isSettled = value; }
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
		/// Gets or sets the Gl_ID value.
		/// </summary>
		
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accDebitNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNote_Date", SqlDbType.DateTime,8);
            scom.Parameters.Add("@remarks", SqlDbType.VarChar, 100);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
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
			scom.Parameters.Add("@isReturnedGoods", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesNote", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAPNAdjustment", SqlDbType.Bit,1);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@debitNote_Date"].Value = debitNote_Date;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@otherTaxTotal"].Value = otherTaxTotal;
			scom.Parameters["@vatTotal"].Value = vatTotal;
			scom.Parameters["@nbtTotal"].Value = nbtTotal;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
			scom.Parameters["@vatPercentage"].Value = vatPercentage;
			scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
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
			scom.Parameters["@isReturnedGoods"].Value = isReturnedGoods;
			scom.Parameters["@isSalesNote"].Value = isSalesNote;
			scom.Parameters["@isAPNAdjustment"].Value = isAPNAdjustment;
			scom.Parameters["@settledAmount"].Value = settledAmount;
			scom.Parameters["@isSettled"].Value = isSettled;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@printCount"].Value = printCount; 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accDebitNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNote_Date", SqlDbType.DateTime,8);
            scom.Parameters.Add("@remarks", SqlDbType.VarChar, 100);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
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
			scom.Parameters.Add("@isReturnedGoods", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesNote", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAPNAdjustment", SqlDbType.Bit,1);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
 
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@debitNote_Date"].Value = debitNote_Date;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@otherTaxTotal"].Value = otherTaxTotal;
			scom.Parameters["@vatTotal"].Value = vatTotal;
			scom.Parameters["@nbtTotal"].Value = nbtTotal;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
			scom.Parameters["@vatPercentage"].Value = vatPercentage;
			scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
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
			scom.Parameters["@isReturnedGoods"].Value = isReturnedGoods;
			scom.Parameters["@isSalesNote"].Value = isSalesNote;
			scom.Parameters["@isAPNAdjustment"].Value = isAPNAdjustment;
			scom.Parameters["@settledAmount"].Value = settledAmount;
			scom.Parameters["@isSettled"].Value = isSettled;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accDebitNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

        /// <summary>
        /// Selects all records from the tbl_accDebitNote table by a foreign key.
        /// </summary>
        public static void DeleteAllByPurchaseReturnedNote_ID(string purchaseReturnedNote_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accDebitNoteDeleteAllByPurchaseReturnedNote_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the tbl_accDebitNote table by a foreign key.
        /// </summary>
        public static void DeleteAllByAccountPayableNote_ID(string accountPayableNote_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accDebitNoteDeleteAllByAccountPayableNote_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }
		
		/// <summary>
		/// Selects a single record from the tbl_accDebitNote table.
		/// </summary>
		public static tbl_accDebitNote Select(string debitNote_ID_Incoming){

			tbl_accDebitNote tbl_accDebitNoteins = new tbl_accDebitNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accDebitNoteins = Maketbl_accDebitNote(dataReader);
				} else {
					tbl_accDebitNoteins = null;
				}
			}
			scon.Close();
			return tbl_accDebitNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDebitNote table.
		/// </summary>
		public static List<tbl_accDebitNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            List<tbl_accDebitNote> tbl_accDebitNoteList = new List<tbl_accDebitNote>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_accDebitNote tbl_accDebitNote = Maketbl_accDebitNote(dataReader);
                    tbl_accDebitNoteList.Add(tbl_accDebitNote);
                }
            }
            scon.Close();
            return tbl_accDebitNoteList;
        }

        /// <summary>
        /// Selects all records from the tbl_accDebitNote table by a foreign key.
        /// </summary>
        public static List<tbl_accDebitNote> SelectAllByPurchaseReturnedNote_ID(string purchaseReturnedNote_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accDebitNoteSelectAllByPurchaseReturnedNote_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
				List<tbl_accDebitNote> tbl_accDebitNoteList = new List<tbl_accDebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accDebitNote tbl_accDebitNote = Maketbl_accDebitNote(dataReader);
					tbl_accDebitNoteList.Add(tbl_accDebitNote);
				}
			}
			scon.Close();
			return tbl_accDebitNoteList;
		}

        /// <summary>
        /// Selects all records from the tbl_accDebitNote table by a foreign key.
        /// </summary>
        public static List<tbl_accDebitNote> SelectAllByAccountPayableNote_ID(string accountPayableNote_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accDebitNoteSelectAllByAccountPayableNote_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
            List<tbl_accDebitNote> tbl_accDebitNoteList = new List<tbl_accDebitNote>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_accDebitNote tbl_accDebitNote = Maketbl_accDebitNote(dataReader);
                    tbl_accDebitNoteList.Add(tbl_accDebitNote);
                }
            }
            scon.Close();
            return tbl_accDebitNoteList;
        }
		/// <summary>
		/// Creates a new instance of the tbl_accDebitNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accDebitNote Maketbl_accDebitNote(SqlDataReader dataReader) {
			tbl_accDebitNote tbl_accDebitNote = new tbl_accDebitNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accDebitNote.DebitNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accDebitNote.DebitNote_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accDebitNote.Remarks = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accDebitNote.PurchaseReturnedNote_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accDebitNote.AccountPayableNote_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accDebitNote.PaymentVoucher_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accDebitNote.Invoice_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accDebitNote.CreditNote_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accDebitNote.Supplier_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accDebitNote.Currency_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accDebitNote.CurrencyRate = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accDebitNote.GrandTotal = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accDebitNote.OtherTaxTotal = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_accDebitNote.VatTotal = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_accDebitNote.NbtTotal = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_accDebitNote.DiscountTotal = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_accDebitNote.SubTotal = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_accDebitNote.OtherTaxPercentage = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_accDebitNote.VatPercentage = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_accDebitNote.NbtPercentage = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_accDebitNote.DiscountPercentage = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_accDebitNote.CompanyID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_accDebitNote.CompanyBranch_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_accDebitNote.FinancialYear_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_accDebitNote.PostingStatus_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_accDebitNote.GlPosting_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_accDebitNote.CostCenter1_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_accDebitNote.CostCenter2_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_accDebitNote.CreateUser_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_accDebitNote.ModifiedUser_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_accDebitNote.CheckedUser_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_accDebitNote.ApprovedUser_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_accDebitNote.DeletedUser_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_accDebitNote.PrintedUser_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_accDebitNote.CreateTerminal_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_accDebitNote.ModifiedTerminal_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_accDebitNote.DeletedTerminal_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_accDebitNote.PrintedTerminal_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_accDebitNote.DateCreate = dataReader.GetDateTime(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_accDebitNote.DateModified = dataReader.GetDateTime(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_accDebitNote.DateChecked = dataReader.GetDateTime(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_accDebitNote.DateApproved = dataReader.GetDateTime(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_accDebitNote.DateDeleted = dataReader.GetDateTime(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_accDebitNote.DatePrinted = dataReader.GetDateTime(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_accDebitNote.IsChecked = dataReader.GetBoolean(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_accDebitNote.IsApproved = dataReader.GetBoolean(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_accDebitNote.IsFinished = dataReader.GetBoolean(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_accDebitNote.IsDeleted = dataReader.GetBoolean(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_accDebitNote.IsReturnedGoods = dataReader.GetBoolean(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_accDebitNote.IsSalesNote = dataReader.GetBoolean(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_accDebitNote.IsAPNAdjustment = dataReader.GetBoolean(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_accDebitNote.SettledAmount = dataReader.GetDecimal(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_accDebitNote.IsSettled = dataReader.GetBoolean(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_accDebitNote.IsLocked = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_accDebitNote.PrintCount = dataReader.GetInt32(54);
			}
			
			return tbl_accDebitNote;
		}
		/// <summary>
		/// This makes tbl_accDebitNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accDebitNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accDebitNote  tbl_accDebitNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_debitNote_ID = new DataColumn("debitNote_ID" , typeof(string));
			DataColumn col_debitNote_Date = new DataColumn("debitNote_Date" , typeof(DateTime));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_purchaseReturnedNote_ID = new DataColumn("purchaseReturnedNote_ID" , typeof(string));
			DataColumn col_accountPayableNote_ID = new DataColumn("accountPayableNote_ID" , typeof(string));
			DataColumn col_paymentVoucher_ID = new DataColumn("paymentVoucher_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_creditNote_ID = new DataColumn("creditNote_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
			DataColumn col_otherTaxTotal = new DataColumn("otherTaxTotal" , typeof(decimal));
			DataColumn col_vatTotal = new DataColumn("vatTotal" , typeof(decimal));
			DataColumn col_nbtTotal = new DataColumn("nbtTotal" , typeof(decimal));
			DataColumn col_discountTotal = new DataColumn("discountTotal" , typeof(decimal));
			DataColumn col_subTotal = new DataColumn("subTotal" , typeof(decimal));
			DataColumn col_otherTaxPercentage = new DataColumn("otherTaxPercentage" , typeof(decimal));
			DataColumn col_vatPercentage = new DataColumn("vatPercentage" , typeof(decimal));
			DataColumn col_nbtPercentage = new DataColumn("nbtPercentage" , typeof(decimal));
			DataColumn col_discountPercentage = new DataColumn("discountPercentage" , typeof(decimal));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_costCenter1_ID = new DataColumn("costCenter1_ID" , typeof(string));
			DataColumn col_costCenter2_ID = new DataColumn("costCenter2_ID" , typeof(string));
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
			DataColumn col_isReturnedGoods = new DataColumn("isReturnedGoods" , typeof(bool));
			DataColumn col_isSalesNote = new DataColumn("isSalesNote" , typeof(bool));
			DataColumn col_isAPNAdjustment = new DataColumn("isAPNAdjustment" , typeof(bool));
			DataColumn col_settledAmount = new DataColumn("settledAmount" , typeof(decimal));
			DataColumn col_isSettled = new DataColumn("isSettled" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_debitNote_ID,col_debitNote_Date,col_remarks,col_purchaseReturnedNote_ID,col_accountPayableNote_ID,col_paymentVoucher_ID,col_invoice_ID,col_creditNote_ID,col_supplier_ID,col_currency_ID,col_currencyRate,col_grandTotal,col_otherTaxTotal,col_vatTotal,col_nbtTotal,col_discountTotal,col_subTotal,col_otherTaxPercentage,col_vatPercentage,col_nbtPercentage,col_discountPercentage,col_companyID,col_companyBranch_ID,col_financialYear_ID,col_postingStatus_ID,col_glPosting_ID,col_costCenter1_ID,col_costCenter2_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isReturnedGoods,col_isSalesNote,col_isAPNAdjustment,col_settledAmount,col_isSettled,col_isLocked,col_printCount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accDebitNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accDebitNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accDebitNote user) {
		DataRow drow = dt.NewRow();
		
			drow["debitNote_ID"] = user.debitNote_ID;
			drow["debitNote_Date"] = user.debitNote_Date;
			drow["remarks"] = user.remarks;
			drow["purchaseReturnedNote_ID"] = user.purchaseReturnedNote_ID;
			drow["accountPayableNote_ID"] = user.accountPayableNote_ID;
			drow["paymentVoucher_ID"] = user.paymentVoucher_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["creditNote_ID"] = user.creditNote_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["grandTotal"] = user.grandTotal;
			drow["otherTaxTotal"] = user.otherTaxTotal;
			drow["vatTotal"] = user.vatTotal;
			drow["nbtTotal"] = user.nbtTotal;
			drow["discountTotal"] = user.discountTotal;
			drow["subTotal"] = user.subTotal;
			drow["otherTaxPercentage"] = user.otherTaxPercentage;
			drow["vatPercentage"] = user.vatPercentage;
			drow["nbtPercentage"] = user.nbtPercentage;
			drow["discountPercentage"] = user.discountPercentage;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["costCenter1_ID"] = user.costCenter1_ID;
			drow["costCenter2_ID"] = user.costCenter2_ID;
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
			drow["isReturnedGoods"] = user.isReturnedGoods;
			drow["isSalesNote"] = user.isSalesNote;
			drow["isAPNAdjustment"] = user.isAPNAdjustment;
			drow["settledAmount"] = user.settledAmount;
			drow["isSettled"] = user.isSettled;
			drow["isLocked"] = user.isLocked;
			drow["printCount"] = user.printCount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
