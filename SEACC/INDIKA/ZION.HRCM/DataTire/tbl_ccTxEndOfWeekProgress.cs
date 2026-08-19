using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ccTxEndOfWeekProgress {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int year_ID;
		private int week_ID;
		private string employee_ID;
		private decimal workingDays_Mandatory;
		private decimal workingDays_Actual;
		private decimal qty_weeklyTarget;
		private decimal qty_Actual;
		private bool isWeeklytargetAchived;
		private decimal salary_Basic;
		private decimal salary_Basic_PS;
		private decimal allowance_Budgetary1;
		private decimal allowance_Budgetary2;
		private decimal allowance_Budgetary3;
		private decimal allowance_Attendence;
		private decimal allowance_Transport;
		private decimal salary_Gross;
		private decimal salary_Gross_PS;
		private decimal deductions_EPF_8;
		private decimal deductions_EPF_12;
		private decimal deductions_ETF_3;
		private decimal deduction_Loan;
		private decimal deduction_Festival;
		private decimal deduction_Other;
		private decimal salary_Net;
		private decimal salary_Net_PS;
		private bool isProcessed;
		private bool isRollbacked;
		private bool isCancelled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		private decimal earning_NightTime;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxEndOfWeekProgress class.
		/// </summary>
		public tbl_ccTxEndOfWeekProgress() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxEndOfWeekProgress class.
		/// </summary>
		public tbl_ccTxEndOfWeekProgress(string company_ID, string companyBranch_ID, int year_ID, int week_ID, string employee_ID, decimal workingDays_Mandatory, decimal workingDays_Actual, decimal qty_weeklyTarget, decimal qty_Actual, bool isWeeklytargetAchived, decimal salary_Basic, decimal salary_Basic_PS, decimal allowance_Budgetary1, decimal allowance_Budgetary2, decimal allowance_Budgetary3, decimal allowance_Attendence, decimal allowance_Transport, decimal salary_Gross, decimal salary_Gross_PS, decimal deductions_EPF_8, decimal deductions_EPF_12, decimal deductions_ETF_3, decimal deduction_Loan, decimal deduction_Festival, decimal deduction_Other, decimal salary_Net, decimal salary_Net_PS, bool isProcessed, bool isRollbacked, bool isCancelled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled, decimal earning_NightTime) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.year_ID = year_ID;
			this.week_ID = week_ID;
			this.employee_ID = employee_ID;
			this.workingDays_Mandatory = workingDays_Mandatory;
			this.workingDays_Actual = workingDays_Actual;
			this.qty_weeklyTarget = qty_weeklyTarget;
			this.qty_Actual = qty_Actual;
			this.isWeeklytargetAchived = isWeeklytargetAchived;
			this.salary_Basic = salary_Basic;
			this.salary_Basic_PS = salary_Basic_PS;
			this.allowance_Budgetary1 = allowance_Budgetary1;
			this.allowance_Budgetary2 = allowance_Budgetary2;
			this.allowance_Budgetary3 = allowance_Budgetary3;
			this.allowance_Attendence = allowance_Attendence;
			this.allowance_Transport = allowance_Transport;
			this.salary_Gross = salary_Gross;
			this.salary_Gross_PS = salary_Gross_PS;
			this.deductions_EPF_8 = deductions_EPF_8;
			this.deductions_EPF_12 = deductions_EPF_12;
			this.deductions_ETF_3 = deductions_ETF_3;
			this.deduction_Loan = deduction_Loan;
			this.deduction_Festival = deduction_Festival;
			this.deduction_Other = deduction_Other;
			this.salary_Net = salary_Net;
			this.salary_Net_PS = salary_Net_PS;
			this.isProcessed = isProcessed;
			this.isRollbacked = isRollbacked;
			this.isCancelled = isCancelled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
			this.earning_NightTime = earning_NightTime;
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
		/// Gets or sets the WorkingDays_Mandatory value.
		/// </summary>
		public decimal WorkingDays_Mandatory {
			get { return workingDays_Mandatory; }
			set { workingDays_Mandatory = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingDays_Actual value.
		/// </summary>
		public decimal WorkingDays_Actual {
			get { return workingDays_Actual; }
			set { workingDays_Actual = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_weeklyTarget value.
		/// </summary>
		public decimal Qty_weeklyTarget {
			get { return qty_weeklyTarget; }
			set { qty_weeklyTarget = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Actual value.
		/// </summary>
		public decimal Qty_Actual {
			get { return qty_Actual; }
			set { qty_Actual = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeeklytargetAchived value.
		/// </summary>
		public bool IsWeeklytargetAchived {
			get { return isWeeklytargetAchived; }
			set { isWeeklytargetAchived = value; }
		}
		
		/// <summary>
		/// Gets or sets the Salary_Basic value.
		/// </summary>
		public decimal Salary_Basic {
			get { return salary_Basic; }
			set { salary_Basic = value; }
		}
		
		/// <summary>
		/// Gets or sets the Salary_Basic_PS value.
		/// </summary>
		public decimal Salary_Basic_PS {
			get { return salary_Basic_PS; }
			set { salary_Basic_PS = value; }
		}
		
		/// <summary>
		/// Gets or sets the Allowance_Budgetary1 value.
		/// </summary>
		public decimal Allowance_Budgetary1 {
			get { return allowance_Budgetary1; }
			set { allowance_Budgetary1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Allowance_Budgetary2 value.
		/// </summary>
		public decimal Allowance_Budgetary2 {
			get { return allowance_Budgetary2; }
			set { allowance_Budgetary2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Allowance_Budgetary3 value.
		/// </summary>
		public decimal Allowance_Budgetary3 {
			get { return allowance_Budgetary3; }
			set { allowance_Budgetary3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Allowance_Attendence value.
		/// </summary>
		public decimal Allowance_Attendence {
			get { return allowance_Attendence; }
			set { allowance_Attendence = value; }
		}
		
		/// <summary>
		/// Gets or sets the Allowance_Transport value.
		/// </summary>
		public decimal Allowance_Transport {
			get { return allowance_Transport; }
			set { allowance_Transport = value; }
		}
		
		/// <summary>
		/// Gets or sets the Salary_Gross value.
		/// </summary>
		public decimal Salary_Gross {
			get { return salary_Gross; }
			set { salary_Gross = value; }
		}
		
		/// <summary>
		/// Gets or sets the Salary_Gross_PS value.
		/// </summary>
		public decimal Salary_Gross_PS {
			get { return salary_Gross_PS; }
			set { salary_Gross_PS = value; }
		}
		
		/// <summary>
		/// Gets or sets the Deductions_EPF_8 value.
		/// </summary>
		public decimal Deductions_EPF_8 {
			get { return deductions_EPF_8; }
			set { deductions_EPF_8 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Deductions_EPF_12 value.
		/// </summary>
		public decimal Deductions_EPF_12 {
			get { return deductions_EPF_12; }
			set { deductions_EPF_12 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Deductions_ETF_3 value.
		/// </summary>
		public decimal Deductions_ETF_3 {
			get { return deductions_ETF_3; }
			set { deductions_ETF_3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Deduction_Loan value.
		/// </summary>
		public decimal Deduction_Loan {
			get { return deduction_Loan; }
			set { deduction_Loan = value; }
		}
		
		/// <summary>
		/// Gets or sets the Deduction_Festival value.
		/// </summary>
		public decimal Deduction_Festival {
			get { return deduction_Festival; }
			set { deduction_Festival = value; }
		}
		
		/// <summary>
		/// Gets or sets the Deduction_Other value.
		/// </summary>
		public decimal Deduction_Other {
			get { return deduction_Other; }
			set { deduction_Other = value; }
		}
		
		/// <summary>
		/// Gets or sets the Salary_Net value.
		/// </summary>
		public decimal Salary_Net {
			get { return salary_Net; }
			set { salary_Net = value; }
		}
		
		/// <summary>
		/// Gets or sets the Salary_Net_PS value.
		/// </summary>
		public decimal Salary_Net_PS {
			get { return salary_Net_PS; }
			set { salary_Net_PS = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsProcessed value.
		/// </summary>
		public bool IsProcessed {
			get { return isProcessed; }
			set { isProcessed = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRollbacked value.
		/// </summary>
		public bool IsRollbacked {
			get { return isRollbacked; }
			set { isRollbacked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCancelled value.
		/// </summary>
		public bool IsCancelled {
			get { return isCancelled; }
			set { isCancelled = value; }
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
		/// Gets or sets the Earning_NightTime value.
		/// </summary>
		public decimal Earning_NightTime {
			get { return earning_NightTime; }
			set { earning_NightTime = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ccTxEndOfWeekProgress table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workingDays_Mandatory", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingDays_Actual", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_weeklyTarget", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Actual", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isWeeklytargetAchived", SqlDbType.Bit,1);
			scom.Parameters.Add("@salary_Basic", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salary_Basic_PS", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowance_Budgetary1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowance_Budgetary2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowance_Budgetary3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowance_Attendence", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowance_Transport", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salary_Gross", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salary_Gross_PS", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deductions_EPF_8", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deductions_EPF_12", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deductions_ETF_3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deduction_Loan", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deduction_Festival", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deduction_Other", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salary_Net", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salary_Net_PS", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isProcessed", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRollbacked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCancelled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@earning_NightTime", SqlDbType.Decimal,9);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@workingDays_Mandatory"].Value = workingDays_Mandatory;
			scom.Parameters["@workingDays_Actual"].Value = workingDays_Actual;
			scom.Parameters["@qty_weeklyTarget"].Value = qty_weeklyTarget;
			scom.Parameters["@qty_Actual"].Value = qty_Actual;
			scom.Parameters["@isWeeklytargetAchived"].Value = isWeeklytargetAchived;
			scom.Parameters["@salary_Basic"].Value = salary_Basic;
			scom.Parameters["@salary_Basic_PS"].Value = salary_Basic_PS;
			scom.Parameters["@allowance_Budgetary1"].Value = allowance_Budgetary1;
			scom.Parameters["@allowance_Budgetary2"].Value = allowance_Budgetary2;
			scom.Parameters["@allowance_Budgetary3"].Value = allowance_Budgetary3;
			scom.Parameters["@allowance_Attendence"].Value = allowance_Attendence;
			scom.Parameters["@allowance_Transport"].Value = allowance_Transport;
			scom.Parameters["@salary_Gross"].Value = salary_Gross;
			scom.Parameters["@salary_Gross_PS"].Value = salary_Gross_PS;
			scom.Parameters["@deductions_EPF_8"].Value = deductions_EPF_8;
			scom.Parameters["@deductions_EPF_12"].Value = deductions_EPF_12;
			scom.Parameters["@deductions_ETF_3"].Value = deductions_ETF_3;
			scom.Parameters["@deduction_Loan"].Value = deduction_Loan;
			scom.Parameters["@deduction_Festival"].Value = deduction_Festival;
			scom.Parameters["@deduction_Other"].Value = deduction_Other;
			scom.Parameters["@salary_Net"].Value = salary_Net;
			scom.Parameters["@salary_Net_PS"].Value = salary_Net_PS;
			scom.Parameters["@isProcessed"].Value = isProcessed;
			scom.Parameters["@isRollbacked"].Value = isRollbacked;
			scom.Parameters["@isCancelled"].Value = isCancelled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
			scom.Parameters["@earning_NightTime"].Value = earning_NightTime;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ccTxEndOfWeekProgress table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workingDays_Mandatory", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingDays_Actual", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_weeklyTarget", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Actual", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isWeeklytargetAchived", SqlDbType.Bit,1);
			scom.Parameters.Add("@salary_Basic", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salary_Basic_PS", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowance_Budgetary1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowance_Budgetary2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowance_Budgetary3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowance_Attendence", SqlDbType.Decimal,9);
			scom.Parameters.Add("@allowance_Transport", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salary_Gross", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salary_Gross_PS", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deductions_EPF_8", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deductions_EPF_12", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deductions_ETF_3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deduction_Loan", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deduction_Festival", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deduction_Other", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salary_Net", SqlDbType.Decimal,9);
			scom.Parameters.Add("@salary_Net_PS", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isProcessed", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRollbacked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCancelled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@earning_NightTime", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@workingDays_Mandatory"].Value = workingDays_Mandatory;
			scom.Parameters["@workingDays_Actual"].Value = workingDays_Actual;
			scom.Parameters["@qty_weeklyTarget"].Value = qty_weeklyTarget;
			scom.Parameters["@qty_Actual"].Value = qty_Actual;
			scom.Parameters["@isWeeklytargetAchived"].Value = isWeeklytargetAchived;
			scom.Parameters["@salary_Basic"].Value = salary_Basic;
			scom.Parameters["@salary_Basic_PS"].Value = salary_Basic_PS;
			scom.Parameters["@allowance_Budgetary1"].Value = allowance_Budgetary1;
			scom.Parameters["@allowance_Budgetary2"].Value = allowance_Budgetary2;
			scom.Parameters["@allowance_Budgetary3"].Value = allowance_Budgetary3;
			scom.Parameters["@allowance_Attendence"].Value = allowance_Attendence;
			scom.Parameters["@allowance_Transport"].Value = allowance_Transport;
			scom.Parameters["@salary_Gross"].Value = salary_Gross;
			scom.Parameters["@salary_Gross_PS"].Value = salary_Gross_PS;
			scom.Parameters["@deductions_EPF_8"].Value = deductions_EPF_8;
			scom.Parameters["@deductions_EPF_12"].Value = deductions_EPF_12;
			scom.Parameters["@deductions_ETF_3"].Value = deductions_ETF_3;
			scom.Parameters["@deduction_Loan"].Value = deduction_Loan;
			scom.Parameters["@deduction_Festival"].Value = deduction_Festival;
			scom.Parameters["@deduction_Other"].Value = deduction_Other;
			scom.Parameters["@salary_Net"].Value = salary_Net;
			scom.Parameters["@salary_Net_PS"].Value = salary_Net_PS;
			scom.Parameters["@isProcessed"].Value = isProcessed;
			scom.Parameters["@isRollbacked"].Value = isRollbacked;
			scom.Parameters["@isCancelled"].Value = isCancelled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
			scom.Parameters["@earning_NightTime"].Value = earning_NightTime;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ccTxEndOfWeekProgress table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scom.Parameters["@year_ID"].Value = year_ID;
 
			scom.Parameters["@week_ID"].Value = week_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressDeleteAllByCompany_ID_CompanyBranch_ID", scon);
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
		/// Selects all records from the tbl_ccTxEndOfWeekProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(string company_ID, string companyBranch_ID, int year_ID, int week_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressDeleteAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID", scon);
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
		/// Selects all records from the tbl_ccTxEndOfWeekProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
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
		/// Selects a single record from the tbl_ccTxEndOfWeekProgress table.
		/// </summary>
		public static tbl_ccTxEndOfWeekProgress Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string employee_ID_Incoming, int year_ID_Incoming, int week_ID_Incoming){

			tbl_ccTxEndOfWeekProgress tbl_ccTxEndOfWeekProgressins = new tbl_ccTxEndOfWeekProgress();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			scom.Parameters["@year_ID"].Value = year_ID_Incoming;
			scom.Parameters["@week_ID"].Value = week_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ccTxEndOfWeekProgressins = Maketbl_ccTxEndOfWeekProgress(dataReader);
				} else {
					tbl_ccTxEndOfWeekProgressins = null;
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekProgressins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekProgress table.
		/// </summary>
		public static List<tbl_ccTxEndOfWeekProgress> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ccTxEndOfWeekProgress> tbl_ccTxEndOfWeekProgressList = new List<tbl_ccTxEndOfWeekProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxEndOfWeekProgress tbl_ccTxEndOfWeekProgress = Maketbl_ccTxEndOfWeekProgress(dataReader);
					tbl_ccTxEndOfWeekProgressList.Add(tbl_ccTxEndOfWeekProgress);
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxEndOfWeekProgress> SelectAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressSelectAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_ccTxEndOfWeekProgress> tbl_ccTxEndOfWeekProgressList = new List<tbl_ccTxEndOfWeekProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxEndOfWeekProgress tbl_ccTxEndOfWeekProgress = Maketbl_ccTxEndOfWeekProgress(dataReader);
					tbl_ccTxEndOfWeekProgressList.Add(tbl_ccTxEndOfWeekProgress);
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxEndOfWeekProgress> SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(string company_ID, string companyBranch_ID, int year_ID, int week_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressSelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID", scon);
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
				List<tbl_ccTxEndOfWeekProgress> tbl_ccTxEndOfWeekProgressList = new List<tbl_ccTxEndOfWeekProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxEndOfWeekProgress tbl_ccTxEndOfWeekProgress = Maketbl_ccTxEndOfWeekProgress(dataReader);
					tbl_ccTxEndOfWeekProgressList.Add(tbl_ccTxEndOfWeekProgress);
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxEndOfWeekProgress> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgressSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_ccTxEndOfWeekProgress> tbl_ccTxEndOfWeekProgressList = new List<tbl_ccTxEndOfWeekProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxEndOfWeekProgress tbl_ccTxEndOfWeekProgress = Maketbl_ccTxEndOfWeekProgress(dataReader);
					tbl_ccTxEndOfWeekProgressList.Add(tbl_ccTxEndOfWeekProgress);
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekProgressList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ccTxEndOfWeekProgress class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ccTxEndOfWeekProgress Maketbl_ccTxEndOfWeekProgress(SqlDataReader dataReader) {
			tbl_ccTxEndOfWeekProgress tbl_ccTxEndOfWeekProgress = new tbl_ccTxEndOfWeekProgress();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ccTxEndOfWeekProgress.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ccTxEndOfWeekProgress.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ccTxEndOfWeekProgress.Year_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ccTxEndOfWeekProgress.Week_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ccTxEndOfWeekProgress.Employee_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ccTxEndOfWeekProgress.WorkingDays_Mandatory = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ccTxEndOfWeekProgress.WorkingDays_Actual = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ccTxEndOfWeekProgress.Qty_weeklyTarget = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ccTxEndOfWeekProgress.Qty_Actual = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ccTxEndOfWeekProgress.IsWeeklytargetAchived = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_ccTxEndOfWeekProgress.Salary_Basic = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_ccTxEndOfWeekProgress.Salary_Basic_PS = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_ccTxEndOfWeekProgress.Allowance_Budgetary1 = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_ccTxEndOfWeekProgress.Allowance_Budgetary2 = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_ccTxEndOfWeekProgress.Allowance_Budgetary3 = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_ccTxEndOfWeekProgress.Allowance_Attendence = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_ccTxEndOfWeekProgress.Allowance_Transport = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_ccTxEndOfWeekProgress.Salary_Gross = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_ccTxEndOfWeekProgress.Salary_Gross_PS = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_ccTxEndOfWeekProgress.Deductions_EPF_8 = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_ccTxEndOfWeekProgress.Deductions_EPF_12 = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_ccTxEndOfWeekProgress.Deductions_ETF_3 = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_ccTxEndOfWeekProgress.Deduction_Loan = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_ccTxEndOfWeekProgress.Deduction_Festival = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_ccTxEndOfWeekProgress.Deduction_Other = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_ccTxEndOfWeekProgress.Salary_Net = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_ccTxEndOfWeekProgress.Salary_Net_PS = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_ccTxEndOfWeekProgress.IsProcessed = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_ccTxEndOfWeekProgress.IsRollbacked = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_ccTxEndOfWeekProgress.IsCancelled = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_ccTxEndOfWeekProgress.UserID_Created = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_ccTxEndOfWeekProgress.UserID_Modified = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_ccTxEndOfWeekProgress.UserID_Canceled = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_ccTxEndOfWeekProgress.TerminalID_Created = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_ccTxEndOfWeekProgress.TerminalID_Modified = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_ccTxEndOfWeekProgress.TerminalID_Canceled = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_ccTxEndOfWeekProgress.Date_Created = dataReader.GetDateTime(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_ccTxEndOfWeekProgress.Date_Modified = dataReader.GetDateTime(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_ccTxEndOfWeekProgress.Date_Canceled = dataReader.GetDateTime(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_ccTxEndOfWeekProgress.Earning_NightTime = dataReader.GetDecimal(39);
			}

			return tbl_ccTxEndOfWeekProgress;
		}
		/// <summary>
		/// This makes tbl_ccTxEndOfWeekProgress datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ccTxEndOfWeekProgress object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ccTxEndOfWeekProgress  tbl_ccTxEndOfWeekProgress   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_year_ID = new DataColumn("year_ID" , typeof(int));
			DataColumn col_week_ID = new DataColumn("week_ID" , typeof(int));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_workingDays_Mandatory = new DataColumn("workingDays_Mandatory" , typeof(decimal));
			DataColumn col_workingDays_Actual = new DataColumn("workingDays_Actual" , typeof(decimal));
			DataColumn col_qty_weeklyTarget = new DataColumn("qty_weeklyTarget" , typeof(decimal));
			DataColumn col_qty_Actual = new DataColumn("qty_Actual" , typeof(decimal));
			DataColumn col_isWeeklytargetAchived = new DataColumn("isWeeklytargetAchived" , typeof(bool));
			DataColumn col_salary_Basic = new DataColumn("salary_Basic" , typeof(decimal));
			DataColumn col_salary_Basic_PS = new DataColumn("salary_Basic_PS" , typeof(decimal));
			DataColumn col_allowance_Budgetary1 = new DataColumn("allowance_Budgetary1" , typeof(decimal));
			DataColumn col_allowance_Budgetary2 = new DataColumn("allowance_Budgetary2" , typeof(decimal));
			DataColumn col_allowance_Budgetary3 = new DataColumn("allowance_Budgetary3" , typeof(decimal));
			DataColumn col_allowance_Attendence = new DataColumn("allowance_Attendence" , typeof(decimal));
			DataColumn col_allowance_Transport = new DataColumn("allowance_Transport" , typeof(decimal));
			DataColumn col_salary_Gross = new DataColumn("salary_Gross" , typeof(decimal));
			DataColumn col_salary_Gross_PS = new DataColumn("salary_Gross_PS" , typeof(decimal));
			DataColumn col_deductions_EPF_8 = new DataColumn("deductions_EPF_8" , typeof(decimal));
			DataColumn col_deductions_EPF_12 = new DataColumn("deductions_EPF_12" , typeof(decimal));
			DataColumn col_deductions_ETF_3 = new DataColumn("deductions_ETF_3" , typeof(decimal));
			DataColumn col_deduction_Loan = new DataColumn("deduction_Loan" , typeof(decimal));
			DataColumn col_deduction_Festival = new DataColumn("deduction_Festival" , typeof(decimal));
			DataColumn col_deduction_Other = new DataColumn("deduction_Other" , typeof(decimal));
			DataColumn col_salary_Net = new DataColumn("salary_Net" , typeof(decimal));
			DataColumn col_salary_Net_PS = new DataColumn("salary_Net_PS" , typeof(decimal));
			DataColumn col_isProcessed = new DataColumn("isProcessed" , typeof(bool));
			DataColumn col_isRollbacked = new DataColumn("isRollbacked" , typeof(bool));
			DataColumn col_isCancelled = new DataColumn("isCancelled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
			DataColumn col_earning_NightTime = new DataColumn("earning_NightTime" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_year_ID,col_week_ID,col_employee_ID,col_workingDays_Mandatory,col_workingDays_Actual,col_qty_weeklyTarget,col_qty_Actual,col_isWeeklytargetAchived,col_salary_Basic,col_salary_Basic_PS,col_allowance_Budgetary1,col_allowance_Budgetary2,col_allowance_Budgetary3,col_allowance_Attendence,col_allowance_Transport,col_salary_Gross,col_salary_Gross_PS,col_deductions_EPF_8,col_deductions_EPF_12,col_deductions_ETF_3,col_deduction_Loan,col_deduction_Festival,col_deduction_Other,col_salary_Net,col_salary_Net_PS,col_isProcessed,col_isRollbacked,col_isCancelled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,col_earning_NightTime,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ccTxEndOfWeekProgress datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ccTxEndOfWeekProgress object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ccTxEndOfWeekProgress user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["year_ID"] = user.year_ID;
			drow["week_ID"] = user.week_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["workingDays_Mandatory"] = user.workingDays_Mandatory;
			drow["workingDays_Actual"] = user.workingDays_Actual;
			drow["qty_weeklyTarget"] = user.qty_weeklyTarget;
			drow["qty_Actual"] = user.qty_Actual;
			drow["isWeeklytargetAchived"] = user.isWeeklytargetAchived;
			drow["salary_Basic"] = user.salary_Basic;
			drow["salary_Basic_PS"] = user.salary_Basic_PS;
			drow["allowance_Budgetary1"] = user.allowance_Budgetary1;
			drow["allowance_Budgetary2"] = user.allowance_Budgetary2;
			drow["allowance_Budgetary3"] = user.allowance_Budgetary3;
			drow["allowance_Attendence"] = user.allowance_Attendence;
			drow["allowance_Transport"] = user.allowance_Transport;
			drow["salary_Gross"] = user.salary_Gross;
			drow["salary_Gross_PS"] = user.salary_Gross_PS;
			drow["deductions_EPF_8"] = user.deductions_EPF_8;
			drow["deductions_EPF_12"] = user.deductions_EPF_12;
			drow["deductions_ETF_3"] = user.deductions_ETF_3;
			drow["deduction_Loan"] = user.deduction_Loan;
			drow["deduction_Festival"] = user.deduction_Festival;
			drow["deduction_Other"] = user.deduction_Other;
			drow["salary_Net"] = user.salary_Net;
			drow["salary_Net_PS"] = user.salary_Net_PS;
			drow["isProcessed"] = user.isProcessed;
			drow["isRollbacked"] = user.isRollbacked;
			drow["isCancelled"] = user.isCancelled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
			drow["earning_NightTime"] = user.earning_NightTime;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
