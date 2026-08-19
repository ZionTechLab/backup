using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxGoodIssueNote {
		#region Fields
		private string pGIN_No;
		private DateTime pGIN_Date;
		private string store_ID;
		private string ordered_HOD;
		private string itemCollectedBy;
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
		/// Initializes a new instance of the tbl_prodTxGoodIssueNote class.
		/// </summary>
		public tbl_prodTxGoodIssueNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxGoodIssueNote class.
		/// </summary>
		public tbl_prodTxGoodIssueNote(string pGIN_No, DateTime pGIN_Date, string store_ID, string ordered_HOD, string itemCollectedBy, string remark, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID) {
			this.pGIN_No = pGIN_No;
			this.pGIN_Date = pGIN_Date;
			this.store_ID = store_ID;
			this.ordered_HOD = ordered_HOD;
			this.itemCollectedBy = itemCollectedBy;
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
		/// Gets or sets the PGIN_No value.
		/// </summary>
		public string PGIN_No {
			get { return pGIN_No; }
			set { pGIN_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PGIN_Date value.
		/// </summary>
		public DateTime PGIN_Date {
			get { return pGIN_Date; }
			set { pGIN_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ordered_HOD value.
		/// </summary>
		public string Ordered_HOD {
			get { return ordered_HOD; }
			set { ordered_HOD = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCollectedBy value.
		/// </summary>
		public string ItemCollectedBy {
			get { return itemCollectedBy; }
			set { itemCollectedBy = value; }
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
		/// Saves a record to the tbl_prodTxGoodIssueNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pGIN_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pGIN_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@ordered_HOD", SqlDbType.VarChar,20);
			scom.Parameters.Add("@ItemCollectedBy", SqlDbType.VarChar,20);
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
 
			scom.Parameters["@pGIN_No"].Value = pGIN_No;
			scom.Parameters["@pGIN_Date"].Value = pGIN_Date;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@ordered_HOD"].Value = ordered_HOD;
			scom.Parameters["@ItemCollectedBy"].Value = itemCollectedBy;
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
		/// Updates a record in the tbl_prodTxGoodIssueNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pGIN_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pGIN_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@ordered_HOD", SqlDbType.VarChar,20);
			scom.Parameters.Add("@ItemCollectedBy", SqlDbType.VarChar,20);
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
 
 
			scom.Parameters["@pGIN_No"].Value = pGIN_No;
			scom.Parameters["@pGIN_Date"].Value = pGIN_Date;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@ordered_HOD"].Value = ordered_HOD;
			scom.Parameters["@ItemCollectedBy"].Value = itemCollectedBy;
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
		/// Deletes a record from the tbl_prodTxGoodIssueNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pGIN_No", SqlDbType.VarChar,20);
			scom.Parameters["@pGIN_No"].Value = pGIN_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByOrdered_HOD(string ordered_HOD) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDeleteAllByOrdered_HOD", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@ordered_HOD", SqlDbType.VarChar,20);
			scom.Parameters["@ordered_HOD"].Value = ordered_HOD;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemCollectedBy(string itemCollectedBy) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDeleteAllByItemCollectedBy", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@ItemCollectedBy", SqlDbType.VarChar,20);
			scom.Parameters["@ItemCollectedBy"].Value = itemCollectedBy;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxGoodIssueNote table.
		/// </summary>
		public static tbl_prodTxGoodIssueNote Select(string pGIN_No_Incoming){

			tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNoteins = new tbl_prodTxGoodIssueNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pGIN_No", SqlDbType.VarChar,20);
			scom.Parameters["@pGIN_No"].Value = pGIN_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxGoodIssueNoteins = Maketbl_prodTxGoodIssueNote(dataReader);
				} else {
					tbl_prodTxGoodIssueNoteins = null;
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAllByOrdered_HOD(string ordered_HOD) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAllByOrdered_HOD", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@ordered_HOD", SqlDbType.VarChar,20);
			scom.Parameters["@ordered_HOD"].Value = ordered_HOD;
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAllByItemCollectedBy(string itemCollectedBy) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAllByItemCollectedBy", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@ItemCollectedBy", SqlDbType.VarChar,20);
			scom.Parameters["@ItemCollectedBy"].Value = itemCollectedBy;
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNoteSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prodTxGoodIssueNote> tbl_prodTxGoodIssueNoteList = new List<tbl_prodTxGoodIssueNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = Maketbl_prodTxGoodIssueNote(dataReader);
					tbl_prodTxGoodIssueNoteList.Add(tbl_prodTxGoodIssueNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxGoodIssueNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxGoodIssueNote Maketbl_prodTxGoodIssueNote(SqlDataReader dataReader) {
			tbl_prodTxGoodIssueNote tbl_prodTxGoodIssueNote = new tbl_prodTxGoodIssueNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxGoodIssueNote.PGIN_No = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxGoodIssueNote.PGIN_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxGoodIssueNote.Store_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxGoodIssueNote.Ordered_HOD = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxGoodIssueNote.ItemCollectedBy = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxGoodIssueNote.Remark = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxGoodIssueNote.IsChecked = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxGoodIssueNote.IsApproved = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxGoodIssueNote.IsCanceled = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxGoodIssueNote.CreateUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxGoodIssueNote.ModifiedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxGoodIssueNote.CheckedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxGoodIssueNote.ApprovedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prodTxGoodIssueNote.CanceldUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prodTxGoodIssueNote.DateCreate = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prodTxGoodIssueNote.DateModified = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prodTxGoodIssueNote.DateChecked = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prodTxGoodIssueNote.DateApproved = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prodTxGoodIssueNote.DateCanceled = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prodTxGoodIssueNote.CreateUserTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prodTxGoodIssueNote.ModifiedUserTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prodTxGoodIssueNote.CheckedUserTerminal_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prodTxGoodIssueNote.ApprovedUserTerminal_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prodTxGoodIssueNote.CanceledUserTerminal_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prodTxGoodIssueNote.CompanyID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_prodTxGoodIssueNote.CompanyBranchID = dataReader.GetString(25);
			}

			return tbl_prodTxGoodIssueNote;
		}
		/// <summary>
		/// This makes tbl_prodTxGoodIssueNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxGoodIssueNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxGoodIssueNote  tbl_prodTxGoodIssueNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pGIN_No = new DataColumn("pGIN_No" , typeof(string));
			DataColumn col_pGIN_Date = new DataColumn("pGIN_Date" , typeof(DateTime));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_ordered_HOD = new DataColumn("ordered_HOD" , typeof(string));
			DataColumn col_ItemCollectedBy = new DataColumn("ItemCollectedBy" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_pGIN_No,col_pGIN_Date,col_store_ID,col_ordered_HOD,col_ItemCollectedBy,col_remark,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxGoodIssueNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxGoodIssueNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxGoodIssueNote user) {
		DataRow drow = dt.NewRow();
		
			drow["pGIN_No"] = user.pGIN_No;
			drow["pGIN_Date"] = user.pGIN_Date;
			drow["store_ID"] = user.store_ID;
			drow["ordered_HOD"] = user.ordered_HOD;
			drow["ItemCollectedBy"] = user.ItemCollectedBy;
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
