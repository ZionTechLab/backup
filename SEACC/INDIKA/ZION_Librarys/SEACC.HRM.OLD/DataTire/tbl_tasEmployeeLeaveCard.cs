using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasEmployeeLeaveCard {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string leave_ID;
		private string employee_ID;
		private int year_ID;
		private DateTime leave_Start;
		private DateTime leave_End;
		private string leaveType_ID;
		private decimal leaves_Utilized;
		private string reason;
		private int approvalStatus_CP1;
		private int approvalStatus_CP2;
		private int approvalStatus_Supevosior;
		private int approvalStatus_Manager;
		private string comments_CP1;
		private string comments_CP2;
		private string comments_Supevisor;
		private string comments_Manager;
		private bool isCancled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string userID_CP1;
		private string userID_CP2;
		private string userID_Supevisor;
		private string userID_Manager;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private string terminalID_CP1;
		private string terminalID_CP2;
		private string terminalID_Supevisor;
		private string terminalID_Manager;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		private DateTime date_Checked_CP1;
		private DateTime date_Checked_CP2;
		private DateTime date_Checked_Supevisor;
		private DateTime date_Checked_Manager;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasEmployeeLeaveCard class.
		/// </summary>
		public tbl_tasEmployeeLeaveCard() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasEmployeeLeaveCard class.
		/// </summary>
		public tbl_tasEmployeeLeaveCard(string company_ID, string companyBranch_ID, string leave_ID, string employee_ID, int year_ID, DateTime leave_Start, DateTime leave_End, string leaveType_ID, decimal leaves_Utilized, string reason, int approvalStatus_CP1, int approvalStatus_CP2, int approvalStatus_Supevosior, int approvalStatus_Manager, string comments_CP1, string comments_CP2, string comments_Supevisor, string comments_Manager, bool isCancled, string userID_Created, string userID_Modified, string userID_Canceled, string userID_CP1, string userID_CP2, string userID_Supevisor, string userID_Manager, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, string terminalID_CP1, string terminalID_CP2, string terminalID_Supevisor, string terminalID_Manager, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled, DateTime date_Checked_CP1, DateTime date_Checked_CP2, DateTime date_Checked_Supevisor, DateTime date_Checked_Manager) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.leave_ID = leave_ID;
			this.employee_ID = employee_ID;
			this.year_ID = year_ID;
			this.leave_Start = leave_Start;
			this.leave_End = leave_End;
			this.leaveType_ID = leaveType_ID;
			this.leaves_Utilized = leaves_Utilized;
			this.reason = reason;
			this.approvalStatus_CP1 = approvalStatus_CP1;
			this.approvalStatus_CP2 = approvalStatus_CP2;
			this.approvalStatus_Supevosior = approvalStatus_Supevosior;
			this.approvalStatus_Manager = approvalStatus_Manager;
			this.comments_CP1 = comments_CP1;
			this.comments_CP2 = comments_CP2;
			this.comments_Supevisor = comments_Supevisor;
			this.comments_Manager = comments_Manager;
			this.isCancled = isCancled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.userID_CP1 = userID_CP1;
			this.userID_CP2 = userID_CP2;
			this.userID_Supevisor = userID_Supevisor;
			this.userID_Manager = userID_Manager;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.terminalID_CP1 = terminalID_CP1;
			this.terminalID_CP2 = terminalID_CP2;
			this.terminalID_Supevisor = terminalID_Supevisor;
			this.terminalID_Manager = terminalID_Manager;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
			this.date_Checked_CP1 = date_Checked_CP1;
			this.date_Checked_CP2 = date_Checked_CP2;
			this.date_Checked_Supevisor = date_Checked_Supevisor;
			this.date_Checked_Manager = date_Checked_Manager;
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
		/// Gets or sets the Leave_ID value.
		/// </summary>
		public string Leave_ID {
			get { return leave_ID; }
			set { leave_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Year_ID value.
		/// </summary>
		public int Year_ID {
			get { return year_ID; }
			set { year_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Leave_Start value.
		/// </summary>
		public DateTime Leave_Start {
			get { return leave_Start; }
			set { leave_Start = value; }
		}
		
		/// <summary>
		/// Gets or sets the Leave_End value.
		/// </summary>
		public DateTime Leave_End {
			get { return leave_End; }
			set { leave_End = value; }
		}
		
		/// <summary>
		/// Gets or sets the LeaveType_ID value.
		/// </summary>
		public string LeaveType_ID {
			get { return leaveType_ID; }
			set { leaveType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Leaves_Utilized value.
		/// </summary>
		public decimal Leaves_Utilized {
			get { return leaves_Utilized; }
			set { leaves_Utilized = value; }
		}
		
		/// <summary>
		/// Gets or sets the Reason value.
		/// </summary>
		public string Reason {
			get { return reason; }
			set { reason = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovalStatus_CP1 value.
		/// </summary>
		public int ApprovalStatus_CP1 {
			get { return approvalStatus_CP1; }
			set { approvalStatus_CP1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovalStatus_CP2 value.
		/// </summary>
		public int ApprovalStatus_CP2 {
			get { return approvalStatus_CP2; }
			set { approvalStatus_CP2 = value; }
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
		/// Gets or sets the Comments_CP1 value.
		/// </summary>
		public string Comments_CP1 {
			get { return comments_CP1; }
			set { comments_CP1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Comments_CP2 value.
		/// </summary>
		public string Comments_CP2 {
			get { return comments_CP2; }
			set { comments_CP2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Comments_Supevisor value.
		/// </summary>
		public string Comments_Supevisor {
			get { return comments_Supevisor; }
			set { comments_Supevisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the Comments_Manager value.
		/// </summary>
		public string Comments_Manager {
			get { return comments_Manager; }
			set { comments_Manager = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCancled value.
		/// </summary>
		public bool IsCancled {
			get { return isCancled; }
			set { isCancled = value; }
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
		/// Gets or sets the UserID_CP1 value.
		/// </summary>
		public string UserID_CP1 {
			get { return userID_CP1; }
			set { userID_CP1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_CP2 value.
		/// </summary>
		public string UserID_CP2 {
			get { return userID_CP2; }
			set { userID_CP2 = value; }
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
		/// Gets or sets the TerminalID_CP1 value.
		/// </summary>
		public string TerminalID_CP1 {
			get { return terminalID_CP1; }
			set { terminalID_CP1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_CP2 value.
		/// </summary>
		public string TerminalID_CP2 {
			get { return terminalID_CP2; }
			set { terminalID_CP2 = value; }
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
		/// Gets or sets the Date_Checked_CP1 value.
		/// </summary>
		public DateTime Date_Checked_CP1 {
			get { return date_Checked_CP1; }
			set { date_Checked_CP1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Checked_CP2 value.
		/// </summary>
		public DateTime Date_Checked_CP2 {
			get { return date_Checked_CP2; }
			set { date_Checked_CP2 = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasEmployeeLeaveCard table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCardInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@leave_Start", SqlDbType.DateTime,8);
			scom.Parameters.Add("@leave_End", SqlDbType.DateTime,8);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leaves_Utilized", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reason", SqlDbType.VarChar,100);
			scom.Parameters.Add("@approvalStatus_CP1", SqlDbType.Int,4);
			scom.Parameters.Add("@approvalStatus_CP2", SqlDbType.Int,4);
			scom.Parameters.Add("@approvalStatus_Supevosior", SqlDbType.Int,4);
			scom.Parameters.Add("@approvalStatus_Manager", SqlDbType.Int,4);
			scom.Parameters.Add("@comments_CP1", SqlDbType.VarChar,200);
			scom.Parameters.Add("@comments_CP2", SqlDbType.VarChar,200);
			scom.Parameters.Add("@comments_Supevisor", SqlDbType.VarChar,200);
			scom.Parameters.Add("@comments_Manager", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isCancled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_CP1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_CP2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Supevisor", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Manager", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_CP1", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_CP2", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Supevisor", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Manager", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_CP1", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_CP2", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_Supevisor", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_Manager", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@leave_ID"].Value = leave_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@leave_Start"].Value = leave_Start;
			scom.Parameters["@leave_End"].Value = leave_End;
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
			scom.Parameters["@leaves_Utilized"].Value = leaves_Utilized;
			scom.Parameters["@reason"].Value = reason;
			scom.Parameters["@approvalStatus_CP1"].Value = approvalStatus_CP1;
			scom.Parameters["@approvalStatus_CP2"].Value = approvalStatus_CP2;
			scom.Parameters["@approvalStatus_Supevosior"].Value = approvalStatus_Supevosior;
			scom.Parameters["@approvalStatus_Manager"].Value = approvalStatus_Manager;
			scom.Parameters["@comments_CP1"].Value = comments_CP1;
			scom.Parameters["@comments_CP2"].Value = comments_CP2;
			scom.Parameters["@comments_Supevisor"].Value = comments_Supevisor;
			scom.Parameters["@comments_Manager"].Value = comments_Manager;
			scom.Parameters["@isCancled"].Value = isCancled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@userID_CP1"].Value = userID_CP1;
			scom.Parameters["@userID_CP2"].Value = userID_CP2;
			scom.Parameters["@userID_Supevisor"].Value = userID_Supevisor;
			scom.Parameters["@userID_Manager"].Value = userID_Manager;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@terminalID_CP1"].Value = terminalID_CP1;
			scom.Parameters["@terminalID_CP2"].Value = terminalID_CP2;
			scom.Parameters["@terminalID_Supevisor"].Value = terminalID_Supevisor;
			scom.Parameters["@terminalID_Manager"].Value = terminalID_Manager;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
			scom.Parameters["@date_Checked_CP1"].Value = date_Checked_CP1;
			scom.Parameters["@date_Checked_CP2"].Value = date_Checked_CP2;
			scom.Parameters["@date_Checked_Supevisor"].Value = date_Checked_Supevisor;
			scom.Parameters["@date_Checked_Manager"].Value = date_Checked_Manager;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasEmployeeLeaveCard table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCardUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@leave_Start", SqlDbType.DateTime,8);
			scom.Parameters.Add("@leave_End", SqlDbType.DateTime,8);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leaves_Utilized", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reason", SqlDbType.VarChar,100);
			scom.Parameters.Add("@approvalStatus_CP1", SqlDbType.Int,4);
			scom.Parameters.Add("@approvalStatus_CP2", SqlDbType.Int,4);
			scom.Parameters.Add("@approvalStatus_Supevosior", SqlDbType.Int,4);
			scom.Parameters.Add("@approvalStatus_Manager", SqlDbType.Int,4);
			scom.Parameters.Add("@comments_CP1", SqlDbType.VarChar,200);
			scom.Parameters.Add("@comments_CP2", SqlDbType.VarChar,200);
			scom.Parameters.Add("@comments_Supevisor", SqlDbType.VarChar,200);
			scom.Parameters.Add("@comments_Manager", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isCancled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_CP1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_CP2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Supevisor", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Manager", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_CP1", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_CP2", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Supevisor", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Manager", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_CP1", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_CP2", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_Supevisor", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked_Manager", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@leave_ID"].Value = leave_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@leave_Start"].Value = leave_Start;
			scom.Parameters["@leave_End"].Value = leave_End;
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
			scom.Parameters["@leaves_Utilized"].Value = leaves_Utilized;
			scom.Parameters["@reason"].Value = reason;
			scom.Parameters["@approvalStatus_CP1"].Value = approvalStatus_CP1;
			scom.Parameters["@approvalStatus_CP2"].Value = approvalStatus_CP2;
			scom.Parameters["@approvalStatus_Supevosior"].Value = approvalStatus_Supevosior;
			scom.Parameters["@approvalStatus_Manager"].Value = approvalStatus_Manager;
			scom.Parameters["@comments_CP1"].Value = comments_CP1;
			scom.Parameters["@comments_CP2"].Value = comments_CP2;
			scom.Parameters["@comments_Supevisor"].Value = comments_Supevisor;
			scom.Parameters["@comments_Manager"].Value = comments_Manager;
			scom.Parameters["@isCancled"].Value = isCancled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@userID_CP1"].Value = userID_CP1;
			scom.Parameters["@userID_CP2"].Value = userID_CP2;
			scom.Parameters["@userID_Supevisor"].Value = userID_Supevisor;
			scom.Parameters["@userID_Manager"].Value = userID_Manager;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@terminalID_CP1"].Value = terminalID_CP1;
			scom.Parameters["@terminalID_CP2"].Value = terminalID_CP2;
			scom.Parameters["@terminalID_Supevisor"].Value = terminalID_Supevisor;
			scom.Parameters["@terminalID_Manager"].Value = terminalID_Manager;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
			scom.Parameters["@date_Checked_CP1"].Value = date_Checked_CP1;
			scom.Parameters["@date_Checked_CP2"].Value = date_Checked_CP2;
			scom.Parameters["@date_Checked_Supevisor"].Value = date_Checked_Supevisor;
			scom.Parameters["@date_Checked_Manager"].Value = date_Checked_Manager;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasEmployeeLeaveCard table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCardDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@leave_ID"].Value = leave_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCardDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
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
		/// Selects all records from the tbl_tasEmployeeLeaveCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Year_ID(string company_ID, string companyBranch_ID, int year_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCardDeleteAllByCompany_ID_CompanyBranch_ID_Year_ID", scon);
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
		/// Selects a single record from the tbl_tasEmployeeLeaveCard table.
		/// </summary>
		public static tbl_tasEmployeeLeaveCard Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string leave_ID_Incoming){

			tbl_tasEmployeeLeaveCard tbl_tasEmployeeLeaveCardins = new tbl_tasEmployeeLeaveCard();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCardSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@leave_ID"].Value = leave_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasEmployeeLeaveCardins = Maketbl_tasEmployeeLeaveCard(dataReader);
				} else {
					tbl_tasEmployeeLeaveCardins = null;
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCardins;
		}
        public static tbl_tasEmployeeLeaveCard SelectByDateRange(DateTime FromDate, DateTime ToDate, string EmployeeID)
        {

            tbl_tasEmployeeLeaveCard tbl_tasEmployeeLeaveCardins = new tbl_tasEmployeeLeaveCard();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("sp_GetAllLeavesByDateRange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@FromDate", SqlDbType.DateTime, 10);
            scom.Parameters["@FromDate"].Value = FromDate;

            scom.Parameters.Add("@ToDate", SqlDbType.DateTime, 10);
            scom.Parameters["@ToDate"].Value = ToDate;

            scom.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 20);
            scom.Parameters["@EmployeeID"].Value = EmployeeID;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_tasEmployeeLeaveCardins = Maketbl_tasEmployeeLeaveCard(dataReader);
                }
                else
                {
                    tbl_tasEmployeeLeaveCardins = null;
                }
            }
            scon.Close();
            return tbl_tasEmployeeLeaveCardins;
        }

        /// <summary>
        /// Selects all records from the tbl_tasEmployeeLeaveCard table.
        /// </summary>
        public static List<tbl_tasEmployeeLeaveCard> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCardSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasEmployeeLeaveCard> tbl_tasEmployeeLeaveCardList = new List<tbl_tasEmployeeLeaveCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeaveCard tbl_tasEmployeeLeaveCard = Maketbl_tasEmployeeLeaveCard(dataReader);
					tbl_tasEmployeeLeaveCardList.Add(tbl_tasEmployeeLeaveCard);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard table by a foreign key.
		/// </summary>
		public static List<tbl_tasEmployeeLeaveCard> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCardSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_tasEmployeeLeaveCard> tbl_tasEmployeeLeaveCardList = new List<tbl_tasEmployeeLeaveCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeaveCard tbl_tasEmployeeLeaveCard = Maketbl_tasEmployeeLeaveCard(dataReader);
					tbl_tasEmployeeLeaveCardList.Add(tbl_tasEmployeeLeaveCard);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard table by a foreign key.
		/// </summary>
		public static List<tbl_tasEmployeeLeaveCard> SelectAllByCompany_ID_CompanyBranch_ID_Year_ID(string company_ID, string companyBranch_ID, int year_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCardSelectAllByCompany_ID_CompanyBranch_ID_Year_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
				List<tbl_tasEmployeeLeaveCard> tbl_tasEmployeeLeaveCardList = new List<tbl_tasEmployeeLeaveCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeaveCard tbl_tasEmployeeLeaveCard = Maketbl_tasEmployeeLeaveCard(dataReader);
					tbl_tasEmployeeLeaveCardList.Add(tbl_tasEmployeeLeaveCard);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCardList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasEmployeeLeaveCard class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasEmployeeLeaveCard Maketbl_tasEmployeeLeaveCard(SqlDataReader dataReader) {
			tbl_tasEmployeeLeaveCard tbl_tasEmployeeLeaveCard = new tbl_tasEmployeeLeaveCard();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasEmployeeLeaveCard.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasEmployeeLeaveCard.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasEmployeeLeaveCard.Leave_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasEmployeeLeaveCard.Employee_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasEmployeeLeaveCard.Year_ID = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasEmployeeLeaveCard.Leave_Start = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasEmployeeLeaveCard.Leave_End = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasEmployeeLeaveCard.LeaveType_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasEmployeeLeaveCard.Leaves_Utilized = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasEmployeeLeaveCard.Reason = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasEmployeeLeaveCard.ApprovalStatus_CP1 = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasEmployeeLeaveCard.ApprovalStatus_CP2 = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasEmployeeLeaveCard.ApprovalStatus_Supevosior = dataReader.GetInt32(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasEmployeeLeaveCard.ApprovalStatus_Manager = dataReader.GetInt32(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasEmployeeLeaveCard.Comments_CP1 = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_tasEmployeeLeaveCard.Comments_CP2 = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_tasEmployeeLeaveCard.Comments_Supevisor = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_tasEmployeeLeaveCard.Comments_Manager = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_tasEmployeeLeaveCard.IsCancled = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_tasEmployeeLeaveCard.UserID_Created = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_tasEmployeeLeaveCard.UserID_Modified = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_tasEmployeeLeaveCard.UserID_Canceled = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_tasEmployeeLeaveCard.UserID_CP1 = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_tasEmployeeLeaveCard.UserID_CP2 = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_tasEmployeeLeaveCard.UserID_Supevisor = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_tasEmployeeLeaveCard.UserID_Manager = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_tasEmployeeLeaveCard.TerminalID_Created = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_tasEmployeeLeaveCard.TerminalID_Modified = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_tasEmployeeLeaveCard.TerminalID_Canceled = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_tasEmployeeLeaveCard.TerminalID_CP1 = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_tasEmployeeLeaveCard.TerminalID_CP2 = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_tasEmployeeLeaveCard.TerminalID_Supevisor = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_tasEmployeeLeaveCard.TerminalID_Manager = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_tasEmployeeLeaveCard.Date_Created = dataReader.GetDateTime(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_tasEmployeeLeaveCard.Date_Modified = dataReader.GetDateTime(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_tasEmployeeLeaveCard.Date_Canceled = dataReader.GetDateTime(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_tasEmployeeLeaveCard.Date_Checked_CP1 = dataReader.GetDateTime(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_tasEmployeeLeaveCard.Date_Checked_CP2 = dataReader.GetDateTime(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_tasEmployeeLeaveCard.Date_Checked_Supevisor = dataReader.GetDateTime(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_tasEmployeeLeaveCard.Date_Checked_Manager = dataReader.GetDateTime(39);
			}

			return tbl_tasEmployeeLeaveCard;
		}
		/// <summary>
		/// This makes tbl_tasEmployeeLeaveCard datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeLeaveCard object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasEmployeeLeaveCard  tbl_tasEmployeeLeaveCard   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_leave_ID = new DataColumn("leave_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_year_ID = new DataColumn("year_ID" , typeof(int));
			DataColumn col_leave_Start = new DataColumn("leave_Start" , typeof(DateTime));
			DataColumn col_leave_End = new DataColumn("leave_End" , typeof(DateTime));
			DataColumn col_leaveType_ID = new DataColumn("leaveType_ID" , typeof(string));
			DataColumn col_leaves_Utilized = new DataColumn("leaves_Utilized" , typeof(decimal));
			DataColumn col_reason = new DataColumn("reason" , typeof(string));
			DataColumn col_approvalStatus_CP1 = new DataColumn("approvalStatus_CP1" , typeof(int));
			DataColumn col_approvalStatus_CP2 = new DataColumn("approvalStatus_CP2" , typeof(int));
			DataColumn col_approvalStatus_Supevosior = new DataColumn("approvalStatus_Supevosior" , typeof(int));
			DataColumn col_approvalStatus_Manager = new DataColumn("approvalStatus_Manager" , typeof(int));
			DataColumn col_comments_CP1 = new DataColumn("comments_CP1" , typeof(string));
			DataColumn col_comments_CP2 = new DataColumn("comments_CP2" , typeof(string));
			DataColumn col_comments_Supevisor = new DataColumn("comments_Supevisor" , typeof(string));
			DataColumn col_comments_Manager = new DataColumn("comments_Manager" , typeof(string));
			DataColumn col_isCancled = new DataColumn("isCancled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_userID_CP1 = new DataColumn("userID_CP1" , typeof(string));
			DataColumn col_userID_CP2 = new DataColumn("userID_CP2" , typeof(string));
			DataColumn col_userID_Supevisor = new DataColumn("userID_Supevisor" , typeof(string));
			DataColumn col_userID_Manager = new DataColumn("userID_Manager" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_terminalID_CP1 = new DataColumn("terminalID_CP1" , typeof(string));
			DataColumn col_terminalID_CP2 = new DataColumn("terminalID_CP2" , typeof(string));
			DataColumn col_terminalID_Supevisor = new DataColumn("terminalID_Supevisor" , typeof(string));
			DataColumn col_terminalID_Manager = new DataColumn("terminalID_Manager" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
			DataColumn col_date_Checked_CP1 = new DataColumn("date_Checked_CP1" , typeof(DateTime));
			DataColumn col_date_Checked_CP2 = new DataColumn("date_Checked_CP2" , typeof(DateTime));
			DataColumn col_date_Checked_Supevisor = new DataColumn("date_Checked_Supevisor" , typeof(DateTime));
			DataColumn col_date_Checked_Manager = new DataColumn("date_Checked_Manager" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_leave_ID,col_employee_ID,col_year_ID,col_leave_Start,col_leave_End,col_leaveType_ID,col_leaves_Utilized,col_reason,col_approvalStatus_CP1,col_approvalStatus_CP2,col_approvalStatus_Supevosior,col_approvalStatus_Manager,col_comments_CP1,col_comments_CP2,col_comments_Supevisor,col_comments_Manager,col_isCancled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_userID_CP1,col_userID_CP2,col_userID_Supevisor,col_userID_Manager,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_terminalID_CP1,col_terminalID_CP2,col_terminalID_Supevisor,col_terminalID_Manager,col_date_Created,col_date_Modified,col_date_Canceled,col_date_Checked_CP1,col_date_Checked_CP2,col_date_Checked_Supevisor,col_date_Checked_Manager,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasEmployeeLeaveCard datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeLeaveCard object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasEmployeeLeaveCard user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["leave_ID"] = user.leave_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["year_ID"] = user.year_ID;
			drow["leave_Start"] = user.leave_Start;
			drow["leave_End"] = user.leave_End;
			drow["leaveType_ID"] = user.leaveType_ID;
			drow["leaves_Utilized"] = user.leaves_Utilized;
			drow["reason"] = user.reason;
			drow["approvalStatus_CP1"] = user.approvalStatus_CP1;
			drow["approvalStatus_CP2"] = user.approvalStatus_CP2;
			drow["approvalStatus_Supevosior"] = user.approvalStatus_Supevosior;
			drow["approvalStatus_Manager"] = user.approvalStatus_Manager;
			drow["comments_CP1"] = user.comments_CP1;
			drow["comments_CP2"] = user.comments_CP2;
			drow["comments_Supevisor"] = user.comments_Supevisor;
			drow["comments_Manager"] = user.comments_Manager;
			drow["isCancled"] = user.isCancled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["userID_CP1"] = user.userID_CP1;
			drow["userID_CP2"] = user.userID_CP2;
			drow["userID_Supevisor"] = user.userID_Supevisor;
			drow["userID_Manager"] = user.userID_Manager;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["terminalID_CP1"] = user.terminalID_CP1;
			drow["terminalID_CP2"] = user.terminalID_CP2;
			drow["terminalID_Supevisor"] = user.terminalID_Supevisor;
			drow["terminalID_Manager"] = user.terminalID_Manager;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
			drow["date_Checked_CP1"] = user.date_Checked_CP1;
			drow["date_Checked_CP2"] = user.date_Checked_CP2;
			drow["date_Checked_Supevisor"] = user.date_Checked_Supevisor;
			drow["date_Checked_Manager"] = user.date_Checked_Manager;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
