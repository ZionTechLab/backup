using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlertMailBox_Pending {
		#region Fields
		private int eMail_ID;
		private int alert_ID;
		private string subject;
		private string body;
		private int status;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertMailBox_Pending class.
		/// </summary>
		public tbl_utlAlertMailBox_Pending() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertMailBox_Pending class.
		/// </summary>
		public tbl_utlAlertMailBox_Pending(int eMail_ID, int alert_ID, string subject, string body, int status) {
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
		public int Alert_ID {
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
		/// Saves a record to the tbl_utlAlertMailBox_Pending table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_PendingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@subject", SqlDbType.VarChar,500);
			scom.Parameters.Add("@body", SqlDbType.VarChar,8000);
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
		/// Updates a record in the tbl_utlAlertMailBox_Pending table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_PendingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@subject", SqlDbType.VarChar,500);
			scom.Parameters.Add("@body", SqlDbType.VarChar,8000);
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
		/// Deletes a record from the tbl_utlAlertMailBox_Pending table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_PendingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertMailBox_Pending table by a foreign key.
		/// </summary>
		public static void DeleteAllByAlert_ID(int alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_PendingDeleteAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlertMailBox_Pending table.
		/// </summary>
		public static tbl_utlAlertMailBox_Pending Select(int eMail_ID_Incoming){

			tbl_utlAlertMailBox_Pending tbl_utlAlertMailBox_Pendingins = new tbl_utlAlertMailBox_Pending();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_PendingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlertMailBox_Pendingins = Maketbl_utlAlertMailBox_Pending(dataReader);
				} else {
					tbl_utlAlertMailBox_Pendingins = null;
				}
			}
			scon.Close();
			return tbl_utlAlertMailBox_Pendingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertMailBox_Pending table.
		/// </summary>
		public static List<tbl_utlAlertMailBox_Pending> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_PendingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlertMailBox_Pending> tbl_utlAlertMailBox_PendingList = new List<tbl_utlAlertMailBox_Pending>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertMailBox_Pending tbl_utlAlertMailBox_Pending = Maketbl_utlAlertMailBox_Pending(dataReader);
					tbl_utlAlertMailBox_PendingList.Add(tbl_utlAlertMailBox_Pending);
				}
			}
			scon.Close();
			return tbl_utlAlertMailBox_PendingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertMailBox_Pending table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlertMailBox_Pending> SelectAllByAlert_ID(int alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_PendingSelectAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters["@alert_ID"].Value = alert_ID;
				List<tbl_utlAlertMailBox_Pending> tbl_utlAlertMailBox_PendingList = new List<tbl_utlAlertMailBox_Pending>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertMailBox_Pending tbl_utlAlertMailBox_Pending = Maketbl_utlAlertMailBox_Pending(dataReader);
					tbl_utlAlertMailBox_PendingList.Add(tbl_utlAlertMailBox_Pending);
				}
			}
			scon.Close();
			return tbl_utlAlertMailBox_PendingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlertMailBox_Pending class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlertMailBox_Pending Maketbl_utlAlertMailBox_Pending(SqlDataReader dataReader) {
			tbl_utlAlertMailBox_Pending tbl_utlAlertMailBox_Pending = new tbl_utlAlertMailBox_Pending();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlertMailBox_Pending.EMail_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlertMailBox_Pending.Alert_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlertMailBox_Pending.Subject = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlertMailBox_Pending.Body = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlAlertMailBox_Pending.Status = dataReader.GetInt32(4);
			}

			return tbl_utlAlertMailBox_Pending;
		}
		/// <summary>
		/// This makes tbl_utlAlertMailBox_Pending datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlertMailBox_Pending object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlertMailBox_Pending  tbl_utlAlertMailBox_Pending   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_eMail_ID = new DataColumn("eMail_ID" , typeof(int));
			DataColumn col_alert_ID = new DataColumn("alert_ID" , typeof(int));
			DataColumn col_subject = new DataColumn("subject" , typeof(string));
			DataColumn col_body = new DataColumn("body" , typeof(string));
			DataColumn col_status = new DataColumn("status" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_eMail_ID,col_alert_ID,col_subject,col_body,col_status,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlertMailBox_Pending datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlertMailBox_Pending object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlertMailBox_Pending user) {
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
