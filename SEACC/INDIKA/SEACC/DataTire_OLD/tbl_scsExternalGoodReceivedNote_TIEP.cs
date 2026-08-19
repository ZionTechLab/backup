using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsExternalGoodReceivedNote_TIEP {
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
		private string companyID;
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
		private string country_ID;
		private string cleaningAgent_ID;
		private string cleaningBillNo;
		private string fileNo;
		private string cusdecCode1;
		private string cusdecCode2;
		private string cusdecCode3;
		private string cusdecCode4;
		private string cusdecCodeFull;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsExternalGoodReceivedNote_TIEP class.
		/// </summary>
		public tbl_scsExternalGoodReceivedNote_TIEP() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsExternalGoodReceivedNote_TIEP class.
		/// </summary>
		public tbl_scsExternalGoodReceivedNote_TIEP(string externalGoodReceivedNote_ID, DateTime externalGoodReceivedNoteDate, string remark, string supplier_ID, string purchaseOrder_ID, string store_ID, string issuedRefNo_ID, string currency_ID, decimal currencyRate, string paymentTerms, string paymentMode, string creditPeriod, DateTime paymentDueDate, string deliveryOrderNumber, string invoiceNo, string stockNoteType_ID, string glPosting_ID, string costCenter, string postingStatus_ID, string financialYear_ID, string companyID, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, decimal seattleAmount, bool isSeattled, int printCount, bool isWeightCalculation, bool isVAT, bool isSVAT, string country_ID, string cleaningAgent_ID, string cleaningBillNo, string fileNo, string cusdecCode1, string cusdecCode2, string cusdecCode3, string cusdecCode4, string cusdecCodeFull) {
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.externalGoodReceivedNoteDate = externalGoodReceivedNoteDate;
			this.remark = remark;
			this.supplier_ID = supplier_ID;
			this.purchaseOrder_ID = purchaseOrder_ID;
			this.store_ID = store_ID;
			this.issuedRefNo_ID = issuedRefNo_ID;
			this.currency_ID = currency_ID;
			this.currencyRate = currencyRate;
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
			this.companyID = companyID;
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
			this.country_ID = country_ID;
			this.cleaningAgent_ID = cleaningAgent_ID;
			this.cleaningBillNo = cleaningBillNo;
			this.fileNo = fileNo;
			this.cusdecCode1 = cusdecCode1;
			this.cusdecCode2 = cusdecCode2;
			this.cusdecCode3 = cusdecCode3;
			this.cusdecCode4 = cusdecCode4;
			this.cusdecCodeFull = cusdecCodeFull;
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
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
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
		/// Gets or sets the Country_ID value.
		/// </summary>
		public string Country_ID {
			get { return country_ID; }
			set { country_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CleaningAgent_ID value.
		/// </summary>
		public string CleaningAgent_ID {
			get { return cleaningAgent_ID; }
			set { cleaningAgent_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CleaningBillNo value.
		/// </summary>
		public string CleaningBillNo {
			get { return cleaningBillNo; }
			set { cleaningBillNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the FileNo value.
		/// </summary>
		public string FileNo {
			get { return fileNo; }
			set { fileNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the CusdecCode1 value.
		/// </summary>
		public string CusdecCode1 {
			get { return cusdecCode1; }
			set { cusdecCode1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the CusdecCode2 value.
		/// </summary>
		public string CusdecCode2 {
			get { return cusdecCode2; }
			set { cusdecCode2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the CusdecCode3 value.
		/// </summary>
		public string CusdecCode3 {
			get { return cusdecCode3; }
			set { cusdecCode3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the CusdecCode4 value.
		/// </summary>
		public string CusdecCode4 {
			get { return cusdecCode4; }
			set { cusdecCode4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the CusdecCodeFull value.
		/// </summary>
		public string CusdecCodeFull {
			get { return cusdecCodeFull; }
			set { cusdecCodeFull = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsExternalGoodReceivedNote_TIEP table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEPInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@paymentTerms", SqlDbType.VarChar,100);
			scom.Parameters.Add("@paymentMode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@creditPeriod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@paymentDueDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveryOrderNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoiceNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@CostCenter", SqlDbType.VarChar,50);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
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
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cleaningAgent_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cleaningBillNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fileNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@cusdecCode1", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cusdecCode2", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cusdecCode3", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cusdecCode4", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cusdecCodeFull", SqlDbType.VarChar,50);
 
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@externalGoodReceivedNoteDate"].Value = externalGoodReceivedNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@paymentTerms"].Value = paymentTerms;
			scom.Parameters["@paymentMode"].Value = paymentMode;
			scom.Parameters["@creditPeriod"].Value = creditPeriod;
			scom.Parameters["@paymentDueDate"].Value = paymentDueDate;
			scom.Parameters["@deliveryOrderNumber"].Value = deliveryOrderNumber;
			scom.Parameters["@invoiceNo"].Value = invoiceNo;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@CostCenter"].Value = costCenter;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
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
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@cleaningAgent_ID"].Value = cleaningAgent_ID;
			scom.Parameters["@cleaningBillNo"].Value = cleaningBillNo;
			scom.Parameters["@fileNo"].Value = fileNo;
			scom.Parameters["@cusdecCode1"].Value = cusdecCode1;
			scom.Parameters["@cusdecCode2"].Value = cusdecCode2;
			scom.Parameters["@cusdecCode3"].Value = cusdecCode3;
			scom.Parameters["@cusdecCode4"].Value = cusdecCode4;
			scom.Parameters["@cusdecCodeFull"].Value = cusdecCodeFull;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsExternalGoodReceivedNote_TIEP table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEPUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@paymentTerms", SqlDbType.VarChar,100);
			scom.Parameters.Add("@paymentMode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@creditPeriod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@paymentDueDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveryOrderNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoiceNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@CostCenter", SqlDbType.VarChar,50);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
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
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cleaningAgent_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cleaningBillNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fileNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@cusdecCode1", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cusdecCode2", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cusdecCode3", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cusdecCode4", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cusdecCodeFull", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@externalGoodReceivedNoteDate"].Value = externalGoodReceivedNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@paymentTerms"].Value = paymentTerms;
			scom.Parameters["@paymentMode"].Value = paymentMode;
			scom.Parameters["@creditPeriod"].Value = creditPeriod;
			scom.Parameters["@paymentDueDate"].Value = paymentDueDate;
			scom.Parameters["@deliveryOrderNumber"].Value = deliveryOrderNumber;
			scom.Parameters["@invoiceNo"].Value = invoiceNo;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@CostCenter"].Value = costCenter;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
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
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@cleaningAgent_ID"].Value = cleaningAgent_ID;
			scom.Parameters["@cleaningBillNo"].Value = cleaningBillNo;
			scom.Parameters["@fileNo"].Value = fileNo;
			scom.Parameters["@cusdecCode1"].Value = cusdecCode1;
			scom.Parameters["@cusdecCode2"].Value = cusdecCode2;
			scom.Parameters["@cusdecCode3"].Value = cusdecCode3;
			scom.Parameters["@cusdecCode4"].Value = cusdecCode4;
			scom.Parameters["@cusdecCodeFull"].Value = cusdecCodeFull;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsExternalGoodReceivedNote_TIEP table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEPDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsExternalGoodReceivedNote_TIEP table.
		/// </summary>
		public static tbl_scsExternalGoodReceivedNote_TIEP Select(string externalGoodReceivedNote_ID_Incoming){

			tbl_scsExternalGoodReceivedNote_TIEP tbl_scsExternalGoodReceivedNote_TIEPins = new tbl_scsExternalGoodReceivedNote_TIEP();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEPSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote_TIEPins = Maketbl_scsExternalGoodReceivedNote_TIEP(dataReader);
				} else {
					tbl_scsExternalGoodReceivedNote_TIEPins = null;
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNote_TIEPins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote_TIEP table.
		/// </summary>
		public static List<tbl_scsExternalGoodReceivedNote_TIEP> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEPSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsExternalGoodReceivedNote_TIEP> tbl_scsExternalGoodReceivedNote_TIEPList = new List<tbl_scsExternalGoodReceivedNote_TIEP>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote_TIEP tbl_scsExternalGoodReceivedNote_TIEP = Maketbl_scsExternalGoodReceivedNote_TIEP(dataReader);
					tbl_scsExternalGoodReceivedNote_TIEPList.Add(tbl_scsExternalGoodReceivedNote_TIEP);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNote_TIEPList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsExternalGoodReceivedNote_TIEP class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsExternalGoodReceivedNote_TIEP Maketbl_scsExternalGoodReceivedNote_TIEP(SqlDataReader dataReader) {
			tbl_scsExternalGoodReceivedNote_TIEP tbl_scsExternalGoodReceivedNote_TIEP = new tbl_scsExternalGoodReceivedNote_TIEP();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.ExternalGoodReceivedNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.ExternalGoodReceivedNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.Supplier_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.PurchaseOrder_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.Store_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.IssuedRefNo_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.Currency_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CurrencyRate = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.PaymentTerms = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.PaymentMode = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CreditPeriod = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.PaymentDueDate = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DeliveryOrderNumber = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.InvoiceNo = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.StockNoteType_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.GlPosting_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CostCenter = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.PostingStatus_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.FinancialYear_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CompanyID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DiscountPercentage = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.NbtPercentage = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.VatPercentage = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.OtherTaxPercentage = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.SubTotal = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DiscountTotal = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.NbtTotal = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.VatTotal = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.OtherTaxTotal = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.GrandTotal = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CreateUser_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.ModifiedUser_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CheckedUser_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.ApprovedUser_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DeletedUser_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.PrintedUser_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CreateTerminal_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.ModifiedTerminal_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DeletedTerminal_ID = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.PrintedTerminal_ID = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DateCreate = dataReader.GetDateTime(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DateModified = dataReader.GetDateTime(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DateChecked = dataReader.GetDateTime(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DateApproved = dataReader.GetDateTime(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DateDeleted = dataReader.GetDateTime(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.DatePrinted = dataReader.GetDateTime(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.IsChecked = dataReader.GetBoolean(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.IsApproved = dataReader.GetBoolean(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.IsFinished = dataReader.GetBoolean(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.IsDeleted = dataReader.GetBoolean(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.IsLocked = dataReader.GetBoolean(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.SeattleAmount = dataReader.GetDecimal(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.IsSeattled = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.PrintCount = dataReader.GetInt32(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.IsWeightCalculation = dataReader.GetBoolean(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.IsVAT = dataReader.GetBoolean(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.IsSVAT = dataReader.GetBoolean(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.Country_ID = dataReader.GetString(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CleaningAgent_ID = dataReader.GetString(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CleaningBillNo = dataReader.GetString(60);
			}
			if (dataReader.IsDBNull(61) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.FileNo = dataReader.GetString(61);
			}
			if (dataReader.IsDBNull(62) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CusdecCode1 = dataReader.GetString(62);
			}
			if (dataReader.IsDBNull(63) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CusdecCode2 = dataReader.GetString(63);
			}
			if (dataReader.IsDBNull(64) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CusdecCode3 = dataReader.GetString(64);
			}
			if (dataReader.IsDBNull(65) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CusdecCode4 = dataReader.GetString(65);
			}
			if (dataReader.IsDBNull(66) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP.CusdecCodeFull = dataReader.GetString(66);
			}

			return tbl_scsExternalGoodReceivedNote_TIEP;
		}
		/// <summary>
		/// This makes tbl_scsExternalGoodReceivedNote_TIEP datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsExternalGoodReceivedNote_TIEP object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsExternalGoodReceivedNote_TIEP  tbl_scsExternalGoodReceivedNote_TIEP   )
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
			DataColumn col_paymentTerms = new DataColumn("paymentTerms" , typeof(string));
			DataColumn col_paymentMode = new DataColumn("paymentMode" , typeof(string));
			DataColumn col_creditPeriod = new DataColumn("creditPeriod" , typeof(string));
			DataColumn col_paymentDueDate = new DataColumn("paymentDueDate" , typeof(DateTime));
			DataColumn col_deliveryOrderNumber = new DataColumn("deliveryOrderNumber" , typeof(string));
			DataColumn col_invoiceNo = new DataColumn("invoiceNo" , typeof(string));
			DataColumn col_stockNoteType_ID = new DataColumn("stockNoteType_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_CostCenter = new DataColumn("CostCenter" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
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
			DataColumn col_country_ID = new DataColumn("country_ID" , typeof(string));
			DataColumn col_cleaningAgent_ID = new DataColumn("cleaningAgent_ID" , typeof(string));
			DataColumn col_cleaningBillNo = new DataColumn("cleaningBillNo" , typeof(string));
			DataColumn col_fileNo = new DataColumn("fileNo" , typeof(string));
			DataColumn col_cusdecCode1 = new DataColumn("cusdecCode1" , typeof(string));
			DataColumn col_cusdecCode2 = new DataColumn("cusdecCode2" , typeof(string));
			DataColumn col_cusdecCode3 = new DataColumn("cusdecCode3" , typeof(string));
			DataColumn col_cusdecCode4 = new DataColumn("cusdecCode4" , typeof(string));
			DataColumn col_cusdecCodeFull = new DataColumn("cusdecCodeFull" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_externalGoodReceivedNote_ID,col_externalGoodReceivedNoteDate,col_remark,col_supplier_ID,col_purchaseOrder_ID,col_store_ID,col_IssuedRefNo_ID,col_currency_ID,col_currencyRate,col_paymentTerms,col_paymentMode,col_creditPeriod,col_paymentDueDate,col_deliveryOrderNumber,col_invoiceNo,col_stockNoteType_ID,col_glPosting_ID,col_CostCenter,col_postingStatus_ID,col_financialYear_ID,col_companyID,col_discountPercentage,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grandTotal,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_seattleAmount,col_isSeattled,col_printCount,col_isWeightCalculation,col_isVAT,col_isSVAT,col_country_ID,col_cleaningAgent_ID,col_cleaningBillNo,col_fileNo,col_cusdecCode1,col_cusdecCode2,col_cusdecCode3,col_cusdecCode4,col_cusdecCodeFull,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsExternalGoodReceivedNote_TIEP datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsExternalGoodReceivedNote_TIEP object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsExternalGoodReceivedNote_TIEP user) {
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
			drow["paymentTerms"] = user.paymentTerms;
			drow["paymentMode"] = user.paymentMode;
			drow["creditPeriod"] = user.creditPeriod;
			drow["paymentDueDate"] = user.paymentDueDate;
			drow["deliveryOrderNumber"] = user.deliveryOrderNumber;
			drow["invoiceNo"] = user.invoiceNo;
			drow["stockNoteType_ID"] = user.stockNoteType_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["CostCenter"] = user.CostCenter;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["companyID"] = user.companyID;
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
			drow["country_ID"] = user.country_ID;
			drow["cleaningAgent_ID"] = user.cleaningAgent_ID;
			drow["cleaningBillNo"] = user.cleaningBillNo;
			drow["fileNo"] = user.fileNo;
			drow["cusdecCode1"] = user.cusdecCode1;
			drow["cusdecCode2"] = user.cusdecCode2;
			drow["cusdecCode3"] = user.cusdecCode3;
			drow["cusdecCode4"] = user.cusdecCode4;
			drow["cusdecCodeFull"] = user.cusdecCodeFull;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
