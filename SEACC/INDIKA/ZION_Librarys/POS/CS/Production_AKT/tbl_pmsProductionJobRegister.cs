using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsProductionJobRegister {
		#region Fields
		private string productionJob_ID;
		private DateTime productionOrderDate;
		private string remark;
		private string job_ID;
		private string item_ID;
		private string uom_ID;
		private string customerOrder_ID;
		private string customer_ID;
		private string productionJobType_ID;
		private string employee_ID;
		private string orderRefNo_ID;
		private string deliveryAddress;
		private decimal qty;
		private decimal weight;
		private DateTime planDate;
		private DateTime startDate;
		private DateTime endDate;
		private DateTime deliveryDate;
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
		private bool isPrePlaned;
		private bool isPrePlanedApproved;
		private bool isJobWorkInProgress;
		private bool isJobClosed;
		private bool isJobSuspended;
		private string currency_ID;
		private decimal currencyRate;
		private decimal unitPrice;
		private decimal kiloPrice;
		private DateTime deliveryDate_Production;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsProductionJobRegister class.
		/// </summary>
		public tbl_pmsProductionJobRegister() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsProductionJobRegister class.
		/// </summary>
		public tbl_pmsProductionJobRegister(string productionJob_ID, DateTime productionOrderDate, string remark, string job_ID, string item_ID, string uom_ID, string customerOrder_ID, string customer_ID, string productionJobType_ID, string employee_ID, string orderRefNo_ID, string deliveryAddress, decimal qty, decimal weight, DateTime planDate, DateTime startDate, DateTime endDate, DateTime deliveryDate, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isPrePlaned, bool isPrePlanedApproved, bool isJobWorkInProgress, bool isJobClosed, bool isJobSuspended, string currency_ID, decimal currencyRate, decimal unitPrice, decimal kiloPrice, DateTime deliveryDate_Production) {
			this.productionJob_ID = productionJob_ID;
			this.productionOrderDate = productionOrderDate;
			this.remark = remark;
			this.job_ID = job_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.customer_ID = customer_ID;
			this.productionJobType_ID = productionJobType_ID;
			this.employee_ID = employee_ID;
			this.orderRefNo_ID = orderRefNo_ID;
			this.deliveryAddress = deliveryAddress;
			this.qty = qty;
			this.weight = weight;
			this.planDate = planDate;
			this.startDate = startDate;
			this.endDate = endDate;
			this.deliveryDate = deliveryDate;
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
			this.isPrePlaned = isPrePlaned;
			this.isPrePlanedApproved = isPrePlanedApproved;
			this.isJobWorkInProgress = isJobWorkInProgress;
			this.isJobClosed = isJobClosed;
			this.isJobSuspended = isJobSuspended;
			this.currency_ID = currency_ID;
			this.currencyRate = currencyRate;
			this.unitPrice = unitPrice;
			this.kiloPrice = kiloPrice;
			this.deliveryDate_Production = deliveryDate_Production;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionOrderDate value.
		/// </summary>
		public DateTime ProductionOrderDate {
			get { return productionOrderDate; }
			set { productionOrderDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Job_ID value.
		/// </summary>
		public string Job_ID {
			get { return job_ID; }
			set { job_ID = value; }
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
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJobType_ID value.
		/// </summary>
		public string ProductionJobType_ID {
			get { return productionJobType_ID; }
			set { productionJobType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderRefNo_ID value.
		/// </summary>
		public string OrderRefNo_ID {
			get { return orderRefNo_ID; }
			set { orderRefNo_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryAddress value.
		/// </summary>
		public string DeliveryAddress {
			get { return deliveryAddress; }
			set { deliveryAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the PlanDate value.
		/// </summary>
		public DateTime PlanDate {
			get { return planDate; }
			set { planDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the StartDate value.
		/// </summary>
		public DateTime StartDate {
			get { return startDate; }
			set { startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the EndDate value.
		/// </summary>
		public DateTime EndDate {
			get { return endDate; }
			set { endDate = value; }
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
		/// Gets or sets the IsPrePlaned value.
		/// </summary>
		public bool IsPrePlaned {
			get { return isPrePlaned; }
			set { isPrePlaned = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPrePlanedApproved value.
		/// </summary>
		public bool IsPrePlanedApproved {
			get { return isPrePlanedApproved; }
			set { isPrePlanedApproved = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobWorkInProgress value.
		/// </summary>
		public bool IsJobWorkInProgress {
			get { return isJobWorkInProgress; }
			set { isJobWorkInProgress = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobClosed value.
		/// </summary>
		public bool IsJobClosed {
			get { return isJobClosed; }
			set { isJobClosed = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobSuspended value.
		/// </summary>
		public bool IsJobSuspended {
			get { return isJobSuspended; }
			set { isJobSuspended = value; }
		}
		
		/// <summary>
		/// Gets or sets the Currency_ID value.
		/// </summary>
		public string Currency_ID {
			get { return currency_ID; }
			set { currency_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CurrencyRate value.
		/// </summary>
		public decimal CurrencyRate {
			get { return currencyRate; }
			set { currencyRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the KiloPrice value.
		/// </summary>
		public decimal KiloPrice {
			get { return kiloPrice; }
			set { kiloPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryDate_Production value.
		/// </summary>
		public DateTime DeliveryDate_Production {
			get { return deliveryDate_Production; }
			set { deliveryDate_Production = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsProductionJobRegister table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@productionOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deliveryAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@planDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveryDate", SqlDbType.DateTime,8);
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
			scom.Parameters.Add("@isPrePlaned", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPrePlanedApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobWorkInProgress", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobSuspended", SqlDbType.Bit,1);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@KiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliveryDate_Production", SqlDbType.DateTime,8);
 
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@productionOrderDate"].Value = productionOrderDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@deliveryAddress"].Value = deliveryAddress;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@planDate"].Value = planDate;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@deliveryDate"].Value = deliveryDate;
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
			scom.Parameters["@isPrePlaned"].Value = isPrePlaned;
			scom.Parameters["@isPrePlanedApproved"].Value = isPrePlanedApproved;
			scom.Parameters["@isJobWorkInProgress"].Value = isJobWorkInProgress;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@isJobSuspended"].Value = isJobSuspended;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@KiloPrice"].Value = kiloPrice;
			scom.Parameters["@deliveryDate_Production"].Value = deliveryDate_Production;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsProductionJobRegister table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@productionOrderDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deliveryAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@planDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveryDate", SqlDbType.DateTime,8);
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
			scom.Parameters.Add("@isPrePlaned", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPrePlanedApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobWorkInProgress", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobSuspended", SqlDbType.Bit,1);
			scom.Parameters.Add("@currency_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@currencyRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@KiloPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliveryDate_Production", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@productionOrderDate"].Value = productionOrderDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@job_ID"].Value = job_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
			scom.Parameters["@deliveryAddress"].Value = deliveryAddress;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@planDate"].Value = planDate;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@deliveryDate"].Value = deliveryDate;
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
			scom.Parameters["@isPrePlaned"].Value = isPrePlaned;
			scom.Parameters["@isPrePlanedApproved"].Value = isPrePlanedApproved;
			scom.Parameters["@isJobWorkInProgress"].Value = isJobWorkInProgress;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@isJobSuspended"].Value = isJobSuspended;
			scom.Parameters["@currency_ID"].Value = currency_ID;
			scom.Parameters["@currencyRate"].Value = currencyRate;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@KiloPrice"].Value = kiloPrice;
			scom.Parameters["@deliveryDate_Production"].Value = deliveryDate_Production;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsProductionJobRegister table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterDeleteAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByProductionJobType_ID(string productionJobType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterDeleteAllByProductionJobType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterDeleteAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsProductionJobRegister table.
		/// </summary>
		public static tbl_pmsProductionJobRegister Select(string productionJob_ID_Incoming){

			tbl_pmsProductionJobRegister tbl_pmsProductionJobRegisterins = new tbl_pmsProductionJobRegister();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsProductionJobRegisterins = Maketbl_pmsProductionJobRegister(dataReader);
				} else {
					tbl_pmsProductionJobRegisterins = null;
				}
			}
			scon.Close();
			return tbl_pmsProductionJobRegisterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table.
		/// </summary>
		public static List<tbl_pmsProductionJobRegister> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsProductionJobRegister> tbl_pmsProductionJobRegisterList = new List<tbl_pmsProductionJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobRegister tbl_pmsProductionJobRegister = Maketbl_pmsProductionJobRegister(dataReader);
					tbl_pmsProductionJobRegisterList.Add(tbl_pmsProductionJobRegister);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_pmsProductionJobRegister> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_pmsProductionJobRegister> tbl_pmsProductionJobRegisterList = new List<tbl_pmsProductionJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobRegister tbl_pmsProductionJobRegister = Maketbl_pmsProductionJobRegister(dataReader);
					tbl_pmsProductionJobRegisterList.Add(tbl_pmsProductionJobRegister);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_pmsProductionJobRegister> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_pmsProductionJobRegister> tbl_pmsProductionJobRegisterList = new List<tbl_pmsProductionJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobRegister tbl_pmsProductionJobRegister = Maketbl_pmsProductionJobRegister(dataReader);
					tbl_pmsProductionJobRegisterList.Add(tbl_pmsProductionJobRegister);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_pmsProductionJobRegister> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_pmsProductionJobRegister> tbl_pmsProductionJobRegisterList = new List<tbl_pmsProductionJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobRegister tbl_pmsProductionJobRegister = Maketbl_pmsProductionJobRegister(dataReader);
					tbl_pmsProductionJobRegisterList.Add(tbl_pmsProductionJobRegister);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_pmsProductionJobRegister> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_pmsProductionJobRegister> tbl_pmsProductionJobRegisterList = new List<tbl_pmsProductionJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobRegister tbl_pmsProductionJobRegister = Maketbl_pmsProductionJobRegister(dataReader);
					tbl_pmsProductionJobRegisterList.Add(tbl_pmsProductionJobRegister);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_pmsProductionJobRegister> SelectAllByOrderRefNo_ID(string orderRefNo_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterSelectAllByOrderRefNo_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@orderRefNo_ID", SqlDbType.VarChar,10);
			scom.Parameters["@orderRefNo_ID"].Value = orderRefNo_ID;
				List<tbl_pmsProductionJobRegister> tbl_pmsProductionJobRegisterList = new List<tbl_pmsProductionJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobRegister tbl_pmsProductionJobRegister = Maketbl_pmsProductionJobRegister(dataReader);
					tbl_pmsProductionJobRegisterList.Add(tbl_pmsProductionJobRegister);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_pmsProductionJobRegister> SelectAllByProductionJobType_ID(string productionJobType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterSelectAllByProductionJobType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID;
				List<tbl_pmsProductionJobRegister> tbl_pmsProductionJobRegisterList = new List<tbl_pmsProductionJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobRegister tbl_pmsProductionJobRegister = Maketbl_pmsProductionJobRegister(dataReader);
					tbl_pmsProductionJobRegisterList.Add(tbl_pmsProductionJobRegister);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsProductionJobRegister table by a foreign key.
		/// </summary>
		public static List<tbl_pmsProductionJobRegister> SelectAllByJob_ID(string job_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsProductionJobRegisterSelectAllByJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@job_ID", SqlDbType.VarChar,20);
			scom.Parameters["@job_ID"].Value = job_ID;
				List<tbl_pmsProductionJobRegister> tbl_pmsProductionJobRegisterList = new List<tbl_pmsProductionJobRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsProductionJobRegister tbl_pmsProductionJobRegister = Maketbl_pmsProductionJobRegister(dataReader);
					tbl_pmsProductionJobRegisterList.Add(tbl_pmsProductionJobRegister);
				}
			}
			scon.Close();
			return tbl_pmsProductionJobRegisterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsProductionJobRegister class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsProductionJobRegister Maketbl_pmsProductionJobRegister(SqlDataReader dataReader) {
			tbl_pmsProductionJobRegister tbl_pmsProductionJobRegister = new tbl_pmsProductionJobRegister();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsProductionJobRegister.ProductionJob_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsProductionJobRegister.ProductionOrderDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsProductionJobRegister.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsProductionJobRegister.Job_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsProductionJobRegister.Item_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsProductionJobRegister.Uom_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsProductionJobRegister.CustomerOrder_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsProductionJobRegister.Customer_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsProductionJobRegister.ProductionJobType_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pmsProductionJobRegister.Employee_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pmsProductionJobRegister.OrderRefNo_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pmsProductionJobRegister.DeliveryAddress = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pmsProductionJobRegister.Qty = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pmsProductionJobRegister.Weight = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pmsProductionJobRegister.PlanDate = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pmsProductionJobRegister.StartDate = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pmsProductionJobRegister.EndDate = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pmsProductionJobRegister.DeliveryDate = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pmsProductionJobRegister.CreateUser_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_pmsProductionJobRegister.ModifiedUser_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_pmsProductionJobRegister.CheckedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_pmsProductionJobRegister.ApprovedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_pmsProductionJobRegister.DateCreate = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_pmsProductionJobRegister.DateModified = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_pmsProductionJobRegister.DateChecked = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_pmsProductionJobRegister.DateApproved = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_pmsProductionJobRegister.IsChecked = dataReader.GetBoolean(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_pmsProductionJobRegister.IsApproved = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_pmsProductionJobRegister.IsFinished = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_pmsProductionJobRegister.IsDeleted = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_pmsProductionJobRegister.IsLocked = dataReader.GetBoolean(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_pmsProductionJobRegister.IsPrePlaned = dataReader.GetBoolean(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_pmsProductionJobRegister.IsPrePlanedApproved = dataReader.GetBoolean(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_pmsProductionJobRegister.IsJobWorkInProgress = dataReader.GetBoolean(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_pmsProductionJobRegister.IsJobClosed = dataReader.GetBoolean(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_pmsProductionJobRegister.IsJobSuspended = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_pmsProductionJobRegister.Currency_ID = dataReader.GetString(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_pmsProductionJobRegister.CurrencyRate = dataReader.GetDecimal(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_pmsProductionJobRegister.UnitPrice = dataReader.GetDecimal(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_pmsProductionJobRegister.KiloPrice = dataReader.GetDecimal(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_pmsProductionJobRegister.DeliveryDate_Production = dataReader.GetDateTime(40);
			}

			return tbl_pmsProductionJobRegister;
		}
		/// <summary>
		/// This makes tbl_pmsProductionJobRegister datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsProductionJobRegister object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsProductionJobRegister  tbl_pmsProductionJobRegister   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_productionOrderDate = new DataColumn("productionOrderDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_job_ID = new DataColumn("job_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_productionJobType_ID = new DataColumn("productionJobType_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_orderRefNo_ID = new DataColumn("orderRefNo_ID" , typeof(string));
			DataColumn col_deliveryAddress = new DataColumn("deliveryAddress" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_planDate = new DataColumn("planDate" , typeof(DateTime));
			DataColumn col_startDate = new DataColumn("startDate" , typeof(DateTime));
			DataColumn col_endDate = new DataColumn("endDate" , typeof(DateTime));
			DataColumn col_deliveryDate = new DataColumn("deliveryDate" , typeof(DateTime));
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
			DataColumn col_isPrePlaned = new DataColumn("isPrePlaned" , typeof(bool));
			DataColumn col_isPrePlanedApproved = new DataColumn("isPrePlanedApproved" , typeof(bool));
			DataColumn col_isJobWorkInProgress = new DataColumn("isJobWorkInProgress" , typeof(bool));
			DataColumn col_isJobClosed = new DataColumn("isJobClosed" , typeof(bool));
			DataColumn col_isJobSuspended = new DataColumn("isJobSuspended" , typeof(bool));
			DataColumn col_currency_ID = new DataColumn("currency_ID" , typeof(string));
			DataColumn col_currencyRate = new DataColumn("currencyRate" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_KiloPrice = new DataColumn("KiloPrice" , typeof(decimal));
			DataColumn col_deliveryDate_Production = new DataColumn("deliveryDate_Production" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_productionJob_ID,col_productionOrderDate,col_remark,col_job_ID,col_item_ID,col_uom_ID,col_customerOrder_ID,col_customer_ID,col_productionJobType_ID,col_employee_ID,col_orderRefNo_ID,col_deliveryAddress,col_qty,col_weight,col_planDate,col_startDate,col_endDate,col_deliveryDate,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isPrePlaned,col_isPrePlanedApproved,col_isJobWorkInProgress,col_isJobClosed,col_isJobSuspended,col_currency_ID,col_currencyRate,col_unitPrice,col_KiloPrice,col_deliveryDate_Production,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsProductionJobRegister datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsProductionJobRegister object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsProductionJobRegister user) {
		DataRow drow = dt.NewRow();
		
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["productionOrderDate"] = user.productionOrderDate;
			drow["remark"] = user.remark;
			drow["job_ID"] = user.job_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["customer_ID"] = user.customer_ID;
			drow["productionJobType_ID"] = user.productionJobType_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["orderRefNo_ID"] = user.orderRefNo_ID;
			drow["deliveryAddress"] = user.deliveryAddress;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["planDate"] = user.planDate;
			drow["startDate"] = user.startDate;
			drow["endDate"] = user.endDate;
			drow["deliveryDate"] = user.deliveryDate;
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
			drow["isPrePlaned"] = user.isPrePlaned;
			drow["isPrePlanedApproved"] = user.isPrePlanedApproved;
			drow["isJobWorkInProgress"] = user.isJobWorkInProgress;
			drow["isJobClosed"] = user.isJobClosed;
			drow["isJobSuspended"] = user.isJobSuspended;
			drow["currency_ID"] = user.currency_ID;
			drow["currencyRate"] = user.currencyRate;
			drow["unitPrice"] = user.unitPrice;
			drow["KiloPrice"] = user.KiloPrice;
			drow["deliveryDate_Production"] = user.deliveryDate_Production;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
