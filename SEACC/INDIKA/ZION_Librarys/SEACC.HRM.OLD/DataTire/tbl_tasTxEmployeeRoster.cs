using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasTxEmployeeRoster {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int roster_index;
		private DateTime rosterDate;
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
		private bool isOT_Applicable;
		private int shift_OTMinuteMin;
		private int shift_OTMinuteMax;
		private int shift_OTGracePeroiod;
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
		/// Initializes a new instance of the tbl_tasTxEmployeeRoster class.
		/// </summary>
		public tbl_tasTxEmployeeRoster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxEmployeeRoster class.
		/// </summary>
		public tbl_tasTxEmployeeRoster(string company_ID, string companyBranch_ID, DateTime rosterDate, string employee_ID, string department_ID, int dayType, string shift_ID, int shiftDay, DateTime shiftStartTime, DateTime shiftEndTime, int shiftMinutes, int shiftMinutesMin, int nextShiftMinutes, int shiftGracePeriod, bool isOT_Applicable, int shift_OTMinuteMin, int shift_OTMinuteMax, int shift_OTGracePeroiod, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.rosterDate = rosterDate;
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
			this.isOT_Applicable = isOT_Applicable;
			this.shift_OTMinuteMin = shift_OTMinuteMin;
			this.shift_OTMinuteMax = shift_OTMinuteMax;
			this.shift_OTGracePeroiod = shift_OTGracePeroiod;
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
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxEmployeeRoster class.
		/// </summary>
		public tbl_tasTxEmployeeRoster(string company_ID, string companyBranch_ID, int roster_index, DateTime rosterDate, string employee_ID, string department_ID, int dayType, string shift_ID, int shiftDay, DateTime shiftStartTime, DateTime shiftEndTime, int shiftMinutes, int shiftMinutesMin, int nextShiftMinutes, int shiftGracePeriod, bool isOT_Applicable, int shift_OTMinuteMin, int shift_OTMinuteMax, int shift_OTGracePeroiod, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.roster_index = roster_index;
			this.rosterDate = rosterDate;
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
			this.isOT_Applicable = isOT_Applicable;
			this.shift_OTMinuteMin = shift_OTMinuteMin;
			this.shift_OTMinuteMax = shift_OTMinuteMax;
			this.shift_OTGracePeroiod = shift_OTGracePeroiod;
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
		/// Gets or sets the Roster_index value.
		/// </summary>
		public int Roster_index {
			get { return roster_index; }
			set { roster_index = value; }
		}
		
		/// <summary>
		/// Gets or sets the RosterDate value.
		/// </summary>
		public DateTime RosterDate {
			get { return rosterDate; }
			set { rosterDate = value; }
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
		/// Gets or sets the IsOT_Applicable value.
		/// </summary>
		public bool IsOT_Applicable {
			get { return isOT_Applicable; }
			set { isOT_Applicable = value; }
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
		/// Gets or sets the Shift_OTGracePeroiod value.
		/// </summary>
		public int Shift_OTGracePeroiod {
			get { return shift_OTGracePeroiod; }
			set { shift_OTGracePeroiod = value; }
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
		/// Saves a record to the tbl_tasTxEmployeeRoster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@rosterDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@shiftDay", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftStartTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftEndTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftGracePeriod", SqlDbType.Int,4);
			scom.Parameters.Add("@isOT_Applicable", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTMinuteMin", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTGracePeroiod", SqlDbType.Int,4);
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
			scom.Parameters["@rosterDate"].Value = rosterDate;
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
			scom.Parameters["@isOT_Applicable"].Value = isOT_Applicable;
			scom.Parameters["@shift_OTMinuteMin"].Value = shift_OTMinuteMin;
			scom.Parameters["@shift_OTMinuteMax"].Value = shift_OTMinuteMax;
			scom.Parameters["@shift_OTGracePeroiod"].Value = shift_OTGracePeroiod;
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
		/// Updates a record in the tbl_tasTxEmployeeRoster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
            scom.Parameters.Add("@roster_index", SqlDbType.Int, 4);
			scom.Parameters.Add("@rosterDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@shiftDay", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftStartTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftEndTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@shiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftMinutesMin", SqlDbType.Int,4);
			scom.Parameters.Add("@nextShiftMinutes", SqlDbType.Int,4);
			scom.Parameters.Add("@shiftGracePeriod", SqlDbType.Int,4);
			scom.Parameters.Add("@isOT_Applicable", SqlDbType.Bit,1);
			scom.Parameters.Add("@shift_OTMinuteMin", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTMinuteMax", SqlDbType.Int,4);
			scom.Parameters.Add("@shift_OTGracePeroiod", SqlDbType.Int,4);
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
            scom.Parameters["@roster_index"].Value = roster_index;
			scom.Parameters["@rosterDate"].Value = rosterDate;
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
			scom.Parameters["@isOT_Applicable"].Value = isOT_Applicable;
			scom.Parameters["@shift_OTMinuteMin"].Value = shift_OTMinuteMin;
			scom.Parameters["@shift_OTMinuteMax"].Value = shift_OTMinuteMax;
			scom.Parameters["@shift_OTGracePeroiod"].Value = shift_OTGracePeroiod;
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
		/// Deletes a record from the tbl_tasTxEmployeeRoster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@roster_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@roster_index"].Value = roster_index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxEmployeeRoster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
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
		/// Selects all records from the tbl_tasTxEmployeeRoster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterDeleteAllByCompany_ID_CompanyBranch_ID", scon);
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
		/// Selects all records from the tbl_tasTxEmployeeRoster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterDeleteAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxEmployeeRoster table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Roster_index(string company_ID, string companyBranch_ID, int roster_index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterDeleteAllByCompany_ID_CompanyBranch_ID_Roster_index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@roster_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@roster_index"].Value = roster_index;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasTxEmployeeRoster table.
		/// </summary>
		public static tbl_tasTxEmployeeRoster Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int roster_index_Incoming){

			tbl_tasTxEmployeeRoster tbl_tasTxEmployeeRosterins = new tbl_tasTxEmployeeRoster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@roster_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@roster_index"].Value = roster_index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasTxEmployeeRosterins = Maketbl_tasTxEmployeeRoster(dataReader);
				} else {
					tbl_tasTxEmployeeRosterins = null;
				}
			}
			scon.Close();
			return tbl_tasTxEmployeeRosterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxEmployeeRoster table.
		/// </summary>
		public static List<tbl_tasTxEmployeeRoster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasTxEmployeeRoster> tbl_tasTxEmployeeRosterList = new List<tbl_tasTxEmployeeRoster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxEmployeeRoster tbl_tasTxEmployeeRoster = Maketbl_tasTxEmployeeRoster(dataReader);
					tbl_tasTxEmployeeRosterList.Add(tbl_tasTxEmployeeRoster);
				}
			}
			scon.Close();
			return tbl_tasTxEmployeeRosterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxEmployeeRoster table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxEmployeeRoster> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_tasTxEmployeeRoster> tbl_tasTxEmployeeRosterList = new List<tbl_tasTxEmployeeRoster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxEmployeeRoster tbl_tasTxEmployeeRoster = Maketbl_tasTxEmployeeRoster(dataReader);
					tbl_tasTxEmployeeRosterList.Add(tbl_tasTxEmployeeRoster);
				}
			}
			scon.Close();
			return tbl_tasTxEmployeeRosterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxEmployeeRoster table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxEmployeeRoster> SelectAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterSelectAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_tasTxEmployeeRoster> tbl_tasTxEmployeeRosterList = new List<tbl_tasTxEmployeeRoster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxEmployeeRoster tbl_tasTxEmployeeRoster = Maketbl_tasTxEmployeeRoster(dataReader);
					tbl_tasTxEmployeeRosterList.Add(tbl_tasTxEmployeeRoster);
				}
			}
			scon.Close();
			return tbl_tasTxEmployeeRosterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxEmployeeRoster table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxEmployeeRoster> SelectAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterSelectAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
				List<tbl_tasTxEmployeeRoster> tbl_tasTxEmployeeRosterList = new List<tbl_tasTxEmployeeRoster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxEmployeeRoster tbl_tasTxEmployeeRoster = Maketbl_tasTxEmployeeRoster(dataReader);
					tbl_tasTxEmployeeRosterList.Add(tbl_tasTxEmployeeRoster);
				}
			}
			scon.Close();
			return tbl_tasTxEmployeeRosterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxEmployeeRoster table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxEmployeeRoster> SelectAllByCompany_ID_CompanyBranch_ID_Roster_index(string company_ID, string companyBranch_ID, int roster_index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxEmployeeRosterSelectAllByCompany_ID_CompanyBranch_ID_Roster_index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@roster_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@roster_index"].Value = roster_index;
				List<tbl_tasTxEmployeeRoster> tbl_tasTxEmployeeRosterList = new List<tbl_tasTxEmployeeRoster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxEmployeeRoster tbl_tasTxEmployeeRoster = Maketbl_tasTxEmployeeRoster(dataReader);
					tbl_tasTxEmployeeRosterList.Add(tbl_tasTxEmployeeRoster);
				}
			}
			scon.Close();
			return tbl_tasTxEmployeeRosterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasTxEmployeeRoster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasTxEmployeeRoster Maketbl_tasTxEmployeeRoster(SqlDataReader dataReader) {
			tbl_tasTxEmployeeRoster tbl_tasTxEmployeeRoster = new tbl_tasTxEmployeeRoster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasTxEmployeeRoster.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasTxEmployeeRoster.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasTxEmployeeRoster.Roster_index = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasTxEmployeeRoster.RosterDate = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasTxEmployeeRoster.Employee_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasTxEmployeeRoster.Department_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasTxEmployeeRoster.DayType = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasTxEmployeeRoster.Shift_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasTxEmployeeRoster.ShiftDay = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasTxEmployeeRoster.ShiftStartTime = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasTxEmployeeRoster.ShiftEndTime = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasTxEmployeeRoster.ShiftMinutes = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasTxEmployeeRoster.ShiftMinutesMin = dataReader.GetInt32(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasTxEmployeeRoster.NextShiftMinutes = dataReader.GetInt32(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasTxEmployeeRoster.ShiftGracePeriod = dataReader.GetInt32(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_tasTxEmployeeRoster.IsOT_Applicable = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_tasTxEmployeeRoster.Shift_OTMinuteMin = dataReader.GetInt32(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_tasTxEmployeeRoster.Shift_OTMinuteMax = dataReader.GetInt32(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_tasTxEmployeeRoster.Shift_OTGracePeroiod = dataReader.GetInt32(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_tasTxEmployeeRoster.IsCanceled = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_tasTxEmployeeRoster.UserID_Created = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_tasTxEmployeeRoster.UserID_Modified = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_tasTxEmployeeRoster.UserID_Canceled = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_tasTxEmployeeRoster.TerminalID_Created = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_tasTxEmployeeRoster.TerminalID_Modified = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_tasTxEmployeeRoster.TerminalID_Canceled = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_tasTxEmployeeRoster.Date_Created = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_tasTxEmployeeRoster.Date_Modified = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_tasTxEmployeeRoster.Date_Canceled = dataReader.GetDateTime(28);
			}

			return tbl_tasTxEmployeeRoster;
		}
		/// <summary>
		/// This makes tbl_tasTxEmployeeRoster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasTxEmployeeRoster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasTxEmployeeRoster  tbl_tasTxEmployeeRoster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_roster_index = new DataColumn("roster_index" , typeof(int));
			DataColumn col_rosterDate = new DataColumn("rosterDate" , typeof(DateTime));
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
			DataColumn col_isOT_Applicable = new DataColumn("isOT_Applicable" , typeof(bool));
			DataColumn col_shift_OTMinuteMin = new DataColumn("shift_OTMinuteMin" , typeof(int));
			DataColumn col_shift_OTMinuteMax = new DataColumn("shift_OTMinuteMax" , typeof(int));
			DataColumn col_shift_OTGracePeroiod = new DataColumn("shift_OTGracePeroiod" , typeof(int));
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
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_roster_index,col_rosterDate,col_employee_ID,col_department_ID,col_dayType,col_shift_ID,col_shiftDay,col_shiftStartTime,col_shiftEndTime,col_shiftMinutes,col_shiftMinutesMin,col_nextShiftMinutes,col_shiftGracePeriod,col_isOT_Applicable,col_shift_OTMinuteMin,col_shift_OTMinuteMax,col_shift_OTGracePeroiod,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasTxEmployeeRoster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasTxEmployeeRoster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasTxEmployeeRoster user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["roster_index"] = user.roster_index;
			drow["rosterDate"] = user.rosterDate;
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
			drow["isOT_Applicable"] = user.isOT_Applicable;
			drow["shift_OTMinuteMin"] = user.shift_OTMinuteMin;
			drow["shift_OTMinuteMax"] = user.shift_OTMinuteMax;
			drow["shift_OTGracePeroiod"] = user.shift_OTGracePeroiod;
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
