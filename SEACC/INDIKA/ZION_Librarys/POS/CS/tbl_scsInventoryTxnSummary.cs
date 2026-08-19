using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsInventoryTxnSummary {
		#region Fields
		private string companyID;
		private string companyBranch_ID;
		private string financialYear_ID;
		private string month_ID;
		private string store_ID;
		private string item_ID;
		private decimal openingQty;
		private decimal receivedQty;
		private decimal issuedQty;
		private decimal endQty;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsInventoryTxnSummary class.
		/// </summary>
		public tbl_scsInventoryTxnSummary() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsInventoryTxnSummary class.
		/// </summary>
		public tbl_scsInventoryTxnSummary(string companyID, string companyBranch_ID, string financialYear_ID, string month_ID, string store_ID, string item_ID, decimal openingQty, decimal receivedQty, decimal issuedQty, decimal endQty) {
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.financialYear_ID = financialYear_ID;
			this.month_ID = month_ID;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.openingQty = openingQty;
			this.receivedQty = receivedQty;
			this.issuedQty = issuedQty;
			this.endQty = endQty;
		}
		#endregion
		
		#region Properties
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
		/// Gets or sets the OpeningQty value.
		/// </summary>
		public decimal OpeningQty {
			get { return openingQty; }
			set { openingQty = value; }
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
		/// Gets or sets the EndQty value.
		/// </summary>
		public decimal EndQty {
			get { return endQty; }
			set { endQty = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsInventoryTxnSummary table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummaryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@openingQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@receivedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@issuedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@endQty", SqlDbType.Decimal,9);
 
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@openingQty"].Value = openingQty;
			scom.Parameters["@receivedQty"].Value = receivedQty;
			scom.Parameters["@issuedQty"].Value = issuedQty;
			scom.Parameters["@endQty"].Value = endQty;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsInventoryTxnSummary table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummaryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@openingQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@receivedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@issuedQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@endQty", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@openingQty"].Value = openingQty;
			scom.Parameters["@receivedQty"].Value = receivedQty;
			scom.Parameters["@issuedQty"].Value = issuedQty;
			scom.Parameters["@endQty"].Value = endQty;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsInventoryTxnSummary table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummaryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyID"].Value = companyID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
			scom.Parameters["@month_ID"].Value = month_ID;
 
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummaryDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummaryDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static void DeleteAllByFinancialYear_ID_Month_ID(string financialYear_ID, string month_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummaryDeleteAllByFinancialYear_ID_Month_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummaryDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static void DeleteAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummaryDeleteAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummaryDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsInventoryTxnSummary table.
		/// </summary>
		public static tbl_scsInventoryTxnSummary Select(string companyID_Incoming, string companyBranch_ID_Incoming, string financialYear_ID_Incoming, string month_ID_Incoming, string store_ID_Incoming, string item_ID_Incoming){

			tbl_scsInventoryTxnSummary tbl_scsInventoryTxnSummaryins = new tbl_scsInventoryTxnSummary();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummarySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyID"].Value = companyID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID_Incoming;
			scom.Parameters["@month_ID"].Value = month_ID_Incoming;
			scom.Parameters["@store_ID"].Value = store_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsInventoryTxnSummaryins = Maketbl_scsInventoryTxnSummary(dataReader);
				} else {
					tbl_scsInventoryTxnSummaryins = null;
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnSummaryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table.
		/// </summary>
		public static List<tbl_scsInventoryTxnSummary> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummarySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsInventoryTxnSummary> tbl_scsInventoryTxnSummaryList = new List<tbl_scsInventoryTxnSummary>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnSummary tbl_scsInventoryTxnSummary = Maketbl_scsInventoryTxnSummary(dataReader);
					tbl_scsInventoryTxnSummaryList.Add(tbl_scsInventoryTxnSummary);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnSummaryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnSummary> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummarySelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_scsInventoryTxnSummary> tbl_scsInventoryTxnSummaryList = new List<tbl_scsInventoryTxnSummary>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnSummary tbl_scsInventoryTxnSummary = Maketbl_scsInventoryTxnSummary(dataReader);
					tbl_scsInventoryTxnSummaryList.Add(tbl_scsInventoryTxnSummary);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnSummaryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnSummary> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummarySelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_scsInventoryTxnSummary> tbl_scsInventoryTxnSummaryList = new List<tbl_scsInventoryTxnSummary>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnSummary tbl_scsInventoryTxnSummary = Maketbl_scsInventoryTxnSummary(dataReader);
					tbl_scsInventoryTxnSummaryList.Add(tbl_scsInventoryTxnSummary);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnSummaryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnSummary> SelectAllByFinancialYear_ID_Month_ID(string financialYear_ID, string month_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummarySelectAllByFinancialYear_ID_Month_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
				List<tbl_scsInventoryTxnSummary> tbl_scsInventoryTxnSummaryList = new List<tbl_scsInventoryTxnSummary>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnSummary tbl_scsInventoryTxnSummary = Maketbl_scsInventoryTxnSummary(dataReader);
					tbl_scsInventoryTxnSummaryList.Add(tbl_scsInventoryTxnSummary);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnSummaryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnSummary> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummarySelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_scsInventoryTxnSummary> tbl_scsInventoryTxnSummaryList = new List<tbl_scsInventoryTxnSummary>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnSummary tbl_scsInventoryTxnSummary = Maketbl_scsInventoryTxnSummary(dataReader);
					tbl_scsInventoryTxnSummaryList.Add(tbl_scsInventoryTxnSummary);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnSummaryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnSummary> SelectAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummarySelectAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
				List<tbl_scsInventoryTxnSummary> tbl_scsInventoryTxnSummaryList = new List<tbl_scsInventoryTxnSummary>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnSummary tbl_scsInventoryTxnSummary = Maketbl_scsInventoryTxnSummary(dataReader);
					tbl_scsInventoryTxnSummaryList.Add(tbl_scsInventoryTxnSummary);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnSummaryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsInventoryTxnSummary table by a foreign key.
		/// </summary>
		public static List<tbl_scsInventoryTxnSummary> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsInventoryTxnSummarySelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_scsInventoryTxnSummary> tbl_scsInventoryTxnSummaryList = new List<tbl_scsInventoryTxnSummary>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsInventoryTxnSummary tbl_scsInventoryTxnSummary = Maketbl_scsInventoryTxnSummary(dataReader);
					tbl_scsInventoryTxnSummaryList.Add(tbl_scsInventoryTxnSummary);
				}
			}
			scon.Close();
			return tbl_scsInventoryTxnSummaryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsInventoryTxnSummary class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsInventoryTxnSummary Maketbl_scsInventoryTxnSummary(SqlDataReader dataReader) {
			tbl_scsInventoryTxnSummary tbl_scsInventoryTxnSummary = new tbl_scsInventoryTxnSummary();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsInventoryTxnSummary.CompanyID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsInventoryTxnSummary.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsInventoryTxnSummary.FinancialYear_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsInventoryTxnSummary.Month_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsInventoryTxnSummary.Store_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsInventoryTxnSummary.Item_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsInventoryTxnSummary.OpeningQty = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsInventoryTxnSummary.ReceivedQty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsInventoryTxnSummary.IssuedQty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsInventoryTxnSummary.EndQty = dataReader.GetDecimal(9);
			}

			return tbl_scsInventoryTxnSummary;
		}
		/// <summary>
		/// This makes tbl_scsInventoryTxnSummary datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsInventoryTxnSummary object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsInventoryTxnSummary  tbl_scsInventoryTxnSummary   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_openingQty = new DataColumn("openingQty" , typeof(decimal));
			DataColumn col_receivedQty = new DataColumn("receivedQty" , typeof(decimal));
			DataColumn col_issuedQty = new DataColumn("issuedQty" , typeof(decimal));
			DataColumn col_endQty = new DataColumn("endQty" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_companyID,col_companyBranch_ID,col_financialYear_ID,col_month_ID,col_store_ID,col_item_ID,col_openingQty,col_receivedQty,col_issuedQty,col_endQty,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsInventoryTxnSummary datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsInventoryTxnSummary object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsInventoryTxnSummary user) {
		DataRow drow = dt.NewRow();
		
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["month_ID"] = user.month_ID;
			drow["store_ID"] = user.store_ID;
			drow["item_ID"] = user.item_ID;
			drow["openingQty"] = user.openingQty;
			drow["receivedQty"] = user.receivedQty;
			drow["issuedQty"] = user.issuedQty;
			drow["endQty"] = user.endQty;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
