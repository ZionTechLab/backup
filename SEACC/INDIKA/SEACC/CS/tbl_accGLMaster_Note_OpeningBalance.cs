using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_Note_OpeningBalance {
		#region Fields
		private string glNote_ID;
		private string financialYear_ID;
		private decimal openingBalance;
		private decimal closingBalance;
		private bool isCredit;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Note_OpeningBalance class.
		/// </summary>
		public tbl_accGLMaster_Note_OpeningBalance() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Note_OpeningBalance class.
		/// </summary>
		public tbl_accGLMaster_Note_OpeningBalance(string glNote_ID, string financialYear_ID, decimal openingBalance, decimal closingBalance, bool isCredit) {
			this.glNote_ID = glNote_ID;
			this.financialYear_ID = financialYear_ID;
			this.openingBalance = openingBalance;
			this.closingBalance = closingBalance;
			this.isCredit = isCredit;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the GlNote_ID value.
		/// </summary>
		public string GlNote_ID {
			get { return glNote_ID; }
			set { glNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OpeningBalance value.
		/// </summary>
		public decimal OpeningBalance {
			get { return openingBalance; }
			set { openingBalance = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClosingBalance value.
		/// </summary>
		public decimal ClosingBalance {
			get { return closingBalance; }
			set { closingBalance = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCredit value.
		/// </summary>
		public bool IsCredit {
			get { return isCredit; }
			set { isCredit = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLMaster_Note_OpeningBalance table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_Note_OpeningBalanceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@glNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@openingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@closingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
 
			scom.Parameters["@glNote_ID"].Value = glNote_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@openingBalance"].Value = openingBalance;
			scom.Parameters["@closingBalance"].Value = closingBalance;
			scom.Parameters["@isCredit"].Value = isCredit;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_Note_OpeningBalance table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_Note_OpeningBalanceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@glNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@openingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@closingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCredit", SqlDbType.Bit,1);
 
 
			scom.Parameters["@glNote_ID"].Value = glNote_ID;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@openingBalance"].Value = openingBalance;
			scom.Parameters["@closingBalance"].Value = closingBalance;
			scom.Parameters["@isCredit"].Value = isCredit;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_Note_OpeningBalance table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_Note_OpeningBalanceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@glNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glNote_ID"].Value = glNote_ID;
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Note_OpeningBalance table by a foreign key.
		/// </summary>
		public static void DeleteAllByGlNote_ID(string glNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_Note_OpeningBalanceDeleteAllByGlNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glNote_ID"].Value = glNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Note_OpeningBalance table by a foreign key.
		/// </summary>
		public static void DeleteAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_Note_OpeningBalanceDeleteAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster_Note_OpeningBalance table.
		/// </summary>
		public static tbl_accGLMaster_Note_OpeningBalance Select(string glNote_ID_Incoming, string financialYear_ID_Incoming){

			tbl_accGLMaster_Note_OpeningBalance tbl_accGLMaster_Note_OpeningBalanceins = new tbl_accGLMaster_Note_OpeningBalance();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_Note_OpeningBalanceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glNote_ID"].Value = glNote_ID_Incoming;
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMaster_Note_OpeningBalanceins = Maketbl_accGLMaster_Note_OpeningBalance(dataReader);
				} else {
					tbl_accGLMaster_Note_OpeningBalanceins = null;
				}
			}
			scon.Close();
			return tbl_accGLMaster_Note_OpeningBalanceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Note_OpeningBalance table.
		/// </summary>
		public static List<tbl_accGLMaster_Note_OpeningBalance> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_Note_OpeningBalanceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_Note_OpeningBalance> tbl_accGLMaster_Note_OpeningBalanceList = new List<tbl_accGLMaster_Note_OpeningBalance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Note_OpeningBalance tbl_accGLMaster_Note_OpeningBalance = Maketbl_accGLMaster_Note_OpeningBalance(dataReader);
					tbl_accGLMaster_Note_OpeningBalanceList.Add(tbl_accGLMaster_Note_OpeningBalance);
				}
			}
			scon.Close();
			return tbl_accGLMaster_Note_OpeningBalanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Note_OpeningBalance table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_Note_OpeningBalance> SelectAllByGlNote_ID(string glNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_Note_OpeningBalanceSelectAllByGlNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@glNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@glNote_ID"].Value = glNote_ID;
				List<tbl_accGLMaster_Note_OpeningBalance> tbl_accGLMaster_Note_OpeningBalanceList = new List<tbl_accGLMaster_Note_OpeningBalance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Note_OpeningBalance tbl_accGLMaster_Note_OpeningBalance = Maketbl_accGLMaster_Note_OpeningBalance(dataReader);
					tbl_accGLMaster_Note_OpeningBalanceList.Add(tbl_accGLMaster_Note_OpeningBalance);
				}
			}
			scon.Close();
			return tbl_accGLMaster_Note_OpeningBalanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Note_OpeningBalance table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_Note_OpeningBalance> SelectAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_Note_OpeningBalanceSelectAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
				List<tbl_accGLMaster_Note_OpeningBalance> tbl_accGLMaster_Note_OpeningBalanceList = new List<tbl_accGLMaster_Note_OpeningBalance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Note_OpeningBalance tbl_accGLMaster_Note_OpeningBalance = Maketbl_accGLMaster_Note_OpeningBalance(dataReader);
					tbl_accGLMaster_Note_OpeningBalanceList.Add(tbl_accGLMaster_Note_OpeningBalance);
				}
			}
			scon.Close();
			return tbl_accGLMaster_Note_OpeningBalanceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_Note_OpeningBalance class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_Note_OpeningBalance Maketbl_accGLMaster_Note_OpeningBalance(SqlDataReader dataReader) {
			tbl_accGLMaster_Note_OpeningBalance tbl_accGLMaster_Note_OpeningBalance = new tbl_accGLMaster_Note_OpeningBalance();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_Note_OpeningBalance.GlNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_Note_OpeningBalance.FinancialYear_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_Note_OpeningBalance.OpeningBalance = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accGLMaster_Note_OpeningBalance.ClosingBalance = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accGLMaster_Note_OpeningBalance.IsCredit = dataReader.GetBoolean(4);
			}

			return tbl_accGLMaster_Note_OpeningBalance;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_Note_OpeningBalance datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Note_OpeningBalance object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_Note_OpeningBalance  tbl_accGLMaster_Note_OpeningBalance   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_glNote_ID = new DataColumn("glNote_ID" , typeof(string));
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_openingBalance = new DataColumn("openingBalance" , typeof(decimal));
			DataColumn col_closingBalance = new DataColumn("closingBalance" , typeof(decimal));
			DataColumn col_isCredit = new DataColumn("isCredit" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_glNote_ID,col_financialYear_ID,col_openingBalance,col_closingBalance,col_isCredit,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_Note_OpeningBalance datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Note_OpeningBalance object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_Note_OpeningBalance user) {
		DataRow drow = dt.NewRow();
		
			drow["glNote_ID"] = user.glNote_ID;
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["openingBalance"] = user.openingBalance;
			drow["closingBalance"] = user.closingBalance;
			drow["isCredit"] = user.isCredit;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
