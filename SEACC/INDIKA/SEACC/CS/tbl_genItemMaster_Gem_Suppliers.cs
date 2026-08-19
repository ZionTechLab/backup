using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_Gem_Suppliers {
		#region Fields
		private string supplier_ID;
		private string item_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Gem_Suppliers class.
		/// </summary>
		public tbl_genItemMaster_Gem_Suppliers() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Gem_Suppliers class.
		/// </summary>
		public tbl_genItemMaster_Gem_Suppliers(string supplier_ID, string item_ID, bool isActive) {
			this.supplier_ID = supplier_ID;
			this.item_ID = item_ID;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_Gem_Suppliers table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_SuppliersInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_Gem_Suppliers table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_SuppliersUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_Gem_Suppliers table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_SuppliersDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Gem_Suppliers table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_SuppliersDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Gem_Suppliers table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_SuppliersDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_Gem_Suppliers table.
		/// </summary>
		public static tbl_genItemMaster_Gem_Suppliers Select(string supplier_ID_Incoming, string item_ID_Incoming){

			tbl_genItemMaster_Gem_Suppliers tbl_genItemMaster_Gem_Suppliersins = new tbl_genItemMaster_Gem_Suppliers();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_SuppliersSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_Gem_Suppliersins = Maketbl_genItemMaster_Gem_Suppliers(dataReader);
				} else {
					tbl_genItemMaster_Gem_Suppliersins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_Gem_Suppliersins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Gem_Suppliers table.
		/// </summary>
		public static List<tbl_genItemMaster_Gem_Suppliers> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_SuppliersSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_Gem_Suppliers> tbl_genItemMaster_Gem_SuppliersList = new List<tbl_genItemMaster_Gem_Suppliers>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Gem_Suppliers tbl_genItemMaster_Gem_Suppliers = Maketbl_genItemMaster_Gem_Suppliers(dataReader);
					tbl_genItemMaster_Gem_SuppliersList.Add(tbl_genItemMaster_Gem_Suppliers);
				}
			}
			scon.Close();
			return tbl_genItemMaster_Gem_SuppliersList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Gem_Suppliers table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Gem_Suppliers> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_SuppliersSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_genItemMaster_Gem_Suppliers> tbl_genItemMaster_Gem_SuppliersList = new List<tbl_genItemMaster_Gem_Suppliers>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Gem_Suppliers tbl_genItemMaster_Gem_Suppliers = Maketbl_genItemMaster_Gem_Suppliers(dataReader);
					tbl_genItemMaster_Gem_SuppliersList.Add(tbl_genItemMaster_Gem_Suppliers);
				}
			}
			scon.Close();
			return tbl_genItemMaster_Gem_SuppliersList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Gem_Suppliers table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Gem_Suppliers> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Gem_SuppliersSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_Gem_Suppliers> tbl_genItemMaster_Gem_SuppliersList = new List<tbl_genItemMaster_Gem_Suppliers>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Gem_Suppliers tbl_genItemMaster_Gem_Suppliers = Maketbl_genItemMaster_Gem_Suppliers(dataReader);
					tbl_genItemMaster_Gem_SuppliersList.Add(tbl_genItemMaster_Gem_Suppliers);
				}
			}
			scon.Close();
			return tbl_genItemMaster_Gem_SuppliersList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_Gem_Suppliers class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_Gem_Suppliers Maketbl_genItemMaster_Gem_Suppliers(SqlDataReader dataReader) {
			tbl_genItemMaster_Gem_Suppliers tbl_genItemMaster_Gem_Suppliers = new tbl_genItemMaster_Gem_Suppliers();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_Gem_Suppliers.Supplier_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_Gem_Suppliers.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_Gem_Suppliers.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_genItemMaster_Gem_Suppliers;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_Gem_Suppliers datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Gem_Suppliers object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_Gem_Suppliers  tbl_genItemMaster_Gem_Suppliers   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_supplier_ID,col_item_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_Gem_Suppliers datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Gem_Suppliers object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_Gem_Suppliers user) {
		DataRow drow = dt.NewRow();
		
			drow["supplier_ID"] = user.supplier_ID;
			drow["item_ID"] = user.item_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
