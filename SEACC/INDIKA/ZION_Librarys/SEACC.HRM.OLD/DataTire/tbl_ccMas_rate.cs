using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ccMas_rate {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string activity_ID;
		private int grade_ID;
		private int dayType;
		private int weekTargertStatus;
		private decimal qtyRange;
		private decimal rate1;
		private decimal rate2;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ccMas_rate class.
		/// </summary>
		public tbl_ccMas_rate() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ccMas_rate class.
		/// </summary>
		public tbl_ccMas_rate(string company_ID, string companyBranch_ID, string activity_ID, int grade_ID, int dayType, int weekTargertStatus, decimal qtyRange, decimal rate1, decimal rate2) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.activity_ID = activity_ID;
			this.grade_ID = grade_ID;
			this.dayType = dayType;
			this.weekTargertStatus = weekTargertStatus;
			this.qtyRange = qtyRange;
			this.rate1 = rate1;
			this.rate2 = rate2;
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
		/// Gets or sets the QtyRange value.
		/// </summary>
		public decimal QtyRange {
			get { return qtyRange; }
			set { qtyRange = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rate1 value.
		/// </summary>
		public decimal Rate1 {
			get { return rate1; }
			set { rate1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rate2 value.
		/// </summary>
		public decimal Rate2 {
			get { return rate2; }
			set { rate2 = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ccMas_rate table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccMas_rateInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@grade_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@WeekTargertStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@qtyRange", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rate1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rate2", SqlDbType.Decimal,9);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@activity_ID"].Value = activity_ID;
			scom.Parameters["@grade_ID"].Value = grade_ID;
			scom.Parameters["@dayType"].Value = dayType;
			scom.Parameters["@WeekTargertStatus"].Value = weekTargertStatus;
			scom.Parameters["@qtyRange"].Value = qtyRange;
			scom.Parameters["@rate1"].Value = rate1;
			scom.Parameters["@rate2"].Value = rate2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ccMas_rate table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccMas_rateUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@grade_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@WeekTargertStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@qtyRange", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rate1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rate2", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@activity_ID"].Value = activity_ID;
			scom.Parameters["@grade_ID"].Value = grade_ID;
			scom.Parameters["@dayType"].Value = dayType;
			scom.Parameters["@WeekTargertStatus"].Value = weekTargertStatus;
			scom.Parameters["@qtyRange"].Value = qtyRange;
			scom.Parameters["@rate1"].Value = rate1;
			scom.Parameters["@rate2"].Value = rate2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ccMas_rate table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccMas_rateDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@grade_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@WeekTargertStatus", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@activity_ID"].Value = activity_ID;
 
			scom.Parameters["@grade_ID"].Value = grade_ID;
 
			scom.Parameters["@dayType"].Value = dayType;
 
			scom.Parameters["@WeekTargertStatus"].Value = weekTargertStatus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ccMas_rate table.
		/// </summary>
		public static tbl_ccMas_rate Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string activity_ID_Incoming, int grade_ID_Incoming, int dayType_Incoming, int weekTargertStatus_Incoming){

			tbl_ccMas_rate tbl_ccMas_rateins = new tbl_ccMas_rate();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccMas_rateSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@activity_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@grade_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType", SqlDbType.Int,4);
			scom.Parameters.Add("@WeekTargertStatus", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@activity_ID"].Value = activity_ID_Incoming;
			scom.Parameters["@grade_ID"].Value = grade_ID_Incoming;
			scom.Parameters["@dayType"].Value = dayType_Incoming;
			scom.Parameters["@WeekTargertStatus"].Value = weekTargertStatus_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ccMas_rateins = Maketbl_ccMas_rate(dataReader);
				} else {
					tbl_ccMas_rateins = null;
				}
			}
			scon.Close();
			return tbl_ccMas_rateins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccMas_rate table.
		/// </summary>
		public static List<tbl_ccMas_rate> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccMas_rateSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ccMas_rate> tbl_ccMas_rateList = new List<tbl_ccMas_rate>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccMas_rate tbl_ccMas_rate = Maketbl_ccMas_rate(dataReader);
					tbl_ccMas_rateList.Add(tbl_ccMas_rate);
				}
			}
			scon.Close();
			return tbl_ccMas_rateList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ccMas_rate class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ccMas_rate Maketbl_ccMas_rate(SqlDataReader dataReader) {
			tbl_ccMas_rate tbl_ccMas_rate = new tbl_ccMas_rate();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ccMas_rate.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ccMas_rate.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ccMas_rate.Activity_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ccMas_rate.Grade_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ccMas_rate.DayType = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ccMas_rate.WeekTargertStatus = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ccMas_rate.QtyRange = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ccMas_rate.Rate1 = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ccMas_rate.Rate2 = dataReader.GetDecimal(8);
			}

			return tbl_ccMas_rate;
		}
		/// <summary>
		/// This makes tbl_ccMas_rate datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ccMas_rate object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ccMas_rate  tbl_ccMas_rate   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_activity_ID = new DataColumn("activity_ID" , typeof(string));
			DataColumn col_grade_ID = new DataColumn("grade_ID" , typeof(int));
			DataColumn col_dayType = new DataColumn("dayType" , typeof(int));
			DataColumn col_WeekTargertStatus = new DataColumn("WeekTargertStatus" , typeof(int));
			DataColumn col_qtyRange = new DataColumn("qtyRange" , typeof(decimal));
			DataColumn col_rate1 = new DataColumn("rate1" , typeof(decimal));
			DataColumn col_rate2 = new DataColumn("rate2" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_activity_ID,col_grade_ID,col_dayType,col_WeekTargertStatus,col_qtyRange,col_rate1,col_rate2,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ccMas_rate datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ccMas_rate object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ccMas_rate user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["activity_ID"] = user.activity_ID;
			drow["grade_ID"] = user.grade_ID;
			drow["dayType"] = user.dayType;
			drow["WeekTargertStatus"] = user.WeekTargertStatus;
			drow["qtyRange"] = user.qtyRange;
			drow["rate1"] = user.rate1;
			drow["rate2"] = user.rate2;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
