using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxSubContractOutNote {
		#region Fields
		private string subOut_ID;
		private DateTime subOut_Date;
		private string release_Dept_ID;
		private string release_Section_ID;
		private string supplier_ID;
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
		/// Initializes a new instance of the tbl_prod_pharmaTxSubContractOutNote class.
		/// </summary>
		public tbl_prod_pharmaTxSubContractOutNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxSubContractOutNote class.
		/// </summary>
		public tbl_prod_pharmaTxSubContractOutNote(string subOut_ID, DateTime subOut_Date, string release_Dept_ID, string release_Section_ID, string supplier_ID, string remark, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID) {
			this.subOut_ID = subOut_ID;
			this.subOut_Date = subOut_Date;
			this.release_Dept_ID = release_Dept_ID;
			this.release_Section_ID = release_Section_ID;
			this.supplier_ID = supplier_ID;
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
		/// Gets or sets the SubOut_ID value.
		/// </summary>
		public string SubOut_ID {
			get { return subOut_ID; }
			set { subOut_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubOut_Date value.
		/// </summary>
		public DateTime SubOut_Date {
			get { return subOut_Date; }
			set { subOut_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Release_Dept_ID value.
		/// </summary>
		public string Release_Dept_ID {
			get { return release_Dept_ID; }
			set { release_Dept_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Release_Section_ID value.
		/// </summary>
		public string Release_Section_ID {
			get { return release_Section_ID; }
			set { release_Section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
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
		/// Saves a record to the tbl_prod_pharmaTxSubContractOutNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subOut_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@release_Dept_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@release_Section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
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
 
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
			scom.Parameters["@subOut_Date"].Value = subOut_Date;
			scom.Parameters["@release_Dept_ID"].Value = release_Dept_ID;
			scom.Parameters["@release_Section_ID"].Value = release_Section_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
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
		/// Updates a record in the tbl_prod_pharmaTxSubContractOutNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subOut_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@release_Dept_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@release_Section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
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
 
 
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
			scom.Parameters["@subOut_Date"].Value = subOut_Date;
			scom.Parameters["@release_Dept_ID"].Value = release_Dept_ID;
			scom.Parameters["@release_Section_ID"].Value = release_Section_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
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
		/// Deletes a record from the tbl_prod_pharmaTxSubContractOutNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByRelease_Dept_ID(string release_Dept_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDeleteAllByRelease_Dept_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@release_Dept_ID", SqlDbType.VarChar,20);
			scom.Parameters["@release_Dept_ID"].Value = release_Dept_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByRelease_Section_ID(string release_Section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDeleteAllByRelease_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@release_Section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@release_Section_ID"].Value = release_Section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxSubContractOutNote table.
		/// </summary>
		public static tbl_prod_pharmaTxSubContractOutNote Select(string subOut_ID_Incoming){

			tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNoteins = new tbl_prod_pharmaTxSubContractOutNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subOut_ID"].Value = subOut_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNoteins = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
				} else {
					tbl_prod_pharmaTxSubContractOutNoteins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAllByRelease_Dept_ID(string release_Dept_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAllByRelease_Dept_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@release_Dept_ID", SqlDbType.VarChar,20);
			scom.Parameters["@release_Dept_ID"].Value = release_Dept_ID;
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAllByRelease_Section_ID(string release_Section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAllByRelease_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@release_Section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@release_Section_ID"].Value = release_Section_ID;
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNoteSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prod_pharmaTxSubContractOutNote> tbl_prod_pharmaTxSubContractOutNoteList = new List<tbl_prod_pharmaTxSubContractOutNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = Maketbl_prod_pharmaTxSubContractOutNote(dataReader);
					tbl_prod_pharmaTxSubContractOutNoteList.Add(tbl_prod_pharmaTxSubContractOutNote);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxSubContractOutNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxSubContractOutNote Maketbl_prod_pharmaTxSubContractOutNote(SqlDataReader dataReader) {
			tbl_prod_pharmaTxSubContractOutNote tbl_prod_pharmaTxSubContractOutNote = new tbl_prod_pharmaTxSubContractOutNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxSubContractOutNote.SubOut_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxSubContractOutNote.SubOut_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxSubContractOutNote.Release_Dept_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxSubContractOutNote.Release_Section_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxSubContractOutNote.Supplier_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxSubContractOutNote.Remark = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxSubContractOutNote.IsChecked = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxSubContractOutNote.IsApproved = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxSubContractOutNote.IsCanceled = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_pharmaTxSubContractOutNote.CreateUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_pharmaTxSubContractOutNote.ModifiedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_pharmaTxSubContractOutNote.CheckedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prod_pharmaTxSubContractOutNote.ApprovedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prod_pharmaTxSubContractOutNote.CanceldUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prod_pharmaTxSubContractOutNote.DateCreate = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prod_pharmaTxSubContractOutNote.DateModified = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prod_pharmaTxSubContractOutNote.DateChecked = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prod_pharmaTxSubContractOutNote.DateApproved = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prod_pharmaTxSubContractOutNote.DateCanceled = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prod_pharmaTxSubContractOutNote.CreateUserTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prod_pharmaTxSubContractOutNote.ModifiedUserTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prod_pharmaTxSubContractOutNote.CheckedUserTerminal_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prod_pharmaTxSubContractOutNote.ApprovedUserTerminal_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prod_pharmaTxSubContractOutNote.CanceledUserTerminal_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prod_pharmaTxSubContractOutNote.CompanyID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_prod_pharmaTxSubContractOutNote.CompanyBranchID = dataReader.GetString(25);
			}

			return tbl_prod_pharmaTxSubContractOutNote;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxSubContractOutNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxSubContractOutNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxSubContractOutNote  tbl_prod_pharmaTxSubContractOutNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_subOut_ID = new DataColumn("subOut_ID" , typeof(string));
			DataColumn col_subOut_Date = new DataColumn("subOut_Date" , typeof(DateTime));
			DataColumn col_release_Dept_ID = new DataColumn("release_Dept_ID" , typeof(string));
			DataColumn col_release_Section_ID = new DataColumn("release_Section_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_subOut_ID,col_subOut_Date,col_release_Dept_ID,col_release_Section_ID,col_supplier_ID,col_remark,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxSubContractOutNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxSubContractOutNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxSubContractOutNote user) {
		DataRow drow = dt.NewRow();
		
			drow["subOut_ID"] = user.subOut_ID;
			drow["subOut_Date"] = user.subOut_Date;
			drow["release_Dept_ID"] = user.release_Dept_ID;
			drow["release_Section_ID"] = user.release_Section_ID;
			drow["supplier_ID"] = user.supplier_ID;
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
