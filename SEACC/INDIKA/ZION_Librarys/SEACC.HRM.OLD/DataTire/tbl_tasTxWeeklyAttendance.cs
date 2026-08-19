using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasTxWeeklyAttendance {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int index_ID;
		private DateTime period_StartDate;
		private DateTime period_EndDate;
		private string employee_ID;
		private string division_ID;
		private string department_ID;
		private string section_ID;
		private string subSection_ID;
		private string empCatagory1_ID;
		private string empCatagory2_ID;
		private string empCatagory3_ID;
		private string attendanceGroup1_ID;
		private string attendanceGroup2_ID;
		private bool isTime_Attendance;
		private decimal workingDays_Mand;
		private decimal workingDays_Act;
		private decimal workingMinutes_Mand;
		private decimal workingMinutes_Act;
		private decimal noPayMinutes;
		private decimal lateMinutes;
		private decimal weeklyFixed_OT;
		private decimal workingMinutesAct_OT;
		private decimal workingMinutesAct_OT_Dub;
		private decimal workingMinutesAct_OT_Trpl;
		private decimal leaveMinutes;
		private decimal gatePassMinutes;
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
		/// Initializes a new instance of the tbl_tasTxWeeklyAttendance class.
		/// </summary>
		public tbl_tasTxWeeklyAttendance() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxWeeklyAttendance class.
		/// </summary>
		public tbl_tasTxWeeklyAttendance(string company_ID, string companyBranch_ID, int index_ID, DateTime period_StartDate, DateTime period_EndDate, string employee_ID, string division_ID, string department_ID, string section_ID, string subSection_ID, string empCatagory1_ID, string empCatagory2_ID, string empCatagory3_ID, string attendanceGroup1_ID, string attendanceGroup2_ID, bool isTime_Attendance, decimal workingDays_Mand, decimal workingDays_Act, decimal workingMinutes_Mand, decimal workingMinutes_Act, decimal noPayMinutes, decimal lateMinutes, decimal weeklyFixed_OT, decimal workingMinutesAct_OT, decimal workingMinutesAct_OT_Dub, decimal workingMinutesAct_OT_Trpl, decimal leaveMinutes, decimal gatePassMinutes, bool isChecked, bool isApproved, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string checkedTerminal_ID, string approvedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.index_ID = index_ID;
			this.period_StartDate = period_StartDate;
			this.period_EndDate = period_EndDate;
			this.employee_ID = employee_ID;
			this.division_ID = division_ID;
			this.department_ID = department_ID;
			this.section_ID = section_ID;
			this.subSection_ID = subSection_ID;
			this.empCatagory1_ID = empCatagory1_ID;
			this.empCatagory2_ID = empCatagory2_ID;
			this.empCatagory3_ID = empCatagory3_ID;
			this.attendanceGroup1_ID = attendanceGroup1_ID;
			this.attendanceGroup2_ID = attendanceGroup2_ID;
			this.isTime_Attendance = isTime_Attendance;
			this.workingDays_Mand = workingDays_Mand;
			this.workingDays_Act = workingDays_Act;
			this.workingMinutes_Mand = workingMinutes_Mand;
			this.workingMinutes_Act = workingMinutes_Act;
			this.noPayMinutes = noPayMinutes;
			this.lateMinutes = lateMinutes;
			this.weeklyFixed_OT = weeklyFixed_OT;
			this.workingMinutesAct_OT = workingMinutesAct_OT;
			this.workingMinutesAct_OT_Dub = workingMinutesAct_OT_Dub;
			this.workingMinutesAct_OT_Trpl = workingMinutesAct_OT_Trpl;
			this.leaveMinutes = leaveMinutes;
			this.gatePassMinutes = gatePassMinutes;
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
		/// Gets or sets the Period_StartDate value.
		/// </summary>
		public DateTime Period_StartDate {
			get { return period_StartDate; }
			set { period_StartDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Period_EndDate value.
		/// </summary>
		public DateTime Period_EndDate {
			get { return period_EndDate; }
			set { period_EndDate = value; }
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
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubSection_ID value.
		/// </summary>
		public string SubSection_ID {
			get { return subSection_ID; }
			set { subSection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpCatagory1_ID value.
		/// </summary>
		public string EmpCatagory1_ID {
			get { return empCatagory1_ID; }
			set { empCatagory1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpCatagory2_ID value.
		/// </summary>
		public string EmpCatagory2_ID {
			get { return empCatagory2_ID; }
			set { empCatagory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmpCatagory3_ID value.
		/// </summary>
		public string EmpCatagory3_ID {
			get { return empCatagory3_ID; }
			set { empCatagory3_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttendanceGroup1_ID value.
		/// </summary>
		public string AttendanceGroup1_ID {
			get { return attendanceGroup1_ID; }
			set { attendanceGroup1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttendanceGroup2_ID value.
		/// </summary>
		public string AttendanceGroup2_ID {
			get { return attendanceGroup2_ID; }
			set { attendanceGroup2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTime_Attendance value.
		/// </summary>
		public bool IsTime_Attendance {
			get { return isTime_Attendance; }
			set { isTime_Attendance = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingDays_Mand value.
		/// </summary>
		public decimal WorkingDays_Mand {
			get { return workingDays_Mand; }
			set { workingDays_Mand = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingDays_Act value.
		/// </summary>
		public decimal WorkingDays_Act {
			get { return workingDays_Act; }
			set { workingDays_Act = value; }
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
		/// Gets or sets the LateMinutes value.
		/// </summary>
		public decimal LateMinutes {
			get { return lateMinutes; }
			set { lateMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeeklyFixed_OT value.
		/// </summary>
		public decimal WeeklyFixed_OT {
			get { return weeklyFixed_OT; }
			set { weeklyFixed_OT = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutesAct_OT value.
		/// </summary>
		public decimal WorkingMinutesAct_OT {
			get { return workingMinutesAct_OT; }
			set { workingMinutesAct_OT = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutesAct_OT_Dub value.
		/// </summary>
		public decimal WorkingMinutesAct_OT_Dub {
			get { return workingMinutesAct_OT_Dub; }
			set { workingMinutesAct_OT_Dub = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutesAct_OT_Trpl value.
		/// </summary>
		public decimal WorkingMinutesAct_OT_Trpl {
			get { return workingMinutesAct_OT_Trpl; }
			set { workingMinutesAct_OT_Trpl = value; }
		}
		
		/// <summary>
		/// Gets or sets the LeaveMinutes value.
		/// </summary>
		public decimal LeaveMinutes {
			get { return leaveMinutes; }
			set { leaveMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the GatePassMinutes value.
		/// </summary>
		public decimal GatePassMinutes {
			get { return gatePassMinutes; }
			set { gatePassMinutes = value; }
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
		/// Saves a record to the tbl_tasTxWeeklyAttendance table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@index_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@period_StartDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@period_EndDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@empCatagory1_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory2_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory3_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendanceGroup1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attendanceGroup2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isTime_Attendance", SqlDbType.Bit,1);
			scom.Parameters.Add("@workingDays_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingDays_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noPayMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lateMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weeklyFixed_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Dub", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Trpl", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaveMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gatePassMinutes", SqlDbType.Decimal,9);
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
			scom.Parameters["@period_StartDate"].Value = period_StartDate;
			scom.Parameters["@period_EndDate"].Value = period_EndDate;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@subSection_ID"].Value = subSection_ID;
			scom.Parameters["@empCatagory1_ID"].Value = empCatagory1_ID;
			scom.Parameters["@empCatagory2_ID"].Value = empCatagory2_ID;
			scom.Parameters["@empCatagory3_ID"].Value = empCatagory3_ID;
			scom.Parameters["@attendanceGroup1_ID"].Value = attendanceGroup1_ID;
			scom.Parameters["@attendanceGroup2_ID"].Value = attendanceGroup2_ID;
			scom.Parameters["@isTime_Attendance"].Value = isTime_Attendance;
			scom.Parameters["@workingDays_Mand"].Value = workingDays_Mand;
			scom.Parameters["@workingDays_Act"].Value = workingDays_Act;
			scom.Parameters["@workingMinutes_Mand"].Value = workingMinutes_Mand;
			scom.Parameters["@workingMinutes_Act"].Value = workingMinutes_Act;
			scom.Parameters["@noPayMinutes"].Value = noPayMinutes;
			scom.Parameters["@lateMinutes"].Value = lateMinutes;
			scom.Parameters["@weeklyFixed_OT"].Value = weeklyFixed_OT;
			scom.Parameters["@workingMinutesAct_OT"].Value = workingMinutesAct_OT;
			scom.Parameters["@workingMinutesAct_OT_Dub"].Value = workingMinutesAct_OT_Dub;
			scom.Parameters["@workingMinutesAct_OT_Trpl"].Value = workingMinutesAct_OT_Trpl;
			scom.Parameters["@leaveMinutes"].Value = leaveMinutes;
			scom.Parameters["@gatePassMinutes"].Value = gatePassMinutes;
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
		/// Updates a record in the tbl_tasTxWeeklyAttendance table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@index_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@period_StartDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@period_EndDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@empCatagory1_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory2_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@empCatagory3_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendanceGroup1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attendanceGroup2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isTime_Attendance", SqlDbType.Bit,1);
			scom.Parameters.Add("@workingDays_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingDays_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noPayMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lateMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weeklyFixed_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Dub", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Trpl", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaveMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gatePassMinutes", SqlDbType.Decimal,9);
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
			scom.Parameters["@period_StartDate"].Value = period_StartDate;
			scom.Parameters["@period_EndDate"].Value = period_EndDate;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@subSection_ID"].Value = subSection_ID;
			scom.Parameters["@empCatagory1_ID"].Value = empCatagory1_ID;
			scom.Parameters["@empCatagory2_ID"].Value = empCatagory2_ID;
			scom.Parameters["@empCatagory3_ID"].Value = empCatagory3_ID;
			scom.Parameters["@attendanceGroup1_ID"].Value = attendanceGroup1_ID;
			scom.Parameters["@attendanceGroup2_ID"].Value = attendanceGroup2_ID;
			scom.Parameters["@isTime_Attendance"].Value = isTime_Attendance;
			scom.Parameters["@workingDays_Mand"].Value = workingDays_Mand;
			scom.Parameters["@workingDays_Act"].Value = workingDays_Act;
			scom.Parameters["@workingMinutes_Mand"].Value = workingMinutes_Mand;
			scom.Parameters["@workingMinutes_Act"].Value = workingMinutes_Act;
			scom.Parameters["@noPayMinutes"].Value = noPayMinutes;
			scom.Parameters["@lateMinutes"].Value = lateMinutes;
			scom.Parameters["@weeklyFixed_OT"].Value = weeklyFixed_OT;
			scom.Parameters["@workingMinutesAct_OT"].Value = workingMinutesAct_OT;
			scom.Parameters["@workingMinutesAct_OT_Dub"].Value = workingMinutesAct_OT_Dub;
			scom.Parameters["@workingMinutesAct_OT_Trpl"].Value = workingMinutesAct_OT_Trpl;
			scom.Parameters["@leaveMinutes"].Value = leaveMinutes;
			scom.Parameters["@gatePassMinutes"].Value = gatePassMinutes;
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
		/// Deletes a record from the tbl_tasTxWeeklyAttendance table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceDelete", scon);
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
		/// Selects all records from the tbl_tasTxWeeklyAttendance table by a foreign key.
		/// </summary>
		public static void DeleteAllByAttendanceGroup2_ID(string attendanceGroup2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceDeleteAllByAttendanceGroup2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attendanceGroup2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@attendanceGroup2_ID"].Value = attendanceGroup2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxWeeklyAttendance table by a foreign key.
		/// </summary>
		public static void DeleteAllByAttendanceGroup1_ID(string attendanceGroup1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceDeleteAllByAttendanceGroup1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attendanceGroup1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@attendanceGroup1_ID"].Value = attendanceGroup1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxWeeklyAttendance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
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
		/// Selects all records from the tbl_tasTxWeeklyAttendance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Division_ID(string company_ID, string companyBranch_ID, string division_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceDeleteAllByCompany_ID_CompanyBranch_ID_Division_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasTxWeeklyAttendance table.
		/// </summary>
		public static tbl_tasTxWeeklyAttendance Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int index_ID_Incoming){

			tbl_tasTxWeeklyAttendance tbl_tasTxWeeklyAttendanceins = new tbl_tasTxWeeklyAttendance();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceSelect", scon);
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
					tbl_tasTxWeeklyAttendanceins = Maketbl_tasTxWeeklyAttendance(dataReader);
				} else {
					tbl_tasTxWeeklyAttendanceins = null;
				}
			}
			scon.Close();
			return tbl_tasTxWeeklyAttendanceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxWeeklyAttendance table.
		/// </summary>
		public static List<tbl_tasTxWeeklyAttendance> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasTxWeeklyAttendance> tbl_tasTxWeeklyAttendanceList = new List<tbl_tasTxWeeklyAttendance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxWeeklyAttendance tbl_tasTxWeeklyAttendance = Maketbl_tasTxWeeklyAttendance(dataReader);
					tbl_tasTxWeeklyAttendanceList.Add(tbl_tasTxWeeklyAttendance);
				}
			}
			scon.Close();
			return tbl_tasTxWeeklyAttendanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxWeeklyAttendance table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxWeeklyAttendance> SelectAllByAttendanceGroup2_ID(string attendanceGroup2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceSelectAllByAttendanceGroup2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attendanceGroup2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@attendanceGroup2_ID"].Value = attendanceGroup2_ID;
				List<tbl_tasTxWeeklyAttendance> tbl_tasTxWeeklyAttendanceList = new List<tbl_tasTxWeeklyAttendance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxWeeklyAttendance tbl_tasTxWeeklyAttendance = Maketbl_tasTxWeeklyAttendance(dataReader);
					tbl_tasTxWeeklyAttendanceList.Add(tbl_tasTxWeeklyAttendance);
				}
			}
			scon.Close();
			return tbl_tasTxWeeklyAttendanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxWeeklyAttendance table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxWeeklyAttendance> SelectAllByAttendanceGroup1_ID(string attendanceGroup1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceSelectAllByAttendanceGroup1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attendanceGroup1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@attendanceGroup1_ID"].Value = attendanceGroup1_ID;
				List<tbl_tasTxWeeklyAttendance> tbl_tasTxWeeklyAttendanceList = new List<tbl_tasTxWeeklyAttendance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxWeeklyAttendance tbl_tasTxWeeklyAttendance = Maketbl_tasTxWeeklyAttendance(dataReader);
					tbl_tasTxWeeklyAttendanceList.Add(tbl_tasTxWeeklyAttendance);
				}
			}
			scon.Close();
			return tbl_tasTxWeeklyAttendanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxWeeklyAttendance table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxWeeklyAttendance> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_tasTxWeeklyAttendance> tbl_tasTxWeeklyAttendanceList = new List<tbl_tasTxWeeklyAttendance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxWeeklyAttendance tbl_tasTxWeeklyAttendance = Maketbl_tasTxWeeklyAttendance(dataReader);
					tbl_tasTxWeeklyAttendanceList.Add(tbl_tasTxWeeklyAttendance);
				}
			}
			scon.Close();
			return tbl_tasTxWeeklyAttendanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxWeeklyAttendance table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxWeeklyAttendance> SelectAllByCompany_ID_CompanyBranch_ID_Division_ID(string company_ID, string companyBranch_ID, string division_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceSelectAllByCompany_ID_CompanyBranch_ID_Division_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
				List<tbl_tasTxWeeklyAttendance> tbl_tasTxWeeklyAttendanceList = new List<tbl_tasTxWeeklyAttendance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxWeeklyAttendance tbl_tasTxWeeklyAttendance = Maketbl_tasTxWeeklyAttendance(dataReader);
					tbl_tasTxWeeklyAttendanceList.Add(tbl_tasTxWeeklyAttendance);
				}
			}
			scon.Close();
			return tbl_tasTxWeeklyAttendanceList;
		}
        public static List<tbl_tasTxWeeklyAttendance> SelectAllBy_EmployeeIDWithDateRange(string EmployeeID, DateTime FromDate, DateTime ToDate)
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasTxWeeklyAttendanceSelectAllByEmployeeID_DateRange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            scom.Parameters["@EmployeeID"].Value = EmployeeID;

            scom.Parameters.Add("@FromDate", SqlDbType.DateTime, 10);
            scom.Parameters["@FromDate"].Value = FromDate;

            scom.Parameters.Add("@ToDate", SqlDbType.DateTime, 10);
            scom.Parameters["@ToDate"].Value = ToDate;

            List<tbl_tasTxWeeklyAttendance> tbl_tasTxWeeklyAttendanceList = new List<tbl_tasTxWeeklyAttendance>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_tasTxWeeklyAttendance tbl_tasTxDailyAttendance = Maketbl_tasTxWeeklyAttendance(dataReader);
                    tbl_tasTxWeeklyAttendanceList.Add(tbl_tasTxDailyAttendance);
                }
            }
            scon.Close();
            return tbl_tasTxWeeklyAttendanceList;
        }
		/// <summary>
		/// Creates a new instance of the tbl_tasTxWeeklyAttendance class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasTxWeeklyAttendance Maketbl_tasTxWeeklyAttendance(SqlDataReader dataReader) {
			tbl_tasTxWeeklyAttendance tbl_tasTxWeeklyAttendance = new tbl_tasTxWeeklyAttendance();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasTxWeeklyAttendance.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasTxWeeklyAttendance.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasTxWeeklyAttendance.Index_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasTxWeeklyAttendance.Period_StartDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasTxWeeklyAttendance.Period_EndDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasTxWeeklyAttendance.Employee_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasTxWeeklyAttendance.Division_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasTxWeeklyAttendance.Department_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasTxWeeklyAttendance.Section_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasTxWeeklyAttendance.SubSection_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasTxWeeklyAttendance.EmpCatagory1_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasTxWeeklyAttendance.EmpCatagory2_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasTxWeeklyAttendance.EmpCatagory3_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasTxWeeklyAttendance.AttendanceGroup1_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasTxWeeklyAttendance.AttendanceGroup2_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_tasTxWeeklyAttendance.IsTime_Attendance = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_tasTxWeeklyAttendance.WorkingDays_Mand = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_tasTxWeeklyAttendance.WorkingDays_Act = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_tasTxWeeklyAttendance.WorkingMinutes_Mand = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_tasTxWeeklyAttendance.WorkingMinutes_Act = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_tasTxWeeklyAttendance.NoPayMinutes = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_tasTxWeeklyAttendance.LateMinutes = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_tasTxWeeklyAttendance.WeeklyFixed_OT = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_tasTxWeeklyAttendance.WorkingMinutesAct_OT = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_tasTxWeeklyAttendance.WorkingMinutesAct_OT_Dub = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_tasTxWeeklyAttendance.WorkingMinutesAct_OT_Trpl = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_tasTxWeeklyAttendance.LeaveMinutes = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_tasTxWeeklyAttendance.GatePassMinutes = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_tasTxWeeklyAttendance.IsChecked = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_tasTxWeeklyAttendance.IsApproved = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_tasTxWeeklyAttendance.CreateUser_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_tasTxWeeklyAttendance.ModifiedUser_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_tasTxWeeklyAttendance.CheckedUser_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_tasTxWeeklyAttendance.ApprovedUser_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_tasTxWeeklyAttendance.CreateTerminal_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_tasTxWeeklyAttendance.ModifiedTerminal_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_tasTxWeeklyAttendance.CheckedTerminal_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_tasTxWeeklyAttendance.ApprovedTerminal_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_tasTxWeeklyAttendance.DateCreate = dataReader.GetDateTime(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_tasTxWeeklyAttendance.DateModified = dataReader.GetDateTime(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_tasTxWeeklyAttendance.DateChecked = dataReader.GetDateTime(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_tasTxWeeklyAttendance.DateApproved = dataReader.GetDateTime(41);
			}

			return tbl_tasTxWeeklyAttendance;
		}
		/// <summary>
		/// This makes tbl_tasTxWeeklyAttendance datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasTxWeeklyAttendance object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasTxWeeklyAttendance  tbl_tasTxWeeklyAttendance   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_index_ID = new DataColumn("index_ID" , typeof(int));
			DataColumn col_period_StartDate = new DataColumn("period_StartDate" , typeof(DateTime));
			DataColumn col_period_EndDate = new DataColumn("period_EndDate" , typeof(DateTime));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_division_ID = new DataColumn("division_ID" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_subSection_ID = new DataColumn("subSection_ID" , typeof(string));
			DataColumn col_empCatagory1_ID = new DataColumn("empCatagory1_ID" , typeof(string));
			DataColumn col_empCatagory2_ID = new DataColumn("empCatagory2_ID" , typeof(string));
			DataColumn col_empCatagory3_ID = new DataColumn("empCatagory3_ID" , typeof(string));
			DataColumn col_attendanceGroup1_ID = new DataColumn("attendanceGroup1_ID" , typeof(string));
			DataColumn col_attendanceGroup2_ID = new DataColumn("attendanceGroup2_ID" , typeof(string));
			DataColumn col_isTime_Attendance = new DataColumn("isTime_Attendance" , typeof(bool));
			DataColumn col_workingDays_Mand = new DataColumn("workingDays_Mand" , typeof(decimal));
			DataColumn col_workingDays_Act = new DataColumn("workingDays_Act" , typeof(decimal));
			DataColumn col_workingMinutes_Mand = new DataColumn("workingMinutes_Mand" , typeof(decimal));
			DataColumn col_workingMinutes_Act = new DataColumn("workingMinutes_Act" , typeof(decimal));
			DataColumn col_noPayMinutes = new DataColumn("noPayMinutes" , typeof(decimal));
			DataColumn col_lateMinutes = new DataColumn("lateMinutes" , typeof(decimal));
			DataColumn col_weeklyFixed_OT = new DataColumn("weeklyFixed_OT" , typeof(decimal));
			DataColumn col_workingMinutesAct_OT = new DataColumn("workingMinutesAct_OT" , typeof(decimal));
			DataColumn col_workingMinutesAct_OT_Dub = new DataColumn("workingMinutesAct_OT_Dub" , typeof(decimal));
			DataColumn col_workingMinutesAct_OT_Trpl = new DataColumn("workingMinutesAct_OT_Trpl" , typeof(decimal));
			DataColumn col_leaveMinutes = new DataColumn("leaveMinutes" , typeof(decimal));
			DataColumn col_gatePassMinutes = new DataColumn("gatePassMinutes" , typeof(decimal));
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
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_index_ID,col_period_StartDate,col_period_EndDate,col_employee_ID,col_division_ID,col_department_ID,col_section_ID,col_subSection_ID,col_empCatagory1_ID,col_empCatagory2_ID,col_empCatagory3_ID,col_attendanceGroup1_ID,col_attendanceGroup2_ID,col_isTime_Attendance,col_workingDays_Mand,col_workingDays_Act,col_workingMinutes_Mand,col_workingMinutes_Act,col_noPayMinutes,col_lateMinutes,col_weeklyFixed_OT,col_workingMinutesAct_OT,col_workingMinutesAct_OT_Dub,col_workingMinutesAct_OT_Trpl,col_leaveMinutes,col_gatePassMinutes,col_isChecked,col_isApproved,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_checkedTerminal_ID,col_approvedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasTxWeeklyAttendance datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasTxWeeklyAttendance object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasTxWeeklyAttendance user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["index_ID"] = user.index_ID;
			drow["period_StartDate"] = user.period_StartDate;
			drow["period_EndDate"] = user.period_EndDate;
			drow["employee_ID"] = user.employee_ID;
			drow["division_ID"] = user.division_ID;
			drow["department_ID"] = user.department_ID;
			drow["section_ID"] = user.section_ID;
			drow["subSection_ID"] = user.subSection_ID;
			drow["empCatagory1_ID"] = user.empCatagory1_ID;
			drow["empCatagory2_ID"] = user.empCatagory2_ID;
			drow["empCatagory3_ID"] = user.empCatagory3_ID;
			drow["attendanceGroup1_ID"] = user.attendanceGroup1_ID;
			drow["attendanceGroup2_ID"] = user.attendanceGroup2_ID;
			drow["isTime_Attendance"] = user.isTime_Attendance;
			drow["workingDays_Mand"] = user.workingDays_Mand;
			drow["workingDays_Act"] = user.workingDays_Act;
			drow["workingMinutes_Mand"] = user.workingMinutes_Mand;
			drow["workingMinutes_Act"] = user.workingMinutes_Act;
			drow["noPayMinutes"] = user.noPayMinutes;
			drow["lateMinutes"] = user.lateMinutes;
			drow["weeklyFixed_OT"] = user.weeklyFixed_OT;
			drow["workingMinutesAct_OT"] = user.workingMinutesAct_OT;
			drow["workingMinutesAct_OT_Dub"] = user.workingMinutesAct_OT_Dub;
			drow["workingMinutesAct_OT_Trpl"] = user.workingMinutesAct_OT_Trpl;
			drow["leaveMinutes"] = user.leaveMinutes;
			drow["gatePassMinutes"] = user.gatePassMinutes;
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
