using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityUserMaster {
		#region Fields
		private string user_ID;
		private string userName;
		private string password;
		private string employeeID;
		private string email;
		private string moible;
		private string computerName;
		private string computerIP;
		private DateTime lastLogedDateTime;
		private bool isLoged;
		private bool isBlocked;
		private bool isLocked;
		private string group_ID;
		private byte[] image;
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
		/// Initializes a new instance of the tbl_securityUserMaster class.
		/// </summary>
		public tbl_securityUserMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityUserMaster class.
		/// </summary>
		public tbl_securityUserMaster(string user_ID, string userName, string password, string employeeID, string email, string moible, string computerName, string computerIP, DateTime lastLogedDateTime, bool isLoged, bool isBlocked, bool isLocked, string group_ID, byte[] image, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.user_ID = user_ID;
			this.userName = userName;
			this.password = password;
			this.employeeID = employeeID;
			this.email = email;
			this.moible = moible;
			this.computerName = computerName;
			this.computerIP = computerIP;
			this.lastLogedDateTime = lastLogedDateTime;
			this.isLoged = isLoged;
			this.isBlocked = isBlocked;
			this.isLocked = isLocked;
			this.group_ID = group_ID;
			this.image = image;
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
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserName value.
		/// </summary>
		public string UserName {
			get { return userName; }
			set { userName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Password value.
		/// </summary>
		public string Password {
			get { return password; }
			set { password = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmployeeID value.
		/// </summary>
		public string EmployeeID {
			get { return employeeID; }
			set { employeeID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email {
			get { return email; }
			set { email = value; }
		}
		
		/// <summary>
		/// Gets or sets the Moible value.
		/// </summary>
		public string Moible {
			get { return moible; }
			set { moible = value; }
		}
		
		/// <summary>
		/// Gets or sets the ComputerName value.
		/// </summary>
		public string ComputerName {
			get { return computerName; }
			set { computerName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ComputerIP value.
		/// </summary>
		public string ComputerIP {
			get { return computerIP; }
			set { computerIP = value; }
		}
		
		/// <summary>
		/// Gets or sets the LastLogedDateTime value.
		/// </summary>
		public DateTime LastLogedDateTime {
			get { return lastLogedDateTime; }
			set { lastLogedDateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLoged value.
		/// </summary>
		public bool IsLoged {
			get { return isLoged; }
			set { isLoged = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBlocked value.
		/// </summary>
		public bool IsBlocked {
			get { return isBlocked; }
			set { isBlocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the Group_ID value.
		/// </summary>
		public string Group_ID {
			get { return group_ID; }
			set { group_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Image value.
		/// </summary>
		public byte[] Image {
			get { return image; }
			set { image = value; }
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
		/// Saves a record to the tbl_securityUserMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@password", SqlDbType.VarChar,50);
			scom.Parameters.Add("@employeeID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@moible", SqlDbType.VarChar,50);
			scom.Parameters.Add("@computerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@computerIP", SqlDbType.VarChar,50);
			scom.Parameters.Add("@lastLogedDateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isLoged", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBlocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar,10);
            scom.Parameters.Add("@image", SqlDbType.Image, 2147483647);
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
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@userName"].Value = userName;
			scom.Parameters["@password"].Value = password;
			scom.Parameters["@employeeID"].Value = employeeID;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@moible"].Value = moible;
			scom.Parameters["@computerName"].Value = computerName;
			scom.Parameters["@computerIP"].Value = computerIP;
			scom.Parameters["@lastLogedDateTime"].Value = lastLogedDateTime;
			scom.Parameters["@isLoged"].Value = isLoged;
			scom.Parameters["@isBlocked"].Value = isBlocked;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@group_ID"].Value = group_ID;
			scom.Parameters["@image"].Value = image;
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
		/// Updates a record in the tbl_securityUserMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@password", SqlDbType.VarChar,50);
			scom.Parameters.Add("@employeeID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@moible", SqlDbType.VarChar,50);
			scom.Parameters.Add("@computerName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@computerIP", SqlDbType.VarChar,50);
			scom.Parameters.Add("@lastLogedDateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isLoged", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBlocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar,10);
            scom.Parameters.Add("@image", SqlDbType.Image, 2147483647);
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
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@userName"].Value = userName;
			scom.Parameters["@password"].Value = password;
			scom.Parameters["@employeeID"].Value = employeeID;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@moible"].Value = moible;
			scom.Parameters["@computerName"].Value = computerName;
			scom.Parameters["@computerIP"].Value = computerIP;
			scom.Parameters["@lastLogedDateTime"].Value = lastLogedDateTime;
			scom.Parameters["@isLoged"].Value = isLoged;
			scom.Parameters["@isBlocked"].Value = isBlocked;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@group_ID"].Value = group_ID;
			scom.Parameters["@image"].Value = image;
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
		/// Deletes a record from the tbl_securityUserMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByGroup_ID(string group_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterDeleteAllByGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar,10);
			scom.Parameters["@group_ID"].Value = group_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityUserMaster table.
		/// </summary>
		public static tbl_securityUserMaster Select(string user_ID_Incoming){

			tbl_securityUserMaster tbl_securityUserMasterins = new tbl_securityUserMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityUserMasterins = Maketbl_securityUserMaster(dataReader);
				} else {
					tbl_securityUserMasterins = null;
				}
			}
			scon.Close();
			return tbl_securityUserMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserMaster table.
		/// </summary>
		public static List<tbl_securityUserMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityUserMaster> tbl_securityUserMasterList = new List<tbl_securityUserMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserMaster tbl_securityUserMaster = Maketbl_securityUserMaster(dataReader);
					tbl_securityUserMasterList.Add(tbl_securityUserMaster);
				}
			}
			scon.Close();
			return tbl_securityUserMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityUserMaster table by a foreign key.
		/// </summary>
		public static List<tbl_securityUserMaster> SelectAllByGroup_ID(string group_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityUserMasterSelectAllByGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@group_ID", SqlDbType.VarChar,10);
			scom.Parameters["@group_ID"].Value = group_ID;
				List<tbl_securityUserMaster> tbl_securityUserMasterList = new List<tbl_securityUserMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityUserMaster tbl_securityUserMaster = Maketbl_securityUserMaster(dataReader);
					tbl_securityUserMasterList.Add(tbl_securityUserMaster);
				}
			}
			scon.Close();
			return tbl_securityUserMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityUserMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityUserMaster Maketbl_securityUserMaster(SqlDataReader dataReader) {
			tbl_securityUserMaster tbl_securityUserMaster = new tbl_securityUserMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityUserMaster.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityUserMaster.UserName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityUserMaster.Password = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityUserMaster.EmployeeID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityUserMaster.Email = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_securityUserMaster.Moible = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_securityUserMaster.ComputerName = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_securityUserMaster.ComputerIP = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_securityUserMaster.LastLogedDateTime = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_securityUserMaster.IsLoged = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_securityUserMaster.IsBlocked = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_securityUserMaster.IsLocked = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_securityUserMaster.Group_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
                tbl_securityUserMaster.Image = (byte[])dataReader[13];
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_securityUserMaster.IsCanceled = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_securityUserMaster.UserID_Created = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_securityUserMaster.UserID_Modified = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_securityUserMaster.UserID_Canceled = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_securityUserMaster.TerminalID_Created = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_securityUserMaster.TerminalID_Modified = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_securityUserMaster.TerminalID_Canceled = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_securityUserMaster.Date_Created = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_securityUserMaster.Date_Modified = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_securityUserMaster.Date_Canceled = dataReader.GetDateTime(23);
			}

			return tbl_securityUserMaster;
		}
		/// <summary>
		/// This makes tbl_securityUserMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityUserMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityUserMaster  tbl_securityUserMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_userName = new DataColumn("userName" , typeof(string));
			DataColumn col_password = new DataColumn("password" , typeof(string));
			DataColumn col_employeeID = new DataColumn("employeeID" , typeof(string));
			DataColumn col_email = new DataColumn("email" , typeof(string));
			DataColumn col_moible = new DataColumn("moible" , typeof(string));
			DataColumn col_computerName = new DataColumn("computerName" , typeof(string));
			DataColumn col_computerIP = new DataColumn("computerIP" , typeof(string));
			DataColumn col_lastLogedDateTime = new DataColumn("lastLogedDateTime" , typeof(DateTime));
			DataColumn col_isLoged = new DataColumn("isLoged" , typeof(bool));
			DataColumn col_isBlocked = new DataColumn("isBlocked" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_group_ID = new DataColumn("group_ID" , typeof(string));
			DataColumn col_image = new DataColumn("image" , typeof(byte));
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
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_userName,col_password,col_employeeID,col_email,col_moible,col_computerName,col_computerIP,col_lastLogedDateTime,col_isLoged,col_isBlocked,col_isLocked,col_group_ID,col_image,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityUserMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityUserMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityUserMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["user_ID"] = user.user_ID;
			drow["userName"] = user.userName;
			drow["password"] = user.password;
			drow["employeeID"] = user.employeeID;
			drow["email"] = user.email;
			drow["moible"] = user.moible;
			drow["computerName"] = user.computerName;
			drow["computerIP"] = user.computerIP;
			drow["lastLogedDateTime"] = user.lastLogedDateTime;
			drow["isLoged"] = user.isLoged;
			drow["isBlocked"] = user.isBlocked;
			drow["isLocked"] = user.isLocked;
			drow["group_ID"] = user.group_ID;
			drow["image"] = user.image;
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
