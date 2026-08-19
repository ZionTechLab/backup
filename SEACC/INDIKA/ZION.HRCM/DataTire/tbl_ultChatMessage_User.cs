using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ultChatMessage_User {
		#region Fields
		private string chat_ID;
		private string message_ID;
		private string user_ID;
		private bool isRead;
		private bool isHidden;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ultChatMessage_User class.
		/// </summary>
		public tbl_ultChatMessage_User() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ultChatMessage_User class.
		/// </summary>
		public tbl_ultChatMessage_User(string chat_ID, string message_ID, string user_ID, bool isRead, bool isHidden) {
			this.chat_ID = chat_ID;
			this.message_ID = message_ID;
			this.user_ID = user_ID;
			this.isRead = isRead;
			this.isHidden = isHidden;
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
		public string Message_ID {
			get { return message_ID; }
			set { message_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRead value.
		/// </summary>
		public bool IsRead {
			get { return isRead; }
			set { isRead = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsHidden value.
		/// </summary>
		public bool IsHidden {
			get { return isHidden; }
			set { isHidden = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ultChatMessage_User table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ultChatMessage_UserInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@message_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@isHidden", SqlDbType.Bit,1);
 
			scom.Parameters["@chat_ID"].Value = chat_ID;
			scom.Parameters["@message_ID"].Value = message_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@isRead"].Value = isRead;
			scom.Parameters["@isHidden"].Value = isHidden;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ultChatMessage_User table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ultChatMessage_UserUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@message_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isRead", SqlDbType.Bit,1);
			scom.Parameters.Add("@isHidden", SqlDbType.Bit,1);
 
 
			scom.Parameters["@chat_ID"].Value = chat_ID;
			scom.Parameters["@message_ID"].Value = message_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@isRead"].Value = isRead;
			scom.Parameters["@isHidden"].Value = isHidden;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ultChatMessage_User table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ultChatMessage_UserDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@message_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chat_ID"].Value = chat_ID;
 
			scom.Parameters["@message_ID"].Value = message_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ultChatMessage_User table.
		/// </summary>
		public static tbl_ultChatMessage_User Select(string chat_ID_Incoming, string message_ID_Incoming, string user_ID_Incoming){

			tbl_ultChatMessage_User tbl_ultChatMessage_Userins = new tbl_ultChatMessage_User();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ultChatMessage_UserSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@message_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chat_ID"].Value = chat_ID_Incoming;
			scom.Parameters["@message_ID"].Value = message_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ultChatMessage_Userins = Maketbl_ultChatMessage_User(dataReader);
				} else {
					tbl_ultChatMessage_Userins = null;
				}
			}
			scon.Close();
			return tbl_ultChatMessage_Userins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ultChatMessage_User table.
		/// </summary>
		public static List<tbl_ultChatMessage_User> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ultChatMessage_UserSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ultChatMessage_User> tbl_ultChatMessage_UserList = new List<tbl_ultChatMessage_User>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ultChatMessage_User tbl_ultChatMessage_User = Maketbl_ultChatMessage_User(dataReader);
					tbl_ultChatMessage_UserList.Add(tbl_ultChatMessage_User);
				}
			}
			scon.Close();
			return tbl_ultChatMessage_UserList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ultChatMessage_User class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ultChatMessage_User Maketbl_ultChatMessage_User(SqlDataReader dataReader) {
			tbl_ultChatMessage_User tbl_ultChatMessage_User = new tbl_ultChatMessage_User();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ultChatMessage_User.Chat_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ultChatMessage_User.Message_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ultChatMessage_User.User_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ultChatMessage_User.IsRead = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ultChatMessage_User.IsHidden = dataReader.GetBoolean(4);
			}

			return tbl_ultChatMessage_User;
		}
		/// <summary>
		/// This makes tbl_ultChatMessage_User datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ultChatMessage_User object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ultChatMessage_User  tbl_ultChatMessage_User   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chat_ID = new DataColumn("chat_ID" , typeof(string));
			DataColumn col_message_ID = new DataColumn("message_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_isRead = new DataColumn("isRead" , typeof(bool));
			DataColumn col_isHidden = new DataColumn("isHidden" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_chat_ID,col_message_ID,col_user_ID,col_isRead,col_isHidden,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ultChatMessage_User datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ultChatMessage_User object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ultChatMessage_User user) {
		DataRow drow = dt.NewRow();
		
			drow["chat_ID"] = user.chat_ID;
			drow["message_ID"] = user.message_ID;
			drow["user_ID"] = user.user_ID;
			drow["isRead"] = user.isRead;
			drow["isHidden"] = user.isHidden;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
