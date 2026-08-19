using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audTxEmployee_PaySlipItems {
		#region Fields
		private Int64 audit_ID;
		private string company_ID;
		private string companyBranch_ID;
		private string employee_ID;
		private string payItem_ID;
		private int function_ID;
		private int activityType_ID;
		private decimal previous_Amount;
		private decimal new_Amount;
		private DateTime activityDate;
		private bool is_SystemGenerated;
		private string user_ID;
		private string terminal_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audTxEmployee_PaySlipItems class.
		/// </summary>
		public tbl_audTxEmployee_PaySlipItems() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audTxEmployee_PaySlipItems class.
		/// </summary>
		public tbl_audTxEmployee_PaySlipItems(string company_ID, string companyBranch_ID, string employee_ID, string payItem_ID, int function_ID, int activityType_ID, decimal previous_Amount, decimal new_Amount, DateTime activityDate, bool is_SystemGenerated, string user_ID, string terminal_ID) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.employee_ID = employee_ID;
			this.payItem_ID = payItem_ID;
			this.function_ID = function_ID;
			this.activityType_ID = activityType_ID;
			this.previous_Amount = previous_Amount;
			this.new_Amount = new_Amount;
			this.activityDate = activityDate;
			this.is_SystemGenerated = is_SystemGenerated;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audTxEmployee_PaySlipItems class.
		/// </summary>
		public tbl_audTxEmployee_PaySlipItems(Int64 audit_ID, string company_ID, string companyBranch_ID, string employee_ID, string payItem_ID, int function_ID, int activityType_ID, decimal previous_Amount, decimal new_Amount, DateTime activityDate, bool is_SystemGenerated, string user_ID, string terminal_ID) {
			this.audit_ID = audit_ID;
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.employee_ID = employee_ID;
			this.payItem_ID = payItem_ID;
			this.function_ID = function_ID;
			this.activityType_ID = activityType_ID;
			this.previous_Amount = previous_Amount;
			this.new_Amount = new_Amount;
			this.activityDate = activityDate;
			this.is_SystemGenerated = is_SystemGenerated;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Audit_ID value.
		/// </summary>
		public Int64 Audit_ID {
			get { return audit_ID; }
			set { audit_ID = value; }
		}
		
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
		/// Gets or sets the Function_ID value.
		/// </summary>
		public int Function_ID {
			get { return function_ID; }
			set { function_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ActivityType_ID value.
		/// </summary>
		public int ActivityType_ID {
			get { return activityType_ID; }
			set { activityType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Previous_Amount value.
		/// </summary>
		public decimal Previous_Amount {
			get { return previous_Amount; }
			set { previous_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the New_Amount value.
		/// </summary>
		public decimal New_Amount {
			get { return new_Amount; }
			set { new_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ActivityDate value.
		/// </summary>
		public DateTime ActivityDate {
			get { return activityDate; }
			set { activityDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Is_SystemGenerated value.
		/// </summary>
		public bool Is_SystemGenerated {
			get { return is_SystemGenerated; }
			set { is_SystemGenerated = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_audTxEmployee_PaySlipItems table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@activityType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@previous_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@new_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@activityDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@is_SystemGenerated", SqlDbType.Bit,1);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@activityType_ID"].Value = activityType_ID;
			scom.Parameters["@previous_Amount"].Value = previous_Amount;
			scom.Parameters["@new_Amount"].Value = new_Amount;
			scom.Parameters["@activityDate"].Value = activityDate;
			scom.Parameters["@is_SystemGenerated"].Value = is_SystemGenerated;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audTxEmployee_PaySlipItems table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@activityType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@previous_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@new_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@activityDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@is_SystemGenerated", SqlDbType.Bit,1);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@activityType_ID"].Value = activityType_ID;
			scom.Parameters["@previous_Amount"].Value = previous_Amount;
			scom.Parameters["@new_Amount"].Value = new_Amount;
			scom.Parameters["@activityDate"].Value = activityDate;
			scom.Parameters["@is_SystemGenerated"].Value = is_SystemGenerated;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audTxEmployee_PaySlipItems table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@audit_ID", SqlDbType.BigInt,8);
			scom.Parameters["@audit_ID"].Value = audit_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTxEmployee_PaySlipItems table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTxEmployee_PaySlipItems table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
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
		/// Selects all records from the tbl_audTxEmployee_PaySlipItems table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_PayItem_ID(string company_ID, string companyBranch_ID, string payItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsDeleteAllByCompany_ID_CompanyBranch_ID_PayItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTxEmployee_PaySlipItems table by a foreign key.
		/// </summary>
		public static void DeleteAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsDeleteAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audTxEmployee_PaySlipItems table.
		/// </summary>
		public static tbl_audTxEmployee_PaySlipItems Select(Int64 audit_ID_Incoming){

			tbl_audTxEmployee_PaySlipItems tbl_audTxEmployee_PaySlipItemsins = new tbl_audTxEmployee_PaySlipItems();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@audit_ID", SqlDbType.BigInt,8);
			scom.Parameters["@audit_ID"].Value = audit_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audTxEmployee_PaySlipItemsins = Maketbl_audTxEmployee_PaySlipItems(dataReader);
				} else {
					tbl_audTxEmployee_PaySlipItemsins = null;
				}
			}
			scon.Close();
			return tbl_audTxEmployee_PaySlipItemsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTxEmployee_PaySlipItems table.
		/// </summary>
		public static List<tbl_audTxEmployee_PaySlipItems> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audTxEmployee_PaySlipItems> tbl_audTxEmployee_PaySlipItemsList = new List<tbl_audTxEmployee_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTxEmployee_PaySlipItems tbl_audTxEmployee_PaySlipItems = Maketbl_audTxEmployee_PaySlipItems(dataReader);
					tbl_audTxEmployee_PaySlipItemsList.Add(tbl_audTxEmployee_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_audTxEmployee_PaySlipItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTxEmployee_PaySlipItems table by a foreign key.
		/// </summary>
		public static List<tbl_audTxEmployee_PaySlipItems> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_audTxEmployee_PaySlipItems> tbl_audTxEmployee_PaySlipItemsList = new List<tbl_audTxEmployee_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTxEmployee_PaySlipItems tbl_audTxEmployee_PaySlipItems = Maketbl_audTxEmployee_PaySlipItems(dataReader);
					tbl_audTxEmployee_PaySlipItemsList.Add(tbl_audTxEmployee_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_audTxEmployee_PaySlipItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTxEmployee_PaySlipItems table by a foreign key.
		/// </summary>
		public static List<tbl_audTxEmployee_PaySlipItems> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_audTxEmployee_PaySlipItems> tbl_audTxEmployee_PaySlipItemsList = new List<tbl_audTxEmployee_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTxEmployee_PaySlipItems tbl_audTxEmployee_PaySlipItems = Maketbl_audTxEmployee_PaySlipItems(dataReader);
					tbl_audTxEmployee_PaySlipItemsList.Add(tbl_audTxEmployee_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_audTxEmployee_PaySlipItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTxEmployee_PaySlipItems table by a foreign key.
		/// </summary>
		public static List<tbl_audTxEmployee_PaySlipItems> SelectAllByCompany_ID_CompanyBranch_ID_PayItem_ID(string company_ID, string companyBranch_ID, string payItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsSelectAllByCompany_ID_CompanyBranch_ID_PayItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
				List<tbl_audTxEmployee_PaySlipItems> tbl_audTxEmployee_PaySlipItemsList = new List<tbl_audTxEmployee_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTxEmployee_PaySlipItems tbl_audTxEmployee_PaySlipItems = Maketbl_audTxEmployee_PaySlipItems(dataReader);
					tbl_audTxEmployee_PaySlipItemsList.Add(tbl_audTxEmployee_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_audTxEmployee_PaySlipItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTxEmployee_PaySlipItems table by a foreign key.
		/// </summary>
		public static List<tbl_audTxEmployee_PaySlipItems> SelectAllByFunction_ID(int function_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTxEmployee_PaySlipItemsSelectAllByFunction_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@function_ID"].Value = function_ID;
				List<tbl_audTxEmployee_PaySlipItems> tbl_audTxEmployee_PaySlipItemsList = new List<tbl_audTxEmployee_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTxEmployee_PaySlipItems tbl_audTxEmployee_PaySlipItems = Maketbl_audTxEmployee_PaySlipItems(dataReader);
					tbl_audTxEmployee_PaySlipItemsList.Add(tbl_audTxEmployee_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_audTxEmployee_PaySlipItemsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audTxEmployee_PaySlipItems class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audTxEmployee_PaySlipItems Maketbl_audTxEmployee_PaySlipItems(SqlDataReader dataReader) {
			tbl_audTxEmployee_PaySlipItems tbl_audTxEmployee_PaySlipItems = new tbl_audTxEmployee_PaySlipItems();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audTxEmployee_PaySlipItems.Audit_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audTxEmployee_PaySlipItems.Company_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audTxEmployee_PaySlipItems.CompanyBranch_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audTxEmployee_PaySlipItems.Employee_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_audTxEmployee_PaySlipItems.PayItem_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_audTxEmployee_PaySlipItems.Function_ID = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_audTxEmployee_PaySlipItems.ActivityType_ID = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_audTxEmployee_PaySlipItems.Previous_Amount = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_audTxEmployee_PaySlipItems.New_Amount = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_audTxEmployee_PaySlipItems.ActivityDate = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_audTxEmployee_PaySlipItems.Is_SystemGenerated = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_audTxEmployee_PaySlipItems.User_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_audTxEmployee_PaySlipItems.Terminal_ID = dataReader.GetString(12);
			}

			return tbl_audTxEmployee_PaySlipItems;
		}
		/// <summary>
		/// This makes tbl_audTxEmployee_PaySlipItems datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audTxEmployee_PaySlipItems object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audTxEmployee_PaySlipItems  tbl_audTxEmployee_PaySlipItems   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_audit_ID = new DataColumn("audit_ID" , typeof(Int64));
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_payItem_ID = new DataColumn("payItem_ID" , typeof(string));
			DataColumn col_function_ID = new DataColumn("function_ID" , typeof(int));
			DataColumn col_activityType_ID = new DataColumn("activityType_ID" , typeof(int));
			DataColumn col_previous_Amount = new DataColumn("previous_Amount" , typeof(decimal));
			DataColumn col_new_Amount = new DataColumn("new_Amount" , typeof(decimal));
			DataColumn col_activityDate = new DataColumn("activityDate" , typeof(DateTime));
			DataColumn col_is_SystemGenerated = new DataColumn("is_SystemGenerated" , typeof(bool));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_audit_ID,col_company_ID,col_companyBranch_ID,col_employee_ID,col_payItem_ID,col_function_ID,col_activityType_ID,col_previous_Amount,col_new_Amount,col_activityDate,col_is_SystemGenerated,col_user_ID,col_terminal_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audTxEmployee_PaySlipItems datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audTxEmployee_PaySlipItems object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audTxEmployee_PaySlipItems user) {
		DataRow drow = dt.NewRow();
		
			drow["audit_ID"] = user.audit_ID;
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["payItem_ID"] = user.payItem_ID;
			drow["function_ID"] = user.function_ID;
			drow["activityType_ID"] = user.activityType_ID;
			drow["previous_Amount"] = user.previous_Amount;
			drow["new_Amount"] = user.new_Amount;
			drow["activityDate"] = user.activityDate;
			drow["is_SystemGenerated"] = user.is_SystemGenerated;
			drow["user_ID"] = user.user_ID;
			drow["terminal_ID"] = user.terminal_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
