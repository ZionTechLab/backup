using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsWorkInProgress_Machine_ItemSerials {
		#region Fields
		private string itemSerialNo;
		private int up1;
		private int up2;
		private string productionJob_ID;
		private string workInProgress_ID;
		private int line_No;
		private string prePlan_ID;
		private string section_ID;
		private string machine_ID;
		private decimal ups;
		private decimal grossLength;
		private decimal spoolWeight;
		private decimal grossWeigh;
		private string rollNumber;
		private string item_ID;
		private string operator_ID;
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
		private bool isIssued;
		private DateTime dateIssued;
		private int printCount;
		private decimal nOS;
		private decimal joints;
		private int noOfCopies;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsWorkInProgress_Machine_ItemSerials class.
		/// </summary>
		public tbl_pmsWorkInProgress_Machine_ItemSerials() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsWorkInProgress_Machine_ItemSerials class.
		/// </summary>
		public tbl_pmsWorkInProgress_Machine_ItemSerials(string itemSerialNo, int up1, int up2, string productionJob_ID, string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID, decimal ups, decimal grossLength, decimal spoolWeight, decimal grossWeigh, string rollNumber, string item_ID, string operator_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isIssued, DateTime dateIssued, int printCount, decimal nOS, decimal joints, int noOfCopies) {
			this.itemSerialNo = itemSerialNo;
			this.up1 = up1;
			this.up2 = up2;
			this.productionJob_ID = productionJob_ID;
			this.workInProgress_ID = workInProgress_ID;
			this.line_No = line_No;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.machine_ID = machine_ID;
			this.ups = ups;
			this.grossLength = grossLength;
			this.spoolWeight = spoolWeight;
			this.grossWeigh = grossWeigh;
			this.rollNumber = rollNumber;
			this.item_ID = item_ID;
			this.operator_ID = operator_ID;
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
			this.isIssued = isIssued;
			this.dateIssued = dateIssued;
			this.printCount = printCount;
			this.nOS = nOS;
			this.joints = joints;
			this.noOfCopies = noOfCopies;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Up1 value.
		/// </summary>
		public int Up1 {
			get { return up1; }
			set { up1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Up2 value.
		/// </summary>
		public int Up2 {
			get { return up2; }
			set { up2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkInProgress_ID value.
		/// </summary>
		public string WorkInProgress_ID {
			get { return workInProgress_ID; }
			set { workInProgress_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrePlan_ID value.
		/// </summary>
		public string PrePlan_ID {
			get { return prePlan_ID; }
			set { prePlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ups value.
		/// </summary>
		public decimal Ups {
			get { return ups; }
			set { ups = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrossLength value.
		/// </summary>
		public decimal GrossLength {
			get { return grossLength; }
			set { grossLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the SpoolWeight value.
		/// </summary>
		public decimal SpoolWeight {
			get { return spoolWeight; }
			set { spoolWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrossWeigh value.
		/// </summary>
		public decimal GrossWeigh {
			get { return grossWeigh; }
			set { grossWeigh = value; }
		}
		
		/// <summary>
		/// Gets or sets the RollNumber value.
		/// </summary>
		public string RollNumber {
			get { return rollNumber; }
			set { rollNumber = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Operator_ID value.
		/// </summary>
		public string Operator_ID {
			get { return operator_ID; }
			set { operator_ID = value; }
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
		/// Gets or sets the IsIssued value.
		/// </summary>
		public bool IsIssued {
			get { return isIssued; }
			set { isIssued = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateIssued value.
		/// </summary>
		public DateTime DateIssued {
			get { return dateIssued; }
			set { dateIssued = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the NOS value.
		/// </summary>
		public decimal NOS {
			get { return nOS; }
			set { nOS = value; }
		}
		
		/// <summary>
		/// Gets or sets the Joints value.
		/// </summary>
		public decimal Joints {
			get { return joints; }
			set { joints = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoOfCopies value.
		/// </summary>
		public int NoOfCopies {
			get { return noOfCopies; }
			set { noOfCopies = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsWorkInProgress_Machine_ItemSerials table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@up1", SqlDbType.Int,4);
			scom.Parameters.Add("@up2", SqlDbType.Int,4);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@ups", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossLength", SqlDbType.Decimal,9);
			scom.Parameters.Add("@spoolWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossWeigh", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rollNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@operator_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isIssued", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateIssued", SqlDbType.DateTime,8);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@nOS", SqlDbType.Decimal,9);
			scom.Parameters.Add("@joints", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noOfCopies", SqlDbType.Int,4);
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@up1"].Value = up1;
			scom.Parameters["@up2"].Value = up2;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@ups"].Value = ups;
			scom.Parameters["@grossLength"].Value = grossLength;
			scom.Parameters["@spoolWeight"].Value = spoolWeight;
			scom.Parameters["@grossWeigh"].Value = grossWeigh;
			scom.Parameters["@rollNumber"].Value = rollNumber;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@operator_ID"].Value = operator_ID;
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
			scom.Parameters["@isIssued"].Value = isIssued;
			scom.Parameters["@dateIssued"].Value = dateIssued;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@nOS"].Value = nOS;
			scom.Parameters["@joints"].Value = joints;
			scom.Parameters["@noOfCopies"].Value = noOfCopies;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsWorkInProgress_Machine_ItemSerials table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@up1", SqlDbType.Int,4);
			scom.Parameters.Add("@up2", SqlDbType.Int,4);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@ups", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossLength", SqlDbType.Decimal,9);
			scom.Parameters.Add("@spoolWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossWeigh", SqlDbType.Decimal,9);
			scom.Parameters.Add("@rollNumber", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@operator_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@isIssued", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateIssued", SqlDbType.DateTime,8);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@nOS", SqlDbType.Decimal,9);
			scom.Parameters.Add("@joints", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noOfCopies", SqlDbType.Int,4);
 
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@up1"].Value = up1;
			scom.Parameters["@up2"].Value = up2;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@ups"].Value = ups;
			scom.Parameters["@grossLength"].Value = grossLength;
			scom.Parameters["@spoolWeight"].Value = spoolWeight;
			scom.Parameters["@grossWeigh"].Value = grossWeigh;
			scom.Parameters["@rollNumber"].Value = rollNumber;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@operator_ID"].Value = operator_ID;
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
			scom.Parameters["@isIssued"].Value = isIssued;
			scom.Parameters["@dateIssued"].Value = dateIssued;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@nOS"].Value = nOS;
			scom.Parameters["@joints"].Value = joints;
			scom.Parameters["@noOfCopies"].Value = noOfCopies;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsWorkInProgress_Machine_ItemSerials table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_ItemSerials table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_ItemSerials table by a foreign key.
		/// </summary>
		public static void DeleteAllByWorkInProgress_ID(string workInProgress_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsDeleteAllByWorkInProgress_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_ItemSerials table by a foreign key.
		/// </summary>
		public static void DeleteAllByWorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID(string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsDeleteAllByWorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_ItemSerials table by a foreign key.
		/// </summary>
		public static void DeleteAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsDeleteAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsWorkInProgress_Machine_ItemSerials table.
		/// </summary>
		public static tbl_pmsWorkInProgress_Machine_ItemSerials Select(string itemSerialNo_Incoming){

			tbl_pmsWorkInProgress_Machine_ItemSerials tbl_pmsWorkInProgress_Machine_ItemSerialsins = new tbl_pmsWorkInProgress_Machine_ItemSerials();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_ItemSerialsins = Maketbl_pmsWorkInProgress_Machine_ItemSerials(dataReader);
				} else {
					tbl_pmsWorkInProgress_Machine_ItemSerialsins = null;
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_ItemSerialsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_ItemSerials table.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine_ItemSerials> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsWorkInProgress_Machine_ItemSerials> tbl_pmsWorkInProgress_Machine_ItemSerialsList = new List<tbl_pmsWorkInProgress_Machine_ItemSerials>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_ItemSerials tbl_pmsWorkInProgress_Machine_ItemSerials = Maketbl_pmsWorkInProgress_Machine_ItemSerials(dataReader);
					tbl_pmsWorkInProgress_Machine_ItemSerialsList.Add(tbl_pmsWorkInProgress_Machine_ItemSerials);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_ItemSerialsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_ItemSerials table by a foreign key.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine_ItemSerials> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_pmsWorkInProgress_Machine_ItemSerials> tbl_pmsWorkInProgress_Machine_ItemSerialsList = new List<tbl_pmsWorkInProgress_Machine_ItemSerials>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_ItemSerials tbl_pmsWorkInProgress_Machine_ItemSerials = Maketbl_pmsWorkInProgress_Machine_ItemSerials(dataReader);
					tbl_pmsWorkInProgress_Machine_ItemSerialsList.Add(tbl_pmsWorkInProgress_Machine_ItemSerials);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_ItemSerialsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_ItemSerials table by a foreign key.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine_ItemSerials> SelectAllByWorkInProgress_ID(string workInProgress_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsSelectAllByWorkInProgress_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
				List<tbl_pmsWorkInProgress_Machine_ItemSerials> tbl_pmsWorkInProgress_Machine_ItemSerialsList = new List<tbl_pmsWorkInProgress_Machine_ItemSerials>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_ItemSerials tbl_pmsWorkInProgress_Machine_ItemSerials = Maketbl_pmsWorkInProgress_Machine_ItemSerials(dataReader);
					tbl_pmsWorkInProgress_Machine_ItemSerialsList.Add(tbl_pmsWorkInProgress_Machine_ItemSerials);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_ItemSerialsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_ItemSerials table by a foreign key.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine_ItemSerials> SelectAllByWorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID(string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsSelectAllByWorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
				List<tbl_pmsWorkInProgress_Machine_ItemSerials> tbl_pmsWorkInProgress_Machine_ItemSerialsList = new List<tbl_pmsWorkInProgress_Machine_ItemSerials>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_ItemSerials tbl_pmsWorkInProgress_Machine_ItemSerials = Maketbl_pmsWorkInProgress_Machine_ItemSerials(dataReader);
					tbl_pmsWorkInProgress_Machine_ItemSerialsList.Add(tbl_pmsWorkInProgress_Machine_ItemSerials);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_ItemSerialsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine_ItemSerials table by a foreign key.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine_ItemSerials> SelectAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_Machine_ItemSerialsSelectAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
				List<tbl_pmsWorkInProgress_Machine_ItemSerials> tbl_pmsWorkInProgress_Machine_ItemSerialsList = new List<tbl_pmsWorkInProgress_Machine_ItemSerials>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine_ItemSerials tbl_pmsWorkInProgress_Machine_ItemSerials = Maketbl_pmsWorkInProgress_Machine_ItemSerials(dataReader);
					tbl_pmsWorkInProgress_Machine_ItemSerialsList.Add(tbl_pmsWorkInProgress_Machine_ItemSerials);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machine_ItemSerialsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsWorkInProgress_Machine_ItemSerials class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsWorkInProgress_Machine_ItemSerials Maketbl_pmsWorkInProgress_Machine_ItemSerials(SqlDataReader dataReader) {
			tbl_pmsWorkInProgress_Machine_ItemSerials tbl_pmsWorkInProgress_Machine_ItemSerials = new tbl_pmsWorkInProgress_Machine_ItemSerials();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.ItemSerialNo = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.Up1 = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.Up2 = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.ProductionJob_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.WorkInProgress_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.Line_No = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.PrePlan_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.Section_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.Machine_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.Ups = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.GrossLength = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.SpoolWeight = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.GrossWeigh = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.RollNumber = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.Item_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.Operator_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.CreateUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.ModifiedUser_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.CheckedUser_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.ApprovedUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.DeletedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.PrintedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.CreateTerminal_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.ModifiedTerminal_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.DeletedTerminal_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.PrintedTerminal_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.DateCreate = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.DateModified = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.DateChecked = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.DateApproved = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.DateDeleted = dataReader.GetDateTime(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.DatePrinted = dataReader.GetDateTime(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.IsChecked = dataReader.GetBoolean(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.IsApproved = dataReader.GetBoolean(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.IsFinished = dataReader.GetBoolean(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.IsDeleted = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.IsLocked = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.IsIssued = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.DateIssued = dataReader.GetDateTime(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.PrintCount = dataReader.GetInt32(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.NOS = dataReader.GetDecimal(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.Joints = dataReader.GetDecimal(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_pmsWorkInProgress_Machine_ItemSerials.NoOfCopies = dataReader.GetInt32(42);
			}

			return tbl_pmsWorkInProgress_Machine_ItemSerials;
		}
		/// <summary>
		/// This makes tbl_pmsWorkInProgress_Machine_ItemSerials datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsWorkInProgress_Machine_ItemSerials object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsWorkInProgress_Machine_ItemSerials  tbl_pmsWorkInProgress_Machine_ItemSerials   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_up1 = new DataColumn("up1" , typeof(int));
			DataColumn col_up2 = new DataColumn("up2" , typeof(int));
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_workInProgress_ID = new DataColumn("workInProgress_ID" , typeof(string));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prePlan_ID = new DataColumn("prePlan_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_ups = new DataColumn("ups" , typeof(decimal));
			DataColumn col_grossLength = new DataColumn("grossLength" , typeof(decimal));
			DataColumn col_spoolWeight = new DataColumn("spoolWeight" , typeof(decimal));
			DataColumn col_grossWeigh = new DataColumn("grossWeigh" , typeof(decimal));
			DataColumn col_rollNumber = new DataColumn("rollNumber" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_operator_ID = new DataColumn("operator_ID" , typeof(string));
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
			DataColumn col_isIssued = new DataColumn("isIssued" , typeof(bool));
			DataColumn col_dateIssued = new DataColumn("dateIssued" , typeof(DateTime));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_nOS = new DataColumn("nOS" , typeof(decimal));
			DataColumn col_joints = new DataColumn("joints" , typeof(decimal));
			DataColumn col_noOfCopies = new DataColumn("noOfCopies" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_itemSerialNo,col_up1,col_up2,col_productionJob_ID,col_workInProgress_ID,col_line_No,col_prePlan_ID,col_section_ID,col_machine_ID,col_ups,col_grossLength,col_spoolWeight,col_grossWeigh,col_rollNumber,col_item_ID,col_operator_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isIssued,col_dateIssued,col_printCount,col_nOS,col_joints,col_noOfCopies,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsWorkInProgress_Machine_ItemSerials datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsWorkInProgress_Machine_ItemSerials object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsWorkInProgress_Machine_ItemSerials user) {
		DataRow drow = dt.NewRow();
		
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["up1"] = user.up1;
			drow["up2"] = user.up2;
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["workInProgress_ID"] = user.workInProgress_ID;
			drow["line_No"] = user.line_No;
			drow["prePlan_ID"] = user.prePlan_ID;
			drow["section_ID"] = user.section_ID;
			drow["machine_ID"] = user.machine_ID;
			drow["ups"] = user.ups;
			drow["grossLength"] = user.grossLength;
			drow["spoolWeight"] = user.spoolWeight;
			drow["grossWeigh"] = user.grossWeigh;
			drow["rollNumber"] = user.rollNumber;
			drow["item_ID"] = user.item_ID;
			drow["operator_ID"] = user.operator_ID;
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
			drow["isIssued"] = user.isIssued;
			drow["dateIssued"] = user.dateIssued;
			drow["printCount"] = user.printCount;
			drow["nOS"] = user.nOS;
			drow["joints"] = user.joints;
			drow["noOfCopies"] = user.noOfCopies;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
