using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemSerialNo_InforMetal {
		#region Fields
		private string itemSerialNo;
		private string mettleID;
		private string item_ID;
		private decimal costPrice;
		private decimal sellingPrice;
		private decimal weight;
		private bool isGrams;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSerialNo_InforMetal class.
		/// </summary>
		public tbl_zItemSerialNo_InforMetal() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSerialNo_InforMetal class.
		/// </summary>
		public tbl_zItemSerialNo_InforMetal(string itemSerialNo, string mettleID, string item_ID, decimal costPrice, decimal sellingPrice, decimal weight, bool isGrams) {
			this.itemSerialNo = itemSerialNo;
			this.mettleID = mettleID;
			this.item_ID = item_ID;
			this.costPrice = costPrice;
			this.sellingPrice = sellingPrice;
			this.weight = weight;
			this.isGrams = isGrams;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the MettleID value.
		/// </summary>
		public string MettleID {
			get { return mettleID; }
			set { mettleID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
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
		/// Saves a record to the tbl_zItemSerialNo_InforMetal table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNo_InforMetalInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isGrams", SqlDbType.Bit,1);
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@mettleID"].Value = mettleID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@isGrams"].Value = isGrams;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemSerialNo_InforMetal table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNo_InforMetalUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isGrams", SqlDbType.Bit,1);
 
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@mettleID"].Value = mettleID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@isGrams"].Value = isGrams;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemSerialNo_InforMetal table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNo_InforMetalDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@mettleID"].Value = mettleID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSerialNo_InforMetal table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSerialNo(string itemSerialNo) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNo_InforMetalDeleteAllByItemSerialNo", scon);
			scom.CommandType = CommandType.StoredProcedure;			
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemSerialNo_InforMetal table.
		/// </summary>
		public static tbl_zItemSerialNo_InforMetal Select(string itemSerialNo_Incoming, string mettleID_Incoming){

			tbl_zItemSerialNo_InforMetal tbl_zItemSerialNo_InforMetalins = new tbl_zItemSerialNo_InforMetal();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNo_InforMetalSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@mettleID"].Value = mettleID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemSerialNo_InforMetalins = Maketbl_zItemSerialNo_InforMetal(dataReader);
				} else {
					tbl_zItemSerialNo_InforMetalins = null;
				}
			}
			scon.Close();
			return tbl_zItemSerialNo_InforMetalins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSerialNo_InforMetal table.
		/// </summary>
		public static List<tbl_zItemSerialNo_InforMetal> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNo_InforMetalSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemSerialNo_InforMetal> tbl_zItemSerialNo_InforMetalList = new List<tbl_zItemSerialNo_InforMetal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSerialNo_InforMetal tbl_zItemSerialNo_InforMetal = Maketbl_zItemSerialNo_InforMetal(dataReader);
					tbl_zItemSerialNo_InforMetalList.Add(tbl_zItemSerialNo_InforMetal);
				}
			}
			scon.Close();
			return tbl_zItemSerialNo_InforMetalList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSerialNo_InforMetal table by a foreign key.
		/// </summary>
		public static List<tbl_zItemSerialNo_InforMetal> SelectAllByItemSerialNo(string itemSerialNo) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNo_InforMetalSelectAllByItemSerialNo", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
				List<tbl_zItemSerialNo_InforMetal> tbl_zItemSerialNo_InforMetalList = new List<tbl_zItemSerialNo_InforMetal>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSerialNo_InforMetal tbl_zItemSerialNo_InforMetal = Maketbl_zItemSerialNo_InforMetal(dataReader);
					tbl_zItemSerialNo_InforMetalList.Add(tbl_zItemSerialNo_InforMetal);
				}
			}
			scon.Close();
			return tbl_zItemSerialNo_InforMetalList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemSerialNo_InforMetal class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemSerialNo_InforMetal Maketbl_zItemSerialNo_InforMetal(SqlDataReader dataReader) {
			tbl_zItemSerialNo_InforMetal tbl_zItemSerialNo_InforMetal = new tbl_zItemSerialNo_InforMetal();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemSerialNo_InforMetal.ItemSerialNo = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemSerialNo_InforMetal.MettleID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zItemSerialNo_InforMetal.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zItemSerialNo_InforMetal.CostPrice = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zItemSerialNo_InforMetal.SellingPrice = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zItemSerialNo_InforMetal.Weight = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zItemSerialNo_InforMetal.IsGrams = dataReader.GetBoolean(6);
			}

			return tbl_zItemSerialNo_InforMetal;
		}
		/// <summary>
		/// This makes tbl_zItemSerialNo_InforMetal datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemSerialNo_InforMetal object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemSerialNo_InforMetal  tbl_zItemSerialNo_InforMetal   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_mettleID = new DataColumn("mettleID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_costPrice = new DataColumn("costPrice" , typeof(decimal));
			DataColumn col_sellingPrice = new DataColumn("sellingPrice" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_isGrams = new DataColumn("isGrams" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_itemSerialNo,col_mettleID,col_item_ID,col_costPrice,col_sellingPrice,col_weight,col_isGrams,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemSerialNo_InforMetal datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemSerialNo_InforMetal object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemSerialNo_InforMetal user) {
		DataRow drow = dt.NewRow();
		
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["mettleID"] = user.mettleID;
			drow["item_ID"] = user.item_ID;
			drow["costPrice"] = user.costPrice;
			drow["sellingPrice"] = user.sellingPrice;
			drow["weight"] = user.weight;
			drow["isGrams"] = user.isGrams;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
