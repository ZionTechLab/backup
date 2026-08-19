using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemSerialNoMaster {
		#region Fields
		private string itemSerialNo;
		private string item_ID;
		private string batchNo;
		private DateTime dateProduced;
		private DateTime dateExpired;
		private string externalGoodReceivedNote_ID;
		private DateTime externalGoodReceivedNoteDate;
		private bool isDeleted;
		private bool isDelivered;
		private bool isReturned;
		private bool isReDelivered;
		private string store_ID;
		private string section_ID;
		private string job_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemSerialNoMaster class.
		/// </summary>
		public tbl_genItemSerialNoMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemSerialNoMaster class.
		/// </summary>
		public tbl_genItemSerialNoMaster(string itemSerialNo, string item_ID, string batchNo, DateTime dateProduced, DateTime dateExpired, string externalGoodReceivedNote_ID, DateTime externalGoodReceivedNoteDate, bool isDeleted, bool isDelivered, bool isReturned, bool isReDelivered, string store_ID, string section_ID, string job_ID) {
			this.itemSerialNo = itemSerialNo;
			this.item_ID = item_ID;
			this.batchNo = batchNo;
			this.dateProduced = dateProduced;
			this.dateExpired = dateExpired;
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.externalGoodReceivedNoteDate = externalGoodReceivedNoteDate;
			this.isDeleted = isDeleted;
			this.isDelivered = isDelivered;
			this.isReturned = isReturned;
			this.isReDelivered = isReDelivered;
			this.store_ID = store_ID;
			this.section_ID = section_ID;
			this.job_ID = job_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BatchNo value.
		/// </summary>
		public string BatchNo {
			get { return batchNo; }
			set { batchNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateProduced value.
		/// </summary>
		public DateTime DateProduced {
			get { return dateProduced; }
			set { dateProduced = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateExpired value.
		/// </summary>
		public DateTime DateExpired {
			get { return dateExpired; }
			set { dateExpired = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNote_ID value.
		/// </summary>
		public string ExternalGoodReceivedNote_ID {
			get { return externalGoodReceivedNote_ID; }
			set { externalGoodReceivedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNoteDate value.
		/// </summary>
		public DateTime ExternalGoodReceivedNoteDate {
			get { return externalGoodReceivedNoteDate; }
			set { externalGoodReceivedNoteDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDelivered value.
		/// </summary>
		public bool IsDelivered {
			get { return isDelivered; }
			set { isDelivered = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReturned value.
		/// </summary>
		public bool IsReturned {
			get { return isReturned; }
			set { isReturned = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReDelivered value.
		/// </summary>
		public bool IsReDelivered {
			get { return isReDelivered; }
			set { isReDelivered = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemSerialNoMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemSerialNoMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateProduced", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateExpired", SqlDbType.DateTime,8);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDelivered", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturned", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReDelivered", SqlDbType.Bit,1);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@dateProduced"].Value = dateProduced;
			scom.Parameters["@dateExpired"].Value = dateExpired;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@externalGoodReceivedNoteDate"].Value = externalGoodReceivedNoteDate;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isDelivered"].Value = isDelivered;
			scom.Parameters["@isReturned"].Value = isReturned;
			scom.Parameters["@isReDelivered"].Value = isReDelivered;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemSerialNoMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemSerialNoMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateProduced", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateExpired", SqlDbType.DateTime,8);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDelivered", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturned", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReDelivered", SqlDbType.Bit,1);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@dateProduced"].Value = dateProduced;
			scom.Parameters["@dateExpired"].Value = dateExpired;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@externalGoodReceivedNoteDate"].Value = externalGoodReceivedNoteDate;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isDelivered"].Value = isDelivered;
			scom.Parameters["@isReturned"].Value = isReturned;
			scom.Parameters["@isReDelivered"].Value = isReDelivered;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@job_ID"].Value = job_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemSerialNoMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemSerialNoMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemSerialNoMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemSerialNoMasterDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemSerialNoMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemSerialNoMasterDeleteAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemSerialNoMaster table.
		/// </summary>
		public static tbl_genItemSerialNoMaster Select(string itemSerialNo_Incoming){

			tbl_genItemSerialNoMaster tbl_genItemSerialNoMasterins = new tbl_genItemSerialNoMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemSerialNoMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemSerialNoMasterins = Maketbl_genItemSerialNoMaster(dataReader);
				} else {
					tbl_genItemSerialNoMasterins = null;
				}
			}
			scon.Close();
			return tbl_genItemSerialNoMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemSerialNoMaster table.
		/// </summary>
		public static List<tbl_genItemSerialNoMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemSerialNoMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemSerialNoMaster> tbl_genItemSerialNoMasterList = new List<tbl_genItemSerialNoMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemSerialNoMaster tbl_genItemSerialNoMaster = Maketbl_genItemSerialNoMaster(dataReader);
					tbl_genItemSerialNoMasterList.Add(tbl_genItemSerialNoMaster);
				}
			}
			scon.Close();
			return tbl_genItemSerialNoMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemSerialNoMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genItemSerialNoMaster> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemSerialNoMasterSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_genItemSerialNoMaster> tbl_genItemSerialNoMasterList = new List<tbl_genItemSerialNoMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemSerialNoMaster tbl_genItemSerialNoMaster = Maketbl_genItemSerialNoMaster(dataReader);
					tbl_genItemSerialNoMasterList.Add(tbl_genItemSerialNoMaster);
				}
			}
			scon.Close();
			return tbl_genItemSerialNoMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemSerialNoMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genItemSerialNoMaster> SelectAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemSerialNoMasterSelectAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_genItemSerialNoMaster> tbl_genItemSerialNoMasterList = new List<tbl_genItemSerialNoMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemSerialNoMaster tbl_genItemSerialNoMaster = Maketbl_genItemSerialNoMaster(dataReader);
					tbl_genItemSerialNoMasterList.Add(tbl_genItemSerialNoMaster);
				}
			}
			scon.Close();
			return tbl_genItemSerialNoMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemSerialNoMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemSerialNoMaster Maketbl_genItemSerialNoMaster(SqlDataReader dataReader) {
			tbl_genItemSerialNoMaster tbl_genItemSerialNoMaster = new tbl_genItemSerialNoMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemSerialNoMaster.ItemSerialNo = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemSerialNoMaster.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemSerialNoMaster.BatchNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemSerialNoMaster.DateProduced = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemSerialNoMaster.DateExpired = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemSerialNoMaster.ExternalGoodReceivedNote_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemSerialNoMaster.ExternalGoodReceivedNoteDate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemSerialNoMaster.IsDeleted = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemSerialNoMaster.IsDelivered = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genItemSerialNoMaster.IsReturned = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genItemSerialNoMaster.IsReDelivered = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genItemSerialNoMaster.Store_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genItemSerialNoMaster.Section_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genItemSerialNoMaster.Job_ID = dataReader.GetString(13);
			}

			return tbl_genItemSerialNoMaster;
		}
		/// <summary>
		/// This makes tbl_genItemSerialNoMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemSerialNoMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemSerialNoMaster  tbl_genItemSerialNoMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_batchNo = new DataColumn("batchNo" , typeof(string));
			DataColumn col_dateProduced = new DataColumn("dateProduced" , typeof(DateTime));
			DataColumn col_dateExpired = new DataColumn("dateExpired" , typeof(DateTime));
			DataColumn col_externalGoodReceivedNote_ID = new DataColumn("externalGoodReceivedNote_ID" , typeof(string));
			DataColumn col_externalGoodReceivedNoteDate = new DataColumn("externalGoodReceivedNoteDate" , typeof(DateTime));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isDelivered = new DataColumn("isDelivered" , typeof(bool));
			DataColumn col_isReturned = new DataColumn("isReturned" , typeof(bool));
			DataColumn col_isReDelivered = new DataColumn("isReDelivered" , typeof(bool));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_itemSerialNo,col_item_ID,col_batchNo,col_dateProduced,col_dateExpired,col_externalGoodReceivedNote_ID,col_externalGoodReceivedNoteDate,col_isDeleted,col_isDelivered,col_isReturned,col_isReDelivered,col_store_ID,col_section_ID,col_job_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemSerialNoMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemSerialNoMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemSerialNoMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["item_ID"] = user.item_ID;
			drow["batchNo"] = user.batchNo;
			drow["dateProduced"] = user.dateProduced;
			drow["dateExpired"] = user.dateExpired;
			drow["externalGoodReceivedNote_ID"] = user.externalGoodReceivedNote_ID;
			drow["externalGoodReceivedNoteDate"] = user.externalGoodReceivedNoteDate;
			drow["isDeleted"] = user.isDeleted;
			drow["isDelivered"] = user.isDelivered;
			drow["isReturned"] = user.isReturned;
			drow["isReDelivered"] = user.isReDelivered;
			drow["store_ID"] = user.store_ID;
			drow["section_ID"] = user.section_ID;
			drow["job_ID"] = user.job_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
