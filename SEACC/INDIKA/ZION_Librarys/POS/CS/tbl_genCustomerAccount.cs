using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCustomerAccount {
		#region Fields
		private string customer_ID;
		private string accountNumber;
		private string bank_ID;
		private string branch_ID;
		private decimal deposittedCount;
		private decimal realizedCount;
		private decimal returnedCount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerAccount class.
		/// </summary>
		public tbl_genCustomerAccount() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerAccount class.
		/// </summary>
		public tbl_genCustomerAccount(string customer_ID, string accountNumber, string bank_ID, string branch_ID, decimal deposittedCount, decimal realizedCount, decimal returnedCount) {
			this.customer_ID = customer_ID;
			this.accountNumber = accountNumber;
			this.bank_ID = bank_ID;
			this.branch_ID = branch_ID;
			this.deposittedCount = deposittedCount;
			this.realizedCount = realizedCount;
			this.returnedCount = returnedCount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
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
		/// Gets or sets the DeposittedCount value.
		/// </summary>
		public decimal DeposittedCount {
			get { return deposittedCount; }
			set { deposittedCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the RealizedCount value.
		/// </summary>
		public decimal RealizedCount {
			get { return realizedCount; }
			set { realizedCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReturnedCount value.
		/// </summary>
		public decimal ReturnedCount {
			get { return returnedCount; }
			set { returnedCount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genCustomerAccount table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deposittedCount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@realizedCount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@returnedCount", SqlDbType.Decimal,9);
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@deposittedCount"].Value = deposittedCount;
			scom.Parameters["@realizedCount"].Value = realizedCount;
			scom.Parameters["@returnedCount"].Value = returnedCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCustomerAccount table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deposittedCount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@realizedCount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@returnedCount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@deposittedCount"].Value = deposittedCount;
			scom.Parameters["@realizedCount"].Value = realizedCount;
			scom.Parameters["@returnedCount"].Value = returnedCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCustomerAccount table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scom.Parameters["@accountNumber"].Value = accountNumber;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;

 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountDeleteAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerAccount table by a foreign key.
		/// </summary>
		public static void DeleteAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountDeleteAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCustomerAccount table.
		/// </summary>
		public static tbl_genCustomerAccount Select(string customer_ID_Incoming, string accountNumber_Incoming){

			tbl_genCustomerAccount tbl_genCustomerAccountins = new tbl_genCustomerAccount();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			scom.Parameters["@accountNumber"].Value = accountNumber_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCustomerAccountins = Maketbl_genCustomerAccount(dataReader);
				} else {
					tbl_genCustomerAccountins = null;
				}
			}
			scon.Close();
			return tbl_genCustomerAccountins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerAccount table.
		/// </summary>
		public static List<tbl_genCustomerAccount> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCustomerAccount> tbl_genCustomerAccountList = new List<tbl_genCustomerAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerAccount tbl_genCustomerAccount = Maketbl_genCustomerAccount(dataReader);
					tbl_genCustomerAccountList.Add(tbl_genCustomerAccount);
				}
			}
			scon.Close();
			return tbl_genCustomerAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerAccount table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerAccount> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_genCustomerAccount> tbl_genCustomerAccountList = new List<tbl_genCustomerAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerAccount tbl_genCustomerAccount = Maketbl_genCustomerAccount(dataReader);
					tbl_genCustomerAccountList.Add(tbl_genCustomerAccount);
				}
			}
			scon.Close();
			return tbl_genCustomerAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerAccount table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerAccount> SelectAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountSelectAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,10);
			scom.Parameters["@bank_ID"].Value = bank_ID;
				List<tbl_genCustomerAccount> tbl_genCustomerAccountList = new List<tbl_genCustomerAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerAccount tbl_genCustomerAccount = Maketbl_genCustomerAccount(dataReader);
					tbl_genCustomerAccountList.Add(tbl_genCustomerAccount);
				}
			}
			scon.Close();
			return tbl_genCustomerAccountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerAccount table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerAccount> SelectAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerAccountSelectAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
				List<tbl_genCustomerAccount> tbl_genCustomerAccountList = new List<tbl_genCustomerAccount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerAccount tbl_genCustomerAccount = Maketbl_genCustomerAccount(dataReader);
					tbl_genCustomerAccountList.Add(tbl_genCustomerAccount);
				}
			}
			scon.Close();
			return tbl_genCustomerAccountList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCustomerAccount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCustomerAccount Maketbl_genCustomerAccount(SqlDataReader dataReader) {
			tbl_genCustomerAccount tbl_genCustomerAccount = new tbl_genCustomerAccount();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCustomerAccount.Customer_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCustomerAccount.AccountNumber = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCustomerAccount.Bank_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genCustomerAccount.Branch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genCustomerAccount.DeposittedCount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genCustomerAccount.RealizedCount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genCustomerAccount.ReturnedCount = dataReader.GetDecimal(6);
			}

			return tbl_genCustomerAccount;
		}
		/// <summary>
		/// This makes tbl_genCustomerAccount datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCustomerAccount object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCustomerAccount  tbl_genCustomerAccount   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_accountNumber = new DataColumn("accountNumber" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_deposittedCount = new DataColumn("deposittedCount" , typeof(decimal));
			DataColumn col_realizedCount = new DataColumn("realizedCount" , typeof(decimal));
			DataColumn col_returnedCount = new DataColumn("returnedCount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_customer_ID,col_accountNumber,col_bank_ID,col_branch_ID,col_deposittedCount,col_realizedCount,col_returnedCount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCustomerAccount datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCustomerAccount object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCustomerAccount user) {
		DataRow drow = dt.NewRow();
		
			drow["customer_ID"] = user.customer_ID;
			drow["accountNumber"] = user.accountNumber;
			drow["bank_ID"] = user.bank_ID;
			drow["branch_ID"] = user.branch_ID;
			drow["deposittedCount"] = user.deposittedCount;
			drow["realizedCount"] = user.realizedCount;
			drow["returnedCount"] = user.returnedCount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
