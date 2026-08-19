using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasTxDailyAttendance_revision {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int attendance_revision_index;
		private DateTime attendenceDate;
		private string employee_ID;
		private string department_ID;
		private int dayType;
		private string shift_ID;
		private int shiftDay;
		private DateTime shiftStartTime;
		private DateTime shiftEndTime;
		private int shiftMinutes;
		private int shiftMinutesMin;
		private int nextShiftMinutes;
		private int shiftGracePeriod;
		private int timeIn_ID;
		private DateTime timeIn_DateTime;
		private int timeOut_ID;
		private DateTime timeOut_DateTime;
		private int totalMinutes;
		private int workedMinutes;
		private decimal oTRate;
		private decimal dOTRate;
		private decimal tOTRate;
		private int oTMinutes;
		private int dOTMinutes;
		private int tOTMinutes;
		private bool isOT_Applicable;
		private int oTMinutesApproved;
		private int dOTMinutesApproved;
		private int tOTMinutesApproved;
		private int lateMinutes;
		private int lateMinutesApproved;
		private int noPayMinutes;
		private int noPayMinutesApproved;
		private int leaveMinutes;
		private int gpMinutes;
		private bool isCanceled;
		private bool isOverride;
		private int approvalStatus;
		private string userID_Created;
		private string userID_Approvad;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Approvad;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Approvad;
		private DateTime date_Canceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxDailyAttendance_revision class.
		/// </summary>
		public tbl_tasTxDailyAttendance_revision() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxDailyAttendance_revision class.
		/// </summary>
		public tbl_tasTxDailyAttendance_revision(string company_ID, string companyBranch_ID, DateTime attendenceDate, string employee_ID, string department_ID, int dayType, string shift_ID, int shiftDay, DateTime shiftStartTime, DateTime shiftEndTime, int shiftMinutes, int shiftMinutesMin, int nextShiftMinutes, int shiftGracePeriod, int timeIn_ID, DateTime timeIn_DateTime, int timeOut_ID, DateTime timeOut_DateTime, int totalMinutes, int workedMinutes, decimal oTRate, decimal dOTRate, decimal tOTRate, int oTMinutes, int dOTMinutes, int tOTMinutes, bool isOT_Applicable, int oTMinutesApproved, int dOTMinutesApproved, int tOTMinutesApproved, int lateMinutes, int lateMinutesApproved, int noPayMinutes, int noPayMinutesApproved, int leaveMinutes, int gpMinutes, bool isCanceled, bool isOverride, int approvalStatus, string userID_Created, string userID_Approvad, string userID_Canceled, string terminalID_Created, string terminalID_Approvad, string terminalID_Canceled, DateTime date_Created, DateTime date_Approvad, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.attendenceDate = attendenceDate;
			this.employee_ID = employee_ID;
			this.department_ID = department_ID;
			this.dayType = dayType;
			this.shift_ID = shift_ID;
			this.shiftDay = shiftDay;
			this.shiftStartTime = shiftStartTime;
			this.shiftEndTime = shiftEndTime;
			this.shiftMinutes = shiftMinutes;
			this.shiftMinutesMin = shiftMinutesMin;
			this.nextShiftMinutes = nextShiftMinutes;
			this.shiftGracePeriod = shiftGracePeriod;
			this.timeIn_ID = timeIn_ID;
			this.timeIn_DateTime = timeIn_DateTime;
			this.timeOut_ID = timeOut_ID;
			this.timeOut_DateTime = timeOut_DateTime;
			this.totalMinutes = totalMinutes;
			this.workedMinutes = workedMinutes;
			this.oTRate = oTRate;
			this.dOTRate = dOTRate;
			this.tOTRate = tOTRate;
			this.oTMinutes = oTMinutes;
			this.dOTMinutes = dOTMinutes;
			this.tOTMinutes = tOTMinutes;
			this.isOT_Applicable = isOT_Applicable;
			this.oTMinutesApproved = oTMinutesApproved;
			this.dOTMinutesApproved = dOTMinutesApproved;
			this.tOTMinutesApproved = tOTMinutesApproved;
			this.lateMinutes = lateMinutes;
			this.lateMinutesApproved = lateMinutesApproved;
			this.noPayMinutes = noPayMinutes;
			this.noPayMinutesApproved = noPayMinutesApproved;
			this.leaveMinutes = leaveMinutes;
			this.gpMinutes = gpMinutes;
			this.isCanceled = isCanceled;
			this.isOverride = isOverride;
			this.approvalStatus = approvalStatus;
			this.userID_Created = userID_Created;
			this.userID_Approvad = userID_Approvad;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Approvad = terminalID_Approvad;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Approvad = date_Approvad;
			this.date_Canceled = date_Canceled;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxDailyAttendance_revision class.
		/// </summary>
		public tbl_tasTxDailyAttendance_revision(string company_ID, string companyBranch_ID, int attendance_revision_index, DateTime attendenceDate, string employee_ID, string department_ID, int dayType, string shift_ID, int shiftDay, DateTime shiftStartTime, DateTime shiftEndTime, int shiftMinutes, int shiftMinutesMin, int nextShiftMinutes, int shiftGracePeriod, int timeIn_ID, DateTime timeIn_DateTime, int timeOut_ID, DateTime timeOut_DateTime, int totalMinutes, int workedMinutes, decimal oTRate, decimal dOTRate, decimal tOTRate, int oTMinutes, int dOTMinutes, int tOTMinutes, bool isOT_Applicable, int oTMinutesApproved, int dOTMinutesApproved, int tOTMinutesApproved, int lateMinutes, int lateMinutesApproved, int noPayMinutes, int noPayMinutesApproved, int leaveMinutes, int gpMinutes, bool isCanceled, bool isOverride, int approvalStatus, string userID_Created, string userID_Approvad, string userID_Canceled, string terminalID_Created, string terminalID_Approvad, string terminalID_Canceled, DateTime date_Created, DateTime date_Approvad, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.attendance_revision_index = attendance_revision_index;
			this.attendenceDate = attendenceDate;
			this.employee_ID = employee_ID;
			this.department_ID = department_ID;
			this.dayType = dayType;
			this.shift_ID = shift_ID;
			this.shiftDay = shiftDay;
			this.shiftStartTime = shiftStartTime;
			this.shiftEndTime = shiftEndTime;
			this.shiftMinutes = shiftMinutes;
			this.shiftMinutesMin = shiftMinutesMin;
			this.nextShiftMinutes = nextShiftMinutes;
			this.shiftGracePeriod = shiftGracePeriod;
			this.timeIn_ID = timeIn_ID;
			this.timeIn_DateTime = timeIn_DateTime;
			this.timeOut_ID = timeOut_ID;
			this.timeOut_DateTime = timeOut_DateTime;
			this.totalMinutes = totalMinutes;
			this.workedMinutes = workedMinutes;
			this.oTRate = oTRate;
			this.dOTRate = dOTRate;
			this.tOTRate = tOTRate;
			this.oTMinutes = oTMinutes;
			this.dOTMinutes = dOTMinutes;
			this.tOTMinutes = tOTMinutes;
			this.isOT_Applicable = isOT_Applicable;
			this.oTMinutesApproved = oTMinutesApproved;
			this.dOTMinutesApproved = dOTMinutesApproved;
			this.tOTMinutesApproved = tOTMinutesApproved;
			this.lateMinutes = lateMinutes;
			this.lateMinutesApproved = lateMinutesApproved;
			this.noPayMinutes = noPayMinutes;
			this.noPayMinutesApproved = noPayMinutesApproved;
			this.leaveMinutes = leaveMinutes;
			this.gpMinutes = gpMinutes;
			this.isCanceled = isCanceled;
			this.isOverride = isOverride;
			this.approvalStatus = approvalStatus;
			this.userID_Created = userID_Created;
			this.userID_Approvad = userID_Approvad;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Approvad = terminalID_Approvad;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Approvad = date_Approvad;
			this.date_Canceled = date_Canceled;
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
		/// Gets or sets the Attendance_revision_index value.
		/// </summary>
		public int Attendance_revision_index {
			get { return attendance_revision_index; }
			set { attendance_revision_index = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttendenceDate value.
		/// </summary>
		public DateTime AttendenceDate {
			get { return attendenceDate; }
			set { attendenceDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DayType value.
		/// </summary>
		public int DayType {
			get { return dayType; }
			set { dayType = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_ID value.
		/// </summary>
		public string Shift_ID {
			get { return shift_ID; }
			set { shift_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftDay value.
		/// </summary>
		public int ShiftDay {
			get { return shiftDay; }
			set { shiftDay = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftStartTime value.
		/// </summary>
		public DateTime ShiftStartTime {
			get { return shiftStartTime; }
			set { shiftStartTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftEndTime value.
		/// </summary>
		public DateTime ShiftEndTime {
			get { return shiftEndTime; }
			set { shiftEndTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes value.
		/// </summary>
		public int ShiftMinutes {
			get { return shiftMinutes; }
			set { shiftMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutesMin value.
		/// </summary>
		public int ShiftMinutesMin {
			get { return shiftMinutesMin; }
			set { shiftMinutesMin = value; }
		}
		
		/// <summary>
		/// Gets or sets the NextShiftMinutes value.
		/// </summary>
		public int NextShiftMinutes {
			get { return nextShiftMinutes; }
			set { nextShiftMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftGracePeriod value.
		/// </summary>
		public int ShiftGracePeriod {
			get { return shiftGracePeriod; }
			set { shiftGracePeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the TimeIn_ID value.
		/// </summary>
		public int TimeIn_ID {
			get { return timeIn_ID; }
			set { timeIn_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TimeIn_DateTime value.
		/// </summary>
		public DateTime TimeIn_DateTime {
			get { return timeIn_DateTime; }
			set { timeIn_DateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the TimeOut_ID value.
		/// </summary>
		public int TimeOut_ID {
			get { return timeOut_ID; }
			set { timeOut_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TimeOut_DateTime value.
		/// </summary>
		public DateTime TimeOut_DateTime {
			get { return timeOut_DateTime; }
			set { timeOut_DateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalMinutes value.
		/// </summary>
		public int TotalMinutes {
			get { return totalMinutes; }
			set { totalMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkedMinutes value.
		/// </summary>
		public int WorkedMinutes {
			get { return workedMinutes; }
			set { workedMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the OTRate value.
		/// </summary>
		public decimal OTRate {
			get { return oTRate; }
			set { oTRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DOTRate value.
		/// </summary>
		public decimal DOTRate {
			get { return dOTRate; }
			set { dOTRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the TOTRate value.
		/// </summary>
		public decimal TOTRate {
			get { return tOTRate; }
			set { tOTRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the OTMinutes value.
		/// </summary>
		public int OTMinutes {
			get { return oTMinutes; }
			set { oTMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the DOTMinutes value.
		/// </summary>
		public int DOTMinutes {
			get { return dOTMinutes; }
			set { dOTMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the TOTMinutes value.
		/// </summary>
		public int TOTMinutes {
			get { return tOTMinutes; }
			set { tOTMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOT_Applicable value.
		/// </summary>
		public bool IsOT_Applicable {
			get { return isOT_Applicable; }
			set { isOT_Applicable = value; }
		}
		
		/// <summary>
		/// Gets or sets the OTMinutesApproved value.
		/// </summary>
		public int OTMinutesApproved {
			get { return oTMinutesApproved; }
			set { oTMinutesApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the DOTMinutesApproved value.
		/// </summary>
		public int DOTMinutesApproved {
			get { return dOTMinutesApproved; }
			set { dOTMinutesApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the TOTMinutesApproved value.
		/// </summary>
		public int TOTMinutesApproved {
			get { return tOTMinutesApproved; }
			set { tOTMinutesApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the LateMinutes value.
		/// </summary>
		public int LateMinutes {
			get { return lateMinutes; }
			set { lateMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the LateMinutesApproved value.
		/// </summary>
		public int LateMinutesApproved {
			get { return lateMinutesApproved; }
			set { lateMinutesApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoPayMinutes value.
		/// </summary>
		public int NoPayMinutes {
			get { return noPayMinutes; }
			set { noPayMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoPayMinutesApproved value.
		/// </summary>
		public int NoPayMinutesApproved {
			get { return noPayMinutesApproved; }
			set { noPayMinutesApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the LeaveMinutes value.
		/// </summary>
		public int LeaveMinutes {
			get { return leaveMinutes; }
			set { leaveMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the GpMinutes value.
		/// </summary>
		public int GpMinutes {
			get { return gpMinutes; }
			set { gpMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOverride value.
		/// </summary>
		public bool IsOverride {
			get { return isOverride; }
			set { isOverride = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovalStatus value.
		/// </summary>
		public int ApprovalStatus {
			get { return approvalStatus; }
			set { approvalStatus = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Approvad value.
		/// </summary>
		public string UserID_Approvad {
			get { return userID_Approvad; }
			set { userID_Approvad = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Canceled value.
		/// </summary>
		public string UserID_Canceled {
			get { return userID_Canceled; }
			set { userID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Approvad value.
		/// </summary>
		public string TerminalID_Approvad {
			get { return terminalID_Approvad; }
			set { terminalID_Approvad = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Canceled value.
		/// </summary>
		public string TerminalID_Canceled {
			get { return terminalID_Canceled; }
			set { terminalID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Approvad value.
		/// </summary>
		public DateTime Date_Approvad {
			get { return date_Approvad; }
			set { date_Approvad = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Canceled value.
		/// </summary>
		public DateTime Date_Canceled {
			get { return date_Canceled; }
			set { date_Canceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasTxDailyAttendance_revision table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxDailyAttendance_revisionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendenceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shiftDay", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftStartTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftEndTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftGracePeriod", SqlDbType.Int,4);
			scom.Parameters.Add("@timeIn_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@timeIn_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@timeOut_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@timeOut_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@totalMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@workedMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@oTRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dOTRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tOTRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@oTMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@dOTMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@tOTMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@isOT_Applicable", SqlDbType.Bit,1);
			scom.Parameters.Add("@oTMinutesApproved", SqlDbType.Int,4);
			scom.Parameters.Add("@dOTMinutesApproved", SqlDbType.Int,4);
			scom.Parameters.Add("@tOTMinutesApproved", SqlDbType.Int,4);
			scom.Parameters.Add("@lateMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@lateMinutesApproved", SqlDbType.Int,4);
			scom.Parameters.Add("@noPayMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@noPayMinutesApproved", SqlDbType.Int,4);
			scom.Parameters.Add("@leaveMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@gpMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOverride", SqlDbType.Bit,1);
			scom.Parameters.Add("@approvalStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Approvad", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Approvad", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Approvad", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attendenceDate"].Value = attendenceDate;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@dayType"].Value = dayType;
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@shiftDay"].Value = shiftDay;
			scom.Parameters["@shiftStartTime"].Value = shiftStartTime;
			scom.Parameters["@shiftEndTime"].Value = shiftEndTime;
			scom.Parameters["@shiftMinutes"].Value = shiftMinutes;
			scom.Parameters["@shiftMinutesMin"].Value = shiftMinutesMin;
			scom.Parameters["@nextShiftMinutes"].Value = nextShiftMinutes;
			scom.Parameters["@shiftGracePeriod"].Value = shiftGracePeriod;
			scom.Parameters["@timeIn_ID"].Value = timeIn_ID;
			scom.Parameters["@timeIn_DateTime"].Value = timeIn_DateTime;
			scom.Parameters["@timeOut_ID"].Value = timeOut_ID;
			scom.Parameters["@timeOut_DateTime"].Value = timeOut_DateTime;
			scom.Parameters["@totalMinutes"].Value = totalMinutes;
			scom.Parameters["@workedMinutes"].Value = workedMinutes;
			scom.Parameters["@oTRate"].Value = oTRate;
			scom.Parameters["@dOTRate"].Value = dOTRate;
			scom.Parameters["@tOTRate"].Value = tOTRate;
			scom.Parameters["@oTMinutes"].Value = oTMinutes;
			scom.Parameters["@dOTMinutes"].Value = dOTMinutes;
			scom.Parameters["@tOTMinutes"].Value = tOTMinutes;
			scom.Parameters["@isOT_Applicable"].Value = isOT_Applicable;
			scom.Parameters["@oTMinutesApproved"].Value = oTMinutesApproved;
			scom.Parameters["@dOTMinutesApproved"].Value = dOTMinutesApproved;
			scom.Parameters["@tOTMinutesApproved"].Value = tOTMinutesApproved;
			scom.Parameters["@lateMinutes"].Value = lateMinutes;
			scom.Parameters["@lateMinutesApproved"].Value = lateMinutesApproved;
			scom.Parameters["@noPayMinutes"].Value = noPayMinutes;
			scom.Parameters["@noPayMinutesApproved"].Value = noPayMinutesApproved;
			scom.Parameters["@leaveMinutes"].Value = leaveMinutes;
			scom.Parameters["@gpMinutes"].Value = gpMinutes;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@isOverride"].Value = isOverride;
			scom.Parameters["@approvalStatus"].Value = approvalStatus;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Approvad"].Value = userID_Approvad;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Approvad"].Value = terminalID_Approvad;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Approvad"].Value = date_Approvad;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasTxDailyAttendance_revision table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxDailyAttendance_revisionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
            scom.Parameters.Add("@attendance_revision_index", SqlDbType.Int, 8);
            scom.Parameters.Add("@attendenceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shiftDay", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftStartTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftEndTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftGracePeriod", SqlDbType.Int,4);
			scom.Parameters.Add("@timeIn_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@timeIn_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@timeOut_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@timeOut_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@totalMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@workedMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@oTRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@dOTRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tOTRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@oTMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@dOTMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@tOTMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@isOT_Applicable", SqlDbType.Bit,1);
			scom.Parameters.Add("@oTMinutesApproved", SqlDbType.Int,4);
			scom.Parameters.Add("@dOTMinutesApproved", SqlDbType.Int,4);
			scom.Parameters.Add("@tOTMinutesApproved", SqlDbType.Int,4);
			scom.Parameters.Add("@lateMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@lateMinutesApproved", SqlDbType.Int,4);
			scom.Parameters.Add("@noPayMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@noPayMinutesApproved", SqlDbType.Int,4);
			scom.Parameters.Add("@leaveMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@gpMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOverride", SqlDbType.Bit,1);
			scom.Parameters.Add("@approvalStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Approvad", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Approvad", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Approvad", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            scom.Parameters["@attendance_revision_index"].Value = attendance_revision_index;
            scom.Parameters["@attendenceDate"].Value = attendenceDate;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@dayType"].Value = dayType;
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@shiftDay"].Value = shiftDay;
			scom.Parameters["@shiftStartTime"].Value = shiftStartTime;
			scom.Parameters["@shiftEndTime"].Value = shiftEndTime;
			scom.Parameters["@shiftMinutes"].Value = shiftMinutes;
			scom.Parameters["@shiftMinutesMin"].Value = shiftMinutesMin;
			scom.Parameters["@nextShiftMinutes"].Value = nextShiftMinutes;
			scom.Parameters["@shiftGracePeriod"].Value = shiftGracePeriod;
			scom.Parameters["@timeIn_ID"].Value = timeIn_ID;
			scom.Parameters["@timeIn_DateTime"].Value = timeIn_DateTime;
			scom.Parameters["@timeOut_ID"].Value = timeOut_ID;
			scom.Parameters["@timeOut_DateTime"].Value = timeOut_DateTime;
			scom.Parameters["@totalMinutes"].Value = totalMinutes;
			scom.Parameters["@workedMinutes"].Value = workedMinutes;
			scom.Parameters["@oTRate"].Value = oTRate;
			scom.Parameters["@dOTRate"].Value = dOTRate;
			scom.Parameters["@tOTRate"].Value = tOTRate;
			scom.Parameters["@oTMinutes"].Value = oTMinutes;
			scom.Parameters["@dOTMinutes"].Value = dOTMinutes;
			scom.Parameters["@tOTMinutes"].Value = tOTMinutes;
			scom.Parameters["@isOT_Applicable"].Value = isOT_Applicable;
			scom.Parameters["@oTMinutesApproved"].Value = oTMinutesApproved;
			scom.Parameters["@dOTMinutesApproved"].Value = dOTMinutesApproved;
			scom.Parameters["@tOTMinutesApproved"].Value = tOTMinutesApproved;
			scom.Parameters["@lateMinutes"].Value = lateMinutes;
			scom.Parameters["@lateMinutesApproved"].Value = lateMinutesApproved;
			scom.Parameters["@noPayMinutes"].Value = noPayMinutes;
			scom.Parameters["@noPayMinutesApproved"].Value = noPayMinutesApproved;
			scom.Parameters["@leaveMinutes"].Value = leaveMinutes;
			scom.Parameters["@gpMinutes"].Value = gpMinutes;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@isOverride"].Value = isOverride;
			scom.Parameters["@approvalStatus"].Value = approvalStatus;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Approvad"].Value = userID_Approvad;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Approvad"].Value = terminalID_Approvad;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Approvad"].Value = date_Approvad;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasTxDailyAttendance_revision table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxDailyAttendance_revisionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_revision_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@attendance_revision_index"].Value = attendance_revision_index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasTxDailyAttendance_revision table.
		/// </summary>
		public static tbl_tasTxDailyAttendance_revision Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int attendance_revision_index_Incoming){

			tbl_tasTxDailyAttendance_revision tbl_tasTxDailyAttendance_revisionins = new tbl_tasTxDailyAttendance_revision();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxDailyAttendance_revisionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_revision_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@attendance_revision_index"].Value = attendance_revision_index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasTxDailyAttendance_revisionins = Maketbl_tasTxDailyAttendance_revision(dataReader);
				} else {
					tbl_tasTxDailyAttendance_revisionins = null;
				}
			}
			scon.Close();
			return tbl_tasTxDailyAttendance_revisionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxDailyAttendance_revision table.
		/// </summary>
		public static List<tbl_tasTxDailyAttendance_revision> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxDailyAttendance_revisionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasTxDailyAttendance_revision> tbl_tasTxDailyAttendance_revisionList = new List<tbl_tasTxDailyAttendance_revision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxDailyAttendance_revision tbl_tasTxDailyAttendance_revision = Maketbl_tasTxDailyAttendance_revision(dataReader);
					tbl_tasTxDailyAttendance_revisionList.Add(tbl_tasTxDailyAttendance_revision);
				}
			}
			scon.Close();
			return tbl_tasTxDailyAttendance_revisionList;
		}
        public static List<tbl_tasTxDailyAttendance_revision> SelectAll_Advanced(DateTime attendenceDate_Incoming, string employee_ID_Incoming)
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasTxDailyAttendance_revisionSelectAll_Advanced", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@attendenceDate", SqlDbType.DateTime);
            scom.Parameters["@attendenceDate"].Value = attendenceDate_Incoming;
            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
            List<tbl_tasTxDailyAttendance_revision> tbl_tasTxDailyAttendance_revisionList = new List<tbl_tasTxDailyAttendance_revision>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_tasTxDailyAttendance_revision tbl_tasTxDailyAttendance_revision = Maketbl_tasTxDailyAttendance_revision(dataReader);
                    tbl_tasTxDailyAttendance_revisionList.Add(tbl_tasTxDailyAttendance_revision);
                }
            }
            scon.Close();
            return tbl_tasTxDailyAttendance_revisionList;
        }
        /// <summary>
        /// Creates a new instance of the tbl_tasTxDailyAttendance_revision class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_tasTxDailyAttendance_revision Maketbl_tasTxDailyAttendance_revision(SqlDataReader dataReader) {
			tbl_tasTxDailyAttendance_revision tbl_tasTxDailyAttendance_revision = new tbl_tasTxDailyAttendance_revision();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasTxDailyAttendance_revision.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasTxDailyAttendance_revision.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasTxDailyAttendance_revision.Attendance_revision_index = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasTxDailyAttendance_revision.AttendenceDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasTxDailyAttendance_revision.Employee_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasTxDailyAttendance_revision.Department_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasTxDailyAttendance_revision.DayType = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasTxDailyAttendance_revision.Shift_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasTxDailyAttendance_revision.ShiftDay = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasTxDailyAttendance_revision.ShiftStartTime = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasTxDailyAttendance_revision.ShiftEndTime = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasTxDailyAttendance_revision.ShiftMinutes = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasTxDailyAttendance_revision.ShiftMinutesMin = dataReader.GetInt32(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasTxDailyAttendance_revision.NextShiftMinutes = dataReader.GetInt32(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasTxDailyAttendance_revision.ShiftGracePeriod = dataReader.GetInt32(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_tasTxDailyAttendance_revision.TimeIn_ID = dataReader.GetInt32(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_tasTxDailyAttendance_revision.TimeIn_DateTime = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_tasTxDailyAttendance_revision.TimeOut_ID = dataReader.GetInt32(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_tasTxDailyAttendance_revision.TimeOut_DateTime = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_tasTxDailyAttendance_revision.TotalMinutes = dataReader.GetInt32(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_tasTxDailyAttendance_revision.WorkedMinutes = dataReader.GetInt32(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_tasTxDailyAttendance_revision.OTRate = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_tasTxDailyAttendance_revision.DOTRate = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_tasTxDailyAttendance_revision.TOTRate = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_tasTxDailyAttendance_revision.OTMinutes = dataReader.GetInt32(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_tasTxDailyAttendance_revision.DOTMinutes = dataReader.GetInt32(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_tasTxDailyAttendance_revision.TOTMinutes = dataReader.GetInt32(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_tasTxDailyAttendance_revision.IsOT_Applicable = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_tasTxDailyAttendance_revision.OTMinutesApproved = dataReader.GetInt32(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_tasTxDailyAttendance_revision.DOTMinutesApproved = dataReader.GetInt32(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_tasTxDailyAttendance_revision.TOTMinutesApproved = dataReader.GetInt32(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_tasTxDailyAttendance_revision.LateMinutes = dataReader.GetInt32(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_tasTxDailyAttendance_revision.LateMinutesApproved = dataReader.GetInt32(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_tasTxDailyAttendance_revision.NoPayMinutes = dataReader.GetInt32(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_tasTxDailyAttendance_revision.NoPayMinutesApproved = dataReader.GetInt32(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_tasTxDailyAttendance_revision.LeaveMinutes = dataReader.GetInt32(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_tasTxDailyAttendance_revision.GpMinutes = dataReader.GetInt32(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_tasTxDailyAttendance_revision.IsCanceled = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_tasTxDailyAttendance_revision.IsOverride = dataReader.GetBoolean(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_tasTxDailyAttendance_revision.ApprovalStatus = dataReader.GetInt32(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_tasTxDailyAttendance_revision.UserID_Created = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_tasTxDailyAttendance_revision.UserID_Approvad = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_tasTxDailyAttendance_revision.UserID_Canceled = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_tasTxDailyAttendance_revision.TerminalID_Created = dataReader.GetString(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_tasTxDailyAttendance_revision.TerminalID_Approvad = dataReader.GetString(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_tasTxDailyAttendance_revision.TerminalID_Canceled = dataReader.GetString(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_tasTxDailyAttendance_revision.Date_Created = dataReader.GetDateTime(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_tasTxDailyAttendance_revision.Date_Approvad = dataReader.GetDateTime(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_tasTxDailyAttendance_revision.Date_Canceled = dataReader.GetDateTime(48);
			}

			return tbl_tasTxDailyAttendance_revision;
		}
		/// <summary>
		/// This makes tbl_tasTxDailyAttendance_revision datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasTxDailyAttendance_revision object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasTxDailyAttendance_revision  tbl_tasTxDailyAttendance_revision   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_attendance_revision_index = new DataColumn("attendance_revision_index" , typeof(int));
			DataColumn col_attendenceDate = new DataColumn("attendenceDate" , typeof(DateTime));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_dayType = new DataColumn("dayType" , typeof(int));
			DataColumn col_shift_ID = new DataColumn("shift_ID" , typeof(string));
			DataColumn col_shiftDay = new DataColumn("shiftDay" , typeof(int));
			DataColumn col_shiftStartTime = new DataColumn("shiftStartTime" , typeof(DateTime));
			DataColumn col_shiftEndTime = new DataColumn("shiftEndTime" , typeof(DateTime));
			DataColumn col_shiftMinutes = new DataColumn("shiftMinutes" , typeof(int));
			DataColumn col_shiftMinutesMin = new DataColumn("shiftMinutesMin" , typeof(int));
			DataColumn col_nextShiftMinutes = new DataColumn("nextShiftMinutes" , typeof(int));
			DataColumn col_shiftGracePeriod = new DataColumn("shiftGracePeriod" , typeof(int));
			DataColumn col_timeIn_ID = new DataColumn("timeIn_ID" , typeof(int));
			DataColumn col_timeIn_DateTime = new DataColumn("timeIn_DateTime" , typeof(DateTime));
			DataColumn col_timeOut_ID = new DataColumn("timeOut_ID" , typeof(int));
			DataColumn col_timeOut_DateTime = new DataColumn("timeOut_DateTime" , typeof(DateTime));
			DataColumn col_totalMinutes = new DataColumn("totalMinutes" , typeof(int));
			DataColumn col_workedMinutes = new DataColumn("workedMinutes" , typeof(int));
			DataColumn col_oTRate = new DataColumn("oTRate" , typeof(decimal));
			DataColumn col_dOTRate = new DataColumn("dOTRate" , typeof(decimal));
			DataColumn col_tOTRate = new DataColumn("tOTRate" , typeof(decimal));
			DataColumn col_oTMinutes = new DataColumn("oTMinutes" , typeof(int));
			DataColumn col_dOTMinutes = new DataColumn("dOTMinutes" , typeof(int));
			DataColumn col_tOTMinutes = new DataColumn("tOTMinutes" , typeof(int));
			DataColumn col_isOT_Applicable = new DataColumn("isOT_Applicable" , typeof(bool));
			DataColumn col_oTMinutesApproved = new DataColumn("oTMinutesApproved" , typeof(int));
			DataColumn col_dOTMinutesApproved = new DataColumn("dOTMinutesApproved" , typeof(int));
			DataColumn col_tOTMinutesApproved = new DataColumn("tOTMinutesApproved" , typeof(int));
			DataColumn col_lateMinutes = new DataColumn("lateMinutes" , typeof(int));
			DataColumn col_lateMinutesApproved = new DataColumn("lateMinutesApproved" , typeof(int));
			DataColumn col_noPayMinutes = new DataColumn("noPayMinutes" , typeof(int));
			DataColumn col_noPayMinutesApproved = new DataColumn("noPayMinutesApproved" , typeof(int));
			DataColumn col_leaveMinutes = new DataColumn("leaveMinutes" , typeof(int));
			DataColumn col_gpMinutes = new DataColumn("gpMinutes" , typeof(int));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_isOverride = new DataColumn("isOverride" , typeof(bool));
			DataColumn col_approvalStatus = new DataColumn("approvalStatus" , typeof(int));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Approvad = new DataColumn("userID_Approvad" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Approvad = new DataColumn("terminalID_Approvad" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Approvad = new DataColumn("date_Approvad" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_attendance_revision_index,col_attendenceDate,col_employee_ID,col_department_ID,col_dayType,col_shift_ID,col_shiftDay,col_shiftStartTime,col_shiftEndTime,col_shiftMinutes,col_shiftMinutesMin,col_nextShiftMinutes,col_shiftGracePeriod,col_timeIn_ID,col_timeIn_DateTime,col_timeOut_ID,col_timeOut_DateTime,col_totalMinutes,col_workedMinutes,col_oTRate,col_dOTRate,col_tOTRate,col_oTMinutes,col_dOTMinutes,col_tOTMinutes,col_isOT_Applicable,col_oTMinutesApproved,col_dOTMinutesApproved,col_tOTMinutesApproved,col_lateMinutes,col_lateMinutesApproved,col_noPayMinutes,col_noPayMinutesApproved,col_leaveMinutes,col_gpMinutes,col_isCanceled,col_isOverride,col_approvalStatus,col_userID_Created,col_userID_Approvad,col_userID_Canceled,col_terminalID_Created,col_terminalID_Approvad,col_terminalID_Canceled,col_date_Created,col_date_Approvad,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasTxDailyAttendance_revision datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasTxDailyAttendance_revision object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasTxDailyAttendance_revision user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["attendance_revision_index"] = user.attendance_revision_index;
			drow["attendenceDate"] = user.attendenceDate;
			drow["employee_ID"] = user.employee_ID;
			drow["department_ID"] = user.department_ID;
			drow["dayType"] = user.dayType;
			drow["shift_ID"] = user.shift_ID;
			drow["shiftDay"] = user.shiftDay;
			drow["shiftStartTime"] = user.shiftStartTime;
			drow["shiftEndTime"] = user.shiftEndTime;
			drow["shiftMinutes"] = user.shiftMinutes;
			drow["shiftMinutesMin"] = user.shiftMinutesMin;
			drow["nextShiftMinutes"] = user.nextShiftMinutes;
			drow["shiftGracePeriod"] = user.shiftGracePeriod;
			drow["timeIn_ID"] = user.timeIn_ID;
			drow["timeIn_DateTime"] = user.timeIn_DateTime;
			drow["timeOut_ID"] = user.timeOut_ID;
			drow["timeOut_DateTime"] = user.timeOut_DateTime;
			drow["totalMinutes"] = user.totalMinutes;
			drow["workedMinutes"] = user.workedMinutes;
			drow["oTRate"] = user.oTRate;
			drow["dOTRate"] = user.dOTRate;
			drow["tOTRate"] = user.tOTRate;
			drow["oTMinutes"] = user.oTMinutes;
			drow["dOTMinutes"] = user.dOTMinutes;
			drow["tOTMinutes"] = user.tOTMinutes;
			drow["isOT_Applicable"] = user.isOT_Applicable;
			drow["oTMinutesApproved"] = user.oTMinutesApproved;
			drow["dOTMinutesApproved"] = user.dOTMinutesApproved;
			drow["tOTMinutesApproved"] = user.tOTMinutesApproved;
			drow["lateMinutes"] = user.lateMinutes;
			drow["lateMinutesApproved"] = user.lateMinutesApproved;
			drow["noPayMinutes"] = user.noPayMinutes;
			drow["noPayMinutesApproved"] = user.noPayMinutesApproved;
			drow["leaveMinutes"] = user.leaveMinutes;
			drow["gpMinutes"] = user.gpMinutes;
			drow["isCanceled"] = user.isCanceled;
			drow["isOverride"] = user.isOverride;
			drow["approvalStatus"] = user.approvalStatus;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Approvad"] = user.userID_Approvad;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Approvad"] = user.terminalID_Approvad;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Approvad"] = user.date_Approvad;
			drow["date_Canceled"] = user.date_Canceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
