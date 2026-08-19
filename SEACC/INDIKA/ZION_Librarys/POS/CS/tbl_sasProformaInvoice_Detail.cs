using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasProformaInvoice_Detail {
		#region Fields
		private int line_No;
		private string proformaInvoice_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string quotation_ID;
		private string job_ID;
		private decimal qty;
		private decimal qtySettle;
		private decimal weight;
		private decimal weightSettle;
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
		private string uom_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasProformaInvoice_Detail class.
		/// </summary>
		public tbl_sasProformaInvoice_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasProformaInvoice_Detail class.
		/// </summary>
		public tbl_sasProformaInvoice_Detail(int line_No, string proformaInvoice_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string quotation_ID, string job_ID, decimal qty, decimal qtySettle, decimal weight, decimal weightSettle, decimal unitPrice, decimal weightPrice, bool bIsFreeItem, decimal discountPresentage, decimal discountAmount, decimal tatalAmount, decimal recommendedUnitPrice, decimal recommendedWeightPrice, decimal recommendedunitTotalAmount, string remark, string uom_ID) {
			this.line_No = line_No;
			this.proformaInvoice_ID = proformaInvoice_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.quotation_ID = quotation_ID;
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
		/// Gets or sets the ProformaInvoice_ID value.
		/// </summary>
		public string ProformaInvoice_ID {
			get { return proformaInvoice_ID; }
			set { proformaInvoice_ID = value; }
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
		/// Saves a record to the tbl_sasProformaInvoice_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasProformaInvoice_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
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
		/// Updates a record in the tbl_sasProformaInvoice_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasProformaInvoice_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
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
		/// Deletes a record from the tbl_sasProformaInvoice_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasProformaInvoice_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasProformaInvoice_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByProformaInvoice_ID(string proformaInvoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasProformaInvoice_DetailDeleteAllByProformaInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasProformaInvoice_Detail table.
		/// </summary>
		public static tbl_sasProformaInvoice_Detail Select(int line_No_Incoming, string proformaInvoice_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming, string quotation_ID_Incoming){

			tbl_sasProformaInvoice_Detail tbl_sasProformaInvoice_Detailins = new tbl_sasProformaInvoice_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasProformaInvoice_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			scom.Parameters["@quotation_ID"].Value = quotation_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasProformaInvoice_Detailins = Maketbl_sasProformaInvoice_Detail(dataReader);
				} else {
					tbl_sasProformaInvoice_Detailins = null;
				}
			}
			scon.Close();
			return tbl_sasProformaInvoice_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasProformaInvoice_Detail table.
		/// </summary>
		public static List<tbl_sasProformaInvoice_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasProformaInvoice_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasProformaInvoice_Detail> tbl_sasProformaInvoice_DetailList = new List<tbl_sasProformaInvoice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasProformaInvoice_Detail tbl_sasProformaInvoice_Detail = Maketbl_sasProformaInvoice_Detail(dataReader);
					tbl_sasProformaInvoice_DetailList.Add(tbl_sasProformaInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasProformaInvoice_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasProformaInvoice_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasProformaInvoice_Detail> SelectAllByProformaInvoice_ID(string proformaInvoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasProformaInvoice_DetailSelectAllByProformaInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@proformaInvoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@proformaInvoice_ID"].Value = proformaInvoice_ID;
				List<tbl_sasProformaInvoice_Detail> tbl_sasProformaInvoice_DetailList = new List<tbl_sasProformaInvoice_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasProformaInvoice_Detail tbl_sasProformaInvoice_Detail = Maketbl_sasProformaInvoice_Detail(dataReader);
					tbl_sasProformaInvoice_DetailList.Add(tbl_sasProformaInvoice_Detail);
				}
			}
			scon.Close();
			return tbl_sasProformaInvoice_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasProformaInvoice_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasProformaInvoice_Detail Maketbl_sasProformaInvoice_Detail(SqlDataReader dataReader) {
			tbl_sasProformaInvoice_Detail tbl_sasProformaInvoice_Detail = new tbl_sasProformaInvoice_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasProformaInvoice_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasProformaInvoice_Detail.ProformaInvoice_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasProformaInvoice_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasProformaInvoice_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasProformaInvoice_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasProformaInvoice_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasProformaInvoice_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasProformaInvoice_Detail.Quotation_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasProformaInvoice_Detail.Job_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasProformaInvoice_Detail.Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasProformaInvoice_Detail.QtySettle = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasProformaInvoice_Detail.Weight = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasProformaInvoice_Detail.WeightSettle = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasProformaInvoice_Detail.UnitPrice = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasProformaInvoice_Detail.WeightPrice = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasProformaInvoice_Detail.BIsFreeItem = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasProformaInvoice_Detail.DiscountPresentage = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasProformaInvoice_Detail.DiscountAmount = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasProformaInvoice_Detail.TatalAmount = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasProformaInvoice_Detail.RecommendedUnitPrice = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasProformaInvoice_Detail.RecommendedWeightPrice = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasProformaInvoice_Detail.RecommendedunitTotalAmount = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasProformaInvoice_Detail.Remark = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasProformaInvoice_Detail.Uom_ID = dataReader.GetString(23);
			}

			return tbl_sasProformaInvoice_Detail;
		}
		/// <summary>
		/// This makes tbl_sasProformaInvoice_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasProformaInvoice_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasProformaInvoice_Detail  tbl_sasProformaInvoice_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_proformaInvoice_ID = new DataColumn("proformaInvoice_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_quotation_ID = new DataColumn("quotation_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle" , typeof(decimal));
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
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_proformaInvoice_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_quotation_ID,col_job_ID,col_qty,col_qtySettle,col_weight,col_weightSettle,col_unitPrice,col_weightPrice,col_bIsFreeItem,col_discountPresentage,col_discountAmount,col_tatalAmount,col_recommendedUnitPrice,col_recommendedWeightPrice,col_recommendedunitTotalAmount,col_remark,col_uom_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasProformaInvoice_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasProformaInvoice_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasProformaInvoice_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["proformaInvoice_ID"] = user.proformaInvoice_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["quotation_ID"] = user.quotation_ID;
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
