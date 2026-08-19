using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_polyTxMaterialRequision {
		#region Fields
		private string mr_No;
		private DateTime mr_Date;
		private string section_ID;
		private DateTime planDate_from;
		private DateTime planDate_to;
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
		/// Initializes a new instance of the tbl_prod_polyTxMaterialRequision class.
		/// </summary>
		public tbl_prod_polyTxMaterialRequision() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyTxMaterialRequision class.
		/// </summary>
		public tbl_prod_polyTxMaterialRequision(string mr_No, DateTime mr_Date, string section_ID, DateTime planDate_from, DateTime planDate_to, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID) {
			this.mr_No = mr_No;
			this.mr_Date = mr_Date;
			this.section_ID = section_ID;
			this.planDate_from = planDate_from;
			this.planDate_to = planDate_to;
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
		/// Gets or sets the Mr_No value.
		/// </summary>
		public string Mr_No {
			get { return mr_No; }
			set { mr_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mr_Date value.
		/// </summary>
		public DateTime Mr_Date {
			get { return mr_Date; }
			set { mr_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PlanDate_from value.
		/// </summary>
		public DateTime PlanDate_from {
			get { return planDate_from; }
			set { planDate_from = value; }
		}
		
		/// <summary>
		/// Gets or sets the PlanDate_to value.
		/// </summary>
		public DateTime PlanDate_to {
			get { return planDate_to; }
			set { planDate_to = value; }
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
		/// Saves a record to the tbl_prod_polyTxMaterialRequision table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mr_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@planDate_from", SqlDbType.DateTime,8);
			scom.Parameters.Add("@planDate_to", SqlDbType.DateTime,8);
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
 
			scom.Parameters["@mr_No"].Value = mr_No;
			scom.Parameters["@mr_Date"].Value = mr_Date;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@planDate_from"].Value = planDate_from;
			scom.Parameters["@planDate_to"].Value = planDate_to;
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
		/// Updates a record in the tbl_prod_polyTxMaterialRequision table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mr_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@planDate_from", SqlDbType.DateTime,8);
			scom.Parameters.Add("@planDate_to", SqlDbType.DateTime,8);
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
 
 
			scom.Parameters["@mr_No"].Value = mr_No;
			scom.Parameters["@mr_Date"].Value = mr_Date;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@planDate_from"].Value = planDate_from;
			scom.Parameters["@planDate_to"].Value = planDate_to;
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
		/// Deletes a record from the tbl_prod_polyTxMaterialRequision table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static void DeleteAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionDeleteAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_polyTxMaterialRequision table.
		/// </summary>
		public static tbl_prod_polyTxMaterialRequision Select(string mr_No_Incoming){

			tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequisionins = new tbl_prod_polyTxMaterialRequision();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequisionins = Maketbl_prod_polyTxMaterialRequision(dataReader);
				} else {
					tbl_prod_polyTxMaterialRequisionins = null;
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequisionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_polyTxMaterialRequision> tbl_prod_polyTxMaterialRequisionList = new List<tbl_prod_polyTxMaterialRequision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequision = Maketbl_prod_polyTxMaterialRequision(dataReader);
					tbl_prod_polyTxMaterialRequisionList.Add(tbl_prod_polyTxMaterialRequision);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequisionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prod_polyTxMaterialRequision> tbl_prod_polyTxMaterialRequisionList = new List<tbl_prod_polyTxMaterialRequision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequision = Maketbl_prod_polyTxMaterialRequision(dataReader);
					tbl_prod_polyTxMaterialRequisionList.Add(tbl_prod_polyTxMaterialRequision);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequisionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prod_polyTxMaterialRequision> tbl_prod_polyTxMaterialRequisionList = new List<tbl_prod_polyTxMaterialRequision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequision = Maketbl_prod_polyTxMaterialRequision(dataReader);
					tbl_prod_polyTxMaterialRequisionList.Add(tbl_prod_polyTxMaterialRequision);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequisionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prod_polyTxMaterialRequision> tbl_prod_polyTxMaterialRequisionList = new List<tbl_prod_polyTxMaterialRequision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequision = Maketbl_prod_polyTxMaterialRequision(dataReader);
					tbl_prod_polyTxMaterialRequisionList.Add(tbl_prod_polyTxMaterialRequision);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequisionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prod_polyTxMaterialRequision> tbl_prod_polyTxMaterialRequisionList = new List<tbl_prod_polyTxMaterialRequision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequision = Maketbl_prod_polyTxMaterialRequision(dataReader);
					tbl_prod_polyTxMaterialRequisionList.Add(tbl_prod_polyTxMaterialRequision);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequisionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prod_polyTxMaterialRequision> tbl_prod_polyTxMaterialRequisionList = new List<tbl_prod_polyTxMaterialRequision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequision = Maketbl_prod_polyTxMaterialRequision(dataReader);
					tbl_prod_polyTxMaterialRequisionList.Add(tbl_prod_polyTxMaterialRequision);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequisionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prod_polyTxMaterialRequision> tbl_prod_polyTxMaterialRequisionList = new List<tbl_prod_polyTxMaterialRequision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequision = Maketbl_prod_polyTxMaterialRequision(dataReader);
					tbl_prod_polyTxMaterialRequisionList.Add(tbl_prod_polyTxMaterialRequision);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequisionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prod_polyTxMaterialRequision> tbl_prod_polyTxMaterialRequisionList = new List<tbl_prod_polyTxMaterialRequision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequision = Maketbl_prod_polyTxMaterialRequision(dataReader);
					tbl_prod_polyTxMaterialRequisionList.Add(tbl_prod_polyTxMaterialRequision);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequisionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision> SelectAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequisionSelectAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_prod_polyTxMaterialRequision> tbl_prod_polyTxMaterialRequisionList = new List<tbl_prod_polyTxMaterialRequision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequision = Maketbl_prod_polyTxMaterialRequision(dataReader);
					tbl_prod_polyTxMaterialRequisionList.Add(tbl_prod_polyTxMaterialRequision);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequisionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_polyTxMaterialRequision class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_polyTxMaterialRequision Maketbl_prod_polyTxMaterialRequision(SqlDataReader dataReader) {
			tbl_prod_polyTxMaterialRequision tbl_prod_polyTxMaterialRequision = new tbl_prod_polyTxMaterialRequision();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_polyTxMaterialRequision.Mr_No = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_polyTxMaterialRequision.Mr_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_polyTxMaterialRequision.Section_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_polyTxMaterialRequision.PlanDate_from = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_polyTxMaterialRequision.PlanDate_to = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_polyTxMaterialRequision.IsChecked = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_polyTxMaterialRequision.IsApproved = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_polyTxMaterialRequision.IsCanceled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_polyTxMaterialRequision.CreateUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_polyTxMaterialRequision.ModifiedUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_polyTxMaterialRequision.CheckedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_polyTxMaterialRequision.ApprovedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prod_polyTxMaterialRequision.CanceldUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prod_polyTxMaterialRequision.DateCreate = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prod_polyTxMaterialRequision.DateModified = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prod_polyTxMaterialRequision.DateChecked = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prod_polyTxMaterialRequision.DateApproved = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prod_polyTxMaterialRequision.DateCanceled = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prod_polyTxMaterialRequision.CreateUserTerminal_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prod_polyTxMaterialRequision.ModifiedUserTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prod_polyTxMaterialRequision.CheckedUserTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prod_polyTxMaterialRequision.ApprovedUserTerminal_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prod_polyTxMaterialRequision.CanceledUserTerminal_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prod_polyTxMaterialRequision.CompanyID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prod_polyTxMaterialRequision.CompanyBranchID = dataReader.GetString(24);
			}

			return tbl_prod_polyTxMaterialRequision;
		}
		/// <summary>
		/// This makes tbl_prod_polyTxMaterialRequision datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_polyTxMaterialRequision object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_polyTxMaterialRequision  tbl_prod_polyTxMaterialRequision   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_mr_No = new DataColumn("mr_No" , typeof(string));
			DataColumn col_mr_Date = new DataColumn("mr_Date" , typeof(DateTime));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_planDate_from = new DataColumn("planDate_from" , typeof(DateTime));
			DataColumn col_planDate_to = new DataColumn("planDate_to" , typeof(DateTime));
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
		dt.Columns.AddRange(new DataColumn[] { col_mr_No,col_mr_Date,col_section_ID,col_planDate_from,col_planDate_to,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_polyTxMaterialRequision datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_polyTxMaterialRequision object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_polyTxMaterialRequision user) {
		DataRow drow = dt.NewRow();
		
			drow["mr_No"] = user.mr_No;
			drow["mr_Date"] = user.mr_Date;
			drow["section_ID"] = user.section_ID;
			drow["planDate_from"] = user.planDate_from;
			drow["planDate_to"] = user.planDate_to;
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
