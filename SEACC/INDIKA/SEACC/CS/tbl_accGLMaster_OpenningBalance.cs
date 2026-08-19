using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_OpenningBalance {
		#region Fields
		private string gl_ID;
		private string financialYear_ID;
		private string month_ID;
		private decimal openingBalance;
		private bool isCreditOpening;
		private decimal closingBalance;
		private bool isCreditClosing;
		private decimal debitAmount;
		private decimal creditAmount;
		private decimal budget;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_OpenningBalance class.
		/// </summary>
		public tbl_accGLMaster_OpenningBalance() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_OpenningBalance class.
		/// </summary>
		public tbl_accGLMaster_OpenningBalance(string gl_ID, string financialYear_ID, string month_ID, decimal openingBalance, bool isCreditOpening, decimal closingBalance, bool isCreditClosing, decimal debitAmount, decimal creditAmount, decimal budget) {
			this.gl_ID = gl_ID;
			this.financialYear_ID = financialYear_ID;
			this.month_ID = month_ID;
			this.openingBalance = openingBalance;
			this.isCreditOpening = isCreditOpening;
			this.closingBalance = closingBalance;
			this.isCreditClosing = isCreditClosing;
			this.debitAmount = debitAmount;
			this.creditAmount = creditAmount;
			this.budget = budget;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_ID value.
		/// </summary>
		public string Month_ID {
			get { return month_ID; }
			set { month_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OpeningBalance value.
		/// </summary>
		public decimal OpeningBalance {
			get { return openingBalance; }
			set { openingBalance = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCreditOpening value.
		/// </summary>
		public bool IsCreditOpening {
			get { return isCreditOpening; }
			set { isCreditOpening = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClosingBalance value.
		/// </summary>
		public decimal ClosingBalance {
			get { return closingBalance; }
			set { closingBalance = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCreditClosing value.
		/// </summary>
		public bool IsCreditClosing {
			get { return isCreditClosing; }
			set { isCreditClosing = value; }
		}
		
		/// <summary>
		/// Gets or sets the DebitAmount value.
		/// </summary>
		public decimal DebitAmount {
			get { return debitAmount; }
			set { debitAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreditAmount value.
		/// </summary>
		public decimal CreditAmount {
			get { return creditAmount; }
			set { creditAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Budget value.
		/// </summary>
		public decimal Budget {
			get { return budget; }
			set { budget = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLMaster_OpenningBalance table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_OpenningBalanceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@openingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCreditOpening", SqlDbType.Bit,1);
			scom.Parameters.Add("@closingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCreditClosing", SqlDbType.Bit,1);
			scom.Parameters.Add("@debitAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@budget", SqlDbType.Decimal,9);
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@openingBalance"].Value = openingBalance;
			scom.Parameters["@isCreditOpening"].Value = isCreditOpening;
			scom.Parameters["@closingBalance"].Value = closingBalance;
			scom.Parameters["@isCreditClosing"].Value = isCreditClosing;
			scom.Parameters["@debitAmount"].Value = debitAmount;
			scom.Parameters["@creditAmount"].Value = creditAmount;
			scom.Parameters["@budget"].Value = budget;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_OpenningBalance table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_OpenningBalanceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@openingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCreditOpening", SqlDbType.Bit,1);
			scom.Parameters.Add("@closingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCreditClosing", SqlDbType.Bit,1);
			scom.Parameters.Add("@debitAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@creditAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@budget", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@openingBalance"].Value = openingBalance;
			scom.Parameters["@isCreditOpening"].Value = isCreditOpening;
			scom.Parameters["@closingBalance"].Value = closingBalance;
			scom.Parameters["@isCreditClosing"].Value = isCreditClosing;
			scom.Parameters["@debitAmount"].Value = debitAmount;
			scom.Parameters["@creditAmount"].Value = creditAmount;
			scom.Parameters["@budget"].Value = budget;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_OpenningBalance table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_OpenningBalanceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
			scom.Parameters["@month_ID"].Value = month_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_OpenningBalance table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_OpenningBalanceDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_OpenningBalance table by a foreign key.
		/// </summary>
		public static void DeleteAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_OpenningBalanceDeleteAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster_OpenningBalance table.
		/// </summary>
		public static tbl_accGLMaster_OpenningBalance Select(string gl_ID_Incoming, string financialYear_ID_Incoming, string month_ID_Incoming){

			tbl_accGLMaster_OpenningBalance tbl_accGLMaster_OpenningBalanceins = new tbl_accGLMaster_OpenningBalance();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_OpenningBalanceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID_Incoming;
			scom.Parameters["@month_ID"].Value = month_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMaster_OpenningBalanceins = Maketbl_accGLMaster_OpenningBalance(dataReader);
				} else {
					tbl_accGLMaster_OpenningBalanceins = null;
				}
			}
			scon.Close();
			return tbl_accGLMaster_OpenningBalanceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_OpenningBalance table.
		/// </summary>
		public static List<tbl_accGLMaster_OpenningBalance> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_OpenningBalanceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_OpenningBalance> tbl_accGLMaster_OpenningBalanceList = new List<tbl_accGLMaster_OpenningBalance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_OpenningBalance tbl_accGLMaster_OpenningBalance = Maketbl_accGLMaster_OpenningBalance(dataReader);
					tbl_accGLMaster_OpenningBalanceList.Add(tbl_accGLMaster_OpenningBalance);
				}
			}
			scon.Close();
			return tbl_accGLMaster_OpenningBalanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_OpenningBalance table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_OpenningBalance> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_OpenningBalanceSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accGLMaster_OpenningBalance> tbl_accGLMaster_OpenningBalanceList = new List<tbl_accGLMaster_OpenningBalance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_OpenningBalance tbl_accGLMaster_OpenningBalance = Maketbl_accGLMaster_OpenningBalance(dataReader);
					tbl_accGLMaster_OpenningBalanceList.Add(tbl_accGLMaster_OpenningBalance);
				}
			}
			scon.Close();
			return tbl_accGLMaster_OpenningBalanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_OpenningBalance table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_OpenningBalance> SelectAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_OpenningBalanceSelectAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
				List<tbl_accGLMaster_OpenningBalance> tbl_accGLMaster_OpenningBalanceList = new List<tbl_accGLMaster_OpenningBalance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_OpenningBalance tbl_accGLMaster_OpenningBalance = Maketbl_accGLMaster_OpenningBalance(dataReader);
					tbl_accGLMaster_OpenningBalanceList.Add(tbl_accGLMaster_OpenningBalance);
				}
			}
			scon.Close();
			return tbl_accGLMaster_OpenningBalanceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_OpenningBalance class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_OpenningBalance Maketbl_accGLMaster_OpenningBalance(SqlDataReader dataReader) {
			tbl_accGLMaster_OpenningBalance tbl_accGLMaster_OpenningBalance = new tbl_accGLMaster_OpenningBalance();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_OpenningBalance.Gl_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_OpenningBalance.FinancialYear_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_OpenningBalance.Month_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accGLMaster_OpenningBalance.OpeningBalance = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accGLMaster_OpenningBalance.IsCreditOpening = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accGLMaster_OpenningBalance.ClosingBalance = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accGLMaster_OpenningBalance.IsCreditClosing = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accGLMaster_OpenningBalance.DebitAmount = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accGLMaster_OpenningBalance.CreditAmount = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accGLMaster_OpenningBalance.Budget = dataReader.GetDecimal(9);
			}

			return tbl_accGLMaster_OpenningBalance;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_OpenningBalance datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_OpenningBalance object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_OpenningBalance  tbl_accGLMaster_OpenningBalance   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(string));
			DataColumn col_openingBalance = new DataColumn("openingBalance" , typeof(decimal));
			DataColumn col_isCreditOpening = new DataColumn("isCreditOpening" , typeof(bool));
			DataColumn col_closingBalance = new DataColumn("closingBalance" , typeof(decimal));
			DataColumn col_isCreditClosing = new DataColumn("isCreditClosing" , typeof(bool));
			DataColumn col_debitAmount = new DataColumn("debitAmount" , typeof(decimal));
			DataColumn col_creditAmount = new DataColumn("creditAmount" , typeof(decimal));
			DataColumn col_budget = new DataColumn("budget" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_gl_ID,col_financialYear_ID,col_month_ID,col_openingBalance,col_isCreditOpening,col_closingBalance,col_isCreditClosing,col_debitAmount,col_creditAmount,col_budget,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_OpenningBalance datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_OpenningBalance object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_OpenningBalance user) {
		DataRow drow = dt.NewRow();
		
			drow["gl_ID"] = user.gl_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["month_ID"] = user.month_ID;
			drow["openingBalance"] = user.openingBalance;
			drow["isCreditOpening"] = user.isCreditOpening;
			drow["closingBalance"] = user.closingBalance;
			drow["isCreditClosing"] = user.isCreditClosing;
			drow["debitAmount"] = user.debitAmount;
			drow["creditAmount"] = user.creditAmount;
			drow["budget"] = user.budget;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
