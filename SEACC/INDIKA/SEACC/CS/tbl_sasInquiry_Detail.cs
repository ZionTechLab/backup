using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasInquiry_Detail {
		#region Fields
		private int line_No;
		private string inquiry_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty;
		private decimal qtySettle;
		private decimal weight;
		private decimal weightSettle;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal unitDiscount;
		private decimal totalDiscount;
		private decimal tatalAmount;
		private decimal recommendedUnitPrice;
		private decimal recommendedWeightPrice;
		private decimal recommendedunitTotalAmount;
		private string remark;
		private bool isWeightCalculation;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasInquiry_Detail class.
		/// </summary>
		public tbl_sasInquiry_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasInquiry_Detail class.
		/// </summary>
		public tbl_sasInquiry_Detail(int line_No, string inquiry_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal qtySettle, decimal weight, decimal weightSettle, decimal unitPrice, decimal weightPrice, decimal unitDiscount, decimal totalDiscount, decimal tatalAmount, decimal recommendedUnitPrice, decimal recommendedWeightPrice, decimal recommendedunitTotalAmount, string remark, bool isWeightCalculation) {
			this.line_No = line_No;
			this.inquiry_ID = inquiry_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.weight = weight;
			this.weightSettle = weightSettle;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.unitDiscount = unitDiscount;
			this.totalDiscount = totalDiscount;
			this.tatalAmount = tatalAmount;
			this.recommendedUnitPrice = recommendedUnitPrice;
			this.recommendedWeightPrice = recommendedWeightPrice;
			this.recommendedunitTotalAmount = recommendedunitTotalAmount;
			this.remark = remark;
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
		/// Gets or sets the Inquiry_ID value.
		/// </summary>
		public string Inquiry_ID {
			get { return inquiry_ID; }
			set { inquiry_ID = value; }
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
		/// Gets or sets the IsWeightCalculation value.
		/// </summary>
		public bool IsWeightCalculation {
			get { return isWeightCalculation; }
			set { isWeightCalculation = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasInquiry_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@unitDiscount"].Value = unitDiscount;
			scom.Parameters["@totalDiscount"].Value = totalDiscount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasInquiry_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedUnitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedWeightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@recommendedunitTotalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@unitDiscount"].Value = unitDiscount;
			scom.Parameters["@totalDiscount"].Value = totalDiscount;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@recommendedUnitPrice"].Value = recommendedUnitPrice;
			scom.Parameters["@recommendedWeightPrice"].Value = recommendedWeightPrice;
			scom.Parameters["@recommendedunitTotalAmount"].Value = recommendedunitTotalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasInquiry_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
 
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
		/// Selects all records from the tbl_sasInquiry_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInquiry_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByInquiry_ID(string inquiry_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailDeleteAllByInquiry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInquiry_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInquiry_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasInquiry_Detail table.
		/// </summary>
		public static tbl_sasInquiry_Detail Select(string inquiry_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_sasInquiry_Detail tbl_sasInquiry_Detailins = new tbl_sasInquiry_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasInquiry_Detailins = Maketbl_sasInquiry_Detail(dataReader);
				} else {
					tbl_sasInquiry_Detailins = null;
				}
			}
			scon.Close();
			return tbl_sasInquiry_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInquiry_Detail table.
		/// </summary>
		public static List<tbl_sasInquiry_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasInquiry_Detail> tbl_sasInquiry_DetailList = new List<tbl_sasInquiry_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInquiry_Detail tbl_sasInquiry_Detail = Maketbl_sasInquiry_Detail(dataReader);
					tbl_sasInquiry_DetailList.Add(tbl_sasInquiry_Detail);
				}
			}
			scon.Close();
			return tbl_sasInquiry_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInquiry_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInquiry_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_sasInquiry_Detail> tbl_sasInquiry_DetailList = new List<tbl_sasInquiry_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInquiry_Detail tbl_sasInquiry_Detail = Maketbl_sasInquiry_Detail(dataReader);
					tbl_sasInquiry_DetailList.Add(tbl_sasInquiry_Detail);
				}
			}
			scon.Close();
			return tbl_sasInquiry_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInquiry_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInquiry_Detail> SelectAllByInquiry_ID(string inquiry_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailSelectAllByInquiry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
				List<tbl_sasInquiry_Detail> tbl_sasInquiry_DetailList = new List<tbl_sasInquiry_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInquiry_Detail tbl_sasInquiry_Detail = Maketbl_sasInquiry_Detail(dataReader);
					tbl_sasInquiry_DetailList.Add(tbl_sasInquiry_Detail);
				}
			}
			scon.Close();
			return tbl_sasInquiry_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInquiry_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInquiry_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_sasInquiry_Detail> tbl_sasInquiry_DetailList = new List<tbl_sasInquiry_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInquiry_Detail tbl_sasInquiry_Detail = Maketbl_sasInquiry_Detail(dataReader);
					tbl_sasInquiry_DetailList.Add(tbl_sasInquiry_Detail);
				}
			}
			scon.Close();
			return tbl_sasInquiry_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasInquiry_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasInquiry_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasInquiry_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_sasInquiry_Detail> tbl_sasInquiry_DetailList = new List<tbl_sasInquiry_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasInquiry_Detail tbl_sasInquiry_Detail = Maketbl_sasInquiry_Detail(dataReader);
					tbl_sasInquiry_DetailList.Add(tbl_sasInquiry_Detail);
				}
			}
			scon.Close();
			return tbl_sasInquiry_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasInquiry_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasInquiry_Detail Maketbl_sasInquiry_Detail(SqlDataReader dataReader) {
			tbl_sasInquiry_Detail tbl_sasInquiry_Detail = new tbl_sasInquiry_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasInquiry_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasInquiry_Detail.Inquiry_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasInquiry_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasInquiry_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasInquiry_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasInquiry_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasInquiry_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasInquiry_Detail.Qty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasInquiry_Detail.QtySettle = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasInquiry_Detail.Weight = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasInquiry_Detail.WeightSettle = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasInquiry_Detail.UnitPrice = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasInquiry_Detail.WeightPrice = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasInquiry_Detail.UnitDiscount = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasInquiry_Detail.TotalDiscount = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasInquiry_Detail.TatalAmount = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasInquiry_Detail.RecommendedUnitPrice = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasInquiry_Detail.RecommendedWeightPrice = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasInquiry_Detail.RecommendedunitTotalAmount = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasInquiry_Detail.Remark = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasInquiry_Detail.IsWeightCalculation = dataReader.GetBoolean(20);
			}

			return tbl_sasInquiry_Detail;
		}
		/// <summary>
		/// This makes tbl_sasInquiry_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasInquiry_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasInquiry_Detail  tbl_sasInquiry_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_inquiry_ID = new DataColumn("inquiry_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_unitDiscount = new DataColumn("unitDiscount" , typeof(decimal));
			DataColumn col_totalDiscount = new DataColumn("totalDiscount" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
			DataColumn col_recommendedUnitPrice = new DataColumn("recommendedUnitPrice" , typeof(decimal));
			DataColumn col_recommendedWeightPrice = new DataColumn("recommendedWeightPrice" , typeof(decimal));
			DataColumn col_recommendedunitTotalAmount = new DataColumn("recommendedunitTotalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_inquiry_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_qtySettle,col_weight,col_weightSettle,col_unitPrice,col_weightPrice,col_unitDiscount,col_totalDiscount,col_tatalAmount,col_recommendedUnitPrice,col_recommendedWeightPrice,col_recommendedunitTotalAmount,col_remark,col_isWeightCalculation,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasInquiry_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasInquiry_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasInquiry_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["inquiry_ID"] = user.inquiry_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty"] = user.qty;
			drow["qtySettle"] = user.qtySettle;
			drow["weight"] = user.weight;
			drow["weightSettle"] = user.weightSettle;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["unitDiscount"] = user.unitDiscount;
			drow["totalDiscount"] = user.totalDiscount;
			drow["tatalAmount"] = user.tatalAmount;
			drow["recommendedUnitPrice"] = user.recommendedUnitPrice;
			drow["recommendedWeightPrice"] = user.recommendedWeightPrice;
			drow["recommendedunitTotalAmount"] = user.recommendedunitTotalAmount;
			drow["remark"] = user.remark;
			drow["isWeightCalculation"] = user.isWeightCalculation;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
