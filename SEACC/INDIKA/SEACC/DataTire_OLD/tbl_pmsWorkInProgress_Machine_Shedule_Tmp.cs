using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsWorkInProgress_Machine_Shedule_Tmp {
		#region Fields
		private int line_NoShedule;
		private string workInProgress_ID;
		private int line_No;
		private string prePlan_ID;
		private string section_ID;
		private string machine_ID;
		private DateTime dateStart;
		private DateTime dateEnd;
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
		private string employee_ID;
		private decimal extraHours_iddle;
		private decimal extraHours_Maintenance;
		private decimal extraHours_Labours;
		private decimal extraHours_Cleaning;
		private decimal extraHours_Approval;
		private decimal extraHours_Powe_Air_etc;
		private decimal extraHours_JobSetting;
		private decimal extraHours_JobRunning;
		private decimal cutbackSize;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsWorkInProgress_Machine_Shedule_Tmp class.
		/// </summary>
		public tbl_pmsWorkInProgress_Machine_Shedule_Tmp() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsWorkInProgress_Machine_Shedule_Tmp class.
		/// </summary>
		public tbl_pmsWorkInProgress_Machine_Shedule_Tmp(int line_NoShedule, string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID, DateTime dateStart, DateTime dateEnd, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, string employee_ID, decimal extraHours_iddle, decimal extraHours_Maintenance, decimal extraHours_Labours, decimal extraHours_Cleaning, decimal extraHours_Approval, decimal extraHours_Powe_Air_etc, decimal extraHours_JobSetting, decimal extraHours_JobRunning, decimal cutbackSize) {
			this.line_NoShedule = line_NoShedule;
			this.workInProgress_ID = workInProgress_ID;
			this.line_No = line_No;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.machine_ID = machine_ID;
			this.dateStart = dateStart;
			this.dateEnd = dateEnd;
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
			this.employee_ID = employee_ID;
			this.extraHours_iddle = extraHours_iddle;
			this.extraHours_Maintenance = extraHours_Maintenance;
			this.extraHours_Labours = extraHours_Labours;
			this.extraHours_Cleaning = extraHours_Cleaning;
			this.extraHours_Approval = extraHours_Approval;
			this.extraHours_Powe_Air_etc = extraHours_Powe_Air_etc;
			this.extraHours_JobSetting = extraHours_JobSetting;
			this.extraHours_JobRunning = extraHours_JobRunning;
			this.cutbackSize = cutbackSize;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_NoShedule value.
		/// </summary>
		public int Line_NoShedule {
			get { return line_NoShedule; }
			set { line_NoShedule = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkInProgress_ID value.
		/// </summary>
		public string WorkInProgress_ID {
			get { return workInProgress_ID; }
			set { workInProgress_ID = value; }
		}
		
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
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateStart value.
		/// </summary>
		public DateTime DateStart {
			get { return dateStart; }
			set { dateStart = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateEnd value.
		/// </summary>
		public DateTime DateEnd {
			get { return dateEnd; }
			set { dateEnd = value; }
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
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_iddle value.
		/// </summary>
		public decimal ExtraHours_iddle {
			get { return extraHours_iddle; }
			set { extraHours_iddle = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Maintenance value.
		/// </summary>
		public decimal ExtraHours_Maintenance {
			get { return extraHours_Maintenance; }
			set { extraHours_Maintenance = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Labours value.
		/// </summary>
		public decimal ExtraHours_Labours {
			get { return extraHours_Labours; }
			set { extraHours_Labours = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Cleaning value.
		/// </summary>
		public decimal ExtraHours_Cleaning {
			get { return extraHours_Cleaning; }
			set { extraHours_Cleaning = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Approval value.
		/// </summary>
		public decimal ExtraHours_Approval {
			get { return extraHours_Approval; }
			set { extraHours_Approval = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Powe_Air_etc value.
		/// </summary>
		public decimal ExtraHours_Powe_Air_etc {
			get { return extraHours_Powe_Air_etc; }
			set { extraHours_Powe_Air_etc = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_JobSetting value.
		/// </summary>
		public decimal ExtraHours_JobSetting {
			get { return extraHours_JobSetting; }
			set { extraHours_JobSetting = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_JobRunning value.
		/// </summary>
		public decimal ExtraHours_JobRunning {
			get { return extraHours_JobRunning; }
			set { extraHours_JobRunning = value; }
		}
		
		/// <summary>
		/// Gets or sets the CutbackSize value.
		/// </summary>
		public decimal CutbackSize {
			get { return cutbackSize; }
			set { cutbackSize = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsWorkInProgress_Machine_Shedule_Tmp table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_TmpInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateEnd", SqlDbType.DateTime,8);
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
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@extraHours_iddle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Maintenance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Labours", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Cleaning", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Approval", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Powe_Air_etc", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_JobSetting", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_JobRunning", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cutbackSize", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@dateStart"].Value = dateStart;
			scom.Parameters["@dateEnd"].Value = dateEnd;
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
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@extraHours_iddle"].Value = extraHours_iddle;
			scom.Parameters["@extraHours_Maintenance"].Value = extraHours_Maintenance;
			scom.Parameters["@extraHours_Labours"].Value = extraHours_Labours;
			scom.Parameters["@extraHours_Cleaning"].Value = extraHours_Cleaning;
			scom.Parameters["@extraHours_Approval"].Value = extraHours_Approval;
			scom.Parameters["@extraHours_Powe_Air_etc"].Value = extraHours_Powe_Air_etc;
			scom.Parameters["@extraHours_JobSetting"].Value = extraHours_JobSetting;
			scom.Parameters["@extraHours_JobRunning"].Value = extraHours_JobRunning;
			scom.Parameters["@cutbackSize"].Value = cutbackSize;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsWorkInProgress_Machine_Shedule_Tmp table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_TmpUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateEnd", SqlDbType.DateTime,8);
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
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@extraHours_iddle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Maintenance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Labours", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Cleaning", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Approval", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Powe_Air_etc", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_JobSetting", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_JobRunning", SqlDbType.Decimal,9);
			scom.Parameters.Add("@cutbackSize", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@dateStart"].Value = dateStart;
			scom.Parameters["@dateEnd"].Value = dateEnd;
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
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@extraHours_iddle"].Value = extraHours_iddle;
			scom.Parameters["@extraHours_Maintenance"].Value = extraHours_Maintenance;
			scom.Parameters["@extraHours_Labours"].Value = extraHours_Labours;
			scom.Parameters["@extraHours_Cleaning"].Value = extraHours_Cleaning;
			scom.Parameters["@extraHours_Approval"].Value = extraHours_Approval;
			scom.Parameters["@extraHours_Powe_Air_etc"].Value = extraHours_Powe_Air_etc;
			scom.Parameters["@extraHours_JobSetting"].Value = extraHours_JobSetting;
			scom.Parameters["@extraHours_JobRunning"].Value = extraHours_JobRunning;
			scom.Parameters["@cutbackSize"].Value = cutbackSize;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsWorkInProgress_Machine_Shedule_Tmp table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_TmpDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
 
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
 
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
 
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_Shedule_Tmp table by a foreign key.
		/// </summary>
		public static void DeleteAllByWorkInProgress_ID(string workInProgress_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_TmpDeleteAllByWorkInProgress_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsWorkInProgress_Machine_Shedule_Tmp table.
		/// </summary>
		public static tbl_pmsWorkInProgress_Machine_Shedule_Tmp Select(int line_NoShedule_Incoming, string workInProgress_ID_Incoming, int line_No_Incoming, string prePlan_ID_Incoming, string section_ID_Incoming, string machine_ID_Incoming){

			tbl_pmsWorkInProgress_Machine_Shedule_Tmp tbl_pmsWorkInProgress_Machine_Shedule_Tmpins = new tbl_pmsWorkInProgress_Machine_Shedule_Tmp();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_TmpSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule_Incoming;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID_Incoming;
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			scom.Parameters["@machine_ID"].Value = machine_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_Shedule_Tmpins = Maketbl_pmsWorkInProgress_Machine_Shedule_Tmp(dataReader);
				} else {
					tbl_pmsWorkInProgress_Machine_Shedule_Tmpins = null;
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_Shedule_Tmpins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_Shedule_Tmp table.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine_Shedule_Tmp> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_TmpSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsWorkInProgress_Machine_Shedule_Tmp> tbl_pmsWorkInProgress_Machine_Shedule_TmpList = new List<tbl_pmsWorkInProgress_Machine_Shedule_Tmp>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_Shedule_Tmp tbl_pmsWorkInProgress_Machine_Shedule_Tmp = Maketbl_pmsWorkInProgress_Machine_Shedule_Tmp(dataReader);
					tbl_pmsWorkInProgress_Machine_Shedule_TmpList.Add(tbl_pmsWorkInProgress_Machine_Shedule_Tmp);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_Shedule_TmpList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_Shedule_Tmp table by a foreign key.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine_Shedule_Tmp> SelectAllByWorkInProgress_ID(string workInProgress_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_Shedule_TmpSelectAllByWorkInProgress_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
				List<tbl_pmsWorkInProgress_Machine_Shedule_Tmp> tbl_pmsWorkInProgress_Machine_Shedule_TmpList = new List<tbl_pmsWorkInProgress_Machine_Shedule_Tmp>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_Shedule_Tmp tbl_pmsWorkInProgress_Machine_Shedule_Tmp = Maketbl_pmsWorkInProgress_Machine_Shedule_Tmp(dataReader);
					tbl_pmsWorkInProgress_Machine_Shedule_TmpList.Add(tbl_pmsWorkInProgress_Machine_Shedule_Tmp);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_Shedule_TmpList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsWorkInProgress_Machine_Shedule_Tmp class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsWorkInProgress_Machine_Shedule_Tmp Maketbl_pmsWorkInProgress_Machine_Shedule_Tmp(SqlDataReader dataReader) {
			tbl_pmsWorkInProgress_Machine_Shedule_Tmp tbl_pmsWorkInProgress_Machine_Shedule_Tmp = new tbl_pmsWorkInProgress_Machine_Shedule_Tmp();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.Line_NoShedule = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.WorkInProgress_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.Line_No = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.PrePlan_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.Section_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.Machine_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.DateStart = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.DateEnd = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.CreateUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ModifiedUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.CheckedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ApprovedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.DeletedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.PrintedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.CreateTerminal_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ModifiedTerminal_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.DeletedTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.PrintedTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.DateCreate = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.DateModified = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.DateChecked = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.DateApproved = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.DateDeleted = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.DatePrinted = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.Employee_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ExtraHours_iddle = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ExtraHours_Maintenance = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ExtraHours_Labours = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ExtraHours_Cleaning = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ExtraHours_Approval = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ExtraHours_Powe_Air_etc = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ExtraHours_JobSetting = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.ExtraHours_JobRunning = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_pmsWorkInProgress_Machine_Shedule_Tmp.CutbackSize = dataReader.GetDecimal(33);
			}

			return tbl_pmsWorkInProgress_Machine_Shedule_Tmp;
		}
		/// <summary>
		/// This makes tbl_pmsWorkInProgress_Machine_Shedule_Tmp datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsWorkInProgress_Machine_Shedule_Tmp object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsWorkInProgress_Machine_Shedule_Tmp  tbl_pmsWorkInProgress_Machine_Shedule_Tmp   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_NoShedule = new DataColumn("line_NoShedule" , typeof(int));
			DataColumn col_workInProgress_ID = new DataColumn("workInProgress_ID" , typeof(string));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prePlan_ID = new DataColumn("prePlan_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_dateStart = new DataColumn("dateStart" , typeof(DateTime));
			DataColumn col_dateEnd = new DataColumn("dateEnd" , typeof(DateTime));
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
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_extraHours_iddle = new DataColumn("extraHours_iddle" , typeof(decimal));
			DataColumn col_extraHours_Maintenance = new DataColumn("extraHours_Maintenance" , typeof(decimal));
			DataColumn col_extraHours_Labours = new DataColumn("extraHours_Labours" , typeof(decimal));
			DataColumn col_extraHours_Cleaning = new DataColumn("extraHours_Cleaning" , typeof(decimal));
			DataColumn col_extraHours_Approval = new DataColumn("extraHours_Approval" , typeof(decimal));
			DataColumn col_extraHours_Powe_Air_etc = new DataColumn("extraHours_Powe_Air_etc" , typeof(decimal));
			DataColumn col_extraHours_JobSetting = new DataColumn("extraHours_JobSetting" , typeof(decimal));
			DataColumn col_extraHours_JobRunning = new DataColumn("extraHours_JobRunning" , typeof(decimal));
			DataColumn col_cutbackSize = new DataColumn("cutbackSize" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_NoShedule,col_workInProgress_ID,col_line_No,col_prePlan_ID,col_section_ID,col_machine_ID,col_dateStart,col_dateEnd,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_employee_ID,col_extraHours_iddle,col_extraHours_Maintenance,col_extraHours_Labours,col_extraHours_Cleaning,col_extraHours_Approval,col_extraHours_Powe_Air_etc,col_extraHours_JobSetting,col_extraHours_JobRunning,col_cutbackSize,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsWorkInProgress_Machine_Shedule_Tmp datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsWorkInProgress_Machine_Shedule_Tmp object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsWorkInProgress_Machine_Shedule_Tmp user) {
		DataRow drow = dt.NewRow();
		
			drow["line_NoShedule"] = user.line_NoShedule;
			drow["workInProgress_ID"] = user.workInProgress_ID;
			drow["line_No"] = user.line_No;
			drow["prePlan_ID"] = user.prePlan_ID;
			drow["section_ID"] = user.section_ID;
			drow["machine_ID"] = user.machine_ID;
			drow["dateStart"] = user.dateStart;
			drow["dateEnd"] = user.dateEnd;
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
			drow["employee_ID"] = user.employee_ID;
			drow["extraHours_iddle"] = user.extraHours_iddle;
			drow["extraHours_Maintenance"] = user.extraHours_Maintenance;
			drow["extraHours_Labours"] = user.extraHours_Labours;
			drow["extraHours_Cleaning"] = user.extraHours_Cleaning;
			drow["extraHours_Approval"] = user.extraHours_Approval;
			drow["extraHours_Powe_Air_etc"] = user.extraHours_Powe_Air_etc;
			drow["extraHours_JobSetting"] = user.extraHours_JobSetting;
			drow["extraHours_JobRunning"] = user.extraHours_JobRunning;
			drow["cutbackSize"] = user.cutbackSize;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
