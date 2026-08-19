using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_whTxn_GoodReceivedNote {
		#region Fields
		private string goodReceivedNote_ID;
		private DateTime goodReceivedNote_Date;
		private string estimation_ID;
		private string vehicleTracking_ID;
		private string customer_ID;
		private string store_ID;
		private int storage_Period;
		private string remarks;
		private string currency_ID;
		private decimal currencyRate;
		private decimal subTotal;
		private decimal discountPercentage;
		private decimal discountTotal;
		private decimal grandTotal;
		private bool isCanceled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		private int printCount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_GoodReceivedNote class.
		/// </summary>
		public tbl_whTxn_GoodReceivedNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_GoodReceivedNote class.
		/// </summary>
		public tbl_whTxn_GoodReceivedNote(string goodReceivedNote_ID, DateTime goodReceivedNote_Date, string estimation_ID, string vehicleTracking_ID, string customer_ID, string store_ID, int storage_Period, string remarks, string currency_ID, decimal currencyRate, decimal subTotal, decimal discountPercentage, decimal discountTotal, decimal grandTotal, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled, int printCount) {
			this.goodReceivedNote_ID = goodReceivedNote_ID;
			this.goodReceivedNote_Date = goodReceivedNote_Date;
			this.estimation_ID = estimation_ID;
			this.vehicleTracking_ID = vehicleTracking_ID;
			this.customer_ID = customer_ID;
			this.store_ID = store_ID;
			this.storage_Period = storage_Period;
			this.remarks = remarks;
			this.currency_ID = currency_ID;
			this.currencyRate = currencyRate;
			this.subTotal = subTotal;
			this.discountPercentage = discountPercentage;
			this.discountTotal = discountTotal;
			this.grandTotal = grandTotal;
			this.isCanceled = isCanceled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
			this.printCount = printCount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the GoodReceivedNote_ID value.
		/// </summary>
		public string GoodReceivedNote_ID {
			get { return goodReceivedNote_ID; }
			set { goodReceivedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GoodReceivedNote_Date value.
		/// </summary>
		public DateTime GoodReceivedNote_Date {
			get { return goodReceivedNote_Date; }
			set { goodReceivedNote_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Estimation_ID value.
		/// </summary>
		public string Estimation_ID {
			get { return estimation_ID; }
			set { estimation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the VehicleTracking_ID value.
		/// </summary>
		public string VehicleTracking_ID {
			get { return vehicleTracking_ID; }
			set { vehicleTracking_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Storage_Period value.
		/// </summary>
		public int Storage_Period {
			get { return storage_Period; }
			set { storage_Period = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CurrencyRate value.
		/// </summary>
		public decimal CurrencyRate {
			get { return currencyRate; }
			set { currencyRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubTotal value.
		/// </summary>
		public decimal SubTotal {
			get { return subTotal; }
			set { subTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPercentage value.
		/// </summary>
		public decimal DiscountPercentage {
			get { return discountPercentage; }
			set { discountPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountTotal value.
		/// </summary>
		public decimal DiscountTotal {
			get { return discountTotal; }
			set { discountTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrandTotal value.
		/// </summary>
		public decimal GrandTotal {
			get { return grandTotal; }
			set { grandTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Modified value.
		/// </summary>
		public string UserID_Modified {
			get { return userID_Modified; }
			set { userID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Canceled value.
		/// </summary>
		public string UserID_Canceled {
			get { return userID_Canceled; }
			set { userID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Modified value.
		/// </summary>
		public string TerminalID_Modified {
			get { return terminalID_Modified; }
			set { terminalID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Canceled value.
		/// </summary>
		public string TerminalID_Canceled {
			get { return terminalID_Canceled; }
			set { terminalID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Modified value.
		/// </summary>
		public DateTime Date_Modified {
			get { return date_Modified; }
			set { date_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Canceled value.
		/// </summary>
		public DateTime Date_Canceled {
			get { return date_Canceled; }
			set { date_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_whTxn_GoodReceivedNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@goodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@goodReceivedNote_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@vehicleTracking_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storage_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,50);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
			scom.Parameters["@goodReceivedNote_ID"].Value = goodReceivedNote_ID;
			scom.Parameters["@goodReceivedNote_Date"].Value = goodReceivedNote_Date;
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
			scom.Parameters["@vehicleTracking_ID"].Value = vehicleTracking_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@storage_Period"].Value = storage_Period;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_whTxn_GoodReceivedNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@goodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@goodReceivedNote_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@vehicleTracking_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storage_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,50);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
 
			scom.Parameters["@goodReceivedNote_ID"].Value = goodReceivedNote_ID;
			scom.Parameters["@goodReceivedNote_Date"].Value = goodReceivedNote_Date;
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
			scom.Parameters["@vehicleTracking_ID"].Value = vehicleTracking_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@storage_Period"].Value = storage_Period;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_whTxn_GoodReceivedNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@goodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@goodReceivedNote_ID"].Value = goodReceivedNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCurrency_ID(string currency_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteDeleteAllByCurrency_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByVehicleTracking_ID(string vehicleTracking_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteDeleteAllByVehicleTracking_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@vehicleTracking_ID", SqlDbType.VarChar,8);
			scom.Parameters["@vehicleTracking_ID"].Value = vehicleTracking_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByEstimation_ID(string estimation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteDeleteAllByEstimation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_whTxn_GoodReceivedNote table.
		/// </summary>
		public static tbl_whTxn_GoodReceivedNote Select(string goodReceivedNote_ID_Incoming){

			tbl_whTxn_GoodReceivedNote tbl_whTxn_GoodReceivedNoteins = new tbl_whTxn_GoodReceivedNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@goodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@goodReceivedNote_ID"].Value = goodReceivedNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNoteins = Maketbl_whTxn_GoodReceivedNote(dataReader);
				} else {
					tbl_whTxn_GoodReceivedNoteins = null;
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table.
		/// </summary>
		public static List<tbl_whTxn_GoodReceivedNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_whTxn_GoodReceivedNote> tbl_whTxn_GoodReceivedNoteList = new List<tbl_whTxn_GoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote tbl_whTxn_GoodReceivedNote = Maketbl_whTxn_GoodReceivedNote(dataReader);
					tbl_whTxn_GoodReceivedNoteList.Add(tbl_whTxn_GoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodReceivedNote> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_whTxn_GoodReceivedNote> tbl_whTxn_GoodReceivedNoteList = new List<tbl_whTxn_GoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote tbl_whTxn_GoodReceivedNote = Maketbl_whTxn_GoodReceivedNote(dataReader);
					tbl_whTxn_GoodReceivedNoteList.Add(tbl_whTxn_GoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodReceivedNote> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_whTxn_GoodReceivedNote> tbl_whTxn_GoodReceivedNoteList = new List<tbl_whTxn_GoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote tbl_whTxn_GoodReceivedNote = Maketbl_whTxn_GoodReceivedNote(dataReader);
					tbl_whTxn_GoodReceivedNoteList.Add(tbl_whTxn_GoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodReceivedNote> SelectAllByCurrency_ID(string currency_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteSelectAllByCurrency_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
				List<tbl_whTxn_GoodReceivedNote> tbl_whTxn_GoodReceivedNoteList = new List<tbl_whTxn_GoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote tbl_whTxn_GoodReceivedNote = Maketbl_whTxn_GoodReceivedNote(dataReader);
					tbl_whTxn_GoodReceivedNoteList.Add(tbl_whTxn_GoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodReceivedNote> SelectAllByVehicleTracking_ID(string vehicleTracking_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteSelectAllByVehicleTracking_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@vehicleTracking_ID", SqlDbType.VarChar,8);
			scom.Parameters["@vehicleTracking_ID"].Value = vehicleTracking_ID;
				List<tbl_whTxn_GoodReceivedNote> tbl_whTxn_GoodReceivedNoteList = new List<tbl_whTxn_GoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote tbl_whTxn_GoodReceivedNote = Maketbl_whTxn_GoodReceivedNote(dataReader);
					tbl_whTxn_GoodReceivedNoteList.Add(tbl_whTxn_GoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodReceivedNote> SelectAllByEstimation_ID(string estimation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNoteSelectAllByEstimation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
				List<tbl_whTxn_GoodReceivedNote> tbl_whTxn_GoodReceivedNoteList = new List<tbl_whTxn_GoodReceivedNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote tbl_whTxn_GoodReceivedNote = Maketbl_whTxn_GoodReceivedNote(dataReader);
					tbl_whTxn_GoodReceivedNoteList.Add(tbl_whTxn_GoodReceivedNote);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_whTxn_GoodReceivedNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_whTxn_GoodReceivedNote Maketbl_whTxn_GoodReceivedNote(SqlDataReader dataReader) {
			tbl_whTxn_GoodReceivedNote tbl_whTxn_GoodReceivedNote = new tbl_whTxn_GoodReceivedNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_whTxn_GoodReceivedNote.GoodReceivedNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_whTxn_GoodReceivedNote.GoodReceivedNote_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_whTxn_GoodReceivedNote.Estimation_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_whTxn_GoodReceivedNote.VehicleTracking_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_whTxn_GoodReceivedNote.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_whTxn_GoodReceivedNote.Store_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_whTxn_GoodReceivedNote.Storage_Period = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_whTxn_GoodReceivedNote.Remarks = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_whTxn_GoodReceivedNote.Currency_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_whTxn_GoodReceivedNote.CurrencyRate = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_whTxn_GoodReceivedNote.SubTotal = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_whTxn_GoodReceivedNote.DiscountPercentage = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_whTxn_GoodReceivedNote.DiscountTotal = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_whTxn_GoodReceivedNote.GrandTotal = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_whTxn_GoodReceivedNote.IsCanceled = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_whTxn_GoodReceivedNote.UserID_Created = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_whTxn_GoodReceivedNote.UserID_Modified = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_whTxn_GoodReceivedNote.UserID_Canceled = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_whTxn_GoodReceivedNote.TerminalID_Created = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_whTxn_GoodReceivedNote.TerminalID_Modified = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_whTxn_GoodReceivedNote.TerminalID_Canceled = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_whTxn_GoodReceivedNote.Date_Created = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_whTxn_GoodReceivedNote.Date_Modified = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_whTxn_GoodReceivedNote.Date_Canceled = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_whTxn_GoodReceivedNote.PrintCount = dataReader.GetInt32(24);
			}

			return tbl_whTxn_GoodReceivedNote;
		}
		/// <summary>
		/// This makes tbl_whTxn_GoodReceivedNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_whTxn_GoodReceivedNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_whTxn_GoodReceivedNote  tbl_whTxn_GoodReceivedNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_goodReceivedNote_ID = new DataColumn("goodReceivedNote_ID" , typeof(string));
			DataColumn col_goodReceivedNote_Date = new DataColumn("goodReceivedNote_Date" , typeof(DateTime));
			DataColumn col_estimation_ID = new DataColumn("estimation_ID" , typeof(string));
			DataColumn col_vehicleTracking_ID = new DataColumn("vehicleTracking_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_storage_Period = new DataColumn("storage_Period" , typeof(int));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_subTotal = new DataColumn("subTotal" , typeof(decimal));
			DataColumn col_discountPercentage = new DataColumn("discountPercentage" , typeof(decimal));
			DataColumn col_discountTotal = new DataColumn("discountTotal" , typeof(decimal));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_goodReceivedNote_ID,col_goodReceivedNote_Date,col_estimation_ID,col_vehicleTracking_ID,col_customer_ID,col_store_ID,col_storage_Period,col_remarks,col_currency_ID,col_currencyRate,col_subTotal,col_discountPercentage,col_discountTotal,col_grandTotal,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,col_printCount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_whTxn_GoodReceivedNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_whTxn_GoodReceivedNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_whTxn_GoodReceivedNote user) {
		DataRow drow = dt.NewRow();
		
			drow["goodReceivedNote_ID"] = user.goodReceivedNote_ID;
			drow["goodReceivedNote_Date"] = user.goodReceivedNote_Date;
			drow["estimation_ID"] = user.estimation_ID;
			drow["vehicleTracking_ID"] = user.vehicleTracking_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["store_ID"] = user.store_ID;
			drow["storage_Period"] = user.storage_Period;
			drow["remarks"] = user.remarks;
			drow["currency_ID"] = user.currency_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["subTotal"] = user.subTotal;
			drow["discountPercentage"] = user.discountPercentage;
			drow["discountTotal"] = user.discountTotal;
			drow["grandTotal"] = user.grandTotal;
			drow["isCanceled"] = user.isCanceled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
			drow["printCount"] = user.printCount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
