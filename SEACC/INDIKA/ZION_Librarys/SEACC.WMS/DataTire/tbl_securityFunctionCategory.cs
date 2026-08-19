using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityFunctionCategory {
		#region Fields
		private string functionCategory_ID;
		private int sortOrder;
		private string categoryName;
		private byte[] image;
		private string displayName;
		private bool isEnable;
		private bool isVisible;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionCategory class.
		/// </summary>
		public tbl_securityFunctionCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityFunctionCategory class.
		/// </summary>
		public tbl_securityFunctionCategory(string functionCategory_ID, int sortOrder, string categoryName, byte[] image, string displayName, bool isEnable, bool isVisible) {
			this.functionCategory_ID = functionCategory_ID;
			this.sortOrder = sortOrder;
			this.categoryName = categoryName;
			this.image = image;
			this.displayName = displayName;
			this.isEnable = isEnable;
			this.isVisible = isVisible;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FunctionCategory_ID value.
		/// </summary>
		public string FunctionCategory_ID {
			get { return functionCategory_ID; }
			set { functionCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SortOrder value.
		/// </summary>
		public int SortOrder {
			get { return sortOrder; }
			set { sortOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategoryName value.
		/// </summary>
		public string CategoryName {
			get { return categoryName; }
			set { categoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Image value.
		/// </summary>
		public byte[] Image {
			get { return image; }
			set { image = value; }
		}
		
		/// <summary>
		/// Gets or sets the DisplayName value.
		/// </summary>
		public string DisplayName {
			get { return displayName; }
			set { displayName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEnable value.
		/// </summary>
		public bool IsEnable {
			get { return isEnable; }
			set { isEnable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsVisible value.
		/// </summary>
		public bool IsVisible {
			get { return isVisible; }
			set { isVisible = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityFunctionCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@functionCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image,2147483647);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVisible", SqlDbType.Bit,1);
 
			scom.Parameters["@functionCategory_ID"].Value = functionCategory_ID;
			scom.Parameters["@sortOrder"].Value = sortOrder;
			scom.Parameters["@categoryName"].Value = categoryName;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@isVisible"].Value = isVisible;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityFunctionCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@functionCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image,2147483647);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVisible", SqlDbType.Bit,1);
 
 
			scom.Parameters["@functionCategory_ID"].Value = functionCategory_ID;
			scom.Parameters["@sortOrder"].Value = sortOrder;
			scom.Parameters["@categoryName"].Value = categoryName;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@isEnable"].Value = isEnable;
			scom.Parameters["@isVisible"].Value = isVisible;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityFunctionCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@functionCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@functionCategory_ID"].Value = functionCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityFunctionCategory table.
		/// </summary>
		public static tbl_securityFunctionCategory Select(string functionCategory_ID_Incoming){

			tbl_securityFunctionCategory tbl_securityFunctionCategoryins = new tbl_securityFunctionCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@functionCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@functionCategory_ID"].Value = functionCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityFunctionCategoryins = Maketbl_securityFunctionCategory(dataReader);
				} else {
					tbl_securityFunctionCategoryins = null;
				}
			}
			scon.Close();
			return tbl_securityFunctionCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFunctionCategory table.
		/// </summary>
		public static List<tbl_securityFunctionCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFunctionCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityFunctionCategory> tbl_securityFunctionCategoryList = new List<tbl_securityFunctionCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFunctionCategory tbl_securityFunctionCategory = Maketbl_securityFunctionCategory(dataReader);
					tbl_securityFunctionCategoryList.Add(tbl_securityFunctionCategory);
				}
			}
			scon.Close();
			return tbl_securityFunctionCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityFunctionCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityFunctionCategory Maketbl_securityFunctionCategory(SqlDataReader dataReader) {
			tbl_securityFunctionCategory tbl_securityFunctionCategory = new tbl_securityFunctionCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityFunctionCategory.FunctionCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityFunctionCategory.SortOrder = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityFunctionCategory.CategoryName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityFunctionCategory.Image = (byte[])dataReader[3];
            }
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityFunctionCategory.DisplayName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityFunctionCategory.IsEnable = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityFunctionCategory.IsVisible = dataReader.GetBoolean(6);
			}

			return tbl_securityFunctionCategory;
		}
		/// <summary>
		/// This makes tbl_securityFunctionCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityFunctionCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityFunctionCategory  tbl_securityFunctionCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_functionCategory_ID = new DataColumn("functionCategory_ID" , typeof(string));
			DataColumn col_sortOrder = new DataColumn("sortOrder" , typeof(int));
			DataColumn col_categoryName = new DataColumn("categoryName" , typeof(string));
			DataColumn col_image = new DataColumn("image" , typeof(byte));
			DataColumn col_displayName = new DataColumn("displayName" , typeof(string));
			DataColumn col_isEnable = new DataColumn("isEnable" , typeof(bool));
			DataColumn col_isVisible = new DataColumn("isVisible" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_functionCategory_ID,col_sortOrder,col_categoryName,col_image,col_displayName,col_isEnable,col_isVisible,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityFunctionCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityFunctionCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityFunctionCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["functionCategory_ID"] = user.functionCategory_ID;
			drow["sortOrder"] = user.sortOrder;
			drow["categoryName"] = user.categoryName;
			drow["image"] = user.image;
			drow["displayName"] = user.displayName;
			drow["isEnable"] = user.isEnable;
			drow["isVisible"] = user.isVisible;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
