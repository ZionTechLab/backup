using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMasDivision {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string division_ID;
		private string divisionName;
		private string address;
		private string telephone1;
		private string telephone2;
		private string extention;
		private string fax;
		private string employeeID_HoDiv;
		private string remarks;
		private string reg_ID;
		private bool isCanceled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genMasDivision class.
		/// </summary>
		public tbl_genMasDivision() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMasDivision class.
		/// </summary>
		public tbl_genMasDivision(string company_ID, string companyBranch_ID, string division_ID, string divisionName, string address, string telephone1, string telephone2, string extention, string fax, string employeeID_HoDiv, string remarks, string reg_ID, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.division_ID = division_ID;
			this.divisionName = divisionName;
			this.address = address;
			this.telephone1 = telephone1;
			this.telephone2 = telephone2;
			this.extention = extention;
			this.fax = fax;
			this.employeeID_HoDiv = employeeID_HoDiv;
			this.remarks = remarks;
			this.reg_ID = reg_ID;
			this.isCanceled = isCanceled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Company_ID value.
		/// </summary>
		public string Company_ID {
			get { return company_ID; }
			set { company_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Division_ID value.
		/// </summary>
		public string Division_ID {
			get { return division_ID; }
			set { division_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivisionName value.
		/// </summary>
		public string DivisionName {
			get { return divisionName; }
			set { divisionName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Address value.
		/// </summary>
		public string Address {
			get { return address; }
			set { address = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone1 value.
		/// </summary>
		public string Telephone1 {
			get { return telephone1; }
			set { telephone1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Telephone2 value.
		/// </summary>
		public string Telephone2 {
			get { return telephone2; }
			set { telephone2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Extention value.
		/// </summary>
		public string Extention {
			get { return extention; }
			set { extention = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fax value.
		/// </summary>
		public string Fax {
			get { return fax; }
			set { fax = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmployeeID_HoDiv value.
		/// </summary>
		public string EmployeeID_HoDiv {
			get { return employeeID_HoDiv; }
			set { employeeID_HoDiv = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Reg_ID value.
		/// </summary>
		public string Reg_ID {
			get { return reg_ID; }
			set { reg_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Modified value.
		/// </summary>
		public string UserID_Modified {
			get { return userID_Modified; }
			set { userID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Canceled value.
		/// </summary>
		public string UserID_Canceled {
			get { return userID_Canceled; }
			set { userID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Modified value.
		/// </summary>
		public string TerminalID_Modified {
			get { return terminalID_Modified; }
			set { terminalID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Canceled value.
		/// </summary>
		public string TerminalID_Canceled {
			get { return terminalID_Canceled; }
			set { terminalID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Modified value.
		/// </summary>
		public DateTime Date_Modified {
			get { return date_Modified; }
			set { date_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Canceled value.
		/// </summary>
		public DateTime Date_Canceled {
			get { return date_Canceled; }
			set { date_Canceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genMasDivision table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDivisionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@divisionName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@address", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@telephone2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@extention", SqlDbType.VarChar,5);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employeeID_HoDiv", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@reg_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@divisionName"].Value = divisionName;
			scom.Parameters["@address"].Value = address;
			scom.Parameters["@telephone1"].Value = telephone1;
			scom.Parameters["@telephone2"].Value = telephone2;
			scom.Parameters["@extention"].Value = extention;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@employeeID_HoDiv"].Value = employeeID_HoDiv;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@reg_ID"].Value = reg_ID;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genMasDivision table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDivisionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@divisionName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@address", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@telephone2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@extention", SqlDbType.VarChar,5);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employeeID_HoDiv", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
			scom.Parameters.Add("@reg_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@divisionName"].Value = divisionName;
			scom.Parameters["@address"].Value = address;
			scom.Parameters["@telephone1"].Value = telephone1;
			scom.Parameters["@telephone2"].Value = telephone2;
			scom.Parameters["@extention"].Value = extention;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@employeeID_HoDiv"].Value = employeeID_HoDiv;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@reg_ID"].Value = reg_ID;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genMasDivision table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDivisionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@division_ID"].Value = division_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasDivision table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Reg_ID(string company_ID, string companyBranch_ID, string reg_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDivisionDeleteAllByCompany_ID_CompanyBranch_ID_Reg_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reg_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@reg_ID"].Value = reg_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMasDivision table.
		/// </summary>
		public static tbl_genMasDivision Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string division_ID_Incoming){

			tbl_genMasDivision tbl_genMasDivisionins = new tbl_genMasDivision();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDivisionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@division_ID"].Value = division_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMasDivisionins = Maketbl_genMasDivision(dataReader);
				} else {
					tbl_genMasDivisionins = null;
				}
			}
			scon.Close();
			return tbl_genMasDivisionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasDivision table.
		/// </summary>
		public static List<tbl_genMasDivision> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDivisionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMasDivision> tbl_genMasDivisionList = new List<tbl_genMasDivision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasDivision tbl_genMasDivision = Maketbl_genMasDivision(dataReader);
					tbl_genMasDivisionList.Add(tbl_genMasDivision);
				}
			}
			scon.Close();
			return tbl_genMasDivisionList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasDivision table by a foreign key.
		/// </summary>
		public static List<tbl_genMasDivision> SelectAllByCompany_ID_CompanyBranch_ID_Reg_ID(string company_ID, string companyBranch_ID, string reg_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDivisionSelectAllByCompany_ID_CompanyBranch_ID_Reg_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@reg_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@reg_ID"].Value = reg_ID;
				List<tbl_genMasDivision> tbl_genMasDivisionList = new List<tbl_genMasDivision>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasDivision tbl_genMasDivision = Maketbl_genMasDivision(dataReader);
					tbl_genMasDivisionList.Add(tbl_genMasDivision);
				}
			}
			scon.Close();
			return tbl_genMasDivisionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMasDivision class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMasDivision Maketbl_genMasDivision(SqlDataReader dataReader) {
			tbl_genMasDivision tbl_genMasDivision = new tbl_genMasDivision();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMasDivision.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMasDivision.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMasDivision.Division_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMasDivision.DivisionName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMasDivision.Address = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMasDivision.Telephone1 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genMasDivision.Telephone2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genMasDivision.Extention = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genMasDivision.Fax = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genMasDivision.EmployeeID_HoDiv = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genMasDivision.Remarks = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genMasDivision.Reg_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genMasDivision.IsCanceled = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genMasDivision.UserID_Created = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genMasDivision.UserID_Modified = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genMasDivision.UserID_Canceled = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genMasDivision.TerminalID_Created = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genMasDivision.TerminalID_Modified = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genMasDivision.TerminalID_Canceled = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genMasDivision.Date_Created = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genMasDivision.Date_Modified = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genMasDivision.Date_Canceled = dataReader.GetDateTime(21);
			}

			return tbl_genMasDivision;
		}
		/// <summary>
		/// This makes tbl_genMasDivision datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMasDivision object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMasDivision  tbl_genMasDivision   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_division_ID = new DataColumn("division_ID" , typeof(string));
			DataColumn col_divisionName = new DataColumn("divisionName" , typeof(string));
			DataColumn col_address = new DataColumn("address" , typeof(string));
			DataColumn col_telephone1 = new DataColumn("telephone1" , typeof(string));
			DataColumn col_telephone2 = new DataColumn("telephone2" , typeof(string));
			DataColumn col_extention = new DataColumn("extention" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_employeeID_HoDiv = new DataColumn("employeeID_HoDiv" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_reg_ID = new DataColumn("reg_ID" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_division_ID,col_divisionName,col_address,col_telephone1,col_telephone2,col_extention,col_fax,col_employeeID_HoDiv,col_remarks,col_reg_ID,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMasDivision datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMasDivision object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMasDivision user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["division_ID"] = user.division_ID;
			drow["divisionName"] = user.divisionName;
			drow["address"] = user.address;
			drow["telephone1"] = user.telephone1;
			drow["telephone2"] = user.telephone2;
			drow["extention"] = user.extention;
			drow["fax"] = user.fax;
			drow["employeeID_HoDiv"] = user.employeeID_HoDiv;
			drow["remarks"] = user.remarks;
			drow["reg_ID"] = user.reg_ID;
			drow["isCanceled"] = user.isCanceled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
