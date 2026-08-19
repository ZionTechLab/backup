using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMasBankBranch {
		#region Fields
		private string bankBranch_ID;
		private string bankBranch_code;
		private string bank_ID;
		private string branchName;
		private string originalBranchCode;
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
		/// Initializes a new instance of the tbl_genMasBankBranch class.
		/// </summary>
		public tbl_genMasBankBranch() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMasBankBranch class.
		/// </summary>
		public tbl_genMasBankBranch(string bankBranch_ID, string bankBranch_code, string bank_ID, string branchName, string originalBranchCode, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.bankBranch_ID = bankBranch_ID;
			this.bankBranch_code = bankBranch_code;
			this.bank_ID = bank_ID;
			this.branchName = branchName;
			this.originalBranchCode = originalBranchCode;
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
		/// Gets or sets the BankBranch_ID value.
		/// </summary>
		public string BankBranch_ID {
			get { return bankBranch_ID; }
			set { bankBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankBranch_code value.
		/// </summary>
		public string BankBranch_code {
			get { return bankBranch_code; }
			set { bankBranch_code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bank_ID value.
		/// </summary>
		public string Bank_ID {
			get { return bank_ID; }
			set { bank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BranchName value.
		/// </summary>
		public string BranchName {
			get { return branchName; }
			set { branchName = value; }
		}
		
		/// <summary>
		/// Gets or sets the OriginalBranchCode value.
		/// </summary>
		public string OriginalBranchCode {
			get { return originalBranchCode; }
			set { originalBranchCode = value; }
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
		/// Saves a record to the tbl_genMasBankBranch table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasBankBranchInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankBranch_code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branchName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@originalBranchCode", SqlDbType.VarChar,20);
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
 
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
			scom.Parameters["@bankBranch_code"].Value = bankBranch_code;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branchName"].Value = branchName;
			scom.Parameters["@originalBranchCode"].Value = originalBranchCode;
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
		/// Updates a record in the tbl_genMasBankBranch table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasBankBranchUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bankBranch_code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branchName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@originalBranchCode", SqlDbType.VarChar,20);
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
 
 
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
			scom.Parameters["@bankBranch_code"].Value = bankBranch_code;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branchName"].Value = branchName;
			scom.Parameters["@originalBranchCode"].Value = originalBranchCode;
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
		/// Deletes a record from the tbl_genMasBankBranch table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasBankBranchDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasBankBranch table by a foreign key.
		/// </summary>
		public static void DeleteAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasBankBranchDeleteAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMasBankBranch table.
		/// </summary>
		public static tbl_genMasBankBranch Select(string bankBranch_ID_Incoming){

			tbl_genMasBankBranch tbl_genMasBankBranchins = new tbl_genMasBankBranch();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasBankBranchSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bankBranch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bankBranch_ID"].Value = bankBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMasBankBranchins = Maketbl_genMasBankBranch(dataReader);
				} else {
					tbl_genMasBankBranchins = null;
				}
			}
			scon.Close();
			return tbl_genMasBankBranchins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasBankBranch table.
		/// </summary>
		public static List<tbl_genMasBankBranch> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasBankBranchSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMasBankBranch> tbl_genMasBankBranchList = new List<tbl_genMasBankBranch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasBankBranch tbl_genMasBankBranch = Maketbl_genMasBankBranch(dataReader);
					tbl_genMasBankBranchList.Add(tbl_genMasBankBranch);
				}
			}
			scon.Close();
			return tbl_genMasBankBranchList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasBankBranch table by a foreign key.
		/// </summary>
		public static List<tbl_genMasBankBranch> SelectAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasBankBranchSelectAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
				List<tbl_genMasBankBranch> tbl_genMasBankBranchList = new List<tbl_genMasBankBranch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasBankBranch tbl_genMasBankBranch = Maketbl_genMasBankBranch(dataReader);
					tbl_genMasBankBranchList.Add(tbl_genMasBankBranch);
				}
			}
			scon.Close();
			return tbl_genMasBankBranchList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMasBankBranch class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMasBankBranch Maketbl_genMasBankBranch(SqlDataReader dataReader) {
			tbl_genMasBankBranch tbl_genMasBankBranch = new tbl_genMasBankBranch();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMasBankBranch.BankBranch_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMasBankBranch.BankBranch_code = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMasBankBranch.Bank_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMasBankBranch.BranchName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMasBankBranch.OriginalBranchCode = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMasBankBranch.IsCanceled = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genMasBankBranch.UserID_Created = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genMasBankBranch.UserID_Modified = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genMasBankBranch.UserID_Canceled = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genMasBankBranch.TerminalID_Created = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genMasBankBranch.TerminalID_Modified = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genMasBankBranch.TerminalID_Canceled = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genMasBankBranch.Date_Created = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genMasBankBranch.Date_Modified = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genMasBankBranch.Date_Canceled = dataReader.GetDateTime(14);
			}

			return tbl_genMasBankBranch;
		}
		/// <summary>
		/// This makes tbl_genMasBankBranch datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMasBankBranch object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMasBankBranch  tbl_genMasBankBranch   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_bankBranch_ID = new DataColumn("bankBranch_ID" , typeof(string));
			DataColumn col_bankBranch_code = new DataColumn("bankBranch_code" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_branchName = new DataColumn("branchName" , typeof(string));
			DataColumn col_originalBranchCode = new DataColumn("originalBranchCode" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_bankBranch_ID,col_bankBranch_code,col_bank_ID,col_branchName,col_originalBranchCode,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMasBankBranch datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMasBankBranch object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMasBankBranch user) {
		DataRow drow = dt.NewRow();
		
			drow["bankBranch_ID"] = user.bankBranch_ID;
			drow["bankBranch_code"] = user.bankBranch_code;
			drow["bank_ID"] = user.bank_ID;
			drow["branchName"] = user.branchName;
			drow["originalBranchCode"] = user.originalBranchCode;
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
