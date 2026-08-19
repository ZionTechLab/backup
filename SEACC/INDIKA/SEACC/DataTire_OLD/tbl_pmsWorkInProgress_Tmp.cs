using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsWorkInProgress_Tmp {
		#region Fields
		private string workInProgress_ID;
		private DateTime workInProgressDate;
		private string remark;
		private string productionJob_ID;
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
		private bool isNewJob;
		private bool isJobWorkInProgress;
		private bool isJobClosedAuto;
		private bool isJobClosed;
		private DateTime dateJobClosed;
		private string jobClosedUser_ID;
		private bool isJobSuspended;
		private DateTime dateJobSuspended;
		private string jobSuspendedUser_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsWorkInProgress_Tmp class.
		/// </summary>
		public tbl_pmsWorkInProgress_Tmp() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsWorkInProgress_Tmp class.
		/// </summary>
		public tbl_pmsWorkInProgress_Tmp(string workInProgress_ID, DateTime workInProgressDate, string remark, string productionJob_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isNewJob, bool isJobWorkInProgress, bool isJobClosedAuto, bool isJobClosed, DateTime dateJobClosed, string jobClosedUser_ID, bool isJobSuspended, DateTime dateJobSuspended, string jobSuspendedUser_ID) {
			this.workInProgress_ID = workInProgress_ID;
			this.workInProgressDate = workInProgressDate;
			this.remark = remark;
			this.productionJob_ID = productionJob_ID;
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
			this.isNewJob = isNewJob;
			this.isJobWorkInProgress = isJobWorkInProgress;
			this.isJobClosedAuto = isJobClosedAuto;
			this.isJobClosed = isJobClosed;
			this.dateJobClosed = dateJobClosed;
			this.jobClosedUser_ID = jobClosedUser_ID;
			this.isJobSuspended = isJobSuspended;
			this.dateJobSuspended = dateJobSuspended;
			this.jobSuspendedUser_ID = jobSuspendedUser_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the WorkInProgress_ID value.
		/// </summary>
		public string WorkInProgress_ID {
			get { return workInProgress_ID; }
			set { workInProgress_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkInProgressDate value.
		/// </summary>
		public DateTime WorkInProgressDate {
			get { return workInProgressDate; }
			set { workInProgressDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
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
		/// Gets or sets the IsNewJob value.
		/// </summary>
		public bool IsNewJob {
			get { return isNewJob; }
			set { isNewJob = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobWorkInProgress value.
		/// </summary>
		public bool IsJobWorkInProgress {
			get { return isJobWorkInProgress; }
			set { isJobWorkInProgress = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobClosedAuto value.
		/// </summary>
		public bool IsJobClosedAuto {
			get { return isJobClosedAuto; }
			set { isJobClosedAuto = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobClosed value.
		/// </summary>
		public bool IsJobClosed {
			get { return isJobClosed; }
			set { isJobClosed = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateJobClosed value.
		/// </summary>
		public DateTime DateJobClosed {
			get { return dateJobClosed; }
			set { dateJobClosed = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobClosedUser_ID value.
		/// </summary>
		public string JobClosedUser_ID {
			get { return jobClosedUser_ID; }
			set { jobClosedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobSuspended value.
		/// </summary>
		public bool IsJobSuspended {
			get { return isJobSuspended; }
			set { isJobSuspended = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateJobSuspended value.
		/// </summary>
		public DateTime DateJobSuspended {
			get { return dateJobSuspended; }
			set { dateJobSuspended = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobSuspendedUser_ID value.
		/// </summary>
		public string JobSuspendedUser_ID {
			get { return jobSuspendedUser_ID; }
			set { jobSuspendedUser_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsWorkInProgress_Tmp table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_TmpInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workInProgressDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isNewJob", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobWorkInProgress", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosedAuto", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobClosed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@jobClosedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isJobSuspended", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobSuspended", SqlDbType.DateTime,8);
			scom.Parameters.Add("@jobSuspendedUser_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@workInProgressDate"].Value = workInProgressDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
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
			scom.Parameters["@isNewJob"].Value = isNewJob;
			scom.Parameters["@isJobWorkInProgress"].Value = isJobWorkInProgress;
			scom.Parameters["@isJobClosedAuto"].Value = isJobClosedAuto;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@dateJobClosed"].Value = dateJobClosed;
			scom.Parameters["@jobClosedUser_ID"].Value = jobClosedUser_ID;
			scom.Parameters["@isJobSuspended"].Value = isJobSuspended;
			scom.Parameters["@dateJobSuspended"].Value = dateJobSuspended;
			scom.Parameters["@jobSuspendedUser_ID"].Value = jobSuspendedUser_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsWorkInProgress_Tmp table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_TmpUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workInProgressDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isNewJob", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobWorkInProgress", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosedAuto", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobClosed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@jobClosedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isJobSuspended", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobSuspended", SqlDbType.DateTime,8);
			scom.Parameters.Add("@jobSuspendedUser_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@workInProgressDate"].Value = workInProgressDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
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
			scom.Parameters["@isNewJob"].Value = isNewJob;
			scom.Parameters["@isJobWorkInProgress"].Value = isJobWorkInProgress;
			scom.Parameters["@isJobClosedAuto"].Value = isJobClosedAuto;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@dateJobClosed"].Value = dateJobClosed;
			scom.Parameters["@jobClosedUser_ID"].Value = jobClosedUser_ID;
			scom.Parameters["@isJobSuspended"].Value = isJobSuspended;
			scom.Parameters["@dateJobSuspended"].Value = dateJobSuspended;
			scom.Parameters["@jobSuspendedUser_ID"].Value = jobSuspendedUser_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsWorkInProgress_Tmp table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_TmpDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Tmp table by a foreign key.
		/// </summary>
		public static void DeleteAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_TmpDeleteAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsWorkInProgress_Tmp table.
		/// </summary>
		public static tbl_pmsWorkInProgress_Tmp Select(string workInProgress_ID_Incoming){

			tbl_pmsWorkInProgress_Tmp tbl_pmsWorkInProgress_Tmpins = new tbl_pmsWorkInProgress_Tmp();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_TmpSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsWorkInProgress_Tmpins = Maketbl_pmsWorkInProgress_Tmp(dataReader);
				} else {
					tbl_pmsWorkInProgress_Tmpins = null;
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Tmpins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Tmp table.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Tmp> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_TmpSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsWorkInProgress_Tmp> tbl_pmsWorkInProgress_TmpList = new List<tbl_pmsWorkInProgress_Tmp>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Tmp tbl_pmsWorkInProgress_Tmp = Maketbl_pmsWorkInProgress_Tmp(dataReader);
					tbl_pmsWorkInProgress_TmpList.Add(tbl_pmsWorkInProgress_Tmp);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_TmpList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Tmp table by a foreign key.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Tmp> SelectAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_TmpSelectAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
				List<tbl_pmsWorkInProgress_Tmp> tbl_pmsWorkInProgress_TmpList = new List<tbl_pmsWorkInProgress_Tmp>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Tmp tbl_pmsWorkInProgress_Tmp = Maketbl_pmsWorkInProgress_Tmp(dataReader);
					tbl_pmsWorkInProgress_TmpList.Add(tbl_pmsWorkInProgress_Tmp);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_TmpList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsWorkInProgress_Tmp class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsWorkInProgress_Tmp Maketbl_pmsWorkInProgress_Tmp(SqlDataReader dataReader) {
			tbl_pmsWorkInProgress_Tmp tbl_pmsWorkInProgress_Tmp = new tbl_pmsWorkInProgress_Tmp();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsWorkInProgress_Tmp.WorkInProgress_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsWorkInProgress_Tmp.WorkInProgressDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsWorkInProgress_Tmp.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsWorkInProgress_Tmp.ProductionJob_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsWorkInProgress_Tmp.CreateUser_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsWorkInProgress_Tmp.ModifiedUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsWorkInProgress_Tmp.CheckedUser_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsWorkInProgress_Tmp.ApprovedUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsWorkInProgress_Tmp.DateCreate = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pmsWorkInProgress_Tmp.DateModified = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pmsWorkInProgress_Tmp.DateChecked = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pmsWorkInProgress_Tmp.DateApproved = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pmsWorkInProgress_Tmp.IsChecked = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pmsWorkInProgress_Tmp.IsApproved = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pmsWorkInProgress_Tmp.IsFinished = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pmsWorkInProgress_Tmp.IsDeleted = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pmsWorkInProgress_Tmp.IsLocked = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pmsWorkInProgress_Tmp.IsNewJob = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pmsWorkInProgress_Tmp.IsJobWorkInProgress = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_pmsWorkInProgress_Tmp.IsJobClosedAuto = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_pmsWorkInProgress_Tmp.IsJobClosed = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_pmsWorkInProgress_Tmp.DateJobClosed = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_pmsWorkInProgress_Tmp.JobClosedUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_pmsWorkInProgress_Tmp.IsJobSuspended = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_pmsWorkInProgress_Tmp.DateJobSuspended = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_pmsWorkInProgress_Tmp.JobSuspendedUser_ID = dataReader.GetString(25);
			}

			return tbl_pmsWorkInProgress_Tmp;
		}
		/// <summary>
		/// This makes tbl_pmsWorkInProgress_Tmp datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsWorkInProgress_Tmp object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsWorkInProgress_Tmp  tbl_pmsWorkInProgress_Tmp   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_workInProgress_ID = new DataColumn("workInProgress_ID" , typeof(string));
			DataColumn col_workInProgressDate = new DataColumn("workInProgressDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
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
			DataColumn col_isNewJob = new DataColumn("isNewJob" , typeof(bool));
			DataColumn col_isJobWorkInProgress = new DataColumn("isJobWorkInProgress" , typeof(bool));
			DataColumn col_isJobClosedAuto = new DataColumn("isJobClosedAuto" , typeof(bool));
			DataColumn col_isJobClosed = new DataColumn("isJobClosed" , typeof(bool));
			DataColumn col_dateJobClosed = new DataColumn("dateJobClosed" , typeof(DateTime));
			DataColumn col_jobClosedUser_ID = new DataColumn("jobClosedUser_ID" , typeof(string));
			DataColumn col_isJobSuspended = new DataColumn("isJobSuspended" , typeof(bool));
			DataColumn col_dateJobSuspended = new DataColumn("dateJobSuspended" , typeof(DateTime));
			DataColumn col_jobSuspendedUser_ID = new DataColumn("jobSuspendedUser_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_workInProgress_ID,col_workInProgressDate,col_remark,col_productionJob_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isNewJob,col_isJobWorkInProgress,col_isJobClosedAuto,col_isJobClosed,col_dateJobClosed,col_jobClosedUser_ID,col_isJobSuspended,col_dateJobSuspended,col_jobSuspendedUser_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsWorkInProgress_Tmp datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsWorkInProgress_Tmp object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsWorkInProgress_Tmp user) {
		DataRow drow = dt.NewRow();
		
			drow["workInProgress_ID"] = user.workInProgress_ID;
			drow["workInProgressDate"] = user.workInProgressDate;
			drow["remark"] = user.remark;
			drow["productionJob_ID"] = user.productionJob_ID;
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
			drow["isNewJob"] = user.isNewJob;
			drow["isJobWorkInProgress"] = user.isJobWorkInProgress;
			drow["isJobClosedAuto"] = user.isJobClosedAuto;
			drow["isJobClosed"] = user.isJobClosed;
			drow["dateJobClosed"] = user.dateJobClosed;
			drow["jobClosedUser_ID"] = user.jobClosedUser_ID;
			drow["isJobSuspended"] = user.isJobSuspended;
			drow["dateJobSuspended"] = user.dateJobSuspended;
			drow["jobSuspendedUser_ID"] = user.jobSuspendedUser_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
