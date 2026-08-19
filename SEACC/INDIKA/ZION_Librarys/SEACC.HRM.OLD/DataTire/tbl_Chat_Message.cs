using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_Chat_Message {
		#region Fields
		private string chat_ID;
		private int message_ID;
		private int messageType;
		private string chatMessage;
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
		/// Initializes a new instance of the tbl_Chat_Message class.
		/// </summary>
		public tbl_Chat_Message() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_Chat_Message class.
		/// </summary>
		public tbl_Chat_Message(string chat_ID, int message_ID, int messageType, string chatMessage, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.chat_ID = chat_ID;
			this.message_ID = message_ID;
			this.messageType = messageType;
			this.chatMessage = chatMessage;
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
		/// Gets or sets the Chat_ID value.
		/// </summary>
		public string Chat_ID {
			get { return chat_ID; }
			set { chat_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Message_ID value.
		/// </summary>
		public int Message_ID {
			get { return message_ID; }
			set { message_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MessageType value.
		/// </summary>
		public int MessageType {
			get { return messageType; }
			set { messageType = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChatMessage value.
		/// </summary>
		public string ChatMessage {
			get { return chatMessage; }
			set { chatMessage = value; }
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
		/// Saves a record to the tbl_Chat_Message table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_Chat_MessageInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@message_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@messageType", SqlDbType.Int,4);
			scom.Parameters.Add("@chatMessage", SqlDbType.VarChar,500);
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
 
			scom.Parameters["@chat_ID"].Value = chat_ID;
			scom.Parameters["@message_ID"].Value = message_ID;
			scom.Parameters["@messageType"].Value = messageType;
			scom.Parameters["@chatMessage"].Value = chatMessage;
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
		/// Updates a record in the tbl_Chat_Message table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_Chat_MessageUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@message_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@messageType", SqlDbType.Int,4);
			scom.Parameters.Add("@chatMessage", SqlDbType.VarChar,500);
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
 
 
			scom.Parameters["@chat_ID"].Value = chat_ID;
			scom.Parameters["@message_ID"].Value = message_ID;
			scom.Parameters["@messageType"].Value = messageType;
			scom.Parameters["@chatMessage"].Value = chatMessage;
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
		/// Deletes a record from the tbl_Chat_Message table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_Chat_MessageDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@message_ID", SqlDbType.Int,4);
			scom.Parameters["@chat_ID"].Value = chat_ID;
 
			scom.Parameters["@message_ID"].Value = message_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_Chat_Message table.
		/// </summary>
		public static tbl_Chat_Message Select(string chat_ID_Incoming, int message_ID_Incoming){

			tbl_Chat_Message tbl_Chat_Messageins = new tbl_Chat_Message();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_Chat_MessageSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@message_ID", SqlDbType.Int,4);
			scom.Parameters["@chat_ID"].Value = chat_ID_Incoming;
			scom.Parameters["@message_ID"].Value = message_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_Chat_Messageins = Maketbl_Chat_Message(dataReader);
				} else {
					tbl_Chat_Messageins = null;
				}
			}
			scon.Close();
			return tbl_Chat_Messageins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_Chat_Message table.
		/// </summary>
		public static List<tbl_Chat_Message> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_Chat_MessageSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_Chat_Message> tbl_Chat_MessageList = new List<tbl_Chat_Message>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_Chat_Message tbl_Chat_Message = Maketbl_Chat_Message(dataReader);
					tbl_Chat_MessageList.Add(tbl_Chat_Message);
				}
			}
			scon.Close();
			return tbl_Chat_MessageList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_Chat_Message class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_Chat_Message Maketbl_Chat_Message(SqlDataReader dataReader) {
			tbl_Chat_Message tbl_Chat_Message = new tbl_Chat_Message();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_Chat_Message.Chat_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_Chat_Message.Message_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_Chat_Message.MessageType = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_Chat_Message.ChatMessage = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_Chat_Message.IsCanceled = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_Chat_Message.UserID_Created = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_Chat_Message.UserID_Modified = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_Chat_Message.UserID_Canceled = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_Chat_Message.TerminalID_Created = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_Chat_Message.TerminalID_Modified = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_Chat_Message.TerminalID_Canceled = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_Chat_Message.Date_Created = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_Chat_Message.Date_Modified = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_Chat_Message.Date_Canceled = dataReader.GetDateTime(13);
			}

			return tbl_Chat_Message;
		}
		/// <summary>
		/// This makes tbl_Chat_Message datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_Chat_Message object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_Chat_Message  tbl_Chat_Message   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chat_ID = new DataColumn("chat_ID" , typeof(string));
			DataColumn col_message_ID = new DataColumn("message_ID" , typeof(int));
			DataColumn col_messageType = new DataColumn("messageType" , typeof(int));
			DataColumn col_chatMessage = new DataColumn("chatMessage" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_chat_ID,col_message_ID,col_messageType,col_chatMessage,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_Chat_Message datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_Chat_Message object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_Chat_Message user) {
		DataRow drow = dt.NewRow();
		
			drow["chat_ID"] = user.chat_ID;
			drow["message_ID"] = user.message_ID;
			drow["messageType"] = user.messageType;
			drow["chatMessage"] = user.chatMessage;
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
