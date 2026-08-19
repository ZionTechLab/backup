using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxSubContractInNote {
		#region Fields
		private string subIn_ID;
		private DateTime subIn_Date;
		private string return_Dept_ID;
		private string return_Section_ID;
		private string supplier_ID;
		private decimal supplier_Rate;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string fG_Item_ID;
		private string semiFG_item_ID;
		private string uom_ID;
		private decimal subIn_Qty;
		private decimal unitCost;
		private decimal weightCost;
		private decimal totalAmount;
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
		/// Initializes a new instance of the tbl_prodTxSubContractInNote class.
		/// </summary>
		public tbl_prodTxSubContractInNote() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxSubContractInNote class.
		/// </summary>
		public tbl_prodTxSubContractInNote(string subIn_ID, DateTime subIn_Date, string return_Dept_ID, string return_Section_ID, string supplier_ID, decimal supplier_Rate, string prodJob_ID, string prodBatch_ID, string fG_Item_ID, string semiFG_item_ID, string uom_ID, decimal subIn_Qty, decimal unitCost, decimal weightCost, decimal totalAmount, string remark, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID) {
			this.subIn_ID = subIn_ID;
			this.subIn_Date = subIn_Date;
			this.return_Dept_ID = return_Dept_ID;
			this.return_Section_ID = return_Section_ID;
			this.supplier_ID = supplier_ID;
			this.supplier_Rate = supplier_Rate;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.fG_Item_ID = fG_Item_ID;
			this.semiFG_item_ID = semiFG_item_ID;
			this.uom_ID = uom_ID;
			this.subIn_Qty = subIn_Qty;
			this.unitCost = unitCost;
			this.weightCost = weightCost;
			this.totalAmount = totalAmount;
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
		/// Gets or sets the SubIn_ID value.
		/// </summary>
		public string SubIn_ID {
			get { return subIn_ID; }
			set { subIn_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubIn_Date value.
		/// </summary>
		public DateTime SubIn_Date {
			get { return subIn_Date; }
			set { subIn_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Return_Dept_ID value.
		/// </summary>
		public string Return_Dept_ID {
			get { return return_Dept_ID; }
			set { return_Dept_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Return_Section_ID value.
		/// </summary>
		public string Return_Section_ID {
			get { return return_Section_ID; }
			set { return_Section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_Rate value.
		/// </summary>
		public decimal Supplier_Rate {
			get { return supplier_Rate; }
			set { supplier_Rate = value; }
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
		/// Gets or sets the FG_Item_ID value.
		/// </summary>
		public string FG_Item_ID {
			get { return fG_Item_ID; }
			set { fG_Item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SemiFG_item_ID value.
		/// </summary>
		public string SemiFG_item_ID {
			get { return semiFG_item_ID; }
			set { semiFG_item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubIn_Qty value.
		/// </summary>
		public decimal SubIn_Qty {
			get { return subIn_Qty; }
			set { subIn_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitCost value.
		/// </summary>
		public decimal UnitCost {
			get { return unitCost; }
			set { unitCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightCost value.
		/// </summary>
		public decimal WeightCost {
			get { return weightCost; }
			set { weightCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
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
		/// Saves a record to the tbl_prodTxSubContractInNote table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subIn_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@return_Dept_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@return_Section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_Rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fG_Item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@semiFG_item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@subIn_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
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
 
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
			scom.Parameters["@subIn_Date"].Value = subIn_Date;
			scom.Parameters["@return_Dept_ID"].Value = return_Dept_ID;
			scom.Parameters["@return_Section_ID"].Value = return_Section_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@supplier_Rate"].Value = supplier_Rate;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@fG_Item_ID"].Value = fG_Item_ID;
			scom.Parameters["@semiFG_item_ID"].Value = semiFG_item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@subIn_Qty"].Value = subIn_Qty;
			scom.Parameters["@unitCost"].Value = unitCost;
			scom.Parameters["@weightCost"].Value = weightCost;
			scom.Parameters["@totalAmount"].Value = totalAmount;
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
		/// Updates a record in the tbl_prodTxSubContractInNote table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@subIn_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@return_Dept_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@return_Section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_Rate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fG_Item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@semiFG_item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@subIn_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
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
 
 
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
			scom.Parameters["@subIn_Date"].Value = subIn_Date;
			scom.Parameters["@return_Dept_ID"].Value = return_Dept_ID;
			scom.Parameters["@return_Section_ID"].Value = return_Section_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@supplier_Rate"].Value = supplier_Rate;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@fG_Item_ID"].Value = fG_Item_ID;
			scom.Parameters["@semiFG_item_ID"].Value = semiFG_item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@subIn_Qty"].Value = subIn_Qty;
			scom.Parameters["@unitCost"].Value = unitCost;
			scom.Parameters["@weightCost"].Value = weightCost;
			scom.Parameters["@totalAmount"].Value = totalAmount;
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
		/// Deletes a record from the tbl_prodTxSubContractInNote table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subIn_ID"].Value = subIn_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByFG_Item_ID(string fG_Item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByFG_Item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@fG_Item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fG_Item_ID"].Value = fG_Item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByReturn_Dept_ID(string return_Dept_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByReturn_Dept_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@return_Dept_ID", SqlDbType.VarChar,20);
			scom.Parameters["@return_Dept_ID"].Value = return_Dept_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByReturn_Section_ID(string return_Section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByReturn_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@return_Section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@return_Section_ID"].Value = return_Section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllBySemiFG_item_ID(string semiFG_item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllBySemiFG_item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@semiFG_item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@semiFG_item_ID"].Value = semiFG_item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxSubContractInNote table.
		/// </summary>
		public static tbl_prodTxSubContractInNote Select(string subIn_ID_Incoming){

			tbl_prodTxSubContractInNote tbl_prodTxSubContractInNoteins = new tbl_prodTxSubContractInNote();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@subIn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subIn_ID"].Value = subIn_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxSubContractInNoteins = Maketbl_prodTxSubContractInNote(dataReader);
				} else {
					tbl_prodTxSubContractInNoteins = null;
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByFG_Item_ID(string fG_Item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByFG_Item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fG_Item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fG_Item_ID"].Value = fG_Item_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByReturn_Dept_ID(string return_Dept_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByReturn_Dept_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@return_Dept_ID", SqlDbType.VarChar,20);
			scom.Parameters["@return_Dept_ID"].Value = return_Dept_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByReturn_Section_ID(string return_Section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByReturn_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@return_Section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@return_Section_ID"].Value = return_Section_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllBySemiFG_item_ID(string semiFG_item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllBySemiFG_item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@semiFG_item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@semiFG_item_ID"].Value = semiFG_item_ID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractInNote table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractInNote> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractInNoteSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prodTxSubContractInNote> tbl_prodTxSubContractInNoteList = new List<tbl_prodTxSubContractInNote>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = Maketbl_prodTxSubContractInNote(dataReader);
					tbl_prodTxSubContractInNoteList.Add(tbl_prodTxSubContractInNote);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractInNoteList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxSubContractInNote class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxSubContractInNote Maketbl_prodTxSubContractInNote(SqlDataReader dataReader) {
			tbl_prodTxSubContractInNote tbl_prodTxSubContractInNote = new tbl_prodTxSubContractInNote();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxSubContractInNote.SubIn_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxSubContractInNote.SubIn_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxSubContractInNote.Return_Dept_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxSubContractInNote.Return_Section_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxSubContractInNote.Supplier_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxSubContractInNote.Supplier_Rate = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxSubContractInNote.ProdJob_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxSubContractInNote.ProdBatch_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxSubContractInNote.FG_Item_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxSubContractInNote.SemiFG_item_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxSubContractInNote.Uom_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxSubContractInNote.SubIn_Qty = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxSubContractInNote.UnitCost = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prodTxSubContractInNote.WeightCost = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prodTxSubContractInNote.TotalAmount = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prodTxSubContractInNote.Remark = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prodTxSubContractInNote.IsChecked = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prodTxSubContractInNote.IsApproved = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prodTxSubContractInNote.IsCanceled = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prodTxSubContractInNote.CreateUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prodTxSubContractInNote.ModifiedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prodTxSubContractInNote.CheckedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prodTxSubContractInNote.ApprovedUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prodTxSubContractInNote.CanceldUser_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prodTxSubContractInNote.DateCreate = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_prodTxSubContractInNote.DateModified = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_prodTxSubContractInNote.DateChecked = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_prodTxSubContractInNote.DateApproved = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_prodTxSubContractInNote.DateCanceled = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_prodTxSubContractInNote.CreateUserTerminal_ID = dataReader.GetString(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_prodTxSubContractInNote.ModifiedUserTerminal_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_prodTxSubContractInNote.CheckedUserTerminal_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_prodTxSubContractInNote.ApprovedUserTerminal_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_prodTxSubContractInNote.CanceledUserTerminal_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_prodTxSubContractInNote.CompanyID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_prodTxSubContractInNote.CompanyBranchID = dataReader.GetString(35);
			}

			return tbl_prodTxSubContractInNote;
		}
		/// <summary>
		/// This makes tbl_prodTxSubContractInNote datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxSubContractInNote object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxSubContractInNote  tbl_prodTxSubContractInNote   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_subIn_ID = new DataColumn("subIn_ID" , typeof(string));
			DataColumn col_subIn_Date = new DataColumn("subIn_Date" , typeof(DateTime));
			DataColumn col_return_Dept_ID = new DataColumn("return_Dept_ID" , typeof(string));
			DataColumn col_return_Section_ID = new DataColumn("return_Section_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_supplier_Rate = new DataColumn("supplier_Rate" , typeof(decimal));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_fG_Item_ID = new DataColumn("fG_Item_ID" , typeof(string));
			DataColumn col_semiFG_item_ID = new DataColumn("semiFG_item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_subIn_Qty = new DataColumn("subIn_Qty" , typeof(decimal));
			DataColumn col_unitCost = new DataColumn("unitCost" , typeof(decimal));
			DataColumn col_weightCost = new DataColumn("weightCost" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
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
		dt.Columns.AddRange(new DataColumn[] { col_subIn_ID,col_subIn_Date,col_return_Dept_ID,col_return_Section_ID,col_supplier_ID,col_supplier_Rate,col_prodJob_ID,col_prodBatch_ID,col_fG_Item_ID,col_semiFG_item_ID,col_uom_ID,col_subIn_Qty,col_unitCost,col_weightCost,col_totalAmount,col_remark,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxSubContractInNote datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxSubContractInNote object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxSubContractInNote user) {
		DataRow drow = dt.NewRow();
		
			drow["subIn_ID"] = user.subIn_ID;
			drow["subIn_Date"] = user.subIn_Date;
			drow["return_Dept_ID"] = user.return_Dept_ID;
			drow["return_Section_ID"] = user.return_Section_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["supplier_Rate"] = user.supplier_Rate;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["fG_Item_ID"] = user.fG_Item_ID;
			drow["semiFG_item_ID"] = user.semiFG_item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["subIn_Qty"] = user.subIn_Qty;
			drow["unitCost"] = user.unitCost;
			drow["weightCost"] = user.weightCost;
			drow["totalAmount"] = user.totalAmount;
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
