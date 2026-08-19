using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasJobRegister {
		#region Fields
		private string job_ID;
		private DateTime jobDate;
		private string remark;
		private string customer_ID;
		private string inquiry_ID;
		private string jobCategory_ID;
		private string selesRep_ID;
		private string item_ID;
		private string uom_ID;
		private decimal kiloPrice;
		private decimal weight;
		private decimal qty;
		private DateTime deliveryDate;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isSTSCostingConfirmed;
		private bool isSTSQuotaionPending;
		private bool isSTSJobConfirmPending;
		private bool isSTSJobConfirmed;
		private string costingConfirmedUser_ID;
		private DateTime costingConfirmedDate;
		private string jobConfirmedUser_ID;
		private DateTime jobConfirmedDate;
		private string confirmRemark;
		private int printCount;
		private int printCount_Other;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasJobRegister class.
		/// </summary>
		public tbl_sasJobRegister() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasJobRegister class.
		/// </summary>
		public tbl_sasJobRegister(string job_ID, DateTime jobDate, string remark, string customer_ID, string inquiry_ID, string jobCategory_ID, string selesRep_ID, string item_ID, string uom_ID, decimal kiloPrice, decimal weight, decimal qty, DateTime deliveryDate, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isFinished, bool isDeleted, bool isLocked, bool isSTSCostingConfirmed, bool isSTSQuotaionPending, bool isSTSJobConfirmPending, bool isSTSJobConfirmed, string costingConfirmedUser_ID, DateTime costingConfirmedDate, string jobConfirmedUser_ID, DateTime jobConfirmedDate, string confirmRemark, int printCount, int printCount_Other) {
			this.job_ID = job_ID;
			this.jobDate = jobDate;
			this.remark = remark;
			this.customer_ID = customer_ID;
			this.inquiry_ID = inquiry_ID;
			this.jobCategory_ID = jobCategory_ID;
			this.selesRep_ID = selesRep_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.kiloPrice = kiloPrice;
			this.weight = weight;
			this.qty = qty;
			this.deliveryDate = deliveryDate;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isSTSCostingConfirmed = isSTSCostingConfirmed;
			this.isSTSQuotaionPending = isSTSQuotaionPending;
			this.isSTSJobConfirmPending = isSTSJobConfirmPending;
			this.isSTSJobConfirmed = isSTSJobConfirmed;
			this.costingConfirmedUser_ID = costingConfirmedUser_ID;
			this.costingConfirmedDate = costingConfirmedDate;
			this.jobConfirmedUser_ID = jobConfirmedUser_ID;
			this.jobConfirmedDate = jobConfirmedDate;
			this.confirmRemark = confirmRemark;
			this.printCount = printCount;
			this.printCount_Other = printCount_Other;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobDate value.
		/// </summary>
		public DateTime JobDate {
			get { return jobDate; }
			set { jobDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Inquiry_ID value.
		/// </summary>
		public string Inquiry_ID {
			get { return inquiry_ID; }
			set { inquiry_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobCategory_ID value.
		/// </summary>
		public string JobCategory_ID {
			get { return jobCategory_ID; }
			set { jobCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SelesRep_ID value.
		/// </summary>
		public string SelesRep_ID {
			get { return selesRep_ID; }
			set { selesRep_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the KiloPrice value.
		/// </summary>
		public decimal KiloPrice {
			get { return kiloPrice; }
			set { kiloPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryDate value.
		/// </summary>
		public DateTime DeliveryDate {
			get { return deliveryDate; }
			set { deliveryDate = value; }
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
		/// Gets or sets the IsSTSCostingConfirmed value.
		/// </summary>
		public bool IsSTSCostingConfirmed {
			get { return isSTSCostingConfirmed; }
			set { isSTSCostingConfirmed = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSTSQuotaionPending value.
		/// </summary>
		public bool IsSTSQuotaionPending {
			get { return isSTSQuotaionPending; }
			set { isSTSQuotaionPending = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSTSJobConfirmPending value.
		/// </summary>
		public bool IsSTSJobConfirmPending {
			get { return isSTSJobConfirmPending; }
			set { isSTSJobConfirmPending = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSTSJobConfirmed value.
		/// </summary>
		public bool IsSTSJobConfirmed {
			get { return isSTSJobConfirmed; }
			set { isSTSJobConfirmed = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostingConfirmedUser_ID value.
		/// </summary>
		public string CostingConfirmedUser_ID {
			get { return costingConfirmedUser_ID; }
			set { costingConfirmedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostingConfirmedDate value.
		/// </summary>
		public DateTime CostingConfirmedDate {
			get { return costingConfirmedDate; }
			set { costingConfirmedDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobConfirmedUser_ID value.
		/// </summary>
		public string JobConfirmedUser_ID {
			get { return jobConfirmedUser_ID; }
			set { jobConfirmedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobConfirmedDate value.
		/// </summary>
		public DateTime JobConfirmedDate {
			get { return jobConfirmedDate; }
			set { jobConfirmedDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ConfirmRemark value.
		/// </summary>
		public string ConfirmRemark {
			get { return confirmRemark; }
			set { confirmRemark = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount_Other value.
		/// </summary>
		public int PrintCount_Other {
			get { return printCount_Other; }
			set { printCount_Other = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasJobRegister table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@jobDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@jobCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliveryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSTSCostingConfirmed", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSTSQuotaionPending", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSTSJobConfirmPending", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSTSJobConfirmed", SqlDbType.Bit,1);
			scom.Parameters.Add("@costingConfirmedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costingConfirmedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@jobConfirmedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@jobConfirmedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@confirmRemark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@printCount_Other", SqlDbType.Int,4);
 
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@jobDate"].Value = jobDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@jobCategory_ID"].Value = jobCategory_ID;
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@kiloPrice"].Value = kiloPrice;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@deliveryDate"].Value = deliveryDate;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSTSCostingConfirmed"].Value = isSTSCostingConfirmed;
			scom.Parameters["@isSTSQuotaionPending"].Value = isSTSQuotaionPending;
			scom.Parameters["@isSTSJobConfirmPending"].Value = isSTSJobConfirmPending;
			scom.Parameters["@isSTSJobConfirmed"].Value = isSTSJobConfirmed;
			scom.Parameters["@costingConfirmedUser_ID"].Value = costingConfirmedUser_ID;
			scom.Parameters["@costingConfirmedDate"].Value = costingConfirmedDate;
			scom.Parameters["@jobConfirmedUser_ID"].Value = jobConfirmedUser_ID;
			scom.Parameters["@jobConfirmedDate"].Value = jobConfirmedDate;
			scom.Parameters["@confirmRemark"].Value = confirmRemark;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@printCount_Other"].Value = printCount_Other;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasJobRegister table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@jobDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@inquiry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@jobCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@kiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliveryDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSTSCostingConfirmed", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSTSQuotaionPending", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSTSJobConfirmPending", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSTSJobConfirmed", SqlDbType.Bit,1);
			scom.Parameters.Add("@costingConfirmedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costingConfirmedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@jobConfirmedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@jobConfirmedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@confirmRemark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@printCount_Other", SqlDbType.Int,4);
 
 
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@jobDate"].Value = jobDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@inquiry_ID"].Value = inquiry_ID;
			scom.Parameters["@jobCategory_ID"].Value = jobCategory_ID;
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@kiloPrice"].Value = kiloPrice;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@deliveryDate"].Value = deliveryDate;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isSTSCostingConfirmed"].Value = isSTSCostingConfirmed;
			scom.Parameters["@isSTSQuotaionPending"].Value = isSTSQuotaionPending;
			scom.Parameters["@isSTSJobConfirmPending"].Value = isSTSJobConfirmPending;
			scom.Parameters["@isSTSJobConfirmed"].Value = isSTSJobConfirmed;
			scom.Parameters["@costingConfirmedUser_ID"].Value = costingConfirmedUser_ID;
			scom.Parameters["@costingConfirmedDate"].Value = costingConfirmedDate;
			scom.Parameters["@jobConfirmedUser_ID"].Value = jobConfirmedUser_ID;
			scom.Parameters["@jobConfirmedDate"].Value = jobConfirmedDate;
			scom.Parameters["@confirmRemark"].Value = confirmRemark;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@printCount_Other"].Value = printCount_Other;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasJobRegister table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByJobCategory_ID(string jobCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterDeleteAllByJobCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@jobCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@jobCategory_ID"].Value = jobCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllBySelesRep_ID(string selesRep_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterDeleteAllBySelesRep_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasJobRegister table.
		/// </summary>
		public static tbl_sasJobRegister Select(string job_ID_Incoming){

			tbl_sasJobRegister tbl_sasJobRegisterins = new tbl_sasJobRegister();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasJobRegisterins = Maketbl_sasJobRegister(dataReader);
				} else {
					tbl_sasJobRegisterins = null;
				}
			}
			scon.Close();
			return tbl_sasJobRegisterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table.
		/// </summary>
		public static List<tbl_sasJobRegister> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasJobRegister> tbl_sasJobRegisterList = new List<tbl_sasJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister tbl_sasJobRegister = Maketbl_sasJobRegister(dataReader);
					tbl_sasJobRegisterList.Add(tbl_sasJobRegister);
				}
			}
			scon.Close();
			return tbl_sasJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister> SelectAllByJobCategory_ID(string jobCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterSelectAllByJobCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@jobCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@jobCategory_ID"].Value = jobCategory_ID;
				List<tbl_sasJobRegister> tbl_sasJobRegisterList = new List<tbl_sasJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister tbl_sasJobRegister = Maketbl_sasJobRegister(dataReader);
					tbl_sasJobRegisterList.Add(tbl_sasJobRegister);
				}
			}
			scon.Close();
			return tbl_sasJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_sasJobRegister> tbl_sasJobRegisterList = new List<tbl_sasJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister tbl_sasJobRegister = Maketbl_sasJobRegister(dataReader);
					tbl_sasJobRegisterList.Add(tbl_sasJobRegister);
				}
			}
			scon.Close();
			return tbl_sasJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_sasJobRegister> tbl_sasJobRegisterList = new List<tbl_sasJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister tbl_sasJobRegister = Maketbl_sasJobRegister(dataReader);
					tbl_sasJobRegisterList.Add(tbl_sasJobRegister);
				}
			}
			scon.Close();
			return tbl_sasJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister> SelectAllBySelesRep_ID(string selesRep_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterSelectAllBySelesRep_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@selesRep_ID", SqlDbType.VarChar,20);
			scom.Parameters["@selesRep_ID"].Value = selesRep_ID;
				List<tbl_sasJobRegister> tbl_sasJobRegisterList = new List<tbl_sasJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister tbl_sasJobRegister = Maketbl_sasJobRegister(dataReader);
					tbl_sasJobRegisterList.Add(tbl_sasJobRegister);
				}
			}
			scon.Close();
			return tbl_sasJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_sasJobRegister> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasJobRegisterSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_sasJobRegister> tbl_sasJobRegisterList = new List<tbl_sasJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasJobRegister tbl_sasJobRegister = Maketbl_sasJobRegister(dataReader);
					tbl_sasJobRegisterList.Add(tbl_sasJobRegister);
				}
			}
			scon.Close();
			return tbl_sasJobRegisterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasJobRegister class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasJobRegister Maketbl_sasJobRegister(SqlDataReader dataReader) {
			tbl_sasJobRegister tbl_sasJobRegister = new tbl_sasJobRegister();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasJobRegister.Job_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasJobRegister.JobDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasJobRegister.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasJobRegister.Customer_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasJobRegister.Inquiry_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasJobRegister.JobCategory_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasJobRegister.SelesRep_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasJobRegister.Item_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasJobRegister.Uom_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasJobRegister.KiloPrice = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasJobRegister.Weight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasJobRegister.Qty = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasJobRegister.DeliveryDate = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasJobRegister.CreateUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasJobRegister.ModifiedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasJobRegister.CheckedUser_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasJobRegister.DateCreate = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasJobRegister.DateModified = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasJobRegister.DateChecked = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasJobRegister.DateApproved = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasJobRegister.IsChecked = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasJobRegister.IsFinished = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasJobRegister.IsDeleted = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasJobRegister.IsLocked = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_sasJobRegister.IsSTSCostingConfirmed = dataReader.GetBoolean(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_sasJobRegister.IsSTSQuotaionPending = dataReader.GetBoolean(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_sasJobRegister.IsSTSJobConfirmPending = dataReader.GetBoolean(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_sasJobRegister.IsSTSJobConfirmed = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_sasJobRegister.CostingConfirmedUser_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_sasJobRegister.CostingConfirmedDate = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_sasJobRegister.JobConfirmedUser_ID = dataReader.GetString(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_sasJobRegister.JobConfirmedDate = dataReader.GetDateTime(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_sasJobRegister.ConfirmRemark = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_sasJobRegister.PrintCount = dataReader.GetInt32(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_sasJobRegister.PrintCount_Other = dataReader.GetInt32(34);
			}

			return tbl_sasJobRegister;
		}
		/// <summary>
		/// This makes tbl_sasJobRegister datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasJobRegister object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasJobRegister  tbl_sasJobRegister   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_jobDate = new DataColumn("jobDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_inquiry_ID = new DataColumn("inquiry_ID" , typeof(string));
			DataColumn col_jobCategory_ID = new DataColumn("jobCategory_ID" , typeof(string));
			DataColumn col_selesRep_ID = new DataColumn("selesRep_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_kiloPrice = new DataColumn("kiloPrice" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_deliveryDate = new DataColumn("deliveryDate" , typeof(DateTime));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isSTSCostingConfirmed = new DataColumn("isSTSCostingConfirmed" , typeof(bool));
			DataColumn col_isSTSQuotaionPending = new DataColumn("isSTSQuotaionPending" , typeof(bool));
			DataColumn col_isSTSJobConfirmPending = new DataColumn("isSTSJobConfirmPending" , typeof(bool));
			DataColumn col_isSTSJobConfirmed = new DataColumn("isSTSJobConfirmed" , typeof(bool));
			DataColumn col_costingConfirmedUser_ID = new DataColumn("costingConfirmedUser_ID" , typeof(string));
			DataColumn col_costingConfirmedDate = new DataColumn("costingConfirmedDate" , typeof(DateTime));
			DataColumn col_jobConfirmedUser_ID = new DataColumn("jobConfirmedUser_ID" , typeof(string));
			DataColumn col_jobConfirmedDate = new DataColumn("jobConfirmedDate" , typeof(DateTime));
			DataColumn col_confirmRemark = new DataColumn("confirmRemark" , typeof(string));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_printCount_Other = new DataColumn("printCount_Other" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_job_ID,col_jobDate,col_remark,col_customer_ID,col_inquiry_ID,col_jobCategory_ID,col_selesRep_ID,col_item_ID,col_uom_ID,col_kiloPrice,col_weight,col_qty,col_deliveryDate,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isFinished,col_isDeleted,col_isLocked,col_isSTSCostingConfirmed,col_isSTSQuotaionPending,col_isSTSJobConfirmPending,col_isSTSJobConfirmed,col_costingConfirmedUser_ID,col_costingConfirmedDate,col_jobConfirmedUser_ID,col_jobConfirmedDate,col_confirmRemark,col_printCount,col_printCount_Other,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasJobRegister datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasJobRegister object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasJobRegister user) {
		DataRow drow = dt.NewRow();
		
			drow["job_ID"] = user.job_ID;
			drow["jobDate"] = user.jobDate;
			drow["remark"] = user.remark;
			drow["customer_ID"] = user.customer_ID;
			drow["inquiry_ID"] = user.inquiry_ID;
			drow["jobCategory_ID"] = user.jobCategory_ID;
			drow["selesRep_ID"] = user.selesRep_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["kiloPrice"] = user.kiloPrice;
			drow["weight"] = user.weight;
			drow["qty"] = user.qty;
			drow["deliveryDate"] = user.deliveryDate;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isSTSCostingConfirmed"] = user.isSTSCostingConfirmed;
			drow["isSTSQuotaionPending"] = user.isSTSQuotaionPending;
			drow["isSTSJobConfirmPending"] = user.isSTSJobConfirmPending;
			drow["isSTSJobConfirmed"] = user.isSTSJobConfirmed;
			drow["costingConfirmedUser_ID"] = user.costingConfirmedUser_ID;
			drow["costingConfirmedDate"] = user.costingConfirmedDate;
			drow["jobConfirmedUser_ID"] = user.jobConfirmedUser_ID;
			drow["jobConfirmedDate"] = user.jobConfirmedDate;
			drow["confirmRemark"] = user.confirmRemark;
			drow["printCount"] = user.printCount;
			drow["printCount_Other"] = user.printCount_Other;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
