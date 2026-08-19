using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsPettyCashReimbursement {
		#region Fields
		private string reimbRequest_ID;
		private DateTime reimbRequestDate;
		private string pettyCashAccount_ID;
		private int rangeFrom;
		private int rangeTo;
		private string remark;
		private decimal oPBalanceTotal;
		private decimal totalIncome;
		private decimal totalExpenditure;
		private decimal closingBalanceAmount;
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
		private int printCount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashReimbursement class.
		/// </summary>
		public tbl_bpsPettyCashReimbursement() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPettyCashReimbursement class.
		/// </summary>
		public tbl_bpsPettyCashReimbursement(string reimbRequest_ID, DateTime reimbRequestDate, string pettyCashAccount_ID, int rangeFrom, int rangeTo, string remark, decimal oPBalanceTotal, decimal totalIncome, decimal totalExpenditure, decimal closingBalanceAmount, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deletedUser_ID, string printedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isSeattled, int printCount) {
			this.reimbRequest_ID = reimbRequest_ID;
			this.reimbRequestDate = reimbRequestDate;
			this.pettyCashAccount_ID = pettyCashAccount_ID;
			this.rangeFrom = rangeFrom;
			this.rangeTo = rangeTo;
			this.remark = remark;
			this.oPBalanceTotal = oPBalanceTotal;
			this.totalIncome = totalIncome;
			this.totalExpenditure = totalExpenditure;
			this.closingBalanceAmount = closingBalanceAmount;
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
			this.printCount = printCount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ReimbRequest_ID value.
		/// </summary>
		public string ReimbRequest_ID {
			get { return reimbRequest_ID; }
			set { reimbRequest_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReimbRequestDate value.
		/// </summary>
		public DateTime ReimbRequestDate {
			get { return reimbRequestDate; }
			set { reimbRequestDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the PettyCashAccount_ID value.
		/// </summary>
		public string PettyCashAccount_ID {
			get { return pettyCashAccount_ID; }
			set { pettyCashAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RangeFrom value.
		/// </summary>
		public int RangeFrom {
			get { return rangeFrom; }
			set { rangeFrom = value; }
		}
		
		/// <summary>
		/// Gets or sets the RangeTo value.
		/// </summary>
		public int RangeTo {
			get { return rangeTo; }
			set { rangeTo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the OPBalanceTotal value.
		/// </summary>
		public decimal OPBalanceTotal {
			get { return oPBalanceTotal; }
			set { oPBalanceTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalIncome value.
		/// </summary>
		public decimal TotalIncome {
			get { return totalIncome; }
			set { totalIncome = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalExpenditure value.
		/// </summary>
		public decimal TotalExpenditure {
			get { return totalExpenditure; }
			set { totalExpenditure = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClosingBalanceAmount value.
		/// </summary>
		public decimal ClosingBalanceAmount {
			get { return closingBalanceAmount; }
			set { closingBalanceAmount = value; }
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
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsPettyCashReimbursement table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashReimbursementInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reimbRequest_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reimbRequestDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@rangeFrom", SqlDbType.Int,4);
			scom.Parameters.Add("@rangeTo", SqlDbType.Int,4);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@oPBalanceTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalIncome", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalExpenditure", SqlDbType.Decimal,9);
			scom.Parameters.Add("@closingBalanceAmount", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
			scom.Parameters["@reimbRequest_ID"].Value = reimbRequest_ID;
			scom.Parameters["@reimbRequestDate"].Value = reimbRequestDate;
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
			scom.Parameters["@rangeFrom"].Value = rangeFrom;
			scom.Parameters["@rangeTo"].Value = rangeTo;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@oPBalanceTotal"].Value = oPBalanceTotal;
			scom.Parameters["@totalIncome"].Value = totalIncome;
			scom.Parameters["@totalExpenditure"].Value = totalExpenditure;
			scom.Parameters["@closingBalanceAmount"].Value = closingBalanceAmount;
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
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsPettyCashReimbursement table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashReimbursementUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reimbRequest_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reimbRequestDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@pettyCashAccount_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@rangeFrom", SqlDbType.Int,4);
			scom.Parameters.Add("@rangeTo", SqlDbType.Int,4);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@oPBalanceTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalIncome", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalExpenditure", SqlDbType.Decimal,9);
			scom.Parameters.Add("@closingBalanceAmount", SqlDbType.Decimal,9);
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
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
 
 
			scom.Parameters["@reimbRequest_ID"].Value = reimbRequest_ID;
			scom.Parameters["@reimbRequestDate"].Value = reimbRequestDate;
			scom.Parameters["@pettyCashAccount_ID"].Value = pettyCashAccount_ID;
			scom.Parameters["@rangeFrom"].Value = rangeFrom;
			scom.Parameters["@rangeTo"].Value = rangeTo;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@oPBalanceTotal"].Value = oPBalanceTotal;
			scom.Parameters["@totalIncome"].Value = totalIncome;
			scom.Parameters["@totalExpenditure"].Value = totalExpenditure;
			scom.Parameters["@closingBalanceAmount"].Value = closingBalanceAmount;
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
			scom.Parameters["@printCount"].Value = printCount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsPettyCashReimbursement table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashReimbursementDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@reimbRequest_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reimbRequest_ID"].Value = reimbRequest_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsPettyCashReimbursement table.
		/// </summary>
		public static tbl_bpsPettyCashReimbursement Select(string reimbRequest_ID_Incoming){

			tbl_bpsPettyCashReimbursement tbl_bpsPettyCashReimbursementins = new tbl_bpsPettyCashReimbursement();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashReimbursementSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reimbRequest_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reimbRequest_ID"].Value = reimbRequest_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsPettyCashReimbursementins = Maketbl_bpsPettyCashReimbursement(dataReader);
				} else {
					tbl_bpsPettyCashReimbursementins = null;
				}
			}
			scon.Close();
			return tbl_bpsPettyCashReimbursementins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPettyCashReimbursement table.
		/// </summary>
		public static List<tbl_bpsPettyCashReimbursement> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPettyCashReimbursementSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsPettyCashReimbursement> tbl_bpsPettyCashReimbursementList = new List<tbl_bpsPettyCashReimbursement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPettyCashReimbursement tbl_bpsPettyCashReimbursement = Maketbl_bpsPettyCashReimbursement(dataReader);
					tbl_bpsPettyCashReimbursementList.Add(tbl_bpsPettyCashReimbursement);
				}
			}
			scon.Close();
			return tbl_bpsPettyCashReimbursementList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsPettyCashReimbursement class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsPettyCashReimbursement Maketbl_bpsPettyCashReimbursement(SqlDataReader dataReader) {
			tbl_bpsPettyCashReimbursement tbl_bpsPettyCashReimbursement = new tbl_bpsPettyCashReimbursement();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsPettyCashReimbursement.ReimbRequest_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsPettyCashReimbursement.ReimbRequestDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsPettyCashReimbursement.PettyCashAccount_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsPettyCashReimbursement.RangeFrom = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsPettyCashReimbursement.RangeTo = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsPettyCashReimbursement.Remark = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsPettyCashReimbursement.OPBalanceTotal = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsPettyCashReimbursement.TotalIncome = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsPettyCashReimbursement.TotalExpenditure = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsPettyCashReimbursement.ClosingBalanceAmount = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsPettyCashReimbursement.CreateUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsPettyCashReimbursement.ModifiedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsPettyCashReimbursement.CheckedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsPettyCashReimbursement.ApprovedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsPettyCashReimbursement.DeletedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsPettyCashReimbursement.PrintedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsPettyCashReimbursement.CreateTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsPettyCashReimbursement.ModifiedTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsPettyCashReimbursement.DeletedTerminal_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsPettyCashReimbursement.PrintedTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_bpsPettyCashReimbursement.DateCreate = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_bpsPettyCashReimbursement.DateModified = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_bpsPettyCashReimbursement.DateChecked = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_bpsPettyCashReimbursement.DateApproved = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_bpsPettyCashReimbursement.DateDeleted = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_bpsPettyCashReimbursement.DatePrinted = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_bpsPettyCashReimbursement.IsChecked = dataReader.GetBoolean(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_bpsPettyCashReimbursement.IsApproved = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_bpsPettyCashReimbursement.IsFinished = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_bpsPettyCashReimbursement.IsDeleted = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_bpsPettyCashReimbursement.IsLocked = dataReader.GetBoolean(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_bpsPettyCashReimbursement.IsSeattled = dataReader.GetBoolean(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_bpsPettyCashReimbursement.PrintCount = dataReader.GetInt32(32);
			}

			return tbl_bpsPettyCashReimbursement;
		}
		/// <summary>
		/// This makes tbl_bpsPettyCashReimbursement datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashReimbursement object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsPettyCashReimbursement  tbl_bpsPettyCashReimbursement   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_reimbRequest_ID = new DataColumn("reimbRequest_ID" , typeof(string));
			DataColumn col_reimbRequestDate = new DataColumn("reimbRequestDate" , typeof(DateTime));
			DataColumn col_pettyCashAccount_ID = new DataColumn("pettyCashAccount_ID" , typeof(string));
			DataColumn col_rangeFrom = new DataColumn("rangeFrom" , typeof(int));
			DataColumn col_rangeTo = new DataColumn("rangeTo" , typeof(int));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_oPBalanceTotal = new DataColumn("oPBalanceTotal" , typeof(decimal));
			DataColumn col_totalIncome = new DataColumn("totalIncome" , typeof(decimal));
			DataColumn col_totalExpenditure = new DataColumn("totalExpenditure" , typeof(decimal));
			DataColumn col_closingBalanceAmount = new DataColumn("closingBalanceAmount" , typeof(decimal));
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
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_reimbRequest_ID,col_reimbRequestDate,col_pettyCashAccount_ID,col_rangeFrom,col_rangeTo,col_remark,col_oPBalanceTotal,col_totalIncome,col_totalExpenditure,col_closingBalanceAmount,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deletedUser_ID,col_printedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_printedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isSeattled,col_printCount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsPettyCashReimbursement datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsPettyCashReimbursement object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsPettyCashReimbursement user) {
		DataRow drow = dt.NewRow();
		
			drow["reimbRequest_ID"] = user.reimbRequest_ID;
			drow["reimbRequestDate"] = user.reimbRequestDate;
			drow["pettyCashAccount_ID"] = user.pettyCashAccount_ID;
			drow["rangeFrom"] = user.rangeFrom;
			drow["rangeTo"] = user.rangeTo;
			drow["remark"] = user.remark;
			drow["oPBalanceTotal"] = user.oPBalanceTotal;
			drow["totalIncome"] = user.totalIncome;
			drow["totalExpenditure"] = user.totalExpenditure;
			drow["closingBalanceAmount"] = user.closingBalanceAmount;
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
			drow["printCount"] = user.printCount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
