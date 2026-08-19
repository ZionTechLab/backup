using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasEmployeeLeave_settement {
		#region Fields
		private string leaveSettement_ID;
		private string employee_ID;
		private string leave_ID;
		private string leaveType_ID;
		private decimal settled_leaves;
		private bool isCancled;
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
		/// Initializes a new instance of the tbl_tasEmployeeLeave_settement class.
		/// </summary>
		public tbl_tasEmployeeLeave_settement() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasEmployeeLeave_settement class.
		/// </summary>
		public tbl_tasEmployeeLeave_settement(string leaveSettement_ID, string employee_ID, string leave_ID, string leaveType_ID, decimal settled_leaves, bool isCancled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.leaveSettement_ID = leaveSettement_ID;
			this.employee_ID = employee_ID;
			this.leave_ID = leave_ID;
			this.leaveType_ID = leaveType_ID;
			this.settled_leaves = settled_leaves;
			this.isCancled = isCancled;
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
		/// Gets or sets the LeaveSettement_ID value.
		/// </summary>
		public string LeaveSettement_ID {
			get { return leaveSettement_ID; }
			set { leaveSettement_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Leave_ID value.
		/// </summary>
		public string Leave_ID {
			get { return leave_ID; }
			set { leave_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LeaveType_ID value.
		/// </summary>
		public string LeaveType_ID {
			get { return leaveType_ID; }
			set { leaveType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Settled_leaves value.
		/// </summary>
		public decimal Settled_leaves {
			get { return settled_leaves; }
			set { settled_leaves = value; }
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
		/// Saves a record to the tbl_tasEmployeeLeave_settement table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@leaveSettement_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@settled_leaves", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCancled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@leaveSettement_ID"].Value = leaveSettement_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@leave_ID"].Value = leave_ID;
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
			scom.Parameters["@settled_leaves"].Value = settled_leaves;
			scom.Parameters["@isCancled"].Value = isCancled;
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
		/// Updates a record in the tbl_tasEmployeeLeave_settement table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@leaveSettement_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@settled_leaves", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCancled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@leaveSettement_ID"].Value = leaveSettement_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@leave_ID"].Value = leave_ID;
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
			scom.Parameters["@settled_leaves"].Value = settled_leaves;
			scom.Parameters["@isCancled"].Value = isCancled;
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
		/// Deletes a record from the tbl_tasEmployeeLeave_settement table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@leaveSettement_ID", SqlDbType.VarChar,10);
			scom.Parameters["@leaveSettement_ID"].Value = leaveSettement_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_settement table by a foreign key.
		/// </summary>
		public static void DeleteAllByLeave_ID(string leave_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementDeleteAllByLeave_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters["@leave_ID"].Value = leave_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_settement table by a foreign key.
		/// </summary>
		public static void DeleteAllByLeaveType_ID(string leaveType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementDeleteAllByLeaveType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_settement table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasEmployeeLeave_settement table.
		/// </summary>
		public static tbl_tasEmployeeLeave_settement Select(string leaveSettement_ID_Incoming){

			tbl_tasEmployeeLeave_settement tbl_tasEmployeeLeave_settementins = new tbl_tasEmployeeLeave_settement();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@leaveSettement_ID", SqlDbType.VarChar,10);
			scom.Parameters["@leaveSettement_ID"].Value = leaveSettement_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasEmployeeLeave_settementins = Maketbl_tasEmployeeLeave_settement(dataReader);
				} else {
					tbl_tasEmployeeLeave_settementins = null;
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeave_settementins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_settement table.
		/// </summary>
		public static List<tbl_tasEmployeeLeave_settement> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasEmployeeLeave_settement> tbl_tasEmployeeLeave_settementList = new List<tbl_tasEmployeeLeave_settement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeave_settement tbl_tasEmployeeLeave_settement = Maketbl_tasEmployeeLeave_settement(dataReader);
					tbl_tasEmployeeLeave_settementList.Add(tbl_tasEmployeeLeave_settement);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeave_settementList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_settement table by a foreign key.
		/// </summary>
		public static List<tbl_tasEmployeeLeave_settement> SelectAllByLeave_ID(string leave_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementSelectAllByLeave_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters["@leave_ID"].Value = leave_ID;
				List<tbl_tasEmployeeLeave_settement> tbl_tasEmployeeLeave_settementList = new List<tbl_tasEmployeeLeave_settement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeave_settement tbl_tasEmployeeLeave_settement = Maketbl_tasEmployeeLeave_settement(dataReader);
					tbl_tasEmployeeLeave_settementList.Add(tbl_tasEmployeeLeave_settement);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeave_settementList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_settement table by a foreign key.
		/// </summary>
		public static List<tbl_tasEmployeeLeave_settement> SelectAllByLeaveType_ID(string leaveType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementSelectAllByLeaveType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
				List<tbl_tasEmployeeLeave_settement> tbl_tasEmployeeLeave_settementList = new List<tbl_tasEmployeeLeave_settement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeave_settement tbl_tasEmployeeLeave_settement = Maketbl_tasEmployeeLeave_settement(dataReader);
					tbl_tasEmployeeLeave_settementList.Add(tbl_tasEmployeeLeave_settement);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeave_settementList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_settement table by a foreign key.
		/// </summary>
		public static List<tbl_tasEmployeeLeave_settement> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_settementSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_tasEmployeeLeave_settement> tbl_tasEmployeeLeave_settementList = new List<tbl_tasEmployeeLeave_settement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeave_settement tbl_tasEmployeeLeave_settement = Maketbl_tasEmployeeLeave_settement(dataReader);
					tbl_tasEmployeeLeave_settementList.Add(tbl_tasEmployeeLeave_settement);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeave_settementList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasEmployeeLeave_settement class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasEmployeeLeave_settement Maketbl_tasEmployeeLeave_settement(SqlDataReader dataReader) {
			tbl_tasEmployeeLeave_settement tbl_tasEmployeeLeave_settement = new tbl_tasEmployeeLeave_settement();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasEmployeeLeave_settement.LeaveSettement_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasEmployeeLeave_settement.Employee_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasEmployeeLeave_settement.Leave_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasEmployeeLeave_settement.LeaveType_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasEmployeeLeave_settement.Settled_leaves = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasEmployeeLeave_settement.IsCancled = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasEmployeeLeave_settement.UserID_Created = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasEmployeeLeave_settement.UserID_Modified = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasEmployeeLeave_settement.UserID_Canceled = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasEmployeeLeave_settement.TerminalID_Created = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasEmployeeLeave_settement.TerminalID_Modified = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasEmployeeLeave_settement.TerminalID_Canceled = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasEmployeeLeave_settement.Date_Created = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasEmployeeLeave_settement.Date_Modified = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasEmployeeLeave_settement.Date_Canceled = dataReader.GetDateTime(14);
			}

			return tbl_tasEmployeeLeave_settement;
		}
		/// <summary>
		/// This makes tbl_tasEmployeeLeave_settement datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeLeave_settement object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasEmployeeLeave_settement  tbl_tasEmployeeLeave_settement   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_leaveSettement_ID = new DataColumn("leaveSettement_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_leave_ID = new DataColumn("leave_ID" , typeof(string));
			DataColumn col_leaveType_ID = new DataColumn("leaveType_ID" , typeof(string));
			DataColumn col_settled_leaves = new DataColumn("settled_leaves" , typeof(decimal));
			DataColumn col_isCancled = new DataColumn("isCancled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_leaveSettement_ID,col_employee_ID,col_leave_ID,col_leaveType_ID,col_settled_leaves,col_isCancled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasEmployeeLeave_settement datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeLeave_settement object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasEmployeeLeave_settement user) {
		DataRow drow = dt.NewRow();
		
			drow["leaveSettement_ID"] = user.leaveSettement_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["leave_ID"] = user.leave_ID;
			drow["leaveType_ID"] = user.leaveType_ID;
			drow["settled_leaves"] = user.settled_leaves;
			drow["isCancled"] = user.isCancled;
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
