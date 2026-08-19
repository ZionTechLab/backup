using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCompanyAccount {
		#region Fields
		private int companyAccount_ID;
		private string companyID;
		private string accountNumber;
		private string bank_ID;
		private string branch_ID;
		private decimal balanceAmount;
		private string controlAcc;
		private string prefix;
		private int counter;
		private int bankReconcilationCounter;
		private int chequeFormat_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCompanyAccount class.
		/// </summary>
		public tbl_genCompanyAccount() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCompanyAccount class.
		/// </summary>
		public tbl_genCompanyAccount(int companyAccount_ID, string companyID, string accountNumber, string bank_ID, string branch_ID, decimal balanceAmount, string controlAcc, string prefix, int counter, int bankReconcilationCounter, int chequeFormat_ID) {
			this.companyAccount_ID = companyAccount_ID;
			this.companyID = companyID;
			this.accountNumber = accountNumber;
			this.bank_ID = bank_ID;
			this.branch_ID = branch_ID;
			this.balanceAmount = balanceAmount;
			this.controlAcc = controlAcc;
			this.prefix = prefix;
			this.counter = counter;
			this.bankReconcilationCounter = bankReconcilationCounter;
			this.chequeFormat_ID = chequeFormat_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CompanyAccount_ID value.
		/// </summary>
		public int CompanyAccount_ID {
			get { return companyAccount_ID; }
			set { companyAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountNumber value.
		/// </summary>
		public string AccountNumber {
			get { return accountNumber; }
			set { accountNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bank_ID value.
		/// </summary>
		public string Bank_ID {
			get { return bank_ID; }
			set { bank_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Branch_ID value.
		/// </summary>
		public string Branch_ID {
			get { return branch_ID; }
			set { branch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BalanceAmount value.
		/// </summary>
		public decimal BalanceAmount {
			get { return balanceAmount; }
			set { balanceAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ControlAcc value.
		/// </summary>
		public string ControlAcc {
			get { return controlAcc; }
			set { controlAcc = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public int Counter {
			get { return counter; }
			set { counter = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankReconcilationCounter value.
		/// </summary>
		public int BankReconcilationCounter {
			get { return bankReconcilationCounter; }
			set { bankReconcilationCounter = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeFormat_ID value.
		/// </summary>
		public int ChequeFormat_ID {
			get { return chequeFormat_ID; }
			set { chequeFormat_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genCompanyAccount table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@balanceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@controlAcc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@bankReconcilationCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@chequeFormat_ID", SqlDbType.Int,4);
 
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@balanceAmount"].Value = balanceAmount;
			scom.Parameters["@controlAcc"].Value = controlAcc;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@bankReconcilationCounter"].Value = bankReconcilationCounter;
			scom.Parameters["@chequeFormat_ID"].Value = chequeFormat_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCompanyAccount table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@balanceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@controlAcc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,50);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@bankReconcilationCounter", SqlDbType.Int,4);
			scom.Parameters.Add("@chequeFormat_ID", SqlDbType.Int,4);
 
 
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@balanceAmount"].Value = balanceAmount;
			scom.Parameters["@controlAcc"].Value = controlAcc;
			scom.Parameters["@prefix"].Value = prefix;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@bankReconcilationCounter"].Value = bankReconcilationCounter;
			scom.Parameters["@chequeFormat_ID"].Value = chequeFormat_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCompanyAccount table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountDeleteAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountDeleteAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCompanyAccount table.
		/// </summary>
		public static tbl_genCompanyAccount Select(int companyAccount_ID_Incoming){

			tbl_genCompanyAccount tbl_genCompanyAccountins = new tbl_genCompanyAccount();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCompanyAccountins = Maketbl_genCompanyAccount(dataReader);
				} else {
					tbl_genCompanyAccountins = null;
				}
			}
			scon.Close();
			return tbl_genCompanyAccountins;
		}
        public static tbl_genCompanyAccount Select(string accountNumber_Incoming)
        {

            tbl_genCompanyAccount tbl_genCompanyAccountins = new tbl_genCompanyAccount();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_genCompanyAccountSelectByAccountNumber", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@accountNumber", SqlDbType.VarChar, 20);
            scom.Parameters["@accountNumber"].Value = accountNumber_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_genCompanyAccountins = Maketbl_genCompanyAccount(dataReader);
                }
                else
                {
                    tbl_genCompanyAccountins = null;
                }
            }
            scon.Close();
            return tbl_genCompanyAccountins;
        }
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyAccount table.
		/// </summary>
		public static List<tbl_genCompanyAccount> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCompanyAccount> tbl_genCompanyAccountList = new List<tbl_genCompanyAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCompanyAccount tbl_genCompanyAccount = Maketbl_genCompanyAccount(dataReader);
					tbl_genCompanyAccountList.Add(tbl_genCompanyAccount);
				}
			}
			scon.Close();
			return tbl_genCompanyAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyAccount table by a foreign key.
		/// </summary>
		public static List<tbl_genCompanyAccount> SelectAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountSelectAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
				List<tbl_genCompanyAccount> tbl_genCompanyAccountList = new List<tbl_genCompanyAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCompanyAccount tbl_genCompanyAccount = Maketbl_genCompanyAccount(dataReader);
					tbl_genCompanyAccountList.Add(tbl_genCompanyAccount);
				}
			}
			scon.Close();
			return tbl_genCompanyAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyAccount table by a foreign key.
		/// </summary>
		public static List<tbl_genCompanyAccount> SelectAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountSelectAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters["@bank_ID"].Value = bank_ID;
				List<tbl_genCompanyAccount> tbl_genCompanyAccountList = new List<tbl_genCompanyAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCompanyAccount tbl_genCompanyAccount = Maketbl_genCompanyAccount(dataReader);
					tbl_genCompanyAccountList.Add(tbl_genCompanyAccount);
				}
			}
			scon.Close();
			return tbl_genCompanyAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyAccount table by a foreign key.
		/// </summary>
		public static List<tbl_genCompanyAccount> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyAccountSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_genCompanyAccount> tbl_genCompanyAccountList = new List<tbl_genCompanyAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCompanyAccount tbl_genCompanyAccount = Maketbl_genCompanyAccount(dataReader);
					tbl_genCompanyAccountList.Add(tbl_genCompanyAccount);
				}
			}
			scon.Close();
			return tbl_genCompanyAccountList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCompanyAccount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCompanyAccount Maketbl_genCompanyAccount(SqlDataReader dataReader) {
			tbl_genCompanyAccount tbl_genCompanyAccount = new tbl_genCompanyAccount();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCompanyAccount.CompanyAccount_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCompanyAccount.CompanyID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCompanyAccount.AccountNumber = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genCompanyAccount.Bank_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genCompanyAccount.Branch_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genCompanyAccount.BalanceAmount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genCompanyAccount.ControlAcc = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genCompanyAccount.Prefix = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genCompanyAccount.Counter = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genCompanyAccount.BankReconcilationCounter = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genCompanyAccount.ChequeFormat_ID = dataReader.GetInt32(10);
			}

			return tbl_genCompanyAccount;
		}
		/// <summary>
		/// This makes tbl_genCompanyAccount datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCompanyAccount object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCompanyAccount  tbl_genCompanyAccount   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyAccount_ID = new DataColumn("companyAccount_ID" , typeof(int));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_accountNumber = new DataColumn("accountNumber" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_balanceAmount = new DataColumn("balanceAmount" , typeof(decimal));
			DataColumn col_controlAcc = new DataColumn("controlAcc" , typeof(string));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_bankReconcilationCounter = new DataColumn("bankReconcilationCounter" , typeof(int));
			DataColumn col_chequeFormat_ID = new DataColumn("chequeFormat_ID" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_companyAccount_ID,col_companyID,col_accountNumber,col_bank_ID,col_branch_ID,col_balanceAmount,col_controlAcc,col_prefix,col_counter,col_bankReconcilationCounter,col_chequeFormat_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCompanyAccount datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCompanyAccount object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCompanyAccount user) {
		DataRow drow = dt.NewRow();
		
			drow["companyAccount_ID"] = user.companyAccount_ID;
			drow["companyID"] = user.companyID;
			drow["accountNumber"] = user.accountNumber;
			drow["bank_ID"] = user.bank_ID;
			drow["branch_ID"] = user.branch_ID;
			drow["balanceAmount"] = user.balanceAmount;
			drow["controlAcc"] = user.controlAcc;
			drow["prefix"] = user.prefix;
			drow["counter"] = user.counter;
			drow["bankReconcilationCounter"] = user.bankReconcilationCounter;
			drow["chequeFormat_ID"] = user.chequeFormat_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
