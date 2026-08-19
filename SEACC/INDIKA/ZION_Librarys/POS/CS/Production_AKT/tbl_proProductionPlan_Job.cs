using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_proProductionPlan_Job {
		#region Fields
		private int line_No;
		private string productionPlan_ID;
		private string productionJob_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty;
		private decimal qty_Printed;
		private decimal qty_UnPrinted;
		private decimal qty_Confirmed;
		private decimal qty_Stock;
		private DateTime productionPlan_StartDate;
		private DateTime productionPlan_EndDate;
		private bool isJobClosed;
		private DateTime dateJobClosed;
		private string jobClosedUser_ID;
		private bool isJobSuspended;
		private DateTime dateJobSuspended;
		private string jobSuspendedUser_ID;
		private bool isJobWorkInProgress;
		private DateTime workInProgress_StartDate;
		private DateTime workInProgress_EndDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_proProductionPlan_Job class.
		/// </summary>
		public tbl_proProductionPlan_Job() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_proProductionPlan_Job class.
		/// </summary>
		public tbl_proProductionPlan_Job(int line_No, string productionPlan_ID, string productionJob_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal qty_Printed, decimal qty_UnPrinted, decimal qty_Confirmed, decimal qty_Stock, DateTime productionPlan_StartDate, DateTime productionPlan_EndDate, bool isJobClosed, DateTime dateJobClosed, string jobClosedUser_ID, bool isJobSuspended, DateTime dateJobSuspended, string jobSuspendedUser_ID, bool isJobWorkInProgress, DateTime workInProgress_StartDate, DateTime workInProgress_EndDate) {
			this.line_No = line_No;
			this.productionPlan_ID = productionPlan_ID;
			this.productionJob_ID = productionJob_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty = qty;
			this.qty_Printed = qty_Printed;
			this.qty_UnPrinted = qty_UnPrinted;
			this.qty_Confirmed = qty_Confirmed;
			this.qty_Stock = qty_Stock;
			this.productionPlan_StartDate = productionPlan_StartDate;
			this.productionPlan_EndDate = productionPlan_EndDate;
			this.isJobClosed = isJobClosed;
			this.dateJobClosed = dateJobClosed;
			this.jobClosedUser_ID = jobClosedUser_ID;
			this.isJobSuspended = isJobSuspended;
			this.dateJobSuspended = dateJobSuspended;
			this.jobSuspendedUser_ID = jobSuspendedUser_ID;
			this.isJobWorkInProgress = isJobWorkInProgress;
			this.workInProgress_StartDate = workInProgress_StartDate;
			this.workInProgress_EndDate = workInProgress_EndDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionPlan_ID value.
		/// </summary>
		public string ProductionPlan_ID {
			get { return productionPlan_ID; }
			set { productionPlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory_ID value.
		/// </summary>
		public string ItemSubCategory_ID {
			get { return itemSubCategory_ID; }
			set { itemSubCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory2_ID value.
		/// </summary>
		public string ItemSubCategory2_ID {
			get { return itemSubCategory2_ID; }
			set { itemSubCategory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo2 value.
		/// </summary>
		public string ItemSerialNo2 {
			get { return itemSerialNo2; }
			set { itemSerialNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Printed value.
		/// </summary>
		public decimal Qty_Printed {
			get { return qty_Printed; }
			set { qty_Printed = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_UnPrinted value.
		/// </summary>
		public decimal Qty_UnPrinted {
			get { return qty_UnPrinted; }
			set { qty_UnPrinted = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Confirmed value.
		/// </summary>
		public decimal Qty_Confirmed {
			get { return qty_Confirmed; }
			set { qty_Confirmed = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_Stock value.
		/// </summary>
		public decimal Qty_Stock {
			get { return qty_Stock; }
			set { qty_Stock = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionPlan_StartDate value.
		/// </summary>
		public DateTime ProductionPlan_StartDate {
			get { return productionPlan_StartDate; }
			set { productionPlan_StartDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionPlan_EndDate value.
		/// </summary>
		public DateTime ProductionPlan_EndDate {
			get { return productionPlan_EndDate; }
			set { productionPlan_EndDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobClosed value.
		/// </summary>
		public bool IsJobClosed {
			get { return isJobClosed; }
			set { isJobClosed = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateJobClosed value.
		/// </summary>
		public DateTime DateJobClosed {
			get { return dateJobClosed; }
			set { dateJobClosed = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobClosedUser_ID value.
		/// </summary>
		public string JobClosedUser_ID {
			get { return jobClosedUser_ID; }
			set { jobClosedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobSuspended value.
		/// </summary>
		public bool IsJobSuspended {
			get { return isJobSuspended; }
			set { isJobSuspended = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateJobSuspended value.
		/// </summary>
		public DateTime DateJobSuspended {
			get { return dateJobSuspended; }
			set { dateJobSuspended = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobSuspendedUser_ID value.
		/// </summary>
		public string JobSuspendedUser_ID {
			get { return jobSuspendedUser_ID; }
			set { jobSuspendedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobWorkInProgress value.
		/// </summary>
		public bool IsJobWorkInProgress {
			get { return isJobWorkInProgress; }
			set { isJobWorkInProgress = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkInProgress_StartDate value.
		/// </summary>
		public DateTime WorkInProgress_StartDate {
			get { return workInProgress_StartDate; }
			set { workInProgress_StartDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkInProgress_EndDate value.
		/// </summary>
		public DateTime WorkInProgress_EndDate {
			get { return workInProgress_EndDate; }
			set { workInProgress_EndDate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_proProductionPlan_Job table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proProductionPlan_JobInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@productionPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Printed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_UnPrinted", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Confirmed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Stock", SqlDbType.Decimal,9);
			scom.Parameters.Add("@productionPlan_StartDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@productionPlan_EndDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobClosed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@jobClosedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isJobSuspended", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobSuspended", SqlDbType.DateTime,8);
			scom.Parameters.Add("@jobSuspendedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isJobWorkInProgress", SqlDbType.Bit,1);
			scom.Parameters.Add("@WorkInProgress_StartDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@WorkInProgress_EndDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@productionPlan_ID"].Value = productionPlan_ID;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qty_Printed"].Value = qty_Printed;
			scom.Parameters["@qty_UnPrinted"].Value = qty_UnPrinted;
			scom.Parameters["@qty_Confirmed"].Value = qty_Confirmed;
			scom.Parameters["@qty_Stock"].Value = qty_Stock;
			scom.Parameters["@productionPlan_StartDate"].Value = productionPlan_StartDate;
			scom.Parameters["@productionPlan_EndDate"].Value = productionPlan_EndDate;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@dateJobClosed"].Value = dateJobClosed;
			scom.Parameters["@jobClosedUser_ID"].Value = jobClosedUser_ID;
			scom.Parameters["@isJobSuspended"].Value = isJobSuspended;
			scom.Parameters["@dateJobSuspended"].Value = dateJobSuspended;
			scom.Parameters["@jobSuspendedUser_ID"].Value = jobSuspendedUser_ID;
			scom.Parameters["@isJobWorkInProgress"].Value = isJobWorkInProgress;
			scom.Parameters["@WorkInProgress_StartDate"].Value = workInProgress_StartDate;
			scom.Parameters["@WorkInProgress_EndDate"].Value = workInProgress_EndDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_proProductionPlan_Job table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proProductionPlan_JobUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@productionPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Printed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_UnPrinted", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Confirmed", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty_Stock", SqlDbType.Decimal,9);
			scom.Parameters.Add("@productionPlan_StartDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@productionPlan_EndDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobClosed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@jobClosedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isJobSuspended", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobSuspended", SqlDbType.DateTime,8);
			scom.Parameters.Add("@jobSuspendedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isJobWorkInProgress", SqlDbType.Bit,1);
			scom.Parameters.Add("@WorkInProgress_StartDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@WorkInProgress_EndDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@productionPlan_ID"].Value = productionPlan_ID;
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qty_Printed"].Value = qty_Printed;
			scom.Parameters["@qty_UnPrinted"].Value = qty_UnPrinted;
			scom.Parameters["@qty_Confirmed"].Value = qty_Confirmed;
			scom.Parameters["@qty_Stock"].Value = qty_Stock;
			scom.Parameters["@productionPlan_StartDate"].Value = productionPlan_StartDate;
			scom.Parameters["@productionPlan_EndDate"].Value = productionPlan_EndDate;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@dateJobClosed"].Value = dateJobClosed;
			scom.Parameters["@jobClosedUser_ID"].Value = jobClosedUser_ID;
			scom.Parameters["@isJobSuspended"].Value = isJobSuspended;
			scom.Parameters["@dateJobSuspended"].Value = dateJobSuspended;
			scom.Parameters["@jobSuspendedUser_ID"].Value = jobSuspendedUser_ID;
			scom.Parameters["@isJobWorkInProgress"].Value = isJobWorkInProgress;
			scom.Parameters["@WorkInProgress_StartDate"].Value = workInProgress_StartDate;
			scom.Parameters["@WorkInProgress_EndDate"].Value = workInProgress_EndDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_proProductionPlan_Job table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proProductionPlan_JobDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_proProductionPlan_Job table by a foreign key.
		/// </summary>
		public static void DeleteAllByProductionPlan_ID(string productionPlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proProductionPlan_JobDeleteAllByProductionPlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionPlan_ID"].Value = productionPlan_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_proProductionPlan_Job table.
		/// </summary>
		public static tbl_proProductionPlan_Job Select(string productionJob_ID_Incoming){

			tbl_proProductionPlan_Job tbl_proProductionPlan_Jobins = new tbl_proProductionPlan_Job();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proProductionPlan_JobSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionJob_ID"].Value = productionJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_proProductionPlan_Jobins = Maketbl_proProductionPlan_Job(dataReader);
				} else {
					tbl_proProductionPlan_Jobins = null;
				}
			}
			scon.Close();
			return tbl_proProductionPlan_Jobins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_proProductionPlan_Job table.
		/// </summary>
		public static List<tbl_proProductionPlan_Job> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proProductionPlan_JobSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_proProductionPlan_Job> tbl_proProductionPlan_JobList = new List<tbl_proProductionPlan_Job>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_proProductionPlan_Job tbl_proProductionPlan_Job = Maketbl_proProductionPlan_Job(dataReader);
					tbl_proProductionPlan_JobList.Add(tbl_proProductionPlan_Job);
				}
			}
			scon.Close();
			return tbl_proProductionPlan_JobList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_proProductionPlan_Job table by a foreign key.
		/// </summary>
		public static List<tbl_proProductionPlan_Job> SelectAllByProductionPlan_ID(string productionPlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_proProductionPlan_JobSelectAllByProductionPlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@productionPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@productionPlan_ID"].Value = productionPlan_ID;
				List<tbl_proProductionPlan_Job> tbl_proProductionPlan_JobList = new List<tbl_proProductionPlan_Job>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_proProductionPlan_Job tbl_proProductionPlan_Job = Maketbl_proProductionPlan_Job(dataReader);
					tbl_proProductionPlan_JobList.Add(tbl_proProductionPlan_Job);
				}
			}
			scon.Close();
			return tbl_proProductionPlan_JobList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_proProductionPlan_Job class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_proProductionPlan_Job Maketbl_proProductionPlan_Job(SqlDataReader dataReader) {
			tbl_proProductionPlan_Job tbl_proProductionPlan_Job = new tbl_proProductionPlan_Job();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_proProductionPlan_Job.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_proProductionPlan_Job.ProductionPlan_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_proProductionPlan_Job.ProductionJob_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_proProductionPlan_Job.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_proProductionPlan_Job.ItemSubCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_proProductionPlan_Job.ItemSubCategory2_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_proProductionPlan_Job.ItemSerialNo = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_proProductionPlan_Job.ItemSerialNo2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_proProductionPlan_Job.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_proProductionPlan_Job.Qty_Printed = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_proProductionPlan_Job.Qty_UnPrinted = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_proProductionPlan_Job.Qty_Confirmed = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_proProductionPlan_Job.Qty_Stock = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_proProductionPlan_Job.ProductionPlan_StartDate = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_proProductionPlan_Job.ProductionPlan_EndDate = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_proProductionPlan_Job.IsJobClosed = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_proProductionPlan_Job.DateJobClosed = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_proProductionPlan_Job.JobClosedUser_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_proProductionPlan_Job.IsJobSuspended = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_proProductionPlan_Job.DateJobSuspended = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_proProductionPlan_Job.JobSuspendedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_proProductionPlan_Job.IsJobWorkInProgress = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_proProductionPlan_Job.WorkInProgress_StartDate = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_proProductionPlan_Job.WorkInProgress_EndDate = dataReader.GetDateTime(23);
			}

			return tbl_proProductionPlan_Job;
		}
		/// <summary>
		/// This makes tbl_proProductionPlan_Job datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_proProductionPlan_Job object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_proProductionPlan_Job  tbl_proProductionPlan_Job   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_productionPlan_ID = new DataColumn("productionPlan_ID" , typeof(string));
			DataColumn col_productionJob_ID = new DataColumn("productionJob_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qty_Printed = new DataColumn("qty_Printed" , typeof(decimal));
			DataColumn col_qty_UnPrinted = new DataColumn("qty_UnPrinted" , typeof(decimal));
			DataColumn col_qty_Confirmed = new DataColumn("qty_Confirmed" , typeof(decimal));
			DataColumn col_qty_Stock = new DataColumn("qty_Stock" , typeof(decimal));
			DataColumn col_productionPlan_StartDate = new DataColumn("productionPlan_StartDate" , typeof(DateTime));
			DataColumn col_productionPlan_EndDate = new DataColumn("productionPlan_EndDate" , typeof(DateTime));
			DataColumn col_isJobClosed = new DataColumn("isJobClosed" , typeof(bool));
			DataColumn col_dateJobClosed = new DataColumn("dateJobClosed" , typeof(DateTime));
			DataColumn col_jobClosedUser_ID = new DataColumn("jobClosedUser_ID" , typeof(string));
			DataColumn col_isJobSuspended = new DataColumn("isJobSuspended" , typeof(bool));
			DataColumn col_dateJobSuspended = new DataColumn("dateJobSuspended" , typeof(DateTime));
			DataColumn col_jobSuspendedUser_ID = new DataColumn("jobSuspendedUser_ID" , typeof(string));
			DataColumn col_isJobWorkInProgress = new DataColumn("isJobWorkInProgress" , typeof(bool));
			DataColumn col_WorkInProgress_StartDate = new DataColumn("WorkInProgress_StartDate" , typeof(DateTime));
			DataColumn col_WorkInProgress_EndDate = new DataColumn("WorkInProgress_EndDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_productionPlan_ID,col_productionJob_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_qty_Printed,col_qty_UnPrinted,col_qty_Confirmed,col_qty_Stock,col_productionPlan_StartDate,col_productionPlan_EndDate,col_isJobClosed,col_dateJobClosed,col_jobClosedUser_ID,col_isJobSuspended,col_dateJobSuspended,col_jobSuspendedUser_ID,col_isJobWorkInProgress,col_WorkInProgress_StartDate,col_WorkInProgress_EndDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_proProductionPlan_Job datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_proProductionPlan_Job object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_proProductionPlan_Job user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["productionPlan_ID"] = user.productionPlan_ID;
			drow["productionJob_ID"] = user.productionJob_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty"] = user.qty;
			drow["qty_Printed"] = user.qty_Printed;
			drow["qty_UnPrinted"] = user.qty_UnPrinted;
			drow["qty_Confirmed"] = user.qty_Confirmed;
			drow["qty_Stock"] = user.qty_Stock;
			drow["productionPlan_StartDate"] = user.productionPlan_StartDate;
			drow["productionPlan_EndDate"] = user.productionPlan_EndDate;
			drow["isJobClosed"] = user.isJobClosed;
			drow["dateJobClosed"] = user.dateJobClosed;
			drow["jobClosedUser_ID"] = user.jobClosedUser_ID;
			drow["isJobSuspended"] = user.isJobSuspended;
			drow["dateJobSuspended"] = user.dateJobSuspended;
			drow["jobSuspendedUser_ID"] = user.jobSuspendedUser_ID;
			drow["isJobWorkInProgress"] = user.isJobWorkInProgress;
			drow["WorkInProgress_StartDate"] = user.WorkInProgress_StartDate;
			drow["WorkInProgress_EndDate"] = user.WorkInProgress_EndDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
