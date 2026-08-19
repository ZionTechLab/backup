using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsFactoringSchedule {
		#region Fields
		private string factoringSehedule_ID;
		private DateTime factoringSeheduleDate;
		private string factoringAgreement_ID;
		private string factoringAgreement_Revision;
		private string remark;
		private decimal nbtPercentage;
		private decimal vatPercentage;
		private decimal otherTaxPercentage;
		private decimal faceAmount;
		private decimal factoringAmount;
		private decimal serviceCharges;
		private decimal nbtTotal;
		private decimal vatTotal;
		private decimal otherTaxTotal;
		private decimal grossFactoringAmount;
		private decimal pendingAmount;
		private int noOfCheques;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string deletedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string printedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deletedTerminal_ID;
		private string checkedTerminal_ID;
		private string approvedTerminal_ID;
		private string printedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateDeleted;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime datePrinted;
		private bool isChecked;
		private bool isApproved;
		private DateTime approvedDate;
		private bool isDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsFactoringSchedule class.
		/// </summary>
		public tbl_bpsFactoringSchedule() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsFactoringSchedule class.
		/// </summary>
		public tbl_bpsFactoringSchedule(string factoringSehedule_ID, DateTime factoringSeheduleDate, string factoringAgreement_ID, string factoringAgreement_Revision, string remark, decimal nbtPercentage, decimal vatPercentage, decimal otherTaxPercentage, decimal faceAmount, decimal factoringAmount, decimal serviceCharges, decimal nbtTotal, decimal vatTotal, decimal otherTaxTotal, decimal grossFactoringAmount, decimal pendingAmount, int noOfCheques, string createUser_ID, string modifiedUser_ID, string deletedUser_ID, string checkedUser_ID, string approvedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string checkedTerminal_ID, string approvedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateDeleted, DateTime dateChecked, DateTime dateApproved, DateTime datePrinted, bool isChecked, bool isApproved, DateTime approvedDate, bool isDeleted) {
			this.factoringSehedule_ID = factoringSehedule_ID;
			this.factoringSeheduleDate = factoringSeheduleDate;
			this.factoringAgreement_ID = factoringAgreement_ID;
			this.factoringAgreement_Revision = factoringAgreement_Revision;
			this.remark = remark;
			this.nbtPercentage = nbtPercentage;
			this.vatPercentage = vatPercentage;
			this.otherTaxPercentage = otherTaxPercentage;
			this.faceAmount = faceAmount;
			this.factoringAmount = factoringAmount;
			this.serviceCharges = serviceCharges;
			this.nbtTotal = nbtTotal;
			this.vatTotal = vatTotal;
			this.otherTaxTotal = otherTaxTotal;
			this.grossFactoringAmount = grossFactoringAmount;
			this.pendingAmount = pendingAmount;
			this.noOfCheques = noOfCheques;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.deletedUser_ID = deletedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.printedUser_ID = printedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deletedTerminal_ID = deletedTerminal_ID;
			this.checkedTerminal_ID = checkedTerminal_ID;
			this.approvedTerminal_ID = approvedTerminal_ID;
			this.printedTerminal_ID = printedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateDeleted = dateDeleted;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.datePrinted = datePrinted;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.approvedDate = approvedDate;
			this.isDeleted = isDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FactoringSehedule_ID value.
		/// </summary>
		public string FactoringSehedule_ID {
			get { return factoringSehedule_ID; }
			set { factoringSehedule_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FactoringSeheduleDate value.
		/// </summary>
		public DateTime FactoringSeheduleDate {
			get { return factoringSeheduleDate; }
			set { factoringSeheduleDate = value; }
		}
		
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
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the NbtPercentage value.
		/// </summary>
		public decimal NbtPercentage {
			get { return nbtPercentage; }
			set { nbtPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatPercentage value.
		/// </summary>
		public decimal VatPercentage {
			get { return vatPercentage; }
			set { vatPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the OtherTaxPercentage value.
		/// </summary>
		public decimal OtherTaxPercentage {
			get { return otherTaxPercentage; }
			set { otherTaxPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the FaceAmount value.
		/// </summary>
		public decimal FaceAmount {
			get { return faceAmount; }
			set { faceAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the FactoringAmount value.
		/// </summary>
		public decimal FactoringAmount {
			get { return factoringAmount; }
			set { factoringAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ServiceCharges value.
		/// </summary>
		public decimal ServiceCharges {
			get { return serviceCharges; }
			set { serviceCharges = value; }
		}
		
		/// <summary>
		/// Gets or sets the NbtTotal value.
		/// </summary>
		public decimal NbtTotal {
			get { return nbtTotal; }
			set { nbtTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the VatTotal value.
		/// </summary>
		public decimal VatTotal {
			get { return vatTotal; }
			set { vatTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the OtherTaxTotal value.
		/// </summary>
		public decimal OtherTaxTotal {
			get { return otherTaxTotal; }
			set { otherTaxTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrossFactoringAmount value.
		/// </summary>
		public decimal GrossFactoringAmount {
			get { return grossFactoringAmount; }
			set { grossFactoringAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the PendingAmount value.
		/// </summary>
		public decimal PendingAmount {
			get { return pendingAmount; }
			set { pendingAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoOfCheques value.
		/// </summary>
		public int NoOfCheques {
			get { return noOfCheques; }
			set { noOfCheques = value; }
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
		/// Gets or sets the DeletedUser_ID value.
		/// </summary>
		public string DeletedUser_ID {
			get { return deletedUser_ID; }
			set { deletedUser_ID = value; }
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
		/// Gets or sets the DateDeleted value.
		/// </summary>
		public DateTime DateDeleted {
			get { return dateDeleted; }
			set { dateDeleted = value; }
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
		/// Gets or sets the ApprovedDate value.
		/// </summary>
		public DateTime ApprovedDate {
			get { return approvedDate; }
			set { approvedDate = value; }
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
		/// Saves a record to the tbl_bpsFactoringSchedule table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringScheduleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@factoringSehedule_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@factoringSeheduleDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@factoringAgreement_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@factoringAgreement_Revision", SqlDbType.VarChar,2);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@faceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoringAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@serviceCharges", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossFactoringAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@pendingAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noOfCheques", SqlDbType.Int,4);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@approvedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@factoringSehedule_ID"].Value = factoringSehedule_ID;
			scom.Parameters["@factoringSeheduleDate"].Value = factoringSeheduleDate;
			scom.Parameters["@factoringAgreement_ID"].Value = factoringAgreement_ID;
			scom.Parameters["@factoringAgreement_Revision"].Value = factoringAgreement_Revision;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
			scom.Parameters["@vatPercentage"].Value = vatPercentage;
			scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
			scom.Parameters["@faceAmount"].Value = faceAmount;
			scom.Parameters["@factoringAmount"].Value = factoringAmount;
			scom.Parameters["@serviceCharges"].Value = serviceCharges;
			scom.Parameters["@nbtTotal"].Value = nbtTotal;
			scom.Parameters["@vatTotal"].Value = vatTotal;
			scom.Parameters["@otherTaxTotal"].Value = otherTaxTotal;
			scom.Parameters["@grossFactoringAmount"].Value = grossFactoringAmount;
			scom.Parameters["@pendingAmount"].Value = pendingAmount;
			scom.Parameters["@noOfCheques"].Value = noOfCheques;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@approvedDate"].Value = approvedDate;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsFactoringSchedule table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringScheduleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@factoringSehedule_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@factoringSeheduleDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@factoringAgreement_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@factoringAgreement_Revision", SqlDbType.VarChar,2);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@nbtPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@faceAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@factoringAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@serviceCharges", SqlDbType.Decimal,9);
			scom.Parameters.Add("@nbtTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@vatTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@otherTaxTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossFactoringAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@pendingAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noOfCheques", SqlDbType.Int,4);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@printedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@approvedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@factoringSehedule_ID"].Value = factoringSehedule_ID;
			scom.Parameters["@factoringSeheduleDate"].Value = factoringSeheduleDate;
			scom.Parameters["@factoringAgreement_ID"].Value = factoringAgreement_ID;
			scom.Parameters["@factoringAgreement_Revision"].Value = factoringAgreement_Revision;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@nbtPercentage"].Value = nbtPercentage;
			scom.Parameters["@vatPercentage"].Value = vatPercentage;
			scom.Parameters["@otherTaxPercentage"].Value = otherTaxPercentage;
			scom.Parameters["@faceAmount"].Value = faceAmount;
			scom.Parameters["@factoringAmount"].Value = factoringAmount;
			scom.Parameters["@serviceCharges"].Value = serviceCharges;
			scom.Parameters["@nbtTotal"].Value = nbtTotal;
			scom.Parameters["@vatTotal"].Value = vatTotal;
			scom.Parameters["@otherTaxTotal"].Value = otherTaxTotal;
			scom.Parameters["@grossFactoringAmount"].Value = grossFactoringAmount;
			scom.Parameters["@pendingAmount"].Value = pendingAmount;
			scom.Parameters["@noOfCheques"].Value = noOfCheques;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@printedTerminal_ID"].Value = printedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@approvedDate"].Value = approvedDate;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsFactoringSchedule table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringScheduleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@factoringSehedule_ID", SqlDbType.VarChar,20);
			scom.Parameters["@factoringSehedule_ID"].Value = factoringSehedule_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringSchedule table by a foreign key.
		/// </summary>
		public static void DeleteAllByFactoringAgreement_ID_FactoringAgreement_Revision(string factoringAgreement_ID, string factoringAgreement_Revision) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringScheduleDeleteAllByFactoringAgreement_ID_FactoringAgreement_Revision", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@factoringAgreement_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@factoringAgreement_Revision", SqlDbType.VarChar,2);
			scom.Parameters["@factoringAgreement_ID"].Value = factoringAgreement_ID;
			scom.Parameters["@factoringAgreement_Revision"].Value = factoringAgreement_Revision;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsFactoringSchedule table.
		/// </summary>
		public static tbl_bpsFactoringSchedule Select(string factoringSehedule_ID_Incoming){

			tbl_bpsFactoringSchedule tbl_bpsFactoringScheduleins = new tbl_bpsFactoringSchedule();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringScheduleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@factoringSehedule_ID", SqlDbType.VarChar,20);
			scom.Parameters["@factoringSehedule_ID"].Value = factoringSehedule_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsFactoringScheduleins = Maketbl_bpsFactoringSchedule(dataReader);
				} else {
					tbl_bpsFactoringScheduleins = null;
				}
			}
			scon.Close();
			return tbl_bpsFactoringScheduleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringSchedule table.
		/// </summary>
		public static List<tbl_bpsFactoringSchedule> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringScheduleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsFactoringSchedule> tbl_bpsFactoringScheduleList = new List<tbl_bpsFactoringSchedule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsFactoringSchedule tbl_bpsFactoringSchedule = Maketbl_bpsFactoringSchedule(dataReader);
					tbl_bpsFactoringScheduleList.Add(tbl_bpsFactoringSchedule);
				}
			}
			scon.Close();
			return tbl_bpsFactoringScheduleList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsFactoringSchedule table by a foreign key.
		/// </summary>
		public static List<tbl_bpsFactoringSchedule> SelectAllByFactoringAgreement_ID_FactoringAgreement_Revision(string factoringAgreement_ID, string factoringAgreement_Revision) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsFactoringScheduleSelectAllByFactoringAgreement_ID_FactoringAgreement_Revision", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@factoringAgreement_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@factoringAgreement_Revision", SqlDbType.VarChar,2);
			scom.Parameters["@factoringAgreement_ID"].Value = factoringAgreement_ID;
			scom.Parameters["@factoringAgreement_Revision"].Value = factoringAgreement_Revision;
				List<tbl_bpsFactoringSchedule> tbl_bpsFactoringScheduleList = new List<tbl_bpsFactoringSchedule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsFactoringSchedule tbl_bpsFactoringSchedule = Maketbl_bpsFactoringSchedule(dataReader);
					tbl_bpsFactoringScheduleList.Add(tbl_bpsFactoringSchedule);
				}
			}
			scon.Close();
			return tbl_bpsFactoringScheduleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsFactoringSchedule class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsFactoringSchedule Maketbl_bpsFactoringSchedule(SqlDataReader dataReader) {
			tbl_bpsFactoringSchedule tbl_bpsFactoringSchedule = new tbl_bpsFactoringSchedule();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsFactoringSchedule.FactoringSehedule_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsFactoringSchedule.FactoringSeheduleDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsFactoringSchedule.FactoringAgreement_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsFactoringSchedule.FactoringAgreement_Revision = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsFactoringSchedule.Remark = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsFactoringSchedule.NbtPercentage = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsFactoringSchedule.VatPercentage = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsFactoringSchedule.OtherTaxPercentage = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsFactoringSchedule.FaceAmount = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsFactoringSchedule.FactoringAmount = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsFactoringSchedule.ServiceCharges = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsFactoringSchedule.NbtTotal = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsFactoringSchedule.VatTotal = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsFactoringSchedule.OtherTaxTotal = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsFactoringSchedule.GrossFactoringAmount = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsFactoringSchedule.PendingAmount = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsFactoringSchedule.NoOfCheques = dataReader.GetInt32(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsFactoringSchedule.CreateUser_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsFactoringSchedule.ModifiedUser_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsFactoringSchedule.DeletedUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_bpsFactoringSchedule.CheckedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_bpsFactoringSchedule.ApprovedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_bpsFactoringSchedule.PrintedUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_bpsFactoringSchedule.CreateTerminal_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_bpsFactoringSchedule.ModifiedTerminal_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_bpsFactoringSchedule.DeletedTerminal_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_bpsFactoringSchedule.CheckedTerminal_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_bpsFactoringSchedule.ApprovedTerminal_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_bpsFactoringSchedule.PrintedTerminal_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_bpsFactoringSchedule.DateCreate = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_bpsFactoringSchedule.DateModified = dataReader.GetDateTime(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_bpsFactoringSchedule.DateDeleted = dataReader.GetDateTime(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_bpsFactoringSchedule.DateChecked = dataReader.GetDateTime(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_bpsFactoringSchedule.DateApproved = dataReader.GetDateTime(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_bpsFactoringSchedule.DatePrinted = dataReader.GetDateTime(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_bpsFactoringSchedule.IsChecked = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_bpsFactoringSchedule.IsApproved = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_bpsFactoringSchedule.ApprovedDate = dataReader.GetDateTime(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_bpsFactoringSchedule.IsDeleted = dataReader.GetBoolean(38);
			}

			return tbl_bpsFactoringSchedule;
		}
		/// <summary>
		/// This makes tbl_bpsFactoringSchedule datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsFactoringSchedule object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsFactoringSchedule  tbl_bpsFactoringSchedule   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_factoringSehedule_ID = new DataColumn("factoringSehedule_ID" , typeof(string));
			DataColumn col_factoringSeheduleDate = new DataColumn("factoringSeheduleDate" , typeof(DateTime));
			DataColumn col_factoringAgreement_ID = new DataColumn("factoringAgreement_ID" , typeof(string));
			DataColumn col_factoringAgreement_Revision = new DataColumn("factoringAgreement_Revision" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_nbtPercentage = new DataColumn("nbtPercentage" , typeof(decimal));
			DataColumn col_vatPercentage = new DataColumn("vatPercentage" , typeof(decimal));
			DataColumn col_otherTaxPercentage = new DataColumn("otherTaxPercentage" , typeof(decimal));
			DataColumn col_faceAmount = new DataColumn("faceAmount" , typeof(decimal));
			DataColumn col_factoringAmount = new DataColumn("factoringAmount" , typeof(decimal));
			DataColumn col_serviceCharges = new DataColumn("serviceCharges" , typeof(decimal));
			DataColumn col_nbtTotal = new DataColumn("nbtTotal" , typeof(decimal));
			DataColumn col_vatTotal = new DataColumn("vatTotal" , typeof(decimal));
			DataColumn col_otherTaxTotal = new DataColumn("otherTaxTotal" , typeof(decimal));
			DataColumn col_grossFactoringAmount = new DataColumn("grossFactoringAmount" , typeof(decimal));
			DataColumn col_pendingAmount = new DataColumn("pendingAmount" , typeof(decimal));
			DataColumn col_noOfCheques = new DataColumn("noOfCheques" , typeof(int));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_deletedUser_ID = new DataColumn("deletedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_printedUser_ID = new DataColumn("printedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID" , typeof(string));
			DataColumn col_checkedTerminal_ID = new DataColumn("checkedTerminal_ID" , typeof(string));
			DataColumn col_approvedTerminal_ID = new DataColumn("approvedTerminal_ID" , typeof(string));
			DataColumn col_printedTerminal_ID = new DataColumn("printedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateDeleted = new DataColumn("dateDeleted" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_datePrinted = new DataColumn("datePrinted" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_approvedDate = new DataColumn("approvedDate" , typeof(DateTime));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_factoringSehedule_ID,col_factoringSeheduleDate,col_factoringAgreement_ID,col_factoringAgreement_Revision,col_remark,col_nbtPercentage,col_vatPercentage,col_otherTaxPercentage,col_faceAmount,col_factoringAmount,col_serviceCharges,col_nbtTotal,col_vatTotal,col_otherTaxTotal,col_grossFactoringAmount,col_pendingAmount,col_noOfCheques,col_createUser_ID,col_modifiedUser_ID,col_deletedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_checkedTerminal_ID,col_approvedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateDeleted,col_dateChecked,col_dateApproved,col_datePrinted,col_isChecked,col_isApproved,col_approvedDate,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsFactoringSchedule datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsFactoringSchedule object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsFactoringSchedule user) {
		DataRow drow = dt.NewRow();
		
			drow["factoringSehedule_ID"] = user.factoringSehedule_ID;
			drow["factoringSeheduleDate"] = user.factoringSeheduleDate;
			drow["factoringAgreement_ID"] = user.factoringAgreement_ID;
			drow["factoringAgreement_Revision"] = user.factoringAgreement_Revision;
			drow["remark"] = user.remark;
			drow["nbtPercentage"] = user.nbtPercentage;
			drow["vatPercentage"] = user.vatPercentage;
			drow["otherTaxPercentage"] = user.otherTaxPercentage;
			drow["faceAmount"] = user.faceAmount;
			drow["factoringAmount"] = user.factoringAmount;
			drow["serviceCharges"] = user.serviceCharges;
			drow["nbtTotal"] = user.nbtTotal;
			drow["vatTotal"] = user.vatTotal;
			drow["otherTaxTotal"] = user.otherTaxTotal;
			drow["grossFactoringAmount"] = user.grossFactoringAmount;
			drow["pendingAmount"] = user.pendingAmount;
			drow["noOfCheques"] = user.noOfCheques;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["deletedUser_ID"] = user.deletedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["printedUser_ID"] = user.printedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
			drow["checkedTerminal_ID"] = user.checkedTerminal_ID;
			drow["approvedTerminal_ID"] = user.approvedTerminal_ID;
			drow["printedTerminal_ID"] = user.printedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateDeleted"] = user.dateDeleted;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["datePrinted"] = user.datePrinted;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["approvedDate"] = user.approvedDate;
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
