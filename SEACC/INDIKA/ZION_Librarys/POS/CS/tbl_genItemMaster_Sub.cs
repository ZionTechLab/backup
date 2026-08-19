using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_Sub {
		#region Fields
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSerialNo;
		private string itemName;
		private string remark;
		private DateTime dataIssued;
		private DateTime dateExpired;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Sub class.
		/// </summary>
		public tbl_genItemMaster_Sub() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Sub class.
		/// </summary>
		public tbl_genItemMaster_Sub(string item_ID, string itemSubCategory_ID, string itemSerialNo, string itemName, string remark, DateTime dataIssued, DateTime dateExpired) {
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemName = itemName;
			this.remark = remark;
			this.dataIssued = dataIssued;
			this.dateExpired = dateExpired;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory_ID value.
		/// </summary>
		public string ItemSubCategory_ID {
			get { return itemSubCategory_ID; }
			set { itemSubCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the DataIssued value.
		/// </summary>
		public DateTime DataIssued {
			get { return dataIssued; }
			set { dataIssued = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateExpired value.
		/// </summary>
		public DateTime DateExpired {
			get { return dateExpired; }
			set { dateExpired = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_Sub table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SubInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dataIssued", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateExpired", SqlDbType.DateTime,8);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dataIssued"].Value = dataIssued;
			scom.Parameters["@dateExpired"].Value = dateExpired;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_Sub table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SubUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dataIssued", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateExpired", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dataIssued"].Value = dataIssued;
			scom.Parameters["@dateExpired"].Value = dateExpired;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_Sub table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SubDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Sub table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SubDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Sub table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SubDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_Sub table.
		/// </summary>
		public static tbl_genItemMaster_Sub Select(string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSerialNo_Incoming){

			tbl_genItemMaster_Sub tbl_genItemMaster_Subins = new tbl_genItemMaster_Sub();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SubSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_Subins = Maketbl_genItemMaster_Sub(dataReader);
				} else {
					tbl_genItemMaster_Subins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_Subins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Sub table.
		/// </summary>
		public static List<tbl_genItemMaster_Sub> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SubSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_Sub> tbl_genItemMaster_SubList = new List<tbl_genItemMaster_Sub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Sub tbl_genItemMaster_Sub = Maketbl_genItemMaster_Sub(dataReader);
					tbl_genItemMaster_SubList.Add(tbl_genItemMaster_Sub);
				}
			}
			scon.Close();
			return tbl_genItemMaster_SubList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Sub table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Sub> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SubSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_genItemMaster_Sub> tbl_genItemMaster_SubList = new List<tbl_genItemMaster_Sub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Sub tbl_genItemMaster_Sub = Maketbl_genItemMaster_Sub(dataReader);
					tbl_genItemMaster_SubList.Add(tbl_genItemMaster_Sub);
				}
			}
			scon.Close();
			return tbl_genItemMaster_SubList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Sub table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Sub> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SubSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_Sub> tbl_genItemMaster_SubList = new List<tbl_genItemMaster_Sub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Sub tbl_genItemMaster_Sub = Maketbl_genItemMaster_Sub(dataReader);
					tbl_genItemMaster_SubList.Add(tbl_genItemMaster_Sub);
				}
			}
			scon.Close();
			return tbl_genItemMaster_SubList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_Sub class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_Sub Maketbl_genItemMaster_Sub(SqlDataReader dataReader) {
			tbl_genItemMaster_Sub tbl_genItemMaster_Sub = new tbl_genItemMaster_Sub();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_Sub.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_Sub.ItemSubCategory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_Sub.ItemSerialNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_Sub.ItemName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_Sub.Remark = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_Sub.DataIssued = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster_Sub.DateExpired = dataReader.GetDateTime(6);
			}

			return tbl_genItemMaster_Sub;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_Sub datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Sub object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_Sub  tbl_genItemMaster_Sub   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_dataIssued = new DataColumn("dataIssued" , typeof(DateTime));
			DataColumn col_dateExpired = new DataColumn("dateExpired" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_itemSubCategory_ID,col_itemSerialNo,col_itemName,col_remark,col_dataIssued,col_dateExpired,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_Sub datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Sub object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_Sub user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemName"] = user.itemName;
			drow["remark"] = user.remark;
			drow["dataIssued"] = user.dataIssued;
			drow["dateExpired"] = user.dateExpired;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
