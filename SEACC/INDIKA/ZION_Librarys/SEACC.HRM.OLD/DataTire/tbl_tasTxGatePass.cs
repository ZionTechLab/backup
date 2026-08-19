using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasTxGatePass {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string gatePass_ID;
		private string employee_ID;
		private string division_ID;
		private string department_ID;
		private string section_ID;
		private string subSection_ID;
		private int year_ID;
		private DateTime gatePass_DateTime;
		private decimal leave_Hours;
		private string reason;
		private bool isBataPayable;
		private decimal bataAmount;
		private bool isCanceled;
		private int approvalStatus_Supevosior;
		private int approvalStatus_Manager;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string userID_Supevisor;
		private string userID_Manager;
		private string userIDbataApproved;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private string terminalID_Supevisor;
		private string terminalID_Manager;
		private string terminalID_bataApproved;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		private DateTime date_Checked_Supevisor;
		private DateTime date_Checked_Manager;
		private DateTime date_bataApproved;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxGatePass class.
		/// </summary>
		public tbl_tasTxGatePass() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxGatePass class.
		/// </summary>
		public tbl_tasTxGatePass(string company_ID, string companyBranch_ID, string gatePass_ID, string employee_ID, string division_ID, string department_ID, string section_ID, string subSection_ID, int year_ID, DateTime gatePass_DateTime, decimal leave_Hours, string reason, bool isBataPayable, decimal bataAmount, bool isCanceled, int approvalStatus_Supevosior, int approvalStatus_Manager, string userID_Created, string userID_Modified, string userID_Canceled, string userID_Supevisor, string userID_Manager, string userIDbataApproved, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, string terminalID_Supevisor, string terminalID_Manager, string terminalID_bataApproved, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled, DateTime date_Checked_Supevisor, DateTime date_Checked_Manager, DateTime date_bataApproved) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.gatePass_ID = gatePass_ID;
			this.employee_ID = employee_ID;
			this.division_ID = division_ID;
			this.department_ID = department_ID;
			this.section_ID = section_ID;
			this.subSection_ID = subSection_ID;
			this.year_ID = year_ID;
			this.gatePass_DateTime = gatePass_DateTime;
			this.leave_Hours = leave_Hours;
			this.reason = reason;
			this.isBataPayable = isBataPayable;
			this.bataAmount = bataAmount;
			this.isCanceled = isCanceled;
			this.approvalStatus_Supevosior = approvalStatus_Supevosior;
			this.approvalStatus_Manager = approvalStatus_Manager;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.userID_Supevisor = userID_Supevisor;
			this.userID_Manager = userID_Manager;
			this.userIDbataApproved = userIDbataApproved;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.terminalID_Supevisor = terminalID_Supevisor;
			this.terminalID_Manager = terminalID_Manager;
			this.terminalID_bataApproved = terminalID_bataApproved;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
			this.date_Checked_Supevisor = date_Checked_Supevisor;
			this.date_Checked_Manager = date_Checked_Manager;
			this.date_bataApproved = date_bataApproved;
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
		/// Gets or sets the GatePass_ID value.
		/// </summary>
		public string GatePass_ID {
			get { return gatePass_ID; }
			set { gatePass_ID = value; }
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
		/// Gets or sets the Year_ID value.
		/// </summary>
		public int Year_ID {
			get { return year_ID; }
			set { year_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GatePass_DateTime value.
		/// </summary>
		public DateTime GatePass_DateTime {
			get { return gatePass_DateTime; }
			set { gatePass_DateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the Leave_Hours value.
		/// </summary>
		public decimal Leave_Hours {
			get { return leave_Hours; }
			set { leave_Hours = value; }
		}
		
		/// <summary>
		/// Gets or sets the Reason value.
		/// </summary>
		public string Reason {
			get { return reason; }
			set { reason = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBataPayable value.
		/// </summary>
		public bool IsBataPayable {
			get { return isBataPayable; }
			set { isBataPayable = value; }
		}
		
		/// <summary>
		/// Gets or sets the BataAmount value.
		/// </summary>
		public decimal BataAmount {
			get { return bataAmount; }
			set { bataAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovalStatus_Supevosior value.
		/// </summary>
		public int ApprovalStatus_Supevosior {
			get { return approvalStatus_Supevosior; }
			set { approvalStatus_Supevosior = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovalStatus_Manager value.
		/// </summary>
		public int ApprovalStatus_Manager {
			get { return approvalStatus_Manager; }
			set { approvalStatus_Manager = value; }
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
		/// Gets or sets the UserID_Supevisor value.
		/// </summary>
		public string UserID_Supevisor {
			get { return userID_Supevisor; }
			set { userID_Supevisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Manager value.
		/// </summary>
		public string UserID_Manager {
			get { return userID_Manager; }
			set { userID_Manager = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserIDbataApproved value.
		/// </summary>
		public string UserIDbataApproved {
			get { return userIDbataApproved; }
			set { userIDbataApproved = value; }
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
		/// Gets or sets the TerminalID_Supevisor value.
		/// </summary>
		public string TerminalID_Supevisor {
			get { return terminalID_Supevisor; }
			set { terminalID_Supevisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Manager value.
		/// </summary>
		public string TerminalID_Manager {
			get { return terminalID_Manager; }
			set { terminalID_Manager = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_bataApproved value.
		/// </summary>
		public string TerminalID_bataApproved {
			get { return terminalID_bataApproved; }
			set { terminalID_bataApproved = value; }
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
		/// Gets or sets the Date_Checked_Supevisor value.
		/// </summary>
		public DateTime Date_Checked_Supevisor {
			get { return date_Checked_Supevisor; }
			set { date_Checked_Supevisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Checked_Manager value.
		/// </summary>
		public DateTime Date_Checked_Manager {
			get { return date_Checked_Manager; }
			set { date_Checked_Manager = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_bataApproved value.
		/// </summary>
		public DateTime Date_bataApproved {
			get { return date_bataApproved; }
			set { date_bataApproved = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasTxGatePass table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxGatePassInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@gatePass_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@gatePass_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@leave_Hours", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reason", SqlDbType.VarChar,250);
			scom.Parameters.Add("@isBataPayable", SqlDbType.Bit,1);
			scom.Parameters.Add("@bataAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@approvalStatus_Supevosior", SqlDbType.Int,4);
			scom.Parameters.Add("@approvalStatus_Manager", SqlDbType.Int,4);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Supevisor", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Manager", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userIDbataApproved", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Supevisor", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Manager", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_bataApproved", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_Supevisor", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_Manager", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_bataApproved", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@gatePass_ID"].Value = gatePass_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@subSection_ID"].Value = subSection_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@gatePass_DateTime"].Value = gatePass_DateTime;
			scom.Parameters["@leave_Hours"].Value = leave_Hours;
			scom.Parameters["@reason"].Value = reason;
			scom.Parameters["@isBataPayable"].Value = isBataPayable;
			scom.Parameters["@bataAmount"].Value = bataAmount;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@approvalStatus_Supevosior"].Value = approvalStatus_Supevosior;
			scom.Parameters["@approvalStatus_Manager"].Value = approvalStatus_Manager;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@userID_Supevisor"].Value = userID_Supevisor;
			scom.Parameters["@userID_Manager"].Value = userID_Manager;
			scom.Parameters["@userIDbataApproved"].Value = userIDbataApproved;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@terminalID_Supevisor"].Value = terminalID_Supevisor;
			scom.Parameters["@terminalID_Manager"].Value = terminalID_Manager;
			scom.Parameters["@terminalID_bataApproved"].Value = terminalID_bataApproved;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
			scom.Parameters["@date_Checked_Supevisor"].Value = date_Checked_Supevisor;
			scom.Parameters["@date_Checked_Manager"].Value = date_Checked_Manager;
			scom.Parameters["@date_bataApproved"].Value = date_bataApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasTxGatePass table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxGatePassUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@gatePass_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@gatePass_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@leave_Hours", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reason", SqlDbType.VarChar,250);
			scom.Parameters.Add("@isBataPayable", SqlDbType.Bit,1);
			scom.Parameters.Add("@bataAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@approvalStatus_Supevosior", SqlDbType.Int,4);
			scom.Parameters.Add("@approvalStatus_Manager", SqlDbType.Int,4);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Supevisor", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Manager", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userIDbataApproved", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Supevisor", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Manager", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_bataApproved", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_Supevisor", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_Manager", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_bataApproved", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@gatePass_ID"].Value = gatePass_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@subSection_ID"].Value = subSection_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@gatePass_DateTime"].Value = gatePass_DateTime;
			scom.Parameters["@leave_Hours"].Value = leave_Hours;
			scom.Parameters["@reason"].Value = reason;
			scom.Parameters["@isBataPayable"].Value = isBataPayable;
			scom.Parameters["@bataAmount"].Value = bataAmount;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@approvalStatus_Supevosior"].Value = approvalStatus_Supevosior;
			scom.Parameters["@approvalStatus_Manager"].Value = approvalStatus_Manager;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@userID_Supevisor"].Value = userID_Supevisor;
			scom.Parameters["@userID_Manager"].Value = userID_Manager;
			scom.Parameters["@userIDbataApproved"].Value = userIDbataApproved;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@terminalID_Supevisor"].Value = terminalID_Supevisor;
			scom.Parameters["@terminalID_Manager"].Value = terminalID_Manager;
			scom.Parameters["@terminalID_bataApproved"].Value = terminalID_bataApproved;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
			scom.Parameters["@date_Checked_Supevisor"].Value = date_Checked_Supevisor;
			scom.Parameters["@date_Checked_Manager"].Value = date_Checked_Manager;
			scom.Parameters["@date_bataApproved"].Value = date_bataApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasTxGatePass table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxGatePassDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@gatePass_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@gatePass_ID"].Value = gatePass_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxGatePass table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxGatePassDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
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
		/// Selects all records from the tbl_tasTxGatePass table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Year_ID(string company_ID, string companyBranch_ID, int year_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxGatePassDeleteAllByCompany_ID_CompanyBranch_ID_Year_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasTxGatePass table.
		/// </summary>
		public static tbl_tasTxGatePass Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string gatePass_ID_Incoming){

			tbl_tasTxGatePass tbl_tasTxGatePassins = new tbl_tasTxGatePass();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxGatePassSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@gatePass_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@gatePass_ID"].Value = gatePass_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasTxGatePassins = Maketbl_tasTxGatePass(dataReader);
				} else {
					tbl_tasTxGatePassins = null;
				}
			}
			scon.Close();
			return tbl_tasTxGatePassins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxGatePass table.
		/// </summary>
		public static List<tbl_tasTxGatePass> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxGatePassSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasTxGatePass> tbl_tasTxGatePassList = new List<tbl_tasTxGatePass>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxGatePass tbl_tasTxGatePass = Maketbl_tasTxGatePass(dataReader);
					tbl_tasTxGatePassList.Add(tbl_tasTxGatePass);
				}
			}
			scon.Close();
			return tbl_tasTxGatePassList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxGatePass table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxGatePass> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxGatePassSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_tasTxGatePass> tbl_tasTxGatePassList = new List<tbl_tasTxGatePass>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxGatePass tbl_tasTxGatePass = Maketbl_tasTxGatePass(dataReader);
					tbl_tasTxGatePassList.Add(tbl_tasTxGatePass);
				}
			}
			scon.Close();
			return tbl_tasTxGatePassList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxGatePass table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxGatePass> SelectAllByCompany_ID_CompanyBranch_ID_Year_ID(string company_ID, string companyBranch_ID, int year_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxGatePassSelectAllByCompany_ID_CompanyBranch_ID_Year_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
				List<tbl_tasTxGatePass> tbl_tasTxGatePassList = new List<tbl_tasTxGatePass>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxGatePass tbl_tasTxGatePass = Maketbl_tasTxGatePass(dataReader);
					tbl_tasTxGatePassList.Add(tbl_tasTxGatePass);
				}
			}
			scon.Close();
			return tbl_tasTxGatePassList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasTxGatePass class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasTxGatePass Maketbl_tasTxGatePass(SqlDataReader dataReader) {
			tbl_tasTxGatePass tbl_tasTxGatePass = new tbl_tasTxGatePass();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasTxGatePass.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasTxGatePass.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasTxGatePass.GatePass_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasTxGatePass.Employee_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasTxGatePass.Division_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasTxGatePass.Department_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasTxGatePass.Section_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasTxGatePass.SubSection_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasTxGatePass.Year_ID = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasTxGatePass.GatePass_DateTime = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasTxGatePass.Leave_Hours = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasTxGatePass.Reason = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasTxGatePass.IsBataPayable = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasTxGatePass.BataAmount = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasTxGatePass.IsCanceled = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_tasTxGatePass.ApprovalStatus_Supevosior = dataReader.GetInt32(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_tasTxGatePass.ApprovalStatus_Manager = dataReader.GetInt32(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_tasTxGatePass.UserID_Created = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_tasTxGatePass.UserID_Modified = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_tasTxGatePass.UserID_Canceled = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_tasTxGatePass.UserID_Supevisor = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_tasTxGatePass.UserID_Manager = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_tasTxGatePass.UserIDbataApproved = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_tasTxGatePass.TerminalID_Created = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_tasTxGatePass.TerminalID_Modified = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_tasTxGatePass.TerminalID_Canceled = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_tasTxGatePass.TerminalID_Supevisor = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_tasTxGatePass.TerminalID_Manager = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_tasTxGatePass.TerminalID_bataApproved = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_tasTxGatePass.Date_Created = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_tasTxGatePass.Date_Modified = dataReader.GetDateTime(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_tasTxGatePass.Date_Canceled = dataReader.GetDateTime(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_tasTxGatePass.Date_Checked_Supevisor = dataReader.GetDateTime(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_tasTxGatePass.Date_Checked_Manager = dataReader.GetDateTime(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_tasTxGatePass.Date_bataApproved = dataReader.GetDateTime(34);
			}

			return tbl_tasTxGatePass;
		}
		/// <summary>
		/// This makes tbl_tasTxGatePass datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasTxGatePass object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasTxGatePass  tbl_tasTxGatePass   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_gatePass_ID = new DataColumn("gatePass_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_division_ID = new DataColumn("division_ID" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_subSection_ID = new DataColumn("subSection_ID" , typeof(string));
			DataColumn col_year_ID = new DataColumn("year_ID" , typeof(int));
			DataColumn col_gatePass_DateTime = new DataColumn("gatePass_DateTime" , typeof(DateTime));
			DataColumn col_leave_Hours = new DataColumn("leave_Hours" , typeof(decimal));
			DataColumn col_reason = new DataColumn("reason" , typeof(string));
			DataColumn col_isBataPayable = new DataColumn("isBataPayable" , typeof(bool));
			DataColumn col_bataAmount = new DataColumn("bataAmount" , typeof(decimal));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_approvalStatus_Supevosior = new DataColumn("approvalStatus_Supevosior" , typeof(int));
			DataColumn col_approvalStatus_Manager = new DataColumn("approvalStatus_Manager" , typeof(int));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_userID_Supevisor = new DataColumn("userID_Supevisor" , typeof(string));
			DataColumn col_userID_Manager = new DataColumn("userID_Manager" , typeof(string));
			DataColumn col_userIDbataApproved = new DataColumn("userIDbataApproved" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_terminalID_Supevisor = new DataColumn("terminalID_Supevisor" , typeof(string));
			DataColumn col_terminalID_Manager = new DataColumn("terminalID_Manager" , typeof(string));
			DataColumn col_terminalID_bataApproved = new DataColumn("terminalID_bataApproved" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
			DataColumn col_date_Checked_Supevisor = new DataColumn("date_Checked_Supevisor" , typeof(DateTime));
			DataColumn col_date_Checked_Manager = new DataColumn("date_Checked_Manager" , typeof(DateTime));
			DataColumn col_date_bataApproved = new DataColumn("date_bataApproved" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_gatePass_ID,col_employee_ID,col_division_ID,col_department_ID,col_section_ID,col_subSection_ID,col_year_ID,col_gatePass_DateTime,col_leave_Hours,col_reason,col_isBataPayable,col_bataAmount,col_isCanceled,col_approvalStatus_Supevosior,col_approvalStatus_Manager,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_userID_Supevisor,col_userID_Manager,col_userIDbataApproved,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_terminalID_Supevisor,col_terminalID_Manager,col_terminalID_bataApproved,col_date_Created,col_date_Modified,col_date_Canceled,col_date_Checked_Supevisor,col_date_Checked_Manager,col_date_bataApproved,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasTxGatePass datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasTxGatePass object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasTxGatePass user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["gatePass_ID"] = user.gatePass_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["division_ID"] = user.division_ID;
			drow["department_ID"] = user.department_ID;
			drow["section_ID"] = user.section_ID;
			drow["subSection_ID"] = user.subSection_ID;
			drow["year_ID"] = user.year_ID;
			drow["gatePass_DateTime"] = user.gatePass_DateTime;
			drow["leave_Hours"] = user.leave_Hours;
			drow["reason"] = user.reason;
			drow["isBataPayable"] = user.isBataPayable;
			drow["bataAmount"] = user.bataAmount;
			drow["isCanceled"] = user.isCanceled;
			drow["approvalStatus_Supevosior"] = user.approvalStatus_Supevosior;
			drow["approvalStatus_Manager"] = user.approvalStatus_Manager;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["userID_Supevisor"] = user.userID_Supevisor;
			drow["userID_Manager"] = user.userID_Manager;
			drow["userIDbataApproved"] = user.userIDbataApproved;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["terminalID_Supevisor"] = user.terminalID_Supevisor;
			drow["terminalID_Manager"] = user.terminalID_Manager;
			drow["terminalID_bataApproved"] = user.terminalID_bataApproved;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
			drow["date_Checked_Supevisor"] = user.date_Checked_Supevisor;
			drow["date_Checked_Manager"] = user.date_Checked_Manager;
			drow["date_bataApproved"] = user.date_bataApproved;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
