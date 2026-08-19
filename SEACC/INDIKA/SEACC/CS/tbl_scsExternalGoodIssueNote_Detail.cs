using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsExternalGoodIssueNote_Detail {
		#region Fields
		private int line_No;
		private string externalGoodIssueNote_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty;
		private decimal weight;
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
		/// Initializes a new instance of the tbl_scsExternalGoodIssueNote_Detail class.
		/// </summary>
		public tbl_scsExternalGoodIssueNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsExternalGoodIssueNote_Detail class.
		/// </summary>
		public tbl_scsExternalGoodIssueNote_Detail(int line_No, string externalGoodIssueNote_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal weight, decimal kiloPrice, decimal unitPrice, decimal unitDiscount, decimal totalDiscount, decimal tatalAmount, string remark, decimal cost_FIFO, decimal weightedAvgCost) {
			this.line_No = line_No;
			this.externalGoodIssueNote_ID = externalGoodIssueNote_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty = qty;
			this.weight = weight;
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
		/// Gets or sets the ExternalGoodIssueNote_ID value.
		/// </summary>
		public string ExternalGoodIssueNote_ID {
			get { return externalGoodIssueNote_ID; }
			set { externalGoodIssueNote_ID = value; }
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
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
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
		/// Saves a record to the tbl_scsExternalGoodIssueNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@externalGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@cost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@externalGoodIssueNote_ID"].Value = externalGoodIssueNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
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
		/// Updates a record in the tbl_scsExternalGoodIssueNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@externalGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalDiscount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@cost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@externalGoodIssueNote_ID"].Value = externalGoodIssueNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
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
		/// Deletes a record from the tbl_scsExternalGoodIssueNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@externalGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@externalGoodIssueNote_ID"].Value = externalGoodIssueNote_ID;
 
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
		/// Selects all records from the tbl_scsExternalGoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByExternalGoodIssueNote_ID(string externalGoodIssueNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailDeleteAllByExternalGoodIssueNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodIssueNote_ID"].Value = externalGoodIssueNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsExternalGoodIssueNote_Detail table.
		/// </summary>
		public static tbl_scsExternalGoodIssueNote_Detail Select(int line_No_Incoming, string externalGoodIssueNote_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_scsExternalGoodIssueNote_Detail tbl_scsExternalGoodIssueNote_Detailins = new tbl_scsExternalGoodIssueNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@externalGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@externalGoodIssueNote_ID"].Value = externalGoodIssueNote_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsExternalGoodIssueNote_Detailins = Maketbl_scsExternalGoodIssueNote_Detail(dataReader);
				} else {
					tbl_scsExternalGoodIssueNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsExternalGoodIssueNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodIssueNote_Detail table.
		/// </summary>
		public static List<tbl_scsExternalGoodIssueNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsExternalGoodIssueNote_Detail> tbl_scsExternalGoodIssueNote_DetailList = new List<tbl_scsExternalGoodIssueNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodIssueNote_Detail tbl_scsExternalGoodIssueNote_Detail = Maketbl_scsExternalGoodIssueNote_Detail(dataReader);
					tbl_scsExternalGoodIssueNote_DetailList.Add(tbl_scsExternalGoodIssueNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodIssueNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsExternalGoodIssueNote_Detail> SelectAllByExternalGoodIssueNote_ID(string externalGoodIssueNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailSelectAllByExternalGoodIssueNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodIssueNote_ID"].Value = externalGoodIssueNote_ID;
				List<tbl_scsExternalGoodIssueNote_Detail> tbl_scsExternalGoodIssueNote_DetailList = new List<tbl_scsExternalGoodIssueNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodIssueNote_Detail tbl_scsExternalGoodIssueNote_Detail = Maketbl_scsExternalGoodIssueNote_Detail(dataReader);
					tbl_scsExternalGoodIssueNote_DetailList.Add(tbl_scsExternalGoodIssueNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodIssueNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsExternalGoodIssueNote_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_scsExternalGoodIssueNote_Detail> tbl_scsExternalGoodIssueNote_DetailList = new List<tbl_scsExternalGoodIssueNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodIssueNote_Detail tbl_scsExternalGoodIssueNote_Detail = Maketbl_scsExternalGoodIssueNote_Detail(dataReader);
					tbl_scsExternalGoodIssueNote_DetailList.Add(tbl_scsExternalGoodIssueNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodIssueNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsExternalGoodIssueNote_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsExternalGoodIssueNote_Detail> tbl_scsExternalGoodIssueNote_DetailList = new List<tbl_scsExternalGoodIssueNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodIssueNote_Detail tbl_scsExternalGoodIssueNote_Detail = Maketbl_scsExternalGoodIssueNote_Detail(dataReader);
					tbl_scsExternalGoodIssueNote_DetailList.Add(tbl_scsExternalGoodIssueNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodIssueNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsExternalGoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsExternalGoodIssueNote_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsExternalGoodIssueNote_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_scsExternalGoodIssueNote_Detail> tbl_scsExternalGoodIssueNote_DetailList = new List<tbl_scsExternalGoodIssueNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsExternalGoodIssueNote_Detail tbl_scsExternalGoodIssueNote_Detail = Maketbl_scsExternalGoodIssueNote_Detail(dataReader);
					tbl_scsExternalGoodIssueNote_DetailList.Add(tbl_scsExternalGoodIssueNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsExternalGoodIssueNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsExternalGoodIssueNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsExternalGoodIssueNote_Detail Maketbl_scsExternalGoodIssueNote_Detail(SqlDataReader dataReader) {
			tbl_scsExternalGoodIssueNote_Detail tbl_scsExternalGoodIssueNote_Detail = new tbl_scsExternalGoodIssueNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsExternalGoodIssueNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsExternalGoodIssueNote_Detail.ExternalGoodIssueNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsExternalGoodIssueNote_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsExternalGoodIssueNote_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsExternalGoodIssueNote_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsExternalGoodIssueNote_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsExternalGoodIssueNote_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsExternalGoodIssueNote_Detail.Qty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsExternalGoodIssueNote_Detail.Weight = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsExternalGoodIssueNote_Detail.KiloPrice = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsExternalGoodIssueNote_Detail.UnitPrice = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsExternalGoodIssueNote_Detail.UnitDiscount = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsExternalGoodIssueNote_Detail.TotalDiscount = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsExternalGoodIssueNote_Detail.TatalAmount = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsExternalGoodIssueNote_Detail.Remark = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsExternalGoodIssueNote_Detail.Cost_FIFO = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsExternalGoodIssueNote_Detail.WeightedAvgCost = dataReader.GetDecimal(16);
			}

			return tbl_scsExternalGoodIssueNote_Detail;
		}
		/// <summary>
		/// This makes tbl_scsExternalGoodIssueNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsExternalGoodIssueNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsExternalGoodIssueNote_Detail  tbl_scsExternalGoodIssueNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_externalGoodIssueNote_ID = new DataColumn("externalGoodIssueNote_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_kiloPrice = new DataColumn("kiloPrice" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_unitDiscount = new DataColumn("unitDiscount" , typeof(decimal));
			DataColumn col_totalDiscount = new DataColumn("totalDiscount" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_cost_FIFO = new DataColumn("cost_FIFO" , typeof(decimal));
			DataColumn col_weightedAvgCost = new DataColumn("weightedAvgCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_externalGoodIssueNote_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_weight,col_kiloPrice,col_unitPrice,col_unitDiscount,col_totalDiscount,col_tatalAmount,col_remark,col_cost_FIFO,col_weightedAvgCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsExternalGoodIssueNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsExternalGoodIssueNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsExternalGoodIssueNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["externalGoodIssueNote_ID"] = user.externalGoodIssueNote_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
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
