using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCustomerMaster_Branches {
		#region Fields
		private int line_No;
		private string customer_ID;
		private string branchName;
		private string address;
		private string telephone;
		private string fax;
		private string email;
		private int route_ID;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string checkedUser_ID;
		private string approvedUser_ID;
		private string deleteUser_ID;
		private string printUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deletedTerminal_ID;
		private string printTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateChecked;
		private DateTime dateApproved;
		private DateTime dateDeleted;
		private DateTime datePrinted;
		private bool isChecked;
		private bool isApproved;
		private bool isFinished;
		private bool isDeleted;
		private bool isLocked;
		private bool isBillltoHeadOffice;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerMaster_Branches class.
		/// </summary>
		public tbl_genCustomerMaster_Branches() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCustomerMaster_Branches class.
		/// </summary>
		public tbl_genCustomerMaster_Branches(int line_No, string customer_ID, string branchName, string address, string telephone, string fax, string email, int route_ID, string createUser_ID, string modifiedUser_ID, string checkedUser_ID, string approvedUser_ID, string deleteUser_ID, string printUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, string printTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateChecked, DateTime dateApproved, DateTime dateDeleted, DateTime datePrinted, bool isChecked, bool isApproved, bool isFinished, bool isDeleted, bool isLocked, bool isBillltoHeadOffice) {
			this.line_No = line_No;
			this.customer_ID = customer_ID;
			this.branchName = branchName;
			this.address = address;
			this.telephone = telephone;
			this.fax = fax;
			this.email = email;
			this.route_ID = route_ID;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.checkedUser_ID = checkedUser_ID;
			this.approvedUser_ID = approvedUser_ID;
			this.deleteUser_ID = deleteUser_ID;
			this.printUser_ID = printUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deletedTerminal_ID = deletedTerminal_ID;
			this.printTerminal_ID = printTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateChecked = dateChecked;
			this.dateApproved = dateApproved;
			this.dateDeleted = dateDeleted;
			this.datePrinted = datePrinted;
			this.isChecked = isChecked;
			this.isApproved = isApproved;
			this.isFinished = isFinished;
			this.isDeleted = isDeleted;
			this.isLocked = isLocked;
			this.isBillltoHeadOffice = isBillltoHeadOffice;
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
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BranchName value.
		/// </summary>
		public string BranchName {
			get { return branchName; }
			set { branchName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Address value.
		/// </summary>
		public string Address {
			get { return address; }
			set { address = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone value.
		/// </summary>
		public string Telephone {
			get { return telephone; }
			set { telephone = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fax value.
		/// </summary>
		public string Fax {
			get { return fax; }
			set { fax = value; }
		}
		
		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email {
			get { return email; }
			set { email = value; }
		}
		
		/// <summary>
		/// Gets or sets the Route_ID value.
		/// </summary>
		public int Route_ID {
			get { return route_ID; }
			set { route_ID = value; }
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
		/// Gets or sets the DeleteUser_ID value.
		/// </summary>
		public string DeleteUser_ID {
			get { return deleteUser_ID; }
			set { deleteUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintUser_ID value.
		/// </summary>
		public string PrintUser_ID {
			get { return printUser_ID; }
			set { printUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeletedTerminal_ID value.
		/// </summary>
		public string DeletedTerminal_ID {
			get { return deletedTerminal_ID; }
			set { deletedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrintTerminal_ID value.
		/// </summary>
		public string PrintTerminal_ID {
			get { return printTerminal_ID; }
			set { printTerminal_ID = value; }
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
		/// Gets or sets the DateDeleted value.
		/// </summary>
		public DateTime DateDeleted {
			get { return dateDeleted; }
			set { dateDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the DatePrinted value.
		/// </summary>
		public DateTime DatePrinted {
			get { return datePrinted; }
			set { datePrinted = value; }
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
		/// Gets or sets the IsBillltoHeadOffice value.
		/// </summary>
		public bool IsBillltoHeadOffice {
			get { return isBillltoHeadOffice; }
			set { isBillltoHeadOffice = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genCustomerMaster_Branches table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_BranchesInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branchName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@address", SqlDbType.VarChar,100);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deleteUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@printUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@PrintTerminal_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBillltoHeadOffice", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@branchName"].Value = branchName;
			scom.Parameters["@address"].Value = address;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@deleteUser_ID"].Value = deleteUser_ID;
			scom.Parameters["@printUser_ID"].Value = printUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@PrintTerminal_ID"].Value = printTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isBillltoHeadOffice"].Value = isBillltoHeadOffice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCustomerMaster_Branches table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_BranchesUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branchName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@address", SqlDbType.VarChar,100);
			scom.Parameters.Add("@telephone", SqlDbType.VarChar,50);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@email", SqlDbType.VarChar,50);
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@checkedUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@approvedUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deleteUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@printUser_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@PrintTerminal_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateChecked", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateApproved", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@datePrinted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isChecked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFinished", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBillltoHeadOffice", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@branchName"].Value = branchName;
			scom.Parameters["@address"].Value = address;
			scom.Parameters["@telephone"].Value = telephone;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@email"].Value = email;
			scom.Parameters["@route_ID"].Value = route_ID;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@checkedUser_ID"].Value = checkedUser_ID;
			scom.Parameters["@approvedUser_ID"].Value = approvedUser_ID;
			scom.Parameters["@deleteUser_ID"].Value = deleteUser_ID;
			scom.Parameters["@printUser_ID"].Value = printUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@PrintTerminal_ID"].Value = printTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateChecked"].Value = dateChecked;
			scom.Parameters["@dateApproved"].Value = dateApproved;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@datePrinted"].Value = datePrinted;
			scom.Parameters["@isChecked"].Value = isChecked;
			scom.Parameters["@isApproved"].Value = isApproved;
			scom.Parameters["@isFinished"].Value = isFinished;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isLocked"].Value = isLocked;
			scom.Parameters["@isBillltoHeadOffice"].Value = isBillltoHeadOffice;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCustomerMaster_Branches table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_BranchesDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scom.Parameters["@line_No"].Value = line_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Branches table by a foreign key.
		/// </summary>
		public static void DeleteAllByRoute_ID(int route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_BranchesDeleteAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Branches table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_BranchesDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCustomerMaster_Branches table.
		/// </summary>
		public static tbl_genCustomerMaster_Branches Select(string customer_ID_Incoming, int line_No_Incoming){

			tbl_genCustomerMaster_Branches tbl_genCustomerMaster_Branchesins = new tbl_genCustomerMaster_Branches();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_BranchesSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCustomerMaster_Branchesins = Maketbl_genCustomerMaster_Branches(dataReader);
				} else {
					tbl_genCustomerMaster_Branchesins = null;
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_Branchesins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Branches table.
		/// </summary>
		public static List<tbl_genCustomerMaster_Branches> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_BranchesSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCustomerMaster_Branches> tbl_genCustomerMaster_BranchesList = new List<tbl_genCustomerMaster_Branches>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerMaster_Branches tbl_genCustomerMaster_Branches = Maketbl_genCustomerMaster_Branches(dataReader);
					tbl_genCustomerMaster_BranchesList.Add(tbl_genCustomerMaster_Branches);
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_BranchesList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Branches table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerMaster_Branches> SelectAllByRoute_ID(int route_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_BranchesSelectAllByRoute_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@route_ID", SqlDbType.Int,4);
			scom.Parameters["@route_ID"].Value = route_ID;
				List<tbl_genCustomerMaster_Branches> tbl_genCustomerMaster_BranchesList = new List<tbl_genCustomerMaster_Branches>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerMaster_Branches tbl_genCustomerMaster_Branches = Maketbl_genCustomerMaster_Branches(dataReader);
					tbl_genCustomerMaster_BranchesList.Add(tbl_genCustomerMaster_Branches);
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_BranchesList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCustomerMaster_Branches table by a foreign key.
		/// </summary>
		public static List<tbl_genCustomerMaster_Branches> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCustomerMaster_BranchesSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_genCustomerMaster_Branches> tbl_genCustomerMaster_BranchesList = new List<tbl_genCustomerMaster_Branches>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCustomerMaster_Branches tbl_genCustomerMaster_Branches = Maketbl_genCustomerMaster_Branches(dataReader);
					tbl_genCustomerMaster_BranchesList.Add(tbl_genCustomerMaster_Branches);
				}
			}
			scon.Close();
			return tbl_genCustomerMaster_BranchesList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCustomerMaster_Branches class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCustomerMaster_Branches Maketbl_genCustomerMaster_Branches(SqlDataReader dataReader) {
			tbl_genCustomerMaster_Branches tbl_genCustomerMaster_Branches = new tbl_genCustomerMaster_Branches();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCustomerMaster_Branches.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCustomerMaster_Branches.Customer_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCustomerMaster_Branches.BranchName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genCustomerMaster_Branches.Address = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genCustomerMaster_Branches.Telephone = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genCustomerMaster_Branches.Fax = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genCustomerMaster_Branches.Email = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genCustomerMaster_Branches.Route_ID = dataReader.GetInt32(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genCustomerMaster_Branches.CreateUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genCustomerMaster_Branches.ModifiedUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genCustomerMaster_Branches.CheckedUser_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genCustomerMaster_Branches.ApprovedUser_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genCustomerMaster_Branches.DeleteUser_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genCustomerMaster_Branches.PrintUser_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genCustomerMaster_Branches.CreateTerminal_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genCustomerMaster_Branches.ModifiedTerminal_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genCustomerMaster_Branches.DeletedTerminal_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genCustomerMaster_Branches.PrintTerminal_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genCustomerMaster_Branches.DateCreate = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genCustomerMaster_Branches.DateModified = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genCustomerMaster_Branches.DateChecked = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genCustomerMaster_Branches.DateApproved = dataReader.GetDateTime(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genCustomerMaster_Branches.DateDeleted = dataReader.GetDateTime(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genCustomerMaster_Branches.DatePrinted = dataReader.GetDateTime(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genCustomerMaster_Branches.IsChecked = dataReader.GetBoolean(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_genCustomerMaster_Branches.IsApproved = dataReader.GetBoolean(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_genCustomerMaster_Branches.IsFinished = dataReader.GetBoolean(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_genCustomerMaster_Branches.IsDeleted = dataReader.GetBoolean(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_genCustomerMaster_Branches.IsLocked = dataReader.GetBoolean(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_genCustomerMaster_Branches.IsBillltoHeadOffice = dataReader.GetBoolean(29);
			}

			return tbl_genCustomerMaster_Branches;
		}
		/// <summary>
		/// This makes tbl_genCustomerMaster_Branches datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCustomerMaster_Branches object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCustomerMaster_Branches  tbl_genCustomerMaster_Branches   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_branchName = new DataColumn("branchName" , typeof(string));
			DataColumn col_address = new DataColumn("address" , typeof(string));
			DataColumn col_telephone = new DataColumn("telephone" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_email = new DataColumn("email" , typeof(string));
			DataColumn col_route_ID = new DataColumn("route_ID" , typeof(int));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_checkedUser_ID = new DataColumn("checkedUser_ID" , typeof(string));
			DataColumn col_approvedUser_ID = new DataColumn("approvedUser_ID" , typeof(string));
			DataColumn col_deleteUser_ID = new DataColumn("deleteUser_ID" , typeof(string));
			DataColumn col_printUser_ID = new DataColumn("printUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID" , typeof(string));
			DataColumn col_PrintTerminal_ID = new DataColumn("PrintTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateChecked = new DataColumn("dateChecked" , typeof(DateTime));
			DataColumn col_dateApproved = new DataColumn("dateApproved" , typeof(DateTime));
			DataColumn col_dateDeleted = new DataColumn("dateDeleted" , typeof(DateTime));
			DataColumn col_datePrinted = new DataColumn("datePrinted" , typeof(DateTime));
			DataColumn col_isChecked = new DataColumn("isChecked" , typeof(bool));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
			DataColumn col_isFinished = new DataColumn("isFinished" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
			DataColumn col_isBillltoHeadOffice = new DataColumn("isBillltoHeadOffice" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_customer_ID,col_branchName,col_address,col_telephone,col_fax,col_email,col_route_ID,col_createUser_ID,col_modifiedUser_ID,col_checkedUser_ID,col_approvedUser_ID,col_deleteUser_ID,col_printUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_PrintTerminal_ID,col_dateCreate,col_dateModified,col_dateChecked,col_dateApproved,col_dateDeleted,col_datePrinted,col_isChecked,col_isApproved,col_isFinished,col_isDeleted,col_isLocked,col_isBillltoHeadOffice,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCustomerMaster_Branches datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCustomerMaster_Branches object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCustomerMaster_Branches user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["customer_ID"] = user.customer_ID;
			drow["branchName"] = user.branchName;
			drow["address"] = user.address;
			drow["telephone"] = user.telephone;
			drow["fax"] = user.fax;
			drow["email"] = user.email;
			drow["route_ID"] = user.route_ID;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["checkedUser_ID"] = user.checkedUser_ID;
			drow["approvedUser_ID"] = user.approvedUser_ID;
			drow["deleteUser_ID"] = user.deleteUser_ID;
			drow["printUser_ID"] = user.printUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
			drow["PrintTerminal_ID"] = user.PrintTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateChecked"] = user.dateChecked;
			drow["dateApproved"] = user.dateApproved;
			drow["dateDeleted"] = user.dateDeleted;
			drow["datePrinted"] = user.datePrinted;
			drow["isChecked"] = user.isChecked;
			drow["isApproved"] = user.isApproved;
			drow["isFinished"] = user.isFinished;
			drow["isDeleted"] = user.isDeleted;
			drow["isLocked"] = user.isLocked;
			drow["isBillltoHeadOffice"] = user.isBillltoHeadOffice;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
