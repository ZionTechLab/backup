using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlEmailConfig {
		#region Fields
		private string user_ID;
		private string emailAddress;
		private string eliesName;
		private string emailUserID;
		private string emailPassword;
		private string emailSubject;
		private string emailBody;
		private string emailSignature;
		private string smtpClient;
		private int smtpPort;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlEmailConfig class.
		/// </summary>
		public tbl_utlEmailConfig() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlEmailConfig class.
		/// </summary>
		public tbl_utlEmailConfig(string user_ID, string emailAddress, string eliesName, string emailUserID, string emailPassword, string emailSubject, string emailBody, string emailSignature, string smtpClient, int smtpPort) {
			this.user_ID = user_ID;
			this.emailAddress = emailAddress;
			this.eliesName = eliesName;
			this.emailUserID = emailUserID;
			this.emailPassword = emailPassword;
			this.emailSubject = emailSubject;
			this.emailBody = emailBody;
			this.emailSignature = emailSignature;
			this.smtpClient = smtpClient;
			this.smtpPort = smtpPort;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailAddress value.
		/// </summary>
		public string EmailAddress {
			get { return emailAddress; }
			set { emailAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the EliesName value.
		/// </summary>
		public string EliesName {
			get { return eliesName; }
			set { eliesName = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailUserID value.
		/// </summary>
		public string EmailUserID {
			get { return emailUserID; }
			set { emailUserID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailPassword value.
		/// </summary>
		public string EmailPassword {
			get { return emailPassword; }
			set { emailPassword = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailSubject value.
		/// </summary>
		public string EmailSubject {
			get { return emailSubject; }
			set { emailSubject = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailBody value.
		/// </summary>
		public string EmailBody {
			get { return emailBody; }
			set { emailBody = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailSignature value.
		/// </summary>
		public string EmailSignature {
			get { return emailSignature; }
			set { emailSignature = value; }
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
		/// Saves a record to the tbl_utlEmailConfig table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlEmailConfigInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emailAddress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@eliesName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailUserID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailPassword", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailSubject", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailBody", SqlDbType.VarChar,200);
			scom.Parameters.Add("@emailSignature", SqlDbType.VarChar,100);
			scom.Parameters.Add("@smtpClient", SqlDbType.VarChar,50);
			scom.Parameters.Add("@smtpPort", SqlDbType.Int,4);
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@emailAddress"].Value = emailAddress;
			scom.Parameters["@eliesName"].Value = eliesName;
			scom.Parameters["@emailUserID"].Value = emailUserID;
			scom.Parameters["@emailPassword"].Value = emailPassword;
			scom.Parameters["@emailSubject"].Value = emailSubject;
			scom.Parameters["@emailBody"].Value = emailBody;
			scom.Parameters["@emailSignature"].Value = emailSignature;
			scom.Parameters["@smtpClient"].Value = smtpClient;
			scom.Parameters["@smtpPort"].Value = smtpPort;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlEmailConfig table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlEmailConfigUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emailAddress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@eliesName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailUserID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailPassword", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailSubject", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailBody", SqlDbType.VarChar,200);
			scom.Parameters.Add("@emailSignature", SqlDbType.VarChar,100);
			scom.Parameters.Add("@smtpClient", SqlDbType.VarChar,50);
			scom.Parameters.Add("@smtpPort", SqlDbType.Int,4);
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@emailAddress"].Value = emailAddress;
			scom.Parameters["@eliesName"].Value = eliesName;
			scom.Parameters["@emailUserID"].Value = emailUserID;
			scom.Parameters["@emailPassword"].Value = emailPassword;
			scom.Parameters["@emailSubject"].Value = emailSubject;
			scom.Parameters["@emailBody"].Value = emailBody;
			scom.Parameters["@emailSignature"].Value = emailSignature;
			scom.Parameters["@smtpClient"].Value = smtpClient;
			scom.Parameters["@smtpPort"].Value = smtpPort;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlEmailConfig table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlEmailConfigDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlEmailConfig table.
		/// </summary>
		public static tbl_utlEmailConfig Select(string user_ID_Incoming){

			tbl_utlEmailConfig tbl_utlEmailConfigins = new tbl_utlEmailConfig();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlEmailConfigSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlEmailConfigins = Maketbl_utlEmailConfig(dataReader);
				} else {
					tbl_utlEmailConfigins = null;
				}
			}
			scon.Close();
			return tbl_utlEmailConfigins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlEmailConfig table.
		/// </summary>
		public static List<tbl_utlEmailConfig> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlEmailConfigSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlEmailConfig> tbl_utlEmailConfigList = new List<tbl_utlEmailConfig>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlEmailConfig tbl_utlEmailConfig = Maketbl_utlEmailConfig(dataReader);
					tbl_utlEmailConfigList.Add(tbl_utlEmailConfig);
				}
			}
			scon.Close();
			return tbl_utlEmailConfigList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlEmailConfig class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlEmailConfig Maketbl_utlEmailConfig(SqlDataReader dataReader) {
			tbl_utlEmailConfig tbl_utlEmailConfig = new tbl_utlEmailConfig();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlEmailConfig.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlEmailConfig.EmailAddress = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlEmailConfig.EliesName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlEmailConfig.EmailUserID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlEmailConfig.EmailPassword = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlEmailConfig.EmailSubject = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_utlEmailConfig.EmailBody = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_utlEmailConfig.EmailSignature = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_utlEmailConfig.SmtpClient = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_utlEmailConfig.SmtpPort = dataReader.GetInt32(9);
			}

			return tbl_utlEmailConfig;
		}
		/// <summary>
		/// This makes tbl_utlEmailConfig datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlEmailConfig object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlEmailConfig  tbl_utlEmailConfig   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_emailAddress = new DataColumn("emailAddress" , typeof(string));
			DataColumn col_eliesName = new DataColumn("eliesName" , typeof(string));
			DataColumn col_emailUserID = new DataColumn("emailUserID" , typeof(string));
			DataColumn col_emailPassword = new DataColumn("emailPassword" , typeof(string));
			DataColumn col_emailSubject = new DataColumn("emailSubject" , typeof(string));
			DataColumn col_emailBody = new DataColumn("emailBody" , typeof(string));
			DataColumn col_emailSignature = new DataColumn("emailSignature" , typeof(string));
			DataColumn col_smtpClient = new DataColumn("smtpClient" , typeof(string));
			DataColumn col_smtpPort = new DataColumn("smtpPort" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_emailAddress,col_eliesName,col_emailUserID,col_emailPassword,col_emailSubject,col_emailBody,col_emailSignature,col_smtpClient,col_smtpPort,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlEmailConfig datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlEmailConfig object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlEmailConfig user) {
		DataRow drow = dt.NewRow();
		
			drow["user_ID"] = user.user_ID;
			drow["emailAddress"] = user.emailAddress;
			drow["eliesName"] = user.eliesName;
			drow["emailUserID"] = user.emailUserID;
			drow["emailPassword"] = user.emailPassword;
			drow["emailSubject"] = user.emailSubject;
			drow["emailBody"] = user.emailBody;
			drow["emailSignature"] = user.emailSignature;
			drow["smtpClient"] = user.smtpClient;
			drow["smtpPort"] = user.smtpPort;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
