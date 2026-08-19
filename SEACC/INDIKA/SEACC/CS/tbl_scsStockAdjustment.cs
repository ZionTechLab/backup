using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsStockAdjustment {
		#region Fields
		private string stockAdjustment_ID;
		private DateTime stockAdjustmentDate;
		private string remark;
		private string department_ID;
		private string section_ID;
		private string store_ID;
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
		private int printCount;
		private string companyID;
		private string companyBranch_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsStockAdjustment class.
		/// </summary>
		public tbl_scsStockAdjustment() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsStockAdjustment class.
		/// </summary>
		public tbl_scsStockAdjustment(string stockAdjustment_ID, DateTime stockAdjustmentDate, string remark, string department_ID, string section_ID, string store_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, int printCount, string companyID, string companyBranch_ID) {
			this.stockAdjustment_ID = stockAdjustment_ID;
			this.stockAdjustmentDate = stockAdjustmentDate;
			this.remark = remark;
			this.department_ID = department_ID;
			this.section_ID = section_ID;
			this.store_ID = store_ID;
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
			this.printCount = printCount;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the StockAdjustment_ID value.
		/// </summary>
		public string StockAdjustment_ID {
			get { return stockAdjustment_ID; }
			set { stockAdjustment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StockAdjustmentDate value.
		/// </summary>
		public DateTime StockAdjustmentDate {
			get { return stockAdjustmentDate; }
			set { stockAdjustmentDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
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
		/// Gets or sets the PrintCount value.
		/// </summary>
		public int PrintCount {
			get { return printCount; }
			set { printCount = value; }
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
		/// Saves a record to the tbl_scsStockAdjustment table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@stockAdjustment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@stockAdjustmentDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@stockAdjustment_ID"].Value = stockAdjustment_ID;
			scom.Parameters["@stockAdjustmentDate"].Value = stockAdjustmentDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
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
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsStockAdjustment table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@stockAdjustment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@stockAdjustmentDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,500);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
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
			scom.Parameters.Add("@printCount", SqlDbType.Int,4);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@stockAdjustment_ID"].Value = stockAdjustment_ID;
			scom.Parameters["@stockAdjustmentDate"].Value = stockAdjustmentDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
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
			scom.Parameters["@printCount"].Value = printCount;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsStockAdjustment table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@stockAdjustment_ID", SqlDbType.VarChar,20);
			scom.Parameters["@stockAdjustment_ID"].Value = stockAdjustment_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment table by a foreign key.
		/// </summary>
		public static void DeleteAllByDepartment_ID(string department_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentDeleteAllByDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment table by a foreign key.
		/// </summary>
		public static void DeleteAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentDeleteAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsStockAdjustment table.
		/// </summary>
		public static tbl_scsStockAdjustment Select(string stockAdjustment_ID_Incoming){

			tbl_scsStockAdjustment tbl_scsStockAdjustmentins = new tbl_scsStockAdjustment();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@stockAdjustment_ID", SqlDbType.VarChar,20);
			scom.Parameters["@stockAdjustment_ID"].Value = stockAdjustment_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsStockAdjustmentins = Maketbl_scsStockAdjustment(dataReader);
				} else {
					tbl_scsStockAdjustmentins = null;
				}
			}
			scon.Close();
			return tbl_scsStockAdjustmentins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment table.
		/// </summary>
		public static List<tbl_scsStockAdjustment> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsStockAdjustment> tbl_scsStockAdjustmentList = new List<tbl_scsStockAdjustment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdjustment tbl_scsStockAdjustment = Maketbl_scsStockAdjustment(dataReader);
					tbl_scsStockAdjustmentList.Add(tbl_scsStockAdjustment);
				}
			}
			scon.Close();
			return tbl_scsStockAdjustmentList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment table by a foreign key.
		/// </summary>
		public static List<tbl_scsStockAdjustment> SelectAllByDepartment_ID(string department_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentSelectAllByDepartment_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,20);
			scom.Parameters["@department_ID"].Value = department_ID;
				List<tbl_scsStockAdjustment> tbl_scsStockAdjustmentList = new List<tbl_scsStockAdjustment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdjustment tbl_scsStockAdjustment = Maketbl_scsStockAdjustment(dataReader);
					tbl_scsStockAdjustmentList.Add(tbl_scsStockAdjustment);
				}
			}
			scon.Close();
			return tbl_scsStockAdjustmentList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment table by a foreign key.
		/// </summary>
		public static List<tbl_scsStockAdjustment> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_scsStockAdjustment> tbl_scsStockAdjustmentList = new List<tbl_scsStockAdjustment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdjustment tbl_scsStockAdjustment = Maketbl_scsStockAdjustment(dataReader);
					tbl_scsStockAdjustmentList.Add(tbl_scsStockAdjustment);
				}
			}
			scon.Close();
			return tbl_scsStockAdjustmentList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsStockAdjustment table by a foreign key.
		/// </summary>
		public static List<tbl_scsStockAdjustment> SelectAllBySection_ID(string section_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsStockAdjustmentSelectAllBySection_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_scsStockAdjustment> tbl_scsStockAdjustmentList = new List<tbl_scsStockAdjustment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsStockAdjustment tbl_scsStockAdjustment = Maketbl_scsStockAdjustment(dataReader);
					tbl_scsStockAdjustmentList.Add(tbl_scsStockAdjustment);
				}
			}
			scon.Close();
			return tbl_scsStockAdjustmentList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsStockAdjustment class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsStockAdjustment Maketbl_scsStockAdjustment(SqlDataReader dataReader) {
			tbl_scsStockAdjustment tbl_scsStockAdjustment = new tbl_scsStockAdjustment();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsStockAdjustment.StockAdjustment_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsStockAdjustment.StockAdjustmentDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsStockAdjustment.Remark = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsStockAdjustment.Department_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsStockAdjustment.Section_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsStockAdjustment.Store_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsStockAdjustment.CreateUser_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsStockAdjustment.ModifiedUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsStockAdjustment.CheckedUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsStockAdjustment.ApprovedUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsStockAdjustment.DateCreate = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsStockAdjustment.DateModified = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsStockAdjustment.DateChecked = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsStockAdjustment.DateApproved = dataReader.GetDateTime(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_scsStockAdjustment.IsChecked = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_scsStockAdjustment.IsApproved = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_scsStockAdjustment.IsFinished = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_scsStockAdjustment.IsDeleted = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_scsStockAdjustment.IsLocked = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_scsStockAdjustment.PrintCount = dataReader.GetInt32(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_scsStockAdjustment.CompanyID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_scsStockAdjustment.CompanyBranch_ID = dataReader.GetString(21);
			}

			return tbl_scsStockAdjustment;
		}
		/// <summary>
		/// This makes tbl_scsStockAdjustment datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsStockAdjustment object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsStockAdjustment  tbl_scsStockAdjustment   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_stockAdjustment_ID = new DataColumn("stockAdjustment_ID" , typeof(string));
			DataColumn col_stockAdjustmentDate = new DataColumn("stockAdjustmentDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
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
			DataColumn col_printCount = new DataColumn("printCount" , typeof(int));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_stockAdjustment_ID,col_stockAdjustmentDate,col_remark,col_department_ID,col_section_ID,col_store_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_printCount,col_companyID,col_companyBranch_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsStockAdjustment datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsStockAdjustment object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsStockAdjustment user) {
		DataRow drow = dt.NewRow();
		
			drow["stockAdjustment_ID"] = user.stockAdjustment_ID;
			drow["stockAdjustmentDate"] = user.stockAdjustmentDate;
			drow["remark"] = user.remark;
			drow["department_ID"] = user.department_ID;
			drow["section_ID"] = user.section_ID;
			drow["store_ID"] = user.store_ID;
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
			drow["printCount"] = user.printCount;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
