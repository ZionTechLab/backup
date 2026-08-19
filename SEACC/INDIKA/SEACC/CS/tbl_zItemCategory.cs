using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemCategory {
		#region Fields
		private string itemCategory_ID;
		private string categoryName;
		private string itemType_ID;
		private string prefrix;
		private string prefrix2;
		private bool isItemSubCategoryEnabled;
		private bool isItemSubCategory2Enabled;
		private bool isItemSerialNoEnabled;
		private bool isItemSerialNo2Enabled;
		private int categoryCounter;
		private int categoryLength;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemCategory class.
		/// </summary>
		public tbl_zItemCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemCategory class.
		/// </summary>
		public tbl_zItemCategory(string itemCategory_ID, string categoryName, string itemType_ID, string prefrix, string prefrix2, bool isItemSubCategoryEnabled, bool isItemSubCategory2Enabled, bool isItemSerialNoEnabled, bool isItemSerialNo2Enabled, int categoryCounter, int categoryLength, string remark) {
			this.itemCategory_ID = itemCategory_ID;
			this.categoryName = categoryName;
			this.itemType_ID = itemType_ID;
			this.prefrix = prefrix;
			this.prefrix2 = prefrix2;
			this.isItemSubCategoryEnabled = isItemSubCategoryEnabled;
			this.isItemSubCategory2Enabled = isItemSubCategory2Enabled;
			this.isItemSerialNoEnabled = isItemSerialNoEnabled;
			this.isItemSerialNo2Enabled = isItemSerialNo2Enabled;
			this.categoryCounter = categoryCounter;
			this.categoryLength = categoryLength;
			this.remark = remark;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemCategory_ID value.
		/// </summary>
		public string ItemCategory_ID {
			get { return itemCategory_ID; }
			set { itemCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategoryName value.
		/// </summary>
		public string CategoryName {
			get { return categoryName; }
			set { categoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemType_ID value.
		/// </summary>
		public string ItemType_ID {
			get { return itemType_ID; }
			set { itemType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefrix value.
		/// </summary>
		public string Prefrix {
			get { return prefrix; }
			set { prefrix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefrix2 value.
		/// </summary>
		public string Prefrix2 {
			get { return prefrix2; }
			set { prefrix2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsItemSubCategoryEnabled value.
		/// </summary>
		public bool IsItemSubCategoryEnabled {
			get { return isItemSubCategoryEnabled; }
			set { isItemSubCategoryEnabled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsItemSubCategory2Enabled value.
		/// </summary>
		public bool IsItemSubCategory2Enabled {
			get { return isItemSubCategory2Enabled; }
			set { isItemSubCategory2Enabled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsItemSerialNoEnabled value.
		/// </summary>
		public bool IsItemSerialNoEnabled {
			get { return isItemSerialNoEnabled; }
			set { isItemSerialNoEnabled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsItemSerialNo2Enabled value.
		/// </summary>
		public bool IsItemSerialNo2Enabled {
			get { return isItemSerialNo2Enabled; }
			set { isItemSerialNo2Enabled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategoryCounter value.
		/// </summary>
		public int CategoryCounter {
			get { return categoryCounter; }
			set { categoryCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategoryLength value.
		/// </summary>
		public int CategoryLength {
			get { return categoryLength; }
			set { categoryLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefrix2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isItemSubCategoryEnabled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isItemSubCategory2Enabled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isItemSerialNoEnabled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isItemSerialNo2Enabled", SqlDbType.Bit,1);
			scom.Parameters.Add("@categoryCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@categoryLength", SqlDbType.Int,4);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@categoryName"].Value = categoryName;
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@prefrix"].Value = prefrix;
			scom.Parameters["@prefrix2"].Value = prefrix2;
			scom.Parameters["@isItemSubCategoryEnabled"].Value = isItemSubCategoryEnabled;
			scom.Parameters["@isItemSubCategory2Enabled"].Value = isItemSubCategory2Enabled;
			scom.Parameters["@isItemSerialNoEnabled"].Value = isItemSerialNoEnabled;
			scom.Parameters["@isItemSerialNo2Enabled"].Value = isItemSerialNo2Enabled;
			scom.Parameters["@categoryCounter"].Value = categoryCounter;
			scom.Parameters["@categoryLength"].Value = categoryLength;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefrix2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isItemSubCategoryEnabled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isItemSubCategory2Enabled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isItemSerialNoEnabled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isItemSerialNo2Enabled", SqlDbType.Bit,1);
			scom.Parameters.Add("@categoryCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@categoryLength", SqlDbType.Int,4);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@categoryName"].Value = categoryName;
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@prefrix"].Value = prefrix;
			scom.Parameters["@prefrix2"].Value = prefrix2;
			scom.Parameters["@isItemSubCategoryEnabled"].Value = isItemSubCategoryEnabled;
			scom.Parameters["@isItemSubCategory2Enabled"].Value = isItemSubCategory2Enabled;
			scom.Parameters["@isItemSerialNoEnabled"].Value = isItemSerialNoEnabled;
			scom.Parameters["@isItemSerialNo2Enabled"].Value = isItemSerialNo2Enabled;
			scom.Parameters["@categoryCounter"].Value = categoryCounter;
			scom.Parameters["@categoryLength"].Value = categoryLength;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemCategory table.
		/// </summary>
		public static tbl_zItemCategory Select(string itemCategory_ID_Incoming){

			tbl_zItemCategory tbl_zItemCategoryins = new tbl_zItemCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemCategoryins = Maketbl_zItemCategory(dataReader);
				} else {
					tbl_zItemCategoryins = null;
				}
			}
			scon.Close();
			return tbl_zItemCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemCategory table.
		/// </summary>
		public static List<tbl_zItemCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemCategory> tbl_zItemCategoryList = new List<tbl_zItemCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemCategory tbl_zItemCategory = Maketbl_zItemCategory(dataReader);
					tbl_zItemCategoryList.Add(tbl_zItemCategory);
				}
			}
			scon.Close();
			return tbl_zItemCategoryList;
		}
        public static List<tbl_zItemCategory> SelectAllByItemType_ID(string itemType_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_zItemCategorySelectAllByItemType_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@itemType_ID"].Value = itemType_ID;
            List<tbl_zItemCategory> tbl_zItemCategoryList = new List<tbl_zItemCategory>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_zItemCategory tbl_zItemCategory = Maketbl_zItemCategory(dataReader);
                    tbl_zItemCategoryList.Add(tbl_zItemCategory);
                }
            }
            scon.Close();
            return tbl_zItemCategoryList;
        }
        /// <summary>
        /// Creates a new instance of the tbl_zItemCategory class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_zItemCategory Maketbl_zItemCategory(SqlDataReader dataReader) {
			tbl_zItemCategory tbl_zItemCategory = new tbl_zItemCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemCategory.ItemCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemCategory.CategoryName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zItemCategory.ItemType_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zItemCategory.Prefrix = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zItemCategory.Prefrix2 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zItemCategory.IsItemSubCategoryEnabled = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zItemCategory.IsItemSubCategory2Enabled = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zItemCategory.IsItemSerialNoEnabled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zItemCategory.IsItemSerialNo2Enabled = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_zItemCategory.CategoryCounter = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_zItemCategory.CategoryLength = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_zItemCategory.Remark = dataReader.GetString(11);
			}

			return tbl_zItemCategory;
		}
		/// <summary>
		/// This makes tbl_zItemCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemCategory  tbl_zItemCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemCategory_ID = new DataColumn("itemCategory_ID" , typeof(string));
			DataColumn col_categoryName = new DataColumn("categoryName" , typeof(string));
			DataColumn col_itemType_ID = new DataColumn("itemType_ID" , typeof(string));
			DataColumn col_prefrix = new DataColumn("prefrix" , typeof(string));
			DataColumn col_prefrix2 = new DataColumn("prefrix2" , typeof(string));
			DataColumn col_isItemSubCategoryEnabled = new DataColumn("isItemSubCategoryEnabled" , typeof(bool));
			DataColumn col_isItemSubCategory2Enabled = new DataColumn("isItemSubCategory2Enabled" , typeof(bool));
			DataColumn col_isItemSerialNoEnabled = new DataColumn("isItemSerialNoEnabled" , typeof(bool));
			DataColumn col_isItemSerialNo2Enabled = new DataColumn("isItemSerialNo2Enabled" , typeof(bool));
			DataColumn col_categoryCounter = new DataColumn("categoryCounter" , typeof(int));
			DataColumn col_categoryLength = new DataColumn("categoryLength" , typeof(int));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_itemCategory_ID,col_categoryName,col_itemType_ID,col_prefrix,col_prefrix2,col_isItemSubCategoryEnabled,col_isItemSubCategory2Enabled,col_isItemSerialNoEnabled,col_isItemSerialNo2Enabled,col_categoryCounter,col_categoryLength,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["itemCategory_ID"] = user.itemCategory_ID;
			drow["categoryName"] = user.categoryName;
			drow["itemType_ID"] = user.itemType_ID;
			drow["prefrix"] = user.prefrix;
			drow["prefrix2"] = user.prefrix2;
			drow["isItemSubCategoryEnabled"] = user.isItemSubCategoryEnabled;
			drow["isItemSubCategory2Enabled"] = user.isItemSubCategory2Enabled;
			drow["isItemSerialNoEnabled"] = user.isItemSerialNoEnabled;
			drow["isItemSerialNo2Enabled"] = user.isItemSerialNo2Enabled;
			drow["categoryCounter"] = user.categoryCounter;
			drow["categoryLength"] = user.categoryLength;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
