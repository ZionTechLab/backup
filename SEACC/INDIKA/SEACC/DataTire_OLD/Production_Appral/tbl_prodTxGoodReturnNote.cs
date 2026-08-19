using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxGoodReturnNote {
		#region Fields
		private string pGRN_No;
		private DateTime pGRN_Date;
		private string fromSection_ID;
		private string fromSection_HOD_ID;
		private string store_ID;
		private string prodJob_ID;
		private string prodBatch_ID;
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
		/// Initializes a new instance of the tbl_prodTxGoodReturnNote class.
		/// </summary>
		public tbl_prodTxGoodReturnNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxGoodReturnNote class.
		/// </summary>
		public tbl_prodTxGoodReturnNote(string pGRN_No, DateTime pGRN_Date, string fromSection_ID, string fromSection_HOD_ID, string store_ID, string prodJob_ID, string prodBatch_ID, string remark, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID) {
			this.pGRN_No = pGRN_No;
			this.pGRN_Date = pGRN_Date;
			this.fromSection_ID = fromSection_ID;
			this.fromSection_HOD_ID = fromSection_HOD_ID;
			this.store_ID = store_ID;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
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
		/// Gets or sets the PGRN_No value.
		/// </summary>
		public string PGRN_No {
			get { return pGRN_No; }
			set { pGRN_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PGRN_Date value.
		/// </summary>
		public DateTime PGRN_Date {
			get { return pGRN_Date; }
			set { pGRN_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromSection_ID value.
		/// </summary>
		public string FromSection_ID {
			get { return fromSection_ID; }
			set { fromSection_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromSection_HOD_ID value.
		/// </summary>
		public string FromSection_HOD_ID {
			get { return fromSection_HOD_ID; }
			set { fromSection_HOD_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdBatch_ID value.
		/// </summary>
		public string ProdBatch_ID {
			get { return prodBatch_ID; }
			set { prodBatch_ID = value; }
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
		/// Saves a record to the tbl_prodTxGoodReturnNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pGRN_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSection_HOD_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
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
 
			scom.Parameters["@pGRN_No"].Value = pGRN_No;
			scom.Parameters["@pGRN_Date"].Value = pGRN_Date;
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
			scom.Parameters["@fromSection_HOD_ID"].Value = fromSection_HOD_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
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
		/// Updates a record in the tbl_prodTxGoodReturnNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pGRN_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fromSection_HOD_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
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
 
 
			scom.Parameters["@pGRN_No"].Value = pGRN_No;
			scom.Parameters["@pGRN_Date"].Value = pGRN_Date;
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
			scom.Parameters["@fromSection_HOD_ID"].Value = fromSection_HOD_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
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
		/// Deletes a record from the tbl_prodTxGoodReturnNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters["@pGRN_No"].Value = pGRN_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByFromSection_ID(string fromSection_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByFromSection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByFromSection_HOD_ID(string fromSection_HOD_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteDeleteAllByFromSection_HOD_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSection_HOD_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fromSection_HOD_ID"].Value = fromSection_HOD_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxGoodReturnNote table.
		/// </summary>
		public static tbl_prodTxGoodReturnNote Select(string pGRN_No_Incoming){

			tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNoteins = new tbl_prodTxGoodReturnNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pGRN_No", SqlDbType.VarChar,20);
			scom.Parameters["@pGRN_No"].Value = pGRN_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxGoodReturnNoteins = Maketbl_prodTxGoodReturnNote(dataReader);
				} else {
					tbl_prodTxGoodReturnNoteins = null;
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByFromSection_ID(string fromSection_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByFromSection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSection_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fromSection_ID"].Value = fromSection_ID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodReturnNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodReturnNote> SelectAllByFromSection_HOD_ID(string fromSection_HOD_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodReturnNoteSelectAllByFromSection_HOD_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fromSection_HOD_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fromSection_HOD_ID"].Value = fromSection_HOD_ID;
				List<tbl_prodTxGoodReturnNote> tbl_prodTxGoodReturnNoteList = new List<tbl_prodTxGoodReturnNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = Maketbl_prodTxGoodReturnNote(dataReader);
					tbl_prodTxGoodReturnNoteList.Add(tbl_prodTxGoodReturnNote);
				}
			}
			scon.Close();
			return tbl_prodTxGoodReturnNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxGoodReturnNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxGoodReturnNote Maketbl_prodTxGoodReturnNote(SqlDataReader dataReader) {
			tbl_prodTxGoodReturnNote tbl_prodTxGoodReturnNote = new tbl_prodTxGoodReturnNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxGoodReturnNote.PGRN_No = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxGoodReturnNote.PGRN_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxGoodReturnNote.FromSection_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxGoodReturnNote.FromSection_HOD_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxGoodReturnNote.Store_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxGoodReturnNote.ProdJob_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxGoodReturnNote.ProdBatch_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxGoodReturnNote.Remark = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxGoodReturnNote.IsChecked = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxGoodReturnNote.IsApproved = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxGoodReturnNote.IsCanceled = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxGoodReturnNote.CreateUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxGoodReturnNote.ModifiedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prodTxGoodReturnNote.CheckedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prodTxGoodReturnNote.ApprovedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prodTxGoodReturnNote.CanceldUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prodTxGoodReturnNote.DateCreate = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prodTxGoodReturnNote.DateModified = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prodTxGoodReturnNote.DateChecked = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prodTxGoodReturnNote.DateApproved = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prodTxGoodReturnNote.DateCanceled = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prodTxGoodReturnNote.CreateUserTerminal_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prodTxGoodReturnNote.ModifiedUserTerminal_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prodTxGoodReturnNote.CheckedUserTerminal_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prodTxGoodReturnNote.ApprovedUserTerminal_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_prodTxGoodReturnNote.CanceledUserTerminal_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_prodTxGoodReturnNote.CompanyID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_prodTxGoodReturnNote.CompanyBranchID = dataReader.GetString(27);
			}

			return tbl_prodTxGoodReturnNote;
		}
		/// <summary>
		/// This makes tbl_prodTxGoodReturnNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxGoodReturnNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxGoodReturnNote  tbl_prodTxGoodReturnNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_pGRN_No = new DataColumn("pGRN_No" , typeof(string));
			DataColumn col_pGRN_Date = new DataColumn("pGRN_Date" , typeof(DateTime));
			DataColumn col_fromSection_ID = new DataColumn("fromSection_ID" , typeof(string));
			DataColumn col_fromSection_HOD_ID = new DataColumn("fromSection_HOD_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_pGRN_No,col_pGRN_Date,col_fromSection_ID,col_fromSection_HOD_ID,col_store_ID,col_prodJob_ID,col_prodBatch_ID,col_remark,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxGoodReturnNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxGoodReturnNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxGoodReturnNote user) {
		DataRow drow = dt.NewRow();
		
			drow["pGRN_No"] = user.pGRN_No;
			drow["pGRN_Date"] = user.pGRN_Date;
			drow["fromSection_ID"] = user.fromSection_ID;
			drow["fromSection_HOD_ID"] = user.fromSection_HOD_ID;
			drow["store_ID"] = user.store_ID;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
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
