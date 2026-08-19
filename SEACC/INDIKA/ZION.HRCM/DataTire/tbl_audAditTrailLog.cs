using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_audAditTrailLog {
		#region Fields
		private DateTime auditDate;
		private string systemName;
		private string auditUser;
		private string terminal_ID;
		private string action1;
		private string action2;
		private string action3;
		private string action4;
		private string remarks;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audAditTrailLog class.
		/// </summary>
		public tbl_audAditTrailLog() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audAditTrailLog class.
		/// </summary>
		public tbl_audAditTrailLog(DateTime auditDate, string systemName, string auditUser, string terminal_ID, string action1, string action2, string action3, string action4, string remarks) {
			this.auditDate = auditDate;
			this.systemName = systemName;
			this.auditUser = auditUser;
			this.terminal_ID = terminal_ID;
			this.action1 = action1;
			this.action2 = action2;
			this.action3 = action3;
			this.action4 = action4;
			this.remarks = remarks;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AuditDate value.
		/// </summary>
		public DateTime AuditDate {
			get { return auditDate; }
			set { auditDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the SystemName value.
		/// </summary>
		public string SystemName {
			get { return systemName; }
			set { systemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the AuditUser value.
		/// </summary>
		public string AuditUser {
			get { return auditUser; }
			set { auditUser = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Action1 value.
		/// </summary>
		public string Action1 {
			get { return action1; }
			set { action1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Action2 value.
		/// </summary>
		public string Action2 {
			get { return action2; }
			set { action2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Action3 value.
		/// </summary>
		public string Action3 {
			get { return action3; }
			set { action3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Action4 value.
		/// </summary>
		public string Action4 {
			get { return action4; }
			set { action4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_audAditTrailLog table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAditTrailLogInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@systemName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@auditUser", SqlDbType.VarChar,50);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@action1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@action2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@action3", SqlDbType.VarChar,50);
			scom.Parameters.Add("@action4", SqlDbType.VarChar,300);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,50);
 
			scom.Parameters["@auditDate"].Value = auditDate;
			scom.Parameters["@systemName"].Value = systemName;
			scom.Parameters["@auditUser"].Value = auditUser;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@action1"].Value = action1;
			scom.Parameters["@action2"].Value = action2;
			scom.Parameters["@action3"].Value = action3;
			scom.Parameters["@action4"].Value = action4;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audAditTrailLog table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAditTrailLogUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@systemName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@auditUser", SqlDbType.VarChar,50);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@action1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@action2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@action3", SqlDbType.VarChar,50);
			scom.Parameters.Add("@action4", SqlDbType.VarChar,300);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@auditDate"].Value = auditDate;
			scom.Parameters["@systemName"].Value = systemName;
			scom.Parameters["@auditUser"].Value = auditUser;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@action1"].Value = action1;
			scom.Parameters["@action2"].Value = action2;
			scom.Parameters["@action3"].Value = action3;
			scom.Parameters["@action4"].Value = action4;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audAditTrailLog table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAditTrailLogDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@systemName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@auditUser", SqlDbType.VarChar,50);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@auditDate"].Value = auditDate;
 
			scom.Parameters["@systemName"].Value = systemName;
 
			scom.Parameters["@auditUser"].Value = auditUser;
 
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audAditTrailLog table.
		/// </summary>
		public static tbl_audAditTrailLog Select(DateTime auditDate_Incoming, string systemName_Incoming, string auditUser_Incoming, string terminal_ID_Incoming){

			tbl_audAditTrailLog tbl_audAditTrailLogins = new tbl_audAditTrailLog();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAditTrailLogSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@systemName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@auditUser", SqlDbType.VarChar,50);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@auditDate"].Value = auditDate_Incoming;
			scom.Parameters["@systemName"].Value = systemName_Incoming;
			scom.Parameters["@auditUser"].Value = auditUser_Incoming;
			scom.Parameters["@terminal_ID"].Value = terminal_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audAditTrailLogins = Maketbl_audAditTrailLog(dataReader);
				} else {
					tbl_audAditTrailLogins = null;
				}
			}
			scon.Close();
			return tbl_audAditTrailLogins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audAditTrailLog table.
		/// </summary>
		public static List<tbl_audAditTrailLog> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audAditTrailLogSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audAditTrailLog> tbl_audAditTrailLogList = new List<tbl_audAditTrailLog>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audAditTrailLog tbl_audAditTrailLog = Maketbl_audAditTrailLog(dataReader);
					tbl_audAditTrailLogList.Add(tbl_audAditTrailLog);
				}
			}
			scon.Close();
			return tbl_audAditTrailLogList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audAditTrailLog class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audAditTrailLog Maketbl_audAditTrailLog(SqlDataReader dataReader) {
			tbl_audAditTrailLog tbl_audAditTrailLog = new tbl_audAditTrailLog();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audAditTrailLog.AuditDate = dataReader.GetDateTime(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audAditTrailLog.SystemName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audAditTrailLog.AuditUser = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audAditTrailLog.Terminal_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_audAditTrailLog.Action1 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_audAditTrailLog.Action2 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_audAditTrailLog.Action3 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_audAditTrailLog.Action4 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_audAditTrailLog.Remarks = dataReader.GetString(8);
			}

			return tbl_audAditTrailLog;
		}
		/// <summary>
		/// This makes tbl_audAditTrailLog datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audAditTrailLog object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audAditTrailLog  tbl_audAditTrailLog   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_auditDate = new DataColumn("auditDate" , typeof(DateTime));
			DataColumn col_systemName = new DataColumn("systemName" , typeof(string));
			DataColumn col_auditUser = new DataColumn("auditUser" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_action1 = new DataColumn("action1" , typeof(string));
			DataColumn col_action2 = new DataColumn("action2" , typeof(string));
			DataColumn col_action3 = new DataColumn("action3" , typeof(string));
			DataColumn col_action4 = new DataColumn("action4" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_auditDate,col_systemName,col_auditUser,col_terminal_ID,col_action1,col_action2,col_action3,col_action4,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audAditTrailLog datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audAditTrailLog object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audAditTrailLog user) {
		DataRow drow = dt.NewRow();
		
			drow["auditDate"] = user.auditDate;
			drow["systemName"] = user.systemName;
			drow["auditUser"] = user.auditUser;
			drow["terminal_ID"] = user.terminal_ID;
			drow["action1"] = user.action1;
			drow["action2"] = user.action2;
			drow["action3"] = user.action3;
			drow["action4"] = user.action4;
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
