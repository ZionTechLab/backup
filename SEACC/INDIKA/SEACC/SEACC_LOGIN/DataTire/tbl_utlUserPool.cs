using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SEACC_LOGIN.DataTire
{
	public sealed class tbl_utlUserPool {
		#region Fields
		private int line_no;
		private string user_ID;
		private string terminal_ID;
		private int activeForm_ID;
		private string loginStatus_ID;
		private DateTime logedTime;
		private bool isForceShoutdown;
		private bool isForceLogout;
		private bool isNewLogin;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlUserPool class.
		/// </summary>
		public tbl_utlUserPool() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlUserPool class.
		/// </summary>
		public tbl_utlUserPool(int line_no, string user_ID, string terminal_ID, int activeForm_ID, string loginStatus_ID, DateTime logedTime, bool isForceShoutdown, bool isForceLogout, bool isNewLogin) {
			this.line_no = line_no;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
			this.activeForm_ID = activeForm_ID;
			this.loginStatus_ID = loginStatus_ID;
			this.logedTime = logedTime;
			this.isForceShoutdown = isForceShoutdown;
			this.isForceLogout = isForceLogout;
			this.isNewLogin = isNewLogin;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_no value.
		/// </summary>
		public int Line_no {
			get { return line_no; }
			set { line_no = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ActiveForm_ID value.
		/// </summary>
		public int ActiveForm_ID {
			get { return activeForm_ID; }
			set { activeForm_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LoginStatus_ID value.
		/// </summary>
		public string LoginStatus_ID {
			get { return loginStatus_ID; }
			set { loginStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LogedTime value.
		/// </summary>
		public DateTime LogedTime {
			get { return logedTime; }
			set { logedTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsForceShoutdown value.
		/// </summary>
		public bool IsForceShoutdown {
			get { return isForceShoutdown; }
			set { isForceShoutdown = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsForceLogout value.
		/// </summary>
		public bool IsForceLogout {
			get { return isForceLogout; }
			set { isForceLogout = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsNewLogin value.
		/// </summary>
		public bool IsNewLogin {
			get { return isNewLogin; }
			set { isNewLogin = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlUserPool table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@activeForm_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@loginStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@logedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isForceShoutdown", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForceLogout", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNewLogin", SqlDbType.Bit,1);
 
			scom.Parameters["@line_no"].Value = line_no;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@activeForm_ID"].Value = activeForm_ID;
			scom.Parameters["@loginStatus_ID"].Value = loginStatus_ID;
			scom.Parameters["@logedTime"].Value = logedTime;
			scom.Parameters["@isForceShoutdown"].Value = isForceShoutdown;
			scom.Parameters["@isForceLogout"].Value = isForceLogout;
			scom.Parameters["@isNewLogin"].Value = isNewLogin;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlUserPool table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@activeForm_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@loginStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@logedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isForceShoutdown", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForceLogout", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNewLogin", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_no"].Value = line_no;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@activeForm_ID"].Value = activeForm_ID;
			scom.Parameters["@loginStatus_ID"].Value = loginStatus_ID;
			scom.Parameters["@logedTime"].Value = logedTime;
			scom.Parameters["@isForceShoutdown"].Value = isForceShoutdown;
			scom.Parameters["@isForceLogout"].Value = isForceLogout;
			scom.Parameters["@isNewLogin"].Value = isNewLogin;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlUserPool table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@line_no"].Value = line_no;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlUserPool table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlUserPool table by a foreign key.
		/// </summary>
		public static void DeleteAllByActiveForm_ID(int activeForm_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolDeleteAllByActiveForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@activeForm_ID", SqlDbType.Int,4);
			scom.Parameters["@activeForm_ID"].Value = activeForm_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlUserPool table by a foreign key.
		/// </summary>
		public static void DeleteAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolDeleteAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlUserPool table by a foreign key.
		/// </summary>
		public static void DeleteAllByLoginStatus_ID(string loginStatus_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolDeleteAllByLoginStatus_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@loginStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@loginStatus_ID"].Value = loginStatus_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlUserPool table.
		/// </summary>
		public static tbl_utlUserPool Select(int line_no_Incoming, string user_ID_Incoming, string terminal_ID_Incoming){

			tbl_utlUserPool tbl_utlUserPoolins = new tbl_utlUserPool();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@line_no"].Value = line_no_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@terminal_ID"].Value = terminal_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlUserPoolins = Maketbl_utlUserPool(dataReader);
				} else {
					tbl_utlUserPoolins = null;
				}
			}
			scon.Close();
			return tbl_utlUserPoolins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlUserPool table.
		/// </summary>
		public static List<tbl_utlUserPool> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlUserPool> tbl_utlUserPoolList = new List<tbl_utlUserPool>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlUserPool tbl_utlUserPool = Maketbl_utlUserPool(dataReader);
					tbl_utlUserPoolList.Add(tbl_utlUserPool);
				}
			}
			scon.Close();
			return tbl_utlUserPoolList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlUserPool table by a foreign key.
		/// </summary>
		public static List<tbl_utlUserPool> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_utlUserPool> tbl_utlUserPoolList = new List<tbl_utlUserPool>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlUserPool tbl_utlUserPool = Maketbl_utlUserPool(dataReader);
					tbl_utlUserPoolList.Add(tbl_utlUserPool);
				}
			}
			scon.Close();
			return tbl_utlUserPoolList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlUserPool table by a foreign key.
		/// </summary>
		public static List<tbl_utlUserPool> SelectAllByActiveForm_ID(int activeForm_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolSelectAllByActiveForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@activeForm_ID", SqlDbType.Int,4);
			scom.Parameters["@activeForm_ID"].Value = activeForm_ID;
				List<tbl_utlUserPool> tbl_utlUserPoolList = new List<tbl_utlUserPool>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlUserPool tbl_utlUserPool = Maketbl_utlUserPool(dataReader);
					tbl_utlUserPoolList.Add(tbl_utlUserPool);
				}
			}
			scon.Close();
			return tbl_utlUserPoolList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlUserPool table by a foreign key.
		/// </summary>
		public static List<tbl_utlUserPool> SelectAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolSelectAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
				List<tbl_utlUserPool> tbl_utlUserPoolList = new List<tbl_utlUserPool>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlUserPool tbl_utlUserPool = Maketbl_utlUserPool(dataReader);
					tbl_utlUserPoolList.Add(tbl_utlUserPool);
				}
			}
			scon.Close();
			return tbl_utlUserPoolList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlUserPool table by a foreign key.
		/// </summary>
		public static List<tbl_utlUserPool> SelectAllByLoginStatus_ID(string loginStatus_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlUserPoolSelectAllByLoginStatus_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@loginStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@loginStatus_ID"].Value = loginStatus_ID;
				List<tbl_utlUserPool> tbl_utlUserPoolList = new List<tbl_utlUserPool>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlUserPool tbl_utlUserPool = Maketbl_utlUserPool(dataReader);
					tbl_utlUserPoolList.Add(tbl_utlUserPool);
				}
			}
			scon.Close();
			return tbl_utlUserPoolList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlUserPool class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlUserPool Maketbl_utlUserPool(SqlDataReader dataReader) {
			tbl_utlUserPool tbl_utlUserPool = new tbl_utlUserPool();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlUserPool.Line_no = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlUserPool.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlUserPool.Terminal_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlUserPool.ActiveForm_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlUserPool.LoginStatus_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlUserPool.LogedTime = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_utlUserPool.IsForceShoutdown = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_utlUserPool.IsForceLogout = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_utlUserPool.IsNewLogin = dataReader.GetBoolean(8);
			}

			return tbl_utlUserPool;
		}
		/// <summary>
		/// This makes tbl_utlUserPool datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlUserPool object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlUserPool  tbl_utlUserPool   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_no = new DataColumn("line_no" , typeof(int));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_activeForm_ID = new DataColumn("activeForm_ID" , typeof(int));
			DataColumn col_loginStatus_ID = new DataColumn("loginStatus_ID" , typeof(string));
			DataColumn col_logedTime = new DataColumn("logedTime" , typeof(DateTime));
			DataColumn col_isForceShoutdown = new DataColumn("isForceShoutdown" , typeof(bool));
			DataColumn col_isForceLogout = new DataColumn("isForceLogout" , typeof(bool));
			DataColumn col_isNewLogin = new DataColumn("isNewLogin" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_no,col_user_ID,col_terminal_ID,col_activeForm_ID,col_loginStatus_ID,col_logedTime,col_isForceShoutdown,col_isForceLogout,col_isNewLogin,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlUserPool datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlUserPool object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlUserPool user) {
		DataRow drow = dt.NewRow();
		
			drow["line_no"] = user.line_no;
			drow["user_ID"] = user.user_ID;
			drow["terminal_ID"] = user.terminal_ID;
			drow["activeForm_ID"] = user.activeForm_ID;
			drow["loginStatus_ID"] = user.loginStatus_ID;
			drow["logedTime"] = user.logedTime;
			drow["isForceShoutdown"] = user.isForceShoutdown;
			drow["isForceLogout"] = user.isForceLogout;
			drow["isNewLogin"] = user.isNewLogin;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
