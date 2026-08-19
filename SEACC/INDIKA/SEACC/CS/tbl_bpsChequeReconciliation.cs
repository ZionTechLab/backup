using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsChequeReconciliation {
		#region Fields
		private string reconciliation_ID;
		private string remark;
		private DateTime dateReconciliation;
		private decimal totalCheque;
		private decimal totalAmount;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private string companyID;
		private string companyBranch_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeReconciliation class.
		/// </summary>
		public tbl_bpsChequeReconciliation() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsChequeReconciliation class.
		/// </summary>
		public tbl_bpsChequeReconciliation(string reconciliation_ID, string remark, DateTime dateReconciliation, decimal totalCheque, decimal totalAmount, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, string companyID, string companyBranch_ID) {
			this.reconciliation_ID = reconciliation_ID;
			this.remark = remark;
			this.dateReconciliation = dateReconciliation;
			this.totalCheque = totalCheque;
			this.totalAmount = totalAmount;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Reconciliation_ID value.
		/// </summary>
		public string Reconciliation_ID {
			get { return reconciliation_ID; }
			set { reconciliation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateReconciliation value.
		/// </summary>
		public DateTime DateReconciliation {
			get { return dateReconciliation; }
			set { dateReconciliation = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalCheque value.
		/// </summary>
		public decimal TotalCheque {
			get { return totalCheque; }
			set { totalCheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
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
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsChequeReconciliation table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateReconciliation", SqlDbType.DateTime,8);
			scom.Parameters.Add("@totalCheque", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dateReconciliation"].Value = dateReconciliation;
			scom.Parameters["@totalCheque"].Value = totalCheque;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsChequeReconciliation table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateReconciliation", SqlDbType.DateTime,8);
			scom.Parameters.Add("@totalCheque", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@dateReconciliation"].Value = dateReconciliation;
			scom.Parameters["@totalCheque"].Value = totalCheque;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsChequeReconciliation table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReconciliation table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliationDeleteAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReconciliation table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliationDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsChequeReconciliation table.
		/// </summary>
		public static tbl_bpsChequeReconciliation Select(string reconciliation_ID_Incoming){

			tbl_bpsChequeReconciliation tbl_bpsChequeReconciliationins = new tbl_bpsChequeReconciliation();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@reconciliation_ID", SqlDbType.VarChar,20);
			scom.Parameters["@reconciliation_ID"].Value = reconciliation_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsChequeReconciliationins = Maketbl_bpsChequeReconciliation(dataReader);
				} else {
					tbl_bpsChequeReconciliationins = null;
				}
			}
			scon.Close();
			return tbl_bpsChequeReconciliationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReconciliation table.
		/// </summary>
		public static List<tbl_bpsChequeReconciliation> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsChequeReconciliation> tbl_bpsChequeReconciliationList = new List<tbl_bpsChequeReconciliation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeReconciliation tbl_bpsChequeReconciliation = Maketbl_bpsChequeReconciliation(dataReader);
					tbl_bpsChequeReconciliationList.Add(tbl_bpsChequeReconciliation);
				}
			}
			scon.Close();
			return tbl_bpsChequeReconciliationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReconciliation table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeReconciliation> SelectAllByCompanyBranch_ID(string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliationSelectAllByCompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_bpsChequeReconciliation> tbl_bpsChequeReconciliationList = new List<tbl_bpsChequeReconciliation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeReconciliation tbl_bpsChequeReconciliation = Maketbl_bpsChequeReconciliation(dataReader);
					tbl_bpsChequeReconciliationList.Add(tbl_bpsChequeReconciliation);
				}
			}
			scon.Close();
			return tbl_bpsChequeReconciliationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsChequeReconciliation table by a foreign key.
		/// </summary>
		public static List<tbl_bpsChequeReconciliation> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsChequeReconciliationSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_bpsChequeReconciliation> tbl_bpsChequeReconciliationList = new List<tbl_bpsChequeReconciliation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsChequeReconciliation tbl_bpsChequeReconciliation = Maketbl_bpsChequeReconciliation(dataReader);
					tbl_bpsChequeReconciliationList.Add(tbl_bpsChequeReconciliation);
				}
			}
			scon.Close();
			return tbl_bpsChequeReconciliationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsChequeReconciliation class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsChequeReconciliation Maketbl_bpsChequeReconciliation(SqlDataReader dataReader) {
			tbl_bpsChequeReconciliation tbl_bpsChequeReconciliation = new tbl_bpsChequeReconciliation();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsChequeReconciliation.Reconciliation_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsChequeReconciliation.Remark = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsChequeReconciliation.DateReconciliation = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsChequeReconciliation.TotalCheque = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsChequeReconciliation.TotalAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsChequeReconciliation.CreateUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsChequeReconciliation.ModifiedUser_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsChequeReconciliation.CheckedUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsChequeReconciliation.ApprovedUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsChequeReconciliation.DateCreate = dataReader.GetDateTime(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsChequeReconciliation.DateModified = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsChequeReconciliation.DateChecked = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsChequeReconciliation.DateApproved = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsChequeReconciliation.IsChecked = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsChequeReconciliation.IsApproved = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsChequeReconciliation.IsFinished = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsChequeReconciliation.IsDeleted = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsChequeReconciliation.IsLocked = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsChequeReconciliation.CompanyID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsChequeReconciliation.CompanyBranch_ID = dataReader.GetString(19);
			}

			return tbl_bpsChequeReconciliation;
		}
		/// <summary>
		/// This makes tbl_bpsChequeReconciliation datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsChequeReconciliation object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsChequeReconciliation  tbl_bpsChequeReconciliation   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_reconciliation_ID = new DataColumn("reconciliation_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_dateReconciliation = new DataColumn("dateReconciliation" , typeof(DateTime));
			DataColumn col_totalCheque = new DataColumn("totalCheque" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_reconciliation_ID,col_remark,col_dateReconciliation,col_totalCheque,col_totalAmount,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsChequeReconciliation datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsChequeReconciliation object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsChequeReconciliation user) {
		DataRow drow = dt.NewRow();
		
			drow["reconciliation_ID"] = user.reconciliation_ID;
			drow["remark"] = user.remark;
			drow["dateReconciliation"] = user.dateReconciliation;
			drow["totalCheque"] = user.totalCheque;
			drow["totalAmount"] = user.totalAmount;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
