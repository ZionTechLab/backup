using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCompanyInfo {
		#region Fields
		private string companyID;
		private string companyName;
		private string address;
		private string telephone1;
		private string telephone2;
		private string telephone3;
		private string fax;
		private string email;
		private string url;
		private string vatRegisterNo;
		private string companyMDName;
		private string mdTelephone;
		private string databaseName;
		private string businessRegisterNo;
		private string epf_RegNo;
		private string etf_RegNo;
		private string payee_RegNo;
		private string tax_IdentityNo;
		private int edition;
		private string serialNo1;
		private string serialNo2;
		private string serialNo3;
		private string serialNo4;
		private string financialYear_ID;
		private string month_ID;
		private DateTime startDate;
		private int theme_ID;
		private string productKey;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCompanyInfo class.
		/// </summary>
		public tbl_genCompanyInfo() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCompanyInfo class.
		/// </summary>
		public tbl_genCompanyInfo(string companyID, string companyName, string address, string telephone1, string telephone2, string telephone3, string fax, string email, string url, string vatRegisterNo, string companyMDName, string mdTelephone, string databaseName, string businessRegisterNo, string epf_RegNo, string etf_RegNo, string payee_RegNo, string tax_IdentityNo, int edition, string serialNo1, string serialNo2, string serialNo3, string serialNo4, string financialYear_ID, string month_ID, DateTime startDate, int theme_ID, string productKey) {
			this.companyID = companyID;
			this.companyName = companyName;
			this.address = address;
			this.telephone1 = telephone1;
			this.telephone2 = telephone2;
			this.telephone3 = telephone3;
			this.fax = fax;
			this.email = email;
			this.url = url;
			this.vatRegisterNo = vatRegisterNo;
			this.companyMDName = companyMDName;
			this.mdTelephone = mdTelephone;
			this.databaseName = databaseName;
			this.businessRegisterNo = businessRegisterNo;
			this.epf_RegNo = epf_RegNo;
			this.etf_RegNo = etf_RegNo;
			this.payee_RegNo = payee_RegNo;
			this.tax_IdentityNo = tax_IdentityNo;
			this.edition = edition;
			this.serialNo1 = serialNo1;
			this.serialNo2 = serialNo2;
			this.serialNo3 = serialNo3;
			this.serialNo4 = serialNo4;
			this.financialYear_ID = financialYear_ID;
			this.month_ID = month_ID;
			this.startDate = startDate;
			this.theme_ID = theme_ID;
			this.productKey = productKey;
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
		/// Gets or sets the CompanyName value.
		/// </summary>
		public string CompanyName {
			get { return companyName; }
			set { companyName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Address value.
		/// </summary>
		public string Address {
			get { return address; }
			set { address = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone1 value.
		/// </summary>
		public string Telephone1 {
			get { return telephone1; }
			set { telephone1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone2 value.
		/// </summary>
		public string Telephone2 {
			get { return telephone2; }
			set { telephone2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone3 value.
		/// </summary>
		public string Telephone3 {
			get { return telephone3; }
			set { telephone3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fax value.
		/// </summary>
		public string Fax {
			get { return fax; }
			set { fax = value; }
		}
		
		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email {
			get { return email; }
			set { email = value; }
		}
		
		/// <summary>
		/// Gets or sets the Url value.
		/// </summary>
		public string Url {
			get { return url; }
			set { url = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatRegisterNo value.
		/// </summary>
		public string VatRegisterNo {
			get { return vatRegisterNo; }
			set { vatRegisterNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyMDName value.
		/// </summary>
		public string CompanyMDName {
			get { return companyMDName; }
			set { companyMDName = value; }
		}
		
		/// <summary>
		/// Gets or sets the MdTelephone value.
		/// </summary>
		public string MdTelephone {
			get { return mdTelephone; }
			set { mdTelephone = value; }
		}
		
		/// <summary>
		/// Gets or sets the DatabaseName value.
		/// </summary>
		public string DatabaseName {
			get { return databaseName; }
			set { databaseName = value; }
		}
		
		/// <summary>
		/// Gets or sets the BusinessRegisterNo value.
		/// </summary>
		public string BusinessRegisterNo {
			get { return businessRegisterNo; }
			set { businessRegisterNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Epf_RegNo value.
		/// </summary>
		public string Epf_RegNo {
			get { return epf_RegNo; }
			set { epf_RegNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Etf_RegNo value.
		/// </summary>
		public string Etf_RegNo {
			get { return etf_RegNo; }
			set { etf_RegNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Payee_RegNo value.
		/// </summary>
		public string Payee_RegNo {
			get { return payee_RegNo; }
			set { payee_RegNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tax_IdentityNo value.
		/// </summary>
		public string Tax_IdentityNo {
			get { return tax_IdentityNo; }
			set { tax_IdentityNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Edition value.
		/// </summary>
		public int Edition {
			get { return edition; }
			set { edition = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNo1 value.
		/// </summary>
		public string SerialNo1 {
			get { return serialNo1; }
			set { serialNo1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNo2 value.
		/// </summary>
		public string SerialNo2 {
			get { return serialNo2; }
			set { serialNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNo3 value.
		/// </summary>
		public string SerialNo3 {
			get { return serialNo3; }
			set { serialNo3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNo4 value.
		/// </summary>
		public string SerialNo4 {
			get { return serialNo4; }
			set { serialNo4 = value; }
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
		/// Gets or sets the StartDate value.
		/// </summary>
		public DateTime StartDate {
			get { return startDate; }
			set { startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Theme_ID value.
		/// </summary>
		public int Theme_ID {
			get { return theme_ID; }
			set { theme_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductKey value.
		/// </summary>
		public string ProductKey {
			get { return productKey; }
			set { productKey = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genCompanyInfo table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyInfoInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@address", SqlDbType.VarChar,100);
			scom.Parameters.Add("@telephone1", SqlDbType.VarChar,25);
			scom.Parameters.Add("@telephone2", SqlDbType.VarChar,25);
			scom.Parameters.Add("@telephone3", SqlDbType.VarChar,25);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,25);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@url", SqlDbType.VarChar,50);
			scom.Parameters.Add("@vatRegisterNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyMDName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@mdTelephone", SqlDbType.VarChar,25);
			scom.Parameters.Add("@databaseName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@businessRegisterNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@epf_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@etf_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payee_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@tax_IdentityNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@edition", SqlDbType.Int,4);
			scom.Parameters.Add("@serialNo1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo3", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo4", SqlDbType.VarChar,50);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@theme_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@productKey", SqlDbType.VarChar,200);
 
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyName"].Value = companyName;
			scom.Parameters["@address"].Value = address;
			scom.Parameters["@telephone1"].Value = telephone1;
			scom.Parameters["@telephone2"].Value = telephone2;
			scom.Parameters["@telephone3"].Value = telephone3;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@url"].Value = url;
			scom.Parameters["@vatRegisterNo"].Value = vatRegisterNo;
			scom.Parameters["@companyMDName"].Value = companyMDName;
			scom.Parameters["@mdTelephone"].Value = mdTelephone;
			scom.Parameters["@databaseName"].Value = databaseName;
			scom.Parameters["@businessRegisterNo"].Value = businessRegisterNo;
			scom.Parameters["@epf_RegNo"].Value = epf_RegNo;
			scom.Parameters["@etf_RegNo"].Value = etf_RegNo;
			scom.Parameters["@payee_RegNo"].Value = payee_RegNo;
			scom.Parameters["@tax_IdentityNo"].Value = tax_IdentityNo;
			scom.Parameters["@edition"].Value = edition;
			scom.Parameters["@serialNo1"].Value = serialNo1;
			scom.Parameters["@serialNo2"].Value = serialNo2;
			scom.Parameters["@serialNo3"].Value = serialNo3;
			scom.Parameters["@serialNo4"].Value = serialNo4;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@theme_ID"].Value = theme_ID;
			scom.Parameters["@productKey"].Value = productKey;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCompanyInfo table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyInfoUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@address", SqlDbType.VarChar,100);
			scom.Parameters.Add("@telephone1", SqlDbType.VarChar,25);
			scom.Parameters.Add("@telephone2", SqlDbType.VarChar,25);
			scom.Parameters.Add("@telephone3", SqlDbType.VarChar,25);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,25);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@url", SqlDbType.VarChar,50);
			scom.Parameters.Add("@vatRegisterNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyMDName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@mdTelephone", SqlDbType.VarChar,25);
			scom.Parameters.Add("@databaseName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@businessRegisterNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@epf_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@etf_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payee_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@tax_IdentityNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@edition", SqlDbType.Int,4);
			scom.Parameters.Add("@serialNo1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo3", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo4", SqlDbType.VarChar,50);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@theme_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@productKey", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyName"].Value = companyName;
			scom.Parameters["@address"].Value = address;
			scom.Parameters["@telephone1"].Value = telephone1;
			scom.Parameters["@telephone2"].Value = telephone2;
			scom.Parameters["@telephone3"].Value = telephone3;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@url"].Value = url;
			scom.Parameters["@vatRegisterNo"].Value = vatRegisterNo;
			scom.Parameters["@companyMDName"].Value = companyMDName;
			scom.Parameters["@mdTelephone"].Value = mdTelephone;
			scom.Parameters["@databaseName"].Value = databaseName;
			scom.Parameters["@businessRegisterNo"].Value = businessRegisterNo;
			scom.Parameters["@epf_RegNo"].Value = epf_RegNo;
			scom.Parameters["@etf_RegNo"].Value = etf_RegNo;
			scom.Parameters["@payee_RegNo"].Value = payee_RegNo;
			scom.Parameters["@tax_IdentityNo"].Value = tax_IdentityNo;
			scom.Parameters["@edition"].Value = edition;
			scom.Parameters["@serialNo1"].Value = serialNo1;
			scom.Parameters["@serialNo2"].Value = serialNo2;
			scom.Parameters["@serialNo3"].Value = serialNo3;
			scom.Parameters["@serialNo4"].Value = serialNo4;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@theme_ID"].Value = theme_ID;
			scom.Parameters["@productKey"].Value = productKey;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCompanyInfo table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyInfoDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCompanyInfo table.
		/// </summary>
		public static tbl_genCompanyInfo Select(string companyID_Incoming){

			tbl_genCompanyInfo tbl_genCompanyInfoins = new tbl_genCompanyInfo();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyInfoSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCompanyInfoins = Maketbl_genCompanyInfo(dataReader);
				} else {
					tbl_genCompanyInfoins = null;
				}
			}
			scon.Close();
			return tbl_genCompanyInfoins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyInfo table.
		/// </summary>
		public static List<tbl_genCompanyInfo> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyInfoSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCompanyInfo> tbl_genCompanyInfoList = new List<tbl_genCompanyInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCompanyInfo tbl_genCompanyInfo = Maketbl_genCompanyInfo(dataReader);
					tbl_genCompanyInfoList.Add(tbl_genCompanyInfo);
				}
			}
			scon.Close();
			return tbl_genCompanyInfoList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCompanyInfo class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCompanyInfo Maketbl_genCompanyInfo(SqlDataReader dataReader) {
			tbl_genCompanyInfo tbl_genCompanyInfo = new tbl_genCompanyInfo();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCompanyInfo.CompanyID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCompanyInfo.CompanyName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCompanyInfo.Address = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genCompanyInfo.Telephone1 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genCompanyInfo.Telephone2 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genCompanyInfo.Telephone3 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genCompanyInfo.Fax = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genCompanyInfo.Email = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genCompanyInfo.Url = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genCompanyInfo.VatRegisterNo = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genCompanyInfo.CompanyMDName = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genCompanyInfo.MdTelephone = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genCompanyInfo.DatabaseName = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genCompanyInfo.BusinessRegisterNo = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genCompanyInfo.Epf_RegNo = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genCompanyInfo.Etf_RegNo = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genCompanyInfo.Payee_RegNo = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genCompanyInfo.Tax_IdentityNo = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genCompanyInfo.Edition = dataReader.GetInt32(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genCompanyInfo.SerialNo1 = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genCompanyInfo.SerialNo2 = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genCompanyInfo.SerialNo3 = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genCompanyInfo.SerialNo4 = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genCompanyInfo.FinancialYear_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genCompanyInfo.Month_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_genCompanyInfo.StartDate = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_genCompanyInfo.Theme_ID = dataReader.GetInt32(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_genCompanyInfo.ProductKey = dataReader.GetString(27);
			}

			return tbl_genCompanyInfo;
		}
		/// <summary>
		/// This makes tbl_genCompanyInfo datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCompanyInfo object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCompanyInfo  tbl_genCompanyInfo   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyName = new DataColumn("companyName" , typeof(string));
			DataColumn col_address = new DataColumn("address" , typeof(string));
			DataColumn col_telephone1 = new DataColumn("telephone1" , typeof(string));
			DataColumn col_telephone2 = new DataColumn("telephone2" , typeof(string));
			DataColumn col_telephone3 = new DataColumn("telephone3" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_email = new DataColumn("email" , typeof(string));
			DataColumn col_url = new DataColumn("url" , typeof(string));
			DataColumn col_vatRegisterNo = new DataColumn("vatRegisterNo" , typeof(string));
			DataColumn col_companyMDName = new DataColumn("companyMDName" , typeof(string));
			DataColumn col_mdTelephone = new DataColumn("mdTelephone" , typeof(string));
			DataColumn col_databaseName = new DataColumn("databaseName" , typeof(string));
			DataColumn col_businessRegisterNo = new DataColumn("businessRegisterNo" , typeof(string));
			DataColumn col_epf_RegNo = new DataColumn("epf_RegNo" , typeof(string));
			DataColumn col_etf_RegNo = new DataColumn("etf_RegNo" , typeof(string));
			DataColumn col_payee_RegNo = new DataColumn("payee_RegNo" , typeof(string));
			DataColumn col_tax_IdentityNo = new DataColumn("tax_IdentityNo" , typeof(string));
			DataColumn col_edition = new DataColumn("edition" , typeof(int));
			DataColumn col_serialNo1 = new DataColumn("serialNo1" , typeof(string));
			DataColumn col_serialNo2 = new DataColumn("serialNo2" , typeof(string));
			DataColumn col_serialNo3 = new DataColumn("serialNo3" , typeof(string));
			DataColumn col_serialNo4 = new DataColumn("serialNo4" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(string));
			DataColumn col_startDate = new DataColumn("startDate" , typeof(DateTime));
			DataColumn col_theme_ID = new DataColumn("theme_ID" , typeof(int));
			DataColumn col_productKey = new DataColumn("productKey" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_companyID,col_companyName,col_address,col_telephone1,col_telephone2,col_telephone3,col_fax,col_email,col_url,col_vatRegisterNo,col_companyMDName,col_mdTelephone,col_databaseName,col_businessRegisterNo,col_epf_RegNo,col_etf_RegNo,col_payee_RegNo,col_tax_IdentityNo,col_edition,col_serialNo1,col_serialNo2,col_serialNo3,col_serialNo4,col_financialYear_ID,col_month_ID,col_startDate,col_theme_ID,col_productKey,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCompanyInfo datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCompanyInfo object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCompanyInfo user) {
		DataRow drow = dt.NewRow();
		
			drow["companyID"] = user.companyID;
			drow["companyName"] = user.companyName;
			drow["address"] = user.address;
			drow["telephone1"] = user.telephone1;
			drow["telephone2"] = user.telephone2;
			drow["telephone3"] = user.telephone3;
			drow["fax"] = user.fax;
			drow["email"] = user.email;
			drow["url"] = user.url;
			drow["vatRegisterNo"] = user.vatRegisterNo;
			drow["companyMDName"] = user.companyMDName;
			drow["mdTelephone"] = user.mdTelephone;
			drow["databaseName"] = user.databaseName;
			drow["businessRegisterNo"] = user.businessRegisterNo;
			drow["epf_RegNo"] = user.epf_RegNo;
			drow["etf_RegNo"] = user.etf_RegNo;
			drow["payee_RegNo"] = user.payee_RegNo;
			drow["tax_IdentityNo"] = user.tax_IdentityNo;
			drow["edition"] = user.edition;
			drow["serialNo1"] = user.serialNo1;
			drow["serialNo2"] = user.serialNo2;
			drow["serialNo3"] = user.serialNo3;
			drow["serialNo4"] = user.serialNo4;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["month_ID"] = user.month_ID;
			drow["startDate"] = user.startDate;
			drow["theme_ID"] = user.theme_ID;
			drow["productKey"] = user.productKey;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
