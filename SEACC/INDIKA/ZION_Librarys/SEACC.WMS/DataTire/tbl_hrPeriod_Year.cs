using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_hrPeriod_Year {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string hrYear_ID;
		private string year_Name;
		private DateTime year_startDate;
		private DateTime year_endDate;
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
		/// Initializes a new instance of the tbl_hrPeriod_Year class.
		/// </summary>
		public tbl_hrPeriod_Year() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_hrPeriod_Year class.
		/// </summary>
		public tbl_hrPeriod_Year(string company_ID, string companyBranch_ID, string hrYear_ID, string year_Name, DateTime year_startDate, DateTime year_endDate, int status, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.hrYear_ID = hrYear_ID;
			this.year_Name = year_Name;
			this.year_startDate = year_startDate;
			this.year_endDate = year_endDate;
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
		/// Gets or sets the HrYear_ID value.
		/// </summary>
		public string HrYear_ID {
			get { return hrYear_ID; }
			set { hrYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Year_Name value.
		/// </summary>
		public string Year_Name {
			get { return year_Name; }
			set { year_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Year_startDate value.
		/// </summary>
		public DateTime Year_startDate {
			get { return year_startDate; }
			set { year_startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Year_endDate value.
		/// </summary>
		public DateTime Year_endDate {
			get { return year_endDate; }
			set { year_endDate = value; }
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
		/// Saves a record to the tbl_hrPeriod_Year table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_YearInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@hrYear_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_Name", SqlDbType.VarChar,20);
			scom.Parameters.Add("@year_startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@year_endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@Status", SqlDbType.Int,4);
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
			scom.Parameters["@hrYear_ID"].Value = hrYear_ID;
			scom.Parameters["@year_Name"].Value = year_Name;
			scom.Parameters["@year_startDate"].Value = year_startDate;
			scom.Parameters["@year_endDate"].Value = year_endDate;
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
		/// Updates a record in the tbl_hrPeriod_Year table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_YearUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@hrYear_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_Name", SqlDbType.VarChar,20);
			scom.Parameters.Add("@year_startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@year_endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@Status", SqlDbType.Int,4);
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
			scom.Parameters["@hrYear_ID"].Value = hrYear_ID;
			scom.Parameters["@year_Name"].Value = year_Name;
			scom.Parameters["@year_startDate"].Value = year_startDate;
			scom.Parameters["@year_endDate"].Value = year_endDate;
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
		/// Deletes a record from the tbl_hrPeriod_Year table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_YearDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@hrYear_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@hrYear_ID"].Value = hrYear_ID;
 
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrPeriod_Year table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_YearDeleteAllByCompany_ID_CompanyBranch_ID", scon);
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
		/// Selects all records from the tbl_hrPeriod_Year table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_YearDeleteAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_hrPeriod_Year table.
		/// </summary>
		public static tbl_hrPeriod_Year Select(string hrYear_ID_Incoming, string company_ID_Incoming, string companyBranch_ID_Incoming)
        {

			tbl_hrPeriod_Year tbl_hrPeriod_Yearins = new tbl_hrPeriod_Year();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_YearSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@hrYear_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@hrYear_ID"].Value = hrYear_ID_Incoming;
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_hrPeriod_Yearins = Maketbl_hrPeriod_Year(dataReader);
				} else {
					tbl_hrPeriod_Yearins = null;
				}
			}
			scon.Close();
			return tbl_hrPeriod_Yearins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrPeriod_Year table.
		/// </summary>
		public static List<tbl_hrPeriod_Year> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_YearSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_hrPeriod_Year> tbl_hrPeriod_YearList = new List<tbl_hrPeriod_Year>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_hrPeriod_Year tbl_hrPeriod_Year = Maketbl_hrPeriod_Year(dataReader);
					tbl_hrPeriod_YearList.Add(tbl_hrPeriod_Year);
				}
			}
			scon.Close();
			return tbl_hrPeriod_YearList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrPeriod_Year table by a foreign key.
		/// </summary>
		public static List<tbl_hrPeriod_Year> SelectAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_YearSelectAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_hrPeriod_Year> tbl_hrPeriod_YearList = new List<tbl_hrPeriod_Year>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_hrPeriod_Year tbl_hrPeriod_Year = Maketbl_hrPeriod_Year(dataReader);
					tbl_hrPeriod_YearList.Add(tbl_hrPeriod_Year);
				}
			}
			scon.Close();
			return tbl_hrPeriod_YearList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrPeriod_Year table by a foreign key.
		/// </summary>
		public static List<tbl_hrPeriod_Year> SelectAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrPeriod_YearSelectAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
				List<tbl_hrPeriod_Year> tbl_hrPeriod_YearList = new List<tbl_hrPeriod_Year>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_hrPeriod_Year tbl_hrPeriod_Year = Maketbl_hrPeriod_Year(dataReader);
					tbl_hrPeriod_YearList.Add(tbl_hrPeriod_Year);
				}
			}
			scon.Close();
			return tbl_hrPeriod_YearList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_hrPeriod_Year class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_hrPeriod_Year Maketbl_hrPeriod_Year(SqlDataReader dataReader) {
			tbl_hrPeriod_Year tbl_hrPeriod_Year = new tbl_hrPeriod_Year();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_hrPeriod_Year.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_hrPeriod_Year.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_hrPeriod_Year.HrYear_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_hrPeriod_Year.Year_Name = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_hrPeriod_Year.Year_startDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_hrPeriod_Year.Year_endDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_hrPeriod_Year.Status = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_hrPeriod_Year.IsCanceled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_hrPeriod_Year.UserID_Created = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_hrPeriod_Year.UserID_Modified = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_hrPeriod_Year.UserID_Canceled = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_hrPeriod_Year.TerminalID_Created = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_hrPeriod_Year.TerminalID_Modified = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_hrPeriod_Year.TerminalID_Canceled = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_hrPeriod_Year.Date_Created = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_hrPeriod_Year.Date_Modified = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_hrPeriod_Year.Date_Canceled = dataReader.GetDateTime(16);
			}

			return tbl_hrPeriod_Year;
		}
		/// <summary>
		/// This makes tbl_hrPeriod_Year datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_hrPeriod_Year object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_hrPeriod_Year  tbl_hrPeriod_Year   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_hrYear_ID = new DataColumn("hrYear_ID" , typeof(string));
			DataColumn col_year_Name = new DataColumn("year_Name" , typeof(string));
			DataColumn col_year_startDate = new DataColumn("year_startDate" , typeof(DateTime));
			DataColumn col_year_endDate = new DataColumn("year_endDate" , typeof(DateTime));
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
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_hrYear_ID,col_year_Name,col_year_startDate,col_year_endDate,col_Status,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_hrPeriod_Year datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_hrPeriod_Year object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_hrPeriod_Year user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["hrYear_ID"] = user.hrYear_ID;
			drow["year_Name"] = user.year_Name;
			drow["year_startDate"] = user.year_startDate;
			drow["year_endDate"] = user.year_endDate;
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
