using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ccTxEndOfWeekProgress_rate {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int year_ID;
		private int week_ID;
		private string employee_ID;
		private int daytype;
		private string rate_ID;
		private decimal qty;
		private decimal rate;
		private decimal amount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxEndOfWeekProgress_rate class.
		/// </summary>
		public tbl_ccTxEndOfWeekProgress_rate() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ccTxEndOfWeekProgress_rate class.
		/// </summary>
		public tbl_ccTxEndOfWeekProgress_rate(string company_ID, string companyBranch_ID, int year_ID, int week_ID, string employee_ID, int daytype, string rate_ID, decimal qty, decimal rate, decimal amount) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.year_ID = year_ID;
			this.week_ID = week_ID;
			this.employee_ID = employee_ID;
			this.daytype = daytype;
			this.rate_ID = rate_ID;
			this.qty = qty;
			this.rate = rate;
			this.amount = amount;
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
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Daytype value.
		/// </summary>
		public int Daytype {
			get { return daytype; }
			set { daytype = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rate_ID value.
		/// </summary>
		public string Rate_ID {
			get { return rate_ID; }
			set { rate_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ccTxEndOfWeekProgress_rate table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgress_rateInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@daytype", SqlDbType.Int,4);
			scom.Parameters.Add("@rate_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@daytype"].Value = daytype;
			scom.Parameters["@rate_ID"].Value = rate_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@rate"].Value = rate;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ccTxEndOfWeekProgress_rate table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgress_rateUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@daytype", SqlDbType.Int,4);
			scom.Parameters.Add("@rate_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@year_ID"].Value = year_ID;
			scom.Parameters["@week_ID"].Value = week_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@daytype"].Value = daytype;
			scom.Parameters["@rate_ID"].Value = rate_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@rate"].Value = rate;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ccTxEndOfWeekProgress_rate table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgress_rateDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@daytype", SqlDbType.Int,4);
			scom.Parameters.Add("@rate_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@year_ID"].Value = year_ID;
 
			scom.Parameters["@week_ID"].Value = week_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scom.Parameters["@daytype"].Value = daytype;
 
			scom.Parameters["@rate_ID"].Value = rate_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ccTxEndOfWeekProgress_rate table.
		/// </summary>
		public static tbl_ccTxEndOfWeekProgress_rate Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int year_ID_Incoming, int week_ID_Incoming, string employee_ID_Incoming, int daytype_Incoming, string rate_ID_Incoming){

			tbl_ccTxEndOfWeekProgress_rate tbl_ccTxEndOfWeekProgress_rateins = new tbl_ccTxEndOfWeekProgress_rate();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgress_rateSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@year_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@week_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@daytype", SqlDbType.Int,4);
			scom.Parameters.Add("@rate_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@year_ID"].Value = year_ID_Incoming;
			scom.Parameters["@week_ID"].Value = week_ID_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			scom.Parameters["@daytype"].Value = daytype_Incoming;
			scom.Parameters["@rate_ID"].Value = rate_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ccTxEndOfWeekProgress_rateins = Maketbl_ccTxEndOfWeekProgress_rate(dataReader);
				} else {
					tbl_ccTxEndOfWeekProgress_rateins = null;
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekProgress_rateins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ccTxEndOfWeekProgress_rate table.
		/// </summary>
		public static List<tbl_ccTxEndOfWeekProgress_rate> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ccTxEndOfWeekProgress_rateSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ccTxEndOfWeekProgress_rate> tbl_ccTxEndOfWeekProgress_rateList = new List<tbl_ccTxEndOfWeekProgress_rate>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ccTxEndOfWeekProgress_rate tbl_ccTxEndOfWeekProgress_rate = Maketbl_ccTxEndOfWeekProgress_rate(dataReader);
					tbl_ccTxEndOfWeekProgress_rateList.Add(tbl_ccTxEndOfWeekProgress_rate);
				}
			}
			scon.Close();
			return tbl_ccTxEndOfWeekProgress_rateList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ccTxEndOfWeekProgress_rate class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ccTxEndOfWeekProgress_rate Maketbl_ccTxEndOfWeekProgress_rate(SqlDataReader dataReader) {
			tbl_ccTxEndOfWeekProgress_rate tbl_ccTxEndOfWeekProgress_rate = new tbl_ccTxEndOfWeekProgress_rate();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ccTxEndOfWeekProgress_rate.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ccTxEndOfWeekProgress_rate.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ccTxEndOfWeekProgress_rate.Year_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ccTxEndOfWeekProgress_rate.Week_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ccTxEndOfWeekProgress_rate.Employee_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ccTxEndOfWeekProgress_rate.Daytype = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ccTxEndOfWeekProgress_rate.Rate_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ccTxEndOfWeekProgress_rate.Qty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ccTxEndOfWeekProgress_rate.Rate = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ccTxEndOfWeekProgress_rate.Amount = dataReader.GetDecimal(9);
			}

			return tbl_ccTxEndOfWeekProgress_rate;
		}
		/// <summary>
		/// This makes tbl_ccTxEndOfWeekProgress_rate datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ccTxEndOfWeekProgress_rate object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ccTxEndOfWeekProgress_rate  tbl_ccTxEndOfWeekProgress_rate   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_year_ID = new DataColumn("year_ID" , typeof(int));
			DataColumn col_week_ID = new DataColumn("week_ID" , typeof(int));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_daytype = new DataColumn("daytype" , typeof(int));
			DataColumn col_rate_ID = new DataColumn("rate_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_rate = new DataColumn("rate" , typeof(decimal));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_year_ID,col_week_ID,col_employee_ID,col_daytype,col_rate_ID,col_qty,col_rate,col_amount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ccTxEndOfWeekProgress_rate datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ccTxEndOfWeekProgress_rate object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ccTxEndOfWeekProgress_rate user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["year_ID"] = user.year_ID;
			drow["week_ID"] = user.week_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["daytype"] = user.daytype;
			drow["rate_ID"] = user.rate_ID;
			drow["qty"] = user.qty;
			drow["rate"] = user.rate;
			drow["amount"] = user.amount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
