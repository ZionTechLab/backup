using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accReceipt {
		#region Fields
		private string receipt_ID;
		private DateTime dateReceipt;
		private string remark;
		private string drRevenueCode1;
		private string drRevenueCode2;
		private string shortNarration;
		private string narration;
		private bool isCash;
		private bool isCheque;
		private decimal totalAmount;
		private int printCount;
		private string gl_ID;
		private string revenueCostProject_ID;
		private string location_ID;
		private string createUser_ID;
		private string createTerminal_ID;
		private string modifiedUser_ID;
		private string modifiedTerminal_ID;
		private string checkedUser_ID;
		private string checkedTerminal_ID;
		private string approvedUser_ID;
		private string approvedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accReceipt class.
		/// </summary>
		public tbl_accReceipt() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accReceipt class.
		/// </summary>
		public tbl_accReceipt(string receipt_ID, DateTime dateReceipt, string remark, string drRevenueCode1, string drRevenueCode2, string shortNarration, string narration, bool isCash, bool isCheque, decimal totalAmount, int printCount, string gl_ID, string revenueCostProject_ID, string location_ID, string createUser_ID, string createTerminal_ID, string modifiedUser_ID, string modifiedTerminal_ID, string checkedUser_ID, string checkedTerminal_ID, string approvedUser_ID, string approvedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked) {
			this.receipt_ID = receipt_ID;
			this.dateReceipt = dateReceipt;
			this.remark = remark;
			this.drRevenueCode1 = drRevenueCode1;
			this.drRevenueCode2 = drRevenueCode2;
			this.shortNarration = shortNarration;
			this.narration = narration;
			this.isCash = isCash;
			this.isCheque = isCheque;
			this.totalAmount = totalAmount;
			this.printCount = printCount;
			this.gl_ID = gl_ID;
			this.revenueCostProject_ID = revenueCostProject_ID;
			this.location_ID = location_ID;
			this.createUser_ID = createUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.checkedTerminal_ID = checkedTerminal_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.approvedTerminal_ID = approvedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Receipt_ID value.
		/// </summary>
		public string Receipt_ID {
			get { return receipt_ID; }
			set { receipt_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateReceipt value.
		/// </summary>
		public DateTime DateReceipt {
			get { return dateReceipt; }
			set { dateReceipt = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the DrRevenueCode1 value.
		/// </summary>
		public string DrRevenueCode1 {
			get { return drRevenueCode1; }
			set { drRevenueCode1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the DrRevenueCode2 value.
		/// </summary>
		public string DrRevenueCode2 {
			get { return drRevenueCode2; }
			set { drRevenueCode2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ShortNarration value.
		/// </summary>
		public string ShortNarration {
			get { return shortNarration; }
			set { shortNarration = value; }
		}
		
		/// <summary>
		/// Gets or sets the Narration value.
		/// </summary>
		public string Narration {
			get { return narration; }
			set { narration = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCash value.
		/// </summary>
		public bool IsCash {
			get { return isCash; }
			set { isCash = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCheque value.
		/// </summary>
		public bool IsCheque {
			get { return isCheque; }
			set { isCheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RevenueCostProject_ID value.
		/// </summary>
		public string RevenueCostProject_ID {
			get { return revenueCostProject_ID; }
			set { revenueCostProject_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Location_ID value.
		/// </summary>
		public string Location_ID {
			get { return location_ID; }
			set { location_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedUser_ID value.
		/// </summary>
		public string CheckedUser_ID {
			get { return checkedUser_ID; }
			set { checkedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CheckedTerminal_ID value.
		/// </summary>
		public string CheckedTerminal_ID {
			get { return checkedTerminal_ID; }
			set { checkedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedUser_ID value.
		/// </summary>
		public string ApprovedUser_ID {
			get { return approvedUser_ID; }
			set { approvedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ApprovedTerminal_ID value.
		/// </summary>
		public string ApprovedTerminal_ID {
			get { return approvedTerminal_ID; }
			set { approvedTerminal_ID = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accReceipt table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateReceipt", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,250);
			scom.Parameters.Add("@drRevenueCode1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@drRevenueCode2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shortNarration", SqlDbType.VarChar,200);
			scom.Parameters.Add("@narration", SqlDbType.VarChar,250);
			scom.Parameters.Add("@isCash", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCheque", SqlDbType.Bit,1);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@revenueCostProject_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@location_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@dateReceipt"].Value = dateReceipt;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@drRevenueCode1"].Value = drRevenueCode1;
			scom.Parameters["@drRevenueCode2"].Value = drRevenueCode2;
			scom.Parameters["@shortNarration"].Value = shortNarration;
			scom.Parameters["@narration"].Value = narration;
			scom.Parameters["@isCash"].Value = isCash;
			scom.Parameters["@isCheque"].Value = isCheque;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@revenueCostProject_ID"].Value = revenueCostProject_ID;
			scom.Parameters["@location_ID"].Value = location_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accReceipt table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateReceipt", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,250);
			scom.Parameters.Add("@drRevenueCode1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@drRevenueCode2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@shortNarration", SqlDbType.VarChar,200);
			scom.Parameters.Add("@narration", SqlDbType.VarChar,250);
			scom.Parameters.Add("@isCash", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCheque", SqlDbType.Bit,1);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@revenueCostProject_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@location_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@checkedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@approvedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
 
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
			scom.Parameters["@dateReceipt"].Value = dateReceipt;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@drRevenueCode1"].Value = drRevenueCode1;
			scom.Parameters["@drRevenueCode2"].Value = drRevenueCode2;
			scom.Parameters["@shortNarration"].Value = shortNarration;
			scom.Parameters["@narration"].Value = narration;
			scom.Parameters["@isCash"].Value = isCash;
			scom.Parameters["@isCheque"].Value = isCheque;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@revenueCostProject_ID"].Value = revenueCostProject_ID;
			scom.Parameters["@location_ID"].Value = location_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@checkedTerminal_ID"].Value = checkedTerminal_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@approvedTerminal_ID"].Value = approvedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accReceipt table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByRevenueCostProject_ID(string revenueCostProject_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptDeleteAllByRevenueCostProject_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@revenueCostProject_ID", SqlDbType.VarChar,20);
			scom.Parameters["@revenueCostProject_ID"].Value = revenueCostProject_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceipt table by a foreign key.
		/// </summary>
		public static void DeleteAllByLocation_ID(string location_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptDeleteAllByLocation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@location_ID", SqlDbType.VarChar,10);
			scom.Parameters["@location_ID"].Value = location_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accReceipt table.
		/// </summary>
		public static tbl_accReceipt Select(string receipt_ID_Incoming){

			tbl_accReceipt tbl_accReceiptins = new tbl_accReceipt();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@receipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@receipt_ID"].Value = receipt_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accReceiptins = Maketbl_accReceipt(dataReader);
				} else {
					tbl_accReceiptins = null;
				}
			}
			scon.Close();
			return tbl_accReceiptins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceipt table.
		/// </summary>
		public static List<tbl_accReceipt> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accReceipt> tbl_accReceiptList = new List<tbl_accReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceipt tbl_accReceipt = Maketbl_accReceipt(dataReader);
					tbl_accReceiptList.Add(tbl_accReceipt);
				}
			}
			scon.Close();
			return tbl_accReceiptList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceipt table by a foreign key.
		/// </summary>
		public static List<tbl_accReceipt> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accReceipt> tbl_accReceiptList = new List<tbl_accReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceipt tbl_accReceipt = Maketbl_accReceipt(dataReader);
					tbl_accReceiptList.Add(tbl_accReceipt);
				}
			}
			scon.Close();
			return tbl_accReceiptList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceipt table by a foreign key.
		/// </summary>
		public static List<tbl_accReceipt> SelectAllByRevenueCostProject_ID(string revenueCostProject_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptSelectAllByRevenueCostProject_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@revenueCostProject_ID", SqlDbType.VarChar,20);
			scom.Parameters["@revenueCostProject_ID"].Value = revenueCostProject_ID;
				List<tbl_accReceipt> tbl_accReceiptList = new List<tbl_accReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceipt tbl_accReceipt = Maketbl_accReceipt(dataReader);
					tbl_accReceiptList.Add(tbl_accReceipt);
				}
			}
			scon.Close();
			return tbl_accReceiptList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accReceipt table by a foreign key.
		/// </summary>
		public static List<tbl_accReceipt> SelectAllByLocation_ID(string location_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accReceiptSelectAllByLocation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@location_ID", SqlDbType.VarChar,10);
			scom.Parameters["@location_ID"].Value = location_ID;
				List<tbl_accReceipt> tbl_accReceiptList = new List<tbl_accReceipt>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accReceipt tbl_accReceipt = Maketbl_accReceipt(dataReader);
					tbl_accReceiptList.Add(tbl_accReceipt);
				}
			}
			scon.Close();
			return tbl_accReceiptList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accReceipt class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accReceipt Maketbl_accReceipt(SqlDataReader dataReader) {
			tbl_accReceipt tbl_accReceipt = new tbl_accReceipt();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accReceipt.Receipt_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accReceipt.DateReceipt = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accReceipt.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accReceipt.DrRevenueCode1 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accReceipt.DrRevenueCode2 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accReceipt.ShortNarration = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accReceipt.Narration = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accReceipt.IsCash = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accReceipt.IsCheque = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accReceipt.TotalAmount = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accReceipt.PrintCount = dataReader.GetInt32(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accReceipt.Gl_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accReceipt.RevenueCostProject_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_accReceipt.Location_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_accReceipt.CreateUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_accReceipt.CreateTerminal_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_accReceipt.ModifiedUser_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_accReceipt.ModifiedTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_accReceipt.CheckedUser_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_accReceipt.CheckedTerminal_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_accReceipt.ApprovedUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_accReceipt.ApprovedTerminal_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_accReceipt.DateCreate = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_accReceipt.DateModified = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_accReceipt.DateChecked = dataReader.GetDateTime(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_accReceipt.DateApproved = dataReader.GetDateTime(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_accReceipt.IsChecked = dataReader.GetBoolean(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_accReceipt.IsApproved = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_accReceipt.IsFinished = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_accReceipt.IsDeleted = dataReader.GetBoolean(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_accReceipt.IsLocked = dataReader.GetBoolean(30);
			}

			return tbl_accReceipt;
		}
		/// <summary>
		/// This makes tbl_accReceipt datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accReceipt object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accReceipt  tbl_accReceipt   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_receipt_ID = new DataColumn("receipt_ID" , typeof(string));
			DataColumn col_dateReceipt = new DataColumn("dateReceipt" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_drRevenueCode1 = new DataColumn("drRevenueCode1" , typeof(string));
			DataColumn col_drRevenueCode2 = new DataColumn("drRevenueCode2" , typeof(string));
			DataColumn col_shortNarration = new DataColumn("shortNarration" , typeof(string));
			DataColumn col_narration = new DataColumn("narration" , typeof(string));
			DataColumn col_isCash = new DataColumn("isCash" , typeof(bool));
			DataColumn col_isCheque = new DataColumn("isCheque" , typeof(bool));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_revenueCostProject_ID = new DataColumn("revenueCostProject_ID" , typeof(string));
			DataColumn col_location_ID = new DataColumn("location_ID" , typeof(string));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_checkedTerminal_ID = new DataColumn("checkedTerminal_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_approvedTerminal_ID = new DataColumn("approvedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_receipt_ID,col_dateReceipt,col_remark,col_drRevenueCode1,col_drRevenueCode2,col_shortNarration,col_narration,col_isCash,col_isCheque,col_totalAmount,col_printCount,col_gl_ID,col_revenueCostProject_ID,col_location_ID,col_createUser_ID,col_createTerminal_ID,col_modifiedUser_ID,col_modifiedTerminal_ID,col_checkedUser_ID,col_checkedTerminal_ID,col_approvedUser_ID,col_approvedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accReceipt datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accReceipt object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accReceipt user) {
		DataRow drow = dt.NewRow();
		
			drow["receipt_ID"] = user.receipt_ID;
			drow["dateReceipt"] = user.dateReceipt;
			drow["remark"] = user.remark;
			drow["drRevenueCode1"] = user.drRevenueCode1;
			drow["drRevenueCode2"] = user.drRevenueCode2;
			drow["shortNarration"] = user.shortNarration;
			drow["narration"] = user.narration;
			drow["isCash"] = user.isCash;
			drow["isCheque"] = user.isCheque;
			drow["totalAmount"] = user.totalAmount;
			drow["printCount"] = user.printCount;
			drow["gl_ID"] = user.gl_ID;
			drow["revenueCostProject_ID"] = user.revenueCostProject_ID;
			drow["location_ID"] = user.location_ID;
			drow["createUser_ID"] = user.createUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["checkedTerminal_ID"] = user.checkedTerminal_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["approvedTerminal_ID"] = user.approvedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
