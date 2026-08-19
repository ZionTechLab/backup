using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zGemMettle {
		#region Fields
		private string mettleID;
		private string mettleName;
		private string remarks;
		private string cartage;
		private decimal costPrice;
		private decimal sellingPrice;
		private bool isGram;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zGemMettle class.
		/// </summary>
		public tbl_zGemMettle() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zGemMettle class.
		/// </summary>
		public tbl_zGemMettle(string mettleID, string mettleName, string remarks, string cartage, decimal costPrice, decimal sellingPrice, bool isGram) {
			this.mettleID = mettleID;
			this.mettleName = mettleName;
			this.remarks = remarks;
			this.cartage = cartage;
			this.costPrice = costPrice;
			this.sellingPrice = sellingPrice;
			this.isGram = isGram;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MettleID value.
		/// </summary>
		public string MettleID {
			get { return mettleID; }
			set { mettleID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MettleName value.
		/// </summary>
		public string MettleName {
			get { return mettleName; }
			set { mettleName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cartage value.
		/// </summary>
		public string Cartage {
			get { return cartage; }
			set { cartage = value; }
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
		/// Gets or sets the IsGram value.
		/// </summary>
		public bool IsGram {
			get { return isGram; }
			set { isGram = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zGemMettle table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemMettleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@mettleName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@cartage", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isGram", SqlDbType.Bit,1);
 
			scom.Parameters["@mettleID"].Value = mettleID;
			scom.Parameters["@mettleName"].Value = mettleName;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@cartage"].Value = cartage;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@isGram"].Value = isGram;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zGemMettle table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemMettleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@mettleName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@cartage", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isGram", SqlDbType.Bit,1);
 
 
			scom.Parameters["@mettleID"].Value = mettleID;
			scom.Parameters["@mettleName"].Value = mettleName;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@cartage"].Value = cartage;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@isGram"].Value = isGram;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zGemMettle table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemMettleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters["@mettleID"].Value = mettleID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zGemMettle table.
		/// </summary>
		public static tbl_zGemMettle Select(string mettleID_Incoming){

			tbl_zGemMettle tbl_zGemMettleins = new tbl_zGemMettle();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemMettleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mettleID", SqlDbType.VarChar,10);
			scom.Parameters["@mettleID"].Value = mettleID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zGemMettleins = Maketbl_zGemMettle(dataReader);
				} else {
					tbl_zGemMettleins = null;
				}
			}
			scon.Close();
			return tbl_zGemMettleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zGemMettle table.
		/// </summary>
		public static List<tbl_zGemMettle> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemMettleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zGemMettle> tbl_zGemMettleList = new List<tbl_zGemMettle>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zGemMettle tbl_zGemMettle = Maketbl_zGemMettle(dataReader);
					tbl_zGemMettleList.Add(tbl_zGemMettle);
				}
			}
			scon.Close();
			return tbl_zGemMettleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zGemMettle class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zGemMettle Maketbl_zGemMettle(SqlDataReader dataReader) {
			tbl_zGemMettle tbl_zGemMettle = new tbl_zGemMettle();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zGemMettle.MettleID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zGemMettle.MettleName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zGemMettle.Remarks = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zGemMettle.Cartage = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zGemMettle.CostPrice = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zGemMettle.SellingPrice = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zGemMettle.IsGram = dataReader.GetBoolean(6);
			}

			return tbl_zGemMettle;
		}
		/// <summary>
		/// This makes tbl_zGemMettle datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zGemMettle object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zGemMettle  tbl_zGemMettle   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_mettleID = new DataColumn("mettleID" , typeof(string));
			DataColumn col_mettleName = new DataColumn("mettleName" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_cartage = new DataColumn("cartage" , typeof(string));
			DataColumn col_costPrice = new DataColumn("costPrice" , typeof(decimal));
			DataColumn col_sellingPrice = new DataColumn("sellingPrice" , typeof(decimal));
			DataColumn col_isGram = new DataColumn("isGram" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_mettleID,col_mettleName,col_remarks,col_cartage,col_costPrice,col_sellingPrice,col_isGram,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zGemMettle datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zGemMettle object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zGemMettle user) {
		DataRow drow = dt.NewRow();
		
			drow["mettleID"] = user.mettleID;
			drow["mettleName"] = user.mettleName;
			drow["remarks"] = user.remarks;
			drow["cartage"] = user.cartage;
			drow["costPrice"] = user.costPrice;
			drow["sellingPrice"] = user.sellingPrice;
			drow["isGram"] = user.isGram;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
