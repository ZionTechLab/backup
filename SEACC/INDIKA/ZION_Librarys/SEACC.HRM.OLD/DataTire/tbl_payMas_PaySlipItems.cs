using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payMas_PaySlipItems {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string payItem_ID;
		private string payItem_Code;
		private string payItem_Title;
		private string payItem_Class_ID;
		private string payItem_Type_ID;
		private int inputMode;
		private bool isEarning;
		private int pay_Period;
		private bool is_OneTimePayment;
		private int oneTime_PayrollYear;
		private int oneTime_PayrollMonth;
		private bool isCanceled;
		private bool isNoPayable;
		private bool isZeroValueShow;
		private bool isPayslipApplicable;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_PaySlipItems class.
		/// </summary>
		public tbl_payMas_PaySlipItems() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_PaySlipItems class.
		/// </summary>
		public tbl_payMas_PaySlipItems(string company_ID, string companyBranch_ID, string payItem_ID, string payItem_Code, string payItem_Title, string payItem_Class_ID, string payItem_Type_ID, int inputMode, bool isEarning, int pay_Period, bool is_OneTimePayment, int oneTime_PayrollYear, int oneTime_PayrollMonth, bool isCanceled, bool isNoPayable, bool isZeroValueShow, bool isPayslipApplicable) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.payItem_ID = payItem_ID;
			this.payItem_Code = payItem_Code;
			this.payItem_Title = payItem_Title;
			this.payItem_Class_ID = payItem_Class_ID;
			this.payItem_Type_ID = payItem_Type_ID;
			this.inputMode = inputMode;
			this.isEarning = isEarning;
			this.pay_Period = pay_Period;
			this.is_OneTimePayment = is_OneTimePayment;
			this.oneTime_PayrollYear = oneTime_PayrollYear;
			this.oneTime_PayrollMonth = oneTime_PayrollMonth;
			this.isCanceled = isCanceled;
			this.isNoPayable = isNoPayable;
			this.isZeroValueShow = isZeroValueShow;
			this.isPayslipApplicable = isPayslipApplicable;
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
		/// Gets or sets the PayItem_ID value.
		/// </summary>
		public string PayItem_ID {
			get { return payItem_ID; }
			set { payItem_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayItem_Code value.
		/// </summary>
		public string PayItem_Code {
			get { return payItem_Code; }
			set { payItem_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayItem_Title value.
		/// </summary>
		public string PayItem_Title {
			get { return payItem_Title; }
			set { payItem_Title = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayItem_Class_ID value.
		/// </summary>
		public string PayItem_Class_ID {
			get { return payItem_Class_ID; }
			set { payItem_Class_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayItem_Type_ID value.
		/// </summary>
		public string PayItem_Type_ID {
			get { return payItem_Type_ID; }
			set { payItem_Type_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the InputMode value.
		/// </summary>
		public int InputMode {
			get { return inputMode; }
			set { inputMode = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsEarning value.
		/// </summary>
		public bool IsEarning {
			get { return isEarning; }
			set { isEarning = value; }
		}
		
		/// <summary>
		/// Gets or sets the Pay_Period value.
		/// </summary>
		public int Pay_Period {
			get { return pay_Period; }
			set { pay_Period = value; }
		}
		
		/// <summary>
		/// Gets or sets the Is_OneTimePayment value.
		/// </summary>
		public bool Is_OneTimePayment {
			get { return is_OneTimePayment; }
			set { is_OneTimePayment = value; }
		}
		
		/// <summary>
		/// Gets or sets the OneTime_PayrollYear value.
		/// </summary>
		public int OneTime_PayrollYear {
			get { return oneTime_PayrollYear; }
			set { oneTime_PayrollYear = value; }
		}
		
		/// <summary>
		/// Gets or sets the OneTime_PayrollMonth value.
		/// </summary>
		public int OneTime_PayrollMonth {
			get { return oneTime_PayrollMonth; }
			set { oneTime_PayrollMonth = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsNoPayable value.
		/// </summary>
		public bool IsNoPayable {
			get { return isNoPayable; }
			set { isNoPayable = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsZeroValueShow value.
		/// </summary>
		public bool IsZeroValueShow {
			get { return isZeroValueShow; }
			set { isZeroValueShow = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPayslipApplicable value.
		/// </summary>
		public bool IsPayslipApplicable {
			get { return isPayslipApplicable; }
			set { isPayslipApplicable = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_payMas_PaySlipItems table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItemsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@inputMode", SqlDbType.Int,4);
			scom.Parameters.Add("@isEarning", SqlDbType.Bit,1);
			scom.Parameters.Add("@pay_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@is_OneTimePayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@oneTime_PayrollYear", SqlDbType.Int,4);
			scom.Parameters.Add("@oneTime_PayrollMonth", SqlDbType.Int,4);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNoPayable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isZeroValueShow", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPayslipApplicable", SqlDbType.Bit,1);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
			scom.Parameters["@payItem_Code"].Value = payItem_Code;
			scom.Parameters["@payItem_Title"].Value = payItem_Title;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
			scom.Parameters["@payItem_Type_ID"].Value = payItem_Type_ID;
			scom.Parameters["@inputMode"].Value = inputMode;
			scom.Parameters["@isEarning"].Value = isEarning;
			scom.Parameters["@pay_Period"].Value = pay_Period;
			scom.Parameters["@is_OneTimePayment"].Value = is_OneTimePayment;
			scom.Parameters["@oneTime_PayrollYear"].Value = oneTime_PayrollYear;
			scom.Parameters["@oneTime_PayrollMonth"].Value = oneTime_PayrollMonth;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@isNoPayable"].Value = isNoPayable;
			scom.Parameters["@isZeroValueShow"].Value = isZeroValueShow;
			scom.Parameters["@isPayslipApplicable"].Value = isPayslipApplicable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payMas_PaySlipItems table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItemsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@inputMode", SqlDbType.Int,4);
			scom.Parameters.Add("@isEarning", SqlDbType.Bit,1);
			scom.Parameters.Add("@pay_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@is_OneTimePayment", SqlDbType.Bit,1);
			scom.Parameters.Add("@oneTime_PayrollYear", SqlDbType.Int,4);
			scom.Parameters.Add("@oneTime_PayrollMonth", SqlDbType.Int,4);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNoPayable", SqlDbType.Bit,1);
			scom.Parameters.Add("@isZeroValueShow", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPayslipApplicable", SqlDbType.Bit,1);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
			scom.Parameters["@payItem_Code"].Value = payItem_Code;
			scom.Parameters["@payItem_Title"].Value = payItem_Title;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
			scom.Parameters["@payItem_Type_ID"].Value = payItem_Type_ID;
			scom.Parameters["@inputMode"].Value = inputMode;
			scom.Parameters["@isEarning"].Value = isEarning;
			scom.Parameters["@pay_Period"].Value = pay_Period;
			scom.Parameters["@is_OneTimePayment"].Value = is_OneTimePayment;
			scom.Parameters["@oneTime_PayrollYear"].Value = oneTime_PayrollYear;
			scom.Parameters["@oneTime_PayrollMonth"].Value = oneTime_PayrollMonth;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@isNoPayable"].Value = isNoPayable;
			scom.Parameters["@isZeroValueShow"].Value = isZeroValueShow;
			scom.Parameters["@isPayslipApplicable"].Value = isPayslipApplicable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payMas_PaySlipItems table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItemsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
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
		/// Selects all records from the tbl_payMas_PaySlipItems table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_PayItem_Class_ID_PayItem_Type_ID(string company_ID, string companyBranch_ID, string payItem_Class_ID, string payItem_Type_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItemsDeleteAllByCompany_ID_CompanyBranch_ID_PayItem_Class_ID_PayItem_Type_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
			scom.Parameters["@payItem_Type_ID"].Value = payItem_Type_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_payMas_PaySlipItems table.
		/// </summary>
		public static tbl_payMas_PaySlipItems Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string payItem_ID_Incoming){

			tbl_payMas_PaySlipItems tbl_payMas_PaySlipItemsins = new tbl_payMas_PaySlipItems();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItemsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@payItem_ID"].Value = payItem_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payMas_PaySlipItemsins = Maketbl_payMas_PaySlipItems(dataReader);
				} else {
					tbl_payMas_PaySlipItemsins = null;
				}
			}
			scon.Close();
			return tbl_payMas_PaySlipItemsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PaySlipItems table.
		/// </summary>
		public static List<tbl_payMas_PaySlipItems> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItemsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payMas_PaySlipItems> tbl_payMas_PaySlipItemsList = new List<tbl_payMas_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PaySlipItems tbl_payMas_PaySlipItems = Maketbl_payMas_PaySlipItems(dataReader);
					tbl_payMas_PaySlipItemsList.Add(tbl_payMas_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_payMas_PaySlipItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PaySlipItems table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_PaySlipItems> SelectAllByCompany_ID_CompanyBranch_ID_PayItem_Class_ID_PayItem_Type_ID(string company_ID, string companyBranch_ID, string payItem_Class_ID, string payItem_Type_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItemsSelectAllByCompany_ID_CompanyBranch_ID_PayItem_Class_ID_PayItem_Type_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
			scom.Parameters["@payItem_Type_ID"].Value = payItem_Type_ID;
				List<tbl_payMas_PaySlipItems> tbl_payMas_PaySlipItemsList = new List<tbl_payMas_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PaySlipItems tbl_payMas_PaySlipItems = Maketbl_payMas_PaySlipItems(dataReader);
					tbl_payMas_PaySlipItemsList.Add(tbl_payMas_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_payMas_PaySlipItemsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payMas_PaySlipItems class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payMas_PaySlipItems Maketbl_payMas_PaySlipItems(SqlDataReader dataReader) {
			tbl_payMas_PaySlipItems tbl_payMas_PaySlipItems = new tbl_payMas_PaySlipItems();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payMas_PaySlipItems.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payMas_PaySlipItems.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payMas_PaySlipItems.PayItem_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payMas_PaySlipItems.PayItem_Code = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payMas_PaySlipItems.PayItem_Title = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_payMas_PaySlipItems.PayItem_Class_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_payMas_PaySlipItems.PayItem_Type_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_payMas_PaySlipItems.InputMode = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_payMas_PaySlipItems.IsEarning = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_payMas_PaySlipItems.Pay_Period = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_payMas_PaySlipItems.Is_OneTimePayment = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_payMas_PaySlipItems.OneTime_PayrollYear = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_payMas_PaySlipItems.OneTime_PayrollMonth = dataReader.GetInt32(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_payMas_PaySlipItems.IsCanceled = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_payMas_PaySlipItems.IsNoPayable = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_payMas_PaySlipItems.IsZeroValueShow = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_payMas_PaySlipItems.IsPayslipApplicable = dataReader.GetBoolean(16);
			}

			return tbl_payMas_PaySlipItems;
		}
		/// <summary>
		/// This makes tbl_payMas_PaySlipItems datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payMas_PaySlipItems object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payMas_PaySlipItems  tbl_payMas_PaySlipItems   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_payItem_ID = new DataColumn("payItem_ID" , typeof(string));
			DataColumn col_payItem_Code = new DataColumn("payItem_Code" , typeof(string));
			DataColumn col_payItem_Title = new DataColumn("payItem_Title" , typeof(string));
			DataColumn col_payItem_Class_ID = new DataColumn("payItem_Class_ID" , typeof(string));
			DataColumn col_payItem_Type_ID = new DataColumn("payItem_Type_ID" , typeof(string));
			DataColumn col_inputMode = new DataColumn("inputMode" , typeof(int));
			DataColumn col_isEarning = new DataColumn("isEarning" , typeof(bool));
			DataColumn col_pay_Period = new DataColumn("pay_Period" , typeof(int));
			DataColumn col_is_OneTimePayment = new DataColumn("is_OneTimePayment" , typeof(bool));
			DataColumn col_oneTime_PayrollYear = new DataColumn("oneTime_PayrollYear" , typeof(int));
			DataColumn col_oneTime_PayrollMonth = new DataColumn("oneTime_PayrollMonth" , typeof(int));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_isNoPayable = new DataColumn("isNoPayable" , typeof(bool));
			DataColumn col_isZeroValueShow = new DataColumn("isZeroValueShow" , typeof(bool));
			DataColumn col_isPayslipApplicable = new DataColumn("isPayslipApplicable" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_payItem_ID,col_payItem_Code,col_payItem_Title,col_payItem_Class_ID,col_payItem_Type_ID,col_inputMode,col_isEarning,col_pay_Period,col_is_OneTimePayment,col_oneTime_PayrollYear,col_oneTime_PayrollMonth,col_isCanceled,col_isNoPayable,col_isZeroValueShow,col_isPayslipApplicable,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payMas_PaySlipItems datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payMas_PaySlipItems object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payMas_PaySlipItems user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["payItem_ID"] = user.payItem_ID;
			drow["payItem_Code"] = user.payItem_Code;
			drow["payItem_Title"] = user.payItem_Title;
			drow["payItem_Class_ID"] = user.payItem_Class_ID;
			drow["payItem_Type_ID"] = user.payItem_Type_ID;
			drow["inputMode"] = user.inputMode;
			drow["isEarning"] = user.isEarning;
			drow["pay_Period"] = user.pay_Period;
			drow["is_OneTimePayment"] = user.is_OneTimePayment;
			drow["oneTime_PayrollYear"] = user.oneTime_PayrollYear;
			drow["oneTime_PayrollMonth"] = user.oneTime_PayrollMonth;
			drow["isCanceled"] = user.isCanceled;
			drow["isNoPayable"] = user.isNoPayable;
			drow["isZeroValueShow"] = user.isZeroValueShow;
			drow["isPayslipApplicable"] = user.isPayslipApplicable;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
