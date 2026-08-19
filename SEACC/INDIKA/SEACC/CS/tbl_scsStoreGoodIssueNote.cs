using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsStoreGoodIssueNote {
		#region Fields
		private string storeGoodIssueNote_ID;
		private DateTime storeGoodIssueNoteDate;
		private string remark;
		private string job_ID;
		private string fromStore_ID;
		private string toSelectArea_ID;
		private string toDepartment_ID;
		private string toSection_ID;
		private string toStore_ID;
		private string departmentReqositionNote_ID;
		private string sectionRequisitionNote_ID;
		private string storeRequisitionNote_ID;
		private string issuedRefNo_ID;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string deletedUser_ID;
		private string printedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deletedTerminal_ID;
		private string printedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime dateDeleted;
		private DateTime datePrinted;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private int printCount;
		private bool isSeattled;
		private string itemPriceCategory;
		private string companyID;
		private string companyBranch_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsStoreGoodIssueNote class.
		/// </summary>
		public tbl_scsStoreGoodIssueNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsStoreGoodIssueNote class.
		/// </summary>
		public tbl_scsStoreGoodIssueNote(string storeGoodIssueNote_ID, DateTime storeGoodIssueNoteDate, string remark, string job_ID, string fromStore_ID, string toSelectArea_ID, string toDepartment_ID, string toSection_ID, string toStore_ID, string departmentReqositionNote_ID, string sectionRequisitionNote_ID, string storeRequisitionNote_ID, string issuedRefNo_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, int printCount, bool isSeattled, string itemPriceCategory, string companyID, string companyBranch_ID) {
			this.storeGoodIssueNote_ID = storeGoodIssueNote_ID;
			this.storeGoodIssueNoteDate = storeGoodIssueNoteDate;
			this.remark = remark;
			this.job_ID = job_ID;
			this.fromStore_ID = fromStore_ID;
			this.toSelectArea_ID = toSelectArea_ID;
			this.toDepartment_ID = toDepartment_ID;
			this.toSection_ID = toSection_ID;
			this.toStore_ID = toStore_ID;
			this.departmentReqositionNote_ID = departmentReqositionNote_ID;
			this.sectionRequisitionNote_ID = sectionRequisitionNote_ID;
			this.storeRequisitionNote_ID = storeRequisitionNote_ID;
			this.issuedRefNo_ID = issuedRefNo_ID;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.deletedUser_ID = deletedUser_ID;
			this.printedUser_ID = printedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deletedTerminal_ID = deletedTerminal_ID;
			this.printedTerminal_ID = printedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.dateDeleted = dateDeleted;
			this.datePrinted = datePrinted;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.printCount = printCount;
			this.isSeattled = isSeattled;
			this.itemPriceCategory = itemPriceCategory;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the StoreGoodIssueNote_ID value.
		/// </summary>
		public string StoreGoodIssueNote_ID {
			get { return storeGoodIssueNote_ID; }
			set { storeGoodIssueNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StoreGoodIssueNoteDate value.
		/// </summary>
		public DateTime StoreGoodIssueNoteDate {
			get { return storeGoodIssueNoteDate; }
			set { storeGoodIssueNoteDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromStore_ID value.
		/// </summary>
		public string FromStore_ID {
			get { return fromStore_ID; }
			set { fromStore_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToSelectArea_ID value.
		/// </summary>
		public string ToSelectArea_ID {
			get { return toSelectArea_ID; }
			set { toSelectArea_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToDepartment_ID value.
		/// </summary>
		public string ToDepartment_ID {
			get { return toDepartment_ID; }
			set { toDepartment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToSection_ID value.
		/// </summary>
		public string ToSection_ID {
			get { return toSection_ID; }
			set { toSection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToStore_ID value.
		/// </summary>
		public string ToStore_ID {
			get { return toStore_ID; }
			set { toStore_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepartmentReqositionNote_ID value.
		/// </summary>
		public string DepartmentReqositionNote_ID {
			get { return departmentReqositionNote_ID; }
			set { departmentReqositionNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionRequisitionNote_ID value.
		/// </summary>
		public string SectionRequisitionNote_ID {
			get { return sectionRequisitionNote_ID; }
			set { sectionRequisitionNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StoreRequisitionNote_ID value.
		/// </summary>
		public string StoreRequisitionNote_ID {
			get { return storeRequisitionNote_ID; }
			set { storeRequisitionNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IssuedRefNo_ID value.
		/// </summary>
		public string IssuedRefNo_ID {
			get { return issuedRefNo_ID; }
			set { issuedRefNo_ID = value; }
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
		/// Gets or sets the DeletedUser_ID value.
		/// </summary>
		public string DeletedUser_ID {
			get { return deletedUser_ID; }
			set { deletedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintedUser_ID value.
		/// </summary>
		public string PrintedUser_ID {
			get { return printedUser_ID; }
			set { printedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeletedTerminal_ID value.
		/// </summary>
		public string DeletedTerminal_ID {
			get { return deletedTerminal_ID; }
			set { deletedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintedTerminal_ID value.
		/// </summary>
		public string PrintedTerminal_ID {
			get { return printedTerminal_ID; }
			set { printedTerminal_ID = value; }
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
		/// Gets or sets the DateDeleted value.
		/// </summary>
		public DateTime DateDeleted {
			get { return dateDeleted; }
			set { dateDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the DatePrinted value.
		/// </summary>
		public DateTime DatePrinted {
			get { return datePrinted; }
			set { datePrinted = value; }
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
		/// Gets or sets the IsFinished value.
		/// </summary>
		public bool IsFinished {
			get { return isFinished; }
			set { isFinished = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSeattled value.
		/// </summary>
		public bool IsSeattled {
			get { return isSeattled; }
			set { isSeattled = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemPriceCategory value.
		/// </summary>
		public string ItemPriceCategory {
			get { return itemPriceCategory; }
			set { itemPriceCategory = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsStoreGoodIssueNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@storeGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeGoodIssueNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionRequisitionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeRequisitionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@storeGoodIssueNote_ID"].Value = storeGoodIssueNote_ID;
			scom.Parameters["@storeGoodIssueNoteDate"].Value = storeGoodIssueNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromStore_ID"].Value = fromStore_ID;
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
			scom.Parameters["@departmentReqositionNote_ID"].Value = departmentReqositionNote_ID;
			scom.Parameters["@sectionRequisitionNote_ID"].Value = sectionRequisitionNote_ID;
			scom.Parameters["@storeRequisitionNote_ID"].Value = storeRequisitionNote_ID;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsStoreGoodIssueNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@storeGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeGoodIssueNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionRequisitionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeRequisitionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemPriceCategory", SqlDbType.VarChar,20);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@storeGoodIssueNote_ID"].Value = storeGoodIssueNote_ID;
			scom.Parameters["@storeGoodIssueNoteDate"].Value = storeGoodIssueNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromStore_ID"].Value = fromStore_ID;
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
			scom.Parameters["@departmentReqositionNote_ID"].Value = departmentReqositionNote_ID;
			scom.Parameters["@sectionRequisitionNote_ID"].Value = sectionRequisitionNote_ID;
			scom.Parameters["@storeRequisitionNote_ID"].Value = storeRequisitionNote_ID;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@itemPriceCategory"].Value = itemPriceCategory;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsStoreGoodIssueNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@storeGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@storeGoodIssueNote_ID"].Value = storeGoodIssueNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByToSelectArea_ID(string toSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteDeleteAllByToSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteDeleteAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByFromStore_ID(string fromStore_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteDeleteAllByFromStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromStore_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fromStore_ID"].Value = fromStore_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsStoreGoodIssueNote table.
		/// </summary>
		public static tbl_scsStoreGoodIssueNote Select(string storeGoodIssueNote_ID_Incoming){

			tbl_scsStoreGoodIssueNote tbl_scsStoreGoodIssueNoteins = new tbl_scsStoreGoodIssueNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@storeGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@storeGoodIssueNote_ID"].Value = storeGoodIssueNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsStoreGoodIssueNoteins = Maketbl_scsStoreGoodIssueNote(dataReader);
				} else {
					tbl_scsStoreGoodIssueNoteins = null;
				}
			}
			scon.Close();
			return tbl_scsStoreGoodIssueNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodIssueNote table.
		/// </summary>
		public static List<tbl_scsStoreGoodIssueNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsStoreGoodIssueNote> tbl_scsStoreGoodIssueNoteList = new List<tbl_scsStoreGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStoreGoodIssueNote tbl_scsStoreGoodIssueNote = Maketbl_scsStoreGoodIssueNote(dataReader);
					tbl_scsStoreGoodIssueNoteList.Add(tbl_scsStoreGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_scsStoreGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsStoreGoodIssueNote> SelectAllByToSelectArea_ID(string toSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteSelectAllByToSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
				List<tbl_scsStoreGoodIssueNote> tbl_scsStoreGoodIssueNoteList = new List<tbl_scsStoreGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStoreGoodIssueNote tbl_scsStoreGoodIssueNote = Maketbl_scsStoreGoodIssueNote(dataReader);
					tbl_scsStoreGoodIssueNoteList.Add(tbl_scsStoreGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_scsStoreGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsStoreGoodIssueNote> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_scsStoreGoodIssueNote> tbl_scsStoreGoodIssueNoteList = new List<tbl_scsStoreGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStoreGoodIssueNote tbl_scsStoreGoodIssueNote = Maketbl_scsStoreGoodIssueNote(dataReader);
					tbl_scsStoreGoodIssueNoteList.Add(tbl_scsStoreGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_scsStoreGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsStoreGoodIssueNote> SelectAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteSelectAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
				List<tbl_scsStoreGoodIssueNote> tbl_scsStoreGoodIssueNoteList = new List<tbl_scsStoreGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStoreGoodIssueNote tbl_scsStoreGoodIssueNote = Maketbl_scsStoreGoodIssueNote(dataReader);
					tbl_scsStoreGoodIssueNoteList.Add(tbl_scsStoreGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_scsStoreGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsStoreGoodIssueNote> SelectAllByFromStore_ID(string fromStore_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodIssueNoteSelectAllByFromStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromStore_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fromStore_ID"].Value = fromStore_ID;
				List<tbl_scsStoreGoodIssueNote> tbl_scsStoreGoodIssueNoteList = new List<tbl_scsStoreGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStoreGoodIssueNote tbl_scsStoreGoodIssueNote = Maketbl_scsStoreGoodIssueNote(dataReader);
					tbl_scsStoreGoodIssueNoteList.Add(tbl_scsStoreGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_scsStoreGoodIssueNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsStoreGoodIssueNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsStoreGoodIssueNote Maketbl_scsStoreGoodIssueNote(SqlDataReader dataReader) {
			tbl_scsStoreGoodIssueNote tbl_scsStoreGoodIssueNote = new tbl_scsStoreGoodIssueNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsStoreGoodIssueNote.StoreGoodIssueNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsStoreGoodIssueNote.StoreGoodIssueNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsStoreGoodIssueNote.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsStoreGoodIssueNote.Job_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsStoreGoodIssueNote.FromStore_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsStoreGoodIssueNote.ToSelectArea_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsStoreGoodIssueNote.ToDepartment_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsStoreGoodIssueNote.ToSection_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsStoreGoodIssueNote.ToStore_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsStoreGoodIssueNote.DepartmentReqositionNote_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsStoreGoodIssueNote.SectionRequisitionNote_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsStoreGoodIssueNote.StoreRequisitionNote_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsStoreGoodIssueNote.IssuedRefNo_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsStoreGoodIssueNote.CreateUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsStoreGoodIssueNote.ModifiedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsStoreGoodIssueNote.CheckedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsStoreGoodIssueNote.ApprovedUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsStoreGoodIssueNote.DeletedUser_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsStoreGoodIssueNote.PrintedUser_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsStoreGoodIssueNote.CreateTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsStoreGoodIssueNote.ModifiedTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsStoreGoodIssueNote.DeletedTerminal_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsStoreGoodIssueNote.PrintedTerminal_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsStoreGoodIssueNote.DateCreate = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsStoreGoodIssueNote.DateModified = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_scsStoreGoodIssueNote.DateChecked = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_scsStoreGoodIssueNote.DateApproved = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_scsStoreGoodIssueNote.DateDeleted = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_scsStoreGoodIssueNote.DatePrinted = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_scsStoreGoodIssueNote.IsChecked = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_scsStoreGoodIssueNote.IsApproved = dataReader.GetBoolean(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_scsStoreGoodIssueNote.IsFinished = dataReader.GetBoolean(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_scsStoreGoodIssueNote.IsDeleted = dataReader.GetBoolean(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_scsStoreGoodIssueNote.IsLocked = dataReader.GetBoolean(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_scsStoreGoodIssueNote.PrintCount = dataReader.GetInt32(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_scsStoreGoodIssueNote.IsSeattled = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_scsStoreGoodIssueNote.ItemPriceCategory = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_scsStoreGoodIssueNote.CompanyID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_scsStoreGoodIssueNote.CompanyBranch_ID = dataReader.GetString(38);
			}

			return tbl_scsStoreGoodIssueNote;
		}
		/// <summary>
		/// This makes tbl_scsStoreGoodIssueNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsStoreGoodIssueNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsStoreGoodIssueNote  tbl_scsStoreGoodIssueNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_storeGoodIssueNote_ID = new DataColumn("storeGoodIssueNote_ID" , typeof(string));
			DataColumn col_storeGoodIssueNoteDate = new DataColumn("storeGoodIssueNoteDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_fromStore_ID = new DataColumn("fromStore_ID" , typeof(string));
			DataColumn col_toSelectArea_ID = new DataColumn("toSelectArea_ID" , typeof(string));
			DataColumn col_toDepartment_ID = new DataColumn("toDepartment_ID" , typeof(string));
			DataColumn col_toSection_ID = new DataColumn("toSection_ID" , typeof(string));
			DataColumn col_toStore_ID = new DataColumn("toStore_ID" , typeof(string));
			DataColumn col_departmentReqositionNote_ID = new DataColumn("departmentReqositionNote_ID" , typeof(string));
			DataColumn col_sectionRequisitionNote_ID = new DataColumn("sectionRequisitionNote_ID" , typeof(string));
			DataColumn col_storeRequisitionNote_ID = new DataColumn("storeRequisitionNote_ID" , typeof(string));
			DataColumn col_IssuedRefNo_ID = new DataColumn("IssuedRefNo_ID" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_deletedUser_ID = new DataColumn("deletedUser_ID" , typeof(string));
			DataColumn col_printedUser_ID = new DataColumn("printedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID" , typeof(string));
			DataColumn col_printedTerminal_ID = new DataColumn("printedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_dateDeleted = new DataColumn("dateDeleted" , typeof(DateTime));
			DataColumn col_datePrinted = new DataColumn("datePrinted" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_itemPriceCategory = new DataColumn("itemPriceCategory" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_storeGoodIssueNote_ID,col_storeGoodIssueNoteDate,col_remark,col_job_ID,col_fromStore_ID,col_toSelectArea_ID,col_toDepartment_ID,col_toSection_ID,col_toStore_ID,col_departmentReqositionNote_ID,col_sectionRequisitionNote_ID,col_storeRequisitionNote_ID,col_IssuedRefNo_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_printCount,col_isSeattled,col_itemPriceCategory,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsStoreGoodIssueNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsStoreGoodIssueNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsStoreGoodIssueNote user) {
		DataRow drow = dt.NewRow();
		
			drow["storeGoodIssueNote_ID"] = user.storeGoodIssueNote_ID;
			drow["storeGoodIssueNoteDate"] = user.storeGoodIssueNoteDate;
			drow["remark"] = user.remark;
			drow["job_ID"] = user.job_ID;
			drow["fromStore_ID"] = user.fromStore_ID;
			drow["toSelectArea_ID"] = user.toSelectArea_ID;
			drow["toDepartment_ID"] = user.toDepartment_ID;
			drow["toSection_ID"] = user.toSection_ID;
			drow["toStore_ID"] = user.toStore_ID;
			drow["departmentReqositionNote_ID"] = user.departmentReqositionNote_ID;
			drow["sectionRequisitionNote_ID"] = user.sectionRequisitionNote_ID;
			drow["storeRequisitionNote_ID"] = user.storeRequisitionNote_ID;
			drow["IssuedRefNo_ID"] = user.IssuedRefNo_ID;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["deletedUser_ID"] = user.deletedUser_ID;
			drow["printedUser_ID"] = user.printedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
			drow["printedTerminal_ID"] = user.printedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["dateDeleted"] = user.dateDeleted;
			drow["datePrinted"] = user.datePrinted;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["printCount"] = user.printCount;
			drow["isSeattled"] = user.isSeattled;
			drow["itemPriceCategory"] = user.itemPriceCategory;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
