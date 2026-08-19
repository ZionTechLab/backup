using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsDepartmentGoodIssueNote {
		#region Fields
		private string departmentGoodIssueNote_ID;
		private DateTime departmentGoodIssueNoteDate;
		private string remark;
		private string job_ID;
		private string fromDepartment_ID;
		private string toSelectArea_ID;
		private string toDepartment_ID;
		private string toSection_ID;
		private string toStore_ID;
		private string departmentReqositionNote_ID;
		private string sectionRequisitionNote_ID;
		private string storeRequisitionNote_ID;
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
		private bool isGRNdone;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsDepartmentGoodIssueNote class.
		/// </summary>
		public tbl_scsDepartmentGoodIssueNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsDepartmentGoodIssueNote class.
		/// </summary>
		public tbl_scsDepartmentGoodIssueNote(string departmentGoodIssueNote_ID, DateTime departmentGoodIssueNoteDate, string remark, string job_ID, string fromDepartment_ID, string toSelectArea_ID, string toDepartment_ID, string toSection_ID, string toStore_ID, string departmentReqositionNote_ID, string sectionRequisitionNote_ID, string storeRequisitionNote_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, int printCount, bool isGRNdone) {
			this.departmentGoodIssueNote_ID = departmentGoodIssueNote_ID;
			this.departmentGoodIssueNoteDate = departmentGoodIssueNoteDate;
			this.remark = remark;
			this.job_ID = job_ID;
			this.fromDepartment_ID = fromDepartment_ID;
			this.toSelectArea_ID = toSelectArea_ID;
			this.toDepartment_ID = toDepartment_ID;
			this.toSection_ID = toSection_ID;
			this.toStore_ID = toStore_ID;
			this.departmentReqositionNote_ID = departmentReqositionNote_ID;
			this.sectionRequisitionNote_ID = sectionRequisitionNote_ID;
			this.storeRequisitionNote_ID = storeRequisitionNote_ID;
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
			this.isGRNdone = isGRNdone;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the DepartmentGoodIssueNote_ID value.
		/// </summary>
		public string DepartmentGoodIssueNote_ID {
			get { return departmentGoodIssueNote_ID; }
			set { departmentGoodIssueNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepartmentGoodIssueNoteDate value.
		/// </summary>
		public DateTime DepartmentGoodIssueNoteDate {
			get { return departmentGoodIssueNoteDate; }
			set { departmentGoodIssueNoteDate = value; }
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
		/// Gets or sets the FromDepartment_ID value.
		/// </summary>
		public string FromDepartment_ID {
			get { return fromDepartment_ID; }
			set { fromDepartment_ID = value; }
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
		
		/// <summary>
		/// Gets or sets the IsGRNdone value.
		/// </summary>
		public bool IsGRNdone {
			get { return isGRNdone; }
			set { isGRNdone = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsDepartmentGoodIssueNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@departmentGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentGoodIssueNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionRequisitionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeRequisitionNote_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isGRNdone", SqlDbType.Bit,1);
 
			scom.Parameters["@departmentGoodIssueNote_ID"].Value = departmentGoodIssueNote_ID;
			scom.Parameters["@departmentGoodIssueNoteDate"].Value = departmentGoodIssueNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromDepartment_ID"].Value = fromDepartment_ID;
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
			scom.Parameters["@departmentReqositionNote_ID"].Value = departmentReqositionNote_ID;
			scom.Parameters["@sectionRequisitionNote_ID"].Value = sectionRequisitionNote_ID;
			scom.Parameters["@storeRequisitionNote_ID"].Value = storeRequisitionNote_ID;
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
			scom.Parameters["@isGRNdone"].Value = isGRNdone;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsDepartmentGoodIssueNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@departmentGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentGoodIssueNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@toDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@toStore_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@departmentReqositionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionRequisitionNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@storeRequisitionNote_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isGRNdone", SqlDbType.Bit,1);
 
 
			scom.Parameters["@departmentGoodIssueNote_ID"].Value = departmentGoodIssueNote_ID;
			scom.Parameters["@departmentGoodIssueNoteDate"].Value = departmentGoodIssueNoteDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@fromDepartment_ID"].Value = fromDepartment_ID;
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
			scom.Parameters["@toDepartment_ID"].Value = toDepartment_ID;
			scom.Parameters["@toSection_ID"].Value = toSection_ID;
			scom.Parameters["@toStore_ID"].Value = toStore_ID;
			scom.Parameters["@departmentReqositionNote_ID"].Value = departmentReqositionNote_ID;
			scom.Parameters["@sectionRequisitionNote_ID"].Value = sectionRequisitionNote_ID;
			scom.Parameters["@storeRequisitionNote_ID"].Value = storeRequisitionNote_ID;
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
			scom.Parameters["@isGRNdone"].Value = isGRNdone;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsDepartmentGoodIssueNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@departmentGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@departmentGoodIssueNote_ID"].Value = departmentGoodIssueNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByToSelectArea_ID(string toSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteDeleteAllByToSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByFromDepartment_ID(string fromDepartment_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteDeleteAllByFromDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fromDepartment_ID"].Value = fromDepartment_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsDepartmentGoodIssueNote table.
		/// </summary>
		public static tbl_scsDepartmentGoodIssueNote Select(string departmentGoodIssueNote_ID_Incoming){

			tbl_scsDepartmentGoodIssueNote tbl_scsDepartmentGoodIssueNoteins = new tbl_scsDepartmentGoodIssueNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@departmentGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@departmentGoodIssueNote_ID"].Value = departmentGoodIssueNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsDepartmentGoodIssueNoteins = Maketbl_scsDepartmentGoodIssueNote(dataReader);
				} else {
					tbl_scsDepartmentGoodIssueNoteins = null;
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodIssueNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodIssueNote table.
		/// </summary>
		public static List<tbl_scsDepartmentGoodIssueNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsDepartmentGoodIssueNote> tbl_scsDepartmentGoodIssueNoteList = new List<tbl_scsDepartmentGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodIssueNote tbl_scsDepartmentGoodIssueNote = Maketbl_scsDepartmentGoodIssueNote(dataReader);
					tbl_scsDepartmentGoodIssueNoteList.Add(tbl_scsDepartmentGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentGoodIssueNote> SelectAllByToSelectArea_ID(string toSelectArea_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteSelectAllByToSelectArea_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@toSelectArea_ID", SqlDbType.VarChar,10);
			scom.Parameters["@toSelectArea_ID"].Value = toSelectArea_ID;
				List<tbl_scsDepartmentGoodIssueNote> tbl_scsDepartmentGoodIssueNoteList = new List<tbl_scsDepartmentGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodIssueNote tbl_scsDepartmentGoodIssueNote = Maketbl_scsDepartmentGoodIssueNote(dataReader);
					tbl_scsDepartmentGoodIssueNoteList.Add(tbl_scsDepartmentGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentGoodIssueNote> SelectAllByFromDepartment_ID(string fromDepartment_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteSelectAllByFromDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromDepartment_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fromDepartment_ID"].Value = fromDepartment_ID;
				List<tbl_scsDepartmentGoodIssueNote> tbl_scsDepartmentGoodIssueNoteList = new List<tbl_scsDepartmentGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodIssueNote tbl_scsDepartmentGoodIssueNote = Maketbl_scsDepartmentGoodIssueNote(dataReader);
					tbl_scsDepartmentGoodIssueNoteList.Add(tbl_scsDepartmentGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsDepartmentGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_scsDepartmentGoodIssueNote> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsDepartmentGoodIssueNoteSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_scsDepartmentGoodIssueNote> tbl_scsDepartmentGoodIssueNoteList = new List<tbl_scsDepartmentGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsDepartmentGoodIssueNote tbl_scsDepartmentGoodIssueNote = Maketbl_scsDepartmentGoodIssueNote(dataReader);
					tbl_scsDepartmentGoodIssueNoteList.Add(tbl_scsDepartmentGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_scsDepartmentGoodIssueNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsDepartmentGoodIssueNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsDepartmentGoodIssueNote Maketbl_scsDepartmentGoodIssueNote(SqlDataReader dataReader) {
			tbl_scsDepartmentGoodIssueNote tbl_scsDepartmentGoodIssueNote = new tbl_scsDepartmentGoodIssueNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsDepartmentGoodIssueNote.DepartmentGoodIssueNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsDepartmentGoodIssueNote.DepartmentGoodIssueNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsDepartmentGoodIssueNote.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsDepartmentGoodIssueNote.Job_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsDepartmentGoodIssueNote.FromDepartment_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsDepartmentGoodIssueNote.ToSelectArea_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsDepartmentGoodIssueNote.ToDepartment_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsDepartmentGoodIssueNote.ToSection_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsDepartmentGoodIssueNote.ToStore_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsDepartmentGoodIssueNote.DepartmentReqositionNote_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsDepartmentGoodIssueNote.SectionRequisitionNote_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsDepartmentGoodIssueNote.StoreRequisitionNote_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsDepartmentGoodIssueNote.CreateUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsDepartmentGoodIssueNote.ModifiedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsDepartmentGoodIssueNote.CheckedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsDepartmentGoodIssueNote.ApprovedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsDepartmentGoodIssueNote.DateCreate = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsDepartmentGoodIssueNote.DateModified = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsDepartmentGoodIssueNote.DateChecked = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsDepartmentGoodIssueNote.DateApproved = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsDepartmentGoodIssueNote.IsChecked = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsDepartmentGoodIssueNote.IsApproved = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsDepartmentGoodIssueNote.IsFinished = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsDepartmentGoodIssueNote.IsDeleted = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsDepartmentGoodIssueNote.IsLocked = dataReader.GetBoolean(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_scsDepartmentGoodIssueNote.PrintCount = dataReader.GetInt32(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_scsDepartmentGoodIssueNote.IsGRNdone = dataReader.GetBoolean(26);
			}

			return tbl_scsDepartmentGoodIssueNote;
		}
		/// <summary>
		/// This makes tbl_scsDepartmentGoodIssueNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsDepartmentGoodIssueNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsDepartmentGoodIssueNote  tbl_scsDepartmentGoodIssueNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_departmentGoodIssueNote_ID = new DataColumn("departmentGoodIssueNote_ID" , typeof(string));
			DataColumn col_departmentGoodIssueNoteDate = new DataColumn("departmentGoodIssueNoteDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_fromDepartment_ID = new DataColumn("fromDepartment_ID" , typeof(string));
			DataColumn col_toSelectArea_ID = new DataColumn("toSelectArea_ID" , typeof(string));
			DataColumn col_toDepartment_ID = new DataColumn("toDepartment_ID" , typeof(string));
			DataColumn col_toSection_ID = new DataColumn("toSection_ID" , typeof(string));
			DataColumn col_toStore_ID = new DataColumn("toStore_ID" , typeof(string));
			DataColumn col_departmentReqositionNote_ID = new DataColumn("departmentReqositionNote_ID" , typeof(string));
			DataColumn col_sectionRequisitionNote_ID = new DataColumn("sectionRequisitionNote_ID" , typeof(string));
			DataColumn col_storeRequisitionNote_ID = new DataColumn("storeRequisitionNote_ID" , typeof(string));
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
			DataColumn col_isGRNdone = new DataColumn("isGRNdone" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_departmentGoodIssueNote_ID,col_departmentGoodIssueNoteDate,col_remark,col_job_ID,col_fromDepartment_ID,col_toSelectArea_ID,col_toDepartment_ID,col_toSection_ID,col_toStore_ID,col_departmentReqositionNote_ID,col_sectionRequisitionNote_ID,col_storeRequisitionNote_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_printCount,col_isGRNdone,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsDepartmentGoodIssueNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsDepartmentGoodIssueNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsDepartmentGoodIssueNote user) {
		DataRow drow = dt.NewRow();
		
			drow["departmentGoodIssueNote_ID"] = user.departmentGoodIssueNote_ID;
			drow["departmentGoodIssueNoteDate"] = user.departmentGoodIssueNoteDate;
			drow["remark"] = user.remark;
			drow["job_ID"] = user.job_ID;
			drow["fromDepartment_ID"] = user.fromDepartment_ID;
			drow["toSelectArea_ID"] = user.toSelectArea_ID;
			drow["toDepartment_ID"] = user.toDepartment_ID;
			drow["toSection_ID"] = user.toSection_ID;
			drow["toStore_ID"] = user.toStore_ID;
			drow["departmentReqositionNote_ID"] = user.departmentReqositionNote_ID;
			drow["sectionRequisitionNote_ID"] = user.sectionRequisitionNote_ID;
			drow["storeRequisitionNote_ID"] = user.storeRequisitionNote_ID;
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
			drow["isGRNdone"] = user.isGRNdone;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
