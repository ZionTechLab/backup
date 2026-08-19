using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genStore_Stock {
		#region Fields
		private string store_ID;
		private string item_ID;
		private string customer_ID;
		private decimal qty;
		private decimal weight;
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
		public tbl_genStore_Stock(string store_ID, string item_ID, string customer_ID, decimal qty, decimal weight) {
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.customer_ID = customer_ID;
			this.qty = qty;
			this.weight = weight;
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
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
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
		/// Saves a record to the tbl_genStore_Stock table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
 
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genStore_Stock table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genStore_Stock table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genStore_Stock table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genStore_Stock table.
		/// </summary>
		public static tbl_genStore_Stock Select(string store_ID_Incoming, string item_ID_Incoming, string customer_ID_Incoming){

			tbl_genStore_Stock tbl_genStore_Stockins = new tbl_genStore_Stock();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
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
		public static List<tbl_genStore_Stock> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStore_StockSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
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
				tbl_genStore_Stock.Customer_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genStore_Stock.Qty = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genStore_Stock.Weight = dataReader.GetDecimal(4);
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
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_store_ID,col_item_ID,col_customer_ID,col_qty,col_weight,});		return dt;
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
			drow["customer_ID"] = user.customer_ID;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
