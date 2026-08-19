using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsStockAdd_Detail {
		#region Fields
		private string stockAdd_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty;
		private decimal weight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsStockAdd_Detail class.
		/// </summary>
		public tbl_scsStockAdd_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsStockAdd_Detail class.
		/// </summary>
		public tbl_scsStockAdd_Detail(string stockAdd_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal weight) {
			this.stockAdd_ID = stockAdd_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty = qty;
			this.weight = weight;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the StockAdd_ID value.
		/// </summary>
		public string StockAdd_ID {
			get { return stockAdd_ID; }
			set { stockAdd_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsStockAdd_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@stockAdd_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
 
			scom.Parameters["@stockAdd_ID"].Value = stockAdd_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsStockAdd_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@stockAdd_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@stockAdd_ID"].Value = stockAdd_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsStockAdd_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@stockAdd_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@stockAdd_ID"].Value = stockAdd_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdd_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByStockAdd_ID(string stockAdd_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailDeleteAllByStockAdd_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@stockAdd_ID", SqlDbType.VarChar,20);
			scom.Parameters["@stockAdd_ID"].Value = stockAdd_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsStockAdd_Detail table.
		/// </summary>
		public static tbl_scsStockAdd_Detail Select(string stockAdd_ID_Incoming, string item_ID_Incoming){

			tbl_scsStockAdd_Detail tbl_scsStockAdd_Detailins = new tbl_scsStockAdd_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@stockAdd_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@stockAdd_ID"].Value = stockAdd_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsStockAdd_Detailins = Maketbl_scsStockAdd_Detail(dataReader);
				} else {
					tbl_scsStockAdd_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsStockAdd_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdd_Detail table.
		/// </summary>
		public static List<tbl_scsStockAdd_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsStockAdd_Detail> tbl_scsStockAdd_DetailList = new List<tbl_scsStockAdd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdd_Detail tbl_scsStockAdd_Detail = Maketbl_scsStockAdd_Detail(dataReader);
					tbl_scsStockAdd_DetailList.Add(tbl_scsStockAdd_Detail);
				}
			}
			scon.Close();
			return tbl_scsStockAdd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsStockAdd_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsStockAdd_Detail> tbl_scsStockAdd_DetailList = new List<tbl_scsStockAdd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdd_Detail tbl_scsStockAdd_Detail = Maketbl_scsStockAdd_Detail(dataReader);
					tbl_scsStockAdd_DetailList.Add(tbl_scsStockAdd_Detail);
				}
			}
			scon.Close();
			return tbl_scsStockAdd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsStockAdd_Detail> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_scsStockAdd_Detail> tbl_scsStockAdd_DetailList = new List<tbl_scsStockAdd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdd_Detail tbl_scsStockAdd_Detail = Maketbl_scsStockAdd_Detail(dataReader);
					tbl_scsStockAdd_DetailList.Add(tbl_scsStockAdd_Detail);
				}
			}
			scon.Close();
			return tbl_scsStockAdd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsStockAdd_Detail> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_scsStockAdd_Detail> tbl_scsStockAdd_DetailList = new List<tbl_scsStockAdd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdd_Detail tbl_scsStockAdd_Detail = Maketbl_scsStockAdd_Detail(dataReader);
					tbl_scsStockAdd_DetailList.Add(tbl_scsStockAdd_Detail);
				}
			}
			scon.Close();
			return tbl_scsStockAdd_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdd_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsStockAdd_Detail> SelectAllByStockAdd_ID(string stockAdd_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdd_DetailSelectAllByStockAdd_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@stockAdd_ID", SqlDbType.VarChar,20);
			scom.Parameters["@stockAdd_ID"].Value = stockAdd_ID;
				List<tbl_scsStockAdd_Detail> tbl_scsStockAdd_DetailList = new List<tbl_scsStockAdd_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdd_Detail tbl_scsStockAdd_Detail = Maketbl_scsStockAdd_Detail(dataReader);
					tbl_scsStockAdd_DetailList.Add(tbl_scsStockAdd_Detail);
				}
			}
			scon.Close();
			return tbl_scsStockAdd_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsStockAdd_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsStockAdd_Detail Maketbl_scsStockAdd_Detail(SqlDataReader dataReader) {
			tbl_scsStockAdd_Detail tbl_scsStockAdd_Detail = new tbl_scsStockAdd_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsStockAdd_Detail.StockAdd_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsStockAdd_Detail.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsStockAdd_Detail.ItemSubCategory_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsStockAdd_Detail.ItemSubCategory2_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsStockAdd_Detail.ItemSerialNo = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsStockAdd_Detail.ItemSerialNo2 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsStockAdd_Detail.Qty = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsStockAdd_Detail.Weight = dataReader.GetDecimal(7);
			}

			return tbl_scsStockAdd_Detail;
		}
		/// <summary>
		/// This makes tbl_scsStockAdd_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsStockAdd_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsStockAdd_Detail  tbl_scsStockAdd_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_stockAdd_ID = new DataColumn("stockAdd_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_stockAdd_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_weight,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsStockAdd_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsStockAdd_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsStockAdd_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["stockAdd_ID"] = user.stockAdd_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
