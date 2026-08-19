using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genSupplierMaster {
		#region Fields
		private string supplier_ID;
		private string supplierName;
		private string addressRegister;
		private string addressDelivery;
		private string telephone;
		private string fax;
		private string email;
		private string url;
		private string businessRegistraionNo;
		private string vatRegistrationNo;
		private string nbtRegistrationNo;
		private string svatRegistrationNo;
		private string payee;
		private string remark;
		private decimal creditLimit;
		private decimal creditPeriod;
		private decimal outstandingAmount;
		private decimal chequeInHandAmount;
		private decimal outstandingBalance;
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
		private string supplierType_ID;
		private string supplierCategory_ID;
		private string supplierClass_ID;
		private string currency_ID;
		private string salesManager_ID;
		private byte[] image;
		private decimal depositAmount;
		private bool isVATenable;
		private bool isSVATenable;
		private bool isNBTenable;
		private string supplierAccountType_ID;
		private string companyID;
		private string companyBranch_ID;
		private bool isOtherCreditor;
		private bool isSubContractor;
		private string store_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genSupplierMaster class.
		/// </summary>
		public tbl_genSupplierMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genSupplierMaster class.
		/// </summary>
		public tbl_genSupplierMaster(string supplier_ID, string supplierName, string addressRegister, string addressDelivery, string telephone, string fax, string email, string url, string businessRegistraionNo, string vatRegistrationNo, string nbtRegistrationNo, string svatRegistrationNo, string payee, string remark, decimal creditLimit, decimal creditPeriod, decimal outstandingAmount, decimal chequeInHandAmount, decimal outstandingBalance, bool isBlacklisted, bool isLocked, bool isDeleted, string country_ID, string province_ID, string district_ID, string city_ID, string town_ID, string area_ID, string route_ID, string supplierType_ID, string supplierCategory_ID, string supplierClass_ID, string currency_ID, string salesManager_ID, byte[] image, decimal depositAmount, bool isVATenable, bool isSVATenable, bool isNBTenable, string supplierAccountType_ID, string companyID, string companyBranch_ID, bool isOtherCreditor, bool isSubContractor, string store_ID) {
			this.supplier_ID = supplier_ID;
			this.supplierName = supplierName;
			this.addressRegister = addressRegister;
			this.addressDelivery = addressDelivery;
			this.telephone = telephone;
			this.fax = fax;
			this.email = email;
			this.url = url;
			this.businessRegistraionNo = businessRegistraionNo;
			this.vatRegistrationNo = vatRegistrationNo;
			this.nbtRegistrationNo = nbtRegistrationNo;
			this.svatRegistrationNo = svatRegistrationNo;
			this.payee = payee;
			this.remark = remark;
			this.creditLimit = creditLimit;
			this.creditPeriod = creditPeriod;
			this.outstandingAmount = outstandingAmount;
			this.chequeInHandAmount = chequeInHandAmount;
			this.outstandingBalance = outstandingBalance;
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
			this.supplierType_ID = supplierType_ID;
			this.supplierCategory_ID = supplierCategory_ID;
			this.supplierClass_ID = supplierClass_ID;
			this.currency_ID = currency_ID;
			this.salesManager_ID = salesManager_ID;
			this.image = image;
			this.depositAmount = depositAmount;
			this.isVATenable = isVATenable;
			this.isSVATenable = isSVATenable;
			this.isNBTenable = isNBTenable;
			this.supplierAccountType_ID = supplierAccountType_ID;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.isOtherCreditor = isOtherCreditor;
			this.isSubContractor = isSubContractor;
			this.store_ID = store_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SupplierName value.
		/// </summary>
		public string SupplierName {
			get { return supplierName; }
			set { supplierName = value; }
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
		/// Gets or sets the Payee value.
		/// </summary>
		public string Payee {
			get { return payee; }
			set { payee = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditLimit value.
		/// </summary>
		public decimal CreditLimit {
			get { return creditLimit; }
			set { creditLimit = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditPeriod value.
		/// </summary>
		public decimal CreditPeriod {
			get { return creditPeriod; }
			set { creditPeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the OutstandingAmount value.
		/// </summary>
		public decimal OutstandingAmount {
			get { return outstandingAmount; }
			set { outstandingAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeInHandAmount value.
		/// </summary>
		public decimal ChequeInHandAmount {
			get { return chequeInHandAmount; }
			set { chequeInHandAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the OutstandingBalance value.
		/// </summary>
		public decimal OutstandingBalance {
			get { return outstandingBalance; }
			set { outstandingBalance = value; }
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
		/// Gets or sets the SupplierType_ID value.
		/// </summary>
		public string SupplierType_ID {
			get { return supplierType_ID; }
			set { supplierType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SupplierCategory_ID value.
		/// </summary>
		public string SupplierCategory_ID {
			get { return supplierCategory_ID; }
			set { supplierCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SupplierClass_ID value.
		/// </summary>
		public string SupplierClass_ID {
			get { return supplierClass_ID; }
			set { supplierClass_ID = value; }
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
		/// Gets or sets the Image value.
		/// </summary>
		public byte[] Image {
			get { return image; }
			set { image = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepositAmount value.
		/// </summary>
		public decimal DepositAmount {
			get { return depositAmount; }
			set { depositAmount = value; }
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
		/// Gets or sets the SupplierAccountType_ID value.
		/// </summary>
		public string SupplierAccountType_ID {
			get { return supplierAccountType_ID; }
			set { supplierAccountType_ID = value; }
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
		/// Gets or sets the IsOtherCreditor value.
		/// </summary>
		public bool IsOtherCreditor {
			get { return isOtherCreditor; }
			set { isOtherCreditor = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSubContractor value.
		/// </summary>
		public bool IsSubContractor {
			get { return isSubContractor; }
			set { isSubContractor = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genSupplierMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplierName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@addressRegister", SqlDbType.VarChar,200);
			scom.Parameters.Add("@addressDelivery", SqlDbType.VarChar,200);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@url", SqlDbType.VarChar,50);
			scom.Parameters.Add("@businessRegistraionNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@vatRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nbtRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@svatRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payee", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@creditLimit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditPeriod", SqlDbType.Decimal,9);
			scom.Parameters.Add("@outstandingAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeInHandAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@outstandingBalance", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@supplierType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@supplierCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@supplierClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@depositAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isVATenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVATenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@supplierAccountType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isOtherCreditor", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSubContractor", SqlDbType.Bit,1);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@supplierName"].Value = supplierName;
			scom.Parameters["@addressRegister"].Value = addressRegister;
			scom.Parameters["@addressDelivery"].Value = addressDelivery;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@url"].Value = url;
			scom.Parameters["@businessRegistraionNo"].Value = businessRegistraionNo;
			scom.Parameters["@vatRegistrationNo"].Value = vatRegistrationNo;
			scom.Parameters["@nbtRegistrationNo"].Value = nbtRegistrationNo;
			scom.Parameters["@svatRegistrationNo"].Value = svatRegistrationNo;
			scom.Parameters["@payee"].Value = payee;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@creditLimit"].Value = creditLimit;
			scom.Parameters["@creditPeriod"].Value = creditPeriod;
			scom.Parameters["@outstandingAmount"].Value = outstandingAmount;
			scom.Parameters["@chequeInHandAmount"].Value = chequeInHandAmount;
			scom.Parameters["@outstandingBalance"].Value = outstandingBalance;
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
			scom.Parameters["@supplierType_ID"].Value = supplierType_ID;
			scom.Parameters["@supplierCategory_ID"].Value = supplierCategory_ID;
			scom.Parameters["@supplierClass_ID"].Value = supplierClass_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@depositAmount"].Value = depositAmount;
			scom.Parameters["@isVATenable"].Value = isVATenable;
			scom.Parameters["@isSVATenable"].Value = isSVATenable;
			scom.Parameters["@isNBTenable"].Value = isNBTenable;
			scom.Parameters["@supplierAccountType_ID"].Value = supplierAccountType_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isOtherCreditor"].Value = isOtherCreditor;
			scom.Parameters["@isSubContractor"].Value = isSubContractor;
			scom.Parameters["@store_ID"].Value = store_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genSupplierMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplierName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@addressRegister", SqlDbType.VarChar,200);
			scom.Parameters.Add("@addressDelivery", SqlDbType.VarChar,200);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@url", SqlDbType.VarChar,50);
			scom.Parameters.Add("@businessRegistraionNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@vatRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@nbtRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@svatRegistrationNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payee", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@creditLimit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditPeriod", SqlDbType.Decimal,9);
			scom.Parameters.Add("@outstandingAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@chequeInHandAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@outstandingBalance", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@supplierType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@supplierCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@supplierClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@image", SqlDbType.Image);
			scom.Parameters.Add("@depositAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isVATenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSVATenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTenable", SqlDbType.Bit,1);
			scom.Parameters.Add("@supplierAccountType_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isOtherCreditor", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSubContractor", SqlDbType.Bit,1);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@supplierName"].Value = supplierName;
			scom.Parameters["@addressRegister"].Value = addressRegister;
			scom.Parameters["@addressDelivery"].Value = addressDelivery;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@url"].Value = url;
			scom.Parameters["@businessRegistraionNo"].Value = businessRegistraionNo;
			scom.Parameters["@vatRegistrationNo"].Value = vatRegistrationNo;
			scom.Parameters["@nbtRegistrationNo"].Value = nbtRegistrationNo;
			scom.Parameters["@svatRegistrationNo"].Value = svatRegistrationNo;
			scom.Parameters["@payee"].Value = payee;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@creditLimit"].Value = creditLimit;
			scom.Parameters["@creditPeriod"].Value = creditPeriod;
			scom.Parameters["@outstandingAmount"].Value = outstandingAmount;
			scom.Parameters["@chequeInHandAmount"].Value = chequeInHandAmount;
			scom.Parameters["@outstandingBalance"].Value = outstandingBalance;
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
			scom.Parameters["@supplierType_ID"].Value = supplierType_ID;
			scom.Parameters["@supplierCategory_ID"].Value = supplierCategory_ID;
			scom.Parameters["@supplierClass_ID"].Value = supplierClass_ID;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@image"].Value = image;
			scom.Parameters["@depositAmount"].Value = depositAmount;
			scom.Parameters["@isVATenable"].Value = isVATenable;
			scom.Parameters["@isSVATenable"].Value = isSVATenable;
			scom.Parameters["@isNBTenable"].Value = isNBTenable;
			scom.Parameters["@supplierAccountType_ID"].Value = supplierAccountType_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@isOtherCreditor"].Value = isOtherCreditor;
			scom.Parameters["@isSubContractor"].Value = isSubContractor;
			scom.Parameters["@store_ID"].Value = store_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genSupplierMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplierCategory_ID(string supplierCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllBySupplierCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@supplierCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierCategory_ID"].Value = supplierCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCity_ID(string city_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllByCity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters["@city_ID"].Value = city_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplierType_ID(string supplierType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllBySupplierType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@supplierType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierType_ID"].Value = supplierType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCurrency_ID(string currency_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllByCurrency_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByDistrict_ID(string district_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllByDistrict_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
			scom.Parameters["@district_ID"].Value = district_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByArea_ID(string area_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllByArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@area_ID", SqlDbType.VarChar,10);
			scom.Parameters["@area_ID"].Value = area_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCountry_ID(string country_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllByCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters["@country_ID"].Value = country_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByProvince_ID(string province_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllByProvince_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters["@province_ID"].Value = province_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplierClass_ID(string supplierClass_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterDeleteAllBySupplierClass_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@supplierClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierClass_ID"].Value = supplierClass_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genSupplierMaster table.
		/// </summary>
		public static tbl_genSupplierMaster Select(string supplier_ID_Incoming){

			tbl_genSupplierMaster tbl_genSupplierMasterins = new tbl_genSupplierMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genSupplierMasterins = Maketbl_genSupplierMaster(dataReader);
				} else {
					tbl_genSupplierMasterins = null;
				}
			}
			scon.Close();
			return tbl_genSupplierMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllBySupplierCategory_ID(string supplierCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllBySupplierCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplierCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierCategory_ID"].Value = supplierCategory_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllByCity_ID(string city_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllByCity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters["@city_ID"].Value = city_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllBySupplierType_ID(string supplierType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllBySupplierType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplierType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierType_ID"].Value = supplierType_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllByCurrency_ID(string currency_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllByCurrency_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters["@currency_ID"].Value = currency_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllByDistrict_ID(string district_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllByDistrict_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
			scom.Parameters["@district_ID"].Value = district_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllByArea_ID(string area_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllByArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@area_ID", SqlDbType.VarChar,10);
			scom.Parameters["@area_ID"].Value = area_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllByCountry_ID(string country_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllByCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters["@country_ID"].Value = country_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllByTown_ID(string town_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllByTown_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllByProvince_ID(string province_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllByProvince_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters["@province_ID"].Value = province_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllByRoute_ID(string route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.VarChar,20);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierMaster> SelectAllBySupplierClass_ID(string supplierClass_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierMasterSelectAllBySupplierClass_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplierClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierClass_ID"].Value = supplierClass_ID;
				List<tbl_genSupplierMaster> tbl_genSupplierMasterList = new List<tbl_genSupplierMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierMaster tbl_genSupplierMaster = Maketbl_genSupplierMaster(dataReader);
					tbl_genSupplierMasterList.Add(tbl_genSupplierMaster);
				}
			}
			scon.Close();
			return tbl_genSupplierMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genSupplierMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genSupplierMaster Maketbl_genSupplierMaster(SqlDataReader dataReader) {
			tbl_genSupplierMaster tbl_genSupplierMaster = new tbl_genSupplierMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genSupplierMaster.Supplier_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genSupplierMaster.SupplierName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genSupplierMaster.AddressRegister = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genSupplierMaster.AddressDelivery = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genSupplierMaster.Telephone = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genSupplierMaster.Fax = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genSupplierMaster.Email = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genSupplierMaster.Url = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genSupplierMaster.BusinessRegistraionNo = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genSupplierMaster.VatRegistrationNo = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genSupplierMaster.NbtRegistrationNo = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genSupplierMaster.SvatRegistrationNo = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genSupplierMaster.Payee = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genSupplierMaster.Remark = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genSupplierMaster.CreditLimit = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genSupplierMaster.CreditPeriod = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genSupplierMaster.OutstandingAmount = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genSupplierMaster.ChequeInHandAmount = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genSupplierMaster.OutstandingBalance = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genSupplierMaster.IsBlacklisted = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genSupplierMaster.IsLocked = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genSupplierMaster.IsDeleted = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genSupplierMaster.Country_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genSupplierMaster.Province_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genSupplierMaster.District_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_genSupplierMaster.City_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_genSupplierMaster.Town_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_genSupplierMaster.Area_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_genSupplierMaster.Route_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_genSupplierMaster.SupplierType_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_genSupplierMaster.SupplierCategory_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_genSupplierMaster.SupplierClass_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_genSupplierMaster.Currency_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_genSupplierMaster.SalesManager_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_genSupplierMaster.Image = (byte[])dataReader[34];
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_genSupplierMaster.DepositAmount = dataReader.GetDecimal(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_genSupplierMaster.IsVATenable = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_genSupplierMaster.IsSVATenable = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_genSupplierMaster.IsNBTenable = dataReader.GetBoolean(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_genSupplierMaster.SupplierAccountType_ID = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_genSupplierMaster.CompanyID = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_genSupplierMaster.CompanyBranch_ID = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_genSupplierMaster.IsOtherCreditor = dataReader.GetBoolean(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_genSupplierMaster.IsSubContractor = dataReader.GetBoolean(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_genSupplierMaster.Store_ID = dataReader.GetString(44);
			}

			return tbl_genSupplierMaster;
		}
		/// <summary>
		/// This makes tbl_genSupplierMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genSupplierMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genSupplierMaster  tbl_genSupplierMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_supplierName = new DataColumn("supplierName" , typeof(string));
			DataColumn col_addressRegister = new DataColumn("addressRegister" , typeof(string));
			DataColumn col_addressDelivery = new DataColumn("addressDelivery" , typeof(string));
			DataColumn col_telephone = new DataColumn("telephone" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_email = new DataColumn("email" , typeof(string));
			DataColumn col_url = new DataColumn("url" , typeof(string));
			DataColumn col_businessRegistraionNo = new DataColumn("businessRegistraionNo" , typeof(string));
			DataColumn col_vatRegistrationNo = new DataColumn("vatRegistrationNo" , typeof(string));
			DataColumn col_nbtRegistrationNo = new DataColumn("nbtRegistrationNo" , typeof(string));
			DataColumn col_svatRegistrationNo = new DataColumn("svatRegistrationNo" , typeof(string));
			DataColumn col_payee = new DataColumn("payee" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_creditLimit = new DataColumn("creditLimit" , typeof(decimal));
			DataColumn col_creditPeriod = new DataColumn("creditPeriod" , typeof(decimal));
			DataColumn col_outstandingAmount = new DataColumn("outstandingAmount" , typeof(decimal));
			DataColumn col_chequeInHandAmount = new DataColumn("chequeInHandAmount" , typeof(decimal));
			DataColumn col_outstandingBalance = new DataColumn("outstandingBalance" , typeof(decimal));
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
			DataColumn col_supplierType_ID = new DataColumn("supplierType_ID" , typeof(string));
			DataColumn col_supplierCategory_ID = new DataColumn("supplierCategory_ID" , typeof(string));
			DataColumn col_supplierClass_ID = new DataColumn("supplierClass_ID" , typeof(string));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_salesManager_ID = new DataColumn("salesManager_ID" , typeof(string));
			DataColumn col_image = new DataColumn("image" , typeof(byte[]));
			DataColumn col_depositAmount = new DataColumn("depositAmount" , typeof(decimal));
			DataColumn col_isVATenable = new DataColumn("isVATenable" , typeof(bool));
			DataColumn col_isSVATenable = new DataColumn("isSVATenable" , typeof(bool));
			DataColumn col_isNBTenable = new DataColumn("isNBTenable" , typeof(bool));
			DataColumn col_supplierAccountType_ID = new DataColumn("supplierAccountType_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_isOtherCreditor = new DataColumn("isOtherCreditor" , typeof(bool));
			DataColumn col_isSubContractor = new DataColumn("isSubContractor" , typeof(bool));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_supplier_ID,col_supplierName,col_addressRegister,col_addressDelivery,col_telephone,col_fax,col_email,col_url,col_businessRegistraionNo,col_vatRegistrationNo,col_nbtRegistrationNo,col_svatRegistrationNo,col_payee,col_remark,col_creditLimit,col_creditPeriod,col_outstandingAmount,col_chequeInHandAmount,col_outstandingBalance,col_isBlacklisted,col_isLocked,col_isDeleted,col_country_ID,col_province_ID,col_district_ID,col_city_ID,col_town_ID,col_area_ID,col_route_ID,col_supplierType_ID,col_supplierCategory_ID,col_supplierClass_ID,col_currency_ID,col_salesManager_ID,col_image,col_depositAmount,col_isVATenable,col_isSVATenable,col_isNBTenable,col_supplierAccountType_ID,col_companyID,col_companyBranch_ID,col_isOtherCreditor,col_isSubContractor,col_store_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genSupplierMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genSupplierMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genSupplierMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["supplier_ID"] = user.supplier_ID;
			drow["supplierName"] = user.supplierName;
			drow["addressRegister"] = user.addressRegister;
			drow["addressDelivery"] = user.addressDelivery;
			drow["telephone"] = user.telephone;
			drow["fax"] = user.fax;
			drow["email"] = user.email;
			drow["url"] = user.url;
			drow["businessRegistraionNo"] = user.businessRegistraionNo;
			drow["vatRegistrationNo"] = user.vatRegistrationNo;
			drow["nbtRegistrationNo"] = user.nbtRegistrationNo;
			drow["svatRegistrationNo"] = user.svatRegistrationNo;
			drow["payee"] = user.payee;
			drow["remark"] = user.remark;
			drow["creditLimit"] = user.creditLimit;
			drow["creditPeriod"] = user.creditPeriod;
			drow["outstandingAmount"] = user.outstandingAmount;
			drow["chequeInHandAmount"] = user.chequeInHandAmount;
			drow["outstandingBalance"] = user.outstandingBalance;
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
			drow["supplierType_ID"] = user.supplierType_ID;
			drow["supplierCategory_ID"] = user.supplierCategory_ID;
			drow["supplierClass_ID"] = user.supplierClass_ID;
			drow["currency_ID"] = user.currency_ID;
			drow["salesManager_ID"] = user.salesManager_ID;
			drow["image"] = user.image;
			drow["depositAmount"] = user.depositAmount;
			drow["isVATenable"] = user.isVATenable;
			drow["isSVATenable"] = user.isSVATenable;
			drow["isNBTenable"] = user.isNBTenable;
			drow["supplierAccountType_ID"] = user.supplierAccountType_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["isOtherCreditor"] = user.isOtherCreditor;
			drow["isSubContractor"] = user.isSubContractor;
			drow["store_ID"] = user.store_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
