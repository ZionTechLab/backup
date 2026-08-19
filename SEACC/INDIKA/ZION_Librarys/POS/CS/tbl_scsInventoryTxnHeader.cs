using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsInventoryTxnHeader {
		#region Fields
		private int txnType;
		private int txnIndex;
		private string txnID;
		private DateTime txnDate;
		private string remarks;
		private string customer_ID;
		private string supplier_ID;
		private string salesNoteType_ID;
		private int route_ID;
		private decimal totalAmount;
		private string companyID;
		private string companyBranch_ID;
		private string financialYear_ID;
		private string month_ID;
		private bool isDeleted;
		private string createdUser_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsInventoryTxnHeader class.
		/// </summary>
		public tbl_scsInventoryTxnHeader() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsInventoryTxnHeader class.
		/// </summary>
		public tbl_scsInventoryTxnHeader(int txnType, int txnIndex, string txnID, DateTime txnDate, string remarks, string customer_ID, string supplier_ID, string salesNoteType_ID, int route_ID, decimal totalAmount, string companyID, string companyBranch_ID, string financialYear_ID, string month_ID, bool isDeleted, string createdUser_ID) {
			this.txnType = txnType;
			this.txnIndex = txnIndex;
			this.txnID = txnID;
			this.txnDate = txnDate;
			this.remarks = remarks;
			this.customer_ID = customer_ID;
			this.supplier_ID = supplier_ID;
			this.salesNoteType_ID = salesNoteType_ID;
			this.route_ID = route_ID;
			this.totalAmount = totalAmount;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.financialYear_ID = financialYear_ID;
			this.month_ID = month_ID;
			this.isDeleted = isDeleted;
			this.createdUser_ID = createdUser_ID;
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
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
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
		/// Gets or sets the SalesNoteType_ID value.
		/// </summary>
		public string SalesNoteType_ID {
			get { return salesNoteType_ID; }
			set { salesNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Route_ID value.
		/// </summary>
		public int Route_ID {
			get { return route_ID; }
			set { route_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
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
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreatedUser_ID value.
		/// </summary>
		public string CreatedUser_ID {
			get { return createdUser_ID; }
			set { createdUser_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsInventoryTxnHeader table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@txnType", SqlDbType.Int,4);
			scom.Parameters.Add("@txnIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@txnID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@txnDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@Remarks", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@CreatedUser_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@txnType"].Value = txnType;
			scom.Parameters["@txnIndex"].Value = txnIndex;
			scom.Parameters["@txnID"].Value = txnID;
			scom.Parameters["@txnDate"].Value = txnDate;
			scom.Parameters["@Remarks"].Value = remarks;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@CreatedUser_ID"].Value = createdUser_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsInventoryTxnHeader table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@txnType", SqlDbType.Int,4);
			scom.Parameters.Add("@txnIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@txnID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@txnDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@Remarks", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@CreatedUser_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@txnType"].Value = txnType;
			scom.Parameters["@txnIndex"].Value = txnIndex;
			scom.Parameters["@txnID"].Value = txnID;
			scom.Parameters["@txnDate"].Value = txnDate;
			scom.Parameters["@Remarks"].Value = remarks;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@CreatedUser_ID"].Value = createdUser_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsInventoryTxnHeader table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@txnType", SqlDbType.Int,4);
			scom.Parameters.Add("@txnIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@txnID", SqlDbType.VarChar,20);
			scom.Parameters["@txnType"].Value = txnType;
 
			scom.Parameters["@txnIndex"].Value = txnIndex;
 
			scom.Parameters["@txnID"].Value = txnID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesNoteType_ID(string salesNoteType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderDeleteAllBySalesNoteType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(int route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsInventoryTxnHeader table.
		/// </summary>
		public static tbl_scsInventoryTxnHeader Select(int txnType_Incoming, int txnIndex_Incoming, string txnID_Incoming){

			tbl_scsInventoryTxnHeader tbl_scsInventoryTxnHeaderins = new tbl_scsInventoryTxnHeader();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@txnType", SqlDbType.Int,4);
			scom.Parameters.Add("@txnIndex", SqlDbType.Int,4);
			scom.Parameters.Add("@txnID", SqlDbType.VarChar,20);
			scom.Parameters["@txnType"].Value = txnType_Incoming;
			scom.Parameters["@txnIndex"].Value = txnIndex_Incoming;
			scom.Parameters["@txnID"].Value = txnID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsInventoryTxnHeaderins = Maketbl_scsInventoryTxnHeader(dataReader);
				} else {
					tbl_scsInventoryTxnHeaderins = null;
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnHeaderins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table.
		/// </summary>
		public static List<tbl_scsInventoryTxnHeader> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsInventoryTxnHeader> tbl_scsInventoryTxnHeaderList = new List<tbl_scsInventoryTxnHeader>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnHeader tbl_scsInventoryTxnHeader = Maketbl_scsInventoryTxnHeader(dataReader);
					tbl_scsInventoryTxnHeaderList.Add(tbl_scsInventoryTxnHeader);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnHeaderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnHeader> SelectAllBySalesNoteType_ID(string salesNoteType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderSelectAllBySalesNoteType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesNoteType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@salesNoteType_ID"].Value = salesNoteType_ID;
				List<tbl_scsInventoryTxnHeader> tbl_scsInventoryTxnHeaderList = new List<tbl_scsInventoryTxnHeader>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnHeader tbl_scsInventoryTxnHeader = Maketbl_scsInventoryTxnHeader(dataReader);
					tbl_scsInventoryTxnHeaderList.Add(tbl_scsInventoryTxnHeader);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnHeaderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnHeader> SelectAllByRoute_ID(int route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_scsInventoryTxnHeader> tbl_scsInventoryTxnHeaderList = new List<tbl_scsInventoryTxnHeader>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnHeader tbl_scsInventoryTxnHeader = Maketbl_scsInventoryTxnHeader(dataReader);
					tbl_scsInventoryTxnHeaderList.Add(tbl_scsInventoryTxnHeader);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnHeaderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnHeader> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_scsInventoryTxnHeader> tbl_scsInventoryTxnHeaderList = new List<tbl_scsInventoryTxnHeader>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnHeader tbl_scsInventoryTxnHeader = Maketbl_scsInventoryTxnHeader(dataReader);
					tbl_scsInventoryTxnHeaderList.Add(tbl_scsInventoryTxnHeader);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnHeaderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnHeader> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_scsInventoryTxnHeader> tbl_scsInventoryTxnHeaderList = new List<tbl_scsInventoryTxnHeader>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnHeader tbl_scsInventoryTxnHeader = Maketbl_scsInventoryTxnHeader(dataReader);
					tbl_scsInventoryTxnHeaderList.Add(tbl_scsInventoryTxnHeader);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnHeaderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnHeader> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_scsInventoryTxnHeader> tbl_scsInventoryTxnHeaderList = new List<tbl_scsInventoryTxnHeader>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnHeader tbl_scsInventoryTxnHeader = Maketbl_scsInventoryTxnHeader(dataReader);
					tbl_scsInventoryTxnHeaderList.Add(tbl_scsInventoryTxnHeader);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnHeaderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnHeader table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnHeader> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnHeaderSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_scsInventoryTxnHeader> tbl_scsInventoryTxnHeaderList = new List<tbl_scsInventoryTxnHeader>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnHeader tbl_scsInventoryTxnHeader = Maketbl_scsInventoryTxnHeader(dataReader);
					tbl_scsInventoryTxnHeaderList.Add(tbl_scsInventoryTxnHeader);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnHeaderList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsInventoryTxnHeader class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsInventoryTxnHeader Maketbl_scsInventoryTxnHeader(SqlDataReader dataReader) {
			tbl_scsInventoryTxnHeader tbl_scsInventoryTxnHeader = new tbl_scsInventoryTxnHeader();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsInventoryTxnHeader.TxnType = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsInventoryTxnHeader.TxnIndex = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsInventoryTxnHeader.TxnID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsInventoryTxnHeader.TxnDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsInventoryTxnHeader.Remarks = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsInventoryTxnHeader.Customer_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsInventoryTxnHeader.Supplier_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsInventoryTxnHeader.SalesNoteType_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsInventoryTxnHeader.Route_ID = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsInventoryTxnHeader.TotalAmount = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsInventoryTxnHeader.CompanyID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsInventoryTxnHeader.CompanyBranch_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsInventoryTxnHeader.FinancialYear_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsInventoryTxnHeader.Month_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsInventoryTxnHeader.IsDeleted = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsInventoryTxnHeader.CreatedUser_ID = dataReader.GetString(15);
			}

			return tbl_scsInventoryTxnHeader;
		}
		/// <summary>
		/// This makes tbl_scsInventoryTxnHeader datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsInventoryTxnHeader object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsInventoryTxnHeader  tbl_scsInventoryTxnHeader   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_txnType = new DataColumn("txnType" , typeof(int));
			DataColumn col_txnIndex = new DataColumn("txnIndex" , typeof(int));
			DataColumn col_txnID = new DataColumn("txnID" , typeof(string));
			DataColumn col_txnDate = new DataColumn("txnDate" , typeof(DateTime));
			DataColumn col_Remarks = new DataColumn("Remarks" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID" , typeof(string));
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(int));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(string));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_CreatedUser_ID = new DataColumn("CreatedUser_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_txnType,col_txnIndex,col_txnID,col_txnDate,col_Remarks,col_customer_ID,col_supplier_ID,col_salesNoteType_ID,col_route_ID,col_totalAmount,col_companyID,col_companyBranch_ID,col_financialYear_ID,col_month_ID,col_isDeleted,col_CreatedUser_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsInventoryTxnHeader datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsInventoryTxnHeader object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsInventoryTxnHeader user) {
		DataRow drow = dt.NewRow();
		
			drow["txnType"] = user.txnType;
			drow["txnIndex"] = user.txnIndex;
			drow["txnID"] = user.txnID;
			drow["txnDate"] = user.txnDate;
			drow["Remarks"] = user.Remarks;
			drow["customer_ID"] = user.customer_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["salesNoteType_ID"] = user.salesNoteType_ID;
			drow["route_ID"] = user.route_ID;
			drow["totalAmount"] = user.totalAmount;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["month_ID"] = user.month_ID;
			drow["isDeleted"] = user.isDeleted;
			drow["CreatedUser_ID"] = user.CreatedUser_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
