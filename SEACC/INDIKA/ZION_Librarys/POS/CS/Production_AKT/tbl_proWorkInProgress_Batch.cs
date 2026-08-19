using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_proWorkInProgress_Batch {
		#region Fields
		private int line_No;
		private string productionJob_ID;
		private string workInProgress_ID;
		private string batch_ID;
		private string section_ID;
		private string machine_ID;
		private DateTime dateStart;
		private DateTime dateEnd;
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
		private string employee_ID;
		private decimal extraHours_Idle;
		private decimal extraHours_Maintenance;
		private decimal extraHours_Labour;
		private decimal extraHours_Cleaning;
		private decimal extraHours_Approval;
		private decimal extraHours_JobSetting;
		private decimal extraHours_JobRunning;
		private decimal extraHours_Electricity;
		private decimal extraHours_FactoryCost;
		private decimal extraHours_MachineCost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_proWorkInProgress_Batch class.
		/// </summary>
		public tbl_proWorkInProgress_Batch() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_proWorkInProgress_Batch class.
		/// </summary>
		public tbl_proWorkInProgress_Batch(int line_No, string productionJob_ID, string workInProgress_ID, string batch_ID, string section_ID, string machine_ID, DateTime dateStart, DateTime dateEnd, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, string employee_ID, decimal extraHours_Idle, decimal extraHours_Maintenance, decimal extraHours_Labour, decimal extraHours_Cleaning, decimal extraHours_Approval, decimal extraHours_JobSetting, decimal extraHours_JobRunning, decimal extraHours_Electricity, decimal extraHours_FactoryCost, decimal extraHours_MachineCost) {
			this.line_No = line_No;
			this.productionJob_ID = productionJob_ID;
			this.workInProgress_ID = workInProgress_ID;
			this.batch_ID = batch_ID;
			this.section_ID = section_ID;
			this.machine_ID = machine_ID;
			this.dateStart = dateStart;
			this.dateEnd = dateEnd;
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
			this.employee_ID = employee_ID;
			this.extraHours_Idle = extraHours_Idle;
			this.extraHours_Maintenance = extraHours_Maintenance;
			this.extraHours_Labour = extraHours_Labour;
			this.extraHours_Cleaning = extraHours_Cleaning;
			this.extraHours_Approval = extraHours_Approval;
			this.extraHours_JobSetting = extraHours_JobSetting;
			this.extraHours_JobRunning = extraHours_JobRunning;
			this.extraHours_Electricity = extraHours_Electricity;
			this.extraHours_FactoryCost = extraHours_FactoryCost;
			this.extraHours_MachineCost = extraHours_MachineCost;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
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
		/// Gets or sets the Batch_ID value.
		/// </summary>
		public string Batch_ID {
			get { return batch_ID; }
			set { batch_ID = value; }
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
		/// Gets or sets the DateStart value.
		/// </summary>
		public DateTime DateStart {
			get { return dateStart; }
			set { dateStart = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateEnd value.
		/// </summary>
		public DateTime DateEnd {
			get { return dateEnd; }
			set { dateEnd = value; }
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
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Idle value.
		/// </summary>
		public decimal ExtraHours_Idle {
			get { return extraHours_Idle; }
			set { extraHours_Idle = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Maintenance value.
		/// </summary>
		public decimal ExtraHours_Maintenance {
			get { return extraHours_Maintenance; }
			set { extraHours_Maintenance = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Labour value.
		/// </summary>
		public decimal ExtraHours_Labour {
			get { return extraHours_Labour; }
			set { extraHours_Labour = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Cleaning value.
		/// </summary>
		public decimal ExtraHours_Cleaning {
			get { return extraHours_Cleaning; }
			set { extraHours_Cleaning = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Approval value.
		/// </summary>
		public decimal ExtraHours_Approval {
			get { return extraHours_Approval; }
			set { extraHours_Approval = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_JobSetting value.
		/// </summary>
		public decimal ExtraHours_JobSetting {
			get { return extraHours_JobSetting; }
			set { extraHours_JobSetting = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_JobRunning value.
		/// </summary>
		public decimal ExtraHours_JobRunning {
			get { return extraHours_JobRunning; }
			set { extraHours_JobRunning = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_Electricity value.
		/// </summary>
		public decimal ExtraHours_Electricity {
			get { return extraHours_Electricity; }
			set { extraHours_Electricity = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_FactoryCost value.
		/// </summary>
		public decimal ExtraHours_FactoryCost {
			get { return extraHours_FactoryCost; }
			set { extraHours_FactoryCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExtraHours_MachineCost value.
		/// </summary>
		public decimal ExtraHours_MachineCost {
			get { return extraHours_MachineCost; }
			set { extraHours_MachineCost = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_proWorkInProgress_Batch table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_BatchInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateEnd", SqlDbType.DateTime,8);
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
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@extraHours_Idle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Maintenance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Labour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Cleaning", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Approval", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_JobSetting", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_JobRunning", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Electricity", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_FactoryCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_MachineCost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@dateStart"].Value = dateStart;
			scom.Parameters["@dateEnd"].Value = dateEnd;
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
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@extraHours_Idle"].Value = extraHours_Idle;
			scom.Parameters["@extraHours_Maintenance"].Value = extraHours_Maintenance;
			scom.Parameters["@extraHours_Labour"].Value = extraHours_Labour;
			scom.Parameters["@extraHours_Cleaning"].Value = extraHours_Cleaning;
			scom.Parameters["@extraHours_Approval"].Value = extraHours_Approval;
			scom.Parameters["@extraHours_JobSetting"].Value = extraHours_JobSetting;
			scom.Parameters["@extraHours_JobRunning"].Value = extraHours_JobRunning;
			scom.Parameters["@extraHours_Electricity"].Value = extraHours_Electricity;
			scom.Parameters["@extraHours_FactoryCost"].Value = extraHours_FactoryCost;
			scom.Parameters["@extraHours_MachineCost"].Value = extraHours_MachineCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_proWorkInProgress_Batch table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_BatchUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateEnd", SqlDbType.DateTime,8);
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
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@extraHours_Idle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Maintenance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Labour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Cleaning", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Approval", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_JobSetting", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_JobRunning", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_Electricity", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_FactoryCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@extraHours_MachineCost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@batch_ID"].Value = batch_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@dateStart"].Value = dateStart;
			scom.Parameters["@dateEnd"].Value = dateEnd;
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
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@extraHours_Idle"].Value = extraHours_Idle;
			scom.Parameters["@extraHours_Maintenance"].Value = extraHours_Maintenance;
			scom.Parameters["@extraHours_Labour"].Value = extraHours_Labour;
			scom.Parameters["@extraHours_Cleaning"].Value = extraHours_Cleaning;
			scom.Parameters["@extraHours_Approval"].Value = extraHours_Approval;
			scom.Parameters["@extraHours_JobSetting"].Value = extraHours_JobSetting;
			scom.Parameters["@extraHours_JobRunning"].Value = extraHours_JobRunning;
			scom.Parameters["@extraHours_Electricity"].Value = extraHours_Electricity;
			scom.Parameters["@extraHours_FactoryCost"].Value = extraHours_FactoryCost;
			scom.Parameters["@extraHours_MachineCost"].Value = extraHours_MachineCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_proWorkInProgress_Batch table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_BatchDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
 
			scom.Parameters["@batch_ID"].Value = batch_ID;
 
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch table by a foreign key.
		/// </summary>
		public static void DeleteAllByWorkInProgress_ID(string workInProgress_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_BatchDeleteAllByWorkInProgress_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_proWorkInProgress_Batch table.
		/// </summary>
		public static tbl_proWorkInProgress_Batch Select(string workInProgress_ID_Incoming, string batch_ID_Incoming, string section_ID_Incoming, string machine_ID_Incoming){

			tbl_proWorkInProgress_Batch tbl_proWorkInProgress_Batchins = new tbl_proWorkInProgress_Batch();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_BatchSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID_Incoming;
			scom.Parameters["@batch_ID"].Value = batch_ID_Incoming;
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			scom.Parameters["@machine_ID"].Value = machine_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_proWorkInProgress_Batchins = Maketbl_proWorkInProgress_Batch(dataReader);
				} else {
					tbl_proWorkInProgress_Batchins = null;
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_Batchins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch table.
		/// </summary>
		public static List<tbl_proWorkInProgress_Batch> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_BatchSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_proWorkInProgress_Batch> tbl_proWorkInProgress_BatchList = new List<tbl_proWorkInProgress_Batch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_proWorkInProgress_Batch tbl_proWorkInProgress_Batch = Maketbl_proWorkInProgress_Batch(dataReader);
					tbl_proWorkInProgress_BatchList.Add(tbl_proWorkInProgress_Batch);
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_BatchList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_proWorkInProgress_Batch table by a foreign key.
		/// </summary>
		public static List<tbl_proWorkInProgress_Batch> SelectAllByWorkInProgress_ID(string workInProgress_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proWorkInProgress_BatchSelectAllByWorkInProgress_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
				List<tbl_proWorkInProgress_Batch> tbl_proWorkInProgress_BatchList = new List<tbl_proWorkInProgress_Batch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_proWorkInProgress_Batch tbl_proWorkInProgress_Batch = Maketbl_proWorkInProgress_Batch(dataReader);
					tbl_proWorkInProgress_BatchList.Add(tbl_proWorkInProgress_Batch);
				}
			}
			scon.Close();
			return tbl_proWorkInProgress_BatchList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_proWorkInProgress_Batch class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_proWorkInProgress_Batch Maketbl_proWorkInProgress_Batch(SqlDataReader dataReader) {
			tbl_proWorkInProgress_Batch tbl_proWorkInProgress_Batch = new tbl_proWorkInProgress_Batch();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_proWorkInProgress_Batch.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_proWorkInProgress_Batch.ProductionJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_proWorkInProgress_Batch.WorkInProgress_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_proWorkInProgress_Batch.Batch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_proWorkInProgress_Batch.Section_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_proWorkInProgress_Batch.Machine_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_proWorkInProgress_Batch.DateStart = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_proWorkInProgress_Batch.DateEnd = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_proWorkInProgress_Batch.CreateUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_proWorkInProgress_Batch.ModifiedUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_proWorkInProgress_Batch.CheckedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_proWorkInProgress_Batch.ApprovedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_proWorkInProgress_Batch.DeletedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_proWorkInProgress_Batch.PrintedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_proWorkInProgress_Batch.CreateTerminal_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_proWorkInProgress_Batch.ModifiedTerminal_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_proWorkInProgress_Batch.DeletedTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_proWorkInProgress_Batch.PrintedTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_proWorkInProgress_Batch.DateCreate = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_proWorkInProgress_Batch.DateModified = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_proWorkInProgress_Batch.DateChecked = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_proWorkInProgress_Batch.DateApproved = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_proWorkInProgress_Batch.DateDeleted = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_proWorkInProgress_Batch.DatePrinted = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_proWorkInProgress_Batch.Employee_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_proWorkInProgress_Batch.ExtraHours_Idle = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_proWorkInProgress_Batch.ExtraHours_Maintenance = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_proWorkInProgress_Batch.ExtraHours_Labour = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_proWorkInProgress_Batch.ExtraHours_Cleaning = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_proWorkInProgress_Batch.ExtraHours_Approval = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_proWorkInProgress_Batch.ExtraHours_JobSetting = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_proWorkInProgress_Batch.ExtraHours_JobRunning = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_proWorkInProgress_Batch.ExtraHours_Electricity = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_proWorkInProgress_Batch.ExtraHours_FactoryCost = dataReader.GetDecimal(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_proWorkInProgress_Batch.ExtraHours_MachineCost = dataReader.GetDecimal(34);
			}

			return tbl_proWorkInProgress_Batch;
		}
		/// <summary>
		/// This makes tbl_proWorkInProgress_Batch datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_proWorkInProgress_Batch object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_proWorkInProgress_Batch  tbl_proWorkInProgress_Batch   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_workInProgress_ID = new DataColumn("workInProgress_ID" , typeof(string));
			DataColumn col_batch_ID = new DataColumn("batch_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_dateStart = new DataColumn("dateStart" , typeof(DateTime));
			DataColumn col_dateEnd = new DataColumn("dateEnd" , typeof(DateTime));
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
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_extraHours_Idle = new DataColumn("extraHours_Idle" , typeof(decimal));
			DataColumn col_extraHours_Maintenance = new DataColumn("extraHours_Maintenance" , typeof(decimal));
			DataColumn col_extraHours_Labour = new DataColumn("extraHours_Labour" , typeof(decimal));
			DataColumn col_extraHours_Cleaning = new DataColumn("extraHours_Cleaning" , typeof(decimal));
			DataColumn col_extraHours_Approval = new DataColumn("extraHours_Approval" , typeof(decimal));
			DataColumn col_extraHours_JobSetting = new DataColumn("extraHours_JobSetting" , typeof(decimal));
			DataColumn col_extraHours_JobRunning = new DataColumn("extraHours_JobRunning" , typeof(decimal));
			DataColumn col_extraHours_Electricity = new DataColumn("extraHours_Electricity" , typeof(decimal));
			DataColumn col_extraHours_FactoryCost = new DataColumn("extraHours_FactoryCost" , typeof(decimal));
			DataColumn col_extraHours_MachineCost = new DataColumn("extraHours_MachineCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_productionJob_ID,col_workInProgress_ID,col_batch_ID,col_section_ID,col_machine_ID,col_dateStart,col_dateEnd,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_employee_ID,col_extraHours_Idle,col_extraHours_Maintenance,col_extraHours_Labour,col_extraHours_Cleaning,col_extraHours_Approval,col_extraHours_JobSetting,col_extraHours_JobRunning,col_extraHours_Electricity,col_extraHours_FactoryCost,col_extraHours_MachineCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_proWorkInProgress_Batch datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_proWorkInProgress_Batch object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_proWorkInProgress_Batch user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["workInProgress_ID"] = user.workInProgress_ID;
			drow["batch_ID"] = user.batch_ID;
			drow["section_ID"] = user.section_ID;
			drow["machine_ID"] = user.machine_ID;
			drow["dateStart"] = user.dateStart;
			drow["dateEnd"] = user.dateEnd;
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
			drow["employee_ID"] = user.employee_ID;
			drow["extraHours_Idle"] = user.extraHours_Idle;
			drow["extraHours_Maintenance"] = user.extraHours_Maintenance;
			drow["extraHours_Labour"] = user.extraHours_Labour;
			drow["extraHours_Cleaning"] = user.extraHours_Cleaning;
			drow["extraHours_Approval"] = user.extraHours_Approval;
			drow["extraHours_JobSetting"] = user.extraHours_JobSetting;
			drow["extraHours_JobRunning"] = user.extraHours_JobRunning;
			drow["extraHours_Electricity"] = user.extraHours_Electricity;
			drow["extraHours_FactoryCost"] = user.extraHours_FactoryCost;
			drow["extraHours_MachineCost"] = user.extraHours_MachineCost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
