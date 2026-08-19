using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxWorkInProgress {
		#region Fields
		private string wip_ID;
		private DateTime wip_Date;
		private DateTime prod_Date;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string item_ID_FG;
		private string uom_ID;
		private decimal fGoodQty;
		private string section_ID;
		private string activity_ID;
		private DateTime job_InTime;
		private string supervisor;
		private string qa_Officer;
		private string machine_Operator;
		private string maintainance_Officer;
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
		private string remarks;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxWorkInProgress class.
		/// </summary>
		public tbl_prod_pharmaTxWorkInProgress() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxWorkInProgress class.
		/// </summary>
		public tbl_prod_pharmaTxWorkInProgress(string wip_ID, DateTime wip_Date, DateTime prod_Date, string prodJob_ID, string prodBatch_ID, string item_ID_FG, string uom_ID, decimal fGoodQty, string section_ID, string activity_ID, DateTime job_InTime, string supervisor, string qa_Officer, string machine_Operator, string maintainance_Officer, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID, string remarks) {
			this.wip_ID = wip_ID;
			this.wip_Date = wip_Date;
			this.prod_Date = prod_Date;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.item_ID_FG = item_ID_FG;
			this.uom_ID = uom_ID;
			this.fGoodQty = fGoodQty;
			this.section_ID = section_ID;
			this.activity_ID = activity_ID;
			this.job_InTime = job_InTime;
			this.supervisor = supervisor;
			this.qa_Officer = qa_Officer;
			this.machine_Operator = machine_Operator;
			this.maintainance_Officer = maintainance_Officer;
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
			this.remarks = remarks;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Wip_ID value.
		/// </summary>
		public string Wip_ID {
			get { return wip_ID; }
			set { wip_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Wip_Date value.
		/// </summary>
		public DateTime Wip_Date {
			get { return wip_Date; }
			set { wip_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prod_Date value.
		/// </summary>
		public DateTime Prod_Date {
			get { return prod_Date; }
			set { prod_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdBatch_ID value.
		/// </summary>
		public string ProdBatch_ID {
			get { return prodBatch_ID; }
			set { prodBatch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID_FG value.
		/// </summary>
		public string Item_ID_FG {
			get { return item_ID_FG; }
			set { item_ID_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FGoodQty value.
		/// </summary>
		public decimal FGoodQty {
			get { return fGoodQty; }
			set { fGoodQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Activity_ID value.
		/// </summary>
		public string Activity_ID {
			get { return activity_ID; }
			set { activity_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_InTime value.
		/// </summary>
		public DateTime Job_InTime {
			get { return job_InTime; }
			set { job_InTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supervisor value.
		/// </summary>
		public string Supervisor {
			get { return supervisor; }
			set { supervisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qa_Officer value.
		/// </summary>
		public string Qa_Officer {
			get { return qa_Officer; }
			set { qa_Officer = value; }
		}
		
		/// <summary>
		/// Gets or sets the Machine_Operator value.
		/// </summary>
		public string Machine_Operator {
			get { return machine_Operator; }
			set { machine_Operator = value; }
		}
		
		/// <summary>
		/// Gets or sets the Maintainance_Officer value.
		/// </summary>
		public string Maintainance_Officer {
			get { return maintainance_Officer; }
			set { maintainance_Officer = value; }
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
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxWorkInProgress table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@wip_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@wip_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@prod_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fGoodQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_InTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@supervisor", SqlDbType.VarChar,100);
			scom.Parameters.Add("@qa_Officer", SqlDbType.VarChar,100);
			scom.Parameters.Add("@machine_Operator", SqlDbType.VarChar,100);
			scom.Parameters.Add("@maintainance_Officer", SqlDbType.VarChar,100);
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
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
 
			scom.Parameters["@wip_ID"].Value = wip_ID;
			scom.Parameters["@wip_Date"].Value = wip_Date;
			scom.Parameters["@prod_Date"].Value = prod_Date;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@fGoodQty"].Value = fGoodQty;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@activity_ID"].Value = activity_ID;
			scom.Parameters["@job_InTime"].Value = job_InTime;
			scom.Parameters["@supervisor"].Value = supervisor;
			scom.Parameters["@qa_Officer"].Value = qa_Officer;
			scom.Parameters["@machine_Operator"].Value = machine_Operator;
			scom.Parameters["@maintainance_Officer"].Value = maintainance_Officer;
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
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxWorkInProgress table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@wip_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@wip_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@prod_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fGoodQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@job_InTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@supervisor", SqlDbType.VarChar,100);
			scom.Parameters.Add("@qa_Officer", SqlDbType.VarChar,100);
			scom.Parameters.Add("@machine_Operator", SqlDbType.VarChar,100);
			scom.Parameters.Add("@maintainance_Officer", SqlDbType.VarChar,100);
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
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
 
 
			scom.Parameters["@wip_ID"].Value = wip_ID;
			scom.Parameters["@wip_Date"].Value = wip_Date;
			scom.Parameters["@prod_Date"].Value = prod_Date;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@fGoodQty"].Value = fGoodQty;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@activity_ID"].Value = activity_ID;
			scom.Parameters["@job_InTime"].Value = job_InTime;
			scom.Parameters["@supervisor"].Value = supervisor;
			scom.Parameters["@qa_Officer"].Value = qa_Officer;
			scom.Parameters["@machine_Operator"].Value = machine_Operator;
			scom.Parameters["@maintainance_Officer"].Value = maintainance_Officer;
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
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxWorkInProgress table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@wip_ID", SqlDbType.VarChar,20);
			scom.Parameters["@wip_ID"].Value = wip_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByActivity_ID(string activity_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByActivity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,20);
			scom.Parameters["@activity_ID"].Value = activity_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxWorkInProgress table.
		/// </summary>
		public static tbl_prod_pharmaTxWorkInProgress Select(string wip_ID_Incoming){

			tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgressins = new tbl_prod_pharmaTxWorkInProgress();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@wip_ID", SqlDbType.VarChar,20);
			scom.Parameters["@wip_ID"].Value = wip_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgressins = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
				} else {
					tbl_prod_pharmaTxWorkInProgressins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByActivity_ID(string activity_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByActivity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,20);
			scom.Parameters["@activity_ID"].Value = activity_ID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxWorkInProgress table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxWorkInProgress> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxWorkInProgressSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prod_pharmaTxWorkInProgress> tbl_prod_pharmaTxWorkInProgressList = new List<tbl_prod_pharmaTxWorkInProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = Maketbl_prod_pharmaTxWorkInProgress(dataReader);
					tbl_prod_pharmaTxWorkInProgressList.Add(tbl_prod_pharmaTxWorkInProgress);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxWorkInProgressList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxWorkInProgress class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxWorkInProgress Maketbl_prod_pharmaTxWorkInProgress(SqlDataReader dataReader) {
			tbl_prod_pharmaTxWorkInProgress tbl_prod_pharmaTxWorkInProgress = new tbl_prod_pharmaTxWorkInProgress();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxWorkInProgress.Wip_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxWorkInProgress.Wip_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxWorkInProgress.Prod_Date = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxWorkInProgress.ProdJob_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxWorkInProgress.ProdBatch_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxWorkInProgress.Item_ID_FG = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxWorkInProgress.Uom_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxWorkInProgress.FGoodQty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxWorkInProgress.Section_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_pharmaTxWorkInProgress.Activity_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_pharmaTxWorkInProgress.Job_InTime = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_pharmaTxWorkInProgress.Supervisor = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prod_pharmaTxWorkInProgress.Qa_Officer = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prod_pharmaTxWorkInProgress.Machine_Operator = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prod_pharmaTxWorkInProgress.Maintainance_Officer = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prod_pharmaTxWorkInProgress.IsChecked = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prod_pharmaTxWorkInProgress.IsApproved = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prod_pharmaTxWorkInProgress.IsCanceled = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prod_pharmaTxWorkInProgress.CreateUser_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prod_pharmaTxWorkInProgress.ModifiedUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prod_pharmaTxWorkInProgress.CheckedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prod_pharmaTxWorkInProgress.ApprovedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prod_pharmaTxWorkInProgress.CanceldUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prod_pharmaTxWorkInProgress.DateCreate = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prod_pharmaTxWorkInProgress.DateModified = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_prod_pharmaTxWorkInProgress.DateChecked = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_prod_pharmaTxWorkInProgress.DateApproved = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_prod_pharmaTxWorkInProgress.DateCanceled = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_prod_pharmaTxWorkInProgress.CreateUserTerminal_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_prod_pharmaTxWorkInProgress.ModifiedUserTerminal_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_prod_pharmaTxWorkInProgress.CheckedUserTerminal_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_prod_pharmaTxWorkInProgress.ApprovedUserTerminal_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_prod_pharmaTxWorkInProgress.CanceledUserTerminal_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_prod_pharmaTxWorkInProgress.CompanyID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_prod_pharmaTxWorkInProgress.CompanyBranchID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_prod_pharmaTxWorkInProgress.Remarks = dataReader.GetString(35);
			}

			return tbl_prod_pharmaTxWorkInProgress;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxWorkInProgress datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxWorkInProgress object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxWorkInProgress  tbl_prod_pharmaTxWorkInProgress   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_wip_ID = new DataColumn("wip_ID" , typeof(string));
			DataColumn col_wip_Date = new DataColumn("wip_Date" , typeof(DateTime));
			DataColumn col_prod_Date = new DataColumn("prod_Date" , typeof(DateTime));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_item_ID_FG = new DataColumn("item_ID_FG" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_fGoodQty = new DataColumn("fGoodQty" , typeof(decimal));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_activity_ID = new DataColumn("activity_ID" , typeof(string));
			DataColumn col_job_InTime = new DataColumn("job_InTime" , typeof(DateTime));
			DataColumn col_supervisor = new DataColumn("supervisor" , typeof(string));
			DataColumn col_qa_Officer = new DataColumn("qa_Officer" , typeof(string));
			DataColumn col_machine_Operator = new DataColumn("machine_Operator" , typeof(string));
			DataColumn col_maintainance_Officer = new DataColumn("maintainance_Officer" , typeof(string));
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
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_wip_ID,col_wip_Date,col_prod_Date,col_prodJob_ID,col_prodBatch_ID,col_item_ID_FG,col_uom_ID,col_fGoodQty,col_section_ID,col_activity_ID,col_job_InTime,col_supervisor,col_qa_Officer,col_machine_Operator,col_maintainance_Officer,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxWorkInProgress datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxWorkInProgress object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxWorkInProgress user) {
		DataRow drow = dt.NewRow();
		
			drow["wip_ID"] = user.wip_ID;
			drow["wip_Date"] = user.wip_Date;
			drow["prod_Date"] = user.prod_Date;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["item_ID_FG"] = user.item_ID_FG;
			drow["uom_ID"] = user.uom_ID;
			drow["fGoodQty"] = user.fGoodQty;
			drow["section_ID"] = user.section_ID;
			drow["activity_ID"] = user.activity_ID;
			drow["job_InTime"] = user.job_InTime;
			drow["supervisor"] = user.supervisor;
			drow["qa_Officer"] = user.qa_Officer;
			drow["machine_Operator"] = user.machine_Operator;
			drow["maintainance_Officer"] = user.maintainance_Officer;
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
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
