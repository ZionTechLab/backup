using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsPrePlan_SectionPath {
		#region Fields
		private int line_No;
		private string prePlan_ID;
		private string section_ID;
		private string dependedSection_ID;
		private DateTime planDate;
		private string shift_ID;
		private decimal totalHours;
		private bool isLocked;
		private bool isJobWorkInProgress;
		private bool isJobClosed;
		private DateTime dateJobClosed;
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
		private DateTime dateWIPStart;
		private string machine_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsPrePlan_SectionPath class.
		/// </summary>
		public tbl_pmsPrePlan_SectionPath() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsPrePlan_SectionPath class.
		/// </summary>
		public tbl_pmsPrePlan_SectionPath(int line_No, string prePlan_ID, string section_ID, string dependedSection_ID, DateTime planDate, string shift_ID, decimal totalHours, bool isLocked, bool isJobWorkInProgress, bool isJobClosed, DateTime dateJobClosed, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, DateTime dateWIPStart, string machine_ID) {
			this.line_No = line_No;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.dependedSection_ID = dependedSection_ID;
			this.planDate = planDate;
			this.shift_ID = shift_ID;
			this.totalHours = totalHours;
			this.isLocked = isLocked;
			this.isJobWorkInProgress = isJobWorkInProgress;
			this.isJobClosed = isJobClosed;
			this.dateJobClosed = dateJobClosed;
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
			this.dateWIPStart = dateWIPStart;
			this.machine_ID = machine_ID;
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
		/// Gets or sets the PrePlan_ID value.
		/// </summary>
		public string PrePlan_ID {
			get { return prePlan_ID; }
			set { prePlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DependedSection_ID value.
		/// </summary>
		public string DependedSection_ID {
			get { return dependedSection_ID; }
			set { dependedSection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PlanDate value.
		/// </summary>
		public DateTime PlanDate {
			get { return planDate; }
			set { planDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_ID value.
		/// </summary>
		public string Shift_ID {
			get { return shift_ID; }
			set { shift_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalHours value.
		/// </summary>
		public decimal TotalHours {
			get { return totalHours; }
			set { totalHours = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobWorkInProgress value.
		/// </summary>
		public bool IsJobWorkInProgress {
			get { return isJobWorkInProgress; }
			set { isJobWorkInProgress = value; }
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
		/// Gets or sets the DateWIPStart value.
		/// </summary>
		public DateTime DateWIPStart {
			get { return dateWIPStart; }
			set { dateWIPStart = value; }
		}
		
		/// <summary>
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsPrePlan_SectionPath table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dependedSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@planDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@totalHours", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobWorkInProgress", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobClosed", SqlDbType.DateTime,8);
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
			scom.Parameters.Add("@dateWIPStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@dependedSection_ID"].Value = dependedSection_ID;
			scom.Parameters["@planDate"].Value = planDate;
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@totalHours"].Value = totalHours;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isJobWorkInProgress"].Value = isJobWorkInProgress;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@dateJobClosed"].Value = dateJobClosed;
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
			scom.Parameters["@dateWIPStart"].Value = dateWIPStart;
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsPrePlan_SectionPath table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dependedSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@planDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@totalHours", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobWorkInProgress", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobClosed", SqlDbType.DateTime,8);
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
			scom.Parameters.Add("@dateWIPStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@dependedSection_ID"].Value = dependedSection_ID;
			scom.Parameters["@planDate"].Value = planDate;
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@totalHours"].Value = totalHours;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isJobWorkInProgress"].Value = isJobWorkInProgress;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@dateJobClosed"].Value = dateJobClosed;
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
			scom.Parameters["@dateWIPStart"].Value = dateWIPStart;
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsPrePlan_SectionPath table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
 
			scom.Parameters["@section_ID"].Value = section_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath table by a foreign key.
		/// </summary>
		public static void DeleteAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathDeleteAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath table by a foreign key.
		/// </summary>
		public static void DeleteAllByPrePlan_ID(string prePlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathDeleteAllByPrePlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath table by a foreign key.
		/// </summary>
		public static void DeleteAllByShift_ID(string shift_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathDeleteAllByShift_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters["@shift_ID"].Value = shift_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsPrePlan_SectionPath table.
		/// </summary>
		public static tbl_pmsPrePlan_SectionPath Select(int line_No_Incoming, string prePlan_ID_Incoming, string section_ID_Incoming){

			tbl_pmsPrePlan_SectionPath tbl_pmsPrePlan_SectionPathins = new tbl_pmsPrePlan_SectionPath();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID_Incoming;
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPathins = Maketbl_pmsPrePlan_SectionPath(dataReader);
				} else {
					tbl_pmsPrePlan_SectionPathins = null;
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPathins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath table.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsPrePlan_SectionPath> tbl_pmsPrePlan_SectionPathList = new List<tbl_pmsPrePlan_SectionPath>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath tbl_pmsPrePlan_SectionPath = Maketbl_pmsPrePlan_SectionPath(dataReader);
					tbl_pmsPrePlan_SectionPathList.Add(tbl_pmsPrePlan_SectionPath);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPathList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath table by a foreign key.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath> SelectAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathSelectAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_pmsPrePlan_SectionPath> tbl_pmsPrePlan_SectionPathList = new List<tbl_pmsPrePlan_SectionPath>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath tbl_pmsPrePlan_SectionPath = Maketbl_pmsPrePlan_SectionPath(dataReader);
					tbl_pmsPrePlan_SectionPathList.Add(tbl_pmsPrePlan_SectionPath);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPathList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath table by a foreign key.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath> SelectAllByPrePlan_ID(string prePlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathSelectAllByPrePlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
				List<tbl_pmsPrePlan_SectionPath> tbl_pmsPrePlan_SectionPathList = new List<tbl_pmsPrePlan_SectionPath>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath tbl_pmsPrePlan_SectionPath = Maketbl_pmsPrePlan_SectionPath(dataReader);
					tbl_pmsPrePlan_SectionPathList.Add(tbl_pmsPrePlan_SectionPath);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPathList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsPrePlan_SectionPath table by a foreign key.
		/// </summary>
		public static List<tbl_pmsPrePlan_SectionPath> SelectAllByShift_ID(string shift_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsPrePlan_SectionPathSelectAllByShift_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters["@shift_ID"].Value = shift_ID;
				List<tbl_pmsPrePlan_SectionPath> tbl_pmsPrePlan_SectionPathList = new List<tbl_pmsPrePlan_SectionPath>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsPrePlan_SectionPath tbl_pmsPrePlan_SectionPath = Maketbl_pmsPrePlan_SectionPath(dataReader);
					tbl_pmsPrePlan_SectionPathList.Add(tbl_pmsPrePlan_SectionPath);
				}
			}
			scon.Close();
			return tbl_pmsPrePlan_SectionPathList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsPrePlan_SectionPath class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsPrePlan_SectionPath Maketbl_pmsPrePlan_SectionPath(SqlDataReader dataReader) {
			tbl_pmsPrePlan_SectionPath tbl_pmsPrePlan_SectionPath = new tbl_pmsPrePlan_SectionPath();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsPrePlan_SectionPath.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsPrePlan_SectionPath.PrePlan_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsPrePlan_SectionPath.Section_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsPrePlan_SectionPath.DependedSection_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsPrePlan_SectionPath.PlanDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsPrePlan_SectionPath.Shift_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsPrePlan_SectionPath.TotalHours = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsPrePlan_SectionPath.IsLocked = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsPrePlan_SectionPath.IsJobWorkInProgress = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pmsPrePlan_SectionPath.IsJobClosed = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pmsPrePlan_SectionPath.DateJobClosed = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pmsPrePlan_SectionPath.CreateUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pmsPrePlan_SectionPath.ModifiedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pmsPrePlan_SectionPath.CheckedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pmsPrePlan_SectionPath.ApprovedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pmsPrePlan_SectionPath.DeletedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pmsPrePlan_SectionPath.PrintedUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pmsPrePlan_SectionPath.CreateTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pmsPrePlan_SectionPath.ModifiedTerminal_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_pmsPrePlan_SectionPath.DeletedTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_pmsPrePlan_SectionPath.PrintedTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_pmsPrePlan_SectionPath.DateCreate = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_pmsPrePlan_SectionPath.DateModified = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_pmsPrePlan_SectionPath.DateChecked = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_pmsPrePlan_SectionPath.DateApproved = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_pmsPrePlan_SectionPath.DateDeleted = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_pmsPrePlan_SectionPath.DatePrinted = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_pmsPrePlan_SectionPath.DateWIPStart = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_pmsPrePlan_SectionPath.Machine_ID = dataReader.GetString(28);
			}

			return tbl_pmsPrePlan_SectionPath;
		}
		/// <summary>
		/// This makes tbl_pmsPrePlan_SectionPath datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsPrePlan_SectionPath object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsPrePlan_SectionPath  tbl_pmsPrePlan_SectionPath   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prePlan_ID = new DataColumn("prePlan_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_dependedSection_ID = new DataColumn("dependedSection_ID" , typeof(string));
			DataColumn col_planDate = new DataColumn("planDate" , typeof(DateTime));
			DataColumn col_shift_ID = new DataColumn("shift_ID" , typeof(string));
			DataColumn col_totalHours = new DataColumn("totalHours" , typeof(decimal));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isJobWorkInProgress = new DataColumn("isJobWorkInProgress" , typeof(bool));
			DataColumn col_isJobClosed = new DataColumn("isJobClosed" , typeof(bool));
			DataColumn col_dateJobClosed = new DataColumn("dateJobClosed" , typeof(DateTime));
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
			DataColumn col_dateWIPStart = new DataColumn("dateWIPStart" , typeof(DateTime));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_prePlan_ID,col_section_ID,col_dependedSection_ID,col_planDate,col_shift_ID,col_totalHours,col_isLocked,col_isJobWorkInProgress,col_isJobClosed,col_dateJobClosed,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_dateWIPStart,col_machine_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsPrePlan_SectionPath datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsPrePlan_SectionPath object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsPrePlan_SectionPath user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["prePlan_ID"] = user.prePlan_ID;
			drow["section_ID"] = user.section_ID;
			drow["dependedSection_ID"] = user.dependedSection_ID;
			drow["planDate"] = user.planDate;
			drow["shift_ID"] = user.shift_ID;
			drow["totalHours"] = user.totalHours;
			drow["isLocked"] = user.isLocked;
			drow["isJobWorkInProgress"] = user.isJobWorkInProgress;
			drow["isJobClosed"] = user.isJobClosed;
			drow["dateJobClosed"] = user.dateJobClosed;
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
			drow["dateWIPStart"] = user.dateWIPStart;
			drow["machine_ID"] = user.machine_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
