using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMasEmployee_PaySlipItems {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string employee_ID;
		private string payItem_ID;
		private int lineNo;
		private decimal rate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genMasEmployee_PaySlipItems class.
		/// </summary>
		public tbl_genMasEmployee_PaySlipItems() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMasEmployee_PaySlipItems class.
		/// </summary>
		public tbl_genMasEmployee_PaySlipItems(string company_ID, string companyBranch_ID, string employee_ID, string payItem_ID, int lineNo, decimal rate) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.employee_ID = employee_ID;
			this.payItem_ID = payItem_ID;
			this.lineNo = lineNo;
			this.rate = rate;
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
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayItem_ID value.
		/// </summary>
		public string PayItem_ID {
			get { return payItem_ID; }
			set { payItem_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LineNo value.
		/// </summary>
		public int LineNo {
			get { return lineNo; }
			set { lineNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Rate value.
		/// </summary>
		public decimal Rate {
			get { return rate; }
			set { rate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genMasEmployee_PaySlipItems table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployee_PaySlipItemsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.Int,4);
			scom.Parameters.Add("@rate", SqlDbType.Decimal,9);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
			scom.Parameters["@lineNo"].Value = lineNo;
			scom.Parameters["@rate"].Value = rate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genMasEmployee_PaySlipItems table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployee_PaySlipItemsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.Int,4);
			scom.Parameters.Add("@rate", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
			scom.Parameters["@lineNo"].Value = lineNo;
			scom.Parameters["@rate"].Value = rate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genMasEmployee_PaySlipItems table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployee_PaySlipItemsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee_PaySlipItems table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployee_PaySlipItemsDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMasEmployee_PaySlipItems table.
		/// </summary>
		public static tbl_genMasEmployee_PaySlipItems Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string employee_ID_Incoming, string payItem_ID_Incoming){

			tbl_genMasEmployee_PaySlipItems tbl_genMasEmployee_PaySlipItemsins = new tbl_genMasEmployee_PaySlipItems();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployee_PaySlipItemsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			scom.Parameters["@payItem_ID"].Value = payItem_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMasEmployee_PaySlipItemsins = Maketbl_genMasEmployee_PaySlipItems(dataReader);
				} else {
					tbl_genMasEmployee_PaySlipItemsins = null;
				}
			}
			scon.Close();
			return tbl_genMasEmployee_PaySlipItemsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee_PaySlipItems table.
		/// </summary>
		public static List<tbl_genMasEmployee_PaySlipItems> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployee_PaySlipItemsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMasEmployee_PaySlipItems> tbl_genMasEmployee_PaySlipItemsList = new List<tbl_genMasEmployee_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee_PaySlipItems tbl_genMasEmployee_PaySlipItems = Maketbl_genMasEmployee_PaySlipItems(dataReader);
					tbl_genMasEmployee_PaySlipItemsList.Add(tbl_genMasEmployee_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_genMasEmployee_PaySlipItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmployee_PaySlipItems table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmployee_PaySlipItems> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployee_PaySlipItemsSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_genMasEmployee_PaySlipItems> tbl_genMasEmployee_PaySlipItemsList = new List<tbl_genMasEmployee_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmployee_PaySlipItems tbl_genMasEmployee_PaySlipItems = Maketbl_genMasEmployee_PaySlipItems(dataReader);
					tbl_genMasEmployee_PaySlipItemsList.Add(tbl_genMasEmployee_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_genMasEmployee_PaySlipItemsList;
		}
		public static List<tbl_genMasEmployee_PaySlipItems> SelectAll_Items(string company_ID, string companyBranch_ID, string employee_ID,bool showOnlyDeffinetionItems)
		{

			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmployee_PaySlipItemsSelectAll_New", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

			scom.Parameters.Add("@company_ID", SqlDbType.VarChar, 8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
			scom.Parameters.Add("@showOnlyDeffinetionItems", SqlDbType.Bit);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@showOnlyDeffinetionItems"].Value = showOnlyDeffinetionItems;
			List<tbl_genMasEmployee_PaySlipItems> tbl_genMasEmployee_PaySlipItemsList = new List<tbl_genMasEmployee_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader())
			{
				while (dataReader.Read())
				{
					tbl_genMasEmployee_PaySlipItems tbl_genMasEmployee_PaySlipItems = Maketbl_genMasEmployee_PaySlipItems(dataReader);
					tbl_genMasEmployee_PaySlipItemsList.Add(tbl_genMasEmployee_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_genMasEmployee_PaySlipItemsList;
		}
		/// <summary>
		/// Creates a new instance of the tbl_genMasEmployee_PaySlipItems class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMasEmployee_PaySlipItems Maketbl_genMasEmployee_PaySlipItems(SqlDataReader dataReader) {
			tbl_genMasEmployee_PaySlipItems tbl_genMasEmployee_PaySlipItems = new tbl_genMasEmployee_PaySlipItems();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMasEmployee_PaySlipItems.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMasEmployee_PaySlipItems.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMasEmployee_PaySlipItems.Employee_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMasEmployee_PaySlipItems.PayItem_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMasEmployee_PaySlipItems.LineNo = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMasEmployee_PaySlipItems.Rate = dataReader.GetDecimal(5);
			}

			return tbl_genMasEmployee_PaySlipItems;
		}
		/// <summary>
		/// This makes tbl_genMasEmployee_PaySlipItems datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMasEmployee_PaySlipItems object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMasEmployee_PaySlipItems  tbl_genMasEmployee_PaySlipItems   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_payItem_ID = new DataColumn("payItem_ID" , typeof(string));
			DataColumn col_lineNo = new DataColumn("lineNo" , typeof(int));
			DataColumn col_rate = new DataColumn("rate" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_employee_ID,col_payItem_ID,col_lineNo,col_rate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMasEmployee_PaySlipItems datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMasEmployee_PaySlipItems object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMasEmployee_PaySlipItems user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["payItem_ID"] = user.payItem_ID;
			drow["lineNo"] = user.lineNo;
			drow["rate"] = user.rate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
