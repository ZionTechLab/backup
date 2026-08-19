using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxBatch_Closure {
		#region Fields
		private string closure_ID;
		private string prodJob_ID;
		private string prodBatch_ID;
		private int batchStatus;
		private DateTime closure_DateTime;
		private string remarks;
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
		private string item_ID_FG;
		private decimal unitCost_Actual_FG;
		private decimal qty_Actual_FG;
		private string uom_ID_FG;
		private decimal totalCost_Actual_FG;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxBatch_Closure class.
		/// </summary>
		public tbl_prod_pharmaTxBatch_Closure() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxBatch_Closure class.
		/// </summary>
		public tbl_prod_pharmaTxBatch_Closure(string closure_ID, string prodJob_ID, string prodBatch_ID, int batchStatus, DateTime closure_DateTime, string remarks, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID, string item_ID_FG, decimal unitCost_Actual_FG, decimal qty_Actual_FG, string uom_ID_FG, decimal totalCost_Actual_FG) {
			this.closure_ID = closure_ID;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.batchStatus = batchStatus;
			this.closure_DateTime = closure_DateTime;
			this.remarks = remarks;
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
			this.item_ID_FG = item_ID_FG;
			this.unitCost_Actual_FG = unitCost_Actual_FG;
			this.qty_Actual_FG = qty_Actual_FG;
			this.uom_ID_FG = uom_ID_FG;
			this.totalCost_Actual_FG = totalCost_Actual_FG;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Closure_ID value.
		/// </summary>
		public string Closure_ID {
			get { return closure_ID; }
			set { closure_ID = value; }
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
		/// Gets or sets the BatchStatus value.
		/// </summary>
		public int BatchStatus {
			get { return batchStatus; }
			set { batchStatus = value; }
		}
		
		/// <summary>
		/// Gets or sets the Closure_DateTime value.
		/// </summary>
		public DateTime Closure_DateTime {
			get { return closure_DateTime; }
			set { closure_DateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
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
		
		/// <summary>
		/// Gets or sets the Item_ID_FG value.
		/// </summary>
		public string Item_ID_FG {
			get { return item_ID_FG; }
			set { item_ID_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitCost_Actual_FG value.
		/// </summary>
		public decimal UnitCost_Actual_FG {
			get { return unitCost_Actual_FG; }
			set { unitCost_Actual_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Actual_FG value.
		/// </summary>
		public decimal Qty_Actual_FG {
			get { return qty_Actual_FG; }
			set { qty_Actual_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID_FG value.
		/// </summary>
		public string Uom_ID_FG {
			get { return uom_ID_FG; }
			set { uom_ID_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalCost_Actual_FG value.
		/// </summary>
		public decimal TotalCost_Actual_FG {
			get { return totalCost_Actual_FG; }
			set { totalCost_Actual_FG = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxBatch_Closure table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@closure_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batchStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@closure_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
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
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@unitCost_Actual_FG", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Actual_FG", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_FG", SqlDbType.VarChar,10);
			scom.Parameters.Add("@totalCost_Actual_FG", SqlDbType.Decimal,9);
 
			scom.Parameters["@closure_ID"].Value = closure_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@batchStatus"].Value = batchStatus;
			scom.Parameters["@closure_DateTime"].Value = closure_DateTime;
			scom.Parameters["@remarks"].Value = remarks;
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
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@unitCost_Actual_FG"].Value = unitCost_Actual_FG;
			scom.Parameters["@qty_Actual_FG"].Value = qty_Actual_FG;
			scom.Parameters["@uom_ID_FG"].Value = uom_ID_FG;
			scom.Parameters["@totalCost_Actual_FG"].Value = totalCost_Actual_FG;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxBatch_Closure table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@closure_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batchStatus", SqlDbType.Int,4);
			scom.Parameters.Add("@closure_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
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
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@unitCost_Actual_FG", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Actual_FG", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID_FG", SqlDbType.VarChar,10);
			scom.Parameters.Add("@totalCost_Actual_FG", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@closure_ID"].Value = closure_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@batchStatus"].Value = batchStatus;
			scom.Parameters["@closure_DateTime"].Value = closure_DateTime;
			scom.Parameters["@remarks"].Value = remarks;
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
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@unitCost_Actual_FG"].Value = unitCost_Actual_FG;
			scom.Parameters["@qty_Actual_FG"].Value = qty_Actual_FG;
			scom.Parameters["@uom_ID_FG"].Value = uom_ID_FG;
			scom.Parameters["@totalCost_Actual_FG"].Value = totalCost_Actual_FG;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxBatch_Closure table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@closure_ID", SqlDbType.VarChar,20);
			scom.Parameters["@closure_ID"].Value = closure_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxBatch_Closure table.
		/// </summary>
		public static tbl_prod_pharmaTxBatch_Closure Select(string closure_ID_Incoming){

			tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closureins = new tbl_prod_pharmaTxBatch_Closure();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@closure_ID", SqlDbType.VarChar,20);
			scom.Parameters["@closure_ID"].Value = closure_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxBatch_Closureins = Maketbl_prod_pharmaTxBatch_Closure(dataReader);
				} else {
					tbl_prod_pharmaTxBatch_Closureins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxBatch_Closureins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table.
		/// </summary>
		public static List<tbl_prod_pharmaTxBatch_Closure> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxBatch_Closure> tbl_prod_pharmaTxBatch_ClosureList = new List<tbl_prod_pharmaTxBatch_Closure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closure = Maketbl_prod_pharmaTxBatch_Closure(dataReader);
					tbl_prod_pharmaTxBatch_ClosureList.Add(tbl_prod_pharmaTxBatch_Closure);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxBatch_ClosureList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxBatch_Closure> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prod_pharmaTxBatch_Closure> tbl_prod_pharmaTxBatch_ClosureList = new List<tbl_prod_pharmaTxBatch_Closure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closure = Maketbl_prod_pharmaTxBatch_Closure(dataReader);
					tbl_prod_pharmaTxBatch_ClosureList.Add(tbl_prod_pharmaTxBatch_Closure);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxBatch_ClosureList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxBatch_Closure> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prod_pharmaTxBatch_Closure> tbl_prod_pharmaTxBatch_ClosureList = new List<tbl_prod_pharmaTxBatch_Closure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closure = Maketbl_prod_pharmaTxBatch_Closure(dataReader);
					tbl_prod_pharmaTxBatch_ClosureList.Add(tbl_prod_pharmaTxBatch_Closure);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxBatch_ClosureList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxBatch_Closure> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_pharmaTxBatch_Closure> tbl_prod_pharmaTxBatch_ClosureList = new List<tbl_prod_pharmaTxBatch_Closure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closure = Maketbl_prod_pharmaTxBatch_Closure(dataReader);
					tbl_prod_pharmaTxBatch_ClosureList.Add(tbl_prod_pharmaTxBatch_Closure);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxBatch_ClosureList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxBatch_Closure> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prod_pharmaTxBatch_Closure> tbl_prod_pharmaTxBatch_ClosureList = new List<tbl_prod_pharmaTxBatch_Closure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closure = Maketbl_prod_pharmaTxBatch_Closure(dataReader);
					tbl_prod_pharmaTxBatch_ClosureList.Add(tbl_prod_pharmaTxBatch_Closure);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxBatch_ClosureList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxBatch_Closure> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prod_pharmaTxBatch_Closure> tbl_prod_pharmaTxBatch_ClosureList = new List<tbl_prod_pharmaTxBatch_Closure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closure = Maketbl_prod_pharmaTxBatch_Closure(dataReader);
					tbl_prod_pharmaTxBatch_ClosureList.Add(tbl_prod_pharmaTxBatch_Closure);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxBatch_ClosureList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxBatch_Closure> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prod_pharmaTxBatch_Closure> tbl_prod_pharmaTxBatch_ClosureList = new List<tbl_prod_pharmaTxBatch_Closure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closure = Maketbl_prod_pharmaTxBatch_Closure(dataReader);
					tbl_prod_pharmaTxBatch_ClosureList.Add(tbl_prod_pharmaTxBatch_Closure);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxBatch_ClosureList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxBatch_Closure> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prod_pharmaTxBatch_Closure> tbl_prod_pharmaTxBatch_ClosureList = new List<tbl_prod_pharmaTxBatch_Closure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closure = Maketbl_prod_pharmaTxBatch_Closure(dataReader);
					tbl_prod_pharmaTxBatch_ClosureList.Add(tbl_prod_pharmaTxBatch_Closure);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxBatch_ClosureList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxBatch_Closure table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxBatch_Closure> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxBatch_ClosureSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prod_pharmaTxBatch_Closure> tbl_prod_pharmaTxBatch_ClosureList = new List<tbl_prod_pharmaTxBatch_Closure>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closure = Maketbl_prod_pharmaTxBatch_Closure(dataReader);
					tbl_prod_pharmaTxBatch_ClosureList.Add(tbl_prod_pharmaTxBatch_Closure);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxBatch_ClosureList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxBatch_Closure class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxBatch_Closure Maketbl_prod_pharmaTxBatch_Closure(SqlDataReader dataReader) {
			tbl_prod_pharmaTxBatch_Closure tbl_prod_pharmaTxBatch_Closure = new tbl_prod_pharmaTxBatch_Closure();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxBatch_Closure.Closure_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxBatch_Closure.ProdJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxBatch_Closure.ProdBatch_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxBatch_Closure.BatchStatus = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxBatch_Closure.Closure_DateTime = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxBatch_Closure.Remarks = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxBatch_Closure.IsChecked = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxBatch_Closure.IsApproved = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxBatch_Closure.IsCanceled = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_pharmaTxBatch_Closure.CreateUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_pharmaTxBatch_Closure.ModifiedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_pharmaTxBatch_Closure.CheckedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prod_pharmaTxBatch_Closure.ApprovedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prod_pharmaTxBatch_Closure.CanceldUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prod_pharmaTxBatch_Closure.DateCreate = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prod_pharmaTxBatch_Closure.DateModified = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prod_pharmaTxBatch_Closure.DateChecked = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prod_pharmaTxBatch_Closure.DateApproved = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prod_pharmaTxBatch_Closure.DateCanceled = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prod_pharmaTxBatch_Closure.CreateUserTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prod_pharmaTxBatch_Closure.ModifiedUserTerminal_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prod_pharmaTxBatch_Closure.CheckedUserTerminal_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prod_pharmaTxBatch_Closure.ApprovedUserTerminal_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prod_pharmaTxBatch_Closure.CanceledUserTerminal_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prod_pharmaTxBatch_Closure.CompanyID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_prod_pharmaTxBatch_Closure.CompanyBranchID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_prod_pharmaTxBatch_Closure.Item_ID_FG = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_prod_pharmaTxBatch_Closure.UnitCost_Actual_FG = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_prod_pharmaTxBatch_Closure.Qty_Actual_FG = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_prod_pharmaTxBatch_Closure.Uom_ID_FG = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_prod_pharmaTxBatch_Closure.TotalCost_Actual_FG = dataReader.GetDecimal(30);
			}

			return tbl_prod_pharmaTxBatch_Closure;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxBatch_Closure datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxBatch_Closure object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxBatch_Closure  tbl_prod_pharmaTxBatch_Closure   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_closure_ID = new DataColumn("closure_ID" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_batchStatus = new DataColumn("batchStatus" , typeof(int));
			DataColumn col_closure_DateTime = new DataColumn("closure_DateTime" , typeof(DateTime));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
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
			DataColumn col_item_ID_FG = new DataColumn("item_ID_FG" , typeof(string));
			DataColumn col_unitCost_Actual_FG = new DataColumn("unitCost_Actual_FG" , typeof(decimal));
			DataColumn col_qty_Actual_FG = new DataColumn("qty_Actual_FG" , typeof(decimal));
			DataColumn col_uom_ID_FG = new DataColumn("uom_ID_FG" , typeof(string));
			DataColumn col_totalCost_Actual_FG = new DataColumn("totalCost_Actual_FG" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_closure_ID,col_prodJob_ID,col_prodBatch_ID,col_batchStatus,col_closure_DateTime,col_remarks,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,col_item_ID_FG,col_unitCost_Actual_FG,col_qty_Actual_FG,col_uom_ID_FG,col_totalCost_Actual_FG,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxBatch_Closure datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxBatch_Closure object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxBatch_Closure user) {
		DataRow drow = dt.NewRow();
		
			drow["closure_ID"] = user.closure_ID;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["batchStatus"] = user.batchStatus;
			drow["closure_DateTime"] = user.closure_DateTime;
			drow["remarks"] = user.remarks;
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
			drow["item_ID_FG"] = user.item_ID_FG;
			drow["unitCost_Actual_FG"] = user.unitCost_Actual_FG;
			drow["qty_Actual_FG"] = user.qty_Actual_FG;
			drow["uom_ID_FG"] = user.uom_ID_FG;
			drow["totalCost_Actual_FG"] = user.totalCost_Actual_FG;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
