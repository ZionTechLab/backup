using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlert_EMail {
		#region Fields
		private string eMail_ID;
		private string alert_ID;
		private string subject;
		private string body;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_EMail class.
		/// </summary>
		public tbl_utlAlert_EMail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_EMail class.
		/// </summary>
		public tbl_utlAlert_EMail(string eMail_ID, string alert_ID, string subject, string body) {
			this.eMail_ID = eMail_ID;
			this.alert_ID = alert_ID;
			this.subject = subject;
			this.body = body;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the EMail_ID value.
		/// </summary>
		public string EMail_ID {
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlAlert_EMail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subject", SqlDbType.VarChar,50);
            scom.Parameters.Add("@body", SqlDbType.NVarChar, -1);
 
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@subject"].Value = subject;
			scom.Parameters["@body"].Value = body;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlert_EMail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subject", SqlDbType.VarChar,50);
            scom.Parameters.Add("@body", SqlDbType.NVarChar, -1);
 
 
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@subject"].Value = subject;
			scom.Parameters["@body"].Value = body;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlert_EMail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.VarChar,20);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_EMail table by a foreign key.
		/// </summary>
		public static void DeleteAllByAlert_ID(string alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailDeleteAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlert_EMail table.
		/// </summary>
		public static tbl_utlAlert_EMail Select(string eMail_ID_Incoming){

			tbl_utlAlert_EMail tbl_utlAlert_EMailins = new tbl_utlAlert_EMail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.VarChar,20);
			scom.Parameters["@eMail_ID"].Value = eMail_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlert_EMailins = Maketbl_utlAlert_EMail(dataReader);
				} else {
					tbl_utlAlert_EMailins = null;
				}
			}
			scon.Close();
			return tbl_utlAlert_EMailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_EMail table.
		/// </summary>
		public static List<tbl_utlAlert_EMail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlert_EMail> tbl_utlAlert_EMailList = new List<tbl_utlAlert_EMail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_EMail tbl_utlAlert_EMail = Maketbl_utlAlert_EMail(dataReader);
					tbl_utlAlert_EMailList.Add(tbl_utlAlert_EMail);
				}
			}
			scon.Close();
			return tbl_utlAlert_EMailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_EMail table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_EMail> SelectAllByAlert_ID(string alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_EMailSelectAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
				List<tbl_utlAlert_EMail> tbl_utlAlert_EMailList = new List<tbl_utlAlert_EMail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_EMail tbl_utlAlert_EMail = Maketbl_utlAlert_EMail(dataReader);
					tbl_utlAlert_EMailList.Add(tbl_utlAlert_EMail);
				}
			}
			scon.Close();
			return tbl_utlAlert_EMailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlert_EMail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlert_EMail Maketbl_utlAlert_EMail(SqlDataReader dataReader) {
			tbl_utlAlert_EMail tbl_utlAlert_EMail = new tbl_utlAlert_EMail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlert_EMail.EMail_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlert_EMail.Alert_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlert_EMail.Subject = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlert_EMail.Body = dataReader.GetString(3);
			}

			return tbl_utlAlert_EMail;
		}
		/// <summary>
		/// This makes tbl_utlAlert_EMail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlert_EMail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlert_EMail  tbl_utlAlert_EMail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_eMail_ID = new DataColumn("eMail_ID" , typeof(string));
			DataColumn col_alert_ID = new DataColumn("alert_ID" , typeof(string));
			DataColumn col_subject = new DataColumn("subject" , typeof(string));
			DataColumn col_body = new DataColumn("body" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_eMail_ID,col_alert_ID,col_subject,col_body,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlert_EMail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlert_EMail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlert_EMail user) {
		DataRow drow = dt.NewRow();
		
			drow["eMail_ID"] = user.eMail_ID;
			drow["alert_ID"] = user.alert_ID;
			drow["subject"] = user.subject;
			drow["body"] = user.body;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
