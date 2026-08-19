using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_PricesCustomerWise {
		#region Fields
		private string item_ID;
		private string customer_ID;
		private decimal sellingPrice;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_PricesCustomerWise class.
		/// </summary>
		public tbl_genItemMaster_PricesCustomerWise() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_PricesCustomerWise class.
		/// </summary>
		public tbl_genItemMaster_PricesCustomerWise(string item_ID, string customer_ID, decimal sellingPrice) {
			this.item_ID = item_ID;
			this.customer_ID = customer_ID;
			this.sellingPrice = sellingPrice;
		}
		#endregion
		
		#region Properties
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
		/// Gets or sets the SellingPrice value.
		/// </summary>
		public decimal SellingPrice {
			get { return sellingPrice; }
			set { sellingPrice = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_PricesCustomerWise table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesCustomerWiseInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_PricesCustomerWise table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesCustomerWiseUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_PricesCustomerWise table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesCustomerWiseDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_PricesCustomerWise table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesCustomerWiseDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_PricesCustomerWise table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesCustomerWiseDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_PricesCustomerWise table.
		/// </summary>
		public static tbl_genItemMaster_PricesCustomerWise Select(string item_ID_Incoming, string customer_ID_Incoming){

			tbl_genItemMaster_PricesCustomerWise tbl_genItemMaster_PricesCustomerWiseins = new tbl_genItemMaster_PricesCustomerWise();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesCustomerWiseSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_PricesCustomerWiseins = Maketbl_genItemMaster_PricesCustomerWise(dataReader);
				} else {
					tbl_genItemMaster_PricesCustomerWiseins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_PricesCustomerWiseins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_PricesCustomerWise table.
		/// </summary>
		public static List<tbl_genItemMaster_PricesCustomerWise> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesCustomerWiseSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_PricesCustomerWise> tbl_genItemMaster_PricesCustomerWiseList = new List<tbl_genItemMaster_PricesCustomerWise>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_PricesCustomerWise tbl_genItemMaster_PricesCustomerWise = Maketbl_genItemMaster_PricesCustomerWise(dataReader);
					tbl_genItemMaster_PricesCustomerWiseList.Add(tbl_genItemMaster_PricesCustomerWise);
				}
			}
			scon.Close();
			return tbl_genItemMaster_PricesCustomerWiseList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_PricesCustomerWise table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_PricesCustomerWise> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesCustomerWiseSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_genItemMaster_PricesCustomerWise> tbl_genItemMaster_PricesCustomerWiseList = new List<tbl_genItemMaster_PricesCustomerWise>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_PricesCustomerWise tbl_genItemMaster_PricesCustomerWise = Maketbl_genItemMaster_PricesCustomerWise(dataReader);
					tbl_genItemMaster_PricesCustomerWiseList.Add(tbl_genItemMaster_PricesCustomerWise);
				}
			}
			scon.Close();
			return tbl_genItemMaster_PricesCustomerWiseList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_PricesCustomerWise table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_PricesCustomerWise> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesCustomerWiseSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_PricesCustomerWise> tbl_genItemMaster_PricesCustomerWiseList = new List<tbl_genItemMaster_PricesCustomerWise>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_PricesCustomerWise tbl_genItemMaster_PricesCustomerWise = Maketbl_genItemMaster_PricesCustomerWise(dataReader);
					tbl_genItemMaster_PricesCustomerWiseList.Add(tbl_genItemMaster_PricesCustomerWise);
				}
			}
			scon.Close();
			return tbl_genItemMaster_PricesCustomerWiseList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_PricesCustomerWise class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_PricesCustomerWise Maketbl_genItemMaster_PricesCustomerWise(SqlDataReader dataReader) {
			tbl_genItemMaster_PricesCustomerWise tbl_genItemMaster_PricesCustomerWise = new tbl_genItemMaster_PricesCustomerWise();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_PricesCustomerWise.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_PricesCustomerWise.Customer_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_PricesCustomerWise.SellingPrice = dataReader.GetDecimal(2);
			}

			return tbl_genItemMaster_PricesCustomerWise;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_PricesCustomerWise datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_PricesCustomerWise object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_PricesCustomerWise  tbl_genItemMaster_PricesCustomerWise   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_sellingPrice = new DataColumn("sellingPrice" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_customer_ID,col_sellingPrice,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_PricesCustomerWise datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_PricesCustomerWise object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_PricesCustomerWise user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["sellingPrice"] = user.sellingPrice;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
