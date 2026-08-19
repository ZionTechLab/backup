using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesReturnedNote {
		#region Fields
		private string salesReturnedNote_ID;
		private DateTime salesReturnedNoteDate;
		private string remark;
		private string invoice_ID;
		private string customer_ID;
		private string deliveryOrder_ID;
		private string orderRefNo_ID;
		private string creditNote_ID;
		private string store_ID;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string financialYear_ID;
		private string currency_ID;
		private string salesNoteType_ID;
		private decimal currencyRate;
		private decimal financeCharges;
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
		private bool isTaxReverseCalulation;
		private bool isReturnable;
		private bool isRefundable;
		private bool isExcess;
		private string branch_ID;
		private bool isEntryError;
		private string companyID;
		private string companyBranch_ID;
		private string itemPriceCategory;
		private int route_ID;
		public bool isNewReturn;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesReturnedNote class.
		/// </summary>
		public tbl_sasSalesReturnedNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesReturnedNote class.
		/// </summary>
		public tbl_sasSalesReturnedNote(string salesReturnedNote_ID, DateTime salesReturnedNoteDate, string remark, string invoice_ID, string customer_ID, string deliveryOrder_ID, string orderRefNo_ID, string creditNote_ID, string store_ID, string glPosting_ID, string postingStatus_ID, string financialYear_ID, string currency_ID, string salesNoteType_ID, decimal currencyRate, decimal financeCharges, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, decimal seattleAmount, bool isSeattled, int printCount, bool isWeightCalculation, bool isTaxReverseCalulation, bool isReturnable, bool isRefundable, bool isExcess, string branch_ID, bool isEntryError, string companyID, string companyBranch_ID, string itemPriceCategory, int route_ID,bool isNewReturn) {
			this.salesReturnedNote_ID = salesReturnedNote_ID;
			this.salesReturnedNoteDate = salesReturnedNoteDate;
			this.remark = remark;
			this.invoice_ID = invoice_ID;
			this.customer_ID = customer_ID;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.orderRefNo_ID = orderRefNo_ID;
			this.creditNote_ID = creditNote_ID;
			this.store_ID = store_ID;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.financialYear_ID = financialYear_ID;
			this.currency_ID = currency_ID;
			this.salesNoteType_ID = salesNoteType_ID;
			this.currencyRate = currencyRate;
			this.financeCharges = financeCharges;
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
			this.isTaxReverseCalulation = isTaxReverseCalulation;
			this.isReturnable = isReturnable;
			this.isRefundable = isRefundable;
			this.isExcess = isExcess;
			this.branch_ID = branch_ID;
			this.isEntryError = isEntryError;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.itemPriceCategory = itemPriceCategory;
			this.route_ID = route_ID;
			this.isNewReturn = isNewReturn;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SalesReturnedNote_ID value.
		/// </summary>
		public string SalesReturnedNote_ID {
			get { return salesReturnedNote_ID; }
			set { salesReturnedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesReturnedNoteDate value.
		/// </summary>
		public DateTime SalesReturnedNoteDate {
			get { return salesReturnedNoteDate; }
			set { salesReturnedNoteDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
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
		/// Gets or sets the CreditNote_ID value.
		/// </summary>
		public string CreditNote_ID {
			get { return creditNote_ID; }
			set { creditNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
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
		/// Gets or sets the SalesNoteType_ID value.
		/// </summary>
		public string SalesNoteType_ID {
			get { return salesNoteType_ID; }
			set { salesNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CurrencyRate value.
		/// </summary>
		public decimal CurrencyRate {
			get { return currencyRate; }
			set { currencyRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinanceCharges value.
		/// </summary>
		public decimal FinanceCharges {
			get { return financeCharges; }
			set { financeCharges = value; }
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
		/// Gets or sets the IsTaxReverseCalulation value.
		/// </summary>
		public bool IsTaxReverseCalulation {
			get { return isTaxReverseCalulation; }
			set { isTaxReverseCalulation = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReturnable value.
		/// </summary>
		public bool IsReturnable {
			get { return isReturnable; }
			set { isReturnable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRefundable value.
		/// </summary>
		public bool IsRefundable {
			get { return isRefundable; }
			set { isRefundable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsExcess value.
		/// </summary>
		public bool IsExcess {
			get { return isExcess; }
			set { isExcess = value; }
		}
		
		/// <summary>
		/// Gets or sets the Branch_ID value.
		/// </summary>
		public string Branch_ID {
			get { return branch_ID; }
			set { branch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEntryError value.
		/// </summary>
		public bool IsEntryError {
			get { return isEntryError; }
			set { isEntryError = value; }
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
		/// Gets or sets the ItemPriceCategory value.
		/// </summary>
		public string ItemPriceCategory {
			get { return itemPriceCategory; }
			set { itemPriceCategory = value; }
		}
		
		/// <summary>
		/// Gets or sets the Route_ID value.
		/// </summary>
		public int Route_ID {
			get { return route_ID; }
			set { route_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesReturnedNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesReturnedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@FinanceCharges", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@isTaxReverseCalulation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRefundable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isExcess", SqlDbType.Bit,1);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isEntryError", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar,20);
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isNewReturn", SqlDbType.Bit, 1);

			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@salesReturnedNoteDate"].Value = salesReturnedNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@FinanceCharges"].Value = financeCharges;
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
			scom.Parameters["@isTaxReverseCalulation"].Value = isTaxReverseCalulation;
			scom.Parameters["@isReturnable"].Value = isReturnable;
			scom.Parameters["@isRefundable"].Value = isRefundable;
			scom.Parameters["@isExcess"].Value = isExcess;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@isEntryError"].Value = isEntryError;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@isNewReturn"].Value = isNewReturn;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesReturnedNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesReturnedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@creditNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@FinanceCharges", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@isTaxReverseCalulation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRefundable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isExcess", SqlDbType.Bit,1);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isEntryError", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar,20);
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isNewReturn", SqlDbType.Bit, 1);

			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@salesReturnedNoteDate"].Value = salesReturnedNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@creditNote_ID"].Value = creditNote_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@FinanceCharges"].Value = financeCharges;
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
			scom.Parameters["@isTaxReverseCalulation"].Value = isTaxReverseCalulation;
			scom.Parameters["@isReturnable"].Value = isReturnable;
			scom.Parameters["@isRefundable"].Value = isRefundable;
			scom.Parameters["@isExcess"].Value = isExcess;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@isEntryError"].Value = isEntryError;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@isNewReturn"].Value = isNewReturn;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesReturnedNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteDeleteAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteDeleteAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(int route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasSalesReturnedNote table.
		/// </summary>
		public static tbl_sasSalesReturnedNote Select(string salesReturnedNote_ID_Incoming){

			tbl_sasSalesReturnedNote tbl_sasSalesReturnedNoteins = new tbl_sasSalesReturnedNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasSalesReturnedNoteins = Maketbl_sasSalesReturnedNote(dataReader);
				} else {
					tbl_sasSalesReturnedNoteins = null;
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table.
		/// </summary>
		public static List<tbl_sasSalesReturnedNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
					tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNoteList;
		}
        public static List<tbl_sasSalesReturnedNote> SelectForReport(DateTime FromDate,DateTime ToDate,string CurrentPeriodReturnsOnly)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectForReport", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
            scom.Parameters.Add("@FromDate", SqlDbType.DateTime, 10);
            scom.Parameters.Add("@ToDate", SqlDbType.DateTime, 10);
            scom.Parameters.Add("@CurrentPeriodReturnsOnly", SqlDbType.VarChar, 10);
            scom.Parameters["@FromDate"].Value = FromDate;
 scom.Parameters["@ToDate"].Value = ToDate;
            scom.Parameters["@CurrentPeriodReturnsOnly"].Value = CurrentPeriodReturnsOnly;
            List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
                    tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
                }
            }
            scon.Close();
            return tbl_sasSalesReturnedNoteList;
        }
        /// <summary>
        /// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
        /// </summary>
        public static List<tbl_sasSalesReturnedNote> SelectAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
				List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
					tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesReturnedNote> SelectAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
				List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
					tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesReturnedNote> SelectAllByInvoice_ID(string invoice_ID)
        { //tbl_sasSalesReturnedNoteSelectAllByCollector_ID

            SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
					tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNoteList;
		}

        
        //Sales Rep
        public static List<tbl_sasSalesReturnedNote> SelectAllBySalesRep_ID(string sSalesRep_ID)
        { //tbl_sasSalesReturnedNoteSelectAllByCollector_ID

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAllBySalesRep_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@SalesRep_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@SalesRep_ID"].Value = sSalesRep_ID;
            List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
                    tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
                }
            }
            scon.Close();
            return tbl_sasSalesReturnedNoteList;
        }

        //Area Manager
        public static List<tbl_sasSalesReturnedNote> SelectAllByAreaManager_ID(string sAreaManager_ID)
        { //tbl_sasSalesReturnedNoteSelectAllByCollector_ID

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAllByAreaManager_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@AreaManager_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@AreaManager_ID"].Value = sAreaManager_ID;
            List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
                    tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
                }
            }
            scon.Close();
            return tbl_sasSalesReturnedNoteList;
        }

        //Sales Manager
        public static List<tbl_sasSalesReturnedNote> SelectAllBySalesManager_ID(string sSalesRep_ID)
        { //tbl_sasSalesReturnedNoteSelectAllByCollector_ID

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAllBySalesManager_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@SalesManager_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@SalesManager_ID"].Value = sSalesRep_ID;
            List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
                    tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
                }
            }
            scon.Close();
            return tbl_sasSalesReturnedNoteList;
        }

        //Collector
        public static List<tbl_sasSalesReturnedNote> SelectAllByCollector_ID(string sCollector_ID)
        { //tbl_sasSalesReturnedNoteSelectAllByCollector_ID

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAllByCollector_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@collector_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@collector_ID"].Value = sCollector_ID;
            List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
                    tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
                }
            }
            scon.Close();
            return tbl_sasSalesReturnedNoteList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
        /// </summary>
        public static List<tbl_sasSalesReturnedNote> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
					tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesReturnedNote> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
					tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesReturnedNote> SelectAllByRoute_ID(int route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNoteSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_sasSalesReturnedNote> tbl_sasSalesReturnedNoteList = new List<tbl_sasSalesReturnedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = Maketbl_sasSalesReturnedNote(dataReader);
					tbl_sasSalesReturnedNoteList.Add(tbl_sasSalesReturnedNote);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesReturnedNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesReturnedNote Maketbl_sasSalesReturnedNote(SqlDataReader dataReader) {
			tbl_sasSalesReturnedNote tbl_sasSalesReturnedNote = new tbl_sasSalesReturnedNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesReturnedNote.SalesReturnedNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesReturnedNote.SalesReturnedNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesReturnedNote.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesReturnedNote.Invoice_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasSalesReturnedNote.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasSalesReturnedNote.DeliveryOrder_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasSalesReturnedNote.OrderRefNo_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasSalesReturnedNote.CreditNote_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasSalesReturnedNote.Store_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasSalesReturnedNote.GlPosting_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasSalesReturnedNote.PostingStatus_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasSalesReturnedNote.FinancialYear_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasSalesReturnedNote.Currency_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasSalesReturnedNote.SalesNoteType_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasSalesReturnedNote.CurrencyRate = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasSalesReturnedNote.FinanceCharges = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasSalesReturnedNote.DiscountPercentage = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasSalesReturnedNote.NbtPercentage = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasSalesReturnedNote.VatPercentage = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasSalesReturnedNote.OtherTaxPercentage = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasSalesReturnedNote.SubTotal = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasSalesReturnedNote.DiscountTotal = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasSalesReturnedNote.NbtTotal = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasSalesReturnedNote.VatTotal = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_sasSalesReturnedNote.OtherTaxTotal = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_sasSalesReturnedNote.GrandTotal = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_sasSalesReturnedNote.CreateUser_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_sasSalesReturnedNote.ModifiedUser_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_sasSalesReturnedNote.CheckedUser_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_sasSalesReturnedNote.ApprovedUser_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_sasSalesReturnedNote.DeletedUser_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_sasSalesReturnedNote.PrintedUser_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_sasSalesReturnedNote.CreateTerminal_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_sasSalesReturnedNote.ModifiedTerminal_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_sasSalesReturnedNote.DeletedTerminal_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_sasSalesReturnedNote.PrintedTerminal_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_sasSalesReturnedNote.DateCreate = dataReader.GetDateTime(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_sasSalesReturnedNote.DateModified = dataReader.GetDateTime(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_sasSalesReturnedNote.DateChecked = dataReader.GetDateTime(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_sasSalesReturnedNote.DateApproved = dataReader.GetDateTime(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_sasSalesReturnedNote.DateDeleted = dataReader.GetDateTime(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_sasSalesReturnedNote.DatePrinted = dataReader.GetDateTime(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_sasSalesReturnedNote.IsChecked = dataReader.GetBoolean(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_sasSalesReturnedNote.IsApproved = dataReader.GetBoolean(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_sasSalesReturnedNote.IsFinished = dataReader.GetBoolean(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_sasSalesReturnedNote.IsDeleted = dataReader.GetBoolean(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_sasSalesReturnedNote.IsLocked = dataReader.GetBoolean(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_sasSalesReturnedNote.SeattleAmount = dataReader.GetDecimal(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_sasSalesReturnedNote.IsSeattled = dataReader.GetBoolean(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_sasSalesReturnedNote.PrintCount = dataReader.GetInt32(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_sasSalesReturnedNote.IsWeightCalculation = dataReader.GetBoolean(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_sasSalesReturnedNote.IsTaxReverseCalulation = dataReader.GetBoolean(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_sasSalesReturnedNote.IsReturnable = dataReader.GetBoolean(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_sasSalesReturnedNote.IsRefundable = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_sasSalesReturnedNote.IsExcess = dataReader.GetBoolean(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_sasSalesReturnedNote.Branch_ID = dataReader.GetString(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_sasSalesReturnedNote.IsEntryError = dataReader.GetBoolean(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_sasSalesReturnedNote.CompanyID = dataReader.GetString(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_sasSalesReturnedNote.CompanyBranch_ID = dataReader.GetString(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_sasSalesReturnedNote.ItemPriceCategory = dataReader.GetString(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_sasSalesReturnedNote.Route_ID = dataReader.GetInt32(60);
			}
			try
			{
				if (dataReader.IsDBNull(61) == false)
				{
					tbl_sasSalesReturnedNote.isNewReturn = dataReader.GetBoolean(61);
				}
			}
			catch { }
			return tbl_sasSalesReturnedNote;
		}
		/// <summary>
		/// This makes tbl_sasSalesReturnedNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesReturnedNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesReturnedNote  tbl_sasSalesReturnedNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_salesReturnedNote_ID = new DataColumn("salesReturnedNote_ID" , typeof(string));
			DataColumn col_salesReturnedNoteDate = new DataColumn("salesReturnedNoteDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_creditNote_ID = new DataColumn("creditNote_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_FinanceCharges = new DataColumn("FinanceCharges" , typeof(decimal));
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
			DataColumn col_isTaxReverseCalulation = new DataColumn("isTaxReverseCalulation" , typeof(bool));
			DataColumn col_isReturnable = new DataColumn("isReturnable" , typeof(bool));
			DataColumn col_isRefundable = new DataColumn("isRefundable" , typeof(bool));
			DataColumn col_isExcess = new DataColumn("isExcess" , typeof(bool));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_isEntryError = new DataColumn("isEntryError" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_itemPriceCategory = new DataColumn("itemPriceCategory" , typeof(string));
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_salesReturnedNote_ID,col_salesReturnedNoteDate,col_remark,col_invoice_ID,col_customer_ID,col_deliveryOrder_ID,col_orderRefNo_ID,col_creditNote_ID,col_store_ID,col_glPosting_ID,col_postingStatus_ID,col_financialYear_ID,col_currency_ID,col_salesNoteType_ID,col_currencyRate,col_FinanceCharges,col_discountPercentage,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grandTotal,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_seattleAmount,col_isSeattled,col_printCount,col_isWeightCalculation,col_isTaxReverseCalulation,col_isReturnable,col_isRefundable,col_isExcess,col_branch_ID,col_isEntryError,col_companyID,col_companyBranch_ID,col_itemPriceCategory,col_route_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesReturnedNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesReturnedNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesReturnedNote user) {
		DataRow drow = dt.NewRow();
		
			drow["salesReturnedNote_ID"] = user.salesReturnedNote_ID;
			drow["salesReturnedNoteDate"] = user.salesReturnedNoteDate;
			drow["remark"] = user.remark;
			drow["invoice_ID"] = user.invoice_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["creditNote_ID"] = user.creditNote_ID;
			drow["store_ID"] = user.store_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["salesNoteType_ID"] = user.salesNoteType_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["FinanceCharges"] = user.FinanceCharges;
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
			drow["isTaxReverseCalulation"] = user.isTaxReverseCalulation;
			drow["isReturnable"] = user.isReturnable;
			drow["isRefundable"] = user.isRefundable;
			drow["isExcess"] = user.isExcess;
			drow["branch_ID"] = user.branch_ID;
			drow["isEntryError"] = user.isEntryError;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["itemPriceCategory"] = user.itemPriceCategory;
			drow["route_ID"] = user.route_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
