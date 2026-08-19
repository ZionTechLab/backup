using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasShiftMaster {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string shift_ID;
		private string shift_Name;
		private string shift_Remarks;
		private int shiftType;
		private DateTime shiftStartTime;
		private int shiftMinutes;
		private int shiftMinutesMin;
		private int nextShiftMinutes;
		private decimal shiftBaseRate;
		private int shiftGracePeriod;
		private bool isSundaySpecialWH;
		private int shiftMinutes_Sunday;
		private int shiftMinutesMin_Sunday;
		private int nextShiftMinutes_Sunday;
		private decimal shiftBaseRate_Sunday;
		private int shiftGracePeriod_Sunday;
		private bool bSpecialParameter1_Sunday;
		private bool bSpecialParameter2_Sunday;
		private bool isMondaySpecialWH;
		private int shiftMinutes_Monday;
		private int shiftMinutesMin_Monday;
		private decimal shiftBaseRate_Monday;
		private int nextShiftMinutes_Monday;
		private int shiftGracePeriod_Monday;
		private bool bSpecialParameter1_Monday;
		private bool bSpecialParameter2_Monday;
		private bool isTuesdaySpecialWH;
		private int shiftMinutes_Tuesday;
		private int shiftMinutesMin_Tuesday;
		private int nextShiftMinutes_Tuesday;
		private decimal shiftBaseRate_Tuesday;
		private int shiftGracePeriod_Tuesday;
		private bool bSpecialParameter1_Tuesday;
		private bool bSpecialParameter2_Tuesday;
		private bool isWednesdaySpecialWH;
		private int shiftMinutes_Wednesday;
		private int shiftMinutesMin_Wednesday;
		private int nextShiftMinutes_Wednesday;
		private decimal shiftBaseRate_Wednesday;
		private int shiftGracePeriod_Wednesday;
		private bool bSpecialParameter1_Wednesday;
		private bool bSpecialParameter2_Wednesday;
		private bool isThursdaySpecialWH;
		private int shiftMinutes_Thursday;
		private int shiftMinutesMin_Thursday;
		private int nextShiftMinutes_Thursday;
		private decimal shiftBaseRate_Thursday;
		private int shiftGracePeriod_Thursday;
		private bool bSpecialParameter1_Thursday;
		private bool bSpecialParameter2_Thursday;
		private bool isFridaySpecialWH;
		private int shiftMinutes_Friday;
		private int shiftMinutesMin_Friday;
		private int nextShiftMinutes_Friday;
		private decimal shiftBaseRate_Friday;
		private int shiftGracePeriod_Friday;
		private bool bSpecialParameter1_Friday;
		private bool bSpecialParameter2_Friday;
		private bool isSaturdaySpecialWH;
		private int shiftMinutes_Saturday;
		private int shiftMinutesMin_Saturday;
		private int nextShiftMinutes_Saturday;
		private decimal shiftBaseRate_Saturday;
		private int shiftGracePeriod_Saturday;
		private bool bSpecialParameter1_Saturday;
		private bool bSpecialParameter2_Saturday;
		private bool isOT_Applicable;
		private bool isEarlyOtApplicable;
		private int shift_OTRoundMode;
		private int shift_OTRoundMinutes;
		private decimal shift_OTRate;
		private int shift_OTGracePeroiod;
		private int shift_EarlyOTGracePeroiod;
		private int shift_OTMinuteMin;
		private int shift_OTMinuteMax;
		private bool isWeekdaySpecialOT;
		private decimal shift_OTRate_Weekday;
		private int shift_OTGracePeroiod_Weekday;
		private int shift_OTMinuteMin_Weekday;
		private int shift_OTMinuteMax_Weekday;
		private bool isOTLunchDeduction_Weekday;
		private bool isSaturdaySpecialOT;
		private decimal shift_OTRate_Saturday;
		private int shift_OTGracePeroiod_Saturday;
		private int shift_OTMinuteMin_Saturday;
		private int shift_OTMinuteMax_Saturday;
		private bool isOTLunchDeduction_Saturday;
		private bool isSundaySpecialOT;
		private decimal shift_OTRate_Sunday;
		private int shift_OTGracePeroiod_Sunday;
		private int shift_OTMinuteMin_Sunday;
		private int shift_OTMinuteMax_Sunday;
		private bool isOTLunchDeduction_Sundy;
		private bool isPoyadaySpecialOT;
		private decimal shift_OTRate_Poyaday;
		private int shift_OTGracePeroiod_Poyaday;
		private int shift_OTMinuteMin_Poyaday;
		private int shift_OTMinuteMax_Poyaday;
		private bool isOTLunchDeduction_Poyaday;
		private bool isCompanyHolidaySpecialOT;
		private decimal shift_OTRate_CompanyHoliday;
		private int shift_OTGracePeroiod_CompanyHoliday;
		private int shift_OTMinuteMin_CompanyHoliday;
		private int shift_OTMinuteMax_CompanyHoliday;
		private bool isOTLunchDeduction_CompanyHoliday;
		private DateTime shift_Status_Effective_Date;
		private DateTime shift_Status_ExpireDate;
		private bool shift_Status;
		private DateTime lunchStartTime;
		private int lunchDurationMins;
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
		/// Initializes a new instance of the tbl_tasShiftMaster class.
		/// </summary>
		public tbl_tasShiftMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasShiftMaster class.
		/// </summary>
		public tbl_tasShiftMaster(string company_ID, string companyBranch_ID, string shift_ID, string shift_Name, string shift_Remarks, int shiftType, DateTime shiftStartTime, int shiftMinutes, int shiftMinutesMin, int nextShiftMinutes, decimal shiftBaseRate, int shiftGracePeriod, bool isSundaySpecialWH, int shiftMinutes_Sunday, int shiftMinutesMin_Sunday, int nextShiftMinutes_Sunday, decimal shiftBaseRate_Sunday, int shiftGracePeriod_Sunday, bool bSpecialParameter1_Sunday, bool bSpecialParameter2_Sunday, bool isMondaySpecialWH, int shiftMinutes_Monday, int shiftMinutesMin_Monday, decimal shiftBaseRate_Monday, int nextShiftMinutes_Monday, int shiftGracePeriod_Monday, bool bSpecialParameter1_Monday, bool bSpecialParameter2_Monday, bool isTuesdaySpecialWH, int shiftMinutes_Tuesday, int shiftMinutesMin_Tuesday, int nextShiftMinutes_Tuesday, decimal shiftBaseRate_Tuesday, int shiftGracePeriod_Tuesday, bool bSpecialParameter1_Tuesday, bool bSpecialParameter2_Tuesday, bool isWednesdaySpecialWH, int shiftMinutes_Wednesday, int shiftMinutesMin_Wednesday, int nextShiftMinutes_Wednesday, decimal shiftBaseRate_Wednesday, int shiftGracePeriod_Wednesday, bool bSpecialParameter1_Wednesday, bool bSpecialParameter2_Wednesday, bool isThursdaySpecialWH, int shiftMinutes_Thursday, int shiftMinutesMin_Thursday, int nextShiftMinutes_Thursday, decimal shiftBaseRate_Thursday, int shiftGracePeriod_Thursday, bool bSpecialParameter1_Thursday, bool bSpecialParameter2_Thursday, bool isFridaySpecialWH, int shiftMinutes_Friday, int shiftMinutesMin_Friday, int nextShiftMinutes_Friday, decimal shiftBaseRate_Friday, int shiftGracePeriod_Friday, bool bSpecialParameter1_Friday, bool bSpecialParameter2_Friday, bool isSaturdaySpecialWH, int shiftMinutes_Saturday, int shiftMinutesMin_Saturday, int nextShiftMinutes_Saturday, decimal shiftBaseRate_Saturday, int shiftGracePeriod_Saturday, bool bSpecialParameter1_Saturday, bool bSpecialParameter2_Saturday, bool isOT_Applicable, bool isEarlyOtApplicable, int shift_OTRoundMode, int shift_OTRoundMinutes, decimal shift_OTRate, int shift_OTGracePeroiod, int shift_EarlyOTGracePeroiod, int shift_OTMinuteMin, int shift_OTMinuteMax, bool isWeekdaySpecialOT, decimal shift_OTRate_Weekday, int shift_OTGracePeroiod_Weekday, int shift_OTMinuteMin_Weekday, int shift_OTMinuteMax_Weekday, bool isOTLunchDeduction_Weekday, bool isSaturdaySpecialOT, decimal shift_OTRate_Saturday, int shift_OTGracePeroiod_Saturday, int shift_OTMinuteMin_Saturday, int shift_OTMinuteMax_Saturday, bool isOTLunchDeduction_Saturday, bool isSundaySpecialOT, decimal shift_OTRate_Sunday, int shift_OTGracePeroiod_Sunday, int shift_OTMinuteMin_Sunday, int shift_OTMinuteMax_Sunday, bool isOTLunchDeduction_Sundy, bool isPoyadaySpecialOT, decimal shift_OTRate_Poyaday, int shift_OTGracePeroiod_Poyaday, int shift_OTMinuteMin_Poyaday, int shift_OTMinuteMax_Poyaday, bool isOTLunchDeduction_Poyaday, bool isCompanyHolidaySpecialOT, decimal shift_OTRate_CompanyHoliday, int shift_OTGracePeroiod_CompanyHoliday, int shift_OTMinuteMin_CompanyHoliday, int shift_OTMinuteMax_CompanyHoliday, bool isOTLunchDeduction_CompanyHoliday, DateTime shift_Status_Effective_Date, DateTime shift_Status_ExpireDate, bool shift_Status, DateTime lunchStartTime, int lunchDurationMins, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.shift_ID = shift_ID;
			this.shift_Name = shift_Name;
			this.shift_Remarks = shift_Remarks;
			this.shiftType = shiftType;
			this.shiftStartTime = shiftStartTime;
			this.shiftMinutes = shiftMinutes;
			this.shiftMinutesMin = shiftMinutesMin;
			this.nextShiftMinutes = nextShiftMinutes;
			this.shiftBaseRate = shiftBaseRate;
			this.shiftGracePeriod = shiftGracePeriod;
			this.isSundaySpecialWH = isSundaySpecialWH;
			this.shiftMinutes_Sunday = shiftMinutes_Sunday;
			this.shiftMinutesMin_Sunday = shiftMinutesMin_Sunday;
			this.nextShiftMinutes_Sunday = nextShiftMinutes_Sunday;
			this.shiftBaseRate_Sunday = shiftBaseRate_Sunday;
			this.shiftGracePeriod_Sunday = shiftGracePeriod_Sunday;
			this.bSpecialParameter1_Sunday = bSpecialParameter1_Sunday;
			this.bSpecialParameter2_Sunday = bSpecialParameter2_Sunday;
			this.isMondaySpecialWH = isMondaySpecialWH;
			this.shiftMinutes_Monday = shiftMinutes_Monday;
			this.shiftMinutesMin_Monday = shiftMinutesMin_Monday;
			this.shiftBaseRate_Monday = shiftBaseRate_Monday;
			this.nextShiftMinutes_Monday = nextShiftMinutes_Monday;
			this.shiftGracePeriod_Monday = shiftGracePeriod_Monday;
			this.bSpecialParameter1_Monday = bSpecialParameter1_Monday;
			this.bSpecialParameter2_Monday = bSpecialParameter2_Monday;
			this.isTuesdaySpecialWH = isTuesdaySpecialWH;
			this.shiftMinutes_Tuesday = shiftMinutes_Tuesday;
			this.shiftMinutesMin_Tuesday = shiftMinutesMin_Tuesday;
			this.nextShiftMinutes_Tuesday = nextShiftMinutes_Tuesday;
			this.shiftBaseRate_Tuesday = shiftBaseRate_Tuesday;
			this.shiftGracePeriod_Tuesday = shiftGracePeriod_Tuesday;
			this.bSpecialParameter1_Tuesday = bSpecialParameter1_Tuesday;
			this.bSpecialParameter2_Tuesday = bSpecialParameter2_Tuesday;
			this.isWednesdaySpecialWH = isWednesdaySpecialWH;
			this.shiftMinutes_Wednesday = shiftMinutes_Wednesday;
			this.shiftMinutesMin_Wednesday = shiftMinutesMin_Wednesday;
			this.nextShiftMinutes_Wednesday = nextShiftMinutes_Wednesday;
			this.shiftBaseRate_Wednesday = shiftBaseRate_Wednesday;
			this.shiftGracePeriod_Wednesday = shiftGracePeriod_Wednesday;
			this.bSpecialParameter1_Wednesday = bSpecialParameter1_Wednesday;
			this.bSpecialParameter2_Wednesday = bSpecialParameter2_Wednesday;
			this.isThursdaySpecialWH = isThursdaySpecialWH;
			this.shiftMinutes_Thursday = shiftMinutes_Thursday;
			this.shiftMinutesMin_Thursday = shiftMinutesMin_Thursday;
			this.nextShiftMinutes_Thursday = nextShiftMinutes_Thursday;
			this.shiftBaseRate_Thursday = shiftBaseRate_Thursday;
			this.shiftGracePeriod_Thursday = shiftGracePeriod_Thursday;
			this.bSpecialParameter1_Thursday = bSpecialParameter1_Thursday;
			this.bSpecialParameter2_Thursday = bSpecialParameter2_Thursday;
			this.isFridaySpecialWH = isFridaySpecialWH;
			this.shiftMinutes_Friday = shiftMinutes_Friday;
			this.shiftMinutesMin_Friday = shiftMinutesMin_Friday;
			this.nextShiftMinutes_Friday = nextShiftMinutes_Friday;
			this.shiftBaseRate_Friday = shiftBaseRate_Friday;
			this.shiftGracePeriod_Friday = shiftGracePeriod_Friday;
			this.bSpecialParameter1_Friday = bSpecialParameter1_Friday;
			this.bSpecialParameter2_Friday = bSpecialParameter2_Friday;
			this.isSaturdaySpecialWH = isSaturdaySpecialWH;
			this.shiftMinutes_Saturday = shiftMinutes_Saturday;
			this.shiftMinutesMin_Saturday = shiftMinutesMin_Saturday;
			this.nextShiftMinutes_Saturday = nextShiftMinutes_Saturday;
			this.shiftBaseRate_Saturday = shiftBaseRate_Saturday;
			this.shiftGracePeriod_Saturday = shiftGracePeriod_Saturday;
			this.bSpecialParameter1_Saturday = bSpecialParameter1_Saturday;
			this.bSpecialParameter2_Saturday = bSpecialParameter2_Saturday;
			this.isOT_Applicable = isOT_Applicable;
			this.isEarlyOtApplicable = isEarlyOtApplicable;
			this.shift_OTRoundMode = shift_OTRoundMode;
			this.shift_OTRoundMinutes = shift_OTRoundMinutes;
			this.shift_OTRate = shift_OTRate;
			this.shift_OTGracePeroiod = shift_OTGracePeroiod;
			this.shift_EarlyOTGracePeroiod = shift_EarlyOTGracePeroiod;
			this.shift_OTMinuteMin = shift_OTMinuteMin;
			this.shift_OTMinuteMax = shift_OTMinuteMax;
			this.isWeekdaySpecialOT = isWeekdaySpecialOT;
			this.shift_OTRate_Weekday = shift_OTRate_Weekday;
			this.shift_OTGracePeroiod_Weekday = shift_OTGracePeroiod_Weekday;
			this.shift_OTMinuteMin_Weekday = shift_OTMinuteMin_Weekday;
			this.shift_OTMinuteMax_Weekday = shift_OTMinuteMax_Weekday;
			this.isOTLunchDeduction_Weekday = isOTLunchDeduction_Weekday;
			this.isSaturdaySpecialOT = isSaturdaySpecialOT;
			this.shift_OTRate_Saturday = shift_OTRate_Saturday;
			this.shift_OTGracePeroiod_Saturday = shift_OTGracePeroiod_Saturday;
			this.shift_OTMinuteMin_Saturday = shift_OTMinuteMin_Saturday;
			this.shift_OTMinuteMax_Saturday = shift_OTMinuteMax_Saturday;
			this.isOTLunchDeduction_Saturday = isOTLunchDeduction_Saturday;
			this.isSundaySpecialOT = isSundaySpecialOT;
			this.shift_OTRate_Sunday = shift_OTRate_Sunday;
			this.shift_OTGracePeroiod_Sunday = shift_OTGracePeroiod_Sunday;
			this.shift_OTMinuteMin_Sunday = shift_OTMinuteMin_Sunday;
			this.shift_OTMinuteMax_Sunday = shift_OTMinuteMax_Sunday;
			this.isOTLunchDeduction_Sundy = isOTLunchDeduction_Sundy;
			this.isPoyadaySpecialOT = isPoyadaySpecialOT;
			this.shift_OTRate_Poyaday = shift_OTRate_Poyaday;
			this.shift_OTGracePeroiod_Poyaday = shift_OTGracePeroiod_Poyaday;
			this.shift_OTMinuteMin_Poyaday = shift_OTMinuteMin_Poyaday;
			this.shift_OTMinuteMax_Poyaday = shift_OTMinuteMax_Poyaday;
			this.isOTLunchDeduction_Poyaday = isOTLunchDeduction_Poyaday;
			this.isCompanyHolidaySpecialOT = isCompanyHolidaySpecialOT;
			this.shift_OTRate_CompanyHoliday = shift_OTRate_CompanyHoliday;
			this.shift_OTGracePeroiod_CompanyHoliday = shift_OTGracePeroiod_CompanyHoliday;
			this.shift_OTMinuteMin_CompanyHoliday = shift_OTMinuteMin_CompanyHoliday;
			this.shift_OTMinuteMax_CompanyHoliday = shift_OTMinuteMax_CompanyHoliday;
			this.isOTLunchDeduction_CompanyHoliday = isOTLunchDeduction_CompanyHoliday;
			this.shift_Status_Effective_Date = shift_Status_Effective_Date;
			this.shift_Status_ExpireDate = shift_Status_ExpireDate;
			this.shift_Status = shift_Status;
			this.lunchStartTime = lunchStartTime;
			this.lunchDurationMins = lunchDurationMins;
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
		/// Gets or sets the Shift_ID value.
		/// </summary>
		public string Shift_ID {
			get { return shift_ID; }
			set { shift_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_Name value.
		/// </summary>
		public string Shift_Name {
			get { return shift_Name; }
			set { shift_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_Remarks value.
		/// </summary>
		public string Shift_Remarks {
			get { return shift_Remarks; }
			set { shift_Remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftType value.
		/// </summary>
		public int ShiftType {
			get { return shiftType; }
			set { shiftType = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftStartTime value.
		/// </summary>
		public DateTime ShiftStartTime {
			get { return shiftStartTime; }
			set { shiftStartTime = value; }
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
		/// Gets or sets the ShiftBaseRate value.
		/// </summary>
		public decimal ShiftBaseRate {
			get { return shiftBaseRate; }
			set { shiftBaseRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftGracePeriod value.
		/// </summary>
		public int ShiftGracePeriod {
			get { return shiftGracePeriod; }
			set { shiftGracePeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSundaySpecialWH value.
		/// </summary>
		public bool IsSundaySpecialWH {
			get { return isSundaySpecialWH; }
			set { isSundaySpecialWH = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Sunday value.
		/// </summary>
		public int ShiftMinutes_Sunday {
			get { return shiftMinutes_Sunday; }
			set { shiftMinutes_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutesMin_Sunday value.
		/// </summary>
		public int ShiftMinutesMin_Sunday {
			get { return shiftMinutesMin_Sunday; }
			set { shiftMinutesMin_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the NextShiftMinutes_Sunday value.
		/// </summary>
		public int NextShiftMinutes_Sunday {
			get { return nextShiftMinutes_Sunday; }
			set { nextShiftMinutes_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftBaseRate_Sunday value.
		/// </summary>
		public decimal ShiftBaseRate_Sunday {
			get { return shiftBaseRate_Sunday; }
			set { shiftBaseRate_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftGracePeriod_Sunday value.
		/// </summary>
		public int ShiftGracePeriod_Sunday {
			get { return shiftGracePeriod_Sunday; }
			set { shiftGracePeriod_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter1_Sunday value.
		/// </summary>
		public bool BSpecialParameter1_Sunday {
			get { return bSpecialParameter1_Sunday; }
			set { bSpecialParameter1_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter2_Sunday value.
		/// </summary>
		public bool BSpecialParameter2_Sunday {
			get { return bSpecialParameter2_Sunday; }
			set { bSpecialParameter2_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsMondaySpecialWH value.
		/// </summary>
		public bool IsMondaySpecialWH {
			get { return isMondaySpecialWH; }
			set { isMondaySpecialWH = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Monday value.
		/// </summary>
		public int ShiftMinutes_Monday {
			get { return shiftMinutes_Monday; }
			set { shiftMinutes_Monday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutesMin_Monday value.
		/// </summary>
		public int ShiftMinutesMin_Monday {
			get { return shiftMinutesMin_Monday; }
			set { shiftMinutesMin_Monday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftBaseRate_Monday value.
		/// </summary>
		public decimal ShiftBaseRate_Monday {
			get { return shiftBaseRate_Monday; }
			set { shiftBaseRate_Monday = value; }
		}
		
		/// <summary>
		/// Gets or sets the NextShiftMinutes_Monday value.
		/// </summary>
		public int NextShiftMinutes_Monday {
			get { return nextShiftMinutes_Monday; }
			set { nextShiftMinutes_Monday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftGracePeriod_Monday value.
		/// </summary>
		public int ShiftGracePeriod_Monday {
			get { return shiftGracePeriod_Monday; }
			set { shiftGracePeriod_Monday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter1_Monday value.
		/// </summary>
		public bool BSpecialParameter1_Monday {
			get { return bSpecialParameter1_Monday; }
			set { bSpecialParameter1_Monday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter2_Monday value.
		/// </summary>
		public bool BSpecialParameter2_Monday {
			get { return bSpecialParameter2_Monday; }
			set { bSpecialParameter2_Monday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTuesdaySpecialWH value.
		/// </summary>
		public bool IsTuesdaySpecialWH {
			get { return isTuesdaySpecialWH; }
			set { isTuesdaySpecialWH = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Tuesday value.
		/// </summary>
		public int ShiftMinutes_Tuesday {
			get { return shiftMinutes_Tuesday; }
			set { shiftMinutes_Tuesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutesMin_Tuesday value.
		/// </summary>
		public int ShiftMinutesMin_Tuesday {
			get { return shiftMinutesMin_Tuesday; }
			set { shiftMinutesMin_Tuesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the NextShiftMinutes_Tuesday value.
		/// </summary>
		public int NextShiftMinutes_Tuesday {
			get { return nextShiftMinutes_Tuesday; }
			set { nextShiftMinutes_Tuesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftBaseRate_Tuesday value.
		/// </summary>
		public decimal ShiftBaseRate_Tuesday {
			get { return shiftBaseRate_Tuesday; }
			set { shiftBaseRate_Tuesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftGracePeriod_Tuesday value.
		/// </summary>
		public int ShiftGracePeriod_Tuesday {
			get { return shiftGracePeriod_Tuesday; }
			set { shiftGracePeriod_Tuesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter1_Tuesday value.
		/// </summary>
		public bool BSpecialParameter1_Tuesday {
			get { return bSpecialParameter1_Tuesday; }
			set { bSpecialParameter1_Tuesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter2_Tuesday value.
		/// </summary>
		public bool BSpecialParameter2_Tuesday {
			get { return bSpecialParameter2_Tuesday; }
			set { bSpecialParameter2_Tuesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWednesdaySpecialWH value.
		/// </summary>
		public bool IsWednesdaySpecialWH {
			get { return isWednesdaySpecialWH; }
			set { isWednesdaySpecialWH = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Wednesday value.
		/// </summary>
		public int ShiftMinutes_Wednesday {
			get { return shiftMinutes_Wednesday; }
			set { shiftMinutes_Wednesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutesMin_Wednesday value.
		/// </summary>
		public int ShiftMinutesMin_Wednesday {
			get { return shiftMinutesMin_Wednesday; }
			set { shiftMinutesMin_Wednesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the NextShiftMinutes_Wednesday value.
		/// </summary>
		public int NextShiftMinutes_Wednesday {
			get { return nextShiftMinutes_Wednesday; }
			set { nextShiftMinutes_Wednesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftBaseRate_Wednesday value.
		/// </summary>
		public decimal ShiftBaseRate_Wednesday {
			get { return shiftBaseRate_Wednesday; }
			set { shiftBaseRate_Wednesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftGracePeriod_Wednesday value.
		/// </summary>
		public int ShiftGracePeriod_Wednesday {
			get { return shiftGracePeriod_Wednesday; }
			set { shiftGracePeriod_Wednesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter1_Wednesday value.
		/// </summary>
		public bool BSpecialParameter1_Wednesday {
			get { return bSpecialParameter1_Wednesday; }
			set { bSpecialParameter1_Wednesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter2_Wednesday value.
		/// </summary>
		public bool BSpecialParameter2_Wednesday {
			get { return bSpecialParameter2_Wednesday; }
			set { bSpecialParameter2_Wednesday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsThursdaySpecialWH value.
		/// </summary>
		public bool IsThursdaySpecialWH {
			get { return isThursdaySpecialWH; }
			set { isThursdaySpecialWH = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Thursday value.
		/// </summary>
		public int ShiftMinutes_Thursday {
			get { return shiftMinutes_Thursday; }
			set { shiftMinutes_Thursday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutesMin_Thursday value.
		/// </summary>
		public int ShiftMinutesMin_Thursday {
			get { return shiftMinutesMin_Thursday; }
			set { shiftMinutesMin_Thursday = value; }
		}
		
		/// <summary>
		/// Gets or sets the NextShiftMinutes_Thursday value.
		/// </summary>
		public int NextShiftMinutes_Thursday {
			get { return nextShiftMinutes_Thursday; }
			set { nextShiftMinutes_Thursday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftBaseRate_Thursday value.
		/// </summary>
		public decimal ShiftBaseRate_Thursday {
			get { return shiftBaseRate_Thursday; }
			set { shiftBaseRate_Thursday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftGracePeriod_Thursday value.
		/// </summary>
		public int ShiftGracePeriod_Thursday {
			get { return shiftGracePeriod_Thursday; }
			set { shiftGracePeriod_Thursday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter1_Thursday value.
		/// </summary>
		public bool BSpecialParameter1_Thursday {
			get { return bSpecialParameter1_Thursday; }
			set { bSpecialParameter1_Thursday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter2_Thursday value.
		/// </summary>
		public bool BSpecialParameter2_Thursday {
			get { return bSpecialParameter2_Thursday; }
			set { bSpecialParameter2_Thursday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFridaySpecialWH value.
		/// </summary>
		public bool IsFridaySpecialWH {
			get { return isFridaySpecialWH; }
			set { isFridaySpecialWH = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Friday value.
		/// </summary>
		public int ShiftMinutes_Friday {
			get { return shiftMinutes_Friday; }
			set { shiftMinutes_Friday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutesMin_Friday value.
		/// </summary>
		public int ShiftMinutesMin_Friday {
			get { return shiftMinutesMin_Friday; }
			set { shiftMinutesMin_Friday = value; }
		}
		
		/// <summary>
		/// Gets or sets the NextShiftMinutes_Friday value.
		/// </summary>
		public int NextShiftMinutes_Friday {
			get { return nextShiftMinutes_Friday; }
			set { nextShiftMinutes_Friday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftBaseRate_Friday value.
		/// </summary>
		public decimal ShiftBaseRate_Friday {
			get { return shiftBaseRate_Friday; }
			set { shiftBaseRate_Friday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftGracePeriod_Friday value.
		/// </summary>
		public int ShiftGracePeriod_Friday {
			get { return shiftGracePeriod_Friday; }
			set { shiftGracePeriod_Friday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter1_Friday value.
		/// </summary>
		public bool BSpecialParameter1_Friday {
			get { return bSpecialParameter1_Friday; }
			set { bSpecialParameter1_Friday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter2_Friday value.
		/// </summary>
		public bool BSpecialParameter2_Friday {
			get { return bSpecialParameter2_Friday; }
			set { bSpecialParameter2_Friday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSaturdaySpecialWH value.
		/// </summary>
		public bool IsSaturdaySpecialWH {
			get { return isSaturdaySpecialWH; }
			set { isSaturdaySpecialWH = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutes_Saturday value.
		/// </summary>
		public int ShiftMinutes_Saturday {
			get { return shiftMinutes_Saturday; }
			set { shiftMinutes_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftMinutesMin_Saturday value.
		/// </summary>
		public int ShiftMinutesMin_Saturday {
			get { return shiftMinutesMin_Saturday; }
			set { shiftMinutesMin_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the NextShiftMinutes_Saturday value.
		/// </summary>
		public int NextShiftMinutes_Saturday {
			get { return nextShiftMinutes_Saturday; }
			set { nextShiftMinutes_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftBaseRate_Saturday value.
		/// </summary>
		public decimal ShiftBaseRate_Saturday {
			get { return shiftBaseRate_Saturday; }
			set { shiftBaseRate_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShiftGracePeriod_Saturday value.
		/// </summary>
		public int ShiftGracePeriod_Saturday {
			get { return shiftGracePeriod_Saturday; }
			set { shiftGracePeriod_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter1_Saturday value.
		/// </summary>
		public bool BSpecialParameter1_Saturday {
			get { return bSpecialParameter1_Saturday; }
			set { bSpecialParameter1_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpecialParameter2_Saturday value.
		/// </summary>
		public bool BSpecialParameter2_Saturday {
			get { return bSpecialParameter2_Saturday; }
			set { bSpecialParameter2_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOT_Applicable value.
		/// </summary>
		public bool IsOT_Applicable {
			get { return isOT_Applicable; }
			set { isOT_Applicable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEarlyOtApplicable value.
		/// </summary>
		public bool IsEarlyOtApplicable {
			get { return isEarlyOtApplicable; }
			set { isEarlyOtApplicable = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTRoundMode value.
		/// </summary>
		public int Shift_OTRoundMode {
			get { return shift_OTRoundMode; }
			set { shift_OTRoundMode = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTRoundMinutes value.
		/// </summary>
		public int Shift_OTRoundMinutes {
			get { return shift_OTRoundMinutes; }
			set { shift_OTRoundMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTRate value.
		/// </summary>
		public decimal Shift_OTRate {
			get { return shift_OTRate; }
			set { shift_OTRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTGracePeroiod value.
		/// </summary>
		public int Shift_OTGracePeroiod {
			get { return shift_OTGracePeroiod; }
			set { shift_OTGracePeroiod = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_EarlyOTGracePeroiod value.
		/// </summary>
		public int Shift_EarlyOTGracePeroiod {
			get { return shift_EarlyOTGracePeroiod; }
			set { shift_EarlyOTGracePeroiod = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMin value.
		/// </summary>
		public int Shift_OTMinuteMin {
			get { return shift_OTMinuteMin; }
			set { shift_OTMinuteMin = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMax value.
		/// </summary>
		public int Shift_OTMinuteMax {
			get { return shift_OTMinuteMax; }
			set { shift_OTMinuteMax = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeekdaySpecialOT value.
		/// </summary>
		public bool IsWeekdaySpecialOT {
			get { return isWeekdaySpecialOT; }
			set { isWeekdaySpecialOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTRate_Weekday value.
		/// </summary>
		public decimal Shift_OTRate_Weekday {
			get { return shift_OTRate_Weekday; }
			set { shift_OTRate_Weekday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTGracePeroiod_Weekday value.
		/// </summary>
		public int Shift_OTGracePeroiod_Weekday {
			get { return shift_OTGracePeroiod_Weekday; }
			set { shift_OTGracePeroiod_Weekday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMin_Weekday value.
		/// </summary>
		public int Shift_OTMinuteMin_Weekday {
			get { return shift_OTMinuteMin_Weekday; }
			set { shift_OTMinuteMin_Weekday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMax_Weekday value.
		/// </summary>
		public int Shift_OTMinuteMax_Weekday {
			get { return shift_OTMinuteMax_Weekday; }
			set { shift_OTMinuteMax_Weekday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOTLunchDeduction_Weekday value.
		/// </summary>
		public bool IsOTLunchDeduction_Weekday {
			get { return isOTLunchDeduction_Weekday; }
			set { isOTLunchDeduction_Weekday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSaturdaySpecialOT value.
		/// </summary>
		public bool IsSaturdaySpecialOT {
			get { return isSaturdaySpecialOT; }
			set { isSaturdaySpecialOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTRate_Saturday value.
		/// </summary>
		public decimal Shift_OTRate_Saturday {
			get { return shift_OTRate_Saturday; }
			set { shift_OTRate_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTGracePeroiod_Saturday value.
		/// </summary>
		public int Shift_OTGracePeroiod_Saturday {
			get { return shift_OTGracePeroiod_Saturday; }
			set { shift_OTGracePeroiod_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMin_Saturday value.
		/// </summary>
		public int Shift_OTMinuteMin_Saturday {
			get { return shift_OTMinuteMin_Saturday; }
			set { shift_OTMinuteMin_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMax_Saturday value.
		/// </summary>
		public int Shift_OTMinuteMax_Saturday {
			get { return shift_OTMinuteMax_Saturday; }
			set { shift_OTMinuteMax_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOTLunchDeduction_Saturday value.
		/// </summary>
		public bool IsOTLunchDeduction_Saturday {
			get { return isOTLunchDeduction_Saturday; }
			set { isOTLunchDeduction_Saturday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSundaySpecialOT value.
		/// </summary>
		public bool IsSundaySpecialOT {
			get { return isSundaySpecialOT; }
			set { isSundaySpecialOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTRate_Sunday value.
		/// </summary>
		public decimal Shift_OTRate_Sunday {
			get { return shift_OTRate_Sunday; }
			set { shift_OTRate_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTGracePeroiod_Sunday value.
		/// </summary>
		public int Shift_OTGracePeroiod_Sunday {
			get { return shift_OTGracePeroiod_Sunday; }
			set { shift_OTGracePeroiod_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMin_Sunday value.
		/// </summary>
		public int Shift_OTMinuteMin_Sunday {
			get { return shift_OTMinuteMin_Sunday; }
			set { shift_OTMinuteMin_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMax_Sunday value.
		/// </summary>
		public int Shift_OTMinuteMax_Sunday {
			get { return shift_OTMinuteMax_Sunday; }
			set { shift_OTMinuteMax_Sunday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOTLunchDeduction_Sundy value.
		/// </summary>
		public bool IsOTLunchDeduction_Sundy {
			get { return isOTLunchDeduction_Sundy; }
			set { isOTLunchDeduction_Sundy = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPoyadaySpecialOT value.
		/// </summary>
		public bool IsPoyadaySpecialOT {
			get { return isPoyadaySpecialOT; }
			set { isPoyadaySpecialOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTRate_Poyaday value.
		/// </summary>
		public decimal Shift_OTRate_Poyaday {
			get { return shift_OTRate_Poyaday; }
			set { shift_OTRate_Poyaday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTGracePeroiod_Poyaday value.
		/// </summary>
		public int Shift_OTGracePeroiod_Poyaday {
			get { return shift_OTGracePeroiod_Poyaday; }
			set { shift_OTGracePeroiod_Poyaday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMin_Poyaday value.
		/// </summary>
		public int Shift_OTMinuteMin_Poyaday {
			get { return shift_OTMinuteMin_Poyaday; }
			set { shift_OTMinuteMin_Poyaday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMax_Poyaday value.
		/// </summary>
		public int Shift_OTMinuteMax_Poyaday {
			get { return shift_OTMinuteMax_Poyaday; }
			set { shift_OTMinuteMax_Poyaday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOTLunchDeduction_Poyaday value.
		/// </summary>
		public bool IsOTLunchDeduction_Poyaday {
			get { return isOTLunchDeduction_Poyaday; }
			set { isOTLunchDeduction_Poyaday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCompanyHolidaySpecialOT value.
		/// </summary>
		public bool IsCompanyHolidaySpecialOT {
			get { return isCompanyHolidaySpecialOT; }
			set { isCompanyHolidaySpecialOT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTRate_CompanyHoliday value.
		/// </summary>
		public decimal Shift_OTRate_CompanyHoliday {
			get { return shift_OTRate_CompanyHoliday; }
			set { shift_OTRate_CompanyHoliday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTGracePeroiod_CompanyHoliday value.
		/// </summary>
		public int Shift_OTGracePeroiod_CompanyHoliday {
			get { return shift_OTGracePeroiod_CompanyHoliday; }
			set { shift_OTGracePeroiod_CompanyHoliday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMin_CompanyHoliday value.
		/// </summary>
		public int Shift_OTMinuteMin_CompanyHoliday {
			get { return shift_OTMinuteMin_CompanyHoliday; }
			set { shift_OTMinuteMin_CompanyHoliday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_OTMinuteMax_CompanyHoliday value.
		/// </summary>
		public int Shift_OTMinuteMax_CompanyHoliday {
			get { return shift_OTMinuteMax_CompanyHoliday; }
			set { shift_OTMinuteMax_CompanyHoliday = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOTLunchDeduction_CompanyHoliday value.
		/// </summary>
		public bool IsOTLunchDeduction_CompanyHoliday {
			get { return isOTLunchDeduction_CompanyHoliday; }
			set { isOTLunchDeduction_CompanyHoliday = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_Status_Effective_Date value.
		/// </summary>
		public DateTime Shift_Status_Effective_Date {
			get { return shift_Status_Effective_Date; }
			set { shift_Status_Effective_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_Status_ExpireDate value.
		/// </summary>
		public DateTime Shift_Status_ExpireDate {
			get { return shift_Status_ExpireDate; }
			set { shift_Status_ExpireDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shift_Status value.
		/// </summary>
		public bool Shift_Status {
			get { return shift_Status; }
			set { shift_Status = value; }
		}
		
		/// <summary>
		/// Gets or sets the LunchStartTime value.
		/// </summary>
		public DateTime LunchStartTime {
			get { return lunchStartTime; }
			set { lunchStartTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the LunchDurationMins value.
		/// </summary>
		public int LunchDurationMins {
			get { return lunchDurationMins; }
			set { lunchDurationMins = value; }
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
		/// Saves a record to the tbl_tasShiftMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasShiftMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@shift_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@shift_Remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@shiftType", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftStartTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod", SqlDbType.Int,4);
			scom.Parameters.Add("@isSundaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Sunday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Sunday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Sunday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMondaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Monday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Monday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Monday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nextShiftMinutes_Monday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftGracePeriod_Monday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Monday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Monday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTuesdaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Tuesday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Tuesday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Tuesday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Tuesday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Tuesday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Tuesday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Tuesday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWednesdaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Wednesday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Wednesday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Wednesday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Wednesday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Wednesday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Wednesday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Wednesday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isThursdaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Thursday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Thursday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Thursday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Thursday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Thursday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Thursday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Thursday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFridaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Friday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Friday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Friday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Friday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Friday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Friday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Friday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSaturdaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Saturday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Saturday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Saturday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOT_Applicable", SqlDbType.Bit,1);
			scom.Parameters.Add("@IsEarlyOtApplicable", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRoundMode", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTRoundMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_EarlyOTGracePeroiod", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax", SqlDbType.Int,4);
			scom.Parameters.Add("@isWeekdaySpecialOT", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRate_Weekday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod_Weekday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin_Weekday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax_Weekday", SqlDbType.Int,4);
			scom.Parameters.Add("@isOTLunchDeduction_Weekday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSaturdaySpecialOT", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRate_Saturday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@isOTLunchDeduction_Saturday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSundaySpecialOT", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRate_Sunday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@isOTLunchDeduction_Sundy", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPoyadaySpecialOT", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRate_Poyaday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod_Poyaday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin_Poyaday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax_Poyaday", SqlDbType.Int,4);
			scom.Parameters.Add("@isOTLunchDeduction_Poyaday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCompanyHolidaySpecialOT", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRate_CompanyHoliday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod_CompanyHoliday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin_CompanyHoliday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax_CompanyHoliday", SqlDbType.Int,4);
			scom.Parameters.Add("@isOTLunchDeduction_CompanyHoliday", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_Status_Effective_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shift_Status_ExpireDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shift_Status", SqlDbType.Bit,1);
			scom.Parameters.Add("@lunchStartTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lunchDurationMins", SqlDbType.Int,4);
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
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@shift_Name"].Value = shift_Name;
			scom.Parameters["@shift_Remarks"].Value = shift_Remarks;
			scom.Parameters["@shiftType"].Value = shiftType;
			scom.Parameters["@shiftStartTime"].Value = shiftStartTime;
			scom.Parameters["@shiftMinutes"].Value = shiftMinutes;
			scom.Parameters["@shiftMinutesMin"].Value = shiftMinutesMin;
			scom.Parameters["@nextShiftMinutes"].Value = nextShiftMinutes;
			scom.Parameters["@shiftBaseRate"].Value = shiftBaseRate;
			scom.Parameters["@shiftGracePeriod"].Value = shiftGracePeriod;
			scom.Parameters["@isSundaySpecialWH"].Value = isSundaySpecialWH;
			scom.Parameters["@shiftMinutes_Sunday"].Value = shiftMinutes_Sunday;
			scom.Parameters["@shiftMinutesMin_Sunday"].Value = shiftMinutesMin_Sunday;
			scom.Parameters["@nextShiftMinutes_Sunday"].Value = nextShiftMinutes_Sunday;
			scom.Parameters["@shiftBaseRate_Sunday"].Value = shiftBaseRate_Sunday;
			scom.Parameters["@shiftGracePeriod_Sunday"].Value = shiftGracePeriod_Sunday;
			scom.Parameters["@bSpecialParameter1_Sunday"].Value = bSpecialParameter1_Sunday;
			scom.Parameters["@bSpecialParameter2_Sunday"].Value = bSpecialParameter2_Sunday;
			scom.Parameters["@isMondaySpecialWH"].Value = isMondaySpecialWH;
			scom.Parameters["@shiftMinutes_Monday"].Value = shiftMinutes_Monday;
			scom.Parameters["@shiftMinutesMin_Monday"].Value = shiftMinutesMin_Monday;
			scom.Parameters["@shiftBaseRate_Monday"].Value = shiftBaseRate_Monday;
			scom.Parameters["@nextShiftMinutes_Monday"].Value = nextShiftMinutes_Monday;
			scom.Parameters["@shiftGracePeriod_Monday"].Value = shiftGracePeriod_Monday;
			scom.Parameters["@bSpecialParameter1_Monday"].Value = bSpecialParameter1_Monday;
			scom.Parameters["@bSpecialParameter2_Monday"].Value = bSpecialParameter2_Monday;
			scom.Parameters["@isTuesdaySpecialWH"].Value = isTuesdaySpecialWH;
			scom.Parameters["@shiftMinutes_Tuesday"].Value = shiftMinutes_Tuesday;
			scom.Parameters["@shiftMinutesMin_Tuesday"].Value = shiftMinutesMin_Tuesday;
			scom.Parameters["@nextShiftMinutes_Tuesday"].Value = nextShiftMinutes_Tuesday;
			scom.Parameters["@shiftBaseRate_Tuesday"].Value = shiftBaseRate_Tuesday;
			scom.Parameters["@shiftGracePeriod_Tuesday"].Value = shiftGracePeriod_Tuesday;
			scom.Parameters["@bSpecialParameter1_Tuesday"].Value = bSpecialParameter1_Tuesday;
			scom.Parameters["@bSpecialParameter2_Tuesday"].Value = bSpecialParameter2_Tuesday;
			scom.Parameters["@isWednesdaySpecialWH"].Value = isWednesdaySpecialWH;
			scom.Parameters["@shiftMinutes_Wednesday"].Value = shiftMinutes_Wednesday;
			scom.Parameters["@shiftMinutesMin_Wednesday"].Value = shiftMinutesMin_Wednesday;
			scom.Parameters["@nextShiftMinutes_Wednesday"].Value = nextShiftMinutes_Wednesday;
			scom.Parameters["@shiftBaseRate_Wednesday"].Value = shiftBaseRate_Wednesday;
			scom.Parameters["@shiftGracePeriod_Wednesday"].Value = shiftGracePeriod_Wednesday;
			scom.Parameters["@bSpecialParameter1_Wednesday"].Value = bSpecialParameter1_Wednesday;
			scom.Parameters["@bSpecialParameter2_Wednesday"].Value = bSpecialParameter2_Wednesday;
			scom.Parameters["@isThursdaySpecialWH"].Value = isThursdaySpecialWH;
			scom.Parameters["@shiftMinutes_Thursday"].Value = shiftMinutes_Thursday;
			scom.Parameters["@shiftMinutesMin_Thursday"].Value = shiftMinutesMin_Thursday;
			scom.Parameters["@nextShiftMinutes_Thursday"].Value = nextShiftMinutes_Thursday;
			scom.Parameters["@shiftBaseRate_Thursday"].Value = shiftBaseRate_Thursday;
			scom.Parameters["@shiftGracePeriod_Thursday"].Value = shiftGracePeriod_Thursday;
			scom.Parameters["@bSpecialParameter1_Thursday"].Value = bSpecialParameter1_Thursday;
			scom.Parameters["@bSpecialParameter2_Thursday"].Value = bSpecialParameter2_Thursday;
			scom.Parameters["@isFridaySpecialWH"].Value = isFridaySpecialWH;
			scom.Parameters["@shiftMinutes_Friday"].Value = shiftMinutes_Friday;
			scom.Parameters["@shiftMinutesMin_Friday"].Value = shiftMinutesMin_Friday;
			scom.Parameters["@nextShiftMinutes_Friday"].Value = nextShiftMinutes_Friday;
			scom.Parameters["@shiftBaseRate_Friday"].Value = shiftBaseRate_Friday;
			scom.Parameters["@shiftGracePeriod_Friday"].Value = shiftGracePeriod_Friday;
			scom.Parameters["@bSpecialParameter1_Friday"].Value = bSpecialParameter1_Friday;
			scom.Parameters["@bSpecialParameter2_Friday"].Value = bSpecialParameter2_Friday;
			scom.Parameters["@isSaturdaySpecialWH"].Value = isSaturdaySpecialWH;
			scom.Parameters["@shiftMinutes_Saturday"].Value = shiftMinutes_Saturday;
			scom.Parameters["@shiftMinutesMin_Saturday"].Value = shiftMinutesMin_Saturday;
			scom.Parameters["@nextShiftMinutes_Saturday"].Value = nextShiftMinutes_Saturday;
			scom.Parameters["@shiftBaseRate_Saturday"].Value = shiftBaseRate_Saturday;
			scom.Parameters["@shiftGracePeriod_Saturday"].Value = shiftGracePeriod_Saturday;
			scom.Parameters["@bSpecialParameter1_Saturday"].Value = bSpecialParameter1_Saturday;
			scom.Parameters["@bSpecialParameter2_Saturday"].Value = bSpecialParameter2_Saturday;
			scom.Parameters["@isOT_Applicable"].Value = isOT_Applicable;
			scom.Parameters["@IsEarlyOtApplicable"].Value = isEarlyOtApplicable;
			scom.Parameters["@shift_OTRoundMode"].Value = shift_OTRoundMode;
			scom.Parameters["@shift_OTRoundMinutes"].Value = shift_OTRoundMinutes;
			scom.Parameters["@shift_OTRate"].Value = shift_OTRate;
			scom.Parameters["@shift_OTGracePeroiod"].Value = shift_OTGracePeroiod;
			scom.Parameters["@shift_EarlyOTGracePeroiod"].Value = shift_EarlyOTGracePeroiod;
			scom.Parameters["@shift_OTMinuteMin"].Value = shift_OTMinuteMin;
			scom.Parameters["@shift_OTMinuteMax"].Value = shift_OTMinuteMax;
			scom.Parameters["@isWeekdaySpecialOT"].Value = isWeekdaySpecialOT;
			scom.Parameters["@shift_OTRate_Weekday"].Value = shift_OTRate_Weekday;
			scom.Parameters["@shift_OTGracePeroiod_Weekday"].Value = shift_OTGracePeroiod_Weekday;
			scom.Parameters["@shift_OTMinuteMin_Weekday"].Value = shift_OTMinuteMin_Weekday;
			scom.Parameters["@shift_OTMinuteMax_Weekday"].Value = shift_OTMinuteMax_Weekday;
			scom.Parameters["@isOTLunchDeduction_Weekday"].Value = isOTLunchDeduction_Weekday;
			scom.Parameters["@isSaturdaySpecialOT"].Value = isSaturdaySpecialOT;
			scom.Parameters["@shift_OTRate_Saturday"].Value = shift_OTRate_Saturday;
			scom.Parameters["@shift_OTGracePeroiod_Saturday"].Value = shift_OTGracePeroiod_Saturday;
			scom.Parameters["@shift_OTMinuteMin_Saturday"].Value = shift_OTMinuteMin_Saturday;
			scom.Parameters["@shift_OTMinuteMax_Saturday"].Value = shift_OTMinuteMax_Saturday;
			scom.Parameters["@isOTLunchDeduction_Saturday"].Value = isOTLunchDeduction_Saturday;
			scom.Parameters["@isSundaySpecialOT"].Value = isSundaySpecialOT;
			scom.Parameters["@shift_OTRate_Sunday"].Value = shift_OTRate_Sunday;
			scom.Parameters["@shift_OTGracePeroiod_Sunday"].Value = shift_OTGracePeroiod_Sunday;
			scom.Parameters["@shift_OTMinuteMin_Sunday"].Value = shift_OTMinuteMin_Sunday;
			scom.Parameters["@shift_OTMinuteMax_Sunday"].Value = shift_OTMinuteMax_Sunday;
			scom.Parameters["@isOTLunchDeduction_Sundy"].Value = isOTLunchDeduction_Sundy;
			scom.Parameters["@isPoyadaySpecialOT"].Value = isPoyadaySpecialOT;
			scom.Parameters["@shift_OTRate_Poyaday"].Value = shift_OTRate_Poyaday;
			scom.Parameters["@shift_OTGracePeroiod_Poyaday"].Value = shift_OTGracePeroiod_Poyaday;
			scom.Parameters["@shift_OTMinuteMin_Poyaday"].Value = shift_OTMinuteMin_Poyaday;
			scom.Parameters["@shift_OTMinuteMax_Poyaday"].Value = shift_OTMinuteMax_Poyaday;
			scom.Parameters["@isOTLunchDeduction_Poyaday"].Value = isOTLunchDeduction_Poyaday;
			scom.Parameters["@isCompanyHolidaySpecialOT"].Value = isCompanyHolidaySpecialOT;
			scom.Parameters["@shift_OTRate_CompanyHoliday"].Value = shift_OTRate_CompanyHoliday;
			scom.Parameters["@shift_OTGracePeroiod_CompanyHoliday"].Value = shift_OTGracePeroiod_CompanyHoliday;
			scom.Parameters["@shift_OTMinuteMin_CompanyHoliday"].Value = shift_OTMinuteMin_CompanyHoliday;
			scom.Parameters["@shift_OTMinuteMax_CompanyHoliday"].Value = shift_OTMinuteMax_CompanyHoliday;
			scom.Parameters["@isOTLunchDeduction_CompanyHoliday"].Value = isOTLunchDeduction_CompanyHoliday;
			scom.Parameters["@shift_Status_Effective_Date"].Value = shift_Status_Effective_Date;
			scom.Parameters["@shift_Status_ExpireDate"].Value = shift_Status_ExpireDate;
			scom.Parameters["@shift_Status"].Value = shift_Status;
			scom.Parameters["@lunchStartTime"].Value = lunchStartTime;
			scom.Parameters["@lunchDurationMins"].Value = lunchDurationMins;
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
		/// Updates a record in the tbl_tasShiftMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasShiftMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@shift_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@shift_Remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@shiftType", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftStartTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod", SqlDbType.Int,4);
			scom.Parameters.Add("@isSundaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Sunday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Sunday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Sunday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMondaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Monday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Monday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Monday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nextShiftMinutes_Monday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftGracePeriod_Monday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Monday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Monday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTuesdaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Tuesday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Tuesday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Tuesday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Tuesday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Tuesday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Tuesday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Tuesday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWednesdaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Wednesday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Wednesday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Wednesday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Wednesday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Wednesday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Wednesday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Wednesday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isThursdaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Thursday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Thursday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Thursday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Thursday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Thursday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Thursday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Thursday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFridaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Friday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Friday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Friday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Friday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Friday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Friday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Friday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSaturdaySpecialWH", SqlDbType.Bit,1);
			scom.Parameters.Add("@shiftMinutes_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftBaseRate_Saturday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shiftGracePeriod_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@bSpecialParameter1_Saturday", SqlDbType.Bit,1);
			scom.Parameters.Add("@bSpecialParameter2_Saturday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOT_Applicable", SqlDbType.Bit,1);
			scom.Parameters.Add("@IsEarlyOtApplicable", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRoundMode", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTRoundMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_EarlyOTGracePeroiod", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax", SqlDbType.Int,4);
			scom.Parameters.Add("@isWeekdaySpecialOT", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRate_Weekday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod_Weekday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin_Weekday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax_Weekday", SqlDbType.Int,4);
			scom.Parameters.Add("@isOTLunchDeduction_Weekday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSaturdaySpecialOT", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRate_Saturday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax_Saturday", SqlDbType.Int,4);
			scom.Parameters.Add("@isOTLunchDeduction_Saturday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSundaySpecialOT", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRate_Sunday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax_Sunday", SqlDbType.Int,4);
			scom.Parameters.Add("@isOTLunchDeduction_Sundy", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPoyadaySpecialOT", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRate_Poyaday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod_Poyaday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin_Poyaday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax_Poyaday", SqlDbType.Int,4);
			scom.Parameters.Add("@isOTLunchDeduction_Poyaday", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCompanyHolidaySpecialOT", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTRate_CompanyHoliday", SqlDbType.Decimal,9);
			scom.Parameters.Add("@shift_OTGracePeroiod_CompanyHoliday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMin_CompanyHoliday", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax_CompanyHoliday", SqlDbType.Int,4);
			scom.Parameters.Add("@isOTLunchDeduction_CompanyHoliday", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_Status_Effective_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shift_Status_ExpireDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shift_Status", SqlDbType.Bit,1);
			scom.Parameters.Add("@lunchStartTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lunchDurationMins", SqlDbType.Int,4);
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
			scom.Parameters["@shift_ID"].Value = shift_ID;
			scom.Parameters["@shift_Name"].Value = shift_Name;
			scom.Parameters["@shift_Remarks"].Value = shift_Remarks;
			scom.Parameters["@shiftType"].Value = shiftType;
			scom.Parameters["@shiftStartTime"].Value = shiftStartTime;
			scom.Parameters["@shiftMinutes"].Value = shiftMinutes;
			scom.Parameters["@shiftMinutesMin"].Value = shiftMinutesMin;
			scom.Parameters["@nextShiftMinutes"].Value = nextShiftMinutes;
			scom.Parameters["@shiftBaseRate"].Value = shiftBaseRate;
			scom.Parameters["@shiftGracePeriod"].Value = shiftGracePeriod;
			scom.Parameters["@isSundaySpecialWH"].Value = isSundaySpecialWH;
			scom.Parameters["@shiftMinutes_Sunday"].Value = shiftMinutes_Sunday;
			scom.Parameters["@shiftMinutesMin_Sunday"].Value = shiftMinutesMin_Sunday;
			scom.Parameters["@nextShiftMinutes_Sunday"].Value = nextShiftMinutes_Sunday;
			scom.Parameters["@shiftBaseRate_Sunday"].Value = shiftBaseRate_Sunday;
			scom.Parameters["@shiftGracePeriod_Sunday"].Value = shiftGracePeriod_Sunday;
			scom.Parameters["@bSpecialParameter1_Sunday"].Value = bSpecialParameter1_Sunday;
			scom.Parameters["@bSpecialParameter2_Sunday"].Value = bSpecialParameter2_Sunday;
			scom.Parameters["@isMondaySpecialWH"].Value = isMondaySpecialWH;
			scom.Parameters["@shiftMinutes_Monday"].Value = shiftMinutes_Monday;
			scom.Parameters["@shiftMinutesMin_Monday"].Value = shiftMinutesMin_Monday;
			scom.Parameters["@shiftBaseRate_Monday"].Value = shiftBaseRate_Monday;
			scom.Parameters["@nextShiftMinutes_Monday"].Value = nextShiftMinutes_Monday;
			scom.Parameters["@shiftGracePeriod_Monday"].Value = shiftGracePeriod_Monday;
			scom.Parameters["@bSpecialParameter1_Monday"].Value = bSpecialParameter1_Monday;
			scom.Parameters["@bSpecialParameter2_Monday"].Value = bSpecialParameter2_Monday;
			scom.Parameters["@isTuesdaySpecialWH"].Value = isTuesdaySpecialWH;
			scom.Parameters["@shiftMinutes_Tuesday"].Value = shiftMinutes_Tuesday;
			scom.Parameters["@shiftMinutesMin_Tuesday"].Value = shiftMinutesMin_Tuesday;
			scom.Parameters["@nextShiftMinutes_Tuesday"].Value = nextShiftMinutes_Tuesday;
			scom.Parameters["@shiftBaseRate_Tuesday"].Value = shiftBaseRate_Tuesday;
			scom.Parameters["@shiftGracePeriod_Tuesday"].Value = shiftGracePeriod_Tuesday;
			scom.Parameters["@bSpecialParameter1_Tuesday"].Value = bSpecialParameter1_Tuesday;
			scom.Parameters["@bSpecialParameter2_Tuesday"].Value = bSpecialParameter2_Tuesday;
			scom.Parameters["@isWednesdaySpecialWH"].Value = isWednesdaySpecialWH;
			scom.Parameters["@shiftMinutes_Wednesday"].Value = shiftMinutes_Wednesday;
			scom.Parameters["@shiftMinutesMin_Wednesday"].Value = shiftMinutesMin_Wednesday;
			scom.Parameters["@nextShiftMinutes_Wednesday"].Value = nextShiftMinutes_Wednesday;
			scom.Parameters["@shiftBaseRate_Wednesday"].Value = shiftBaseRate_Wednesday;
			scom.Parameters["@shiftGracePeriod_Wednesday"].Value = shiftGracePeriod_Wednesday;
			scom.Parameters["@bSpecialParameter1_Wednesday"].Value = bSpecialParameter1_Wednesday;
			scom.Parameters["@bSpecialParameter2_Wednesday"].Value = bSpecialParameter2_Wednesday;
			scom.Parameters["@isThursdaySpecialWH"].Value = isThursdaySpecialWH;
			scom.Parameters["@shiftMinutes_Thursday"].Value = shiftMinutes_Thursday;
			scom.Parameters["@shiftMinutesMin_Thursday"].Value = shiftMinutesMin_Thursday;
			scom.Parameters["@nextShiftMinutes_Thursday"].Value = nextShiftMinutes_Thursday;
			scom.Parameters["@shiftBaseRate_Thursday"].Value = shiftBaseRate_Thursday;
			scom.Parameters["@shiftGracePeriod_Thursday"].Value = shiftGracePeriod_Thursday;
			scom.Parameters["@bSpecialParameter1_Thursday"].Value = bSpecialParameter1_Thursday;
			scom.Parameters["@bSpecialParameter2_Thursday"].Value = bSpecialParameter2_Thursday;
			scom.Parameters["@isFridaySpecialWH"].Value = isFridaySpecialWH;
			scom.Parameters["@shiftMinutes_Friday"].Value = shiftMinutes_Friday;
			scom.Parameters["@shiftMinutesMin_Friday"].Value = shiftMinutesMin_Friday;
			scom.Parameters["@nextShiftMinutes_Friday"].Value = nextShiftMinutes_Friday;
			scom.Parameters["@shiftBaseRate_Friday"].Value = shiftBaseRate_Friday;
			scom.Parameters["@shiftGracePeriod_Friday"].Value = shiftGracePeriod_Friday;
			scom.Parameters["@bSpecialParameter1_Friday"].Value = bSpecialParameter1_Friday;
			scom.Parameters["@bSpecialParameter2_Friday"].Value = bSpecialParameter2_Friday;
			scom.Parameters["@isSaturdaySpecialWH"].Value = isSaturdaySpecialWH;
			scom.Parameters["@shiftMinutes_Saturday"].Value = shiftMinutes_Saturday;
			scom.Parameters["@shiftMinutesMin_Saturday"].Value = shiftMinutesMin_Saturday;
			scom.Parameters["@nextShiftMinutes_Saturday"].Value = nextShiftMinutes_Saturday;
			scom.Parameters["@shiftBaseRate_Saturday"].Value = shiftBaseRate_Saturday;
			scom.Parameters["@shiftGracePeriod_Saturday"].Value = shiftGracePeriod_Saturday;
			scom.Parameters["@bSpecialParameter1_Saturday"].Value = bSpecialParameter1_Saturday;
			scom.Parameters["@bSpecialParameter2_Saturday"].Value = bSpecialParameter2_Saturday;
			scom.Parameters["@isOT_Applicable"].Value = isOT_Applicable;
			scom.Parameters["@IsEarlyOtApplicable"].Value = isEarlyOtApplicable;
			scom.Parameters["@shift_OTRoundMode"].Value = shift_OTRoundMode;
			scom.Parameters["@shift_OTRoundMinutes"].Value = shift_OTRoundMinutes;
			scom.Parameters["@shift_OTRate"].Value = shift_OTRate;
			scom.Parameters["@shift_OTGracePeroiod"].Value = shift_OTGracePeroiod;
			scom.Parameters["@shift_EarlyOTGracePeroiod"].Value = shift_EarlyOTGracePeroiod;
			scom.Parameters["@shift_OTMinuteMin"].Value = shift_OTMinuteMin;
			scom.Parameters["@shift_OTMinuteMax"].Value = shift_OTMinuteMax;
			scom.Parameters["@isWeekdaySpecialOT"].Value = isWeekdaySpecialOT;
			scom.Parameters["@shift_OTRate_Weekday"].Value = shift_OTRate_Weekday;
			scom.Parameters["@shift_OTGracePeroiod_Weekday"].Value = shift_OTGracePeroiod_Weekday;
			scom.Parameters["@shift_OTMinuteMin_Weekday"].Value = shift_OTMinuteMin_Weekday;
			scom.Parameters["@shift_OTMinuteMax_Weekday"].Value = shift_OTMinuteMax_Weekday;
			scom.Parameters["@isOTLunchDeduction_Weekday"].Value = isOTLunchDeduction_Weekday;
			scom.Parameters["@isSaturdaySpecialOT"].Value = isSaturdaySpecialOT;
			scom.Parameters["@shift_OTRate_Saturday"].Value = shift_OTRate_Saturday;
			scom.Parameters["@shift_OTGracePeroiod_Saturday"].Value = shift_OTGracePeroiod_Saturday;
			scom.Parameters["@shift_OTMinuteMin_Saturday"].Value = shift_OTMinuteMin_Saturday;
			scom.Parameters["@shift_OTMinuteMax_Saturday"].Value = shift_OTMinuteMax_Saturday;
			scom.Parameters["@isOTLunchDeduction_Saturday"].Value = isOTLunchDeduction_Saturday;
			scom.Parameters["@isSundaySpecialOT"].Value = isSundaySpecialOT;
			scom.Parameters["@shift_OTRate_Sunday"].Value = shift_OTRate_Sunday;
			scom.Parameters["@shift_OTGracePeroiod_Sunday"].Value = shift_OTGracePeroiod_Sunday;
			scom.Parameters["@shift_OTMinuteMin_Sunday"].Value = shift_OTMinuteMin_Sunday;
			scom.Parameters["@shift_OTMinuteMax_Sunday"].Value = shift_OTMinuteMax_Sunday;
			scom.Parameters["@isOTLunchDeduction_Sundy"].Value = isOTLunchDeduction_Sundy;
			scom.Parameters["@isPoyadaySpecialOT"].Value = isPoyadaySpecialOT;
			scom.Parameters["@shift_OTRate_Poyaday"].Value = shift_OTRate_Poyaday;
			scom.Parameters["@shift_OTGracePeroiod_Poyaday"].Value = shift_OTGracePeroiod_Poyaday;
			scom.Parameters["@shift_OTMinuteMin_Poyaday"].Value = shift_OTMinuteMin_Poyaday;
			scom.Parameters["@shift_OTMinuteMax_Poyaday"].Value = shift_OTMinuteMax_Poyaday;
			scom.Parameters["@isOTLunchDeduction_Poyaday"].Value = isOTLunchDeduction_Poyaday;
			scom.Parameters["@isCompanyHolidaySpecialOT"].Value = isCompanyHolidaySpecialOT;
			scom.Parameters["@shift_OTRate_CompanyHoliday"].Value = shift_OTRate_CompanyHoliday;
			scom.Parameters["@shift_OTGracePeroiod_CompanyHoliday"].Value = shift_OTGracePeroiod_CompanyHoliday;
			scom.Parameters["@shift_OTMinuteMin_CompanyHoliday"].Value = shift_OTMinuteMin_CompanyHoliday;
			scom.Parameters["@shift_OTMinuteMax_CompanyHoliday"].Value = shift_OTMinuteMax_CompanyHoliday;
			scom.Parameters["@isOTLunchDeduction_CompanyHoliday"].Value = isOTLunchDeduction_CompanyHoliday;
			scom.Parameters["@shift_Status_Effective_Date"].Value = shift_Status_Effective_Date;
			scom.Parameters["@shift_Status_ExpireDate"].Value = shift_Status_ExpireDate;
			scom.Parameters["@shift_Status"].Value = shift_Status;
			scom.Parameters["@lunchStartTime"].Value = lunchStartTime;
			scom.Parameters["@lunchDurationMins"].Value = lunchDurationMins;
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
		/// Deletes a record from the tbl_tasShiftMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasShiftMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@shift_ID"].Value = shift_ID;
 
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasShiftMaster table.
		/// </summary>
		public static tbl_tasShiftMaster Select(string shift_ID_Incoming, string company_ID_Incoming, string companyBranch_ID_Incoming){

			tbl_tasShiftMaster tbl_tasShiftMasterins = new tbl_tasShiftMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasShiftMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@shift_ID"].Value = shift_ID_Incoming;
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasShiftMasterins = Maketbl_tasShiftMaster(dataReader);
				} else {
					tbl_tasShiftMasterins = null;
				}
			}
			scon.Close();
			return tbl_tasShiftMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasShiftMaster table.
		/// </summary>
		public static List<tbl_tasShiftMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasShiftMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasShiftMaster> tbl_tasShiftMasterList = new List<tbl_tasShiftMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasShiftMaster tbl_tasShiftMaster = Maketbl_tasShiftMaster(dataReader);
					tbl_tasShiftMasterList.Add(tbl_tasShiftMaster);
				}
			}
			scon.Close();
			return tbl_tasShiftMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasShiftMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasShiftMaster Maketbl_tasShiftMaster(SqlDataReader dataReader) {
			tbl_tasShiftMaster tbl_tasShiftMaster = new tbl_tasShiftMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasShiftMaster.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasShiftMaster.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasShiftMaster.Shift_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasShiftMaster.Shift_Name = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasShiftMaster.Shift_Remarks = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasShiftMaster.ShiftType = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasShiftMaster.ShiftStartTime = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasShiftMaster.ShiftMinutes = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasShiftMaster.ShiftMinutesMin = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasShiftMaster.NextShiftMinutes = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasShiftMaster.ShiftBaseRate = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasShiftMaster.ShiftGracePeriod = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasShiftMaster.IsSundaySpecialWH = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasShiftMaster.ShiftMinutes_Sunday = dataReader.GetInt32(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasShiftMaster.ShiftMinutesMin_Sunday = dataReader.GetInt32(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_tasShiftMaster.NextShiftMinutes_Sunday = dataReader.GetInt32(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_tasShiftMaster.ShiftBaseRate_Sunday = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_tasShiftMaster.ShiftGracePeriod_Sunday = dataReader.GetInt32(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_tasShiftMaster.BSpecialParameter1_Sunday = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_tasShiftMaster.BSpecialParameter2_Sunday = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_tasShiftMaster.IsMondaySpecialWH = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_tasShiftMaster.ShiftMinutes_Monday = dataReader.GetInt32(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_tasShiftMaster.ShiftMinutesMin_Monday = dataReader.GetInt32(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_tasShiftMaster.ShiftBaseRate_Monday = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_tasShiftMaster.NextShiftMinutes_Monday = dataReader.GetInt32(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_tasShiftMaster.ShiftGracePeriod_Monday = dataReader.GetInt32(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_tasShiftMaster.BSpecialParameter1_Monday = dataReader.GetBoolean(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_tasShiftMaster.BSpecialParameter2_Monday = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_tasShiftMaster.IsTuesdaySpecialWH = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_tasShiftMaster.ShiftMinutes_Tuesday = dataReader.GetInt32(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_tasShiftMaster.ShiftMinutesMin_Tuesday = dataReader.GetInt32(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_tasShiftMaster.NextShiftMinutes_Tuesday = dataReader.GetInt32(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_tasShiftMaster.ShiftBaseRate_Tuesday = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_tasShiftMaster.ShiftGracePeriod_Tuesday = dataReader.GetInt32(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_tasShiftMaster.BSpecialParameter1_Tuesday = dataReader.GetBoolean(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_tasShiftMaster.BSpecialParameter2_Tuesday = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_tasShiftMaster.IsWednesdaySpecialWH = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_tasShiftMaster.ShiftMinutes_Wednesday = dataReader.GetInt32(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_tasShiftMaster.ShiftMinutesMin_Wednesday = dataReader.GetInt32(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_tasShiftMaster.NextShiftMinutes_Wednesday = dataReader.GetInt32(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_tasShiftMaster.ShiftBaseRate_Wednesday = dataReader.GetDecimal(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_tasShiftMaster.ShiftGracePeriod_Wednesday = dataReader.GetInt32(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_tasShiftMaster.BSpecialParameter1_Wednesday = dataReader.GetBoolean(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_tasShiftMaster.BSpecialParameter2_Wednesday = dataReader.GetBoolean(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_tasShiftMaster.IsThursdaySpecialWH = dataReader.GetBoolean(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_tasShiftMaster.ShiftMinutes_Thursday = dataReader.GetInt32(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_tasShiftMaster.ShiftMinutesMin_Thursday = dataReader.GetInt32(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_tasShiftMaster.NextShiftMinutes_Thursday = dataReader.GetInt32(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_tasShiftMaster.ShiftBaseRate_Thursday = dataReader.GetDecimal(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_tasShiftMaster.ShiftGracePeriod_Thursday = dataReader.GetInt32(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_tasShiftMaster.BSpecialParameter1_Thursday = dataReader.GetBoolean(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_tasShiftMaster.BSpecialParameter2_Thursday = dataReader.GetBoolean(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_tasShiftMaster.IsFridaySpecialWH = dataReader.GetBoolean(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_tasShiftMaster.ShiftMinutes_Friday = dataReader.GetInt32(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_tasShiftMaster.ShiftMinutesMin_Friday = dataReader.GetInt32(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_tasShiftMaster.NextShiftMinutes_Friday = dataReader.GetInt32(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_tasShiftMaster.ShiftBaseRate_Friday = dataReader.GetDecimal(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_tasShiftMaster.ShiftGracePeriod_Friday = dataReader.GetInt32(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_tasShiftMaster.BSpecialParameter1_Friday = dataReader.GetBoolean(58);
			}
			if (dataReader.IsDBNull(59) == false) {
				tbl_tasShiftMaster.BSpecialParameter2_Friday = dataReader.GetBoolean(59);
			}
			if (dataReader.IsDBNull(60) == false) {
				tbl_tasShiftMaster.IsSaturdaySpecialWH = dataReader.GetBoolean(60);
			}
			if (dataReader.IsDBNull(61) == false) {
				tbl_tasShiftMaster.ShiftMinutes_Saturday = dataReader.GetInt32(61);
			}
			if (dataReader.IsDBNull(62) == false) {
				tbl_tasShiftMaster.ShiftMinutesMin_Saturday = dataReader.GetInt32(62);
			}
			if (dataReader.IsDBNull(63) == false) {
				tbl_tasShiftMaster.NextShiftMinutes_Saturday = dataReader.GetInt32(63);
			}
			if (dataReader.IsDBNull(64) == false) {
				tbl_tasShiftMaster.ShiftBaseRate_Saturday = dataReader.GetDecimal(64);
			}
			if (dataReader.IsDBNull(65) == false) {
				tbl_tasShiftMaster.ShiftGracePeriod_Saturday = dataReader.GetInt32(65);
			}
			if (dataReader.IsDBNull(66) == false) {
				tbl_tasShiftMaster.BSpecialParameter1_Saturday = dataReader.GetBoolean(66);
			}
			if (dataReader.IsDBNull(67) == false) {
				tbl_tasShiftMaster.BSpecialParameter2_Saturday = dataReader.GetBoolean(67);
			}
			if (dataReader.IsDBNull(68) == false) {
				tbl_tasShiftMaster.IsOT_Applicable = dataReader.GetBoolean(68);
			}
			if (dataReader.IsDBNull(69) == false) {
				tbl_tasShiftMaster.IsEarlyOtApplicable = dataReader.GetBoolean(69);
			}
			if (dataReader.IsDBNull(70) == false) {
				tbl_tasShiftMaster.Shift_OTRoundMode = dataReader.GetInt32(70);
			}
			if (dataReader.IsDBNull(71) == false) {
				tbl_tasShiftMaster.Shift_OTRoundMinutes = dataReader.GetInt32(71);
			}
			if (dataReader.IsDBNull(72) == false) {
				tbl_tasShiftMaster.Shift_OTRate = dataReader.GetDecimal(72);
			}
			if (dataReader.IsDBNull(73) == false) {
				tbl_tasShiftMaster.Shift_OTGracePeroiod = dataReader.GetInt32(73);
			}
			if (dataReader.IsDBNull(74) == false) {
				tbl_tasShiftMaster.Shift_EarlyOTGracePeroiod = dataReader.GetInt32(74);
			}
			if (dataReader.IsDBNull(75) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMin = dataReader.GetInt32(75);
			}
			if (dataReader.IsDBNull(76) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMax = dataReader.GetInt32(76);
			}
			if (dataReader.IsDBNull(77) == false) {
				tbl_tasShiftMaster.IsWeekdaySpecialOT = dataReader.GetBoolean(77);
			}
			if (dataReader.IsDBNull(78) == false) {
				tbl_tasShiftMaster.Shift_OTRate_Weekday = dataReader.GetDecimal(78);
			}
			if (dataReader.IsDBNull(79) == false) {
				tbl_tasShiftMaster.Shift_OTGracePeroiod_Weekday = dataReader.GetInt32(79);
			}
			if (dataReader.IsDBNull(80) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMin_Weekday = dataReader.GetInt32(80);
			}
			if (dataReader.IsDBNull(81) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMax_Weekday = dataReader.GetInt32(81);
			}
			if (dataReader.IsDBNull(82) == false) {
				tbl_tasShiftMaster.IsOTLunchDeduction_Weekday = dataReader.GetBoolean(82);
			}
			if (dataReader.IsDBNull(83) == false) {
				tbl_tasShiftMaster.IsSaturdaySpecialOT = dataReader.GetBoolean(83);
			}
			if (dataReader.IsDBNull(84) == false) {
				tbl_tasShiftMaster.Shift_OTRate_Saturday = dataReader.GetDecimal(84);
			}
			if (dataReader.IsDBNull(85) == false) {
				tbl_tasShiftMaster.Shift_OTGracePeroiod_Saturday = dataReader.GetInt32(85);
			}
			if (dataReader.IsDBNull(86) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMin_Saturday = dataReader.GetInt32(86);
			}
			if (dataReader.IsDBNull(87) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMax_Saturday = dataReader.GetInt32(87);
			}
			if (dataReader.IsDBNull(88) == false) {
				tbl_tasShiftMaster.IsOTLunchDeduction_Saturday = dataReader.GetBoolean(88);
			}
			if (dataReader.IsDBNull(89) == false) {
				tbl_tasShiftMaster.IsSundaySpecialOT = dataReader.GetBoolean(89);
			}
			if (dataReader.IsDBNull(90) == false) {
				tbl_tasShiftMaster.Shift_OTRate_Sunday = dataReader.GetDecimal(90);
			}
			if (dataReader.IsDBNull(91) == false) {
				tbl_tasShiftMaster.Shift_OTGracePeroiod_Sunday = dataReader.GetInt32(91);
			}
			if (dataReader.IsDBNull(92) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMin_Sunday = dataReader.GetInt32(92);
			}
			if (dataReader.IsDBNull(93) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMax_Sunday = dataReader.GetInt32(93);
			}
			if (dataReader.IsDBNull(94) == false) {
				tbl_tasShiftMaster.IsOTLunchDeduction_Sundy = dataReader.GetBoolean(94);
			}
			if (dataReader.IsDBNull(95) == false) {
				tbl_tasShiftMaster.IsPoyadaySpecialOT = dataReader.GetBoolean(95);
			}
			if (dataReader.IsDBNull(96) == false) {
				tbl_tasShiftMaster.Shift_OTRate_Poyaday = dataReader.GetDecimal(96);
			}
			if (dataReader.IsDBNull(97) == false) {
				tbl_tasShiftMaster.Shift_OTGracePeroiod_Poyaday = dataReader.GetInt32(97);
			}
			if (dataReader.IsDBNull(98) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMin_Poyaday = dataReader.GetInt32(98);
			}
			if (dataReader.IsDBNull(99) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMax_Poyaday = dataReader.GetInt32(99);
			}
			if (dataReader.IsDBNull(100) == false) {
				tbl_tasShiftMaster.IsOTLunchDeduction_Poyaday = dataReader.GetBoolean(100);
			}
			if (dataReader.IsDBNull(101) == false) {
				tbl_tasShiftMaster.IsCompanyHolidaySpecialOT = dataReader.GetBoolean(101);
			}
			if (dataReader.IsDBNull(102) == false) {
				tbl_tasShiftMaster.Shift_OTRate_CompanyHoliday = dataReader.GetDecimal(102);
			}
			if (dataReader.IsDBNull(103) == false) {
				tbl_tasShiftMaster.Shift_OTGracePeroiod_CompanyHoliday = dataReader.GetInt32(103);
			}
			if (dataReader.IsDBNull(104) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMin_CompanyHoliday = dataReader.GetInt32(104);
			}
			if (dataReader.IsDBNull(105) == false) {
				tbl_tasShiftMaster.Shift_OTMinuteMax_CompanyHoliday = dataReader.GetInt32(105);
			}
			if (dataReader.IsDBNull(106) == false) {
				tbl_tasShiftMaster.IsOTLunchDeduction_CompanyHoliday = dataReader.GetBoolean(106);
			}
			if (dataReader.IsDBNull(107) == false) {
				tbl_tasShiftMaster.Shift_Status_Effective_Date = dataReader.GetDateTime(107);
			}
			if (dataReader.IsDBNull(108) == false) {
				tbl_tasShiftMaster.Shift_Status_ExpireDate = dataReader.GetDateTime(108);
			}
			if (dataReader.IsDBNull(109) == false) {
				tbl_tasShiftMaster.Shift_Status = dataReader.GetBoolean(109);
			}
			if (dataReader.IsDBNull(110) == false) {
				tbl_tasShiftMaster.LunchStartTime = dataReader.GetDateTime(110);
			}
			if (dataReader.IsDBNull(111) == false) {
				tbl_tasShiftMaster.LunchDurationMins = dataReader.GetInt32(111);
			}
			if (dataReader.IsDBNull(112) == false) {
				tbl_tasShiftMaster.IsCanceled = dataReader.GetBoolean(112);
			}
			if (dataReader.IsDBNull(113) == false) {
				tbl_tasShiftMaster.UserID_Created = dataReader.GetString(113);
			}
			if (dataReader.IsDBNull(114) == false) {
				tbl_tasShiftMaster.UserID_Modified = dataReader.GetString(114);
			}
			if (dataReader.IsDBNull(115) == false) {
				tbl_tasShiftMaster.UserID_Canceled = dataReader.GetString(115);
			}
			if (dataReader.IsDBNull(116) == false) {
				tbl_tasShiftMaster.TerminalID_Created = dataReader.GetString(116);
			}
			if (dataReader.IsDBNull(117) == false) {
				tbl_tasShiftMaster.TerminalID_Modified = dataReader.GetString(117);
			}
			if (dataReader.IsDBNull(118) == false) {
				tbl_tasShiftMaster.TerminalID_Canceled = dataReader.GetString(118);
			}
			if (dataReader.IsDBNull(119) == false) {
				tbl_tasShiftMaster.Date_Created = dataReader.GetDateTime(119);
			}
			if (dataReader.IsDBNull(120) == false) {
				tbl_tasShiftMaster.Date_Modified = dataReader.GetDateTime(120);
			}
			if (dataReader.IsDBNull(121) == false) {
				tbl_tasShiftMaster.Date_Canceled = dataReader.GetDateTime(121);
			}

			return tbl_tasShiftMaster;
		}
		/// <summary>
		/// This makes tbl_tasShiftMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasShiftMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasShiftMaster  tbl_tasShiftMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_shift_ID = new DataColumn("shift_ID" , typeof(string));
			DataColumn col_shift_Name = new DataColumn("shift_Name" , typeof(string));
			DataColumn col_shift_Remarks = new DataColumn("shift_Remarks" , typeof(string));
			DataColumn col_shiftType = new DataColumn("shiftType" , typeof(int));
			DataColumn col_shiftStartTime = new DataColumn("shiftStartTime" , typeof(DateTime));
			DataColumn col_shiftMinutes = new DataColumn("shiftMinutes" , typeof(int));
			DataColumn col_shiftMinutesMin = new DataColumn("shiftMinutesMin" , typeof(int));
			DataColumn col_nextShiftMinutes = new DataColumn("nextShiftMinutes" , typeof(int));
			DataColumn col_shiftBaseRate = new DataColumn("shiftBaseRate" , typeof(decimal));
			DataColumn col_shiftGracePeriod = new DataColumn("shiftGracePeriod" , typeof(int));
			DataColumn col_isSundaySpecialWH = new DataColumn("isSundaySpecialWH" , typeof(bool));
			DataColumn col_shiftMinutes_Sunday = new DataColumn("shiftMinutes_Sunday" , typeof(int));
			DataColumn col_shiftMinutesMin_Sunday = new DataColumn("shiftMinutesMin_Sunday" , typeof(int));
			DataColumn col_nextShiftMinutes_Sunday = new DataColumn("nextShiftMinutes_Sunday" , typeof(int));
			DataColumn col_shiftBaseRate_Sunday = new DataColumn("shiftBaseRate_Sunday" , typeof(decimal));
			DataColumn col_shiftGracePeriod_Sunday = new DataColumn("shiftGracePeriod_Sunday" , typeof(int));
			DataColumn col_bSpecialParameter1_Sunday = new DataColumn("bSpecialParameter1_Sunday" , typeof(bool));
			DataColumn col_bSpecialParameter2_Sunday = new DataColumn("bSpecialParameter2_Sunday" , typeof(bool));
			DataColumn col_isMondaySpecialWH = new DataColumn("isMondaySpecialWH" , typeof(bool));
			DataColumn col_shiftMinutes_Monday = new DataColumn("shiftMinutes_Monday" , typeof(int));
			DataColumn col_shiftMinutesMin_Monday = new DataColumn("shiftMinutesMin_Monday" , typeof(int));
			DataColumn col_shiftBaseRate_Monday = new DataColumn("shiftBaseRate_Monday" , typeof(decimal));
			DataColumn col_nextShiftMinutes_Monday = new DataColumn("nextShiftMinutes_Monday" , typeof(int));
			DataColumn col_shiftGracePeriod_Monday = new DataColumn("shiftGracePeriod_Monday" , typeof(int));
			DataColumn col_bSpecialParameter1_Monday = new DataColumn("bSpecialParameter1_Monday" , typeof(bool));
			DataColumn col_bSpecialParameter2_Monday = new DataColumn("bSpecialParameter2_Monday" , typeof(bool));
			DataColumn col_isTuesdaySpecialWH = new DataColumn("isTuesdaySpecialWH" , typeof(bool));
			DataColumn col_shiftMinutes_Tuesday = new DataColumn("shiftMinutes_Tuesday" , typeof(int));
			DataColumn col_shiftMinutesMin_Tuesday = new DataColumn("shiftMinutesMin_Tuesday" , typeof(int));
			DataColumn col_nextShiftMinutes_Tuesday = new DataColumn("nextShiftMinutes_Tuesday" , typeof(int));
			DataColumn col_shiftBaseRate_Tuesday = new DataColumn("shiftBaseRate_Tuesday" , typeof(decimal));
			DataColumn col_shiftGracePeriod_Tuesday = new DataColumn("shiftGracePeriod_Tuesday" , typeof(int));
			DataColumn col_bSpecialParameter1_Tuesday = new DataColumn("bSpecialParameter1_Tuesday" , typeof(bool));
			DataColumn col_bSpecialParameter2_Tuesday = new DataColumn("bSpecialParameter2_Tuesday" , typeof(bool));
			DataColumn col_isWednesdaySpecialWH = new DataColumn("isWednesdaySpecialWH" , typeof(bool));
			DataColumn col_shiftMinutes_Wednesday = new DataColumn("shiftMinutes_Wednesday" , typeof(int));
			DataColumn col_shiftMinutesMin_Wednesday = new DataColumn("shiftMinutesMin_Wednesday" , typeof(int));
			DataColumn col_nextShiftMinutes_Wednesday = new DataColumn("nextShiftMinutes_Wednesday" , typeof(int));
			DataColumn col_shiftBaseRate_Wednesday = new DataColumn("shiftBaseRate_Wednesday" , typeof(decimal));
			DataColumn col_shiftGracePeriod_Wednesday = new DataColumn("shiftGracePeriod_Wednesday" , typeof(int));
			DataColumn col_bSpecialParameter1_Wednesday = new DataColumn("bSpecialParameter1_Wednesday" , typeof(bool));
			DataColumn col_bSpecialParameter2_Wednesday = new DataColumn("bSpecialParameter2_Wednesday" , typeof(bool));
			DataColumn col_isThursdaySpecialWH = new DataColumn("isThursdaySpecialWH" , typeof(bool));
			DataColumn col_shiftMinutes_Thursday = new DataColumn("shiftMinutes_Thursday" , typeof(int));
			DataColumn col_shiftMinutesMin_Thursday = new DataColumn("shiftMinutesMin_Thursday" , typeof(int));
			DataColumn col_nextShiftMinutes_Thursday = new DataColumn("nextShiftMinutes_Thursday" , typeof(int));
			DataColumn col_shiftBaseRate_Thursday = new DataColumn("shiftBaseRate_Thursday" , typeof(decimal));
			DataColumn col_shiftGracePeriod_Thursday = new DataColumn("shiftGracePeriod_Thursday" , typeof(int));
			DataColumn col_bSpecialParameter1_Thursday = new DataColumn("bSpecialParameter1_Thursday" , typeof(bool));
			DataColumn col_bSpecialParameter2_Thursday = new DataColumn("bSpecialParameter2_Thursday" , typeof(bool));
			DataColumn col_isFridaySpecialWH = new DataColumn("isFridaySpecialWH" , typeof(bool));
			DataColumn col_shiftMinutes_Friday = new DataColumn("shiftMinutes_Friday" , typeof(int));
			DataColumn col_shiftMinutesMin_Friday = new DataColumn("shiftMinutesMin_Friday" , typeof(int));
			DataColumn col_nextShiftMinutes_Friday = new DataColumn("nextShiftMinutes_Friday" , typeof(int));
			DataColumn col_shiftBaseRate_Friday = new DataColumn("shiftBaseRate_Friday" , typeof(decimal));
			DataColumn col_shiftGracePeriod_Friday = new DataColumn("shiftGracePeriod_Friday" , typeof(int));
			DataColumn col_bSpecialParameter1_Friday = new DataColumn("bSpecialParameter1_Friday" , typeof(bool));
			DataColumn col_bSpecialParameter2_Friday = new DataColumn("bSpecialParameter2_Friday" , typeof(bool));
			DataColumn col_isSaturdaySpecialWH = new DataColumn("isSaturdaySpecialWH" , typeof(bool));
			DataColumn col_shiftMinutes_Saturday = new DataColumn("shiftMinutes_Saturday" , typeof(int));
			DataColumn col_shiftMinutesMin_Saturday = new DataColumn("shiftMinutesMin_Saturday" , typeof(int));
			DataColumn col_nextShiftMinutes_Saturday = new DataColumn("nextShiftMinutes_Saturday" , typeof(int));
			DataColumn col_shiftBaseRate_Saturday = new DataColumn("shiftBaseRate_Saturday" , typeof(decimal));
			DataColumn col_shiftGracePeriod_Saturday = new DataColumn("shiftGracePeriod_Saturday" , typeof(int));
			DataColumn col_bSpecialParameter1_Saturday = new DataColumn("bSpecialParameter1_Saturday" , typeof(bool));
			DataColumn col_bSpecialParameter2_Saturday = new DataColumn("bSpecialParameter2_Saturday" , typeof(bool));
			DataColumn col_isOT_Applicable = new DataColumn("isOT_Applicable" , typeof(bool));
			DataColumn col_IsEarlyOtApplicable = new DataColumn("IsEarlyOtApplicable" , typeof(bool));
			DataColumn col_shift_OTRoundMode = new DataColumn("shift_OTRoundMode" , typeof(int));
			DataColumn col_shift_OTRoundMinutes = new DataColumn("shift_OTRoundMinutes" , typeof(int));
			DataColumn col_shift_OTRate = new DataColumn("shift_OTRate" , typeof(decimal));
			DataColumn col_shift_OTGracePeroiod = new DataColumn("shift_OTGracePeroiod" , typeof(int));
			DataColumn col_shift_EarlyOTGracePeroiod = new DataColumn("shift_EarlyOTGracePeroiod" , typeof(int));
			DataColumn col_shift_OTMinuteMin = new DataColumn("shift_OTMinuteMin" , typeof(int));
			DataColumn col_shift_OTMinuteMax = new DataColumn("shift_OTMinuteMax" , typeof(int));
			DataColumn col_isWeekdaySpecialOT = new DataColumn("isWeekdaySpecialOT" , typeof(bool));
			DataColumn col_shift_OTRate_Weekday = new DataColumn("shift_OTRate_Weekday" , typeof(decimal));
			DataColumn col_shift_OTGracePeroiod_Weekday = new DataColumn("shift_OTGracePeroiod_Weekday" , typeof(int));
			DataColumn col_shift_OTMinuteMin_Weekday = new DataColumn("shift_OTMinuteMin_Weekday" , typeof(int));
			DataColumn col_shift_OTMinuteMax_Weekday = new DataColumn("shift_OTMinuteMax_Weekday" , typeof(int));
			DataColumn col_isOTLunchDeduction_Weekday = new DataColumn("isOTLunchDeduction_Weekday" , typeof(bool));
			DataColumn col_isSaturdaySpecialOT = new DataColumn("isSaturdaySpecialOT" , typeof(bool));
			DataColumn col_shift_OTRate_Saturday = new DataColumn("shift_OTRate_Saturday" , typeof(decimal));
			DataColumn col_shift_OTGracePeroiod_Saturday = new DataColumn("shift_OTGracePeroiod_Saturday" , typeof(int));
			DataColumn col_shift_OTMinuteMin_Saturday = new DataColumn("shift_OTMinuteMin_Saturday" , typeof(int));
			DataColumn col_shift_OTMinuteMax_Saturday = new DataColumn("shift_OTMinuteMax_Saturday" , typeof(int));
			DataColumn col_isOTLunchDeduction_Saturday = new DataColumn("isOTLunchDeduction_Saturday" , typeof(bool));
			DataColumn col_isSundaySpecialOT = new DataColumn("isSundaySpecialOT" , typeof(bool));
			DataColumn col_shift_OTRate_Sunday = new DataColumn("shift_OTRate_Sunday" , typeof(decimal));
			DataColumn col_shift_OTGracePeroiod_Sunday = new DataColumn("shift_OTGracePeroiod_Sunday" , typeof(int));
			DataColumn col_shift_OTMinuteMin_Sunday = new DataColumn("shift_OTMinuteMin_Sunday" , typeof(int));
			DataColumn col_shift_OTMinuteMax_Sunday = new DataColumn("shift_OTMinuteMax_Sunday" , typeof(int));
			DataColumn col_isOTLunchDeduction_Sundy = new DataColumn("isOTLunchDeduction_Sundy" , typeof(bool));
			DataColumn col_isPoyadaySpecialOT = new DataColumn("isPoyadaySpecialOT" , typeof(bool));
			DataColumn col_shift_OTRate_Poyaday = new DataColumn("shift_OTRate_Poyaday" , typeof(decimal));
			DataColumn col_shift_OTGracePeroiod_Poyaday = new DataColumn("shift_OTGracePeroiod_Poyaday" , typeof(int));
			DataColumn col_shift_OTMinuteMin_Poyaday = new DataColumn("shift_OTMinuteMin_Poyaday" , typeof(int));
			DataColumn col_shift_OTMinuteMax_Poyaday = new DataColumn("shift_OTMinuteMax_Poyaday" , typeof(int));
			DataColumn col_isOTLunchDeduction_Poyaday = new DataColumn("isOTLunchDeduction_Poyaday" , typeof(bool));
			DataColumn col_isCompanyHolidaySpecialOT = new DataColumn("isCompanyHolidaySpecialOT" , typeof(bool));
			DataColumn col_shift_OTRate_CompanyHoliday = new DataColumn("shift_OTRate_CompanyHoliday" , typeof(decimal));
			DataColumn col_shift_OTGracePeroiod_CompanyHoliday = new DataColumn("shift_OTGracePeroiod_CompanyHoliday" , typeof(int));
			DataColumn col_shift_OTMinuteMin_CompanyHoliday = new DataColumn("shift_OTMinuteMin_CompanyHoliday" , typeof(int));
			DataColumn col_shift_OTMinuteMax_CompanyHoliday = new DataColumn("shift_OTMinuteMax_CompanyHoliday" , typeof(int));
			DataColumn col_isOTLunchDeduction_CompanyHoliday = new DataColumn("isOTLunchDeduction_CompanyHoliday" , typeof(bool));
			DataColumn col_shift_Status_Effective_Date = new DataColumn("shift_Status_Effective_Date" , typeof(DateTime));
			DataColumn col_shift_Status_ExpireDate = new DataColumn("shift_Status_ExpireDate" , typeof(DateTime));
			DataColumn col_shift_Status = new DataColumn("shift_Status" , typeof(bool));
			DataColumn col_lunchStartTime = new DataColumn("lunchStartTime" , typeof(DateTime));
			DataColumn col_lunchDurationMins = new DataColumn("lunchDurationMins" , typeof(int));
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
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_shift_ID,col_shift_Name,col_shift_Remarks,col_shiftType,col_shiftStartTime,col_shiftMinutes,col_shiftMinutesMin,col_nextShiftMinutes,col_shiftBaseRate,col_shiftGracePeriod,col_isSundaySpecialWH,col_shiftMinutes_Sunday,col_shiftMinutesMin_Sunday,col_nextShiftMinutes_Sunday,col_shiftBaseRate_Sunday,col_shiftGracePeriod_Sunday,col_bSpecialParameter1_Sunday,col_bSpecialParameter2_Sunday,col_isMondaySpecialWH,col_shiftMinutes_Monday,col_shiftMinutesMin_Monday,col_shiftBaseRate_Monday,col_nextShiftMinutes_Monday,col_shiftGracePeriod_Monday,col_bSpecialParameter1_Monday,col_bSpecialParameter2_Monday,col_isTuesdaySpecialWH,col_shiftMinutes_Tuesday,col_shiftMinutesMin_Tuesday,col_nextShiftMinutes_Tuesday,col_shiftBaseRate_Tuesday,col_shiftGracePeriod_Tuesday,col_bSpecialParameter1_Tuesday,col_bSpecialParameter2_Tuesday,col_isWednesdaySpecialWH,col_shiftMinutes_Wednesday,col_shiftMinutesMin_Wednesday,col_nextShiftMinutes_Wednesday,col_shiftBaseRate_Wednesday,col_shiftGracePeriod_Wednesday,col_bSpecialParameter1_Wednesday,col_bSpecialParameter2_Wednesday,col_isThursdaySpecialWH,col_shiftMinutes_Thursday,col_shiftMinutesMin_Thursday,col_nextShiftMinutes_Thursday,col_shiftBaseRate_Thursday,col_shiftGracePeriod_Thursday,col_bSpecialParameter1_Thursday,col_bSpecialParameter2_Thursday,col_isFridaySpecialWH,col_shiftMinutes_Friday,col_shiftMinutesMin_Friday,col_nextShiftMinutes_Friday,col_shiftBaseRate_Friday,col_shiftGracePeriod_Friday,col_bSpecialParameter1_Friday,col_bSpecialParameter2_Friday,col_isSaturdaySpecialWH,col_shiftMinutes_Saturday,col_shiftMinutesMin_Saturday,col_nextShiftMinutes_Saturday,col_shiftBaseRate_Saturday,col_shiftGracePeriod_Saturday,col_bSpecialParameter1_Saturday,col_bSpecialParameter2_Saturday,col_isOT_Applicable,col_IsEarlyOtApplicable,col_shift_OTRoundMode,col_shift_OTRoundMinutes,col_shift_OTRate,col_shift_OTGracePeroiod,col_shift_EarlyOTGracePeroiod,col_shift_OTMinuteMin,col_shift_OTMinuteMax,col_isWeekdaySpecialOT,col_shift_OTRate_Weekday,col_shift_OTGracePeroiod_Weekday,col_shift_OTMinuteMin_Weekday,col_shift_OTMinuteMax_Weekday,col_isOTLunchDeduction_Weekday,col_isSaturdaySpecialOT,col_shift_OTRate_Saturday,col_shift_OTGracePeroiod_Saturday,col_shift_OTMinuteMin_Saturday,col_shift_OTMinuteMax_Saturday,col_isOTLunchDeduction_Saturday,col_isSundaySpecialOT,col_shift_OTRate_Sunday,col_shift_OTGracePeroiod_Sunday,col_shift_OTMinuteMin_Sunday,col_shift_OTMinuteMax_Sunday,col_isOTLunchDeduction_Sundy,col_isPoyadaySpecialOT,col_shift_OTRate_Poyaday,col_shift_OTGracePeroiod_Poyaday,col_shift_OTMinuteMin_Poyaday,col_shift_OTMinuteMax_Poyaday,col_isOTLunchDeduction_Poyaday,col_isCompanyHolidaySpecialOT,col_shift_OTRate_CompanyHoliday,col_shift_OTGracePeroiod_CompanyHoliday,col_shift_OTMinuteMin_CompanyHoliday,col_shift_OTMinuteMax_CompanyHoliday,col_isOTLunchDeduction_CompanyHoliday,col_shift_Status_Effective_Date,col_shift_Status_ExpireDate,col_shift_Status,col_lunchStartTime,col_lunchDurationMins,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasShiftMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasShiftMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasShiftMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["shift_ID"] = user.shift_ID;
			drow["shift_Name"] = user.shift_Name;
			drow["shift_Remarks"] = user.shift_Remarks;
			drow["shiftType"] = user.shiftType;
			drow["shiftStartTime"] = user.shiftStartTime;
			drow["shiftMinutes"] = user.shiftMinutes;
			drow["shiftMinutesMin"] = user.shiftMinutesMin;
			drow["nextShiftMinutes"] = user.nextShiftMinutes;
			drow["shiftBaseRate"] = user.shiftBaseRate;
			drow["shiftGracePeriod"] = user.shiftGracePeriod;
			drow["isSundaySpecialWH"] = user.isSundaySpecialWH;
			drow["shiftMinutes_Sunday"] = user.shiftMinutes_Sunday;
			drow["shiftMinutesMin_Sunday"] = user.shiftMinutesMin_Sunday;
			drow["nextShiftMinutes_Sunday"] = user.nextShiftMinutes_Sunday;
			drow["shiftBaseRate_Sunday"] = user.shiftBaseRate_Sunday;
			drow["shiftGracePeriod_Sunday"] = user.shiftGracePeriod_Sunday;
			drow["bSpecialParameter1_Sunday"] = user.bSpecialParameter1_Sunday;
			drow["bSpecialParameter2_Sunday"] = user.bSpecialParameter2_Sunday;
			drow["isMondaySpecialWH"] = user.isMondaySpecialWH;
			drow["shiftMinutes_Monday"] = user.shiftMinutes_Monday;
			drow["shiftMinutesMin_Monday"] = user.shiftMinutesMin_Monday;
			drow["shiftBaseRate_Monday"] = user.shiftBaseRate_Monday;
			drow["nextShiftMinutes_Monday"] = user.nextShiftMinutes_Monday;
			drow["shiftGracePeriod_Monday"] = user.shiftGracePeriod_Monday;
			drow["bSpecialParameter1_Monday"] = user.bSpecialParameter1_Monday;
			drow["bSpecialParameter2_Monday"] = user.bSpecialParameter2_Monday;
			drow["isTuesdaySpecialWH"] = user.isTuesdaySpecialWH;
			drow["shiftMinutes_Tuesday"] = user.shiftMinutes_Tuesday;
			drow["shiftMinutesMin_Tuesday"] = user.shiftMinutesMin_Tuesday;
			drow["nextShiftMinutes_Tuesday"] = user.nextShiftMinutes_Tuesday;
			drow["shiftBaseRate_Tuesday"] = user.shiftBaseRate_Tuesday;
			drow["shiftGracePeriod_Tuesday"] = user.shiftGracePeriod_Tuesday;
			drow["bSpecialParameter1_Tuesday"] = user.bSpecialParameter1_Tuesday;
			drow["bSpecialParameter2_Tuesday"] = user.bSpecialParameter2_Tuesday;
			drow["isWednesdaySpecialWH"] = user.isWednesdaySpecialWH;
			drow["shiftMinutes_Wednesday"] = user.shiftMinutes_Wednesday;
			drow["shiftMinutesMin_Wednesday"] = user.shiftMinutesMin_Wednesday;
			drow["nextShiftMinutes_Wednesday"] = user.nextShiftMinutes_Wednesday;
			drow["shiftBaseRate_Wednesday"] = user.shiftBaseRate_Wednesday;
			drow["shiftGracePeriod_Wednesday"] = user.shiftGracePeriod_Wednesday;
			drow["bSpecialParameter1_Wednesday"] = user.bSpecialParameter1_Wednesday;
			drow["bSpecialParameter2_Wednesday"] = user.bSpecialParameter2_Wednesday;
			drow["isThursdaySpecialWH"] = user.isThursdaySpecialWH;
			drow["shiftMinutes_Thursday"] = user.shiftMinutes_Thursday;
			drow["shiftMinutesMin_Thursday"] = user.shiftMinutesMin_Thursday;
			drow["nextShiftMinutes_Thursday"] = user.nextShiftMinutes_Thursday;
			drow["shiftBaseRate_Thursday"] = user.shiftBaseRate_Thursday;
			drow["shiftGracePeriod_Thursday"] = user.shiftGracePeriod_Thursday;
			drow["bSpecialParameter1_Thursday"] = user.bSpecialParameter1_Thursday;
			drow["bSpecialParameter2_Thursday"] = user.bSpecialParameter2_Thursday;
			drow["isFridaySpecialWH"] = user.isFridaySpecialWH;
			drow["shiftMinutes_Friday"] = user.shiftMinutes_Friday;
			drow["shiftMinutesMin_Friday"] = user.shiftMinutesMin_Friday;
			drow["nextShiftMinutes_Friday"] = user.nextShiftMinutes_Friday;
			drow["shiftBaseRate_Friday"] = user.shiftBaseRate_Friday;
			drow["shiftGracePeriod_Friday"] = user.shiftGracePeriod_Friday;
			drow["bSpecialParameter1_Friday"] = user.bSpecialParameter1_Friday;
			drow["bSpecialParameter2_Friday"] = user.bSpecialParameter2_Friday;
			drow["isSaturdaySpecialWH"] = user.isSaturdaySpecialWH;
			drow["shiftMinutes_Saturday"] = user.shiftMinutes_Saturday;
			drow["shiftMinutesMin_Saturday"] = user.shiftMinutesMin_Saturday;
			drow["nextShiftMinutes_Saturday"] = user.nextShiftMinutes_Saturday;
			drow["shiftBaseRate_Saturday"] = user.shiftBaseRate_Saturday;
			drow["shiftGracePeriod_Saturday"] = user.shiftGracePeriod_Saturday;
			drow["bSpecialParameter1_Saturday"] = user.bSpecialParameter1_Saturday;
			drow["bSpecialParameter2_Saturday"] = user.bSpecialParameter2_Saturday;
			drow["isOT_Applicable"] = user.isOT_Applicable;
			drow["IsEarlyOtApplicable"] = user.IsEarlyOtApplicable;
			drow["shift_OTRoundMode"] = user.shift_OTRoundMode;
			drow["shift_OTRoundMinutes"] = user.shift_OTRoundMinutes;
			drow["shift_OTRate"] = user.shift_OTRate;
			drow["shift_OTGracePeroiod"] = user.shift_OTGracePeroiod;
			drow["shift_EarlyOTGracePeroiod"] = user.shift_EarlyOTGracePeroiod;
			drow["shift_OTMinuteMin"] = user.shift_OTMinuteMin;
			drow["shift_OTMinuteMax"] = user.shift_OTMinuteMax;
			drow["isWeekdaySpecialOT"] = user.isWeekdaySpecialOT;
			drow["shift_OTRate_Weekday"] = user.shift_OTRate_Weekday;
			drow["shift_OTGracePeroiod_Weekday"] = user.shift_OTGracePeroiod_Weekday;
			drow["shift_OTMinuteMin_Weekday"] = user.shift_OTMinuteMin_Weekday;
			drow["shift_OTMinuteMax_Weekday"] = user.shift_OTMinuteMax_Weekday;
			drow["isOTLunchDeduction_Weekday"] = user.isOTLunchDeduction_Weekday;
			drow["isSaturdaySpecialOT"] = user.isSaturdaySpecialOT;
			drow["shift_OTRate_Saturday"] = user.shift_OTRate_Saturday;
			drow["shift_OTGracePeroiod_Saturday"] = user.shift_OTGracePeroiod_Saturday;
			drow["shift_OTMinuteMin_Saturday"] = user.shift_OTMinuteMin_Saturday;
			drow["shift_OTMinuteMax_Saturday"] = user.shift_OTMinuteMax_Saturday;
			drow["isOTLunchDeduction_Saturday"] = user.isOTLunchDeduction_Saturday;
			drow["isSundaySpecialOT"] = user.isSundaySpecialOT;
			drow["shift_OTRate_Sunday"] = user.shift_OTRate_Sunday;
			drow["shift_OTGracePeroiod_Sunday"] = user.shift_OTGracePeroiod_Sunday;
			drow["shift_OTMinuteMin_Sunday"] = user.shift_OTMinuteMin_Sunday;
			drow["shift_OTMinuteMax_Sunday"] = user.shift_OTMinuteMax_Sunday;
			drow["isOTLunchDeduction_Sundy"] = user.isOTLunchDeduction_Sundy;
			drow["isPoyadaySpecialOT"] = user.isPoyadaySpecialOT;
			drow["shift_OTRate_Poyaday"] = user.shift_OTRate_Poyaday;
			drow["shift_OTGracePeroiod_Poyaday"] = user.shift_OTGracePeroiod_Poyaday;
			drow["shift_OTMinuteMin_Poyaday"] = user.shift_OTMinuteMin_Poyaday;
			drow["shift_OTMinuteMax_Poyaday"] = user.shift_OTMinuteMax_Poyaday;
			drow["isOTLunchDeduction_Poyaday"] = user.isOTLunchDeduction_Poyaday;
			drow["isCompanyHolidaySpecialOT"] = user.isCompanyHolidaySpecialOT;
			drow["shift_OTRate_CompanyHoliday"] = user.shift_OTRate_CompanyHoliday;
			drow["shift_OTGracePeroiod_CompanyHoliday"] = user.shift_OTGracePeroiod_CompanyHoliday;
			drow["shift_OTMinuteMin_CompanyHoliday"] = user.shift_OTMinuteMin_CompanyHoliday;
			drow["shift_OTMinuteMax_CompanyHoliday"] = user.shift_OTMinuteMax_CompanyHoliday;
			drow["isOTLunchDeduction_CompanyHoliday"] = user.isOTLunchDeduction_CompanyHoliday;
			drow["shift_Status_Effective_Date"] = user.shift_Status_Effective_Date;
			drow["shift_Status_ExpireDate"] = user.shift_Status_ExpireDate;
			drow["shift_Status"] = user.shift_Status;
			drow["lunchStartTime"] = user.lunchStartTime;
			drow["lunchDurationMins"] = user.lunchDurationMins;
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
