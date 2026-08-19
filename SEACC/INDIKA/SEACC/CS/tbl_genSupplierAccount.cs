using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genSupplierAccount {
		#region Fields
		private string supplier_ID;
		private string accountNumber;
		private string bank_ID;
		private string branch_ID;
		private decimal balanceAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genSupplierAccount class.
		/// </summary>
		public tbl_genSupplierAccount() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genSupplierAccount class.
		/// </summary>
		public tbl_genSupplierAccount(string supplier_ID, string accountNumber, string bank_ID, string branch_ID, decimal balanceAmount) {
			this.supplier_ID = supplier_ID;
			this.accountNumber = accountNumber;
			this.bank_ID = bank_ID;
			this.branch_ID = branch_ID;
			this.balanceAmount = balanceAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genSupplierAccount table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@balanceAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@balanceAmount"].Value = balanceAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genSupplierAccount table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@balanceAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@balanceAmount"].Value = balanceAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genSupplierAccount table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scom.Parameters["@accountNumber"].Value = accountNumber;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountDeleteAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;

			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountDeleteAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;			
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genSupplierAccount table.
		/// </summary>
		public static tbl_genSupplierAccount Select(string supplier_ID_Incoming, string accountNumber_Incoming){

			tbl_genSupplierAccount tbl_genSupplierAccountins = new tbl_genSupplierAccount();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID_Incoming;
			scom.Parameters["@accountNumber"].Value = accountNumber_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genSupplierAccountins = Maketbl_genSupplierAccount(dataReader);
				} else {
					tbl_genSupplierAccountins = null;
				}
			}
			scon.Close();
			return tbl_genSupplierAccountins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierAccount table.
		/// </summary>
		public static List<tbl_genSupplierAccount> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genSupplierAccount> tbl_genSupplierAccountList = new List<tbl_genSupplierAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierAccount tbl_genSupplierAccount = Maketbl_genSupplierAccount(dataReader);
					tbl_genSupplierAccountList.Add(tbl_genSupplierAccount);
				}
			}
			scon.Close();
			return tbl_genSupplierAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierAccount table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierAccount> SelectAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountSelectAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
				List<tbl_genSupplierAccount> tbl_genSupplierAccountList = new List<tbl_genSupplierAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierAccount tbl_genSupplierAccount = Maketbl_genSupplierAccount(dataReader);
					tbl_genSupplierAccountList.Add(tbl_genSupplierAccount);
				}
			}
			scon.Close();
			return tbl_genSupplierAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierAccount table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierAccount> SelectAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountSelectAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
				List<tbl_genSupplierAccount> tbl_genSupplierAccountList = new List<tbl_genSupplierAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierAccount tbl_genSupplierAccount = Maketbl_genSupplierAccount(dataReader);
					tbl_genSupplierAccountList.Add(tbl_genSupplierAccount);
				}
			}
			scon.Close();
			return tbl_genSupplierAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genSupplierAccount table by a foreign key.
		/// </summary>
		public static List<tbl_genSupplierAccount> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genSupplierAccountSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_genSupplierAccount> tbl_genSupplierAccountList = new List<tbl_genSupplierAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genSupplierAccount tbl_genSupplierAccount = Maketbl_genSupplierAccount(dataReader);
					tbl_genSupplierAccountList.Add(tbl_genSupplierAccount);
				}
			}
			scon.Close();
			return tbl_genSupplierAccountList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genSupplierAccount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genSupplierAccount Maketbl_genSupplierAccount(SqlDataReader dataReader) {
			tbl_genSupplierAccount tbl_genSupplierAccount = new tbl_genSupplierAccount();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genSupplierAccount.Supplier_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genSupplierAccount.AccountNumber = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genSupplierAccount.Bank_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genSupplierAccount.Branch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genSupplierAccount.BalanceAmount = (decimal)dataReader.GetDecimal(4);
			}

			return tbl_genSupplierAccount;
		}
		/// <summary>
		/// This fills tbl_genSupplierAccount datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genSupplierAccount object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genSupplierAccount user) {
		DataRow drow = dt.NewRow();
		
			drow["supplier_ID"] = user.supplier_ID;
			drow["accountNumber"] = user.accountNumber;
			drow["bank_ID"] = user.bank_ID;
			drow["branch_ID"] = user.branch_ID;
			drow["balanceAmount"] = user.balanceAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
