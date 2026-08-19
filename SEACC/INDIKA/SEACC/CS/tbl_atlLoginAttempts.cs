using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_atlLoginAttempts {
		#region Fields
		private Int64 transaction_ID;
		private string terminal_ID;
		private string userID;
		private string userPassword;
		private bool isAttemptFail;
		private DateTime attemptDate;
		private string message;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_atlLoginAttempts class.
		/// </summary>
		public tbl_atlLoginAttempts() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlLoginAttempts class.
		/// </summary>
		public tbl_atlLoginAttempts(string terminal_ID, string userID, string userPassword, bool isAttemptFail, DateTime attemptDate, string message) {
			this.terminal_ID = terminal_ID;
			this.userID = userID;
			this.userPassword = userPassword;
			this.isAttemptFail = isAttemptFail;
			this.attemptDate = attemptDate;
			this.message = message;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_atlLoginAttempts class.
		/// </summary>
		public tbl_atlLoginAttempts(Int64 transaction_ID, string terminal_ID, string userID, string userPassword, bool isAttemptFail, DateTime attemptDate, string message) {
			this.transaction_ID = transaction_ID;
			this.terminal_ID = terminal_ID;
			this.userID = userID;
			this.userPassword = userPassword;
			this.isAttemptFail = isAttemptFail;
			this.attemptDate = attemptDate;
			this.message = message;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public Int64 Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID value.
		/// </summary>
		public string UserID {
			get { return userID; }
			set { userID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserPassword value.
		/// </summary>
		public string UserPassword {
			get { return userPassword; }
			set { userPassword = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAttemptFail value.
		/// </summary>
		public bool IsAttemptFail {
			get { return isAttemptFail; }
			set { isAttemptFail = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttemptDate value.
		/// </summary>
		public DateTime AttemptDate {
			get { return attemptDate; }
			set { attemptDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Message value.
		/// </summary>
		public string Message {
			get { return message; }
			set { message = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_atlLoginAttempts table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlLoginAttemptsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@userID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userPassword", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isAttemptFail", SqlDbType.Bit,1);
			scom.Parameters.Add("@attemptDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@message", SqlDbType.VarChar,-1);
 
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@userID"].Value = userID;
			scom.Parameters["@userPassword"].Value = userPassword;
			scom.Parameters["@isAttemptFail"].Value = isAttemptFail;
			scom.Parameters["@attemptDate"].Value = attemptDate;
			scom.Parameters["@message"].Value = message;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_atlLoginAttempts table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlLoginAttemptsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@userID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userPassword", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isAttemptFail", SqlDbType.Bit,1);
			scom.Parameters.Add("@attemptDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@message", SqlDbType.VarChar,-1);
 
 
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@userID"].Value = userID;
			scom.Parameters["@userPassword"].Value = userPassword;
			scom.Parameters["@isAttemptFail"].Value = isAttemptFail;
			scom.Parameters["@attemptDate"].Value = attemptDate;
			scom.Parameters["@message"].Value = message;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_atlLoginAttempts table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlLoginAttemptsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt,8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_atlLoginAttempts table.
		/// </summary>
		public static tbl_atlLoginAttempts Select(Int64 transaction_ID_Incoming){

			tbl_atlLoginAttempts tbl_atlLoginAttemptsins = new tbl_atlLoginAttempts();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlLoginAttemptsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt,8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_atlLoginAttemptsins = Maketbl_atlLoginAttempts(dataReader);
				} else {
					tbl_atlLoginAttemptsins = null;
				}
			}
			scon.Close();
			return tbl_atlLoginAttemptsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_atlLoginAttempts table.
		/// </summary>
		public static List<tbl_atlLoginAttempts> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_atlLoginAttemptsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_atlLoginAttempts> tbl_atlLoginAttemptsList = new List<tbl_atlLoginAttempts>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_atlLoginAttempts tbl_atlLoginAttempts = Maketbl_atlLoginAttempts(dataReader);
					tbl_atlLoginAttemptsList.Add(tbl_atlLoginAttempts);
				}
			}
			scon.Close();
			return tbl_atlLoginAttemptsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_atlLoginAttempts class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_atlLoginAttempts Maketbl_atlLoginAttempts(SqlDataReader dataReader) {
			tbl_atlLoginAttempts tbl_atlLoginAttempts = new tbl_atlLoginAttempts();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_atlLoginAttempts.Transaction_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_atlLoginAttempts.Terminal_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_atlLoginAttempts.UserID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_atlLoginAttempts.UserPassword = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_atlLoginAttempts.IsAttemptFail = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_atlLoginAttempts.AttemptDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_atlLoginAttempts.Message = dataReader.GetString(6);
			}

			return tbl_atlLoginAttempts;
		}
		/// <summary>
		/// This makes tbl_atlLoginAttempts datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_atlLoginAttempts object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_atlLoginAttempts  tbl_atlLoginAttempts   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(Int64));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_userID = new DataColumn("userID" , typeof(string));
			DataColumn col_userPassword = new DataColumn("userPassword" , typeof(string));
			DataColumn col_isAttemptFail = new DataColumn("isAttemptFail" , typeof(bool));
			DataColumn col_attemptDate = new DataColumn("attemptDate" , typeof(DateTime));
			DataColumn col_message = new DataColumn("message" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_transaction_ID,col_terminal_ID,col_userID,col_userPassword,col_isAttemptFail,col_attemptDate,col_message,});		return dt;
		}
		/// <summary>
		/// This fills tbl_atlLoginAttempts datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_atlLoginAttempts object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_atlLoginAttempts user) {
		DataRow drow = dt.NewRow();
		
			drow["transaction_ID"] = user.transaction_ID;
			drow["terminal_ID"] = user.terminal_ID;
			drow["userID"] = user.userID;
			drow["userPassword"] = user.userPassword;
			drow["isAttemptFail"] = user.isAttemptFail;
			drow["attemptDate"] = user.attemptDate;
			drow["message"] = user.message;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
