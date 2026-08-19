using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsPurchaseReturnedNote_Detail {
		#region Fields
		private int line_No;
		private string purchaseReturnedNote_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string externalGoodReceivedNote_ID;
		private decimal qty;
		private decimal qtySettle;
		private decimal weight;
		private decimal weightSettle;
		private decimal warranty;
		private decimal kiloPrice;
		private decimal unitPrice;
		private decimal unitDiscount;
		private decimal totalDiscount;
		private decimal tatalAmount;
		private string remark;
		private decimal cost_FIFO;
		private decimal weightedAvgCost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsPurchaseReturnedNote_Detail class.
		/// </summary>
		public tbl_scsPurchaseReturnedNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsPurchaseReturnedNote_Detail class.
		/// </summary>
		public tbl_scsPurchaseReturnedNote_Detail(int line_No, string purchaseReturnedNote_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string externalGoodReceivedNote_ID, decimal qty, decimal qtySettle, decimal weight, decimal weightSettle, decimal warranty, decimal kiloPrice, decimal unitPrice, decimal unitDiscount, decimal totalDiscount, decimal tatalAmount, string remark, decimal cost_FIFO, decimal weightedAvgCost) {
			this.line_No = line_No;
			this.purchaseReturnedNote_ID = purchaseReturnedNote_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.weight = weight;
			this.weightSettle = weightSettle;
			this.warranty = warranty;
			this.kiloPrice = kiloPrice;
			this.unitPrice = unitPrice;
			this.unitDiscount = unitDiscount;
			this.totalDiscount = totalDiscount;
			this.tatalAmount = tatalAmount;
			this.remark = remark;
			this.cost_FIFO = cost_FIFO;
			this.weightedAvgCost = weightedAvgCost;
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
		/// Gets or sets the PurchaseReturnedNote_ID value.
		/// </summary>
		public string PurchaseReturnedNote_ID {
			get { return purchaseReturnedNote_ID; }
			set { purchaseReturnedNote_ID = value; }
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
		/// Gets or sets the ExternalGoodReceivedNote_ID value.
		/// </summary>
		public string ExternalGoodReceivedNote_ID {
			get { return externalGoodReceivedNote_ID; }
			set { externalGoodReceivedNote_ID = value; }
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
		/// Gets or sets the Warranty value.
		/// </summary>
		public decimal Warranty {
			get { return warranty; }
			set { warranty = value; }
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
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cost_FIFO value.
		/// </summary>
		public decimal Cost_FIFO {
			get { return cost_FIFO; }
			set { cost_FIFO = value; }
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
		/// Saves a record to the tbl_scsPurchaseReturnedNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@warranty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@cost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@warranty"].Value = warranty;
			scom.Parameters["@kiloPrice"].Value = kiloPrice;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@unitDiscount"].Value = unitDiscount;
			scom.Parameters["@totalDiscount"].Value = totalDiscount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@cost_FIFO"].Value = cost_FIFO;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsPurchaseReturnedNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@warranty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@cost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@warranty"].Value = warranty;
			scom.Parameters["@kiloPrice"].Value = kiloPrice;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@unitDiscount"].Value = unitDiscount;
			scom.Parameters["@totalDiscount"].Value = totalDiscount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@cost_FIFO"].Value = cost_FIFO;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsPurchaseReturnedNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
 
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
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByExternalGoodReceivedNote_ID(string externalGoodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailDeleteAllByExternalGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPurchaseReturnedNote_ID(string purchaseReturnedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailDeleteAllByPurchaseReturnedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsPurchaseReturnedNote_Detail table.
		/// </summary>
		public static tbl_scsPurchaseReturnedNote_Detail Select(int line_No_Incoming, string purchaseReturnedNote_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_scsPurchaseReturnedNote_Detail tbl_scsPurchaseReturnedNote_Detailins = new tbl_scsPurchaseReturnedNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsPurchaseReturnedNote_Detailins = Maketbl_scsPurchaseReturnedNote_Detail(dataReader);
				} else {
					tbl_scsPurchaseReturnedNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsPurchaseReturnedNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table.
		/// </summary>
		public static List<tbl_scsPurchaseReturnedNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsPurchaseReturnedNote_Detail> tbl_scsPurchaseReturnedNote_DetailList = new List<tbl_scsPurchaseReturnedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsPurchaseReturnedNote_Detail tbl_scsPurchaseReturnedNote_Detail = Maketbl_scsPurchaseReturnedNote_Detail(dataReader);
					tbl_scsPurchaseReturnedNote_DetailList.Add(tbl_scsPurchaseReturnedNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsPurchaseReturnedNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsPurchaseReturnedNote_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsPurchaseReturnedNote_Detail> tbl_scsPurchaseReturnedNote_DetailList = new List<tbl_scsPurchaseReturnedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsPurchaseReturnedNote_Detail tbl_scsPurchaseReturnedNote_Detail = Maketbl_scsPurchaseReturnedNote_Detail(dataReader);
					tbl_scsPurchaseReturnedNote_DetailList.Add(tbl_scsPurchaseReturnedNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsPurchaseReturnedNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsPurchaseReturnedNote_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_scsPurchaseReturnedNote_Detail> tbl_scsPurchaseReturnedNote_DetailList = new List<tbl_scsPurchaseReturnedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsPurchaseReturnedNote_Detail tbl_scsPurchaseReturnedNote_Detail = Maketbl_scsPurchaseReturnedNote_Detail(dataReader);
					tbl_scsPurchaseReturnedNote_DetailList.Add(tbl_scsPurchaseReturnedNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsPurchaseReturnedNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsPurchaseReturnedNote_Detail> SelectAllByExternalGoodReceivedNote_ID(string externalGoodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailSelectAllByExternalGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
				List<tbl_scsPurchaseReturnedNote_Detail> tbl_scsPurchaseReturnedNote_DetailList = new List<tbl_scsPurchaseReturnedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsPurchaseReturnedNote_Detail tbl_scsPurchaseReturnedNote_Detail = Maketbl_scsPurchaseReturnedNote_Detail(dataReader);
					tbl_scsPurchaseReturnedNote_DetailList.Add(tbl_scsPurchaseReturnedNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsPurchaseReturnedNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsPurchaseReturnedNote_Detail> SelectAllByPurchaseReturnedNote_ID(string purchaseReturnedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailSelectAllByPurchaseReturnedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
				List<tbl_scsPurchaseReturnedNote_Detail> tbl_scsPurchaseReturnedNote_DetailList = new List<tbl_scsPurchaseReturnedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsPurchaseReturnedNote_Detail tbl_scsPurchaseReturnedNote_Detail = Maketbl_scsPurchaseReturnedNote_Detail(dataReader);
					tbl_scsPurchaseReturnedNote_DetailList.Add(tbl_scsPurchaseReturnedNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsPurchaseReturnedNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsPurchaseReturnedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsPurchaseReturnedNote_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsPurchaseReturnedNote_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_scsPurchaseReturnedNote_Detail> tbl_scsPurchaseReturnedNote_DetailList = new List<tbl_scsPurchaseReturnedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsPurchaseReturnedNote_Detail tbl_scsPurchaseReturnedNote_Detail = Maketbl_scsPurchaseReturnedNote_Detail(dataReader);
					tbl_scsPurchaseReturnedNote_DetailList.Add(tbl_scsPurchaseReturnedNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsPurchaseReturnedNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsPurchaseReturnedNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsPurchaseReturnedNote_Detail Maketbl_scsPurchaseReturnedNote_Detail(SqlDataReader dataReader) {
			tbl_scsPurchaseReturnedNote_Detail tbl_scsPurchaseReturnedNote_Detail = new tbl_scsPurchaseReturnedNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsPurchaseReturnedNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsPurchaseReturnedNote_Detail.PurchaseReturnedNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsPurchaseReturnedNote_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsPurchaseReturnedNote_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsPurchaseReturnedNote_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsPurchaseReturnedNote_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsPurchaseReturnedNote_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsPurchaseReturnedNote_Detail.ExternalGoodReceivedNote_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsPurchaseReturnedNote_Detail.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsPurchaseReturnedNote_Detail.QtySettle = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsPurchaseReturnedNote_Detail.Weight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsPurchaseReturnedNote_Detail.WeightSettle = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsPurchaseReturnedNote_Detail.Warranty = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsPurchaseReturnedNote_Detail.KiloPrice = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsPurchaseReturnedNote_Detail.UnitPrice = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsPurchaseReturnedNote_Detail.UnitDiscount = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsPurchaseReturnedNote_Detail.TotalDiscount = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsPurchaseReturnedNote_Detail.TatalAmount = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsPurchaseReturnedNote_Detail.Remark = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsPurchaseReturnedNote_Detail.Cost_FIFO = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsPurchaseReturnedNote_Detail.WeightedAvgCost = dataReader.GetDecimal(20);
			}

			return tbl_scsPurchaseReturnedNote_Detail;
		}
		/// <summary>
		/// This makes tbl_scsPurchaseReturnedNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsPurchaseReturnedNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsPurchaseReturnedNote_Detail  tbl_scsPurchaseReturnedNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_purchaseReturnedNote_ID = new DataColumn("purchaseReturnedNote_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_externalGoodReceivedNote_ID = new DataColumn("externalGoodReceivedNote_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle" , typeof(decimal));
			DataColumn col_warranty = new DataColumn("warranty" , typeof(decimal));
			DataColumn col_kiloPrice = new DataColumn("kiloPrice" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_unitDiscount = new DataColumn("unitDiscount" , typeof(decimal));
			DataColumn col_totalDiscount = new DataColumn("totalDiscount" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_cost_FIFO = new DataColumn("cost_FIFO" , typeof(decimal));
			DataColumn col_weightedAvgCost = new DataColumn("weightedAvgCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_purchaseReturnedNote_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_externalGoodReceivedNote_ID,col_qty,col_qtySettle,col_weight,col_weightSettle,col_warranty,col_kiloPrice,col_unitPrice,col_unitDiscount,col_totalDiscount,col_tatalAmount,col_remark,col_cost_FIFO,col_weightedAvgCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsPurchaseReturnedNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsPurchaseReturnedNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsPurchaseReturnedNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["purchaseReturnedNote_ID"] = user.purchaseReturnedNote_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["externalGoodReceivedNote_ID"] = user.externalGoodReceivedNote_ID;
			drow["qty"] = user.qty;
			drow["qtySettle"] = user.qtySettle;
			drow["weight"] = user.weight;
			drow["weightSettle"] = user.weightSettle;
			drow["warranty"] = user.warranty;
			drow["kiloPrice"] = user.kiloPrice;
			drow["unitPrice"] = user.unitPrice;
			drow["unitDiscount"] = user.unitDiscount;
			drow["totalDiscount"] = user.totalDiscount;
			drow["tatalAmount"] = user.tatalAmount;
			drow["remark"] = user.remark;
			drow["cost_FIFO"] = user.cost_FIFO;
			drow["weightedAvgCost"] = user.weightedAvgCost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
