using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_hrPeriod_Month {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int year_ID;
		private int month_ID;
		private string month_Name;
		private DateTime month_startDate;
		private DateTime month_endDate;
		private int status;
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
		/// Initializes a new instance of the tbl_hrPeriod_Month class.
		/// </summary>
		public tbl_hrPeriod_Month() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_hrPeriod_Month class.
		/// </summary>
		public tbl_hrPeriod_Month(string company_ID, string companyBranch_ID, int year_ID, int month_ID, string month_Name, DateTime month_startDate, DateTime month_endDate, int status, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.year_ID = year_ID;
			this.month_ID = month_ID;
			this.month_Name = month_Name;
			this.month_startDate = month_startDate;
			this.month_endDate = month_endDate;
			this.status = status;
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
		/// Gets or sets the Month_ID value.
		/// </summary>
		public int Month_ID {
			get { return month_ID; }
			set { month_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_Name value.
		/// </summary>
		public string Month_Name {
			get { return month_Name; }
			set { month_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_startDate value.
		/// </summary>
		public DateTime Month_startDate {
			get { return month_startDate; }
			set { month_startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_endDate value.
		/// </summary>
		public DateTime Month_endDate {
			get { return month_endDate; }
			set { month_endDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public int Status {
			get { return status; }
			set { status = value; }
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
		/// Saves a record to the tbl_hrPeriod_Month table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_MonthInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_Name", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@month_endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@Status", SqlDbType.Int,4);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@month_Name"].Value = month_Name;
			scom.Parameters["@month_startDate"].Value = month_startDate;
			scom.Parameters["@month_endDate"].Value = month_endDate;
			scom.Parameters["@Status"].Value = status;
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
		/// Updates a record in the tbl_hrPeriod_Month table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_MonthUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_Name", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@month_endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@Status", SqlDbType.Int,4);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@month_Name"].Value = month_Name;
			scom.Parameters["@month_startDate"].Value = month_startDate;
			scom.Parameters["@month_endDate"].Value = month_endDate;
			scom.Parameters["@Status"].Value = status;
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
		/// Deletes a record from the tbl_hrPeriod_Month table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_MonthDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@year_ID"].Value = year_ID;
 
			scom.Parameters["@month_ID"].Value = month_ID;
 
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrPeriod_Month table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_MonthDeleteAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrPeriod_Month table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_MonthDeleteAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_hrPeriod_Month table.
		/// </summary>
		public static tbl_hrPeriod_Month Select(int year_ID_Incoming, int month_ID_Incoming, string company_ID_Incoming, string companyBranch_ID_Incoming)
        {

			tbl_hrPeriod_Month tbl_hrPeriod_Monthins = new tbl_hrPeriod_Month();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_MonthSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@month_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@year_ID"].Value = year_ID_Incoming;
			scom.Parameters["@month_ID"].Value = month_ID_Incoming;
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_hrPeriod_Monthins = Maketbl_hrPeriod_Month(dataReader);
				} else {
					tbl_hrPeriod_Monthins = null;
				}
			}
			scon.Close();
			return tbl_hrPeriod_Monthins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrPeriod_Month table.
		/// </summary>
		public static List<tbl_hrPeriod_Month> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_MonthSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_hrPeriod_Month> tbl_hrPeriod_MonthList = new List<tbl_hrPeriod_Month>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_hrPeriod_Month tbl_hrPeriod_Month = Maketbl_hrPeriod_Month(dataReader);
					tbl_hrPeriod_MonthList.Add(tbl_hrPeriod_Month);
				}
			}
			scon.Close();
			return tbl_hrPeriod_MonthList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrPeriod_Month table by a foreign key.
		/// </summary>
		public static List<tbl_hrPeriod_Month> SelectAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_MonthSelectAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
				List<tbl_hrPeriod_Month> tbl_hrPeriod_MonthList = new List<tbl_hrPeriod_Month>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_hrPeriod_Month tbl_hrPeriod_Month = Maketbl_hrPeriod_Month(dataReader);
					tbl_hrPeriod_MonthList.Add(tbl_hrPeriod_Month);
				}
			}
			scon.Close();
			return tbl_hrPeriod_MonthList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrPeriod_Month table by a foreign key.
		/// </summary>
		public static List<tbl_hrPeriod_Month> SelectAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_MonthSelectAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_hrPeriod_Month> tbl_hrPeriod_MonthList = new List<tbl_hrPeriod_Month>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_hrPeriod_Month tbl_hrPeriod_Month = Maketbl_hrPeriod_Month(dataReader);
					tbl_hrPeriod_MonthList.Add(tbl_hrPeriod_Month);
				}
			}
			scon.Close();
			return tbl_hrPeriod_MonthList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_hrPeriod_Month class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_hrPeriod_Month Maketbl_hrPeriod_Month(SqlDataReader dataReader) {
			tbl_hrPeriod_Month tbl_hrPeriod_Month = new tbl_hrPeriod_Month();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_hrPeriod_Month.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_hrPeriod_Month.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_hrPeriod_Month.Year_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_hrPeriod_Month.Month_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_hrPeriod_Month.Month_Name = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_hrPeriod_Month.Month_startDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_hrPeriod_Month.Month_endDate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_hrPeriod_Month.Status = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_hrPeriod_Month.IsCanceled = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_hrPeriod_Month.UserID_Created = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_hrPeriod_Month.UserID_Modified = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_hrPeriod_Month.UserID_Canceled = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_hrPeriod_Month.TerminalID_Created = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_hrPeriod_Month.TerminalID_Modified = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_hrPeriod_Month.TerminalID_Canceled = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_hrPeriod_Month.Date_Created = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_hrPeriod_Month.Date_Modified = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_hrPeriod_Month.Date_Canceled = dataReader.GetDateTime(17);
			}

			return tbl_hrPeriod_Month;
		}
		/// <summary>
		/// This makes tbl_hrPeriod_Month datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_hrPeriod_Month object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_hrPeriod_Month  tbl_hrPeriod_Month   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_year_ID = new DataColumn("year_ID" , typeof(int));
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(int));
			DataColumn col_month_Name = new DataColumn("month_Name" , typeof(string));
			DataColumn col_month_startDate = new DataColumn("month_startDate" , typeof(DateTime));
			DataColumn col_month_endDate = new DataColumn("month_endDate" , typeof(DateTime));
			DataColumn col_Status = new DataColumn("Status" , typeof(int));
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
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_year_ID,col_month_ID,col_month_Name,col_month_startDate,col_month_endDate,col_Status,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_hrPeriod_Month datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_hrPeriod_Month object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_hrPeriod_Month user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["year_ID"] = user.year_ID;
			drow["month_ID"] = user.month_ID;
			drow["month_Name"] = user.month_Name;
			drow["month_startDate"] = user.month_startDate;
			drow["month_endDate"] = user.month_endDate;
			drow["Status"] = user.Status;
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
