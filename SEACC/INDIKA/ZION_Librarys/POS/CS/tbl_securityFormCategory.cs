using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityFormCategory {
		#region Fields
		private string formCategory_ID;
		private int sortOrder;
		private string categoryName;
		private byte[] image;
		private string displayName;
		private bool isEnable;
		private bool isVisible;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityFormCategory class.
		/// </summary>
		public tbl_securityFormCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityFormCategory class.
		/// </summary>
		public tbl_securityFormCategory(string formCategory_ID, int sortOrder, string categoryName, byte[] image, string displayName, bool isEnable, bool isVisible) {
			this.formCategory_ID = formCategory_ID;
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
		/// Gets or sets the FormCategory_ID value.
		/// </summary>
		public string FormCategory_ID {
			get { return formCategory_ID; }
			set { formCategory_ID = value; }
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
		/// Saves a record to the tbl_securityFormCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@formCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVisible", SqlDbType.Bit,1);
 
			scom.Parameters["@formCategory_ID"].Value = formCategory_ID;
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
		/// Updates a record in the tbl_securityFormCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@formCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVisible", SqlDbType.Bit,1);
 
 
			scom.Parameters["@formCategory_ID"].Value = formCategory_ID;
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
		/// Deletes a record from the tbl_securityFormCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@formCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@formCategory_ID"].Value = formCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityFormCategory table.
		/// </summary>
		public static tbl_securityFormCategory Select(string formCategory_ID_Incoming){

			tbl_securityFormCategory tbl_securityFormCategoryins = new tbl_securityFormCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@formCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@formCategory_ID"].Value = formCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityFormCategoryins = Maketbl_securityFormCategory(dataReader);
				} else {
					tbl_securityFormCategoryins = null;
				}
			}
			scon.Close();
			return tbl_securityFormCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityFormCategory table.
		/// </summary>
		public static List<tbl_securityFormCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityFormCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityFormCategory> tbl_securityFormCategoryList = new List<tbl_securityFormCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityFormCategory tbl_securityFormCategory = Maketbl_securityFormCategory(dataReader);
					tbl_securityFormCategoryList.Add(tbl_securityFormCategory);
				}
			}
			scon.Close();
			return tbl_securityFormCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityFormCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityFormCategory Maketbl_securityFormCategory(SqlDataReader dataReader) {
			tbl_securityFormCategory tbl_securityFormCategory = new tbl_securityFormCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityFormCategory.FormCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityFormCategory.SortOrder = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityFormCategory.CategoryName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
                tbl_securityFormCategory.Image = (byte[])dataReader[3];
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityFormCategory.DisplayName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityFormCategory.IsEnable = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityFormCategory.IsVisible = dataReader.GetBoolean(6);
			}

			return tbl_securityFormCategory;
		}
		/// <summary>
		/// This makes tbl_securityFormCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityFormCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityFormCategory  tbl_securityFormCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_formCategory_ID = new DataColumn("formCategory_ID" , typeof(string));
			DataColumn col_sortOrder = new DataColumn("sortOrder" , typeof(int));
			DataColumn col_categoryName = new DataColumn("categoryName" , typeof(string));
			DataColumn col_image = new DataColumn("image" , typeof(byte[]));
			DataColumn col_displayName = new DataColumn("displayName" , typeof(string));
			DataColumn col_isEnable = new DataColumn("isEnable" , typeof(bool));
			DataColumn col_isVisible = new DataColumn("isVisible" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_formCategory_ID,col_sortOrder,col_categoryName,col_image,col_displayName,col_isEnable,col_isVisible,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityFormCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityFormCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityFormCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["formCategory_ID"] = user.formCategory_ID;
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
