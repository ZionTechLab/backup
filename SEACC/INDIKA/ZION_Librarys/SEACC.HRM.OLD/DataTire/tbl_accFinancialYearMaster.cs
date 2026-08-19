using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accFinancialYearMaster {
		#region Fields
		private string financialYear_ID;
		private string financialYearCode;
		private string financialYearName;
		private DateTime dateStart;
		private DateTime dateEnd;
		private DateTime dateTransactionStart;
		private DateTime financialYearClosedDate;
		private int statusID;
		private decimal pL_BalanceBroughtForward;
		private string createUser_ID;
		private string createTerminal_ID;
		private string modifiedUser_ID;
		private string modifiedTerminal_ID;
		private string checkedUser_ID;
		private string checkedTerminal_ID;
		private string approvedUser_ID;
		private string approvedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isCurrentYear;
		private bool isLastYear;
		private bool isBeforeLastYear;
		private bool isFinancialYearClose;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accFinancialYearMaster class.
		/// </summary>
		public tbl_accFinancialYearMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accFinancialYearMaster class.
		/// </summary>
		public tbl_accFinancialYearMaster(string financialYear_ID, string financialYearCode, string financialYearName, DateTime dateStart, DateTime dateEnd, DateTime dateTransactionStart, DateTime financialYearClosedDate, int statusID, decimal pL_BalanceBroughtForward, string createUser_ID, string createTerminal_ID, string modifiedUser_ID, string modifiedTerminal_ID, string checkedUser_ID, string checkedTerminal_ID, string approvedUser_ID, string approvedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isCurrentYear, bool isLastYear, bool isBeforeLastYear, bool isFinancialYearClose) {
			this.financialYear_ID = financialYear_ID;
			this.financialYearCode = financialYearCode;
			this.financialYearName = financialYearName;
			this.dateStart = dateStart;
			this.dateEnd = dateEnd;
			this.dateTransactionStart = dateTransactionStart;
			this.financialYearClosedDate = financialYearClosedDate;
			this.statusID = statusID;
			this.pL_BalanceBroughtForward = pL_BalanceBroughtForward;
			this.createUser_ID = createUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.checkedTerminal_ID = checkedTerminal_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.approvedTerminal_ID = approvedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isCurrentYear = isCurrentYear;
			this.isLastYear = isLastYear;
			this.isBeforeLastYear = isBeforeLastYear;
			this.isFinancialYearClose = isFinancialYearClose;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYearCode value.
		/// </summary>
		public string FinancialYearCode {
			get { return financialYearCode; }
			set { financialYearCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYearName value.
		/// </summary>
		public string FinancialYearName {
			get { return financialYearName; }
			set { financialYearName = value; }
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
		/// Gets or sets the DateTransactionStart value.
		/// </summary>
		public DateTime DateTransactionStart {
			get { return dateTransactionStart; }
			set { dateTransactionStart = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinancialYearClosedDate value.
		/// </summary>
		public DateTime FinancialYearClosedDate {
			get { return financialYearClosedDate; }
			set { financialYearClosedDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatusID value.
		/// </summary>
		public int StatusID {
			get { return statusID; }
			set { statusID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PL_BalanceBroughtForward value.
		/// </summary>
		public decimal PL_BalanceBroughtForward {
			get { return pL_BalanceBroughtForward; }
			set { pL_BalanceBroughtForward = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedUser_ID value.
		/// </summary>
		public string CheckedUser_ID {
			get { return checkedUser_ID; }
			set { checkedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedTerminal_ID value.
		/// </summary>
		public string CheckedTerminal_ID {
			get { return checkedTerminal_ID; }
			set { checkedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedTerminal_ID value.
		/// </summary>
		public string ApprovedTerminal_ID {
			get { return approvedTerminal_ID; }
			set { approvedTerminal_ID = value; }
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
		/// Gets or sets the IsCurrentYear value.
		/// </summary>
		public bool IsCurrentYear {
			get { return isCurrentYear; }
			set { isCurrentYear = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLastYear value.
		/// </summary>
		public bool IsLastYear {
			get { return isLastYear; }
			set { isLastYear = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBeforeLastYear value.
		/// </summary>
		public bool IsBeforeLastYear {
			get { return isBeforeLastYear; }
			set { isBeforeLastYear = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFinancialYearClose value.
		/// </summary>
		public bool IsFinancialYearClose {
			get { return isFinancialYearClose; }
			set { isFinancialYearClose = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accFinancialYearMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYearCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYearName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateEnd", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateTransactionStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@financialYearClosedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters.Add("@pL_BalanceBroughtForward", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCurrentYear", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLastYear", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBeforeLastYear", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinancialYearClose", SqlDbType.Bit,1);
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@financialYearCode"].Value = financialYearCode;
			scom.Parameters["@financialYearName"].Value = financialYearName;
			scom.Parameters["@dateStart"].Value = dateStart;
			scom.Parameters["@dateEnd"].Value = dateEnd;
			scom.Parameters["@dateTransactionStart"].Value = dateTransactionStart;
			scom.Parameters["@financialYearClosedDate"].Value = financialYearClosedDate;
			scom.Parameters["@statusID"].Value = statusID;
			scom.Parameters["@pL_BalanceBroughtForward"].Value = pL_BalanceBroughtForward;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isCurrentYear"].Value = isCurrentYear;
			scom.Parameters["@isLastYear"].Value = isLastYear;
			scom.Parameters["@isBeforeLastYear"].Value = isBeforeLastYear;
			scom.Parameters["@isFinancialYearClose"].Value = isFinancialYearClose;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accFinancialYearMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYearCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYearName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateEnd", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateTransactionStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@financialYearClosedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters.Add("@pL_BalanceBroughtForward", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCurrentYear", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLastYear", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBeforeLastYear", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinancialYearClose", SqlDbType.Bit,1);
 
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@financialYearCode"].Value = financialYearCode;
			scom.Parameters["@financialYearName"].Value = financialYearName;
			scom.Parameters["@dateStart"].Value = dateStart;
			scom.Parameters["@dateEnd"].Value = dateEnd;
			scom.Parameters["@dateTransactionStart"].Value = dateTransactionStart;
			scom.Parameters["@financialYearClosedDate"].Value = financialYearClosedDate;
			scom.Parameters["@statusID"].Value = statusID;
			scom.Parameters["@pL_BalanceBroughtForward"].Value = pL_BalanceBroughtForward;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isCurrentYear"].Value = isCurrentYear;
			scom.Parameters["@isLastYear"].Value = isLastYear;
			scom.Parameters["@isBeforeLastYear"].Value = isBeforeLastYear;
			scom.Parameters["@isFinancialYearClose"].Value = isFinancialYearClose;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accFinancialYearMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accFinancialYearMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByStatusID(int statusID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterDeleteAllByStatusID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters["@statusID"].Value = statusID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accFinancialYearMaster table.
		/// </summary>
		public static tbl_accFinancialYearMaster Select(string financialYear_ID_Incoming){

			tbl_accFinancialYearMaster tbl_accFinancialYearMasterins = new tbl_accFinancialYearMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accFinancialYearMasterins = Maketbl_accFinancialYearMaster(dataReader);
				} else {
					tbl_accFinancialYearMasterins = null;
				}
			}
			scon.Close();
			return tbl_accFinancialYearMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accFinancialYearMaster table.
		/// </summary>
		public static List<tbl_accFinancialYearMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accFinancialYearMaster> tbl_accFinancialYearMasterList = new List<tbl_accFinancialYearMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accFinancialYearMaster tbl_accFinancialYearMaster = Maketbl_accFinancialYearMaster(dataReader);
					tbl_accFinancialYearMasterList.Add(tbl_accFinancialYearMaster);
				}
			}
			scon.Close();
			return tbl_accFinancialYearMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accFinancialYearMaster table by a foreign key.
		/// </summary>
		public static List<tbl_accFinancialYearMaster> SelectAllByStatusID(int statusID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterSelectAllByStatusID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters["@statusID"].Value = statusID;
				List<tbl_accFinancialYearMaster> tbl_accFinancialYearMasterList = new List<tbl_accFinancialYearMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accFinancialYearMaster tbl_accFinancialYearMaster = Maketbl_accFinancialYearMaster(dataReader);
					tbl_accFinancialYearMasterList.Add(tbl_accFinancialYearMaster);
				}
			}
			scon.Close();
			return tbl_accFinancialYearMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accFinancialYearMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accFinancialYearMaster Maketbl_accFinancialYearMaster(SqlDataReader dataReader) {
			tbl_accFinancialYearMaster tbl_accFinancialYearMaster = new tbl_accFinancialYearMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accFinancialYearMaster.FinancialYear_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accFinancialYearMaster.FinancialYearCode = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accFinancialYearMaster.FinancialYearName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accFinancialYearMaster.DateStart = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accFinancialYearMaster.DateEnd = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accFinancialYearMaster.DateTransactionStart = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accFinancialYearMaster.FinancialYearClosedDate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accFinancialYearMaster.StatusID = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accFinancialYearMaster.PL_BalanceBroughtForward = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accFinancialYearMaster.CreateUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accFinancialYearMaster.CreateTerminal_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accFinancialYearMaster.ModifiedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accFinancialYearMaster.ModifiedTerminal_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_accFinancialYearMaster.CheckedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_accFinancialYearMaster.CheckedTerminal_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_accFinancialYearMaster.ApprovedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_accFinancialYearMaster.ApprovedTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_accFinancialYearMaster.DateCreate = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_accFinancialYearMaster.DateModified = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_accFinancialYearMaster.DateChecked = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_accFinancialYearMaster.DateApproved = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_accFinancialYearMaster.IsChecked = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_accFinancialYearMaster.IsApproved = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_accFinancialYearMaster.IsFinished = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_accFinancialYearMaster.IsDeleted = dataReader.GetBoolean(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_accFinancialYearMaster.IsLocked = dataReader.GetBoolean(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_accFinancialYearMaster.IsCurrentYear = dataReader.GetBoolean(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_accFinancialYearMaster.IsLastYear = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_accFinancialYearMaster.IsBeforeLastYear = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_accFinancialYearMaster.IsFinancialYearClose = dataReader.GetBoolean(29);
			}

			return tbl_accFinancialYearMaster;
		}
		/// <summary>
		/// This makes tbl_accFinancialYearMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accFinancialYearMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accFinancialYearMaster  tbl_accFinancialYearMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_financialYearCode = new DataColumn("financialYearCode" , typeof(string));
			DataColumn col_financialYearName = new DataColumn("financialYearName" , typeof(string));
			DataColumn col_dateStart = new DataColumn("dateStart" , typeof(DateTime));
			DataColumn col_dateEnd = new DataColumn("dateEnd" , typeof(DateTime));
			DataColumn col_dateTransactionStart = new DataColumn("dateTransactionStart" , typeof(DateTime));
			DataColumn col_financialYearClosedDate = new DataColumn("financialYearClosedDate" , typeof(DateTime));
			DataColumn col_statusID = new DataColumn("statusID" , typeof(int));
			DataColumn col_pL_BalanceBroughtForward = new DataColumn("pL_BalanceBroughtForward" , typeof(decimal));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_checkedTerminal_ID = new DataColumn("checkedTerminal_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_approvedTerminal_ID = new DataColumn("approvedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isCurrentYear = new DataColumn("isCurrentYear" , typeof(bool));
			DataColumn col_isLastYear = new DataColumn("isLastYear" , typeof(bool));
			DataColumn col_isBeforeLastYear = new DataColumn("isBeforeLastYear" , typeof(bool));
			DataColumn col_isFinancialYearClose = new DataColumn("isFinancialYearClose" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_financialYear_ID,col_financialYearCode,col_financialYearName,col_dateStart,col_dateEnd,col_dateTransactionStart,col_financialYearClosedDate,col_statusID,col_pL_BalanceBroughtForward,col_createUser_ID,col_createTerminal_ID,col_modifiedUser_ID,col_modifiedTerminal_ID,col_checkedUser_ID,col_checkedTerminal_ID,col_approvedUser_ID,col_approvedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isCurrentYear,col_isLastYear,col_isBeforeLastYear,col_isFinancialYearClose,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accFinancialYearMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accFinancialYearMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accFinancialYearMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["financialYearCode"] = user.financialYearCode;
			drow["financialYearName"] = user.financialYearName;
			drow["dateStart"] = user.dateStart;
			drow["dateEnd"] = user.dateEnd;
			drow["dateTransactionStart"] = user.dateTransactionStart;
			drow["financialYearClosedDate"] = user.financialYearClosedDate;
			drow["statusID"] = user.statusID;
			drow["pL_BalanceBroughtForward"] = user.pL_BalanceBroughtForward;
			drow["createUser_ID"] = user.createUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["checkedTerminal_ID"] = user.checkedTerminal_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["approvedTerminal_ID"] = user.approvedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isCurrentYear"] = user.isCurrentYear;
			drow["isLastYear"] = user.isLastYear;
			drow["isBeforeLastYear"] = user.isBeforeLastYear;
			drow["isFinancialYearClose"] = user.isFinancialYearClose;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
