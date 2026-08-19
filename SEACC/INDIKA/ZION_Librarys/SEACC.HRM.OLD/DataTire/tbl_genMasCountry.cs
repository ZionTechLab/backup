using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMasCountry {
		#region Fields
		private string country_ID;
		private string countryName;
		private string country_Code_ISO;
		private string country_Code_UN;
		private string dialingCode;
		private bool status;
		private bool isDefaultcountry;
		private string pfReg_1;
		private string pfReg_2;
		private string pfReg_3;
		private string pfReg_4;
		private string pfReg_5;
		private string taxReg_1;
		private string taxReg_2;
		private string taxReg_3;
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
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genMasCountry class.
		/// </summary>
		public tbl_genMasCountry() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMasCountry class.
		/// </summary>
		public tbl_genMasCountry(string country_ID, string countryName, string country_Code_ISO, string country_Code_UN, string dialingCode, bool status, bool isDefaultcountry, string pfReg_1, string pfReg_2, string pfReg_3, string pfReg_4, string pfReg_5, string taxReg_1, string taxReg_2, string taxReg_3, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.country_ID = country_ID;
			this.countryName = countryName;
			this.country_Code_ISO = country_Code_ISO;
			this.country_Code_UN = country_Code_UN;
			this.dialingCode = dialingCode;
			this.status = status;
			this.isDefaultcountry = isDefaultcountry;
			this.pfReg_1 = pfReg_1;
			this.pfReg_2 = pfReg_2;
			this.pfReg_3 = pfReg_3;
			this.pfReg_4 = pfReg_4;
			this.pfReg_5 = pfReg_5;
			this.taxReg_1 = taxReg_1;
			this.taxReg_2 = taxReg_2;
			this.taxReg_3 = taxReg_3;
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
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Country_ID value.
		/// </summary>
		public string Country_ID {
			get { return country_ID; }
			set { country_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CountryName value.
		/// </summary>
		public string CountryName {
			get { return countryName; }
			set { countryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Country_Code_ISO value.
		/// </summary>
		public string Country_Code_ISO {
			get { return country_Code_ISO; }
			set { country_Code_ISO = value; }
		}
		
		/// <summary>
		/// Gets or sets the Country_Code_UN value.
		/// </summary>
		public string Country_Code_UN {
			get { return country_Code_UN; }
			set { country_Code_UN = value; }
		}
		
		/// <summary>
		/// Gets or sets the DialingCode value.
		/// </summary>
		public string DialingCode {
			get { return dialingCode; }
			set { dialingCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public bool Status {
			get { return status; }
			set { status = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDefaultcountry value.
		/// </summary>
		public bool IsDefaultcountry {
			get { return isDefaultcountry; }
			set { isDefaultcountry = value; }
		}
		
		/// <summary>
		/// Gets or sets the PfReg_1 value.
		/// </summary>
		public string PfReg_1 {
			get { return pfReg_1; }
			set { pfReg_1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PfReg_2 value.
		/// </summary>
		public string PfReg_2 {
			get { return pfReg_2; }
			set { pfReg_2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PfReg_3 value.
		/// </summary>
		public string PfReg_3 {
			get { return pfReg_3; }
			set { pfReg_3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PfReg_4 value.
		/// </summary>
		public string PfReg_4 {
			get { return pfReg_4; }
			set { pfReg_4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PfReg_5 value.
		/// </summary>
		public string PfReg_5 {
			get { return pfReg_5; }
			set { pfReg_5 = value; }
		}
		
		/// <summary>
		/// Gets or sets the TaxReg_1 value.
		/// </summary>
		public string TaxReg_1 {
			get { return taxReg_1; }
			set { taxReg_1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the TaxReg_2 value.
		/// </summary>
		public string TaxReg_2 {
			get { return taxReg_2; }
			set { taxReg_2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the TaxReg_3 value.
		/// </summary>
		public string TaxReg_3 {
			get { return taxReg_3; }
			set { taxReg_3 = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genMasCountry table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasCountryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@countryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@country_Code_ISO", SqlDbType.VarChar,5);
			scom.Parameters.Add("@country_Code_UN", SqlDbType.VarChar,5);
			scom.Parameters.Add("@dialingCode", SqlDbType.VarChar,6);
			scom.Parameters.Add("@status", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDefaultcountry", SqlDbType.Bit,1);
			scom.Parameters.Add("@pfReg_1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pfReg_2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pfReg_3", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pfReg_4", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pfReg_5", SqlDbType.VarChar,20);
			scom.Parameters.Add("@taxReg_1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@taxReg_2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@taxReg_3", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@countryName"].Value = countryName;
			scom.Parameters["@country_Code_ISO"].Value = country_Code_ISO;
			scom.Parameters["@country_Code_UN"].Value = country_Code_UN;
			scom.Parameters["@dialingCode"].Value = dialingCode;
			scom.Parameters["@status"].Value = status;
			scom.Parameters["@isDefaultcountry"].Value = isDefaultcountry;
			scom.Parameters["@pfReg_1"].Value = pfReg_1;
			scom.Parameters["@pfReg_2"].Value = pfReg_2;
			scom.Parameters["@pfReg_3"].Value = pfReg_3;
			scom.Parameters["@pfReg_4"].Value = pfReg_4;
			scom.Parameters["@pfReg_5"].Value = pfReg_5;
			scom.Parameters["@taxReg_1"].Value = taxReg_1;
			scom.Parameters["@taxReg_2"].Value = taxReg_2;
			scom.Parameters["@taxReg_3"].Value = taxReg_3;
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
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genMasCountry table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasCountryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@countryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@country_Code_ISO", SqlDbType.VarChar,5);
			scom.Parameters.Add("@country_Code_UN", SqlDbType.VarChar,5);
			scom.Parameters.Add("@dialingCode", SqlDbType.VarChar,6);
			scom.Parameters.Add("@status", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDefaultcountry", SqlDbType.Bit,1);
			scom.Parameters.Add("@pfReg_1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pfReg_2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pfReg_3", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pfReg_4", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pfReg_5", SqlDbType.VarChar,20);
			scom.Parameters.Add("@taxReg_1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@taxReg_2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@taxReg_3", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@countryName"].Value = countryName;
			scom.Parameters["@country_Code_ISO"].Value = country_Code_ISO;
			scom.Parameters["@country_Code_UN"].Value = country_Code_UN;
			scom.Parameters["@dialingCode"].Value = dialingCode;
			scom.Parameters["@status"].Value = status;
			scom.Parameters["@isDefaultcountry"].Value = isDefaultcountry;
			scom.Parameters["@pfReg_1"].Value = pfReg_1;
			scom.Parameters["@pfReg_2"].Value = pfReg_2;
			scom.Parameters["@pfReg_3"].Value = pfReg_3;
			scom.Parameters["@pfReg_4"].Value = pfReg_4;
			scom.Parameters["@pfReg_5"].Value = pfReg_5;
			scom.Parameters["@taxReg_1"].Value = taxReg_1;
			scom.Parameters["@taxReg_2"].Value = taxReg_2;
			scom.Parameters["@taxReg_3"].Value = taxReg_3;
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
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genMasCountry table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasCountryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,8);
			scom.Parameters["@country_ID"].Value = country_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMasCountry table.
		/// </summary>
		public static tbl_genMasCountry Select(string country_ID_Incoming){

			tbl_genMasCountry tbl_genMasCountryins = new tbl_genMasCountry();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasCountrySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,8);
			scom.Parameters["@country_ID"].Value = country_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMasCountryins = Maketbl_genMasCountry(dataReader);
				} else {
					tbl_genMasCountryins = null;
				}
			}
			scon.Close();
			return tbl_genMasCountryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasCountry table.
		/// </summary>
		public static List<tbl_genMasCountry> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasCountrySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMasCountry> tbl_genMasCountryList = new List<tbl_genMasCountry>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasCountry tbl_genMasCountry = Maketbl_genMasCountry(dataReader);
					tbl_genMasCountryList.Add(tbl_genMasCountry);
				}
			}
			scon.Close();
			return tbl_genMasCountryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMasCountry class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMasCountry Maketbl_genMasCountry(SqlDataReader dataReader) {
			tbl_genMasCountry tbl_genMasCountry = new tbl_genMasCountry();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMasCountry.Country_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMasCountry.CountryName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMasCountry.Country_Code_ISO = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMasCountry.Country_Code_UN = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMasCountry.DialingCode = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMasCountry.Status = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genMasCountry.IsDefaultcountry = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genMasCountry.PfReg_1 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genMasCountry.PfReg_2 = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genMasCountry.PfReg_3 = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genMasCountry.PfReg_4 = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genMasCountry.PfReg_5 = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genMasCountry.TaxReg_1 = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genMasCountry.TaxReg_2 = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genMasCountry.TaxReg_3 = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genMasCountry.IsCanceled = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genMasCountry.UserID_Created = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genMasCountry.UserID_Modified = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genMasCountry.UserID_Canceled = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genMasCountry.TerminalID_Created = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genMasCountry.TerminalID_Modified = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genMasCountry.TerminalID_Canceled = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genMasCountry.Date_Created = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genMasCountry.Date_Modified = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genMasCountry.Date_Canceled = dataReader.GetDateTime(24);
			}

			return tbl_genMasCountry;
		}
		/// <summary>
		/// This makes tbl_genMasCountry datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMasCountry object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMasCountry  tbl_genMasCountry   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_country_ID = new DataColumn("country_ID" , typeof(string));
			DataColumn col_countryName = new DataColumn("countryName" , typeof(string));
			DataColumn col_country_Code_ISO = new DataColumn("country_Code_ISO" , typeof(string));
			DataColumn col_country_Code_UN = new DataColumn("country_Code_UN" , typeof(string));
			DataColumn col_dialingCode = new DataColumn("dialingCode" , typeof(string));
			DataColumn col_status = new DataColumn("status" , typeof(bool));
			DataColumn col_isDefaultcountry = new DataColumn("isDefaultcountry" , typeof(bool));
			DataColumn col_pfReg_1 = new DataColumn("pfReg_1" , typeof(string));
			DataColumn col_pfReg_2 = new DataColumn("pfReg_2" , typeof(string));
			DataColumn col_pfReg_3 = new DataColumn("pfReg_3" , typeof(string));
			DataColumn col_pfReg_4 = new DataColumn("pfReg_4" , typeof(string));
			DataColumn col_pfReg_5 = new DataColumn("pfReg_5" , typeof(string));
			DataColumn col_taxReg_1 = new DataColumn("taxReg_1" , typeof(string));
			DataColumn col_taxReg_2 = new DataColumn("taxReg_2" , typeof(string));
			DataColumn col_taxReg_3 = new DataColumn("taxReg_3" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_country_ID,col_countryName,col_country_Code_ISO,col_country_Code_UN,col_dialingCode,col_status,col_isDefaultcountry,col_pfReg_1,col_pfReg_2,col_pfReg_3,col_pfReg_4,col_pfReg_5,col_taxReg_1,col_taxReg_2,col_taxReg_3,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMasCountry datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMasCountry object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMasCountry user) {
		DataRow drow = dt.NewRow();
		
			drow["country_ID"] = user.country_ID;
			drow["countryName"] = user.countryName;
			drow["country_Code_ISO"] = user.country_Code_ISO;
			drow["country_Code_UN"] = user.country_Code_UN;
			drow["dialingCode"] = user.dialingCode;
			drow["status"] = user.status;
			drow["isDefaultcountry"] = user.isDefaultcountry;
			drow["pfReg_1"] = user.pfReg_1;
			drow["pfReg_2"] = user.pfReg_2;
			drow["pfReg_3"] = user.pfReg_3;
			drow["pfReg_4"] = user.pfReg_4;
			drow["pfReg_5"] = user.pfReg_5;
			drow["taxReg_1"] = user.taxReg_1;
			drow["taxReg_2"] = user.taxReg_2;
			drow["taxReg_3"] = user.taxReg_3;
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
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
