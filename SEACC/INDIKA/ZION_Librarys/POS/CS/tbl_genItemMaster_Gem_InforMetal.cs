using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_Gem_InforMetal {
		#region Fields
		private string item_ID;
		private string mettleID;
		private decimal costPrice;
		private decimal sellingPrice;
		private decimal weight;
		private bool isGrams;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Gem_InforMetal class.
		/// </summary>
		public tbl_genItemMaster_Gem_InforMetal() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Gem_InforMetal class.
		/// </summary>
		public tbl_genItemMaster_Gem_InforMetal(string item_ID, string mettleID, decimal costPrice, decimal sellingPrice, decimal weight, bool isGrams) {
			this.item_ID = item_ID;
			this.mettleID = mettleID;
			this.costPrice = costPrice;
			this.sellingPrice = sellingPrice;
			this.weight = weight;
			this.isGrams = isGrams;
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
		/// Gets or sets the MettleID value.
		/// </summary>
		public string MettleID {
			get { return mettleID; }
			set { mettleID = value; }
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
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsGrams value.
		/// </summary>
		public bool IsGrams {
			get { return isGrams; }
			set { isGrams = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_Gem_InforMetal table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_InforMetalInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isGrams", SqlDbType.Bit,1);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@mettleID"].Value = mettleID;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@isGrams"].Value = isGrams;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_Gem_InforMetal table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_InforMetalUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isGrams", SqlDbType.Bit,1);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@mettleID"].Value = mettleID;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@isGrams"].Value = isGrams;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_Gem_InforMetal table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_InforMetalDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@mettleID"].Value = mettleID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Gem_InforMetal table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_InforMetalDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Gem_InforMetal table by a foreign key.
		/// </summary>
		public static void DeleteAllByMettleID(string mettleID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_InforMetalDeleteAllByMettleID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters["@mettleID"].Value = mettleID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_Gem_InforMetal table.
		/// </summary>
		public static tbl_genItemMaster_Gem_InforMetal Select(string item_ID_Incoming, string mettleID_Incoming){

			tbl_genItemMaster_Gem_InforMetal tbl_genItemMaster_Gem_InforMetalins = new tbl_genItemMaster_Gem_InforMetal();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_InforMetalSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@mettleID"].Value = mettleID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_Gem_InforMetalins = Maketbl_genItemMaster_Gem_InforMetal(dataReader);
				} else {
					tbl_genItemMaster_Gem_InforMetalins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_Gem_InforMetalins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Gem_InforMetal table.
		/// </summary>
		public static List<tbl_genItemMaster_Gem_InforMetal> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_InforMetalSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_Gem_InforMetal> tbl_genItemMaster_Gem_InforMetalList = new List<tbl_genItemMaster_Gem_InforMetal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Gem_InforMetal tbl_genItemMaster_Gem_InforMetal = Maketbl_genItemMaster_Gem_InforMetal(dataReader);
					tbl_genItemMaster_Gem_InforMetalList.Add(tbl_genItemMaster_Gem_InforMetal);
				}
			}
			scon.Close();
			return tbl_genItemMaster_Gem_InforMetalList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Gem_InforMetal table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Gem_InforMetal> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_InforMetalSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_Gem_InforMetal> tbl_genItemMaster_Gem_InforMetalList = new List<tbl_genItemMaster_Gem_InforMetal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Gem_InforMetal tbl_genItemMaster_Gem_InforMetal = Maketbl_genItemMaster_Gem_InforMetal(dataReader);
					tbl_genItemMaster_Gem_InforMetalList.Add(tbl_genItemMaster_Gem_InforMetal);
				}
			}
			scon.Close();
			return tbl_genItemMaster_Gem_InforMetalList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Gem_InforMetal table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Gem_InforMetal> SelectAllByMettleID(string mettleID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_InforMetalSelectAllByMettleID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters["@mettleID"].Value = mettleID;
				List<tbl_genItemMaster_Gem_InforMetal> tbl_genItemMaster_Gem_InforMetalList = new List<tbl_genItemMaster_Gem_InforMetal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Gem_InforMetal tbl_genItemMaster_Gem_InforMetal = Maketbl_genItemMaster_Gem_InforMetal(dataReader);
					tbl_genItemMaster_Gem_InforMetalList.Add(tbl_genItemMaster_Gem_InforMetal);
				}
			}
			scon.Close();
			return tbl_genItemMaster_Gem_InforMetalList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_Gem_InforMetal class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_Gem_InforMetal Maketbl_genItemMaster_Gem_InforMetal(SqlDataReader dataReader) {
			tbl_genItemMaster_Gem_InforMetal tbl_genItemMaster_Gem_InforMetal = new tbl_genItemMaster_Gem_InforMetal();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_Gem_InforMetal.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_Gem_InforMetal.MettleID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_Gem_InforMetal.CostPrice = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_Gem_InforMetal.SellingPrice = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_Gem_InforMetal.Weight = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_Gem_InforMetal.IsGrams = dataReader.GetBoolean(5);
			}

			return tbl_genItemMaster_Gem_InforMetal;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_Gem_InforMetal datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Gem_InforMetal object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_Gem_InforMetal  tbl_genItemMaster_Gem_InforMetal   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_mettleID = new DataColumn("mettleID" , typeof(string));
			DataColumn col_costPrice = new DataColumn("costPrice" , typeof(decimal));
			DataColumn col_sellingPrice = new DataColumn("sellingPrice" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_isGrams = new DataColumn("isGrams" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_mettleID,col_costPrice,col_sellingPrice,col_weight,col_isGrams,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_Gem_InforMetal datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Gem_InforMetal object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_Gem_InforMetal user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["mettleID"] = user.mettleID;
			drow["costPrice"] = user.costPrice;
			drow["sellingPrice"] = user.sellingPrice;
			drow["weight"] = user.weight;
			drow["isGrams"] = user.isGrams;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
