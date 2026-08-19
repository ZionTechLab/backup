using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasGreeting {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string greet_ID;
		private int greet_Party;
		private int greet_Type;
		private string email_Subj;
		private string email_To;
		private string email_BCC;
		private byte[] greet_Image;
		private DateTime alert_Time;
		private int eMail_ID;
		private bool isChecked;
		private bool isApproved;
		private bool isCanceled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Checked;
		private string userID_Approved;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Checked;
		private string terminalID_Approved;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Checked;
		private DateTime date_Approved;
		private DateTime date_Canceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasGreeting class.
		/// </summary>
		public tbl_tasGreeting() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasGreeting class.
		/// </summary>
		public tbl_tasGreeting(string company_ID, string companyBranch_ID, string greet_ID, int greet_Party, int greet_Type, string email_Subj, string email_To, string email_BCC, byte[] greet_Image, DateTime alert_Time, int eMail_ID, bool isChecked, bool isApproved, bool isCanceled, string userID_Created, string userID_Modified, string userID_Checked, string userID_Approved, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Checked, string terminalID_Approved, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Checked, DateTime date_Approved, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.greet_ID = greet_ID;
			this.greet_Party = greet_Party;
			this.greet_Type = greet_Type;
			this.email_Subj = email_Subj;
			this.email_To = email_To;
			this.email_BCC = email_BCC;
			this.greet_Image = greet_Image;
			this.alert_Time = alert_Time;
			this.eMail_ID = eMail_ID;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isCanceled = isCanceled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Checked = userID_Checked;
			this.userID_Approved = userID_Approved;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Checked = terminalID_Checked;
			this.terminalID_Approved = terminalID_Approved;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Checked = date_Checked;
			this.date_Approved = date_Approved;
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
		/// Gets or sets the Greet_ID value.
		/// </summary>
		public string Greet_ID {
			get { return greet_ID; }
			set { greet_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Greet_Party value.
		/// </summary>
		public int Greet_Party {
			get { return greet_Party; }
			set { greet_Party = value; }
		}
		
		/// <summary>
		/// Gets or sets the Greet_Type value.
		/// </summary>
		public int Greet_Type {
			get { return greet_Type; }
			set { greet_Type = value; }
		}
		
		/// <summary>
		/// Gets or sets the Email_Subj value.
		/// </summary>
		public string Email_Subj {
			get { return email_Subj; }
			set { email_Subj = value; }
		}
		
		/// <summary>
		/// Gets or sets the Email_To value.
		/// </summary>
		public string Email_To {
			get { return email_To; }
			set { email_To = value; }
		}
		
		/// <summary>
		/// Gets or sets the Email_BCC value.
		/// </summary>
		public string Email_BCC {
			get { return email_BCC; }
			set { email_BCC = value; }
		}
		
		/// <summary>
		/// Gets or sets the Greet_Image value.
		/// </summary>
		public byte[] Greet_Image {
			get { return greet_Image; }
			set { greet_Image = value; }
		}
		
		/// <summary>
		/// Gets or sets the Alert_Time value.
		/// </summary>
		public DateTime Alert_Time {
			get { return alert_Time; }
			set { alert_Time = value; }
		}
		
		/// <summary>
		/// Gets or sets the EMail_ID value.
		/// </summary>
		public int EMail_ID {
			get { return eMail_ID; }
			set { eMail_ID = value; }
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
		/// Gets or sets the UserID_Checked value.
		/// </summary>
		public string UserID_Checked {
			get { return userID_Checked; }
			set { userID_Checked = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Approved value.
		/// </summary>
		public string UserID_Approved {
			get { return userID_Approved; }
			set { userID_Approved = value; }
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
		/// Gets or sets the TerminalID_Checked value.
		/// </summary>
		public string TerminalID_Checked {
			get { return terminalID_Checked; }
			set { terminalID_Checked = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Approved value.
		/// </summary>
		public string TerminalID_Approved {
			get { return terminalID_Approved; }
			set { terminalID_Approved = value; }
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
		/// Gets or sets the Date_Checked value.
		/// </summary>
		public DateTime Date_Checked {
			get { return date_Checked; }
			set { date_Checked = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Approved value.
		/// </summary>
		public DateTime Date_Approved {
			get { return date_Approved; }
			set { date_Approved = value; }
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
		/// Saves a record to the tbl_tasGreeting table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@greet_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@greet_Party", SqlDbType.Int,4);
			scom.Parameters.Add("@greet_Type", SqlDbType.Int,4);
			scom.Parameters.Add("@email_Subj", SqlDbType.VarChar,200);
			scom.Parameters.Add("@email_To", SqlDbType.VarChar,200);
			scom.Parameters.Add("@email_BCC", SqlDbType.VarChar,200);
			scom.Parameters.Add("@greet_Image", SqlDbType.Image,2147483647);
			scom.Parameters.Add("@alert_Time", SqlDbType.DateTime,8);
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Checked", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Approved", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Checked", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Approved", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,100);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Approved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@greet_ID"].Value = greet_ID;
			scom.Parameters["@greet_Party"].Value = greet_Party;
			scom.Parameters["@greet_Type"].Value = greet_Type;
			scom.Parameters["@email_Subj"].Value = email_Subj;
			scom.Parameters["@email_To"].Value = email_To;
			scom.Parameters["@email_BCC"].Value = email_BCC;
			scom.Parameters["@greet_Image"].Value = greet_Image;
			scom.Parameters["@alert_Time"].Value = alert_Time;
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Checked"].Value = userID_Checked;
			scom.Parameters["@userID_Approved"].Value = userID_Approved;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Checked"].Value = terminalID_Checked;
			scom.Parameters["@terminalID_Approved"].Value = terminalID_Approved;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Checked"].Value = date_Checked;
			scom.Parameters["@date_Approved"].Value = date_Approved;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasGreeting table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@greet_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@greet_Party", SqlDbType.Int,4);
			scom.Parameters.Add("@greet_Type", SqlDbType.Int,4);
			scom.Parameters.Add("@email_Subj", SqlDbType.VarChar,200);
			scom.Parameters.Add("@email_To", SqlDbType.VarChar,200);
			scom.Parameters.Add("@email_BCC", SqlDbType.VarChar,200);
			scom.Parameters.Add("@greet_Image", SqlDbType.Image,2147483647);
			scom.Parameters.Add("@alert_Time", SqlDbType.DateTime,8);
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Checked", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Approved", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Checked", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Approved", SqlDbType.VarChar,100);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,100);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Checked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Approved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@greet_ID"].Value = greet_ID;
			scom.Parameters["@greet_Party"].Value = greet_Party;
			scom.Parameters["@greet_Type"].Value = greet_Type;
			scom.Parameters["@email_Subj"].Value = email_Subj;
			scom.Parameters["@email_To"].Value = email_To;
			scom.Parameters["@email_BCC"].Value = email_BCC;
			scom.Parameters["@greet_Image"].Value = greet_Image;
			scom.Parameters["@alert_Time"].Value = alert_Time;
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Checked"].Value = userID_Checked;
			scom.Parameters["@userID_Approved"].Value = userID_Approved;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Checked"].Value = terminalID_Checked;
			scom.Parameters["@terminalID_Approved"].Value = terminalID_Approved;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Checked"].Value = date_Checked;
			scom.Parameters["@date_Approved"].Value = date_Approved;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasGreeting table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@greet_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@greet_ID"].Value = greet_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID(string company_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingDeleteAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserID_Modified(string userID_Modified) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingDeleteAllByUserID_Modified", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserID_Created(string userID_Created) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingDeleteAllByUserID_Created", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Created"].Value = userID_Created;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserID_Checked(string userID_Checked) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingDeleteAllByUserID_Checked", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Checked", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Checked"].Value = userID_Checked;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserID_Approved(string userID_Approved) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingDeleteAllByUserID_Approved", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Approved", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Approved"].Value = userID_Approved;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static void DeleteAllByEMail_ID(int eMail_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingDeleteAllByEMail_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static void DeleteAllByUserID_Canceled(string userID_Canceled) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingDeleteAllByUserID_Canceled", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasGreeting table.
		/// </summary>
		public static tbl_tasGreeting Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string greet_ID_Incoming){

			tbl_tasGreeting tbl_tasGreetingins = new tbl_tasGreeting();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@greet_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@greet_ID"].Value = greet_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasGreetingins = Maketbl_tasGreeting(dataReader);
				} else {
					tbl_tasGreetingins = null;
				}
			}
			scon.Close();
			return tbl_tasGreetingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table.
		/// </summary>
		public static List<tbl_tasGreeting> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasGreeting> tbl_tasGreetingList = new List<tbl_tasGreeting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting tbl_tasGreeting = Maketbl_tasGreeting(dataReader);
					tbl_tasGreetingList.Add(tbl_tasGreeting);
				}
			}
			scon.Close();
			return tbl_tasGreetingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static List<tbl_tasGreeting> SelectAllByCompany_ID(string company_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingSelectAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
				List<tbl_tasGreeting> tbl_tasGreetingList = new List<tbl_tasGreeting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting tbl_tasGreeting = Maketbl_tasGreeting(dataReader);
					tbl_tasGreetingList.Add(tbl_tasGreeting);
				}
			}
			scon.Close();
			return tbl_tasGreetingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static List<tbl_tasGreeting> SelectAllByUserID_Modified(string userID_Modified) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingSelectAllByUserID_Modified", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
				List<tbl_tasGreeting> tbl_tasGreetingList = new List<tbl_tasGreeting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting tbl_tasGreeting = Maketbl_tasGreeting(dataReader);
					tbl_tasGreetingList.Add(tbl_tasGreeting);
				}
			}
			scon.Close();
			return tbl_tasGreetingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static List<tbl_tasGreeting> SelectAllByUserID_Created(string userID_Created) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingSelectAllByUserID_Created", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Created"].Value = userID_Created;
				List<tbl_tasGreeting> tbl_tasGreetingList = new List<tbl_tasGreeting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting tbl_tasGreeting = Maketbl_tasGreeting(dataReader);
					tbl_tasGreetingList.Add(tbl_tasGreeting);
				}
			}
			scon.Close();
			return tbl_tasGreetingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static List<tbl_tasGreeting> SelectAllByUserID_Checked(string userID_Checked) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingSelectAllByUserID_Checked", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Checked", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Checked"].Value = userID_Checked;
				List<tbl_tasGreeting> tbl_tasGreetingList = new List<tbl_tasGreeting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting tbl_tasGreeting = Maketbl_tasGreeting(dataReader);
					tbl_tasGreetingList.Add(tbl_tasGreeting);
				}
			}
			scon.Close();
			return tbl_tasGreetingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static List<tbl_tasGreeting> SelectAllByUserID_Approved(string userID_Approved) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingSelectAllByUserID_Approved", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Approved", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Approved"].Value = userID_Approved;
				List<tbl_tasGreeting> tbl_tasGreetingList = new List<tbl_tasGreeting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting tbl_tasGreeting = Maketbl_tasGreeting(dataReader);
					tbl_tasGreetingList.Add(tbl_tasGreeting);
				}
			}
			scon.Close();
			return tbl_tasGreetingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static List<tbl_tasGreeting> SelectAllByEMail_ID(int eMail_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingSelectAllByEMail_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
				List<tbl_tasGreeting> tbl_tasGreetingList = new List<tbl_tasGreeting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting tbl_tasGreeting = Maketbl_tasGreeting(dataReader);
					tbl_tasGreetingList.Add(tbl_tasGreeting);
				}
			}
			scon.Close();
			return tbl_tasGreetingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting table by a foreign key.
		/// </summary>
		public static List<tbl_tasGreeting> SelectAllByUserID_Canceled(string userID_Canceled) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreetingSelectAllByUserID_Canceled", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
				List<tbl_tasGreeting> tbl_tasGreetingList = new List<tbl_tasGreeting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting tbl_tasGreeting = Maketbl_tasGreeting(dataReader);
					tbl_tasGreetingList.Add(tbl_tasGreeting);
				}
			}
			scon.Close();
			return tbl_tasGreetingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasGreeting class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasGreeting Maketbl_tasGreeting(SqlDataReader dataReader) {
			tbl_tasGreeting tbl_tasGreeting = new tbl_tasGreeting();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasGreeting.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasGreeting.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasGreeting.Greet_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasGreeting.Greet_Party = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasGreeting.Greet_Type = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasGreeting.Email_Subj = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasGreeting.Email_To = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasGreeting.Email_BCC = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasGreeting.Greet_Image = (byte[])dataReader[8];
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasGreeting.Alert_Time = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasGreeting.EMail_ID = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasGreeting.IsChecked = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasGreeting.IsApproved = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasGreeting.IsCanceled = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasGreeting.UserID_Created = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_tasGreeting.UserID_Modified = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_tasGreeting.UserID_Checked = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_tasGreeting.UserID_Approved = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_tasGreeting.UserID_Canceled = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_tasGreeting.TerminalID_Created = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_tasGreeting.TerminalID_Modified = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_tasGreeting.TerminalID_Checked = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_tasGreeting.TerminalID_Approved = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_tasGreeting.TerminalID_Canceled = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_tasGreeting.Date_Created = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_tasGreeting.Date_Modified = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_tasGreeting.Date_Checked = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_tasGreeting.Date_Approved = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_tasGreeting.Date_Canceled = dataReader.GetDateTime(28);
			}

			return tbl_tasGreeting;
		}
		/// <summary>
		/// This makes tbl_tasGreeting datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasGreeting object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasGreeting  tbl_tasGreeting   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_greet_ID = new DataColumn("greet_ID" , typeof(string));
			DataColumn col_greet_Party = new DataColumn("greet_Party" , typeof(int));
			DataColumn col_greet_Type = new DataColumn("greet_Type" , typeof(int));
			DataColumn col_email_Subj = new DataColumn("email_Subj" , typeof(string));
			DataColumn col_email_To = new DataColumn("email_To" , typeof(string));
			DataColumn col_email_BCC = new DataColumn("email_BCC" , typeof(string));
			DataColumn col_greet_Image = new DataColumn("greet_Image" , typeof(byte));
			DataColumn col_alert_Time = new DataColumn("alert_Time" , typeof(DateTime));
			DataColumn col_eMail_ID = new DataColumn("eMail_ID" , typeof(int));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Checked = new DataColumn("userID_Checked" , typeof(string));
			DataColumn col_userID_Approved = new DataColumn("userID_Approved" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Checked = new DataColumn("terminalID_Checked" , typeof(string));
			DataColumn col_terminalID_Approved = new DataColumn("terminalID_Approved" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Checked = new DataColumn("date_Checked" , typeof(DateTime));
			DataColumn col_date_Approved = new DataColumn("date_Approved" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_greet_ID,col_greet_Party,col_greet_Type,col_email_Subj,col_email_To,col_email_BCC,col_greet_Image,col_alert_Time,col_eMail_ID,col_isChecked,col_isApproved,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Checked,col_userID_Approved,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Checked,col_terminalID_Approved,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Checked,col_date_Approved,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasGreeting datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasGreeting object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasGreeting user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["greet_ID"] = user.greet_ID;
			drow["greet_Party"] = user.greet_Party;
			drow["greet_Type"] = user.greet_Type;
			drow["email_Subj"] = user.email_Subj;
			drow["email_To"] = user.email_To;
			drow["email_BCC"] = user.email_BCC;
			drow["greet_Image"] = user.greet_Image;
			drow["alert_Time"] = user.alert_Time;
			drow["eMail_ID"] = user.eMail_ID;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isCanceled"] = user.isCanceled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Checked"] = user.userID_Checked;
			drow["userID_Approved"] = user.userID_Approved;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Checked"] = user.terminalID_Checked;
			drow["terminalID_Approved"] = user.terminalID_Approved;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Checked"] = user.date_Checked;
			drow["date_Approved"] = user.date_Approved;
			drow["date_Canceled"] = user.date_Canceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
