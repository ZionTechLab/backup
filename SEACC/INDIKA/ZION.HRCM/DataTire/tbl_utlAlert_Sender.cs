using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlert_Sender {
		#region Fields
		private string alertSender_ID;
		private string alertSender_name;
		private string emailAddress;
		private string emailPassword;
		private string smtpClient;
		private int smtpPort;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Sender class.
		/// </summary>
		public tbl_utlAlert_Sender() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Sender class.
		/// </summary>
		public tbl_utlAlert_Sender(string alertSender_ID, string alertSender_name, string emailAddress, string emailPassword, string smtpClient, int smtpPort) {
			this.alertSender_ID = alertSender_ID;
			this.alertSender_name = alertSender_name;
			this.emailAddress = emailAddress;
			this.emailPassword = emailPassword;
			this.smtpClient = smtpClient;
			this.smtpPort = smtpPort;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AlertSender_ID value.
		/// </summary>
		public string AlertSender_ID {
			get { return alertSender_ID; }
			set { alertSender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AlertSender_name value.
		/// </summary>
		public string AlertSender_name {
			get { return alertSender_name; }
			set { alertSender_name = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailAddress value.
		/// </summary>
		public string EmailAddress {
			get { return emailAddress; }
			set { emailAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailPassword value.
		/// </summary>
		public string EmailPassword {
			get { return emailPassword; }
			set { emailPassword = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmtpClient value.
		/// </summary>
		public string SmtpClient {
			get { return smtpClient; }
			set { smtpClient = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmtpPort value.
		/// </summary>
		public int SmtpPort {
			get { return smtpPort; }
			set { smtpPort = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlAlert_Sender table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SenderInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@alertSender_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@alertSender_name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@emailAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@emailPassword", SqlDbType.VarChar,50);
			scom.Parameters.Add("@smtpClient", SqlDbType.VarChar,50);
			scom.Parameters.Add("@smtpPort", SqlDbType.Int,4);
 
			scom.Parameters["@alertSender_ID"].Value = alertSender_ID;
			scom.Parameters["@alertSender_name"].Value = alertSender_name;
			scom.Parameters["@emailAddress"].Value = emailAddress;
			scom.Parameters["@emailPassword"].Value = emailPassword;
			scom.Parameters["@smtpClient"].Value = smtpClient;
			scom.Parameters["@smtpPort"].Value = smtpPort;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlert_Sender table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SenderUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@alertSender_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@alertSender_name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@emailAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@emailPassword", SqlDbType.VarChar,50);
			scom.Parameters.Add("@smtpClient", SqlDbType.VarChar,50);
			scom.Parameters.Add("@smtpPort", SqlDbType.Int,4);
 
 
			scom.Parameters["@alertSender_ID"].Value = alertSender_ID;
			scom.Parameters["@alertSender_name"].Value = alertSender_name;
			scom.Parameters["@emailAddress"].Value = emailAddress;
			scom.Parameters["@emailPassword"].Value = emailPassword;
			scom.Parameters["@smtpClient"].Value = smtpClient;
			scom.Parameters["@smtpPort"].Value = smtpPort;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlert_Sender table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SenderDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@alertSender_ID", SqlDbType.VarChar,50);
			scom.Parameters["@alertSender_ID"].Value = alertSender_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlert_Sender table.
		/// </summary>
		public static tbl_utlAlert_Sender Select(string alertSender_ID_Incoming){

			tbl_utlAlert_Sender tbl_utlAlert_Senderins = new tbl_utlAlert_Sender();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SenderSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alertSender_ID", SqlDbType.VarChar,50);
			scom.Parameters["@alertSender_ID"].Value = alertSender_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlert_Senderins = Maketbl_utlAlert_Sender(dataReader);
				} else {
					tbl_utlAlert_Senderins = null;
				}
			}
			scon.Close();
			return tbl_utlAlert_Senderins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Sender table.
		/// </summary>
		public static List<tbl_utlAlert_Sender> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SenderSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlert_Sender> tbl_utlAlert_SenderList = new List<tbl_utlAlert_Sender>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Sender tbl_utlAlert_Sender = Maketbl_utlAlert_Sender(dataReader);
					tbl_utlAlert_SenderList.Add(tbl_utlAlert_Sender);
				}
			}
			scon.Close();
			return tbl_utlAlert_SenderList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlert_Sender class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlert_Sender Maketbl_utlAlert_Sender(SqlDataReader dataReader) {
			tbl_utlAlert_Sender tbl_utlAlert_Sender = new tbl_utlAlert_Sender();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlert_Sender.AlertSender_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlert_Sender.AlertSender_name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlert_Sender.EmailAddress = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlert_Sender.EmailPassword = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlAlert_Sender.SmtpClient = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlAlert_Sender.SmtpPort = dataReader.GetInt32(5);
			}

			return tbl_utlAlert_Sender;
		}
		/// <summary>
		/// This makes tbl_utlAlert_Sender datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Sender object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlert_Sender  tbl_utlAlert_Sender   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_alertSender_ID = new DataColumn("alertSender_ID" , typeof(string));
			DataColumn col_alertSender_name = new DataColumn("alertSender_name" , typeof(string));
			DataColumn col_emailAddress = new DataColumn("emailAddress" , typeof(string));
			DataColumn col_emailPassword = new DataColumn("emailPassword" , typeof(string));
			DataColumn col_smtpClient = new DataColumn("smtpClient" , typeof(string));
			DataColumn col_smtpPort = new DataColumn("smtpPort" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_alertSender_ID,col_alertSender_name,col_emailAddress,col_emailPassword,col_smtpClient,col_smtpPort,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlert_Sender datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Sender object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlert_Sender user) {
		DataRow drow = dt.NewRow();
		
			drow["alertSender_ID"] = user.alertSender_ID;
			drow["alertSender_name"] = user.alertSender_name;
			drow["emailAddress"] = user.emailAddress;
			drow["emailPassword"] = user.emailPassword;
			drow["smtpClient"] = user.smtpClient;
			drow["smtpPort"] = user.smtpPort;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
