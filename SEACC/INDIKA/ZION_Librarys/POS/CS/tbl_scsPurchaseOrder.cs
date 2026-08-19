using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsPurchaseOrder {
		#region Fields
		private string purchaseOrder_ID;
		private DateTime purchaseOrderDate;
		private string issuedRefNo_ID;
		private string paymentMethod_ID;
		private string purchaseRequisitionNote_ID;
		private string quotation_ID;
		private string stockNoteType_ID;
		private string remark;
		private string deliveryAddress;
		private DateTime dueDate;
		private string deliveryTerms;
		private string orderdBy;
		private string contactNo;
		private string verifyEmail;
		private decimal advanceAmount;
		private decimal onDeliveryAmount;
		private decimal balanceDays;
		private decimal forexRate;
		private string currency_ID;
		private string supplier_ID;
		private string quotaionNo;
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
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
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
		private bool isTIEP;
		private string companyID;
		private string companyBranch_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsPurchaseOrder class.
		/// </summary>
		public tbl_scsPurchaseOrder() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsPurchaseOrder class.
		/// </summary>
		public tbl_scsPurchaseOrder(string purchaseOrder_ID, DateTime purchaseOrderDate, string issuedRefNo_ID, string paymentMethod_ID, string purchaseRequisitionNote_ID, string quotation_ID, string stockNoteType_ID, string remark, string deliveryAddress, DateTime dueDate, string deliveryTerms, string orderdBy, string contactNo, string verifyEmail, decimal advanceAmount, decimal onDeliveryAmount, decimal balanceDays, decimal forexRate, string currency_ID, string supplier_ID, string quotaionNo, string glPosting_ID, string costCenter, string postingStatus_ID, string financialYear_ID, decimal discountPercentage, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal subTotal, decimal discountTotal, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grandTotal, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, decimal seattleAmount, bool isSeattled, int printCount, bool isWeightCalculation, bool isVAT, bool isSVAT, bool isTIEP, string companyID, string companyBranch_ID) {
			this.purchaseOrder_ID = purchaseOrder_ID;
			this.purchaseOrderDate = purchaseOrderDate;
			this.issuedRefNo_ID = issuedRefNo_ID;
			this.paymentMethod_ID = paymentMethod_ID;
			this.purchaseRequisitionNote_ID = purchaseRequisitionNote_ID;
			this.quotation_ID = quotation_ID;
			this.stockNoteType_ID = stockNoteType_ID;
			this.remark = remark;
			this.deliveryAddress = deliveryAddress;
			this.dueDate = dueDate;
			this.deliveryTerms = deliveryTerms;
			this.orderdBy = orderdBy;
			this.contactNo = contactNo;
			this.verifyEmail = verifyEmail;
			this.advanceAmount = advanceAmount;
			this.onDeliveryAmount = onDeliveryAmount;
			this.balanceDays = balanceDays;
			this.forexRate = forexRate;
			this.currency_ID = currency_ID;
			this.supplier_ID = supplier_ID;
			this.quotaionNo = quotaionNo;
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
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
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
			this.isTIEP = isTIEP;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PurchaseOrder_ID value.
		/// </summary>
		public string PurchaseOrder_ID {
			get { return purchaseOrder_ID; }
			set { purchaseOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseOrderDate value.
		/// </summary>
		public DateTime PurchaseOrderDate {
			get { return purchaseOrderDate; }
			set { purchaseOrderDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IssuedRefNo_ID value.
		/// </summary>
		public string IssuedRefNo_ID {
			get { return issuedRefNo_ID; }
			set { issuedRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentMethod_ID value.
		/// </summary>
		public string PaymentMethod_ID {
			get { return paymentMethod_ID; }
			set { paymentMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseRequisitionNote_ID value.
		/// </summary>
		public string PurchaseRequisitionNote_ID {
			get { return purchaseRequisitionNote_ID; }
			set { purchaseRequisitionNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Quotation_ID value.
		/// </summary>
		public string Quotation_ID {
			get { return quotation_ID; }
			set { quotation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StockNoteType_ID value.
		/// </summary>
		public string StockNoteType_ID {
			get { return stockNoteType_ID; }
			set { stockNoteType_ID = value; }
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
		/// Gets or sets the DueDate value.
		/// </summary>
		public DateTime DueDate {
			get { return dueDate; }
			set { dueDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryTerms value.
		/// </summary>
		public string DeliveryTerms {
			get { return deliveryTerms; }
			set { deliveryTerms = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderdBy value.
		/// </summary>
		public string OrderdBy {
			get { return orderdBy; }
			set { orderdBy = value; }
		}
		
		/// <summary>
		/// Gets or sets the ContactNo value.
		/// </summary>
		public string ContactNo {
			get { return contactNo; }
			set { contactNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the VerifyEmail value.
		/// </summary>
		public string VerifyEmail {
			get { return verifyEmail; }
			set { verifyEmail = value; }
		}
		
		/// <summary>
		/// Gets or sets the AdvanceAmount value.
		/// </summary>
		public decimal AdvanceAmount {
			get { return advanceAmount; }
			set { advanceAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the OnDeliveryAmount value.
		/// </summary>
		public decimal OnDeliveryAmount {
			get { return onDeliveryAmount; }
			set { onDeliveryAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the BalanceDays value.
		/// </summary>
		public decimal BalanceDays {
			get { return balanceDays; }
			set { balanceDays = value; }
		}
		
		/// <summary>
		/// Gets or sets the ForexRate value.
		/// </summary>
		public decimal ForexRate {
			get { return forexRate; }
			set { forexRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the QuotaionNo value.
		/// </summary>
		public string QuotaionNo {
			get { return quotaionNo; }
			set { quotaionNo = value; }
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
		/// Gets or sets the IsTIEP value.
		/// </summary>
		public bool IsTIEP {
			get { return isTIEP; }
			set { isTIEP = value; }
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
		/// Saves a record to the tbl_scsPurchaseOrder table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@purchaseRequisitionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@deliveryAddress", SqlDbType.VarChar,500);
			scom.Parameters.Add("@dueDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveryTerms", SqlDbType.VarChar,100);
			scom.Parameters.Add("@orderdBy", SqlDbType.VarChar,100);
			scom.Parameters.Add("@contactNo", SqlDbType.VarChar,100);
			scom.Parameters.Add("@verifyEmail", SqlDbType.VarChar,100);
			scom.Parameters.Add("@advanceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@onDeliveryAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@balanceDays", SqlDbType.Decimal,9);
			scom.Parameters.Add("@forexRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotaionNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@CostCenter", SqlDbType.VarChar,50);
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
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
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
			scom.Parameters.Add("@isTIEP", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@purchaseOrderDate"].Value = purchaseOrderDate;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@purchaseRequisitionNote_ID"].Value = purchaseRequisitionNote_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@deliveryAddress"].Value = deliveryAddress;
			scom.Parameters["@dueDate"].Value = dueDate;
			scom.Parameters["@deliveryTerms"].Value = deliveryTerms;
			scom.Parameters["@orderdBy"].Value = orderdBy;
			scom.Parameters["@contactNo"].Value = contactNo;
			scom.Parameters["@verifyEmail"].Value = verifyEmail;
			scom.Parameters["@advanceAmount"].Value = advanceAmount;
			scom.Parameters["@onDeliveryAmount"].Value = onDeliveryAmount;
			scom.Parameters["@balanceDays"].Value = balanceDays;
			scom.Parameters["@forexRate"].Value = forexRate;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@quotaionNo"].Value = quotaionNo;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@CostCenter"].Value = costCenter;
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
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
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
			scom.Parameters["@isTIEP"].Value = isTIEP;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsPurchaseOrder table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@purchaseRequisitionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@stockNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@deliveryAddress", SqlDbType.VarChar,500);
			scom.Parameters.Add("@dueDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveryTerms", SqlDbType.VarChar,100);
			scom.Parameters.Add("@orderdBy", SqlDbType.VarChar,100);
			scom.Parameters.Add("@contactNo", SqlDbType.VarChar,100);
			scom.Parameters.Add("@verifyEmail", SqlDbType.VarChar,100);
			scom.Parameters.Add("@advanceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@onDeliveryAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@balanceDays", SqlDbType.Decimal,9);
			scom.Parameters.Add("@forexRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotaionNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@CostCenter", SqlDbType.VarChar,50);
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
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
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
			scom.Parameters.Add("@isTIEP", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@purchaseOrderDate"].Value = purchaseOrderDate;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@purchaseRequisitionNote_ID"].Value = purchaseRequisitionNote_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@stockNoteType_ID"].Value = stockNoteType_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@deliveryAddress"].Value = deliveryAddress;
			scom.Parameters["@dueDate"].Value = dueDate;
			scom.Parameters["@deliveryTerms"].Value = deliveryTerms;
			scom.Parameters["@orderdBy"].Value = orderdBy;
			scom.Parameters["@contactNo"].Value = contactNo;
			scom.Parameters["@verifyEmail"].Value = verifyEmail;
			scom.Parameters["@advanceAmount"].Value = advanceAmount;
			scom.Parameters["@onDeliveryAmount"].Value = onDeliveryAmount;
			scom.Parameters["@balanceDays"].Value = balanceDays;
			scom.Parameters["@forexRate"].Value = forexRate;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@quotaionNo"].Value = quotaionNo;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@CostCenter"].Value = costCenter;
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
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
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
			scom.Parameters["@isTIEP"].Value = isTIEP;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsPurchaseOrder table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByPaymentMethod_ID(string paymentMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderDeleteAllByPaymentMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderDeleteAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
        /// <summary>
        /// Selects all records from the tbl_scsPurchaseOrder table by a foreign key.
        /// </summary>
        public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderDeleteAllByCompanyBranch_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseOrder table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsPurchaseOrder table.
		/// </summary>
		public static tbl_scsPurchaseOrder Select(string purchaseOrder_ID_Incoming){

			tbl_scsPurchaseOrder tbl_scsPurchaseOrderins = new tbl_scsPurchaseOrder();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsPurchaseOrderins = Maketbl_scsPurchaseOrder(dataReader);
				} else {
					tbl_scsPurchaseOrderins = null;
				}
			}
			scon.Close();
			return tbl_scsPurchaseOrderins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseOrder table.
		/// </summary>
		public static List<tbl_scsPurchaseOrder> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsPurchaseOrder> tbl_scsPurchaseOrderList = new List<tbl_scsPurchaseOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsPurchaseOrder tbl_scsPurchaseOrder = Maketbl_scsPurchaseOrder(dataReader);
					tbl_scsPurchaseOrderList.Add(tbl_scsPurchaseOrder);
				}
			}
			scon.Close();
			return tbl_scsPurchaseOrderList;
		}
      
        public static List<tbl_scsPurchaseOrder> SelectAllByQuotation_ID(string quotation_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderSelectAllByQuotation_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@quotation_ID"].Value = quotation_ID;
            List<tbl_scsPurchaseOrder> tbl_scsPurchaseOrderList = new List<tbl_scsPurchaseOrder>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_scsPurchaseOrder tbl_scsPurchaseOrder = Maketbl_scsPurchaseOrder(dataReader);
                    tbl_scsPurchaseOrderList.Add(tbl_scsPurchaseOrder);
                }
            }
            scon.Close();
            return tbl_scsPurchaseOrderList;
        }
        /// <summary>
        /// Selects all records from the tbl_scsPurchaseOrder table by a foreign key.
        /// </summary>
        public static List<tbl_scsPurchaseOrder> SelectAllByCompanyID(string companyID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderSelectAllByCompanyID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
            scom.Parameters["@companyID"].Value = companyID;
            List<tbl_scsPurchaseOrder> tbl_scsPurchaseOrderList = new List<tbl_scsPurchaseOrder>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_scsPurchaseOrder tbl_scsPurchaseOrder = Maketbl_scsPurchaseOrder(dataReader);
                    tbl_scsPurchaseOrderList.Add(tbl_scsPurchaseOrder);
                }
            }
            scon.Close();
            return tbl_scsPurchaseOrderList;
        }

		/// <summary>
		/// Selects all records from the tbl_scsPurchaseOrder table by a foreign key.
		/// </summary>
		public static List<tbl_scsPurchaseOrder> SelectAllByPaymentMethod_ID(string paymentMethod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderSelectAllByPaymentMethod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,10);
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
				List<tbl_scsPurchaseOrder> tbl_scsPurchaseOrderList = new List<tbl_scsPurchaseOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsPurchaseOrder tbl_scsPurchaseOrder = Maketbl_scsPurchaseOrder(dataReader);
					tbl_scsPurchaseOrderList.Add(tbl_scsPurchaseOrder);
				}
			}
			scon.Close();
			return tbl_scsPurchaseOrderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseOrder table by a foreign key.
		/// </summary>
		public static List<tbl_scsPurchaseOrder> SelectAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderSelectAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
				List<tbl_scsPurchaseOrder> tbl_scsPurchaseOrderList = new List<tbl_scsPurchaseOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsPurchaseOrder tbl_scsPurchaseOrder = Maketbl_scsPurchaseOrder(dataReader);
					tbl_scsPurchaseOrderList.Add(tbl_scsPurchaseOrder);
				}
			}
			scon.Close();
			return tbl_scsPurchaseOrderList;
		}
        public static List<tbl_scsPurchaseOrder> SelectAllByPurchaseRequisitionNote_ID(string purchaseRequisitionNote_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderSelectAllByPurchaseRequisitionNote_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@purchaseRequisitionNote_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@purchaseRequisitionNote_ID"].Value = purchaseRequisitionNote_ID;
            List<tbl_scsPurchaseOrder> tbl_scsPurchaseOrderList = new List<tbl_scsPurchaseOrder>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_scsPurchaseOrder tbl_scsPurchaseOrder = Maketbl_scsPurchaseOrder(dataReader);
                    tbl_scsPurchaseOrderList.Add(tbl_scsPurchaseOrder);
                }
            }
            scon.Close();
            return tbl_scsPurchaseOrderList;
        }
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseOrder table by a foreign key.
		/// </summary>
		public static List<tbl_scsPurchaseOrder> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseOrderSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_scsPurchaseOrder> tbl_scsPurchaseOrderList = new List<tbl_scsPurchaseOrder>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsPurchaseOrder tbl_scsPurchaseOrder = Maketbl_scsPurchaseOrder(dataReader);
					tbl_scsPurchaseOrderList.Add(tbl_scsPurchaseOrder);
				}
			}
			scon.Close();
			return tbl_scsPurchaseOrderList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsPurchaseOrder class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsPurchaseOrder Maketbl_scsPurchaseOrder(SqlDataReader dataReader) {
			tbl_scsPurchaseOrder tbl_scsPurchaseOrder = new tbl_scsPurchaseOrder();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsPurchaseOrder.PurchaseOrder_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsPurchaseOrder.PurchaseOrderDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsPurchaseOrder.IssuedRefNo_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsPurchaseOrder.PaymentMethod_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsPurchaseOrder.PurchaseRequisitionNote_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsPurchaseOrder.Quotation_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsPurchaseOrder.StockNoteType_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsPurchaseOrder.Remark = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsPurchaseOrder.DeliveryAddress = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsPurchaseOrder.DueDate = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsPurchaseOrder.DeliveryTerms = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsPurchaseOrder.OrderdBy = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsPurchaseOrder.ContactNo = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsPurchaseOrder.VerifyEmail = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsPurchaseOrder.AdvanceAmount = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsPurchaseOrder.OnDeliveryAmount = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsPurchaseOrder.BalanceDays = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsPurchaseOrder.ForexRate = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsPurchaseOrder.Currency_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsPurchaseOrder.Supplier_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsPurchaseOrder.QuotaionNo = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsPurchaseOrder.GlPosting_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsPurchaseOrder.CostCenter = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsPurchaseOrder.PostingStatus_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsPurchaseOrder.FinancialYear_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_scsPurchaseOrder.DiscountPercentage = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_scsPurchaseOrder.NbtPercentage = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_scsPurchaseOrder.VatPercentage = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_scsPurchaseOrder.OtherTaxPercentage = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_scsPurchaseOrder.SubTotal = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_scsPurchaseOrder.DiscountTotal = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_scsPurchaseOrder.NbtTotal = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_scsPurchaseOrder.VatTotal = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_scsPurchaseOrder.OtherTaxTotal = dataReader.GetDecimal(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_scsPurchaseOrder.GrandTotal = dataReader.GetDecimal(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_scsPurchaseOrder.CreateUser_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_scsPurchaseOrder.ModifiedUser_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_scsPurchaseOrder.CheckedUser_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_scsPurchaseOrder.ApprovedUser_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_scsPurchaseOrder.DateCreate = dataReader.GetDateTime(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_scsPurchaseOrder.DateModified = dataReader.GetDateTime(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_scsPurchaseOrder.DateChecked = dataReader.GetDateTime(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_scsPurchaseOrder.DateApproved = dataReader.GetDateTime(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_scsPurchaseOrder.IsChecked = dataReader.GetBoolean(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_scsPurchaseOrder.IsApproved = dataReader.GetBoolean(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_scsPurchaseOrder.IsFinished = dataReader.GetBoolean(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_scsPurchaseOrder.IsDeleted = dataReader.GetBoolean(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_scsPurchaseOrder.IsLocked = dataReader.GetBoolean(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_scsPurchaseOrder.SeattleAmount = dataReader.GetDecimal(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_scsPurchaseOrder.IsSeattled = dataReader.GetBoolean(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_scsPurchaseOrder.PrintCount = dataReader.GetInt32(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_scsPurchaseOrder.IsWeightCalculation = dataReader.GetBoolean(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_scsPurchaseOrder.IsVAT = dataReader.GetBoolean(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_scsPurchaseOrder.IsSVAT = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_scsPurchaseOrder.IsTIEP = dataReader.GetBoolean(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_scsPurchaseOrder.CompanyID = dataReader.GetString(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_scsPurchaseOrder.CompanyBranch_ID = dataReader.GetString(56);
			}

			return tbl_scsPurchaseOrder;
		}
		/// <summary>
		/// This makes tbl_scsPurchaseOrder datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsPurchaseOrder object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsPurchaseOrder  tbl_scsPurchaseOrder   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_purchaseOrder_ID = new DataColumn("purchaseOrder_ID" , typeof(string));
			DataColumn col_purchaseOrderDate = new DataColumn("purchaseOrderDate" , typeof(DateTime));
			DataColumn col_IssuedRefNo_ID = new DataColumn("IssuedRefNo_ID" , typeof(string));
			DataColumn col_paymentMethod_ID = new DataColumn("paymentMethod_ID" , typeof(string));
			DataColumn col_purchaseRequisitionNote_ID = new DataColumn("purchaseRequisitionNote_ID" , typeof(string));
			DataColumn col_quotation_ID = new DataColumn("quotation_ID" , typeof(string));
			DataColumn col_stockNoteType_ID = new DataColumn("stockNoteType_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_deliveryAddress = new DataColumn("deliveryAddress" , typeof(string));
			DataColumn col_dueDate = new DataColumn("dueDate" , typeof(DateTime));
			DataColumn col_deliveryTerms = new DataColumn("deliveryTerms" , typeof(string));
			DataColumn col_orderdBy = new DataColumn("orderdBy" , typeof(string));
			DataColumn col_contactNo = new DataColumn("contactNo" , typeof(string));
			DataColumn col_verifyEmail = new DataColumn("verifyEmail" , typeof(string));
			DataColumn col_advanceAmount = new DataColumn("advanceAmount" , typeof(decimal));
			DataColumn col_onDeliveryAmount = new DataColumn("onDeliveryAmount" , typeof(decimal));
			DataColumn col_balanceDays = new DataColumn("balanceDays" , typeof(decimal));
			DataColumn col_forexRate = new DataColumn("forexRate" , typeof(decimal));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_quotaionNo = new DataColumn("quotaionNo" , typeof(string));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_CostCenter = new DataColumn("CostCenter" , typeof(string));
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
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
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
			DataColumn col_isTIEP = new DataColumn("isTIEP" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_purchaseOrder_ID,col_purchaseOrderDate,col_IssuedRefNo_ID,col_paymentMethod_ID,col_purchaseRequisitionNote_ID,col_quotation_ID,col_stockNoteType_ID,col_remark,col_deliveryAddress,col_dueDate,col_deliveryTerms,col_orderdBy,col_contactNo,col_verifyEmail,col_advanceAmount,col_onDeliveryAmount,col_balanceDays,col_forexRate,col_currency_ID,col_supplier_ID,col_quotaionNo,col_glPosting_ID,col_CostCenter,col_postingStatus_ID,col_financialYear_ID,col_discountPercentage,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_subTotal,col_discountTotal,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grandTotal,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_seattleAmount,col_isSeattled,col_printCount,col_isWeightCalculation,col_isVAT,col_isSVAT,col_isTIEP,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsPurchaseOrder datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsPurchaseOrder object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsPurchaseOrder user) {
		DataRow drow = dt.NewRow();
		
			drow["purchaseOrder_ID"] = user.purchaseOrder_ID;
			drow["purchaseOrderDate"] = user.purchaseOrderDate;
			drow["IssuedRefNo_ID"] = user.IssuedRefNo_ID;
			drow["paymentMethod_ID"] = user.paymentMethod_ID;
			drow["purchaseRequisitionNote_ID"] = user.purchaseRequisitionNote_ID;
			drow["quotation_ID"] = user.quotation_ID;
			drow["stockNoteType_ID"] = user.stockNoteType_ID;
			drow["remark"] = user.remark;
			drow["deliveryAddress"] = user.deliveryAddress;
			drow["dueDate"] = user.dueDate;
			drow["deliveryTerms"] = user.deliveryTerms;
			drow["orderdBy"] = user.orderdBy;
			drow["contactNo"] = user.contactNo;
			drow["verifyEmail"] = user.verifyEmail;
			drow["advanceAmount"] = user.advanceAmount;
			drow["onDeliveryAmount"] = user.onDeliveryAmount;
			drow["balanceDays"] = user.balanceDays;
			drow["forexRate"] = user.forexRate;
			drow["currency_ID"] = user.currency_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["quotaionNo"] = user.quotaionNo;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["CostCenter"] = user.CostCenter;
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
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
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
			drow["isTIEP"] = user.isTIEP;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
