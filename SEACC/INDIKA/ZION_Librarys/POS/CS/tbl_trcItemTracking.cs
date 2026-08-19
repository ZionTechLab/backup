using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_trcItemTracking {
		#region Fields
		private int month_ID;
		private string store_ID;
		private string item_ID;
		private string job_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string transaction_ID;
		private int processNote_ID;
		private DateTime transactionDate;
		private decimal qty_Changed;
		private decimal weight_Changed;
		private bool isPlus;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_trcItemTracking class.
		/// </summary>
		public tbl_trcItemTracking() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_trcItemTracking class.
		/// </summary>
		public tbl_trcItemTracking(int month_ID, string store_ID, string item_ID, string job_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string transaction_ID, int processNote_ID, DateTime transactionDate, decimal qty_Changed, decimal weight_Changed, bool isPlus) {
			this.month_ID = month_ID;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.job_ID = job_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.transaction_ID = transaction_ID;
			this.processNote_ID = processNote_ID;
			this.transactionDate = transactionDate;
			this.qty_Changed = qty_Changed;
			this.weight_Changed = weight_Changed;
			this.isPlus = isPlus;
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
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessNote_ID value.
		/// </summary>
		public int ProcessNote_ID {
			get { return processNote_ID; }
			set { processNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionDate value.
		/// </summary>
		public DateTime TransactionDate {
			get { return transactionDate; }
			set { transactionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Changed value.
		/// </summary>
		public decimal Qty_Changed {
			get { return qty_Changed; }
			set { qty_Changed = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight_Changed value.
		/// </summary>
		public decimal Weight_Changed {
			get { return weight_Changed; }
			set { weight_Changed = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPlus value.
		/// </summary>
		public bool IsPlus {
			get { return isPlus; }
			set { isPlus = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_trcItemTracking table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@qty_Changed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Changed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isPlus", SqlDbType.Bit,1);
 
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@Job_ID"].Value = job_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@qty_Changed"].Value = qty_Changed;
			scom.Parameters["@weight_Changed"].Value = weight_Changed;
			scom.Parameters["@isPlus"].Value = isPlus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_trcItemTracking table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@processNote_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transactionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@qty_Changed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Changed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isPlus", SqlDbType.Bit,1);
 
 
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@Job_ID"].Value = job_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@processNote_ID"].Value = processNote_ID;
			scom.Parameters["@transactionDate"].Value = transactionDate;
			scom.Parameters["@qty_Changed"].Value = qty_Changed;
			scom.Parameters["@weight_Changed"].Value = weight_Changed;
			scom.Parameters["@isPlus"].Value = isPlus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_trcItemTracking table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@Job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters["@month_ID"].Value = month_ID;
 
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@Job_ID"].Value = job_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID_Item_ID_Job_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(string store_ID, string item_ID, string job_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingDeleteAllByStore_ID_Item_ID_Job_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2", scon);
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
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking table by a foreign key.
		/// </summary>
		public static void DeleteAllByMonth_ID(int month_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingDeleteAllByMonth_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters["@month_ID"].Value = month_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking table by a foreign key.
		/// </summary>
		public static void DeleteAllByTransaction_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(string transaction_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingDeleteAllByTransaction_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_trcItemTracking table.
		/// </summary>
		public static tbl_trcItemTracking Select(int month_ID_Incoming, string store_ID_Incoming, string item_ID_Incoming, string job_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming, string transaction_ID_Incoming){

			tbl_trcItemTracking tbl_trcItemTrackingins = new tbl_trcItemTracking();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingSelect", scon);
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
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters["@month_ID"].Value = month_ID_Incoming;
			scom.Parameters["@store_ID"].Value = store_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@Job_ID"].Value = job_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_trcItemTrackingins = Maketbl_trcItemTracking(dataReader);
				} else {
					tbl_trcItemTrackingins = null;
				}
			}
			scon.Close();
			return tbl_trcItemTrackingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking table.
		/// </summary>
		public static List<tbl_trcItemTracking> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_trcItemTracking> tbl_trcItemTrackingList = new List<tbl_trcItemTracking>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcItemTracking tbl_trcItemTracking = Maketbl_trcItemTracking(dataReader);
					tbl_trcItemTrackingList.Add(tbl_trcItemTracking);
				}
			}
			scon.Close();
			return tbl_trcItemTrackingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking table by a foreign key.
		/// </summary>
		public static List<tbl_trcItemTracking> SelectAllByStore_ID_Item_ID_Job_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(string store_ID, string item_ID, string job_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingSelectAllByStore_ID_Item_ID_Job_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2", scon);
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
				List<tbl_trcItemTracking> tbl_trcItemTrackingList = new List<tbl_trcItemTracking>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcItemTracking tbl_trcItemTracking = Maketbl_trcItemTracking(dataReader);
					tbl_trcItemTrackingList.Add(tbl_trcItemTracking);
				}
			}
			scon.Close();
			return tbl_trcItemTrackingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking table by a foreign key.
		/// </summary>
		public static List<tbl_trcItemTracking> SelectAllByMonth_ID(int month_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingSelectAllByMonth_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters["@month_ID"].Value = month_ID;
				List<tbl_trcItemTracking> tbl_trcItemTrackingList = new List<tbl_trcItemTracking>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcItemTracking tbl_trcItemTracking = Maketbl_trcItemTracking(dataReader);
					tbl_trcItemTrackingList.Add(tbl_trcItemTracking);
				}
			}
			scon.Close();
			return tbl_trcItemTrackingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcItemTracking table by a foreign key.
		/// </summary>
		public static List<tbl_trcItemTracking> SelectAllByTransaction_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(string transaction_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcItemTrackingSelectAllByTransaction_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
				List<tbl_trcItemTracking> tbl_trcItemTrackingList = new List<tbl_trcItemTracking>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcItemTracking tbl_trcItemTracking = Maketbl_trcItemTracking(dataReader);
					tbl_trcItemTrackingList.Add(tbl_trcItemTracking);
				}
			}
			scon.Close();
			return tbl_trcItemTrackingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_trcItemTracking class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_trcItemTracking Maketbl_trcItemTracking(SqlDataReader dataReader) {
			tbl_trcItemTracking tbl_trcItemTracking = new tbl_trcItemTracking();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_trcItemTracking.Month_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_trcItemTracking.Store_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_trcItemTracking.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_trcItemTracking.Job_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_trcItemTracking.ItemSubCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_trcItemTracking.ItemSubCategory2_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_trcItemTracking.ItemSerialNo = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_trcItemTracking.ItemSerialNo2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_trcItemTracking.Transaction_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_trcItemTracking.ProcessNote_ID = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_trcItemTracking.TransactionDate = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_trcItemTracking.Qty_Changed = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_trcItemTracking.Weight_Changed = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_trcItemTracking.IsPlus = dataReader.GetBoolean(13);
			}

			return tbl_trcItemTracking;
		}
		/// <summary>
		/// This makes tbl_trcItemTracking datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_trcItemTracking object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_trcItemTracking  tbl_trcItemTracking   )
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
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_processNote_ID = new DataColumn("processNote_ID" , typeof(int));
			DataColumn col_transactionDate = new DataColumn("transactionDate" , typeof(DateTime));
			DataColumn col_qty_Changed = new DataColumn("qty_Changed" , typeof(decimal));
			DataColumn col_weight_Changed = new DataColumn("weight_Changed" , typeof(decimal));
			DataColumn col_isPlus = new DataColumn("isPlus" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_month_ID,col_store_ID,col_item_ID,col_Job_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_transaction_ID,col_processNote_ID,col_transactionDate,col_qty_Changed,col_weight_Changed,col_isPlus,});		return dt;
		}
		/// <summary>
		/// This fills tbl_trcItemTracking datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_trcItemTracking object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_trcItemTracking user) {
		DataRow drow = dt.NewRow();
		
			drow["month_ID"] = user.month_ID;
			drow["store_ID"] = user.store_ID;
			drow["item_ID"] = user.item_ID;
			drow["Job_ID"] = user.Job_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["transaction_ID"] = user.transaction_ID;
			drow["processNote_ID"] = user.processNote_ID;
			drow["transactionDate"] = user.transactionDate;
			drow["qty_Changed"] = user.qty_Changed;
			drow["weight_Changed"] = user.weight_Changed;
			drow["isPlus"] = user.isPlus;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
