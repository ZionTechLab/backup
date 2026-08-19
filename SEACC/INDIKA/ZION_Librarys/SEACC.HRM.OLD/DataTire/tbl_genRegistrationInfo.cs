using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genRegistrationInfo {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string reg_ID;
		private string companyCode;
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
		private string businessRegisterNo;
		private string epf_RegNo;
		private string etf_RegNo;
		private string payee_RegNo;
		private string tax_IdentityNo;
		private string serialNo1;
		private string serialNo2;
		private string serialNo3;
		private string serialNo4;
		private byte[] mainLogo;
		private byte[] logoOnly;
		private byte[] textOnly;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genRegistrationInfo class.
		/// </summary>
		public tbl_genRegistrationInfo() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genRegistrationInfo class.
		/// </summary>
		public tbl_genRegistrationInfo(string company_ID, string companyBranch_ID, string reg_ID, string companyCode, string companyName, string address, string telephone1, string telephone2, string telephone3, string fax, string email, string url, string vatRegisterNo, string companyMDName, string mdTelephone, string businessRegisterNo, string epf_RegNo, string etf_RegNo, string payee_RegNo, string tax_IdentityNo, string serialNo1, string serialNo2, string serialNo3, string serialNo4, byte[] mainLogo, byte[] logoOnly, byte[] textOnly) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.reg_ID = reg_ID;
			this.companyCode = companyCode;
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
			this.businessRegisterNo = businessRegisterNo;
			this.epf_RegNo = epf_RegNo;
			this.etf_RegNo = etf_RegNo;
			this.payee_RegNo = payee_RegNo;
			this.tax_IdentityNo = tax_IdentityNo;
			this.serialNo1 = serialNo1;
			this.serialNo2 = serialNo2;
			this.serialNo3 = serialNo3;
			this.serialNo4 = serialNo4;
			this.mainLogo = mainLogo;
			this.logoOnly = logoOnly;
			this.textOnly = textOnly;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Company_ID value.
		/// </summary>
		public string Company_ID {
			get { return company_ID; }
			set { company_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Reg_ID value.
		/// </summary>
		public string Reg_ID {
			get { return reg_ID; }
			set { reg_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyCode value.
		/// </summary>
		public string CompanyCode {
			get { return companyCode; }
			set { companyCode = value; }
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
		/// Gets or sets the MainLogo value.
		/// </summary>
		public byte[] MainLogo {
			get { return mainLogo; }
			set { mainLogo = value; }
		}
		
		/// <summary>
		/// Gets or sets the LogoOnly value.
		/// </summary>
		public byte[] LogoOnly {
			get { return logoOnly; }
			set { logoOnly = value; }
		}
		
		/// <summary>
		/// Gets or sets the TextOnly value.
		/// </summary>
		public byte[] TextOnly {
			get { return textOnly; }
			set { textOnly = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genRegistrationInfo table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRegistrationInfoInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reg_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyCode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@address", SqlDbType.VarChar,200);
			scom.Parameters.Add("@telephone1", SqlDbType.VarChar,25);
			scom.Parameters.Add("@telephone2", SqlDbType.VarChar,25);
			scom.Parameters.Add("@telephone3", SqlDbType.VarChar,25);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,25);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@url", SqlDbType.VarChar,50);
			scom.Parameters.Add("@vatRegisterNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyMDName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@mdTelephone", SqlDbType.VarChar,25);
			scom.Parameters.Add("@businessRegisterNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@epf_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@etf_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payee_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@tax_IdentityNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo3", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo4", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mainLogo", SqlDbType.Image);
			scom.Parameters.Add("@logoOnly", SqlDbType.Image);
			scom.Parameters.Add("@textOnly", SqlDbType.Image);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@reg_ID"].Value = reg_ID;
			scom.Parameters["@companyCode"].Value = companyCode;
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
			scom.Parameters["@businessRegisterNo"].Value = businessRegisterNo;
			scom.Parameters["@epf_RegNo"].Value = epf_RegNo;
			scom.Parameters["@etf_RegNo"].Value = etf_RegNo;
			scom.Parameters["@payee_RegNo"].Value = payee_RegNo;
			scom.Parameters["@tax_IdentityNo"].Value = tax_IdentityNo;
			scom.Parameters["@serialNo1"].Value = serialNo1;
			scom.Parameters["@serialNo2"].Value = serialNo2;
			scom.Parameters["@serialNo3"].Value = serialNo3;
			scom.Parameters["@serialNo4"].Value = serialNo4;
			scom.Parameters["@mainLogo"].Value = mainLogo;
			scom.Parameters["@logoOnly"].Value = logoOnly;
			scom.Parameters["@textOnly"].Value = textOnly;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genRegistrationInfo table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRegistrationInfoUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reg_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyCode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@address", SqlDbType.VarChar,200);
			scom.Parameters.Add("@telephone1", SqlDbType.VarChar,25);
			scom.Parameters.Add("@telephone2", SqlDbType.VarChar,25);
			scom.Parameters.Add("@telephone3", SqlDbType.VarChar,25);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,25);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@url", SqlDbType.VarChar,50);
			scom.Parameters.Add("@vatRegisterNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyMDName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@mdTelephone", SqlDbType.VarChar,25);
			scom.Parameters.Add("@businessRegisterNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@epf_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@etf_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payee_RegNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@tax_IdentityNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo3", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo4", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mainLogo", SqlDbType.Image);
			scom.Parameters.Add("@logoOnly", SqlDbType.Image);
			scom.Parameters.Add("@textOnly", SqlDbType.Image);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@reg_ID"].Value = reg_ID;
			scom.Parameters["@companyCode"].Value = companyCode;
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
			scom.Parameters["@businessRegisterNo"].Value = businessRegisterNo;
			scom.Parameters["@epf_RegNo"].Value = epf_RegNo;
			scom.Parameters["@etf_RegNo"].Value = etf_RegNo;
			scom.Parameters["@payee_RegNo"].Value = payee_RegNo;
			scom.Parameters["@tax_IdentityNo"].Value = tax_IdentityNo;
			scom.Parameters["@serialNo1"].Value = serialNo1;
			scom.Parameters["@serialNo2"].Value = serialNo2;
			scom.Parameters["@serialNo3"].Value = serialNo3;
			scom.Parameters["@serialNo4"].Value = serialNo4;
			scom.Parameters["@mainLogo"].Value = mainLogo;
			scom.Parameters["@logoOnly"].Value = logoOnly;
			scom.Parameters["@textOnly"].Value = textOnly;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genRegistrationInfo table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRegistrationInfoDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reg_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@reg_ID"].Value = reg_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRegistrationInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRegistrationInfoDeleteAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRegistrationInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Reg_ID(string company_ID, string companyBranch_ID, string reg_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRegistrationInfoDeleteAllByCompany_ID_CompanyBranch_ID_Reg_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reg_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@reg_ID"].Value = reg_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genRegistrationInfo table.
		/// </summary>
		public static tbl_genRegistrationInfo Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string reg_ID_Incoming){

			tbl_genRegistrationInfo tbl_genRegistrationInfoins = new tbl_genRegistrationInfo();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRegistrationInfoSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reg_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@reg_ID"].Value = reg_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genRegistrationInfoins = Maketbl_genRegistrationInfo(dataReader);
				} else {
					tbl_genRegistrationInfoins = null;
				}
			}
			scon.Close();
			return tbl_genRegistrationInfoins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRegistrationInfo table.
		/// </summary>
		public static List<tbl_genRegistrationInfo> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRegistrationInfoSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genRegistrationInfo> tbl_genRegistrationInfoList = new List<tbl_genRegistrationInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRegistrationInfo tbl_genRegistrationInfo = Maketbl_genRegistrationInfo(dataReader);
					tbl_genRegistrationInfoList.Add(tbl_genRegistrationInfo);
				}
			}
			scon.Close();
			return tbl_genRegistrationInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRegistrationInfo table by a foreign key.
		/// </summary>
		public static List<tbl_genRegistrationInfo> SelectAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRegistrationInfoSelectAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
				List<tbl_genRegistrationInfo> tbl_genRegistrationInfoList = new List<tbl_genRegistrationInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRegistrationInfo tbl_genRegistrationInfo = Maketbl_genRegistrationInfo(dataReader);
					tbl_genRegistrationInfoList.Add(tbl_genRegistrationInfo);
				}
			}
			scon.Close();
			return tbl_genRegistrationInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genRegistrationInfo table by a foreign key.
		/// </summary>
		public static List<tbl_genRegistrationInfo> SelectAllByCompany_ID_CompanyBranch_ID_Reg_ID(string company_ID, string companyBranch_ID, string reg_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genRegistrationInfoSelectAllByCompany_ID_CompanyBranch_ID_Reg_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reg_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@reg_ID"].Value = reg_ID;
				List<tbl_genRegistrationInfo> tbl_genRegistrationInfoList = new List<tbl_genRegistrationInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genRegistrationInfo tbl_genRegistrationInfo = Maketbl_genRegistrationInfo(dataReader);
					tbl_genRegistrationInfoList.Add(tbl_genRegistrationInfo);
				}
			}
			scon.Close();
			return tbl_genRegistrationInfoList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genRegistrationInfo class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genRegistrationInfo Maketbl_genRegistrationInfo(SqlDataReader dataReader) {
			tbl_genRegistrationInfo tbl_genRegistrationInfo = new tbl_genRegistrationInfo();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genRegistrationInfo.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genRegistrationInfo.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genRegistrationInfo.Reg_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genRegistrationInfo.CompanyCode = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genRegistrationInfo.CompanyName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genRegistrationInfo.Address = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genRegistrationInfo.Telephone1 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genRegistrationInfo.Telephone2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genRegistrationInfo.Telephone3 = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genRegistrationInfo.Fax = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genRegistrationInfo.Email = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genRegistrationInfo.Url = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genRegistrationInfo.VatRegisterNo = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genRegistrationInfo.CompanyMDName = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genRegistrationInfo.MdTelephone = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genRegistrationInfo.BusinessRegisterNo = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genRegistrationInfo.Epf_RegNo = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genRegistrationInfo.Etf_RegNo = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genRegistrationInfo.Payee_RegNo = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genRegistrationInfo.Tax_IdentityNo = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genRegistrationInfo.SerialNo1 = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genRegistrationInfo.SerialNo2 = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genRegistrationInfo.SerialNo3 = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genRegistrationInfo.SerialNo4 = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genRegistrationInfo.MainLogo = (byte[])dataReader[24];
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_genRegistrationInfo.LogoOnly = (byte[])dataReader[25];
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_genRegistrationInfo.TextOnly = (byte[])dataReader[26];
			}

			return tbl_genRegistrationInfo;
		}
		/// <summary>
		/// This makes tbl_genRegistrationInfo datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genRegistrationInfo object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genRegistrationInfo  tbl_genRegistrationInfo   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_reg_ID = new DataColumn("reg_ID" , typeof(string));
			DataColumn col_companyCode = new DataColumn("companyCode" , typeof(string));
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
			DataColumn col_businessRegisterNo = new DataColumn("businessRegisterNo" , typeof(string));
			DataColumn col_epf_RegNo = new DataColumn("epf_RegNo" , typeof(string));
			DataColumn col_etf_RegNo = new DataColumn("etf_RegNo" , typeof(string));
			DataColumn col_payee_RegNo = new DataColumn("payee_RegNo" , typeof(string));
			DataColumn col_tax_IdentityNo = new DataColumn("tax_IdentityNo" , typeof(string));
			DataColumn col_serialNo1 = new DataColumn("serialNo1" , typeof(string));
			DataColumn col_serialNo2 = new DataColumn("serialNo2" , typeof(string));
			DataColumn col_serialNo3 = new DataColumn("serialNo3" , typeof(string));
			DataColumn col_serialNo4 = new DataColumn("serialNo4" , typeof(string));
			DataColumn col_mainLogo = new DataColumn("mainLogo" , typeof(byte[]));
			DataColumn col_logoOnly = new DataColumn("logoOnly" , typeof(byte[]));
			DataColumn col_textOnly = new DataColumn("textOnly" , typeof(byte[]));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_reg_ID,col_companyCode,col_companyName,col_address,col_telephone1,col_telephone2,col_telephone3,col_fax,col_email,col_url,col_vatRegisterNo,col_companyMDName,col_mdTelephone,col_businessRegisterNo,col_epf_RegNo,col_etf_RegNo,col_payee_RegNo,col_tax_IdentityNo,col_serialNo1,col_serialNo2,col_serialNo3,col_serialNo4,col_mainLogo,col_logoOnly,col_textOnly,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genRegistrationInfo datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genRegistrationInfo object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genRegistrationInfo user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["reg_ID"] = user.reg_ID;
			drow["companyCode"] = user.companyCode;
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
			drow["businessRegisterNo"] = user.businessRegisterNo;
			drow["epf_RegNo"] = user.epf_RegNo;
			drow["etf_RegNo"] = user.etf_RegNo;
			drow["payee_RegNo"] = user.payee_RegNo;
			drow["tax_IdentityNo"] = user.tax_IdentityNo;
			drow["serialNo1"] = user.serialNo1;
			drow["serialNo2"] = user.serialNo2;
			drow["serialNo3"] = user.serialNo3;
			drow["serialNo4"] = user.serialNo4;
			drow["mainLogo"] = user.mainLogo;
			drow["logoOnly"] = user.logoOnly;
			drow["textOnly"] = user.textOnly;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
