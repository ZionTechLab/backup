using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ccTxDailyWorkingProgress {
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
		private decimal qty_Grade1;
		private decimal qty_Grade2;
		private decimal qty_Grade1_Night;
		private decimal qty_Grade2_Night;
		private decimal qty_Total;
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
		private int paymentPeriod;
		private decimal amount_Total;
		private decimal amount_Total_Night;
		private decimal amount_Payslip;
		private decimal budgetary_Allowance1;
		private decimal budgetary_Allowance2;
		private decimal budgetary_Allowance3;
		private decimal travel_Allowance;
		private decimal attendace_Allowance;
		private decimal other_Allowance1;
		private decimal other_Deduction1;
		private decimal other_Deduction2;
		private decimal epf_8;
		private decimal epf_12;
		private decimal etf_3;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxDailyWorkingProgress class.
		/// </summary>
		public tbl_ccTxDailyWorkingProgress() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxDailyWorkingProgress class.
		/// </summary>
		public tbl_ccTxDailyWorkingProgress(string company_ID, string companyBranch_ID, DateTime attendenceDate, int year_ID, int week_ID, string employee_ID, string department_ID, int dayType, string shift_ID, int shiftDay, DateTime shiftStartTime, DateTime shiftEndTime, int timeIn_ID, DateTime timeIn_DateTime, int timeOut_ID, DateTime timeOut_DateTime, int attendanceStatus, decimal qty_Grade1, decimal qty_Grade2, decimal qty_Grade1_Night, decimal qty_Grade2_Night, decimal qty_Total, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled, int paymentPeriod, decimal amount_Total, decimal amount_Total_Night, decimal amount_Payslip, decimal budgetary_Allowance1, decimal budgetary_Allowance2, decimal budgetary_Allowance3, decimal travel_Allowance, decimal attendace_Allowance, decimal other_Allowance1, decimal other_Deduction1, decimal other_Deduction2, decimal epf_8, decimal epf_12, decimal etf_3) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
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
			this.qty_Grade1 = qty_Grade1;
			this.qty_Grade2 = qty_Grade2;
			this.qty_Grade1_Night = qty_Grade1_Night;
			this.qty_Grade2_Night = qty_Grade2_Night;
			this.qty_Total = qty_Total;
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
			this.paymentPeriod = paymentPeriod;
			this.amount_Total = amount_Total;
			this.amount_Total_Night = amount_Total_Night;
			this.amount_Payslip = amount_Payslip;
			this.budgetary_Allowance1 = budgetary_Allowance1;
			this.budgetary_Allowance2 = budgetary_Allowance2;
			this.budgetary_Allowance3 = budgetary_Allowance3;
			this.travel_Allowance = travel_Allowance;
			this.attendace_Allowance = attendace_Allowance;
			this.other_Allowance1 = other_Allowance1;
			this.other_Deduction1 = other_Deduction1;
			this.other_Deduction2 = other_Deduction2;
			this.epf_8 = epf_8;
			this.epf_12 = epf_12;
			this.etf_3 = etf_3;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxDailyWorkingProgress class.
		/// </summary>
		public tbl_ccTxDailyWorkingProgress(string company_ID, string companyBranch_ID, int attendance_index, DateTime attendenceDate, int year_ID, int week_ID, string employee_ID, string department_ID, int dayType, string shift_ID, int shiftDay, DateTime shiftStartTime, DateTime shiftEndTime, int timeIn_ID, DateTime timeIn_DateTime, int timeOut_ID, DateTime timeOut_DateTime, int attendanceStatus, decimal qty_Grade1, decimal qty_Grade2, decimal qty_Grade1_Night, decimal qty_Grade2_Night, decimal qty_Total, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled, int paymentPeriod, decimal amount_Total, decimal amount_Total_Night, decimal amount_Payslip, decimal budgetary_Allowance1, decimal budgetary_Allowance2, decimal budgetary_Allowance3, decimal travel_Allowance, decimal attendace_Allowance, decimal other_Allowance1, decimal other_Deduction1, decimal other_Deduction2, decimal epf_8, decimal epf_12, decimal etf_3) {
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
			this.qty_Grade1 = qty_Grade1;
			this.qty_Grade2 = qty_Grade2;
			this.qty_Grade1_Night = qty_Grade1_Night;
			this.qty_Grade2_Night = qty_Grade2_Night;
			this.qty_Total = qty_Total;
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
			this.paymentPeriod = paymentPeriod;
			this.amount_Total = amount_Total;
			this.amount_Total_Night = amount_Total_Night;
			this.amount_Payslip = amount_Payslip;
			this.budgetary_Allowance1 = budgetary_Allowance1;
			this.budgetary_Allowance2 = budgetary_Allowance2;
			this.budgetary_Allowance3 = budgetary_Allowance3;
			this.travel_Allowance = travel_Allowance;
			this.attendace_Allowance = attendace_Allowance;
			this.other_Allowance1 = other_Allowance1;
			this.other_Deduction1 = other_Deduction1;
			this.other_Deduction2 = other_Deduction2;
			this.epf_8 = epf_8;
			this.epf_12 = epf_12;
			this.etf_3 = etf_3;
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
		/// Gets or sets the Qty_Grade1 value.
		/// </summary>
		public decimal Qty_Grade1 {
			get { return qty_Grade1; }
			set { qty_Grade1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Grade2 value.
		/// </summary>
		public decimal Qty_Grade2 {
			get { return qty_Grade2; }
			set { qty_Grade2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Grade1_Night value.
		/// </summary>
		public decimal Qty_Grade1_Night {
			get { return qty_Grade1_Night; }
			set { qty_Grade1_Night = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Grade2_Night value.
		/// </summary>
		public decimal Qty_Grade2_Night {
			get { return qty_Grade2_Night; }
			set { qty_Grade2_Night = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Total value.
		/// </summary>
		public decimal Qty_Total {
			get { return qty_Total; }
			set { qty_Total = value; }
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
		
		/// <summary>
		/// Gets or sets the PaymentPeriod value.
		/// </summary>
		public int PaymentPeriod {
			get { return paymentPeriod; }
			set { paymentPeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount_Total value.
		/// </summary>
		public decimal Amount_Total {
			get { return amount_Total; }
			set { amount_Total = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount_Total_Night value.
		/// </summary>
		public decimal Amount_Total_Night {
			get { return amount_Total_Night; }
			set { amount_Total_Night = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount_Payslip value.
		/// </summary>
		public decimal Amount_Payslip {
			get { return amount_Payslip; }
			set { amount_Payslip = value; }
		}
		
		/// <summary>
		/// Gets or sets the Budgetary_Allowance1 value.
		/// </summary>
		public decimal Budgetary_Allowance1 {
			get { return budgetary_Allowance1; }
			set { budgetary_Allowance1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Budgetary_Allowance2 value.
		/// </summary>
		public decimal Budgetary_Allowance2 {
			get { return budgetary_Allowance2; }
			set { budgetary_Allowance2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Budgetary_Allowance3 value.
		/// </summary>
		public decimal Budgetary_Allowance3 {
			get { return budgetary_Allowance3; }
			set { budgetary_Allowance3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Travel_Allowance value.
		/// </summary>
		public decimal Travel_Allowance {
			get { return travel_Allowance; }
			set { travel_Allowance = value; }
		}
		
		/// <summary>
		/// Gets or sets the Attendace_Allowance value.
		/// </summary>
		public decimal Attendace_Allowance {
			get { return attendace_Allowance; }
			set { attendace_Allowance = value; }
		}
		
		/// <summary>
		/// Gets or sets the Other_Allowance1 value.
		/// </summary>
		public decimal Other_Allowance1 {
			get { return other_Allowance1; }
			set { other_Allowance1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Other_Deduction1 value.
		/// </summary>
		public decimal Other_Deduction1 {
			get { return other_Deduction1; }
			set { other_Deduction1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Other_Deduction2 value.
		/// </summary>
		public decimal Other_Deduction2 {
			get { return other_Deduction2; }
			set { other_Deduction2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Epf_8 value.
		/// </summary>
		public decimal Epf_8 {
			get { return epf_8; }
			set { epf_8 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Epf_12 value.
		/// </summary>
		public decimal Epf_12 {
			get { return epf_12; }
			set { epf_12 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Etf_3 value.
		/// </summary>
		public decimal Etf_3 {
			get { return etf_3; }
			set { etf_3 = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ccTxDailyWorkingProgress table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
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
			scom.Parameters.Add("@qty_Grade1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Grade2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Grade1_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Grade2_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Total", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@paymentPeriod", SqlDbType.Int,4);
			scom.Parameters.Add("@amount_Total", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount_Total_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount_Payslip", SqlDbType.Decimal,9);
			scom.Parameters.Add("@budgetary_Allowance1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@budgetary_Allowance2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@budgetary_Allowance3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@travel_Allowance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@attendace_Allowance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@other_Allowance1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@other_Deduction1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@other_Deduction2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@epf_8", SqlDbType.Decimal,9);
			scom.Parameters.Add("@epf_12", SqlDbType.Decimal,9);
			scom.Parameters.Add("@etf_3", SqlDbType.Decimal,9);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
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
			scom.Parameters["@qty_Grade1"].Value = qty_Grade1;
			scom.Parameters["@qty_Grade2"].Value = qty_Grade2;
			scom.Parameters["@qty_Grade1_Night"].Value = qty_Grade1_Night;
			scom.Parameters["@qty_Grade2_Night"].Value = qty_Grade2_Night;
			scom.Parameters["@qty_Total"].Value = qty_Total;
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
			scom.Parameters["@paymentPeriod"].Value = paymentPeriod;
			scom.Parameters["@amount_Total"].Value = amount_Total;
			scom.Parameters["@amount_Total_Night"].Value = amount_Total_Night;
			scom.Parameters["@amount_Payslip"].Value = amount_Payslip;
			scom.Parameters["@budgetary_Allowance1"].Value = budgetary_Allowance1;
			scom.Parameters["@budgetary_Allowance2"].Value = budgetary_Allowance2;
			scom.Parameters["@budgetary_Allowance3"].Value = budgetary_Allowance3;
			scom.Parameters["@travel_Allowance"].Value = travel_Allowance;
			scom.Parameters["@attendace_Allowance"].Value = attendace_Allowance;
			scom.Parameters["@other_Allowance1"].Value = other_Allowance1;
			scom.Parameters["@other_Deduction1"].Value = other_Deduction1;
			scom.Parameters["@other_Deduction2"].Value = other_Deduction2;
			scom.Parameters["@epf_8"].Value = epf_8;
			scom.Parameters["@epf_12"].Value = epf_12;
			scom.Parameters["@etf_3"].Value = etf_3;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ccTxDailyWorkingProgress table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
            scom.Parameters.Add("@attendance_index", SqlDbType.Int, 4);
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
			scom.Parameters.Add("@qty_Grade1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Grade2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Grade1_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Grade2_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Total", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@paymentPeriod", SqlDbType.Int,4);
			scom.Parameters.Add("@amount_Total", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount_Total_Night", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount_Payslip", SqlDbType.Decimal,9);
			scom.Parameters.Add("@budgetary_Allowance1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@budgetary_Allowance2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@budgetary_Allowance3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@travel_Allowance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@attendace_Allowance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@other_Allowance1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@other_Deduction1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@other_Deduction2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@epf_8", SqlDbType.Decimal,9);
			scom.Parameters.Add("@epf_12", SqlDbType.Decimal,9);
			scom.Parameters.Add("@etf_3", SqlDbType.Decimal,9);
 
 
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
			scom.Parameters["@qty_Grade1"].Value = qty_Grade1;
			scom.Parameters["@qty_Grade2"].Value = qty_Grade2;
			scom.Parameters["@qty_Grade1_Night"].Value = qty_Grade1_Night;
			scom.Parameters["@qty_Grade2_Night"].Value = qty_Grade2_Night;
			scom.Parameters["@qty_Total"].Value = qty_Total;
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
			scom.Parameters["@paymentPeriod"].Value = paymentPeriod;
			scom.Parameters["@amount_Total"].Value = amount_Total;
			scom.Parameters["@amount_Total_Night"].Value = amount_Total_Night;
			scom.Parameters["@amount_Payslip"].Value = amount_Payslip;
			scom.Parameters["@budgetary_Allowance1"].Value = budgetary_Allowance1;
			scom.Parameters["@budgetary_Allowance2"].Value = budgetary_Allowance2;
			scom.Parameters["@budgetary_Allowance3"].Value = budgetary_Allowance3;
			scom.Parameters["@travel_Allowance"].Value = travel_Allowance;
			scom.Parameters["@attendace_Allowance"].Value = attendace_Allowance;
			scom.Parameters["@other_Allowance1"].Value = other_Allowance1;
			scom.Parameters["@other_Deduction1"].Value = other_Deduction1;
			scom.Parameters["@other_Deduction2"].Value = other_Deduction2;
			scom.Parameters["@epf_8"].Value = epf_8;
			scom.Parameters["@epf_12"].Value = epf_12;
			scom.Parameters["@etf_3"].Value = etf_3;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ccTxDailyWorkingProgress table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressDelete", scon);
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
		/// Selects all records from the tbl_ccTxDailyWorkingProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(string company_ID, string companyBranch_ID, int year_ID, int week_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressDeleteAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID", scon);
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
		/// Selects all records from the tbl_ccTxDailyWorkingProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressDeleteAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWorkingProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
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
		/// Selects a single record from the tbl_ccTxDailyWorkingProgress table.
		/// </summary>
		public static tbl_ccTxDailyWorkingProgress Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int attendance_index_Incoming){

			tbl_ccTxDailyWorkingProgress tbl_ccTxDailyWorkingProgressins = new tbl_ccTxDailyWorkingProgress();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressSelect", scon);
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
					tbl_ccTxDailyWorkingProgressins = Maketbl_ccTxDailyWorkingProgress(dataReader);
				} else {
					tbl_ccTxDailyWorkingProgressins = null;
				}
			}
			scon.Close();
			return tbl_ccTxDailyWorkingProgressins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWorkingProgress table.
		/// </summary>
		public static List<tbl_ccTxDailyWorkingProgress> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ccTxDailyWorkingProgress> tbl_ccTxDailyWorkingProgressList = new List<tbl_ccTxDailyWorkingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxDailyWorkingProgress tbl_ccTxDailyWorkingProgress = Maketbl_ccTxDailyWorkingProgress(dataReader);
					tbl_ccTxDailyWorkingProgressList.Add(tbl_ccTxDailyWorkingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxDailyWorkingProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWorkingProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxDailyWorkingProgress> SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(string company_ID, string companyBranch_ID, int year_ID, int week_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressSelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID", scon);
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
				List<tbl_ccTxDailyWorkingProgress> tbl_ccTxDailyWorkingProgressList = new List<tbl_ccTxDailyWorkingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxDailyWorkingProgress tbl_ccTxDailyWorkingProgress = Maketbl_ccTxDailyWorkingProgress(dataReader);
					tbl_ccTxDailyWorkingProgressList.Add(tbl_ccTxDailyWorkingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxDailyWorkingProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWorkingProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxDailyWorkingProgress> SelectAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressSelectAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_ccTxDailyWorkingProgress> tbl_ccTxDailyWorkingProgressList = new List<tbl_ccTxDailyWorkingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxDailyWorkingProgress tbl_ccTxDailyWorkingProgress = Maketbl_ccTxDailyWorkingProgress(dataReader);
					tbl_ccTxDailyWorkingProgressList.Add(tbl_ccTxDailyWorkingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxDailyWorkingProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWorkingProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxDailyWorkingProgress> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_ccTxDailyWorkingProgress> tbl_ccTxDailyWorkingProgressList = new List<tbl_ccTxDailyWorkingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxDailyWorkingProgress tbl_ccTxDailyWorkingProgress = Maketbl_ccTxDailyWorkingProgress(dataReader);
					tbl_ccTxDailyWorkingProgressList.Add(tbl_ccTxDailyWorkingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxDailyWorkingProgressList;
		}
        public static List<tbl_ccTxDailyWorkingProgress> SelectAllBy_DateRange(string company_ID, string companyBranch_ID, string employee_ID, DateTime FromDate, DateTime ToDate)
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgressSelectAllByDateRange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@company_ID", SqlDbType.VarChar, 8);
            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 8);
            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@company_ID"].Value = company_ID;
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            scom.Parameters["@employee_ID"].Value = employee_ID;
            scom.Parameters.Add("@FromDate", SqlDbType.DateTime, 10);
            scom.Parameters["@FromDate"].Value = FromDate;
            scom.Parameters.Add("@ToDate", SqlDbType.DateTime, 10);
            scom.Parameters["@ToDate"].Value = ToDate;

            List<tbl_ccTxDailyWorkingProgress> tbl_ccTxDailyWorkingProgressList = new List<tbl_ccTxDailyWorkingProgress>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_ccTxDailyWorkingProgress tbl_ccTxDailyWorkingProgress = Maketbl_ccTxDailyWorkingProgress(dataReader);
                    tbl_ccTxDailyWorkingProgressList.Add(tbl_ccTxDailyWorkingProgress);
                }
            }
            scon.Close();
            return tbl_ccTxDailyWorkingProgressList;

        }

        /// <summary>
        /// Creates a new instance of the tbl_ccTxDailyWorkingProgress class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_ccTxDailyWorkingProgress Maketbl_ccTxDailyWorkingProgress(SqlDataReader dataReader) {
			tbl_ccTxDailyWorkingProgress tbl_ccTxDailyWorkingProgress = new tbl_ccTxDailyWorkingProgress();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ccTxDailyWorkingProgress.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ccTxDailyWorkingProgress.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ccTxDailyWorkingProgress.Attendance_index = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ccTxDailyWorkingProgress.AttendenceDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ccTxDailyWorkingProgress.Year_ID = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ccTxDailyWorkingProgress.Week_ID = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ccTxDailyWorkingProgress.Employee_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ccTxDailyWorkingProgress.Department_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ccTxDailyWorkingProgress.DayType = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ccTxDailyWorkingProgress.Shift_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_ccTxDailyWorkingProgress.ShiftDay = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_ccTxDailyWorkingProgress.ShiftStartTime = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_ccTxDailyWorkingProgress.ShiftEndTime = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_ccTxDailyWorkingProgress.TimeIn_ID = dataReader.GetInt32(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_ccTxDailyWorkingProgress.TimeIn_DateTime = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_ccTxDailyWorkingProgress.TimeOut_ID = dataReader.GetInt32(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_ccTxDailyWorkingProgress.TimeOut_DateTime = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_ccTxDailyWorkingProgress.AttendanceStatus = dataReader.GetInt32(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_ccTxDailyWorkingProgress.Qty_Grade1 = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_ccTxDailyWorkingProgress.Qty_Grade2 = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_ccTxDailyWorkingProgress.Qty_Grade1_Night = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_ccTxDailyWorkingProgress.Qty_Grade2_Night = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_ccTxDailyWorkingProgress.Qty_Total = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_ccTxDailyWorkingProgress.IsCanceled = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_ccTxDailyWorkingProgress.UserID_Created = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_ccTxDailyWorkingProgress.UserID_Modified = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_ccTxDailyWorkingProgress.UserID_Canceled = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_ccTxDailyWorkingProgress.TerminalID_Created = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_ccTxDailyWorkingProgress.TerminalID_Modified = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_ccTxDailyWorkingProgress.TerminalID_Canceled = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_ccTxDailyWorkingProgress.Date_Created = dataReader.GetDateTime(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_ccTxDailyWorkingProgress.Date_Modified = dataReader.GetDateTime(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_ccTxDailyWorkingProgress.Date_Canceled = dataReader.GetDateTime(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_ccTxDailyWorkingProgress.PaymentPeriod = dataReader.GetInt32(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_ccTxDailyWorkingProgress.Amount_Total = dataReader.GetDecimal(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_ccTxDailyWorkingProgress.Amount_Total_Night = dataReader.GetDecimal(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_ccTxDailyWorkingProgress.Amount_Payslip = dataReader.GetDecimal(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_ccTxDailyWorkingProgress.Budgetary_Allowance1 = dataReader.GetDecimal(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_ccTxDailyWorkingProgress.Budgetary_Allowance2 = dataReader.GetDecimal(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_ccTxDailyWorkingProgress.Budgetary_Allowance3 = dataReader.GetDecimal(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_ccTxDailyWorkingProgress.Travel_Allowance = dataReader.GetDecimal(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_ccTxDailyWorkingProgress.Attendace_Allowance = dataReader.GetDecimal(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_ccTxDailyWorkingProgress.Other_Allowance1 = dataReader.GetDecimal(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_ccTxDailyWorkingProgress.Other_Deduction1 = dataReader.GetDecimal(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_ccTxDailyWorkingProgress.Other_Deduction2 = dataReader.GetDecimal(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_ccTxDailyWorkingProgress.Epf_8 = dataReader.GetDecimal(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_ccTxDailyWorkingProgress.Epf_12 = dataReader.GetDecimal(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_ccTxDailyWorkingProgress.Etf_3 = dataReader.GetDecimal(47);
			}

			return tbl_ccTxDailyWorkingProgress;
		}
		/// <summary>
		/// This makes tbl_ccTxDailyWorkingProgress datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ccTxDailyWorkingProgress object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ccTxDailyWorkingProgress  tbl_ccTxDailyWorkingProgress   )
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
			DataColumn col_qty_Grade1 = new DataColumn("qty_Grade1" , typeof(decimal));
			DataColumn col_qty_Grade2 = new DataColumn("qty_Grade2" , typeof(decimal));
			DataColumn col_qty_Grade1_Night = new DataColumn("qty_Grade1_Night" , typeof(decimal));
			DataColumn col_qty_Grade2_Night = new DataColumn("qty_Grade2_Night" , typeof(decimal));
			DataColumn col_qty_Total = new DataColumn("qty_Total" , typeof(decimal));
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
			DataColumn col_paymentPeriod = new DataColumn("paymentPeriod" , typeof(int));
			DataColumn col_amount_Total = new DataColumn("amount_Total" , typeof(decimal));
			DataColumn col_amount_Total_Night = new DataColumn("amount_Total_Night" , typeof(decimal));
			DataColumn col_amount_Payslip = new DataColumn("amount_Payslip" , typeof(decimal));
			DataColumn col_budgetary_Allowance1 = new DataColumn("budgetary_Allowance1" , typeof(decimal));
			DataColumn col_budgetary_Allowance2 = new DataColumn("budgetary_Allowance2" , typeof(decimal));
			DataColumn col_budgetary_Allowance3 = new DataColumn("budgetary_Allowance3" , typeof(decimal));
			DataColumn col_travel_Allowance = new DataColumn("travel_Allowance" , typeof(decimal));
			DataColumn col_attendace_Allowance = new DataColumn("attendace_Allowance" , typeof(decimal));
			DataColumn col_other_Allowance1 = new DataColumn("other_Allowance1" , typeof(decimal));
			DataColumn col_other_Deduction1 = new DataColumn("other_Deduction1" , typeof(decimal));
			DataColumn col_other_Deduction2 = new DataColumn("other_Deduction2" , typeof(decimal));
			DataColumn col_epf_8 = new DataColumn("epf_8" , typeof(decimal));
			DataColumn col_epf_12 = new DataColumn("epf_12" , typeof(decimal));
			DataColumn col_etf_3 = new DataColumn("etf_3" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_attendance_index,col_attendenceDate,col_year_ID,col_week_ID,col_employee_ID,col_department_ID,col_dayType,col_shift_ID,col_shiftDay,col_shiftStartTime,col_shiftEndTime,col_timeIn_ID,col_timeIn_DateTime,col_timeOut_ID,col_timeOut_DateTime,col_attendanceStatus,col_qty_Grade1,col_qty_Grade2,col_qty_Grade1_Night,col_qty_Grade2_Night,col_qty_Total,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,col_paymentPeriod,col_amount_Total,col_amount_Total_Night,col_amount_Payslip,col_budgetary_Allowance1,col_budgetary_Allowance2,col_budgetary_Allowance3,col_travel_Allowance,col_attendace_Allowance,col_other_Allowance1,col_other_Deduction1,col_other_Deduction2,col_epf_8,col_epf_12,col_etf_3,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ccTxDailyWorkingProgress datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ccTxDailyWorkingProgress object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ccTxDailyWorkingProgress user) {
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
			drow["qty_Grade1"] = user.qty_Grade1;
			drow["qty_Grade2"] = user.qty_Grade2;
			drow["qty_Grade1_Night"] = user.qty_Grade1_Night;
			drow["qty_Grade2_Night"] = user.qty_Grade2_Night;
			drow["qty_Total"] = user.qty_Total;
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
			drow["paymentPeriod"] = user.paymentPeriod;
			drow["amount_Total"] = user.amount_Total;
			drow["amount_Total_Night"] = user.amount_Total_Night;
			drow["amount_Payslip"] = user.amount_Payslip;
			drow["budgetary_Allowance1"] = user.budgetary_Allowance1;
			drow["budgetary_Allowance2"] = user.budgetary_Allowance2;
			drow["budgetary_Allowance3"] = user.budgetary_Allowance3;
			drow["travel_Allowance"] = user.travel_Allowance;
			drow["attendace_Allowance"] = user.attendace_Allowance;
			drow["other_Allowance1"] = user.other_Allowance1;
			drow["other_Deduction1"] = user.other_Deduction1;
			drow["other_Deduction2"] = user.other_Deduction2;
			drow["epf_8"] = user.epf_8;
			drow["epf_12"] = user.epf_12;
			drow["etf_3"] = user.etf_3;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
