using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public class tbl_sasInvoice_Detail
	{
		#region Fields
		protected int line_No;
		protected string invoice_ID;
		protected string item_ID;
		protected string itemSubCategory_ID;
		protected string itemSubCategory2_ID;
		protected string itemSerialNo;
		protected string itemSerialNo2;
		protected string deliveryOrder_ID;
		protected string customer_ID;
		protected string quotation_ID;
		protected string customerOrder_ID;
		protected string job_ID;
		protected decimal qty;
		protected decimal qtySettle;
		protected decimal weight;
		protected decimal weightSettle;
		protected decimal unitPrice;
		protected decimal weightPrice;
		protected bool bIsFreeItem;
		protected decimal discountPresentage;
		protected decimal discountAmount;
		protected decimal tatalAmount;
		protected decimal tatalCost_FIFO;
		protected decimal tatalCost_WA;
		protected decimal recommendedUnitPrice;
		protected decimal recommendedWeightPrice;
		protected decimal recommendedunitTotalAmount;
		protected string remark;
		protected string uom_ID;
		protected decimal weightedAvgCost;

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasInvoice_Detail class.
		/// </summary>
		public tbl_sasInvoice_Detail()
		{
		}

		/// <summary>
		/// Initializes a new instance of the tbl_sasInvoice_Detail class.
		/// </summary>
		public tbl_sasInvoice_Detail(int line_No, string invoice_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string deliveryOrder_ID, string customer_ID, string quotation_ID, string customerOrder_ID, string job_ID, decimal qty, decimal qtySettle, decimal weight, decimal weightSettle, decimal unitPrice, decimal weightPrice, bool bIsFreeItem, decimal discountPresentage, decimal discountAmount, decimal tatalAmount, decimal tatalCost_FIFO, decimal tatalCost_WA, decimal recommendedUnitPrice, decimal recommendedWeightPrice, decimal recommendedunitTotalAmount, string remark, string uom_ID, decimal weightedAvgCost)
		{
			this.line_No = line_No;
			this.invoice_ID = invoice_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.customer_ID = customer_ID;
			this.quotation_ID = quotation_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.job_ID = job_ID;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.weight = weight;
			this.weightSettle = weightSettle;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.bIsFreeItem = bIsFreeItem;
			this.discountPresentage = discountPresentage;
			this.discountAmount = discountAmount;
			this.tatalAmount = tatalAmount;
			this.tatalCost_FIFO = tatalCost_FIFO;
			this.tatalCost_WA = tatalCost_WA;
			this.recommendedUnitPrice = recommendedUnitPrice;
			this.recommendedWeightPrice = recommendedWeightPrice;
			this.recommendedunitTotalAmount = recommendedunitTotalAmount;
			this.remark = remark;
			this.uom_ID = uom_ID;
			this.weightedAvgCost = weightedAvgCost;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No
		{
			get { return line_No; }
			set { line_No = value; }
		}

		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID
		{
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID
		{
			get { return item_ID; }
			set { item_ID = value; }
		}

		/// <summary>
		/// Gets or sets the ItemSubCategory_ID value.
		/// </summary>
		public string ItemSubCategory_ID
		{
			get { return itemSubCategory_ID; }
			set { itemSubCategory_ID = value; }
		}

		/// <summary>
		/// Gets or sets the ItemSubCategory2_ID value.
		/// </summary>
		public string ItemSubCategory2_ID
		{
			get { return itemSubCategory2_ID; }
			set { itemSubCategory2_ID = value; }
		}

		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo
		{
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}

		/// <summary>
		/// Gets or sets the ItemSerialNo2 value.
		/// </summary>
		public string ItemSerialNo2
		{
			get { return itemSerialNo2; }
			set { itemSerialNo2 = value; }
		}

		/// <summary>
		/// Gets or sets the DeliveryOrder_ID value.
		/// </summary>
		public string DeliveryOrder_ID
		{
			get { return deliveryOrder_ID; }
			set { deliveryOrder_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID
		{
			get { return customer_ID; }
			set { customer_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Quotation_ID value.
		/// </summary>
		public string Quotation_ID
		{
			get { return quotation_ID; }
			set { quotation_ID = value; }
		}

		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID
		{
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID
		{
			get { return job_ID; }
			set { job_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}

		/// <summary>
		/// Gets or sets the QtySettle value.
		/// </summary>
		public decimal QtySettle
		{
			get { return qtySettle; }
			set { qtySettle = value; }
		}

		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		/// <summary>
		/// Gets or sets the WeightSettle value.
		/// </summary>
		public decimal WeightSettle
		{
			get { return weightSettle; }
			set { weightSettle = value; }
		}

		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice
		{
			get { return unitPrice; }
			set { unitPrice = value; }
		}

		/// <summary>
		/// Gets or sets the WeightPrice value.
		/// </summary>
		public decimal WeightPrice
		{
			get { return weightPrice; }
			set { weightPrice = value; }
		}

		/// <summary>
		/// Gets or sets the BIsFreeItem value.
		/// </summary>
		public bool BIsFreeItem
		{
			get { return bIsFreeItem; }
			set { bIsFreeItem = value; }
		}

		/// <summary>
		/// Gets or sets the DiscountPresentage value.
		/// </summary>
		public decimal DiscountPresentage
		{
			get { return discountPresentage; }
			set { discountPresentage = value; }
		}

		/// <summary>
		/// Gets or sets the DiscountAmount value.
		/// </summary>
		public decimal DiscountAmount
		{
			get { return discountAmount; }
			set { discountAmount = value; }
		}

		/// <summary>
		/// Gets or sets the TatalAmount value.
		/// </summary>
		public decimal TatalAmount
		{
			get { return tatalAmount; }
			set { tatalAmount = value; }
		}

		/// <summary>
		/// Gets or sets the TatalCost_FIFO value.
		/// </summary>
		public decimal TatalCost_FIFO
		{
			get { return tatalCost_FIFO; }
			set { tatalCost_FIFO = value; }
		}

		/// <summary>
		/// Gets or sets the TatalCost_WA value.
		/// </summary>
		public decimal TatalCost_WA
		{
			get { return tatalCost_WA; }
			set { tatalCost_WA = value; }
		}

		/// <summary>
		/// Gets or sets the RecommendedUnitPrice value.
		/// </summary>
		public decimal RecommendedUnitPrice
		{
			get { return recommendedUnitPrice; }
			set { recommendedUnitPrice = value; }
		}

		/// <summary>
		/// Gets or sets the RecommendedWeightPrice value.
		/// </summary>
		public decimal RecommendedWeightPrice
		{
			get { return recommendedWeightPrice; }
			set { recommendedWeightPrice = value; }
		}

		/// <summary>
		/// Gets or sets the RecommendedunitTotalAmount value.
		/// </summary>
		public decimal RecommendedunitTotalAmount
		{
			get { return recommendedunitTotalAmount; }
			set { recommendedunitTotalAmount = value; }
		}

		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark
		{
			get { return remark; }
			set { remark = value; }
		}

		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID
		{
			get { return uom_ID; }
			set { uom_ID = value; }
		}

		/// <summary>
		/// Gets or sets the WeightedAvgCost value.
		/// </summary>
		public decimal WeightedAvgCost
		{
			get { return weightedAvgCost; }
			set { weightedAvgCost = value; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasInvoice_Detail table.
		/// </summary>
		public void Insert()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;


			scom.Parameters.Add("@line_No", SqlDbType.Int, 4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit, 1);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@discountAmount", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@tatalCost_WA", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar, 100);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal, 9);

			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountAmount"].Value = discountAmount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@tatalCost_WA"].Value = tatalCost_WA;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Updates a record in the tbl_sasInvoice_Detail table.
		/// </summary>
		public void Update()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;


			scom.Parameters.Add("@line_No", SqlDbType.Int, 4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit, 1);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@discountAmount", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@tatalCost_WA", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar, 100);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal, 9);


			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountAmount"].Value = discountAmount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@tatalCost_WA"].Value = tatalCost_WA;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Deletes a record from the tbl_sasInvoice_Detail table by its primary key.
		/// </summary>
		public void Delete()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;

			scom.Parameters.Add("@line_No", SqlDbType.Int, 4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@line_No"].Value = line_No;

			scom.Parameters["@invoice_ID"].Value = invoice_ID;

			scom.Parameters["@item_ID"].Value = item_ID;

			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;

			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;

			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;

			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;

			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;


			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@job_ID"].Value = job_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@item_ID"].Value = item_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		public static void DeleteAllByLine_No_Invoice_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2_DeliveryOrder_ID(int line_No, string invoice_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string deliveryOrder_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailDeleteAllByLine_No_withOthers", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@line_No", SqlDbType.Int, 4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryOrder_ID(string deliveryOrder_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailDeleteAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		/// <summary>
		/// Selects a single record from the tbl_sasInvoice_Detail table.
		/// </summary>
		public static tbl_sasInvoice_Detail Select(int line_No_Incoming, string invoice_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming, string deliveryOrder_ID_Incoming)
		{

			tbl_sasInvoice_Detail tbl_sasInvoice_Detailins = new tbl_sasInvoice_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@line_No", SqlDbType.Int, 4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@invoice_ID"].Value = invoice_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				if (dataReader.Read())
				{
					tbl_sasInvoice_Detailins = Maketbl_sasInvoice_Detail(dataReader);
				}
				else
				{
					tbl_sasInvoice_Detailins = null;
				}
			}
			scon.Close();
			return tbl_sasInvoice_Detailins;
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table.
		/// </summary>
		public static List<tbl_sasInvoice_Detail> SelectAll()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			List<tbl_sasInvoice_Detail> tbl_sasInvoice_DetailList = new List<tbl_sasInvoice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_sasInvoice_Detail tbl_sasInvoice_Detail = Maketbl_sasInvoice_Detail(dataReader);
					tbl_sasInvoice_DetailList.Add(tbl_sasInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvoice_DetailList;
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Detail> SelectAllByJob_ID(string job_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@job_ID"].Value = job_ID;
			List<tbl_sasInvoice_Detail> tbl_sasInvoice_DetailList = new List<tbl_sasInvoice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_sasInvoice_Detail tbl_sasInvoice_Detail = Maketbl_sasInvoice_Detail(dataReader);
					tbl_sasInvoice_DetailList.Add(tbl_sasInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvoice_DetailList;
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			List<tbl_sasInvoice_Detail> tbl_sasInvoice_DetailList = new List<tbl_sasInvoice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_sasInvoice_Detail tbl_sasInvoice_Detail = Maketbl_sasInvoice_Detail(dataReader);
					tbl_sasInvoice_DetailList.Add(tbl_sasInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvoice_DetailList;
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Detail> SelectAllByItem_ID(string item_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@item_ID"].Value = item_ID;
			List<tbl_sasInvoice_Detail> tbl_sasInvoice_DetailList = new List<tbl_sasInvoice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_sasInvoice_Detail tbl_sasInvoice_Detail = Maketbl_sasInvoice_Detail(dataReader);
					tbl_sasInvoice_DetailList.Add(tbl_sasInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvoice_DetailList;
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Detail> SelectAllByDeliveryOrder_ID(string deliveryOrder_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailSelectAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			List<tbl_sasInvoice_Detail> tbl_sasInvoice_DetailList = new List<tbl_sasInvoice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_sasInvoice_Detail tbl_sasInvoice_Detail = Maketbl_sasInvoice_Detail(dataReader);
					tbl_sasInvoice_DetailList.Add(tbl_sasInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvoice_DetailList;
		}

		public static List<tbl_sasInvoice_Detail> SelectAllByLine_No_Invoice_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2_DeliveryOrder_ID(int line_No, string invoice_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string deliveryOrder_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailSelectAllByLine_No_withOthers", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@line_No", SqlDbType.Int, 4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			List<tbl_sasInvoice_Detail> tbl_sasInvoice_DetailList = new List<tbl_sasInvoice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_sasInvoice_Detail tbl_sasInvoice_Detail = Maketbl_sasInvoice_Detail(dataReader);
					tbl_sasInvoice_DetailList.Add(tbl_sasInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvoice_DetailList;
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Detail> SelectAllByInvoice_ID(string invoice_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			List<tbl_sasInvoice_Detail> tbl_sasInvoice_DetailList = new List<tbl_sasInvoice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_sasInvoice_Detail tbl_sasInvoice_Detail = Maketbl_sasInvoice_Detail(dataReader);
					tbl_sasInvoice_DetailList.Add(tbl_sasInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvoice_DetailList;
		}

		/// <summary>
		/// Selects all records from the tbl_sasInvoice_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvoice_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			List<tbl_sasInvoice_Detail> tbl_sasInvoice_DetailList = new List<tbl_sasInvoice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_sasInvoice_Detail tbl_sasInvoice_Detail = Maketbl_sasInvoice_Detail(dataReader);
					tbl_sasInvoice_DetailList.Add(tbl_sasInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvoice_DetailList;
		}

		/// <summary>
		/// Creates a new instance of the tbl_sasInvoice_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasInvoice_Detail Maketbl_sasInvoice_Detail(SqlDataReader dataReader)
		{
			tbl_sasInvoice_Detail tbl_sasInvoice_Detail = new tbl_sasInvoice_Detail();

			if (dataReader.IsDBNull(0) == false)
			{
				tbl_sasInvoice_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false)
			{
				tbl_sasInvoice_Detail.Invoice_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false)
			{
				tbl_sasInvoice_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false)
			{
				tbl_sasInvoice_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false)
			{
				tbl_sasInvoice_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false)
			{
				tbl_sasInvoice_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false)
			{
				tbl_sasInvoice_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false)
			{
				tbl_sasInvoice_Detail.DeliveryOrder_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false)
			{
				tbl_sasInvoice_Detail.Customer_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false)
			{
				tbl_sasInvoice_Detail.Quotation_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false)
			{
				tbl_sasInvoice_Detail.CustomerOrder_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false)
			{
				tbl_sasInvoice_Detail.Job_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false)
			{
				tbl_sasInvoice_Detail.Qty = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false)
			{
				tbl_sasInvoice_Detail.QtySettle = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false)
			{
				tbl_sasInvoice_Detail.Weight = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false)
			{
				tbl_sasInvoice_Detail.WeightSettle = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false)
			{
				tbl_sasInvoice_Detail.UnitPrice = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false)
			{
				tbl_sasInvoice_Detail.WeightPrice = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false)
			{
				tbl_sasInvoice_Detail.BIsFreeItem = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false)
			{
				tbl_sasInvoice_Detail.DiscountPresentage = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false)
			{
				tbl_sasInvoice_Detail.DiscountAmount = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false)
			{
				tbl_sasInvoice_Detail.TatalAmount = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false)
			{
				tbl_sasInvoice_Detail.TatalCost_FIFO = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false)
			{
				tbl_sasInvoice_Detail.TatalCost_WA = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false)
			{
				tbl_sasInvoice_Detail.RecommendedUnitPrice = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false)
			{
				tbl_sasInvoice_Detail.RecommendedWeightPrice = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false)
			{
				tbl_sasInvoice_Detail.RecommendedunitTotalAmount = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false)
			{
				tbl_sasInvoice_Detail.Remark = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false)
			{
				tbl_sasInvoice_Detail.Uom_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false)
			{
				tbl_sasInvoice_Detail.WeightedAvgCost = dataReader.GetDecimal(29);
			}

			return tbl_sasInvoice_Detail;
		}

		/// <summary>
		/// This makes tbl_sasInvoice_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasInvoice_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable(tbl_sasInvoice_Detail tbl_sasInvoice_Detail)
		{
			DataTable dt = new DataTable();

			DataColumn col_line_No = new DataColumn("line_No", typeof(int));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID", typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID", typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID", typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID", typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo", typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2", typeof(string));
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID", typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID", typeof(string));
			DataColumn col_quotation_ID = new DataColumn("quotation_ID", typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID", typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID", typeof(string));
			DataColumn col_qty = new DataColumn("qty", typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle", typeof(decimal));
			DataColumn col_weight = new DataColumn("weight", typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle", typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice", typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice", typeof(decimal));
			DataColumn col_bIsFreeItem = new DataColumn("bIsFreeItem", typeof(bool));
			DataColumn col_discountPresentage = new DataColumn("discountPresentage", typeof(decimal));
			DataColumn col_discountAmount = new DataColumn("discountAmount", typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount", typeof(decimal));
			DataColumn col_tatalCost_FIFO = new DataColumn("tatalCost_FIFO", typeof(decimal));
			DataColumn col_tatalCost_WA = new DataColumn("tatalCost_WA", typeof(decimal));
			DataColumn col_recommendedUnitPrice = new DataColumn("recommendedUnitPrice", typeof(decimal));
			DataColumn col_recommendedWeightPrice = new DataColumn("recommendedWeightPrice", typeof(decimal));
			DataColumn col_recommendedunitTotalAmount = new DataColumn("recommendedunitTotalAmount", typeof(decimal));
			DataColumn col_remark = new DataColumn("remark", typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID", typeof(string));
			DataColumn col_weightedAvgCost = new DataColumn("weightedAvgCost", typeof(decimal));
			dt.Columns.AddRange(new DataColumn[] { col_line_No, col_invoice_ID, col_item_ID, col_itemSubCategory_ID, col_itemSubCategory2_ID, col_itemSerialNo, col_itemSerialNo2, col_deliveryOrder_ID, col_customer_ID, col_quotation_ID, col_customerOrder_ID, col_job_ID, col_qty, col_qtySettle, col_weight, col_weightSettle, col_unitPrice, col_weightPrice, col_bIsFreeItem, col_discountPresentage, col_discountAmount, col_tatalAmount, col_tatalCost_FIFO, col_tatalCost_WA, col_recommendedUnitPrice, col_recommendedWeightPrice, col_recommendedunitTotalAmount, col_remark, col_uom_ID, col_weightedAvgCost, }); return dt;
		}
		/// <summary>
		/// This fills tbl_sasInvoice_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasInvoice_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasInvoice_Detail user)
		{
			DataRow drow = dt.NewRow();

			drow["line_No"] = user.line_No;
			drow["invoice_ID"] = user.invoice_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["quotation_ID"] = user.quotation_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["job_ID"] = user.job_ID;
			drow["qty"] = user.qty;
			drow["qtySettle"] = user.qtySettle;
			drow["weight"] = user.weight;
			drow["weightSettle"] = user.weightSettle;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["bIsFreeItem"] = user.bIsFreeItem;
			drow["discountPresentage"] = user.discountPresentage;
			drow["discountAmount"] = user.discountAmount;
			drow["tatalAmount"] = user.tatalAmount;
			drow["tatalCost_FIFO"] = user.tatalCost_FIFO;
			drow["tatalCost_WA"] = user.tatalCost_WA;
			drow["recommendedUnitPrice"] = user.recommendedUnitPrice;
			drow["recommendedWeightPrice"] = user.recommendedWeightPrice;
			drow["recommendedunitTotalAmount"] = user.recommendedunitTotalAmount;
			drow["remark"] = user.remark;
			drow["uom_ID"] = user.uom_ID;
			drow["weightedAvgCost"] = user.weightedAvgCost;
			dt.Rows.Add(drow);
		}
		#endregion
	}

	public class tbl_sasInvoice_Detail_Ex : tbl_sasInvoice_Detail
	{
		public string store_ID;

		public tbl_sasInvoice_Detail_Ex()
		{ }

		public void Insert2()
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailInsert2", scon);
			scom.CommandType = CommandType.StoredProcedure;


			scom.Parameters.Add("@line_No", SqlDbType.Int, 4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar, 50);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit, 1);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@discountAmount", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@tatalCost_WA", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar, 100);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar, 10);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal, 9);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar, 20);

			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountAmount"].Value = discountAmount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@tatalCost_WA"].Value = tatalCost_WA;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
scom.Parameters["@store_ID"].Value = store_ID;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		public tbl_sasInvoice_Detail_Ex(int line_No, string invoice_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string deliveryOrder_ID, string customer_ID, string quotation_ID, string customerOrder_ID, string job_ID, decimal qty, decimal qtySettle, decimal weight, decimal weightSettle, decimal unitPrice, decimal weightPrice, bool bIsFreeItem, decimal discountPresentage, decimal discountAmount, decimal tatalAmount, decimal tatalCost_FIFO, decimal tatalCost_WA, decimal recommendedUnitPrice, decimal recommendedWeightPrice, decimal recommendedunitTotalAmount, string remark, string uom_ID, decimal weightedAvgCost, string store_ID)
		{
			this.line_No = line_No;
			this.invoice_ID = invoice_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.customer_ID = customer_ID;
			this.quotation_ID = quotation_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.job_ID = job_ID;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.weight = weight;
			this.weightSettle = weightSettle;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.bIsFreeItem = bIsFreeItem;
			this.discountPresentage = discountPresentage;
			this.discountAmount = discountAmount;
			this.tatalAmount = tatalAmount;
			this.tatalCost_FIFO = tatalCost_FIFO;
			this.tatalCost_WA = tatalCost_WA;
			this.recommendedUnitPrice = recommendedUnitPrice;
			this.recommendedWeightPrice = recommendedWeightPrice;
			this.recommendedunitTotalAmount = recommendedunitTotalAmount;
			this.remark = remark;
			this.uom_ID = uom_ID;
			this.weightedAvgCost = weightedAvgCost;
			this.store_ID = store_ID;
		}

		public static List<tbl_sasInvoice_Detail_Ex> SelectAllByInvoice_ID_WithStore(string invoice_ID)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvoice_DetailSelectAllByInvoice_ID2", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			List<tbl_sasInvoice_Detail_Ex> tbl_sasInvoice_DetailList = new List<tbl_sasInvoice_Detail_Ex>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_sasInvoice_Detail_Ex tbl_sasInvoice_Detail = Maketbl_sasInvoice_Detail2(dataReader);
					tbl_sasInvoice_DetailList.Add(tbl_sasInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvoice_DetailList;
		}

		private static tbl_sasInvoice_Detail_Ex Maketbl_sasInvoice_Detail2(SqlDataReader dataReader)
		{
			tbl_sasInvoice_Detail_Ex tbl_sasInvoice_Detail = new tbl_sasInvoice_Detail_Ex();

			if (dataReader.IsDBNull(0) == false)
			{
				tbl_sasInvoice_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false)
			{
				tbl_sasInvoice_Detail.Invoice_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false)
			{
				tbl_sasInvoice_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false)
			{
				tbl_sasInvoice_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false)
			{
				tbl_sasInvoice_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false)
			{
				tbl_sasInvoice_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false)
			{
				tbl_sasInvoice_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false)
			{
				tbl_sasInvoice_Detail.DeliveryOrder_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false)
			{
				tbl_sasInvoice_Detail.Customer_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false)
			{
				tbl_sasInvoice_Detail.Quotation_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false)
			{
				tbl_sasInvoice_Detail.CustomerOrder_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false)
			{
				tbl_sasInvoice_Detail.Job_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false)
			{
				tbl_sasInvoice_Detail.Qty = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false)
			{
				tbl_sasInvoice_Detail.QtySettle = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false)
			{
				tbl_sasInvoice_Detail.Weight = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false)
			{
				tbl_sasInvoice_Detail.WeightSettle = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false)
			{
				tbl_sasInvoice_Detail.UnitPrice = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false)
			{
				tbl_sasInvoice_Detail.WeightPrice = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false)
			{
				tbl_sasInvoice_Detail.BIsFreeItem = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false)
			{
				tbl_sasInvoice_Detail.DiscountPresentage = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false)
			{
				tbl_sasInvoice_Detail.DiscountAmount = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false)
			{
				tbl_sasInvoice_Detail.TatalAmount = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false)
			{
				tbl_sasInvoice_Detail.TatalCost_FIFO = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false)
			{
				tbl_sasInvoice_Detail.TatalCost_WA = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false)
			{
				tbl_sasInvoice_Detail.RecommendedUnitPrice = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false)
			{
				tbl_sasInvoice_Detail.RecommendedWeightPrice = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false)
			{
				tbl_sasInvoice_Detail.RecommendedunitTotalAmount = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false)
			{
				tbl_sasInvoice_Detail.Remark = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false)
			{
				tbl_sasInvoice_Detail.Uom_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false)
			{
				tbl_sasInvoice_Detail.WeightedAvgCost = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false)
			{
				tbl_sasInvoice_Detail.store_ID = dataReader.GetString(30);
			}

			return tbl_sasInvoice_Detail;
		}
	}
}