using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemCategory_Sub_Specification {
		#region Fields
		private string itemCategorySub_ID;
		private string itemSepcification_ID;
		private string specificationValue;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemCategory_Sub_Specification class.
		/// </summary>
		public tbl_zItemCategory_Sub_Specification() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemCategory_Sub_Specification class.
		/// </summary>
		public tbl_zItemCategory_Sub_Specification(string itemCategorySub_ID, string itemSepcification_ID, string specificationValue) {
			this.itemCategorySub_ID = itemCategorySub_ID;
			this.itemSepcification_ID = itemSepcification_ID;
			this.specificationValue = specificationValue;
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
		/// Gets or sets the ItemSepcification_ID value.
		/// </summary>
		public string ItemSepcification_ID {
			get { return itemSepcification_ID; }
			set { itemSepcification_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SpecificationValue value.
		/// </summary>
		public string SpecificationValue {
			get { return specificationValue; }
			set { specificationValue = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemCategory_Sub_Specification table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_Sub_SpecificationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@specificationValue", SqlDbType.VarChar,50);
 
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
			scom.Parameters["@itemSepcification_ID"].Value = itemSepcification_ID;
			scom.Parameters["@specificationValue"].Value = specificationValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemCategory_Sub_Specification table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_Sub_SpecificationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@specificationValue", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
			scom.Parameters["@itemSepcification_ID"].Value = itemSepcification_ID;
			scom.Parameters["@specificationValue"].Value = specificationValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemCategory_Sub_Specification table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_Sub_SpecificationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
 
			scom.Parameters["@itemSepcification_ID"].Value = itemSepcification_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemCategory_Sub_Specification table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemCategorySub_ID(string itemCategorySub_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_Sub_SpecificationDeleteAllByItemCategorySub_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemCategory_Sub_Specification table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSepcification_ID(string itemSepcification_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_Sub_SpecificationDeleteAllByItemSepcification_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSepcification_ID"].Value = itemSepcification_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemCategory_Sub_Specification table.
		/// </summary>
		public static tbl_zItemCategory_Sub_Specification Select(string itemCategorySub_ID_Incoming, string itemSepcification_ID_Incoming){

			tbl_zItemCategory_Sub_Specification tbl_zItemCategory_Sub_Specificationins = new tbl_zItemCategory_Sub_Specification();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_Sub_SpecificationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID_Incoming;
			scom.Parameters["@itemSepcification_ID"].Value = itemSepcification_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemCategory_Sub_Specificationins = Maketbl_zItemCategory_Sub_Specification(dataReader);
				} else {
					tbl_zItemCategory_Sub_Specificationins = null;
				}
			}
			scon.Close();
			return tbl_zItemCategory_Sub_Specificationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemCategory_Sub_Specification table.
		/// </summary>
		public static List<tbl_zItemCategory_Sub_Specification> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_Sub_SpecificationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemCategory_Sub_Specification> tbl_zItemCategory_Sub_SpecificationList = new List<tbl_zItemCategory_Sub_Specification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemCategory_Sub_Specification tbl_zItemCategory_Sub_Specification = Maketbl_zItemCategory_Sub_Specification(dataReader);
					tbl_zItemCategory_Sub_SpecificationList.Add(tbl_zItemCategory_Sub_Specification);
				}
			}
			scon.Close();
			return tbl_zItemCategory_Sub_SpecificationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemCategory_Sub_Specification table by a foreign key.
		/// </summary>
		public static List<tbl_zItemCategory_Sub_Specification> SelectAllByItemCategorySub_ID(string itemCategorySub_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_Sub_SpecificationSelectAllByItemCategorySub_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
				List<tbl_zItemCategory_Sub_Specification> tbl_zItemCategory_Sub_SpecificationList = new List<tbl_zItemCategory_Sub_Specification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemCategory_Sub_Specification tbl_zItemCategory_Sub_Specification = Maketbl_zItemCategory_Sub_Specification(dataReader);
					tbl_zItemCategory_Sub_SpecificationList.Add(tbl_zItemCategory_Sub_Specification);
				}
			}
			scon.Close();
			return tbl_zItemCategory_Sub_SpecificationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemCategory_Sub_Specification table by a foreign key.
		/// </summary>
		public static List<tbl_zItemCategory_Sub_Specification> SelectAllByItemSepcification_ID(string itemSepcification_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemCategory_Sub_SpecificationSelectAllByItemSepcification_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSepcification_ID"].Value = itemSepcification_ID;
				List<tbl_zItemCategory_Sub_Specification> tbl_zItemCategory_Sub_SpecificationList = new List<tbl_zItemCategory_Sub_Specification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemCategory_Sub_Specification tbl_zItemCategory_Sub_Specification = Maketbl_zItemCategory_Sub_Specification(dataReader);
					tbl_zItemCategory_Sub_SpecificationList.Add(tbl_zItemCategory_Sub_Specification);
				}
			}
			scon.Close();
			return tbl_zItemCategory_Sub_SpecificationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemCategory_Sub_Specification class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemCategory_Sub_Specification Maketbl_zItemCategory_Sub_Specification(SqlDataReader dataReader) {
			tbl_zItemCategory_Sub_Specification tbl_zItemCategory_Sub_Specification = new tbl_zItemCategory_Sub_Specification();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemCategory_Sub_Specification.ItemCategorySub_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemCategory_Sub_Specification.ItemSepcification_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zItemCategory_Sub_Specification.SpecificationValue = dataReader.GetString(2);
			}

			return tbl_zItemCategory_Sub_Specification;
		}
		/// <summary>
		/// This makes tbl_zItemCategory_Sub_Specification datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemCategory_Sub_Specification object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemCategory_Sub_Specification  tbl_zItemCategory_Sub_Specification   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemCategorySub_ID = new DataColumn("itemCategorySub_ID" , typeof(string));
			DataColumn col_itemSepcification_ID = new DataColumn("itemSepcification_ID" , typeof(string));
			DataColumn col_specificationValue = new DataColumn("specificationValue" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_itemCategorySub_ID,col_itemSepcification_ID,col_specificationValue,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemCategory_Sub_Specification datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemCategory_Sub_Specification object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemCategory_Sub_Specification user) {
		DataRow drow = dt.NewRow();
		
			drow["itemCategorySub_ID"] = user.itemCategorySub_ID;
			drow["itemSepcification_ID"] = user.itemSepcification_ID;
			drow["specificationValue"] = user.specificationValue;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
