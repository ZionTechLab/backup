using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ccTxDailyWorkingProgress_Rate {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int attendance_index;
		private string activity_ID;
		private int grade_ID;
		private int dayType;
		private int weekTargertStatus;
		private int rateSlab;
		private decimal qty;
		private decimal rate;
		private decimal amount;
		private bool isNightTimeWork;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxDailyWorkingProgress_Rate class.
		/// </summary>
		public tbl_ccTxDailyWorkingProgress_Rate() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxDailyWorkingProgress_Rate class.
		/// </summary>
		public tbl_ccTxDailyWorkingProgress_Rate(string company_ID, string companyBranch_ID, int attendance_index, string activity_ID, int grade_ID, int dayType, int weekTargertStatus, int rateSlab, decimal qty, decimal rate, decimal amount, bool isNightTimeWork) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.attendance_index = attendance_index;
			this.activity_ID = activity_ID;
			this.grade_ID = grade_ID;
			this.dayType = dayType;
			this.weekTargertStatus = weekTargertStatus;
			this.rateSlab = rateSlab;
			this.qty = qty;
			this.rate = rate;
			this.amount = amount;
			this.isNightTimeWork = isNightTimeWork;
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
		/// Gets or sets the Attendance_index value.
		/// </summary>
		public int Attendance_index {
			get { return attendance_index; }
			set { attendance_index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Activity_ID value.
		/// </summary>
		public string Activity_ID {
			get { return activity_ID; }
			set { activity_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Grade_ID value.
		/// </summary>
		public int Grade_ID {
			get { return grade_ID; }
			set { grade_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DayType value.
		/// </summary>
		public int DayType {
			get { return dayType; }
			set { dayType = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeekTargertStatus value.
		/// </summary>
		public int WeekTargertStatus {
			get { return weekTargertStatus; }
			set { weekTargertStatus = value; }
		}
		
		/// <summary>
		/// Gets or sets the RateSlab value.
		/// </summary>
		public int RateSlab {
			get { return rateSlab; }
			set { rateSlab = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rate value.
		/// </summary>
		public decimal Rate {
			get { return rate; }
			set { rate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsNightTimeWork value.
		/// </summary>
		public bool IsNightTimeWork {
			get { return isNightTimeWork; }
			set { isNightTimeWork = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ccTxDailyWorkingProgress_Rate table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgress_RateInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@grade_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@WeekTargertStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@rateSlab", SqlDbType.Int,4);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isNightTimeWork", SqlDbType.Bit,1);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attendance_index"].Value = attendance_index;
			scom.Parameters["@activity_ID"].Value = activity_ID;
			scom.Parameters["@grade_ID"].Value = grade_ID;
			scom.Parameters["@dayType"].Value = dayType;
			scom.Parameters["@WeekTargertStatus"].Value = weekTargertStatus;
			scom.Parameters["@rateSlab"].Value = rateSlab;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@rate"].Value = rate;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@isNightTimeWork"].Value = isNightTimeWork;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ccTxDailyWorkingProgress_Rate table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgress_RateUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@grade_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@WeekTargertStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@rateSlab", SqlDbType.Int,4);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isNightTimeWork", SqlDbType.Bit,1);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attendance_index"].Value = attendance_index;
			scom.Parameters["@activity_ID"].Value = activity_ID;
			scom.Parameters["@grade_ID"].Value = grade_ID;
			scom.Parameters["@dayType"].Value = dayType;
			scom.Parameters["@WeekTargertStatus"].Value = weekTargertStatus;
			scom.Parameters["@rateSlab"].Value = rateSlab;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@rate"].Value = rate;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@isNightTimeWork"].Value = isNightTimeWork;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ccTxDailyWorkingProgress_Rate table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgress_RateDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@grade_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@WeekTargertStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@rateSlab", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@attendance_index"].Value = attendance_index;
 
			scom.Parameters["@activity_ID"].Value = activity_ID;
 
			scom.Parameters["@grade_ID"].Value = grade_ID;
 
			scom.Parameters["@dayType"].Value = dayType;
 
			scom.Parameters["@WeekTargertStatus"].Value = weekTargertStatus;
 
			scom.Parameters["@rateSlab"].Value = rateSlab;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWorkingProgress_Rate table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Attendance_index(string company_ID, string companyBranch_ID, int attendance_index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgress_RateDeleteAllByCompany_ID_CompanyBranch_ID_Attendance_index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attendance_index"].Value = attendance_index;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ccTxDailyWorkingProgress_Rate table.
		/// </summary>
		public static tbl_ccTxDailyWorkingProgress_Rate Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int attendance_index_Incoming, string activity_ID_Incoming, int grade_ID_Incoming, int dayType_Incoming, int weekTargertStatus_Incoming, int rateSlab_Incoming){

			tbl_ccTxDailyWorkingProgress_Rate tbl_ccTxDailyWorkingProgress_Rateins = new tbl_ccTxDailyWorkingProgress_Rate();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgress_RateSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@grade_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@WeekTargertStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@rateSlab", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@attendance_index"].Value = attendance_index_Incoming;
			scom.Parameters["@activity_ID"].Value = activity_ID_Incoming;
			scom.Parameters["@grade_ID"].Value = grade_ID_Incoming;
			scom.Parameters["@dayType"].Value = dayType_Incoming;
			scom.Parameters["@WeekTargertStatus"].Value = weekTargertStatus_Incoming;
			scom.Parameters["@rateSlab"].Value = rateSlab_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ccTxDailyWorkingProgress_Rateins = Maketbl_ccTxDailyWorkingProgress_Rate(dataReader);
				} else {
					tbl_ccTxDailyWorkingProgress_Rateins = null;
				}
			}
			scon.Close();
			return tbl_ccTxDailyWorkingProgress_Rateins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxDailyWorkingProgress_Rate table.
		/// </summary>
		public static List<tbl_ccTxDailyWorkingProgress_Rate> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgress_RateSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ccTxDailyWorkingProgress_Rate> tbl_ccTxDailyWorkingProgress_RateList = new List<tbl_ccTxDailyWorkingProgress_Rate>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxDailyWorkingProgress_Rate tbl_ccTxDailyWorkingProgress_Rate = Maketbl_ccTxDailyWorkingProgress_Rate(dataReader);
					tbl_ccTxDailyWorkingProgress_RateList.Add(tbl_ccTxDailyWorkingProgress_Rate);
				}
			}
			scon.Close();
			return tbl_ccTxDailyWorkingProgress_RateList;
		}


        public static List<tbl_ccTxDailyWorkingProgress_Rate> SelectAll_DateRange(string company_ID, string companyBranch_ID, string employee_ID, DateTime FromDate, DateTime ToDate)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgress_RateSelectAll_Daterange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@company_ID", SqlDbType.VarChar, 8);
            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 8);
            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@company_ID"].Value = company_ID;
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            scom.Parameters["@employee_ID"].Value = employee_ID;
            scom.Parameters.Add("@FromDate", SqlDbType.DateTime, 10);
            scom.Parameters["@FromDate"].Value = FromDate;
            scom.Parameters.Add("@ToDate", SqlDbType.DateTime, 10);
            scom.Parameters["@ToDate"].Value = ToDate;

            List<tbl_ccTxDailyWorkingProgress_Rate> tbl_ccTxDailyWorkingProgress_RateList = new List<tbl_ccTxDailyWorkingProgress_Rate>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_ccTxDailyWorkingProgress_Rate tbl_ccTxDailyWorkingProgress_Rate = Maketbl_ccTxDailyWorkingProgress_Rate(dataReader);
                    tbl_ccTxDailyWorkingProgress_RateList.Add(tbl_ccTxDailyWorkingProgress_Rate);
                }
            }
            scon.Close();
            return tbl_ccTxDailyWorkingProgress_RateList;
        }


        /// <summary>
        /// Selects all records from the tbl_ccTxDailyWorkingProgress_Rate table by a foreign key.
        /// </summary>
        public static List<tbl_ccTxDailyWorkingProgress_Rate> SelectAllByCompany_ID_CompanyBranch_ID_Attendance_index(string company_ID, string companyBranch_ID, int attendance_index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxDailyWorkingProgress_RateSelectAllByCompany_ID_CompanyBranch_ID_Attendance_index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attendance_index", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attendance_index"].Value = attendance_index;
				List<tbl_ccTxDailyWorkingProgress_Rate> tbl_ccTxDailyWorkingProgress_RateList = new List<tbl_ccTxDailyWorkingProgress_Rate>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxDailyWorkingProgress_Rate tbl_ccTxDailyWorkingProgress_Rate = Maketbl_ccTxDailyWorkingProgress_Rate(dataReader);
					tbl_ccTxDailyWorkingProgress_RateList.Add(tbl_ccTxDailyWorkingProgress_Rate);
				}
			}
			scon.Close();
			return tbl_ccTxDailyWorkingProgress_RateList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ccTxDailyWorkingProgress_Rate class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ccTxDailyWorkingProgress_Rate Maketbl_ccTxDailyWorkingProgress_Rate(SqlDataReader dataReader) {
			tbl_ccTxDailyWorkingProgress_Rate tbl_ccTxDailyWorkingProgress_Rate = new tbl_ccTxDailyWorkingProgress_Rate();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.Attendance_index = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.Activity_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.Grade_ID = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.DayType = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.WeekTargertStatus = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.RateSlab = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.Rate = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.Amount = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_ccTxDailyWorkingProgress_Rate.IsNightTimeWork = dataReader.GetBoolean(11);
			}

			return tbl_ccTxDailyWorkingProgress_Rate;
		}
		/// <summary>
		/// This makes tbl_ccTxDailyWorkingProgress_Rate datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ccTxDailyWorkingProgress_Rate object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ccTxDailyWorkingProgress_Rate  tbl_ccTxDailyWorkingProgress_Rate   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_attendance_index = new DataColumn("attendance_index" , typeof(int));
			DataColumn col_activity_ID = new DataColumn("activity_ID" , typeof(string));
			DataColumn col_grade_ID = new DataColumn("grade_ID" , typeof(int));
			DataColumn col_dayType = new DataColumn("dayType" , typeof(int));
			DataColumn col_WeekTargertStatus = new DataColumn("WeekTargertStatus" , typeof(int));
			DataColumn col_rateSlab = new DataColumn("rateSlab" , typeof(int));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_rate = new DataColumn("rate" , typeof(decimal));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_isNightTimeWork = new DataColumn("isNightTimeWork" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_attendance_index,col_activity_ID,col_grade_ID,col_dayType,col_WeekTargertStatus,col_rateSlab,col_qty,col_rate,col_amount,col_isNightTimeWork,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ccTxDailyWorkingProgress_Rate datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ccTxDailyWorkingProgress_Rate object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ccTxDailyWorkingProgress_Rate user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["attendance_index"] = user.attendance_index;
			drow["activity_ID"] = user.activity_ID;
			drow["grade_ID"] = user.grade_ID;
			drow["dayType"] = user.dayType;
			drow["WeekTargertStatus"] = user.WeekTargertStatus;
			drow["rateSlab"] = user.rateSlab;
			drow["qty"] = user.qty;
			drow["rate"] = user.rate;
			drow["amount"] = user.amount;
			drow["isNightTimeWork"] = user.isNightTimeWork;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
