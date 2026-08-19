using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCurrency_History {
		#region Fields
		private int line_No;
		private string currency_ID;
		private DateTime dateValidFrom;
		private DateTime dateValidTill;
		private decimal currencyRate;
		private decimal buyingRate;
		private string source;
		private string createUser_ID;
		private string createTerminal_ID;
		private DateTime dateCreate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCurrency_History class.
		/// </summary>
		public tbl_zCurrency_History() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCurrency_History class.
		/// </summary>
		public tbl_zCurrency_History(int line_No, string currency_ID, DateTime dateValidFrom, DateTime dateValidTill, decimal currencyRate, decimal buyingRate, string source, string createUser_ID, string createTerminal_ID, DateTime dateCreate) {
			this.line_No = line_No;
			this.currency_ID = currency_ID;
			this.dateValidFrom = dateValidFrom;
			this.dateValidTill = dateValidTill;
			this.currencyRate = currencyRate;
			this.buyingRate = buyingRate;
			this.source = source;
			this.createUser_ID = createUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.dateCreate = dateCreate;
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
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateValidFrom value.
		/// </summary>
		public DateTime DateValidFrom {
			get { return dateValidFrom; }
			set { dateValidFrom = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateValidTill value.
		/// </summary>
		public DateTime DateValidTill {
			get { return dateValidTill; }
			set { dateValidTill = value; }
		}
		
		/// <summary>
		/// Gets or sets the CurrencyRate value.
		/// </summary>
		public decimal CurrencyRate {
			get { return currencyRate; }
			set { currencyRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the BuyingRate value.
		/// </summary>
		public decimal BuyingRate {
			get { return buyingRate; }
			set { buyingRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Source value.
		/// </summary>
		public string Source {
			get { return source; }
			set { source = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zCurrency_History table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrency_HistoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@dateValidFrom", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateValidTill", SqlDbType.DateTime,8);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@buyingRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@source", SqlDbType.VarChar,50);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@dateValidFrom"].Value = dateValidFrom;
			scom.Parameters["@dateValidTill"].Value = dateValidTill;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@buyingRate"].Value = buyingRate;
			scom.Parameters["@source"].Value = source;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCurrency_History table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrency_HistoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@dateValidFrom", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateValidTill", SqlDbType.DateTime,8);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@buyingRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@source", SqlDbType.VarChar,50);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@dateValidFrom"].Value = dateValidFrom;
			scom.Parameters["@dateValidTill"].Value = dateValidTill;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@buyingRate"].Value = buyingRate;
			scom.Parameters["@source"].Value = source;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCurrency_History table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrency_HistoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@currency_ID"].Value = currency_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCurrency_History table by a foreign key.
		/// </summary>
		public static void DeleteAllByCurrency_ID(string currency_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrency_HistoryDeleteAllByCurrency_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCurrency_History table.
		/// </summary>
		public static tbl_zCurrency_History Select(int line_No_Incoming, string currency_ID_Incoming){

			tbl_zCurrency_History tbl_zCurrency_Historyins = new tbl_zCurrency_History();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrency_HistorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@currency_ID"].Value = currency_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCurrency_Historyins = Maketbl_zCurrency_History(dataReader);
				} else {
					tbl_zCurrency_Historyins = null;
				}
			}
			scon.Close();
			return tbl_zCurrency_Historyins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCurrency_History table.
		/// </summary>
		public static List<tbl_zCurrency_History> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrency_HistorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCurrency_History> tbl_zCurrency_HistoryList = new List<tbl_zCurrency_History>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCurrency_History tbl_zCurrency_History = Maketbl_zCurrency_History(dataReader);
					tbl_zCurrency_HistoryList.Add(tbl_zCurrency_History);
				}
			}
			scon.Close();
			return tbl_zCurrency_HistoryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCurrency_History table by a foreign key.
		/// </summary>
		public static List<tbl_zCurrency_History> SelectAllByCurrency_ID(string currency_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrency_HistorySelectAllByCurrency_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
				List<tbl_zCurrency_History> tbl_zCurrency_HistoryList = new List<tbl_zCurrency_History>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCurrency_History tbl_zCurrency_History = Maketbl_zCurrency_History(dataReader);
					tbl_zCurrency_HistoryList.Add(tbl_zCurrency_History);
				}
			}
			scon.Close();
			return tbl_zCurrency_HistoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCurrency_History class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCurrency_History Maketbl_zCurrency_History(SqlDataReader dataReader) {
			tbl_zCurrency_History tbl_zCurrency_History = new tbl_zCurrency_History();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCurrency_History.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCurrency_History.Currency_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zCurrency_History.DateValidFrom = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zCurrency_History.DateValidTill = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zCurrency_History.CurrencyRate = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zCurrency_History.BuyingRate = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zCurrency_History.Source = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zCurrency_History.CreateUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zCurrency_History.CreateTerminal_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_zCurrency_History.DateCreate = dataReader.GetDateTime(9);
			}

			return tbl_zCurrency_History;
		}
		/// <summary>
		/// This makes tbl_zCurrency_History datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zCurrency_History object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zCurrency_History  tbl_zCurrency_History   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_dateValidFrom = new DataColumn("dateValidFrom" , typeof(DateTime));
			DataColumn col_dateValidTill = new DataColumn("dateValidTill" , typeof(DateTime));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_buyingRate = new DataColumn("buyingRate" , typeof(decimal));
			DataColumn col_source = new DataColumn("source" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_currency_ID,col_dateValidFrom,col_dateValidTill,col_currencyRate,col_buyingRate,col_source,col_createUser_ID,col_createTerminal_ID,col_dateCreate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zCurrency_History datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCurrency_History object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCurrency_History user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["currency_ID"] = user.currency_ID;
			drow["dateValidFrom"] = user.dateValidFrom;
			drow["dateValidTill"] = user.dateValidTill;
			drow["currencyRate"] = user.currencyRate;
			drow["buyingRate"] = user.buyingRate;
			drow["source"] = user.source;
			drow["createUser_ID"] = user.createUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
