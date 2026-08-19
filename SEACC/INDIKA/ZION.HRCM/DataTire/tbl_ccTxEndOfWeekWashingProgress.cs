using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ccTxEndOfWeekWashingProgress {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int year_ID;
		private int week_ID;
		private string employee_ID;
		private decimal workingDays_Mandatory;
		private decimal workingDays_Actual;
		private decimal qty_WeekTotal;
		private decimal qty_WeekWashed;
		private decimal earn_Total;
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
		/// Initializes a new instance of the tbl_ccTxEndOfWeekWashingProgress class.
		/// </summary>
		public tbl_ccTxEndOfWeekWashingProgress() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxEndOfWeekWashingProgress class.
		/// </summary>
		public tbl_ccTxEndOfWeekWashingProgress(string company_ID, string companyBranch_ID, int year_ID, int week_ID, string employee_ID, decimal workingDays_Mandatory, decimal workingDays_Actual, decimal qty_WeekTotal, decimal qty_WeekWashed, decimal earn_Total, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.year_ID = year_ID;
			this.week_ID = week_ID;
			this.employee_ID = employee_ID;
			this.workingDays_Mandatory = workingDays_Mandatory;
			this.workingDays_Actual = workingDays_Actual;
			this.qty_WeekTotal = qty_WeekTotal;
			this.qty_WeekWashed = qty_WeekWashed;
			this.earn_Total = earn_Total;
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
		/// Gets or sets the Qty_WeekTotal value.
		/// </summary>
		public decimal Qty_WeekTotal {
			get { return qty_WeekTotal; }
			set { qty_WeekTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_WeekWashed value.
		/// </summary>
		public decimal Qty_WeekWashed {
			get { return qty_WeekWashed; }
			set { qty_WeekWashed = value; }
		}
		
		/// <summary>
		/// Gets or sets the Earn_Total value.
		/// </summary>
		public decimal Earn_Total {
			get { return earn_Total; }
			set { earn_Total = value; }
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
		/// Saves a record to the tbl_ccTxEndOfWeekWashingProgress table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workingDays_Mandatory", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingDays_Actual", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_WeekTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_WeekWashed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@earn_Total", SqlDbType.Decimal,9);
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
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@workingDays_Mandatory"].Value = workingDays_Mandatory;
			scom.Parameters["@workingDays_Actual"].Value = workingDays_Actual;
			scom.Parameters["@qty_WeekTotal"].Value = qty_WeekTotal;
			scom.Parameters["@qty_WeekWashed"].Value = qty_WeekWashed;
			scom.Parameters["@earn_Total"].Value = earn_Total;
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
		/// Updates a record in the tbl_ccTxEndOfWeekWashingProgress table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workingDays_Mandatory", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingDays_Actual", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_WeekTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_WeekWashed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@earn_Total", SqlDbType.Decimal,9);
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
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@workingDays_Mandatory"].Value = workingDays_Mandatory;
			scom.Parameters["@workingDays_Actual"].Value = workingDays_Actual;
			scom.Parameters["@qty_WeekTotal"].Value = qty_WeekTotal;
			scom.Parameters["@qty_WeekWashed"].Value = qty_WeekWashed;
			scom.Parameters["@earn_Total"].Value = earn_Total;
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
		/// Deletes a record from the tbl_ccTxEndOfWeekWashingProgress table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@year_ID"].Value = year_ID;
 
			scom.Parameters["@week_ID"].Value = week_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekWashingProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(string company_ID, string companyBranch_ID, int year_ID, int week_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressDeleteAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID", scon);
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
		/// Selects all records from the tbl_ccTxEndOfWeekWashingProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID_Employee_ID(string company_ID, string companyBranch_ID, int year_ID, int week_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressDeleteAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekWashingProgress table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
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
		/// Selects a single record from the tbl_ccTxEndOfWeekWashingProgress table.
		/// </summary>
		public static tbl_ccTxEndOfWeekWashingProgress Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int year_ID_Incoming, int week_ID_Incoming, string employee_ID_Incoming){

			tbl_ccTxEndOfWeekWashingProgress tbl_ccTxEndOfWeekWashingProgressins = new tbl_ccTxEndOfWeekWashingProgress();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@year_ID"].Value = year_ID_Incoming;
			scom.Parameters["@week_ID"].Value = week_ID_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ccTxEndOfWeekWashingProgressins = Maketbl_ccTxEndOfWeekWashingProgress(dataReader);
				} else {
					tbl_ccTxEndOfWeekWashingProgressins = null;
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekWashingProgressins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekWashingProgress table.
		/// </summary>
		public static List<tbl_ccTxEndOfWeekWashingProgress> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ccTxEndOfWeekWashingProgress> tbl_ccTxEndOfWeekWashingProgressList = new List<tbl_ccTxEndOfWeekWashingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxEndOfWeekWashingProgress tbl_ccTxEndOfWeekWashingProgress = Maketbl_ccTxEndOfWeekWashingProgress(dataReader);
					tbl_ccTxEndOfWeekWashingProgressList.Add(tbl_ccTxEndOfWeekWashingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekWashingProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekWashingProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxEndOfWeekWashingProgress> SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID(string company_ID, string companyBranch_ID, int year_ID, int week_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressSelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID", scon);
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
				List<tbl_ccTxEndOfWeekWashingProgress> tbl_ccTxEndOfWeekWashingProgressList = new List<tbl_ccTxEndOfWeekWashingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxEndOfWeekWashingProgress tbl_ccTxEndOfWeekWashingProgress = Maketbl_ccTxEndOfWeekWashingProgress(dataReader);
					tbl_ccTxEndOfWeekWashingProgressList.Add(tbl_ccTxEndOfWeekWashingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekWashingProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekWashingProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxEndOfWeekWashingProgress> SelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID_Employee_ID(string company_ID, string companyBranch_ID, int year_ID, int week_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressSelectAllByCompany_ID_CompanyBranch_ID_Year_ID_Week_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_ccTxEndOfWeekWashingProgress> tbl_ccTxEndOfWeekWashingProgressList = new List<tbl_ccTxEndOfWeekWashingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxEndOfWeekWashingProgress tbl_ccTxEndOfWeekWashingProgress = Maketbl_ccTxEndOfWeekWashingProgress(dataReader);
					tbl_ccTxEndOfWeekWashingProgressList.Add(tbl_ccTxEndOfWeekWashingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekWashingProgressList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekWashingProgress table by a foreign key.
		/// </summary>
		public static List<tbl_ccTxEndOfWeekWashingProgress> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekWashingProgressSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_ccTxEndOfWeekWashingProgress> tbl_ccTxEndOfWeekWashingProgressList = new List<tbl_ccTxEndOfWeekWashingProgress>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxEndOfWeekWashingProgress tbl_ccTxEndOfWeekWashingProgress = Maketbl_ccTxEndOfWeekWashingProgress(dataReader);
					tbl_ccTxEndOfWeekWashingProgressList.Add(tbl_ccTxEndOfWeekWashingProgress);
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekWashingProgressList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ccTxEndOfWeekWashingProgress class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ccTxEndOfWeekWashingProgress Maketbl_ccTxEndOfWeekWashingProgress(SqlDataReader dataReader) {
			tbl_ccTxEndOfWeekWashingProgress tbl_ccTxEndOfWeekWashingProgress = new tbl_ccTxEndOfWeekWashingProgress();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ccTxEndOfWeekWashingProgress.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ccTxEndOfWeekWashingProgress.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ccTxEndOfWeekWashingProgress.Year_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ccTxEndOfWeekWashingProgress.Week_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ccTxEndOfWeekWashingProgress.Employee_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ccTxEndOfWeekWashingProgress.WorkingDays_Mandatory = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ccTxEndOfWeekWashingProgress.WorkingDays_Actual = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ccTxEndOfWeekWashingProgress.Qty_WeekTotal = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ccTxEndOfWeekWashingProgress.Qty_WeekWashed = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ccTxEndOfWeekWashingProgress.Earn_Total = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_ccTxEndOfWeekWashingProgress.UserID_Created = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_ccTxEndOfWeekWashingProgress.UserID_Modified = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_ccTxEndOfWeekWashingProgress.UserID_Canceled = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_ccTxEndOfWeekWashingProgress.TerminalID_Created = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_ccTxEndOfWeekWashingProgress.TerminalID_Modified = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_ccTxEndOfWeekWashingProgress.TerminalID_Canceled = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_ccTxEndOfWeekWashingProgress.Date_Created = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_ccTxEndOfWeekWashingProgress.Date_Modified = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_ccTxEndOfWeekWashingProgress.Date_Canceled = dataReader.GetDateTime(18);
			}

			return tbl_ccTxEndOfWeekWashingProgress;
		}
		/// <summary>
		/// This makes tbl_ccTxEndOfWeekWashingProgress datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ccTxEndOfWeekWashingProgress object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ccTxEndOfWeekWashingProgress  tbl_ccTxEndOfWeekWashingProgress   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_year_ID = new DataColumn("year_ID" , typeof(int));
			DataColumn col_week_ID = new DataColumn("week_ID" , typeof(int));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_workingDays_Mandatory = new DataColumn("workingDays_Mandatory" , typeof(decimal));
			DataColumn col_workingDays_Actual = new DataColumn("workingDays_Actual" , typeof(decimal));
			DataColumn col_qty_WeekTotal = new DataColumn("qty_WeekTotal" , typeof(decimal));
			DataColumn col_qty_WeekWashed = new DataColumn("qty_WeekWashed" , typeof(decimal));
			DataColumn col_earn_Total = new DataColumn("earn_Total" , typeof(decimal));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_year_ID,col_week_ID,col_employee_ID,col_workingDays_Mandatory,col_workingDays_Actual,col_qty_WeekTotal,col_qty_WeekWashed,col_earn_Total,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ccTxEndOfWeekWashingProgress datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ccTxEndOfWeekWashingProgress object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ccTxEndOfWeekWashingProgress user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["year_ID"] = user.year_ID;
			drow["week_ID"] = user.week_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["workingDays_Mandatory"] = user.workingDays_Mandatory;
			drow["workingDays_Actual"] = user.workingDays_Actual;
			drow["qty_WeekTotal"] = user.qty_WeekTotal;
			drow["qty_WeekWashed"] = user.qty_WeekWashed;
			drow["earn_Total"] = user.earn_Total;
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
