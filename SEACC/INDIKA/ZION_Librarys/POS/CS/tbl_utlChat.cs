using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlChat {
		#region Fields
		private string chat_ID;
		private DateTime startTime;
		private DateTime endTime;
		private string createUser_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlChat class.
		/// </summary>
		public tbl_utlChat() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlChat class.
		/// </summary>
		public tbl_utlChat(string chat_ID, DateTime startTime, DateTime endTime, string createUser_ID) {
			this.chat_ID = chat_ID;
			this.startTime = startTime;
			this.endTime = endTime;
			this.createUser_ID = createUser_ID;
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
		/// Gets or sets the StartTime value.
		/// </summary>
		public DateTime StartTime {
			get { return startTime; }
			set { startTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the EndTime value.
		/// </summary>
		public DateTime EndTime {
			get { return endTime; }
			set { endTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlChat table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@startTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@chat_ID"].Value = chat_ID;
			scom.Parameters["@startTime"].Value = startTime;
			scom.Parameters["@endTime"].Value = endTime;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlChat table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@startTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@chat_ID"].Value = chat_ID;
			scom.Parameters["@startTime"].Value = startTime;
			scom.Parameters["@endTime"].Value = endTime;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlChat table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chat_ID"].Value = chat_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlChat table.
		/// </summary>
		public static tbl_utlChat Select(string chat_ID_Incoming){

			tbl_utlChat tbl_utlChatins = new tbl_utlChat();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chat_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chat_ID"].Value = chat_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlChatins = Maketbl_utlChat(dataReader);
				} else {
					tbl_utlChatins = null;
				}
			}
			scon.Close();
			return tbl_utlChatins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlChat table.
		/// </summary>
		public static List<tbl_utlChat> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlChatSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlChat> tbl_utlChatList = new List<tbl_utlChat>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlChat tbl_utlChat = Maketbl_utlChat(dataReader);
					tbl_utlChatList.Add(tbl_utlChat);
				}
			}
			scon.Close();
			return tbl_utlChatList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlChat class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlChat Maketbl_utlChat(SqlDataReader dataReader) {
			tbl_utlChat tbl_utlChat = new tbl_utlChat();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlChat.Chat_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlChat.StartTime = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlChat.EndTime = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlChat.CreateUser_ID = dataReader.GetString(3);
			}

			return tbl_utlChat;
		}
		/// <summary>
		/// This makes tbl_utlChat datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlChat object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlChat  tbl_utlChat   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chat_ID = new DataColumn("chat_ID" , typeof(string));
			DataColumn col_startTime = new DataColumn("startTime" , typeof(DateTime));
			DataColumn col_endTime = new DataColumn("endTime" , typeof(DateTime));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_chat_ID,col_startTime,col_endTime,col_createUser_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlChat datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlChat object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlChat user) {
		DataRow drow = dt.NewRow();
		
			drow["chat_ID"] = user.chat_ID;
			drow["startTime"] = user.startTime;
			drow["endTime"] = user.endTime;
			drow["createUser_ID"] = user.createUser_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
