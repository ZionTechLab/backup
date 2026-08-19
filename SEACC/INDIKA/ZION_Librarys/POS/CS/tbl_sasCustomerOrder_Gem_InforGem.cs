using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasCustomerOrder_Gem_InforGem {
		#region Fields
		private string customerOrder_ID;
		private string item_ID;
		private string gemID;
		private decimal costPrice;
		private decimal sellingPrice;
		private decimal qty;
		private decimal weight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasCustomerOrder_Gem_InforGem class.
		/// </summary>
		public tbl_sasCustomerOrder_Gem_InforGem() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasCustomerOrder_Gem_InforGem class.
		/// </summary>
		public tbl_sasCustomerOrder_Gem_InforGem(string customerOrder_ID, string item_ID, string gemID, decimal costPrice, decimal sellingPrice, decimal qty, decimal weight) {
			this.customerOrder_ID = customerOrder_ID;
			this.item_ID = item_ID;
			this.gemID = gemID;
			this.costPrice = costPrice;
			this.sellingPrice = sellingPrice;
			this.qty = qty;
			this.weight = weight;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GemID value.
		/// </summary>
		public string GemID {
			get { return gemID; }
			set { gemID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostPrice value.
		/// </summary>
		public decimal CostPrice {
			get { return costPrice; }
			set { costPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the SellingPrice value.
		/// </summary>
		public decimal SellingPrice {
			get { return sellingPrice; }
			set { sellingPrice = value; }
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
		/// Saves a record to the tbl_sasCustomerOrder_Gem_InforGem table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_Gem_InforGemInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gemID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
 
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@gemID"].Value = gemID;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasCustomerOrder_Gem_InforGem table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_Gem_InforGemUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gemID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@gemID"].Value = gemID;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasCustomerOrder_Gem_InforGem table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_Gem_InforGemDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gemID", SqlDbType.VarChar,10);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@gemID"].Value = gemID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Gem_InforGem table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID_Item_ID(string customerOrder_ID, string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_Gem_InforGemDeleteAllByCustomerOrder_ID_Item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;			
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasCustomerOrder_Gem_InforGem table.
		/// </summary>
		public static tbl_sasCustomerOrder_Gem_InforGem Select(string customerOrder_ID_Incoming, string item_ID_Incoming, string gemID_Incoming){

			tbl_sasCustomerOrder_Gem_InforGem tbl_sasCustomerOrder_Gem_InforGemins = new tbl_sasCustomerOrder_Gem_InforGem();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_Gem_InforGemSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gemID", SqlDbType.VarChar,10);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@gemID"].Value = gemID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasCustomerOrder_Gem_InforGemins = Maketbl_sasCustomerOrder_Gem_InforGem(dataReader);
				} else {
					tbl_sasCustomerOrder_Gem_InforGemins = null;
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_Gem_InforGemins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Gem_InforGem table.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Gem_InforGem> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_Gem_InforGemSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasCustomerOrder_Gem_InforGem> tbl_sasCustomerOrder_Gem_InforGemList = new List<tbl_sasCustomerOrder_Gem_InforGem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Gem_InforGem tbl_sasCustomerOrder_Gem_InforGem = Maketbl_sasCustomerOrder_Gem_InforGem(dataReader);
					tbl_sasCustomerOrder_Gem_InforGemList.Add(tbl_sasCustomerOrder_Gem_InforGem);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_Gem_InforGemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Gem_InforGem table by a foreign key.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Gem_InforGem> SelectAllByCustomerOrder_ID_Item_ID(string customerOrder_ID, string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_Gem_InforGemSelectAllByCustomerOrder_ID_Item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_sasCustomerOrder_Gem_InforGem> tbl_sasCustomerOrder_Gem_InforGemList = new List<tbl_sasCustomerOrder_Gem_InforGem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Gem_InforGem tbl_sasCustomerOrder_Gem_InforGem = Maketbl_sasCustomerOrder_Gem_InforGem(dataReader);
					tbl_sasCustomerOrder_Gem_InforGemList.Add(tbl_sasCustomerOrder_Gem_InforGem);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_Gem_InforGemList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasCustomerOrder_Gem_InforGem class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasCustomerOrder_Gem_InforGem Maketbl_sasCustomerOrder_Gem_InforGem(SqlDataReader dataReader) {
			tbl_sasCustomerOrder_Gem_InforGem tbl_sasCustomerOrder_Gem_InforGem = new tbl_sasCustomerOrder_Gem_InforGem();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasCustomerOrder_Gem_InforGem.CustomerOrder_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasCustomerOrder_Gem_InforGem.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasCustomerOrder_Gem_InforGem.GemID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasCustomerOrder_Gem_InforGem.CostPrice = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasCustomerOrder_Gem_InforGem.SellingPrice = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasCustomerOrder_Gem_InforGem.Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasCustomerOrder_Gem_InforGem.Weight = dataReader.GetDecimal(6);
			}

			return tbl_sasCustomerOrder_Gem_InforGem;
		}
		/// <summary>
		/// This makes tbl_sasCustomerOrder_Gem_InforGem datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasCustomerOrder_Gem_InforGem object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasCustomerOrder_Gem_InforGem  tbl_sasCustomerOrder_Gem_InforGem   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_gemID = new DataColumn("gemID" , typeof(string));
			DataColumn col_costPrice = new DataColumn("costPrice" , typeof(decimal));
			DataColumn col_sellingPrice = new DataColumn("sellingPrice" , typeof(decimal));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_customerOrder_ID,col_item_ID,col_gemID,col_costPrice,col_sellingPrice,col_qty,col_weight,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasCustomerOrder_Gem_InforGem datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasCustomerOrder_Gem_InforGem object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasCustomerOrder_Gem_InforGem user) {
		DataRow drow = dt.NewRow();
		
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["item_ID"] = user.item_ID;
			drow["gemID"] = user.gemID;
			drow["costPrice"] = user.costPrice;
			drow["sellingPrice"] = user.sellingPrice;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
