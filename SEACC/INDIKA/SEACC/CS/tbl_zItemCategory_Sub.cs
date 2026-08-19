using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemCategory_Sub {
		#region Fields
		private string itemCategorySub_ID;
		private string itemCategory_ID;
		private string categorySubName;
		private string prefrix;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemCategory_Sub class.
		/// </summary>
		public tbl_zItemCategory_Sub() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemCategory_Sub class.
		/// </summary>
		public tbl_zItemCategory_Sub(string itemCategorySub_ID, string itemCategory_ID, string categorySubName, string prefrix) {
			this.itemCategorySub_ID = itemCategorySub_ID;
			this.itemCategory_ID = itemCategory_ID;
			this.categorySubName = categorySubName;
			this.prefrix = prefrix;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemCategorySub_ID value.
		/// </summary>
		public string ItemCategorySub_ID {
			get { return itemCategorySub_ID; }
			set { itemCategorySub_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCategory_ID value.
		/// </summary>
		public string ItemCategory_ID {
			get { return itemCategory_ID; }
			set { itemCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategorySubName value.
		/// </summary>
		public string CategorySubName {
			get { return categorySubName; }
			set { categorySubName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefrix value.
		/// </summary>
		public string Prefrix {
			get { return prefrix; }
			set { prefrix = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemCategory_Sub table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_SubInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categorySubName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
 
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@categorySubName"].Value = categorySubName;
			scom.Parameters["@prefrix"].Value = prefrix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemCategory_Sub table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_SubUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categorySubName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@categorySubName"].Value = categorySubName;
			scom.Parameters["@prefrix"].Value = prefrix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemCategory_Sub table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_SubDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemCategory_Sub table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemCategory_ID(string itemCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_SubDeleteAllByItemCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemCategory_Sub table.
		/// </summary>
		public static tbl_zItemCategory_Sub Select(string itemCategorySub_ID_Incoming){

			tbl_zItemCategory_Sub tbl_zItemCategory_Subins = new tbl_zItemCategory_Sub();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_SubSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemCategory_Subins = Maketbl_zItemCategory_Sub(dataReader);
				} else {
					tbl_zItemCategory_Subins = null;
				}
			}
			scon.Close();
			return tbl_zItemCategory_Subins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemCategory_Sub table.
		/// </summary>
		public static List<tbl_zItemCategory_Sub> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_SubSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemCategory_Sub> tbl_zItemCategory_SubList = new List<tbl_zItemCategory_Sub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemCategory_Sub tbl_zItemCategory_Sub = Maketbl_zItemCategory_Sub(dataReader);
					tbl_zItemCategory_SubList.Add(tbl_zItemCategory_Sub);
				}
			}
			scon.Close();
			return tbl_zItemCategory_SubList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemCategory_Sub table by a foreign key.
		/// </summary>
		public static List<tbl_zItemCategory_Sub> SelectAllByItemCategory_ID(string itemCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_SubSelectAllByItemCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
				List<tbl_zItemCategory_Sub> tbl_zItemCategory_SubList = new List<tbl_zItemCategory_Sub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemCategory_Sub tbl_zItemCategory_Sub = Maketbl_zItemCategory_Sub(dataReader);
					tbl_zItemCategory_SubList.Add(tbl_zItemCategory_Sub);
				}
			}
			scon.Close();
			return tbl_zItemCategory_SubList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemCategory_Sub class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemCategory_Sub Maketbl_zItemCategory_Sub(SqlDataReader dataReader) {
			tbl_zItemCategory_Sub tbl_zItemCategory_Sub = new tbl_zItemCategory_Sub();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemCategory_Sub.ItemCategorySub_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemCategory_Sub.ItemCategory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zItemCategory_Sub.CategorySubName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zItemCategory_Sub.Prefrix = dataReader.GetString(3);
			}

			return tbl_zItemCategory_Sub;
		}
		/// <summary>
		/// This makes tbl_zItemCategory_Sub datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemCategory_Sub object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemCategory_Sub  tbl_zItemCategory_Sub   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemCategorySub_ID = new DataColumn("itemCategorySub_ID" , typeof(string));
			DataColumn col_itemCategory_ID = new DataColumn("itemCategory_ID" , typeof(string));
			DataColumn col_categorySubName = new DataColumn("categorySubName" , typeof(string));
			DataColumn col_prefrix = new DataColumn("prefrix" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_itemCategorySub_ID,col_itemCategory_ID,col_categorySubName,col_prefrix,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemCategory_Sub datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemCategory_Sub object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemCategory_Sub user) {
		DataRow drow = dt.NewRow();
		
			drow["itemCategorySub_ID"] = user.itemCategorySub_ID;
			drow["itemCategory_ID"] = user.itemCategory_ID;
			drow["categorySubName"] = user.categorySubName;
			drow["prefrix"] = user.prefrix;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
