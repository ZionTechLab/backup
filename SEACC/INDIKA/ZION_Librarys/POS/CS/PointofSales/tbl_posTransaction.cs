using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataTire {
	public sealed class tbl_posTransaction {
		#region Fields
		private int posTransaction_Index;
		private string posTransaction_ID;
		private DateTime posTransactiondate;
		private string remark;
		private string customer_ID;
		private string customerName;
		private string salesRep_ID;
		private string store_ID;
		private string orderRefNo_ID;
		private string itemPriceCategory;
		private string salesNoteType_ID;
		private string currency_ID;
		private decimal currencyRate;
		private decimal discountPercentage;
		private decimal discountPercentage1;
		private decimal discountPercentage2;
		private decimal discountPercentage3;
		private decimal nbtPercentage;
		private decimal vatPercentage;
		private decimal otherTaxPercentage;
		private decimal subTotal;
		private decimal discountTotal;
		private decimal discountTotal1;
		private decimal discountTotal2;
		private decimal discountTotal3;
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
		private int printCount;
		private bool isChecked;
		private bool isApproved;
		private bool isHold;
		private bool isFinished;
		private bool isDeleted;
		private decimal isWeightCalculation;
		private decimal seattleAmount;
		private bool isSeattled;
		private string companyID;
		private string companyBranch_ID;
		private int creditPeriod_Days;
		private string greetingDescription;
		private int dayDetail_Index;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string financialYear_ID;
		private bool isReturnedPOS_Invoice;
		private bool isGV_POS_invoice;
		private bool isIncompleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_posTransaction class.
		/// </summary>
		public tbl_posTransaction() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_posTransaction class.
		/// </summary>
		public tbl_posTransaction(int posTransaction_Index, string posTransaction_ID, DateTime posTransactiondate, string remark, string customer_ID, string customerName, string salesRep_ID, string store_ID, string orderRefNo_ID, string itemPriceCategory, string salesNoteType_ID, string currency_ID, decimal currencyRate, decimal discountPercentage, decimal discountPercentage1, decimal discountPercentage2, decimal discountPercentage3, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal discountTotal1, decimal discountTotal2, decimal discountTotal3, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, int printCount, bool isChecked, bool isApproved, bool isHold, bool isFinished, bool isDeleted, decimal isWeightCalculation, decimal seattleAmount, bool isSeattled, string companyID, string companyBranch_ID, int creditPeriod_Days, string greetingDescription, int dayDetail_Index, string glPosting_ID, string postingStatus_ID, string financialYear_ID, bool isReturnedPOS_Invoice, bool isGV_POS_invoice, bool isIncompleted) {
			this.posTransaction_Index = posTransaction_Index;
			this.posTransaction_ID = posTransaction_ID;
			this.posTransactiondate = posTransactiondate;
			this.remark = remark;
			this.customer_ID = customer_ID;
			this.customerName = customerName;
			this.salesRep_ID = salesRep_ID;
			this.store_ID = store_ID;
			this.orderRefNo_ID = orderRefNo_ID;
			this.itemPriceCategory = itemPriceCategory;
			this.salesNoteType_ID = salesNoteType_ID;
			this.currency_ID = currency_ID;
			this.currencyRate = currencyRate;
			this.discountPercentage = discountPercentage;
			this.discountPercentage1 = discountPercentage1;
			this.discountPercentage2 = discountPercentage2;
			this.discountPercentage3 = discountPercentage3;
			this.nbtPercentage = nbtPercentage;
			this.vatPercentage = vatPercentage;
			this.otherTaxPercentage = otherTaxPercentage;
			this.subTotal = subTotal;
			this.discountTotal = discountTotal;
			this.discountTotal1 = discountTotal1;
			this.discountTotal2 = discountTotal2;
			this.discountTotal3 = discountTotal3;
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
			this.printCount = printCount;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isHold = isHold;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isWeightCalculation = isWeightCalculation;
			this.seattleAmount = seattleAmount;
			this.isSeattled = isSeattled;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.creditPeriod_Days = creditPeriod_Days;
			this.greetingDescription = greetingDescription;
			this.dayDetail_Index = dayDetail_Index;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.financialYear_ID = financialYear_ID;
			this.isReturnedPOS_Invoice = isReturnedPOS_Invoice;
			this.isGV_POS_invoice = isGV_POS_invoice;
			this.isIncompleted = isIncompleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PosTransaction_Index value.
		/// </summary>
		public int PosTransaction_Index {
			get { return posTransaction_Index; }
			set { posTransaction_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosTransaction_ID value.
		/// </summary>
		public string PosTransaction_ID {
			get { return posTransaction_ID; }
			set { posTransaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosTransactiondate value.
		/// </summary>
		public DateTime PosTransactiondate {
			get { return posTransactiondate; }
			set { posTransactiondate = value; }
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
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesRep_ID value.
		/// </summary>
		public string SalesRep_ID {
			get { return salesRep_ID; }
			set { salesRep_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo_ID value.
		/// </summary>
		public string OrderRefNo_ID {
			get { return orderRefNo_ID; }
			set { orderRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemPriceCategory value.
		/// </summary>
		public string ItemPriceCategory {
			get { return itemPriceCategory; }
			set { itemPriceCategory = value; }
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
		/// Gets or sets the DiscountPercentage value.
		/// </summary>
		public decimal DiscountPercentage {
			get { return discountPercentage; }
			set { discountPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPercentage1 value.
		/// </summary>
		public decimal DiscountPercentage1 {
			get { return discountPercentage1; }
			set { discountPercentage1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPercentage2 value.
		/// </summary>
		public decimal DiscountPercentage2 {
			get { return discountPercentage2; }
			set { discountPercentage2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPercentage3 value.
		/// </summary>
		public decimal DiscountPercentage3 {
			get { return discountPercentage3; }
			set { discountPercentage3 = value; }
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
		/// Gets or sets the DiscountTotal1 value.
		/// </summary>
		public decimal DiscountTotal1 {
			get { return discountTotal1; }
			set { discountTotal1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountTotal2 value.
		/// </summary>
		public decimal DiscountTotal2 {
			get { return discountTotal2; }
			set { discountTotal2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountTotal3 value.
		/// </summary>
		public decimal DiscountTotal3 {
			get { return discountTotal3; }
			set { discountTotal3 = value; }
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
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
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
		/// Gets or sets the IsHold value.
		/// </summary>
		public bool IsHold {
			get { return isHold; }
			set { isHold = value; }
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
		/// Gets or sets the IsWeightCalculation value.
		/// </summary>
		public decimal IsWeightCalculation {
			get { return isWeightCalculation; }
			set { isWeightCalculation = value; }
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
		/// Gets or sets the CreditPeriod_Days value.
		/// </summary>
		public int CreditPeriod_Days {
			get { return creditPeriod_Days; }
			set { creditPeriod_Days = value; }
		}
		
		/// <summary>
		/// Gets or sets the GreetingDescription value.
		/// </summary>
		public string GreetingDescription {
			get { return greetingDescription; }
			set { greetingDescription = value; }
		}
		
		/// <summary>
		/// Gets or sets the DayDetail_Index value.
		/// </summary>
		public int DayDetail_Index {
			get { return dayDetail_Index; }
			set { dayDetail_Index = value; }
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
		/// Gets or sets the IsReturnedPOS_Invoice value.
		/// </summary>
		public bool IsReturnedPOS_Invoice {
			get { return isReturnedPOS_Invoice; }
			set { isReturnedPOS_Invoice = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsGV_POS_invoice value.
		/// </summary>
		public bool IsGV_POS_invoice {
			get { return isGV_POS_invoice; }
			set { isGV_POS_invoice = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsIncompleted value.
		/// </summary>
		public bool IsIncompleted {
			get { return isIncompleted; }
			set { isIncompleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_posTransaction table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransactionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posTransactiondate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,200);
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal3", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isHold", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Decimal,9);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditPeriod_Days", SqlDbType.Int,4);
			scom.Parameters.Add("@greetingDescription", SqlDbType.VarChar,200);
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isReturnedPOS_Invoice", SqlDbType.Bit,1);
			scom.Parameters.Add("@isGV_POS_invoice", SqlDbType.Bit,1);
			scom.Parameters.Add("@isIncompleted", SqlDbType.Bit,1);
 
			scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index;
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
			scom.Parameters["@posTransactiondate"].Value = posTransactiondate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@discountPercentage1"].Value = discountPercentage1;
			scom.Parameters["@discountPercentage2"].Value = discountPercentage2;
			scom.Parameters["@discountPercentage3"].Value = discountPercentage3;
			scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
			scom.Parameters["@vatPercentage"].Value = vatPercentage;
			scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@discountTotal1"].Value = discountTotal1;
			scom.Parameters["@discountTotal2"].Value = discountTotal2;
			scom.Parameters["@discountTotal3"].Value = discountTotal3;
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
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isHold"].Value = isHold;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@creditPeriod_Days"].Value = creditPeriod_Days;
			scom.Parameters["@greetingDescription"].Value = greetingDescription;
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@isReturnedPOS_Invoice"].Value = isReturnedPOS_Invoice;
			scom.Parameters["@isGV_POS_invoice"].Value = isGV_POS_invoice;
			scom.Parameters["@isIncompleted"].Value = isIncompleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_posTransaction table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransactionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posTransactiondate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,200);
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal3", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isHold", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Decimal,9);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@creditPeriod_Days", SqlDbType.Int,4);
			scom.Parameters.Add("@greetingDescription", SqlDbType.VarChar,200);
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isReturnedPOS_Invoice", SqlDbType.Bit,1);
			scom.Parameters.Add("@isGV_POS_invoice", SqlDbType.Bit,1);
			scom.Parameters.Add("@isIncompleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index;
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
			scom.Parameters["@posTransactiondate"].Value = posTransactiondate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@customerName"].Value = customerName;
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@discountPercentage1"].Value = discountPercentage1;
			scom.Parameters["@discountPercentage2"].Value = discountPercentage2;
			scom.Parameters["@discountPercentage3"].Value = discountPercentage3;
			scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
			scom.Parameters["@vatPercentage"].Value = vatPercentage;
			scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@discountTotal1"].Value = discountTotal1;
			scom.Parameters["@discountTotal2"].Value = discountTotal2;
			scom.Parameters["@discountTotal3"].Value = discountTotal3;
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
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isHold"].Value = isHold;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@creditPeriod_Days"].Value = creditPeriod_Days;
			scom.Parameters["@greetingDescription"].Value = greetingDescription;
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@isReturnedPOS_Invoice"].Value = isReturnedPOS_Invoice;
			scom.Parameters["@isGV_POS_invoice"].Value = isGV_POS_invoice;
			scom.Parameters["@isIncompleted"].Value = isIncompleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_posTransaction table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransactionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int,4);
			scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

        public static List<tbl_posTransaction> SelectAllByDayDetail_Index(int dayDetail_Index)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_posTransactionSelectAllByDayDetail_Index", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int, 4);
            scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
            List<tbl_posTransaction> tbl_posTransactionList = new List<tbl_posTransaction>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_posTransaction tbl_posTransaction = Maketbl_posTransaction(dataReader);
                    tbl_posTransactionList.Add(tbl_posTransaction);
                }
            }
            scon.Close();
            return tbl_posTransactionList;
        }

        /// <summary>
        /// Selects a single record from the tbl_posTransaction table.
        /// </summary>
        public static tbl_posTransaction Select(int posTransaction_Index_Incoming){

			tbl_posTransaction tbl_posTransactionins = new tbl_posTransaction();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransactionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int,4);
			scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_posTransactionins = Maketbl_posTransaction(dataReader);
				} else {
					tbl_posTransactionins = null;
				}
			}
			scon.Close();
			return tbl_posTransactionins;
		}

        public static tbl_posTransaction Select(string posTransaction_ID)
        {
            tbl_posTransaction oSelectedTx = SelectAll().FirstOrDefault(r => r.PosTransaction_ID == posTransaction_ID);
            return oSelectedTx;
        }

        public static List<tbl_posTransaction> SelectAllByCompanyID(string companyID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_posTransactionSelectAllByCompanyID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
            scom.Parameters["@companyID"].Value = companyID;
            List<tbl_posTransaction> tbl_posTransactionList = new List<tbl_posTransaction>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_posTransaction tbl_posTransaction = Maketbl_posTransaction(dataReader);
                    tbl_posTransactionList.Add(tbl_posTransaction);
                }
            }
            scon.Close();
            return tbl_posTransactionList;
        }

        public static List<tbl_posTransaction> SelectAllByCompanyBranch_ID(string companyBranch_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_posTransactionSelectAllByCompanyBranch_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            List<tbl_posTransaction> tbl_posTransactionList = new List<tbl_posTransaction>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_posTransaction tbl_posTransaction = Maketbl_posTransaction(dataReader);
                    tbl_posTransactionList.Add(tbl_posTransaction);
                }
            }
            scon.Close();
            return tbl_posTransactionList;
        }

        public static List<tbl_posTransaction> SelectAllByCustomer_ID(string customer_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_posTransactionSelectAllByCustomer_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@customer_ID"].Value = customer_ID;
            List<tbl_posTransaction> tbl_posTransactionList = new List<tbl_posTransaction>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_posTransaction tbl_posTransaction = Maketbl_posTransaction(dataReader);
                    tbl_posTransactionList.Add(tbl_posTransaction);
                }
            }
            scon.Close();
            return tbl_posTransactionList;
        }

        /// <summary>
        /// Selects all records from the tbl_posTransaction table.
        /// </summary>
        public static List<tbl_posTransaction> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransactionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_posTransaction> tbl_posTransactionList = new List<tbl_posTransaction>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posTransaction tbl_posTransaction = Maketbl_posTransaction(dataReader);
					tbl_posTransactionList.Add(tbl_posTransaction);
				}
			}
			scon.Close();
			return tbl_posTransactionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_posTransaction class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_posTransaction Maketbl_posTransaction(SqlDataReader dataReader) {
			tbl_posTransaction tbl_posTransaction = new tbl_posTransaction();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_posTransaction.PosTransaction_Index = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_posTransaction.PosTransaction_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_posTransaction.PosTransactiondate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_posTransaction.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_posTransaction.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_posTransaction.CustomerName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_posTransaction.SalesRep_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_posTransaction.Store_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_posTransaction.OrderRefNo_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_posTransaction.ItemPriceCategory = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_posTransaction.SalesNoteType_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_posTransaction.Currency_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_posTransaction.CurrencyRate = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_posTransaction.DiscountPercentage = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_posTransaction.DiscountPercentage1 = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_posTransaction.DiscountPercentage2 = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_posTransaction.DiscountPercentage3 = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_posTransaction.NbtPercentage = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_posTransaction.VatPercentage = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_posTransaction.OtherTaxPercentage = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_posTransaction.SubTotal = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_posTransaction.DiscountTotal = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_posTransaction.DiscountTotal1 = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_posTransaction.DiscountTotal2 = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_posTransaction.DiscountTotal3 = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_posTransaction.NbtTotal = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_posTransaction.VatTotal = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_posTransaction.OtherTaxTotal = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_posTransaction.GrandTotal = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_posTransaction.CreateUser_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_posTransaction.ModifiedUser_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_posTransaction.CheckedUser_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_posTransaction.ApprovedUser_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_posTransaction.DeletedUser_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_posTransaction.PrintedUser_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_posTransaction.CreateTerminal_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_posTransaction.ModifiedTerminal_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_posTransaction.DeletedTerminal_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_posTransaction.PrintedTerminal_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_posTransaction.DateCreate = dataReader.GetDateTime(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_posTransaction.DateModified = dataReader.GetDateTime(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_posTransaction.DateChecked = dataReader.GetDateTime(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_posTransaction.DateApproved = dataReader.GetDateTime(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_posTransaction.DateDeleted = dataReader.GetDateTime(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_posTransaction.DatePrinted = dataReader.GetDateTime(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_posTransaction.PrintCount = dataReader.GetInt32(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_posTransaction.IsChecked = dataReader.GetBoolean(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_posTransaction.IsApproved = dataReader.GetBoolean(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_posTransaction.IsHold = dataReader.GetBoolean(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_posTransaction.IsFinished = dataReader.GetBoolean(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_posTransaction.IsDeleted = dataReader.GetBoolean(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_posTransaction.IsWeightCalculation = dataReader.GetDecimal(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_posTransaction.SeattleAmount = dataReader.GetDecimal(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_posTransaction.IsSeattled = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_posTransaction.CompanyID = dataReader.GetString(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_posTransaction.CompanyBranch_ID = dataReader.GetString(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_posTransaction.CreditPeriod_Days = dataReader.GetInt32(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_posTransaction.GreetingDescription = dataReader.GetString(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_posTransaction.DayDetail_Index = dataReader.GetInt32(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_posTransaction.GlPosting_ID = dataReader.GetString(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_posTransaction.PostingStatus_ID = dataReader.GetString(60);
			}
			if (dataReader.IsDBNull(61) == false) {
				tbl_posTransaction.FinancialYear_ID = dataReader.GetString(61);
			}
			if (dataReader.IsDBNull(62) == false) {
				tbl_posTransaction.IsReturnedPOS_Invoice = dataReader.GetBoolean(62);
			}
			if (dataReader.IsDBNull(63) == false) {
				tbl_posTransaction.IsGV_POS_invoice = dataReader.GetBoolean(63);
			}
			if (dataReader.IsDBNull(64) == false) {
				tbl_posTransaction.IsIncompleted = dataReader.GetBoolean(64);
			}

			return tbl_posTransaction;
		}
		/// <summary>
		/// This makes tbl_posTransaction datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_posTransaction object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_posTransaction  tbl_posTransaction   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_posTransaction_Index = new DataColumn("posTransaction_Index" , typeof(int));
			DataColumn col_posTransaction_ID = new DataColumn("posTransaction_ID" , typeof(string));
			DataColumn col_posTransactiondate = new DataColumn("posTransactiondate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
			DataColumn col_salesRep_ID = new DataColumn("salesRep_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_itemPriceCategory = new DataColumn("itemPriceCategory" , typeof(string));
			DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_discountPercentage = new DataColumn("discountPercentage" , typeof(decimal));
			DataColumn col_discountPercentage1 = new DataColumn("discountPercentage1" , typeof(decimal));
			DataColumn col_discountPercentage2 = new DataColumn("discountPercentage2" , typeof(decimal));
			DataColumn col_discountPercentage3 = new DataColumn("discountPercentage3" , typeof(decimal));
			DataColumn col_nbtPercentage = new DataColumn("nbtPercentage" , typeof(decimal));
			DataColumn col_vatPercentage = new DataColumn("vatPercentage" , typeof(decimal));
			DataColumn col_otherTaxPercentage = new DataColumn("otherTaxPercentage" , typeof(decimal));
			DataColumn col_subTotal = new DataColumn("subTotal" , typeof(decimal));
			DataColumn col_discountTotal = new DataColumn("discountTotal" , typeof(decimal));
			DataColumn col_discountTotal1 = new DataColumn("discountTotal1" , typeof(decimal));
			DataColumn col_discountTotal2 = new DataColumn("discountTotal2" , typeof(decimal));
			DataColumn col_discountTotal3 = new DataColumn("discountTotal3" , typeof(decimal));
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
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isHold = new DataColumn("isHold" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation" , typeof(decimal));
			DataColumn col_seattleAmount = new DataColumn("seattleAmount" , typeof(decimal));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_creditPeriod_Days = new DataColumn("creditPeriod_Days" , typeof(int));
			DataColumn col_greetingDescription = new DataColumn("greetingDescription" , typeof(string));
			DataColumn col_dayDetail_Index = new DataColumn("dayDetail_Index" , typeof(int));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_isReturnedPOS_Invoice = new DataColumn("isReturnedPOS_Invoice" , typeof(bool));
			DataColumn col_isGV_POS_invoice = new DataColumn("isGV_POS_invoice" , typeof(bool));
			DataColumn col_isIncompleted = new DataColumn("isIncompleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_posTransaction_Index,col_posTransaction_ID,col_posTransactiondate,col_remark,col_customer_ID,col_customerName,col_salesRep_ID,col_store_ID,col_orderRefNo_ID,col_itemPriceCategory,col_salesNoteType_ID,col_currency_ID,col_currencyRate,col_discountPercentage,col_discountPercentage1,col_discountPercentage2,col_discountPercentage3,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_discountTotal1,col_discountTotal2,col_discountTotal3,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grandTotal,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_printCount,col_isChecked,col_isApproved,col_isHold,col_isFinished,col_isDeleted,col_isWeightCalculation,col_seattleAmount,col_isSeattled,col_companyID,col_companyBranch_ID,col_creditPeriod_Days,col_greetingDescription,col_dayDetail_Index,col_glPosting_ID,col_postingStatus_ID,col_financialYear_ID,col_isReturnedPOS_Invoice,col_isGV_POS_invoice,col_isIncompleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_posTransaction datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_posTransaction object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_posTransaction user) {
		DataRow drow = dt.NewRow();
		
			drow["posTransaction_Index"] = user.posTransaction_Index;
			drow["posTransaction_ID"] = user.posTransaction_ID;
			drow["posTransactiondate"] = user.posTransactiondate;
			drow["remark"] = user.remark;
			drow["customer_ID"] = user.customer_ID;
			drow["customerName"] = user.customerName;
			drow["salesRep_ID"] = user.salesRep_ID;
			drow["store_ID"] = user.store_ID;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["itemPriceCategory"] = user.itemPriceCategory;
			drow["salesNoteType_ID"] = user.salesNoteType_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["discountPercentage"] = user.discountPercentage;
			drow["discountPercentage1"] = user.discountPercentage1;
			drow["discountPercentage2"] = user.discountPercentage2;
			drow["discountPercentage3"] = user.discountPercentage3;
			drow["nbtPercentage"] = user.nbtPercentage;
			drow["vatPercentage"] = user.vatPercentage;
			drow["otherTaxPercentage"] = user.otherTaxPercentage;
			drow["subTotal"] = user.subTotal;
			drow["discountTotal"] = user.discountTotal;
			drow["discountTotal1"] = user.discountTotal1;
			drow["discountTotal2"] = user.discountTotal2;
			drow["discountTotal3"] = user.discountTotal3;
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
			drow["printCount"] = user.printCount;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isHold"] = user.isHold;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isWeightCalculation"] = user.isWeightCalculation;
			drow["seattleAmount"] = user.seattleAmount;
			drow["isSeattled"] = user.isSeattled;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["creditPeriod_Days"] = user.creditPeriod_Days;
			drow["greetingDescription"] = user.greetingDescription;
			drow["dayDetail_Index"] = user.dayDetail_Index;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["isReturnedPOS_Invoice"] = user.isReturnedPOS_Invoice;
			drow["isGV_POS_invoice"] = user.isGV_POS_invoice;
			drow["isIncompleted"] = user.isIncompleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
