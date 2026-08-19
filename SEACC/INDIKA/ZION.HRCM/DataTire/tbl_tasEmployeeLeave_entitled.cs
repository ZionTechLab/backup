using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasEmployeeLeave_entitled {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string employee_ID;
		private int hrYear_ID;
		private string leaveType_ID;
		private decimal leaves_Entitled;
		private decimal leaves_Utilized;
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
		/// Initializes a new instance of the tbl_tasEmployeeLeave_entitled class.
		/// </summary>
		public tbl_tasEmployeeLeave_entitled() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasEmployeeLeave_entitled class.
		/// </summary>
		public tbl_tasEmployeeLeave_entitled(string company_ID, string companyBranch_ID, string employee_ID, int hrYear_ID, string leaveType_ID, decimal leaves_Entitled, decimal leaves_Utilized, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.employee_ID = employee_ID;
			this.hrYear_ID = hrYear_ID;
			this.leaveType_ID = leaveType_ID;
			this.leaves_Entitled = leaves_Entitled;
			this.leaves_Utilized = leaves_Utilized;
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
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the HrYear_ID value.
		/// </summary>
		public int HrYear_ID {
			get { return hrYear_ID; }
			set { hrYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LeaveType_ID value.
		/// </summary>
		public string LeaveType_ID {
			get { return leaveType_ID; }
			set { leaveType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Leaves_Entitled value.
		/// </summary>
		public decimal Leaves_Entitled {
			get { return leaves_Entitled; }
			set { leaves_Entitled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Leaves_Utilized value.
		/// </summary>
		public decimal Leaves_Utilized {
			get { return leaves_Utilized; }
			set { leaves_Utilized = value; }
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
		/// Saves a record to the tbl_tasEmployeeLeave_entitled table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_entitledInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@hrYear_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leaves_Entitled", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaves_Utilized", SqlDbType.Decimal,9);
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
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@hrYear_ID"].Value = hrYear_ID;
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
			scom.Parameters["@leaves_Entitled"].Value = leaves_Entitled;
			scom.Parameters["@leaves_Utilized"].Value = leaves_Utilized;
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
		/// Updates a record in the tbl_tasEmployeeLeave_entitled table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_entitledUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@hrYear_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leaves_Entitled", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaves_Utilized", SqlDbType.Decimal,9);
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
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@hrYear_ID"].Value = hrYear_ID;
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
			scom.Parameters["@leaves_Entitled"].Value = leaves_Entitled;
			scom.Parameters["@leaves_Utilized"].Value = leaves_Utilized;
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
		/// Deletes a record from the tbl_tasEmployeeLeave_entitled table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_entitledDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@hrYear_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scom.Parameters["@hrYear_ID"].Value = hrYear_ID;
 
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_entitled table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_entitledDeleteAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_entitled table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_HrYear_ID(string company_ID, string companyBranch_ID, int hrYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_entitledDeleteAllByCompany_ID_CompanyBranch_ID_HrYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@hrYear_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@hrYear_ID"].Value = hrYear_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasEmployeeLeave_entitled table.
		/// </summary>
		public static tbl_tasEmployeeLeave_entitled Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string employee_ID_Incoming, int hrYear_ID_Incoming, string leaveType_ID_Incoming){

			tbl_tasEmployeeLeave_entitled tbl_tasEmployeeLeave_entitledins = new tbl_tasEmployeeLeave_entitled();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_entitledSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@hrYear_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			scom.Parameters["@hrYear_ID"].Value = hrYear_ID_Incoming;
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasEmployeeLeave_entitledins = Maketbl_tasEmployeeLeave_entitled(dataReader);
				} else {
					tbl_tasEmployeeLeave_entitledins = null;
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeave_entitledins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_entitled table.
		/// </summary>
		public static List<tbl_tasEmployeeLeave_entitled> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_entitledSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasEmployeeLeave_entitled> tbl_tasEmployeeLeave_entitledList = new List<tbl_tasEmployeeLeave_entitled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeave_entitled tbl_tasEmployeeLeave_entitled = Maketbl_tasEmployeeLeave_entitled(dataReader);
					tbl_tasEmployeeLeave_entitledList.Add(tbl_tasEmployeeLeave_entitled);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeave_entitledList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_entitled table by a foreign key.
		/// </summary>
		public static List<tbl_tasEmployeeLeave_entitled> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_entitledSelectAllByCompany_ID_CompanyBranch_ID_Employee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_tasEmployeeLeave_entitled> tbl_tasEmployeeLeave_entitledList = new List<tbl_tasEmployeeLeave_entitled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeave_entitled tbl_tasEmployeeLeave_entitled = Maketbl_tasEmployeeLeave_entitled(dataReader);
					tbl_tasEmployeeLeave_entitledList.Add(tbl_tasEmployeeLeave_entitled);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeave_entitledList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeave_entitled table by a foreign key.
		/// </summary>
		public static List<tbl_tasEmployeeLeave_entitled> SelectAllByCompany_ID_CompanyBranch_ID_HrYear_ID(string company_ID, string companyBranch_ID, int hrYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_entitledSelectAllByCompany_ID_CompanyBranch_ID_HrYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@hrYear_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@hrYear_ID"].Value = hrYear_ID;
				List<tbl_tasEmployeeLeave_entitled> tbl_tasEmployeeLeave_entitledList = new List<tbl_tasEmployeeLeave_entitled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeave_entitled tbl_tasEmployeeLeave_entitled = Maketbl_tasEmployeeLeave_entitled(dataReader);
					tbl_tasEmployeeLeave_entitledList.Add(tbl_tasEmployeeLeave_entitled);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeave_entitledList;
		}

        //public static List<tbl_tasEmployeeLeave_entitled> SelectAllByEmployee_ID(string employee_ID)
        //{

        //    SqlConnection scon = DBHandling.GetConnection();
        //    SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeave_entitledSelectAllByEmployee_ID", scon);
        //    scom.CommandType = CommandType.StoredProcedure;
        //    scon.Open();

        //    scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
        //    scom.Parameters["@employee_ID"].Value = employee_ID;
        //    List<tbl_tasEmployeeLeave_entitled> tbl_tasEmployeeLeave_entitledList = new List<tbl_tasEmployeeLeave_entitled>();
        //    using (SqlDataReader dataReader = scom.ExecuteReader())
        //    {
        //        while (dataReader.Read())
        //        {
        //            tbl_tasEmployeeLeave_entitled tbl_tasEmployeeLeave_entitled = Maketbl_tasEmployeeLeave_entitled(dataReader);
        //            tbl_tasEmployeeLeave_entitledList.Add(tbl_tasEmployeeLeave_entitled);
        //        }
        //    }
        //    scon.Close();
        //    return tbl_tasEmployeeLeave_entitledList;
        //}

        /// <summary>
        /// Creates a new instance of the tbl_tasEmployeeLeave_entitled class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_tasEmployeeLeave_entitled Maketbl_tasEmployeeLeave_entitled(SqlDataReader dataReader) {
			tbl_tasEmployeeLeave_entitled tbl_tasEmployeeLeave_entitled = new tbl_tasEmployeeLeave_entitled();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasEmployeeLeave_entitled.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasEmployeeLeave_entitled.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasEmployeeLeave_entitled.Employee_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasEmployeeLeave_entitled.HrYear_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasEmployeeLeave_entitled.LeaveType_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasEmployeeLeave_entitled.Leaves_Entitled = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasEmployeeLeave_entitled.Leaves_Utilized = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasEmployeeLeave_entitled.IsCanceled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasEmployeeLeave_entitled.UserID_Created = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasEmployeeLeave_entitled.UserID_Modified = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasEmployeeLeave_entitled.UserID_Canceled = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasEmployeeLeave_entitled.TerminalID_Created = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasEmployeeLeave_entitled.TerminalID_Modified = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasEmployeeLeave_entitled.TerminalID_Canceled = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasEmployeeLeave_entitled.Date_Created = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_tasEmployeeLeave_entitled.Date_Modified = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_tasEmployeeLeave_entitled.Date_Canceled = dataReader.GetDateTime(16);
			}

			return tbl_tasEmployeeLeave_entitled;
		}
		/// <summary>
		/// This makes tbl_tasEmployeeLeave_entitled datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeLeave_entitled object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasEmployeeLeave_entitled  tbl_tasEmployeeLeave_entitled   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_hrYear_ID = new DataColumn("hrYear_ID" , typeof(int));
			DataColumn col_leaveType_ID = new DataColumn("leaveType_ID" , typeof(string));
			DataColumn col_leaves_Entitled = new DataColumn("leaves_Entitled" , typeof(decimal));
			DataColumn col_leaves_Utilized = new DataColumn("leaves_Utilized" , typeof(decimal));
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
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_employee_ID,col_hrYear_ID,col_leaveType_ID,col_leaves_Entitled,col_leaves_Utilized,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasEmployeeLeave_entitled datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeLeave_entitled object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasEmployeeLeave_entitled user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["hrYear_ID"] = user.hrYear_ID;
			drow["leaveType_ID"] = user.leaveType_ID;
			drow["leaves_Entitled"] = user.leaves_Entitled;
			drow["leaves_Utilized"] = user.leaves_Utilized;
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
