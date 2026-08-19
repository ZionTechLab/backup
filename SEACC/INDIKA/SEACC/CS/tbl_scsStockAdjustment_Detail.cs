using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsStockAdjustment_Detail {
		#region Fields
		private string stockAdjustment_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty;
		private decimal weight;
		private decimal oldQty;
		private decimal oldWeight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal tatalCost_FIFO;
		private decimal tatalCost_WA;
		private string remark;
		private decimal weightedAvgCost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsStockAdjustment_Detail class.
		/// </summary>
		public tbl_scsStockAdjustment_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsStockAdjustment_Detail class.
		/// </summary>
		public tbl_scsStockAdjustment_Detail(string stockAdjustment_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal weight, decimal oldQty, decimal oldWeight, decimal unitPrice, decimal weightPrice, decimal tatalCost_FIFO, decimal tatalCost_WA, string remark, decimal weightedAvgCost) {
			this.stockAdjustment_ID = stockAdjustment_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty = qty;
			this.weight = weight;
			this.oldQty = oldQty;
			this.oldWeight = oldWeight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.tatalCost_FIFO = tatalCost_FIFO;
			this.tatalCost_WA = tatalCost_WA;
			this.remark = remark;
			this.weightedAvgCost = weightedAvgCost;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the StockAdjustment_ID value.
		/// </summary>
		public string StockAdjustment_ID {
			get { return stockAdjustment_ID; }
			set { stockAdjustment_ID = value; }
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
		/// Gets or sets the OldQty value.
		/// </summary>
		public decimal OldQty {
			get { return oldQty; }
			set { oldQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the OldWeight value.
		/// </summary>
		public decimal OldWeight {
			get { return oldWeight; }
			set { oldWeight = value; }
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
		/// Saves a record to the tbl_scsStockAdjustment_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@stockAdjustment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@oldQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@oldWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_WA", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
			scom.Parameters["@stockAdjustment_ID"].Value = stockAdjustment_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@oldQty"].Value = oldQty;
			scom.Parameters["@oldWeight"].Value = oldWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@tatalCost_WA"].Value = tatalCost_WA;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsStockAdjustment_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@stockAdjustment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@oldQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@oldWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalCost_WA", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@stockAdjustment_ID"].Value = stockAdjustment_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@oldQty"].Value = oldQty;
			scom.Parameters["@oldWeight"].Value = oldWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@tatalCost_FIFO"].Value = tatalCost_FIFO;
			scom.Parameters["@tatalCost_WA"].Value = tatalCost_WA;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsStockAdjustment_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@stockAdjustment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@stockAdjustment_ID"].Value = stockAdjustment_ID;
 
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
		/// Selects all records from the tbl_scsStockAdjustment_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByStockAdjustment_ID(string stockAdjustment_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailDeleteAllByStockAdjustment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@stockAdjustment_ID", SqlDbType.VarChar,20);
			scom.Parameters["@stockAdjustment_ID"].Value = stockAdjustment_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsStockAdjustment_Detail table.
		/// </summary>
		public static tbl_scsStockAdjustment_Detail Select(string stockAdjustment_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_scsStockAdjustment_Detail tbl_scsStockAdjustment_Detailins = new tbl_scsStockAdjustment_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@stockAdjustment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@stockAdjustment_ID"].Value = stockAdjustment_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsStockAdjustment_Detailins = Maketbl_scsStockAdjustment_Detail(dataReader);
				} else {
					tbl_scsStockAdjustment_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsStockAdjustment_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment_Detail table.
		/// </summary>
		public static List<tbl_scsStockAdjustment_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsStockAdjustment_Detail> tbl_scsStockAdjustment_DetailList = new List<tbl_scsStockAdjustment_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdjustment_Detail tbl_scsStockAdjustment_Detail = Maketbl_scsStockAdjustment_Detail(dataReader);
					tbl_scsStockAdjustment_DetailList.Add(tbl_scsStockAdjustment_Detail);
				}
			}
			scon.Close();
			return tbl_scsStockAdjustment_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsStockAdjustment_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_scsStockAdjustment_Detail> tbl_scsStockAdjustment_DetailList = new List<tbl_scsStockAdjustment_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdjustment_Detail tbl_scsStockAdjustment_Detail = Maketbl_scsStockAdjustment_Detail(dataReader);
					tbl_scsStockAdjustment_DetailList.Add(tbl_scsStockAdjustment_Detail);
				}
			}
			scon.Close();
			return tbl_scsStockAdjustment_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsStockAdjustment_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_scsStockAdjustment_Detail> tbl_scsStockAdjustment_DetailList = new List<tbl_scsStockAdjustment_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdjustment_Detail tbl_scsStockAdjustment_Detail = Maketbl_scsStockAdjustment_Detail(dataReader);
					tbl_scsStockAdjustment_DetailList.Add(tbl_scsStockAdjustment_Detail);
				}
			}
			scon.Close();
			return tbl_scsStockAdjustment_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsStockAdjustment_Detail> SelectAllByStockAdjustment_ID(string stockAdjustment_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustment_DetailSelectAllByStockAdjustment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@stockAdjustment_ID", SqlDbType.VarChar,20);
			scom.Parameters["@stockAdjustment_ID"].Value = stockAdjustment_ID;
				List<tbl_scsStockAdjustment_Detail> tbl_scsStockAdjustment_DetailList = new List<tbl_scsStockAdjustment_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdjustment_Detail tbl_scsStockAdjustment_Detail = Maketbl_scsStockAdjustment_Detail(dataReader);
					tbl_scsStockAdjustment_DetailList.Add(tbl_scsStockAdjustment_Detail);
				}
			}
			scon.Close();
			return tbl_scsStockAdjustment_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsStockAdjustment_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsStockAdjustment_Detail Maketbl_scsStockAdjustment_Detail(SqlDataReader dataReader) {
			tbl_scsStockAdjustment_Detail tbl_scsStockAdjustment_Detail = new tbl_scsStockAdjustment_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsStockAdjustment_Detail.StockAdjustment_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsStockAdjustment_Detail.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsStockAdjustment_Detail.ItemSubCategory_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsStockAdjustment_Detail.ItemSubCategory2_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsStockAdjustment_Detail.ItemSerialNo = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsStockAdjustment_Detail.ItemSerialNo2 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsStockAdjustment_Detail.Qty = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsStockAdjustment_Detail.Weight = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsStockAdjustment_Detail.OldQty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsStockAdjustment_Detail.OldWeight = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsStockAdjustment_Detail.UnitPrice = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsStockAdjustment_Detail.WeightPrice = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsStockAdjustment_Detail.TatalCost_FIFO = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsStockAdjustment_Detail.TatalCost_WA = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsStockAdjustment_Detail.Remark = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsStockAdjustment_Detail.WeightedAvgCost = dataReader.GetDecimal(15);
			}

			return tbl_scsStockAdjustment_Detail;
		}
		/// <summary>
		/// This makes tbl_scsStockAdjustment_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsStockAdjustment_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsStockAdjustment_Detail  tbl_scsStockAdjustment_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_stockAdjustment_ID = new DataColumn("stockAdjustment_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_oldQty = new DataColumn("oldQty" , typeof(decimal));
			DataColumn col_oldWeight = new DataColumn("oldWeight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_tatalCost_FIFO = new DataColumn("tatalCost_FIFO" , typeof(decimal));
			DataColumn col_tatalCost_WA = new DataColumn("tatalCost_WA" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_weightedAvgCost = new DataColumn("weightedAvgCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_stockAdjustment_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_weight,col_oldQty,col_oldWeight,col_unitPrice,col_weightPrice,col_tatalCost_FIFO,col_tatalCost_WA,col_remark,col_weightedAvgCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsStockAdjustment_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsStockAdjustment_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsStockAdjustment_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["stockAdjustment_ID"] = user.stockAdjustment_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["oldQty"] = user.oldQty;
			drow["oldWeight"] = user.oldWeight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["tatalCost_FIFO"] = user.tatalCost_FIFO;
			drow["tatalCost_WA"] = user.tatalCost_WA;
			drow["remark"] = user.remark;
			drow["weightedAvgCost"] = user.weightedAvgCost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
