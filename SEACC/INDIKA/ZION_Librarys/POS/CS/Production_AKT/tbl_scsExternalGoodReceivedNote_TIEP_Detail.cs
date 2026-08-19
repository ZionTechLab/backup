using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsExternalGoodReceivedNote_TIEP_Detail {
		#region Fields
		private int line_No;
		private string externalGoodReceivedNote_ID;
		private string item_ID;
		private string purchaseOrder_ID;
		private string purchaseReturnedNote_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty;
		private decimal qtySettle;
		private decimal weight;
		private decimal weightSettle;
		private decimal warranty;
		private string batchNo;
		private decimal kiloPrice;
		private decimal unitPrice;
		private decimal unitDiscount;
		private decimal totalDiscount;
		private decimal tatalAmount;
		private string remark;
		private bool bHasBreakDown;
		private decimal numberOfRolls;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsExternalGoodReceivedNote_TIEP_Detail class.
		/// </summary>
		public tbl_scsExternalGoodReceivedNote_TIEP_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsExternalGoodReceivedNote_TIEP_Detail class.
		/// </summary>
		public tbl_scsExternalGoodReceivedNote_TIEP_Detail(int line_No, string externalGoodReceivedNote_ID, string item_ID, string purchaseOrder_ID, string purchaseReturnedNote_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal qtySettle, decimal weight, decimal weightSettle, decimal warranty, string batchNo, decimal kiloPrice, decimal unitPrice, decimal unitDiscount, decimal totalDiscount, decimal tatalAmount, string remark, bool bHasBreakDown, decimal numberOfRolls) {
			this.line_No = line_No;
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.item_ID = item_ID;
			this.purchaseOrder_ID = purchaseOrder_ID;
			this.purchaseReturnedNote_ID = purchaseReturnedNote_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.weight = weight;
			this.weightSettle = weightSettle;
			this.warranty = warranty;
			this.batchNo = batchNo;
			this.kiloPrice = kiloPrice;
			this.unitPrice = unitPrice;
			this.unitDiscount = unitDiscount;
			this.totalDiscount = totalDiscount;
			this.tatalAmount = tatalAmount;
			this.remark = remark;
			this.bHasBreakDown = bHasBreakDown;
			this.numberOfRolls = numberOfRolls;
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
		/// Gets or sets the ExternalGoodReceivedNote_ID value.
		/// </summary>
		public string ExternalGoodReceivedNote_ID {
			get { return externalGoodReceivedNote_ID; }
			set { externalGoodReceivedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseOrder_ID value.
		/// </summary>
		public string PurchaseOrder_ID {
			get { return purchaseOrder_ID; }
			set { purchaseOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseReturnedNote_ID value.
		/// </summary>
		public string PurchaseReturnedNote_ID {
			get { return purchaseReturnedNote_ID; }
			set { purchaseReturnedNote_ID = value; }
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
		/// Gets or sets the BatchNo value.
		/// </summary>
		public string BatchNo {
			get { return batchNo; }
			set { batchNo = value; }
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
		/// Gets or sets the BHasBreakDown value.
		/// </summary>
		public bool BHasBreakDown {
			get { return bHasBreakDown; }
			set { bHasBreakDown = value; }
		}
		
		/// <summary>
		/// Gets or sets the NumberOfRolls value.
		/// </summary>
		public decimal NumberOfRolls {
			get { return numberOfRolls; }
			set { numberOfRolls = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsExternalGoodReceivedNote_TIEP_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEP_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@warranty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@bHasBreakDown", SqlDbType.Bit,1);
			scom.Parameters.Add("@numberOfRolls", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@warranty"].Value = warranty;
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@kiloPrice"].Value = kiloPrice;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@unitDiscount"].Value = unitDiscount;
			scom.Parameters["@totalDiscount"].Value = totalDiscount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@bHasBreakDown"].Value = bHasBreakDown;
			scom.Parameters["@numberOfRolls"].Value = numberOfRolls;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsExternalGoodReceivedNote_TIEP_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEP_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@warranty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@bHasBreakDown", SqlDbType.Bit,1);
			scom.Parameters.Add("@numberOfRolls", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@purchaseOrder_ID"].Value = purchaseOrder_ID;
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@warranty"].Value = warranty;
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@kiloPrice"].Value = kiloPrice;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@unitDiscount"].Value = unitDiscount;
			scom.Parameters["@totalDiscount"].Value = totalDiscount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@bHasBreakDown"].Value = bHasBreakDown;
			scom.Parameters["@numberOfRolls"].Value = numberOfRolls;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsExternalGoodReceivedNote_TIEP_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEP_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
 
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
		/// Selects all records from the tbl_scsExternalGoodReceivedNote_TIEP_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByExternalGoodReceivedNote_ID(string externalGoodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEP_DetailDeleteAllByExternalGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsExternalGoodReceivedNote_TIEP_Detail table.
		/// </summary>
		public static tbl_scsExternalGoodReceivedNote_TIEP_Detail Select(string externalGoodReceivedNote_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_scsExternalGoodReceivedNote_TIEP_Detail tbl_scsExternalGoodReceivedNote_TIEP_Detailins = new tbl_scsExternalGoodReceivedNote_TIEP_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEP_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote_TIEP_Detailins = Maketbl_scsExternalGoodReceivedNote_TIEP_Detail(dataReader);
				} else {
					tbl_scsExternalGoodReceivedNote_TIEP_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNote_TIEP_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote_TIEP_Detail table.
		/// </summary>
		public static List<tbl_scsExternalGoodReceivedNote_TIEP_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEP_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsExternalGoodReceivedNote_TIEP_Detail> tbl_scsExternalGoodReceivedNote_TIEP_DetailList = new List<tbl_scsExternalGoodReceivedNote_TIEP_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote_TIEP_Detail tbl_scsExternalGoodReceivedNote_TIEP_Detail = Maketbl_scsExternalGoodReceivedNote_TIEP_Detail(dataReader);
					tbl_scsExternalGoodReceivedNote_TIEP_DetailList.Add(tbl_scsExternalGoodReceivedNote_TIEP_Detail);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNote_TIEP_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodReceivedNote_TIEP_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsExternalGoodReceivedNote_TIEP_Detail> SelectAllByExternalGoodReceivedNote_ID(string externalGoodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodReceivedNote_TIEP_DetailSelectAllByExternalGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
				List<tbl_scsExternalGoodReceivedNote_TIEP_Detail> tbl_scsExternalGoodReceivedNote_TIEP_DetailList = new List<tbl_scsExternalGoodReceivedNote_TIEP_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodReceivedNote_TIEP_Detail tbl_scsExternalGoodReceivedNote_TIEP_Detail = Maketbl_scsExternalGoodReceivedNote_TIEP_Detail(dataReader);
					tbl_scsExternalGoodReceivedNote_TIEP_DetailList.Add(tbl_scsExternalGoodReceivedNote_TIEP_Detail);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodReceivedNote_TIEP_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsExternalGoodReceivedNote_TIEP_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsExternalGoodReceivedNote_TIEP_Detail Maketbl_scsExternalGoodReceivedNote_TIEP_Detail(SqlDataReader dataReader) {
			tbl_scsExternalGoodReceivedNote_TIEP_Detail tbl_scsExternalGoodReceivedNote_TIEP_Detail = new tbl_scsExternalGoodReceivedNote_TIEP_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.ExternalGoodReceivedNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.PurchaseOrder_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.PurchaseReturnedNote_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.ItemSubCategory_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.ItemSubCategory2_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.ItemSerialNo = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.ItemSerialNo2 = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.QtySettle = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.Weight = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.WeightSettle = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.Warranty = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.BatchNo = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.KiloPrice = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.UnitPrice = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.UnitDiscount = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.TotalDiscount = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.TatalAmount = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.Remark = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.BHasBreakDown = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsExternalGoodReceivedNote_TIEP_Detail.NumberOfRolls = dataReader.GetDecimal(22);
			}

			return tbl_scsExternalGoodReceivedNote_TIEP_Detail;
		}
		/// <summary>
		/// This makes tbl_scsExternalGoodReceivedNote_TIEP_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsExternalGoodReceivedNote_TIEP_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsExternalGoodReceivedNote_TIEP_Detail  tbl_scsExternalGoodReceivedNote_TIEP_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_externalGoodReceivedNote_ID = new DataColumn("externalGoodReceivedNote_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_purchaseOrder_ID = new DataColumn("purchaseOrder_ID" , typeof(string));
			DataColumn col_purchaseReturnedNote_ID = new DataColumn("purchaseReturnedNote_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle" , typeof(decimal));
			DataColumn col_warranty = new DataColumn("warranty" , typeof(decimal));
			DataColumn col_batchNo = new DataColumn("batchNo" , typeof(string));
			DataColumn col_kiloPrice = new DataColumn("kiloPrice" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_unitDiscount = new DataColumn("unitDiscount" , typeof(decimal));
			DataColumn col_totalDiscount = new DataColumn("totalDiscount" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_bHasBreakDown = new DataColumn("bHasBreakDown" , typeof(bool));
			DataColumn col_numberOfRolls = new DataColumn("numberOfRolls" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_externalGoodReceivedNote_ID,col_item_ID,col_purchaseOrder_ID,col_purchaseReturnedNote_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_qtySettle,col_weight,col_weightSettle,col_warranty,col_batchNo,col_kiloPrice,col_unitPrice,col_unitDiscount,col_totalDiscount,col_tatalAmount,col_remark,col_bHasBreakDown,col_numberOfRolls,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsExternalGoodReceivedNote_TIEP_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsExternalGoodReceivedNote_TIEP_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsExternalGoodReceivedNote_TIEP_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["externalGoodReceivedNote_ID"] = user.externalGoodReceivedNote_ID;
			drow["item_ID"] = user.item_ID;
			drow["purchaseOrder_ID"] = user.purchaseOrder_ID;
			drow["purchaseReturnedNote_ID"] = user.purchaseReturnedNote_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty"] = user.qty;
			drow["qtySettle"] = user.qtySettle;
			drow["weight"] = user.weight;
			drow["weightSettle"] = user.weightSettle;
			drow["warranty"] = user.warranty;
			drow["batchNo"] = user.batchNo;
			drow["kiloPrice"] = user.kiloPrice;
			drow["unitPrice"] = user.unitPrice;
			drow["unitDiscount"] = user.unitDiscount;
			drow["totalDiscount"] = user.totalDiscount;
			drow["tatalAmount"] = user.tatalAmount;
			drow["remark"] = user.remark;
			drow["bHasBreakDown"] = user.bHasBreakDown;
			drow["numberOfRolls"] = user.numberOfRolls;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
