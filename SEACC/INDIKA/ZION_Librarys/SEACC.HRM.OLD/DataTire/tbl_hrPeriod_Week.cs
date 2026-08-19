using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_hrPeriod_Week {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int year_ID;
		private int week_ID;
		private DateTime startDate;
		private DateTime endDate;
		private decimal werkingDays_Mandatory;
		private decimal target;
		private int weekStatus_ID;
		private bool isCanceled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_hrPeriod_Week class.
		/// </summary>
		public tbl_hrPeriod_Week() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_hrPeriod_Week class.
		/// </summary>
		public tbl_hrPeriod_Week(string company_ID, string companyBranch_ID, int year_ID, int week_ID, DateTime startDate, DateTime endDate, decimal werkingDays_Mandatory, decimal target, int weekStatus_ID, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.year_ID = year_ID;
			this.week_ID = week_ID;
			this.startDate = startDate;
			this.endDate = endDate;
			this.werkingDays_Mandatory = werkingDays_Mandatory;
			this.target = target;
			this.weekStatus_ID = weekStatus_ID;
			this.isCanceled = isCanceled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Company_ID value.
		/// </summary>
		public string Company_ID {
			get { return company_ID; }
			set { company_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Year_ID value.
		/// </summary>
		public int Year_ID {
			get { return year_ID; }
			set { year_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Week_ID value.
		/// </summary>
		public int Week_ID {
			get { return week_ID; }
			set { week_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StartDate value.
		/// </summary>
		public DateTime StartDate {
			get { return startDate; }
			set { startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the EndDate value.
		/// </summary>
		public DateTime EndDate {
			get { return endDate; }
			set { endDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the WerkingDays_Mandatory value.
		/// </summary>
		public decimal WerkingDays_Mandatory {
			get { return werkingDays_Mandatory; }
			set { werkingDays_Mandatory = value; }
		}
		
		/// <summary>
		/// Gets or sets the Target value.
		/// </summary>
		public decimal Target {
			get { return target; }
			set { target = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeekStatus_ID value.
		/// </summary>
		public int WeekStatus_ID {
			get { return weekStatus_ID; }
			set { weekStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Modified value.
		/// </summary>
		public string UserID_Modified {
			get { return userID_Modified; }
			set { userID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Canceled value.
		/// </summary>
		public string UserID_Canceled {
			get { return userID_Canceled; }
			set { userID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Modified value.
		/// </summary>
		public string TerminalID_Modified {
			get { return terminalID_Modified; }
			set { terminalID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Canceled value.
		/// </summary>
		public string TerminalID_Canceled {
			get { return terminalID_Canceled; }
			set { terminalID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Modified value.
		/// </summary>
		public DateTime Date_Modified {
			get { return date_Modified; }
			set { date_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Canceled value.
		/// </summary>
		public DateTime Date_Canceled {
			get { return date_Canceled; }
			set { date_Canceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_hrPeriod_Week table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_WeekInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@werkingDays_Mandatory", SqlDbType.Decimal,9);
			scom.Parameters.Add("@target", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weekStatus_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@werkingDays_Mandatory"].Value = werkingDays_Mandatory;
			scom.Parameters["@target"].Value = target;
			scom.Parameters["@weekStatus_ID"].Value = weekStatus_ID;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_hrPeriod_Week table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_WeekUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@werkingDays_Mandatory", SqlDbType.Decimal,9);
			scom.Parameters.Add("@target", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weekStatus_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@werkingDays_Mandatory"].Value = werkingDays_Mandatory;
			scom.Parameters["@target"].Value = target;
			scom.Parameters["@weekStatus_ID"].Value = weekStatus_ID;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_hrPeriod_Week table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_WeekDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@year_ID"].Value = year_ID;
 
			scom.Parameters["@week_ID"].Value = week_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_hrPeriod_Week table.
		/// </summary>
		public static tbl_hrPeriod_Week Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int year_ID_Incoming, int week_ID_Incoming){

			tbl_hrPeriod_Week tbl_hrPeriod_Weekins = new tbl_hrPeriod_Week();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_WeekSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@year_ID"].Value = year_ID_Incoming;
			scom.Parameters["@week_ID"].Value = week_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_hrPeriod_Weekins = Maketbl_hrPeriod_Week(dataReader);
				} else {
					tbl_hrPeriod_Weekins = null;
				}
			}
			scon.Close();
			return tbl_hrPeriod_Weekins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrPeriod_Week table.
		/// </summary>
		public static List<tbl_hrPeriod_Week> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_WeekSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_hrPeriod_Week> tbl_hrPeriod_WeekList = new List<tbl_hrPeriod_Week>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_hrPeriod_Week tbl_hrPeriod_Week = Maketbl_hrPeriod_Week(dataReader);
					tbl_hrPeriod_WeekList.Add(tbl_hrPeriod_Week);
				}
			}
			scon.Close();
			return tbl_hrPeriod_WeekList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_hrPeriod_Week class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_hrPeriod_Week Maketbl_hrPeriod_Week(SqlDataReader dataReader) {
			tbl_hrPeriod_Week tbl_hrPeriod_Week = new tbl_hrPeriod_Week();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_hrPeriod_Week.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_hrPeriod_Week.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_hrPeriod_Week.Year_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_hrPeriod_Week.Week_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_hrPeriod_Week.StartDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_hrPeriod_Week.EndDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_hrPeriod_Week.WerkingDays_Mandatory = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_hrPeriod_Week.Target = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_hrPeriod_Week.WeekStatus_ID = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_hrPeriod_Week.IsCanceled = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_hrPeriod_Week.UserID_Created = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_hrPeriod_Week.UserID_Modified = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_hrPeriod_Week.UserID_Canceled = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_hrPeriod_Week.TerminalID_Created = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_hrPeriod_Week.TerminalID_Modified = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_hrPeriod_Week.TerminalID_Canceled = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_hrPeriod_Week.Date_Created = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_hrPeriod_Week.Date_Modified = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_hrPeriod_Week.Date_Canceled = dataReader.GetDateTime(18);
			}

			return tbl_hrPeriod_Week;
		}
		/// <summary>
		/// This makes tbl_hrPeriod_Week datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_hrPeriod_Week object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_hrPeriod_Week  tbl_hrPeriod_Week   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_year_ID = new DataColumn("year_ID" , typeof(int));
			DataColumn col_week_ID = new DataColumn("week_ID" , typeof(int));
			DataColumn col_startDate = new DataColumn("startDate" , typeof(DateTime));
			DataColumn col_endDate = new DataColumn("endDate" , typeof(DateTime));
			DataColumn col_werkingDays_Mandatory = new DataColumn("werkingDays_Mandatory" , typeof(decimal));
			DataColumn col_target = new DataColumn("target" , typeof(decimal));
			DataColumn col_weekStatus_ID = new DataColumn("weekStatus_ID" , typeof(int));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_year_ID,col_week_ID,col_startDate,col_endDate,col_werkingDays_Mandatory,col_target,col_weekStatus_ID,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_hrPeriod_Week datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_hrPeriod_Week object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_hrPeriod_Week user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["year_ID"] = user.year_ID;
			drow["week_ID"] = user.week_ID;
			drow["startDate"] = user.startDate;
			drow["endDate"] = user.endDate;
			drow["werkingDays_Mandatory"] = user.werkingDays_Mandatory;
			drow["target"] = user.target;
			drow["weekStatus_ID"] = user.weekStatus_ID;
			drow["isCanceled"] = user.isCanceled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
