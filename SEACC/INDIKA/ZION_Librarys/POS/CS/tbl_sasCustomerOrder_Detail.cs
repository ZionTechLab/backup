using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasCustomerOrder_Detail {
		#region Fields
		private int line_No;
		private string customerOrder_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string purchaseOrder_ID;
		private string inquiry_ID;
		private string proformaInvoice_ID;
		private string quotation_ID;
		private string job_ID;
		private decimal qty;
		private decimal qtySettle_DeliveryOrder;
		private decimal qtySettle_Invoice;
		private decimal weight;
		private decimal weightSettle_DeliveryOrder;
		private decimal weightSettle_Invoice;
		private decimal unitPrice;
		private decimal weightPrice;
		private bool bIsFreeItem;
		private decimal discountPresentage;
		private decimal discountAmount;
		private decimal tatalAmount;
		private decimal recommendedUnitPrice;
		private decimal recommendedWeightPrice;
		private decimal recommendedunitTotalAmount;
		private string remark;
		private bool isHasProductionJob;
		private bool isWeightCalculation;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasCustomerOrder_Detail class.
		/// </summary>
		public tbl_sasCustomerOrder_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasCustomerOrder_Detail class.
		/// </summary>
		public tbl_sasCustomerOrder_Detail(int line_No, string customerOrder_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string purchaseOrder_ID, string inquiry_ID, string proformaInvoice_ID, string quotation_ID, string job_ID, decimal qty, decimal qtySettle_DeliveryOrder, decimal qtySettle_Invoice, decimal weight, decimal weightSettle_DeliveryOrder, decimal weightSettle_Invoice, decimal unitPrice, decimal weightPrice, bool bIsFreeItem, decimal discountPresentage, decimal discountAmount, decimal tatalAmount, decimal recommendedUnitPrice, decimal recommendedWeightPrice, decimal recommendedunitTotalAmount, string remark, bool isHasProductionJob, bool isWeightCalculation) {
			this.line_No = line_No;
			this.customerOrder_ID = customerOrder_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.purchaseOrder_ID = purchaseOrder_ID;
			this.inquiry_ID = inquiry_ID;
			this.proformaInvoice_ID = proformaInvoice_ID;
			this.quotation_ID = quotation_ID;
			this.job_ID = job_ID;
			this.qty = qty;
			this.qtySettle_DeliveryOrder = qtySettle_DeliveryOrder;
			this.qtySettle_Invoice = qtySettle_Invoice;
			this.weight = weight;
			this.weightSettle_DeliveryOrder = weightSettle_DeliveryOrder;
			this.weightSettle_Invoice = weightSettle_Invoice;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.bIsFreeItem = bIsFreeItem;
			this.discountPresentage = discountPresentage;
			this.discountAmount = discountAmount;
			this.tatalAmount = tatalAmount;
			this.recommendedUnitPrice = recommendedUnitPrice;
			this.recommendedWeightPrice = recommendedWeightPrice;
			this.recommendedunitTotalAmount = recommendedunitTotalAmount;
			this.remark = remark;
			this.isHasProductionJob = isHasProductionJob;
			this.isWeightCalculation = isWeightCalculation;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory_ID value.
		/// </summary>
		public string ItemSubCategory_ID {
			get { return itemSubCategory_ID; }
			set { itemSubCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory2_ID value.
		/// </summary>
		public string ItemSubCategory2_ID {
			get { return itemSubCategory2_ID; }
			set { itemSubCategory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo2 value.
		/// </summary>
		public string ItemSerialNo2 {
			get { return itemSerialNo2; }
			set { itemSerialNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseOrder_ID value.
		/// </summary>
		public string PurchaseOrder_ID {
			get { return purchaseOrder_ID; }
			set { purchaseOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Inquiry_ID value.
		/// </summary>
		public string Inquiry_ID {
			get { return inquiry_ID; }
			set { inquiry_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProformaInvoice_ID value.
		/// </summary>
		public string ProformaInvoice_ID {
			get { return proformaInvoice_ID; }
			set { proformaInvoice_ID = value; }
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
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySettle_DeliveryOrder value.
		/// </summary>
		public decimal QtySettle_DeliveryOrder {
			get { return qtySettle_DeliveryOrder; }
			set { qtySettle_DeliveryOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySettle_Invoice value.
		/// </summary>
		public decimal QtySettle_Invoice {
			get { return qtySettle_Invoice; }
			set { qtySettle_Invoice = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightSettle_DeliveryOrder value.
		/// </summary>
		public decimal WeightSettle_DeliveryOrder {
			get { return weightSettle_DeliveryOrder; }
			set { weightSettle_DeliveryOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightSettle_Invoice value.
		/// </summary>
		public decimal WeightSettle_Invoice {
			get { return weightSettle_Invoice; }
			set { weightSettle_Invoice = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightPrice value.
		/// </summary>
		public decimal WeightPrice {
			get { return weightPrice; }
			set { weightPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the BIsFreeItem value.
		/// </summary>
		public bool BIsFreeItem {
			get { return bIsFreeItem; }
			set { bIsFreeItem = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPresentage value.
		/// </summary>
		public decimal DiscountPresentage {
			get { return discountPresentage; }
			set { discountPresentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountAmount value.
		/// </summary>
		public decimal DiscountAmount {
			get { return discountAmount; }
			set { discountAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the TatalAmount value.
		/// </summary>
		public decimal TatalAmount {
			get { return tatalAmount; }
			set { tatalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the RecommendedUnitPrice value.
		/// </summary>
		public decimal RecommendedUnitPrice {
			get { return recommendedUnitPrice; }
			set { recommendedUnitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the RecommendedWeightPrice value.
		/// </summary>
		public decimal RecommendedWeightPrice {
			get { return recommendedWeightPrice; }
			set { recommendedWeightPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the RecommendedunitTotalAmount value.
		/// </summary>
		public decimal RecommendedunitTotalAmount {
			get { return recommendedunitTotalAmount; }
			set { recommendedunitTotalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsHasProductionJob value.
		/// </summary>
		public bool IsHasProductionJob {
			get { return isHasProductionJob; }
			set { isHasProductionJob = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeightCalculation value.
		/// </summary>
		public bool IsWeightCalculation {
			get { return isWeightCalculation; }
			set { isWeightCalculation = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasCustomerOrder_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle_DeliveryOrder", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle_Invoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle_DeliveryOrder", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle_Invoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isHasProductionJob", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle_DeliveryOrder"].Value = qtySettle_DeliveryOrder;
			scom.Parameters["@qtySettle_Invoice"].Value = qtySettle_Invoice;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle_DeliveryOrder"].Value = weightSettle_DeliveryOrder;
			scom.Parameters["@weightSettle_Invoice"].Value = weightSettle_Invoice;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountAmount"].Value = discountAmount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isHasProductionJob"].Value = isHasProductionJob;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasCustomerOrder_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle_DeliveryOrder", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle_Invoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle_DeliveryOrder", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle_Invoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isHasProductionJob", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle_DeliveryOrder"].Value = qtySettle_DeliveryOrder;
			scom.Parameters["@qtySettle_Invoice"].Value = qtySettle_Invoice;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle_DeliveryOrder"].Value = weightSettle_DeliveryOrder;
			scom.Parameters["@weightSettle_Invoice"].Value = weightSettle_Invoice;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountAmount"].Value = discountAmount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isHasProductionJob"].Value = isHasProductionJob;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasCustomerOrder_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByQuotation_ID(string quotation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailDeleteAllByQuotation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByInquiry_ID(string inquiry_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailDeleteAllByInquiry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByProformaInvoice_ID(string proformaInvoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailDeleteAllByProformaInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasCustomerOrder_Detail table.
		/// </summary>
		public static tbl_sasCustomerOrder_Detail Select(int line_No_Incoming, string customerOrder_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detailins = new tbl_sasCustomerOrder_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasCustomerOrder_Detailins = Maketbl_sasCustomerOrder_Detail(dataReader);
				} else {
					tbl_sasCustomerOrder_Detailins = null;
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasCustomerOrder_Detail> tbl_sasCustomerOrder_DetailList = new List<tbl_sasCustomerOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detail = Maketbl_sasCustomerOrder_Detail(dataReader);
					tbl_sasCustomerOrder_DetailList.Add(tbl_sasCustomerOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Detail> SelectAllByQuotation_ID(string quotation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailSelectAllByQuotation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
				List<tbl_sasCustomerOrder_Detail> tbl_sasCustomerOrder_DetailList = new List<tbl_sasCustomerOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detail = Maketbl_sasCustomerOrder_Detail(dataReader);
					tbl_sasCustomerOrder_DetailList.Add(tbl_sasCustomerOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Detail> SelectAllByInquiry_ID(string inquiry_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailSelectAllByInquiry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
				List<tbl_sasCustomerOrder_Detail> tbl_sasCustomerOrder_DetailList = new List<tbl_sasCustomerOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detail = Maketbl_sasCustomerOrder_Detail(dataReader);
					tbl_sasCustomerOrder_DetailList.Add(tbl_sasCustomerOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_sasCustomerOrder_Detail> tbl_sasCustomerOrder_DetailList = new List<tbl_sasCustomerOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detail = Maketbl_sasCustomerOrder_Detail(dataReader);
					tbl_sasCustomerOrder_DetailList.Add(tbl_sasCustomerOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_sasCustomerOrder_Detail> tbl_sasCustomerOrder_DetailList = new List<tbl_sasCustomerOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detail = Maketbl_sasCustomerOrder_Detail(dataReader);
					tbl_sasCustomerOrder_DetailList.Add(tbl_sasCustomerOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Detail> SelectAllByProformaInvoice_ID(string proformaInvoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailSelectAllByProformaInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
				List<tbl_sasCustomerOrder_Detail> tbl_sasCustomerOrder_DetailList = new List<tbl_sasCustomerOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detail = Maketbl_sasCustomerOrder_Detail(dataReader);
					tbl_sasCustomerOrder_DetailList.Add(tbl_sasCustomerOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_sasCustomerOrder_Detail> tbl_sasCustomerOrder_DetailList = new List<tbl_sasCustomerOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detail = Maketbl_sasCustomerOrder_Detail(dataReader);
					tbl_sasCustomerOrder_DetailList.Add(tbl_sasCustomerOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Detail> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_sasCustomerOrder_Detail> tbl_sasCustomerOrder_DetailList = new List<tbl_sasCustomerOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detail = Maketbl_sasCustomerOrder_Detail(dataReader);
					tbl_sasCustomerOrder_DetailList.Add(tbl_sasCustomerOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Detail> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_DetailSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_sasCustomerOrder_Detail> tbl_sasCustomerOrder_DetailList = new List<tbl_sasCustomerOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detail = Maketbl_sasCustomerOrder_Detail(dataReader);
					tbl_sasCustomerOrder_DetailList.Add(tbl_sasCustomerOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasCustomerOrder_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasCustomerOrder_Detail Maketbl_sasCustomerOrder_Detail(SqlDataReader dataReader) {
			tbl_sasCustomerOrder_Detail tbl_sasCustomerOrder_Detail = new tbl_sasCustomerOrder_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasCustomerOrder_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasCustomerOrder_Detail.CustomerOrder_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasCustomerOrder_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasCustomerOrder_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasCustomerOrder_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasCustomerOrder_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasCustomerOrder_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasCustomerOrder_Detail.PurchaseOrder_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasCustomerOrder_Detail.Inquiry_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasCustomerOrder_Detail.ProformaInvoice_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasCustomerOrder_Detail.Quotation_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasCustomerOrder_Detail.Job_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasCustomerOrder_Detail.Qty = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasCustomerOrder_Detail.QtySettle_DeliveryOrder = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasCustomerOrder_Detail.QtySettle_Invoice = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasCustomerOrder_Detail.Weight = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasCustomerOrder_Detail.WeightSettle_DeliveryOrder = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasCustomerOrder_Detail.WeightSettle_Invoice = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasCustomerOrder_Detail.UnitPrice = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasCustomerOrder_Detail.WeightPrice = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasCustomerOrder_Detail.BIsFreeItem = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasCustomerOrder_Detail.DiscountPresentage = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasCustomerOrder_Detail.DiscountAmount = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasCustomerOrder_Detail.TatalAmount = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_sasCustomerOrder_Detail.RecommendedUnitPrice = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_sasCustomerOrder_Detail.RecommendedWeightPrice = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_sasCustomerOrder_Detail.RecommendedunitTotalAmount = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_sasCustomerOrder_Detail.Remark = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_sasCustomerOrder_Detail.IsHasProductionJob = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_sasCustomerOrder_Detail.IsWeightCalculation = dataReader.GetBoolean(29);
			}

			return tbl_sasCustomerOrder_Detail;
		}
		/// <summary>
		/// This makes tbl_sasCustomerOrder_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasCustomerOrder_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasCustomerOrder_Detail  tbl_sasCustomerOrder_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_purchaseOrder_ID = new DataColumn("purchaseOrder_ID" , typeof(string));
			DataColumn col_inquiry_ID = new DataColumn("inquiry_ID" , typeof(string));
			DataColumn col_proformaInvoice_ID = new DataColumn("proformaInvoice_ID" , typeof(string));
			DataColumn col_quotation_ID = new DataColumn("quotation_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle_DeliveryOrder = new DataColumn("qtySettle_DeliveryOrder" , typeof(decimal));
			DataColumn col_qtySettle_Invoice = new DataColumn("qtySettle_Invoice" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle_DeliveryOrder = new DataColumn("weightSettle_DeliveryOrder" , typeof(decimal));
			DataColumn col_weightSettle_Invoice = new DataColumn("weightSettle_Invoice" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_bIsFreeItem = new DataColumn("bIsFreeItem" , typeof(bool));
			DataColumn col_discountPresentage = new DataColumn("discountPresentage" , typeof(decimal));
			DataColumn col_discountAmount = new DataColumn("discountAmount" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
			DataColumn col_recommendedUnitPrice = new DataColumn("recommendedUnitPrice" , typeof(decimal));
			DataColumn col_recommendedWeightPrice = new DataColumn("recommendedWeightPrice" , typeof(decimal));
			DataColumn col_recommendedunitTotalAmount = new DataColumn("recommendedunitTotalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isHasProductionJob = new DataColumn("isHasProductionJob" , typeof(bool));
			DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_customerOrder_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_purchaseOrder_ID,col_inquiry_ID,col_proformaInvoice_ID,col_quotation_ID,col_job_ID,col_qty,col_qtySettle_DeliveryOrder,col_qtySettle_Invoice,col_weight,col_weightSettle_DeliveryOrder,col_weightSettle_Invoice,col_unitPrice,col_weightPrice,col_bIsFreeItem,col_discountPresentage,col_discountAmount,col_tatalAmount,col_recommendedUnitPrice,col_recommendedWeightPrice,col_recommendedunitTotalAmount,col_remark,col_isHasProductionJob,col_isWeightCalculation,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasCustomerOrder_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasCustomerOrder_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasCustomerOrder_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["purchaseOrder_ID"] = user.purchaseOrder_ID;
			drow["inquiry_ID"] = user.inquiry_ID;
			drow["proformaInvoice_ID"] = user.proformaInvoice_ID;
			drow["quotation_ID"] = user.quotation_ID;
			drow["job_ID"] = user.job_ID;
			drow["qty"] = user.qty;
			drow["qtySettle_DeliveryOrder"] = user.qtySettle_DeliveryOrder;
			drow["qtySettle_Invoice"] = user.qtySettle_Invoice;
			drow["weight"] = user.weight;
			drow["weightSettle_DeliveryOrder"] = user.weightSettle_DeliveryOrder;
			drow["weightSettle_Invoice"] = user.weightSettle_Invoice;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["bIsFreeItem"] = user.bIsFreeItem;
			drow["discountPresentage"] = user.discountPresentage;
			drow["discountAmount"] = user.discountAmount;
			drow["tatalAmount"] = user.tatalAmount;
			drow["recommendedUnitPrice"] = user.recommendedUnitPrice;
			drow["recommendedWeightPrice"] = user.recommendedWeightPrice;
			drow["recommendedunitTotalAmount"] = user.recommendedunitTotalAmount;
			drow["remark"] = user.remark;
			drow["isHasProductionJob"] = user.isHasProductionJob;
			drow["isWeightCalculation"] = user.isWeightCalculation;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
