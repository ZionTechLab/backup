using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_PricesSalesRepWise {
		#region Fields
		private string item_ID;
		private string selesRep_ID;
		private decimal sellingPrice;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_PricesSalesRepWise class.
		/// </summary>
		public tbl_genItemMaster_PricesSalesRepWise() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_PricesSalesRepWise class.
		/// </summary>
		public tbl_genItemMaster_PricesSalesRepWise(string item_ID, string selesRep_ID, decimal sellingPrice) {
			this.item_ID = item_ID;
			this.selesRep_ID = selesRep_ID;
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
		/// Gets or sets the SelesRep_ID value.
		/// </summary>
		public string SelesRep_ID {
			get { return selesRep_ID; }
			set { selesRep_ID = value; }
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
		/// Saves a record to the tbl_genItemMaster_PricesSalesRepWise table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesSalesRepWiseInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_PricesSalesRepWise table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesSalesRepWiseUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_PricesSalesRepWise table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesSalesRepWiseDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_PricesSalesRepWise table by a foreign key.
		/// </summary>
		public static void DeleteAllBySelesRep_ID(string selesRep_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesSalesRepWiseDeleteAllBySelesRep_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_PricesSalesRepWise table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesSalesRepWiseDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_PricesSalesRepWise table.
		/// </summary>
		public static tbl_genItemMaster_PricesSalesRepWise Select(string item_ID_Incoming, string selesRep_ID_Incoming){

			tbl_genItemMaster_PricesSalesRepWise tbl_genItemMaster_PricesSalesRepWiseins = new tbl_genItemMaster_PricesSalesRepWise();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesSalesRepWiseSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_PricesSalesRepWiseins = Maketbl_genItemMaster_PricesSalesRepWise(dataReader);
				} else {
					tbl_genItemMaster_PricesSalesRepWiseins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_PricesSalesRepWiseins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_PricesSalesRepWise table.
		/// </summary>
		public static List<tbl_genItemMaster_PricesSalesRepWise> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesSalesRepWiseSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_PricesSalesRepWise> tbl_genItemMaster_PricesSalesRepWiseList = new List<tbl_genItemMaster_PricesSalesRepWise>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_PricesSalesRepWise tbl_genItemMaster_PricesSalesRepWise = Maketbl_genItemMaster_PricesSalesRepWise(dataReader);
					tbl_genItemMaster_PricesSalesRepWiseList.Add(tbl_genItemMaster_PricesSalesRepWise);
				}
			}
			scon.Close();
			return tbl_genItemMaster_PricesSalesRepWiseList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_PricesSalesRepWise table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_PricesSalesRepWise> SelectAllBySelesRep_ID(string selesRep_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesSalesRepWiseSelectAllBySelesRep_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
				List<tbl_genItemMaster_PricesSalesRepWise> tbl_genItemMaster_PricesSalesRepWiseList = new List<tbl_genItemMaster_PricesSalesRepWise>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_PricesSalesRepWise tbl_genItemMaster_PricesSalesRepWise = Maketbl_genItemMaster_PricesSalesRepWise(dataReader);
					tbl_genItemMaster_PricesSalesRepWiseList.Add(tbl_genItemMaster_PricesSalesRepWise);
				}
			}
			scon.Close();
			return tbl_genItemMaster_PricesSalesRepWiseList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_PricesSalesRepWise table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_PricesSalesRepWise> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricesSalesRepWiseSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_PricesSalesRepWise> tbl_genItemMaster_PricesSalesRepWiseList = new List<tbl_genItemMaster_PricesSalesRepWise>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_PricesSalesRepWise tbl_genItemMaster_PricesSalesRepWise = Maketbl_genItemMaster_PricesSalesRepWise(dataReader);
					tbl_genItemMaster_PricesSalesRepWiseList.Add(tbl_genItemMaster_PricesSalesRepWise);
				}
			}
			scon.Close();
			return tbl_genItemMaster_PricesSalesRepWiseList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_PricesSalesRepWise class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_PricesSalesRepWise Maketbl_genItemMaster_PricesSalesRepWise(SqlDataReader dataReader) {
			tbl_genItemMaster_PricesSalesRepWise tbl_genItemMaster_PricesSalesRepWise = new tbl_genItemMaster_PricesSalesRepWise();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_PricesSalesRepWise.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_PricesSalesRepWise.SelesRep_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_PricesSalesRepWise.SellingPrice = dataReader.GetDecimal(2);
			}

			return tbl_genItemMaster_PricesSalesRepWise;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_PricesSalesRepWise datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_PricesSalesRepWise object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_PricesSalesRepWise  tbl_genItemMaster_PricesSalesRepWise   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_selesRep_ID = new DataColumn("selesRep_ID" , typeof(string));
			DataColumn col_sellingPrice = new DataColumn("sellingPrice" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_selesRep_ID,col_sellingPrice,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_PricesSalesRepWise datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_PricesSalesRepWise object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_PricesSalesRepWise user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["selesRep_ID"] = user.selesRep_ID;
			drow["sellingPrice"] = user.sellingPrice;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
