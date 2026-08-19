using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genBrokerMaster {
		#region Fields
		private string broker_ID;
		private string brokerCode;
		private string brokerName;
		private string addressRegister;
		private string addressDelivery;
		private string telephone;
		private string mobile;
		private string fax;
		private string email;
		private string url;
		private string businessRegistraionNo;
		private string vatRegistrationNo;
		private string nbtRegistrationNo;
		private string svatRegistrationNo;
		private string remark;
		private bool isBlacklisted;
		private bool isLocked;
		private bool isDeleted;
		private string country_ID;
		private string province_ID;
		private string district_ID;
		private string city_ID;
		private string town_ID;
		private string area_ID;
		private string route_ID;
		private string brokerType_ID;
		private string brokerCategory_ID;
		private string brokerClass_ID;
		private string currency_ID;
		private string salesManager_ID;
		private string areaManager_ID;
		private string salesRep_ID;
		private string salesExecutive_ID;
		private string gl_ID;
		private string companyBranch_ID;
		private bool isVATenable;
		private bool isSVATenable;
		private bool isNBTenable;
		private bool isBrokerPricingEnable;
		private string title;
		private string nicNo;
		private DateTime dateOfBirth;
		private string brokerAccountType_ID;
		private bool isPostingEnable_VAT;
		private bool isPostingEnable_NBT;
		private string salesReturnedGL_ID;
		private decimal brokerPercentage;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genBrokerMaster class.
		/// </summary>
		public tbl_genBrokerMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genBrokerMaster class.
		/// </summary>
		public tbl_genBrokerMaster(string broker_ID, string brokerCode, string brokerName, string addressRegister, string addressDelivery, string telephone, string mobile, string fax, string email, string url, string businessRegistraionNo, string vatRegistrationNo, string nbtRegistrationNo, string svatRegistrationNo, string remark, bool isBlacklisted, bool isLocked, bool isDeleted, string country_ID, string province_ID, string district_ID, string city_ID, string town_ID, string area_ID, string route_ID, string brokerType_ID, string brokerCategory_ID, string brokerClass_ID, string currency_ID, string salesManager_ID, string areaManager_ID, string salesRep_ID, string salesExecutive_ID, string gl_ID, string companyBranch_ID, bool isVATenable, bool isSVATenable, bool isNBTenable, bool isBrokerPricingEnable, string title, string nicNo, DateTime dateOfBirth, string brokerAccountType_ID, bool isPostingEnable_VAT, bool isPostingEnable_NBT, string salesReturnedGL_ID, decimal brokerPercentage) {
			this.broker_ID = broker_ID;
			this.brokerCode = brokerCode;
			this.brokerName = brokerName;
			this.addressRegister = addressRegister;
			this.addressDelivery = addressDelivery;
			this.telephone = telephone;
			this.mobile = mobile;
			this.fax = fax;
			this.email = email;
			this.url = url;
			this.businessRegistraionNo = businessRegistraionNo;
			this.vatRegistrationNo = vatRegistrationNo;
			this.nbtRegistrationNo = nbtRegistrationNo;
			this.svatRegistrationNo = svatRegistrationNo;
			this.remark = remark;
			this.isBlacklisted = isBlacklisted;
			this.isLocked = isLocked;
			this.isDeleted = isDeleted;
			this.country_ID = country_ID;
			this.province_ID = province_ID;
			this.district_ID = district_ID;
			this.city_ID = city_ID;
			this.town_ID = town_ID;
			this.area_ID = area_ID;
			this.route_ID = route_ID;
			this.brokerType_ID = brokerType_ID;
			this.brokerCategory_ID = brokerCategory_ID;
			this.brokerClass_ID = brokerClass_ID;
			this.currency_ID = currency_ID;
			this.salesManager_ID = salesManager_ID;
			this.areaManager_ID = areaManager_ID;
			this.salesRep_ID = salesRep_ID;
			this.salesExecutive_ID = salesExecutive_ID;
			this.gl_ID = gl_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.isVATenable = isVATenable;
			this.isSVATenable = isSVATenable;
			this.isNBTenable = isNBTenable;
			this.isBrokerPricingEnable = isBrokerPricingEnable;
			this.title = title;
			this.nicNo = nicNo;
			this.dateOfBirth = dateOfBirth;
			this.brokerAccountType_ID = brokerAccountType_ID;
			this.isPostingEnable_VAT = isPostingEnable_VAT;
			this.isPostingEnable_NBT = isPostingEnable_NBT;
			this.salesReturnedGL_ID = salesReturnedGL_ID;
			this.brokerPercentage = brokerPercentage;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Broker_ID value.
		/// </summary>
		public string Broker_ID {
			get { return broker_ID; }
			set { broker_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BrokerCode value.
		/// </summary>
		public string BrokerCode {
			get { return brokerCode; }
			set { brokerCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the BrokerName value.
		/// </summary>
		public string BrokerName {
			get { return brokerName; }
			set { brokerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the AddressRegister value.
		/// </summary>
		public string AddressRegister {
			get { return addressRegister; }
			set { addressRegister = value; }
		}
		
		/// <summary>
		/// Gets or sets the AddressDelivery value.
		/// </summary>
		public string AddressDelivery {
			get { return addressDelivery; }
			set { addressDelivery = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone value.
		/// </summary>
		public string Telephone {
			get { return telephone; }
			set { telephone = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mobile value.
		/// </summary>
		public string Mobile {
			get { return mobile; }
			set { mobile = value; }
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
		/// Gets or sets the BusinessRegistraionNo value.
		/// </summary>
		public string BusinessRegistraionNo {
			get { return businessRegistraionNo; }
			set { businessRegistraionNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatRegistrationNo value.
		/// </summary>
		public string VatRegistrationNo {
			get { return vatRegistrationNo; }
			set { vatRegistrationNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the NbtRegistrationNo value.
		/// </summary>
		public string NbtRegistrationNo {
			get { return nbtRegistrationNo; }
			set { nbtRegistrationNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the SvatRegistrationNo value.
		/// </summary>
		public string SvatRegistrationNo {
			get { return svatRegistrationNo; }
			set { svatRegistrationNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBlacklisted value.
		/// </summary>
		public bool IsBlacklisted {
			get { return isBlacklisted; }
			set { isBlacklisted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the Country_ID value.
		/// </summary>
		public string Country_ID {
			get { return country_ID; }
			set { country_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Province_ID value.
		/// </summary>
		public string Province_ID {
			get { return province_ID; }
			set { province_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the District_ID value.
		/// </summary>
		public string District_ID {
			get { return district_ID; }
			set { district_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the City_ID value.
		/// </summary>
		public string City_ID {
			get { return city_ID; }
			set { city_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Town_ID value.
		/// </summary>
		public string Town_ID {
			get { return town_ID; }
			set { town_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Area_ID value.
		/// </summary>
		public string Area_ID {
			get { return area_ID; }
			set { area_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Route_ID value.
		/// </summary>
		public string Route_ID {
			get { return route_ID; }
			set { route_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BrokerType_ID value.
		/// </summary>
		public string BrokerType_ID {
			get { return brokerType_ID; }
			set { brokerType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BrokerCategory_ID value.
		/// </summary>
		public string BrokerCategory_ID {
			get { return brokerCategory_ID; }
			set { brokerCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BrokerClass_ID value.
		/// </summary>
		public string BrokerClass_ID {
			get { return brokerClass_ID; }
			set { brokerClass_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesManager_ID value.
		/// </summary>
		public string SalesManager_ID {
			get { return salesManager_ID; }
			set { salesManager_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AreaManager_ID value.
		/// </summary>
		public string AreaManager_ID {
			get { return areaManager_ID; }
			set { areaManager_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesRep_ID value.
		/// </summary>
		public string SalesRep_ID {
			get { return salesRep_ID; }
			set { salesRep_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesExecutive_ID value.
		/// </summary>
		public string SalesExecutive_ID {
			get { return salesExecutive_ID; }
			set { salesExecutive_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsVATenable value.
		/// </summary>
		public bool IsVATenable {
			get { return isVATenable; }
			set { isVATenable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSVATenable value.
		/// </summary>
		public bool IsSVATenable {
			get { return isSVATenable; }
			set { isSVATenable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsNBTenable value.
		/// </summary>
		public bool IsNBTenable {
			get { return isNBTenable; }
			set { isNBTenable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBrokerPricingEnable value.
		/// </summary>
		public bool IsBrokerPricingEnable {
			get { return isBrokerPricingEnable; }
			set { isBrokerPricingEnable = value; }
		}
		
		/// <summary>
		/// Gets or sets the Title value.
		/// </summary>
		public string Title {
			get { return title; }
			set { title = value; }
		}
		
		/// <summary>
		/// Gets or sets the NicNo value.
		/// </summary>
		public string NicNo {
			get { return nicNo; }
			set { nicNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateOfBirth value.
		/// </summary>
		public DateTime DateOfBirth {
			get { return dateOfBirth; }
			set { dateOfBirth = value; }
		}
		
		/// <summary>
		/// Gets or sets the BrokerAccountType_ID value.
		/// </summary>
		public string BrokerAccountType_ID {
			get { return brokerAccountType_ID; }
			set { brokerAccountType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPostingEnable_VAT value.
		/// </summary>
		public bool IsPostingEnable_VAT {
			get { return isPostingEnable_VAT; }
			set { isPostingEnable_VAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPostingEnable_NBT value.
		/// </summary>
		public bool IsPostingEnable_NBT {
			get { return isPostingEnable_NBT; }
			set { isPostingEnable_NBT = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesReturnedGL_ID value.
		/// </summary>
		public string SalesReturnedGL_ID {
			get { return salesReturnedGL_ID; }
			set { salesReturnedGL_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BrokerPercentage value.
		/// </summary>
		public decimal BrokerPercentage {
			get { return brokerPercentage; }
			set { brokerPercentage = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genBrokerMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genBrokerMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@broker_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brokerCode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@brokerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@addressRegister", SqlDbType.VarChar,100);
			scom.Parameters.Add("@addressDelivery", SqlDbType.VarChar,100);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mobile", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@url", SqlDbType.VarChar,50);
			scom.Parameters.Add("@businessRegistraionNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@vatRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nbtRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@svatRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isBlacklisted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@area_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brokerType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brokerCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brokerClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesExecutive_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isVATenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVATenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBrokerPricingEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@title", SqlDbType.VarChar,20);
			scom.Parameters.Add("@nicNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateOfBirth", SqlDbType.DateTime,8);
			scom.Parameters.Add("@brokerAccountType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isPostingEnable_VAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPostingEnable_NBT", SqlDbType.Bit,1);
			scom.Parameters.Add("@salesReturnedGL_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brokerPercentage", SqlDbType.Decimal,9);
 
			scom.Parameters["@broker_ID"].Value = broker_ID;
			scom.Parameters["@brokerCode"].Value = brokerCode;
			scom.Parameters["@brokerName"].Value = brokerName;
			scom.Parameters["@addressRegister"].Value = addressRegister;
			scom.Parameters["@addressDelivery"].Value = addressDelivery;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@mobile"].Value = mobile;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@url"].Value = url;
			scom.Parameters["@businessRegistraionNo"].Value = businessRegistraionNo;
			scom.Parameters["@vatRegistrationNo"].Value = vatRegistrationNo;
			scom.Parameters["@nbtRegistrationNo"].Value = nbtRegistrationNo;
			scom.Parameters["@svatRegistrationNo"].Value = svatRegistrationNo;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isBlacklisted"].Value = isBlacklisted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@province_ID"].Value = province_ID;
			scom.Parameters["@district_ID"].Value = district_ID;
			scom.Parameters["@city_ID"].Value = city_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@area_ID"].Value = area_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@brokerType_ID"].Value = brokerType_ID;
			scom.Parameters["@brokerCategory_ID"].Value = brokerCategory_ID;
			scom.Parameters["@brokerClass_ID"].Value = brokerClass_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
			scom.Parameters["@salesExecutive_ID"].Value = salesExecutive_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isVATenable"].Value = isVATenable;
			scom.Parameters["@isSVATenable"].Value = isSVATenable;
			scom.Parameters["@isNBTenable"].Value = isNBTenable;
			scom.Parameters["@isBrokerPricingEnable"].Value = isBrokerPricingEnable;
			scom.Parameters["@title"].Value = title;
			scom.Parameters["@nicNo"].Value = nicNo;
			scom.Parameters["@dateOfBirth"].Value = dateOfBirth;
			scom.Parameters["@brokerAccountType_ID"].Value = brokerAccountType_ID;
			scom.Parameters["@isPostingEnable_VAT"].Value = isPostingEnable_VAT;
			scom.Parameters["@isPostingEnable_NBT"].Value = isPostingEnable_NBT;
			scom.Parameters["@salesReturnedGL_ID"].Value = salesReturnedGL_ID;
			scom.Parameters["@brokerPercentage"].Value = brokerPercentage;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genBrokerMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genBrokerMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@broker_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brokerCode", SqlDbType.VarChar,50);
			scom.Parameters.Add("@brokerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@addressRegister", SqlDbType.VarChar,100);
			scom.Parameters.Add("@addressDelivery", SqlDbType.VarChar,100);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@mobile", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@url", SqlDbType.VarChar,50);
			scom.Parameters.Add("@businessRegistraionNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@vatRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nbtRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@svatRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isBlacklisted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@area_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brokerType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brokerCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brokerClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesExecutive_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isVATenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVATenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBrokerPricingEnable", SqlDbType.Bit,1);
			scom.Parameters.Add("@title", SqlDbType.VarChar,20);
			scom.Parameters.Add("@nicNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateOfBirth", SqlDbType.DateTime,8);
			scom.Parameters.Add("@brokerAccountType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isPostingEnable_VAT", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPostingEnable_NBT", SqlDbType.Bit,1);
			scom.Parameters.Add("@salesReturnedGL_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brokerPercentage", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@broker_ID"].Value = broker_ID;
			scom.Parameters["@brokerCode"].Value = brokerCode;
			scom.Parameters["@brokerName"].Value = brokerName;
			scom.Parameters["@addressRegister"].Value = addressRegister;
			scom.Parameters["@addressDelivery"].Value = addressDelivery;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@mobile"].Value = mobile;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@url"].Value = url;
			scom.Parameters["@businessRegistraionNo"].Value = businessRegistraionNo;
			scom.Parameters["@vatRegistrationNo"].Value = vatRegistrationNo;
			scom.Parameters["@nbtRegistrationNo"].Value = nbtRegistrationNo;
			scom.Parameters["@svatRegistrationNo"].Value = svatRegistrationNo;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isBlacklisted"].Value = isBlacklisted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@province_ID"].Value = province_ID;
			scom.Parameters["@district_ID"].Value = district_ID;
			scom.Parameters["@city_ID"].Value = city_ID;
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@area_ID"].Value = area_ID;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@brokerType_ID"].Value = brokerType_ID;
			scom.Parameters["@brokerCategory_ID"].Value = brokerCategory_ID;
			scom.Parameters["@brokerClass_ID"].Value = brokerClass_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
			scom.Parameters["@salesExecutive_ID"].Value = salesExecutive_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isVATenable"].Value = isVATenable;
			scom.Parameters["@isSVATenable"].Value = isSVATenable;
			scom.Parameters["@isNBTenable"].Value = isNBTenable;
			scom.Parameters["@isBrokerPricingEnable"].Value = isBrokerPricingEnable;
			scom.Parameters["@title"].Value = title;
			scom.Parameters["@nicNo"].Value = nicNo;
			scom.Parameters["@dateOfBirth"].Value = dateOfBirth;
			scom.Parameters["@brokerAccountType_ID"].Value = brokerAccountType_ID;
			scom.Parameters["@isPostingEnable_VAT"].Value = isPostingEnable_VAT;
			scom.Parameters["@isPostingEnable_NBT"].Value = isPostingEnable_NBT;
			scom.Parameters["@salesReturnedGL_ID"].Value = salesReturnedGL_ID;
			scom.Parameters["@brokerPercentage"].Value = brokerPercentage;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genBrokerMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genBrokerMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@broker_ID", SqlDbType.VarChar,20);
			scom.Parameters["@broker_ID"].Value = broker_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genBrokerMaster table.
		/// </summary>
		public static tbl_genBrokerMaster Select(string broker_ID_Incoming){

			tbl_genBrokerMaster tbl_genBrokerMasterins = new tbl_genBrokerMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genBrokerMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@broker_ID", SqlDbType.VarChar,20);
			scom.Parameters["@broker_ID"].Value = broker_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genBrokerMasterins = Maketbl_genBrokerMaster(dataReader);
				} else {
					tbl_genBrokerMasterins = null;
				}
			}
			scon.Close();
			return tbl_genBrokerMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genBrokerMaster table.
		/// </summary>
		public static List<tbl_genBrokerMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genBrokerMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genBrokerMaster> tbl_genBrokerMasterList = new List<tbl_genBrokerMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genBrokerMaster tbl_genBrokerMaster = Maketbl_genBrokerMaster(dataReader);
					tbl_genBrokerMasterList.Add(tbl_genBrokerMaster);
				}
			}
			scon.Close();
			return tbl_genBrokerMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genBrokerMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genBrokerMaster Maketbl_genBrokerMaster(SqlDataReader dataReader) {
			tbl_genBrokerMaster tbl_genBrokerMaster = new tbl_genBrokerMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genBrokerMaster.Broker_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genBrokerMaster.BrokerCode = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genBrokerMaster.BrokerName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genBrokerMaster.AddressRegister = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genBrokerMaster.AddressDelivery = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genBrokerMaster.Telephone = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genBrokerMaster.Mobile = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genBrokerMaster.Fax = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genBrokerMaster.Email = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genBrokerMaster.Url = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genBrokerMaster.BusinessRegistraionNo = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genBrokerMaster.VatRegistrationNo = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genBrokerMaster.NbtRegistrationNo = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genBrokerMaster.SvatRegistrationNo = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genBrokerMaster.Remark = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genBrokerMaster.IsBlacklisted = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genBrokerMaster.IsLocked = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genBrokerMaster.IsDeleted = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genBrokerMaster.Country_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genBrokerMaster.Province_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genBrokerMaster.District_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genBrokerMaster.City_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genBrokerMaster.Town_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genBrokerMaster.Area_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genBrokerMaster.Route_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_genBrokerMaster.BrokerType_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_genBrokerMaster.BrokerCategory_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_genBrokerMaster.BrokerClass_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_genBrokerMaster.Currency_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_genBrokerMaster.SalesManager_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_genBrokerMaster.AreaManager_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_genBrokerMaster.SalesRep_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_genBrokerMaster.SalesExecutive_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_genBrokerMaster.Gl_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_genBrokerMaster.CompanyBranch_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_genBrokerMaster.IsVATenable = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_genBrokerMaster.IsSVATenable = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_genBrokerMaster.IsNBTenable = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_genBrokerMaster.IsBrokerPricingEnable = dataReader.GetBoolean(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_genBrokerMaster.Title = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_genBrokerMaster.NicNo = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_genBrokerMaster.DateOfBirth = dataReader.GetDateTime(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_genBrokerMaster.BrokerAccountType_ID = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_genBrokerMaster.IsPostingEnable_VAT = dataReader.GetBoolean(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_genBrokerMaster.IsPostingEnable_NBT = dataReader.GetBoolean(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_genBrokerMaster.SalesReturnedGL_ID = dataReader.GetString(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_genBrokerMaster.BrokerPercentage = dataReader.GetDecimal(46);
			}

			return tbl_genBrokerMaster;
		}
		/// <summary>
		/// This makes tbl_genBrokerMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genBrokerMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genBrokerMaster  tbl_genBrokerMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_broker_ID = new DataColumn("broker_ID" , typeof(string));
			DataColumn col_brokerCode = new DataColumn("brokerCode" , typeof(string));
			DataColumn col_brokerName = new DataColumn("brokerName" , typeof(string));
			DataColumn col_addressRegister = new DataColumn("addressRegister" , typeof(string));
			DataColumn col_addressDelivery = new DataColumn("addressDelivery" , typeof(string));
			DataColumn col_telephone = new DataColumn("telephone" , typeof(string));
			DataColumn col_mobile = new DataColumn("mobile" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_email = new DataColumn("email" , typeof(string));
			DataColumn col_url = new DataColumn("url" , typeof(string));
			DataColumn col_businessRegistraionNo = new DataColumn("businessRegistraionNo" , typeof(string));
			DataColumn col_vatRegistrationNo = new DataColumn("vatRegistrationNo" , typeof(string));
			DataColumn col_nbtRegistrationNo = new DataColumn("nbtRegistrationNo" , typeof(string));
			DataColumn col_svatRegistrationNo = new DataColumn("svatRegistrationNo" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isBlacklisted = new DataColumn("isBlacklisted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_country_ID = new DataColumn("country_ID" , typeof(string));
			DataColumn col_province_ID = new DataColumn("province_ID" , typeof(string));
			DataColumn col_district_ID = new DataColumn("district_ID" , typeof(string));
			DataColumn col_city_ID = new DataColumn("city_ID" , typeof(string));
			DataColumn col_town_ID = new DataColumn("town_ID" , typeof(string));
			DataColumn col_area_ID = new DataColumn("area_ID" , typeof(string));
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(string));
			DataColumn col_brokerType_ID = new DataColumn("brokerType_ID" , typeof(string));
			DataColumn col_brokerCategory_ID = new DataColumn("brokerCategory_ID" , typeof(string));
			DataColumn col_brokerClass_ID = new DataColumn("brokerClass_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_salesManager_ID = new DataColumn("salesManager_ID" , typeof(string));
			DataColumn col_areaManager_ID = new DataColumn("areaManager_ID" , typeof(string));
			DataColumn col_salesRep_ID = new DataColumn("salesRep_ID" , typeof(string));
			DataColumn col_salesExecutive_ID = new DataColumn("salesExecutive_ID" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_isVATenable = new DataColumn("isVATenable" , typeof(bool));
			DataColumn col_isSVATenable = new DataColumn("isSVATenable" , typeof(bool));
			DataColumn col_isNBTenable = new DataColumn("isNBTenable" , typeof(bool));
			DataColumn col_isBrokerPricingEnable = new DataColumn("isBrokerPricingEnable" , typeof(bool));
			DataColumn col_title = new DataColumn("title" , typeof(string));
			DataColumn col_nicNo = new DataColumn("nicNo" , typeof(string));
			DataColumn col_dateOfBirth = new DataColumn("dateOfBirth" , typeof(DateTime));
			DataColumn col_brokerAccountType_ID = new DataColumn("brokerAccountType_ID" , typeof(string));
			DataColumn col_isPostingEnable_VAT = new DataColumn("isPostingEnable_VAT" , typeof(bool));
			DataColumn col_isPostingEnable_NBT = new DataColumn("isPostingEnable_NBT" , typeof(bool));
			DataColumn col_salesReturnedGL_ID = new DataColumn("salesReturnedGL_ID" , typeof(string));
			DataColumn col_brokerPercentage = new DataColumn("brokerPercentage" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_broker_ID,col_brokerCode,col_brokerName,col_addressRegister,col_addressDelivery,col_telephone,col_mobile,col_fax,col_email,col_url,col_businessRegistraionNo,col_vatRegistrationNo,col_nbtRegistrationNo,col_svatRegistrationNo,col_remark,col_isBlacklisted,col_isLocked,col_isDeleted,col_country_ID,col_province_ID,col_district_ID,col_city_ID,col_town_ID,col_area_ID,col_route_ID,col_brokerType_ID,col_brokerCategory_ID,col_brokerClass_ID,col_currency_ID,col_salesManager_ID,col_areaManager_ID,col_salesRep_ID,col_salesExecutive_ID,col_gl_ID,col_companyBranch_ID,col_isVATenable,col_isSVATenable,col_isNBTenable,col_isBrokerPricingEnable,col_title,col_nicNo,col_dateOfBirth,col_brokerAccountType_ID,col_isPostingEnable_VAT,col_isPostingEnable_NBT,col_salesReturnedGL_ID,col_brokerPercentage,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genBrokerMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genBrokerMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genBrokerMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["broker_ID"] = user.broker_ID;
			drow["brokerCode"] = user.brokerCode;
			drow["brokerName"] = user.brokerName;
			drow["addressRegister"] = user.addressRegister;
			drow["addressDelivery"] = user.addressDelivery;
			drow["telephone"] = user.telephone;
			drow["mobile"] = user.mobile;
			drow["fax"] = user.fax;
			drow["email"] = user.email;
			drow["url"] = user.url;
			drow["businessRegistraionNo"] = user.businessRegistraionNo;
			drow["vatRegistrationNo"] = user.vatRegistrationNo;
			drow["nbtRegistrationNo"] = user.nbtRegistrationNo;
			drow["svatRegistrationNo"] = user.svatRegistrationNo;
			drow["remark"] = user.remark;
			drow["isBlacklisted"] = user.isBlacklisted;
			drow["isLocked"] = user.isLocked;
			drow["isDeleted"] = user.isDeleted;
			drow["country_ID"] = user.country_ID;
			drow["province_ID"] = user.province_ID;
			drow["district_ID"] = user.district_ID;
			drow["city_ID"] = user.city_ID;
			drow["town_ID"] = user.town_ID;
			drow["area_ID"] = user.area_ID;
			drow["route_ID"] = user.route_ID;
			drow["brokerType_ID"] = user.brokerType_ID;
			drow["brokerCategory_ID"] = user.brokerCategory_ID;
			drow["brokerClass_ID"] = user.brokerClass_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["salesManager_ID"] = user.salesManager_ID;
			drow["areaManager_ID"] = user.areaManager_ID;
			drow["salesRep_ID"] = user.salesRep_ID;
			drow["salesExecutive_ID"] = user.salesExecutive_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["isVATenable"] = user.isVATenable;
			drow["isSVATenable"] = user.isSVATenable;
			drow["isNBTenable"] = user.isNBTenable;
			drow["isBrokerPricingEnable"] = user.isBrokerPricingEnable;
			drow["title"] = user.title;
			drow["nicNo"] = user.nicNo;
			drow["dateOfBirth"] = user.dateOfBirth;
			drow["brokerAccountType_ID"] = user.brokerAccountType_ID;
			drow["isPostingEnable_VAT"] = user.isPostingEnable_VAT;
			drow["isPostingEnable_NBT"] = user.isPostingEnable_NBT;
			drow["salesReturnedGL_ID"] = user.salesReturnedGL_ID;
			drow["brokerPercentage"] = user.brokerPercentage;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
