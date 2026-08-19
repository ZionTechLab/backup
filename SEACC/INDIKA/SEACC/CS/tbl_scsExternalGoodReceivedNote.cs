using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsExternalGoodReceivedNote {
		#region Fields
		private string externalGoodReceivedNote_ID;
		private DateTime externalGoodReceivedNoteDate;
		private string remark;
		private string supplier_ID;
		private string purchaseOrder_ID;
		private string store_ID;
		private string issuedRefNo_ID;
		private string currency_ID;
		private decimal currencyRate;
		private string paymentMethod_ID;
		private string paymentTerms;
		private string paymentMode;
		private string creditPeriod;
		private DateTime paymentDueDate;
		private string deliveryOrderNumber;
		private string invoiceNo;
		private string stockNoteType_ID;
		private string glPosting_ID;
		private string costCenter;
		private string postingStatus_ID;
		private string financialYear_ID;
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
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private decimal seattleAmount;
		private bool isSeattled;
		private int printCount;
		private bool isWeightCalculation;
		private bool isVAT;
		private bool isSVAT;
		private string companyID;
		private string companyBranch_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsExternalGoodReceivedNote class.
		/// </summary>
		public tbl_scsExternalGoodReceivedNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsExternalGoodReceivedNote class.
		/// </summary>
		public tbl_scsExternalGoodReceivedNote(string externalGoodReceivedNote_ID, DateTime externalGoodReceivedNoteDate, string remark, string supplier_ID, string purchaseOrder_ID, string store_ID, string issuedRefNo_ID, string currency_ID, decimal currencyRate, string paymentMethod_ID, string paymentTerms, string paymentMode, string creditPeriod, DateTime paymentDueDate, string deliveryOrderNumber, string invoiceNo, string stockNoteType_ID, string glPosting_ID, string costCenter, string postingStatus_ID, string financialYear_ID, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, decimal seattleAmount, bool isSeattled, int printCount, bool isWeightCalculation, bool isVAT, bool isSVAT, string companyID, string companyBranch_ID) {
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.externalGoodReceivedNoteDate = externalGoodReceivedNoteDate;
			this.remark = remark;
			this.supplier_ID = supplier_ID;
			this.purchaseOrder_ID = purchaseOrder_ID;
			this.store_ID = store_ID;
			this.issuedRefNo_ID = issuedRefNo_ID;
			this.currency_ID = currency_ID;
			this.currencyRate = currencyRate;
			this.paymentMethod_ID = paymentMethod_ID;
			this.paymentTerms = paymentTerms;
			this.paymentMode = paymentMode;
			this.creditPeriod = creditPeriod;
			this.paymentDueDate = paymentDueDate;
			this.deliveryOrderNumber = deliveryOrderNumber;
			this.invoiceNo = invoiceNo;
			this.stockNoteType_ID = stockNoteType_ID;
			this.glPosting_ID = glPosting_ID;
			this.costCenter = costCenter;
			this.postingStatus_ID = postingStatus_ID;
			this.financialYear_ID = financialYear_ID;
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
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.seattleAmount = seattleAmount;
			this.isSeattled = isSeattled;
			this.printCount = printCount;
			this.isWeightCalculation = isWeightCalculation;
			this.isVAT = isVAT;
			this.isSVAT = isSVAT;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNote_ID value.
		/// </summary>
		public string ExternalGoodReceivedNote_ID {
			get { return externalGoodReceivedNote_ID; }
			set { externalGoodReceivedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNoteDate value.
		/// </summary>
		public DateTime ExternalGoodReceivedNoteDate {
			get { return externalGoodReceivedNoteDate; }
			set { externalGoodReceivedNoteDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseOrder_ID value.
		/// </summary>
		public string PurchaseOrder_ID {
			get { return purchaseOrder_ID; }
			set { purchaseOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IssuedRefNo_ID value.
		/// </summary>
		public string IssuedRefNo_ID {
			get { return issuedRefNo_ID; }
			set { issuedRefNo_ID = value; }
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
		/// Gets or sets the PaymentMethod_ID value.
		/// </summary>
		public string PaymentMethod_ID {
			get { return paymentMethod_ID; }
			set { paymentMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentTerms value.
		/// </summary>
		public string PaymentTerms {
			get { return paymentTerms; }
			set { paymentTerms = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentMode value.
		/// </summary>
		public string PaymentMode {
			get { return paymentMode; }
			set { paymentMode = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditPeriod value.
		/// </summary>
		public string CreditPeriod {
			get { return creditPeriod; }
			set { creditPeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentDueDate value.
		/// </summary>
		public DateTime PaymentDueDate {
			get { return paymentDueDate; }
			set { paymentDueDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryOrderNumber value.
		/// </summary>
		public string DeliveryOrderNumber {
			get { return deliveryOrderNumber; }
			set { deliveryOrderNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the InvoiceNo value.
		/// </summary>
		public string InvoiceNo {
			get { return invoiceNo; }
			set { invoiceNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the StockNoteType_ID value.
		/// </summary>
		public string StockNoteType_ID {
			get { return stockNoteType_ID; }
			set { stockNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlPosting_ID value.
		/// </summary>
		public string GlPosting_ID {
			get { return glPosting_ID; }
			set { glPosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenter value.
		/// </summary>
		public string CostCenter {
			get { return costCenter; }
			set { costCenter = value; }
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
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeightCalculation value.
		/// </summary>
		public bool IsWeightCalculation {
			get { return isWeightCalculation; }
			set { isWeightCalculation = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsVAT value.
		/// </summary>
		public bool IsVAT {
			get { return isVAT; }
			set { isVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSVAT value.
		/// </summary>
		public bool IsSVAT {
			get { return isSVAT; }
			set { isSVAT = value; }
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
		/// Saves a record to the tbl_scsExternalGoodReceivedNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentTerms", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentMode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@creditPeriod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@paymentDueDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveryOrderNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoiceNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter", SqlDbType.VarChar,50);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@externalGoodReceivedNoteDate"].Value = externalGoodReceivedNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@paymentTerms"].Value = paymentTerms;
			scom.Parameters["@paymentMode"].Value = paymentMode;
			scom.Parameters["@creditPeriod"].Value = creditPeriod;
			scom.Parameters["@paymentDueDate"].Value = paymentDueDate;
			scom.Parameters["@deliveryOrderNumber"].Value = deliveryOrderNumber;
			scom.Parameters["@invoiceNo"].Value = invoiceNo;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@costCenter"].Value = costCenter;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
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
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@isVAT"].Value = isVAT;
			scom.Parameters["@isSVAT"].Value = isSVAT;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsExternalGoodReceivedNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentTerms", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentMode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@creditPeriod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@paymentDueDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveryOrderNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoiceNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter", SqlDbType.VarChar,50);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@externalGoodReceivedNoteDate"].Value = externalGoodReceivedNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@paymentTerms"].Value = paymentTerms;
			scom.Parameters["@paymentMode"].Value = paymentMode;
			scom.Parameters["@creditPeriod"].Value = creditPeriod;
			scom.Parameters["@paymentDueDate"].Value = paymentDueDate;
			scom.Parameters["@deliveryOrderNumber"].Value = deliveryOrderNumber;
			scom.Parameters["@invoiceNo"].Value = invoiceNo;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@costCenter"].Value = costCenter;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
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
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@isVAT"].Value = isVAT;
			scom.Parameters["@isSVAT"].Value = isSVAT;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsExternalGoodReceivedNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteDeleteAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByPurchaseOrder_ID(string purchaseOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteDeleteAllByPurchaseOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByPaymentMethod_ID(string paymentMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteDeleteAllByPaymentMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsExternalGoodReceivedNote table.
		/// </summary>
		public static tbl_scsExternalGoodReceivedNote Select(string externalGoodReceivedNote_ID_Incoming){

			tbl_scsExternalGoodReceivedNote tbl_scsExternalGoodReceivedNoteins = new tbl_scsExternalGoodReceivedNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNoteins = Maketbl_scsExternalGoodReceivedNote(dataReader);
				} else {
					tbl_scsExternalGoodReceivedNoteins = null;
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table.
		/// </summary>
		public static List<tbl_scsExternalGoodReceivedNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsExternalGoodReceivedNote> tbl_scsExternalGoodReceivedNoteList = new List<tbl_scsExternalGoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote tbl_scsExternalGoodReceivedNote = Maketbl_scsExternalGoodReceivedNote(dataReader);
					tbl_scsExternalGoodReceivedNoteList.Add(tbl_scsExternalGoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsExternalGoodReceivedNote> SelectAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteSelectAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
				List<tbl_scsExternalGoodReceivedNote> tbl_scsExternalGoodReceivedNoteList = new List<tbl_scsExternalGoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote tbl_scsExternalGoodReceivedNote = Maketbl_scsExternalGoodReceivedNote(dataReader);
					tbl_scsExternalGoodReceivedNoteList.Add(tbl_scsExternalGoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsExternalGoodReceivedNote> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_scsExternalGoodReceivedNote> tbl_scsExternalGoodReceivedNoteList = new List<tbl_scsExternalGoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote tbl_scsExternalGoodReceivedNote = Maketbl_scsExternalGoodReceivedNote(dataReader);
					tbl_scsExternalGoodReceivedNoteList.Add(tbl_scsExternalGoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsExternalGoodReceivedNote> SelectAllByPurchaseOrder_ID(string purchaseOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteSelectAllByPurchaseOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
				List<tbl_scsExternalGoodReceivedNote> tbl_scsExternalGoodReceivedNoteList = new List<tbl_scsExternalGoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote tbl_scsExternalGoodReceivedNote = Maketbl_scsExternalGoodReceivedNote(dataReader);
					tbl_scsExternalGoodReceivedNoteList.Add(tbl_scsExternalGoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsExternalGoodReceivedNote> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_scsExternalGoodReceivedNote> tbl_scsExternalGoodReceivedNoteList = new List<tbl_scsExternalGoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote tbl_scsExternalGoodReceivedNote = Maketbl_scsExternalGoodReceivedNote(dataReader);
					tbl_scsExternalGoodReceivedNoteList.Add(tbl_scsExternalGoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsExternalGoodReceivedNote> SelectAllByPaymentMethod_ID(string paymentMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNoteSelectAllByPaymentMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
				List<tbl_scsExternalGoodReceivedNote> tbl_scsExternalGoodReceivedNoteList = new List<tbl_scsExternalGoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote tbl_scsExternalGoodReceivedNote = Maketbl_scsExternalGoodReceivedNote(dataReader);
					tbl_scsExternalGoodReceivedNoteList.Add(tbl_scsExternalGoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsExternalGoodReceivedNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsExternalGoodReceivedNote Maketbl_scsExternalGoodReceivedNote(SqlDataReader dataReader) {
			tbl_scsExternalGoodReceivedNote tbl_scsExternalGoodReceivedNote = new tbl_scsExternalGoodReceivedNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsExternalGoodReceivedNote.ExternalGoodReceivedNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsExternalGoodReceivedNote.ExternalGoodReceivedNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsExternalGoodReceivedNote.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsExternalGoodReceivedNote.Supplier_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsExternalGoodReceivedNote.PurchaseOrder_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsExternalGoodReceivedNote.Store_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsExternalGoodReceivedNote.IssuedRefNo_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsExternalGoodReceivedNote.Currency_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsExternalGoodReceivedNote.CurrencyRate = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsExternalGoodReceivedNote.PaymentMethod_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsExternalGoodReceivedNote.PaymentTerms = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsExternalGoodReceivedNote.PaymentMode = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsExternalGoodReceivedNote.CreditPeriod = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsExternalGoodReceivedNote.PaymentDueDate = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsExternalGoodReceivedNote.DeliveryOrderNumber = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsExternalGoodReceivedNote.InvoiceNo = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsExternalGoodReceivedNote.StockNoteType_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsExternalGoodReceivedNote.GlPosting_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsExternalGoodReceivedNote.CostCenter = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsExternalGoodReceivedNote.PostingStatus_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsExternalGoodReceivedNote.FinancialYear_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsExternalGoodReceivedNote.DiscountPercentage = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsExternalGoodReceivedNote.NbtPercentage = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsExternalGoodReceivedNote.VatPercentage = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsExternalGoodReceivedNote.OtherTaxPercentage = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_scsExternalGoodReceivedNote.SubTotal = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_scsExternalGoodReceivedNote.DiscountTotal = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_scsExternalGoodReceivedNote.NbtTotal = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_scsExternalGoodReceivedNote.VatTotal = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_scsExternalGoodReceivedNote.OtherTaxTotal = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_scsExternalGoodReceivedNote.GrandTotal = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_scsExternalGoodReceivedNote.CreateUser_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_scsExternalGoodReceivedNote.ModifiedUser_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_scsExternalGoodReceivedNote.CheckedUser_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_scsExternalGoodReceivedNote.ApprovedUser_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_scsExternalGoodReceivedNote.DeletedUser_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_scsExternalGoodReceivedNote.PrintedUser_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_scsExternalGoodReceivedNote.CreateTerminal_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_scsExternalGoodReceivedNote.ModifiedTerminal_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_scsExternalGoodReceivedNote.DeletedTerminal_ID = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_scsExternalGoodReceivedNote.PrintedTerminal_ID = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_scsExternalGoodReceivedNote.DateCreate = dataReader.GetDateTime(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_scsExternalGoodReceivedNote.DateModified = dataReader.GetDateTime(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_scsExternalGoodReceivedNote.DateChecked = dataReader.GetDateTime(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_scsExternalGoodReceivedNote.DateApproved = dataReader.GetDateTime(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_scsExternalGoodReceivedNote.DateDeleted = dataReader.GetDateTime(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_scsExternalGoodReceivedNote.DatePrinted = dataReader.GetDateTime(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_scsExternalGoodReceivedNote.IsChecked = dataReader.GetBoolean(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_scsExternalGoodReceivedNote.IsApproved = dataReader.GetBoolean(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_scsExternalGoodReceivedNote.IsFinished = dataReader.GetBoolean(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_scsExternalGoodReceivedNote.IsDeleted = dataReader.GetBoolean(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_scsExternalGoodReceivedNote.IsLocked = dataReader.GetBoolean(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_scsExternalGoodReceivedNote.SeattleAmount = dataReader.GetDecimal(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_scsExternalGoodReceivedNote.IsSeattled = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_scsExternalGoodReceivedNote.PrintCount = dataReader.GetInt32(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_scsExternalGoodReceivedNote.IsWeightCalculation = dataReader.GetBoolean(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_scsExternalGoodReceivedNote.IsVAT = dataReader.GetBoolean(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_scsExternalGoodReceivedNote.IsSVAT = dataReader.GetBoolean(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_scsExternalGoodReceivedNote.CompanyID = dataReader.GetString(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_scsExternalGoodReceivedNote.CompanyBranch_ID = dataReader.GetString(59);
			}

			return tbl_scsExternalGoodReceivedNote;
		}
		/// <summary>
		/// This makes tbl_scsExternalGoodReceivedNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsExternalGoodReceivedNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsExternalGoodReceivedNote  tbl_scsExternalGoodReceivedNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_externalGoodReceivedNote_ID = new DataColumn("externalGoodReceivedNote_ID" , typeof(string));
			DataColumn col_externalGoodReceivedNoteDate = new DataColumn("externalGoodReceivedNoteDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_purchaseOrder_ID = new DataColumn("purchaseOrder_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_IssuedRefNo_ID = new DataColumn("IssuedRefNo_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_paymentMethod_ID = new DataColumn("paymentMethod_ID" , typeof(string));
			DataColumn col_paymentTerms = new DataColumn("paymentTerms" , typeof(string));
			DataColumn col_paymentMode = new DataColumn("paymentMode" , typeof(string));
			DataColumn col_creditPeriod = new DataColumn("creditPeriod" , typeof(string));
			DataColumn col_paymentDueDate = new DataColumn("paymentDueDate" , typeof(DateTime));
			DataColumn col_deliveryOrderNumber = new DataColumn("deliveryOrderNumber" , typeof(string));
			DataColumn col_invoiceNo = new DataColumn("invoiceNo" , typeof(string));
			DataColumn col_stockNoteType_ID = new DataColumn("stockNoteType_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_costCenter = new DataColumn("costCenter" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
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
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_seattleAmount = new DataColumn("seattleAmount" , typeof(decimal));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation" , typeof(bool));
			DataColumn col_isVAT = new DataColumn("isVAT" , typeof(bool));
			DataColumn col_isSVAT = new DataColumn("isSVAT" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_externalGoodReceivedNote_ID,col_externalGoodReceivedNoteDate,col_remark,col_supplier_ID,col_purchaseOrder_ID,col_store_ID,col_IssuedRefNo_ID,col_currency_ID,col_currencyRate,col_paymentMethod_ID,col_paymentTerms,col_paymentMode,col_creditPeriod,col_paymentDueDate,col_deliveryOrderNumber,col_invoiceNo,col_stockNoteType_ID,col_glPosting_ID,col_costCenter,col_postingStatus_ID,col_financialYear_ID,col_discountPercentage,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grandTotal,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_seattleAmount,col_isSeattled,col_printCount,col_isWeightCalculation,col_isVAT,col_isSVAT,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsExternalGoodReceivedNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsExternalGoodReceivedNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsExternalGoodReceivedNote user) {
		DataRow drow = dt.NewRow();
		
			drow["externalGoodReceivedNote_ID"] = user.externalGoodReceivedNote_ID;
			drow["externalGoodReceivedNoteDate"] = user.externalGoodReceivedNoteDate;
			drow["remark"] = user.remark;
			drow["supplier_ID"] = user.supplier_ID;
			drow["purchaseOrder_ID"] = user.purchaseOrder_ID;
			drow["store_ID"] = user.store_ID;
			drow["IssuedRefNo_ID"] = user.IssuedRefNo_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["paymentMethod_ID"] = user.paymentMethod_ID;
			drow["paymentTerms"] = user.paymentTerms;
			drow["paymentMode"] = user.paymentMode;
			drow["creditPeriod"] = user.creditPeriod;
			drow["paymentDueDate"] = user.paymentDueDate;
			drow["deliveryOrderNumber"] = user.deliveryOrderNumber;
			drow["invoiceNo"] = user.invoiceNo;
			drow["stockNoteType_ID"] = user.stockNoteType_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["costCenter"] = user.costCenter;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
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
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["seattleAmount"] = user.seattleAmount;
			drow["isSeattled"] = user.isSeattled;
			drow["printCount"] = user.printCount;
			drow["isWeightCalculation"] = user.isWeightCalculation;
			drow["isVAT"] = user.isVAT;
			drow["isSVAT"] = user.isSVAT;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
