using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class vw_searchChequeRegister
    {
        #region Fields
        private string chequeRegister_ID;
        private string accountNumber;
        private string chequeNumber;
        private decimal chequeAmount;
        private string customer_ID;
        private string customerName;
        private string chequeStatus_ID;
        private string statusName;
        private DateTime dateCheque;
        private string invoice_ID;
        private string receipt_ID;
        private string bankName;
        private bool isDeleted;
        private bool isSetteled;
        private bool isLocked;
        private bool isDepositted;
        private bool isReIssued;
        private bool isReconcilied;
        private bool isReturned;
        private bool isReturnedToSender;
        private int depositCount;
        private DateTime dateDeposited;
        private DateTime dateReconcilied;
        private DateTime dateReIssued;
        private DateTime dateReturnedToSender;
        private decimal paneltyAmount;
        private string accountReceipt_ID;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the vw_searchChequeRegister class.
        /// </summary>
        public vw_searchChequeRegister()
        {
        }

        /// <summary>
        /// Initializes a new instance of the vw_searchChequeRegister class.
        /// </summary>
        public vw_searchChequeRegister(string chequeRegister_ID, string accountNumber, string chequeNumber, decimal chequeAmount, string customer_ID, string customerName, string chequeStatus_ID, string statusName, DateTime dateCheque, string invoice_ID, string receipt_ID, string bankName, bool isDeleted, bool isSetteled, bool isLocked, bool isDepositted, bool isReIssued, bool isReconcilied, bool isReturned, bool isReturnedToSender, int depositCount, DateTime dateDeposited, DateTime dateReconcilied, DateTime dateReIssued, DateTime dateReturnedToSender, decimal paneltyAmount, string accountReceipt_ID)
        {
            this.chequeRegister_ID = chequeRegister_ID;
            this.accountNumber = accountNumber;
            this.chequeNumber = chequeNumber;
            this.chequeAmount = chequeAmount;
            this.customer_ID = customer_ID;
            this.customerName = customerName;
            this.chequeStatus_ID = chequeStatus_ID;
            this.statusName = statusName;
            this.dateCheque = dateCheque;
            this.invoice_ID = invoice_ID;
            this.receipt_ID = receipt_ID;
            this.bankName = bankName;
            this.isDeleted = isDeleted;
            this.isSetteled = isSetteled;
            this.isLocked = isLocked;
            this.isDepositted = isDepositted;
            this.isReIssued = isReIssued;
            this.isReconcilied = isReconcilied;
            this.isReturned = isReturned;
            this.isReturnedToSender = isReturnedToSender;
            this.depositCount = depositCount;
            this.dateDeposited = dateDeposited;
            this.dateReconcilied = dateReconcilied;
            this.dateReIssued = dateReIssued;
            this.dateReturnedToSender = dateReturnedToSender;
            this.paneltyAmount = paneltyAmount;
            this.accountReceipt_ID = accountReceipt_ID;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the ChequeRegister_ID value.
        /// </summary>
        public string ChequeRegister_ID
        {
            get { return chequeRegister_ID; }
            set { chequeRegister_ID = value; }
        }

        /// <summary>
        /// Gets or sets the AccountNumber value.
        /// </summary>
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        /// <summary>
        /// Gets or sets the ChequeNumber value.
        /// </summary>
        public string ChequeNumber
        {
            get { return chequeNumber; }
            set { chequeNumber = value; }
        }

        /// <summary>
        /// Gets or sets the ChequeAmount value.
        /// </summary>
        public decimal ChequeAmount
        {
            get { return chequeAmount; }
            set { chequeAmount = value; }
        }

        /// <summary>
        /// Gets or sets the Customer_ID value.
        /// </summary>
        public string Customer_ID
        {
            get { return customer_ID; }
            set { customer_ID = value; }
        }

        /// <summary>
        /// Gets or sets the CustomerName value.
        /// </summary>
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        /// <summary>
        /// Gets or sets the ChequeStatus_ID value.
        /// </summary>
        public string ChequeStatus_ID
        {
            get { return chequeStatus_ID; }
            set { chequeStatus_ID = value; }
        }

        /// <summary>
        /// Gets or sets the StatusName value.
        /// </summary>
        public string StatusName
        {
            get { return statusName; }
            set { statusName = value; }
        }

        /// <summary>
        /// Gets or sets the DateCheque value.
        /// </summary>
        public DateTime DateCheque
        {
            get { return dateCheque; }
            set { dateCheque = value; }
        }

        /// <summary>
        /// Gets or sets the Invoice_ID value.
        /// </summary>
        public string Invoice_ID
        {
            get { return invoice_ID; }
            set { invoice_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Receipt_ID value.
        /// </summary>
        public string Receipt_ID
        {
            get { return receipt_ID; }
            set { receipt_ID = value; }
        }

        /// <summary>
        /// Gets or sets the BankName value.
        /// </summary>
        public string BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }

        /// <summary>
        /// Gets or sets the IsDeleted value.
        /// </summary>
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        /// <summary>
        /// Gets or sets the IsSetteled value.
        /// </summary>
        public bool IsSetteled
        {
            get { return isSetteled; }
            set { isSetteled = value; }
        }

        /// <summary>
        /// Gets or sets the IsLocked value.
        /// </summary>
        public bool IsLocked
        {
            get { return isLocked; }
            set { isLocked = value; }
        }

        /// <summary>
        /// Gets or sets the IsDepositted value.
        /// </summary>
        public bool IsDepositted
        {
            get { return isDepositted; }
            set { isDepositted = value; }
        }

        /// <summary>
        /// Gets or sets the IsReIssued value.
        /// </summary>
        public bool IsReIssued
        {
            get { return isReIssued; }
            set { isReIssued = value; }
        }

        /// <summary>
        /// Gets or sets the IsReconcilied value.
        /// </summary>
        public bool IsReconcilied
        {
            get { return isReconcilied; }
            set { isReconcilied = value; }
        }

        /// <summary>
        /// Gets or sets the IsReturned value.
        /// </summary>
        public bool IsReturned
        {
            get { return isReturned; }
            set { isReturned = value; }
        }

        /// <summary>
        /// Gets or sets the IsReturnedToSender value.
        /// </summary>
        public bool IsReturnedToSender
        {
            get { return isReturnedToSender; }
            set { isReturnedToSender = value; }
        }

        /// <summary>
        /// Gets or sets the DepositCount value.
        /// </summary>
        public int DepositCount
        {
            get { return depositCount; }
            set { depositCount = value; }
        }

        /// <summary>
        /// Gets or sets the DateDeposited value.
        /// </summary>
        public DateTime DateDeposited
        {
            get { return dateDeposited; }
            set { dateDeposited = value; }
        }

        /// <summary>
        /// Gets or sets the DateReconcilied value.
        /// </summary>
        public DateTime DateReconcilied
        {
            get { return dateReconcilied; }
            set { dateReconcilied = value; }
        }

        /// <summary>
        /// Gets or sets the DateReIssued value.
        /// </summary>
        public DateTime DateReIssued
        {
            get { return dateReIssued; }
            set { dateReIssued = value; }
        }

        /// <summary>
        /// Gets or sets the DateReturnedToSender value.
        /// </summary>
        public DateTime DateReturnedToSender
        {
            get { return dateReturnedToSender; }
            set { dateReturnedToSender = value; }
        }

        /// <summary>
        /// Gets or sets the PaneltyAmount value.
        /// </summary>
        public decimal PaneltyAmount
        {
            get { return paneltyAmount; }
            set { paneltyAmount = value; }
        }

        /// <summary>
        /// Gets or sets the AccountReceipt_ID value.
        /// </summary>
        public string AccountReceipt_ID
        {
            get { return accountReceipt_ID; }
            set { accountReceipt_ID = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves a record to the vw_searchChequeRegister table.
        /// </summary>
        public void Insert()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterInsert", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@accountNumber", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customerName", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@statusName", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@dateCheque", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@bankName", SqlDbType.VarChar, 100);
            scom.Parameters.Add("@isDeleted", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isSetteled", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isLocked", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isDepositted", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isReIssued", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isReconcilied", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isReturned", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isReturnedToSender", SqlDbType.Bit, 1);
            scom.Parameters.Add("@depositCount", SqlDbType.Int, 4);
            scom.Parameters.Add("@dateDeposited", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateReconcilied", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateReIssued", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateReturnedToSender", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@paneltyAmount", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar, 20);

            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            scom.Parameters["@accountNumber"].Value = accountNumber;
            scom.Parameters["@chequeNumber"].Value = chequeNumber;
            scom.Parameters["@chequeAmount"].Value = chequeAmount;
            scom.Parameters["@customer_ID"].Value = customer_ID;
            scom.Parameters["@customerName"].Value = customerName;
            scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
            scom.Parameters["@statusName"].Value = statusName;
            scom.Parameters["@dateCheque"].Value = dateCheque;
            scom.Parameters["@invoice_ID"].Value = invoice_ID;
            scom.Parameters["@receipt_ID"].Value = receipt_ID;
            scom.Parameters["@bankName"].Value = bankName;
            scom.Parameters["@isDeleted"].Value = isDeleted;
            scom.Parameters["@isSetteled"].Value = isSetteled;
            scom.Parameters["@isLocked"].Value = isLocked;
            scom.Parameters["@isDepositted"].Value = isDepositted;
            scom.Parameters["@isReIssued"].Value = isReIssued;
            scom.Parameters["@isReconcilied"].Value = isReconcilied;
            scom.Parameters["@isReturned"].Value = isReturned;
            scom.Parameters["@isReturnedToSender"].Value = isReturnedToSender;
            scom.Parameters["@depositCount"].Value = depositCount;
            scom.Parameters["@dateDeposited"].Value = dateDeposited;
            scom.Parameters["@dateReconcilied"].Value = dateReconcilied;
            scom.Parameters["@dateReIssued"].Value = dateReIssued;
            scom.Parameters["@dateReturnedToSender"].Value = dateReturnedToSender;
            scom.Parameters["@paneltyAmount"].Value = paneltyAmount;
            scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Updates a record in the vw_searchChequeRegister table.
        /// </summary>
        public void Update()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterUpdate", scon);
            scom.CommandType = CommandType.StoredProcedure;


            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@accountNumber", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeNumber", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customerName", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@chequeStatus_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@statusName", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@dateCheque", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@bankName", SqlDbType.VarChar, 100);
            scom.Parameters.Add("@isDeleted", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isSetteled", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isLocked", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isDepositted", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isReIssued", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isReconcilied", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isReturned", SqlDbType.Bit, 1);
            scom.Parameters.Add("@isReturnedToSender", SqlDbType.Bit, 1);
            scom.Parameters.Add("@depositCount", SqlDbType.Int, 4);
            scom.Parameters.Add("@dateDeposited", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateReconcilied", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateReIssued", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@dateReturnedToSender", SqlDbType.DateTime, 8);
            scom.Parameters.Add("@paneltyAmount", SqlDbType.Decimal, 9);
            scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar, 20);

            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
            scom.Parameters["@accountNumber"].Value = accountNumber;
            scom.Parameters["@chequeNumber"].Value = chequeNumber;
            scom.Parameters["@chequeAmount"].Value = chequeAmount;
            scom.Parameters["@customer_ID"].Value = customer_ID;
            scom.Parameters["@customerName"].Value = customerName;
            scom.Parameters["@chequeStatus_ID"].Value = chequeStatus_ID;
            scom.Parameters["@statusName"].Value = statusName;
            scom.Parameters["@dateCheque"].Value = dateCheque;
            scom.Parameters["@invoice_ID"].Value = invoice_ID;
            scom.Parameters["@receipt_ID"].Value = receipt_ID;
            scom.Parameters["@bankName"].Value = bankName;
            scom.Parameters["@isDeleted"].Value = isDeleted;
            scom.Parameters["@isSetteled"].Value = isSetteled;
            scom.Parameters["@isLocked"].Value = isLocked;
            scom.Parameters["@isDepositted"].Value = isDepositted;
            scom.Parameters["@isReIssued"].Value = isReIssued;
            scom.Parameters["@isReconcilied"].Value = isReconcilied;
            scom.Parameters["@isReturned"].Value = isReturned;
            scom.Parameters["@isReturnedToSender"].Value = isReturnedToSender;
            scom.Parameters["@depositCount"].Value = depositCount;
            scom.Parameters["@dateDeposited"].Value = dateDeposited;
            scom.Parameters["@dateReconcilied"].Value = dateReconcilied;
            scom.Parameters["@dateReIssued"].Value = dateReIssued;
            scom.Parameters["@dateReturnedToSender"].Value = dateReturnedToSender;
            scom.Parameters["@paneltyAmount"].Value = paneltyAmount;
            scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Deletes a record from the vw_searchChequeRegister table by its primary key.
        /// </summary>
        public void Delete()
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterDelete", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;


            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the vw_searchChequeRegister table by a foreign key.
        /// </summary>
        public static void DeleteAllByAccountReceipt_ID(string accountReceipt_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterDeleteAllByAccountReceipt_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the vw_searchChequeRegister table by a foreign key.
        /// </summary>
        public static void DeleteAllByReceipt_ID(string receipt_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterDeleteAllByReceipt_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@receipt_ID"].Value = receipt_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects all records from the vw_searchChequeRegister table by a foreign key.
        /// </summary>
        public static void DeleteAllByCustomer_ID(string customer_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterDeleteAllByCustomer_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@customer_ID"].Value = customer_ID;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }

        /// <summary>
        /// Selects a single record from the vw_searchChequeRegister table.
        /// </summary>
        public static vw_searchChequeRegister Select(string CompanyID, string BranchID, string chequeRegister_ID_Incoming)
        {

            vw_searchChequeRegister vw_searchChequeRegisterins = new vw_searchChequeRegister();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterSelect", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
            scom.Parameters.Add("@CompanyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@BranchID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar, 20);

            scom.Parameters["@CompanyID"].Value = CompanyID;
            scom.Parameters["@BranchID"].Value = BranchID;
            scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    vw_searchChequeRegisterins = Makevw_searchChequeRegister(dataReader);
                }
                else
                {
                    vw_searchChequeRegisterins = null;
                }
            }
            scon.Close();
            return vw_searchChequeRegisterins;
        }

        /// <summary>
        /// Selects all records from the vw_searchChequeRegister table.
        /// </summary>
        public static List<vw_searchChequeRegister> SelectAll(string CompanyID, string BranchID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterSelectAll", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
            scom.Parameters.Add("@CompanyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@BranchID", SqlDbType.VarChar, 20);

            scom.Parameters["@CompanyID"].Value = CompanyID;
            scom.Parameters["@BranchID"].Value = BranchID;

            List<vw_searchChequeRegister> vw_searchChequeRegisterList = new List<vw_searchChequeRegister>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    vw_searchChequeRegister vw_searchChequeRegister = Makevw_searchChequeRegister(dataReader);
                    vw_searchChequeRegisterList.Add(vw_searchChequeRegister);
                }
            }
            scon.Close();
            return vw_searchChequeRegisterList;
        }

        /// <summary>
        /// Selects all records from the vw_searchChequeRegister table by a foreign key.
        /// </summary>

        public static List<vw_searchChequeRegister> SelectAllByAccountReceipt_ID(string CompanyID, string BranchID, string accountReceipt_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterSelectAllByAccountReceipt_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
            scom.Parameters.Add("@CompanyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@BranchID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar, 20);

            scom.Parameters["@CompanyID"].Value = CompanyID;
            scom.Parameters["@BranchID"].Value = BranchID;
            scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
            List<vw_searchChequeRegister> vw_searchChequeRegisterList = new List<vw_searchChequeRegister>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    vw_searchChequeRegister vw_searchChequeRegister = Makevw_searchChequeRegister(dataReader);
                    vw_searchChequeRegisterList.Add(vw_searchChequeRegister);
                }
            }
            scon.Close();
            return vw_searchChequeRegisterList;
        }

        /// <summary>
        /// Selects all records from the vw_searchChequeRegister table by a foreign key.
        /// </summary>
        public static List<vw_searchChequeRegister> SelectAllByReceipt_ID(string CompanyID, string BranchID, string receipt_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterSelectAllByReceipt_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
            scom.Parameters.Add("@CompanyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@BranchID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar, 20);

            scom.Parameters["@CompanyID"].Value = CompanyID;
            scom.Parameters["@BranchID"].Value = BranchID;
            scom.Parameters["@receipt_ID"].Value = receipt_ID;
            List<vw_searchChequeRegister> vw_searchChequeRegisterList = new List<vw_searchChequeRegister>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    vw_searchChequeRegister vw_searchChequeRegister = Makevw_searchChequeRegister(dataReader);
                    vw_searchChequeRegisterList.Add(vw_searchChequeRegister);
                }
            }
            scon.Close();
            return vw_searchChequeRegisterList;
        }

        /// <summary>
        /// Selects all records from the vw_searchChequeRegister table by a foreign key.
        /// </summary>
        public static List<vw_searchChequeRegister> SelectAllByCustomer_ID(string CompanyID, string BranchID, string customer_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("vw_searchChequeRegisterSelectAllByCustomer_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
            scom.Parameters.Add("@CompanyID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@BranchID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@customer_ID", SqlDbType.VarChar, 20);

            scom.Parameters["@CompanyID"].Value = CompanyID;
            scom.Parameters["@BranchID"].Value = BranchID;
            scom.Parameters["@customer_ID"].Value = customer_ID;
            List<vw_searchChequeRegister> vw_searchChequeRegisterList = new List<vw_searchChequeRegister>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    vw_searchChequeRegister vw_searchChequeRegister = Makevw_searchChequeRegister(dataReader);
                    vw_searchChequeRegisterList.Add(vw_searchChequeRegister);
                }
            }
            scon.Close();
            return vw_searchChequeRegisterList;
        }

        /// <summary>
        /// Creates a new instance of the vw_searchChequeRegister class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static vw_searchChequeRegister Makevw_searchChequeRegister(SqlDataReader dataReader)
        {
            vw_searchChequeRegister vw_searchChequeRegister = new vw_searchChequeRegister();

            if (dataReader.IsDBNull(0) == false)
            {
                vw_searchChequeRegister.ChequeRegister_ID = dataReader.GetString(0);
            }
            if (dataReader.IsDBNull(1) == false)
            {
                vw_searchChequeRegister.AccountNumber = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                vw_searchChequeRegister.ChequeNumber = dataReader.GetString(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                vw_searchChequeRegister.ChequeAmount = dataReader.GetDecimal(3);
            }
            if (dataReader.IsDBNull(4) == false)
            {
                vw_searchChequeRegister.Customer_ID = dataReader.GetString(4);
            }
            if (dataReader.IsDBNull(5) == false)
            {
                vw_searchChequeRegister.CustomerName = dataReader.GetString(5);
            }
            if (dataReader.IsDBNull(6) == false)
            {
                vw_searchChequeRegister.ChequeStatus_ID = dataReader.GetString(6);
            }
            if (dataReader.IsDBNull(7) == false)
            {
                vw_searchChequeRegister.StatusName = dataReader.GetString(7);
            }
            if (dataReader.IsDBNull(8) == false)
            {
                vw_searchChequeRegister.DateCheque = dataReader.GetDateTime(8);
            }
            if (dataReader.IsDBNull(9) == false)
            {
                vw_searchChequeRegister.Invoice_ID = dataReader.GetString(9);
            }
            if (dataReader.IsDBNull(10) == false)
            {
                vw_searchChequeRegister.Receipt_ID = dataReader.GetString(10);
            }
            if (dataReader.IsDBNull(11) == false)
            {
                vw_searchChequeRegister.BankName = dataReader.GetString(11);
            }
            if (dataReader.IsDBNull(12) == false)
            {
                vw_searchChequeRegister.IsDeleted = dataReader.GetBoolean(12);
            }
            if (dataReader.IsDBNull(13) == false)
            {
                vw_searchChequeRegister.IsSetteled = dataReader.GetBoolean(13);
            }
            if (dataReader.IsDBNull(14) == false)
            {
                vw_searchChequeRegister.IsLocked = dataReader.GetBoolean(14);
            }
            if (dataReader.IsDBNull(15) == false)
            {
                vw_searchChequeRegister.IsDepositted = dataReader.GetBoolean(15);
            }
            if (dataReader.IsDBNull(16) == false)
            {
                vw_searchChequeRegister.IsReIssued = dataReader.GetBoolean(16);
            }
            if (dataReader.IsDBNull(17) == false)
            {
                vw_searchChequeRegister.IsReconcilied = dataReader.GetBoolean(17);
            }
            if (dataReader.IsDBNull(18) == false)
            {
                vw_searchChequeRegister.IsReturned = dataReader.GetBoolean(18);
            }
            if (dataReader.IsDBNull(19) == false)
            {
                vw_searchChequeRegister.IsReturnedToSender = dataReader.GetBoolean(19);
            }
            if (dataReader.IsDBNull(20) == false)
            {
                vw_searchChequeRegister.DepositCount = dataReader.GetInt32(20);
            }
            if (dataReader.IsDBNull(21) == false)
            {
                vw_searchChequeRegister.DateDeposited = dataReader.GetDateTime(21);
            }
            if (dataReader.IsDBNull(22) == false)
            {
                vw_searchChequeRegister.DateReconcilied = dataReader.GetDateTime(22);
            }
            if (dataReader.IsDBNull(23) == false)
            {
                vw_searchChequeRegister.DateReIssued = dataReader.GetDateTime(23);
            }
            if (dataReader.IsDBNull(24) == false)
            {
                vw_searchChequeRegister.DateReturnedToSender = dataReader.GetDateTime(24);
            }
            if (dataReader.IsDBNull(25) == false)
            {
                vw_searchChequeRegister.PaneltyAmount = dataReader.GetDecimal(25);
            }
            if (dataReader.IsDBNull(26) == false)
            {
                vw_searchChequeRegister.AccountReceipt_ID = dataReader.GetString(26);
            }
            return vw_searchChequeRegister;
        }
        /// <summary>
        /// This makes vw_searchChequeRegister datatable according to the datatable.
        /// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
        ///            We are still humans
        /// </summary>
        /// <param name="user">new vw_searchChequeRegister object</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(vw_searchChequeRegister vw_searchChequeRegister)
        {
            DataTable dt = new DataTable();

            DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID", typeof(string));
            DataColumn col_accountNumber = new DataColumn("accountNumber", typeof(string));
            DataColumn col_chequeNumber = new DataColumn("chequeNumber", typeof(string));
            DataColumn col_chequeAmount = new DataColumn("chequeAmount", typeof(decimal));
            DataColumn col_customer_ID = new DataColumn("customer_ID", typeof(string));
            DataColumn col_customerName = new DataColumn("customerName", typeof(string));
            DataColumn col_chequeStatus_ID = new DataColumn("chequeStatus_ID", typeof(string));
            DataColumn col_statusName = new DataColumn("statusName", typeof(string));
            DataColumn col_dateCheque = new DataColumn("dateCheque", typeof(DateTime));
            DataColumn col_invoice_ID = new DataColumn("invoice_ID", typeof(string));
            DataColumn col_receipt_ID = new DataColumn("receipt_ID", typeof(string));
            DataColumn col_bankName = new DataColumn("bankName", typeof(string));
            DataColumn col_isDeleted = new DataColumn("isDeleted", typeof(bool));
            DataColumn col_isSetteled = new DataColumn("isSetteled", typeof(bool));
            DataColumn col_isLocked = new DataColumn("isLocked", typeof(bool));
            DataColumn col_isDepositted = new DataColumn("isDepositted", typeof(bool));
            DataColumn col_isReIssued = new DataColumn("isReIssued", typeof(bool));
            DataColumn col_isReconcilied = new DataColumn("isReconcilied", typeof(bool));
            DataColumn col_isReturned = new DataColumn("isReturned", typeof(bool));
            DataColumn col_isReturnedToSender = new DataColumn("isReturnedToSender", typeof(bool));
            DataColumn col_depositCount = new DataColumn("depositCount", typeof(int));
            DataColumn col_dateDeposited = new DataColumn("dateDeposited", typeof(DateTime));
            DataColumn col_dateReconcilied = new DataColumn("dateReconcilied", typeof(DateTime));
            DataColumn col_dateReIssued = new DataColumn("dateReIssued", typeof(DateTime));
            DataColumn col_dateReturnedToSender = new DataColumn("dateReturnedToSender", typeof(DateTime));
            DataColumn col_paneltyAmount = new DataColumn("paneltyAmount", typeof(decimal));
            DataColumn col_accountReceipt_ID = new DataColumn("accountReceipt_ID", typeof(string));

            dt.Columns.AddRange(new DataColumn[] { col_chequeRegister_ID, col_accountNumber, col_chequeNumber, col_chequeAmount, col_customer_ID, col_customerName, col_chequeStatus_ID, col_statusName, col_dateCheque, col_invoice_ID, col_receipt_ID, col_bankName, col_isDeleted, col_isSetteled, col_isLocked, col_isDepositted, col_isReIssued, col_isReconcilied, col_isReturned, col_isReturnedToSender, col_depositCount, col_dateDeposited, col_dateReconcilied, col_dateReIssued, col_dateReturnedToSender, col_paneltyAmount, col_accountReceipt_ID, }); return dt;
        }
        /// <summary>
        /// This fills vw_searchChequeRegister datatable according to the Given user list.
        /// </summary>
        /// <param name="user">new vw_searchChequeRegister object</param>
        /// <returns></returns>
        public static void FillData(DataTable dt, vw_searchChequeRegister user)
        {
            DataRow drow = dt.NewRow();

            drow["chequeRegister_ID"] = user.chequeRegister_ID;
            drow["accountNumber"] = user.accountNumber;
            drow["chequeNumber"] = user.chequeNumber;
            drow["chequeAmount"] = user.chequeAmount;
            drow["customer_ID"] = user.customer_ID;
            drow["customerName"] = user.customerName;
            drow["chequeStatus_ID"] = user.chequeStatus_ID;
            drow["statusName"] = user.statusName;
            drow["dateCheque"] = user.dateCheque;
            drow["invoice_ID"] = user.invoice_ID;
            drow["receipt_ID"] = user.receipt_ID;
            drow["bankName"] = user.bankName;
            drow["isDeleted"] = user.isDeleted;
            drow["isSetteled"] = user.isSetteled;
            drow["isLocked"] = user.isLocked;
            drow["isDepositted"] = user.isDepositted;
            drow["isReIssued"] = user.isReIssued;
            drow["isReconcilied"] = user.isReconcilied;
            drow["isReturned"] = user.isReturned;
            drow["isReturnedToSender"] = user.isReturnedToSender;
            drow["depositCount"] = user.depositCount;
            drow["dateDeposited"] = user.dateDeposited;
            drow["dateReconcilied"] = user.dateReconcilied;
            drow["dateReIssued"] = user.dateReIssued;
            drow["dateReturnedToSender"] = user.dateReturnedToSender;
            drow["paneltyAmount"] = user.paneltyAmount;
            drow["accountReceipt_ID"] = user.accountReceipt_ID;
            dt.Rows.Add(drow);
        }
        #endregion
    }
}
