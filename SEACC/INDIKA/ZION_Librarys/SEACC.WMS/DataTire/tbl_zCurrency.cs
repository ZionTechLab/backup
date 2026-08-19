using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCurrency {
		#region Fields
		private string currency_ID;
		private string currencyName;
		private string currencyCode;
		private decimal currencyRate;
		private decimal buyingRate;
		private DateTime dateValidFrom;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCurrency class.
		/// </summary>
		public tbl_zCurrency() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCurrency class.
		/// </summary>
		public tbl_zCurrency(string currency_ID, string currencyName, string currencyCode, decimal currencyRate, decimal buyingRate, DateTime dateValidFrom) {
			this.currency_ID = currency_ID;
			this.currencyName = currencyName;
			this.currencyCode = currencyCode;
			this.currencyRate = currencyRate;
			this.buyingRate = buyingRate;
			this.dateValidFrom = dateValidFrom;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CurrencyName value.
		/// </summary>
		public string CurrencyName {
			get { return currencyName; }
			set { currencyName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CurrencyCode value.
		/// </summary>
		public string CurrencyCode {
			get { return currencyCode; }
			set { currencyCode = value; }
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
		/// Gets or sets the DateValidFrom value.
		/// </summary>
		public DateTime DateValidFrom {
			get { return dateValidFrom; }
			set { dateValidFrom = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zCurrency table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrencyInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@currencyCode", SqlDbType.VarChar,5);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@buyingRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dateValidFrom", SqlDbType.DateTime,8);
 
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyName"].Value = currencyName;
			scom.Parameters["@currencyCode"].Value = currencyCode;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@buyingRate"].Value = buyingRate;
			scom.Parameters["@dateValidFrom"].Value = dateValidFrom;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCurrency table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrencyUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@currencyCode", SqlDbType.VarChar,5);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@buyingRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dateValidFrom", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyName"].Value = currencyName;
			scom.Parameters["@currencyCode"].Value = currencyCode;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@buyingRate"].Value = buyingRate;
			scom.Parameters["@dateValidFrom"].Value = dateValidFrom;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCurrency table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrencyDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCurrency table.
		/// </summary>
		public static tbl_zCurrency Select(string currency_ID_Incoming){

			tbl_zCurrency tbl_zCurrencyins = new tbl_zCurrency();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrencySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCurrencyins = Maketbl_zCurrency(dataReader);
				} else {
					tbl_zCurrencyins = null;
				}
			}
			scon.Close();
			return tbl_zCurrencyins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCurrency table.
		/// </summary>
		public static List<tbl_zCurrency> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCurrencySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCurrency> tbl_zCurrencyList = new List<tbl_zCurrency>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCurrency tbl_zCurrency = Maketbl_zCurrency(dataReader);
					tbl_zCurrencyList.Add(tbl_zCurrency);
				}
			}
			scon.Close();
			return tbl_zCurrencyList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCurrency class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCurrency Maketbl_zCurrency(SqlDataReader dataReader) {
			tbl_zCurrency tbl_zCurrency = new tbl_zCurrency();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCurrency.Currency_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCurrency.CurrencyName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zCurrency.CurrencyCode = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zCurrency.CurrencyRate = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zCurrency.BuyingRate = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zCurrency.DateValidFrom = dataReader.GetDateTime(5);
			}

			return tbl_zCurrency;
		}
		/// <summary>
		/// This makes tbl_zCurrency datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zCurrency object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zCurrency  tbl_zCurrency   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_currencyName = new DataColumn("currencyName" , typeof(string));
			DataColumn col_currencyCode = new DataColumn("currencyCode" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_buyingRate = new DataColumn("buyingRate" , typeof(decimal));
			DataColumn col_dateValidFrom = new DataColumn("dateValidFrom" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_currency_ID,col_currencyName,col_currencyCode,col_currencyRate,col_buyingRate,col_dateValidFrom,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zCurrency datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCurrency object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCurrency user) {
		DataRow drow = dt.NewRow();
		
			drow["currency_ID"] = user.currency_ID;
			drow["currencyName"] = user.currencyName;
			drow["currencyCode"] = user.currencyCode;
			drow["currencyRate"] = user.currencyRate;
			drow["buyingRate"] = user.buyingRate;
			drow["dateValidFrom"] = user.dateValidFrom;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
