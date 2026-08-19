using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_trcItemTracking_MonthlyBalance_Detail {
		#region Fields
		private int month_ID;
		private string store_ID;
		private string item_ID;
		private string job_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty_Opening;
		private decimal weight_Opening;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_trcItemTracking_MonthlyBalance_Detail class.
		/// </summary>
		public tbl_trcItemTracking_MonthlyBalance_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_trcItemTracking_MonthlyBalance_Detail class.
		/// </summary>
		public tbl_trcItemTracking_MonthlyBalance_Detail(int month_ID, string store_ID, string item_ID, string job_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty_Opening, decimal weight_Opening) {
			this.month_ID = month_ID;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.job_ID = job_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty_Opening = qty_Opening;
			this.weight_Opening = weight_Opening;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Month_ID value.
		/// </summary>
		public int Month_ID {
			get { return month_ID; }
			set { month_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory_ID value.
		/// </summary>
		public string ItemSubCategory_ID {
			get { return itemSubCategory_ID; }
			set { itemSubCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory2_ID value.
		/// </summary>
		public string ItemSubCategory2_ID {
			get { return itemSubCategory2_ID; }
			set { itemSubCategory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo2 value.
		/// </summary>
		public string ItemSerialNo2 {
			get { return itemSerialNo2; }
			set { itemSerialNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Opening value.
		/// </summary>
		public decimal Qty_Opening {
			get { return qty_Opening; }
			set { qty_Opening = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight_Opening value.
		/// </summary>
		public decimal Weight_Opening {
			get { return weight_Opening; }
			set { weight_Opening = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_trcItemTracking_MonthlyBalance_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalance_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty_Opening", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Opening", SqlDbType.Decimal,9);
 
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@Job_ID"].Value = job_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty_Opening"].Value = qty_Opening;
			scom.Parameters["@weight_Opening"].Value = weight_Opening;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_trcItemTracking_MonthlyBalance_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalance_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty_Opening", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Opening", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@Job_ID"].Value = job_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty_Opening"].Value = qty_Opening;
			scom.Parameters["@weight_Opening"].Value = weight_Opening;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_trcItemTracking_MonthlyBalance_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalance_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@month_ID"].Value = month_ID;
 
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@Job_ID"].Value = job_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking_MonthlyBalance_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID_Item_ID_Job_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(string store_ID, string item_ID, string job_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalance_DetailDeleteAllByStore_ID_Item_ID_Job_ID_ItSubCat_ItSubCat2_ItSrl_ItSrl2", scon);
			scom.CommandType = CommandType.StoredProcedure;		
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@Job_ID"].Value = job_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking_MonthlyBalance_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByMonth_ID(int month_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalance_DetailDeleteAllByMonth_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters["@month_ID"].Value = month_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_trcItemTracking_MonthlyBalance_Detail table.
		/// </summary>
		public static tbl_trcItemTracking_MonthlyBalance_Detail Select(int month_ID_Incoming, string store_ID_Incoming, string item_ID_Incoming, string job_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_trcItemTracking_MonthlyBalance_Detail tbl_trcItemTracking_MonthlyBalance_Detailins = new tbl_trcItemTracking_MonthlyBalance_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalance_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@month_ID"].Value = month_ID_Incoming;
			scom.Parameters["@store_ID"].Value = store_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@Job_ID"].Value = job_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_trcItemTracking_MonthlyBalance_Detailins = Maketbl_trcItemTracking_MonthlyBalance_Detail(dataReader);
				} else {
					tbl_trcItemTracking_MonthlyBalance_Detailins = null;
				}
			}
			scon.Close();
			return tbl_trcItemTracking_MonthlyBalance_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking_MonthlyBalance_Detail table.
		/// </summary>
		public static List<tbl_trcItemTracking_MonthlyBalance_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalance_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_trcItemTracking_MonthlyBalance_Detail> tbl_trcItemTracking_MonthlyBalance_DetailList = new List<tbl_trcItemTracking_MonthlyBalance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcItemTracking_MonthlyBalance_Detail tbl_trcItemTracking_MonthlyBalance_Detail = Maketbl_trcItemTracking_MonthlyBalance_Detail(dataReader);
					tbl_trcItemTracking_MonthlyBalance_DetailList.Add(tbl_trcItemTracking_MonthlyBalance_Detail);
				}
			}
			scon.Close();
			return tbl_trcItemTracking_MonthlyBalance_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking_MonthlyBalance_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_trcItemTracking_MonthlyBalance_Detail> SelectAllByStore_ID_Item_ID_Job_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(string store_ID, string item_ID, string job_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalance_DetailSelectAllByStore_ID_Item_ID_Job_ID_ItSubCat_ItSubCat2_ItSerial_ItSerial2", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@Job_ID"].Value = job_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
				List<tbl_trcItemTracking_MonthlyBalance_Detail> tbl_trcItemTracking_MonthlyBalance_DetailList = new List<tbl_trcItemTracking_MonthlyBalance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcItemTracking_MonthlyBalance_Detail tbl_trcItemTracking_MonthlyBalance_Detail = Maketbl_trcItemTracking_MonthlyBalance_Detail(dataReader);
					tbl_trcItemTracking_MonthlyBalance_DetailList.Add(tbl_trcItemTracking_MonthlyBalance_Detail);
				}
			}
			scon.Close();
			return tbl_trcItemTracking_MonthlyBalance_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking_MonthlyBalance_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_trcItemTracking_MonthlyBalance_Detail> SelectAllByMonth_ID(int month_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTracking_MonthlyBalance_DetailSelectAllByMonth_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters["@month_ID"].Value = month_ID;
				List<tbl_trcItemTracking_MonthlyBalance_Detail> tbl_trcItemTracking_MonthlyBalance_DetailList = new List<tbl_trcItemTracking_MonthlyBalance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcItemTracking_MonthlyBalance_Detail tbl_trcItemTracking_MonthlyBalance_Detail = Maketbl_trcItemTracking_MonthlyBalance_Detail(dataReader);
					tbl_trcItemTracking_MonthlyBalance_DetailList.Add(tbl_trcItemTracking_MonthlyBalance_Detail);
				}
			}
			scon.Close();
			return tbl_trcItemTracking_MonthlyBalance_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_trcItemTracking_MonthlyBalance_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_trcItemTracking_MonthlyBalance_Detail Maketbl_trcItemTracking_MonthlyBalance_Detail(SqlDataReader dataReader) {
			tbl_trcItemTracking_MonthlyBalance_Detail tbl_trcItemTracking_MonthlyBalance_Detail = new tbl_trcItemTracking_MonthlyBalance_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_trcItemTracking_MonthlyBalance_Detail.Month_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_trcItemTracking_MonthlyBalance_Detail.Store_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_trcItemTracking_MonthlyBalance_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_trcItemTracking_MonthlyBalance_Detail.Job_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_trcItemTracking_MonthlyBalance_Detail.ItemSubCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_trcItemTracking_MonthlyBalance_Detail.ItemSubCategory2_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_trcItemTracking_MonthlyBalance_Detail.ItemSerialNo = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_trcItemTracking_MonthlyBalance_Detail.ItemSerialNo2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_trcItemTracking_MonthlyBalance_Detail.Qty_Opening = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_trcItemTracking_MonthlyBalance_Detail.Weight_Opening = dataReader.GetDecimal(9);
			}

			return tbl_trcItemTracking_MonthlyBalance_Detail;
		}
		/// <summary>
		/// This makes tbl_trcItemTracking_MonthlyBalance_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_trcItemTracking_MonthlyBalance_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_trcItemTracking_MonthlyBalance_Detail  tbl_trcItemTracking_MonthlyBalance_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(int));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_Job_ID = new DataColumn("Job_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty_Opening = new DataColumn("qty_Opening" , typeof(decimal));
			DataColumn col_weight_Opening = new DataColumn("weight_Opening" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_month_ID,col_store_ID,col_item_ID,col_Job_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty_Opening,col_weight_Opening,});		return dt;
		}
		/// <summary>
		/// This fills tbl_trcItemTracking_MonthlyBalance_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_trcItemTracking_MonthlyBalance_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_trcItemTracking_MonthlyBalance_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["month_ID"] = user.month_ID;
			drow["store_ID"] = user.store_ID;
			drow["item_ID"] = user.item_ID;
			drow["Job_ID"] = user.Job_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty_Opening"] = user.qty_Opening;
			drow["weight_Opening"] = user.weight_Opening;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
