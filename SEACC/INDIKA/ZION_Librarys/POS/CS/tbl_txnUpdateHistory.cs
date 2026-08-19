using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_txnUpdateHistory {
		#region Fields
		private int index;
		private int form_ID;
		private string transaction_ID;
		private int activity_ID;
		private string user_ID;
		private DateTime dateTime;
		private string terminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_txnUpdateHistory class.
		/// </summary>
		public tbl_txnUpdateHistory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_txnUpdateHistory class.
		/// </summary>
		public tbl_txnUpdateHistory(int form_ID, string transaction_ID, int activity_ID, string user_ID, DateTime dateTime, string terminal_ID) {
			this.form_ID = form_ID;
			this.transaction_ID = transaction_ID;
			this.activity_ID = activity_ID;
			this.user_ID = user_ID;
			this.dateTime = dateTime;
			this.terminal_ID = terminal_ID;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_txnUpdateHistory class.
		/// </summary>
		public tbl_txnUpdateHistory(int index, int form_ID, string transaction_ID, int activity_ID, string user_ID, DateTime dateTime, string terminal_ID) {
			this.index = index;
			this.form_ID = form_ID;
			this.transaction_ID = transaction_ID;
			this.activity_ID = activity_ID;
			this.user_ID = user_ID;
			this.dateTime = dateTime;
			this.terminal_ID = terminal_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Index value.
		/// </summary>
		public int Index {
			get { return index; }
			set { index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Form_ID value.
		/// </summary>
		public int Form_ID {
			get { return form_ID; }
			set { form_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Activity_ID value.
		/// </summary>
		public int Activity_ID {
			get { return activity_ID; }
			set { activity_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateTime value.
		/// </summary>
		public DateTime DateTime {
			get { return dateTime; }
			set { dateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_txnUpdateHistory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_txnUpdateHistoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@activity_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@activity_ID"].Value = activity_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@dateTime"].Value = dateTime;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_txnUpdateHistory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_txnUpdateHistoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@activity_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@activity_ID"].Value = activity_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@dateTime"].Value = dateTime;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_txnUpdateHistory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_txnUpdateHistoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@index", SqlDbType.Int,4);
			scom.Parameters["@index"].Value = index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_txnUpdateHistory table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_txnUpdateHistoryDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_txnUpdateHistory table by a foreign key.
		/// </summary>
		public static void DeleteAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_txnUpdateHistoryDeleteAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_txnUpdateHistory table.
		/// </summary>
		public static tbl_txnUpdateHistory Select(int index_Incoming){

			tbl_txnUpdateHistory tbl_txnUpdateHistoryins = new tbl_txnUpdateHistory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_txnUpdateHistorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@index", SqlDbType.Int,4);
			scom.Parameters["@index"].Value = index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_txnUpdateHistoryins = Maketbl_txnUpdateHistory(dataReader);
				} else {
					tbl_txnUpdateHistoryins = null;
				}
			}
			scon.Close();
			return tbl_txnUpdateHistoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_txnUpdateHistory table.
		/// </summary>
		public static List<tbl_txnUpdateHistory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_txnUpdateHistorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_txnUpdateHistory> tbl_txnUpdateHistoryList = new List<tbl_txnUpdateHistory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_txnUpdateHistory tbl_txnUpdateHistory = Maketbl_txnUpdateHistory(dataReader);
					tbl_txnUpdateHistoryList.Add(tbl_txnUpdateHistory);
				}
			}
			scon.Close();
			return tbl_txnUpdateHistoryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_txnUpdateHistory table by a foreign key.
		/// </summary>
		public static List<tbl_txnUpdateHistory> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_txnUpdateHistorySelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_txnUpdateHistory> tbl_txnUpdateHistoryList = new List<tbl_txnUpdateHistory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_txnUpdateHistory tbl_txnUpdateHistory = Maketbl_txnUpdateHistory(dataReader);
					tbl_txnUpdateHistoryList.Add(tbl_txnUpdateHistory);
				}
			}
			scon.Close();
			return tbl_txnUpdateHistoryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_txnUpdateHistory table by a foreign key.
		/// </summary>
		public static List<tbl_txnUpdateHistory> SelectAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_txnUpdateHistorySelectAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
				List<tbl_txnUpdateHistory> tbl_txnUpdateHistoryList = new List<tbl_txnUpdateHistory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_txnUpdateHistory tbl_txnUpdateHistory = Maketbl_txnUpdateHistory(dataReader);
					tbl_txnUpdateHistoryList.Add(tbl_txnUpdateHistory);
				}
			}
			scon.Close();
			return tbl_txnUpdateHistoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_txnUpdateHistory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_txnUpdateHistory Maketbl_txnUpdateHistory(SqlDataReader dataReader) {
			tbl_txnUpdateHistory tbl_txnUpdateHistory = new tbl_txnUpdateHistory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_txnUpdateHistory.Index = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_txnUpdateHistory.Form_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_txnUpdateHistory.Transaction_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_txnUpdateHistory.Activity_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_txnUpdateHistory.User_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_txnUpdateHistory.DateTime = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_txnUpdateHistory.Terminal_ID = dataReader.GetString(6);
			}

			return tbl_txnUpdateHistory;
		}
		/// <summary>
		/// This makes tbl_txnUpdateHistory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_txnUpdateHistory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_txnUpdateHistory  tbl_txnUpdateHistory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_index = new DataColumn("index" , typeof(int));
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_activity_ID = new DataColumn("activity_ID" , typeof(int));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_dateTime = new DataColumn("dateTime" , typeof(DateTime));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_index,col_form_ID,col_transaction_ID,col_activity_ID,col_user_ID,col_dateTime,col_terminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_txnUpdateHistory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_txnUpdateHistory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_txnUpdateHistory user) {
		DataRow drow = dt.NewRow();
		
			drow["index"] = user.index;
			drow["form_ID"] = user.form_ID;
			drow["transaction_ID"] = user.transaction_ID;
			drow["activity_ID"] = user.activity_ID;
			drow["user_ID"] = user.user_ID;
			drow["dateTime"] = user.dateTime;
			drow["terminal_ID"] = user.terminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
