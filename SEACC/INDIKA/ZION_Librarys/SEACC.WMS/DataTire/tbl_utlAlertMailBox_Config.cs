using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlertMailBox_Config {
		#region Fields
		private string emailAddress_ID;
		private string emailAddress;
		private string aliesName;
		private string emailPassword;
		private string emailSignature;
		private string smtpClient;
		private int smtpPort;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertMailBox_Config class.
		/// </summary>
		public tbl_utlAlertMailBox_Config() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertMailBox_Config class.
		/// </summary>
		public tbl_utlAlertMailBox_Config(string emailAddress_ID, string emailAddress, string aliesName, string emailPassword, string emailSignature, string smtpClient, int smtpPort) {
			this.emailAddress_ID = emailAddress_ID;
			this.emailAddress = emailAddress;
			this.aliesName = aliesName;
			this.emailPassword = emailPassword;
			this.emailSignature = emailSignature;
			this.smtpClient = smtpClient;
			this.smtpPort = smtpPort;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the EmailAddress_ID value.
		/// </summary>
		public string EmailAddress_ID {
			get { return emailAddress_ID; }
			set { emailAddress_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailAddress value.
		/// </summary>
		public string EmailAddress {
			get { return emailAddress; }
			set { emailAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the AliesName value.
		/// </summary>
		public string AliesName {
			get { return aliesName; }
			set { aliesName = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmailPassword value.
		/// </summary>
		public string EmailPassword {
			get { return emailPassword; }
			set { emailPassword = value; }
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
		/// Saves a record to the tbl_utlAlertMailBox_Config table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_ConfigInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@EmailAddress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emailAddress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@aliesName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailPassword", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailSignature", SqlDbType.VarChar,100);
			scom.Parameters.Add("@smtpClient", SqlDbType.VarChar,50);
			scom.Parameters.Add("@smtpPort", SqlDbType.Int,4);
 
			scom.Parameters["@EmailAddress_ID"].Value = emailAddress_ID;
			scom.Parameters["@emailAddress"].Value = emailAddress;
			scom.Parameters["@aliesName"].Value = aliesName;
			scom.Parameters["@emailPassword"].Value = emailPassword;
			scom.Parameters["@emailSignature"].Value = emailSignature;
			scom.Parameters["@smtpClient"].Value = smtpClient;
			scom.Parameters["@smtpPort"].Value = smtpPort;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlertMailBox_Config table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_ConfigUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@EmailAddress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@emailAddress", SqlDbType.VarChar,50);
			scom.Parameters.Add("@aliesName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailPassword", SqlDbType.VarChar,50);
			scom.Parameters.Add("@emailSignature", SqlDbType.VarChar,100);
			scom.Parameters.Add("@smtpClient", SqlDbType.VarChar,50);
			scom.Parameters.Add("@smtpPort", SqlDbType.Int,4);
 
 
			scom.Parameters["@EmailAddress_ID"].Value = emailAddress_ID;
			scom.Parameters["@emailAddress"].Value = emailAddress;
			scom.Parameters["@aliesName"].Value = aliesName;
			scom.Parameters["@emailPassword"].Value = emailPassword;
			scom.Parameters["@emailSignature"].Value = emailSignature;
			scom.Parameters["@smtpClient"].Value = smtpClient;
			scom.Parameters["@smtpPort"].Value = smtpPort;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlertMailBox_Config table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_ConfigDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@EmailAddress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@EmailAddress_ID"].Value = emailAddress_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlertMailBox_Config table.
		/// </summary>
		public static tbl_utlAlertMailBox_Config Select(string emailAddress_ID_Incoming){

			tbl_utlAlertMailBox_Config tbl_utlAlertMailBox_Configins = new tbl_utlAlertMailBox_Config();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_ConfigSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@EmailAddress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@EmailAddress_ID"].Value = emailAddress_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlertMailBox_Configins = Maketbl_utlAlertMailBox_Config(dataReader);
				} else {
					tbl_utlAlertMailBox_Configins = null;
				}
			}
			scon.Close();
			return tbl_utlAlertMailBox_Configins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertMailBox_Config table.
		/// </summary>
		public static List<tbl_utlAlertMailBox_Config> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_ConfigSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlertMailBox_Config> tbl_utlAlertMailBox_ConfigList = new List<tbl_utlAlertMailBox_Config>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertMailBox_Config tbl_utlAlertMailBox_Config = Maketbl_utlAlertMailBox_Config(dataReader);
					tbl_utlAlertMailBox_ConfigList.Add(tbl_utlAlertMailBox_Config);
				}
			}
			scon.Close();
			return tbl_utlAlertMailBox_ConfigList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlertMailBox_Config class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlertMailBox_Config Maketbl_utlAlertMailBox_Config(SqlDataReader dataReader) {
			tbl_utlAlertMailBox_Config tbl_utlAlertMailBox_Config = new tbl_utlAlertMailBox_Config();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlertMailBox_Config.EmailAddress_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlertMailBox_Config.EmailAddress = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlertMailBox_Config.AliesName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlertMailBox_Config.EmailPassword = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlAlertMailBox_Config.EmailSignature = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlAlertMailBox_Config.SmtpClient = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_utlAlertMailBox_Config.SmtpPort = dataReader.GetInt32(6);
			}

			return tbl_utlAlertMailBox_Config;
		}
		/// <summary>
		/// This makes tbl_utlAlertMailBox_Config datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlertMailBox_Config object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlertMailBox_Config  tbl_utlAlertMailBox_Config   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_EmailAddress_ID = new DataColumn("EmailAddress_ID" , typeof(string));
			DataColumn col_emailAddress = new DataColumn("emailAddress" , typeof(string));
			DataColumn col_aliesName = new DataColumn("aliesName" , typeof(string));
			DataColumn col_emailPassword = new DataColumn("emailPassword" , typeof(string));
			DataColumn col_emailSignature = new DataColumn("emailSignature" , typeof(string));
			DataColumn col_smtpClient = new DataColumn("smtpClient" , typeof(string));
			DataColumn col_smtpPort = new DataColumn("smtpPort" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_EmailAddress_ID,col_emailAddress,col_aliesName,col_emailPassword,col_emailSignature,col_smtpClient,col_smtpPort,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlertMailBox_Config datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlertMailBox_Config object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlertMailBox_Config user) {
		DataRow drow = dt.NewRow();
		
			drow["EmailAddress_ID"] = user.EmailAddress_ID;
			drow["emailAddress"] = user.emailAddress;
			drow["aliesName"] = user.aliesName;
			drow["emailPassword"] = user.emailPassword;
			drow["emailSignature"] = user.emailSignature;
			drow["smtpClient"] = user.smtpClient;
			drow["smtpPort"] = user.smtpPort;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
