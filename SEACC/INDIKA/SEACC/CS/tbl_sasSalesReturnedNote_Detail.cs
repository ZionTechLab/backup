using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasSalesReturnedNote_Detail {
		#region Fields
		private int line_No;
		private string salesReturnedNote_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string invoice_ID;
		private string deliveryOrder_ID;
		private decimal qty;
		private decimal weight;
		private decimal meters;
		private decimal kiloPrice;
		private decimal unitPrice;
		private bool bIsFreeItem;
		private decimal discountPresentage;
		private decimal discountAmount;
		private decimal tatalAmount;
		private decimal unitCost;
		private decimal tatalCost_FIFO;
		private string remark;
		private decimal weightedAvgCost;
		public string store_ID;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesReturnedNote_Detail class.
		/// </summary>
		public tbl_sasSalesReturnedNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasSalesReturnedNote_Detail class.
		/// </summary>
		public tbl_sasSalesReturnedNote_Detail(int line_No, string salesReturnedNote_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string invoice_ID, string deliveryOrder_ID, decimal qty, decimal weight, decimal meters, decimal kiloPrice, decimal unitPrice, bool bIsFreeItem, decimal discountPresentage, decimal discountAmount, decimal tatalAmount, decimal unitCost, decimal tatalCost_FIFO, string remark, decimal weightedAvgCost,string _store_ID) {
			this.line_No = line_No;
			this.salesReturnedNote_ID = salesReturnedNote_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.invoice_ID = invoice_ID;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.qty = qty;
			this.weight = weight;
			this.meters = meters;
			this.kiloPrice = kiloPrice;
			this.unitPrice = unitPrice;
			this.bIsFreeItem = bIsFreeItem;
			this.discountPresentage = discountPresentage;
			this.discountAmount = discountAmount;
			this.tatalAmount = tatalAmount;
			this.unitCost = unitCost;
			this.tatalCost_FIFO = tatalCost_FIFO;
			this.remark = remark;
			this.weightedAvgCost = weightedAvgCost;
			this.store_ID = _store_ID;
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
		/// Gets or sets the SalesReturnedNote_ID value.
		/// </summary>
		public string SalesReturnedNote_ID {
			get { return salesReturnedNote_ID; }
			set { salesReturnedNote_ID = value; }
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
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryOrder_ID value.
		/// </summary>
		public string DeliveryOrder_ID {
			get { return deliveryOrder_ID; }
			set { deliveryOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Meters value.
		/// </summary>
		public decimal Meters {
			get { return meters; }
			set { meters = value; }
		}
		
		/// <summary>
		/// Gets or sets the KiloPrice value.
		/// </summary>
		public decimal KiloPrice {
			get { return kiloPrice; }
			set { kiloPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
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
		/// Gets or sets the UnitCost value.
		/// </summary>
		public decimal UnitCost {
			get { return unitCost; }
			set { unitCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the TatalCost_FIFO value.
		/// </summary>
		public decimal TatalCost_FIFO {
			get { return tatalCost_FIFO; }
			set { tatalCost_FIFO = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightedAvgCost value.
		/// </summary>
		public decimal WeightedAvgCost {
			get { return weightedAvgCost; }
			set { weightedAvgCost = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasSalesReturnedNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@meters", SqlDbType.Decimal,9);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar, 20);

			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@meters"].Value = meters;
			scom.Parameters["@kiloPrice"].Value = kiloPrice;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountAmount"].Value = discountAmount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@unitCost"].Value = unitCost;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 	scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasSalesReturnedNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@meters", SqlDbType.Decimal,9);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@meters"].Value = meters;
			scom.Parameters["@kiloPrice"].Value = kiloPrice;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountAmount"].Value = discountAmount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@unitCost"].Value = unitCost;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 	scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasSalesReturnedNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
 
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
		/// Selects all records from the tbl_sasSalesReturnedNote_Detail table.
		/// </summary>
		public static List<tbl_sasSalesReturnedNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasSalesReturnedNote_Detail> tbl_sasSalesReturnedNote_DetailList = new List<tbl_sasSalesReturnedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote_Detail tbl_sasSalesReturnedNote_Detail = Maketbl_sasSalesReturnedNote_Detail(dataReader);
					tbl_sasSalesReturnedNote_DetailList.Add(tbl_sasSalesReturnedNote_Detail);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesReturnedNote_Detail> SelectAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailSelectAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
				List<tbl_sasSalesReturnedNote_Detail> tbl_sasSalesReturnedNote_DetailList = new List<tbl_sasSalesReturnedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote_Detail tbl_sasSalesReturnedNote_Detail = Maketbl_sasSalesReturnedNote_Detail(dataReader);
					tbl_sasSalesReturnedNote_DetailList.Add(tbl_sasSalesReturnedNote_Detail);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNote_DetailList;
		}
		
		///// <summary>
		///// Selects all records from the tbl_sasSalesReturnedNote_Detail table by a foreign key.
		///// </summary>
		//public static List<tbl_sasSalesReturnedNote_Detail> SelectAllByItem_ID(string item_ID) {
 
		//	SqlConnection scon = DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailSelectAllByItem_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
		//	scom.Parameters["@item_ID"].Value = item_ID;
		//		List<tbl_sasSalesReturnedNote_Detail> tbl_sasSalesReturnedNote_DetailList = new List<tbl_sasSalesReturnedNote_Detail>();
		//	using (SqlDataReader dataReader = scom.ExecuteReader()){
		//		while (dataReader.Read()) {
		//			tbl_sasSalesReturnedNote_Detail tbl_sasSalesReturnedNote_Detail = Maketbl_sasSalesReturnedNote_Detail(dataReader);
		//			tbl_sasSalesReturnedNote_DetailList.Add(tbl_sasSalesReturnedNote_Detail);
		//		}
		//	}
		//	scon.Close();
		//	return tbl_sasSalesReturnedNote_DetailList;
		//}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesReturnedNote_Detail> SelectAllBySalesReturnedNote_ID(string salesReturnedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailSelectAllBySalesReturnedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
				List<tbl_sasSalesReturnedNote_Detail> tbl_sasSalesReturnedNote_DetailList = new List<tbl_sasSalesReturnedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote_Detail tbl_sasSalesReturnedNote_Detail = Maketbl_sasSalesReturnedNote_Detail(dataReader);
					tbl_sasSalesReturnedNote_DetailList.Add(tbl_sasSalesReturnedNote_Detail);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasSalesReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasSalesReturnedNote_Detail> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_sasSalesReturnedNote_Detail> tbl_sasSalesReturnedNote_DetailList = new List<tbl_sasSalesReturnedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasSalesReturnedNote_Detail tbl_sasSalesReturnedNote_Detail = Maketbl_sasSalesReturnedNote_Detail(dataReader);
					tbl_sasSalesReturnedNote_DetailList.Add(tbl_sasSalesReturnedNote_Detail);
				}
			}
			scon.Close();
			return tbl_sasSalesReturnedNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasSalesReturnedNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasSalesReturnedNote_Detail Maketbl_sasSalesReturnedNote_Detail(SqlDataReader dataReader) {
			tbl_sasSalesReturnedNote_Detail tbl_sasSalesReturnedNote_Detail = new tbl_sasSalesReturnedNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasSalesReturnedNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasSalesReturnedNote_Detail.SalesReturnedNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasSalesReturnedNote_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasSalesReturnedNote_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasSalesReturnedNote_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasSalesReturnedNote_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasSalesReturnedNote_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasSalesReturnedNote_Detail.Invoice_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasSalesReturnedNote_Detail.DeliveryOrder_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasSalesReturnedNote_Detail.Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasSalesReturnedNote_Detail.Weight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasSalesReturnedNote_Detail.Meters = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasSalesReturnedNote_Detail.KiloPrice = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasSalesReturnedNote_Detail.UnitPrice = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasSalesReturnedNote_Detail.BIsFreeItem = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasSalesReturnedNote_Detail.DiscountPresentage = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasSalesReturnedNote_Detail.DiscountAmount = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasSalesReturnedNote_Detail.TatalAmount = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasSalesReturnedNote_Detail.UnitCost = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasSalesReturnedNote_Detail.TatalCost_FIFO = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasSalesReturnedNote_Detail.Remark = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasSalesReturnedNote_Detail.WeightedAvgCost = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false)
			{
				tbl_sasSalesReturnedNote_Detail.store_ID = dataReader.GetString(22);
			}
			return tbl_sasSalesReturnedNote_Detail;
		}
		/// <summary>
		/// This makes tbl_sasSalesReturnedNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasSalesReturnedNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasSalesReturnedNote_Detail  tbl_sasSalesReturnedNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_salesReturnedNote_ID = new DataColumn("salesReturnedNote_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_meters = new DataColumn("meters" , typeof(decimal));
			DataColumn col_kiloPrice = new DataColumn("kiloPrice" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_bIsFreeItem = new DataColumn("bIsFreeItem" , typeof(bool));
			DataColumn col_discountPresentage = new DataColumn("discountPresentage" , typeof(decimal));
			DataColumn col_discountAmount = new DataColumn("discountAmount" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
			DataColumn col_unitCost = new DataColumn("unitCost" , typeof(decimal));
			DataColumn col_tatalCost_FIFO = new DataColumn("tatalCost_FIFO" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_weightedAvgCost = new DataColumn("weightedAvgCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_salesReturnedNote_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_invoice_ID,col_deliveryOrder_ID,col_qty,col_weight,col_meters,col_kiloPrice,col_unitPrice,col_bIsFreeItem,col_discountPresentage,col_discountAmount,col_tatalAmount,col_unitCost,col_tatalCost_FIFO,col_remark,col_weightedAvgCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasSalesReturnedNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasSalesReturnedNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasSalesReturnedNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["salesReturnedNote_ID"] = user.salesReturnedNote_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["invoice_ID"] = user.invoice_ID;
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["meters"] = user.meters;
			drow["kiloPrice"] = user.kiloPrice;
			drow["unitPrice"] = user.unitPrice;
			drow["bIsFreeItem"] = user.bIsFreeItem;
			drow["discountPresentage"] = user.discountPresentage;
			drow["discountAmount"] = user.discountAmount;
			drow["tatalAmount"] = user.tatalAmount;
			drow["unitCost"] = user.unitCost;
			drow["tatalCost_FIFO"] = user.tatalCost_FIFO;
			drow["remark"] = user.remark;
			drow["weightedAvgCost"] = user.weightedAvgCost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
//public static void DeleteAllByDeliveryOrder_ID(string deliveryOrder_ID) {

//	SqlConnection scon = DBHandling.GetConnection();
//	SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailDeleteAllByDeliveryOrder_ID", scon);
//	scom.CommandType = CommandType.StoredProcedure;
//	scon.Open();

//	scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
//	scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;

//	scon.Open();
//	scom.ExecuteNonQuery();
//	scon.Close();
//}

///// <summary>
///// Selects all records from the tbl_sasSalesReturnedNote_Detail table by a foreign key.
///// </summary>
//public static void DeleteAllByItem_ID(string item_ID) {

//	SqlConnection scon = DBHandling.GetConnection();
//	SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailDeleteAllByItem_ID", scon);
//	scom.CommandType = CommandType.StoredProcedure;
//	scon.Open();

//	scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
//	scom.Parameters["@item_ID"].Value = item_ID;

//	scon.Open();
//	scom.ExecuteNonQuery();
//	scon.Close();
//}

///// <summary>
///// Selects all records from the tbl_sasSalesReturnedNote_Detail table by a foreign key.
///// </summary>
//public static void DeleteAllBySalesReturnedNote_ID(string salesReturnedNote_ID) {

//	SqlConnection scon = DBHandling.GetConnection();
//	SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailDeleteAllBySalesReturnedNote_ID", scon);
//	scom.CommandType = CommandType.StoredProcedure;
//	scon.Open();

//	scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
//	scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;

//	scon.Open();
//	scom.ExecuteNonQuery();
//	scon.Close();
//}

///// <summary>
///// Selects all records from the tbl_sasSalesReturnedNote_Detail table by a foreign key.
///// </summary>
//public static void DeleteAllByInvoice_ID(string invoice_ID) {

//	SqlConnection scon = DBHandling.GetConnection();
//	SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailDeleteAllByInvoice_ID", scon);
//	scom.CommandType = CommandType.StoredProcedure;
//	scon.Open();

//	scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
//	scom.Parameters["@invoice_ID"].Value = invoice_ID;

//	scon.Open();
//	scom.ExecuteNonQuery();
//	scon.Close();
//}

///// <summary>
///// Selects a single record from the tbl_sasSalesReturnedNote_Detail table.
///// </summary>
//public static tbl_sasSalesReturnedNote_Detail Select(int line_No_Incoming, string salesReturnedNote_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming, string deliveryOrder_ID_Incoming){

//	tbl_sasSalesReturnedNote_Detail tbl_sasSalesReturnedNote_Detailins = new tbl_sasSalesReturnedNote_Detail();
//	SqlConnection scon = DBHandling.GetConnection();
//	SqlCommand scom = new SqlCommand("tbl_sasSalesReturnedNote_DetailSelect", scon);
//	scom.CommandType = CommandType.StoredProcedure;
//	scon.Open();

//	scom.Parameters.Add("@line_No", SqlDbType.Int,4);
//	scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
//	scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
//	scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
//	scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
//	scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
//	scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
//	scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
//	scom.Parameters["@line_No"].Value = line_No_Incoming;
//	scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID_Incoming;
//	scom.Parameters["@item_ID"].Value = item_ID_Incoming;
//	scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
//	scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
//	scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
//	scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
//	scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID_Incoming;
//	using (SqlDataReader dataReader = scom.ExecuteReader()){
//		if (dataReader.Read()) {
//			tbl_sasSalesReturnedNote_Detailins = Maketbl_sasSalesReturnedNote_Detail(dataReader);
//		} else {
//			tbl_sasSalesReturnedNote_Detailins = null;
//		}
//	}
//	scon.Close();
//	return tbl_sasSalesReturnedNote_Detailins;
//}
