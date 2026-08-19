using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlert_Shedule {
		#region Fields
		private int schedule_ID;
		private string companyBranch_ID;
		private string alert_ID;
		private bool isActive;
		private bool isDaily;
		private bool isWeekly;
		private bool isMonthly;
		private bool isYearly;
		private DateTime sheduledTime;
		private DateTime lastAlert_SentTime;
		private bool isLocked;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Shedule class.
		/// </summary>
		public tbl_utlAlert_Shedule() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Shedule class.
		/// </summary>
		public tbl_utlAlert_Shedule(int schedule_ID, string companyBranch_ID, string alert_ID, bool isActive, bool isDaily, bool isWeekly, bool isMonthly, bool isYearly, DateTime sheduledTime, DateTime lastAlert_SentTime, bool isLocked) {
			this.schedule_ID = schedule_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.alert_ID = alert_ID;
			this.isActive = isActive;
			this.isDaily = isDaily;
			this.isWeekly = isWeekly;
			this.isMonthly = isMonthly;
			this.isYearly = isYearly;
			this.sheduledTime = sheduledTime;
			this.lastAlert_SentTime = lastAlert_SentTime;
			this.isLocked = isLocked;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Schedule_ID value.
		/// </summary>
		public int Schedule_ID {
			get { return schedule_ID; }
			set { schedule_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Alert_ID value.
		/// </summary>
		public string Alert_ID {
			get { return alert_ID; }
			set { alert_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDaily value.
		/// </summary>
		public bool IsDaily {
			get { return isDaily; }
			set { isDaily = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeekly value.
		/// </summary>
		public bool IsWeekly {
			get { return isWeekly; }
			set { isWeekly = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsMonthly value.
		/// </summary>
		public bool IsMonthly {
			get { return isMonthly; }
			set { isMonthly = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsYearly value.
		/// </summary>
		public bool IsYearly {
			get { return isYearly; }
			set { isYearly = value; }
		}
		
		/// <summary>
		/// Gets or sets the SheduledTime value.
		/// </summary>
		public DateTime SheduledTime {
			get { return sheduledTime; }
			set { sheduledTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the LastAlert_SentTime value.
		/// </summary>
		public DateTime LastAlert_SentTime {
			get { return lastAlert_SentTime; }
			set { lastAlert_SentTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlAlert_Shedule table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SheduleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@schedule_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDaily", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeekly", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMonthly", SqlDbType.Bit,1);
			scom.Parameters.Add("@isYearly", SqlDbType.Bit,1);
			scom.Parameters.Add("@sheduledTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lastAlert_SentTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@isDaily"].Value = isDaily;
			scom.Parameters["@isWeekly"].Value = isWeekly;
			scom.Parameters["@isMonthly"].Value = isMonthly;
			scom.Parameters["@isYearly"].Value = isYearly;
			scom.Parameters["@sheduledTime"].Value = sheduledTime;
			scom.Parameters["@lastAlert_SentTime"].Value = lastAlert_SentTime;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlert_Shedule table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SheduleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@schedule_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDaily", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeekly", SqlDbType.Bit,1);
			scom.Parameters.Add("@isMonthly", SqlDbType.Bit,1);
			scom.Parameters.Add("@isYearly", SqlDbType.Bit,1);
			scom.Parameters.Add("@sheduledTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lastAlert_SentTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
 
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@isActive"].Value = isActive;
			scom.Parameters["@isDaily"].Value = isDaily;
			scom.Parameters["@isWeekly"].Value = isWeekly;
			scom.Parameters["@isMonthly"].Value = isMonthly;
			scom.Parameters["@isYearly"].Value = isYearly;
			scom.Parameters["@sheduledTime"].Value = sheduledTime;
			scom.Parameters["@lastAlert_SentTime"].Value = lastAlert_SentTime;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlert_Shedule table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SheduleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@schedule_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@schedule_ID"].Value = schedule_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Shedule table by a foreign key.
		/// </summary>
		public static void DeleteAllByAlert_ID(string alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SheduleDeleteAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Shedule table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SheduleDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlert_Shedule table.
		/// </summary>
		public static tbl_utlAlert_Shedule Select(int schedule_ID_Incoming, string companyBranch_ID_Incoming, string alert_ID_Incoming){

			tbl_utlAlert_Shedule tbl_utlAlert_Sheduleins = new tbl_utlAlert_Shedule();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SheduleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@schedule_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@schedule_ID"].Value = schedule_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@alert_ID"].Value = alert_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlert_Sheduleins = Maketbl_utlAlert_Shedule(dataReader);
				} else {
					tbl_utlAlert_Sheduleins = null;
				}
			}
			scon.Close();
			return tbl_utlAlert_Sheduleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Shedule table.
		/// </summary>
		public static List<tbl_utlAlert_Shedule> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SheduleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlert_Shedule> tbl_utlAlert_SheduleList = new List<tbl_utlAlert_Shedule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Shedule tbl_utlAlert_Shedule = Maketbl_utlAlert_Shedule(dataReader);
					tbl_utlAlert_SheduleList.Add(tbl_utlAlert_Shedule);
				}
			}
			scon.Close();
			return tbl_utlAlert_SheduleList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Shedule table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_Shedule> SelectAllByAlert_ID(string alert_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SheduleSelectAllByAlert_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.VarChar,20);
			scom.Parameters["@alert_ID"].Value = alert_ID;
				List<tbl_utlAlert_Shedule> tbl_utlAlert_SheduleList = new List<tbl_utlAlert_Shedule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Shedule tbl_utlAlert_Shedule = Maketbl_utlAlert_Shedule(dataReader);
					tbl_utlAlert_SheduleList.Add(tbl_utlAlert_Shedule);
				}
			}
			scon.Close();
			return tbl_utlAlert_SheduleList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Shedule table by a foreign key.
		/// </summary>
		public static List<tbl_utlAlert_Shedule> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_SheduleSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_utlAlert_Shedule> tbl_utlAlert_SheduleList = new List<tbl_utlAlert_Shedule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Shedule tbl_utlAlert_Shedule = Maketbl_utlAlert_Shedule(dataReader);
					tbl_utlAlert_SheduleList.Add(tbl_utlAlert_Shedule);
				}
			}
			scon.Close();
			return tbl_utlAlert_SheduleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlert_Shedule class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlert_Shedule Maketbl_utlAlert_Shedule(SqlDataReader dataReader) {
			tbl_utlAlert_Shedule tbl_utlAlert_Shedule = new tbl_utlAlert_Shedule();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlert_Shedule.Schedule_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlert_Shedule.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlert_Shedule.Alert_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlAlert_Shedule.IsActive = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlAlert_Shedule.IsDaily = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlAlert_Shedule.IsWeekly = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_utlAlert_Shedule.IsMonthly = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_utlAlert_Shedule.IsYearly = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_utlAlert_Shedule.SheduledTime = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_utlAlert_Shedule.LastAlert_SentTime = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_utlAlert_Shedule.IsLocked = dataReader.GetBoolean(10);
			}

			return tbl_utlAlert_Shedule;
		}
		/// <summary>
		/// This makes tbl_utlAlert_Shedule datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Shedule object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlert_Shedule  tbl_utlAlert_Shedule   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_schedule_ID = new DataColumn("schedule_ID" , typeof(int));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_alert_ID = new DataColumn("alert_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
			DataColumn col_isDaily = new DataColumn("isDaily" , typeof(bool));
			DataColumn col_isWeekly = new DataColumn("isWeekly" , typeof(bool));
			DataColumn col_isMonthly = new DataColumn("isMonthly" , typeof(bool));
			DataColumn col_isYearly = new DataColumn("isYearly" , typeof(bool));
			DataColumn col_sheduledTime = new DataColumn("sheduledTime" , typeof(DateTime));
			DataColumn col_lastAlert_SentTime = new DataColumn("lastAlert_SentTime" , typeof(DateTime));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_schedule_ID,col_companyBranch_ID,col_alert_ID,col_isActive,col_isDaily,col_isWeekly,col_isMonthly,col_isYearly,col_sheduledTime,col_lastAlert_SentTime,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlert_Shedule datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Shedule object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlert_Shedule user) {
		DataRow drow = dt.NewRow();
		
			drow["schedule_ID"] = user.schedule_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["alert_ID"] = user.alert_ID;
			drow["isActive"] = user.isActive;
			drow["isDaily"] = user.isDaily;
			drow["isWeekly"] = user.isWeekly;
			drow["isMonthly"] = user.isMonthly;
			drow["isYearly"] = user.isYearly;
			drow["sheduledTime"] = user.sheduledTime;
			drow["lastAlert_SentTime"] = user.lastAlert_SentTime;
			drow["isLocked"] = user.isLocked;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
