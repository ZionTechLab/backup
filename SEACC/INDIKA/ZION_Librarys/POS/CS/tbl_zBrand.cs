using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zBrand {
		#region Fields
		private string brand_ID;
		private string brandName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zBrand class.
		/// </summary>
		public tbl_zBrand() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zBrand class.
		/// </summary>
		public tbl_zBrand(string brand_ID, string brandName) {
			this.brand_ID = brand_ID;
			this.brandName = brandName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Brand_ID value.
		/// </summary>
		public string Brand_ID {
			get { return brand_ID; }
			set { brand_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BrandName value.
		/// </summary>
		public string BrandName {
			get { return brandName; }
			set { brandName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zBrand table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBrandInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brandName", SqlDbType.VarChar,50);
 
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@brandName"].Value = brandName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zBrand table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBrandUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brandName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@brandName"].Value = brandName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zBrand table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBrandDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters["@brand_ID"].Value = brand_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zBrand table.
		/// </summary>
		public static tbl_zBrand Select(string brand_ID_Incoming){

			tbl_zBrand tbl_zBrandins = new tbl_zBrand();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBrandSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters["@brand_ID"].Value = brand_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zBrandins = Maketbl_zBrand(dataReader);
				} else {
					tbl_zBrandins = null;
				}
			}
			scon.Close();
			return tbl_zBrandins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zBrand table.
		/// </summary>
		public static List<tbl_zBrand> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBrandSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zBrand> tbl_zBrandList = new List<tbl_zBrand>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zBrand tbl_zBrand = Maketbl_zBrand(dataReader);
					tbl_zBrandList.Add(tbl_zBrand);
				}
			}
			scon.Close();
			return tbl_zBrandList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zBrand class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zBrand Maketbl_zBrand(SqlDataReader dataReader) {
			tbl_zBrand tbl_zBrand = new tbl_zBrand();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zBrand.Brand_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zBrand.BrandName = dataReader.GetString(1);
			}

			return tbl_zBrand;
		}
		/// <summary>
		/// This fills tbl_zBrand datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zBrand object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zBrand user) {
		DataRow drow = dt.NewRow();
		
			drow["brand_ID"] = user.brand_ID;
			drow["brandName"] = user.brandName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
