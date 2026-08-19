using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsDiscardedGoodNote_Detail {
		#region Fields
		private int line_No;
		private string discardedGoodNote_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal damagedQty;
		private decimal damagedWeight;
		private decimal discardingWeight;
		private decimal discardingQty;
		private decimal salvageValue;
		private string remark;
		private decimal cost_FIFO;
		private decimal weightedAvgCost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsDiscardedGoodNote_Detail class.
		/// </summary>
		public tbl_scsDiscardedGoodNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsDiscardedGoodNote_Detail class.
		/// </summary>
		public tbl_scsDiscardedGoodNote_Detail(int line_No, string discardedGoodNote_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal damagedQty, decimal damagedWeight, decimal discardingWeight, decimal discardingQty, decimal salvageValue, string remark, decimal cost_FIFO, decimal weightedAvgCost) {
			this.line_No = line_No;
			this.discardedGoodNote_ID = discardedGoodNote_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.damagedQty = damagedQty;
			this.damagedWeight = damagedWeight;
			this.discardingWeight = discardingWeight;
			this.discardingQty = discardingQty;
			this.salvageValue = salvageValue;
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
		/// Gets or sets the DiscardedGoodNote_ID value.
		/// </summary>
		public string DiscardedGoodNote_ID {
			get { return discardedGoodNote_ID; }
			set { discardedGoodNote_ID = value; }
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
		/// Gets or sets the DamagedQty value.
		/// </summary>
		public decimal DamagedQty {
			get { return damagedQty; }
			set { damagedQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the DamagedWeight value.
		/// </summary>
		public decimal DamagedWeight {
			get { return damagedWeight; }
			set { damagedWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscardingWeight value.
		/// </summary>
		public decimal DiscardingWeight {
			get { return discardingWeight; }
			set { discardingWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscardingQty value.
		/// </summary>
		public decimal DiscardingQty {
			get { return discardingQty; }
			set { discardingQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalvageValue value.
		/// </summary>
		public decimal SalvageValue {
			get { return salvageValue; }
			set { salvageValue = value; }
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
		/// Saves a record to the tbl_scsDiscardedGoodNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@discardedGoodNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@damagedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@damagedWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discardingWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discardingQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salvageValue", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@cost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@discardedGoodNote_ID"].Value = discardedGoodNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@damagedQty"].Value = damagedQty;
			scom.Parameters["@damagedWeight"].Value = damagedWeight;
			scom.Parameters["@discardingWeight"].Value = discardingWeight;
			scom.Parameters["@discardingQty"].Value = discardingQty;
			scom.Parameters["@salvageValue"].Value = salvageValue;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@cost_FIFO"].Value = cost_FIFO;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsDiscardedGoodNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@discardedGoodNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@damagedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@damagedWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discardingWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discardingQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salvageValue", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@cost_FIFO", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@discardedGoodNote_ID"].Value = discardedGoodNote_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@damagedQty"].Value = damagedQty;
			scom.Parameters["@damagedWeight"].Value = damagedWeight;
			scom.Parameters["@discardingWeight"].Value = discardingWeight;
			scom.Parameters["@discardingQty"].Value = discardingQty;
			scom.Parameters["@salvageValue"].Value = salvageValue;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@cost_FIFO"].Value = cost_FIFO;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsDiscardedGoodNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@discardedGoodNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@discardedGoodNote_ID"].Value = discardedGoodNote_ID;
 
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
		/// Selects all records from the tbl_scsDiscardedGoodNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDiscardedGoodNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDiscardedGoodNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByDiscardedGoodNote_ID(string discardedGoodNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailDeleteAllByDiscardedGoodNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@discardedGoodNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@discardedGoodNote_ID"].Value = discardedGoodNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDiscardedGoodNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsDiscardedGoodNote_Detail table.
		/// </summary>
		public static tbl_scsDiscardedGoodNote_Detail Select(int line_No_Incoming, string discardedGoodNote_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_scsDiscardedGoodNote_Detail tbl_scsDiscardedGoodNote_Detailins = new tbl_scsDiscardedGoodNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@discardedGoodNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@discardedGoodNote_ID"].Value = discardedGoodNote_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsDiscardedGoodNote_Detailins = Maketbl_scsDiscardedGoodNote_Detail(dataReader);
				} else {
					tbl_scsDiscardedGoodNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsDiscardedGoodNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDiscardedGoodNote_Detail table.
		/// </summary>
		public static List<tbl_scsDiscardedGoodNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsDiscardedGoodNote_Detail> tbl_scsDiscardedGoodNote_DetailList = new List<tbl_scsDiscardedGoodNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDiscardedGoodNote_Detail tbl_scsDiscardedGoodNote_Detail = Maketbl_scsDiscardedGoodNote_Detail(dataReader);
					tbl_scsDiscardedGoodNote_DetailList.Add(tbl_scsDiscardedGoodNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDiscardedGoodNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDiscardedGoodNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDiscardedGoodNote_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_scsDiscardedGoodNote_Detail> tbl_scsDiscardedGoodNote_DetailList = new List<tbl_scsDiscardedGoodNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDiscardedGoodNote_Detail tbl_scsDiscardedGoodNote_Detail = Maketbl_scsDiscardedGoodNote_Detail(dataReader);
					tbl_scsDiscardedGoodNote_DetailList.Add(tbl_scsDiscardedGoodNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDiscardedGoodNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDiscardedGoodNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDiscardedGoodNote_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsDiscardedGoodNote_Detail> tbl_scsDiscardedGoodNote_DetailList = new List<tbl_scsDiscardedGoodNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDiscardedGoodNote_Detail tbl_scsDiscardedGoodNote_Detail = Maketbl_scsDiscardedGoodNote_Detail(dataReader);
					tbl_scsDiscardedGoodNote_DetailList.Add(tbl_scsDiscardedGoodNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDiscardedGoodNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDiscardedGoodNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDiscardedGoodNote_Detail> SelectAllByDiscardedGoodNote_ID(string discardedGoodNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailSelectAllByDiscardedGoodNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@discardedGoodNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@discardedGoodNote_ID"].Value = discardedGoodNote_ID;
				List<tbl_scsDiscardedGoodNote_Detail> tbl_scsDiscardedGoodNote_DetailList = new List<tbl_scsDiscardedGoodNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDiscardedGoodNote_Detail tbl_scsDiscardedGoodNote_Detail = Maketbl_scsDiscardedGoodNote_Detail(dataReader);
					tbl_scsDiscardedGoodNote_DetailList.Add(tbl_scsDiscardedGoodNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDiscardedGoodNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDiscardedGoodNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsDiscardedGoodNote_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDiscardedGoodNote_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_scsDiscardedGoodNote_Detail> tbl_scsDiscardedGoodNote_DetailList = new List<tbl_scsDiscardedGoodNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDiscardedGoodNote_Detail tbl_scsDiscardedGoodNote_Detail = Maketbl_scsDiscardedGoodNote_Detail(dataReader);
					tbl_scsDiscardedGoodNote_DetailList.Add(tbl_scsDiscardedGoodNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsDiscardedGoodNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsDiscardedGoodNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsDiscardedGoodNote_Detail Maketbl_scsDiscardedGoodNote_Detail(SqlDataReader dataReader) {
			tbl_scsDiscardedGoodNote_Detail tbl_scsDiscardedGoodNote_Detail = new tbl_scsDiscardedGoodNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsDiscardedGoodNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsDiscardedGoodNote_Detail.DiscardedGoodNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsDiscardedGoodNote_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsDiscardedGoodNote_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsDiscardedGoodNote_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsDiscardedGoodNote_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsDiscardedGoodNote_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsDiscardedGoodNote_Detail.DamagedQty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsDiscardedGoodNote_Detail.DamagedWeight = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsDiscardedGoodNote_Detail.DiscardingWeight = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsDiscardedGoodNote_Detail.DiscardingQty = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsDiscardedGoodNote_Detail.SalvageValue = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsDiscardedGoodNote_Detail.Remark = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsDiscardedGoodNote_Detail.Cost_FIFO = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsDiscardedGoodNote_Detail.WeightedAvgCost = dataReader.GetDecimal(14);
			}

			return tbl_scsDiscardedGoodNote_Detail;
		}
		/// <summary>
		/// This makes tbl_scsDiscardedGoodNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsDiscardedGoodNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsDiscardedGoodNote_Detail  tbl_scsDiscardedGoodNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_discardedGoodNote_ID = new DataColumn("discardedGoodNote_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_damagedQty = new DataColumn("damagedQty" , typeof(decimal));
			DataColumn col_damagedWeight = new DataColumn("damagedWeight" , typeof(decimal));
			DataColumn col_discardingWeight = new DataColumn("discardingWeight" , typeof(decimal));
			DataColumn col_discardingQty = new DataColumn("discardingQty" , typeof(decimal));
			DataColumn col_salvageValue = new DataColumn("salvageValue" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_cost_FIFO = new DataColumn("cost_FIFO" , typeof(decimal));
			DataColumn col_weightedAvgCost = new DataColumn("weightedAvgCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_discardedGoodNote_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_damagedQty,col_damagedWeight,col_discardingWeight,col_discardingQty,col_salvageValue,col_remark,col_cost_FIFO,col_weightedAvgCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsDiscardedGoodNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsDiscardedGoodNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsDiscardedGoodNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["discardedGoodNote_ID"] = user.discardedGoodNote_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["damagedQty"] = user.damagedQty;
			drow["damagedWeight"] = user.damagedWeight;
			drow["discardingWeight"] = user.discardingWeight;
			drow["discardingQty"] = user.discardingQty;
			drow["salvageValue"] = user.salvageValue;
			drow["remark"] = user.remark;
			drow["cost_FIFO"] = user.cost_FIFO;
			drow["weightedAvgCost"] = user.weightedAvgCost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
