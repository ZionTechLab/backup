using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasInvDeliveryOrder {
		#region Fields
		private string iDeliveryOrder_ID;
		private DateTime iDeliveryOrderDate;
		private string remark;
		private string deliveryAddress;
		private DateTime dateIn;
		private DateTime dateOut;
		private DateTime customerDeliveryDate;
		private string receiptBy;
		private string customer_ID;
		private string invoice_ID;
		private string driver_ID;
		private string vehicle_ID;
		private string assitant_ID;
		private string store_ID;
		private string employee_ID;
		private string orderRefNo_ID;
		private string cancelReason_ID_DO;
		private string currency_ID;
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
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasInvDeliveryOrder class.
		/// </summary>
		public tbl_sasInvDeliveryOrder() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasInvDeliveryOrder class.
		/// </summary>
		public tbl_sasInvDeliveryOrder(string iDeliveryOrder_ID, DateTime iDeliveryOrderDate, string remark, string deliveryAddress, DateTime dateIn, DateTime dateOut, DateTime customerDeliveryDate, string receiptBy, string customer_ID, string invoice_ID, string driver_ID, string vehicle_ID, string assitant_ID, string store_ID, string employee_ID, string orderRefNo_ID, string cancelReason_ID_DO, string currency_ID, decimal currencyRate, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, decimal recommendedSubTotal, decimal recommendedGrandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled, bool isWeightCalculation, int printCount, bool isPriceEnabled, bool isTaxReverseCalulation) {
			this.iDeliveryOrder_ID = iDeliveryOrder_ID;
			this.iDeliveryOrderDate = iDeliveryOrderDate;
			this.remark = remark;
			this.deliveryAddress = deliveryAddress;
			this.dateIn = dateIn;
			this.dateOut = dateOut;
			this.customerDeliveryDate = customerDeliveryDate;
			this.receiptBy = receiptBy;
			this.customer_ID = customer_ID;
			this.invoice_ID = invoice_ID;
			this.driver_ID = driver_ID;
			this.vehicle_ID = vehicle_ID;
			this.assitant_ID = assitant_ID;
			this.store_ID = store_ID;
			this.employee_ID = employee_ID;
			this.orderRefNo_ID = orderRefNo_ID;
			this.cancelReason_ID_DO = cancelReason_ID_DO;
			this.currency_ID = currency_ID;
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
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the IDeliveryOrder_ID value.
		/// </summary>
		public string IDeliveryOrder_ID {
			get { return iDeliveryOrder_ID; }
			set { iDeliveryOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IDeliveryOrderDate value.
		/// </summary>
		public DateTime IDeliveryOrderDate {
			get { return iDeliveryOrderDate; }
			set { iDeliveryOrderDate = value; }
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
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasInvDeliveryOrder table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@iDeliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@iDeliveryOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@deliveryAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateIn", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateOut", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customerDeliveryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@receiptBy", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@assitant_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cancelReason_ID_DO", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
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
 
			scom.Parameters["@iDeliveryOrder_ID"].Value = iDeliveryOrder_ID;
			scom.Parameters["@iDeliveryOrderDate"].Value = iDeliveryOrderDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@deliveryAddress"].Value = deliveryAddress;
			scom.Parameters["@dateIn"].Value = dateIn;
			scom.Parameters["@dateOut"].Value = dateOut;
			scom.Parameters["@customerDeliveryDate"].Value = customerDeliveryDate;
			scom.Parameters["@receiptBy"].Value = receiptBy;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@driver_ID"].Value = driver_ID;
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
			scom.Parameters["@assitant_ID"].Value = assitant_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@cancelReason_ID_DO"].Value = cancelReason_ID_DO;
			scom.Parameters["@currency_ID"].Value = currency_ID;
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
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasInvDeliveryOrder table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@iDeliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@iDeliveryOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@deliveryAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateIn", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateOut", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customerDeliveryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@receiptBy", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@assitant_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cancelReason_ID_DO", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
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
 
 
			scom.Parameters["@iDeliveryOrder_ID"].Value = iDeliveryOrder_ID;
			scom.Parameters["@iDeliveryOrderDate"].Value = iDeliveryOrderDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@deliveryAddress"].Value = deliveryAddress;
			scom.Parameters["@dateIn"].Value = dateIn;
			scom.Parameters["@dateOut"].Value = dateOut;
			scom.Parameters["@customerDeliveryDate"].Value = customerDeliveryDate;
			scom.Parameters["@receiptBy"].Value = receiptBy;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@driver_ID"].Value = driver_ID;
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
			scom.Parameters["@assitant_ID"].Value = assitant_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@cancelReason_ID_DO"].Value = cancelReason_ID_DO;
			scom.Parameters["@currency_ID"].Value = currency_ID;
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
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasInvDeliveryOrder table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@iDeliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iDeliveryOrder_ID"].Value = iDeliveryOrder_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByVehicle_ID(string vehicle_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderDeleteAllByVehicle_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderDeleteAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByAssitant_ID(string assitant_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderDeleteAllByAssitant_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assitant_ID", SqlDbType.VarChar,10);
			scom.Parameters["@assitant_ID"].Value = assitant_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByDriver_ID(string driver_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderDeleteAllByDriver_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters["@driver_ID"].Value = driver_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasInvDeliveryOrder table.
		/// </summary>
		public static tbl_sasInvDeliveryOrder Select(string iDeliveryOrder_ID_Incoming){

			tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrderins = new tbl_sasInvDeliveryOrder();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iDeliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iDeliveryOrder_ID"].Value = iDeliveryOrder_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasInvDeliveryOrderins = Maketbl_sasInvDeliveryOrder(dataReader);
				} else {
					tbl_sasInvDeliveryOrderins = null;
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrderins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasInvDeliveryOrder> tbl_sasInvDeliveryOrderList = new List<tbl_sasInvDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrder = Maketbl_sasInvDeliveryOrder(dataReader);
					tbl_sasInvDeliveryOrderList.Add(tbl_sasInvDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder> SelectAllByVehicle_ID(string vehicle_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderSelectAllByVehicle_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@vehicle_ID", SqlDbType.VarChar,10);
			scom.Parameters["@vehicle_ID"].Value = vehicle_ID;
				List<tbl_sasInvDeliveryOrder> tbl_sasInvDeliveryOrderList = new List<tbl_sasInvDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrder = Maketbl_sasInvDeliveryOrder(dataReader);
					tbl_sasInvDeliveryOrderList.Add(tbl_sasInvDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder> SelectAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderSelectAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
				List<tbl_sasInvDeliveryOrder> tbl_sasInvDeliveryOrderList = new List<tbl_sasInvDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrder = Maketbl_sasInvDeliveryOrder(dataReader);
					tbl_sasInvDeliveryOrderList.Add(tbl_sasInvDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder> SelectAllByAssitant_ID(string assitant_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderSelectAllByAssitant_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@assitant_ID", SqlDbType.VarChar,10);
			scom.Parameters["@assitant_ID"].Value = assitant_ID;
				List<tbl_sasInvDeliveryOrder> tbl_sasInvDeliveryOrderList = new List<tbl_sasInvDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrder = Maketbl_sasInvDeliveryOrder(dataReader);
					tbl_sasInvDeliveryOrderList.Add(tbl_sasInvDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_sasInvDeliveryOrder> tbl_sasInvDeliveryOrderList = new List<tbl_sasInvDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrder = Maketbl_sasInvDeliveryOrder(dataReader);
					tbl_sasInvDeliveryOrderList.Add(tbl_sasInvDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_sasInvDeliveryOrder> tbl_sasInvDeliveryOrderList = new List<tbl_sasInvDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrder = Maketbl_sasInvDeliveryOrder(dataReader);
					tbl_sasInvDeliveryOrderList.Add(tbl_sasInvDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_sasInvDeliveryOrder> tbl_sasInvDeliveryOrderList = new List<tbl_sasInvDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrder = Maketbl_sasInvDeliveryOrder(dataReader);
					tbl_sasInvDeliveryOrderList.Add(tbl_sasInvDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder> SelectAllByDriver_ID(string driver_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderSelectAllByDriver_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@driver_ID", SqlDbType.VarChar,10);
			scom.Parameters["@driver_ID"].Value = driver_ID;
				List<tbl_sasInvDeliveryOrder> tbl_sasInvDeliveryOrderList = new List<tbl_sasInvDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrder = Maketbl_sasInvDeliveryOrder(dataReader);
					tbl_sasInvDeliveryOrderList.Add(tbl_sasInvDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrderSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_sasInvDeliveryOrder> tbl_sasInvDeliveryOrderList = new List<tbl_sasInvDeliveryOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrder = Maketbl_sasInvDeliveryOrder(dataReader);
					tbl_sasInvDeliveryOrderList.Add(tbl_sasInvDeliveryOrder);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrderList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasInvDeliveryOrder class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasInvDeliveryOrder Maketbl_sasInvDeliveryOrder(SqlDataReader dataReader) {
			tbl_sasInvDeliveryOrder tbl_sasInvDeliveryOrder = new tbl_sasInvDeliveryOrder();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasInvDeliveryOrder.IDeliveryOrder_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasInvDeliveryOrder.IDeliveryOrderDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasInvDeliveryOrder.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasInvDeliveryOrder.DeliveryAddress = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasInvDeliveryOrder.DateIn = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasInvDeliveryOrder.DateOut = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasInvDeliveryOrder.CustomerDeliveryDate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasInvDeliveryOrder.ReceiptBy = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasInvDeliveryOrder.Customer_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasInvDeliveryOrder.Invoice_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasInvDeliveryOrder.Driver_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasInvDeliveryOrder.Vehicle_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasInvDeliveryOrder.Assitant_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasInvDeliveryOrder.Store_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasInvDeliveryOrder.Employee_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasInvDeliveryOrder.OrderRefNo_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasInvDeliveryOrder.CancelReason_ID_DO = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasInvDeliveryOrder.Currency_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasInvDeliveryOrder.CurrencyRate = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasInvDeliveryOrder.DiscountPercentage = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasInvDeliveryOrder.NbtPercentage = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasInvDeliveryOrder.VatPercentage = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasInvDeliveryOrder.OtherTaxPercentage = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasInvDeliveryOrder.SubTotal = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_sasInvDeliveryOrder.DiscountTotal = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_sasInvDeliveryOrder.NbtTotal = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_sasInvDeliveryOrder.VatTotal = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_sasInvDeliveryOrder.OtherTaxTotal = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_sasInvDeliveryOrder.GrandTotal = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_sasInvDeliveryOrder.RecommendedSubTotal = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_sasInvDeliveryOrder.RecommendedGrandTotal = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_sasInvDeliveryOrder.CreateUser_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_sasInvDeliveryOrder.ModifiedUser_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_sasInvDeliveryOrder.CheckedUser_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_sasInvDeliveryOrder.ApprovedUser_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_sasInvDeliveryOrder.DeletedUser_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_sasInvDeliveryOrder.PrintedUser_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_sasInvDeliveryOrder.CreateTerminal_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_sasInvDeliveryOrder.ModifiedTerminal_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_sasInvDeliveryOrder.DeletedTerminal_ID = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_sasInvDeliveryOrder.PrintedTerminal_ID = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_sasInvDeliveryOrder.DateCreate = dataReader.GetDateTime(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_sasInvDeliveryOrder.DateModified = dataReader.GetDateTime(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_sasInvDeliveryOrder.DateChecked = dataReader.GetDateTime(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_sasInvDeliveryOrder.DateApproved = dataReader.GetDateTime(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_sasInvDeliveryOrder.DateDeleted = dataReader.GetDateTime(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_sasInvDeliveryOrder.DatePrinted = dataReader.GetDateTime(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_sasInvDeliveryOrder.IsChecked = dataReader.GetBoolean(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_sasInvDeliveryOrder.IsApproved = dataReader.GetBoolean(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_sasInvDeliveryOrder.IsFinished = dataReader.GetBoolean(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_sasInvDeliveryOrder.IsDeleted = dataReader.GetBoolean(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_sasInvDeliveryOrder.IsLocked = dataReader.GetBoolean(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_sasInvDeliveryOrder.IsSeattled = dataReader.GetBoolean(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_sasInvDeliveryOrder.IsWeightCalculation = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_sasInvDeliveryOrder.PrintCount = dataReader.GetInt32(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_sasInvDeliveryOrder.IsPriceEnabled = dataReader.GetBoolean(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_sasInvDeliveryOrder.IsTaxReverseCalulation = dataReader.GetBoolean(56);
			}

			return tbl_sasInvDeliveryOrder;
		}
		/// <summary>
		/// This makes tbl_sasInvDeliveryOrder datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasInvDeliveryOrder object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasInvDeliveryOrder  tbl_sasInvDeliveryOrder   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_iDeliveryOrder_ID = new DataColumn("iDeliveryOrder_ID" , typeof(string));
			DataColumn col_iDeliveryOrderDate = new DataColumn("iDeliveryOrderDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_deliveryAddress = new DataColumn("deliveryAddress" , typeof(string));
			DataColumn col_dateIn = new DataColumn("dateIn" , typeof(DateTime));
			DataColumn col_dateOut = new DataColumn("dateOut" , typeof(DateTime));
			DataColumn col_customerDeliveryDate = new DataColumn("customerDeliveryDate" , typeof(DateTime));
			DataColumn col_receiptBy = new DataColumn("receiptBy" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_driver_ID = new DataColumn("driver_ID" , typeof(string));
			DataColumn col_vehicle_ID = new DataColumn("vehicle_ID" , typeof(string));
			DataColumn col_assitant_ID = new DataColumn("assitant_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_cancelReason_ID_DO = new DataColumn("cancelReason_ID_DO" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_iDeliveryOrder_ID,col_iDeliveryOrderDate,col_remark,col_deliveryAddress,col_dateIn,col_dateOut,col_customerDeliveryDate,col_receiptBy,col_customer_ID,col_invoice_ID,col_driver_ID,col_vehicle_ID,col_assitant_ID,col_store_ID,col_employee_ID,col_orderRefNo_ID,col_cancelReason_ID_DO,col_currency_ID,col_currencyRate,col_discountPercentage,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grandTotal,col_recommendedSubTotal,col_recommendedGrandTotal,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,col_isWeightCalculation,col_printCount,col_isPriceEnabled,col_isTaxReverseCalulation,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasInvDeliveryOrder datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasInvDeliveryOrder object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasInvDeliveryOrder user) {
		DataRow drow = dt.NewRow();
		
			drow["iDeliveryOrder_ID"] = user.iDeliveryOrder_ID;
			drow["iDeliveryOrderDate"] = user.iDeliveryOrderDate;
			drow["remark"] = user.remark;
			drow["deliveryAddress"] = user.deliveryAddress;
			drow["dateIn"] = user.dateIn;
			drow["dateOut"] = user.dateOut;
			drow["customerDeliveryDate"] = user.customerDeliveryDate;
			drow["receiptBy"] = user.receiptBy;
			drow["customer_ID"] = user.customer_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["driver_ID"] = user.driver_ID;
			drow["vehicle_ID"] = user.vehicle_ID;
			drow["assitant_ID"] = user.assitant_ID;
			drow["store_ID"] = user.store_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["cancelReason_ID_DO"] = user.cancelReason_ID_DO;
			drow["currency_ID"] = user.currency_ID;
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
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
