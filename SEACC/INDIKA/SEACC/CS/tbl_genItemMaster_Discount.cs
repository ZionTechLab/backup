using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_Discount {
		#region Fields
		private string item_ID;
		private decimal maxDiscountPct;
		private decimal maxDiscountAmt;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Discount class.
		/// </summary>
		public tbl_genItemMaster_Discount() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Discount class.
		/// </summary>
		public tbl_genItemMaster_Discount(string item_ID, decimal maxDiscountPct, decimal maxDiscountAmt) {
			this.item_ID = item_ID;
			this.maxDiscountPct = maxDiscountPct;
			this.maxDiscountAmt = maxDiscountAmt;
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
		/// Gets or sets the MaxDiscountPct value.
		/// </summary>
		public decimal MaxDiscountPct {
			get { return maxDiscountPct; }
			set { maxDiscountPct = value; }
		}
		
		/// <summary>
		/// Gets or sets the MaxDiscountAmt value.
		/// </summary>
		public decimal MaxDiscountAmt {
			get { return maxDiscountAmt; }
			set { maxDiscountAmt = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_Discount table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_DiscountInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@maxDiscountPct", SqlDbType.Decimal,9);
			scom.Parameters.Add("@maxDiscountAmt", SqlDbType.Decimal,9);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@maxDiscountPct"].Value = maxDiscountPct;
			scom.Parameters["@maxDiscountAmt"].Value = maxDiscountAmt;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_Discount table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_DiscountUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@maxDiscountPct", SqlDbType.Decimal,9);
			scom.Parameters.Add("@maxDiscountAmt", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@maxDiscountPct"].Value = maxDiscountPct;
			scom.Parameters["@maxDiscountAmt"].Value = maxDiscountAmt;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_Discount table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_DiscountDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Discount table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_DiscountDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_Discount table.
		/// </summary>
		public static tbl_genItemMaster_Discount Select(string item_ID_Incoming){

			tbl_genItemMaster_Discount tbl_genItemMaster_Discountins = new tbl_genItemMaster_Discount();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_DiscountSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_Discountins = Maketbl_genItemMaster_Discount(dataReader);
				} else {
					tbl_genItemMaster_Discountins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_Discountins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Discount table.
		/// </summary>
		public static List<tbl_genItemMaster_Discount> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_DiscountSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_Discount> tbl_genItemMaster_DiscountList = new List<tbl_genItemMaster_Discount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Discount tbl_genItemMaster_Discount = Maketbl_genItemMaster_Discount(dataReader);
					tbl_genItemMaster_DiscountList.Add(tbl_genItemMaster_Discount);
				}
			}
			scon.Close();
			return tbl_genItemMaster_DiscountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Discount table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Discount> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_DiscountSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_Discount> tbl_genItemMaster_DiscountList = new List<tbl_genItemMaster_Discount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Discount tbl_genItemMaster_Discount = Maketbl_genItemMaster_Discount(dataReader);
					tbl_genItemMaster_DiscountList.Add(tbl_genItemMaster_Discount);
				}
			}
			scon.Close();
			return tbl_genItemMaster_DiscountList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_Discount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_Discount Maketbl_genItemMaster_Discount(SqlDataReader dataReader) {
			tbl_genItemMaster_Discount tbl_genItemMaster_Discount = new tbl_genItemMaster_Discount();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_Discount.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_Discount.MaxDiscountPct = dataReader.GetDecimal(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_Discount.MaxDiscountAmt = dataReader.GetDecimal(2);
			}

			return tbl_genItemMaster_Discount;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_Discount datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Discount object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_Discount  tbl_genItemMaster_Discount   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_maxDiscountPct = new DataColumn("maxDiscountPct" , typeof(decimal));
			DataColumn col_maxDiscountAmt = new DataColumn("maxDiscountAmt" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_maxDiscountPct,col_maxDiscountAmt,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_Discount datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Discount object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_Discount user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["maxDiscountPct"] = user.maxDiscountPct;
			drow["maxDiscountAmt"] = user.maxDiscountAmt;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
