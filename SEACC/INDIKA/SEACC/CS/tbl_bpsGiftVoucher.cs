using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsGiftVoucher {
		#region Fields
		private int giftVoucherID;
		private string serialNo;
		private string remark;
		private DateTime voucherDate;
		private DateTime dateIssued;
		private DateTime dateValidFrom;
		private DateTime expiryDate;
		private int validityDays;
		private string invoice_ID;
		private string posTransaction_ID;
		private string financialYear_ID;
		private decimal voucherAmount;
		private decimal setteledAmount;
		private bool isSetteled;
		private bool isChecked;
		private bool isApproved;
		private bool isIssued;
		private bool isRedeemed;
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
		private string item_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsGiftVoucher class.
		/// </summary>
		public tbl_bpsGiftVoucher() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsGiftVoucher class.
		/// </summary>
		public tbl_bpsGiftVoucher(int giftVoucherID, string serialNo, string remark, DateTime voucherDate, DateTime dateIssued, DateTime dateValidFrom, DateTime expiryDate, int validityDays, string invoice_ID, string posTransaction_ID, string financialYear_ID, decimal voucherAmount, decimal setteledAmount, bool isSetteled, bool isChecked, bool isApproved, bool isIssued, bool isRedeemed, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID, string item_ID) {
			this.giftVoucherID = giftVoucherID;
			this.serialNo = serialNo;
			this.remark = remark;
			this.voucherDate = voucherDate;
			this.dateIssued = dateIssued;
			this.dateValidFrom = dateValidFrom;
			this.expiryDate = expiryDate;
			this.validityDays = validityDays;
			this.invoice_ID = invoice_ID;
			this.posTransaction_ID = posTransaction_ID;
			this.financialYear_ID = financialYear_ID;
			this.voucherAmount = voucherAmount;
			this.setteledAmount = setteledAmount;
			this.isSetteled = isSetteled;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isIssued = isIssued;
			this.isRedeemed = isRedeemed;
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
			this.item_ID = item_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the GiftVoucherID value.
		/// </summary>
		public int GiftVoucherID {
			get { return giftVoucherID; }
			set { giftVoucherID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNo value.
		/// </summary>
		public string SerialNo {
			get { return serialNo; }
			set { serialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the VoucherDate value.
		/// </summary>
		public DateTime VoucherDate {
			get { return voucherDate; }
			set { voucherDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateIssued value.
		/// </summary>
		public DateTime DateIssued {
			get { return dateIssued; }
			set { dateIssued = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateValidFrom value.
		/// </summary>
		public DateTime DateValidFrom {
			get { return dateValidFrom; }
			set { dateValidFrom = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExpiryDate value.
		/// </summary>
		public DateTime ExpiryDate {
			get { return expiryDate; }
			set { expiryDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ValidityDays value.
		/// </summary>
		public int ValidityDays {
			get { return validityDays; }
			set { validityDays = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosTransaction_ID value.
		/// </summary>
		public string PosTransaction_ID {
			get { return posTransaction_ID; }
			set { posTransaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the VoucherAmount value.
		/// </summary>
		public decimal VoucherAmount {
			get { return voucherAmount; }
			set { voucherAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the SetteledAmount value.
		/// </summary>
		public decimal SetteledAmount {
			get { return setteledAmount; }
			set { setteledAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSetteled value.
		/// </summary>
		public bool IsSetteled {
			get { return isSetteled; }
			set { isSetteled = value; }
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
		/// Gets or sets the IsIssued value.
		/// </summary>
		public bool IsIssued {
			get { return isIssued; }
			set { isIssued = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRedeemed value.
		/// </summary>
		public bool IsRedeemed {
			get { return isRedeemed; }
			set { isRedeemed = value; }
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
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsGiftVoucher table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@giftVoucherID", SqlDbType.Int,4);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@voucherDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateIssued", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateValidFrom", SqlDbType.DateTime,8);
			scom.Parameters.Add("@expiryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@validityDays", SqlDbType.Int,4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@voucherAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@setteledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSetteled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isIssued", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRedeemed", SqlDbType.Bit,1);
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
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@giftVoucherID"].Value = giftVoucherID;
			scom.Parameters["@serialNo"].Value = serialNo;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@voucherDate"].Value = voucherDate;
			scom.Parameters["@dateIssued"].Value = dateIssued;
			scom.Parameters["@dateValidFrom"].Value = dateValidFrom;
			scom.Parameters["@expiryDate"].Value = expiryDate;
			scom.Parameters["@validityDays"].Value = validityDays;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@voucherAmount"].Value = voucherAmount;
			scom.Parameters["@setteledAmount"].Value = setteledAmount;
			scom.Parameters["@isSetteled"].Value = isSetteled;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isIssued"].Value = isIssued;
			scom.Parameters["@isRedeemed"].Value = isRedeemed;
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
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsGiftVoucher table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@giftVoucherID", SqlDbType.Int,4);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@voucherDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateIssued", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateValidFrom", SqlDbType.DateTime,8);
			scom.Parameters.Add("@expiryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@validityDays", SqlDbType.Int,4);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@voucherAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@setteledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSetteled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isIssued", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRedeemed", SqlDbType.Bit,1);
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
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@giftVoucherID"].Value = giftVoucherID;
			scom.Parameters["@serialNo"].Value = serialNo;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@voucherDate"].Value = voucherDate;
			scom.Parameters["@dateIssued"].Value = dateIssued;
			scom.Parameters["@dateValidFrom"].Value = dateValidFrom;
			scom.Parameters["@expiryDate"].Value = expiryDate;
			scom.Parameters["@validityDays"].Value = validityDays;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@voucherAmount"].Value = voucherAmount;
			scom.Parameters["@setteledAmount"].Value = setteledAmount;
			scom.Parameters["@isSetteled"].Value = isSetteled;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isIssued"].Value = isIssued;
			scom.Parameters["@isRedeemed"].Value = isRedeemed;
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
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsGiftVoucher table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@giftVoucherID", SqlDbType.Int,4);
			scom.Parameters["@giftVoucherID"].Value = giftVoucherID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByPosTransaction_ID(string posTransaction_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByPosTransaction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
	//		scon.Open();
 
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
	//		scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
	//		scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
	//		scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
	//		scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
	//		scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsGiftVoucher table.
		/// </summary>
		public static tbl_bpsGiftVoucher Select(int giftVoucherID_Incoming){

			tbl_bpsGiftVoucher tbl_bpsGiftVoucherins = new tbl_bpsGiftVoucher();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@giftVoucherID", SqlDbType.Int,4);
			scom.Parameters["@giftVoucherID"].Value = giftVoucherID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsGiftVoucherins = Maketbl_bpsGiftVoucher(dataReader);
				} else {
					tbl_bpsGiftVoucherins = null;
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByPosTransaction_ID(string posTransaction_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByPosTransaction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@posTransaction_ID", SqlDbType.VarChar,20);
			scom.Parameters["@posTransaction_ID"].Value = posTransaction_ID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsGiftVoucher table by a foreign key.
		/// </summary>
		public static List<tbl_bpsGiftVoucher> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsGiftVoucherSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_bpsGiftVoucher> tbl_bpsGiftVoucherList = new List<tbl_bpsGiftVoucher>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsGiftVoucher tbl_bpsGiftVoucher = Maketbl_bpsGiftVoucher(dataReader);
					tbl_bpsGiftVoucherList.Add(tbl_bpsGiftVoucher);
				}
			}
			scon.Close();
			return tbl_bpsGiftVoucherList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsGiftVoucher class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsGiftVoucher Maketbl_bpsGiftVoucher(SqlDataReader dataReader) {
			tbl_bpsGiftVoucher tbl_bpsGiftVoucher = new tbl_bpsGiftVoucher();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsGiftVoucher.GiftVoucherID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsGiftVoucher.SerialNo = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsGiftVoucher.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsGiftVoucher.VoucherDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsGiftVoucher.DateIssued = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsGiftVoucher.DateValidFrom = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsGiftVoucher.ExpiryDate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsGiftVoucher.ValidityDays = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsGiftVoucher.Invoice_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsGiftVoucher.PosTransaction_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsGiftVoucher.FinancialYear_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsGiftVoucher.VoucherAmount = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsGiftVoucher.SetteledAmount = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsGiftVoucher.IsSetteled = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsGiftVoucher.IsChecked = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsGiftVoucher.IsApproved = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsGiftVoucher.IsIssued = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsGiftVoucher.IsRedeemed = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsGiftVoucher.IsCanceled = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsGiftVoucher.CreateUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_bpsGiftVoucher.ModifiedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_bpsGiftVoucher.CheckedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_bpsGiftVoucher.ApprovedUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_bpsGiftVoucher.CanceldUser_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_bpsGiftVoucher.DateCreate = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_bpsGiftVoucher.DateModified = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_bpsGiftVoucher.DateChecked = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_bpsGiftVoucher.DateApproved = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_bpsGiftVoucher.DateCanceled = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_bpsGiftVoucher.CreateUserTerminal_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_bpsGiftVoucher.ModifiedUserTerminal_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_bpsGiftVoucher.CheckedUserTerminal_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_bpsGiftVoucher.ApprovedUserTerminal_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_bpsGiftVoucher.CanceledUserTerminal_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_bpsGiftVoucher.CompanyID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_bpsGiftVoucher.CompanyBranchID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_bpsGiftVoucher.Item_ID = dataReader.GetString(36);
			}

			return tbl_bpsGiftVoucher;
		}
		/// <summary>
		/// This makes tbl_bpsGiftVoucher datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsGiftVoucher object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsGiftVoucher  tbl_bpsGiftVoucher   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_giftVoucherID = new DataColumn("giftVoucherID" , typeof(int));
			DataColumn col_serialNo = new DataColumn("serialNo" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_voucherDate = new DataColumn("voucherDate" , typeof(DateTime));
			DataColumn col_dateIssued = new DataColumn("dateIssued" , typeof(DateTime));
			DataColumn col_dateValidFrom = new DataColumn("dateValidFrom" , typeof(DateTime));
			DataColumn col_expiryDate = new DataColumn("expiryDate" , typeof(DateTime));
			DataColumn col_validityDays = new DataColumn("validityDays" , typeof(int));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_posTransaction_ID = new DataColumn("posTransaction_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_voucherAmount = new DataColumn("voucherAmount" , typeof(decimal));
			DataColumn col_setteledAmount = new DataColumn("setteledAmount" , typeof(decimal));
			DataColumn col_isSetteled = new DataColumn("isSetteled" , typeof(bool));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isIssued = new DataColumn("isIssued" , typeof(bool));
			DataColumn col_isRedeemed = new DataColumn("isRedeemed" , typeof(bool));
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
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_giftVoucherID,col_serialNo,col_remark,col_voucherDate,col_dateIssued,col_dateValidFrom,col_expiryDate,col_validityDays,col_invoice_ID,col_posTransaction_ID,col_financialYear_ID,col_voucherAmount,col_setteledAmount,col_isSetteled,col_isChecked,col_isApproved,col_isIssued,col_isRedeemed,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,col_item_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsGiftVoucher datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsGiftVoucher object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsGiftVoucher user) {
		DataRow drow = dt.NewRow();
		
			drow["giftVoucherID"] = user.giftVoucherID;
			drow["serialNo"] = user.serialNo;
			drow["remark"] = user.remark;
			drow["voucherDate"] = user.voucherDate;
			drow["dateIssued"] = user.dateIssued;
			drow["dateValidFrom"] = user.dateValidFrom;
			drow["expiryDate"] = user.expiryDate;
			drow["validityDays"] = user.validityDays;
			drow["invoice_ID"] = user.invoice_ID;
			drow["posTransaction_ID"] = user.posTransaction_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["voucherAmount"] = user.voucherAmount;
			drow["setteledAmount"] = user.setteledAmount;
			drow["isSetteled"] = user.isSetteled;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isIssued"] = user.isIssued;
			drow["isRedeemed"] = user.isRedeemed;
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
			drow["item_ID"] = user.item_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
