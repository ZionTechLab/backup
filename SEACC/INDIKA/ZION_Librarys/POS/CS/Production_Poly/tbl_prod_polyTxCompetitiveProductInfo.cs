using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_polyTxCompetitiveProductInfo {
		#region Fields
		private int line_No;
		private string item_ID_FG;
		private string brand_ID;
		private string model_ID;
		private string company;
		private string country_ID;
		private string remarks;
		private decimal price1;
		private decimal price2;
		private decimal price3;
		private decimal price4;
		private decimal price_MPR;
		private bool isChecked;
		private bool isApproved;
		private bool isCanceled;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string canceldUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime dateCanceled;
		private string createUserTerminal_ID;
		private string modifiedUserTerminal_ID;
		private string checkedUserTerminal_ID;
		private string approvedUserTerminal_ID;
		private string canceledUserTerminal_ID;
		private string companyID;
		private string companyBranchID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyTxCompetitiveProductInfo class.
		/// </summary>
		public tbl_prod_polyTxCompetitiveProductInfo() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyTxCompetitiveProductInfo class.
		/// </summary>
		public tbl_prod_polyTxCompetitiveProductInfo(int line_No, string item_ID_FG, string brand_ID, string model_ID, string company, string country_ID, string remarks, decimal price1, decimal price2, decimal price3, decimal price4, decimal price_MPR, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID) {
			this.line_No = line_No;
			this.item_ID_FG = item_ID_FG;
			this.brand_ID = brand_ID;
			this.model_ID = model_ID;
			this.company = company;
			this.country_ID = country_ID;
			this.remarks = remarks;
			this.price1 = price1;
			this.price2 = price2;
			this.price3 = price3;
			this.price4 = price4;
			this.price_MPR = price_MPR;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isCanceled = isCanceled;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.canceldUser_ID = canceldUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.dateCanceled = dateCanceled;
			this.createUserTerminal_ID = createUserTerminal_ID;
			this.modifiedUserTerminal_ID = modifiedUserTerminal_ID;
			this.checkedUserTerminal_ID = checkedUserTerminal_ID;
			this.approvedUserTerminal_ID = approvedUserTerminal_ID;
			this.canceledUserTerminal_ID = canceledUserTerminal_ID;
			this.companyID = companyID;
			this.companyBranchID = companyBranchID;
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
		/// Gets or sets the Item_ID_FG value.
		/// </summary>
		public string Item_ID_FG {
			get { return item_ID_FG; }
			set { item_ID_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the Brand_ID value.
		/// </summary>
		public string Brand_ID {
			get { return brand_ID; }
			set { brand_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Model_ID value.
		/// </summary>
		public string Model_ID {
			get { return model_ID; }
			set { model_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Company value.
		/// </summary>
		public string Company {
			get { return company; }
			set { company = value; }
		}
		
		/// <summary>
		/// Gets or sets the Country_ID value.
		/// </summary>
		public string Country_ID {
			get { return country_ID; }
			set { country_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Price1 value.
		/// </summary>
		public decimal Price1 {
			get { return price1; }
			set { price1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Price2 value.
		/// </summary>
		public decimal Price2 {
			get { return price2; }
			set { price2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Price3 value.
		/// </summary>
		public decimal Price3 {
			get { return price3; }
			set { price3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Price4 value.
		/// </summary>
		public decimal Price4 {
			get { return price4; }
			set { price4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Price_MPR value.
		/// </summary>
		public decimal Price_MPR {
			get { return price_MPR; }
			set { price_MPR = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChecked value.
		/// </summary>
		public bool IsChecked {
			get { return isChecked; }
			set { isChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedUser_ID value.
		/// </summary>
		public string CheckedUser_ID {
			get { return checkedUser_ID; }
			set { checkedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceldUser_ID value.
		/// </summary>
		public string CanceldUser_ID {
			get { return canceldUser_ID; }
			set { canceldUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateChecked value.
		/// </summary>
		public DateTime DateChecked {
			get { return dateChecked; }
			set { dateChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved value.
		/// </summary>
		public DateTime DateApproved {
			get { return dateApproved; }
			set { dateApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCanceled value.
		/// </summary>
		public DateTime DateCanceled {
			get { return dateCanceled; }
			set { dateCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUserTerminal_ID value.
		/// </summary>
		public string CreateUserTerminal_ID {
			get { return createUserTerminal_ID; }
			set { createUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUserTerminal_ID value.
		/// </summary>
		public string ModifiedUserTerminal_ID {
			get { return modifiedUserTerminal_ID; }
			set { modifiedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedUserTerminal_ID value.
		/// </summary>
		public string CheckedUserTerminal_ID {
			get { return checkedUserTerminal_ID; }
			set { checkedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUserTerminal_ID value.
		/// </summary>
		public string ApprovedUserTerminal_ID {
			get { return approvedUserTerminal_ID; }
			set { approvedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceledUserTerminal_ID value.
		/// </summary>
		public string CanceledUserTerminal_ID {
			get { return canceledUserTerminal_ID; }
			set { canceledUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranchID value.
		/// </summary>
		public string CompanyBranchID {
			get { return companyBranchID; }
			set { companyBranchID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_polyTxCompetitiveProductInfo table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@company", SqlDbType.VarChar,200);
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@price1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@price2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@price3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@price4", SqlDbType.Decimal,9);
			scom.Parameters.Add("@price_MPR", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@model_ID"].Value = model_ID;
			scom.Parameters["@company"].Value = company;
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@price1"].Value = price1;
			scom.Parameters["@price2"].Value = price2;
			scom.Parameters["@price3"].Value = price3;
			scom.Parameters["@price4"].Value = price4;
			scom.Parameters["@price_MPR"].Value = price_MPR;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@checkedUserTerminal_ID"].Value = checkedUserTerminal_ID;
			scom.Parameters["@approvedUserTerminal_ID"].Value = approvedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_polyTxCompetitiveProductInfo table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@company", SqlDbType.VarChar,200);
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@price1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@price2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@price3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@price4", SqlDbType.Decimal,9);
			scom.Parameters.Add("@price_MPR", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@model_ID"].Value = model_ID;
			scom.Parameters["@company"].Value = company;
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@price1"].Value = price1;
			scom.Parameters["@price2"].Value = price2;
			scom.Parameters["@price3"].Value = price3;
			scom.Parameters["@price4"].Value = price4;
			scom.Parameters["@price_MPR"].Value = price_MPR;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@checkedUserTerminal_ID"].Value = checkedUserTerminal_ID;
			scom.Parameters["@approvedUserTerminal_ID"].Value = approvedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_polyTxCompetitiveProductInfo table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByCountry_ID(string country_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters["@country_ID"].Value = country_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByBrand_ID(string brand_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByBrand_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters["@brand_ID"].Value = brand_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByModel_ID(string model_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByModel_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters["@model_ID"].Value = model_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_polyTxCompetitiveProductInfo table.
		/// </summary>
		public static tbl_prod_polyTxCompetitiveProductInfo Select(int line_No_Incoming, string item_ID_FG_Incoming){

			tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfoins = new tbl_prod_polyTxCompetitiveProductInfo();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfoins = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
				} else {
					tbl_prod_polyTxCompetitiveProductInfoins = null;
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByCountry_ID(string country_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters["@country_ID"].Value = country_ID;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByBrand_ID(string brand_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByBrand_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters["@brand_ID"].Value = brand_ID;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByModel_ID(string model_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByModel_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@model_ID", SqlDbType.VarChar,10);
			scom.Parameters["@model_ID"].Value = model_ID;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxCompetitiveProductInfo table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxCompetitiveProductInfo> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxCompetitiveProductInfoSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prod_polyTxCompetitiveProductInfo> tbl_prod_polyTxCompetitiveProductInfoList = new List<tbl_prod_polyTxCompetitiveProductInfo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = Maketbl_prod_polyTxCompetitiveProductInfo(dataReader);
					tbl_prod_polyTxCompetitiveProductInfoList.Add(tbl_prod_polyTxCompetitiveProductInfo);
				}
			}
			scon.Close();
			return tbl_prod_polyTxCompetitiveProductInfoList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_polyTxCompetitiveProductInfo class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_polyTxCompetitiveProductInfo Maketbl_prod_polyTxCompetitiveProductInfo(SqlDataReader dataReader) {
			tbl_prod_polyTxCompetitiveProductInfo tbl_prod_polyTxCompetitiveProductInfo = new tbl_prod_polyTxCompetitiveProductInfo();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Item_ID_FG = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Brand_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Model_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Company = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Country_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Remarks = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Price1 = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Price2 = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Price3 = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Price4 = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.Price_MPR = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.IsChecked = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.IsApproved = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.IsCanceled = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.CreateUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.ModifiedUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.CheckedUser_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.ApprovedUser_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.CanceldUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.DateCreate = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.DateModified = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.DateChecked = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.DateApproved = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.DateCanceled = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.CreateUserTerminal_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.ModifiedUserTerminal_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.CheckedUserTerminal_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.ApprovedUserTerminal_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.CanceledUserTerminal_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.CompanyID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_prod_polyTxCompetitiveProductInfo.CompanyBranchID = dataReader.GetString(31);
			}

			return tbl_prod_polyTxCompetitiveProductInfo;
		}
		/// <summary>
		/// This makes tbl_prod_polyTxCompetitiveProductInfo datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_polyTxCompetitiveProductInfo object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_polyTxCompetitiveProductInfo  tbl_prod_polyTxCompetitiveProductInfo   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_item_ID_FG = new DataColumn("item_ID_FG" , typeof(string));
			DataColumn col_brand_ID = new DataColumn("brand_ID" , typeof(string));
			DataColumn col_model_ID = new DataColumn("model_ID" , typeof(string));
			DataColumn col_company = new DataColumn("company" , typeof(string));
			DataColumn col_country_ID = new DataColumn("country_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_price1 = new DataColumn("price1" , typeof(decimal));
			DataColumn col_price2 = new DataColumn("price2" , typeof(decimal));
			DataColumn col_price3 = new DataColumn("price3" , typeof(decimal));
			DataColumn col_price4 = new DataColumn("price4" , typeof(decimal));
			DataColumn col_price_MPR = new DataColumn("price_MPR" , typeof(decimal));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_canceldUser_ID = new DataColumn("canceldUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
			DataColumn col_createUserTerminal_ID = new DataColumn("createUserTerminal_ID" , typeof(string));
			DataColumn col_modifiedUserTerminal_ID = new DataColumn("modifiedUserTerminal_ID" , typeof(string));
			DataColumn col_checkedUserTerminal_ID = new DataColumn("checkedUserTerminal_ID" , typeof(string));
			DataColumn col_approvedUserTerminal_ID = new DataColumn("approvedUserTerminal_ID" , typeof(string));
			DataColumn col_canceledUserTerminal_ID = new DataColumn("canceledUserTerminal_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranchID = new DataColumn("companyBranchID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_item_ID_FG,col_brand_ID,col_model_ID,col_company,col_country_ID,col_remarks,col_price1,col_price2,col_price3,col_price4,col_price_MPR,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_polyTxCompetitiveProductInfo datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_polyTxCompetitiveProductInfo object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_polyTxCompetitiveProductInfo user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["item_ID_FG"] = user.item_ID_FG;
			drow["brand_ID"] = user.brand_ID;
			drow["model_ID"] = user.model_ID;
			drow["company"] = user.company;
			drow["country_ID"] = user.country_ID;
			drow["remarks"] = user.remarks;
			drow["price1"] = user.price1;
			drow["price2"] = user.price2;
			drow["price3"] = user.price3;
			drow["price4"] = user.price4;
			drow["price_MPR"] = user.price_MPR;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isCanceled"] = user.isCanceled;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["canceldUser_ID"] = user.canceldUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["dateCanceled"] = user.dateCanceled;
			drow["createUserTerminal_ID"] = user.createUserTerminal_ID;
			drow["modifiedUserTerminal_ID"] = user.modifiedUserTerminal_ID;
			drow["checkedUserTerminal_ID"] = user.checkedUserTerminal_ID;
			drow["approvedUserTerminal_ID"] = user.approvedUserTerminal_ID;
			drow["canceledUserTerminal_ID"] = user.canceledUserTerminal_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranchID"] = user.companyBranchID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
