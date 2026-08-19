using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsStoreGoodReceiveNote {
		#region Fields
		private string storeGoodReceiveNote_ID;
		private DateTime storeGoodReceiveNoteDate;
		private string remark;
		private string job_ID;
		private string fromSelectArea_ID;
		private string fromDepartment_ID;
		private string fromSection_ID;
		private string fromStore_ID;
		private string toStore_ID;
		private string departmentGoodIssueNote_ID;
		private string sectionGoodIssueNote_ID;
		private string storeGoodIssueNote_ID;
		private string issuedRefNo_ID;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private int printCount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsStoreGoodReceiveNote class.
		/// </summary>
		public tbl_scsStoreGoodReceiveNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsStoreGoodReceiveNote class.
		/// </summary>
		public tbl_scsStoreGoodReceiveNote(string storeGoodReceiveNote_ID, DateTime storeGoodReceiveNoteDate, string remark, string job_ID, string fromSelectArea_ID, string fromDepartment_ID, string fromSection_ID, string fromStore_ID, string toStore_ID, string departmentGoodIssueNote_ID, string sectionGoodIssueNote_ID, string storeGoodIssueNote_ID, string issuedRefNo_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, int printCount) {
			this.storeGoodReceiveNote_ID = storeGoodReceiveNote_ID;
			this.storeGoodReceiveNoteDate = storeGoodReceiveNoteDate;
			this.remark = remark;
			this.job_ID = job_ID;
			this.fromSelectArea_ID = fromSelectArea_ID;
			this.fromDepartment_ID = fromDepartment_ID;
			this.fromSection_ID = fromSection_ID;
			this.fromStore_ID = fromStore_ID;
			this.toStore_ID = toStore_ID;
			this.departmentGoodIssueNote_ID = departmentGoodIssueNote_ID;
			this.sectionGoodIssueNote_ID = sectionGoodIssueNote_ID;
			this.storeGoodIssueNote_ID = storeGoodIssueNote_ID;
			this.issuedRefNo_ID = issuedRefNo_ID;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.printCount = printCount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the StoreGoodReceiveNote_ID value.
		/// </summary>
		public string StoreGoodReceiveNote_ID {
			get { return storeGoodReceiveNote_ID; }
			set { storeGoodReceiveNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StoreGoodReceiveNoteDate value.
		/// </summary>
		public DateTime StoreGoodReceiveNoteDate {
			get { return storeGoodReceiveNoteDate; }
			set { storeGoodReceiveNoteDate = value; }
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
		/// Gets or sets the FromSelectArea_ID value.
		/// </summary>
		public string FromSelectArea_ID {
			get { return fromSelectArea_ID; }
			set { fromSelectArea_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromDepartment_ID value.
		/// </summary>
		public string FromDepartment_ID {
			get { return fromDepartment_ID; }
			set { fromDepartment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromSection_ID value.
		/// </summary>
		public string FromSection_ID {
			get { return fromSection_ID; }
			set { fromSection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromStore_ID value.
		/// </summary>
		public string FromStore_ID {
			get { return fromStore_ID; }
			set { fromStore_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToStore_ID value.
		/// </summary>
		public string ToStore_ID {
			get { return toStore_ID; }
			set { toStore_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepartmentGoodIssueNote_ID value.
		/// </summary>
		public string DepartmentGoodIssueNote_ID {
			get { return departmentGoodIssueNote_ID; }
			set { departmentGoodIssueNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionGoodIssueNote_ID value.
		/// </summary>
		public string SectionGoodIssueNote_ID {
			get { return sectionGoodIssueNote_ID; }
			set { sectionGoodIssueNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StoreGoodIssueNote_ID value.
		/// </summary>
		public string StoreGoodIssueNote_ID {
			get { return storeGoodIssueNote_ID; }
			set { storeGoodIssueNote_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsStoreGoodReceiveNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@storeGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeGoodReceiveNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fromDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
			scom.Parameters["@storeGoodReceiveNote_ID"].Value = storeGoodReceiveNote_ID;
			scom.Parameters["@storeGoodReceiveNoteDate"].Value = storeGoodReceiveNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromSelectArea_ID"].Value = fromSelectArea_ID;
			scom.Parameters["@fromDepartment_ID"].Value = fromDepartment_ID;
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
			scom.Parameters["@fromStore_ID"].Value = fromStore_ID;
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
			scom.Parameters["@departmentGoodIssueNote_ID"].Value = departmentGoodIssueNote_ID;
			scom.Parameters["@sectionGoodIssueNote_ID"].Value = sectionGoodIssueNote_ID;
			scom.Parameters["@storeGoodIssueNote_ID"].Value = storeGoodIssueNote_ID;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsStoreGoodReceiveNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@storeGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeGoodReceiveNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fromDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
 
			scom.Parameters["@storeGoodReceiveNote_ID"].Value = storeGoodReceiveNote_ID;
			scom.Parameters["@storeGoodReceiveNoteDate"].Value = storeGoodReceiveNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromSelectArea_ID"].Value = fromSelectArea_ID;
			scom.Parameters["@fromDepartment_ID"].Value = fromDepartment_ID;
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
			scom.Parameters["@fromStore_ID"].Value = fromStore_ID;
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
			scom.Parameters["@departmentGoodIssueNote_ID"].Value = departmentGoodIssueNote_ID;
			scom.Parameters["@sectionGoodIssueNote_ID"].Value = sectionGoodIssueNote_ID;
			scom.Parameters["@storeGoodIssueNote_ID"].Value = storeGoodIssueNote_ID;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsStoreGoodReceiveNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@storeGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@storeGoodReceiveNote_ID"].Value = storeGoodReceiveNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodReceiveNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByToStore_ID(string toStore_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteDeleteAllByToStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodReceiveNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByFromSelectArea_ID(string fromSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteDeleteAllByFromSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@fromSelectArea_ID"].Value = fromSelectArea_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodReceiveNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodReceiveNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteDeleteAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsStoreGoodReceiveNote table.
		/// </summary>
		public static tbl_scsStoreGoodReceiveNote Select(string storeGoodReceiveNote_ID_Incoming){

			tbl_scsStoreGoodReceiveNote tbl_scsStoreGoodReceiveNoteins = new tbl_scsStoreGoodReceiveNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@storeGoodReceiveNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@storeGoodReceiveNote_ID"].Value = storeGoodReceiveNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsStoreGoodReceiveNoteins = Maketbl_scsStoreGoodReceiveNote(dataReader);
				} else {
					tbl_scsStoreGoodReceiveNoteins = null;
				}
			}
			scon.Close();
			return tbl_scsStoreGoodReceiveNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodReceiveNote table.
		/// </summary>
		public static List<tbl_scsStoreGoodReceiveNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsStoreGoodReceiveNote> tbl_scsStoreGoodReceiveNoteList = new List<tbl_scsStoreGoodReceiveNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStoreGoodReceiveNote tbl_scsStoreGoodReceiveNote = Maketbl_scsStoreGoodReceiveNote(dataReader);
					tbl_scsStoreGoodReceiveNoteList.Add(tbl_scsStoreGoodReceiveNote);
				}
			}
			scon.Close();
			return tbl_scsStoreGoodReceiveNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodReceiveNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsStoreGoodReceiveNote> SelectAllByToStore_ID(string toStore_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteSelectAllByToStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
				List<tbl_scsStoreGoodReceiveNote> tbl_scsStoreGoodReceiveNoteList = new List<tbl_scsStoreGoodReceiveNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStoreGoodReceiveNote tbl_scsStoreGoodReceiveNote = Maketbl_scsStoreGoodReceiveNote(dataReader);
					tbl_scsStoreGoodReceiveNoteList.Add(tbl_scsStoreGoodReceiveNote);
				}
			}
			scon.Close();
			return tbl_scsStoreGoodReceiveNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodReceiveNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsStoreGoodReceiveNote> SelectAllByFromSelectArea_ID(string fromSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteSelectAllByFromSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@fromSelectArea_ID"].Value = fromSelectArea_ID;
				List<tbl_scsStoreGoodReceiveNote> tbl_scsStoreGoodReceiveNoteList = new List<tbl_scsStoreGoodReceiveNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStoreGoodReceiveNote tbl_scsStoreGoodReceiveNote = Maketbl_scsStoreGoodReceiveNote(dataReader);
					tbl_scsStoreGoodReceiveNoteList.Add(tbl_scsStoreGoodReceiveNote);
				}
			}
			scon.Close();
			return tbl_scsStoreGoodReceiveNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodReceiveNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsStoreGoodReceiveNote> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_scsStoreGoodReceiveNote> tbl_scsStoreGoodReceiveNoteList = new List<tbl_scsStoreGoodReceiveNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStoreGoodReceiveNote tbl_scsStoreGoodReceiveNote = Maketbl_scsStoreGoodReceiveNote(dataReader);
					tbl_scsStoreGoodReceiveNoteList.Add(tbl_scsStoreGoodReceiveNote);
				}
			}
			scon.Close();
			return tbl_scsStoreGoodReceiveNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStoreGoodReceiveNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsStoreGoodReceiveNote> SelectAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStoreGoodReceiveNoteSelectAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
				List<tbl_scsStoreGoodReceiveNote> tbl_scsStoreGoodReceiveNoteList = new List<tbl_scsStoreGoodReceiveNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStoreGoodReceiveNote tbl_scsStoreGoodReceiveNote = Maketbl_scsStoreGoodReceiveNote(dataReader);
					tbl_scsStoreGoodReceiveNoteList.Add(tbl_scsStoreGoodReceiveNote);
				}
			}
			scon.Close();
			return tbl_scsStoreGoodReceiveNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsStoreGoodReceiveNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsStoreGoodReceiveNote Maketbl_scsStoreGoodReceiveNote(SqlDataReader dataReader) {
			tbl_scsStoreGoodReceiveNote tbl_scsStoreGoodReceiveNote = new tbl_scsStoreGoodReceiveNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsStoreGoodReceiveNote.StoreGoodReceiveNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsStoreGoodReceiveNote.StoreGoodReceiveNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsStoreGoodReceiveNote.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsStoreGoodReceiveNote.Job_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsStoreGoodReceiveNote.FromSelectArea_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsStoreGoodReceiveNote.FromDepartment_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsStoreGoodReceiveNote.FromSection_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsStoreGoodReceiveNote.FromStore_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsStoreGoodReceiveNote.ToStore_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsStoreGoodReceiveNote.DepartmentGoodIssueNote_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsStoreGoodReceiveNote.SectionGoodIssueNote_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsStoreGoodReceiveNote.StoreGoodIssueNote_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsStoreGoodReceiveNote.IssuedRefNo_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsStoreGoodReceiveNote.CreateUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsStoreGoodReceiveNote.ModifiedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsStoreGoodReceiveNote.CheckedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsStoreGoodReceiveNote.ApprovedUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsStoreGoodReceiveNote.DateCreate = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsStoreGoodReceiveNote.DateModified = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsStoreGoodReceiveNote.DateChecked = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsStoreGoodReceiveNote.DateApproved = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsStoreGoodReceiveNote.IsChecked = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsStoreGoodReceiveNote.IsApproved = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsStoreGoodReceiveNote.IsFinished = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsStoreGoodReceiveNote.IsDeleted = dataReader.GetBoolean(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_scsStoreGoodReceiveNote.IsLocked = dataReader.GetBoolean(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_scsStoreGoodReceiveNote.PrintCount = dataReader.GetInt32(26);
			}

			return tbl_scsStoreGoodReceiveNote;
		}
		/// <summary>
		/// This makes tbl_scsStoreGoodReceiveNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsStoreGoodReceiveNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsStoreGoodReceiveNote  tbl_scsStoreGoodReceiveNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_storeGoodReceiveNote_ID = new DataColumn("storeGoodReceiveNote_ID" , typeof(string));
			DataColumn col_storeGoodReceiveNoteDate = new DataColumn("storeGoodReceiveNoteDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_fromSelectArea_ID = new DataColumn("fromSelectArea_ID" , typeof(string));
			DataColumn col_fromDepartment_ID = new DataColumn("fromDepartment_ID" , typeof(string));
			DataColumn col_fromSection_ID = new DataColumn("fromSection_ID" , typeof(string));
			DataColumn col_fromStore_ID = new DataColumn("fromStore_ID" , typeof(string));
			DataColumn col_toStore_ID = new DataColumn("toStore_ID" , typeof(string));
			DataColumn col_departmentGoodIssueNote_ID = new DataColumn("departmentGoodIssueNote_ID" , typeof(string));
			DataColumn col_sectionGoodIssueNote_ID = new DataColumn("sectionGoodIssueNote_ID" , typeof(string));
			DataColumn col_storeGoodIssueNote_ID = new DataColumn("storeGoodIssueNote_ID" , typeof(string));
			DataColumn col_IssuedRefNo_ID = new DataColumn("IssuedRefNo_ID" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_storeGoodReceiveNote_ID,col_storeGoodReceiveNoteDate,col_remark,col_job_ID,col_fromSelectArea_ID,col_fromDepartment_ID,col_fromSection_ID,col_fromStore_ID,col_toStore_ID,col_departmentGoodIssueNote_ID,col_sectionGoodIssueNote_ID,col_storeGoodIssueNote_ID,col_IssuedRefNo_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_printCount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsStoreGoodReceiveNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsStoreGoodReceiveNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsStoreGoodReceiveNote user) {
		DataRow drow = dt.NewRow();
		
			drow["storeGoodReceiveNote_ID"] = user.storeGoodReceiveNote_ID;
			drow["storeGoodReceiveNoteDate"] = user.storeGoodReceiveNoteDate;
			drow["remark"] = user.remark;
			drow["job_ID"] = user.job_ID;
			drow["fromSelectArea_ID"] = user.fromSelectArea_ID;
			drow["fromDepartment_ID"] = user.fromDepartment_ID;
			drow["fromSection_ID"] = user.fromSection_ID;
			drow["fromStore_ID"] = user.fromStore_ID;
			drow["toStore_ID"] = user.toStore_ID;
			drow["departmentGoodIssueNote_ID"] = user.departmentGoodIssueNote_ID;
			drow["sectionGoodIssueNote_ID"] = user.sectionGoodIssueNote_ID;
			drow["storeGoodIssueNote_ID"] = user.storeGoodIssueNote_ID;
			drow["IssuedRefNo_ID"] = user.IssuedRefNo_ID;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["printCount"] = user.printCount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
