using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlert_Message {
		#region Fields
		private int messageID;
		private string user_ID;
		private int alertID;
		private bool hasUnReadMessages;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Message class.
		/// </summary>
		public tbl_utlAlert_Message() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Message class.
		/// </summary>
		public tbl_utlAlert_Message(string user_ID, int alertID, bool hasUnReadMessages) {
			this.user_ID = user_ID;
			this.alertID = alertID;
			this.hasUnReadMessages = hasUnReadMessages;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Message class.
		/// </summary>
		public tbl_utlAlert_Message(int messageID, string user_ID, int alertID, bool hasUnReadMessages) {
			this.messageID = messageID;
			this.user_ID = user_ID;
			this.alertID = alertID;
			this.hasUnReadMessages = hasUnReadMessages;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MessageID value.
		/// </summary>
		public int MessageID {
			get { return messageID; }
			set { messageID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AlertID value.
		/// </summary>
		public int AlertID {
			get { return alertID; }
			set { alertID = value; }
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
		/// Saves a record to the tbl_utlAlert_Message table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MessageInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alertID", SqlDbType.Int,4);
			scom.Parameters.Add("@hasUnReadMessages", SqlDbType.Bit,1);
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@alertID"].Value = alertID;
			scom.Parameters["@hasUnReadMessages"].Value = hasUnReadMessages;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlert_Message table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MessageUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alertID", SqlDbType.Int,4);
			scom.Parameters.Add("@hasUnReadMessages", SqlDbType.Bit,1);
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@alertID"].Value = alertID;
			scom.Parameters["@hasUnReadMessages"].Value = hasUnReadMessages;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlert_Message table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MessageDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@messageID", SqlDbType.Int,4);
			scom.Parameters["@messageID"].Value = messageID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Message table by a foreign key.
		/// </summary>
		public static void DeleteAllByAlertID(int alertID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MessageDeleteAllByAlertID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alertID", SqlDbType.Int,4);
			scom.Parameters["@alertID"].Value = alertID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Message table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MessageDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlert_Message table.
		/// </summary>
		public static tbl_utlAlert_Message Select(int messageID_Incoming){

			tbl_utlAlert_Message tbl_utlAlert_Messageins = new tbl_utlAlert_Message();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MessageSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@messageID", SqlDbType.Int,4);
			scom.Parameters["@messageID"].Value = messageID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlert_Messageins = Maketbl_utlAlert_Message(dataReader);
				} else {
					tbl_utlAlert_Messageins = null;
				}
			}
			scon.Close();
			return tbl_utlAlert_Messageins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Message table.
		/// </summary>
		public static List<tbl_utlAlert_Message> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MessageSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlert_Message> tbl_utlAlert_MessageList = new List<tbl_utlAlert_Message>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Message tbl_utlAlert_Message = Maketbl_utlAlert_Message(dataReader);
					tbl_utlAlert_MessageList.Add(tbl_utlAlert_Message);
				}
			}
			scon.Close();
			return tbl_utlAlert_MessageList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Message table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_Message> SelectAllByAlertID(int alertID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MessageSelectAllByAlertID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alertID", SqlDbType.Int,4);
			scom.Parameters["@alertID"].Value = alertID;
				List<tbl_utlAlert_Message> tbl_utlAlert_MessageList = new List<tbl_utlAlert_Message>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Message tbl_utlAlert_Message = Maketbl_utlAlert_Message(dataReader);
					tbl_utlAlert_MessageList.Add(tbl_utlAlert_Message);
				}
			}
			scon.Close();
			return tbl_utlAlert_MessageList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Message table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_Message> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MessageSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_utlAlert_Message> tbl_utlAlert_MessageList = new List<tbl_utlAlert_Message>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Message tbl_utlAlert_Message = Maketbl_utlAlert_Message(dataReader);
					tbl_utlAlert_MessageList.Add(tbl_utlAlert_Message);
				}
			}
			scon.Close();
			return tbl_utlAlert_MessageList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlert_Message class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlert_Message Maketbl_utlAlert_Message(SqlDataReader dataReader) {
			tbl_utlAlert_Message tbl_utlAlert_Message = new tbl_utlAlert_Message();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlert_Message.MessageID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlert_Message.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlert_Message.AlertID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlert_Message.HasUnReadMessages = dataReader.GetBoolean(3);
			}

			return tbl_utlAlert_Message;
		}
		/// <summary>
		/// This makes tbl_utlAlert_Message datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Message object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlert_Message  tbl_utlAlert_Message   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_messageID = new DataColumn("messageID" , typeof(int));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_alertID = new DataColumn("alertID" , typeof(int));
			DataColumn col_hasUnReadMessages = new DataColumn("hasUnReadMessages" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_messageID,col_user_ID,col_alertID,col_hasUnReadMessages,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlert_Message datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Message object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlert_Message user) {
		DataRow drow = dt.NewRow();
		
			drow["messageID"] = user.messageID;
			drow["user_ID"] = user.user_ID;
			drow["alertID"] = user.alertID;
			drow["hasUnReadMessages"] = user.hasUnReadMessages;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
