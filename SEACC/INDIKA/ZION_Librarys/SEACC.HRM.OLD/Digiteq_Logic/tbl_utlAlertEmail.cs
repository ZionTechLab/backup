using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlertEmail {
		#region Fields
		private int eMail_ID;
		private string alert_ID;
		private string subject;
		private string body;
		private int status;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertEmail class.
		/// </summary>
		public tbl_utlAlertEmail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertEmail class.
		/// </summary>
		public tbl_utlAlertEmail(int eMail_ID, string alert_ID, string subject, string body, int status) {
			this.eMail_ID = eMail_ID;
			this.alert_ID = alert_ID;
			this.subject = subject;
			this.body = body;
			this.status = status;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the EMail_ID value.
		/// </summary>
		public int EMail_ID {
			get { return eMail_ID; }
			set { eMail_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Alert_ID value.
		/// </summary>
		public string Alert_ID {
			get { return alert_ID; }
			set { alert_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Subject value.
		/// </summary>
		public string Subject {
			get { return subject; }
			set { subject = value; }
		}
		
		/// <summary>
		/// Gets or sets the Body value.
		/// </summary>
		public string Body {
			get { return body; }
			set { body = value; }
		}
		
		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public int Status {
			get { return status; }
			set { status = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlAlertEmail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subject", SqlDbType.VarChar,50);
			scom.Parameters.Add("@body", SqlDbType.VarChar,1200);
			scom.Parameters.Add("@status", SqlDbType.Int,4);
 
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@subject"].Value = subject;
			scom.Parameters["@body"].Value = body;
			scom.Parameters["@status"].Value = status;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlertEmail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subject", SqlDbType.VarChar,50);
			scom.Parameters.Add("@body", SqlDbType.VarChar,1200);
			scom.Parameters.Add("@status", SqlDbType.Int,4);
 
 
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@subject"].Value = subject;
			scom.Parameters["@body"].Value = body;
			scom.Parameters["@status"].Value = status;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlertEmail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertEmail table by a foreign key.
		/// </summary>
		public static void DeleteAllByAlert_ID(string alert_ID) {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmailDeleteAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlertEmail table.
		/// </summary>
		public static tbl_utlAlertEmail Select(int eMail_ID_Incoming){

			tbl_utlAlertEmail tbl_utlAlertEmailins = new tbl_utlAlertEmail();
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlertEmailins = Maketbl_utlAlertEmail(dataReader);
				} else {
					tbl_utlAlertEmailins = null;
				}
			}
			scon.Close();
			return tbl_utlAlertEmailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertEmail table.
		/// </summary>
		public static List<tbl_utlAlertEmail> SelectAll() {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlertEmail> tbl_utlAlertEmailList = new List<tbl_utlAlertEmail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertEmail tbl_utlAlertEmail = Maketbl_utlAlertEmail(dataReader);
					tbl_utlAlertEmailList.Add(tbl_utlAlertEmail);
				}
			}
			scon.Close();
			return tbl_utlAlertEmailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertEmail table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlertEmail> SelectAllByAlert_ID(string alert_ID) {
 
			SqlConnection scon = Centiyo.DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertEmailSelectAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
				List<tbl_utlAlertEmail> tbl_utlAlertEmailList = new List<tbl_utlAlertEmail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertEmail tbl_utlAlertEmail = Maketbl_utlAlertEmail(dataReader);
					tbl_utlAlertEmailList.Add(tbl_utlAlertEmail);
				}
			}
			scon.Close();
			return tbl_utlAlertEmailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlertEmail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlertEmail Maketbl_utlAlertEmail(SqlDataReader dataReader) {
			tbl_utlAlertEmail tbl_utlAlertEmail = new tbl_utlAlertEmail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlertEmail.EMail_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlertEmail.Alert_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlertEmail.Subject = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlertEmail.Body = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlAlertEmail.Status = dataReader.GetInt32(4);
			}

			return tbl_utlAlertEmail;
		}
		/// <summary>
		/// This makes tbl_utlAlertEmail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlertEmail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlertEmail  tbl_utlAlertEmail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_eMail_ID = new DataColumn("eMail_ID" , typeof(int));
			DataColumn col_alert_ID = new DataColumn("alert_ID" , typeof(string));
			DataColumn col_subject = new DataColumn("subject" , typeof(string));
			DataColumn col_body = new DataColumn("body" , typeof(string));
			DataColumn col_status = new DataColumn("status" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_eMail_ID,col_alert_ID,col_subject,col_body,col_status,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlertEmail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlertEmail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlertEmail user) {
		DataRow drow = dt.NewRow();
		
			drow["eMail_ID"] = user.eMail_ID;
			drow["alert_ID"] = user.alert_ID;
			drow["subject"] = user.subject;
			drow["body"] = user.body;
			drow["status"] = user.status;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
