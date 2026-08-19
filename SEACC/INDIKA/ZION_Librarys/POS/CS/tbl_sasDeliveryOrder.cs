using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasDeliveryOrder {
		#region Fields
		private string deliveryOrder_ID;
		private DateTime deliveryOrderDate;
		private string remark;
		private string deliveryAddress;
		private string vehicle_No;
		private DateTime dateIn;
		private DateTime dateOut;
		private DateTime customerDeliveryDate;
		private string receiptBy;
		private string customer_ID;
		private string customerOrder_ID;
		private string quotation_ID;
		private string job_ID;
		private string driver_ID;
		private string vehicle_ID;
		private string assitant_ID;
		private string store_ID;
		private string employee_ID;
		private string orderRefNo_ID;
		private string cancelReason_ID_DO;
		private string currency_ID;
		private string glPosting_ID;
		private string postingStatus_ID;
		private string financialYear_ID;
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
		private bool isSeattled;
		private bool isWeightCalculation;
		private int printCount;
		private bool isPriceEnabled;
		private bool isTaxReverseCalulation;
		private bool isFreeOrder;
		private bool isVAT;
		private bool isSVAT;
		private string batchNo;
		private string branch_ID;
		private bool isReplacementOrder;
		private string itemPriceCategory;
		private string companyID;
		private string companyBranch_ID;
		private int route_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasDeliveryOrder class.
		/// </summary>
		public tbl_sasDeliveryOrder() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasDeliveryOrder class.
		/// </summary>
		public tbl_sasDeliveryOrder(string deliveryOrder_ID, DateTime deliveryOrderDate, string remark, string deliveryAddress, string vehicle_No, DateTime dateIn, DateTime dateOut, DateTime customerDeliveryDate, string receiptBy, string customer_ID, string customerOrder_ID, string quotation_ID, string job_ID, string driver_ID, string vehicle_ID, string assitant_ID, string store_ID, string employee_ID, string orderRefNo_ID, string cancelReason_ID_DO, string currency_ID, string glPosting_ID, string postingStatus_ID, string financialYear_ID, string salesNoteType_ID, decimal currencyRate, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, decimal recommendedSubTotal, decimal recommendedGrandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled, bool isWeightCalculation, int printCount, bool isPriceEnabled, bool isTaxReverseCalulation, bool isFreeOrder, bool isVAT, bool isSVAT, string batchNo, string branch_ID, bool isReplacementOrder, string itemPriceCategory, string companyID, string companyBranch_ID, int route_ID) {
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.deliveryOrderDate = deliveryOrderDate;
			this.remark = remark;
			this.deliveryAddress = deliveryAddress;
			this.vehicle_No = vehicle_No;
			this.dateIn = dateIn;
			this.dateOut = dateOut;
			this.customerDeliveryDate = customerDeliveryDate;
			this.receiptBy = receiptBy;
			this.customer_ID = customer_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.quotation_ID = quotation_ID;
			this.job_ID = job_ID;
			this.driver_ID = driver_ID;
			this.vehicle_ID = vehicle_ID;
			this.assitant_ID = assitant_ID;
			this.store_ID = store_ID;
			this.employee_ID = employee_ID;
			this.orderRefNo_ID = orderRefNo_ID;
			this.cancelReason_ID_DO = cancelReason_ID_DO;
			this.currency_ID = currency_ID;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.financialYear_ID = financialYear_ID;
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
			this.isSeattled = isSeattled;
			this.isWeightCalculation = isWeightCalculation;
			this.printCount = printCount;
			this.isPriceEnabled = isPriceEnabled;
			this.isTaxReverseCalulation = isTaxReverseCalulation;
			this.isFreeOrder = isFreeOrder;
			this.isVAT = isVAT;
			this.isSVAT = isSVAT;
			this.batchNo = batchNo;
			this.branch_ID = branch_ID;
			this.isReplacementOrder = isReplacementOrder;
			this.itemPriceCategory = itemPriceCategory;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.route_ID = route_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the DeliveryOrder_ID value.
		/// </summary>
		public string DeliveryOrder_ID {
			get { return deliveryOrder_ID; }
			set { deliveryOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryOrderDate value.
		/// </summary>
		public DateTime DeliveryOrderDate {
			get { return deliveryOrderDate; }
			set { deliveryOrderDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryAddress value.
		/// </summary>
		public string DeliveryAddress {
			get { return deliveryAddress; }
			set { deliveryAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the Vehicle_No value.
		/// </summary>
		public string Vehicle_No {
			get { return vehicle_No; }
			set { vehicle_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateIn value.
		/// </summary>
		public DateTime DateIn {
			get { return dateIn; }
			set { dateIn = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateOut value.
		/// </summary>
		public DateTime DateOut {
			get { return dateOut; }
			set { dateOut = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerDeliveryDate value.
		/// </summary>
		public DateTime CustomerDeliveryDate {
			get { return customerDeliveryDate; }
			set { customerDeliveryDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptBy value.
		/// </summary>
		public string ReceiptBy {
			get { return receiptBy; }
			set { receiptBy = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Quotation_ID value.
		/// </summary>
		public string Quotation_ID {
			get { return quotation_ID; }
			set { quotation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Driver_ID value.
		/// </summary>
		public string Driver_ID {
			get { return driver_ID; }
			set { driver_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Vehicle_ID value.
		/// </summary>
		public string Vehicle_ID {
			get { return vehicle_ID; }
			set { vehicle_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Assitant_ID value.
		/// </summary>
		public string Assitant_ID {
			get { return assitant_ID; }
			set { assitant_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo_ID value.
		/// </summary>
		public string OrderRefNo_ID {
			get { return orderRefNo_ID; }
			set { orderRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CancelReason_ID_DO value.
		/// </summary>
		public string CancelReason_ID_DO {
			get { return cancelReason_ID_DO; }
			set { cancelReason_ID_DO = value; }
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
		/// Gets or sets the IsPriceEnabled value.
		/// </summary>
		public bool IsPriceEnabled {
			get { return isPriceEnabled; }
			set { isPriceEnabled = value; }
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
		/// Gets or sets the BatchNo value.
		/// </summary>
		public string BatchNo {
			get { return batchNo; }
			set { batchNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Branch_ID value.
		/// </summary>
		public string Branch_ID {
			get { return branch_ID; }
			set { branch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReplacementOrder value.
		/// </summary>
		public bool IsReplacementOrder {
			get { return isReplacementOrder; }
			set { isReplacementOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemPriceCategory value.
		/// </summary>
		public string ItemPriceCategory {
			get { return itemPriceCategory; }
			set { itemPriceCategory = value; }
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
		/// Gets or sets the Route_ID value.
		/// </summary>
		public int Route_ID {
			get { return route_ID; }
			set { route_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasDeliveryOrder table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@deliveryAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@vehicle_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateIn", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateOut", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customerDeliveryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@receiptBy", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@assitant_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cancelReason_ID_DO", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isPriceEnabled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTaxReverseCalulation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFreeOrder", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isReplacementOrder", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
 
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@deliveryOrderDate"].Value = deliveryOrderDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@deliveryAddress"].Value = deliveryAddress;
			scom.Parameters["@vehicle_No"].Value = vehicle_No;
			scom.Parameters["@dateIn"].Value = dateIn;
			scom.Parameters["@dateOut"].Value = dateOut;
			scom.Parameters["@customerDeliveryDate"].Value = customerDeliveryDate;
			scom.Parameters["@receiptBy"].Value = receiptBy;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@driver_ID"].Value = driver_ID;
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
			scom.Parameters["@assitant_ID"].Value = assitant_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@cancelReason_ID_DO"].Value = cancelReason_ID_DO;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
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
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isPriceEnabled"].Value = isPriceEnabled;
			scom.Parameters["@isTaxReverseCalulation"].Value = isTaxReverseCalulation;
			scom.Parameters["@isFreeOrder"].Value = isFreeOrder;
			scom.Parameters["@isVAT"].Value = isVAT;
			scom.Parameters["@isSVAT"].Value = isSVAT;
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@isReplacementOrder"].Value = isReplacementOrder;
			scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasDeliveryOrder table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@deliveryAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@vehicle_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateIn", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateOut", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customerDeliveryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@receiptBy", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@assitant_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cancelReason_ID_DO", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isPriceEnabled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTaxReverseCalulation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFreeOrder", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isReplacementOrder", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
 
 
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@deliveryOrderDate"].Value = deliveryOrderDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@deliveryAddress"].Value = deliveryAddress;
			scom.Parameters["@vehicle_No"].Value = vehicle_No;
			scom.Parameters["@dateIn"].Value = dateIn;
			scom.Parameters["@dateOut"].Value = dateOut;
			scom.Parameters["@customerDeliveryDate"].Value = customerDeliveryDate;
			scom.Parameters["@receiptBy"].Value = receiptBy;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@driver_ID"].Value = driver_ID;
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
			scom.Parameters["@assitant_ID"].Value = assitant_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@cancelReason_ID_DO"].Value = cancelReason_ID_DO;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
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
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isPriceEnabled"].Value = isPriceEnabled;
			scom.Parameters["@isTaxReverseCalulation"].Value = isTaxReverseCalulation;
			scom.Parameters["@isFreeOrder"].Value = isFreeOrder;
			scom.Parameters["@isVAT"].Value = isVAT;
			scom.Parameters["@isSVAT"].Value = isSVAT;
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@isReplacementOrder"].Value = isReplacementOrder;
			scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasDeliveryOrder table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(int route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByAssitant_ID(string assitant_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByAssitant_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assitant_ID", SqlDbType.VarChar,10);
			scom.Parameters["@assitant_ID"].Value = assitant_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByVehicle_ID(string vehicle_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByVehicle_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByDriver_ID(string driver_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByDriver_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters["@driver_ID"].Value = driver_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByCancelReason_ID_DO(string cancelReason_ID_DO) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByCancelReason_ID_DO", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cancelReason_ID_DO", SqlDbType.VarChar,10);
			scom.Parameters["@cancelReason_ID_DO"].Value = cancelReason_ID_DO;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByQuotation_ID(string quotation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByQuotation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderDeleteAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasDeliveryOrder table.
		/// </summary>
		public static tbl_sasDeliveryOrder Select(string deliveryOrder_ID_Incoming){

			tbl_sasDeliveryOrder tbl_sasDeliveryOrderins = new tbl_sasDeliveryOrder();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasDeliveryOrderins = Maketbl_sasDeliveryOrder(dataReader);
				} else {
					tbl_sasDeliveryOrderins = null;
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
        public static List<tbl_sasDeliveryOrder> SelectAllByDateRange(DateTime dtmFromDate, DateTime dtmToDate)
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByDateRange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime);
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime);

            scom.Parameters["@dateFrom"].Value = dtmFromDate.Date;
            scom.Parameters["@dateTo"].Value = dtmToDate.Date;

            List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
                    tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
                }
            }
            scon.Close();
            return tbl_sasDeliveryOrderList;
        }

        /// <summary>
        /// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
        /// </summary>
        public static List<tbl_sasDeliveryOrder> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByRoute_ID(int route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByAssitant_ID(string assitant_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByAssitant_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assitant_ID", SqlDbType.VarChar,10);
			scom.Parameters["@assitant_ID"].Value = assitant_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByVehicle_ID(string vehicle_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByVehicle_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByDriver_ID(string driver_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByDriver_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters["@driver_ID"].Value = driver_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByCancelReason_ID_DO(string cancelReason_ID_DO) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByCancelReason_ID_DO", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cancelReason_ID_DO", SqlDbType.VarChar,10);
			scom.Parameters["@cancelReason_ID_DO"].Value = cancelReason_ID_DO;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByQuotation_ID(string quotation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByQuotation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryOrder> SelectAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrderSelectAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
				List<tbl_sasDeliveryOrder> tbl_sasDeliveryOrderList = new List<tbl_sasDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder tbl_sasDeliveryOrder = Maketbl_sasDeliveryOrder(dataReader);
					tbl_sasDeliveryOrderList.Add(tbl_sasDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrderList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasDeliveryOrder class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasDeliveryOrder Maketbl_sasDeliveryOrder(SqlDataReader dataReader) {
			tbl_sasDeliveryOrder tbl_sasDeliveryOrder = new tbl_sasDeliveryOrder();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasDeliveryOrder.DeliveryOrder_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasDeliveryOrder.DeliveryOrderDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasDeliveryOrder.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasDeliveryOrder.DeliveryAddress = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasDeliveryOrder.Vehicle_No = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasDeliveryOrder.DateIn = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasDeliveryOrder.DateOut = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasDeliveryOrder.CustomerDeliveryDate = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasDeliveryOrder.ReceiptBy = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasDeliveryOrder.Customer_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasDeliveryOrder.CustomerOrder_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasDeliveryOrder.Quotation_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasDeliveryOrder.Job_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasDeliveryOrder.Driver_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasDeliveryOrder.Vehicle_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasDeliveryOrder.Assitant_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasDeliveryOrder.Store_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasDeliveryOrder.Employee_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasDeliveryOrder.OrderRefNo_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasDeliveryOrder.CancelReason_ID_DO = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasDeliveryOrder.Currency_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasDeliveryOrder.GlPosting_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasDeliveryOrder.PostingStatus_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasDeliveryOrder.FinancialYear_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_sasDeliveryOrder.SalesNoteType_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_sasDeliveryOrder.CurrencyRate = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_sasDeliveryOrder.DiscountPercentage = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_sasDeliveryOrder.NbtPercentage = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_sasDeliveryOrder.VatPercentage = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_sasDeliveryOrder.OtherTaxPercentage = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_sasDeliveryOrder.SubTotal = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_sasDeliveryOrder.DiscountTotal = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_sasDeliveryOrder.NbtTotal = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_sasDeliveryOrder.VatTotal = dataReader.GetDecimal(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_sasDeliveryOrder.OtherTaxTotal = dataReader.GetDecimal(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_sasDeliveryOrder.GrandTotal = dataReader.GetDecimal(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_sasDeliveryOrder.RecommendedSubTotal = dataReader.GetDecimal(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_sasDeliveryOrder.RecommendedGrandTotal = dataReader.GetDecimal(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_sasDeliveryOrder.CreateUser_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_sasDeliveryOrder.ModifiedUser_ID = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_sasDeliveryOrder.CheckedUser_ID = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_sasDeliveryOrder.ApprovedUser_ID = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_sasDeliveryOrder.DeletedUser_ID = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_sasDeliveryOrder.PrintedUser_ID = dataReader.GetString(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_sasDeliveryOrder.CreateTerminal_ID = dataReader.GetString(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_sasDeliveryOrder.ModifiedTerminal_ID = dataReader.GetString(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_sasDeliveryOrder.DeletedTerminal_ID = dataReader.GetString(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_sasDeliveryOrder.PrintedTerminal_ID = dataReader.GetString(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_sasDeliveryOrder.DateCreate = dataReader.GetDateTime(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_sasDeliveryOrder.DateModified = dataReader.GetDateTime(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_sasDeliveryOrder.DateChecked = dataReader.GetDateTime(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_sasDeliveryOrder.DateApproved = dataReader.GetDateTime(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_sasDeliveryOrder.DateDeleted = dataReader.GetDateTime(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_sasDeliveryOrder.DatePrinted = dataReader.GetDateTime(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_sasDeliveryOrder.IsChecked = dataReader.GetBoolean(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_sasDeliveryOrder.IsApproved = dataReader.GetBoolean(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_sasDeliveryOrder.IsFinished = dataReader.GetBoolean(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_sasDeliveryOrder.IsDeleted = dataReader.GetBoolean(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_sasDeliveryOrder.IsLocked = dataReader.GetBoolean(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_sasDeliveryOrder.IsSeattled = dataReader.GetBoolean(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_sasDeliveryOrder.IsWeightCalculation = dataReader.GetBoolean(60);
			}
			if (dataReader.IsDBNull(61) == false) {
				tbl_sasDeliveryOrder.PrintCount = dataReader.GetInt32(61);
			}
			if (dataReader.IsDBNull(62) == false) {
				tbl_sasDeliveryOrder.IsPriceEnabled = dataReader.GetBoolean(62);
			}
			if (dataReader.IsDBNull(63) == false) {
				tbl_sasDeliveryOrder.IsTaxReverseCalulation = dataReader.GetBoolean(63);
			}
			if (dataReader.IsDBNull(64) == false) {
				tbl_sasDeliveryOrder.IsFreeOrder = dataReader.GetBoolean(64);
			}
			if (dataReader.IsDBNull(65) == false) {
				tbl_sasDeliveryOrder.IsVAT = dataReader.GetBoolean(65);
			}
			if (dataReader.IsDBNull(66) == false) {
				tbl_sasDeliveryOrder.IsSVAT = dataReader.GetBoolean(66);
			}
			if (dataReader.IsDBNull(67) == false) {
				tbl_sasDeliveryOrder.BatchNo = dataReader.GetString(67);
			}
			if (dataReader.IsDBNull(68) == false) {
				tbl_sasDeliveryOrder.Branch_ID = dataReader.GetString(68);
			}
			if (dataReader.IsDBNull(69) == false) {
				tbl_sasDeliveryOrder.IsReplacementOrder = dataReader.GetBoolean(69);
			}
			if (dataReader.IsDBNull(70) == false) {
				tbl_sasDeliveryOrder.ItemPriceCategory = dataReader.GetString(70);
			}
			if (dataReader.IsDBNull(71) == false) {
				tbl_sasDeliveryOrder.CompanyID = dataReader.GetString(71);
			}
			if (dataReader.IsDBNull(72) == false) {
				tbl_sasDeliveryOrder.CompanyBranch_ID = dataReader.GetString(72);
			}
			if (dataReader.IsDBNull(73) == false) {
				tbl_sasDeliveryOrder.Route_ID = dataReader.GetInt32(73);
			}

			return tbl_sasDeliveryOrder;
		}
		/// <summary>
		/// This makes tbl_sasDeliveryOrder datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasDeliveryOrder object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasDeliveryOrder  tbl_sasDeliveryOrder   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_deliveryOrderDate = new DataColumn("deliveryOrderDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_deliveryAddress = new DataColumn("deliveryAddress" , typeof(string));
			DataColumn col_vehicle_No = new DataColumn("vehicle_No" , typeof(string));
			DataColumn col_dateIn = new DataColumn("dateIn" , typeof(DateTime));
			DataColumn col_dateOut = new DataColumn("dateOut" , typeof(DateTime));
			DataColumn col_customerDeliveryDate = new DataColumn("customerDeliveryDate" , typeof(DateTime));
			DataColumn col_receiptBy = new DataColumn("receiptBy" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_quotation_ID = new DataColumn("quotation_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_driver_ID = new DataColumn("driver_ID" , typeof(string));
			DataColumn col_vehicle_ID = new DataColumn("vehicle_ID" , typeof(string));
			DataColumn col_assitant_ID = new DataColumn("assitant_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_cancelReason_ID_DO = new DataColumn("cancelReason_ID_DO" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
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
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_isPriceEnabled = new DataColumn("isPriceEnabled" , typeof(bool));
			DataColumn col_isTaxReverseCalulation = new DataColumn("isTaxReverseCalulation" , typeof(bool));
			DataColumn col_isFreeOrder = new DataColumn("isFreeOrder" , typeof(bool));
			DataColumn col_isVAT = new DataColumn("isVAT" , typeof(bool));
			DataColumn col_isSVAT = new DataColumn("isSVAT" , typeof(bool));
			DataColumn col_batchNo = new DataColumn("batchNo" , typeof(string));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_isReplacementOrder = new DataColumn("isReplacementOrder" , typeof(bool));
			DataColumn col_itemPriceCategory = new DataColumn("itemPriceCategory" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_deliveryOrder_ID,col_deliveryOrderDate,col_remark,col_deliveryAddress,col_vehicle_No,col_dateIn,col_dateOut,col_customerDeliveryDate,col_receiptBy,col_customer_ID,col_customerOrder_ID,col_quotation_ID,col_job_ID,col_driver_ID,col_vehicle_ID,col_assitant_ID,col_store_ID,col_employee_ID,col_orderRefNo_ID,col_cancelReason_ID_DO,col_currency_ID,col_glPosting_ID,col_postingStatus_ID,col_financialYear_ID,col_salesNoteType_ID,col_currencyRate,col_discountPercentage,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grandTotal,col_recommendedSubTotal,col_recommendedGrandTotal,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,col_isWeightCalculation,col_printCount,col_isPriceEnabled,col_isTaxReverseCalulation,col_isFreeOrder,col_isVAT,col_isSVAT,col_batchNo,col_branch_ID,col_isReplacementOrder,col_itemPriceCategory,col_companyID,col_companyBranch_ID,col_route_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasDeliveryOrder datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasDeliveryOrder object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasDeliveryOrder user) {
		DataRow drow = dt.NewRow();
		
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["deliveryOrderDate"] = user.deliveryOrderDate;
			drow["remark"] = user.remark;
			drow["deliveryAddress"] = user.deliveryAddress;
			drow["vehicle_No"] = user.vehicle_No;
			drow["dateIn"] = user.dateIn;
			drow["dateOut"] = user.dateOut;
			drow["customerDeliveryDate"] = user.customerDeliveryDate;
			drow["receiptBy"] = user.receiptBy;
			drow["customer_ID"] = user.customer_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["quotation_ID"] = user.quotation_ID;
			drow["job_ID"] = user.job_ID;
			drow["driver_ID"] = user.driver_ID;
			drow["vehicle_ID"] = user.vehicle_ID;
			drow["assitant_ID"] = user.assitant_ID;
			drow["store_ID"] = user.store_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["cancelReason_ID_DO"] = user.cancelReason_ID_DO;
			drow["currency_ID"] = user.currency_ID;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
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
			drow["isSeattled"] = user.isSeattled;
			drow["isWeightCalculation"] = user.isWeightCalculation;
			drow["printCount"] = user.printCount;
			drow["isPriceEnabled"] = user.isPriceEnabled;
			drow["isTaxReverseCalulation"] = user.isTaxReverseCalulation;
			drow["isFreeOrder"] = user.isFreeOrder;
			drow["isVAT"] = user.isVAT;
			drow["isSVAT"] = user.isSVAT;
			drow["batchNo"] = user.batchNo;
			drow["branch_ID"] = user.branch_ID;
			drow["isReplacementOrder"] = user.isReplacementOrder;
			drow["itemPriceCategory"] = user.itemPriceCategory;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["route_ID"] = user.route_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
