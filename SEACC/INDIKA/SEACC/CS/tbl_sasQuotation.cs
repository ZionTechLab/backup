using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasQuotation {
		#region Fields
		private string quotation_ID;
		private DateTime quotationDate;
		private string remark;
		private string valiedPeriod;
		private string deliveryPeriod;
		private string paymentPeriod;
		private string quotationSubject;
		private int contactLine_No;
		private string contactName;
		private string orderRefNo_ID;
		private string customer_ID;
		private string inquiry_ID;
		private string job_ID;
		private string quotationType_ID;
		private string employee_ID;
		private string currency_ID;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string financialYear_ID;
		private string companyID;
		private string companyBranch_ID;
		private decimal currencyRate;
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
		private decimal recommendedSubTotal;
		private decimal recommendedGrandTotal;
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
		private bool isDoneProductionJob;
		private bool isSeattled;
		private bool isWeightCalculation;
		private int printCount;
		private bool isTaxReverseCalulation;
		private bool isFreeOrder;
		private bool isVAT;
		private bool isSVAT;
		private string branch_ID;
		private string deliveryAddress;
		private string quotationTerms;
		private string bankAccount;
		private string itemPriceCategory;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasQuotation class.
		/// </summary>
		public tbl_sasQuotation() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasQuotation class.
		/// </summary>
		public tbl_sasQuotation(string quotation_ID, DateTime quotationDate, string remark, string valiedPeriod, string deliveryPeriod, string paymentPeriod, string quotationSubject, int contactLine_No, string contactName, string orderRefNo_ID, string customer_ID, string inquiry_ID, string job_ID, string quotationType_ID, string employee_ID, string currency_ID, string glPosting_ID, string postingStatus_ID, string financialYear_ID, string companyID, string companyBranch_ID, decimal currencyRate, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, decimal recommendedSubTotal, decimal recommendedGrandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isDoneProductionJob, bool isSeattled, bool isWeightCalculation, int printCount, bool isTaxReverseCalulation, bool isFreeOrder, bool isVAT, bool isSVAT, string branch_ID, string deliveryAddress, string quotationTerms, string bankAccount, string itemPriceCategory) {
			this.quotation_ID = quotation_ID;
			this.quotationDate = quotationDate;
			this.remark = remark;
			this.valiedPeriod = valiedPeriod;
			this.deliveryPeriod = deliveryPeriod;
			this.paymentPeriod = paymentPeriod;
			this.quotationSubject = quotationSubject;
			this.contactLine_No = contactLine_No;
			this.contactName = contactName;
			this.orderRefNo_ID = orderRefNo_ID;
			this.customer_ID = customer_ID;
			this.inquiry_ID = inquiry_ID;
			this.job_ID = job_ID;
			this.quotationType_ID = quotationType_ID;
			this.employee_ID = employee_ID;
			this.currency_ID = currency_ID;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.financialYear_ID = financialYear_ID;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.currencyRate = currencyRate;
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
			this.recommendedSubTotal = recommendedSubTotal;
			this.recommendedGrandTotal = recommendedGrandTotal;
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
			this.isDoneProductionJob = isDoneProductionJob;
			this.isSeattled = isSeattled;
			this.isWeightCalculation = isWeightCalculation;
			this.printCount = printCount;
			this.isTaxReverseCalulation = isTaxReverseCalulation;
			this.isFreeOrder = isFreeOrder;
			this.isVAT = isVAT;
			this.isSVAT = isSVAT;
			this.branch_ID = branch_ID;
			this.deliveryAddress = deliveryAddress;
			this.quotationTerms = quotationTerms;
			this.bankAccount = bankAccount;
			this.itemPriceCategory = itemPriceCategory;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Quotation_ID value.
		/// </summary>
		public string Quotation_ID {
			get { return quotation_ID; }
			set { quotation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the QuotationDate value.
		/// </summary>
		public DateTime QuotationDate {
			get { return quotationDate; }
			set { quotationDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the ValiedPeriod value.
		/// </summary>
		public string ValiedPeriod {
			get { return valiedPeriod; }
			set { valiedPeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryPeriod value.
		/// </summary>
		public string DeliveryPeriod {
			get { return deliveryPeriod; }
			set { deliveryPeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentPeriod value.
		/// </summary>
		public string PaymentPeriod {
			get { return paymentPeriod; }
			set { paymentPeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the QuotationSubject value.
		/// </summary>
		public string QuotationSubject {
			get { return quotationSubject; }
			set { quotationSubject = value; }
		}
		
		/// <summary>
		/// Gets or sets the ContactLine_No value.
		/// </summary>
		public int ContactLine_No {
			get { return contactLine_No; }
			set { contactLine_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the ContactName value.
		/// </summary>
		public string ContactName {
			get { return contactName; }
			set { contactName = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo_ID value.
		/// </summary>
		public string OrderRefNo_ID {
			get { return orderRefNo_ID; }
			set { orderRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Inquiry_ID value.
		/// </summary>
		public string Inquiry_ID {
			get { return inquiry_ID; }
			set { inquiry_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the QuotationType_ID value.
		/// </summary>
		public string QuotationType_ID {
			get { return quotationType_ID; }
			set { quotationType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
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
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CurrencyRate value.
		/// </summary>
		public decimal CurrencyRate {
			get { return currencyRate; }
			set { currencyRate = value; }
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
		/// Gets or sets the RecommendedSubTotal value.
		/// </summary>
		public decimal RecommendedSubTotal {
			get { return recommendedSubTotal; }
			set { recommendedSubTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the RecommendedGrandTotal value.
		/// </summary>
		public decimal RecommendedGrandTotal {
			get { return recommendedGrandTotal; }
			set { recommendedGrandTotal = value; }
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
		/// Gets or sets the IsDoneProductionJob value.
		/// </summary>
		public bool IsDoneProductionJob {
			get { return isDoneProductionJob; }
			set { isDoneProductionJob = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSeattled value.
		/// </summary>
		public bool IsSeattled {
			get { return isSeattled; }
			set { isSeattled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeightCalculation value.
		/// </summary>
		public bool IsWeightCalculation {
			get { return isWeightCalculation; }
			set { isWeightCalculation = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTaxReverseCalulation value.
		/// </summary>
		public bool IsTaxReverseCalulation {
			get { return isTaxReverseCalulation; }
			set { isTaxReverseCalulation = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFreeOrder value.
		/// </summary>
		public bool IsFreeOrder {
			get { return isFreeOrder; }
			set { isFreeOrder = value; }
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
		/// Gets or sets the Branch_ID value.
		/// </summary>
		public string Branch_ID {
			get { return branch_ID; }
			set { branch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryAddress value.
		/// </summary>
		public string DeliveryAddress {
			get { return deliveryAddress; }
			set { deliveryAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the QuotationTerms value.
		/// </summary>
		public string QuotationTerms {
			get { return quotationTerms; }
			set { quotationTerms = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankAccount value.
		/// </summary>
		public string BankAccount {
			get { return bankAccount; }
			set { bankAccount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemPriceCategory value.
		/// </summary>
		public string ItemPriceCategory {
			get { return itemPriceCategory; }
			set { itemPriceCategory = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasQuotation table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotationDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@valiedPeriod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deliveryPeriod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@paymentPeriod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@quotationSubject", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactLine_No", SqlDbType.Int,4);
			scom.Parameters.Add("@contactName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotationType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@recommendedSubTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedGrandTotal", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@isDoneProductionJob", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isTaxReverseCalulation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFreeOrder", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryAddress", SqlDbType.VarChar,150);
			scom.Parameters.Add("@quotationTerms", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankAccount", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar,20);
 
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@quotationDate"].Value = quotationDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@valiedPeriod"].Value = valiedPeriod;
			scom.Parameters["@deliveryPeriod"].Value = deliveryPeriod;
			scom.Parameters["@paymentPeriod"].Value = paymentPeriod;
			scom.Parameters["@quotationSubject"].Value = quotationSubject;
			scom.Parameters["@contactLine_No"].Value = contactLine_No;
			scom.Parameters["@contactName"].Value = contactName;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@quotationType_ID"].Value = quotationType_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
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
			scom.Parameters["@recommendedSubTotal"].Value = recommendedSubTotal;
			scom.Parameters["@recommendedGrandTotal"].Value = recommendedGrandTotal;
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
			scom.Parameters["@isDoneProductionJob"].Value = isDoneProductionJob;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isTaxReverseCalulation"].Value = isTaxReverseCalulation;
			scom.Parameters["@isFreeOrder"].Value = isFreeOrder;
			scom.Parameters["@isVAT"].Value = isVAT;
			scom.Parameters["@isSVAT"].Value = isSVAT;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@deliveryAddress"].Value = deliveryAddress;
			scom.Parameters["@quotationTerms"].Value = quotationTerms;
			scom.Parameters["@bankAccount"].Value = bankAccount;
			scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasQuotation table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotationDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@valiedPeriod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deliveryPeriod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@paymentPeriod", SqlDbType.VarChar,50);
			scom.Parameters.Add("@quotationSubject", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactLine_No", SqlDbType.Int,4);
			scom.Parameters.Add("@contactName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotationType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@recommendedSubTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedGrandTotal", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@isDoneProductionJob", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isTaxReverseCalulation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFreeOrder", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryAddress", SqlDbType.VarChar,150);
			scom.Parameters.Add("@quotationTerms", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankAccount", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@quotationDate"].Value = quotationDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@valiedPeriod"].Value = valiedPeriod;
			scom.Parameters["@deliveryPeriod"].Value = deliveryPeriod;
			scom.Parameters["@paymentPeriod"].Value = paymentPeriod;
			scom.Parameters["@quotationSubject"].Value = quotationSubject;
			scom.Parameters["@contactLine_No"].Value = contactLine_No;
			scom.Parameters["@contactName"].Value = contactName;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@quotationType_ID"].Value = quotationType_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
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
			scom.Parameters["@recommendedSubTotal"].Value = recommendedSubTotal;
			scom.Parameters["@recommendedGrandTotal"].Value = recommendedGrandTotal;
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
			scom.Parameters["@isDoneProductionJob"].Value = isDoneProductionJob;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isTaxReverseCalulation"].Value = isTaxReverseCalulation;
			scom.Parameters["@isFreeOrder"].Value = isFreeOrder;
			scom.Parameters["@isVAT"].Value = isVAT;
			scom.Parameters["@isSVAT"].Value = isSVAT;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@deliveryAddress"].Value = deliveryAddress;
			scom.Parameters["@quotationTerms"].Value = quotationTerms;
			scom.Parameters["@bankAccount"].Value = bankAccount;
			scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasQuotation table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table by a foreign key.
		/// </summary>
		public static void DeleteAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationDeleteAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

        /// <summary>
        /// Selects all records from the tbl_sasQuotation table by a foreign key.
        /// </summary>
        public static void DeleteAllByInquiry_ID(string inquiry_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasQuotationDeleteAllByInquiry_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@inquiry_ID"].Value = inquiry_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table by a foreign key.
		/// </summary>
		public static void DeleteAllByQuotationType_ID(string quotationType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationDeleteAllByQuotationType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotationType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@quotationType_ID"].Value = quotationType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
						
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table by a foreign key.
		/// </summary>
		public static void DeleteAllByQuotationTerms(string quotationTerms) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationDeleteAllByQuotationTerms", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotationTerms", SqlDbType.VarChar,10);
			scom.Parameters["@quotationTerms"].Value = quotationTerms;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasQuotation table.
		/// </summary>
		public static tbl_sasQuotation Select(string quotation_ID_Incoming){

			tbl_sasQuotation tbl_sasQuotationins = new tbl_sasQuotation();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@quotation_ID"].Value = quotation_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasQuotationins = Maketbl_sasQuotation(dataReader);
				} else {
					tbl_sasQuotationins = null;
				}
			}
			scon.Close();
			return tbl_sasQuotationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table.
		/// </summary>
		public static List<tbl_sasQuotation> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasQuotation> tbl_sasQuotationList = new List<tbl_sasQuotation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasQuotation tbl_sasQuotation = Maketbl_sasQuotation(dataReader);
					tbl_sasQuotationList.Add(tbl_sasQuotation);
				}
			}
			scon.Close();
			return tbl_sasQuotationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table by a foreign key.
		/// </summary>
		public static List<tbl_sasQuotation> SelectAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationSelectAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
				List<tbl_sasQuotation> tbl_sasQuotationList = new List<tbl_sasQuotation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasQuotation tbl_sasQuotation = Maketbl_sasQuotation(dataReader);
					tbl_sasQuotationList.Add(tbl_sasQuotation);
				}
			}
			scon.Close();
			return tbl_sasQuotationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table by a foreign key.
		/// </summary>
		public static List<tbl_sasQuotation> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_sasQuotation> tbl_sasQuotationList = new List<tbl_sasQuotation>();

                using (SqlDataReader dataReader = scom.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        tbl_sasQuotation tbl_sasQuotation = Maketbl_sasQuotation(dataReader);
                        tbl_sasQuotationList.Add(tbl_sasQuotation);
                    }
                }
                scon.Close();
                return tbl_sasQuotationList;
        }
        /// <summary>
        /// Selects all records from the tbl_sasQuotation table by a foreign key.
        /// </summary>
        public static List<tbl_sasQuotation> SelectAllByInquiry_ID(string inquiry_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasQuotationSelectAllByInquiry_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
            List<tbl_sasQuotation> tbl_sasQuotationList = new List<tbl_sasQuotation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasQuotation tbl_sasQuotation = Maketbl_sasQuotation(dataReader);
					tbl_sasQuotationList.Add(tbl_sasQuotation);
				}
			}
			scon.Close();
			return tbl_sasQuotationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table by a foreign key.
		/// </summary>
		public static List<tbl_sasQuotation> SelectAllByQuotationType_ID(string quotationType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationSelectAllByQuotationType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotationType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@quotationType_ID"].Value = quotationType_ID;
				List<tbl_sasQuotation> tbl_sasQuotationList = new List<tbl_sasQuotation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasQuotation tbl_sasQuotation = Maketbl_sasQuotation(dataReader);
					tbl_sasQuotationList.Add(tbl_sasQuotation);
				}
			}
			scon.Close();
			return tbl_sasQuotationList;
		}
						
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table by a foreign key.
		/// </summary>
		public static List<tbl_sasQuotation> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_sasQuotation> tbl_sasQuotationList = new List<tbl_sasQuotation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasQuotation tbl_sasQuotation = Maketbl_sasQuotation(dataReader);
					tbl_sasQuotationList.Add(tbl_sasQuotation);
				}
			}
			scon.Close();
			return tbl_sasQuotationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation table by a foreign key.
		/// </summary>
		public static List<tbl_sasQuotation> SelectAllByQuotationTerms(string quotationTerms) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotationSelectAllByQuotationTerms", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotationTerms", SqlDbType.VarChar,10);
			scom.Parameters["@quotationTerms"].Value = quotationTerms;
				List<tbl_sasQuotation> tbl_sasQuotationList = new List<tbl_sasQuotation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasQuotation tbl_sasQuotation = Maketbl_sasQuotation(dataReader);
					tbl_sasQuotationList.Add(tbl_sasQuotation);
				}
			}
			scon.Close();
			return tbl_sasQuotationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasQuotation class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasQuotation Maketbl_sasQuotation(SqlDataReader dataReader) {
			tbl_sasQuotation tbl_sasQuotation = new tbl_sasQuotation();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasQuotation.Quotation_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasQuotation.QuotationDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasQuotation.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasQuotation.ValiedPeriod = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasQuotation.DeliveryPeriod = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasQuotation.PaymentPeriod = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasQuotation.QuotationSubject = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasQuotation.ContactLine_No = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasQuotation.ContactName = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasQuotation.OrderRefNo_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasQuotation.Customer_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasQuotation.Inquiry_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasQuotation.Job_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasQuotation.QuotationType_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasQuotation.Employee_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasQuotation.Currency_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasQuotation.GlPosting_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasQuotation.PostingStatus_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasQuotation.FinancialYear_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasQuotation.CompanyID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasQuotation.CompanyBranch_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasQuotation.CurrencyRate = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasQuotation.DiscountPercentage = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasQuotation.NbtPercentage = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_sasQuotation.VatPercentage = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_sasQuotation.OtherTaxPercentage = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_sasQuotation.SubTotal = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_sasQuotation.DiscountTotal = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_sasQuotation.NbtTotal = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_sasQuotation.VatTotal = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_sasQuotation.OtherTaxTotal = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_sasQuotation.GrandTotal = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_sasQuotation.RecommendedSubTotal = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_sasQuotation.RecommendedGrandTotal = dataReader.GetDecimal(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_sasQuotation.CreateUser_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_sasQuotation.ModifiedUser_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_sasQuotation.CheckedUser_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_sasQuotation.ApprovedUser_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_sasQuotation.DeletedUser_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_sasQuotation.PrintedUser_ID = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_sasQuotation.CreateTerminal_ID = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_sasQuotation.ModifiedTerminal_ID = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_sasQuotation.DeletedTerminal_ID = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_sasQuotation.PrintedTerminal_ID = dataReader.GetString(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_sasQuotation.DateCreate = dataReader.GetDateTime(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_sasQuotation.DateModified = dataReader.GetDateTime(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_sasQuotation.DateChecked = dataReader.GetDateTime(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_sasQuotation.DateApproved = dataReader.GetDateTime(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_sasQuotation.DateDeleted = dataReader.GetDateTime(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_sasQuotation.DatePrinted = dataReader.GetDateTime(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_sasQuotation.IsChecked = dataReader.GetBoolean(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_sasQuotation.IsApproved = dataReader.GetBoolean(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_sasQuotation.IsFinished = dataReader.GetBoolean(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_sasQuotation.IsDeleted = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_sasQuotation.IsLocked = dataReader.GetBoolean(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_sasQuotation.IsDoneProductionJob = dataReader.GetBoolean(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_sasQuotation.IsSeattled = dataReader.GetBoolean(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_sasQuotation.IsWeightCalculation = dataReader.GetBoolean(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_sasQuotation.PrintCount = dataReader.GetInt32(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_sasQuotation.IsTaxReverseCalulation = dataReader.GetBoolean(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_sasQuotation.IsFreeOrder = dataReader.GetBoolean(60);
			}
			if (dataReader.IsDBNull(61) == false) {
				tbl_sasQuotation.IsVAT = dataReader.GetBoolean(61);
			}
			if (dataReader.IsDBNull(62) == false) {
				tbl_sasQuotation.IsSVAT = dataReader.GetBoolean(62);
			}
			if (dataReader.IsDBNull(63) == false) {
				tbl_sasQuotation.Branch_ID = dataReader.GetString(63);
			}
			if (dataReader.IsDBNull(64) == false) {
				tbl_sasQuotation.DeliveryAddress = dataReader.GetString(64);
			}
			if (dataReader.IsDBNull(65) == false) {
				tbl_sasQuotation.QuotationTerms = dataReader.GetString(65);
			}
			if (dataReader.IsDBNull(66) == false) {
				tbl_sasQuotation.BankAccount = dataReader.GetString(66);
			}
			if (dataReader.IsDBNull(67) == false) {
				tbl_sasQuotation.ItemPriceCategory = dataReader.GetString(67);
			}

			return tbl_sasQuotation;
		}
		/// <summary>
		/// This makes tbl_sasQuotation datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasQuotation object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasQuotation  tbl_sasQuotation   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_quotation_ID = new DataColumn("quotation_ID" , typeof(string));
			DataColumn col_quotationDate = new DataColumn("quotationDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_valiedPeriod = new DataColumn("valiedPeriod" , typeof(string));
			DataColumn col_deliveryPeriod = new DataColumn("deliveryPeriod" , typeof(string));
			DataColumn col_paymentPeriod = new DataColumn("paymentPeriod" , typeof(string));
			DataColumn col_quotationSubject = new DataColumn("quotationSubject" , typeof(string));
			DataColumn col_contactLine_No = new DataColumn("contactLine_No" , typeof(int));
			DataColumn col_contactName = new DataColumn("contactName" , typeof(string));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_inquiry_ID = new DataColumn("inquiry_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_quotationType_ID = new DataColumn("quotationType_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
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
			DataColumn col_recommendedSubTotal = new DataColumn("recommendedSubTotal" , typeof(decimal));
			DataColumn col_recommendedGrandTotal = new DataColumn("recommendedGrandTotal" , typeof(decimal));
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
			DataColumn col_isDoneProductionJob = new DataColumn("isDoneProductionJob" , typeof(bool));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_isTaxReverseCalulation = new DataColumn("isTaxReverseCalulation" , typeof(bool));
			DataColumn col_isFreeOrder = new DataColumn("isFreeOrder" , typeof(bool));
			DataColumn col_isVAT = new DataColumn("isVAT" , typeof(bool));
			DataColumn col_isSVAT = new DataColumn("isSVAT" , typeof(bool));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_deliveryAddress = new DataColumn("deliveryAddress" , typeof(string));
			DataColumn col_quotationTerms = new DataColumn("quotationTerms" , typeof(string));
			DataColumn col_bankAccount = new DataColumn("bankAccount" , typeof(string));
			DataColumn col_itemPriceCategory = new DataColumn("itemPriceCategory" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_quotation_ID,col_quotationDate,col_remark,col_valiedPeriod,col_deliveryPeriod,col_paymentPeriod,col_quotationSubject,col_contactLine_No,col_contactName,col_orderRefNo_ID,col_customer_ID,col_inquiry_ID,col_job_ID,col_quotationType_ID,col_employee_ID,col_currency_ID,col_glPosting_ID,col_postingStatus_ID,col_financialYear_ID,col_companyID,col_companyBranch_ID,col_currencyRate,col_discountPercentage,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grandTotal,col_recommendedSubTotal,col_recommendedGrandTotal,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isDoneProductionJob,col_isSeattled,col_isWeightCalculation,col_printCount,col_isTaxReverseCalulation,col_isFreeOrder,col_isVAT,col_isSVAT,col_branch_ID,col_deliveryAddress,col_quotationTerms,col_bankAccount,col_itemPriceCategory,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasQuotation datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasQuotation object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasQuotation user) {
		DataRow drow = dt.NewRow();
		
			drow["quotation_ID"] = user.quotation_ID;
			drow["quotationDate"] = user.quotationDate;
			drow["remark"] = user.remark;
			drow["valiedPeriod"] = user.valiedPeriod;
			drow["deliveryPeriod"] = user.deliveryPeriod;
			drow["paymentPeriod"] = user.paymentPeriod;
			drow["quotationSubject"] = user.quotationSubject;
			drow["contactLine_No"] = user.contactLine_No;
			drow["contactName"] = user.contactName;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["inquiry_ID"] = user.inquiry_ID;
			drow["job_ID"] = user.job_ID;
			drow["quotationType_ID"] = user.quotationType_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["currencyRate"] = user.currencyRate;
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
			drow["recommendedSubTotal"] = user.recommendedSubTotal;
			drow["recommendedGrandTotal"] = user.recommendedGrandTotal;
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
			drow["isDoneProductionJob"] = user.isDoneProductionJob;
			drow["isSeattled"] = user.isSeattled;
			drow["isWeightCalculation"] = user.isWeightCalculation;
			drow["printCount"] = user.printCount;
			drow["isTaxReverseCalulation"] = user.isTaxReverseCalulation;
			drow["isFreeOrder"] = user.isFreeOrder;
			drow["isVAT"] = user.isVAT;
			drow["isSVAT"] = user.isSVAT;
			drow["branch_ID"] = user.branch_ID;
			drow["deliveryAddress"] = user.deliveryAddress;
			drow["quotationTerms"] = user.quotationTerms;
			drow["bankAccount"] = user.bankAccount;
			drow["itemPriceCategory"] = user.itemPriceCategory;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
