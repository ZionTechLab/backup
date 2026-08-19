using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payTxSIPRawData_PaySlipItems {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int sIP_ID;
		private string payItem_ID;
		private int lineNo;
		private string payItem_Code;
		private string payItem_Title;
		private string payItem_Class_ID;
		private string payItem_Type_ID;
		private int inputMode;
		private bool isEarning;
		private int pay_Period;
		private string paymentMethod_ID;
		private decimal amount;
		private decimal checked_Amount;
		private decimal approved_Amount;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string checkedTerminal_ID;
		private string approvedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payTxSIPRawData_PaySlipItems class.
		/// </summary>
		public tbl_payTxSIPRawData_PaySlipItems() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payTxSIPRawData_PaySlipItems class.
		/// </summary>
		public tbl_payTxSIPRawData_PaySlipItems(string company_ID, string companyBranch_ID, int sIP_ID, string payItem_ID, int lineNo, string payItem_Code, string payItem_Title, string payItem_Class_ID, string payItem_Type_ID, int inputMode, bool isEarning, int pay_Period, string paymentMethod_ID, decimal amount, decimal checked_Amount, decimal approved_Amount, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string checkedTerminal_ID, string approvedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.sIP_ID = sIP_ID;
			this.payItem_ID = payItem_ID;
			this.lineNo = lineNo;
			this.payItem_Code = payItem_Code;
			this.payItem_Title = payItem_Title;
			this.payItem_Class_ID = payItem_Class_ID;
			this.payItem_Type_ID = payItem_Type_ID;
			this.inputMode = inputMode;
			this.isEarning = isEarning;
			this.pay_Period = pay_Period;
			this.paymentMethod_ID = paymentMethod_ID;
			this.amount = amount;
			this.checked_Amount = checked_Amount;
			this.approved_Amount = approved_Amount;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.checkedTerminal_ID = checkedTerminal_ID;
			this.approvedTerminal_ID = approvedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
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
		/// Gets or sets the SIP_ID value.
		/// </summary>
		public int SIP_ID {
			get { return sIP_ID; }
			set { sIP_ID = value; }
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
		/// Gets or sets the PaymentMethod_ID value.
		/// </summary>
		public string PaymentMethod_ID {
			get { return paymentMethod_ID; }
			set { paymentMethod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Checked_Amount value.
		/// </summary>
		public decimal Checked_Amount {
			get { return checked_Amount; }
			set { checked_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Approved_Amount value.
		/// </summary>
		public decimal Approved_Amount {
			get { return approved_Amount; }
			set { approved_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedUser_ID value.
		/// </summary>
		public string CheckedUser_ID {
			get { return checkedUser_ID; }
			set { checkedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedTerminal_ID value.
		/// </summary>
		public string CheckedTerminal_ID {
			get { return checkedTerminal_ID; }
			set { checkedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedTerminal_ID value.
		/// </summary>
		public string ApprovedTerminal_ID {
			get { return approvedTerminal_ID; }
			set { approvedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateChecked value.
		/// </summary>
		public DateTime DateChecked {
			get { return dateChecked; }
			set { dateChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateApproved value.
		/// </summary>
		public DateTime DateApproved {
			get { return dateApproved; }
			set { dateApproved = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_payTxSIPRawData_PaySlipItems table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawData_PaySlipItemsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.Int,4);
			scom.Parameters.Add("@payItem_Code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@inputMode", SqlDbType.Int,4);
			scom.Parameters.Add("@isEarning", SqlDbType.Bit,1);
			scom.Parameters.Add("@pay_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@checked_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@approved_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@SIP_ID"].Value = sIP_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
			scom.Parameters["@lineNo"].Value = lineNo;
			scom.Parameters["@payItem_Code"].Value = payItem_Code;
			scom.Parameters["@payItem_Title"].Value = payItem_Title;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
			scom.Parameters["@payItem_Type_ID"].Value = payItem_Type_ID;
			scom.Parameters["@inputMode"].Value = inputMode;
			scom.Parameters["@isEarning"].Value = isEarning;
			scom.Parameters["@pay_Period"].Value = pay_Period;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@checked_Amount"].Value = checked_Amount;
			scom.Parameters["@approved_Amount"].Value = approved_Amount;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payTxSIPRawData_PaySlipItems table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawData_PaySlipItemsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.Int,4);
			scom.Parameters.Add("@payItem_Code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@inputMode", SqlDbType.Int,4);
			scom.Parameters.Add("@isEarning", SqlDbType.Bit,1);
			scom.Parameters.Add("@pay_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@paymentMethod_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@checked_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@approved_Amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@SIP_ID"].Value = sIP_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
			scom.Parameters["@lineNo"].Value = lineNo;
			scom.Parameters["@payItem_Code"].Value = payItem_Code;
			scom.Parameters["@payItem_Title"].Value = payItem_Title;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
			scom.Parameters["@payItem_Type_ID"].Value = payItem_Type_ID;
			scom.Parameters["@inputMode"].Value = inputMode;
			scom.Parameters["@isEarning"].Value = isEarning;
			scom.Parameters["@pay_Period"].Value = pay_Period;
			scom.Parameters["@paymentMethod_ID"].Value = paymentMethod_ID;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@checked_Amount"].Value = checked_Amount;
			scom.Parameters["@approved_Amount"].Value = approved_Amount;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payTxSIPRawData_PaySlipItems table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawData_PaySlipItemsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@SIP_ID"].Value = sIP_ID;
 
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payTxSIPRawData_PaySlipItems table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_SIP_ID(string company_ID, string companyBranch_ID, int sIP_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawData_PaySlipItemsDeleteAllByCompany_ID_CompanyBranch_ID_SIP_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@SIP_ID"].Value = sIP_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_payTxSIPRawData_PaySlipItems table.
		/// </summary>
		public static tbl_payTxSIPRawData_PaySlipItems Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int sIP_ID_Incoming, string payItem_ID_Incoming){

			tbl_payTxSIPRawData_PaySlipItems tbl_payTxSIPRawData_PaySlipItemsins = new tbl_payTxSIPRawData_PaySlipItems();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawData_PaySlipItemsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@SIP_ID"].Value = sIP_ID_Incoming;
			scom.Parameters["@payItem_ID"].Value = payItem_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payTxSIPRawData_PaySlipItemsins = Maketbl_payTxSIPRawData_PaySlipItems(dataReader);
				} else {
					tbl_payTxSIPRawData_PaySlipItemsins = null;
				}
			}
			scon.Close();
			return tbl_payTxSIPRawData_PaySlipItemsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payTxSIPRawData_PaySlipItems table.
		/// </summary>
		public static List<tbl_payTxSIPRawData_PaySlipItems> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawData_PaySlipItemsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payTxSIPRawData_PaySlipItems> tbl_payTxSIPRawData_PaySlipItemsList = new List<tbl_payTxSIPRawData_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payTxSIPRawData_PaySlipItems tbl_payTxSIPRawData_PaySlipItems = Maketbl_payTxSIPRawData_PaySlipItems(dataReader);
					tbl_payTxSIPRawData_PaySlipItemsList.Add(tbl_payTxSIPRawData_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_payTxSIPRawData_PaySlipItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payTxSIPRawData_PaySlipItems table by a foreign key.
		/// </summary>
		public static List<tbl_payTxSIPRawData_PaySlipItems> SelectAllByCompany_ID_CompanyBranch_ID_SIP_ID(string company_ID, string companyBranch_ID, int sIP_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawData_PaySlipItemsSelectAllByCompany_ID_CompanyBranch_ID_SIP_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@SIP_ID"].Value = sIP_ID;
				List<tbl_payTxSIPRawData_PaySlipItems> tbl_payTxSIPRawData_PaySlipItemsList = new List<tbl_payTxSIPRawData_PaySlipItems>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payTxSIPRawData_PaySlipItems tbl_payTxSIPRawData_PaySlipItems = Maketbl_payTxSIPRawData_PaySlipItems(dataReader);
					tbl_payTxSIPRawData_PaySlipItemsList.Add(tbl_payTxSIPRawData_PaySlipItems);
				}
			}
			scon.Close();
			return tbl_payTxSIPRawData_PaySlipItemsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payTxSIPRawData_PaySlipItems class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payTxSIPRawData_PaySlipItems Maketbl_payTxSIPRawData_PaySlipItems(SqlDataReader dataReader) {
			tbl_payTxSIPRawData_PaySlipItems tbl_payTxSIPRawData_PaySlipItems = new tbl_payTxSIPRawData_PaySlipItems();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payTxSIPRawData_PaySlipItems.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payTxSIPRawData_PaySlipItems.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payTxSIPRawData_PaySlipItems.SIP_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payTxSIPRawData_PaySlipItems.PayItem_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payTxSIPRawData_PaySlipItems.LineNo = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_payTxSIPRawData_PaySlipItems.PayItem_Code = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_payTxSIPRawData_PaySlipItems.PayItem_Title = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_payTxSIPRawData_PaySlipItems.PayItem_Class_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_payTxSIPRawData_PaySlipItems.PayItem_Type_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_payTxSIPRawData_PaySlipItems.InputMode = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_payTxSIPRawData_PaySlipItems.IsEarning = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_payTxSIPRawData_PaySlipItems.Pay_Period = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_payTxSIPRawData_PaySlipItems.PaymentMethod_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_payTxSIPRawData_PaySlipItems.Amount = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_payTxSIPRawData_PaySlipItems.Checked_Amount = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_payTxSIPRawData_PaySlipItems.Approved_Amount = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_payTxSIPRawData_PaySlipItems.CreateUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_payTxSIPRawData_PaySlipItems.ModifiedUser_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_payTxSIPRawData_PaySlipItems.CheckedUser_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_payTxSIPRawData_PaySlipItems.ApprovedUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_payTxSIPRawData_PaySlipItems.CreateTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_payTxSIPRawData_PaySlipItems.ModifiedTerminal_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_payTxSIPRawData_PaySlipItems.CheckedTerminal_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_payTxSIPRawData_PaySlipItems.ApprovedTerminal_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_payTxSIPRawData_PaySlipItems.DateCreate = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_payTxSIPRawData_PaySlipItems.DateModified = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_payTxSIPRawData_PaySlipItems.DateChecked = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_payTxSIPRawData_PaySlipItems.DateApproved = dataReader.GetDateTime(27);
			}

			return tbl_payTxSIPRawData_PaySlipItems;
		}
		/// <summary>
		/// This makes tbl_payTxSIPRawData_PaySlipItems datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payTxSIPRawData_PaySlipItems object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payTxSIPRawData_PaySlipItems  tbl_payTxSIPRawData_PaySlipItems   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_SIP_ID = new DataColumn("SIP_ID" , typeof(int));
			DataColumn col_payItem_ID = new DataColumn("payItem_ID" , typeof(string));
			DataColumn col_lineNo = new DataColumn("lineNo" , typeof(int));
			DataColumn col_payItem_Code = new DataColumn("payItem_Code" , typeof(string));
			DataColumn col_payItem_Title = new DataColumn("payItem_Title" , typeof(string));
			DataColumn col_payItem_Class_ID = new DataColumn("payItem_Class_ID" , typeof(string));
			DataColumn col_payItem_Type_ID = new DataColumn("payItem_Type_ID" , typeof(string));
			DataColumn col_inputMode = new DataColumn("inputMode" , typeof(int));
			DataColumn col_isEarning = new DataColumn("isEarning" , typeof(bool));
			DataColumn col_pay_Period = new DataColumn("pay_Period" , typeof(int));
			DataColumn col_paymentMethod_ID = new DataColumn("paymentMethod_ID" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_checked_Amount = new DataColumn("checked_Amount" , typeof(decimal));
			DataColumn col_approved_Amount = new DataColumn("approved_Amount" , typeof(decimal));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_checkedTerminal_ID = new DataColumn("checkedTerminal_ID" , typeof(string));
			DataColumn col_approvedTerminal_ID = new DataColumn("approvedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_SIP_ID,col_payItem_ID,col_lineNo,col_payItem_Code,col_payItem_Title,col_payItem_Class_ID,col_payItem_Type_ID,col_inputMode,col_isEarning,col_pay_Period,col_paymentMethod_ID,col_amount,col_checked_Amount,col_approved_Amount,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_checkedTerminal_ID,col_approvedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payTxSIPRawData_PaySlipItems datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payTxSIPRawData_PaySlipItems object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payTxSIPRawData_PaySlipItems user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["SIP_ID"] = user.SIP_ID;
			drow["payItem_ID"] = user.payItem_ID;
			drow["lineNo"] = user.lineNo;
			drow["payItem_Code"] = user.payItem_Code;
			drow["payItem_Title"] = user.payItem_Title;
			drow["payItem_Class_ID"] = user.payItem_Class_ID;
			drow["payItem_Type_ID"] = user.payItem_Type_ID;
			drow["inputMode"] = user.inputMode;
			drow["isEarning"] = user.isEarning;
			drow["pay_Period"] = user.pay_Period;
			drow["paymentMethod_ID"] = user.paymentMethod_ID;
			drow["amount"] = user.amount;
			drow["checked_Amount"] = user.checked_Amount;
			drow["approved_Amount"] = user.approved_Amount;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["checkedTerminal_ID"] = user.checkedTerminal_ID;
			drow["approvedTerminal_ID"] = user.approvedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
