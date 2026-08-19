using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_posAdvanceReceived {
		#region Fields
		private int advanceReceived_Index;
		private string advanceReceived_ID;
		private string customer_ID;
		private string remark;
		private string financialYear_ID;
		private DateTime paymentDate;
		private decimal advanceAmount;
		private decimal setteledAmount;
		private bool isSetteled;
		private bool isChecked;
		private bool isApproved;
		private bool isCanceled;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string canceldUser_ID;
		private string printedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime dateCanceled;
		private DateTime datePrinted;
		private int printCount;
		private string createUserTerminal_ID;
		private string modifiedUserTerminal_ID;
		private string checkedUserTerminal_ID;
		private string approvedUserTerminal_ID;
		private string canceledUserTerminal_ID;
		private string printedTerminal_ID;
		private string companyID;
		private string companyBranchID;
		private int dayDetail_Index;
		private string glPosting_ID;
		private string postingStatus_ID;
		private bool isIncompleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_posAdvanceReceived class.
		/// </summary>
		public tbl_posAdvanceReceived() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_posAdvanceReceived class.
		/// </summary>
		public tbl_posAdvanceReceived(int advanceReceived_Index, string advanceReceived_ID, string customer_ID, string remark, string financialYear_ID, DateTime paymentDate, decimal advanceAmount, decimal setteledAmount, bool isSetteled, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, string printedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, DateTime datePrinted, int printCount, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string printedTerminal_ID, string companyID, string companyBranchID, int dayDetail_Index, string glPosting_ID, string postingStatus_ID, bool isIncompleted) {
			this.advanceReceived_Index = advanceReceived_Index;
			this.advanceReceived_ID = advanceReceived_ID;
			this.customer_ID = customer_ID;
			this.remark = remark;
			this.financialYear_ID = financialYear_ID;
			this.paymentDate = paymentDate;
			this.advanceAmount = advanceAmount;
			this.setteledAmount = setteledAmount;
			this.isSetteled = isSetteled;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isCanceled = isCanceled;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.canceldUser_ID = canceldUser_ID;
			this.printedUser_ID = printedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.dateCanceled = dateCanceled;
			this.datePrinted = datePrinted;
			this.printCount = printCount;
			this.createUserTerminal_ID = createUserTerminal_ID;
			this.modifiedUserTerminal_ID = modifiedUserTerminal_ID;
			this.checkedUserTerminal_ID = checkedUserTerminal_ID;
			this.approvedUserTerminal_ID = approvedUserTerminal_ID;
			this.canceledUserTerminal_ID = canceledUserTerminal_ID;
			this.printedTerminal_ID = printedTerminal_ID;
			this.companyID = companyID;
			this.companyBranchID = companyBranchID;
			this.dayDetail_Index = dayDetail_Index;
			this.glPosting_ID = glPosting_ID;
			this.postingStatus_ID = postingStatus_ID;
			this.isIncompleted = isIncompleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AdvanceReceived_Index value.
		/// </summary>
		public int AdvanceReceived_Index {
			get { return advanceReceived_Index; }
			set { advanceReceived_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the AdvanceReceived_ID value.
		/// </summary>
		public string AdvanceReceived_ID {
			get { return advanceReceived_ID; }
			set { advanceReceived_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentDate value.
		/// </summary>
		public DateTime PaymentDate {
			get { return paymentDate; }
			set { paymentDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the AdvanceAmount value.
		/// </summary>
		public decimal AdvanceAmount {
			get { return advanceAmount; }
			set { advanceAmount = value; }
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
		/// Gets or sets the PrintedUser_ID value.
		/// </summary>
		public string PrintedUser_ID {
			get { return printedUser_ID; }
			set { printedUser_ID = value; }
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
		/// Gets or sets the DatePrinted value.
		/// </summary>
		public DateTime DatePrinted {
			get { return datePrinted; }
			set { datePrinted = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
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
		/// Gets or sets the PrintedTerminal_ID value.
		/// </summary>
		public string PrintedTerminal_ID {
			get { return printedTerminal_ID; }
			set { printedTerminal_ID = value; }
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
		/// Gets or sets the DayDetail_Index value.
		/// </summary>
		public int DayDetail_Index {
			get { return dayDetail_Index; }
			set { dayDetail_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the GlPosting_ID value.
		/// </summary>
		public string GlPosting_ID {
			get { return glPosting_ID; }
			set { glPosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PostingStatus_ID value.
		/// </summary>
		public string PostingStatus_ID {
			get { return postingStatus_ID; }
			set { postingStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsIncompleted value.
		/// </summary>
		public bool IsIncompleted {
			get { return isIncompleted; }
			set { isIncompleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_posAdvanceReceived table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@advanceReceived_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@advanceReceived_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@advanceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@setteledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSetteled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isIncompleted", SqlDbType.Bit,1);
 
			scom.Parameters["@advanceReceived_Index"].Value = advanceReceived_Index;
			scom.Parameters["@advanceReceived_ID"].Value = advanceReceived_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@paymentDate"].Value = paymentDate;
			scom.Parameters["@advanceAmount"].Value = advanceAmount;
			scom.Parameters["@setteledAmount"].Value = setteledAmount;
			scom.Parameters["@isSetteled"].Value = isSetteled;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@checkedUserTerminal_ID"].Value = checkedUserTerminal_ID;
			scom.Parameters["@approvedUserTerminal_ID"].Value = approvedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@isIncompleted"].Value = isIncompleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_posAdvanceReceived table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@advanceReceived_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@advanceReceived_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@advanceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@setteledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSetteled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@glPosting_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isIncompleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@advanceReceived_Index"].Value = advanceReceived_Index;
			scom.Parameters["@advanceReceived_ID"].Value = advanceReceived_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@paymentDate"].Value = paymentDate;
			scom.Parameters["@advanceAmount"].Value = advanceAmount;
			scom.Parameters["@setteledAmount"].Value = setteledAmount;
			scom.Parameters["@isSetteled"].Value = isSetteled;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@checkedUserTerminal_ID"].Value = checkedUserTerminal_ID;
			scom.Parameters["@approvedUserTerminal_ID"].Value = approvedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
			scom.Parameters["@glPosting_ID"].Value = glPosting_ID;
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@isIncompleted"].Value = isIncompleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_posAdvanceReceived table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@advanceReceived_Index", SqlDbType.Int,4);
			scom.Parameters["@advanceReceived_Index"].Value = advanceReceived_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static void DeleteAllByDayDetail_Index(int dayDetail_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDeleteAllByDayDetail_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static void DeleteAllByPrintedUser_ID(string printedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDeleteAllByPrintedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_posAdvanceReceived table.
		/// </summary>
		public static tbl_posAdvanceReceived Select(int advanceReceived_Index_Incoming){

			tbl_posAdvanceReceived tbl_posAdvanceReceivedins = new tbl_posAdvanceReceived();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@advanceReceived_Index", SqlDbType.Int,4);
			scom.Parameters["@advanceReceived_Index"].Value = advanceReceived_Index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_posAdvanceReceivedins = Maketbl_posAdvanceReceived(dataReader);
				} else {
					tbl_posAdvanceReceivedins = null;
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAllByDayDetail_Index(int dayDetail_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAllByDayDetail_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@dayDetail_Index", SqlDbType.Int,4);
			scom.Parameters["@dayDetail_Index"].Value = dayDetail_Index;
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAllByPrintedUser_ID(string printedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAllByPrintedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posAdvanceReceived table by a foreign key.
		/// </summary>
		public static List<tbl_posAdvanceReceived> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posAdvanceReceivedSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_posAdvanceReceived> tbl_posAdvanceReceivedList = new List<tbl_posAdvanceReceived>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posAdvanceReceived tbl_posAdvanceReceived = Maketbl_posAdvanceReceived(dataReader);
					tbl_posAdvanceReceivedList.Add(tbl_posAdvanceReceived);
				}
			}
			scon.Close();
			return tbl_posAdvanceReceivedList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_posAdvanceReceived class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_posAdvanceReceived Maketbl_posAdvanceReceived(SqlDataReader dataReader) {
			tbl_posAdvanceReceived tbl_posAdvanceReceived = new tbl_posAdvanceReceived();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_posAdvanceReceived.AdvanceReceived_Index = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_posAdvanceReceived.AdvanceReceived_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_posAdvanceReceived.Customer_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_posAdvanceReceived.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_posAdvanceReceived.FinancialYear_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_posAdvanceReceived.PaymentDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_posAdvanceReceived.AdvanceAmount = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_posAdvanceReceived.SetteledAmount = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_posAdvanceReceived.IsSetteled = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_posAdvanceReceived.IsChecked = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_posAdvanceReceived.IsApproved = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_posAdvanceReceived.IsCanceled = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_posAdvanceReceived.CreateUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_posAdvanceReceived.ModifiedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_posAdvanceReceived.CheckedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_posAdvanceReceived.ApprovedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_posAdvanceReceived.CanceldUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_posAdvanceReceived.PrintedUser_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_posAdvanceReceived.DateCreate = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_posAdvanceReceived.DateModified = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_posAdvanceReceived.DateChecked = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_posAdvanceReceived.DateApproved = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_posAdvanceReceived.DateCanceled = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_posAdvanceReceived.DatePrinted = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_posAdvanceReceived.PrintCount = dataReader.GetInt32(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_posAdvanceReceived.CreateUserTerminal_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_posAdvanceReceived.ModifiedUserTerminal_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_posAdvanceReceived.CheckedUserTerminal_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_posAdvanceReceived.ApprovedUserTerminal_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_posAdvanceReceived.CanceledUserTerminal_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_posAdvanceReceived.PrintedTerminal_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_posAdvanceReceived.CompanyID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_posAdvanceReceived.CompanyBranchID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_posAdvanceReceived.DayDetail_Index = dataReader.GetInt32(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_posAdvanceReceived.GlPosting_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_posAdvanceReceived.PostingStatus_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_posAdvanceReceived.IsIncompleted = dataReader.GetBoolean(36);
			}

			return tbl_posAdvanceReceived;
		}
		/// <summary>
		/// This makes tbl_posAdvanceReceived datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_posAdvanceReceived object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_posAdvanceReceived  tbl_posAdvanceReceived   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_advanceReceived_Index = new DataColumn("advanceReceived_Index" , typeof(int));
			DataColumn col_advanceReceived_ID = new DataColumn("advanceReceived_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_paymentDate = new DataColumn("paymentDate" , typeof(DateTime));
			DataColumn col_advanceAmount = new DataColumn("advanceAmount" , typeof(decimal));
			DataColumn col_setteledAmount = new DataColumn("setteledAmount" , typeof(decimal));
			DataColumn col_isSetteled = new DataColumn("isSetteled" , typeof(bool));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_canceldUser_ID = new DataColumn("canceldUser_ID" , typeof(string));
			DataColumn col_printedUser_ID = new DataColumn("printedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
			DataColumn col_datePrinted = new DataColumn("datePrinted" , typeof(DateTime));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_createUserTerminal_ID = new DataColumn("createUserTerminal_ID" , typeof(string));
			DataColumn col_modifiedUserTerminal_ID = new DataColumn("modifiedUserTerminal_ID" , typeof(string));
			DataColumn col_checkedUserTerminal_ID = new DataColumn("checkedUserTerminal_ID" , typeof(string));
			DataColumn col_approvedUserTerminal_ID = new DataColumn("approvedUserTerminal_ID" , typeof(string));
			DataColumn col_canceledUserTerminal_ID = new DataColumn("canceledUserTerminal_ID" , typeof(string));
			DataColumn col_printedTerminal_ID = new DataColumn("printedTerminal_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranchID = new DataColumn("companyBranchID" , typeof(string));
			DataColumn col_dayDetail_Index = new DataColumn("dayDetail_Index" , typeof(int));
			DataColumn col_glPosting_ID = new DataColumn("glPosting_ID" , typeof(string));
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_isIncompleted = new DataColumn("isIncompleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_advanceReceived_Index,col_advanceReceived_ID,col_customer_ID,col_remark,col_financialYear_ID,col_paymentDate,col_advanceAmount,col_setteledAmount,col_isSetteled,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_printedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_datePrinted,col_printCount,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_printedTerminal_ID,col_companyID,col_companyBranchID,col_dayDetail_Index,col_glPosting_ID,col_postingStatus_ID,col_isIncompleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_posAdvanceReceived datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_posAdvanceReceived object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_posAdvanceReceived user) {
		DataRow drow = dt.NewRow();
		
			drow["advanceReceived_Index"] = user.advanceReceived_Index;
			drow["advanceReceived_ID"] = user.advanceReceived_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["remark"] = user.remark;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["paymentDate"] = user.paymentDate;
			drow["advanceAmount"] = user.advanceAmount;
			drow["setteledAmount"] = user.setteledAmount;
			drow["isSetteled"] = user.isSetteled;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isCanceled"] = user.isCanceled;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["canceldUser_ID"] = user.canceldUser_ID;
			drow["printedUser_ID"] = user.printedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["dateCanceled"] = user.dateCanceled;
			drow["datePrinted"] = user.datePrinted;
			drow["printCount"] = user.printCount;
			drow["createUserTerminal_ID"] = user.createUserTerminal_ID;
			drow["modifiedUserTerminal_ID"] = user.modifiedUserTerminal_ID;
			drow["checkedUserTerminal_ID"] = user.checkedUserTerminal_ID;
			drow["approvedUserTerminal_ID"] = user.approvedUserTerminal_ID;
			drow["canceledUserTerminal_ID"] = user.canceledUserTerminal_ID;
			drow["printedTerminal_ID"] = user.printedTerminal_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranchID"] = user.companyBranchID;
			drow["dayDetail_Index"] = user.dayDetail_Index;
			drow["glPosting_ID"] = user.glPosting_ID;
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["isIncompleted"] = user.isIncompleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
