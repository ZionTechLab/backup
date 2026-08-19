using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasTxMonthlyAttendance {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int index_ID;
		private string attenProcessGroup_ID;
		private int attenProcessPeriod_ID;
		private string employee_ID;
		private string division_ID;
		private string department_ID;
		private string sectionID;
		private string subSectionID;
		private DateTime attenProcessPeriod_startDate;
		private DateTime attenProcessPeriod_endDate;
		private decimal workingMinutes_Mand;
		private decimal workingMinutes_Act;
		private decimal noPayMinutes;
		private decimal noPayMinutes_Act;
		private decimal lateMinutes;
		private decimal lateMinutes_Act;
		private decimal workingMinutes_OT;
		private decimal workingMinutes_OT_Act;
		private decimal workingMinutes_OT_Dub;
		private decimal workingMinutes_OT_Dub_Act;
		private decimal workingMinutes_OT_Trpl;
		private decimal workingMinutes_OT_Trpl_Act;
		private decimal leaveMinutes;
		private decimal leaveMinutes_Act;
		private decimal gatePassMinutes;
		private decimal gatePassMinutes_Act;
		private int attendanceIncentive;
		private bool isChecked;
		private bool isApproved;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string checkedTerminal_ID;
		private string approvedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxMonthlyAttendance class.
		/// </summary>
		public tbl_tasTxMonthlyAttendance() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxMonthlyAttendance class.
		/// </summary>
		public tbl_tasTxMonthlyAttendance(string company_ID, string companyBranch_ID, int index_ID, string attenProcessGroup_ID, int attenProcessPeriod_ID, string employee_ID, string division_ID, string department_ID, string sectionID, string subSectionID, DateTime attenProcessPeriod_startDate, DateTime attenProcessPeriod_endDate, decimal workingMinutes_Mand, decimal workingMinutes_Act, decimal noPayMinutes, decimal noPayMinutes_Act, decimal lateMinutes, decimal lateMinutes_Act, decimal workingMinutes_OT, decimal workingMinutes_OT_Act, decimal workingMinutes_OT_Dub, decimal workingMinutes_OT_Dub_Act, decimal workingMinutes_OT_Trpl, decimal workingMinutes_OT_Trpl_Act, decimal leaveMinutes, decimal leaveMinutes_Act, decimal gatePassMinutes, decimal gatePassMinutes_Act, int attendanceIncentive, bool isChecked, bool isApproved, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string checkedTerminal_ID, string approvedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.index_ID = index_ID;
			this.attenProcessGroup_ID = attenProcessGroup_ID;
			this.attenProcessPeriod_ID = attenProcessPeriod_ID;
			this.employee_ID = employee_ID;
			this.division_ID = division_ID;
			this.department_ID = department_ID;
			this.sectionID = sectionID;
			this.subSectionID = subSectionID;
			this.attenProcessPeriod_startDate = attenProcessPeriod_startDate;
			this.attenProcessPeriod_endDate = attenProcessPeriod_endDate;
			this.workingMinutes_Mand = workingMinutes_Mand;
			this.workingMinutes_Act = workingMinutes_Act;
			this.noPayMinutes = noPayMinutes;
			this.noPayMinutes_Act = noPayMinutes_Act;
			this.lateMinutes = lateMinutes;
			this.lateMinutes_Act = lateMinutes_Act;
			this.workingMinutes_OT = workingMinutes_OT;
			this.workingMinutes_OT_Act = workingMinutes_OT_Act;
			this.workingMinutes_OT_Dub = workingMinutes_OT_Dub;
			this.workingMinutes_OT_Dub_Act = workingMinutes_OT_Dub_Act;
			this.workingMinutes_OT_Trpl = workingMinutes_OT_Trpl;
			this.workingMinutes_OT_Trpl_Act = workingMinutes_OT_Trpl_Act;
			this.leaveMinutes = leaveMinutes;
			this.leaveMinutes_Act = leaveMinutes_Act;
			this.gatePassMinutes = gatePassMinutes;
			this.gatePassMinutes_Act = gatePassMinutes_Act;
			this.attendanceIncentive = attendanceIncentive;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.checkedTerminal_ID = checkedTerminal_ID;
			this.approvedTerminal_ID = approvedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Company_ID value.
		/// </summary>
		public string Company_ID {
			get { return company_ID; }
			set { company_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Index_ID value.
		/// </summary>
		public int Index_ID {
			get { return index_ID; }
			set { index_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttenProcessGroup_ID value.
		/// </summary>
		public string AttenProcessGroup_ID {
			get { return attenProcessGroup_ID; }
			set { attenProcessGroup_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttenProcessPeriod_ID value.
		/// </summary>
		public int AttenProcessPeriod_ID {
			get { return attenProcessPeriod_ID; }
			set { attenProcessPeriod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Division_ID value.
		/// </summary>
		public string Division_ID {
			get { return division_ID; }
			set { division_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionID value.
		/// </summary>
		public string SectionID {
			get { return sectionID; }
			set { sectionID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubSectionID value.
		/// </summary>
		public string SubSectionID {
			get { return subSectionID; }
			set { subSectionID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttenProcessPeriod_startDate value.
		/// </summary>
		public DateTime AttenProcessPeriod_startDate {
			get { return attenProcessPeriod_startDate; }
			set { attenProcessPeriod_startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttenProcessPeriod_endDate value.
		/// </summary>
		public DateTime AttenProcessPeriod_endDate {
			get { return attenProcessPeriod_endDate; }
			set { attenProcessPeriod_endDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_Mand value.
		/// </summary>
		public decimal WorkingMinutes_Mand {
			get { return workingMinutes_Mand; }
			set { workingMinutes_Mand = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_Act value.
		/// </summary>
		public decimal WorkingMinutes_Act {
			get { return workingMinutes_Act; }
			set { workingMinutes_Act = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoPayMinutes value.
		/// </summary>
		public decimal NoPayMinutes {
			get { return noPayMinutes; }
			set { noPayMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoPayMinutes_Act value.
		/// </summary>
		public decimal NoPayMinutes_Act {
			get { return noPayMinutes_Act; }
			set { noPayMinutes_Act = value; }
		}
		
		/// <summary>
		/// Gets or sets the LateMinutes value.
		/// </summary>
		public decimal LateMinutes {
			get { return lateMinutes; }
			set { lateMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the LateMinutes_Act value.
		/// </summary>
		public decimal LateMinutes_Act {
			get { return lateMinutes_Act; }
			set { lateMinutes_Act = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_OT value.
		/// </summary>
		public decimal WorkingMinutes_OT {
			get { return workingMinutes_OT; }
			set { workingMinutes_OT = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_OT_Act value.
		/// </summary>
		public decimal WorkingMinutes_OT_Act {
			get { return workingMinutes_OT_Act; }
			set { workingMinutes_OT_Act = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_OT_Dub value.
		/// </summary>
		public decimal WorkingMinutes_OT_Dub {
			get { return workingMinutes_OT_Dub; }
			set { workingMinutes_OT_Dub = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_OT_Dub_Act value.
		/// </summary>
		public decimal WorkingMinutes_OT_Dub_Act {
			get { return workingMinutes_OT_Dub_Act; }
			set { workingMinutes_OT_Dub_Act = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_OT_Trpl value.
		/// </summary>
		public decimal WorkingMinutes_OT_Trpl {
			get { return workingMinutes_OT_Trpl; }
			set { workingMinutes_OT_Trpl = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_OT_Trpl_Act value.
		/// </summary>
		public decimal WorkingMinutes_OT_Trpl_Act {
			get { return workingMinutes_OT_Trpl_Act; }
			set { workingMinutes_OT_Trpl_Act = value; }
		}
		
		/// <summary>
		/// Gets or sets the LeaveMinutes value.
		/// </summary>
		public decimal LeaveMinutes {
			get { return leaveMinutes; }
			set { leaveMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the LeaveMinutes_Act value.
		/// </summary>
		public decimal LeaveMinutes_Act {
			get { return leaveMinutes_Act; }
			set { leaveMinutes_Act = value; }
		}
		
		/// <summary>
		/// Gets or sets the GatePassMinutes value.
		/// </summary>
		public decimal GatePassMinutes {
			get { return gatePassMinutes; }
			set { gatePassMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the GatePassMinutes_Act value.
		/// </summary>
		public decimal GatePassMinutes_Act {
			get { return gatePassMinutes_Act; }
			set { gatePassMinutes_Act = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttendanceIncentive value.
		/// </summary>
		public int AttendanceIncentive {
			get { return attendanceIncentive; }
			set { attendanceIncentive = value; }
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
		/// Gets or sets the CheckedTerminal_ID value.
		/// </summary>
		public string CheckedTerminal_ID {
			get { return checkedTerminal_ID; }
			set { checkedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedTerminal_ID value.
		/// </summary>
		public string ApprovedTerminal_ID {
			get { return approvedTerminal_ID; }
			set { approvedTerminal_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasTxMonthlyAttendance table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@index_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attenProcessPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@attenProcessPeriod_startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@attenProcessPeriod_endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@workingMinutes_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noPayMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noPayMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lateMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lateMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT_Dub", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT_Dub_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT_Trpl", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT_Trpl_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaveMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaveMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gatePassMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gatePassMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@attendanceIncentive", SqlDbType.Int,4);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@index_ID"].Value = index_ID;
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
			scom.Parameters["@attenProcessPeriod_ID"].Value = attenProcessPeriod_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@sectionID"].Value = sectionID;
			scom.Parameters["@subSectionID"].Value = subSectionID;
			scom.Parameters["@attenProcessPeriod_startDate"].Value = attenProcessPeriod_startDate;
			scom.Parameters["@attenProcessPeriod_endDate"].Value = attenProcessPeriod_endDate;
			scom.Parameters["@workingMinutes_Mand"].Value = workingMinutes_Mand;
			scom.Parameters["@workingMinutes_Act"].Value = workingMinutes_Act;
			scom.Parameters["@noPayMinutes"].Value = noPayMinutes;
			scom.Parameters["@noPayMinutes_Act"].Value = noPayMinutes_Act;
			scom.Parameters["@lateMinutes"].Value = lateMinutes;
			scom.Parameters["@lateMinutes_Act"].Value = lateMinutes_Act;
			scom.Parameters["@workingMinutes_OT"].Value = workingMinutes_OT;
			scom.Parameters["@workingMinutes_OT_Act"].Value = workingMinutes_OT_Act;
			scom.Parameters["@workingMinutes_OT_Dub"].Value = workingMinutes_OT_Dub;
			scom.Parameters["@workingMinutes_OT_Dub_Act"].Value = workingMinutes_OT_Dub_Act;
			scom.Parameters["@workingMinutes_OT_Trpl"].Value = workingMinutes_OT_Trpl;
			scom.Parameters["@workingMinutes_OT_Trpl_Act"].Value = workingMinutes_OT_Trpl_Act;
			scom.Parameters["@leaveMinutes"].Value = leaveMinutes;
			scom.Parameters["@leaveMinutes_Act"].Value = leaveMinutes_Act;
			scom.Parameters["@gatePassMinutes"].Value = gatePassMinutes;
			scom.Parameters["@gatePassMinutes_Act"].Value = gatePassMinutes_Act;
			scom.Parameters["@attendanceIncentive"].Value = attendanceIncentive;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasTxMonthlyAttendance table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@index_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attenProcessPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@attenProcessPeriod_startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@attenProcessPeriod_endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@workingMinutes_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noPayMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noPayMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lateMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lateMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT_Dub", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT_Dub_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT_Trpl", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_OT_Trpl_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaveMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaveMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gatePassMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gatePassMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@attendanceIncentive", SqlDbType.Int,4);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@index_ID"].Value = index_ID;
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
			scom.Parameters["@attenProcessPeriod_ID"].Value = attenProcessPeriod_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@sectionID"].Value = sectionID;
			scom.Parameters["@subSectionID"].Value = subSectionID;
			scom.Parameters["@attenProcessPeriod_startDate"].Value = attenProcessPeriod_startDate;
			scom.Parameters["@attenProcessPeriod_endDate"].Value = attenProcessPeriod_endDate;
			scom.Parameters["@workingMinutes_Mand"].Value = workingMinutes_Mand;
			scom.Parameters["@workingMinutes_Act"].Value = workingMinutes_Act;
			scom.Parameters["@noPayMinutes"].Value = noPayMinutes;
			scom.Parameters["@noPayMinutes_Act"].Value = noPayMinutes_Act;
			scom.Parameters["@lateMinutes"].Value = lateMinutes;
			scom.Parameters["@lateMinutes_Act"].Value = lateMinutes_Act;
			scom.Parameters["@workingMinutes_OT"].Value = workingMinutes_OT;
			scom.Parameters["@workingMinutes_OT_Act"].Value = workingMinutes_OT_Act;
			scom.Parameters["@workingMinutes_OT_Dub"].Value = workingMinutes_OT_Dub;
			scom.Parameters["@workingMinutes_OT_Dub_Act"].Value = workingMinutes_OT_Dub_Act;
			scom.Parameters["@workingMinutes_OT_Trpl"].Value = workingMinutes_OT_Trpl;
			scom.Parameters["@workingMinutes_OT_Trpl_Act"].Value = workingMinutes_OT_Trpl_Act;
			scom.Parameters["@leaveMinutes"].Value = leaveMinutes;
			scom.Parameters["@leaveMinutes_Act"].Value = leaveMinutes_Act;
			scom.Parameters["@gatePassMinutes"].Value = gatePassMinutes;
			scom.Parameters["@gatePassMinutes_Act"].Value = gatePassMinutes_Act;
			scom.Parameters["@attendanceIncentive"].Value = attendanceIncentive;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasTxMonthlyAttendance table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@index_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@index_ID"].Value = index_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxMonthlyAttendance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_AttenProcessGroup_ID_AttenProcessPeriod_ID(string company_ID, string companyBranch_ID, string attenProcessGroup_ID, int attenProcessPeriod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceDeleteAllByCompany_ID_CompanyBranch_ID_AttenProcessGroup_ID_AttenProcessPeriod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attenProcessPeriod_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
			scom.Parameters["@attenProcessPeriod_ID"].Value = attenProcessPeriod_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxMonthlyAttendance table by a foreign key.
		/// </summary>
		public static void DeleteAllByAttenProcessGroup_ID(string attenProcessGroup_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceDeleteAllByAttenProcessGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxMonthlyAttendance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasTxMonthlyAttendance table.
		/// </summary>
		public static tbl_tasTxMonthlyAttendance Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int index_ID_Incoming){

			tbl_tasTxMonthlyAttendance tbl_tasTxMonthlyAttendanceins = new tbl_tasTxMonthlyAttendance();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@index_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@index_ID"].Value = index_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasTxMonthlyAttendanceins = Maketbl_tasTxMonthlyAttendance(dataReader);
				} else {
					tbl_tasTxMonthlyAttendanceins = null;
				}
			}
			scon.Close();
			return tbl_tasTxMonthlyAttendanceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxMonthlyAttendance table.
		/// </summary>
		public static List<tbl_tasTxMonthlyAttendance> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasTxMonthlyAttendance> tbl_tasTxMonthlyAttendanceList = new List<tbl_tasTxMonthlyAttendance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxMonthlyAttendance tbl_tasTxMonthlyAttendance = Maketbl_tasTxMonthlyAttendance(dataReader);
					tbl_tasTxMonthlyAttendanceList.Add(tbl_tasTxMonthlyAttendance);
				}
			}
			scon.Close();
			return tbl_tasTxMonthlyAttendanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxMonthlyAttendance table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxMonthlyAttendance> SelectAllByCompany_ID_CompanyBranch_ID_AttenProcessGroup_ID_AttenProcessPeriod_ID(string company_ID, string companyBranch_ID, string attenProcessGroup_ID, int attenProcessPeriod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceSelectAllByCompany_ID_CompanyBranch_ID_AttenProcessGroup_ID_AttenProcessPeriod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attenProcessPeriod_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
			scom.Parameters["@attenProcessPeriod_ID"].Value = attenProcessPeriod_ID;
				List<tbl_tasTxMonthlyAttendance> tbl_tasTxMonthlyAttendanceList = new List<tbl_tasTxMonthlyAttendance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxMonthlyAttendance tbl_tasTxMonthlyAttendance = Maketbl_tasTxMonthlyAttendance(dataReader);
					tbl_tasTxMonthlyAttendanceList.Add(tbl_tasTxMonthlyAttendance);
				}
			}
			scon.Close();
			return tbl_tasTxMonthlyAttendanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxMonthlyAttendance table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxMonthlyAttendance> SelectAllByAttenProcessGroup_ID(string attenProcessGroup_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceSelectAllByAttenProcessGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
				List<tbl_tasTxMonthlyAttendance> tbl_tasTxMonthlyAttendanceList = new List<tbl_tasTxMonthlyAttendance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxMonthlyAttendance tbl_tasTxMonthlyAttendance = Maketbl_tasTxMonthlyAttendance(dataReader);
					tbl_tasTxMonthlyAttendanceList.Add(tbl_tasTxMonthlyAttendance);
				}
			}
			scon.Close();
			return tbl_tasTxMonthlyAttendanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxMonthlyAttendance table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxMonthlyAttendance> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_tasTxMonthlyAttendance> tbl_tasTxMonthlyAttendanceList = new List<tbl_tasTxMonthlyAttendance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxMonthlyAttendance tbl_tasTxMonthlyAttendance = Maketbl_tasTxMonthlyAttendance(dataReader);
					tbl_tasTxMonthlyAttendanceList.Add(tbl_tasTxMonthlyAttendance);
				}
			}
			scon.Close();
			return tbl_tasTxMonthlyAttendanceList;
		}
        public static List<tbl_tasTxMonthlyAttendance> SelectAllBy_EmployeeIDWithDateRange(string EmployeeID, DateTime FromDate, DateTime ToDate)
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendanceSelectAllByEmployeeID_DateRange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            scom.Parameters["@EmployeeID"].Value = EmployeeID;

            scom.Parameters.Add("@FromDate", SqlDbType.DateTime, 10);
            scom.Parameters["@FromDate"].Value = FromDate;

            scom.Parameters.Add("@ToDate", SqlDbType.DateTime, 10);
            scom.Parameters["@ToDate"].Value = ToDate;

            List<tbl_tasTxMonthlyAttendance> tbl_tasTxMonthlyAttendanceList = new List<tbl_tasTxMonthlyAttendance>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_tasTxMonthlyAttendance tbl_tasTxDailyAttendance = Maketbl_tasTxMonthlyAttendance(dataReader);
                    tbl_tasTxMonthlyAttendanceList.Add(tbl_tasTxDailyAttendance);
                }
            }
            scon.Close();
            return tbl_tasTxMonthlyAttendanceList;
        }
		
		/// <summary>
		/// Creates a new instance of the tbl_tasTxMonthlyAttendance class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasTxMonthlyAttendance Maketbl_tasTxMonthlyAttendance(SqlDataReader dataReader) {
			tbl_tasTxMonthlyAttendance tbl_tasTxMonthlyAttendance = new tbl_tasTxMonthlyAttendance();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasTxMonthlyAttendance.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasTxMonthlyAttendance.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasTxMonthlyAttendance.Index_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasTxMonthlyAttendance.AttenProcessGroup_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasTxMonthlyAttendance.AttenProcessPeriod_ID = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasTxMonthlyAttendance.Employee_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasTxMonthlyAttendance.Division_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasTxMonthlyAttendance.Department_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasTxMonthlyAttendance.SectionID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasTxMonthlyAttendance.SubSectionID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasTxMonthlyAttendance.AttenProcessPeriod_startDate = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasTxMonthlyAttendance.AttenProcessPeriod_endDate = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasTxMonthlyAttendance.WorkingMinutes_Mand = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasTxMonthlyAttendance.WorkingMinutes_Act = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasTxMonthlyAttendance.NoPayMinutes = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_tasTxMonthlyAttendance.NoPayMinutes_Act = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_tasTxMonthlyAttendance.LateMinutes = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_tasTxMonthlyAttendance.LateMinutes_Act = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_tasTxMonthlyAttendance.WorkingMinutes_OT = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_tasTxMonthlyAttendance.WorkingMinutes_OT_Act = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_tasTxMonthlyAttendance.WorkingMinutes_OT_Dub = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_tasTxMonthlyAttendance.WorkingMinutes_OT_Dub_Act = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_tasTxMonthlyAttendance.WorkingMinutes_OT_Trpl = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_tasTxMonthlyAttendance.WorkingMinutes_OT_Trpl_Act = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_tasTxMonthlyAttendance.LeaveMinutes = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_tasTxMonthlyAttendance.LeaveMinutes_Act = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_tasTxMonthlyAttendance.GatePassMinutes = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_tasTxMonthlyAttendance.GatePassMinutes_Act = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_tasTxMonthlyAttendance.AttendanceIncentive = dataReader.GetInt32(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_tasTxMonthlyAttendance.IsChecked = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_tasTxMonthlyAttendance.IsApproved = dataReader.GetBoolean(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_tasTxMonthlyAttendance.CreateUser_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_tasTxMonthlyAttendance.ModifiedUser_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_tasTxMonthlyAttendance.CheckedUser_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_tasTxMonthlyAttendance.ApprovedUser_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_tasTxMonthlyAttendance.CreateTerminal_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_tasTxMonthlyAttendance.ModifiedTerminal_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_tasTxMonthlyAttendance.CheckedTerminal_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_tasTxMonthlyAttendance.ApprovedTerminal_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_tasTxMonthlyAttendance.DateCreate = dataReader.GetDateTime(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_tasTxMonthlyAttendance.DateModified = dataReader.GetDateTime(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_tasTxMonthlyAttendance.DateChecked = dataReader.GetDateTime(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_tasTxMonthlyAttendance.DateApproved = dataReader.GetDateTime(42);
			}

			return tbl_tasTxMonthlyAttendance;
		}
		/// <summary>
		/// This makes tbl_tasTxMonthlyAttendance datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasTxMonthlyAttendance object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasTxMonthlyAttendance  tbl_tasTxMonthlyAttendance   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_index_ID = new DataColumn("index_ID" , typeof(int));
			DataColumn col_attenProcessGroup_ID = new DataColumn("attenProcessGroup_ID" , typeof(string));
			DataColumn col_attenProcessPeriod_ID = new DataColumn("attenProcessPeriod_ID" , typeof(int));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_division_ID = new DataColumn("division_ID" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_sectionID = new DataColumn("sectionID" , typeof(string));
			DataColumn col_subSectionID = new DataColumn("subSectionID" , typeof(string));
			DataColumn col_attenProcessPeriod_startDate = new DataColumn("attenProcessPeriod_startDate" , typeof(DateTime));
			DataColumn col_attenProcessPeriod_endDate = new DataColumn("attenProcessPeriod_endDate" , typeof(DateTime));
			DataColumn col_workingMinutes_Mand = new DataColumn("workingMinutes_Mand" , typeof(decimal));
			DataColumn col_workingMinutes_Act = new DataColumn("workingMinutes_Act" , typeof(decimal));
			DataColumn col_noPayMinutes = new DataColumn("noPayMinutes" , typeof(decimal));
			DataColumn col_noPayMinutes_Act = new DataColumn("noPayMinutes_Act" , typeof(decimal));
			DataColumn col_lateMinutes = new DataColumn("lateMinutes" , typeof(decimal));
			DataColumn col_lateMinutes_Act = new DataColumn("lateMinutes_Act" , typeof(decimal));
			DataColumn col_workingMinutes_OT = new DataColumn("workingMinutes_OT" , typeof(decimal));
			DataColumn col_workingMinutes_OT_Act = new DataColumn("workingMinutes_OT_Act" , typeof(decimal));
			DataColumn col_workingMinutes_OT_Dub = new DataColumn("workingMinutes_OT_Dub" , typeof(decimal));
			DataColumn col_workingMinutes_OT_Dub_Act = new DataColumn("workingMinutes_OT_Dub_Act" , typeof(decimal));
			DataColumn col_workingMinutes_OT_Trpl = new DataColumn("workingMinutes_OT_Trpl" , typeof(decimal));
			DataColumn col_workingMinutes_OT_Trpl_Act = new DataColumn("workingMinutes_OT_Trpl_Act" , typeof(decimal));
			DataColumn col_leaveMinutes = new DataColumn("leaveMinutes" , typeof(decimal));
			DataColumn col_leaveMinutes_Act = new DataColumn("leaveMinutes_Act" , typeof(decimal));
			DataColumn col_gatePassMinutes = new DataColumn("gatePassMinutes" , typeof(decimal));
			DataColumn col_gatePassMinutes_Act = new DataColumn("gatePassMinutes_Act" , typeof(decimal));
			DataColumn col_attendanceIncentive = new DataColumn("attendanceIncentive" , typeof(int));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_checkedTerminal_ID = new DataColumn("checkedTerminal_ID" , typeof(string));
			DataColumn col_approvedTerminal_ID = new DataColumn("approvedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_index_ID,col_attenProcessGroup_ID,col_attenProcessPeriod_ID,col_employee_ID,col_division_ID,col_department_ID,col_sectionID,col_subSectionID,col_attenProcessPeriod_startDate,col_attenProcessPeriod_endDate,col_workingMinutes_Mand,col_workingMinutes_Act,col_noPayMinutes,col_noPayMinutes_Act,col_lateMinutes,col_lateMinutes_Act,col_workingMinutes_OT,col_workingMinutes_OT_Act,col_workingMinutes_OT_Dub,col_workingMinutes_OT_Dub_Act,col_workingMinutes_OT_Trpl,col_workingMinutes_OT_Trpl_Act,col_leaveMinutes,col_leaveMinutes_Act,col_gatePassMinutes,col_gatePassMinutes_Act,col_attendanceIncentive,col_isChecked,col_isApproved,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_checkedTerminal_ID,col_approvedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasTxMonthlyAttendance datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasTxMonthlyAttendance object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasTxMonthlyAttendance user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["index_ID"] = user.index_ID;
			drow["attenProcessGroup_ID"] = user.attenProcessGroup_ID;
			drow["attenProcessPeriod_ID"] = user.attenProcessPeriod_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["division_ID"] = user.division_ID;
			drow["department_ID"] = user.department_ID;
			drow["sectionID"] = user.sectionID;
			drow["subSectionID"] = user.subSectionID;
			drow["attenProcessPeriod_startDate"] = user.attenProcessPeriod_startDate;
			drow["attenProcessPeriod_endDate"] = user.attenProcessPeriod_endDate;
			drow["workingMinutes_Mand"] = user.workingMinutes_Mand;
			drow["workingMinutes_Act"] = user.workingMinutes_Act;
			drow["noPayMinutes"] = user.noPayMinutes;
			drow["noPayMinutes_Act"] = user.noPayMinutes_Act;
			drow["lateMinutes"] = user.lateMinutes;
			drow["lateMinutes_Act"] = user.lateMinutes_Act;
			drow["workingMinutes_OT"] = user.workingMinutes_OT;
			drow["workingMinutes_OT_Act"] = user.workingMinutes_OT_Act;
			drow["workingMinutes_OT_Dub"] = user.workingMinutes_OT_Dub;
			drow["workingMinutes_OT_Dub_Act"] = user.workingMinutes_OT_Dub_Act;
			drow["workingMinutes_OT_Trpl"] = user.workingMinutes_OT_Trpl;
			drow["workingMinutes_OT_Trpl_Act"] = user.workingMinutes_OT_Trpl_Act;
			drow["leaveMinutes"] = user.leaveMinutes;
			drow["leaveMinutes_Act"] = user.leaveMinutes_Act;
			drow["gatePassMinutes"] = user.gatePassMinutes;
			drow["gatePassMinutes_Act"] = user.gatePassMinutes_Act;
			drow["attendanceIncentive"] = user.attendanceIncentive;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["checkedTerminal_ID"] = user.checkedTerminal_ID;
			drow["approvedTerminal_ID"] = user.approvedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
