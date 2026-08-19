using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasQuotation_Detail {
		#region Fields
		private int line_No;
		private string quotation_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string inquiry_ID;
		private string job_ID;
		private decimal qty;
		private decimal qtySettle_PInvoice;
		private decimal qtySettle_CustomerOrder;
		private decimal qtySettle_Invoice;
		private decimal weight;
		private decimal weightSettle_PInvoice;
		private decimal weightSettle_CustomerOrder;
		private decimal weightSettle_Invoice;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal unitDiscount;
		private decimal totalDiscount;
		private bool bIsFreeItem;
		private decimal discountPresentage;
		private decimal discountAmount;
		private decimal tatalAmount;
		private decimal recommendedUnitPrice;
		private decimal recommendedWeightPrice;
		private decimal recommendedunitTotalAmount;
		private string remark;
		private string uom_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasQuotation_Detail class.
		/// </summary>
		public tbl_sasQuotation_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasQuotation_Detail class.
		/// </summary>
		public tbl_sasQuotation_Detail(int line_No, string quotation_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string inquiry_ID, string job_ID, decimal qty, decimal qtySettle_PInvoice, decimal qtySettle_CustomerOrder, decimal qtySettle_Invoice, decimal weight, decimal weightSettle_PInvoice, decimal weightSettle_CustomerOrder, decimal weightSettle_Invoice, decimal unitPrice, decimal weightPrice, decimal unitDiscount, decimal totalDiscount, bool bIsFreeItem, decimal discountPresentage, decimal discountAmount, decimal tatalAmount, decimal recommendedUnitPrice, decimal recommendedWeightPrice, decimal recommendedunitTotalAmount, string remark, string uom_ID) {
			this.line_No = line_No;
			this.quotation_ID = quotation_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.inquiry_ID = inquiry_ID;
			this.job_ID = job_ID;
			this.qty = qty;
			this.qtySettle_PInvoice = qtySettle_PInvoice;
			this.qtySettle_CustomerOrder = qtySettle_CustomerOrder;
			this.qtySettle_Invoice = qtySettle_Invoice;
			this.weight = weight;
			this.weightSettle_PInvoice = weightSettle_PInvoice;
			this.weightSettle_CustomerOrder = weightSettle_CustomerOrder;
			this.weightSettle_Invoice = weightSettle_Invoice;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.unitDiscount = unitDiscount;
			this.totalDiscount = totalDiscount;
			this.bIsFreeItem = bIsFreeItem;
			this.discountPresentage = discountPresentage;
			this.discountAmount = discountAmount;
			this.tatalAmount = tatalAmount;
			this.recommendedUnitPrice = recommendedUnitPrice;
			this.recommendedWeightPrice = recommendedWeightPrice;
			this.recommendedunitTotalAmount = recommendedunitTotalAmount;
			this.remark = remark;
			this.uom_ID = uom_ID;
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
		/// Gets or sets the Quotation_ID value.
		/// </summary>
		public string Quotation_ID {
			get { return quotation_ID; }
			set { quotation_ID = value; }
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
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySettle_PInvoice value.
		/// </summary>
		public decimal QtySettle_PInvoice {
			get { return qtySettle_PInvoice; }
			set { qtySettle_PInvoice = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySettle_CustomerOrder value.
		/// </summary>
		public decimal QtySettle_CustomerOrder {
			get { return qtySettle_CustomerOrder; }
			set { qtySettle_CustomerOrder = value; }
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
		/// Gets or sets the WeightSettle_PInvoice value.
		/// </summary>
		public decimal WeightSettle_PInvoice {
			get { return weightSettle_PInvoice; }
			set { weightSettle_PInvoice = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightSettle_CustomerOrder value.
		/// </summary>
		public decimal WeightSettle_CustomerOrder {
			get { return weightSettle_CustomerOrder; }
			set { weightSettle_CustomerOrder = value; }
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
		/// Gets or sets the UnitDiscount value.
		/// </summary>
		public decimal UnitDiscount {
			get { return unitDiscount; }
			set { unitDiscount = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalDiscount value.
		/// </summary>
		public decimal TotalDiscount {
			get { return totalDiscount; }
			set { totalDiscount = value; }
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
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasQuotation_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotation_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle_PInvoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle_CustomerOrder", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle_Invoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle_PInvoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle_CustomerOrder", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle_Invoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle_PInvoice"].Value = qtySettle_PInvoice;
			scom.Parameters["@qtySettle_CustomerOrder"].Value = qtySettle_CustomerOrder;
			scom.Parameters["@qtySettle_Invoice"].Value = qtySettle_Invoice;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle_PInvoice"].Value = weightSettle_PInvoice;
			scom.Parameters["@weightSettle_CustomerOrder"].Value = weightSettle_CustomerOrder;
			scom.Parameters["@weightSettle_Invoice"].Value = weightSettle_Invoice;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@unitDiscount"].Value = unitDiscount;
			scom.Parameters["@totalDiscount"].Value = totalDiscount;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountAmount"].Value = discountAmount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasQuotation_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotation_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle_PInvoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle_CustomerOrder", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle_Invoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle_PInvoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle_CustomerOrder", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle_Invoice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle_PInvoice"].Value = qtySettle_PInvoice;
			scom.Parameters["@qtySettle_CustomerOrder"].Value = qtySettle_CustomerOrder;
			scom.Parameters["@qtySettle_Invoice"].Value = qtySettle_Invoice;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle_PInvoice"].Value = weightSettle_PInvoice;
			scom.Parameters["@weightSettle_CustomerOrder"].Value = weightSettle_CustomerOrder;
			scom.Parameters["@weightSettle_Invoice"].Value = weightSettle_Invoice;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@unitDiscount"].Value = unitDiscount;
			scom.Parameters["@totalDiscount"].Value = totalDiscount;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountAmount"].Value = discountAmount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasQuotation_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotation_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
 
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
		/// Selects all records from the tbl_sasQuotation_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByQuotation_ID(string quotation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotation_DetailDeleteAllByQuotation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasQuotation_Detail table.
		/// </summary>
		public static tbl_sasQuotation_Detail Select(int line_No_Incoming, string quotation_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_sasQuotation_Detail tbl_sasQuotation_Detailins = new tbl_sasQuotation_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotation_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@quotation_ID"].Value = quotation_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasQuotation_Detailins = Maketbl_sasQuotation_Detail(dataReader);
				} else {
					tbl_sasQuotation_Detailins = null;
				}
			}
			scon.Close();
			return tbl_sasQuotation_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation_Detail table.
		/// </summary>
		public static List<tbl_sasQuotation_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotation_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasQuotation_Detail> tbl_sasQuotation_DetailList = new List<tbl_sasQuotation_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasQuotation_Detail tbl_sasQuotation_Detail = Maketbl_sasQuotation_Detail(dataReader);
					tbl_sasQuotation_DetailList.Add(tbl_sasQuotation_Detail);
				}
			}
			scon.Close();
			return tbl_sasQuotation_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasQuotation_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasQuotation_Detail> SelectAllByQuotation_ID(string quotation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasQuotation_DetailSelectAllByQuotation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
				List<tbl_sasQuotation_Detail> tbl_sasQuotation_DetailList = new List<tbl_sasQuotation_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasQuotation_Detail tbl_sasQuotation_Detail = Maketbl_sasQuotation_Detail(dataReader);
					tbl_sasQuotation_DetailList.Add(tbl_sasQuotation_Detail);
				}
			}
			scon.Close();
			return tbl_sasQuotation_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasQuotation_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasQuotation_Detail Maketbl_sasQuotation_Detail(SqlDataReader dataReader) {
			tbl_sasQuotation_Detail tbl_sasQuotation_Detail = new tbl_sasQuotation_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasQuotation_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasQuotation_Detail.Quotation_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasQuotation_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasQuotation_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasQuotation_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasQuotation_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasQuotation_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasQuotation_Detail.Inquiry_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasQuotation_Detail.Job_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasQuotation_Detail.Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasQuotation_Detail.QtySettle_PInvoice = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasQuotation_Detail.QtySettle_CustomerOrder = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasQuotation_Detail.QtySettle_Invoice = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasQuotation_Detail.Weight = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasQuotation_Detail.WeightSettle_PInvoice = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasQuotation_Detail.WeightSettle_CustomerOrder = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasQuotation_Detail.WeightSettle_Invoice = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasQuotation_Detail.UnitPrice = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasQuotation_Detail.WeightPrice = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasQuotation_Detail.UnitDiscount = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasQuotation_Detail.TotalDiscount = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasQuotation_Detail.BIsFreeItem = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasQuotation_Detail.DiscountPresentage = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasQuotation_Detail.DiscountAmount = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_sasQuotation_Detail.TatalAmount = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_sasQuotation_Detail.RecommendedUnitPrice = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_sasQuotation_Detail.RecommendedWeightPrice = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_sasQuotation_Detail.RecommendedunitTotalAmount = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_sasQuotation_Detail.Remark = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_sasQuotation_Detail.Uom_ID = dataReader.GetString(29);
			}

			return tbl_sasQuotation_Detail;
		}
		/// <summary>
		/// This makes tbl_sasQuotation_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasQuotation_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasQuotation_Detail  tbl_sasQuotation_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_quotation_ID = new DataColumn("quotation_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_inquiry_ID = new DataColumn("inquiry_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle_PInvoice = new DataColumn("qtySettle_PInvoice" , typeof(decimal));
			DataColumn col_qtySettle_CustomerOrder = new DataColumn("qtySettle_CustomerOrder" , typeof(decimal));
			DataColumn col_qtySettle_Invoice = new DataColumn("qtySettle_Invoice" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle_PInvoice = new DataColumn("weightSettle_PInvoice" , typeof(decimal));
			DataColumn col_weightSettle_CustomerOrder = new DataColumn("weightSettle_CustomerOrder" , typeof(decimal));
			DataColumn col_weightSettle_Invoice = new DataColumn("weightSettle_Invoice" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_unitDiscount = new DataColumn("unitDiscount" , typeof(decimal));
			DataColumn col_totalDiscount = new DataColumn("totalDiscount" , typeof(decimal));
			DataColumn col_bIsFreeItem = new DataColumn("bIsFreeItem" , typeof(bool));
			DataColumn col_discountPresentage = new DataColumn("discountPresentage" , typeof(decimal));
			DataColumn col_discountAmount = new DataColumn("discountAmount" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
			DataColumn col_recommendedUnitPrice = new DataColumn("recommendedUnitPrice" , typeof(decimal));
			DataColumn col_recommendedWeightPrice = new DataColumn("recommendedWeightPrice" , typeof(decimal));
			DataColumn col_recommendedunitTotalAmount = new DataColumn("recommendedunitTotalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_quotation_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_inquiry_ID,col_job_ID,col_qty,col_qtySettle_PInvoice,col_qtySettle_CustomerOrder,col_qtySettle_Invoice,col_weight,col_weightSettle_PInvoice,col_weightSettle_CustomerOrder,col_weightSettle_Invoice,col_unitPrice,col_weightPrice,col_unitDiscount,col_totalDiscount,col_bIsFreeItem,col_discountPresentage,col_discountAmount,col_tatalAmount,col_recommendedUnitPrice,col_recommendedWeightPrice,col_recommendedunitTotalAmount,col_remark,col_uom_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasQuotation_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasQuotation_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasQuotation_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["quotation_ID"] = user.quotation_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["inquiry_ID"] = user.inquiry_ID;
			drow["job_ID"] = user.job_ID;
			drow["qty"] = user.qty;
			drow["qtySettle_PInvoice"] = user.qtySettle_PInvoice;
			drow["qtySettle_CustomerOrder"] = user.qtySettle_CustomerOrder;
			drow["qtySettle_Invoice"] = user.qtySettle_Invoice;
			drow["weight"] = user.weight;
			drow["weightSettle_PInvoice"] = user.weightSettle_PInvoice;
			drow["weightSettle_CustomerOrder"] = user.weightSettle_CustomerOrder;
			drow["weightSettle_Invoice"] = user.weightSettle_Invoice;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["unitDiscount"] = user.unitDiscount;
			drow["totalDiscount"] = user.totalDiscount;
			drow["bIsFreeItem"] = user.bIsFreeItem;
			drow["discountPresentage"] = user.discountPresentage;
			drow["discountAmount"] = user.discountAmount;
			drow["tatalAmount"] = user.tatalAmount;
			drow["recommendedUnitPrice"] = user.recommendedUnitPrice;
			drow["recommendedWeightPrice"] = user.recommendedWeightPrice;
			drow["recommendedunitTotalAmount"] = user.recommendedunitTotalAmount;
			drow["remark"] = user.remark;
			drow["uom_ID"] = user.uom_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
