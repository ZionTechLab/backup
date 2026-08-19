using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlChatUser {
		#region Fields
		private string chat_ID;
		private string user_ID;
		private bool isSuspanded;
		private bool isBlackListed;
		private bool isAdmin;
		private bool isHidden;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		private string userID_Suspand;
		private string terminalID_Suspand;
		private DateTime date_Suspand;
		private string userID_BlackListed;
		private string terminalID_BlackListed;
		private DateTime date_BlackListed;
		private string userID_Hidden;
		private string terminalID_Hidden;
		private DateTime date_Hidden;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlChatUser class.
		/// </summary>
		public tbl_utlChatUser() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlChatUser class.
		/// </summary>
		public tbl_utlChatUser(string chat_ID, string user_ID, bool isSuspanded, bool isBlackListed, bool isAdmin, bool isHidden, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled, string userID_Suspand, string terminalID_Suspand, DateTime date_Suspand, string userID_BlackListed, string terminalID_BlackListed, DateTime date_BlackListed, string userID_Hidden, string terminalID_Hidden, DateTime date_Hidden) {
			this.chat_ID = chat_ID;
			this.user_ID = user_ID;
			this.isSuspanded = isSuspanded;
			this.isBlackListed = isBlackListed;
			this.isAdmin = isAdmin;
			this.isHidden = isHidden;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
			this.userID_Suspand = userID_Suspand;
			this.terminalID_Suspand = terminalID_Suspand;
			this.date_Suspand = date_Suspand;
			this.userID_BlackListed = userID_BlackListed;
			this.terminalID_BlackListed = terminalID_BlackListed;
			this.date_BlackListed = date_BlackListed;
			this.userID_Hidden = userID_Hidden;
			this.terminalID_Hidden = terminalID_Hidden;
			this.date_Hidden = date_Hidden;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Chat_ID value.
		/// </summary>
		public string Chat_ID {
			get { return chat_ID; }
			set { chat_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSuspanded value.
		/// </summary>
		public bool IsSuspanded {
			get { return isSuspanded; }
			set { isSuspanded = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBlackListed value.
		/// </summary>
		public bool IsBlackListed {
			get { return isBlackListed; }
			set { isBlackListed = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAdmin value.
		/// </summary>
		public bool IsAdmin {
			get { return isAdmin; }
			set { isAdmin = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsHidden value.
		/// </summary>
		public bool IsHidden {
			get { return isHidden; }
			set { isHidden = value; }
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
		/// Gets or sets the UserID_Suspand value.
		/// </summary>
		public string UserID_Suspand {
			get { return userID_Suspand; }
			set { userID_Suspand = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Suspand value.
		/// </summary>
		public string TerminalID_Suspand {
			get { return terminalID_Suspand; }
			set { terminalID_Suspand = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Suspand value.
		/// </summary>
		public DateTime Date_Suspand {
			get { return date_Suspand; }
			set { date_Suspand = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_BlackListed value.
		/// </summary>
		public string UserID_BlackListed {
			get { return userID_BlackListed; }
			set { userID_BlackListed = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_BlackListed value.
		/// </summary>
		public string TerminalID_BlackListed {
			get { return terminalID_BlackListed; }
			set { terminalID_BlackListed = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_BlackListed value.
		/// </summary>
		public DateTime Date_BlackListed {
			get { return date_BlackListed; }
			set { date_BlackListed = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Hidden value.
		/// </summary>
		public string UserID_Hidden {
			get { return userID_Hidden; }
			set { userID_Hidden = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Hidden value.
		/// </summary>
		public string TerminalID_Hidden {
			get { return terminalID_Hidden; }
			set { terminalID_Hidden = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Hidden value.
		/// </summary>
		public DateTime Date_Hidden {
			get { return date_Hidden; }
			set { date_Hidden = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlChatUser table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatUserInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSuspanded", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBlackListed", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAdmin", SqlDbType.Bit,1);
			scom.Parameters.Add("@isHidden", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@userID_Suspand", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Suspand", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Suspand", SqlDbType.DateTime,8);
			scom.Parameters.Add("@userID_BlackListed", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_BlackListed", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_BlackListed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@userID_Hidden", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Hidden", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Hidden", SqlDbType.DateTime,8);
 
			scom.Parameters["@chat_ID"].Value = chat_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@isSuspanded"].Value = isSuspanded;
			scom.Parameters["@isBlackListed"].Value = isBlackListed;
			scom.Parameters["@isAdmin"].Value = isAdmin;
			scom.Parameters["@isHidden"].Value = isHidden;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
			scom.Parameters["@userID_Suspand"].Value = userID_Suspand;
			scom.Parameters["@terminalID_Suspand"].Value = terminalID_Suspand;
			scom.Parameters["@date_Suspand"].Value = date_Suspand;
			scom.Parameters["@userID_BlackListed"].Value = userID_BlackListed;
			scom.Parameters["@terminalID_BlackListed"].Value = terminalID_BlackListed;
			scom.Parameters["@date_BlackListed"].Value = date_BlackListed;
			scom.Parameters["@userID_Hidden"].Value = userID_Hidden;
			scom.Parameters["@terminalID_Hidden"].Value = terminalID_Hidden;
			scom.Parameters["@date_Hidden"].Value = date_Hidden;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlChatUser table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatUserUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSuspanded", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBlackListed", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAdmin", SqlDbType.Bit,1);
			scom.Parameters.Add("@isHidden", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@userID_Suspand", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Suspand", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Suspand", SqlDbType.DateTime,8);
			scom.Parameters.Add("@userID_BlackListed", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_BlackListed", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_BlackListed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@userID_Hidden", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Hidden", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Hidden", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@chat_ID"].Value = chat_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@isSuspanded"].Value = isSuspanded;
			scom.Parameters["@isBlackListed"].Value = isBlackListed;
			scom.Parameters["@isAdmin"].Value = isAdmin;
			scom.Parameters["@isHidden"].Value = isHidden;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
			scom.Parameters["@userID_Suspand"].Value = userID_Suspand;
			scom.Parameters["@terminalID_Suspand"].Value = terminalID_Suspand;
			scom.Parameters["@date_Suspand"].Value = date_Suspand;
			scom.Parameters["@userID_BlackListed"].Value = userID_BlackListed;
			scom.Parameters["@terminalID_BlackListed"].Value = terminalID_BlackListed;
			scom.Parameters["@date_BlackListed"].Value = date_BlackListed;
			scom.Parameters["@userID_Hidden"].Value = userID_Hidden;
			scom.Parameters["@terminalID_Hidden"].Value = terminalID_Hidden;
			scom.Parameters["@date_Hidden"].Value = date_Hidden;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlChatUser table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatUserDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chat_ID"].Value = chat_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlChatUser table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatUserDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlChatUser table.
		/// </summary>
		public static tbl_utlChatUser Select(string chat_ID_Incoming,string user_ID_Incoming){

			tbl_utlChatUser tbl_utlChatUserins = new tbl_utlChatUser();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatUserSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chat_ID"].Value = chat_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlChatUserins = Maketbl_utlChatUser(dataReader);
				} else {
					tbl_utlChatUserins = null;
				}
			}
			scon.Close();
			return tbl_utlChatUserins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlChatUser table.
		/// </summary>
		public static List<tbl_utlChatUser> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatUserSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlChatUser> tbl_utlChatUserList = new List<tbl_utlChatUser>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlChatUser tbl_utlChatUser = Maketbl_utlChatUser(dataReader);
					tbl_utlChatUserList.Add(tbl_utlChatUser);
				}
			}
			scon.Close();
			return tbl_utlChatUserList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlChatUser table by a foreign key.
		/// </summary>
		public static List<tbl_utlChatUser> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatUserSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_utlChatUser> tbl_utlChatUserList = new List<tbl_utlChatUser>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlChatUser tbl_utlChatUser = Maketbl_utlChatUser(dataReader);
					tbl_utlChatUserList.Add(tbl_utlChatUser);
				}
			}
			scon.Close();
			return tbl_utlChatUserList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlChatUser class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlChatUser Maketbl_utlChatUser(SqlDataReader dataReader) {
			tbl_utlChatUser tbl_utlChatUser = new tbl_utlChatUser();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlChatUser.Chat_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlChatUser.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlChatUser.IsSuspanded = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlChatUser.IsBlackListed = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlChatUser.IsAdmin = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlChatUser.IsHidden = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_utlChatUser.UserID_Created = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_utlChatUser.UserID_Modified = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_utlChatUser.UserID_Canceled = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_utlChatUser.TerminalID_Created = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_utlChatUser.TerminalID_Modified = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_utlChatUser.TerminalID_Canceled = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_utlChatUser.Date_Created = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_utlChatUser.Date_Modified = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_utlChatUser.Date_Canceled = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_utlChatUser.UserID_Suspand = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_utlChatUser.TerminalID_Suspand = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_utlChatUser.Date_Suspand = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_utlChatUser.UserID_BlackListed = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_utlChatUser.TerminalID_BlackListed = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_utlChatUser.Date_BlackListed = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_utlChatUser.UserID_Hidden = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_utlChatUser.TerminalID_Hidden = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_utlChatUser.Date_Hidden = dataReader.GetDateTime(23);
			}

			return tbl_utlChatUser;
		}
		/// <summary>
		/// This makes tbl_utlChatUser datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlChatUser object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlChatUser  tbl_utlChatUser   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chat_ID = new DataColumn("chat_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_isSuspanded = new DataColumn("isSuspanded" , typeof(bool));
			DataColumn col_isBlackListed = new DataColumn("isBlackListed" , typeof(bool));
			DataColumn col_isAdmin = new DataColumn("isAdmin" , typeof(bool));
			DataColumn col_isHidden = new DataColumn("isHidden" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
			DataColumn col_userID_Suspand = new DataColumn("userID_Suspand" , typeof(string));
			DataColumn col_terminalID_Suspand = new DataColumn("terminalID_Suspand" , typeof(string));
			DataColumn col_date_Suspand = new DataColumn("date_Suspand" , typeof(DateTime));
			DataColumn col_userID_BlackListed = new DataColumn("userID_BlackListed" , typeof(string));
			DataColumn col_terminalID_BlackListed = new DataColumn("terminalID_BlackListed" , typeof(string));
			DataColumn col_date_BlackListed = new DataColumn("date_BlackListed" , typeof(DateTime));
			DataColumn col_userID_Hidden = new DataColumn("userID_Hidden" , typeof(string));
			DataColumn col_terminalID_Hidden = new DataColumn("terminalID_Hidden" , typeof(string));
			DataColumn col_date_Hidden = new DataColumn("date_Hidden" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_chat_ID,col_user_ID,col_isSuspanded,col_isBlackListed,col_isAdmin,col_isHidden,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,col_userID_Suspand,col_terminalID_Suspand,col_date_Suspand,col_userID_BlackListed,col_terminalID_BlackListed,col_date_BlackListed,col_userID_Hidden,col_terminalID_Hidden,col_date_Hidden,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlChatUser datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlChatUser object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlChatUser user) {
		DataRow drow = dt.NewRow();
		
			drow["chat_ID"] = user.chat_ID;
			drow["user_ID"] = user.user_ID;
			drow["isSuspanded"] = user.isSuspanded;
			drow["isBlackListed"] = user.isBlackListed;
			drow["isAdmin"] = user.isAdmin;
			drow["isHidden"] = user.isHidden;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
			drow["userID_Suspand"] = user.userID_Suspand;
			drow["terminalID_Suspand"] = user.terminalID_Suspand;
			drow["date_Suspand"] = user.date_Suspand;
			drow["userID_BlackListed"] = user.userID_BlackListed;
			drow["terminalID_BlackListed"] = user.terminalID_BlackListed;
			drow["date_BlackListed"] = user.date_BlackListed;
			drow["userID_Hidden"] = user.userID_Hidden;
			drow["terminalID_Hidden"] = user.terminalID_Hidden;
			drow["date_Hidden"] = user.date_Hidden;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
