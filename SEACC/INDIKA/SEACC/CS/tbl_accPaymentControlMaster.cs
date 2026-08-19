using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accPaymentControlMaster {
		#region Fields
		private string user_ID;
		private string location;
		private decimal perVoucher;
		private decimal perDay;
		private decimal perWeek;
		private decimal perMonth;
		private decimal perQuarter;
		private decimal perAnnum;
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
		/// Initializes a new instance of the tbl_accPaymentControlMaster class.
		/// </summary>
		public tbl_accPaymentControlMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accPaymentControlMaster class.
		/// </summary>
		public tbl_accPaymentControlMaster(string user_ID, string location, decimal perVoucher, decimal perDay, decimal perWeek, decimal perMonth, decimal perQuarter, decimal perAnnum, string createUser_ID, string createTerminal_ID, string modifiedUser_ID, string modifiedTerminal_ID, string checkedUser_ID, string checkedTerminal_ID, string approvedUser_ID, string approvedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked) {
			this.user_ID = user_ID;
			this.location = location;
			this.perVoucher = perVoucher;
			this.perDay = perDay;
			this.perWeek = perWeek;
			this.perMonth = perMonth;
			this.perQuarter = perQuarter;
			this.perAnnum = perAnnum;
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
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Location value.
		/// </summary>
		public string Location {
			get { return location; }
			set { location = value; }
		}
		
		/// <summary>
		/// Gets or sets the PerVoucher value.
		/// </summary>
		public decimal PerVoucher {
			get { return perVoucher; }
			set { perVoucher = value; }
		}
		
		/// <summary>
		/// Gets or sets the PerDay value.
		/// </summary>
		public decimal PerDay {
			get { return perDay; }
			set { perDay = value; }
		}
		
		/// <summary>
		/// Gets or sets the PerWeek value.
		/// </summary>
		public decimal PerWeek {
			get { return perWeek; }
			set { perWeek = value; }
		}
		
		/// <summary>
		/// Gets or sets the PerMonth value.
		/// </summary>
		public decimal PerMonth {
			get { return perMonth; }
			set { perMonth = value; }
		}
		
		/// <summary>
		/// Gets or sets the PerQuarter value.
		/// </summary>
		public decimal PerQuarter {
			get { return perQuarter; }
			set { perQuarter = value; }
		}
		
		/// <summary>
		/// Gets or sets the PerAnnum value.
		/// </summary>
		public decimal PerAnnum {
			get { return perAnnum; }
			set { perAnnum = value; }
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
		/// Saves a record to the tbl_accPaymentControlMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentControlMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@location", SqlDbType.VarChar,20);
			scom.Parameters.Add("@perVoucher", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PerDay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PerWeek", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PerMonth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PerQuarter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PerAnnum", SqlDbType.Decimal,9);
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
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@location"].Value = location;
			scom.Parameters["@perVoucher"].Value = perVoucher;
			scom.Parameters["@PerDay"].Value = perDay;
			scom.Parameters["@PerWeek"].Value = perWeek;
			scom.Parameters["@PerMonth"].Value = perMonth;
			scom.Parameters["@PerQuarter"].Value = perQuarter;
			scom.Parameters["@PerAnnum"].Value = perAnnum;
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
		/// Updates a record in the tbl_accPaymentControlMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentControlMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@location", SqlDbType.VarChar,20);
			scom.Parameters.Add("@perVoucher", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PerDay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PerWeek", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PerMonth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PerQuarter", SqlDbType.Decimal,9);
			scom.Parameters.Add("@PerAnnum", SqlDbType.Decimal,9);
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
 
 
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@location"].Value = location;
			scom.Parameters["@perVoucher"].Value = perVoucher;
			scom.Parameters["@PerDay"].Value = perDay;
			scom.Parameters["@PerWeek"].Value = perWeek;
			scom.Parameters["@PerMonth"].Value = perMonth;
			scom.Parameters["@PerQuarter"].Value = perQuarter;
			scom.Parameters["@PerAnnum"].Value = perAnnum;
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
		/// Deletes a record from the tbl_accPaymentControlMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentControlMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentControlMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentControlMasterDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accPaymentControlMaster table.
		/// </summary>
		public static tbl_accPaymentControlMaster Select(string user_ID_Incoming){

			tbl_accPaymentControlMaster tbl_accPaymentControlMasterins = new tbl_accPaymentControlMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentControlMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accPaymentControlMasterins = Maketbl_accPaymentControlMaster(dataReader);
				} else {
					tbl_accPaymentControlMasterins = null;
				}
			}
			scon.Close();
			return tbl_accPaymentControlMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentControlMaster table.
		/// </summary>
		public static List<tbl_accPaymentControlMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentControlMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accPaymentControlMaster> tbl_accPaymentControlMasterList = new List<tbl_accPaymentControlMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentControlMaster tbl_accPaymentControlMaster = Maketbl_accPaymentControlMaster(dataReader);
					tbl_accPaymentControlMasterList.Add(tbl_accPaymentControlMaster);
				}
			}
			scon.Close();
			return tbl_accPaymentControlMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentControlMaster table by a foreign key.
		/// </summary>
		public static List<tbl_accPaymentControlMaster> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentControlMasterSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_accPaymentControlMaster> tbl_accPaymentControlMasterList = new List<tbl_accPaymentControlMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentControlMaster tbl_accPaymentControlMaster = Maketbl_accPaymentControlMaster(dataReader);
					tbl_accPaymentControlMasterList.Add(tbl_accPaymentControlMaster);
				}
			}
			scon.Close();
			return tbl_accPaymentControlMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accPaymentControlMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accPaymentControlMaster Maketbl_accPaymentControlMaster(SqlDataReader dataReader) {
			tbl_accPaymentControlMaster tbl_accPaymentControlMaster = new tbl_accPaymentControlMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accPaymentControlMaster.User_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accPaymentControlMaster.Location = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accPaymentControlMaster.PerVoucher = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accPaymentControlMaster.PerDay = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accPaymentControlMaster.PerWeek = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accPaymentControlMaster.PerMonth = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accPaymentControlMaster.PerQuarter = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accPaymentControlMaster.PerAnnum = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accPaymentControlMaster.CreateUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accPaymentControlMaster.CreateTerminal_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accPaymentControlMaster.ModifiedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accPaymentControlMaster.ModifiedTerminal_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accPaymentControlMaster.CheckedUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_accPaymentControlMaster.CheckedTerminal_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_accPaymentControlMaster.ApprovedUser_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_accPaymentControlMaster.ApprovedTerminal_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_accPaymentControlMaster.DateCreate = dataReader.GetDateTime(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_accPaymentControlMaster.DateModified = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_accPaymentControlMaster.DateChecked = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_accPaymentControlMaster.DateApproved = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_accPaymentControlMaster.IsChecked = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_accPaymentControlMaster.IsApproved = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_accPaymentControlMaster.IsFinished = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_accPaymentControlMaster.IsDeleted = dataReader.GetBoolean(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_accPaymentControlMaster.IsLocked = dataReader.GetBoolean(24);
			}

			return tbl_accPaymentControlMaster;
		}
		/// <summary>
		/// This makes tbl_accPaymentControlMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accPaymentControlMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accPaymentControlMaster  tbl_accPaymentControlMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_location = new DataColumn("location" , typeof(string));
			DataColumn col_perVoucher = new DataColumn("perVoucher" , typeof(decimal));
			DataColumn col_PerDay = new DataColumn("PerDay" , typeof(decimal));
			DataColumn col_PerWeek = new DataColumn("PerWeek" , typeof(decimal));
			DataColumn col_PerMonth = new DataColumn("PerMonth" , typeof(decimal));
			DataColumn col_PerQuarter = new DataColumn("PerQuarter" , typeof(decimal));
			DataColumn col_PerAnnum = new DataColumn("PerAnnum" , typeof(decimal));
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
		dt.Columns.AddRange(new DataColumn[] { col_user_ID,col_location,col_perVoucher,col_PerDay,col_PerWeek,col_PerMonth,col_PerQuarter,col_PerAnnum,col_createUser_ID,col_createTerminal_ID,col_modifiedUser_ID,col_modifiedTerminal_ID,col_checkedUser_ID,col_checkedTerminal_ID,col_approvedUser_ID,col_approvedTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accPaymentControlMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accPaymentControlMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accPaymentControlMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["user_ID"] = user.user_ID;
			drow["location"] = user.location;
			drow["perVoucher"] = user.perVoucher;
			drow["PerDay"] = user.PerDay;
			drow["PerWeek"] = user.PerWeek;
			drow["PerMonth"] = user.PerMonth;
			drow["PerQuarter"] = user.PerQuarter;
			drow["PerAnnum"] = user.PerAnnum;
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
