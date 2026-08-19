using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsSectionReqositionNote {
		#region Fields
		private string sectionReqositionNote_ID;
		private DateTime sectionReqositionNoteDate;
		private string remark;
		private string job_ID;
		private string fromSection_ID;
		private string toSelectArea_ID;
		private string toDepartment_ID;
		private string toSection_ID;
		private string toStore_ID;
		private string issuedRefNo_ID;
		private string purchaseRequisitionNote_ID;
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
		private bool isPRdone;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsSectionReqositionNote class.
		/// </summary>
		public tbl_scsSectionReqositionNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsSectionReqositionNote class.
		/// </summary>
		public tbl_scsSectionReqositionNote(string sectionReqositionNote_ID, DateTime sectionReqositionNoteDate, string remark, string job_ID, string fromSection_ID, string toSelectArea_ID, string toDepartment_ID, string toSection_ID, string toStore_ID, string issuedRefNo_ID, string purchaseRequisitionNote_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, int printCount, bool isSeattled, bool isPRdone) {
			this.sectionReqositionNote_ID = sectionReqositionNote_ID;
			this.sectionReqositionNoteDate = sectionReqositionNoteDate;
			this.remark = remark;
			this.job_ID = job_ID;
			this.fromSection_ID = fromSection_ID;
			this.toSelectArea_ID = toSelectArea_ID;
			this.toDepartment_ID = toDepartment_ID;
			this.toSection_ID = toSection_ID;
			this.toStore_ID = toStore_ID;
			this.issuedRefNo_ID = issuedRefNo_ID;
			this.purchaseRequisitionNote_ID = purchaseRequisitionNote_ID;
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
			this.isPRdone = isPRdone;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SectionReqositionNote_ID value.
		/// </summary>
		public string SectionReqositionNote_ID {
			get { return sectionReqositionNote_ID; }
			set { sectionReqositionNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionReqositionNoteDate value.
		/// </summary>
		public DateTime SectionReqositionNoteDate {
			get { return sectionReqositionNoteDate; }
			set { sectionReqositionNoteDate = value; }
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
		/// Gets or sets the FromSection_ID value.
		/// </summary>
		public string FromSection_ID {
			get { return fromSection_ID; }
			set { fromSection_ID = value; }
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
		/// Gets or sets the IssuedRefNo_ID value.
		/// </summary>
		public string IssuedRefNo_ID {
			get { return issuedRefNo_ID; }
			set { issuedRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseRequisitionNote_ID value.
		/// </summary>
		public string PurchaseRequisitionNote_ID {
			get { return purchaseRequisitionNote_ID; }
			set { purchaseRequisitionNote_ID = value; }
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
		/// Gets or sets the IsPRdone value.
		/// </summary>
		public bool IsPRdone {
			get { return isPRdone; }
			set { isPRdone = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsSectionReqositionNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sectionReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionReqositionNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@purchaseRequisitionNote_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isPRdone", SqlDbType.Bit,1);
 
			scom.Parameters["@sectionReqositionNote_ID"].Value = sectionReqositionNote_ID;
			scom.Parameters["@sectionReqositionNoteDate"].Value = sectionReqositionNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@purchaseRequisitionNote_ID"].Value = purchaseRequisitionNote_ID;
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
			scom.Parameters["@isPRdone"].Value = isPRdone;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsSectionReqositionNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sectionReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionReqositionNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@purchaseRequisitionNote_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isPRdone", SqlDbType.Bit,1);
 
 
			scom.Parameters["@sectionReqositionNote_ID"].Value = sectionReqositionNote_ID;
			scom.Parameters["@sectionReqositionNoteDate"].Value = sectionReqositionNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@purchaseRequisitionNote_ID"].Value = purchaseRequisitionNote_ID;
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
			scom.Parameters["@isPRdone"].Value = isPRdone;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsSectionReqositionNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@sectionReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@sectionReqositionNote_ID"].Value = sectionReqositionNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionReqositionNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionReqositionNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByToSelectArea_ID(string toSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteDeleteAllByToSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionReqositionNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteDeleteAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionReqositionNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByFromSection_ID(string fromSection_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteDeleteAllByFromSection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsSectionReqositionNote table.
		/// </summary>
		public static tbl_scsSectionReqositionNote Select(string sectionReqositionNote_ID_Incoming){

			tbl_scsSectionReqositionNote tbl_scsSectionReqositionNoteins = new tbl_scsSectionReqositionNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sectionReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@sectionReqositionNote_ID"].Value = sectionReqositionNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsSectionReqositionNoteins = Maketbl_scsSectionReqositionNote(dataReader);
				} else {
					tbl_scsSectionReqositionNoteins = null;
				}
			}
			scon.Close();
			return tbl_scsSectionReqositionNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionReqositionNote table.
		/// </summary>
		public static List<tbl_scsSectionReqositionNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsSectionReqositionNote> tbl_scsSectionReqositionNoteList = new List<tbl_scsSectionReqositionNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionReqositionNote tbl_scsSectionReqositionNote = Maketbl_scsSectionReqositionNote(dataReader);
					tbl_scsSectionReqositionNoteList.Add(tbl_scsSectionReqositionNote);
				}
			}
			scon.Close();
			return tbl_scsSectionReqositionNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionReqositionNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionReqositionNote> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_scsSectionReqositionNote> tbl_scsSectionReqositionNoteList = new List<tbl_scsSectionReqositionNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionReqositionNote tbl_scsSectionReqositionNote = Maketbl_scsSectionReqositionNote(dataReader);
					tbl_scsSectionReqositionNoteList.Add(tbl_scsSectionReqositionNote);
				}
			}
			scon.Close();
			return tbl_scsSectionReqositionNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionReqositionNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionReqositionNote> SelectAllByToSelectArea_ID(string toSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteSelectAllByToSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
				List<tbl_scsSectionReqositionNote> tbl_scsSectionReqositionNoteList = new List<tbl_scsSectionReqositionNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionReqositionNote tbl_scsSectionReqositionNote = Maketbl_scsSectionReqositionNote(dataReader);
					tbl_scsSectionReqositionNoteList.Add(tbl_scsSectionReqositionNote);
				}
			}
			scon.Close();
			return tbl_scsSectionReqositionNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionReqositionNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionReqositionNote> SelectAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteSelectAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
				List<tbl_scsSectionReqositionNote> tbl_scsSectionReqositionNoteList = new List<tbl_scsSectionReqositionNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionReqositionNote tbl_scsSectionReqositionNote = Maketbl_scsSectionReqositionNote(dataReader);
					tbl_scsSectionReqositionNoteList.Add(tbl_scsSectionReqositionNote);
				}
			}
			scon.Close();
			return tbl_scsSectionReqositionNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsSectionReqositionNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsSectionReqositionNote> SelectAllByFromSection_ID(string fromSection_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsSectionReqositionNoteSelectAllByFromSection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
				List<tbl_scsSectionReqositionNote> tbl_scsSectionReqositionNoteList = new List<tbl_scsSectionReqositionNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsSectionReqositionNote tbl_scsSectionReqositionNote = Maketbl_scsSectionReqositionNote(dataReader);
					tbl_scsSectionReqositionNoteList.Add(tbl_scsSectionReqositionNote);
				}
			}
			scon.Close();
			return tbl_scsSectionReqositionNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsSectionReqositionNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsSectionReqositionNote Maketbl_scsSectionReqositionNote(SqlDataReader dataReader) {
			tbl_scsSectionReqositionNote tbl_scsSectionReqositionNote = new tbl_scsSectionReqositionNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsSectionReqositionNote.SectionReqositionNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsSectionReqositionNote.SectionReqositionNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsSectionReqositionNote.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsSectionReqositionNote.Job_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsSectionReqositionNote.FromSection_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsSectionReqositionNote.ToSelectArea_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsSectionReqositionNote.ToDepartment_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsSectionReqositionNote.ToSection_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsSectionReqositionNote.ToStore_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsSectionReqositionNote.IssuedRefNo_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsSectionReqositionNote.PurchaseRequisitionNote_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsSectionReqositionNote.CreateUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsSectionReqositionNote.ModifiedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsSectionReqositionNote.CheckedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsSectionReqositionNote.ApprovedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsSectionReqositionNote.DeletedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsSectionReqositionNote.PrintedUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsSectionReqositionNote.CreateTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsSectionReqositionNote.ModifiedTerminal_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsSectionReqositionNote.DeletedTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsSectionReqositionNote.PrintedTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsSectionReqositionNote.DateCreate = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsSectionReqositionNote.DateModified = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsSectionReqositionNote.DateChecked = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsSectionReqositionNote.DateApproved = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_scsSectionReqositionNote.DateDeleted = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_scsSectionReqositionNote.DatePrinted = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_scsSectionReqositionNote.IsChecked = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_scsSectionReqositionNote.IsApproved = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_scsSectionReqositionNote.IsFinished = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_scsSectionReqositionNote.IsDeleted = dataReader.GetBoolean(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_scsSectionReqositionNote.IsLocked = dataReader.GetBoolean(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_scsSectionReqositionNote.PrintCount = dataReader.GetInt32(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_scsSectionReqositionNote.IsSeattled = dataReader.GetBoolean(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_scsSectionReqositionNote.IsPRdone = dataReader.GetBoolean(34);
			}

			return tbl_scsSectionReqositionNote;
		}
		/// <summary>
		/// This makes tbl_scsSectionReqositionNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsSectionReqositionNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsSectionReqositionNote  tbl_scsSectionReqositionNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_sectionReqositionNote_ID = new DataColumn("sectionReqositionNote_ID" , typeof(string));
			DataColumn col_sectionReqositionNoteDate = new DataColumn("sectionReqositionNoteDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_fromSection_ID = new DataColumn("fromSection_ID" , typeof(string));
			DataColumn col_toSelectArea_ID = new DataColumn("toSelectArea_ID" , typeof(string));
			DataColumn col_toDepartment_ID = new DataColumn("toDepartment_ID" , typeof(string));
			DataColumn col_toSection_ID = new DataColumn("toSection_ID" , typeof(string));
			DataColumn col_toStore_ID = new DataColumn("toStore_ID" , typeof(string));
			DataColumn col_IssuedRefNo_ID = new DataColumn("IssuedRefNo_ID" , typeof(string));
			DataColumn col_purchaseRequisitionNote_ID = new DataColumn("purchaseRequisitionNote_ID" , typeof(string));
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
			DataColumn col_isPRdone = new DataColumn("isPRdone" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_sectionReqositionNote_ID,col_sectionReqositionNoteDate,col_remark,col_job_ID,col_fromSection_ID,col_toSelectArea_ID,col_toDepartment_ID,col_toSection_ID,col_toStore_ID,col_IssuedRefNo_ID,col_purchaseRequisitionNote_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_printCount,col_isSeattled,col_isPRdone,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsSectionReqositionNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsSectionReqositionNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsSectionReqositionNote user) {
		DataRow drow = dt.NewRow();
		
			drow["sectionReqositionNote_ID"] = user.sectionReqositionNote_ID;
			drow["sectionReqositionNoteDate"] = user.sectionReqositionNoteDate;
			drow["remark"] = user.remark;
			drow["job_ID"] = user.job_ID;
			drow["fromSection_ID"] = user.fromSection_ID;
			drow["toSelectArea_ID"] = user.toSelectArea_ID;
			drow["toDepartment_ID"] = user.toDepartment_ID;
			drow["toSection_ID"] = user.toSection_ID;
			drow["toStore_ID"] = user.toStore_ID;
			drow["IssuedRefNo_ID"] = user.IssuedRefNo_ID;
			drow["purchaseRequisitionNote_ID"] = user.purchaseRequisitionNote_ID;
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
			drow["isPRdone"] = user.isPRdone;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
