using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_comCommissionCalculation {
		#region Fields
		private Int64 comCalcIndex;
		private Int64 periodIndex;
		private int roleOfEmplyee;
		private string salesRep_ID;
		private string areaManger_ID;
		private string salesManager_ID;
		private string collector_ID;
		private string remarks;
		private int chequePeriod_fromDays;
		private int chequePeriod_toDays;
		private decimal gross_commission_withVAT;
		private decimal ded_CRN_withVAT;
		private decimal ded_ChqDate_withVAT;
		private decimal ded_RchqThisPeriod_withVAT;
		private decimal ded_RchqPrvPeriod_withVAT;
		private decimal ded_SecurityDept_withVAT;
		private decimal ded_BillAdv_withVAT;
		private decimal ded_Loan_withVAT;
		private decimal ded_Advance_withVAT;
		private decimal net_commission_withVAT;
		private decimal gross_commission_withoutVAT;
		private decimal ded_CRN_withoutVAT;
		private decimal ded_ChqDate_withoutVAT;
		private decimal ded_RchqThisPeriod_withoutVAT;
		private decimal ded_RchqPrvPeriod_withoutVAT;
		private decimal ded_SecurityDept_withoutVAT;
		private decimal ded_BillAdv_withoutVAT;
		private decimal ded_Loan_withoutVAT;
		private decimal ded_Advance_withoutVAT;
		private decimal net_commission_withoutVAT;
		private bool isChecked;
		private bool isApproved;
		private bool isDeleted;
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
		private int printCount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_comCommissionCalculation class.
		/// </summary>
		public tbl_comCommissionCalculation() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_comCommissionCalculation class.
		/// </summary>
		public tbl_comCommissionCalculation(Int64 comCalcIndex, Int64 periodIndex, int roleOfEmplyee, string salesRep_ID, string areaManger_ID, string salesManager_ID, string collector_ID, string remarks, int chequePeriod_fromDays, int chequePeriod_toDays, decimal gross_commission_withVAT, decimal ded_CRN_withVAT, decimal ded_ChqDate_withVAT, decimal ded_RchqThisPeriod_withVAT, decimal ded_RchqPrvPeriod_withVAT, decimal ded_SecurityDept_withVAT, decimal ded_BillAdv_withVAT, decimal ded_Loan_withVAT, decimal ded_Advance_withVAT, decimal net_commission_withVAT, decimal gross_commission_withoutVAT, decimal ded_CRN_withoutVAT, decimal ded_ChqDate_withoutVAT, decimal ded_RchqThisPeriod_withoutVAT, decimal ded_RchqPrvPeriod_withoutVAT, decimal ded_SecurityDept_withoutVAT, decimal ded_BillAdv_withoutVAT, decimal ded_Loan_withoutVAT, decimal ded_Advance_withoutVAT, decimal net_commission_withoutVAT, bool isChecked, bool isApproved, bool isDeleted, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, int printCount) {
			this.comCalcIndex = comCalcIndex;
			this.periodIndex = periodIndex;
			this.roleOfEmplyee = roleOfEmplyee;
			this.salesRep_ID = salesRep_ID;
			this.areaManger_ID = areaManger_ID;
			this.salesManager_ID = salesManager_ID;
			this.collector_ID = collector_ID;
			this.remarks = remarks;
			this.chequePeriod_fromDays = chequePeriod_fromDays;
			this.chequePeriod_toDays = chequePeriod_toDays;
			this.gross_commission_withVAT = gross_commission_withVAT;
			this.ded_CRN_withVAT = ded_CRN_withVAT;
			this.ded_ChqDate_withVAT = ded_ChqDate_withVAT;
			this.ded_RchqThisPeriod_withVAT = ded_RchqThisPeriod_withVAT;
			this.ded_RchqPrvPeriod_withVAT = ded_RchqPrvPeriod_withVAT;
			this.ded_SecurityDept_withVAT = ded_SecurityDept_withVAT;
			this.ded_BillAdv_withVAT = ded_BillAdv_withVAT;
			this.ded_Loan_withVAT = ded_Loan_withVAT;
			this.ded_Advance_withVAT = ded_Advance_withVAT;
			this.net_commission_withVAT = net_commission_withVAT;
			this.gross_commission_withoutVAT = gross_commission_withoutVAT;
			this.ded_CRN_withoutVAT = ded_CRN_withoutVAT;
			this.ded_ChqDate_withoutVAT = ded_ChqDate_withoutVAT;
			this.ded_RchqThisPeriod_withoutVAT = ded_RchqThisPeriod_withoutVAT;
			this.ded_RchqPrvPeriod_withoutVAT = ded_RchqPrvPeriod_withoutVAT;
			this.ded_SecurityDept_withoutVAT = ded_SecurityDept_withoutVAT;
			this.ded_BillAdv_withoutVAT = ded_BillAdv_withoutVAT;
			this.ded_Loan_withoutVAT = ded_Loan_withoutVAT;
			this.ded_Advance_withoutVAT = ded_Advance_withoutVAT;
			this.net_commission_withoutVAT = net_commission_withoutVAT;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isDeleted = isDeleted;
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
			this.printCount = printCount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ComCalcIndex value.
		/// </summary>
		public Int64 ComCalcIndex {
			get { return comCalcIndex; }
			set { comCalcIndex = value; }
		}
		
		/// <summary>
		/// Gets or sets the PeriodIndex value.
		/// </summary>
		public Int64 PeriodIndex {
			get { return periodIndex; }
			set { periodIndex = value; }
		}
		
		/// <summary>
		/// Gets or sets the RoleOfEmplyee value.
		/// </summary>
		public int RoleOfEmplyee {
			get { return roleOfEmplyee; }
			set { roleOfEmplyee = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesRep_ID value.
		/// </summary>
		public string SalesRep_ID {
			get { return salesRep_ID; }
			set { salesRep_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AreaManger_ID value.
		/// </summary>
		public string AreaManger_ID {
			get { return areaManger_ID; }
			set { areaManger_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesManager_ID value.
		/// </summary>
		public string SalesManager_ID {
			get { return salesManager_ID; }
			set { salesManager_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Collector_ID value.
		/// </summary>
		public string Collector_ID {
			get { return collector_ID; }
			set { collector_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequePeriod_fromDays value.
		/// </summary>
		public int ChequePeriod_fromDays {
			get { return chequePeriod_fromDays; }
			set { chequePeriod_fromDays = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequePeriod_toDays value.
		/// </summary>
		public int ChequePeriod_toDays {
			get { return chequePeriod_toDays; }
			set { chequePeriod_toDays = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gross_commission_withVAT value.
		/// </summary>
		public decimal Gross_commission_withVAT {
			get { return gross_commission_withVAT; }
			set { gross_commission_withVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_CRN_withVAT value.
		/// </summary>
		public decimal Ded_CRN_withVAT {
			get { return ded_CRN_withVAT; }
			set { ded_CRN_withVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_ChqDate_withVAT value.
		/// </summary>
		public decimal Ded_ChqDate_withVAT {
			get { return ded_ChqDate_withVAT; }
			set { ded_ChqDate_withVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_RchqThisPeriod_withVAT value.
		/// </summary>
		public decimal Ded_RchqThisPeriod_withVAT {
			get { return ded_RchqThisPeriod_withVAT; }
			set { ded_RchqThisPeriod_withVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_RchqPrvPeriod_withVAT value.
		/// </summary>
		public decimal Ded_RchqPrvPeriod_withVAT {
			get { return ded_RchqPrvPeriod_withVAT; }
			set { ded_RchqPrvPeriod_withVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_SecurityDept_withVAT value.
		/// </summary>
		public decimal Ded_SecurityDept_withVAT {
			get { return ded_SecurityDept_withVAT; }
			set { ded_SecurityDept_withVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_BillAdv_withVAT value.
		/// </summary>
		public decimal Ded_BillAdv_withVAT {
			get { return ded_BillAdv_withVAT; }
			set { ded_BillAdv_withVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_Loan_withVAT value.
		/// </summary>
		public decimal Ded_Loan_withVAT {
			get { return ded_Loan_withVAT; }
			set { ded_Loan_withVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_Advance_withVAT value.
		/// </summary>
		public decimal Ded_Advance_withVAT {
			get { return ded_Advance_withVAT; }
			set { ded_Advance_withVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Net_commission_withVAT value.
		/// </summary>
		public decimal Net_commission_withVAT {
			get { return net_commission_withVAT; }
			set { net_commission_withVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gross_commission_withoutVAT value.
		/// </summary>
		public decimal Gross_commission_withoutVAT {
			get { return gross_commission_withoutVAT; }
			set { gross_commission_withoutVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_CRN_withoutVAT value.
		/// </summary>
		public decimal Ded_CRN_withoutVAT {
			get { return ded_CRN_withoutVAT; }
			set { ded_CRN_withoutVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_ChqDate_withoutVAT value.
		/// </summary>
		public decimal Ded_ChqDate_withoutVAT {
			get { return ded_ChqDate_withoutVAT; }
			set { ded_ChqDate_withoutVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_RchqThisPeriod_withoutVAT value.
		/// </summary>
		public decimal Ded_RchqThisPeriod_withoutVAT {
			get { return ded_RchqThisPeriod_withoutVAT; }
			set { ded_RchqThisPeriod_withoutVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_RchqPrvPeriod_withoutVAT value.
		/// </summary>
		public decimal Ded_RchqPrvPeriod_withoutVAT {
			get { return ded_RchqPrvPeriod_withoutVAT; }
			set { ded_RchqPrvPeriod_withoutVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_SecurityDept_withoutVAT value.
		/// </summary>
		public decimal Ded_SecurityDept_withoutVAT {
			get { return ded_SecurityDept_withoutVAT; }
			set { ded_SecurityDept_withoutVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_BillAdv_withoutVAT value.
		/// </summary>
		public decimal Ded_BillAdv_withoutVAT {
			get { return ded_BillAdv_withoutVAT; }
			set { ded_BillAdv_withoutVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_Loan_withoutVAT value.
		/// </summary>
		public decimal Ded_Loan_withoutVAT {
			get { return ded_Loan_withoutVAT; }
			set { ded_Loan_withoutVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ded_Advance_withoutVAT value.
		/// </summary>
		public decimal Ded_Advance_withoutVAT {
			get { return ded_Advance_withoutVAT; }
			set { ded_Advance_withoutVAT = value; }
		}
		
		/// <summary>
		/// Gets or sets the Net_commission_withoutVAT value.
		/// </summary>
		public decimal Net_commission_withoutVAT {
			get { return net_commission_withoutVAT; }
			set { net_commission_withoutVAT = value; }
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
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
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
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_comCommissionCalculation table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@comCalcIndex", SqlDbType.BigInt,8);
			scom.Parameters.Add("@periodIndex", SqlDbType.BigInt,8);
			scom.Parameters.Add("@roleOfEmplyee", SqlDbType.Int,4);
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@areaManger_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@collector_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@chequePeriod_fromDays", SqlDbType.Int,4);
			scom.Parameters.Add("@chequePeriod_toDays", SqlDbType.Int,4);
			scom.Parameters.Add("@gross_commission_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_CRN_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_ChqDate_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_RchqThisPeriod_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_RchqPrvPeriod_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_SecurityDept_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_BillAdv_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_Loan_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_Advance_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@net_commission_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gross_commission_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_CRN_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_ChqDate_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_RchqThisPeriod_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_RchqPrvPeriod_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_SecurityDept_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_BillAdv_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_Loan_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_Advance_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@net_commission_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
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
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
			scom.Parameters["@comCalcIndex"].Value = comCalcIndex;
			scom.Parameters["@periodIndex"].Value = periodIndex;
			scom.Parameters["@roleOfEmplyee"].Value = roleOfEmplyee;
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
			scom.Parameters["@areaManger_ID"].Value = areaManger_ID;
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@collector_ID"].Value = collector_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@chequePeriod_fromDays"].Value = chequePeriod_fromDays;
			scom.Parameters["@chequePeriod_toDays"].Value = chequePeriod_toDays;
			scom.Parameters["@gross_commission_withVAT"].Value = gross_commission_withVAT;
			scom.Parameters["@ded_CRN_withVAT"].Value = ded_CRN_withVAT;
			scom.Parameters["@ded_ChqDate_withVAT"].Value = ded_ChqDate_withVAT;
			scom.Parameters["@ded_RchqThisPeriod_withVAT"].Value = ded_RchqThisPeriod_withVAT;
			scom.Parameters["@ded_RchqPrvPeriod_withVAT"].Value = ded_RchqPrvPeriod_withVAT;
			scom.Parameters["@ded_SecurityDept_withVAT"].Value = ded_SecurityDept_withVAT;
			scom.Parameters["@ded_BillAdv_withVAT"].Value = ded_BillAdv_withVAT;
			scom.Parameters["@ded_Loan_withVAT"].Value = ded_Loan_withVAT;
			scom.Parameters["@ded_Advance_withVAT"].Value = ded_Advance_withVAT;
			scom.Parameters["@net_commission_withVAT"].Value = net_commission_withVAT;
			scom.Parameters["@gross_commission_withoutVAT"].Value = gross_commission_withoutVAT;
			scom.Parameters["@ded_CRN_withoutVAT"].Value = ded_CRN_withoutVAT;
			scom.Parameters["@ded_ChqDate_withoutVAT"].Value = ded_ChqDate_withoutVAT;
			scom.Parameters["@ded_RchqThisPeriod_withoutVAT"].Value = ded_RchqThisPeriod_withoutVAT;
			scom.Parameters["@ded_RchqPrvPeriod_withoutVAT"].Value = ded_RchqPrvPeriod_withoutVAT;
			scom.Parameters["@ded_SecurityDept_withoutVAT"].Value = ded_SecurityDept_withoutVAT;
			scom.Parameters["@ded_BillAdv_withoutVAT"].Value = ded_BillAdv_withoutVAT;
			scom.Parameters["@ded_Loan_withoutVAT"].Value = ded_Loan_withoutVAT;
			scom.Parameters["@ded_Advance_withoutVAT"].Value = ded_Advance_withoutVAT;
			scom.Parameters["@net_commission_withoutVAT"].Value = net_commission_withoutVAT;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isDeleted"].Value = isDeleted;
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
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_comCommissionCalculation table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@comCalcIndex", SqlDbType.BigInt,8);
			scom.Parameters.Add("@periodIndex", SqlDbType.BigInt,8);
			scom.Parameters.Add("@roleOfEmplyee", SqlDbType.Int,4);
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@areaManger_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@collector_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@chequePeriod_fromDays", SqlDbType.Int,4);
			scom.Parameters.Add("@chequePeriod_toDays", SqlDbType.Int,4);
			scom.Parameters.Add("@gross_commission_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_CRN_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_ChqDate_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_RchqThisPeriod_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_RchqPrvPeriod_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_SecurityDept_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_BillAdv_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_Loan_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_Advance_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@net_commission_withVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gross_commission_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_CRN_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_ChqDate_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_RchqThisPeriod_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_RchqPrvPeriod_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_SecurityDept_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_BillAdv_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_Loan_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ded_Advance_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@net_commission_withoutVAT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
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
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
 
			scom.Parameters["@comCalcIndex"].Value = comCalcIndex;
			scom.Parameters["@periodIndex"].Value = periodIndex;
			scom.Parameters["@roleOfEmplyee"].Value = roleOfEmplyee;
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
			scom.Parameters["@areaManger_ID"].Value = areaManger_ID;
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@collector_ID"].Value = collector_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@chequePeriod_fromDays"].Value = chequePeriod_fromDays;
			scom.Parameters["@chequePeriod_toDays"].Value = chequePeriod_toDays;
			scom.Parameters["@gross_commission_withVAT"].Value = gross_commission_withVAT;
			scom.Parameters["@ded_CRN_withVAT"].Value = ded_CRN_withVAT;
			scom.Parameters["@ded_ChqDate_withVAT"].Value = ded_ChqDate_withVAT;
			scom.Parameters["@ded_RchqThisPeriod_withVAT"].Value = ded_RchqThisPeriod_withVAT;
			scom.Parameters["@ded_RchqPrvPeriod_withVAT"].Value = ded_RchqPrvPeriod_withVAT;
			scom.Parameters["@ded_SecurityDept_withVAT"].Value = ded_SecurityDept_withVAT;
			scom.Parameters["@ded_BillAdv_withVAT"].Value = ded_BillAdv_withVAT;
			scom.Parameters["@ded_Loan_withVAT"].Value = ded_Loan_withVAT;
			scom.Parameters["@ded_Advance_withVAT"].Value = ded_Advance_withVAT;
			scom.Parameters["@net_commission_withVAT"].Value = net_commission_withVAT;
			scom.Parameters["@gross_commission_withoutVAT"].Value = gross_commission_withoutVAT;
			scom.Parameters["@ded_CRN_withoutVAT"].Value = ded_CRN_withoutVAT;
			scom.Parameters["@ded_ChqDate_withoutVAT"].Value = ded_ChqDate_withoutVAT;
			scom.Parameters["@ded_RchqThisPeriod_withoutVAT"].Value = ded_RchqThisPeriod_withoutVAT;
			scom.Parameters["@ded_RchqPrvPeriod_withoutVAT"].Value = ded_RchqPrvPeriod_withoutVAT;
			scom.Parameters["@ded_SecurityDept_withoutVAT"].Value = ded_SecurityDept_withoutVAT;
			scom.Parameters["@ded_BillAdv_withoutVAT"].Value = ded_BillAdv_withoutVAT;
			scom.Parameters["@ded_Loan_withoutVAT"].Value = ded_Loan_withoutVAT;
			scom.Parameters["@ded_Advance_withoutVAT"].Value = ded_Advance_withoutVAT;
			scom.Parameters["@net_commission_withoutVAT"].Value = net_commission_withoutVAT;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isDeleted"].Value = isDeleted;
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
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_comCommissionCalculation table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@comCalcIndex", SqlDbType.BigInt,8);
			scom.Parameters["@comCalcIndex"].Value = comCalcIndex;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesRep_ID(string salesRep_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationDeleteAllBySalesRep_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static void DeleteAllByPeriodIndex(Int64 periodIndex) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationDeleteAllByPeriodIndex", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@periodIndex", SqlDbType.BigInt,8);
			scom.Parameters["@periodIndex"].Value = periodIndex;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeletedUser_ID(string deletedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationDeleteAllByDeletedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static void DeleteAllByPrintedUser_ID(string printedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationDeleteAllByPrintedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_comCommissionCalculation table.
		/// </summary>
		public static tbl_comCommissionCalculation Select(Int64 comCalcIndex_Incoming){

			tbl_comCommissionCalculation tbl_comCommissionCalculationins = new tbl_comCommissionCalculation();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@comCalcIndex", SqlDbType.BigInt,8);
			scom.Parameters["@comCalcIndex"].Value = comCalcIndex_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_comCommissionCalculationins = Maketbl_comCommissionCalculation(dataReader);
				} else {
					tbl_comCommissionCalculationins = null;
				}
			}
			scon.Close();
			return tbl_comCommissionCalculationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table.
		/// </summary>
		public static List<tbl_comCommissionCalculation> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_comCommissionCalculation> tbl_comCommissionCalculationList = new List<tbl_comCommissionCalculation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation tbl_comCommissionCalculation = Maketbl_comCommissionCalculation(dataReader);
					tbl_comCommissionCalculationList.Add(tbl_comCommissionCalculation);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation> SelectAllBySalesRep_ID(string salesRep_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationSelectAllBySalesRep_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesRep_ID"].Value = salesRep_ID;
				List<tbl_comCommissionCalculation> tbl_comCommissionCalculationList = new List<tbl_comCommissionCalculation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation tbl_comCommissionCalculation = Maketbl_comCommissionCalculation(dataReader);
					tbl_comCommissionCalculationList.Add(tbl_comCommissionCalculation);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation> SelectAllByPeriodIndex(Int64 periodIndex) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationSelectAllByPeriodIndex", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@periodIndex", SqlDbType.BigInt,8);
			scom.Parameters["@periodIndex"].Value = periodIndex;
				List<tbl_comCommissionCalculation> tbl_comCommissionCalculationList = new List<tbl_comCommissionCalculation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation tbl_comCommissionCalculation = Maketbl_comCommissionCalculation(dataReader);
					tbl_comCommissionCalculationList.Add(tbl_comCommissionCalculation);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_comCommissionCalculation> tbl_comCommissionCalculationList = new List<tbl_comCommissionCalculation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation tbl_comCommissionCalculation = Maketbl_comCommissionCalculation(dataReader);
					tbl_comCommissionCalculationList.Add(tbl_comCommissionCalculation);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_comCommissionCalculation> tbl_comCommissionCalculationList = new List<tbl_comCommissionCalculation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation tbl_comCommissionCalculation = Maketbl_comCommissionCalculation(dataReader);
					tbl_comCommissionCalculationList.Add(tbl_comCommissionCalculation);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_comCommissionCalculation> tbl_comCommissionCalculationList = new List<tbl_comCommissionCalculation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation tbl_comCommissionCalculation = Maketbl_comCommissionCalculation(dataReader);
					tbl_comCommissionCalculationList.Add(tbl_comCommissionCalculation);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_comCommissionCalculation> tbl_comCommissionCalculationList = new List<tbl_comCommissionCalculation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation tbl_comCommissionCalculation = Maketbl_comCommissionCalculation(dataReader);
					tbl_comCommissionCalculationList.Add(tbl_comCommissionCalculation);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation> SelectAllByDeletedUser_ID(string deletedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationSelectAllByDeletedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
				List<tbl_comCommissionCalculation> tbl_comCommissionCalculationList = new List<tbl_comCommissionCalculation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation tbl_comCommissionCalculation = Maketbl_comCommissionCalculation(dataReader);
					tbl_comCommissionCalculationList.Add(tbl_comCommissionCalculation);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_comCommissionCalculation table by a foreign key.
		/// </summary>
		public static List<tbl_comCommissionCalculation> SelectAllByPrintedUser_ID(string printedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_comCommissionCalculationSelectAllByPrintedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@printedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@printedUser_ID"].Value = printedUser_ID;
				List<tbl_comCommissionCalculation> tbl_comCommissionCalculationList = new List<tbl_comCommissionCalculation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_comCommissionCalculation tbl_comCommissionCalculation = Maketbl_comCommissionCalculation(dataReader);
					tbl_comCommissionCalculationList.Add(tbl_comCommissionCalculation);
				}
			}
			scon.Close();
			return tbl_comCommissionCalculationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_comCommissionCalculation class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_comCommissionCalculation Maketbl_comCommissionCalculation(SqlDataReader dataReader) {
			tbl_comCommissionCalculation tbl_comCommissionCalculation = new tbl_comCommissionCalculation();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_comCommissionCalculation.ComCalcIndex = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_comCommissionCalculation.PeriodIndex = dataReader.GetInt64(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_comCommissionCalculation.RoleOfEmplyee = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_comCommissionCalculation.SalesRep_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_comCommissionCalculation.AreaManger_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_comCommissionCalculation.SalesManager_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_comCommissionCalculation.Collector_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_comCommissionCalculation.Remarks = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_comCommissionCalculation.ChequePeriod_fromDays = dataReader.GetInt32(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_comCommissionCalculation.ChequePeriod_toDays = dataReader.GetInt32(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_comCommissionCalculation.Gross_commission_withVAT = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_comCommissionCalculation.Ded_CRN_withVAT = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_comCommissionCalculation.Ded_ChqDate_withVAT = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_comCommissionCalculation.Ded_RchqThisPeriod_withVAT = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_comCommissionCalculation.Ded_RchqPrvPeriod_withVAT = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_comCommissionCalculation.Ded_SecurityDept_withVAT = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_comCommissionCalculation.Ded_BillAdv_withVAT = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_comCommissionCalculation.Ded_Loan_withVAT = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_comCommissionCalculation.Ded_Advance_withVAT = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_comCommissionCalculation.Net_commission_withVAT = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_comCommissionCalculation.Gross_commission_withoutVAT = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_comCommissionCalculation.Ded_CRN_withoutVAT = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_comCommissionCalculation.Ded_ChqDate_withoutVAT = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_comCommissionCalculation.Ded_RchqThisPeriod_withoutVAT = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_comCommissionCalculation.Ded_RchqPrvPeriod_withoutVAT = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_comCommissionCalculation.Ded_SecurityDept_withoutVAT = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_comCommissionCalculation.Ded_BillAdv_withoutVAT = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_comCommissionCalculation.Ded_Loan_withoutVAT = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_comCommissionCalculation.Ded_Advance_withoutVAT = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_comCommissionCalculation.Net_commission_withoutVAT = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_comCommissionCalculation.IsChecked = dataReader.GetBoolean(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_comCommissionCalculation.IsApproved = dataReader.GetBoolean(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_comCommissionCalculation.IsDeleted = dataReader.GetBoolean(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_comCommissionCalculation.CreateUser_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_comCommissionCalculation.ModifiedUser_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_comCommissionCalculation.CheckedUser_ID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_comCommissionCalculation.ApprovedUser_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_comCommissionCalculation.DeletedUser_ID = dataReader.GetString(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_comCommissionCalculation.PrintedUser_ID = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_comCommissionCalculation.CreateTerminal_ID = dataReader.GetString(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_comCommissionCalculation.ModifiedTerminal_ID = dataReader.GetString(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_comCommissionCalculation.DeletedTerminal_ID = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_comCommissionCalculation.PrintedTerminal_ID = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_comCommissionCalculation.DateCreate = dataReader.GetDateTime(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_comCommissionCalculation.DateModified = dataReader.GetDateTime(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_comCommissionCalculation.DateChecked = dataReader.GetDateTime(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_comCommissionCalculation.DateApproved = dataReader.GetDateTime(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_comCommissionCalculation.DateDeleted = dataReader.GetDateTime(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_comCommissionCalculation.DatePrinted = dataReader.GetDateTime(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_comCommissionCalculation.PrintCount = dataReader.GetInt32(49);
			}

			return tbl_comCommissionCalculation;
		}
		/// <summary>
		/// This makes tbl_comCommissionCalculation datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_comCommissionCalculation object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_comCommissionCalculation  tbl_comCommissionCalculation   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_comCalcIndex = new DataColumn("comCalcIndex" , typeof(long));
			DataColumn col_periodIndex = new DataColumn("periodIndex" , typeof(long));
			DataColumn col_roleOfEmplyee = new DataColumn("roleOfEmplyee" , typeof(int));
			DataColumn col_salesRep_ID = new DataColumn("salesRep_ID" , typeof(string));
			DataColumn col_areaManger_ID = new DataColumn("areaManger_ID" , typeof(string));
			DataColumn col_salesManager_ID = new DataColumn("salesManager_ID" , typeof(string));
			DataColumn col_collector_ID = new DataColumn("collector_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_chequePeriod_fromDays = new DataColumn("chequePeriod_fromDays" , typeof(int));
			DataColumn col_chequePeriod_toDays = new DataColumn("chequePeriod_toDays" , typeof(int));
			DataColumn col_gross_commission_withVAT = new DataColumn("gross_commission_withVAT" , typeof(decimal));
			DataColumn col_ded_CRN_withVAT = new DataColumn("ded_CRN_withVAT" , typeof(decimal));
			DataColumn col_ded_ChqDate_withVAT = new DataColumn("ded_ChqDate_withVAT" , typeof(decimal));
			DataColumn col_ded_RchqThisPeriod_withVAT = new DataColumn("ded_RchqThisPeriod_withVAT" , typeof(decimal));
			DataColumn col_ded_RchqPrvPeriod_withVAT = new DataColumn("ded_RchqPrvPeriod_withVAT" , typeof(decimal));
			DataColumn col_ded_SecurityDept_withVAT = new DataColumn("ded_SecurityDept_withVAT" , typeof(decimal));
			DataColumn col_ded_BillAdv_withVAT = new DataColumn("ded_BillAdv_withVAT" , typeof(decimal));
			DataColumn col_ded_Loan_withVAT = new DataColumn("ded_Loan_withVAT" , typeof(decimal));
			DataColumn col_ded_Advance_withVAT = new DataColumn("ded_Advance_withVAT" , typeof(decimal));
			DataColumn col_net_commission_withVAT = new DataColumn("net_commission_withVAT" , typeof(decimal));
			DataColumn col_gross_commission_withoutVAT = new DataColumn("gross_commission_withoutVAT" , typeof(decimal));
			DataColumn col_ded_CRN_withoutVAT = new DataColumn("ded_CRN_withoutVAT" , typeof(decimal));
			DataColumn col_ded_ChqDate_withoutVAT = new DataColumn("ded_ChqDate_withoutVAT" , typeof(decimal));
			DataColumn col_ded_RchqThisPeriod_withoutVAT = new DataColumn("ded_RchqThisPeriod_withoutVAT" , typeof(decimal));
			DataColumn col_ded_RchqPrvPeriod_withoutVAT = new DataColumn("ded_RchqPrvPeriod_withoutVAT" , typeof(decimal));
			DataColumn col_ded_SecurityDept_withoutVAT = new DataColumn("ded_SecurityDept_withoutVAT" , typeof(decimal));
			DataColumn col_ded_BillAdv_withoutVAT = new DataColumn("ded_BillAdv_withoutVAT" , typeof(decimal));
			DataColumn col_ded_Loan_withoutVAT = new DataColumn("ded_Loan_withoutVAT" , typeof(decimal));
			DataColumn col_ded_Advance_withoutVAT = new DataColumn("ded_Advance_withoutVAT" , typeof(decimal));
			DataColumn col_net_commission_withoutVAT = new DataColumn("net_commission_withoutVAT" , typeof(decimal));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
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
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_comCalcIndex,col_periodIndex,col_roleOfEmplyee,col_salesRep_ID,col_areaManger_ID,col_salesManager_ID,col_collector_ID,col_remarks,col_chequePeriod_fromDays,col_chequePeriod_toDays,col_gross_commission_withVAT,col_ded_CRN_withVAT,col_ded_ChqDate_withVAT,col_ded_RchqThisPeriod_withVAT,col_ded_RchqPrvPeriod_withVAT,col_ded_SecurityDept_withVAT,col_ded_BillAdv_withVAT,col_ded_Loan_withVAT,col_ded_Advance_withVAT,col_net_commission_withVAT,col_gross_commission_withoutVAT,col_ded_CRN_withoutVAT,col_ded_ChqDate_withoutVAT,col_ded_RchqThisPeriod_withoutVAT,col_ded_RchqPrvPeriod_withoutVAT,col_ded_SecurityDept_withoutVAT,col_ded_BillAdv_withoutVAT,col_ded_Loan_withoutVAT,col_ded_Advance_withoutVAT,col_net_commission_withoutVAT,col_isChecked,col_isApproved,col_isDeleted,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_printCount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_comCommissionCalculation datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_comCommissionCalculation object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_comCommissionCalculation user) {
		DataRow drow = dt.NewRow();
		
			drow["comCalcIndex"] = user.comCalcIndex;
			drow["periodIndex"] = user.periodIndex;
			drow["roleOfEmplyee"] = user.roleOfEmplyee;
			drow["salesRep_ID"] = user.salesRep_ID;
			drow["areaManger_ID"] = user.areaManger_ID;
			drow["salesManager_ID"] = user.salesManager_ID;
			drow["collector_ID"] = user.collector_ID;
			drow["remarks"] = user.remarks;
			drow["chequePeriod_fromDays"] = user.chequePeriod_fromDays;
			drow["chequePeriod_toDays"] = user.chequePeriod_toDays;
			drow["gross_commission_withVAT"] = user.gross_commission_withVAT;
			drow["ded_CRN_withVAT"] = user.ded_CRN_withVAT;
			drow["ded_ChqDate_withVAT"] = user.ded_ChqDate_withVAT;
			drow["ded_RchqThisPeriod_withVAT"] = user.ded_RchqThisPeriod_withVAT;
			drow["ded_RchqPrvPeriod_withVAT"] = user.ded_RchqPrvPeriod_withVAT;
			drow["ded_SecurityDept_withVAT"] = user.ded_SecurityDept_withVAT;
			drow["ded_BillAdv_withVAT"] = user.ded_BillAdv_withVAT;
			drow["ded_Loan_withVAT"] = user.ded_Loan_withVAT;
			drow["ded_Advance_withVAT"] = user.ded_Advance_withVAT;
			drow["net_commission_withVAT"] = user.net_commission_withVAT;
			drow["gross_commission_withoutVAT"] = user.gross_commission_withoutVAT;
			drow["ded_CRN_withoutVAT"] = user.ded_CRN_withoutVAT;
			drow["ded_ChqDate_withoutVAT"] = user.ded_ChqDate_withoutVAT;
			drow["ded_RchqThisPeriod_withoutVAT"] = user.ded_RchqThisPeriod_withoutVAT;
			drow["ded_RchqPrvPeriod_withoutVAT"] = user.ded_RchqPrvPeriod_withoutVAT;
			drow["ded_SecurityDept_withoutVAT"] = user.ded_SecurityDept_withoutVAT;
			drow["ded_BillAdv_withoutVAT"] = user.ded_BillAdv_withoutVAT;
			drow["ded_Loan_withoutVAT"] = user.ded_Loan_withoutVAT;
			drow["ded_Advance_withoutVAT"] = user.ded_Advance_withoutVAT;
			drow["net_commission_withoutVAT"] = user.net_commission_withoutVAT;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isDeleted"] = user.isDeleted;
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
			drow["printCount"] = user.printCount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
