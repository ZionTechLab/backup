using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxFinishedGoodTransferAcceptance {
		#region Fields
		private string acceptance_ID;
		private DateTime acceptance_Date;
		private string remark;
		private bool isChecked;
		private bool isApproved;
		private bool isCanceled;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string canceldUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime dateCanceled;
		private string createUserTerminal_ID;
		private string modifiedUserTerminal_ID;
		private string checkedUserTerminal_ID;
		private string approvedUserTerminal_ID;
		private string canceledUserTerminal_ID;
		private string companyID;
		private string companyBranchID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxFinishedGoodTransferAcceptance class.
		/// </summary>
		public tbl_prodTxFinishedGoodTransferAcceptance() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxFinishedGoodTransferAcceptance class.
		/// </summary>
		public tbl_prodTxFinishedGoodTransferAcceptance(string acceptance_ID, DateTime acceptance_Date, string remark, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID) {
			this.acceptance_ID = acceptance_ID;
			this.acceptance_Date = acceptance_Date;
			this.remark = remark;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isCanceled = isCanceled;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.canceldUser_ID = canceldUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.dateCanceled = dateCanceled;
			this.createUserTerminal_ID = createUserTerminal_ID;
			this.modifiedUserTerminal_ID = modifiedUserTerminal_ID;
			this.checkedUserTerminal_ID = checkedUserTerminal_ID;
			this.approvedUserTerminal_ID = approvedUserTerminal_ID;
			this.canceledUserTerminal_ID = canceledUserTerminal_ID;
			this.companyID = companyID;
			this.companyBranchID = companyBranchID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Acceptance_ID value.
		/// </summary>
		public string Acceptance_ID {
			get { return acceptance_ID; }
			set { acceptance_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Acceptance_Date value.
		/// </summary>
		public DateTime Acceptance_Date {
			get { return acceptance_Date; }
			set { acceptance_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
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
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
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
		/// Gets or sets the CanceldUser_ID value.
		/// </summary>
		public string CanceldUser_ID {
			get { return canceldUser_ID; }
			set { canceldUser_ID = value; }
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
		/// Gets or sets the DateCanceled value.
		/// </summary>
		public DateTime DateCanceled {
			get { return dateCanceled; }
			set { dateCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUserTerminal_ID value.
		/// </summary>
		public string CreateUserTerminal_ID {
			get { return createUserTerminal_ID; }
			set { createUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUserTerminal_ID value.
		/// </summary>
		public string ModifiedUserTerminal_ID {
			get { return modifiedUserTerminal_ID; }
			set { modifiedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedUserTerminal_ID value.
		/// </summary>
		public string CheckedUserTerminal_ID {
			get { return checkedUserTerminal_ID; }
			set { checkedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUserTerminal_ID value.
		/// </summary>
		public string ApprovedUserTerminal_ID {
			get { return approvedUserTerminal_ID; }
			set { approvedUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CanceledUserTerminal_ID value.
		/// </summary>
		public string CanceledUserTerminal_ID {
			get { return canceledUserTerminal_ID; }
			set { canceledUserTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranchID value.
		/// </summary>
		public string CompanyBranchID {
			get { return companyBranchID; }
			set { companyBranchID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxFinishedGoodTransferAcceptance table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@acceptance_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
 
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
			scom.Parameters["@acceptance_Date"].Value = acceptance_Date;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@checkedUserTerminal_ID"].Value = checkedUserTerminal_ID;
			scom.Parameters["@approvedUserTerminal_ID"].Value = approvedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxFinishedGoodTransferAcceptance table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@acceptance_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateCanceled", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@canceledUserTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
			scom.Parameters["@acceptance_Date"].Value = acceptance_Date;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateCanceled"].Value = dateCanceled;
			scom.Parameters["@createUserTerminal_ID"].Value = createUserTerminal_ID;
			scom.Parameters["@modifiedUserTerminal_ID"].Value = modifiedUserTerminal_ID;
			scom.Parameters["@checkedUserTerminal_ID"].Value = checkedUserTerminal_ID;
			scom.Parameters["@approvedUserTerminal_ID"].Value = approvedUserTerminal_ID;
			scom.Parameters["@canceledUserTerminal_ID"].Value = canceledUserTerminal_ID;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxFinishedGoodTransferAcceptance table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxFinishedGoodTransferAcceptance table.
		/// </summary>
		public static tbl_prodTxFinishedGoodTransferAcceptance Select(string acceptance_ID_Incoming){

			tbl_prodTxFinishedGoodTransferAcceptance tbl_prodTxFinishedGoodTransferAcceptanceins = new tbl_prodTxFinishedGoodTransferAcceptance();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptanceins = Maketbl_prodTxFinishedGoodTransferAcceptance(dataReader);
				} else {
					tbl_prodTxFinishedGoodTransferAcceptanceins = null;
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptanceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxFinishedGoodTransferAcceptance> tbl_prodTxFinishedGoodTransferAcceptanceList = new List<tbl_prodTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance tbl_prodTxFinishedGoodTransferAcceptance = Maketbl_prodTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptanceList.Add(tbl_prodTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prodTxFinishedGoodTransferAcceptance> tbl_prodTxFinishedGoodTransferAcceptanceList = new List<tbl_prodTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance tbl_prodTxFinishedGoodTransferAcceptance = Maketbl_prodTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptanceList.Add(tbl_prodTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance> tbl_prodTxFinishedGoodTransferAcceptanceList = new List<tbl_prodTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance tbl_prodTxFinishedGoodTransferAcceptance = Maketbl_prodTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptanceList.Add(tbl_prodTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance> tbl_prodTxFinishedGoodTransferAcceptanceList = new List<tbl_prodTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance tbl_prodTxFinishedGoodTransferAcceptance = Maketbl_prodTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptanceList.Add(tbl_prodTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prodTxFinishedGoodTransferAcceptance> tbl_prodTxFinishedGoodTransferAcceptanceList = new List<tbl_prodTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance tbl_prodTxFinishedGoodTransferAcceptance = Maketbl_prodTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptanceList.Add(tbl_prodTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance> tbl_prodTxFinishedGoodTransferAcceptanceList = new List<tbl_prodTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance tbl_prodTxFinishedGoodTransferAcceptance = Maketbl_prodTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptanceList.Add(tbl_prodTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance> tbl_prodTxFinishedGoodTransferAcceptanceList = new List<tbl_prodTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance tbl_prodTxFinishedGoodTransferAcceptance = Maketbl_prodTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptanceList.Add(tbl_prodTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptanceSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance> tbl_prodTxFinishedGoodTransferAcceptanceList = new List<tbl_prodTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance tbl_prodTxFinishedGoodTransferAcceptance = Maketbl_prodTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptanceList.Add(tbl_prodTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxFinishedGoodTransferAcceptance class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxFinishedGoodTransferAcceptance Maketbl_prodTxFinishedGoodTransferAcceptance(SqlDataReader dataReader) {
			tbl_prodTxFinishedGoodTransferAcceptance tbl_prodTxFinishedGoodTransferAcceptance = new tbl_prodTxFinishedGoodTransferAcceptance();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.Acceptance_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.Acceptance_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.IsChecked = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.IsApproved = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.IsCanceled = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.CreateUser_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.ModifiedUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.CheckedUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.ApprovedUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.CanceldUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.DateCreate = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.DateModified = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.DateChecked = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.DateApproved = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.DateCanceled = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.CreateUserTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.ModifiedUserTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.CheckedUserTerminal_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.ApprovedUserTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.CanceledUserTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.CompanyID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance.CompanyBranchID = dataReader.GetString(22);
			}

			return tbl_prodTxFinishedGoodTransferAcceptance;
		}
		/// <summary>
		/// This makes tbl_prodTxFinishedGoodTransferAcceptance datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxFinishedGoodTransferAcceptance object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxFinishedGoodTransferAcceptance  tbl_prodTxFinishedGoodTransferAcceptance   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_acceptance_ID = new DataColumn("acceptance_ID" , typeof(string));
			DataColumn col_acceptance_Date = new DataColumn("acceptance_Date" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_canceldUser_ID = new DataColumn("canceldUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_dateCanceled = new DataColumn("dateCanceled" , typeof(DateTime));
			DataColumn col_createUserTerminal_ID = new DataColumn("createUserTerminal_ID" , typeof(string));
			DataColumn col_modifiedUserTerminal_ID = new DataColumn("modifiedUserTerminal_ID" , typeof(string));
			DataColumn col_checkedUserTerminal_ID = new DataColumn("checkedUserTerminal_ID" , typeof(string));
			DataColumn col_approvedUserTerminal_ID = new DataColumn("approvedUserTerminal_ID" , typeof(string));
			DataColumn col_canceledUserTerminal_ID = new DataColumn("canceledUserTerminal_ID" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranchID = new DataColumn("companyBranchID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_acceptance_ID,col_acceptance_Date,col_remark,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxFinishedGoodTransferAcceptance datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxFinishedGoodTransferAcceptance object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxFinishedGoodTransferAcceptance user) {
		DataRow drow = dt.NewRow();
		
			drow["acceptance_ID"] = user.acceptance_ID;
			drow["acceptance_Date"] = user.acceptance_Date;
			drow["remark"] = user.remark;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isCanceled"] = user.isCanceled;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["canceldUser_ID"] = user.canceldUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["dateCanceled"] = user.dateCanceled;
			drow["createUserTerminal_ID"] = user.createUserTerminal_ID;
			drow["modifiedUserTerminal_ID"] = user.modifiedUserTerminal_ID;
			drow["checkedUserTerminal_ID"] = user.checkedUserTerminal_ID;
			drow["approvedUserTerminal_ID"] = user.approvedUserTerminal_ID;
			drow["canceledUserTerminal_ID"] = user.canceledUserTerminal_ID;
			drow["companyID"] = user.companyID;
			drow["companyBranchID"] = user.companyBranchID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
