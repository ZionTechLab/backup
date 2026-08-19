using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zUomCategory {
		#region Fields
		private string uomCategory_ID;
		private string categoryName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zUomCategory class.
		/// </summary>
		public tbl_zUomCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zUomCategory class.
		/// </summary>
		public tbl_zUomCategory(string uomCategory_ID, string categoryName) {
			this.uomCategory_ID = uomCategory_ID;
			this.categoryName = categoryName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the UomCategory_ID value.
		/// </summary>
		public string UomCategory_ID {
			get { return uomCategory_ID; }
			set { uomCategory_ID = value; }
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
		/// Saves a record to the tbl_zUomCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@uomCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
 
			scom.Parameters["@uomCategory_ID"].Value = uomCategory_ID;
			scom.Parameters["@categoryName"].Value = categoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zUomCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@uomCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@uomCategory_ID"].Value = uomCategory_ID;
			scom.Parameters["@categoryName"].Value = categoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zUomCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@uomCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uomCategory_ID"].Value = uomCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zUomCategory table.
		/// </summary>
		public static tbl_zUomCategory Select(string uomCategory_ID_Incoming){

			tbl_zUomCategory tbl_zUomCategoryins = new tbl_zUomCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uomCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uomCategory_ID"].Value = uomCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zUomCategoryins = Maketbl_zUomCategory(dataReader);
				} else {
					tbl_zUomCategoryins = null;
				}
			}
			scon.Close();
			return tbl_zUomCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zUomCategory table.
		/// </summary>
		public static List<tbl_zUomCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zUomCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zUomCategory> tbl_zUomCategoryList = new List<tbl_zUomCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zUomCategory tbl_zUomCategory = Maketbl_zUomCategory(dataReader);
					tbl_zUomCategoryList.Add(tbl_zUomCategory);
				}
			}
			scon.Close();
			return tbl_zUomCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zUomCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zUomCategory Maketbl_zUomCategory(SqlDataReader dataReader) {
			tbl_zUomCategory tbl_zUomCategory = new tbl_zUomCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zUomCategory.UomCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zUomCategory.CategoryName = dataReader.GetString(1);
			}

			return tbl_zUomCategory;
		}
		/// <summary>
		/// This makes tbl_zUomCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zUomCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zUomCategory  tbl_zUomCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_uomCategory_ID = new DataColumn("uomCategory_ID" , typeof(string));
			DataColumn col_categoryName = new DataColumn("categoryName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_uomCategory_ID,col_categoryName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zUomCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zUomCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zUomCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["uomCategory_ID"] = user.uomCategory_ID;
			drow["categoryName"] = user.categoryName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
