using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class vw_searchBpsChequeDepositAndReIssue {
		#region Fields
		private string chequeRegister_ID;
		private DateTime dateDeposit;
		private DateTime dateReIssued;
		private string bankName;
		private string supplierName;
		private string accountNumber;
		private string chequeNumber;
		private decimal chequeAmount;
		private string statusName;
		private bool isDepositted;
		private bool isReIssued;
		private bool isReconcilied;
		private string customerName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the vw_searchBpsChequeDepositAndReIssue class.
		/// </summary>
		public vw_searchBpsChequeDepositAndReIssue() {
		}
		
		/// <summary>
		/// Initializes a new instance of the vw_searchBpsChequeDepositAndReIssue class.
		/// </summary>
		public vw_searchBpsChequeDepositAndReIssue(string chequeRegister_ID, DateTime dateDeposit, DateTime dateReIssued, string bankName, string supplierName, string accountNumber, string chequeNumber, decimal chequeAmount, string statusName, bool isDepositted, bool isReIssued, bool isReconcilied, string customerName) {
			this.chequeRegister_ID = chequeRegister_ID;
			this.dateDeposit = dateDeposit;
			this.dateReIssued = dateReIssued;
			this.bankName = bankName;
			this.supplierName = supplierName;
			this.accountNumber = accountNumber;
			this.chequeNumber = chequeNumber;
			this.chequeAmount = chequeAmount;
			this.statusName = statusName;
			this.isDepositted = isDepositted;
			this.isReIssued = isReIssued;
			this.isReconcilied = isReconcilied;
			this.customerName = customerName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateDeposit value.
		/// </summary>
		public DateTime DateDeposit {
			get { return dateDeposit; }
			set { dateDeposit = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateReIssued value.
		/// </summary>
		public DateTime DateReIssued {
			get { return dateReIssued; }
			set { dateReIssued = value; }
		}
		
		/// <summary>
		/// Gets or sets the BankName value.
		/// </summary>
		public string BankName {
			get { return bankName; }
			set { bankName = value; }
		}
		
		/// <summary>
		/// Gets or sets the SupplierName value.
		/// </summary>
		public string SupplierName {
			get { return supplierName; }
			set { supplierName = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountNumber value.
		/// </summary>
		public string AccountNumber {
			get { return accountNumber; }
			set { accountNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeNumber value.
		/// </summary>
		public string ChequeNumber {
			get { return chequeNumber; }
			set { chequeNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeAmount value.
		/// </summary>
		public decimal ChequeAmount {
			get { return chequeAmount; }
			set { chequeAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatusName value.
		/// </summary>
		public string StatusName {
			get { return statusName; }
			set { statusName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDepositted value.
		/// </summary>
		public bool IsDepositted {
			get { return isDepositted; }
			set { isDepositted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReIssued value.
		/// </summary>
		public bool IsReIssued {
			get { return isReIssued; }
			set { isReIssued = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReconcilied value.
		/// </summary>
		public bool IsReconcilied {
			get { return isReconcilied; }
			set { isReconcilied = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerName value.
		/// </summary>
		public string CustomerName {
			get { return customerName; }
			set { customerName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the vw_searchBpsChequeDepositAndReIssue table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_searchBpsChequeDepositAndReIssueInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateDeposit", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateReIssued", SqlDbType.DateTime,8);
			scom.Parameters.Add("@bankName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@supplierName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@statusName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isDepositted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReIssued", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReconcilied", SqlDbType.Bit,1);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@dateDeposit"].Value = dateDeposit;
			scom.Parameters["@dateReIssued"].Value = dateReIssued;
			scom.Parameters["@bankName"].Value = bankName;
			scom.Parameters["@supplierName"].Value = supplierName;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@statusName"].Value = statusName;
			scom.Parameters["@isDepositted"].Value = isDepositted;
			scom.Parameters["@isReIssued"].Value = isReIssued;
			scom.Parameters["@isReconcilied"].Value = isReconcilied;
			scom.Parameters["@customerName"].Value = customerName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the vw_searchBpsChequeDepositAndReIssue table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_searchBpsChequeDepositAndReIssueUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateDeposit", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateReIssued", SqlDbType.DateTime,8);
			scom.Parameters.Add("@bankName", SqlDbType.VarChar,100);
			scom.Parameters.Add("@supplierName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@accountNumber", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@statusName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isDepositted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReIssued", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReconcilied", SqlDbType.Bit,1);
			scom.Parameters.Add("@customerName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@dateDeposit"].Value = dateDeposit;
			scom.Parameters["@dateReIssued"].Value = dateReIssued;
			scom.Parameters["@bankName"].Value = bankName;
			scom.Parameters["@supplierName"].Value = supplierName;
			scom.Parameters["@accountNumber"].Value = accountNumber;
			scom.Parameters["@chequeNumber"].Value = chequeNumber;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
			scom.Parameters["@statusName"].Value = statusName;
			scom.Parameters["@isDepositted"].Value = isDepositted;
			scom.Parameters["@isReIssued"].Value = isReIssued;
			scom.Parameters["@isReconcilied"].Value = isReconcilied;
			scom.Parameters["@customerName"].Value = customerName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the vw_searchBpsChequeDepositAndReIssue table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_searchBpsChequeDepositAndReIssueDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the vw_searchBpsChequeDepositAndReIssue table.
		/// </summary>
		public static vw_searchBpsChequeDepositAndReIssue Select( string companyID , string companyBranchID, string chequeRegister_ID_Incoming){

			vw_searchBpsChequeDepositAndReIssue vw_searchBpsChequeDepositAndReIssueins = new vw_searchBpsChequeDepositAndReIssue();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_searchBpsChequeDepositAndReIssueSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
            scom.Parameters.Add("@CompanyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@BranchID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);

            scom.Parameters["@CompanyID"].Value = companyID;
            scom.Parameters["@BranchID"].Value = companyBranchID;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					vw_searchBpsChequeDepositAndReIssueins = Makevw_searchBpsChequeDepositAndReIssue(dataReader);
				} else {
					vw_searchBpsChequeDepositAndReIssueins = null;
				}
			}
			scon.Close();
			return vw_searchBpsChequeDepositAndReIssueins;
		}
		
		/// <summary>
		/// Selects all records from the vw_searchBpsChequeDepositAndReIssue table.
		/// </summary>
		public static List<vw_searchBpsChequeDepositAndReIssue> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("vw_searchBpsChequeDepositAndReIssueSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<vw_searchBpsChequeDepositAndReIssue> vw_searchBpsChequeDepositAndReIssueList = new List<vw_searchBpsChequeDepositAndReIssue>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					vw_searchBpsChequeDepositAndReIssue vw_searchBpsChequeDepositAndReIssue = Makevw_searchBpsChequeDepositAndReIssue(dataReader);
					vw_searchBpsChequeDepositAndReIssueList.Add(vw_searchBpsChequeDepositAndReIssue);
				}
			}
			scon.Close();
			return vw_searchBpsChequeDepositAndReIssueList;
		}

        /// <summary>
        /// Search all records by Bank Name
        /// </summary>       
        public static List<vw_searchBpsChequeDepositAndReIssue> SelectAllByBankName(string companyID, string companyBranchID, string Value)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchBpsChequeDepositAndReIssueSelectAllByBankName", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
            scom.Parameters.Add("@CompanyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@BranchID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@My_Value", SqlDbType.VarChar, 20);

            scom.Parameters["@CompanyID"].Value = companyID;
            scom.Parameters["@BranchID"].Value = companyBranchID;
            scom.Parameters["@My_Value"].Value = Value;


            List<vw_searchBpsChequeDepositAndReIssue> vw_searchBpsChequeDepositAndReIssueList = new List<vw_searchBpsChequeDepositAndReIssue>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    vw_searchBpsChequeDepositAndReIssue vw_searchBpsChequeDepositAndReIssue = Makevw_searchBpsChequeDepositAndReIssue(dataReader);
                    vw_searchBpsChequeDepositAndReIssueList.Add(vw_searchBpsChequeDepositAndReIssue);
                }
            }
            scon.Close();
            return vw_searchBpsChequeDepositAndReIssueList;
        }

        /// <summary>
        /// Search all records by Account No
        /// </summary>       
        public static List<vw_searchBpsChequeDepositAndReIssue> SelectAllByAccountNo(string companyID, string companyBranchID, string Value)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchBpsChequeDepositAndReIssueSelectAllByAccountNo", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
            scom.Parameters.Add("@CompanyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@BranchID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@My_Value", SqlDbType.VarChar, 20);

            scom.Parameters["@My_Value"].Value = Value;
            scom.Parameters["@CompanyID"].Value = companyID;
            scom.Parameters["@BranchID"].Value = companyBranchID;

            List<vw_searchBpsChequeDepositAndReIssue> vw_searchBpsChequeDepositAndReIssueList = new List<vw_searchBpsChequeDepositAndReIssue>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    vw_searchBpsChequeDepositAndReIssue vw_searchBpsChequeDepositAndReIssue = Makevw_searchBpsChequeDepositAndReIssue(dataReader);
                    vw_searchBpsChequeDepositAndReIssueList.Add(vw_searchBpsChequeDepositAndReIssue);
                }
            }
            scon.Close();
            return vw_searchBpsChequeDepositAndReIssueList;
        }

        /// <summary>
        /// Search all records by Cheque No
        /// </summary>       
        public static List<vw_searchBpsChequeDepositAndReIssue> SelectAllByChequeNo(string Value)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchBpsChequeDepositAndReIssueSelectAllChequeNo", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@My_Value", SqlDbType.VarChar, 20);
            scom.Parameters["@My_Value"].Value = Value;


            List<vw_searchBpsChequeDepositAndReIssue> vw_searchBpsChequeDepositAndReIssueList = new List<vw_searchBpsChequeDepositAndReIssue>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    vw_searchBpsChequeDepositAndReIssue vw_searchBpsChequeDepositAndReIssue = Makevw_searchBpsChequeDepositAndReIssue(dataReader);
                    vw_searchBpsChequeDepositAndReIssueList.Add(vw_searchBpsChequeDepositAndReIssue);
                }
            }
            scon.Close();
            return vw_searchBpsChequeDepositAndReIssueList;
        }
		
		/// <summary>
		/// Creates a new instance of the vw_searchBpsChequeDepositAndReIssue class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static vw_searchBpsChequeDepositAndReIssue Makevw_searchBpsChequeDepositAndReIssue(SqlDataReader dataReader) {
			vw_searchBpsChequeDepositAndReIssue vw_searchBpsChequeDepositAndReIssue = new vw_searchBpsChequeDepositAndReIssue();
			
			if (dataReader.IsDBNull(0) == false) {
				vw_searchBpsChequeDepositAndReIssue.ChequeRegister_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				vw_searchBpsChequeDepositAndReIssue.DateDeposit = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				vw_searchBpsChequeDepositAndReIssue.DateReIssued = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				vw_searchBpsChequeDepositAndReIssue.BankName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				vw_searchBpsChequeDepositAndReIssue.SupplierName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				vw_searchBpsChequeDepositAndReIssue.AccountNumber = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				vw_searchBpsChequeDepositAndReIssue.ChequeNumber = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				vw_searchBpsChequeDepositAndReIssue.ChequeAmount = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				vw_searchBpsChequeDepositAndReIssue.StatusName = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				vw_searchBpsChequeDepositAndReIssue.IsDepositted = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				vw_searchBpsChequeDepositAndReIssue.IsReIssued = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				vw_searchBpsChequeDepositAndReIssue.IsReconcilied = dataReader.GetBoolean(11);
			}
            try
            {
                if (dataReader.IsDBNull(12) == false)
                {
                    vw_searchBpsChequeDepositAndReIssue.CustomerName = dataReader.GetString(12);
                }
            }
            catch (Exception)
            { }

			return vw_searchBpsChequeDepositAndReIssue;
		}
		/// <summary>
		/// This makes vw_searchBpsChequeDepositAndReIssue datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new vw_searchBpsChequeDepositAndReIssue object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( vw_searchBpsChequeDepositAndReIssue  vw_searchBpsChequeDepositAndReIssue   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_dateDeposit = new DataColumn("dateDeposit" , typeof(DateTime));
			DataColumn col_dateReIssued = new DataColumn("dateReIssued" , typeof(DateTime));
			DataColumn col_bankName = new DataColumn("bankName" , typeof(string));
			DataColumn col_supplierName = new DataColumn("supplierName" , typeof(string));
			DataColumn col_accountNumber = new DataColumn("accountNumber" , typeof(string));
			DataColumn col_chequeNumber = new DataColumn("chequeNumber" , typeof(string));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
			DataColumn col_statusName = new DataColumn("statusName" , typeof(string));
			DataColumn col_isDepositted = new DataColumn("isDepositted" , typeof(bool));
			DataColumn col_isReIssued = new DataColumn("isReIssued" , typeof(bool));
			DataColumn col_isReconcilied = new DataColumn("isReconcilied" , typeof(bool));
			DataColumn col_customerName = new DataColumn("customerName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_chequeRegister_ID,col_dateDeposit,col_dateReIssued,col_bankName,col_supplierName,col_accountNumber,col_chequeNumber,col_chequeAmount,col_statusName,col_isDepositted,col_isReIssued,col_isReconcilied,col_customerName,});		return dt;
		}
		/// <summary>
		/// This fills vw_searchBpsChequeDepositAndReIssue datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new vw_searchBpsChequeDepositAndReIssue object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, vw_searchBpsChequeDepositAndReIssue user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["dateDeposit"] = user.dateDeposit;
			drow["dateReIssued"] = user.dateReIssued;
			drow["bankName"] = user.bankName;
			drow["supplierName"] = user.supplierName;
			drow["accountNumber"] = user.accountNumber;
			drow["chequeNumber"] = user.chequeNumber;
			drow["chequeAmount"] = user.chequeAmount;
			drow["statusName"] = user.statusName;
			drow["isDepositted"] = user.isDepositted;
			drow["isReIssued"] = user.isReIssued;
			drow["isReconcilied"] = user.isReconcilied;
			drow["customerName"] = user.customerName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
