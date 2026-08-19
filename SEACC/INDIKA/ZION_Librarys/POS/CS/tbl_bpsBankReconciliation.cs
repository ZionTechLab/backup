using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsBankReconciliation {
		#region Fields
		private int companyAccount_ID;
		private int recSerialNo;
		private string statementNo;
		private string reference;
		private DateTime dateFrom;
		private DateTime dateTo;
		private decimal openingBalance;
		private decimal debit;
		private decimal credit;
		private decimal closingBalance;
		private decimal statementBalance;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isDeleted;
		private bool isChecked;
		private bool isApproved;
		private string companyID;
		private string companyBranch_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsBankReconciliation class.
		/// </summary>
		public tbl_bpsBankReconciliation() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsBankReconciliation class.
		/// </summary>
		public tbl_bpsBankReconciliation(int companyAccount_ID, int recSerialNo, string statementNo, string reference, DateTime dateFrom, DateTime dateTo, decimal openingBalance, decimal debit, decimal credit, decimal closingBalance, decimal statementBalance, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isDeleted, bool isChecked, bool isApproved, string companyID, string companyBranch_ID) {
			this.companyAccount_ID = companyAccount_ID;
			this.recSerialNo = recSerialNo;
			this.statementNo = statementNo;
			this.reference = reference;
			this.dateFrom = dateFrom;
			this.dateTo = dateTo;
			this.openingBalance = openingBalance;
			this.debit = debit;
			this.credit = credit;
			this.closingBalance = closingBalance;
			this.statementBalance = statementBalance;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isDeleted = isDeleted;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CompanyAccount_ID value.
		/// </summary>
		public int CompanyAccount_ID {
			get { return companyAccount_ID; }
			set { companyAccount_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RecSerialNo value.
		/// </summary>
		public int RecSerialNo {
			get { return recSerialNo; }
			set { recSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatementNo value.
		/// </summary>
		public string StatementNo {
			get { return statementNo; }
			set { statementNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Reference value.
		/// </summary>
		public string Reference {
			get { return reference; }
			set { reference = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateFrom value.
		/// </summary>
		public DateTime DateFrom {
			get { return dateFrom; }
			set { dateFrom = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateTo value.
		/// </summary>
		public DateTime DateTo {
			get { return dateTo; }
			set { dateTo = value; }
		}
		
		/// <summary>
		/// Gets or sets the OpeningBalance value.
		/// </summary>
		public decimal OpeningBalance {
			get { return openingBalance; }
			set { openingBalance = value; }
		}
		
		/// <summary>
		/// Gets or sets the Debit value.
		/// </summary>
		public decimal Debit {
			get { return debit; }
			set { debit = value; }
		}
		
		/// <summary>
		/// Gets or sets the Credit value.
		/// </summary>
		public decimal Credit {
			get { return credit; }
			set { credit = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClosingBalance value.
		/// </summary>
		public decimal ClosingBalance {
			get { return closingBalance; }
			set { closingBalance = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatementBalance value.
		/// </summary>
		public decimal StatementBalance {
			get { return statementBalance; }
			set { statementBalance = value; }
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
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
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
		/// Saves a record to the tbl_bpsBankReconciliation table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsBankReconciliationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
			scom.Parameters.Add("@statementNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reference", SqlDbType.VarChar,200);
			scom.Parameters.Add("@dateFrom", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateTo", SqlDbType.DateTime,8);
			scom.Parameters.Add("@openingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@debit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@credit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@closingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@statementBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
			scom.Parameters["@statementNo"].Value = statementNo;
			scom.Parameters["@reference"].Value = reference;
			scom.Parameters["@dateFrom"].Value = dateFrom;
			scom.Parameters["@dateTo"].Value = dateTo;
			scom.Parameters["@openingBalance"].Value = openingBalance;
			scom.Parameters["@debit"].Value = debit;
			scom.Parameters["@credit"].Value = credit;
			scom.Parameters["@closingBalance"].Value = closingBalance;
			scom.Parameters["@statementBalance"].Value = statementBalance;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsBankReconciliation table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsBankReconciliationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
			scom.Parameters.Add("@statementNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reference", SqlDbType.VarChar,200);
			scom.Parameters.Add("@dateFrom", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateTo", SqlDbType.DateTime,8);
			scom.Parameters.Add("@openingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@debit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@credit", SqlDbType.Decimal,9);
			scom.Parameters.Add("@closingBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@statementBalance", SqlDbType.Decimal,9);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
			scom.Parameters["@statementNo"].Value = statementNo;
			scom.Parameters["@reference"].Value = reference;
			scom.Parameters["@dateFrom"].Value = dateFrom;
			scom.Parameters["@dateTo"].Value = dateTo;
			scom.Parameters["@openingBalance"].Value = openingBalance;
			scom.Parameters["@debit"].Value = debit;
			scom.Parameters["@credit"].Value = credit;
			scom.Parameters["@closingBalance"].Value = closingBalance;
			scom.Parameters["@statementBalance"].Value = statementBalance;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsBankReconciliation table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsBankReconciliationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID;
 
			scom.Parameters["@recSerialNo"].Value = recSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsBankReconciliation table.
		/// </summary>
		public static tbl_bpsBankReconciliation Select(int companyAccount_ID_Incoming, int recSerialNo_Incoming){

			tbl_bpsBankReconciliation tbl_bpsBankReconciliationins = new tbl_bpsBankReconciliation();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsBankReconciliationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyAccount_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@recSerialNo", SqlDbType.Int,4);
			scom.Parameters["@companyAccount_ID"].Value = companyAccount_ID_Incoming;
			scom.Parameters["@recSerialNo"].Value = recSerialNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsBankReconciliationins = Maketbl_bpsBankReconciliation(dataReader);
				} else {
					tbl_bpsBankReconciliationins = null;
				}
			}
			scon.Close();
			return tbl_bpsBankReconciliationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsBankReconciliation table.
		/// </summary>
		public static List<tbl_bpsBankReconciliation> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsBankReconciliationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsBankReconciliation> tbl_bpsBankReconciliationList = new List<tbl_bpsBankReconciliation>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsBankReconciliation tbl_bpsBankReconciliation = Maketbl_bpsBankReconciliation(dataReader);
					tbl_bpsBankReconciliationList.Add(tbl_bpsBankReconciliation);
				}
			}
			scon.Close();
			return tbl_bpsBankReconciliationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsBankReconciliation class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsBankReconciliation Maketbl_bpsBankReconciliation(SqlDataReader dataReader) {
			tbl_bpsBankReconciliation tbl_bpsBankReconciliation = new tbl_bpsBankReconciliation();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsBankReconciliation.CompanyAccount_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsBankReconciliation.RecSerialNo = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsBankReconciliation.StatementNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsBankReconciliation.Reference = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsBankReconciliation.DateFrom = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsBankReconciliation.DateTo = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_bpsBankReconciliation.OpeningBalance = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_bpsBankReconciliation.Debit = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_bpsBankReconciliation.Credit = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_bpsBankReconciliation.ClosingBalance = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_bpsBankReconciliation.StatementBalance = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_bpsBankReconciliation.CreateUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_bpsBankReconciliation.ModifiedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_bpsBankReconciliation.CheckedUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_bpsBankReconciliation.ApprovedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_bpsBankReconciliation.DateCreate = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_bpsBankReconciliation.DateModified = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_bpsBankReconciliation.DateChecked = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_bpsBankReconciliation.DateApproved = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_bpsBankReconciliation.IsDeleted = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_bpsBankReconciliation.IsChecked = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_bpsBankReconciliation.IsApproved = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_bpsBankReconciliation.CompanyID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_bpsBankReconciliation.CompanyBranch_ID = dataReader.GetString(23);
			}

			return tbl_bpsBankReconciliation;
		}
		/// <summary>
		/// This makes tbl_bpsBankReconciliation datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsBankReconciliation object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsBankReconciliation  tbl_bpsBankReconciliation   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyAccount_ID = new DataColumn("companyAccount_ID" , typeof(int));
			DataColumn col_recSerialNo = new DataColumn("recSerialNo" , typeof(int));
			DataColumn col_statementNo = new DataColumn("statementNo" , typeof(string));
			DataColumn col_reference = new DataColumn("reference" , typeof(string));
			DataColumn col_dateFrom = new DataColumn("dateFrom" , typeof(DateTime));
			DataColumn col_dateTo = new DataColumn("dateTo" , typeof(DateTime));
			DataColumn col_openingBalance = new DataColumn("openingBalance" , typeof(decimal));
			DataColumn col_debit = new DataColumn("debit" , typeof(decimal));
			DataColumn col_credit = new DataColumn("credit" , typeof(decimal));
			DataColumn col_closingBalance = new DataColumn("closingBalance" , typeof(decimal));
			DataColumn col_statementBalance = new DataColumn("statementBalance" , typeof(decimal));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_companyAccount_ID,col_recSerialNo,col_statementNo,col_reference,col_dateFrom,col_dateTo,col_openingBalance,col_debit,col_credit,col_closingBalance,col_statementBalance,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isDeleted,col_isChecked,col_isApproved,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsBankReconciliation datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsBankReconciliation object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsBankReconciliation user) {
		DataRow drow = dt.NewRow();
		
			drow["companyAccount_ID"] = user.companyAccount_ID;
			drow["recSerialNo"] = user.recSerialNo;
			drow["statementNo"] = user.statementNo;
			drow["reference"] = user.reference;
			drow["dateFrom"] = user.dateFrom;
			drow["dateTo"] = user.dateTo;
			drow["openingBalance"] = user.openingBalance;
			drow["debit"] = user.debit;
			drow["credit"] = user.credit;
			drow["closingBalance"] = user.closingBalance;
			drow["statementBalance"] = user.statementBalance;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isDeleted"] = user.isDeleted;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
