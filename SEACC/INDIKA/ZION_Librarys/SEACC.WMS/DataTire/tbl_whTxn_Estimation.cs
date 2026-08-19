using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_whTxn_Estimation {
		#region Fields
		private string estimation_ID;
		private DateTime estimation_Date;
		private string customer_ID;
		private int storage_Period;
		private string remarks;
		private string currency_ID;
		private decimal currencyRate;
		private decimal subTotal;
		private decimal discountPercentage;
		private decimal discountTotal;
		private decimal grandTotal;
		private bool isCancelled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Cancelled;
		private string terminalID_Created;
		private string terminaiID_Modified;
		private string terminalID_Cancelled;
		private DateTime date_Created;
		private DateTime dateModified;
		private DateTime date_Cancelled;
		private int printCount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_Estimation class.
		/// </summary>
		public tbl_whTxn_Estimation() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_Estimation class.
		/// </summary>
		public tbl_whTxn_Estimation(string estimation_ID, DateTime estimation_Date, string customer_ID, int storage_Period, string remarks, string currency_ID, decimal currencyRate, decimal subTotal, decimal discountPercentage, decimal discountTotal, decimal grandTotal, bool isCancelled, string userID_Created, string userID_Modified, string userID_Cancelled, string terminalID_Created, string terminaiID_Modified, string terminalID_Cancelled, DateTime date_Created, DateTime dateModified, DateTime date_Cancelled, int printCount) {
			this.estimation_ID = estimation_ID;
			this.estimation_Date = estimation_Date;
			this.customer_ID = customer_ID;
			this.storage_Period = storage_Period;
			this.remarks = remarks;
			this.currency_ID = currency_ID;
			this.currencyRate = currencyRate;
			this.subTotal = subTotal;
			this.discountPercentage = discountPercentage;
			this.discountTotal = discountTotal;
			this.grandTotal = grandTotal;
			this.isCancelled = isCancelled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Cancelled = userID_Cancelled;
			this.terminalID_Created = terminalID_Created;
			this.terminaiID_Modified = terminaiID_Modified;
			this.terminalID_Cancelled = terminalID_Cancelled;
			this.date_Created = date_Created;
			this.dateModified = dateModified;
			this.date_Cancelled = date_Cancelled;
			this.printCount = printCount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Estimation_ID value.
		/// </summary>
		public string Estimation_ID {
			get { return estimation_ID; }
			set { estimation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Estimation_Date value.
		/// </summary>
		public DateTime Estimation_Date {
			get { return estimation_Date; }
			set { estimation_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
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
		/// Gets or sets the IsCancelled value.
		/// </summary>
		public bool IsCancelled {
			get { return isCancelled; }
			set { isCancelled = value; }
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
		/// Gets or sets the UserID_Cancelled value.
		/// </summary>
		public string UserID_Cancelled {
			get { return userID_Cancelled; }
			set { userID_Cancelled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminaiID_Modified value.
		/// </summary>
		public string TerminaiID_Modified {
			get { return terminaiID_Modified; }
			set { terminaiID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Cancelled value.
		/// </summary>
		public string TerminalID_Cancelled {
			get { return terminalID_Cancelled; }
			set { terminalID_Cancelled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Cancelled value.
		/// </summary>
		public DateTime Date_Cancelled {
			get { return date_Cancelled; }
			set { date_Cancelled = value; }
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
		/// Saves a record to the tbl_whTxn_Estimation table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_EstimationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@estimation_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storage_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,50);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCancelled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Cancelled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminaiID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Cancelled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Cancelled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
			scom.Parameters["@estimation_Date"].Value = estimation_Date;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@storage_Period"].Value = storage_Period;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@isCancelled"].Value = isCancelled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Cancelled"].Value = userID_Cancelled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminaiID_Modified"].Value = terminaiID_Modified;
			scom.Parameters["@terminalID_Cancelled"].Value = terminalID_Cancelled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@date_Cancelled"].Value = date_Cancelled;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_whTxn_Estimation table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_EstimationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@estimation_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storage_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,50);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@subTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grandTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCancelled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Cancelled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminaiID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Cancelled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Cancelled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
 
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
			scom.Parameters["@estimation_Date"].Value = estimation_Date;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@storage_Period"].Value = storage_Period;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@subTotal"].Value = subTotal;
			scom.Parameters["@discountPercentage"].Value = discountPercentage;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@grandTotal"].Value = grandTotal;
			scom.Parameters["@isCancelled"].Value = isCancelled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Cancelled"].Value = userID_Cancelled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminaiID_Modified"].Value = terminaiID_Modified;
			scom.Parameters["@terminalID_Cancelled"].Value = terminalID_Cancelled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@date_Cancelled"].Value = date_Cancelled;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_whTxn_Estimation table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_EstimationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_Estimation table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_EstimationDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_whTxn_Estimation table.
		/// </summary>
		public static tbl_whTxn_Estimation Select(string estimation_ID_Incoming){

			tbl_whTxn_Estimation tbl_whTxn_Estimationins = new tbl_whTxn_Estimation();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_EstimationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters["@estimation_ID"].Value = estimation_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_whTxn_Estimationins = Maketbl_whTxn_Estimation(dataReader);
				} else {
					tbl_whTxn_Estimationins = null;
				}
			}
			scon.Close();
			return tbl_whTxn_Estimationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_Estimation table.
		/// </summary>
		public static List<tbl_whTxn_Estimation> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_EstimationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_whTxn_Estimation> tbl_whTxn_EstimationList = new List<tbl_whTxn_Estimation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_Estimation tbl_whTxn_Estimation = Maketbl_whTxn_Estimation(dataReader);
					tbl_whTxn_EstimationList.Add(tbl_whTxn_Estimation);
				}
			}
			scon.Close();
			return tbl_whTxn_EstimationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_Estimation table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_Estimation> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_EstimationSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_whTxn_Estimation> tbl_whTxn_EstimationList = new List<tbl_whTxn_Estimation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_Estimation tbl_whTxn_Estimation = Maketbl_whTxn_Estimation(dataReader);
					tbl_whTxn_EstimationList.Add(tbl_whTxn_Estimation);
				}
			}
			scon.Close();
			return tbl_whTxn_EstimationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_whTxn_Estimation class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_whTxn_Estimation Maketbl_whTxn_Estimation(SqlDataReader dataReader) {
			tbl_whTxn_Estimation tbl_whTxn_Estimation = new tbl_whTxn_Estimation();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_whTxn_Estimation.Estimation_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_whTxn_Estimation.Estimation_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_whTxn_Estimation.Customer_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_whTxn_Estimation.Storage_Period = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_whTxn_Estimation.Remarks = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_whTxn_Estimation.Currency_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_whTxn_Estimation.CurrencyRate = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_whTxn_Estimation.SubTotal = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_whTxn_Estimation.DiscountPercentage = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_whTxn_Estimation.DiscountTotal = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_whTxn_Estimation.GrandTotal = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_whTxn_Estimation.IsCancelled = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_whTxn_Estimation.UserID_Created = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_whTxn_Estimation.UserID_Modified = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_whTxn_Estimation.UserID_Cancelled = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_whTxn_Estimation.TerminalID_Created = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_whTxn_Estimation.TerminaiID_Modified = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_whTxn_Estimation.TerminalID_Cancelled = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_whTxn_Estimation.Date_Created = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_whTxn_Estimation.DateModified = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_whTxn_Estimation.Date_Cancelled = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_whTxn_Estimation.PrintCount = dataReader.GetInt32(21);
			}

			return tbl_whTxn_Estimation;
		}
		/// <summary>
		/// This makes tbl_whTxn_Estimation datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_whTxn_Estimation object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_whTxn_Estimation  tbl_whTxn_Estimation   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_estimation_ID = new DataColumn("estimation_ID" , typeof(string));
			DataColumn col_estimation_Date = new DataColumn("estimation_Date" , typeof(DateTime));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_storage_Period = new DataColumn("storage_Period" , typeof(int));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_subTotal = new DataColumn("subTotal" , typeof(decimal));
			DataColumn col_discountPercentage = new DataColumn("discountPercentage" , typeof(decimal));
			DataColumn col_discountTotal = new DataColumn("discountTotal" , typeof(decimal));
			DataColumn col_grandTotal = new DataColumn("grandTotal" , typeof(decimal));
			DataColumn col_isCancelled = new DataColumn("isCancelled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Cancelled = new DataColumn("userID_Cancelled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminaiID_Modified = new DataColumn("terminaiID_Modified" , typeof(string));
			DataColumn col_terminalID_Cancelled = new DataColumn("terminalID_Cancelled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_date_Cancelled = new DataColumn("date_Cancelled" , typeof(DateTime));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_estimation_ID,col_estimation_Date,col_customer_ID,col_storage_Period,col_remarks,col_currency_ID,col_currencyRate,col_subTotal,col_discountPercentage,col_discountTotal,col_grandTotal,col_isCancelled,col_userID_Created,col_userID_Modified,col_userID_Cancelled,col_terminalID_Created,col_terminaiID_Modified,col_terminalID_Cancelled,col_date_Created,col_dateModified,col_date_Cancelled,col_printCount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_whTxn_Estimation datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_whTxn_Estimation object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_whTxn_Estimation user) {
		DataRow drow = dt.NewRow();
		
			drow["estimation_ID"] = user.estimation_ID;
			drow["estimation_Date"] = user.estimation_Date;
			drow["customer_ID"] = user.customer_ID;
			drow["storage_Period"] = user.storage_Period;
			drow["remarks"] = user.remarks;
			drow["currency_ID"] = user.currency_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["subTotal"] = user.subTotal;
			drow["discountPercentage"] = user.discountPercentage;
			drow["discountTotal"] = user.discountTotal;
			drow["grandTotal"] = user.grandTotal;
			drow["isCancelled"] = user.isCancelled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Cancelled"] = user.userID_Cancelled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminaiID_Modified"] = user.terminaiID_Modified;
			drow["terminalID_Cancelled"] = user.terminalID_Cancelled;
			drow["date_Created"] = user.date_Created;
			drow["dateModified"] = user.dateModified;
			drow["date_Cancelled"] = user.date_Cancelled;
			drow["printCount"] = user.printCount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
