using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasInvDeliveryOrder_Detail {
		#region Fields
		private int line_No;
		private string iDeliveryOrder_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string invoice_ID;
		private decimal qty;
		private decimal qtySettle;
		private decimal weight;
		private decimal weightSettle;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal unitDiscount;
		private decimal totalDiscount;
		private decimal tatalAmount;
		private decimal tatalCost_FIFO;
		private decimal tatalCost_WA;
		private decimal recommendedUnitPrice;
		private decimal recommendedWeightPrice;
		private decimal recommendedunitTotalAmount;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasInvDeliveryOrder_Detail class.
		/// </summary>
		public tbl_sasInvDeliveryOrder_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasInvDeliveryOrder_Detail class.
		/// </summary>
		public tbl_sasInvDeliveryOrder_Detail(int line_No, string iDeliveryOrder_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string invoice_ID, decimal qty, decimal qtySettle, decimal weight, decimal weightSettle, decimal unitPrice, decimal weightPrice, decimal unitDiscount, decimal totalDiscount, decimal tatalAmount, decimal tatalCost_FIFO, decimal tatalCost_WA, decimal recommendedUnitPrice, decimal recommendedWeightPrice, decimal recommendedunitTotalAmount, string remark) {
			this.line_No = line_No;
			this.iDeliveryOrder_ID = iDeliveryOrder_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.invoice_ID = invoice_ID;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.weight = weight;
			this.weightSettle = weightSettle;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.unitDiscount = unitDiscount;
			this.totalDiscount = totalDiscount;
			this.tatalAmount = tatalAmount;
			this.tatalCost_FIFO = tatalCost_FIFO;
			this.tatalCost_WA = tatalCost_WA;
			this.recommendedUnitPrice = recommendedUnitPrice;
			this.recommendedWeightPrice = recommendedWeightPrice;
			this.recommendedunitTotalAmount = recommendedunitTotalAmount;
			this.remark = remark;
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
		/// Gets or sets the IDeliveryOrder_ID value.
		/// </summary>
		public string IDeliveryOrder_ID {
			get { return iDeliveryOrder_ID; }
			set { iDeliveryOrder_ID = value; }
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
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySettle value.
		/// </summary>
		public decimal QtySettle {
			get { return qtySettle; }
			set { qtySettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightSettle value.
		/// </summary>
		public decimal WeightSettle {
			get { return weightSettle; }
			set { weightSettle = value; }
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
		/// Gets or sets the TatalAmount value.
		/// </summary>
		public decimal TatalAmount {
			get { return tatalAmount; }
			set { tatalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the TatalCost_FIFO value.
		/// </summary>
		public decimal TatalCost_FIFO {
			get { return tatalCost_FIFO; }
			set { tatalCost_FIFO = value; }
		}
		
		/// <summary>
		/// Gets or sets the TatalCost_WA value.
		/// </summary>
		public decimal TatalCost_WA {
			get { return tatalCost_WA; }
			set { tatalCost_WA = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasInvDeliveryOrder_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@iDeliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_WA", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@iDeliveryOrder_ID"].Value = iDeliveryOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@unitDiscount"].Value = unitDiscount;
			scom.Parameters["@totalDiscount"].Value = totalDiscount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@tatalCost_WA"].Value = tatalCost_WA;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasInvDeliveryOrder_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@iDeliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_WA", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@iDeliveryOrder_ID"].Value = iDeliveryOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@unitDiscount"].Value = unitDiscount;
			scom.Parameters["@totalDiscount"].Value = totalDiscount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@tatalCost_WA"].Value = tatalCost_WA;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasInvDeliveryOrder_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@iDeliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@iDeliveryOrder_ID"].Value = iDeliveryOrder_ID;
 
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
		/// Selects all records from the tbl_sasInvDeliveryOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByIDeliveryOrder_ID(string iDeliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailDeleteAllByIDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iDeliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iDeliveryOrder_ID"].Value = iDeliveryOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasInvDeliveryOrder_Detail table.
		/// </summary>
		public static tbl_sasInvDeliveryOrder_Detail Select(string iDeliveryOrder_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_sasInvDeliveryOrder_Detail tbl_sasInvDeliveryOrder_Detailins = new tbl_sasInvDeliveryOrder_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iDeliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@iDeliveryOrder_ID"].Value = iDeliveryOrder_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasInvDeliveryOrder_Detailins = Maketbl_sasInvDeliveryOrder_Detail(dataReader);
				} else {
					tbl_sasInvDeliveryOrder_Detailins = null;
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrder_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder_Detail table.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasInvDeliveryOrder_Detail> tbl_sasInvDeliveryOrder_DetailList = new List<tbl_sasInvDeliveryOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder_Detail tbl_sasInvDeliveryOrder_Detail = Maketbl_sasInvDeliveryOrder_Detail(dataReader);
					tbl_sasInvDeliveryOrder_DetailList.Add(tbl_sasInvDeliveryOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_sasInvDeliveryOrder_Detail> tbl_sasInvDeliveryOrder_DetailList = new List<tbl_sasInvDeliveryOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder_Detail tbl_sasInvDeliveryOrder_Detail = Maketbl_sasInvDeliveryOrder_Detail(dataReader);
					tbl_sasInvDeliveryOrder_DetailList.Add(tbl_sasInvDeliveryOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_sasInvDeliveryOrder_Detail> tbl_sasInvDeliveryOrder_DetailList = new List<tbl_sasInvDeliveryOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder_Detail tbl_sasInvDeliveryOrder_Detail = Maketbl_sasInvDeliveryOrder_Detail(dataReader);
					tbl_sasInvDeliveryOrder_DetailList.Add(tbl_sasInvDeliveryOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder_Detail> SelectAllByIDeliveryOrder_ID(string iDeliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailSelectAllByIDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@iDeliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@iDeliveryOrder_ID"].Value = iDeliveryOrder_ID;
				List<tbl_sasInvDeliveryOrder_Detail> tbl_sasInvDeliveryOrder_DetailList = new List<tbl_sasInvDeliveryOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder_Detail tbl_sasInvDeliveryOrder_Detail = Maketbl_sasInvDeliveryOrder_Detail(dataReader);
					tbl_sasInvDeliveryOrder_DetailList.Add(tbl_sasInvDeliveryOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrder_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInvDeliveryOrder_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInvDeliveryOrder_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInvDeliveryOrder_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_sasInvDeliveryOrder_Detail> tbl_sasInvDeliveryOrder_DetailList = new List<tbl_sasInvDeliveryOrder_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInvDeliveryOrder_Detail tbl_sasInvDeliveryOrder_Detail = Maketbl_sasInvDeliveryOrder_Detail(dataReader);
					tbl_sasInvDeliveryOrder_DetailList.Add(tbl_sasInvDeliveryOrder_Detail);
				}
			}
			scon.Close();
			return tbl_sasInvDeliveryOrder_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasInvDeliveryOrder_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasInvDeliveryOrder_Detail Maketbl_sasInvDeliveryOrder_Detail(SqlDataReader dataReader) {
			tbl_sasInvDeliveryOrder_Detail tbl_sasInvDeliveryOrder_Detail = new tbl_sasInvDeliveryOrder_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasInvDeliveryOrder_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasInvDeliveryOrder_Detail.IDeliveryOrder_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasInvDeliveryOrder_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasInvDeliveryOrder_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasInvDeliveryOrder_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasInvDeliveryOrder_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasInvDeliveryOrder_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasInvDeliveryOrder_Detail.Invoice_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasInvDeliveryOrder_Detail.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasInvDeliveryOrder_Detail.QtySettle = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasInvDeliveryOrder_Detail.Weight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasInvDeliveryOrder_Detail.WeightSettle = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasInvDeliveryOrder_Detail.UnitPrice = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasInvDeliveryOrder_Detail.WeightPrice = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasInvDeliveryOrder_Detail.UnitDiscount = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasInvDeliveryOrder_Detail.TotalDiscount = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasInvDeliveryOrder_Detail.TatalAmount = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasInvDeliveryOrder_Detail.TatalCost_FIFO = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasInvDeliveryOrder_Detail.TatalCost_WA = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasInvDeliveryOrder_Detail.RecommendedUnitPrice = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasInvDeliveryOrder_Detail.RecommendedWeightPrice = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasInvDeliveryOrder_Detail.RecommendedunitTotalAmount = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasInvDeliveryOrder_Detail.Remark = dataReader.GetString(22);
			}

			return tbl_sasInvDeliveryOrder_Detail;
		}
		/// <summary>
		/// This makes tbl_sasInvDeliveryOrder_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasInvDeliveryOrder_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasInvDeliveryOrder_Detail  tbl_sasInvDeliveryOrder_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_iDeliveryOrder_ID = new DataColumn("iDeliveryOrder_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_unitDiscount = new DataColumn("unitDiscount" , typeof(decimal));
			DataColumn col_totalDiscount = new DataColumn("totalDiscount" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
			DataColumn col_tatalCost_FIFO = new DataColumn("tatalCost_FIFO" , typeof(decimal));
			DataColumn col_tatalCost_WA = new DataColumn("tatalCost_WA" , typeof(decimal));
			DataColumn col_recommendedUnitPrice = new DataColumn("recommendedUnitPrice" , typeof(decimal));
			DataColumn col_recommendedWeightPrice = new DataColumn("recommendedWeightPrice" , typeof(decimal));
			DataColumn col_recommendedunitTotalAmount = new DataColumn("recommendedunitTotalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_iDeliveryOrder_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_invoice_ID,col_qty,col_qtySettle,col_weight,col_weightSettle,col_unitPrice,col_weightPrice,col_unitDiscount,col_totalDiscount,col_tatalAmount,col_tatalCost_FIFO,col_tatalCost_WA,col_recommendedUnitPrice,col_recommendedWeightPrice,col_recommendedunitTotalAmount,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasInvDeliveryOrder_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasInvDeliveryOrder_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasInvDeliveryOrder_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["iDeliveryOrder_ID"] = user.iDeliveryOrder_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["invoice_ID"] = user.invoice_ID;
			drow["qty"] = user.qty;
			drow["qtySettle"] = user.qtySettle;
			drow["weight"] = user.weight;
			drow["weightSettle"] = user.weightSettle;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["unitDiscount"] = user.unitDiscount;
			drow["totalDiscount"] = user.totalDiscount;
			drow["tatalAmount"] = user.tatalAmount;
			drow["tatalCost_FIFO"] = user.tatalCost_FIFO;
			drow["tatalCost_WA"] = user.tatalCost_WA;
			drow["recommendedUnitPrice"] = user.recommendedUnitPrice;
			drow["recommendedWeightPrice"] = user.recommendedWeightPrice;
			drow["recommendedunitTotalAmount"] = user.recommendedunitTotalAmount;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
