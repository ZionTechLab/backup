using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genStore_Stock {
		#region Fields
		private string store_ID;
		private string item_ID;
		private string job_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty;
		private decimal availableQty;
		private decimal weight;
		private decimal availableWeight;
		private decimal meter;
		private decimal availableMeter;
		private decimal wasteageWeight;
		private decimal damageWeight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genStore_Stock class.
		/// </summary>
		public tbl_genStore_Stock() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genStore_Stock class.
		/// </summary>
		public tbl_genStore_Stock(string store_ID, string item_ID, string job_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal availableQty, decimal weight, decimal availableWeight, decimal meter, decimal availableMeter, decimal wasteageWeight, decimal damageWeight) {
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.job_ID = job_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty = qty;
			this.availableQty = availableQty;
			this.weight = weight;
			this.availableWeight = availableWeight;
			this.meter = meter;
			this.availableMeter = availableMeter;
			this.wasteageWeight = wasteageWeight;
			this.damageWeight = damageWeight;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
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
		/// Gets or sets the AvailableQty value.
		/// </summary>
		public decimal AvailableQty {
			get { return availableQty; }
			set { availableQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the AvailableWeight value.
		/// </summary>
		public decimal AvailableWeight {
			get { return availableWeight; }
			set { availableWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Meter value.
		/// </summary>
		public decimal Meter {
			get { return meter; }
			set { meter = value; }
		}
		
		/// <summary>
		/// Gets or sets the AvailableMeter value.
		/// </summary>
		public decimal AvailableMeter {
			get { return availableMeter; }
			set { availableMeter = value; }
		}
		
		/// <summary>
		/// Gets or sets the WasteageWeight value.
		/// </summary>
		public decimal WasteageWeight {
			get { return wasteageWeight; }
			set { wasteageWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the DamageWeight value.
		/// </summary>
		public decimal DamageWeight {
			get { return damageWeight; }
			set { damageWeight = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genStore_Stock table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@availableQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@availableWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@meter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@availableMeter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@wasteageWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@damageWeight", SqlDbType.Decimal,9);
 
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@availableQty"].Value = availableQty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@availableWeight"].Value = availableWeight;
			scom.Parameters["@meter"].Value = meter;
			scom.Parameters["@availableMeter"].Value = availableMeter;
			scom.Parameters["@wasteageWeight"].Value = wasteageWeight;
			scom.Parameters["@damageWeight"].Value = damageWeight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		



		
		/// <summary>
		/// Selects a single record from the tbl_genStore_Stock table.
		/// </summary>
		public static tbl_genStore_Stock Select(string store_ID_Incoming, string item_ID_Incoming, string job_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_genStore_Stock tbl_genStore_Stockins = new tbl_genStore_Stock();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@store_ID"].Value = store_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@job_ID"].Value = job_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genStore_Stockins = Maketbl_genStore_Stock(dataReader);
				} else {
					tbl_genStore_Stockins = null;
				}
			}
			scon.Close();
			return tbl_genStore_Stockins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock table.
		/// </summary>
		public static List<tbl_genStore_Stock> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genStore_Stock> tbl_genStore_StockList = new List<tbl_genStore_Stock>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genStore_Stock tbl_genStore_Stock = Maketbl_genStore_Stock(dataReader);
					tbl_genStore_StockList.Add(tbl_genStore_Stock);
				}
			}
			scon.Close();
			return tbl_genStore_StockList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock table by a foreign key.
		/// </summary>

		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock table by a foreign key.
		/// </summary>

		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock table by a foreign key.
		/// </summary>

		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock table by a foreign key.
		/// </summary>
		public static List<tbl_genStore_Stock> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_genStore_Stock> tbl_genStore_StockList = new List<tbl_genStore_Stock>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genStore_Stock tbl_genStore_Stock = Maketbl_genStore_Stock(dataReader);
					tbl_genStore_StockList.Add(tbl_genStore_Stock);
				}
			}
			scon.Close();
			return tbl_genStore_StockList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock table by a foreign key.
		/// </summary>
		public static List<tbl_genStore_Stock> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genStore_Stock> tbl_genStore_StockList = new List<tbl_genStore_Stock>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genStore_Stock tbl_genStore_Stock = Maketbl_genStore_Stock(dataReader);
					tbl_genStore_StockList.Add(tbl_genStore_Stock);
				}
			}
			scon.Close();
			return tbl_genStore_StockList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock table by a foreign key.
		/// </summary>
		public static List<tbl_genStore_Stock> SelectAllByItem_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockSelectAllByItem_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
				List<tbl_genStore_Stock> tbl_genStore_StockList = new List<tbl_genStore_Stock>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genStore_Stock tbl_genStore_Stock = Maketbl_genStore_Stock(dataReader);
					tbl_genStore_StockList.Add(tbl_genStore_Stock);
				}
			}
			scon.Close();
			return tbl_genStore_StockList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genStore_Stock class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genStore_Stock Maketbl_genStore_Stock(SqlDataReader dataReader) {
			tbl_genStore_Stock tbl_genStore_Stock = new tbl_genStore_Stock();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genStore_Stock.Store_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genStore_Stock.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genStore_Stock.Job_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genStore_Stock.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genStore_Stock.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genStore_Stock.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genStore_Stock.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genStore_Stock.Qty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genStore_Stock.AvailableQty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genStore_Stock.Weight = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genStore_Stock.AvailableWeight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genStore_Stock.Meter = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genStore_Stock.AvailableMeter = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genStore_Stock.WasteageWeight = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genStore_Stock.DamageWeight = dataReader.GetDecimal(14);
			}

			return tbl_genStore_Stock;
		}
		/// <summary>
		/// This makes tbl_genStore_Stock datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genStore_Stock object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genStore_Stock  tbl_genStore_Stock   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_availableQty = new DataColumn("availableQty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_availableWeight = new DataColumn("availableWeight" , typeof(decimal));
			DataColumn col_meter = new DataColumn("meter" , typeof(decimal));
			DataColumn col_availableMeter = new DataColumn("availableMeter" , typeof(decimal));
			DataColumn col_wasteageWeight = new DataColumn("wasteageWeight" , typeof(decimal));
			DataColumn col_damageWeight = new DataColumn("damageWeight" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_store_ID,col_item_ID,col_job_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_availableQty,col_weight,col_availableWeight,col_meter,col_availableMeter,col_wasteageWeight,col_damageWeight,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genStore_Stock datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genStore_Stock object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genStore_Stock user) {
		DataRow drow = dt.NewRow();
		
			drow["store_ID"] = user.store_ID;
			drow["item_ID"] = user.item_ID;
			drow["job_ID"] = user.job_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty"] = user.qty;
			drow["availableQty"] = user.availableQty;
			drow["weight"] = user.weight;
			drow["availableWeight"] = user.availableWeight;
			drow["meter"] = user.meter;
			drow["availableMeter"] = user.availableMeter;
			drow["wasteageWeight"] = user.wasteageWeight;
			drow["damageWeight"] = user.damageWeight;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
