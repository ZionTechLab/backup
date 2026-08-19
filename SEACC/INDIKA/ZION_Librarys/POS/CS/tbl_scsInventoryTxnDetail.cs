using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsInventoryTxnDetail {
		#region Fields
		private int txnType;
		private int line_No;
		private int txnIndex;
		private string txnID;
		private DateTime txnDate;
		private string companyID;
		private string companyBranch_ID;
		private string financialYear_ID;
		private string month_ID;
		private string customer_ID;
		private string supplier_ID;
		private string store_ID;
		private string item_ID;
		private string uom_ID;
		private decimal receivedQty;
		private decimal issuedQty;
		private decimal unitPrice;
		private decimal weightedAvgPrice;
		private bool isDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsInventoryTxnDetail class.
		/// </summary>
		public tbl_scsInventoryTxnDetail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsInventoryTxnDetail class.
		/// </summary>
		public tbl_scsInventoryTxnDetail(int txnType, int line_No, int txnIndex, string txnID, DateTime txnDate, string companyID, string companyBranch_ID, string financialYear_ID, string month_ID, string customer_ID, string supplier_ID, string store_ID, string item_ID, string uom_ID, decimal receivedQty, decimal issuedQty, decimal unitPrice, decimal weightedAvgPrice, bool isDeleted) {
			this.txnType = txnType;
			this.line_No = line_No;
			this.txnIndex = txnIndex;
			this.txnID = txnID;
			this.txnDate = txnDate;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.financialYear_ID = financialYear_ID;
			this.month_ID = month_ID;
			this.customer_ID = customer_ID;
			this.supplier_ID = supplier_ID;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.receivedQty = receivedQty;
			this.issuedQty = issuedQty;
			this.unitPrice = unitPrice;
			this.weightedAvgPrice = weightedAvgPrice;
			this.isDeleted = isDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the TxnType value.
		/// </summary>
		public int TxnType {
			get { return txnType; }
			set { txnType = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxnIndex value.
		/// </summary>
		public int TxnIndex {
			get { return txnIndex; }
			set { txnIndex = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxnID value.
		/// </summary>
		public string TxnID {
			get { return txnID; }
			set { txnID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxnDate value.
		/// </summary>
		public DateTime TxnDate {
			get { return txnDate; }
			set { txnDate = value; }
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
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_ID value.
		/// </summary>
		public string Month_ID {
			get { return month_ID; }
			set { month_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
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
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceivedQty value.
		/// </summary>
		public decimal ReceivedQty {
			get { return receivedQty; }
			set { receivedQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the IssuedQty value.
		/// </summary>
		public decimal IssuedQty {
			get { return issuedQty; }
			set { issuedQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightedAvgPrice value.
		/// </summary>
		public decimal WeightedAvgPrice {
			get { return weightedAvgPrice; }
			set { weightedAvgPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsInventoryTxnDetail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@txnType", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@txnIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@txnID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@txnDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@receivedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@issuedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@txnType"].Value = txnType;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@txnIndex"].Value = txnIndex;
			scom.Parameters["@txnID"].Value = txnID;
			scom.Parameters["@txnDate"].Value = txnDate;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@receivedQty"].Value = receivedQty;
			scom.Parameters["@issuedQty"].Value = issuedQty;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightedAvgPrice"].Value = weightedAvgPrice;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsInventoryTxnDetail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@txnType", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@txnIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@txnID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@txnDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@receivedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@issuedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAvgPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@txnType"].Value = txnType;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@txnIndex"].Value = txnIndex;
			scom.Parameters["@txnID"].Value = txnID;
			scom.Parameters["@txnDate"].Value = txnDate;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@receivedQty"].Value = receivedQty;
			scom.Parameters["@issuedQty"].Value = issuedQty;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightedAvgPrice"].Value = weightedAvgPrice;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsInventoryTxnDetail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@txnType", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@txnIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@txnID", SqlDbType.VarChar,20);
			scom.Parameters["@txnType"].Value = txnType;
 
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@txnIndex"].Value = txnIndex;
 
			scom.Parameters["@txnID"].Value = txnID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByTxnType_TxnIndex_TxnID(int txnType, int txnIndex, string txnID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailDeleteAllByTxnType_TxnIndex_TxnID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@txnType", SqlDbType.Int,4);
			scom.Parameters.Add("@txnIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@txnID", SqlDbType.VarChar,20);
			scom.Parameters["@txnType"].Value = txnType;
			scom.Parameters["@txnIndex"].Value = txnIndex;
			scom.Parameters["@txnID"].Value = txnID;
 
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsInventoryTxnDetail table.
		/// </summary>
		public static tbl_scsInventoryTxnDetail Select(int txnType_Incoming, int line_No_Incoming, int txnIndex_Incoming, string txnID_Incoming){

			tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetailins = new tbl_scsInventoryTxnDetail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@txnType", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@txnIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@txnID", SqlDbType.VarChar,20);
			scom.Parameters["@txnType"].Value = txnType_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@txnIndex"].Value = txnIndex_Incoming;
			scom.Parameters["@txnID"].Value = txnID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsInventoryTxnDetailins = Maketbl_scsInventoryTxnDetail(dataReader);
				} else {
					tbl_scsInventoryTxnDetailins = null;
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnDetailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table.
		/// </summary>
		public static List<tbl_scsInventoryTxnDetail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsInventoryTxnDetail> tbl_scsInventoryTxnDetailList = new List<tbl_scsInventoryTxnDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetail = Maketbl_scsInventoryTxnDetail(dataReader);
					tbl_scsInventoryTxnDetailList.Add(tbl_scsInventoryTxnDetail);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnDetail> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_scsInventoryTxnDetail> tbl_scsInventoryTxnDetailList = new List<tbl_scsInventoryTxnDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetail = Maketbl_scsInventoryTxnDetail(dataReader);
					tbl_scsInventoryTxnDetailList.Add(tbl_scsInventoryTxnDetail);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnDetail> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_scsInventoryTxnDetail> tbl_scsInventoryTxnDetailList = new List<tbl_scsInventoryTxnDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetail = Maketbl_scsInventoryTxnDetail(dataReader);
					tbl_scsInventoryTxnDetailList.Add(tbl_scsInventoryTxnDetail);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnDetail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsInventoryTxnDetail> tbl_scsInventoryTxnDetailList = new List<tbl_scsInventoryTxnDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetail = Maketbl_scsInventoryTxnDetail(dataReader);
					tbl_scsInventoryTxnDetailList.Add(tbl_scsInventoryTxnDetail);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnDetail> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_scsInventoryTxnDetail> tbl_scsInventoryTxnDetailList = new List<tbl_scsInventoryTxnDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetail = Maketbl_scsInventoryTxnDetail(dataReader);
					tbl_scsInventoryTxnDetailList.Add(tbl_scsInventoryTxnDetail);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnDetail> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_scsInventoryTxnDetail> tbl_scsInventoryTxnDetailList = new List<tbl_scsInventoryTxnDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetail = Maketbl_scsInventoryTxnDetail(dataReader);
					tbl_scsInventoryTxnDetailList.Add(tbl_scsInventoryTxnDetail);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnDetail> SelectAllByTxnType_TxnIndex_TxnID(int txnType, int txnIndex, string txnID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailSelectAllByTxnType_TxnIndex_TxnID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@txnType", SqlDbType.Int,4);
			scom.Parameters.Add("@txnIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@txnID", SqlDbType.VarChar,20);
			scom.Parameters["@txnType"].Value = txnType;
			scom.Parameters["@txnIndex"].Value = txnIndex;
			scom.Parameters["@txnID"].Value = txnID;
				List<tbl_scsInventoryTxnDetail> tbl_scsInventoryTxnDetailList = new List<tbl_scsInventoryTxnDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetail = Maketbl_scsInventoryTxnDetail(dataReader);
					tbl_scsInventoryTxnDetailList.Add(tbl_scsInventoryTxnDetail);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnDetail> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_scsInventoryTxnDetail> tbl_scsInventoryTxnDetailList = new List<tbl_scsInventoryTxnDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetail = Maketbl_scsInventoryTxnDetail(dataReader);
					tbl_scsInventoryTxnDetailList.Add(tbl_scsInventoryTxnDetail);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnDetail table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnDetail> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnDetailSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_scsInventoryTxnDetail> tbl_scsInventoryTxnDetailList = new List<tbl_scsInventoryTxnDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetail = Maketbl_scsInventoryTxnDetail(dataReader);
					tbl_scsInventoryTxnDetailList.Add(tbl_scsInventoryTxnDetail);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnDetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsInventoryTxnDetail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsInventoryTxnDetail Maketbl_scsInventoryTxnDetail(SqlDataReader dataReader) {
			tbl_scsInventoryTxnDetail tbl_scsInventoryTxnDetail = new tbl_scsInventoryTxnDetail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsInventoryTxnDetail.TxnType = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsInventoryTxnDetail.Line_No = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsInventoryTxnDetail.TxnIndex = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsInventoryTxnDetail.TxnID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsInventoryTxnDetail.TxnDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsInventoryTxnDetail.CompanyID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsInventoryTxnDetail.CompanyBranch_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsInventoryTxnDetail.FinancialYear_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsInventoryTxnDetail.Month_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsInventoryTxnDetail.Customer_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsInventoryTxnDetail.Supplier_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsInventoryTxnDetail.Store_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsInventoryTxnDetail.Item_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsInventoryTxnDetail.Uom_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsInventoryTxnDetail.ReceivedQty = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsInventoryTxnDetail.IssuedQty = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsInventoryTxnDetail.UnitPrice = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsInventoryTxnDetail.WeightedAvgPrice = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsInventoryTxnDetail.IsDeleted = dataReader.GetBoolean(18);
			}

			return tbl_scsInventoryTxnDetail;
		}
		/// <summary>
		/// This makes tbl_scsInventoryTxnDetail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsInventoryTxnDetail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsInventoryTxnDetail  tbl_scsInventoryTxnDetail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_txnType = new DataColumn("txnType" , typeof(int));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_txnIndex = new DataColumn("txnIndex" , typeof(int));
			DataColumn col_txnID = new DataColumn("txnID" , typeof(string));
			DataColumn col_txnDate = new DataColumn("txnDate" , typeof(DateTime));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_receivedQty = new DataColumn("receivedQty" , typeof(decimal));
			DataColumn col_issuedQty = new DataColumn("issuedQty" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightedAvgPrice = new DataColumn("weightedAvgPrice" , typeof(decimal));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_txnType,col_line_No,col_txnIndex,col_txnID,col_txnDate,col_companyID,col_companyBranch_ID,col_financialYear_ID,col_month_ID,col_customer_ID,col_supplier_ID,col_store_ID,col_item_ID,col_uom_ID,col_receivedQty,col_issuedQty,col_unitPrice,col_weightedAvgPrice,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsInventoryTxnDetail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsInventoryTxnDetail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsInventoryTxnDetail user) {
		DataRow drow = dt.NewRow();
		
			drow["txnType"] = user.txnType;
			drow["line_No"] = user.line_No;
			drow["txnIndex"] = user.txnIndex;
			drow["txnID"] = user.txnID;
			drow["txnDate"] = user.txnDate;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["month_ID"] = user.month_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["store_ID"] = user.store_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["receivedQty"] = user.receivedQty;
			drow["issuedQty"] = user.issuedQty;
			drow["unitPrice"] = user.unitPrice;
			drow["weightedAvgPrice"] = user.weightedAvgPrice;
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
