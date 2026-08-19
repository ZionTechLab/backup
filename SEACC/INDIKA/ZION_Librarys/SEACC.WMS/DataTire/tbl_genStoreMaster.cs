using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genStoreMaster {
		#region Fields
		private int line_No;
		private string store_ID;
		private string storeName;
		private string adress;
		private string telephone;
		private string fax;
		private string contactPerson;
		private bool isDamagedStore;
		private bool isSingleItemStockStore;
		private bool isMainStore;
		private bool isTradingStore;
		private bool isShowRoom;
		private bool isDeleted;
		private bool isReturnedStore;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genStoreMaster class.
		/// </summary>
		public tbl_genStoreMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genStoreMaster class.
		/// </summary>
		public tbl_genStoreMaster(int line_No, string store_ID, string storeName, string adress, string telephone, string fax, string contactPerson, bool isDamagedStore, bool isSingleItemStockStore, bool isMainStore, bool isTradingStore, bool isShowRoom, bool isDeleted, bool isReturnedStore) {
			this.line_No = line_No;
			this.store_ID = store_ID;
			this.storeName = storeName;
			this.adress = adress;
			this.telephone = telephone;
			this.fax = fax;
			this.contactPerson = contactPerson;
			this.isDamagedStore = isDamagedStore;
			this.isSingleItemStockStore = isSingleItemStockStore;
			this.isMainStore = isMainStore;
			this.isTradingStore = isTradingStore;
			this.isShowRoom = isShowRoom;
			this.isDeleted = isDeleted;
			this.isReturnedStore = isReturnedStore;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StoreName value.
		/// </summary>
		public string StoreName {
			get { return storeName; }
			set { storeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Adress value.
		/// </summary>
		public string Adress {
			get { return adress; }
			set { adress = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone value.
		/// </summary>
		public string Telephone {
			get { return telephone; }
			set { telephone = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fax value.
		/// </summary>
		public string Fax {
			get { return fax; }
			set { fax = value; }
		}
		
		/// <summary>
		/// Gets or sets the ContactPerson value.
		/// </summary>
		public string ContactPerson {
			get { return contactPerson; }
			set { contactPerson = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDamagedStore value.
		/// </summary>
		public bool IsDamagedStore {
			get { return isDamagedStore; }
			set { isDamagedStore = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSingleItemStockStore value.
		/// </summary>
		public bool IsSingleItemStockStore {
			get { return isSingleItemStockStore; }
			set { isSingleItemStockStore = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsMainStore value.
		/// </summary>
		public bool IsMainStore {
			get { return isMainStore; }
			set { isMainStore = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTradingStore value.
		/// </summary>
		public bool IsTradingStore {
			get { return isTradingStore; }
			set { isTradingStore = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowRoom value.
		/// </summary>
		public bool IsShowRoom {
			get { return isShowRoom; }
			set { isShowRoom = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReturnedStore value.
		/// </summary>
		public bool IsReturnedStore {
			get { return isReturnedStore; }
			set { isReturnedStore = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genStoreMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStoreMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isDamagedStore", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSingleItemStockStore", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMainStore", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTradingStore", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowRoom", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturnedStore", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@storeName"].Value = storeName;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
			scom.Parameters["@isDamagedStore"].Value = isDamagedStore;
			scom.Parameters["@isSingleItemStockStore"].Value = isSingleItemStockStore;
			scom.Parameters["@isMainStore"].Value = isMainStore;
			scom.Parameters["@isTradingStore"].Value = isTradingStore;
			scom.Parameters["@isShowRoom"].Value = isShowRoom;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isReturnedStore"].Value = isReturnedStore;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genStoreMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStoreMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@adress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@contactPerson", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isDamagedStore", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSingleItemStockStore", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMainStore", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTradingStore", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowRoom", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturnedStore", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@storeName"].Value = storeName;
			scom.Parameters["@adress"].Value = adress;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@contactPerson"].Value = contactPerson;
			scom.Parameters["@isDamagedStore"].Value = isDamagedStore;
			scom.Parameters["@isSingleItemStockStore"].Value = isSingleItemStockStore;
			scom.Parameters["@isMainStore"].Value = isMainStore;
			scom.Parameters["@isTradingStore"].Value = isTradingStore;
			scom.Parameters["@isShowRoom"].Value = isShowRoom;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isReturnedStore"].Value = isReturnedStore;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genStoreMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStoreMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genStoreMaster table.
		/// </summary>
		public static tbl_genStoreMaster Select(string store_ID_Incoming){

			tbl_genStoreMaster tbl_genStoreMasterins = new tbl_genStoreMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStoreMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genStoreMasterins = Maketbl_genStoreMaster(dataReader);
				} else {
					tbl_genStoreMasterins = null;
				}
			}
			scon.Close();
			return tbl_genStoreMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genStoreMaster table.
		/// </summary>
		public static List<tbl_genStoreMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genStoreMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genStoreMaster> tbl_genStoreMasterList = new List<tbl_genStoreMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genStoreMaster tbl_genStoreMaster = Maketbl_genStoreMaster(dataReader);
					tbl_genStoreMasterList.Add(tbl_genStoreMaster);
				}
			}
			scon.Close();
			return tbl_genStoreMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genStoreMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genStoreMaster Maketbl_genStoreMaster(SqlDataReader dataReader) {
			tbl_genStoreMaster tbl_genStoreMaster = new tbl_genStoreMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genStoreMaster.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genStoreMaster.Store_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genStoreMaster.StoreName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genStoreMaster.Adress = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genStoreMaster.Telephone = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genStoreMaster.Fax = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genStoreMaster.ContactPerson = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genStoreMaster.IsDamagedStore = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genStoreMaster.IsSingleItemStockStore = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genStoreMaster.IsMainStore = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genStoreMaster.IsTradingStore = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genStoreMaster.IsShowRoom = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genStoreMaster.IsDeleted = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genStoreMaster.IsReturnedStore = dataReader.GetBoolean(13);
			}

			return tbl_genStoreMaster;
		}
		/// <summary>
		/// This makes tbl_genStoreMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genStoreMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genStoreMaster  tbl_genStoreMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_storeName = new DataColumn("storeName" , typeof(string));
			DataColumn col_adress = new DataColumn("adress" , typeof(string));
			DataColumn col_telephone = new DataColumn("telephone" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_contactPerson = new DataColumn("contactPerson" , typeof(string));
			DataColumn col_isDamagedStore = new DataColumn("isDamagedStore" , typeof(bool));
			DataColumn col_isSingleItemStockStore = new DataColumn("isSingleItemStockStore" , typeof(bool));
			DataColumn col_isMainStore = new DataColumn("isMainStore" , typeof(bool));
			DataColumn col_isTradingStore = new DataColumn("isTradingStore" , typeof(bool));
			DataColumn col_isShowRoom = new DataColumn("isShowRoom" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isReturnedStore = new DataColumn("isReturnedStore" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_store_ID,col_storeName,col_adress,col_telephone,col_fax,col_contactPerson,col_isDamagedStore,col_isSingleItemStockStore,col_isMainStore,col_isTradingStore,col_isShowRoom,col_isDeleted,col_isReturnedStore,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genStoreMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genStoreMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genStoreMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["store_ID"] = user.store_ID;
			drow["storeName"] = user.storeName;
			drow["adress"] = user.adress;
			drow["telephone"] = user.telephone;
			drow["fax"] = user.fax;
			drow["contactPerson"] = user.contactPerson;
			drow["isDamagedStore"] = user.isDamagedStore;
			drow["isSingleItemStockStore"] = user.isSingleItemStockStore;
			drow["isMainStore"] = user.isMainStore;
			drow["isTradingStore"] = user.isTradingStore;
			drow["isShowRoom"] = user.isShowRoom;
			drow["isDeleted"] = user.isDeleted;
			drow["isReturnedStore"] = user.isReturnedStore;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
