using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsNotification_ProductionOutput {
		#region Fields
		private Int64 notification_ID;
		private int line_NoShedule;
		private string workInProgress_ID;
		private int line_No;
		private string prePlan_ID;
		private string section_ID;
		private string machine_ID;
		private string item_ID;
		private string productionJob_ID;
		private string deliveryOrder_ID;
		private string sectionGoodIssueNote_ID;
		private string salesReturnedNote_ID;
		private string customerID;
		private decimal length;
		private decimal qty;
		private decimal weight;
		private decimal weight_Transfered;
		private decimal weight_Delivered;
		private decimal weight_Returned;
		private bool isDateAsigned;
		private bool isQADone;
		private bool isDelivered;
		private bool isTransfered;
		private bool isReturned;
		private DateTime dateAsignedDate;
		private DateTime dateQADate;
		private DateTime dateProduced;
		private DateTime dateTransfered;
		private DateTime dateDelivered;
		private DateTime dateReturned;
		private string deliveredVehicleNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsNotification_ProductionOutput class.
		/// </summary>
		public tbl_pmsNotification_ProductionOutput() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsNotification_ProductionOutput class.
		/// </summary>
		public tbl_pmsNotification_ProductionOutput(int line_NoShedule, string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID, string item_ID, string productionJob_ID, string deliveryOrder_ID, string sectionGoodIssueNote_ID, string salesReturnedNote_ID, string customerID, decimal length, decimal qty, decimal weight, decimal weight_Transfered, decimal weight_Delivered, decimal weight_Returned, bool isDateAsigned, bool isQADone, bool isDelivered, bool isTransfered, bool isReturned, DateTime dateAsignedDate, DateTime dateQADate, DateTime dateProduced, DateTime dateTransfered, DateTime dateDelivered, DateTime dateReturned, string deliveredVehicleNo) {
			this.line_NoShedule = line_NoShedule;
			this.workInProgress_ID = workInProgress_ID;
			this.line_No = line_No;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.machine_ID = machine_ID;
			this.item_ID = item_ID;
			this.productionJob_ID = productionJob_ID;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.sectionGoodIssueNote_ID = sectionGoodIssueNote_ID;
			this.salesReturnedNote_ID = salesReturnedNote_ID;
			this.customerID = customerID;
			this.length = length;
			this.qty = qty;
			this.weight = weight;
			this.weight_Transfered = weight_Transfered;
			this.weight_Delivered = weight_Delivered;
			this.weight_Returned = weight_Returned;
			this.isDateAsigned = isDateAsigned;
			this.isQADone = isQADone;
			this.isDelivered = isDelivered;
			this.isTransfered = isTransfered;
			this.isReturned = isReturned;
			this.dateAsignedDate = dateAsignedDate;
			this.dateQADate = dateQADate;
			this.dateProduced = dateProduced;
			this.dateTransfered = dateTransfered;
			this.dateDelivered = dateDelivered;
			this.dateReturned = dateReturned;
			this.deliveredVehicleNo = deliveredVehicleNo;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsNotification_ProductionOutput class.
		/// </summary>
		public tbl_pmsNotification_ProductionOutput(Int64 notification_ID, int line_NoShedule, string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID, string item_ID, string productionJob_ID, string deliveryOrder_ID, string sectionGoodIssueNote_ID, string salesReturnedNote_ID, string customerID, decimal length, decimal qty, decimal weight, decimal weight_Transfered, decimal weight_Delivered, decimal weight_Returned, bool isDateAsigned, bool isQADone, bool isDelivered, bool isTransfered, bool isReturned, DateTime dateAsignedDate, DateTime dateQADate, DateTime dateProduced, DateTime dateTransfered, DateTime dateDelivered, DateTime dateReturned, string deliveredVehicleNo) {
			this.notification_ID = notification_ID;
			this.line_NoShedule = line_NoShedule;
			this.workInProgress_ID = workInProgress_ID;
			this.line_No = line_No;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.machine_ID = machine_ID;
			this.item_ID = item_ID;
			this.productionJob_ID = productionJob_ID;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.sectionGoodIssueNote_ID = sectionGoodIssueNote_ID;
			this.salesReturnedNote_ID = salesReturnedNote_ID;
			this.customerID = customerID;
			this.length = length;
			this.qty = qty;
			this.weight = weight;
			this.weight_Transfered = weight_Transfered;
			this.weight_Delivered = weight_Delivered;
			this.weight_Returned = weight_Returned;
			this.isDateAsigned = isDateAsigned;
			this.isQADone = isQADone;
			this.isDelivered = isDelivered;
			this.isTransfered = isTransfered;
			this.isReturned = isReturned;
			this.dateAsignedDate = dateAsignedDate;
			this.dateQADate = dateQADate;
			this.dateProduced = dateProduced;
			this.dateTransfered = dateTransfered;
			this.dateDelivered = dateDelivered;
			this.dateReturned = dateReturned;
			this.deliveredVehicleNo = deliveredVehicleNo;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Notification_ID value.
		/// </summary>
		public Int64 Notification_ID {
			get { return notification_ID; }
			set { notification_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_NoShedule value.
		/// </summary>
		public int Line_NoShedule {
			get { return line_NoShedule; }
			set { line_NoShedule = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkInProgress_ID value.
		/// </summary>
		public string WorkInProgress_ID {
			get { return workInProgress_ID; }
			set { workInProgress_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrePlan_ID value.
		/// </summary>
		public string PrePlan_ID {
			get { return prePlan_ID; }
			set { prePlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryOrder_ID value.
		/// </summary>
		public string DeliveryOrder_ID {
			get { return deliveryOrder_ID; }
			set { deliveryOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionGoodIssueNote_ID value.
		/// </summary>
		public string SectionGoodIssueNote_ID {
			get { return sectionGoodIssueNote_ID; }
			set { sectionGoodIssueNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesReturnedNote_ID value.
		/// </summary>
		public string SalesReturnedNote_ID {
			get { return salesReturnedNote_ID; }
			set { salesReturnedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerID value.
		/// </summary>
		public string CustomerID {
			get { return customerID; }
			set { customerID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Length value.
		/// </summary>
		public decimal Length {
			get { return length; }
			set { length = value; }
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
		/// Gets or sets the Weight_Transfered value.
		/// </summary>
		public decimal Weight_Transfered {
			get { return weight_Transfered; }
			set { weight_Transfered = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight_Delivered value.
		/// </summary>
		public decimal Weight_Delivered {
			get { return weight_Delivered; }
			set { weight_Delivered = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight_Returned value.
		/// </summary>
		public decimal Weight_Returned {
			get { return weight_Returned; }
			set { weight_Returned = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDateAsigned value.
		/// </summary>
		public bool IsDateAsigned {
			get { return isDateAsigned; }
			set { isDateAsigned = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsQADone value.
		/// </summary>
		public bool IsQADone {
			get { return isQADone; }
			set { isQADone = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDelivered value.
		/// </summary>
		public bool IsDelivered {
			get { return isDelivered; }
			set { isDelivered = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTransfered value.
		/// </summary>
		public bool IsTransfered {
			get { return isTransfered; }
			set { isTransfered = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsReturned value.
		/// </summary>
		public bool IsReturned {
			get { return isReturned; }
			set { isReturned = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateAsignedDate value.
		/// </summary>
		public DateTime DateAsignedDate {
			get { return dateAsignedDate; }
			set { dateAsignedDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateQADate value.
		/// </summary>
		public DateTime DateQADate {
			get { return dateQADate; }
			set { dateQADate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateProduced value.
		/// </summary>
		public DateTime DateProduced {
			get { return dateProduced; }
			set { dateProduced = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateTransfered value.
		/// </summary>
		public DateTime DateTransfered {
			get { return dateTransfered; }
			set { dateTransfered = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateDelivered value.
		/// </summary>
		public DateTime DateDelivered {
			get { return dateDelivered; }
			set { dateDelivered = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateReturned value.
		/// </summary>
		public DateTime DateReturned {
			get { return dateReturned; }
			set { dateReturned = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveredVehicleNo value.
		/// </summary>
		public string DeliveredVehicleNo {
			get { return deliveredVehicleNo; }
			set { deliveredVehicleNo = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsNotification_ProductionOutput table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Transfered", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Delivered", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Returned", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDateAsigned", SqlDbType.Bit,1);
			scom.Parameters.Add("@isQADone", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDelivered", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTransfered", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturned", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateAsignedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateQADate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateProduced", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateTransfered", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDelivered", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateReturned", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveredVehicleNo", SqlDbType.VarChar,50);
 
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@sectionGoodIssueNote_ID"].Value = sectionGoodIssueNote_ID;
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@customerID"].Value = customerID;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weight_Transfered"].Value = weight_Transfered;
			scom.Parameters["@weight_Delivered"].Value = weight_Delivered;
			scom.Parameters["@weight_Returned"].Value = weight_Returned;
			scom.Parameters["@isDateAsigned"].Value = isDateAsigned;
			scom.Parameters["@isQADone"].Value = isQADone;
			scom.Parameters["@isDelivered"].Value = isDelivered;
			scom.Parameters["@isTransfered"].Value = isTransfered;
			scom.Parameters["@isReturned"].Value = isReturned;
			scom.Parameters["@dateAsignedDate"].Value = dateAsignedDate;
			scom.Parameters["@dateQADate"].Value = dateQADate;
			scom.Parameters["@dateProduced"].Value = dateProduced;
			scom.Parameters["@dateTransfered"].Value = dateTransfered;
			scom.Parameters["@dateDelivered"].Value = dateDelivered;
			scom.Parameters["@dateReturned"].Value = dateReturned;
			scom.Parameters["@deliveredVehicleNo"].Value = deliveredVehicleNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsNotification_ProductionOutput table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@notification_ID", SqlDbType.BigInt);
            scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@length", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Transfered", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Delivered", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight_Returned", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDateAsigned", SqlDbType.Bit,1);
			scom.Parameters.Add("@isQADone", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDelivered", SqlDbType.Bit,1);
			scom.Parameters.Add("@isTransfered", SqlDbType.Bit,1);
			scom.Parameters.Add("@isReturned", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateAsignedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateQADate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateProduced", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateTransfered", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDelivered", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateReturned", SqlDbType.DateTime,8);
			scom.Parameters.Add("@deliveredVehicleNo", SqlDbType.VarChar,50);

            scom.Parameters["@notification_ID"].Value = notification_ID;
            scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@sectionGoodIssueNote_ID"].Value = sectionGoodIssueNote_ID;
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@customerID"].Value = customerID;
			scom.Parameters["@length"].Value = length;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weight_Transfered"].Value = weight_Transfered;
			scom.Parameters["@weight_Delivered"].Value = weight_Delivered;
			scom.Parameters["@weight_Returned"].Value = weight_Returned;
			scom.Parameters["@isDateAsigned"].Value = isDateAsigned;
			scom.Parameters["@isQADone"].Value = isQADone;
			scom.Parameters["@isDelivered"].Value = isDelivered;
			scom.Parameters["@isTransfered"].Value = isTransfered;
			scom.Parameters["@isReturned"].Value = isReturned;
			scom.Parameters["@dateAsignedDate"].Value = dateAsignedDate;
			scom.Parameters["@dateQADate"].Value = dateQADate;
			scom.Parameters["@dateProduced"].Value = dateProduced;
			scom.Parameters["@dateTransfered"].Value = dateTransfered;
			scom.Parameters["@dateDelivered"].Value = dateDelivered;
			scom.Parameters["@dateReturned"].Value = dateReturned;
			scom.Parameters["@deliveredVehicleNo"].Value = deliveredVehicleNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsNotification_ProductionOutput table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@notification_ID", SqlDbType.BigInt,8);
			scom.Parameters["@notification_ID"].Value = notification_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsNotification_ProductionOutput table by a foreign key.
		/// </summary>
		public static void DeleteAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputDeleteAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsNotification_ProductionOutput table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputDeleteAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsNotification_ProductionOutput table by a foreign key.
		/// </summary>
		public static void DeleteAllBySectionGoodIssueNote_ID(string sectionGoodIssueNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputDeleteAllBySectionGoodIssueNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sectionGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@sectionGoodIssueNote_ID"].Value = sectionGoodIssueNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsNotification_ProductionOutput table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_NoShedule_WorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID_Item_ID(int line_NoShedule, string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID, string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputDeleteAllByLine_NoShedule_WorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID_Item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsNotification_ProductionOutput table.
		/// </summary>
		public static tbl_pmsNotification_ProductionOutput Select(Int64 notification_ID_Incoming){

			tbl_pmsNotification_ProductionOutput tbl_pmsNotification_ProductionOutputins = new tbl_pmsNotification_ProductionOutput();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@notification_ID", SqlDbType.BigInt,8);
			scom.Parameters["@notification_ID"].Value = notification_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsNotification_ProductionOutputins = Maketbl_pmsNotification_ProductionOutput(dataReader);
				} else {
					tbl_pmsNotification_ProductionOutputins = null;
				}
			}
			scon.Close();
			return tbl_pmsNotification_ProductionOutputins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsNotification_ProductionOutput table.
		/// </summary>
		public static List<tbl_pmsNotification_ProductionOutput> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsNotification_ProductionOutput> tbl_pmsNotification_ProductionOutputList = new List<tbl_pmsNotification_ProductionOutput>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsNotification_ProductionOutput tbl_pmsNotification_ProductionOutput = Maketbl_pmsNotification_ProductionOutput(dataReader);
					tbl_pmsNotification_ProductionOutputList.Add(tbl_pmsNotification_ProductionOutput);
				}
			}
			scon.Close();
			return tbl_pmsNotification_ProductionOutputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsNotification_ProductionOutput table by a foreign key.
		/// </summary>
		public static List<tbl_pmsNotification_ProductionOutput> SelectAllByProductionJob_ID(string productionJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputSelectAllByProductionJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
				List<tbl_pmsNotification_ProductionOutput> tbl_pmsNotification_ProductionOutputList = new List<tbl_pmsNotification_ProductionOutput>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsNotification_ProductionOutput tbl_pmsNotification_ProductionOutput = Maketbl_pmsNotification_ProductionOutput(dataReader);
					tbl_pmsNotification_ProductionOutputList.Add(tbl_pmsNotification_ProductionOutput);
				}
			}
			scon.Close();
			return tbl_pmsNotification_ProductionOutputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsNotification_ProductionOutput table by a foreign key.
		/// </summary>
		public static List<tbl_pmsNotification_ProductionOutput> SelectAllByDeliveryOrder_ID(string deliveryOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputSelectAllByDeliveryOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
				List<tbl_pmsNotification_ProductionOutput> tbl_pmsNotification_ProductionOutputList = new List<tbl_pmsNotification_ProductionOutput>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsNotification_ProductionOutput tbl_pmsNotification_ProductionOutput = Maketbl_pmsNotification_ProductionOutput(dataReader);
					tbl_pmsNotification_ProductionOutputList.Add(tbl_pmsNotification_ProductionOutput);
				}
			}
			scon.Close();
			return tbl_pmsNotification_ProductionOutputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsNotification_ProductionOutput table by a foreign key.
		/// </summary>
		public static List<tbl_pmsNotification_ProductionOutput> SelectAllBySectionGoodIssueNote_ID(string sectionGoodIssueNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputSelectAllBySectionGoodIssueNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sectionGoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@sectionGoodIssueNote_ID"].Value = sectionGoodIssueNote_ID;
				List<tbl_pmsNotification_ProductionOutput> tbl_pmsNotification_ProductionOutputList = new List<tbl_pmsNotification_ProductionOutput>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsNotification_ProductionOutput tbl_pmsNotification_ProductionOutput = Maketbl_pmsNotification_ProductionOutput(dataReader);
					tbl_pmsNotification_ProductionOutputList.Add(tbl_pmsNotification_ProductionOutput);
				}
			}
			scon.Close();
			return tbl_pmsNotification_ProductionOutputList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsNotification_ProductionOutput table by a foreign key.
		/// </summary>
		public static List<tbl_pmsNotification_ProductionOutput> SelectAllByLine_NoShedule_WorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID_Item_ID(int line_NoShedule, string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID, string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsNotification_ProductionOutputSelectAllByLine_NoShedule_WorkInProgress_ID_Line_No_PrePlan_ID_Section_ID_Machine_ID_Item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoShedule", SqlDbType.Int,4);
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoShedule"].Value = line_NoShedule;
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_pmsNotification_ProductionOutput> tbl_pmsNotification_ProductionOutputList = new List<tbl_pmsNotification_ProductionOutput>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsNotification_ProductionOutput tbl_pmsNotification_ProductionOutput = Maketbl_pmsNotification_ProductionOutput(dataReader);
					tbl_pmsNotification_ProductionOutputList.Add(tbl_pmsNotification_ProductionOutput);
				}
			}
			scon.Close();
			return tbl_pmsNotification_ProductionOutputList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsNotification_ProductionOutput class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsNotification_ProductionOutput Maketbl_pmsNotification_ProductionOutput(SqlDataReader dataReader) {
			tbl_pmsNotification_ProductionOutput tbl_pmsNotification_ProductionOutput = new tbl_pmsNotification_ProductionOutput();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsNotification_ProductionOutput.Notification_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsNotification_ProductionOutput.Line_NoShedule = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsNotification_ProductionOutput.WorkInProgress_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsNotification_ProductionOutput.Line_No = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsNotification_ProductionOutput.PrePlan_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsNotification_ProductionOutput.Section_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsNotification_ProductionOutput.Machine_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsNotification_ProductionOutput.Item_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsNotification_ProductionOutput.ProductionJob_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pmsNotification_ProductionOutput.DeliveryOrder_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pmsNotification_ProductionOutput.SectionGoodIssueNote_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_pmsNotification_ProductionOutput.SalesReturnedNote_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_pmsNotification_ProductionOutput.CustomerID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_pmsNotification_ProductionOutput.Length = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_pmsNotification_ProductionOutput.Qty = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_pmsNotification_ProductionOutput.Weight = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_pmsNotification_ProductionOutput.Weight_Transfered = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_pmsNotification_ProductionOutput.Weight_Delivered = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_pmsNotification_ProductionOutput.Weight_Returned = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_pmsNotification_ProductionOutput.IsDateAsigned = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_pmsNotification_ProductionOutput.IsQADone = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_pmsNotification_ProductionOutput.IsDelivered = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_pmsNotification_ProductionOutput.IsTransfered = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_pmsNotification_ProductionOutput.IsReturned = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_pmsNotification_ProductionOutput.DateAsignedDate = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_pmsNotification_ProductionOutput.DateQADate = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_pmsNotification_ProductionOutput.DateProduced = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_pmsNotification_ProductionOutput.DateTransfered = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_pmsNotification_ProductionOutput.DateDelivered = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_pmsNotification_ProductionOutput.DateReturned = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_pmsNotification_ProductionOutput.DeliveredVehicleNo = dataReader.GetString(30);
			}

			return tbl_pmsNotification_ProductionOutput;
		}
		/// <summary>
		/// This makes tbl_pmsNotification_ProductionOutput datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsNotification_ProductionOutput object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsNotification_ProductionOutput  tbl_pmsNotification_ProductionOutput   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_notification_ID = new DataColumn("notification_ID" , typeof(long));
			DataColumn col_line_NoShedule = new DataColumn("line_NoShedule" , typeof(int));
			DataColumn col_workInProgress_ID = new DataColumn("workInProgress_ID" , typeof(string));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prePlan_ID = new DataColumn("prePlan_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_sectionGoodIssueNote_ID = new DataColumn("sectionGoodIssueNote_ID" , typeof(string));
			DataColumn col_salesReturnedNote_ID = new DataColumn("salesReturnedNote_ID" , typeof(string));
			DataColumn col_customerID = new DataColumn("customerID" , typeof(string));
			DataColumn col_length = new DataColumn("length" , typeof(decimal));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weight_Transfered = new DataColumn("weight_Transfered" , typeof(decimal));
			DataColumn col_weight_Delivered = new DataColumn("weight_Delivered" , typeof(decimal));
			DataColumn col_weight_Returned = new DataColumn("weight_Returned" , typeof(decimal));
			DataColumn col_isDateAsigned = new DataColumn("isDateAsigned" , typeof(bool));
			DataColumn col_isQADone = new DataColumn("isQADone" , typeof(bool));
			DataColumn col_isDelivered = new DataColumn("isDelivered" , typeof(bool));
			DataColumn col_isTransfered = new DataColumn("isTransfered" , typeof(bool));
			DataColumn col_isReturned = new DataColumn("isReturned" , typeof(bool));
			DataColumn col_dateAsignedDate = new DataColumn("dateAsignedDate" , typeof(DateTime));
			DataColumn col_dateQADate = new DataColumn("dateQADate" , typeof(DateTime));
			DataColumn col_dateProduced = new DataColumn("dateProduced" , typeof(DateTime));
			DataColumn col_dateTransfered = new DataColumn("dateTransfered" , typeof(DateTime));
			DataColumn col_dateDelivered = new DataColumn("dateDelivered" , typeof(DateTime));
			DataColumn col_dateReturned = new DataColumn("dateReturned" , typeof(DateTime));
			DataColumn col_deliveredVehicleNo = new DataColumn("deliveredVehicleNo" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_notification_ID,col_line_NoShedule,col_workInProgress_ID,col_line_No,col_prePlan_ID,col_section_ID,col_machine_ID,col_item_ID,col_productionJob_ID,col_deliveryOrder_ID,col_sectionGoodIssueNote_ID,col_salesReturnedNote_ID,col_customerID,col_length,col_qty,col_weight,col_weight_Transfered,col_weight_Delivered,col_weight_Returned,col_isDateAsigned,col_isQADone,col_isDelivered,col_isTransfered,col_isReturned,col_dateAsignedDate,col_dateQADate,col_dateProduced,col_dateTransfered,col_dateDelivered,col_dateReturned,col_deliveredVehicleNo,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsNotification_ProductionOutput datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsNotification_ProductionOutput object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsNotification_ProductionOutput user) {
		DataRow drow = dt.NewRow();
		
			drow["notification_ID"] = user.notification_ID;
			drow["line_NoShedule"] = user.line_NoShedule;
			drow["workInProgress_ID"] = user.workInProgress_ID;
			drow["line_No"] = user.line_No;
			drow["prePlan_ID"] = user.prePlan_ID;
			drow["section_ID"] = user.section_ID;
			drow["machine_ID"] = user.machine_ID;
			drow["item_ID"] = user.item_ID;
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["sectionGoodIssueNote_ID"] = user.sectionGoodIssueNote_ID;
			drow["salesReturnedNote_ID"] = user.salesReturnedNote_ID;
			drow["customerID"] = user.customerID;
			drow["length"] = user.length;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["weight_Transfered"] = user.weight_Transfered;
			drow["weight_Delivered"] = user.weight_Delivered;
			drow["weight_Returned"] = user.weight_Returned;
			drow["isDateAsigned"] = user.isDateAsigned;
			drow["isQADone"] = user.isQADone;
			drow["isDelivered"] = user.isDelivered;
			drow["isTransfered"] = user.isTransfered;
			drow["isReturned"] = user.isReturned;
			drow["dateAsignedDate"] = user.dateAsignedDate;
			drow["dateQADate"] = user.dateQADate;
			drow["dateProduced"] = user.dateProduced;
			drow["dateTransfered"] = user.dateTransfered;
			drow["dateDelivered"] = user.dateDelivered;
			drow["dateReturned"] = user.dateReturned;
			drow["deliveredVehicleNo"] = user.deliveredVehicleNo;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
