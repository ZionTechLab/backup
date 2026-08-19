using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemSubCategory {
		#region Fields
		private string itemSubCategory_ID;
		private string itemSubCategoryName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSubCategory class.
		/// </summary>
		public tbl_zItemSubCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSubCategory class.
		/// </summary>
		public tbl_zItemSubCategory(string itemSubCategory_ID, string itemSubCategoryName) {
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategoryName = itemSubCategoryName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemSubCategory_ID value.
		/// </summary>
		public string ItemSubCategory_ID {
			get { return itemSubCategory_ID; }
			set { itemSubCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategoryName value.
		/// </summary>
		public string ItemSubCategoryName {
			get { return itemSubCategoryName; }
			set { itemSubCategoryName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemSubCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSubCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategoryName", SqlDbType.VarChar,50);
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategoryName"].Value = itemSubCategoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemSubCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSubCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategoryName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategoryName"].Value = itemSubCategoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemSubCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSubCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemSubCategory table.
		/// </summary>
		public static tbl_zItemSubCategory Select(string itemSubCategory_ID_Incoming){

			tbl_zItemSubCategory tbl_zItemSubCategoryins = new tbl_zItemSubCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSubCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemSubCategoryins = Maketbl_zItemSubCategory(dataReader);
				} else {
					tbl_zItemSubCategoryins = null;
				}
			}
			scon.Close();
			return tbl_zItemSubCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSubCategory table.
		/// </summary>
		public static List<tbl_zItemSubCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSubCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemSubCategory> tbl_zItemSubCategoryList = new List<tbl_zItemSubCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSubCategory tbl_zItemSubCategory = Maketbl_zItemSubCategory(dataReader);
					tbl_zItemSubCategoryList.Add(tbl_zItemSubCategory);
				}
			}
			scon.Close();
			return tbl_zItemSubCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemSubCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemSubCategory Maketbl_zItemSubCategory(SqlDataReader dataReader) {
			tbl_zItemSubCategory tbl_zItemSubCategory = new tbl_zItemSubCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemSubCategory.ItemSubCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemSubCategory.ItemSubCategoryName = dataReader.GetString(1);
			}

			return tbl_zItemSubCategory;
		}
		/// <summary>
		/// This makes tbl_zItemSubCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemSubCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemSubCategory  tbl_zItemSubCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategoryName = new DataColumn("itemSubCategoryName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_itemSubCategory_ID,col_itemSubCategoryName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemSubCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemSubCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemSubCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategoryName"] = user.itemSubCategoryName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
