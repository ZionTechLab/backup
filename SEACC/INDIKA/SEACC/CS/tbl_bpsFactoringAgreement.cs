using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsFactoringAgreement {
		#region Fields
		private string factoringAgreement_ID;
		private string factoringAgreement_Revision;
		private string ref1;
		private string ref2;
		private string remarks;
		private int attachment_ID;
		private DateTime agreementValidity_From;
		private DateTime agreementValidity_To;
		private string accountNumber_Factoring;
		private string accountNumber_Current;
		private string accountNumber_Clearing;
		private string bank_ID;
		private string branch_ID;
		private decimal credit_Limit;
		private decimal factoring_Rate;
		private int credit_Period;
		private int recourse_Period;
		private decimal serviceCharge_presentage;
		private decimal serviceCharge_min;
		private string factoringInterest_ID;
		private bool isActive;
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
		private bool isDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsFactoringAgreement class.
		/// </summary>
		public tbl_bpsFactoringAgreement() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsFactoringAgreement class.
		/// </summary>
		public tbl_bpsFactoringAgreement(string factoringAgreement_ID, string factoringAgreement_Revision, string ref1, string ref2, string remarks, int attachment_ID, DateTime agreementValidity_From, DateTime agreementValidity_To, string accountNumber_Factoring, string accountNumber_Current, string accountNumber_Clearing, string bank_ID, string branch_ID, decimal credit_Limit, decimal factoring_Rate, int credit_Period, int recourse_Period, decimal serviceCharge_presentage, decimal serviceCharge_min, string factoringInterest_ID, bool isActive, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isDeleted) {
			this.factoringAgreement_ID = factoringAgreement_ID;
			this.factoringAgreement_Revision = factoringAgreement_Revision;
			this.ref1 = ref1;
			this.ref2 = ref2;
			this.remarks = remarks;
			this.attachment_ID = attachment_ID;
			this.agreementValidity_From = agreementValidity_From;
			this.agreementValidity_To = agreementValidity_To;
			this.accountNumber_Factoring = accountNumber_Factoring;
			this.accountNumber_Current = accountNumber_Current;
			this.accountNumber_Clearing = accountNumber_Clearing;
			this.bank_ID = bank_ID;
			this.branch_ID = branch_ID;
			this.credit_Limit = credit_Limit;
			this.factoring_Rate = factoring_Rate;
			this.credit_Period = credit_Period;
			this.recourse_Period = recourse_Period;
			this.serviceCharge_presentage = serviceCharge_presentage;
			this.serviceCharge_min = serviceCharge_min;
			this.factoringInterest_ID = factoringInterest_ID;
			this.isActive = isActive;
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
			this.isDeleted = isDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FactoringAgreement_ID value.
		/// </summary>
		public string FactoringAgreement_ID {
			get { return factoringAgreement_ID; }
			set { factoringAgreement_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FactoringAgreement_Revision value.
		/// </summary>
		public string FactoringAgreement_Revision {
			get { return factoringAgreement_Revision; }
			set { factoringAgreement_Revision = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ref1 value.
		/// </summary>
		public string Ref1 {
			get { return ref1; }
			set { ref1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ref2 value.
		/// </summary>
		public string Ref2 {
			get { return ref2; }
			set { ref2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Attachment_ID value.
		/// </summary>
		public int Attachment_ID {
			get { return attachment_ID; }
			set { attachment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AgreementValidity_From value.
		/// </summary>
		public DateTime AgreementValidity_From {
			get { return agreementValidity_From; }
			set { agreementValidity_From = value; }
		}
		
		/// <summary>
		/// Gets or sets the AgreementValidity_To value.
		/// </summary>
		public DateTime AgreementValidity_To {
			get { return agreementValidity_To; }
			set { agreementValidity_To = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountNumber_Factoring value.
		/// </summary>
		public string AccountNumber_Factoring {
			get { return accountNumber_Factoring; }
			set { accountNumber_Factoring = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountNumber_Current value.
		/// </summary>
		public string AccountNumber_Current {
			get { return accountNumber_Current; }
			set { accountNumber_Current = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountNumber_Clearing value.
		/// </summary>
		public string AccountNumber_Clearing {
			get { return accountNumber_Clearing; }
			set { accountNumber_Clearing = value; }
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
		/// Gets or sets the Credit_Limit value.
		/// </summary>
		public decimal Credit_Limit {
			get { return credit_Limit; }
			set { credit_Limit = value; }
		}
		
		/// <summary>
		/// Gets or sets the Factoring_Rate value.
		/// </summary>
		public decimal Factoring_Rate {
			get { return factoring_Rate; }
			set { factoring_Rate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Credit_Period value.
		/// </summary>
		public int Credit_Period {
			get { return credit_Period; }
			set { credit_Period = value; }
		}
		
		/// <summary>
		/// Gets or sets the Recourse_Period value.
		/// </summary>
		public int Recourse_Period {
			get { return recourse_Period; }
			set { recourse_Period = value; }
		}
		
		/// <summary>
		/// Gets or sets the ServiceCharge_presentage value.
		/// </summary>
		public decimal ServiceCharge_presentage {
			get { return serviceCharge_presentage; }
			set { serviceCharge_presentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the ServiceCharge_min value.
		/// </summary>
		public decimal ServiceCharge_min {
			get { return serviceCharge_min; }
			set { serviceCharge_min = value; }
		}
		
		/// <summary>
		/// Gets or sets the FactoringInterest_ID value.
		/// </summary>
		public string FactoringInterest_ID {
			get { return factoringInterest_ID; }
			set { factoringInterest_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
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
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsFactoringAgreement table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@factoringAgreement_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@factoringAgreement_Revision", SqlDbType.VarChar,2);
			scom.Parameters.Add("@ref1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ref2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@attachment_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@agreementValidity_From", SqlDbType.DateTime,8);
			scom.Parameters.Add("@agreementValidity_To", SqlDbType.DateTime,8);
			scom.Parameters.Add("@accountNumber_Factoring", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber_Current", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber_Clearing", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@credit_Limit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoring_Rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@credit_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@Recourse_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@serviceCharge_presentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@serviceCharge_min", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoringInterest_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
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
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@factoringAgreement_ID"].Value = factoringAgreement_ID;
			scom.Parameters["@factoringAgreement_Revision"].Value = factoringAgreement_Revision;
			scom.Parameters["@ref1"].Value = ref1;
			scom.Parameters["@ref2"].Value = ref2;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@attachment_ID"].Value = attachment_ID;
			scom.Parameters["@agreementValidity_From"].Value = agreementValidity_From;
			scom.Parameters["@agreementValidity_To"].Value = agreementValidity_To;
			scom.Parameters["@accountNumber_Factoring"].Value = accountNumber_Factoring;
			scom.Parameters["@accountNumber_Current"].Value = accountNumber_Current;
			scom.Parameters["@accountNumber_Clearing"].Value = accountNumber_Clearing;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@credit_Limit"].Value = credit_Limit;
			scom.Parameters["@factoring_Rate"].Value = factoring_Rate;
			scom.Parameters["@credit_Period"].Value = credit_Period;
			scom.Parameters["@Recourse_Period"].Value = recourse_Period;
			scom.Parameters["@serviceCharge_presentage"].Value = serviceCharge_presentage;
			scom.Parameters["@serviceCharge_min"].Value = serviceCharge_min;
			scom.Parameters["@factoringInterest_ID"].Value = factoringInterest_ID;
			scom.Parameters["@isActive"].Value = isActive;
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
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsFactoringAgreement table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@factoringAgreement_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@factoringAgreement_Revision", SqlDbType.VarChar,2);
			scom.Parameters.Add("@ref1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@ref2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,100);
			scom.Parameters.Add("@attachment_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@agreementValidity_From", SqlDbType.DateTime,8);
			scom.Parameters.Add("@agreementValidity_To", SqlDbType.DateTime,8);
			scom.Parameters.Add("@accountNumber_Factoring", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber_Current", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountNumber_Clearing", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@credit_Limit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoring_Rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@credit_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@Recourse_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@serviceCharge_presentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@serviceCharge_min", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoringInterest_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
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
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@factoringAgreement_ID"].Value = factoringAgreement_ID;
			scom.Parameters["@factoringAgreement_Revision"].Value = factoringAgreement_Revision;
			scom.Parameters["@ref1"].Value = ref1;
			scom.Parameters["@ref2"].Value = ref2;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@attachment_ID"].Value = attachment_ID;
			scom.Parameters["@agreementValidity_From"].Value = agreementValidity_From;
			scom.Parameters["@agreementValidity_To"].Value = agreementValidity_To;
			scom.Parameters["@accountNumber_Factoring"].Value = accountNumber_Factoring;
			scom.Parameters["@accountNumber_Current"].Value = accountNumber_Current;
			scom.Parameters["@accountNumber_Clearing"].Value = accountNumber_Clearing;
			scom.Parameters["@bank_ID"].Value = bank_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@credit_Limit"].Value = credit_Limit;
			scom.Parameters["@factoring_Rate"].Value = factoring_Rate;
			scom.Parameters["@credit_Period"].Value = credit_Period;
			scom.Parameters["@Recourse_Period"].Value = recourse_Period;
			scom.Parameters["@serviceCharge_presentage"].Value = serviceCharge_presentage;
			scom.Parameters["@serviceCharge_min"].Value = serviceCharge_min;
			scom.Parameters["@factoringInterest_ID"].Value = factoringInterest_ID;
			scom.Parameters["@isActive"].Value = isActive;
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
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsFactoringAgreement table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@factoringAgreement_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@factoringAgreement_Revision", SqlDbType.VarChar,2);
			scom.Parameters["@factoringAgreement_ID"].Value = factoringAgreement_ID;
 
			scom.Parameters["@factoringAgreement_Revision"].Value = factoringAgreement_Revision;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringAgreement table by a foreign key.
		/// </summary>
		public static void DeleteAllByFactoringInterest_ID(string factoringInterest_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementDeleteAllByFactoringInterest_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@factoringInterest_ID", SqlDbType.VarChar,20);
			scom.Parameters["@factoringInterest_ID"].Value = factoringInterest_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringAgreement table by a foreign key.
		/// </summary>
		public static void DeleteAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementDeleteAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters["@bank_ID"].Value = bank_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringAgreement table by a foreign key.
		/// </summary>
		public static void DeleteAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementDeleteAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsFactoringAgreement table.
		/// </summary>
		public static tbl_bpsFactoringAgreement Select(string factoringAgreement_ID_Incoming, string factoringAgreement_Revision_Incoming){

			tbl_bpsFactoringAgreement tbl_bpsFactoringAgreementins = new tbl_bpsFactoringAgreement();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@factoringAgreement_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@factoringAgreement_Revision", SqlDbType.VarChar,2);
			scom.Parameters["@factoringAgreement_ID"].Value = factoringAgreement_ID_Incoming;
			scom.Parameters["@factoringAgreement_Revision"].Value = factoringAgreement_Revision_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsFactoringAgreementins = Maketbl_bpsFactoringAgreement(dataReader);
				} else {
					tbl_bpsFactoringAgreementins = null;
				}
			}
			scon.Close();
			return tbl_bpsFactoringAgreementins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringAgreement table.
		/// </summary>
		public static List<tbl_bpsFactoringAgreement> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsFactoringAgreement> tbl_bpsFactoringAgreementList = new List<tbl_bpsFactoringAgreement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsFactoringAgreement tbl_bpsFactoringAgreement = Maketbl_bpsFactoringAgreement(dataReader);
					tbl_bpsFactoringAgreementList.Add(tbl_bpsFactoringAgreement);
				}
			}
			scon.Close();
			return tbl_bpsFactoringAgreementList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringAgreement table by a foreign key.
		/// </summary>
		public static List<tbl_bpsFactoringAgreement> SelectAllByFactoringInterest_ID(string factoringInterest_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementSelectAllByFactoringInterest_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@factoringInterest_ID", SqlDbType.VarChar,20);
			scom.Parameters["@factoringInterest_ID"].Value = factoringInterest_ID;
				List<tbl_bpsFactoringAgreement> tbl_bpsFactoringAgreementList = new List<tbl_bpsFactoringAgreement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsFactoringAgreement tbl_bpsFactoringAgreement = Maketbl_bpsFactoringAgreement(dataReader);
					tbl_bpsFactoringAgreementList.Add(tbl_bpsFactoringAgreement);
				}
			}
			scon.Close();
			return tbl_bpsFactoringAgreementList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringAgreement table by a foreign key.
		/// </summary>
		public static List<tbl_bpsFactoringAgreement> SelectAllByBank_ID(string bank_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementSelectAllByBank_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bank_ID", SqlDbType.VarChar,20);
			scom.Parameters["@bank_ID"].Value = bank_ID;
				List<tbl_bpsFactoringAgreement> tbl_bpsFactoringAgreementList = new List<tbl_bpsFactoringAgreement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsFactoringAgreement tbl_bpsFactoringAgreement = Maketbl_bpsFactoringAgreement(dataReader);
					tbl_bpsFactoringAgreementList.Add(tbl_bpsFactoringAgreement);
				}
			}
			scon.Close();
			return tbl_bpsFactoringAgreementList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringAgreement table by a foreign key.
		/// </summary>
		public static List<tbl_bpsFactoringAgreement> SelectAllByBranch_ID(string branch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringAgreementSelectAllByBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,10);
			scom.Parameters["@branch_ID"].Value = branch_ID;
				List<tbl_bpsFactoringAgreement> tbl_bpsFactoringAgreementList = new List<tbl_bpsFactoringAgreement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsFactoringAgreement tbl_bpsFactoringAgreement = Maketbl_bpsFactoringAgreement(dataReader);
					tbl_bpsFactoringAgreementList.Add(tbl_bpsFactoringAgreement);
				}
			}
			scon.Close();
			return tbl_bpsFactoringAgreementList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsFactoringAgreement class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsFactoringAgreement Maketbl_bpsFactoringAgreement(SqlDataReader dataReader) {
			tbl_bpsFactoringAgreement tbl_bpsFactoringAgreement = new tbl_bpsFactoringAgreement();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsFactoringAgreement.FactoringAgreement_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsFactoringAgreement.FactoringAgreement_Revision = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsFactoringAgreement.Ref1 = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsFactoringAgreement.Ref2 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsFactoringAgreement.Remarks = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsFactoringAgreement.Attachment_ID = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsFactoringAgreement.AgreementValidity_From = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsFactoringAgreement.AgreementValidity_To = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsFactoringAgreement.AccountNumber_Factoring = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsFactoringAgreement.AccountNumber_Current = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsFactoringAgreement.AccountNumber_Clearing = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsFactoringAgreement.Bank_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsFactoringAgreement.Branch_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsFactoringAgreement.Credit_Limit = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsFactoringAgreement.Factoring_Rate = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsFactoringAgreement.Credit_Period = dataReader.GetInt32(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsFactoringAgreement.Recourse_Period = dataReader.GetInt32(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsFactoringAgreement.ServiceCharge_presentage = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsFactoringAgreement.ServiceCharge_min = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsFactoringAgreement.FactoringInterest_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_bpsFactoringAgreement.IsActive = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_bpsFactoringAgreement.CreateUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_bpsFactoringAgreement.ModifiedUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_bpsFactoringAgreement.CheckedUser_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_bpsFactoringAgreement.ApprovedUser_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_bpsFactoringAgreement.DeletedUser_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_bpsFactoringAgreement.PrintedUser_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_bpsFactoringAgreement.CreateTerminal_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_bpsFactoringAgreement.ModifiedTerminal_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_bpsFactoringAgreement.DeletedTerminal_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_bpsFactoringAgreement.PrintedTerminal_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_bpsFactoringAgreement.DateCreate = dataReader.GetDateTime(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_bpsFactoringAgreement.DateModified = dataReader.GetDateTime(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_bpsFactoringAgreement.DateChecked = dataReader.GetDateTime(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_bpsFactoringAgreement.DateApproved = dataReader.GetDateTime(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_bpsFactoringAgreement.DateDeleted = dataReader.GetDateTime(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_bpsFactoringAgreement.DatePrinted = dataReader.GetDateTime(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_bpsFactoringAgreement.IsDeleted = dataReader.GetBoolean(37);
			}

			return tbl_bpsFactoringAgreement;
		}
		/// <summary>
		/// This makes tbl_bpsFactoringAgreement datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsFactoringAgreement object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsFactoringAgreement  tbl_bpsFactoringAgreement   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_factoringAgreement_ID = new DataColumn("factoringAgreement_ID" , typeof(string));
			DataColumn col_factoringAgreement_Revision = new DataColumn("factoringAgreement_Revision" , typeof(string));
			DataColumn col_ref1 = new DataColumn("ref1" , typeof(string));
			DataColumn col_ref2 = new DataColumn("ref2" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_attachment_ID = new DataColumn("attachment_ID" , typeof(int));
			DataColumn col_agreementValidity_From = new DataColumn("agreementValidity_From" , typeof(DateTime));
			DataColumn col_agreementValidity_To = new DataColumn("agreementValidity_To" , typeof(DateTime));
			DataColumn col_accountNumber_Factoring = new DataColumn("accountNumber_Factoring" , typeof(string));
			DataColumn col_accountNumber_Current = new DataColumn("accountNumber_Current" , typeof(string));
			DataColumn col_accountNumber_Clearing = new DataColumn("accountNumber_Clearing" , typeof(string));
			DataColumn col_bank_ID = new DataColumn("bank_ID" , typeof(string));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_credit_Limit = new DataColumn("credit_Limit" , typeof(decimal));
			DataColumn col_factoring_Rate = new DataColumn("factoring_Rate" , typeof(decimal));
			DataColumn col_credit_Period = new DataColumn("credit_Period" , typeof(int));
			DataColumn col_Recourse_Period = new DataColumn("Recourse_Period" , typeof(int));
			DataColumn col_serviceCharge_presentage = new DataColumn("serviceCharge_presentage" , typeof(decimal));
			DataColumn col_serviceCharge_min = new DataColumn("serviceCharge_min" , typeof(decimal));
			DataColumn col_factoringInterest_ID = new DataColumn("factoringInterest_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
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
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_factoringAgreement_ID,col_factoringAgreement_Revision,col_ref1,col_ref2,col_remarks,col_attachment_ID,col_agreementValidity_From,col_agreementValidity_To,col_accountNumber_Factoring,col_accountNumber_Current,col_accountNumber_Clearing,col_bank_ID,col_branch_ID,col_credit_Limit,col_factoring_Rate,col_credit_Period,col_Recourse_Period,col_serviceCharge_presentage,col_serviceCharge_min,col_factoringInterest_ID,col_isActive,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsFactoringAgreement datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsFactoringAgreement object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsFactoringAgreement user) {
		DataRow drow = dt.NewRow();
		
			drow["factoringAgreement_ID"] = user.factoringAgreement_ID;
			drow["factoringAgreement_Revision"] = user.factoringAgreement_Revision;
			drow["ref1"] = user.ref1;
			drow["ref2"] = user.ref2;
			drow["remarks"] = user.remarks;
			drow["attachment_ID"] = user.attachment_ID;
			drow["agreementValidity_From"] = user.agreementValidity_From;
			drow["agreementValidity_To"] = user.agreementValidity_To;
			drow["accountNumber_Factoring"] = user.accountNumber_Factoring;
			drow["accountNumber_Current"] = user.accountNumber_Current;
			drow["accountNumber_Clearing"] = user.accountNumber_Clearing;
			drow["bank_ID"] = user.bank_ID;
			drow["branch_ID"] = user.branch_ID;
			drow["credit_Limit"] = user.credit_Limit;
			drow["factoring_Rate"] = user.factoring_Rate;
			drow["credit_Period"] = user.credit_Period;
			drow["Recourse_Period"] = user.Recourse_Period;
			drow["serviceCharge_presentage"] = user.serviceCharge_presentage;
			drow["serviceCharge_min"] = user.serviceCharge_min;
			drow["factoringInterest_ID"] = user.factoringInterest_ID;
			drow["isActive"] = user.isActive;
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
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
