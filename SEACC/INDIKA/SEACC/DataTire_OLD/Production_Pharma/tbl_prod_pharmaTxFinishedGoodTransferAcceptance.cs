using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxFinishedGoodTransferAcceptance {
		#region Fields
		private string acceptance_ID;
		private DateTime acceptance_Date;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string fgtn_ID;
		private string item_ID_FG;
		private string uom_ID;
		private decimal fgtnQty;
		private decimal fgtn_PendigQty;
		private decimal acceptanceQty;
		private decimal acceptanceWeight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private string from_Store_ID;
		private string to_Store_ID;
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
		/// Initializes a new instance of the tbl_prod_pharmaTxFinishedGoodTransferAcceptance class.
		/// </summary>
		public tbl_prod_pharmaTxFinishedGoodTransferAcceptance() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxFinishedGoodTransferAcceptance class.
		/// </summary>
		public tbl_prod_pharmaTxFinishedGoodTransferAcceptance(string acceptance_ID, DateTime acceptance_Date, string prodJob_ID, string prodBatch_ID, string fgtn_ID, string item_ID_FG, string uom_ID, decimal fgtnQty, decimal fgtn_PendigQty, decimal acceptanceQty, decimal acceptanceWeight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string from_Store_ID, string to_Store_ID, string remark, bool isChecked, bool isApproved, bool isCanceled, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string canceldUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateCanceled, string createUserTerminal_ID, string modifiedUserTerminal_ID, string checkedUserTerminal_ID, string approvedUserTerminal_ID, string canceledUserTerminal_ID, string companyID, string companyBranchID) {
			this.acceptance_ID = acceptance_ID;
			this.acceptance_Date = acceptance_Date;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.fgtn_ID = fgtn_ID;
			this.item_ID_FG = item_ID_FG;
			this.uom_ID = uom_ID;
			this.fgtnQty = fgtnQty;
			this.fgtn_PendigQty = fgtn_PendigQty;
			this.acceptanceQty = acceptanceQty;
			this.acceptanceWeight = acceptanceWeight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
			this.from_Store_ID = from_Store_ID;
			this.to_Store_ID = to_Store_ID;
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
		/// Gets or sets the Fgtn_ID value.
		/// </summary>
		public string Fgtn_ID {
			get { return fgtn_ID; }
			set { fgtn_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID_FG value.
		/// </summary>
		public string Item_ID_FG {
			get { return item_ID_FG; }
			set { item_ID_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FgtnQty value.
		/// </summary>
		public decimal FgtnQty {
			get { return fgtnQty; }
			set { fgtnQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fgtn_PendigQty value.
		/// </summary>
		public decimal Fgtn_PendigQty {
			get { return fgtn_PendigQty; }
			set { fgtn_PendigQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the AcceptanceQty value.
		/// </summary>
		public decimal AcceptanceQty {
			get { return acceptanceQty; }
			set { acceptanceQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the AcceptanceWeight value.
		/// </summary>
		public decimal AcceptanceWeight {
			get { return acceptanceWeight; }
			set { acceptanceWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightPrice value.
		/// </summary>
		public decimal WeightPrice {
			get { return weightPrice; }
			set { weightPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the From_Store_ID value.
		/// </summary>
		public string From_Store_ID {
			get { return from_Store_ID; }
			set { from_Store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the To_Store_ID value.
		/// </summary>
		public string To_Store_ID {
			get { return to_Store_ID; }
			set { to_Store_ID = value; }
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
		/// Saves a record to the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@acceptance_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fgtnQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@fgtn_PendigQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@acceptanceQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@acceptanceWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@from_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@to_Store_ID", SqlDbType.VarChar,20);
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
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@fgtnQty"].Value = fgtnQty;
			scom.Parameters["@fgtn_PendigQty"].Value = fgtn_PendigQty;
			scom.Parameters["@acceptanceQty"].Value = acceptanceQty;
			scom.Parameters["@acceptanceWeight"].Value = acceptanceWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@from_Store_ID"].Value = from_Store_ID;
			scom.Parameters["@to_Store_ID"].Value = to_Store_ID;
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
		/// Updates a record in the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@acceptance_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fgtnQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@fgtn_PendigQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@acceptanceQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@acceptanceWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@from_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@to_Store_ID", SqlDbType.VarChar,20);
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
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@fgtnQty"].Value = fgtnQty;
			scom.Parameters["@fgtn_PendigQty"].Value = fgtn_PendigQty;
			scom.Parameters["@acceptanceQty"].Value = acceptanceQty;
			scom.Parameters["@acceptanceWeight"].Value = acceptanceWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@from_Store_ID"].Value = from_Store_ID;
			scom.Parameters["@to_Store_ID"].Value = to_Store_ID;
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
		/// Deletes a record from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByFrom_Store_ID(string from_Store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByFrom_Store_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@from_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@from_Store_ID"].Value = from_Store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByFgtn_ID(string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByFgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static void DeleteAllByTo_Store_ID(string to_Store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceDeleteAllByTo_Store_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
			scom.Parameters.Add("@to_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@to_Store_ID"].Value = to_Store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table.
		/// </summary>
		public static tbl_prod_pharmaTxFinishedGoodTransferAcceptance Select(string acceptance_ID_Incoming){

			tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptanceins = new tbl_prod_pharmaTxFinishedGoodTransferAcceptance();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceins = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
				} else {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByCompanyID(string companyID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByCompanyID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters["@companyID"].Value = companyID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByFrom_Store_ID(string from_Store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByFrom_Store_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@from_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@from_Store_ID"].Value = from_Store_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByCreateUser_ID(string createUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByCreateUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByCheckedUser_ID(string checkedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByCheckedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByCanceldUser_ID(string canceldUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByCanceldUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@canceldUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@canceldUser_ID"].Value = canceldUser_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByApprovedUser_ID(string approvedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByApprovedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByModifiedUser_ID(string modifiedUser_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByModifiedUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByCompanyBranchID(string companyBranchID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByCompanyBranchID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranchID"].Value = companyBranchID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByFgtn_ID(string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByFgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxFinishedGoodTransferAcceptance table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> SelectAllByTo_Store_ID(string to_Store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxFinishedGoodTransferAcceptanceSelectAllByTo_Store_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@to_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@to_Store_ID"].Value = to_Store_ID;
				List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance> tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList = new List<tbl_prod_pharmaTxFinishedGoodTransferAcceptance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(dataReader);
					tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList.Add(tbl_prod_pharmaTxFinishedGoodTransferAcceptance);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxFinishedGoodTransferAcceptanceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxFinishedGoodTransferAcceptance class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxFinishedGoodTransferAcceptance Maketbl_prod_pharmaTxFinishedGoodTransferAcceptance(SqlDataReader dataReader) {
			tbl_prod_pharmaTxFinishedGoodTransferAcceptance tbl_prod_pharmaTxFinishedGoodTransferAcceptance = new tbl_prod_pharmaTxFinishedGoodTransferAcceptance();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Acceptance_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Acceptance_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.ProdJob_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.ProdBatch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Fgtn_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Item_ID_FG = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Uom_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.FgtnQty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Fgtn_PendigQty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.AcceptanceQty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.AcceptanceWeight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.UnitPrice = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.WeightPrice = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.TotalAmount = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.From_Store_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.To_Store_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Remark = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.IsChecked = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.IsApproved = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.IsCanceled = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.CreateUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.ModifiedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.CheckedUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.ApprovedUser_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.CanceldUser_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.DateCreate = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.DateModified = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.DateChecked = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.DateApproved = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.DateCanceled = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.CreateUserTerminal_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.ModifiedUserTerminal_ID = dataReader.GetString(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.CheckedUserTerminal_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.ApprovedUserTerminal_ID = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.CanceledUserTerminal_ID = dataReader.GetString(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.CompanyID = dataReader.GetString(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_prod_pharmaTxFinishedGoodTransferAcceptance.CompanyBranchID = dataReader.GetString(36);
			}

			return tbl_prod_pharmaTxFinishedGoodTransferAcceptance;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxFinishedGoodTransferAcceptance datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxFinishedGoodTransferAcceptance object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxFinishedGoodTransferAcceptance  tbl_prod_pharmaTxFinishedGoodTransferAcceptance   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_acceptance_ID = new DataColumn("acceptance_ID" , typeof(string));
			DataColumn col_acceptance_Date = new DataColumn("acceptance_Date" , typeof(DateTime));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_fgtn_ID = new DataColumn("fgtn_ID" , typeof(string));
			DataColumn col_item_ID_FG = new DataColumn("item_ID_FG" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_fgtnQty = new DataColumn("fgtnQty" , typeof(decimal));
			DataColumn col_fgtn_PendigQty = new DataColumn("fgtn_PendigQty" , typeof(decimal));
			DataColumn col_acceptanceQty = new DataColumn("acceptanceQty" , typeof(decimal));
			DataColumn col_acceptanceWeight = new DataColumn("acceptanceWeight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_from_Store_ID = new DataColumn("from_Store_ID" , typeof(string));
			DataColumn col_to_Store_ID = new DataColumn("to_Store_ID" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_acceptance_ID,col_acceptance_Date,col_prodJob_ID,col_prodBatch_ID,col_fgtn_ID,col_item_ID_FG,col_uom_ID,col_fgtnQty,col_fgtn_PendigQty,col_acceptanceQty,col_acceptanceWeight,col_unitPrice,col_weightPrice,col_totalAmount,col_from_Store_ID,col_to_Store_ID,col_remark,col_isChecked,col_isApproved,col_isCanceled,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_canceldUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateCanceled,col_createUserTerminal_ID,col_modifiedUserTerminal_ID,col_checkedUserTerminal_ID,col_approvedUserTerminal_ID,col_canceledUserTerminal_ID,col_companyID,col_companyBranchID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxFinishedGoodTransferAcceptance datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxFinishedGoodTransferAcceptance object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxFinishedGoodTransferAcceptance user) {
		DataRow drow = dt.NewRow();
		
			drow["acceptance_ID"] = user.acceptance_ID;
			drow["acceptance_Date"] = user.acceptance_Date;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["fgtn_ID"] = user.fgtn_ID;
			drow["item_ID_FG"] = user.item_ID_FG;
			drow["uom_ID"] = user.uom_ID;
			drow["fgtnQty"] = user.fgtnQty;
			drow["fgtn_PendigQty"] = user.fgtn_PendigQty;
			drow["acceptanceQty"] = user.acceptanceQty;
			drow["acceptanceWeight"] = user.acceptanceWeight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["from_Store_ID"] = user.from_Store_ID;
			drow["to_Store_ID"] = user.to_Store_ID;
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
