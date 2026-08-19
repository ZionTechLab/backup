using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasAccountReceipt {
		#region Fields
		private string receipt_ID;
		private DateTime receiptDate;
		private string remark;
		private string customer_ID;
		private string invoice_ID;
		private string quotation_ID;
		private string customerOrder_ID;
		private string deliveryOrder_ID;
		private decimal amount;
		private decimal amountSettled;
		private string tatalAmountInWord;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private int printCount;
		private bool isAdvance;
		private bool isSettled;
		private bool isChequeReceipt;
		private string chequeRegister_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasAccountReceipt class.
		/// </summary>
		public tbl_sasAccountReceipt() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasAccountReceipt class.
		/// </summary>
		public tbl_sasAccountReceipt(string receipt_ID, DateTime receiptDate, string remark, string customer_ID, string invoice_ID, string quotation_ID, string customerOrder_ID, string deliveryOrder_ID, decimal amount, decimal amountSettled, string tatalAmountInWord, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, int printCount, bool isAdvance, bool isSettled, bool isChequeReceipt, string chequeRegister_ID) {
			this.receipt_ID = receipt_ID;
			this.receiptDate = receiptDate;
			this.remark = remark;
			this.customer_ID = customer_ID;
			this.invoice_ID = invoice_ID;
			this.quotation_ID = quotation_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.amount = amount;
			this.amountSettled = amountSettled;
			this.tatalAmountInWord = tatalAmountInWord;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.printCount = printCount;
			this.isAdvance = isAdvance;
			this.isSettled = isSettled;
			this.isChequeReceipt = isChequeReceipt;
			this.chequeRegister_ID = chequeRegister_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiptDate value.
		/// </summary>
		public DateTime ReceiptDate {
			get { return receiptDate; }
			set { receiptDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Invoice_ID value.
		/// </summary>
		public string Invoice_ID {
			get { return invoice_ID; }
			set { invoice_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Quotation_ID value.
		/// </summary>
		public string Quotation_ID {
			get { return quotation_ID; }
			set { quotation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryOrder_ID value.
		/// </summary>
		public string DeliveryOrder_ID {
			get { return deliveryOrder_ID; }
			set { deliveryOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the AmountSettled value.
		/// </summary>
		public decimal AmountSettled {
			get { return amountSettled; }
			set { amountSettled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TatalAmountInWord value.
		/// </summary>
		public string TatalAmountInWord {
			get { return tatalAmountInWord; }
			set { tatalAmountInWord = value; }
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
		
		/// <summary>
		/// Gets or sets the IsChecked value.
		/// </summary>
		public bool IsChecked {
			get { return isChecked; }
			set { isChecked = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFinished value.
		/// </summary>
		public bool IsFinished {
			get { return isFinished; }
			set { isFinished = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAdvance value.
		/// </summary>
		public bool IsAdvance {
			get { return isAdvance; }
			set { isAdvance = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSettled value.
		/// </summary>
		public bool IsSettled {
			get { return isSettled; }
			set { isSettled = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsChequeReceipt value.
		/// </summary>
		public bool IsChequeReceipt {
			get { return isChequeReceipt; }
			set { isChequeReceipt = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasAccountReceipt table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receiptDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amountSettled", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmountInWord", SqlDbType.VarChar,200);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isAdvance", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChequeReceipt", SqlDbType.Bit,1);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@receiptDate"].Value = receiptDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@amountSettled"].Value = amountSettled;
			scom.Parameters["@tatalAmountInWord"].Value = tatalAmountInWord;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isAdvance"].Value = isAdvance;
			scom.Parameters["@isSettled"].Value = isSettled;
			scom.Parameters["@isChequeReceipt"].Value = isChequeReceipt;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasAccountReceipt table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@receiptDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amountSettled", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmountInWord", SqlDbType.VarChar,200);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isAdvance", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChequeReceipt", SqlDbType.Bit,1);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@receiptDate"].Value = receiptDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@amount"].Value = amount;
			scom.Parameters["@amountSettled"].Value = amountSettled;
			scom.Parameters["@tatalAmountInWord"].Value = tatalAmountInWord;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isAdvance"].Value = isAdvance;
			scom.Parameters["@isSettled"].Value = isSettled;
			scom.Parameters["@isChequeReceipt"].Value = isChequeReceipt;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasAccountReceipt table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByQuotation_ID(string quotation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptDeleteAllByQuotation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptDeleteAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptDeleteAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptDeleteAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasAccountReceipt table.
		/// </summary>
		public static tbl_sasAccountReceipt Select(string receipt_ID_Incoming){

			tbl_sasAccountReceipt tbl_sasAccountReceiptins = new tbl_sasAccountReceipt();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasAccountReceiptins = Maketbl_sasAccountReceipt(dataReader);
				} else {
					tbl_sasAccountReceiptins = null;
				}
			}
			scon.Close();
			return tbl_sasAccountReceiptins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table.
		/// </summary>
		public static List<tbl_sasAccountReceipt> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasAccountReceipt> tbl_sasAccountReceiptList = new List<tbl_sasAccountReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasAccountReceipt tbl_sasAccountReceipt = Maketbl_sasAccountReceipt(dataReader);
					tbl_sasAccountReceiptList.Add(tbl_sasAccountReceipt);
				}
			}
			scon.Close();
			return tbl_sasAccountReceiptList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static List<tbl_sasAccountReceipt> SelectAllByQuotation_ID(string quotation_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptSelectAllByQuotation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@quotation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@quotation_ID"].Value = quotation_ID;
				List<tbl_sasAccountReceipt> tbl_sasAccountReceiptList = new List<tbl_sasAccountReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasAccountReceipt tbl_sasAccountReceipt = Maketbl_sasAccountReceipt(dataReader);
					tbl_sasAccountReceiptList.Add(tbl_sasAccountReceipt);
				}
			}
			scon.Close();
			return tbl_sasAccountReceiptList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static List<tbl_sasAccountReceipt> SelectAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptSelectAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
				List<tbl_sasAccountReceipt> tbl_sasAccountReceiptList = new List<tbl_sasAccountReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasAccountReceipt tbl_sasAccountReceipt = Maketbl_sasAccountReceipt(dataReader);
					tbl_sasAccountReceiptList.Add(tbl_sasAccountReceipt);
				}
			}
			scon.Close();
			return tbl_sasAccountReceiptList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static List<tbl_sasAccountReceipt> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_sasAccountReceipt> tbl_sasAccountReceiptList = new List<tbl_sasAccountReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasAccountReceipt tbl_sasAccountReceipt = Maketbl_sasAccountReceipt(dataReader);
					tbl_sasAccountReceiptList.Add(tbl_sasAccountReceipt);
				}
			}
			scon.Close();
			return tbl_sasAccountReceiptList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static List<tbl_sasAccountReceipt> SelectAllByInvoice_ID(string invoice_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptSelectAllByInvoice_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@invoice_ID", SqlDbType.VarChar,20);
			scom.Parameters["@invoice_ID"].Value = invoice_ID;
				List<tbl_sasAccountReceipt> tbl_sasAccountReceiptList = new List<tbl_sasAccountReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasAccountReceipt tbl_sasAccountReceipt = Maketbl_sasAccountReceipt(dataReader);
					tbl_sasAccountReceiptList.Add(tbl_sasAccountReceipt);
				}
			}
			scon.Close();
			return tbl_sasAccountReceiptList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static List<tbl_sasAccountReceipt> SelectAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptSelectAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
				List<tbl_sasAccountReceipt> tbl_sasAccountReceiptList = new List<tbl_sasAccountReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasAccountReceipt tbl_sasAccountReceipt = Maketbl_sasAccountReceipt(dataReader);
					tbl_sasAccountReceiptList.Add(tbl_sasAccountReceipt);
				}
			}
			scon.Close();
			return tbl_sasAccountReceiptList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAccountReceipt table by a foreign key.
		/// </summary>
		public static List<tbl_sasAccountReceipt> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAccountReceiptSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_sasAccountReceipt> tbl_sasAccountReceiptList = new List<tbl_sasAccountReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasAccountReceipt tbl_sasAccountReceipt = Maketbl_sasAccountReceipt(dataReader);
					tbl_sasAccountReceiptList.Add(tbl_sasAccountReceipt);
				}
			}
			scon.Close();
			return tbl_sasAccountReceiptList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasAccountReceipt class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasAccountReceipt Maketbl_sasAccountReceipt(SqlDataReader dataReader) {
			tbl_sasAccountReceipt tbl_sasAccountReceipt = new tbl_sasAccountReceipt();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasAccountReceipt.Receipt_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasAccountReceipt.ReceiptDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasAccountReceipt.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasAccountReceipt.Customer_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasAccountReceipt.Invoice_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasAccountReceipt.Quotation_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasAccountReceipt.CustomerOrder_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasAccountReceipt.DeliveryOrder_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasAccountReceipt.Amount = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasAccountReceipt.AmountSettled = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasAccountReceipt.TatalAmountInWord = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasAccountReceipt.CreateUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasAccountReceipt.ModifiedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasAccountReceipt.CheckedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasAccountReceipt.ApprovedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasAccountReceipt.DateCreate = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasAccountReceipt.DateModified = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasAccountReceipt.DateChecked = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasAccountReceipt.DateApproved = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasAccountReceipt.IsChecked = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasAccountReceipt.IsApproved = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasAccountReceipt.IsFinished = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasAccountReceipt.IsDeleted = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasAccountReceipt.IsLocked = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_sasAccountReceipt.PrintCount = dataReader.GetInt32(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_sasAccountReceipt.IsAdvance = dataReader.GetBoolean(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_sasAccountReceipt.IsSettled = dataReader.GetBoolean(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_sasAccountReceipt.IsChequeReceipt = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_sasAccountReceipt.ChequeRegister_ID = dataReader.GetString(28);
			}

			return tbl_sasAccountReceipt;
		}
		/// <summary>
		/// This makes tbl_sasAccountReceipt datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasAccountReceipt object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasAccountReceipt  tbl_sasAccountReceipt   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_receiptDate = new DataColumn("receiptDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_invoice_ID = new DataColumn("invoice_ID" , typeof(string));
			DataColumn col_quotation_ID = new DataColumn("quotation_ID" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
			DataColumn col_amountSettled = new DataColumn("amountSettled" , typeof(decimal));
			DataColumn col_tatalAmountInWord = new DataColumn("tatalAmountInWord" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_isAdvance = new DataColumn("isAdvance" , typeof(bool));
			DataColumn col_isSettled = new DataColumn("isSettled" , typeof(bool));
			DataColumn col_isChequeReceipt = new DataColumn("isChequeReceipt" , typeof(bool));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_receipt_ID,col_receiptDate,col_remark,col_customer_ID,col_invoice_ID,col_quotation_ID,col_customerOrder_ID,col_deliveryOrder_ID,col_amount,col_amountSettled,col_tatalAmountInWord,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_printCount,col_isAdvance,col_isSettled,col_isChequeReceipt,col_chequeRegister_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasAccountReceipt datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasAccountReceipt object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasAccountReceipt user) {
		DataRow drow = dt.NewRow();
		
			drow["receipt_ID"] = user.receipt_ID;
			drow["receiptDate"] = user.receiptDate;
			drow["remark"] = user.remark;
			drow["customer_ID"] = user.customer_ID;
			drow["invoice_ID"] = user.invoice_ID;
			drow["quotation_ID"] = user.quotation_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["amount"] = user.amount;
			drow["amountSettled"] = user.amountSettled;
			drow["tatalAmountInWord"] = user.tatalAmountInWord;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["printCount"] = user.printCount;
			drow["isAdvance"] = user.isAdvance;
			drow["isSettled"] = user.isSettled;
			drow["isChequeReceipt"] = user.isChequeReceipt;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
