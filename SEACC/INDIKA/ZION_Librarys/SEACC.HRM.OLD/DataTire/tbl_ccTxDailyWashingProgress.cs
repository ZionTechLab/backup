using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ccTxDailyWashingProgress {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int attendance_index;
		private DateTime attendenceDate;
		private int year_ID;
		private int week_ID;
		private string employee_ID;
		private string department_ID;
		private int dayType;
		private string shift_ID;
		private int shiftDay;
		private DateTime shiftStartTime;
		private DateTime shiftEndTime;
		private int timeIn_ID;
		private DateTime timeIn_DateTime;
		private int timeOut_ID;
		private DateTime timeOut_DateTime;
		private int attendanceStatus;
		private bool isCoconutWashed;
		private decimal washing_Allo;
		private decimal attendance_Allo;
		private decimal budgetary_Allo;
		private decimal other_Allo;
		private decimal qty_Total;
		private decimal employee_Count_Total;
		private decimal rate;
		private decimal earn_Total;
		private bool isLocked;
		private bool isCanceled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxDailyWashingProgress class.
		/// </summary>
		public tbl_ccTxDailyWashingProgress() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxDailyWashingProgress class.
		/// </summary>
		public tbl_ccTxDailyWashingProgress(string company_ID, string companyBranch_ID, int attendance_index, DateTime attendenceDate, int year_ID, int week_ID, string employee_ID, string department_ID, int dayType, string shift_ID, int shiftDay, DateTime shiftStartTime, DateTime shiftEndTime, int timeIn_ID, DateTime timeIn_DateTime, int timeOut_ID, DateTime timeOut_DateTime, int attendanceStatus, bool isCoconutWashed, decimal washing_Allo, decimal attendance_Allo, decimal budgetary_Allo, decimal other_Allo, decimal qty_Total, decimal employee_Count_Total, decimal rate, decimal earn_Total, bool isLocked, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.attendance_index = attendance_index;
			this.attendenceDate = attendenceDate;
			this.year_ID = year_ID;
			this.week_ID = week_ID;
			this.employee_ID = employee_ID;
			this.department_ID = department_ID;
			this.dayType = dayType;
			this.shift_ID = shift_ID;
			this.shiftDay = shiftDay;
			this.shiftStartTime = shiftStartTime;
			this.shiftEndTime = shiftEndTime;
			this.timeIn_ID = timeIn_ID;
			this.timeIn_DateTime = timeIn_DateTime;
			this.timeOut_ID = timeOut_ID;
			this.timeOut_DateTime = timeOut_DateTime;
			this.attendanceStatus = attendanceStatus;
			this.isCoconutWashed = isCoconutWashed;
			this.washing_Allo = washing_Allo;
			this.attendance_Allo = attendance_Allo;
			this.budgetary_Allo = budgetary_Allo;
			this.other_Allo = other_Allo;
			this.qty_Total = qty_Total;
			this.employee_Count_Total = employee_Count_Total;
			this.rate = rate;
			this.earn_Total = earn_Total;
			this.isLocked = isLocked;
			this.isCanceled = isCanceled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
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
		/// Gets or sets the Attendance_index value.
		/// </summary>
		public int Attendance_index {
			get { return attendance_index; }
			set { attendance_index = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttendenceDate value.
		/// </summary>
		public DateTime AttendenceDate {
			get { return attendenceDate; }
			set { attendenceDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Year_ID value.
		/// </summary>
		public int Year_ID {
			get { return year_ID; }
			set { year_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Week_ID value.
		/// </summary>
		public int Week_ID {
			get { return week_ID; }
			set { week_ID = value; }
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
		/// Gets or sets the AttendanceStatus value.
		/// </summary>
		public int AttendanceStatus {
			get { return attendanceStatus; }
			set { attendanceStatus = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCoconutWashed value.
		/// </summary>
		public bool IsCoconutWashed {
			get { return isCoconutWashed; }
			set { isCoconutWashed = value; }
		}
		
		/// <summary>
		/// Gets or sets the Washing_Allo value.
		/// </summary>
		public decimal Washing_Allo {
			get { return washing_Allo; }
			set { washing_Allo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Attendance_Allo value.
		/// </summary>
		public decimal Attendance_Allo {
			get { return attendance_Allo; }
			set { attendance_Allo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Budgetary_Allo value.
		/// </summary>
		public decimal Budgetary_Allo {
			get { return budgetary_Allo; }
			set { budgetary_Allo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Other_Allo value.
		/// </summary>
		public decimal Other_Allo {
			get { return other_Allo; }
			set { other_Allo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Total value.
		/// </summary>
		public decimal Qty_Total {
			get { return qty_Total; }
			set { qty_Total = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_Count_Total value.
		/// </summary>
		public decimal Employee_Count_Total {
			get { return employee_Count_Total; }
			set { employee_Count_Total = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rate value.
		/// </summary>
		public decimal Rate {
			get { return rate; }
			set { rate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Earn_Total value.
		/// </summary>
		public decimal Earn_Total {
			get { return earn_Total; }
			set { earn_Total = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Modified value.
		/// </summary>
		public string UserID_Modified {
			get { return userID_Modified; }
			set { userID_Modified = value; }
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
		/// Gets or sets the TerminalID_Modified value.
		/// </summary>
		public string TerminalID_Modified {
			get { return terminalID_Modified; }
			set { terminalID_Modified = value; }
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
		/// Gets or sets the Date_Modified value.
		/// </summary>
		public DateTime Date_Modified {
			get { return date_Modified; }
			set { date_Modified = value; }
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
		/// Saves a record to the tbl_ccTxDailyWashingProgress table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters.Add("@attendenceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shiftDay", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftStartTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftEndTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@timeIn_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@timeIn_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@timeOut_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@timeOut_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@attendanceStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@isCoconutWashed", SqlDbType.Bit,1);
			scom.Parameters.Add("@washing_Allo", SqlDbType.Decimal,9);
			scom.Parameters.Add("@attendance_Allo", SqlDbType.Decimal,9);
			scom.Parameters.Add("@budgetary_Allo", SqlDbType.Decimal,9);
			scom.Parameters.Add("@other_Allo", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Total", SqlDbType.Decimal,9);
			scom.Parameters.Add("@employee_Count_Total", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@earn_Total", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attendance_index"].Value = attendance_index;
			scom.Parameters["@attendenceDate"].Value = attendenceDate;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@dayType"].Value = dayType;
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@shiftDay"].Value = shiftDay;
			scom.Parameters["@shiftStartTime"].Value = shiftStartTime;
			scom.Parameters["@shiftEndTime"].Value = shiftEndTime;
			scom.Parameters["@timeIn_ID"].Value = timeIn_ID;
			scom.Parameters["@timeIn_DateTime"].Value = timeIn_DateTime;
			scom.Parameters["@timeOut_ID"].Value = timeOut_ID;
			scom.Parameters["@timeOut_DateTime"].Value = timeOut_DateTime;
			scom.Parameters["@attendanceStatus"].Value = attendanceStatus;
			scom.Parameters["@isCoconutWashed"].Value = isCoconutWashed;
			scom.Parameters["@washing_Allo"].Value = washing_Allo;
			scom.Parameters["@attendance_Allo"].Value = attendance_Allo;
			scom.Parameters["@budgetary_Allo"].Value = budgetary_Allo;
			scom.Parameters["@other_Allo"].Value = other_Allo;
			scom.Parameters["@qty_Total"].Value = qty_Total;
			scom.Parameters["@employee_Count_Total"].Value = employee_Count_Total;
			scom.Parameters["@rate"].Value = rate;
			scom.Parameters["@earn_Total"].Value = earn_Total;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ccTxDailyWashingProgress table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters.Add("@attendenceDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shiftDay", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftStartTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftEndTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@timeIn_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@timeIn_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@timeOut_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@timeOut_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@attendanceStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@isCoconutWashed", SqlDbType.Bit,1);
			scom.Parameters.Add("@washing_Allo", SqlDbType.Decimal,9);
			scom.Parameters.Add("@attendance_Allo", SqlDbType.Decimal,9);
			scom.Parameters.Add("@budgetary_Allo", SqlDbType.Decimal,9);
			scom.Parameters.Add("@other_Allo", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Total", SqlDbType.Decimal,9);
			scom.Parameters.Add("@employee_Count_Total", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@earn_Total", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attendance_index"].Value = attendance_index;
			scom.Parameters["@attendenceDate"].Value = attendenceDate;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@dayType"].Value = dayType;
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@shiftDay"].Value = shiftDay;
			scom.Parameters["@shiftStartTime"].Value = shiftStartTime;
			scom.Parameters["@shiftEndTime"].Value = shiftEndTime;
			scom.Parameters["@timeIn_ID"].Value = timeIn_ID;
			scom.Parameters["@timeIn_DateTime"].Value = timeIn_DateTime;
			scom.Parameters["@timeOut_ID"].Value = timeOut_ID;
			scom.Parameters["@timeOut_DateTime"].Value = timeOut_DateTime;
			scom.Parameters["@attendanceStatus"].Value = attendanceStatus;
			scom.Parameters["@isCoconutWashed"].Value = isCoconutWashed;
			scom.Parameters["@washing_Allo"].Value = washing_Allo;
			scom.Parameters["@attendance_Allo"].Value = attendance_Allo;
			scom.Parameters["@budgetary_Allo"].Value = budgetary_Allo;
			scom.Parameters["@other_Allo"].Value = other_Allo;
			scom.Parameters["@qty_Total"].Value = qty_Total;
			scom.Parameters["@employee_Count_Total"].Value = employee_Count_Total;
			scom.Parameters["@rate"].Value = rate;
			scom.Parameters["@earn_Total"].Value = earn_Total;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ccTxDailyWashingProgress table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@attendance_index"].Value = attendance_index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWashingProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(string company_ID, string companyBranch_ID, int year_ID, int week_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressDeleteAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWashingProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
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
		/// Selects all records from the tbl_ccTxDailyWashingProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Attendance_index(string company_ID, string companyBranch_ID, int attendance_index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressDeleteAllByCompany_ID_CompanyBranch_ID_Attendance_index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attendance_index"].Value = attendance_index;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ccTxDailyWashingProgress table.
		/// </summary>
		public static tbl_ccTxDailyWashingProgress Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int attendance_index_Incoming){

			tbl_ccTxDailyWashingProgress tbl_ccTxDailyWashingProgressins = new tbl_ccTxDailyWashingProgress();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@attendance_index"].Value = attendance_index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ccTxDailyWashingProgressins = Maketbl_ccTxDailyWashingProgress(dataReader);
				} else {
					tbl_ccTxDailyWashingProgressins = null;
				}
			}
			scon.Close();
			return tbl_ccTxDailyWashingProgressins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWashingProgress table.
		/// </summary>
		public static List<tbl_ccTxDailyWashingProgress> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ccTxDailyWashingProgress> tbl_ccTxDailyWashingProgressList = new List<tbl_ccTxDailyWashingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxDailyWashingProgress tbl_ccTxDailyWashingProgress = Maketbl_ccTxDailyWashingProgress(dataReader);
					tbl_ccTxDailyWashingProgressList.Add(tbl_ccTxDailyWashingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxDailyWashingProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWashingProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxDailyWashingProgress> SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(string company_ID, string companyBranch_ID, int year_ID, int week_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressSelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
				List<tbl_ccTxDailyWashingProgress> tbl_ccTxDailyWashingProgressList = new List<tbl_ccTxDailyWashingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxDailyWashingProgress tbl_ccTxDailyWashingProgress = Maketbl_ccTxDailyWashingProgress(dataReader);
					tbl_ccTxDailyWashingProgressList.Add(tbl_ccTxDailyWashingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxDailyWashingProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWashingProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxDailyWashingProgress> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_ccTxDailyWashingProgress> tbl_ccTxDailyWashingProgressList = new List<tbl_ccTxDailyWashingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxDailyWashingProgress tbl_ccTxDailyWashingProgress = Maketbl_ccTxDailyWashingProgress(dataReader);
					tbl_ccTxDailyWashingProgressList.Add(tbl_ccTxDailyWashingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxDailyWashingProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWashingProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxDailyWashingProgress> SelectAllByCompany_ID_CompanyBranch_ID_Attendance_index(string company_ID, string companyBranch_ID, int attendance_index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWashingProgressSelectAllByCompany_ID_CompanyBranch_ID_Attendance_index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attendance_index"].Value = attendance_index;
				List<tbl_ccTxDailyWashingProgress> tbl_ccTxDailyWashingProgressList = new List<tbl_ccTxDailyWashingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxDailyWashingProgress tbl_ccTxDailyWashingProgress = Maketbl_ccTxDailyWashingProgress(dataReader);
					tbl_ccTxDailyWashingProgressList.Add(tbl_ccTxDailyWashingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxDailyWashingProgressList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ccTxDailyWashingProgress class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ccTxDailyWashingProgress Maketbl_ccTxDailyWashingProgress(SqlDataReader dataReader) {
			tbl_ccTxDailyWashingProgress tbl_ccTxDailyWashingProgress = new tbl_ccTxDailyWashingProgress();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ccTxDailyWashingProgress.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ccTxDailyWashingProgress.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ccTxDailyWashingProgress.Attendance_index = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ccTxDailyWashingProgress.AttendenceDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ccTxDailyWashingProgress.Year_ID = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ccTxDailyWashingProgress.Week_ID = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ccTxDailyWashingProgress.Employee_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ccTxDailyWashingProgress.Department_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ccTxDailyWashingProgress.DayType = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ccTxDailyWashingProgress.Shift_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_ccTxDailyWashingProgress.ShiftDay = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_ccTxDailyWashingProgress.ShiftStartTime = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_ccTxDailyWashingProgress.ShiftEndTime = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_ccTxDailyWashingProgress.TimeIn_ID = dataReader.GetInt32(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_ccTxDailyWashingProgress.TimeIn_DateTime = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_ccTxDailyWashingProgress.TimeOut_ID = dataReader.GetInt32(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_ccTxDailyWashingProgress.TimeOut_DateTime = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_ccTxDailyWashingProgress.AttendanceStatus = dataReader.GetInt32(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_ccTxDailyWashingProgress.IsCoconutWashed = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_ccTxDailyWashingProgress.Washing_Allo = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_ccTxDailyWashingProgress.Attendance_Allo = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_ccTxDailyWashingProgress.Budgetary_Allo = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_ccTxDailyWashingProgress.Other_Allo = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_ccTxDailyWashingProgress.Qty_Total = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_ccTxDailyWashingProgress.Employee_Count_Total = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_ccTxDailyWashingProgress.Rate = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_ccTxDailyWashingProgress.Earn_Total = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_ccTxDailyWashingProgress.IsLocked = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_ccTxDailyWashingProgress.IsCanceled = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_ccTxDailyWashingProgress.UserID_Created = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_ccTxDailyWashingProgress.UserID_Modified = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_ccTxDailyWashingProgress.UserID_Canceled = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_ccTxDailyWashingProgress.TerminalID_Created = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_ccTxDailyWashingProgress.TerminalID_Modified = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_ccTxDailyWashingProgress.TerminalID_Canceled = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_ccTxDailyWashingProgress.Date_Created = dataReader.GetDateTime(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_ccTxDailyWashingProgress.Date_Modified = dataReader.GetDateTime(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_ccTxDailyWashingProgress.Date_Canceled = dataReader.GetDateTime(37);
			}

			return tbl_ccTxDailyWashingProgress;
		}
		/// <summary>
		/// This makes tbl_ccTxDailyWashingProgress datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ccTxDailyWashingProgress object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ccTxDailyWashingProgress  tbl_ccTxDailyWashingProgress   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_attendance_index = new DataColumn("attendance_index" , typeof(int));
			DataColumn col_attendenceDate = new DataColumn("attendenceDate" , typeof(DateTime));
			DataColumn col_year_ID = new DataColumn("year_ID" , typeof(int));
			DataColumn col_week_ID = new DataColumn("week_ID" , typeof(int));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_dayType = new DataColumn("dayType" , typeof(int));
			DataColumn col_shift_ID = new DataColumn("shift_ID" , typeof(string));
			DataColumn col_shiftDay = new DataColumn("shiftDay" , typeof(int));
			DataColumn col_shiftStartTime = new DataColumn("shiftStartTime" , typeof(DateTime));
			DataColumn col_shiftEndTime = new DataColumn("shiftEndTime" , typeof(DateTime));
			DataColumn col_timeIn_ID = new DataColumn("timeIn_ID" , typeof(int));
			DataColumn col_timeIn_DateTime = new DataColumn("timeIn_DateTime" , typeof(DateTime));
			DataColumn col_timeOut_ID = new DataColumn("timeOut_ID" , typeof(int));
			DataColumn col_timeOut_DateTime = new DataColumn("timeOut_DateTime" , typeof(DateTime));
			DataColumn col_attendanceStatus = new DataColumn("attendanceStatus" , typeof(int));
			DataColumn col_isCoconutWashed = new DataColumn("isCoconutWashed" , typeof(bool));
			DataColumn col_washing_Allo = new DataColumn("washing_Allo" , typeof(decimal));
			DataColumn col_attendance_Allo = new DataColumn("attendance_Allo" , typeof(decimal));
			DataColumn col_budgetary_Allo = new DataColumn("budgetary_Allo" , typeof(decimal));
			DataColumn col_other_Allo = new DataColumn("other_Allo" , typeof(decimal));
			DataColumn col_qty_Total = new DataColumn("qty_Total" , typeof(decimal));
			DataColumn col_employee_Count_Total = new DataColumn("employee_Count_Total" , typeof(decimal));
			DataColumn col_rate = new DataColumn("rate" , typeof(decimal));
			DataColumn col_earn_Total = new DataColumn("earn_Total" , typeof(decimal));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_attendance_index,col_attendenceDate,col_year_ID,col_week_ID,col_employee_ID,col_department_ID,col_dayType,col_shift_ID,col_shiftDay,col_shiftStartTime,col_shiftEndTime,col_timeIn_ID,col_timeIn_DateTime,col_timeOut_ID,col_timeOut_DateTime,col_attendanceStatus,col_isCoconutWashed,col_washing_Allo,col_attendance_Allo,col_budgetary_Allo,col_other_Allo,col_qty_Total,col_employee_Count_Total,col_rate,col_earn_Total,col_isLocked,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ccTxDailyWashingProgress datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ccTxDailyWashingProgress object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ccTxDailyWashingProgress user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["attendance_index"] = user.attendance_index;
			drow["attendenceDate"] = user.attendenceDate;
			drow["year_ID"] = user.year_ID;
			drow["week_ID"] = user.week_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["department_ID"] = user.department_ID;
			drow["dayType"] = user.dayType;
			drow["shift_ID"] = user.shift_ID;
			drow["shiftDay"] = user.shiftDay;
			drow["shiftStartTime"] = user.shiftStartTime;
			drow["shiftEndTime"] = user.shiftEndTime;
			drow["timeIn_ID"] = user.timeIn_ID;
			drow["timeIn_DateTime"] = user.timeIn_DateTime;
			drow["timeOut_ID"] = user.timeOut_ID;
			drow["timeOut_DateTime"] = user.timeOut_DateTime;
			drow["attendanceStatus"] = user.attendanceStatus;
			drow["isCoconutWashed"] = user.isCoconutWashed;
			drow["washing_Allo"] = user.washing_Allo;
			drow["attendance_Allo"] = user.attendance_Allo;
			drow["budgetary_Allo"] = user.budgetary_Allo;
			drow["other_Allo"] = user.other_Allo;
			drow["qty_Total"] = user.qty_Total;
			drow["employee_Count_Total"] = user.employee_Count_Total;
			drow["rate"] = user.rate;
			drow["earn_Total"] = user.earn_Total;
			drow["isLocked"] = user.isLocked;
			drow["isCanceled"] = user.isCanceled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
