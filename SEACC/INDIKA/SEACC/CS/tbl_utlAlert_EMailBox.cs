using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlert_EMailBox {
		#region Fields
		private string eMailBox_ID;
		private string alert_ID;
		private string eMail_ID;
		private string userName;
		private string eMailAddress;
		private DateTime sentDateTime;
		private bool isSending;
		private bool isDelivered;
		private bool isReplied;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_EMailBox class.
		/// </summary>
		public tbl_utlAlert_EMailBox() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_EMailBox class.
		/// </summary>
		public tbl_utlAlert_EMailBox(string eMailBox_ID, string alert_ID, string eMail_ID, string userName, string eMailAddress, DateTime sentDateTime, bool isSending, bool isDelivered, bool isReplied) {
			this.eMailBox_ID = eMailBox_ID;
			this.alert_ID = alert_ID;
			this.eMail_ID = eMail_ID;
			this.userName = userName;
			this.eMailAddress = eMailAddress;
			this.sentDateTime = sentDateTime;
			this.isSending = isSending;
			this.isDelivered = isDelivered;
			this.isReplied = isReplied;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the EMailBox_ID value.
		/// </summary>
		public string EMailBox_ID {
			get { return eMailBox_ID; }
			set { eMailBox_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Alert_ID value.
		/// </summary>
		public string Alert_ID {
			get { return alert_ID; }
			set { alert_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EMail_ID value.
		/// </summary>
		public string EMail_ID {
			get { return eMail_ID; }
			set { eMail_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserName value.
		/// </summary>
		public string UserName {
			get { return userName; }
			set { userName = value; }
		}
		
		/// <summary>
		/// Gets or sets the EMailAddress value.
		/// </summary>
		public string EMailAddress {
			get { return eMailAddress; }
			set { eMailAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the SentDateTime value.
		/// </summary>
		public DateTime SentDateTime {
			get { return sentDateTime; }
			set { sentDateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSending value.
		/// </summary>
		public bool IsSending {
			get { return isSending; }
			set { isSending = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDelivered value.
		/// </summary>
		public bool IsDelivered {
			get { return isDelivered; }
			set { isDelivered = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReplied value.
		/// </summary>
		public bool IsReplied {
			get { return isReplied; }
			set { isReplied = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlAlert_EMailBox table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailBoxInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMailBox_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@eMail_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@eMailAddress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@sentDateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isSending", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDelivered", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReplied", SqlDbType.Bit,1);
 
			scom.Parameters["@eMailBox_ID"].Value = eMailBox_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@userName"].Value = userName;
			scom.Parameters["@eMailAddress"].Value = eMailAddress;
			scom.Parameters["@sentDateTime"].Value = sentDateTime;
			scom.Parameters["@isSending"].Value = isSending;
			scom.Parameters["@isDelivered"].Value = isDelivered;
			scom.Parameters["@isReplied"].Value = isReplied;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlert_EMailBox table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailBoxUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMailBox_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@eMail_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@eMailAddress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@sentDateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isSending", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDelivered", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReplied", SqlDbType.Bit,1);
 
 
			scom.Parameters["@eMailBox_ID"].Value = eMailBox_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@userName"].Value = userName;
			scom.Parameters["@eMailAddress"].Value = eMailAddress;
			scom.Parameters["@sentDateTime"].Value = sentDateTime;
			scom.Parameters["@isSending"].Value = isSending;
			scom.Parameters["@isDelivered"].Value = isDelivered;
			scom.Parameters["@isReplied"].Value = isReplied;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlert_EMailBox table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailBoxDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@eMailBox_ID", SqlDbType.VarChar,20);
			scom.Parameters["@eMailBox_ID"].Value = eMailBox_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_EMailBox table by a foreign key.
		/// </summary>
		public static void DeleteAllByAlert_ID(string alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailBoxDeleteAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_EMailBox table by a foreign key.
		/// </summary>
		public static void DeleteAllByEMail_ID(string eMail_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailBoxDeleteAllByEMail_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.VarChar,20);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlert_EMailBox table.
		/// </summary>
		public static tbl_utlAlert_EMailBox Select(string eMailBox_ID_Incoming){

			tbl_utlAlert_EMailBox tbl_utlAlert_EMailBoxins = new tbl_utlAlert_EMailBox();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailBoxSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMailBox_ID", SqlDbType.VarChar,20);
			scom.Parameters["@eMailBox_ID"].Value = eMailBox_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlert_EMailBoxins = Maketbl_utlAlert_EMailBox(dataReader);
				} else {
					tbl_utlAlert_EMailBoxins = null;
				}
			}
			scon.Close();
			return tbl_utlAlert_EMailBoxins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_EMailBox table.
		/// </summary>
		public static List<tbl_utlAlert_EMailBox> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailBoxSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlert_EMailBox> tbl_utlAlert_EMailBoxList = new List<tbl_utlAlert_EMailBox>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_EMailBox tbl_utlAlert_EMailBox = Maketbl_utlAlert_EMailBox(dataReader);
					tbl_utlAlert_EMailBoxList.Add(tbl_utlAlert_EMailBox);
				}
			}
			scon.Close();
			return tbl_utlAlert_EMailBoxList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_EMailBox table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_EMailBox> SelectAllByAlert_ID(string alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailBoxSelectAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
				List<tbl_utlAlert_EMailBox> tbl_utlAlert_EMailBoxList = new List<tbl_utlAlert_EMailBox>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_EMailBox tbl_utlAlert_EMailBox = Maketbl_utlAlert_EMailBox(dataReader);
					tbl_utlAlert_EMailBoxList.Add(tbl_utlAlert_EMailBox);
				}
			}
			scon.Close();
			return tbl_utlAlert_EMailBoxList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_EMailBox table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_EMailBox> SelectAllByEMail_ID(string eMail_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailBoxSelectAllByEMail_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.VarChar,20);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
				List<tbl_utlAlert_EMailBox> tbl_utlAlert_EMailBoxList = new List<tbl_utlAlert_EMailBox>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_EMailBox tbl_utlAlert_EMailBox = Maketbl_utlAlert_EMailBox(dataReader);
					tbl_utlAlert_EMailBoxList.Add(tbl_utlAlert_EMailBox);
				}
			}
			scon.Close();
			return tbl_utlAlert_EMailBoxList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlert_EMailBox class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlert_EMailBox Maketbl_utlAlert_EMailBox(SqlDataReader dataReader) {
			tbl_utlAlert_EMailBox tbl_utlAlert_EMailBox = new tbl_utlAlert_EMailBox();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlert_EMailBox.EMailBox_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlert_EMailBox.Alert_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlert_EMailBox.EMail_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlert_EMailBox.UserName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlAlert_EMailBox.EMailAddress = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlAlert_EMailBox.SentDateTime = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_utlAlert_EMailBox.IsSending = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_utlAlert_EMailBox.IsDelivered = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_utlAlert_EMailBox.IsReplied = dataReader.GetBoolean(8);
			}

			return tbl_utlAlert_EMailBox;
		}
		/// <summary>
		/// This makes tbl_utlAlert_EMailBox datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlert_EMailBox object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlert_EMailBox  tbl_utlAlert_EMailBox   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_eMailBox_ID = new DataColumn("eMailBox_ID" , typeof(string));
			DataColumn col_alert_ID = new DataColumn("alert_ID" , typeof(string));
			DataColumn col_eMail_ID = new DataColumn("eMail_ID" , typeof(string));
			DataColumn col_userName = new DataColumn("userName" , typeof(string));
			DataColumn col_eMailAddress = new DataColumn("eMailAddress" , typeof(string));
			DataColumn col_sentDateTime = new DataColumn("sentDateTime" , typeof(DateTime));
			DataColumn col_isSending = new DataColumn("isSending" , typeof(bool));
			DataColumn col_isDelivered = new DataColumn("isDelivered" , typeof(bool));
			DataColumn col_isReplied = new DataColumn("isReplied" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_eMailBox_ID,col_alert_ID,col_eMail_ID,col_userName,col_eMailAddress,col_sentDateTime,col_isSending,col_isDelivered,col_isReplied,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlert_EMailBox datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlert_EMailBox object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlert_EMailBox user) {
		DataRow drow = dt.NewRow();
		
			drow["eMailBox_ID"] = user.eMailBox_ID;
			drow["alert_ID"] = user.alert_ID;
			drow["eMail_ID"] = user.eMail_ID;
			drow["userName"] = user.userName;
			drow["eMailAddress"] = user.eMailAddress;
			drow["sentDateTime"] = user.sentDateTime;
			drow["isSending"] = user.isSending;
			drow["isDelivered"] = user.isDelivered;
			drow["isReplied"] = user.isReplied;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
