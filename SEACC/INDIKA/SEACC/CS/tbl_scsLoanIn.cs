using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsLoanIn {
		#region Fields
		private string loanIn_ID;
		private DateTime loanInDate;
		private string remark;
		private string receiverName;
		private string issuedRefNo_ID;
		private string store_ID;
		private string supplier_ID;
		private string customer_ID;
		private decimal totalUnitPrice;
		private decimal totalWeightPrice;
		private decimal totalQty;
		private decimal totalWeight;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string deletedUser_ID;
		private string printedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deletedTerminal_ID;
		private string printedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime dateDeleted;
		private DateTime datePrinted;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isSeattled;
		private decimal seattleAmount;
		private int printCount;
		private bool isForSupplier;
		private bool isForOther;
		private bool isForCustomer;
		private bool isWeightCalculation;
		private bool isFirstDocument;
		private string companyID;
		private string companyBranch_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsLoanIn class.
		/// </summary>
		public tbl_scsLoanIn() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsLoanIn class.
		/// </summary>
		public tbl_scsLoanIn(string loanIn_ID, DateTime loanInDate, string remark, string receiverName, string issuedRefNo_ID, string store_ID, string supplier_ID, string customer_ID, decimal totalUnitPrice, decimal totalWeightPrice, decimal totalQty, decimal totalWeight, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled, decimal seattleAmount, int printCount, bool isForSupplier, bool isForOther, bool isForCustomer, bool isWeightCalculation, bool isFirstDocument, string companyID, string companyBranch_ID) {
			this.loanIn_ID = loanIn_ID;
			this.loanInDate = loanInDate;
			this.remark = remark;
			this.receiverName = receiverName;
			this.issuedRefNo_ID = issuedRefNo_ID;
			this.store_ID = store_ID;
			this.supplier_ID = supplier_ID;
			this.customer_ID = customer_ID;
			this.totalUnitPrice = totalUnitPrice;
			this.totalWeightPrice = totalWeightPrice;
			this.totalQty = totalQty;
			this.totalWeight = totalWeight;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.deletedUser_ID = deletedUser_ID;
			this.printedUser_ID = printedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deletedTerminal_ID = deletedTerminal_ID;
			this.printedTerminal_ID = printedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.dateDeleted = dateDeleted;
			this.datePrinted = datePrinted;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isSeattled = isSeattled;
			this.seattleAmount = seattleAmount;
			this.printCount = printCount;
			this.isForSupplier = isForSupplier;
			this.isForOther = isForOther;
			this.isForCustomer = isForCustomer;
			this.isWeightCalculation = isWeightCalculation;
			this.isFirstDocument = isFirstDocument;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the LoanIn_ID value.
		/// </summary>
		public string LoanIn_ID {
			get { return loanIn_ID; }
			set { loanIn_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LoanInDate value.
		/// </summary>
		public DateTime LoanInDate {
			get { return loanInDate; }
			set { loanInDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReceiverName value.
		/// </summary>
		public string ReceiverName {
			get { return receiverName; }
			set { receiverName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IssuedRefNo_ID value.
		/// </summary>
		public string IssuedRefNo_ID {
			get { return issuedRefNo_ID; }
			set { issuedRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalUnitPrice value.
		/// </summary>
		public decimal TotalUnitPrice {
			get { return totalUnitPrice; }
			set { totalUnitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalWeightPrice value.
		/// </summary>
		public decimal TotalWeightPrice {
			get { return totalWeightPrice; }
			set { totalWeightPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalQty value.
		/// </summary>
		public decimal TotalQty {
			get { return totalQty; }
			set { totalQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalWeight value.
		/// </summary>
		public decimal TotalWeight {
			get { return totalWeight; }
			set { totalWeight = value; }
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
		/// Gets or sets the DeletedUser_ID value.
		/// </summary>
		public string DeletedUser_ID {
			get { return deletedUser_ID; }
			set { deletedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintedUser_ID value.
		/// </summary>
		public string PrintedUser_ID {
			get { return printedUser_ID; }
			set { printedUser_ID = value; }
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
		/// Gets or sets the DeletedTerminal_ID value.
		/// </summary>
		public string DeletedTerminal_ID {
			get { return deletedTerminal_ID; }
			set { deletedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintedTerminal_ID value.
		/// </summary>
		public string PrintedTerminal_ID {
			get { return printedTerminal_ID; }
			set { printedTerminal_ID = value; }
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
		/// Gets or sets the DateDeleted value.
		/// </summary>
		public DateTime DateDeleted {
			get { return dateDeleted; }
			set { dateDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the DatePrinted value.
		/// </summary>
		public DateTime DatePrinted {
			get { return datePrinted; }
			set { datePrinted = value; }
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
		/// Gets or sets the IsSeattled value.
		/// </summary>
		public bool IsSeattled {
			get { return isSeattled; }
			set { isSeattled = value; }
		}
		
		/// <summary>
		/// Gets or sets the SeattleAmount value.
		/// </summary>
		public decimal SeattleAmount {
			get { return seattleAmount; }
			set { seattleAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsForSupplier value.
		/// </summary>
		public bool IsForSupplier {
			get { return isForSupplier; }
			set { isForSupplier = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsForOther value.
		/// </summary>
		public bool IsForOther {
			get { return isForOther; }
			set { isForOther = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsForCustomer value.
		/// </summary>
		public bool IsForCustomer {
			get { return isForCustomer; }
			set { isForCustomer = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeightCalculation value.
		/// </summary>
		public bool IsWeightCalculation {
			get { return isWeightCalculation; }
			set { isWeightCalculation = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFirstDocument value.
		/// </summary>
		public bool IsFirstDocument {
			get { return isFirstDocument; }
			set { isFirstDocument = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsLoanIn table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@loanIn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@loanInDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@ReceiverName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@totalUnitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalWeightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isForSupplier", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForOther", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForCustomer", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFirstDocument", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@loanIn_ID"].Value = loanIn_ID;
			scom.Parameters["@loanInDate"].Value = loanInDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@ReceiverName"].Value = receiverName;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@totalUnitPrice"].Value = totalUnitPrice;
			scom.Parameters["@totalWeightPrice"].Value = totalWeightPrice;
			scom.Parameters["@totalQty"].Value = totalQty;
			scom.Parameters["@totalWeight"].Value = totalWeight;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isForSupplier"].Value = isForSupplier;
			scom.Parameters["@isForOther"].Value = isForOther;
			scom.Parameters["@isForCustomer"].Value = isForCustomer;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@isFirstDocument"].Value = isFirstDocument;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsLoanIn table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@loanIn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@loanInDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@ReceiverName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@totalUnitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalWeightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSeattled", SqlDbType.Bit,1);
			scom.Parameters.Add("@seattleAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@isForSupplier", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForOther", SqlDbType.Bit,1);
			scom.Parameters.Add("@isForCustomer", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFirstDocument", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@loanIn_ID"].Value = loanIn_ID;
			scom.Parameters["@loanInDate"].Value = loanInDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@ReceiverName"].Value = receiverName;
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@totalUnitPrice"].Value = totalUnitPrice;
			scom.Parameters["@totalWeightPrice"].Value = totalWeightPrice;
			scom.Parameters["@totalQty"].Value = totalQty;
			scom.Parameters["@totalWeight"].Value = totalWeight;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSeattled"].Value = isSeattled;
			scom.Parameters["@seattleAmount"].Value = seattleAmount;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@isForSupplier"].Value = isForSupplier;
			scom.Parameters["@isForOther"].Value = isForOther;
			scom.Parameters["@isForCustomer"].Value = isForCustomer;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
			scom.Parameters["@isFirstDocument"].Value = isFirstDocument;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsLoanIn table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@loanIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@loanIn_ID"].Value = loanIn_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanIn table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanIn table by a foreign key.
		/// </summary>
		public static void DeleteAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInDeleteAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanIn table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsLoanIn table.
		/// </summary>
		public static tbl_scsLoanIn Select(string loanIn_ID_Incoming){

			tbl_scsLoanIn tbl_scsLoanInins = new tbl_scsLoanIn();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@loanIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@loanIn_ID"].Value = loanIn_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsLoanInins = Maketbl_scsLoanIn(dataReader);
				} else {
					tbl_scsLoanInins = null;
				}
			}
			scon.Close();
			return tbl_scsLoanInins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanIn table.
		/// </summary>
		public static List<tbl_scsLoanIn> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsLoanIn> tbl_scsLoanInList = new List<tbl_scsLoanIn>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsLoanIn tbl_scsLoanIn = Maketbl_scsLoanIn(dataReader);
					tbl_scsLoanInList.Add(tbl_scsLoanIn);
				}
			}
			scon.Close();
			return tbl_scsLoanInList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanIn table by a foreign key.
		/// </summary>
		public static List<tbl_scsLoanIn> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_scsLoanIn> tbl_scsLoanInList = new List<tbl_scsLoanIn>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsLoanIn tbl_scsLoanIn = Maketbl_scsLoanIn(dataReader);
					tbl_scsLoanInList.Add(tbl_scsLoanIn);
				}
			}
			scon.Close();
			return tbl_scsLoanInList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanIn table by a foreign key.
		/// </summary>
		public static List<tbl_scsLoanIn> SelectAllByIssuedRefNo_ID(string issuedRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInSelectAllByIssuedRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@IssuedRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@IssuedRefNo_ID"].Value = issuedRefNo_ID;
				List<tbl_scsLoanIn> tbl_scsLoanInList = new List<tbl_scsLoanIn>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsLoanIn tbl_scsLoanIn = Maketbl_scsLoanIn(dataReader);
					tbl_scsLoanInList.Add(tbl_scsLoanIn);
				}
			}
			scon.Close();
			return tbl_scsLoanInList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsLoanIn table by a foreign key.
		/// </summary>
		public static List<tbl_scsLoanIn> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsLoanInSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_scsLoanIn> tbl_scsLoanInList = new List<tbl_scsLoanIn>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsLoanIn tbl_scsLoanIn = Maketbl_scsLoanIn(dataReader);
					tbl_scsLoanInList.Add(tbl_scsLoanIn);
				}
			}
			scon.Close();
			return tbl_scsLoanInList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsLoanIn class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsLoanIn Maketbl_scsLoanIn(SqlDataReader dataReader) {
			tbl_scsLoanIn tbl_scsLoanIn = new tbl_scsLoanIn();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsLoanIn.LoanIn_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsLoanIn.LoanInDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsLoanIn.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsLoanIn.ReceiverName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsLoanIn.IssuedRefNo_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsLoanIn.Store_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsLoanIn.Supplier_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsLoanIn.Customer_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsLoanIn.TotalUnitPrice = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsLoanIn.TotalWeightPrice = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsLoanIn.TotalQty = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsLoanIn.TotalWeight = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsLoanIn.CreateUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsLoanIn.ModifiedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsLoanIn.CheckedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsLoanIn.ApprovedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsLoanIn.DeletedUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsLoanIn.PrintedUser_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsLoanIn.CreateTerminal_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsLoanIn.ModifiedTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsLoanIn.DeletedTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsLoanIn.PrintedTerminal_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_scsLoanIn.DateCreate = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_scsLoanIn.DateModified = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_scsLoanIn.DateChecked = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_scsLoanIn.DateApproved = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_scsLoanIn.DateDeleted = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_scsLoanIn.DatePrinted = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_scsLoanIn.IsChecked = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_scsLoanIn.IsApproved = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_scsLoanIn.IsFinished = dataReader.GetBoolean(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_scsLoanIn.IsDeleted = dataReader.GetBoolean(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_scsLoanIn.IsLocked = dataReader.GetBoolean(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_scsLoanIn.IsSeattled = dataReader.GetBoolean(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_scsLoanIn.SeattleAmount = dataReader.GetDecimal(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_scsLoanIn.PrintCount = dataReader.GetInt32(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_scsLoanIn.IsForSupplier = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_scsLoanIn.IsForOther = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_scsLoanIn.IsForCustomer = dataReader.GetBoolean(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_scsLoanIn.IsWeightCalculation = dataReader.GetBoolean(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_scsLoanIn.IsFirstDocument = dataReader.GetBoolean(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_scsLoanIn.CompanyID = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_scsLoanIn.CompanyBranch_ID = dataReader.GetString(42);
			}

			return tbl_scsLoanIn;
		}
		/// <summary>
		/// This makes tbl_scsLoanIn datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsLoanIn object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsLoanIn  tbl_scsLoanIn   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_loanIn_ID = new DataColumn("loanIn_ID" , typeof(string));
			DataColumn col_loanInDate = new DataColumn("loanInDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_ReceiverName = new DataColumn("ReceiverName" , typeof(string));
			DataColumn col_IssuedRefNo_ID = new DataColumn("IssuedRefNo_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_totalUnitPrice = new DataColumn("totalUnitPrice" , typeof(decimal));
			DataColumn col_totalWeightPrice = new DataColumn("totalWeightPrice" , typeof(decimal));
			DataColumn col_totalQty = new DataColumn("totalQty" , typeof(decimal));
			DataColumn col_totalWeight = new DataColumn("totalWeight" , typeof(decimal));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_deletedUser_ID = new DataColumn("deletedUser_ID" , typeof(string));
			DataColumn col_printedUser_ID = new DataColumn("printedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID" , typeof(string));
			DataColumn col_printedTerminal_ID = new DataColumn("printedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_dateDeleted = new DataColumn("dateDeleted" , typeof(DateTime));
			DataColumn col_datePrinted = new DataColumn("datePrinted" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isSeattled = new DataColumn("isSeattled" , typeof(bool));
			DataColumn col_seattleAmount = new DataColumn("seattleAmount" , typeof(decimal));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_isForSupplier = new DataColumn("isForSupplier" , typeof(bool));
			DataColumn col_isForOther = new DataColumn("isForOther" , typeof(bool));
			DataColumn col_isForCustomer = new DataColumn("isForCustomer" , typeof(bool));
			DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation" , typeof(bool));
			DataColumn col_isFirstDocument = new DataColumn("isFirstDocument" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_loanIn_ID,col_loanInDate,col_remark,col_ReceiverName,col_IssuedRefNo_ID,col_store_ID,col_supplier_ID,col_customer_ID,col_totalUnitPrice,col_totalWeightPrice,col_totalQty,col_totalWeight,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,col_seattleAmount,col_printCount,col_isForSupplier,col_isForOther,col_isForCustomer,col_isWeightCalculation,col_isFirstDocument,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsLoanIn datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsLoanIn object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsLoanIn user) {
		DataRow drow = dt.NewRow();
		
			drow["loanIn_ID"] = user.loanIn_ID;
			drow["loanInDate"] = user.loanInDate;
			drow["remark"] = user.remark;
			drow["ReceiverName"] = user.ReceiverName;
			drow["IssuedRefNo_ID"] = user.IssuedRefNo_ID;
			drow["store_ID"] = user.store_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["totalUnitPrice"] = user.totalUnitPrice;
			drow["totalWeightPrice"] = user.totalWeightPrice;
			drow["totalQty"] = user.totalQty;
			drow["totalWeight"] = user.totalWeight;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["deletedUser_ID"] = user.deletedUser_ID;
			drow["printedUser_ID"] = user.printedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
			drow["printedTerminal_ID"] = user.printedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["dateDeleted"] = user.dateDeleted;
			drow["datePrinted"] = user.datePrinted;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isSeattled"] = user.isSeattled;
			drow["seattleAmount"] = user.seattleAmount;
			drow["printCount"] = user.printCount;
			drow["isForSupplier"] = user.isForSupplier;
			drow["isForOther"] = user.isForOther;
			drow["isForCustomer"] = user.isForCustomer;
			drow["isWeightCalculation"] = user.isWeightCalculation;
			drow["isFirstDocument"] = user.isFirstDocument;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
