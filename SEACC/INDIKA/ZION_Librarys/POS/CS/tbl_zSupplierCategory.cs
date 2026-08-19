using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zSupplierCategory {
		#region Fields
		private string supplierCategory_ID;
		private string categoryName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zSupplierCategory class.
		/// </summary>
		public tbl_zSupplierCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zSupplierCategory class.
		/// </summary>
		public tbl_zSupplierCategory(string supplierCategory_ID, string categoryName) {
			this.supplierCategory_ID = supplierCategory_ID;
			this.categoryName = categoryName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SupplierCategory_ID value.
		/// </summary>
		public string SupplierCategory_ID {
			get { return supplierCategory_ID; }
			set { supplierCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategoryName value.
		/// </summary>
		public string CategoryName {
			get { return categoryName; }
			set { categoryName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zSupplierCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplierCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
 
			scom.Parameters["@supplierCategory_ID"].Value = supplierCategory_ID;
			scom.Parameters["@categoryName"].Value = categoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zSupplierCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplierCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@supplierCategory_ID"].Value = supplierCategory_ID;
			scom.Parameters["@categoryName"].Value = categoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zSupplierCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@supplierCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierCategory_ID"].Value = supplierCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zSupplierCategory table.
		/// </summary>
		public static tbl_zSupplierCategory Select(string supplierCategory_ID_Incoming){

			tbl_zSupplierCategory tbl_zSupplierCategoryins = new tbl_zSupplierCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplierCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierCategory_ID"].Value = supplierCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zSupplierCategoryins = Maketbl_zSupplierCategory(dataReader);
				} else {
					tbl_zSupplierCategoryins = null;
				}
			}
			scon.Close();
			return tbl_zSupplierCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zSupplierCategory table.
		/// </summary>
		public static List<tbl_zSupplierCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zSupplierCategory> tbl_zSupplierCategoryList = new List<tbl_zSupplierCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zSupplierCategory tbl_zSupplierCategory = Maketbl_zSupplierCategory(dataReader);
					tbl_zSupplierCategoryList.Add(tbl_zSupplierCategory);
				}
			}
			scon.Close();
			return tbl_zSupplierCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zSupplierCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zSupplierCategory Maketbl_zSupplierCategory(SqlDataReader dataReader) {
			tbl_zSupplierCategory tbl_zSupplierCategory = new tbl_zSupplierCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zSupplierCategory.SupplierCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zSupplierCategory.CategoryName = dataReader.GetString(1);
			}

			return tbl_zSupplierCategory;
		}
		/// <summary>
		/// This fills tbl_zSupplierCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zSupplierCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zSupplierCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["supplierCategory_ID"] = user.supplierCategory_ID;
			drow["categoryName"] = user.categoryName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
