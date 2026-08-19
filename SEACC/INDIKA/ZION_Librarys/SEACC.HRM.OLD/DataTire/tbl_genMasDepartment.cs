using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMasDepartment {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string department_ID;
		private string departmentName;
		private string division_ID;
		private string address;
		private string telephone1;
		private string telephone2;
		private string extention;
		private string fax;
		private string employee_ID_HOD;
		private string remarks;
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
		/// Initializes a new instance of the tbl_genMasDepartment class.
		/// </summary>
		public tbl_genMasDepartment() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMasDepartment class.
		/// </summary>
		public tbl_genMasDepartment(string company_ID, string companyBranch_ID, string department_ID, string departmentName, string division_ID, string address, string telephone1, string telephone2, string extention, string fax, string employee_ID_HOD, string remarks, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.department_ID = department_ID;
			this.departmentName = departmentName;
			this.division_ID = division_ID;
			this.address = address;
			this.telephone1 = telephone1;
			this.telephone2 = telephone2;
			this.extention = extention;
			this.fax = fax;
			this.employee_ID_HOD = employee_ID_HOD;
			this.remarks = remarks;
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
		/// Gets or sets the Department_ID value.
		/// </summary>
		public string Department_ID {
			get { return department_ID; }
			set { department_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DepartmentName value.
		/// </summary>
		public string DepartmentName {
			get { return departmentName; }
			set { departmentName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Division_ID value.
		/// </summary>
		public string Division_ID {
			get { return division_ID; }
			set { division_ID = value; }
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
		/// Gets or sets the Employee_ID_HOD value.
		/// </summary>
		public string Employee_ID_HOD {
			get { return employee_ID_HOD; }
			set { employee_ID_HOD = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
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
		/// Saves a record to the tbl_genMasDepartment table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDepartmentInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@departmentName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@address", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@telephone2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@extention", SqlDbType.VarChar,5);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@employee_ID_HOD", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
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
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@departmentName"].Value = departmentName;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@address"].Value = address;
			scom.Parameters["@telephone1"].Value = telephone1;
			scom.Parameters["@telephone2"].Value = telephone2;
			scom.Parameters["@extention"].Value = extention;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@employee_ID_HOD"].Value = employee_ID_HOD;
			scom.Parameters["@remarks"].Value = remarks;
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
		/// Updates a record in the tbl_genMasDepartment table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDepartmentUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@departmentName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@division_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@address", SqlDbType.VarChar,50);
			scom.Parameters.Add("@telephone1", SqlDbType.VarChar,20);
			scom.Parameters.Add("@telephone2", SqlDbType.VarChar,20);
			scom.Parameters.Add("@extention", SqlDbType.VarChar,5);
			scom.Parameters.Add("@fax", SqlDbType.VarChar,50);
			scom.Parameters.Add("@employee_ID_HOD", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
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
			scom.Parameters["@department_ID"].Value = department_ID;
			scom.Parameters["@departmentName"].Value = departmentName;
			scom.Parameters["@division_ID"].Value = division_ID;
			scom.Parameters["@address"].Value = address;
			scom.Parameters["@telephone1"].Value = telephone1;
			scom.Parameters["@telephone2"].Value = telephone2;
			scom.Parameters["@extention"].Value = extention;
			scom.Parameters["@fax"].Value = fax;
			scom.Parameters["@employee_ID_HOD"].Value = employee_ID_HOD;
			scom.Parameters["@remarks"].Value = remarks;
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
		/// Deletes a record from the tbl_genMasDepartment table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDepartmentDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@department_ID"].Value = department_ID;
 
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasDepartment table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDepartmentDeleteAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasDepartment table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDepartmentDeleteAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMasDepartment table.
		/// </summary>
		public static tbl_genMasDepartment Select(string department_ID_Incoming, string company_ID_Incoming, string companyBranch_ID_Incoming)
        {

			tbl_genMasDepartment tbl_genMasDepartmentins = new tbl_genMasDepartment();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDepartmentSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@department_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@department_ID"].Value = department_ID_Incoming;
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMasDepartmentins = Maketbl_genMasDepartment(dataReader);
				} else {
					tbl_genMasDepartmentins = null;
				}
			}
			scon.Close();
			return tbl_genMasDepartmentins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasDepartment table.
		/// </summary>
		public static List<tbl_genMasDepartment> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDepartmentSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMasDepartment> tbl_genMasDepartmentList = new List<tbl_genMasDepartment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasDepartment tbl_genMasDepartment = Maketbl_genMasDepartment(dataReader);
					tbl_genMasDepartmentList.Add(tbl_genMasDepartment);
				}
			}
			scon.Close();
			return tbl_genMasDepartmentList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasDepartment table by a foreign key.
		/// </summary>
		public static List<tbl_genMasDepartment> SelectAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDepartmentSelectAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_genMasDepartment> tbl_genMasDepartmentList = new List<tbl_genMasDepartment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasDepartment tbl_genMasDepartment = Maketbl_genMasDepartment(dataReader);
					tbl_genMasDepartmentList.Add(tbl_genMasDepartment);
				}
			}
			scon.Close();
			return tbl_genMasDepartmentList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasDepartment table by a foreign key.
		/// </summary>
		public static List<tbl_genMasDepartment> SelectAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasDepartmentSelectAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
				List<tbl_genMasDepartment> tbl_genMasDepartmentList = new List<tbl_genMasDepartment>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasDepartment tbl_genMasDepartment = Maketbl_genMasDepartment(dataReader);
					tbl_genMasDepartmentList.Add(tbl_genMasDepartment);
				}
			}
			scon.Close();
			return tbl_genMasDepartmentList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMasDepartment class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMasDepartment Maketbl_genMasDepartment(SqlDataReader dataReader) {
			tbl_genMasDepartment tbl_genMasDepartment = new tbl_genMasDepartment();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMasDepartment.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMasDepartment.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMasDepartment.Department_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMasDepartment.DepartmentName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMasDepartment.Division_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMasDepartment.Address = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genMasDepartment.Telephone1 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genMasDepartment.Telephone2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genMasDepartment.Extention = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genMasDepartment.Fax = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genMasDepartment.Employee_ID_HOD = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genMasDepartment.Remarks = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genMasDepartment.IsCanceled = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genMasDepartment.UserID_Created = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genMasDepartment.UserID_Modified = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genMasDepartment.UserID_Canceled = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genMasDepartment.TerminalID_Created = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genMasDepartment.TerminalID_Modified = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genMasDepartment.TerminalID_Canceled = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genMasDepartment.Date_Created = dataReader.GetDateTime(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genMasDepartment.Date_Modified = dataReader.GetDateTime(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genMasDepartment.Date_Canceled = dataReader.GetDateTime(21);
			}

			return tbl_genMasDepartment;
		}
		/// <summary>
		/// This makes tbl_genMasDepartment datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMasDepartment object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMasDepartment  tbl_genMasDepartment   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_department_ID = new DataColumn("department_ID" , typeof(string));
			DataColumn col_departmentName = new DataColumn("departmentName" , typeof(string));
			DataColumn col_division_ID = new DataColumn("division_ID" , typeof(string));
			DataColumn col_address = new DataColumn("address" , typeof(string));
			DataColumn col_telephone1 = new DataColumn("telephone1" , typeof(string));
			DataColumn col_telephone2 = new DataColumn("telephone2" , typeof(string));
			DataColumn col_extention = new DataColumn("extention" , typeof(string));
			DataColumn col_fax = new DataColumn("fax" , typeof(string));
			DataColumn col_employee_ID_HOD = new DataColumn("employee_ID_HOD" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_department_ID,col_departmentName,col_division_ID,col_address,col_telephone1,col_telephone2,col_extention,col_fax,col_employee_ID_HOD,col_remarks,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMasDepartment datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMasDepartment object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMasDepartment user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["department_ID"] = user.department_ID;
			drow["departmentName"] = user.departmentName;
			drow["division_ID"] = user.division_ID;
			drow["address"] = user.address;
			drow["telephone1"] = user.telephone1;
			drow["telephone2"] = user.telephone2;
			drow["extention"] = user.extention;
			drow["fax"] = user.fax;
			drow["employee_ID_HOD"] = user.employee_ID_HOD;
			drow["remarks"] = user.remarks;
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
