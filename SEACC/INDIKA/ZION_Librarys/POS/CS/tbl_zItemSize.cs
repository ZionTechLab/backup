using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemSize {
		#region Fields
		private string itemSize_ID;
		private string itemSizeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSize class.
		/// </summary>
		public tbl_zItemSize() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSize class.
		/// </summary>
		public tbl_zItemSize(string itemSize_ID, string itemSizeName) {
			this.itemSize_ID = itemSize_ID;
			this.itemSizeName = itemSizeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemSize_ID value.
		/// </summary>
		public string ItemSize_ID {
			get { return itemSize_ID; }
			set { itemSize_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSizeName value.
		/// </summary>
		public string ItemSizeName {
			get { return itemSizeName; }
			set { itemSizeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemSize table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSizeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSize_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSizeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@itemSize_ID"].Value = itemSize_ID;
			scom.Parameters["@itemSizeName"].Value = itemSizeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemSize table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSizeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSize_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSizeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@itemSize_ID"].Value = itemSize_ID;
			scom.Parameters["@itemSizeName"].Value = itemSizeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemSize table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSizeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemSize_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSize_ID"].Value = itemSize_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemSize table.
		/// </summary>
		public static tbl_zItemSize Select(string itemSize_ID_Incoming){

			tbl_zItemSize tbl_zItemSizeins = new tbl_zItemSize();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSizeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSize_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSize_ID"].Value = itemSize_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemSizeins = Maketbl_zItemSize(dataReader);
				} else {
					tbl_zItemSizeins = null;
				}
			}
			scon.Close();
			return tbl_zItemSizeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSize table.
		/// </summary>
		public static List<tbl_zItemSize> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSizeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemSize> tbl_zItemSizeList = new List<tbl_zItemSize>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSize tbl_zItemSize = Maketbl_zItemSize(dataReader);
					tbl_zItemSizeList.Add(tbl_zItemSize);
				}
			}
			scon.Close();
			return tbl_zItemSizeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemSize class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemSize Maketbl_zItemSize(SqlDataReader dataReader) {
			tbl_zItemSize tbl_zItemSize = new tbl_zItemSize();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemSize.ItemSize_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemSize.ItemSizeName = dataReader.GetString(1);
			}

			return tbl_zItemSize;
		}
		/// <summary>
		/// This makes tbl_zItemSize datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemSize object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemSize  tbl_zItemSize   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemSize_ID = new DataColumn("itemSize_ID" , typeof(string));
			DataColumn col_itemSizeName = new DataColumn("itemSizeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_itemSize_ID,col_itemSizeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemSize datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemSize object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemSize user) {
		DataRow drow = dt.NewRow();
		
			drow["itemSize_ID"] = user.itemSize_ID;
			drow["itemSizeName"] = user.itemSizeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
