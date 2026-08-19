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
		private bool isSalesRepStore;
		private bool isShowRoom;
		private bool isDepartment;
		private bool isDeleted;
		private string companyID;
		private string companyBranch_ID;
		private bool isAllowMinusStock;
		private bool isSubContractorStore;
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
		public tbl_genStoreMaster(int line_No, string store_ID, string storeName, string adress, string telephone, string fax, string contactPerson, bool isDamagedStore, bool isSingleItemStockStore, bool isMainStore, bool isTradingStore, bool isSalesRepStore, bool isShowRoom, bool isDepartment, bool isDeleted, string companyID, string companyBranch_ID, bool isAllowMinusStock, bool isSubContractorStore) {
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
			this.isSalesRepStore = isSalesRepStore;
			this.isShowRoom = isShowRoom;
			this.isDepartment = isDepartment;
			this.isDeleted = isDeleted;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.isAllowMinusStock = isAllowMinusStock;
			this.isSubContractorStore = isSubContractorStore;
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
		/// Gets or sets the IsSalesRepStore value.
		/// </summary>
		public bool IsSalesRepStore {
			get { return isSalesRepStore; }
			set { isSalesRepStore = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowRoom value.
		/// </summary>
		public bool IsShowRoom {
			get { return isShowRoom; }
			set { isShowRoom = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDepartment value.
		/// </summary>
		public bool IsDepartment {
			get { return isDepartment; }
			set { isDepartment = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAllowMinusStock value.
		/// </summary>
		public bool IsAllowMinusStock {
			get { return isAllowMinusStock; }
			set { isAllowMinusStock = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSubContractorStore value.
		/// </summary>
		public bool IsSubContractorStore {
			get { return isSubContractorStore; }
			set { isSubContractorStore = value; }
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
			scom.Parameters.Add("@isSalesRepStore", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowRoom", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDepartment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isAllowMinusStock", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSubContractorStore", SqlDbType.Bit,1);
 
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
			scom.Parameters["@isSalesRepStore"].Value = isSalesRepStore;
			scom.Parameters["@isShowRoom"].Value = isShowRoom;
			scom.Parameters["@isDepartment"].Value = isDepartment;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isAllowMinusStock"].Value = isAllowMinusStock;
			scom.Parameters["@isSubContractorStore"].Value = isSubContractorStore;
 
 
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
			scom.Parameters.Add("@isSalesRepStore", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowRoom", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDepartment", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isAllowMinusStock", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSubContractorStore", SqlDbType.Bit,1);
 
 
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
			scom.Parameters["@isSalesRepStore"].Value = isSalesRepStore;
			scom.Parameters["@isShowRoom"].Value = isShowRoom;
			scom.Parameters["@isDepartment"].Value = isDepartment;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isAllowMinusStock"].Value = isAllowMinusStock;
			scom.Parameters["@isSubContractorStore"].Value = isSubContractorStore;
 
 
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

        public static void DeleteAllByCompanyID(string companyID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_genStoreMasterDeleteAllByCompanyID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
            scom.Parameters["@companyID"].Value = companyID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_genStoreMasterDeleteAllByCompanyBranch_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;

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
        /// /// Selects all records from the tbl_genStoreMaster table by a foreign key.
        /// </summary>
        public static List<tbl_genStoreMaster> SelectAllByCompanyID(string companyID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_genStoreMasterSelectAllByCompanyID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyID", SqlDbType.VarChar, 10);
            scom.Parameters["@companyID"].Value = companyID;
            List<tbl_genStoreMaster> tbl_genStoreMasterList = new List<tbl_genStoreMaster>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_genStoreMaster tbl_genStoreMaster = Maketbl_genStoreMaster(dataReader);
                    tbl_genStoreMasterList.Add(tbl_genStoreMaster);
                }
            }
            scon.Close();
            return tbl_genStoreMasterList;
        }

        /// <summary>
        /// Selects all records from the tbl_genStoreMaster table by a foreign key.
        /// </summary>
        public static List<tbl_genStoreMaster> SelectAllByCompanyBranch_ID(string companyBranch_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_genStoreMasterSelectAllByCompanyBranch_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            List<tbl_genStoreMaster> tbl_genStoreMasterList = new List<tbl_genStoreMaster>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
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
        /// 
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
				tbl_genStoreMaster.IsSalesRepStore = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genStoreMaster.IsShowRoom = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genStoreMaster.IsDepartment = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genStoreMaster.IsDeleted = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genStoreMaster.CompanyID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genStoreMaster.CompanyBranch_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genStoreMaster.IsAllowMinusStock = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genStoreMaster.IsSubContractorStore = dataReader.GetBoolean(18);
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
			DataColumn col_isSalesRepStore = new DataColumn("isSalesRepStore" , typeof(bool));
			DataColumn col_isShowRoom = new DataColumn("isShowRoom" , typeof(bool));
			DataColumn col_isDepartment = new DataColumn("isDepartment" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_isAllowMinusStock = new DataColumn("isAllowMinusStock" , typeof(bool));
			DataColumn col_isSubContractorStore = new DataColumn("isSubContractorStore" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_store_ID,col_storeName,col_adress,col_telephone,col_fax,col_contactPerson,col_isDamagedStore,col_isSingleItemStockStore,col_isMainStore,col_isTradingStore,col_isSalesRepStore,col_isShowRoom,col_isDepartment,col_isDeleted,col_companyID,col_companyBranch_ID,col_isAllowMinusStock,col_isSubContractorStore,});		return dt;
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
			drow["isSalesRepStore"] = user.isSalesRepStore;
			drow["isShowRoom"] = user.isShowRoom;
			drow["isDepartment"] = user.isDepartment;
			drow["isDeleted"] = user.isDeleted;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["isAllowMinusStock"] = user.isAllowMinusStock;
			drow["isSubContractorStore"] = user.isSubContractorStore;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
