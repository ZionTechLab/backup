using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsDebitNote {
		#region Fields
		private string debitNote_ID;
		private DateTime debitNoteDate;
		private string remark;
		private string salesReturnedNote_ID;
		private string invoice_ID;
		private string customer_ID;
		private string deliveryOrder_ID;
		private string orderRefNo_ID;
		private string chequeRegister_ID;
		private string debitNoteType_ID;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string financialYear_ID;
		private string companyID;
		private string companyBranch_ID;
		private string currency_ID;
		private string salesNoteType_ID;
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
		private decimal totalAmount;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isWeightCalculation;
		private decimal seattleAmount;
		private bool isSeattled;
		private int printCount;
		private string creditNoteID;
		private string receiptNoteID;
		private bool isCustomerRefundableNote;
		private string gl_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsDebitNote class.
		/// </summary>
		public tbl_bpsDebitNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsDebitNote class.
		/// </summary>
		public tbl_bpsDebitNote(string debitNote_ID, DateTime debitNoteDate, string remark, string salesReturnedNote_ID, string invoice_ID, string customer_ID, string deliveryOrder_ID, string orderRefNo_ID, string chequeRegister_ID, string debitNoteType_ID, string glPosting_ID, string postingStatus_ID, string financialYear_ID, string companyID, string companyBranch_ID, string currency_ID, string salesNoteType_ID, decimal currencyRate, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal totalAmount, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isWeightCalculation, decimal seattleAmount, bool isSeattled, int printCount, string creditNoteID, string receiptNoteID, bool isCustomerRefundableNote, string gl_ID) {
			this.debitNote_ID = debitNote_ID;
			this.debitNoteDate = debitNoteDate;
			this.remark = remark;
			this.salesReturnedNote_ID = salesReturnedNote_ID;
			this.invoice_ID = invoice_ID;
			this.customer_ID = customer_ID;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.orderRefNo_ID = orderRefNo_ID;
			this.chequeRegister_ID = chequeRegister_ID;
			this.debitNoteType_ID = debitNoteType_ID;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.financialYear_ID = financialYear_ID;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.currency_ID = currency_ID;
			this.salesNoteType_ID = salesNoteType_ID;
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
			this.totalAmount = totalAmount;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isWeightCalculation = isWeightCalculation;
			this.seattleAmount = seattleAmount;
			this.isSeattled = isSeattled;
			this.printCount = printCount;
			this.creditNoteID = creditNoteID;
			this.receiptNoteID = receiptNoteID;
			this.isCustomerRefundableNote = isCustomerRefundableNote;
			this.gl_ID = gl_ID;
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
		/// Gets or sets the DebitNoteDate value.
		/// </summary>
		public DateTime DebitNoteDate {
			get { return debitNoteDate; }
			set { debitNoteDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesReturnedNote_ID value.
		/// </summary>
		public string SalesReturnedNote_ID {
			get { return salesReturnedNote_ID; }
			set { salesReturnedNote_ID = value; }
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
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DebitNoteType_ID value.
		/// </summary>
		public string DebitNoteType_ID {
			get { return debitNoteType_ID; }
			set { debitNoteType_ID = value; }
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
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
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
		/// Gets or sets the IsWeightCalculation value.
		/// </summary>
		public bool IsWeightCalculation {
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
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditNoteID value.
		/// </summary>
		public string CreditNoteID {
			get { return creditNoteID; }
			set { creditNoteID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptNoteID value.
		/// </summary>
		public string ReceiptNoteID {
			get { return receiptNoteID; }
			set { receiptNoteID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCustomerRefundableNote value.
		/// </summary>
		public bool IsCustomerRefundableNote {
			get { return isCustomerRefundableNote; }
			set { isCustomerRefundableNote = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsDebitNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
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
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@creditNoteID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receiptNoteID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCustomerRefundableNote", SqlDbType.Bit,1);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@debitNoteDate"].Value = debitNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@debitNoteType_ID"].Value = debitNoteType_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
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
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@creditNoteID"].Value = creditNoteID;
			scom.Parameters["@receiptNoteID"].Value = receiptNoteID;
			scom.Parameters["@isCustomerRefundableNote"].Value = isCustomerRefundableNote;
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsDebitNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
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
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@creditNoteID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receiptNoteID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCustomerRefundableNote", SqlDbType.Bit,1);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@debitNoteDate"].Value = debitNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@debitNoteType_ID"].Value = debitNoteType_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
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
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@creditNoteID"].Value = creditNoteID;
			scom.Parameters["@receiptNoteID"].Value = receiptNoteID;
			scom.Parameters["@isCustomerRefundableNote"].Value = isCustomerRefundableNote;
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsDebitNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteDeleteAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteDeleteAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesReturnedNote_ID(string salesReturnedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteDeleteAllBySalesReturnedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByDebitNoteType_ID(string debitNoteType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteDeleteAllByDebitNoteType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@debitNoteType_ID"].Value = debitNoteType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteDeleteAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsDebitNote table.
		/// </summary>
		public static tbl_bpsDebitNote Select(string debitNote_ID_Incoming){

			tbl_bpsDebitNote tbl_bpsDebitNoteins = new tbl_bpsDebitNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsDebitNoteins = Maketbl_bpsDebitNote(dataReader);
				} else {
					tbl_bpsDebitNoteins = null;
				}
			}
			scon.Close();
			return tbl_bpsDebitNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table.
		/// </summary>
		public static List<tbl_bpsDebitNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsDebitNote> tbl_bpsDebitNoteList = new List<tbl_bpsDebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote tbl_bpsDebitNote = Maketbl_bpsDebitNote(dataReader);
					tbl_bpsDebitNoteList.Add(tbl_bpsDebitNote);
				}
			}
			scon.Close();
			return tbl_bpsDebitNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_bpsDebitNote> tbl_bpsDebitNoteList = new List<tbl_bpsDebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote tbl_bpsDebitNote = Maketbl_bpsDebitNote(dataReader);
					tbl_bpsDebitNoteList.Add(tbl_bpsDebitNote);
				}
			}
			scon.Close();
			return tbl_bpsDebitNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote> SelectAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteSelectAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
				List<tbl_bpsDebitNote> tbl_bpsDebitNoteList = new List<tbl_bpsDebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote tbl_bpsDebitNote = Maketbl_bpsDebitNote(dataReader);
					tbl_bpsDebitNoteList.Add(tbl_bpsDebitNote);
				}
			}
			scon.Close();
			return tbl_bpsDebitNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote> SelectAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteSelectAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
				List<tbl_bpsDebitNote> tbl_bpsDebitNoteList = new List<tbl_bpsDebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote tbl_bpsDebitNote = Maketbl_bpsDebitNote(dataReader);
					tbl_bpsDebitNoteList.Add(tbl_bpsDebitNote);
				}
			}
			scon.Close();
			return tbl_bpsDebitNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote> SelectAllBySalesReturnedNote_ID(string salesReturnedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteSelectAllBySalesReturnedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
				List<tbl_bpsDebitNote> tbl_bpsDebitNoteList = new List<tbl_bpsDebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote tbl_bpsDebitNote = Maketbl_bpsDebitNote(dataReader);
					tbl_bpsDebitNoteList.Add(tbl_bpsDebitNote);
				}
			}
			scon.Close();
			return tbl_bpsDebitNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_bpsDebitNote> tbl_bpsDebitNoteList = new List<tbl_bpsDebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote tbl_bpsDebitNote = Maketbl_bpsDebitNote(dataReader);
					tbl_bpsDebitNoteList.Add(tbl_bpsDebitNote);
				}
			}
			scon.Close();
			return tbl_bpsDebitNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote> SelectAllByDebitNoteType_ID(string debitNoteType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteSelectAllByDebitNoteType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@debitNoteType_ID"].Value = debitNoteType_ID;
				List<tbl_bpsDebitNote> tbl_bpsDebitNoteList = new List<tbl_bpsDebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote tbl_bpsDebitNote = Maketbl_bpsDebitNote(dataReader);
					tbl_bpsDebitNoteList.Add(tbl_bpsDebitNote);
				}
			}
			scon.Close();
			return tbl_bpsDebitNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsDebitNote table by a foreign key.
		/// </summary>
		public static List<tbl_bpsDebitNote> SelectAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsDebitNoteSelectAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
				List<tbl_bpsDebitNote> tbl_bpsDebitNoteList = new List<tbl_bpsDebitNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsDebitNote tbl_bpsDebitNote = Maketbl_bpsDebitNote(dataReader);
					tbl_bpsDebitNoteList.Add(tbl_bpsDebitNote);
				}
			}
			scon.Close();
			return tbl_bpsDebitNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsDebitNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsDebitNote Maketbl_bpsDebitNote(SqlDataReader dataReader) {
			tbl_bpsDebitNote tbl_bpsDebitNote = new tbl_bpsDebitNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsDebitNote.DebitNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsDebitNote.DebitNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsDebitNote.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsDebitNote.SalesReturnedNote_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsDebitNote.Invoice_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsDebitNote.Customer_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsDebitNote.DeliveryOrder_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsDebitNote.OrderRefNo_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsDebitNote.ChequeRegister_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsDebitNote.DebitNoteType_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsDebitNote.GlPosting_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsDebitNote.PostingStatus_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsDebitNote.FinancialYear_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsDebitNote.CompanyID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsDebitNote.CompanyBranch_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsDebitNote.Currency_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsDebitNote.SalesNoteType_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsDebitNote.CurrencyRate = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsDebitNote.DiscountPercentage = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsDebitNote.NbtPercentage = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_bpsDebitNote.VatPercentage = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_bpsDebitNote.OtherTaxPercentage = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_bpsDebitNote.SubTotal = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_bpsDebitNote.DiscountTotal = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_bpsDebitNote.NbtTotal = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_bpsDebitNote.VatTotal = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_bpsDebitNote.OtherTaxTotal = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_bpsDebitNote.TotalAmount = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_bpsDebitNote.CreateUser_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_bpsDebitNote.ModifiedUser_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_bpsDebitNote.CheckedUser_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_bpsDebitNote.ApprovedUser_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_bpsDebitNote.DateCreate = dataReader.GetDateTime(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_bpsDebitNote.DateModified = dataReader.GetDateTime(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_bpsDebitNote.DateChecked = dataReader.GetDateTime(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_bpsDebitNote.DateApproved = dataReader.GetDateTime(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_bpsDebitNote.IsChecked = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_bpsDebitNote.IsApproved = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_bpsDebitNote.IsFinished = dataReader.GetBoolean(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_bpsDebitNote.IsDeleted = dataReader.GetBoolean(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_bpsDebitNote.IsLocked = dataReader.GetBoolean(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_bpsDebitNote.IsWeightCalculation = dataReader.GetBoolean(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_bpsDebitNote.SeattleAmount = dataReader.GetDecimal(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_bpsDebitNote.IsSeattled = dataReader.GetBoolean(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_bpsDebitNote.PrintCount = dataReader.GetInt32(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_bpsDebitNote.CreditNoteID = dataReader.GetString(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_bpsDebitNote.ReceiptNoteID = dataReader.GetString(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_bpsDebitNote.IsCustomerRefundableNote = dataReader.GetBoolean(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_bpsDebitNote.Gl_ID = dataReader.GetString(48);
			}

			return tbl_bpsDebitNote;
		}
		/// <summary>
		/// This makes tbl_bpsDebitNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsDebitNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsDebitNote  tbl_bpsDebitNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_debitNote_ID = new DataColumn("debitNote_ID" , typeof(string));
			DataColumn col_debitNoteDate = new DataColumn("debitNoteDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_salesReturnedNote_ID = new DataColumn("salesReturnedNote_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_debitNoteType_ID = new DataColumn("debitNoteType_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID" , typeof(string));
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
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation" , typeof(bool));
			DataColumn col_seattleAmount = new DataColumn("seattleAmount" , typeof(decimal));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_creditNoteID = new DataColumn("creditNoteID" , typeof(string));
			DataColumn col_receiptNoteID = new DataColumn("receiptNoteID" , typeof(string));
			DataColumn col_isCustomerRefundableNote = new DataColumn("isCustomerRefundableNote" , typeof(bool));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_debitNote_ID,col_debitNoteDate,col_remark,col_salesReturnedNote_ID,col_invoice_ID,col_customer_ID,col_deliveryOrder_ID,col_orderRefNo_ID,col_chequeRegister_ID,col_debitNoteType_ID,col_glPosting_ID,col_postingStatus_ID,col_financialYear_ID,col_companyID,col_companyBranch_ID,col_currency_ID,col_salesNoteType_ID,col_currencyRate,col_discountPercentage,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_totalAmount,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isWeightCalculation,col_seattleAmount,col_isSeattled,col_printCount,col_creditNoteID,col_receiptNoteID,col_isCustomerRefundableNote,col_gl_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsDebitNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsDebitNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsDebitNote user) {
		DataRow drow = dt.NewRow();
		
			drow["debitNote_ID"] = user.debitNote_ID;
			drow["debitNoteDate"] = user.debitNoteDate;
			drow["remark"] = user.remark;
			drow["salesReturnedNote_ID"] = user.salesReturnedNote_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["debitNoteType_ID"] = user.debitNoteType_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["salesNoteType_ID"] = user.salesNoteType_ID;
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
			drow["totalAmount"] = user.totalAmount;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isWeightCalculation"] = user.isWeightCalculation;
			drow["seattleAmount"] = user.seattleAmount;
			drow["isSeattled"] = user.isSeattled;
			drow["printCount"] = user.printCount;
			drow["creditNoteID"] = user.creditNoteID;
			drow["receiptNoteID"] = user.receiptNoteID;
			drow["isCustomerRefundableNote"] = user.isCustomerRefundableNote;
			drow["gl_ID"] = user.gl_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
