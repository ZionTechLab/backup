using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


//As a rule digiteq will not provide single crdit note for multiple sales returned notes. 2011-12-16 Asanka/Vijitha

namespace DataTire {
	public sealed class tbl_utlChatUser {
		#region Fields
		private string chat_ID;
		private string user_ID;
		private DateTime joinedTime;
		private DateTime removedTime;
		private bool isRemoved;
		private bool hasUnReadMessages;
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
		public tbl_utlChatUser(string chat_ID, string user_ID, DateTime joinedTime, DateTime removedTime, bool isRemoved, bool hasUnReadMessages) {
			this.chat_ID = chat_ID;
			this.user_ID = user_ID;
			this.joinedTime = joinedTime;
			this.removedTime = removedTime;
			this.isRemoved = isRemoved;
			this.hasUnReadMessages = hasUnReadMessages;
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
		/// Gets or sets the JoinedTime value.
		/// </summary>
		public DateTime JoinedTime {
			get { return joinedTime; }
			set { joinedTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the RemovedTime value.
		/// </summary>
		public DateTime RemovedTime {
			get { return removedTime; }
			set { removedTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRemoved value.
		/// </summary>
		public bool IsRemoved {
			get { return isRemoved; }
			set { isRemoved = value; }
		}
		
		/// <summary>
		/// Gets or sets the HasUnReadMessages value.
		/// </summary>
		public bool HasUnReadMessages {
			get { return hasUnReadMessages; }
			set { hasUnReadMessages = value; }
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
			scom.Parameters.Add("@joinedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@removedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isRemoved", SqlDbType.Bit,1);
			scom.Parameters.Add("@hasUnReadMessages", SqlDbType.Bit,1);
 
			scom.Parameters["@chat_ID"].Value = chat_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@joinedTime"].Value = joinedTime;
			scom.Parameters["@removedTime"].Value = removedTime;
			scom.Parameters["@isRemoved"].Value = isRemoved;
			scom.Parameters["@hasUnReadMessages"].Value = hasUnReadMessages;
 
 
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
			scom.Parameters.Add("@joinedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@removedTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isRemoved", SqlDbType.Bit,1);
			scom.Parameters.Add("@hasUnReadMessages", SqlDbType.Bit,1);
 
 
			scom.Parameters["@chat_ID"].Value = chat_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@joinedTime"].Value = joinedTime;
			scom.Parameters["@removedTime"].Value = removedTime;
			scom.Parameters["@isRemoved"].Value = isRemoved;
			scom.Parameters["@hasUnReadMessages"].Value = hasUnReadMessages;
 
 
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
		public static void DeleteAllByChat_ID(string chat_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatUserDeleteAllByChat_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chat_ID"].Value = chat_ID;
 
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
		public static tbl_utlChatUser Select(string chat_ID_Incoming, string user_ID_Incoming){

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
		public static List<tbl_utlChatUser> SelectAllByChat_ID(string chat_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatUserSelectAllByChat_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chat_ID"].Value = chat_ID;
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
				tbl_utlChatUser.JoinedTime = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlChatUser.RemovedTime = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlChatUser.IsRemoved = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlChatUser.HasUnReadMessages = dataReader.GetBoolean(5);
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
			DataColumn col_joinedTime = new DataColumn("joinedTime" , typeof(DateTime));
			DataColumn col_removedTime = new DataColumn("removedTime" , typeof(DateTime));
			DataColumn col_isRemoved = new DataColumn("isRemoved" , typeof(bool));
			DataColumn col_hasUnReadMessages = new DataColumn("hasUnReadMessages" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_chat_ID,col_user_ID,col_joinedTime,col_removedTime,col_isRemoved,col_hasUnReadMessages,});		return dt;
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
			drow["joinedTime"] = user.joinedTime;
			drow["removedTime"] = user.removedTime;
			drow["isRemoved"] = user.isRemoved;
			drow["hasUnReadMessages"] = user.hasUnReadMessages;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
