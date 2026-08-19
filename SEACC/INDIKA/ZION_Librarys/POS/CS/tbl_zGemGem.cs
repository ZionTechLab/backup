using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zGemGem {
		#region Fields
		private string gemID;
		private string gemName;
		private string remarks;
		private decimal costPrice;
		private decimal sellingPrice;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zGemGem class.
		/// </summary>
		public tbl_zGemGem() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zGemGem class.
		/// </summary>
		public tbl_zGemGem(string gemID, string gemName, string remarks, decimal costPrice, decimal sellingPrice) {
			this.gemID = gemID;
			this.gemName = gemName;
			this.remarks = remarks;
			this.costPrice = costPrice;
			this.sellingPrice = sellingPrice;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the GemID value.
		/// </summary>
		public string GemID {
			get { return gemID; }
			set { gemID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GemName value.
		/// </summary>
		public string GemName {
			get { return gemName; }
			set { gemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zGemGem table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemGemInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gemID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gemName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
 
			scom.Parameters["@gemID"].Value = gemID;
			scom.Parameters["@gemName"].Value = gemName;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zGemGem table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemGemUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gemID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gemName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@gemID"].Value = gemID;
			scom.Parameters["@gemName"].Value = gemName;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zGemGem table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemGemDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@gemID", SqlDbType.VarChar,10);
			scom.Parameters["@gemID"].Value = gemID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zGemGem table.
		/// </summary>
		public static tbl_zGemGem Select(string gemID_Incoming){

			tbl_zGemGem tbl_zGemGemins = new tbl_zGemGem();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemGemSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gemID", SqlDbType.VarChar,10);
			scom.Parameters["@gemID"].Value = gemID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zGemGemins = Maketbl_zGemGem(dataReader);
				} else {
					tbl_zGemGemins = null;
				}
			}
			scon.Close();
			return tbl_zGemGemins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zGemGem table.
		/// </summary>
		public static List<tbl_zGemGem> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zGemGemSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zGemGem> tbl_zGemGemList = new List<tbl_zGemGem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zGemGem tbl_zGemGem = Maketbl_zGemGem(dataReader);
					tbl_zGemGemList.Add(tbl_zGemGem);
				}
			}
			scon.Close();
			return tbl_zGemGemList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zGemGem class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zGemGem Maketbl_zGemGem(SqlDataReader dataReader) {
			tbl_zGemGem tbl_zGemGem = new tbl_zGemGem();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zGemGem.GemID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zGemGem.GemName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zGemGem.Remarks = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zGemGem.CostPrice = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zGemGem.SellingPrice = dataReader.GetDecimal(4);
			}

			return tbl_zGemGem;
		}
		/// <summary>
		/// This makes tbl_zGemGem datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zGemGem object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zGemGem  tbl_zGemGem   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_gemID = new DataColumn("gemID" , typeof(string));
			DataColumn col_gemName = new DataColumn("gemName" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_costPrice = new DataColumn("costPrice" , typeof(decimal));
			DataColumn col_sellingPrice = new DataColumn("sellingPrice" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_gemID,col_gemName,col_remarks,col_costPrice,col_sellingPrice,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zGemGem datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zGemGem object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zGemGem user) {
		DataRow drow = dt.NewRow();
		
			drow["gemID"] = user.gemID;
			drow["gemName"] = user.gemName;
			drow["remarks"] = user.remarks;
			drow["costPrice"] = user.costPrice;
			drow["sellingPrice"] = user.sellingPrice;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
