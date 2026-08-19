using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCustomerCategory {
		#region Fields
		private string customerCategory_ID;
		private string categoryName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCustomerCategory class.
		/// </summary>
		public tbl_zCustomerCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCustomerCategory class.
		/// </summary>
		public tbl_zCustomerCategory(string customerCategory_ID, string categoryName) {
			this.customerCategory_ID = customerCategory_ID;
			this.categoryName = categoryName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CustomerCategory_ID value.
		/// </summary>
		public string CustomerCategory_ID {
			get { return customerCategory_ID; }
			set { customerCategory_ID = value; }
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
		/// Saves a record to the tbl_zCustomerCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
 
			scom.Parameters["@customerCategory_ID"].Value = customerCategory_ID;
			scom.Parameters["@categoryName"].Value = categoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCustomerCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@customerCategory_ID"].Value = customerCategory_ID;
			scom.Parameters["@categoryName"].Value = categoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCustomerCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customerCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@customerCategory_ID"].Value = customerCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCustomerCategory table.
		/// </summary>
		public static tbl_zCustomerCategory Select(string customerCategory_ID_Incoming){

			tbl_zCustomerCategory tbl_zCustomerCategoryins = new tbl_zCustomerCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@customerCategory_ID"].Value = customerCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCustomerCategoryins = Maketbl_zCustomerCategory(dataReader);
				} else {
					tbl_zCustomerCategoryins = null;
				}
			}
			scon.Close();
			return tbl_zCustomerCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCustomerCategory table.
		/// </summary>
		public static List<tbl_zCustomerCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCustomerCategory> tbl_zCustomerCategoryList = new List<tbl_zCustomerCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCustomerCategory tbl_zCustomerCategory = Maketbl_zCustomerCategory(dataReader);
					tbl_zCustomerCategoryList.Add(tbl_zCustomerCategory);
				}
			}
			scon.Close();
			return tbl_zCustomerCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCustomerCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCustomerCategory Maketbl_zCustomerCategory(SqlDataReader dataReader) {
			tbl_zCustomerCategory tbl_zCustomerCategory = new tbl_zCustomerCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCustomerCategory.CustomerCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCustomerCategory.CategoryName = dataReader.GetString(1);
			}

			return tbl_zCustomerCategory;
		}
		/// <summary>
		/// This fills tbl_zCustomerCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCustomerCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCustomerCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["customerCategory_ID"] = user.customerCategory_ID;
			drow["categoryName"] = user.categoryName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
