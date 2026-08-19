using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class arc_tbl_utlChat_Message
    {
        #region Fields
        private int messageID;
        private string chat_ID;
        private string user_ID;
        private string chatMessage;
        private DateTime sendTime;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the arc_tbl_utlChat_Message class.
        /// </summary>
        public arc_tbl_utlChat_Message()
        {
        }

        /// <summary>
        /// Initializes a new instance of the arc_tbl_utlChat_Message class.
        /// </summary>
        public arc_tbl_utlChat_Message(string chat_ID, string user_ID, string chatMessage, DateTime sendTime)
        {
            this.chat_ID = chat_ID;
            this.user_ID = user_ID;
            this.chatMessage = chatMessage;
            this.sendTime = sendTime;
        }

        /// <summary>
        /// Initializes a new instance of the arc_tbl_utlChat_Message class.
        /// </summary>
        public arc_tbl_utlChat_Message(int messageID, string chat_ID, string user_ID, string chatMessage, DateTime sendTime)
        {
            this.messageID = messageID;
            this.chat_ID = chat_ID;
            this.user_ID = user_ID;
            this.chatMessage = chatMessage;
            this.sendTime = sendTime;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the MessageID value.
        /// </summary>
        public int MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }

        /// <summary>
        /// Gets or sets the Chat_ID value.
        /// </summary>
        public string Chat_ID
        {
            get { return chat_ID; }
            set { chat_ID = value; }
        }

        /// <summary>
        /// Gets or sets the User_ID value.
        /// </summary>
        public string User_ID
        {
            get { return user_ID; }
            set { user_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ChatMessage value.
        /// </summary>
        public string ChatMessage
        {
            get { return chatMessage; }
            set { chatMessage = value; }
        }

        /// <summary>
        /// Gets or sets the SendTime value.
        /// </summary>
        public DateTime SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the arc_tbl_utlChat_Message table.
        /// </summary>
        public void Insert()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("arc_tbl_utlChat_MessageInsert", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@chat_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@user_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chatMessage", SqlDbType.VarChar, 500);
            scom.Parameters.Add("@sendTime", SqlDbType.DateTime, 8);

            scom.Parameters["@chat_ID"].Value = chat_ID;
            scom.Parameters["@user_ID"].Value = user_ID;
            scom.Parameters["@chatMessage"].Value = chatMessage;
            scom.Parameters["@sendTime"].Value = sendTime;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Updates a record in the arc_tbl_utlChat_Message table.
        /// </summary>
        public void Update()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("arc_tbl_utlChat_MessageUpdate", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@chat_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@user_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chatMessage", SqlDbType.VarChar, 500);
            scom.Parameters.Add("@sendTime", SqlDbType.DateTime, 8);


            scom.Parameters["@chat_ID"].Value = chat_ID;
            scom.Parameters["@user_ID"].Value = user_ID;
            scom.Parameters["@chatMessage"].Value = chatMessage;
            scom.Parameters["@sendTime"].Value = sendTime;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Deletes a record from the arc_tbl_utlChat_Message table by its primary key.
        /// </summary>
        public void Delete()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("arc_tbl_utlChat_MessageDelete", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@messageID", SqlDbType.Int, 4);
            scom.Parameters["@messageID"].Value = messageID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the arc_tbl_utlChat_Message table by a foreign key.
        /// </summary>
        public static void DeleteAllByUser_ID(string user_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("arc_tbl_utlChat_MessageDeleteAllByUser_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@user_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@user_ID"].Value = user_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the arc_tbl_utlChat_Message table by a foreign key.
        /// </summary>
        public static void DeleteAllByChat_ID(string chat_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("arc_tbl_utlChat_MessageDeleteAllByChat_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@chat_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@chat_ID"].Value = chat_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects a single record from the arc_tbl_utlChat_Message table.
        /// </summary>
        public static arc_tbl_utlChat_Message Select(int messageID_Incoming)
        {

            arc_tbl_utlChat_Message arc_tbl_utlChat_Messageins = new arc_tbl_utlChat_Message();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("arc_tbl_utlChat_MessageSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@messageID", SqlDbType.Int, 4);
            scom.Parameters["@messageID"].Value = messageID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    arc_tbl_utlChat_Messageins = Makearc_tbl_utlChat_Message(dataReader);
                }
                else
                {
                    arc_tbl_utlChat_Messageins = null;
                }
            }
            scon.Close();
            return arc_tbl_utlChat_Messageins;
        }

        /// <summary>
        /// Selects all records from the arc_tbl_utlChat_Message table.
        /// </summary>
        public static List<arc_tbl_utlChat_Message> SelectAll()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("arc_tbl_utlChat_MessageSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            List<arc_tbl_utlChat_Message> arc_tbl_utlChat_MessageList = new List<arc_tbl_utlChat_Message>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    arc_tbl_utlChat_Message arc_tbl_utlChat_Message = Makearc_tbl_utlChat_Message(dataReader);
                    arc_tbl_utlChat_MessageList.Add(arc_tbl_utlChat_Message);
                }
            }
            scon.Close();
            return arc_tbl_utlChat_MessageList;
        }

        /// <summary>
        /// Selects all records from the arc_tbl_utlChat_Message table by a foreign key.
        /// </summary>
        public static List<arc_tbl_utlChat_Message> SelectAllByUser_ID(string user_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("arc_tbl_utlChat_MessageSelectAllByUser_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@user_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@user_ID"].Value = user_ID;
            List<arc_tbl_utlChat_Message> arc_tbl_utlChat_MessageList = new List<arc_tbl_utlChat_Message>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    arc_tbl_utlChat_Message arc_tbl_utlChat_Message = Makearc_tbl_utlChat_Message(dataReader);
                    arc_tbl_utlChat_MessageList.Add(arc_tbl_utlChat_Message);
                }
            }
            scon.Close();
            return arc_tbl_utlChat_MessageList;
        }

        /// <summary>
        /// Selects all records from the arc_tbl_utlChat_Message table by a foreign key.
        /// </summary>
        public static List<arc_tbl_utlChat_Message> SelectAllByChat_ID(string chat_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("arc_tbl_utlChat_MessageSelectAllByChat_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@chat_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@chat_ID"].Value = chat_ID;
            List<arc_tbl_utlChat_Message> arc_tbl_utlChat_MessageList = new List<arc_tbl_utlChat_Message>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    arc_tbl_utlChat_Message arc_tbl_utlChat_Message = Makearc_tbl_utlChat_Message(dataReader);
                    arc_tbl_utlChat_MessageList.Add(arc_tbl_utlChat_Message);
                }
            }
            scon.Close();
            return arc_tbl_utlChat_MessageList;
        }

        /// <summary>
        /// Creates a new instance of the arc_tbl_utlChat_Message class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static arc_tbl_utlChat_Message Makearc_tbl_utlChat_Message(SqlDataReader dataReader)
        {
            arc_tbl_utlChat_Message arc_tbl_utlChat_Message = new arc_tbl_utlChat_Message();

            if (dataReader.IsDBNull(0) == false)
            {
                arc_tbl_utlChat_Message.MessageID = dataReader.GetInt32(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                arc_tbl_utlChat_Message.Chat_ID = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                arc_tbl_utlChat_Message.User_ID = dataReader.GetString(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                arc_tbl_utlChat_Message.ChatMessage = dataReader.GetString(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                arc_tbl_utlChat_Message.SendTime = dataReader.GetDateTime(4);
            }

            return arc_tbl_utlChat_Message;
        }
        /// <summary>
        /// This makes arc_tbl_utlChat_Message datatable according to the datatable.
        /// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
        ///            We are still humans
        /// </summary>
        /// <param name="user">new arc_tbl_utlChat_Message object</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(arc_tbl_utlChat_Message arc_tbl_utlChat_Message)
        {
            DataTable dt = new DataTable();

            DataColumn col_messageID = new DataColumn("messageID", typeof(int));
            DataColumn col_chat_ID = new DataColumn("chat_ID", typeof(string));
            DataColumn col_user_ID = new DataColumn("user_ID", typeof(string));
            DataColumn col_chatMessage = new DataColumn("chatMessage", typeof(string));
            DataColumn col_sendTime = new DataColumn("sendTime", typeof(DateTime));
            dt.Columns.AddRange(new DataColumn[] { col_messageID, col_chat_ID, col_user_ID, col_chatMessage, col_sendTime, }); return dt;
        }
        /// <summary>
        /// This fills arc_tbl_utlChat_Message datatable according to the Given user list.
        /// </summary>
        /// <param name="user">new arc_tbl_utlChat_Message object</param>
        /// <returns></returns>
        public static void FillData(DataTable dt, arc_tbl_utlChat_Message user)
        {
            DataRow drow = dt.NewRow();

            drow["messageID"] = user.messageID;
            drow["chat_ID"] = user.chat_ID;
            drow["user_ID"] = user.user_ID;
            drow["chatMessage"] = user.chatMessage;
            drow["sendTime"] = user.sendTime;
            dt.Rows.Add(drow);
        }
        #endregion
    }
}